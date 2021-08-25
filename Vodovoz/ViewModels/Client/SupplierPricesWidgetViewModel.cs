﻿using System;
using System.Linq;
using QS.Commands;
using QS.DomainModel.UoW;
using QS.Project.Journal;
using QS.Project.Search;
using QS.Services;
using QS.Tdi;
using QS.ViewModels;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Goods;
using Vodovoz.FilterViewModels.Goods;
using Vodovoz.TempAdapters;

namespace Vodovoz.ViewModels.Client
{
	public class SupplierPricesWidgetViewModel : EntityWidgetViewModelBase<Counterparty>
	{
		private readonly ITdiTab _dialogTab;
		private readonly INomenclatureSelectorFactory _nomenclatureSelectorFactory;
		public event EventHandler ListContentChanged;

		public IJournalSearch Search { get; private set; }

		public SupplierPricesWidgetViewModel(
			Counterparty entity, 
			IUnitOfWork uow, 
			ITdiTab dialogTab, 
			ICommonServices commonServices,
			INomenclatureSelectorFactory nomenclatureSelectorFactory) : base(entity, commonServices)
		{
			_dialogTab = dialogTab ?? throw new ArgumentNullException(nameof(dialogTab));
			UoW = uow ?? throw new ArgumentNullException(nameof(uow));
			this._nomenclatureSelectorFactory =
				nomenclatureSelectorFactory ?? throw new ArgumentNullException(nameof(nomenclatureSelectorFactory));
			
			CreateCommands();
			RefreshPrices();
			
			Search = new SearchViewModel();
			Search.OnSearch += (sender, e) => RefreshPrices();
			Entity.ObservableSuplierPriceItems.ElementAdded += (aList, aIdx) => RefreshPrices();
			Entity.ObservableSuplierPriceItems.ElementRemoved += (aList, aIdx, aObject) => RefreshPrices();
		}

		void CreateCommands()
		{
			CreateAddItemCommand();
			CreateRemoveItemCommand();
			CreateEditItemCommand();
		}

		void RefreshPrices()
		{
			Entity.SupplierPriceListRefresh(Search?.SearchValues);
			ListContentChanged?.Invoke(this, new EventArgs());
		}
		
		public bool CanAdd { get; set; } = true;
		public bool CanEdit { get; set; } = false;//задача редактирования пока не актуальна

		bool canRemove = false;
		public bool CanRemove {
			get => canRemove;
			set => SetField(ref canRemove, value);
		}
		#region Commands

		#region AddItemCommand

		public DelegateCommand AddItemCommand { get; private set; }

		private void CreateAddItemCommand()
		{
			AddItemCommand = new DelegateCommand(
				() => {
					var existingNomenclatures = Entity.ObservableSuplierPriceItems.Select(i => i.NomenclatureToBuy.Id).Distinct();
					
					var filter = new NomenclatureFilterViewModel
					{
						HidenByDefault = true,
						RestrictedExcludedIds = existingNomenclatures.ToArray()
					};

					var journalViewModel = _nomenclatureSelectorFactory.CreateNomenclaturesJournal(filter);

					journalViewModel.OnEntitySelectedResult += (sender, e) => {
						var selectedNode = e.SelectedNodes.FirstOrDefault();
						if(selectedNode == null)
							return;
						Entity.AddSupplierPriceItems(UoW.GetById<Nomenclature>(selectedNode.Id));
					};
					_dialogTab.TabParent.AddSlaveTab(_dialogTab, journalViewModel);
				},
				() => true
			);
		}

		#endregion AddItemCommand

		#region RemoveItemCommand

		public DelegateCommand<ISupplierPriceNode> RemoveItemCommand { get; private set; }

		private void CreateRemoveItemCommand()
		{
			RemoveItemCommand = new DelegateCommand<ISupplierPriceNode>(
				n => Entity.RemoveNomenclatureWithPrices(n.NomenclatureToBuy.Id),
				n => CanRemove
			);
		}

		#endregion RemoveItemCommand

		#region EditItemCommand

		public DelegateCommand EditItemCommand { get; private set; }

		private void CreateEditItemCommand()
		{
			EditItemCommand = new DelegateCommand(
				() => throw new NotImplementedException(nameof(EditItemCommand)),
				() => false
			);
		}

		#endregion EditItemCommand

		#endregion Commands

	}
}
