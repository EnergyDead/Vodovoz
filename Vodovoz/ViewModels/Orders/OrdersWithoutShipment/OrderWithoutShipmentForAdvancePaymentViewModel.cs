﻿using System;
using System.Linq;
using Gamma.Utilities;
using QS.Commands;
using QS.Dialog;
using QS.DomainModel.UoW;
using QS.Navigation;
using QS.Project.Domain;
using QS.Project.Services;
using QS.Services;
using QS.Tdi;
using QS.ViewModels;
using QSOrmProject;
using QSReport;
using Vodovoz.Dialogs.Email;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Orders.OrdersWithoutShipment;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.FilterViewModels.Goods;
using Vodovoz.Infrastructure.Services;
using Vodovoz.Parameters;
using Vodovoz.TempAdapters;
using Vodovoz.ViewModels.Journals.JournalViewModels.Goods;

namespace Vodovoz.ViewModels.Orders.OrdersWithoutShipment
{
	public class OrderWithoutShipmentForAdvancePaymentViewModel : EntityTabViewModelBase<OrderWithoutShipmentForAdvancePayment>, ITdiTabAddedNotifier
	{
		private readonly INomenclatureSelectorFactory _nomenclatureSelectorFactory;
		private readonly IParametersProvider _parametersProvider;

		private object selectedItem;
		public object SelectedItem {
			get => selectedItem;
			set => SetField(ref selectedItem, value);
		}
		
		public SendDocumentByEmailViewModel SendDocViewModel { get; set; }
		
		public bool IsDocumentSent => Entity.IsBillWithoutShipmentSent;
		
		public Action<string> OpenCounterpartyJournal;
		public IEntityUoWBuilder EntityUoWBuilder { get; }

		public OrderWithoutShipmentForAdvancePaymentViewModel(
			IEntityUoWBuilder uowBuilder,
			IUnitOfWorkFactory uowFactory,
			ICommonServices commonServices,
			IEmployeeService employeeService,
			INomenclatureSelectorFactory nomenclatureSelectorFactory,
			IOrderRepository orderRepository,
			IParametersProvider parametersProvider) : base(uowBuilder, uowFactory, commonServices)
		{
			_parametersProvider = parametersProvider ?? throw new ArgumentNullException(nameof(parametersProvider));
			OrderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
			_nomenclatureSelectorFactory = nomenclatureSelectorFactory ?? throw new ArgumentNullException(nameof(nomenclatureSelectorFactory));
			
			bool canCreateBillsWithoutShipment = 
				CommonServices.PermissionService.ValidateUserPresetPermission("can_create_bills_without_shipment", CurrentUser.Id);
			var currentEmployee = employeeService.GetEmployeeForUser(UoW, UserService.CurrentUserId);
			
			if (uowBuilder.IsNewEntity)
			{
				if (canCreateBillsWithoutShipment)
				{
					if (!AskQuestion("Вы действительно хотите создать счет без отгрузки на предоплату?"))
					{
						AbortOpening();
					}
					else
					{
						Entity.Author = currentEmployee;
					}
				}
				else
				{
					AbortOpening("У Вас нет прав на выставление счетов без отгрузки.");
				}
			}
			
			TabName = "Счет без отгрузки на предоплату";
			EntityUoWBuilder = uowBuilder;
			
			SendDocViewModel = new SendDocumentByEmailViewModel(
				new EmailRepository(), currentEmployee, commonServices.InteractiveService, _parametersProvider, UoW);
		}
		
		public IOrderRepository OrderRepository { get; }

		#region Commands

