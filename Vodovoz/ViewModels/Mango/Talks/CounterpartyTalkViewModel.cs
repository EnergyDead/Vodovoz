﻿using System;
using System.Collections.Generic;
using System.Linq;
using QS.Dialog;
using QS.DomainModel.UoW;
using QS.Navigation;
using QS.Project.Domain;
using QSReport;
using Vodovoz.Dialogs.Sale;
using Vodovoz.Domain.Client;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.EntityRepositories.Logistic;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.FilterViewModels.Goods;
using Vodovoz.Infrastructure.Mango;
using Vodovoz.JournalNodes;
using Vodovoz.JournalViewModels;
using Vodovoz.Parameters;
using Vodovoz.Services;
using Vodovoz.TempAdapters;
using Vodovoz.ViewModels.Complaints;
using Vodovoz.Views.Mango;

namespace Vodovoz.ViewModels.Mango.Talks
{
	public partial class CounterpartyTalkViewModel : TalkViewModelBase
	{
		private readonly ITdiCompatibilityNavigation _tdiNavigation;
		private readonly IRouteListRepository _routedListRepository;
		private readonly IInteractiveService _interactiveService;
		private readonly IOrderParametersProvider _orderParametersProvider;
		private readonly IOrderRepository _orderRepository;
		private readonly IParametersProvider _parametersProvider;
		private readonly IUnitOfWork _uow;

		public List<CounterpartyOrderViewModel> CounterpartyOrdersViewModels { get; private set; } = new List<CounterpartyOrderViewModel>();

		public Counterparty currentCounterparty { get;private set; }
		public event Action CounterpartyOrdersModelsUpdateEvent = () => { };

		public CounterpartyTalkViewModel(
			INavigationManager navigation,
			ITdiCompatibilityNavigation tdinavigation,
			IUnitOfWorkFactory unitOfWorkFactory,
			IRouteListRepository routedListRepository,
			IInteractiveService interactiveService,
			IOrderParametersProvider orderParametersProvider, 
			MangoManager manager,
			IOrderRepository orderRepository,
			IParametersProvider parametersProvider) : base(navigation, manager)
		{
			NavigationManager = navigation ?? throw new ArgumentNullException(nameof(navigation));
			_tdiNavigation = tdinavigation ?? throw new ArgumentNullException(nameof(navigation));

			_routedListRepository = routedListRepository;
			_interactiveService = interactiveService ?? throw new ArgumentNullException(nameof(interactiveService));
			_orderParametersProvider = orderParametersProvider ?? throw new ArgumentNullException(nameof(orderParametersProvider));
			_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
			_parametersProvider = parametersProvider ?? throw new ArgumentNullException(nameof(parametersProvider));
			_uow = unitOfWorkFactory.CreateWithoutRoot();

			if(ActiveCall.CounterpartyIds.Any())
			{
				var clients = _uow.GetById<Counterparty>(ActiveCall.CounterpartyIds);
				
				foreach(Counterparty client in clients)
				{
					CounterpartyOrderViewModel model = new CounterpartyOrderViewModel(client, unitOfWorkFactory, tdinavigation,
						routedListRepository, MangoManager, _orderParametersProvider, _parametersProvider);
					CounterpartyOrdersViewModels.Add(model);
				}
				
				currentCounterparty = CounterpartyOrdersViewModels.FirstOrDefault().Client;
			} else
				throw new InvalidProgramException("Открыт диалог разговора с имеющимся контрагентом, но ни одного id контрагента не найдено.");
		}

		public IDictionary<string, CounterpartyOrderView> GetCounterpartyViewModels()
		{
			return null;
		}
		#region Взаимодействие с Mangos

		#endregion

		#region Действия View

		public void UpadateCurrentCounterparty(Counterparty counterparty)
		{
			currentCounterparty = counterparty;

		}
		public void NewClientCommand()
		{
			var page = _tdiNavigation.OpenTdiTab<CounterpartyDlg>(this);
			var tab = page.TdiTab as CounterpartyDlg;
			page.PageClosed += NewCounerpatry_PageClosed;
		}

		public void ExistingClientCommand()
		{
			var page = NavigationManager.OpenViewModel<CounterpartyJournalViewModel>(null);
			page.ViewModel.SelectionMode = QS.Project.Journal.JournalSelectionMode.Single;
			page.ViewModel.OnEntitySelectedResult += ExistingCounterparty_PageClosed;
		}

