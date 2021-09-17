﻿using QS.DomainModel.UoW;
using QS.Project.Journal;
using QS.Project.Journal.EntitySelector;
using QS.Project.Services;
using System.Collections.Generic;
using Vodovoz.Dialogs.OrderWidgets;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.EntityRepositories.Undeliveries;
using Vodovoz.Filters.ViewModels;
using Vodovoz.JournalViewers;
using Vodovoz.JournalViewModels;
using Vodovoz.Parameters;

namespace Vodovoz.TempAdapters
{
	public class OrderSelectorFactory : IOrderSelectorFactory
	{
		private readonly OrderJournalFilterViewModel _orderJournalFilter;

		public OrderSelectorFactory(OrderJournalFilterViewModel orderFilter = null)
		{
			_orderJournalFilter = orderFilter;
		}

		public IEntitySelector CreateOrderSelectorForDocument(bool IsOnlineStoreOrders, IEnumerable<OrderStatus> orderStatuses)
		{
			OrderForMovDocJournalFilterViewModel orderFilterVM = new OrderForMovDocJournalFilterViewModel();
			orderFilterVM.IsOnlineStoreOrders = IsOnlineStoreOrders;
			orderFilterVM.OrderStatuses = orderStatuses;

			OrderForMovDocJournalViewModel vm = new OrderForMovDocJournalViewModel(
				orderFilterVM,
				UnitOfWorkFactory.GetDefaultFactory,
				ServicesConfig.CommonServices
			) {
				SelectionMode = JournalSelectionMode.Multiple
			};

			return vm;
		}

		public IEntityAutocompleteSelectorFactory CreateOrderAutocompleteSelectorFactory()
		{
			return new EntityAutocompleteSelectorFactory<OrderJournalViewModel>(
				typeof(Order),
				CreateOrderJournalViewModel
			);
		}

		public OrderJournalViewModel CreateOrderJournalViewModel()
		{
			var subdivisionJournalFactory = new SubdivisionJournalFactory();
			var counterpartyJournalFactory = new CounterpartyJournalFactory();
			var deliveryPointJournalFactory = new DeliveryPointJournalFactory();
			var nomenclatureRepository = new NomenclatureRepository(new NomenclatureParametersProvider(new ParametersProvider()));
			var userRepository = new UserRepository();

			return new OrderJournalViewModel(
				_orderJournalFilter ?? new OrderJournalFilterViewModel(counterpartyJournalFactory, deliveryPointJournalFactory),
				UnitOfWorkFactory.GetDefaultFactory,
				ServicesConfig.CommonServices,
				VodovozGtkServicesConfig.EmployeeService,
				nomenclatureRepository,
				userRepository,
				new OrderSelectorFactory(),
				new EmployeeJournalFactory(),
				counterpartyJournalFactory,
				new DeliveryPointJournalFactory(),
				subdivisionJournalFactory,
				new GtkTabsOpener(),
				new UndeliveredOrdersJournalOpener(),
				new NomenclatureSelectorFactory(),
				new UndeliveredOrdersRepository()
			);
		}
	}
}