		private DelegateCommand addForSaleCommand;
		public DelegateCommand AddForSaleCommand => addForSaleCommand ?? (addForSaleCommand = new DelegateCommand(
			() => {

				if(!CanAddNomenclaturesToOrder())
					return;

				var defaultCategory = NomenclatureCategory.water;
				if(CurrentUserSettings.Settings.DefaultSaleCategory.HasValue)
					defaultCategory = CurrentUserSettings.Settings.DefaultSaleCategory.Value;

				var nomenclatureFilter = new NomenclatureFilterViewModel();
				nomenclatureFilter.SetAndRefilterAtOnce(
					x => x.AvailableCategories = Nomenclature.GetCategoriesForSaleToOrder(),
					x => x.SelectCategory = defaultCategory,
					x => x.SelectSaleCategory = SaleCategory.forSale,
					x => x.RestrictArchive = false
				);
				
				var journalViewModel = _nomenclatureSelectorFactory.CreateNomenclaturesJournal(nomenclatureFilter);
				journalViewModel.AdditionalJournalRestriction = new NomenclaturesForOrderJournalRestriction(ServicesConfig.CommonServices);
				journalViewModel.TabName = "Номенклатура на продажу";
				
				journalViewModel.OnEntitySelectedResult += (s, ea) =>
				{
					var selectedNode = ea.SelectedNodes.FirstOrDefault();
					if(selectedNode == null)
					{
						return;
					}

					TryAddNomenclature(UoWGeneric.Session.Get<Nomenclature>(selectedNode.Id));
				};
				TabParent.AddSlaveTab(this, journalViewModel);
			},
			() => true
		));

		private DelegateCommand cancelCommand;
		public DelegateCommand CancelCommand => cancelCommand ?? (cancelCommand = new DelegateCommand(
			() =>Close(true, CloseSource.Cancel),
			() => true
		));

		private DelegateCommand deleteItemCommand;
		public DelegateCommand DeleteItemCommand => deleteItemCommand ?? (deleteItemCommand = new DelegateCommand(
			() => {
				var item = SelectedItem as OrderWithoutShipmentForAdvancePaymentItem;
				Entity.RemoveItem(item);
			},
			() => SelectedItem != null
		));

		private DelegateCommand openBillCommand;
		public DelegateCommand OpenBillCommand => openBillCommand ?? (openBillCommand = new DelegateCommand(
			() =>
			{
				string whatToPrint = "документа \"" + Entity.Type.GetEnumTitle() + "\"";
				
				if (UoWGeneric.HasChanges &&
				    CommonDialogs.SaveBeforePrint(typeof(OrderWithoutShipmentForAdvancePayment), whatToPrint))
				{
					if (Save(false))
						TabParent.AddTab(DocumentPrinter.GetPreviewTab(Entity), this, false);
				}

				if(!UoWGeneric.HasChanges && Entity.Id > 0)
					TabParent.AddTab(DocumentPrinter.GetPreviewTab(Entity), this, false);
			},
			() => true
		));
		
		#endregion Commands

		public void OnTabAdded()
		{
			if(EntityUoWBuilder.IsNewEntity)
				OpenCounterpartyJournal?.Invoke(string.Empty);
		}

		bool CanAddNomenclaturesToOrder()
		{
			if(Entity.Client == null) {
				CommonServices.InteractiveService.ShowMessage(ImportanceLevel.Warning,"Для добавления товара на продажу должен быть выбран клиент.");
				return false;
			}

			return true;
		}

		void TryAddNomenclature(Nomenclature nomenclature, int count = 0, decimal discount = 0, DiscountReason discountReason = null)
		{
			if(nomenclature.OnlineStore != null && !CommonServices.CurrentPermissionService
				.ValidatePresetPermission("can_add_online_store_nomenclatures_to_order"))
			{
				CommonServices.InteractiveService.ShowMessage(
					ImportanceLevel.Warning, "У вас недостаточно прав для добавления на продажу номенклатуры интернет магазина");
				return;
			}

			Entity.AddNomenclature(nomenclature, count, discount, false, discountReason);
		}
		
		public void OnEntityViewModelEntryChanged(object sender, EventArgs e)
		{
			var email = Entity.GetEmailAddressForBill();

			if (email != null)
				SendDocViewModel.Update(Entity, email.Address);
			else
				SendDocViewModel.Update(Entity, string.Empty);
		}
	}
}
