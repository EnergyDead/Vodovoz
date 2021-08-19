using QS.DomainModel.UoW;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Project.Services;
using System.Collections.Generic;
using Vodovoz.Dialogs.OrderWidgets;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.Filters.ViewModels;
using Vodovoz.FilterViewModels.Goods;
using Vodovoz.FilterViewModels.Organization;
using Vodovoz.JournalSelector;
using Vodovoz.JournalViewers;
using Vodovoz.JournalViewModels;
using Vodovoz.Parameters;
using Vodovoz.ViewModels.Journals.FilterViewModels.Orders;
using Vodovoz.ViewModels.Journals.JournalFactories;

namespace Vodovoz.TempAdapters
{
	public class OrderSelectorFactory : IOrderSelectorFactory
	{
		public IEntitySelector CreateOrderSelectorForDocument(bool IsOnlineStoreOrders, IEnumerable<OrderStatus> orderStatuses)
		{
			OrderForMovDocJournalFilterViewModel orderFilterVM = new OrderForMovDocJournalFilterViewModel();
			orderFilterVM.IsOnlineStoreOrders = IsOnlineStoreOrders;
			orderFilterVM.OrderStatuses = orderStatuses;

			OrderForMovDocJournalViewModel vm = new OrderForMovDocJournalViewModel(
				journalActions,
				orderFilterVM,
				UnitOfWorkFactory.GetDefaultFactory,
				ServicesConfig.CommonServices
			) 
			{
				SelectionMode = JournalSelectionMode.Multiple
			};

			return vm;
		}

		public IEntityAutocompleteSelectorFactory CreateOrderAutocompleteSelectorFactory()
		{
			ISubdivisionJournalFactory subdivisionJournalFactory = new SubdivisionJournalFactory();

			var nomenclatureRepository = new NomenclatureRepository(new NomenclatureParametersProvider());

			IEntityAutocompleteSelectorFactory counterpartySelectorFactory =
				new DefaultEntityAutocompleteSelectorFactory<Counterparty, CounterpartyJournalViewModel,
					CounterpartyJournalFilterViewModel>(ServicesConfig.CommonServices);

			IEntityAutocompleteSelectorFactory nomenclatureSelectorFactory =
				new NomenclatureAutoCompleteSelectorFactory<Nomenclature, NomenclaturesJournalViewModel>(ServicesConfig.CommonServices,
					new NomenclatureFilterViewModel(), counterpartySelectorFactory, nomenclatureRepository,
					UserSingletonRepository.GetInstance());

			OrderJournalFilterViewModel orderJournalFilterViewModel = new OrderJournalFilterViewModel();

			return new EntityAutocompleteSelectorFactory<OrderJournalViewModel>(typeof(Order), () =>
			{
				return new OrderJournalViewModel(
					orderJournalFilterViewModel,
					UnitOfWorkFactory.GetDefaultFactory,
					ServicesConfig.CommonServices,
					VodovozGtkServicesConfig.EmployeeService,
					nomenclatureSelectorFactory,
					counterpartySelectorFactory,
					nomenclatureRepository,
					UserSingletonRepository.GetInstance(),
					new OrderSelectorFactory(),
					new EmployeeJournalFactory(),
					new CounterpartyJournalFactory(),
					new DeliveryPointJournalFactory(),
					subdivisionJournalFactory,
					new GtkTabsOpener(),
					new UndeliveredOrdersJournalOpener(),
					new SalesPlanJournalFactory(),
					new NomenclatureSelectorFactory()
					);
			});
		}
	}
}