		void NewCounerpatry_PageClosed(object sender, PageClosedEventArgs e)
		{
			if(e.CloseSource == CloseSource.Save) {
				List<Counterparty> clients = new List<Counterparty>();
				Counterparty client = ((sender as TdiTabPage).TdiTab as CounterpartyDlg).Counterparty;
				client.Phones.Add(ActiveCall.Phone);
				clients.Add(client);
				_uow.Save<Counterparty>(client);
				
				CounterpartyOrderViewModel model = 
					new CounterpartyOrderViewModel(client, UnitOfWorkFactory.GetDefaultFactory, _tdiNavigation, _routedListRepository,
						MangoManager, _orderParametersProvider, _parametersProvider);
				
				CounterpartyOrdersViewModels.Add(model);
				currentCounterparty = client;
				MangoManager.AddCounterpartyToCall(client.Id);
				CounterpartyOrdersModelsUpdateEvent();
			}
			(sender as IPage).PageClosed -= NewCounerpatry_PageClosed;
		}

		void ExistingCounterparty_PageClosed(object sender, QS.Project.Journal.JournalSelectedNodesEventArgs e)
		{
			var counterpartyNode = e.SelectedNodes.First() as CounterpartyJournalNode;
			Counterparty client = _uow.GetById<Counterparty>(counterpartyNode.Id);
			if(!CounterpartyOrdersViewModels.Any(c => c.Client.Id == client.Id)) {
				if(_interactiveService.Question($"Добавить телефон к контрагенту {client.Name} ?", "Телефон контрагента")) {
					client.Phones.Add(ActiveCall.Phone);
					_uow.Save<Counterparty>(client);
					_uow.Commit();
				}
				
				CounterpartyOrderViewModel model =
					new CounterpartyOrderViewModel(client, UnitOfWorkFactory.GetDefaultFactory, _tdiNavigation, _routedListRepository,
						MangoManager, _orderParametersProvider, _parametersProvider);
				
				CounterpartyOrdersViewModels.Add(model);
				currentCounterparty = client;
				MangoManager.AddCounterpartyToCall(client.Id);
				CounterpartyOrdersModelsUpdateEvent();
			}
		}

		public void NewOrderCommand()
		{
			if (currentCounterparty.IsForRetail)
			{
				_interactiveService.ShowMessage(ImportanceLevel.Warning, "Заказ поступает от контрагента дистрибуции");
			}
			var model = CounterpartyOrdersViewModels.Find(m => m.Client.Id == currentCounterparty.Id);
			IPage page = _tdiNavigation.OpenTdiTab<OrderDlg, Counterparty>(null, currentCounterparty);
			page.PageClosed += (sender, e) => { model.RefreshOrders(); };
		}


		public void AddComplainCommand()
		{
			var parameters = new Dictionary<string, object>
			{
				{ "client", currentCounterparty },
				{ "uowBuilder", EntityUoWBuilder.ForCreate() },
				{ "phone", "+7" + ActiveCall.Phone.Number }
			};
			
			_tdiNavigation.OpenTdiTabOnTdiNamedArgs<CreateComplaintViewModel>(null,parameters);
		}

		public void BottleActCommand()
		{
			var parameters = new Vodovoz.Reports.RevisionBottlesAndDeposits(_orderRepository);
			parameters.SetCounterparty(currentCounterparty);
			ReportViewDlg dialog = _tdiNavigation.OpenTdiTab<ReportViewDlg, IParametersWidget>(null, parameters) as ReportViewDlg;
			parameters.OnUpdate(true);
			
		}

		public void StockBalanceCommand()
		{
			NomenclatureStockFilterViewModel filter = new NomenclatureStockFilterViewModel(new WarehouseSelectorFactory());
			NavigationManager.OpenViewModel<NomenclatureStockBalanceJournalViewModel, NomenclatureStockFilterViewModel>(null, filter);
		}

		public void CostAndDeliveryIntervalCommand(DeliveryPoint point)
		{
			_tdiNavigation.OpenTdiTab<DeliveryPriceDlg, DeliveryPoint>(null, point);
		}

		#endregion
	}
}
