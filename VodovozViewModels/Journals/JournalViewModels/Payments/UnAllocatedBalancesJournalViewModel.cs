﻿using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using QS.Dialog;
using QS.DomainModel.UoW;
using QS.Navigation;
using QS.Project.Journal;
using QS.Project.Services;
using QS.Services;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Operations;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Organizations;
using Vodovoz.Domain.Payments;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.EntityRepositories.Payments;
using Vodovoz.Filters.ViewModels;
using Vodovoz.Services;
using Vodovoz.ViewModels.Payments;
using VodOrder = Vodovoz.Domain.Orders.Order;

namespace Vodovoz.ViewModels.Journals.JournalViewModels.Payments
{
	public class UnAllocatedBalancesJournalViewModel
		: EntityJournalViewModelBase<Payment, PaymentsJournalViewModel, UnAllocatedBalancesJournalNode>
	{
		private readonly IPaymentsRepository _paymentsRepository;
		private readonly int _closingDocumentDeliveryScheduleId;
		private bool _canEdit;

		public UnAllocatedBalancesJournalViewModel(
			IUnitOfWorkFactory unitOfWorkFactory,
			IInteractiveService interactiveService,
			IPaymentsRepository paymentsRepository,
			INavigationManager navigationManager,
			ICurrentPermissionService currentPermissionService,
			IDeliveryScheduleParametersProvider deliveryScheduleParametersProvider,
			IDeleteEntityService deleteEntityService = null)
			: base(unitOfWorkFactory, interactiveService, navigationManager, deleteEntityService, currentPermissionService)
		{
			if(navigationManager == null)
			{
				throw new ArgumentNullException(nameof(navigationManager));
			}
			if(currentPermissionService == null)
			{
				throw new ArgumentNullException(nameof(currentPermissionService));
			}

			_paymentsRepository = paymentsRepository ?? throw new ArgumentNullException(nameof(paymentsRepository));

			_closingDocumentDeliveryScheduleId =
				(deliveryScheduleParametersProvider ?? throw new ArgumentNullException(nameof(deliveryScheduleParametersProvider)))
				.ClosingDocumentDeliveryScheduleId;
			
			TabName = "Журнал нераспределенных балансов";

			CreateAutomaticallyAllocationAction();
		}

		private void CreateAutomaticallyAllocationAction()
		{
			var automaticallyAllocationAction = new JournalAction("Автоматическое распределение положительного баланса",
				(selected) => _canEdit && selected.Any(),
				(selected) => true,
				(selected) =>
				{
					var ctorTypes = new[]
					{
						typeof(IUnitOfWork),
						typeof(UnAllocatedBalancesJournalNode),
						typeof(int),
						typeof(IList<UnAllocatedBalancesJournalNode>)
					};
					var objs = new object[]{
						UoW,
						selected.OfType<UnAllocatedBalancesJournalNode>().ToArray()[0],
						_closingDocumentDeliveryScheduleId,
						Items
					};
					
					ShowInfoMessage("Будет произведен разнос всех нераспределенных платежей по неоплаченным заказам, начиная с самого раннего");
					var page = NavigationManager.OpenViewModelTypedArgs<AutomaticallyAllocationBalanceWindowViewModel>(
						this, ctorTypes, objs, OpenPageOptions.IgnoreHash);
					page.PageClosed += (sender, args) => Refresh();
				}
			);
			NodeActionsList.Add(automaticallyAllocationAction);
		}
		
		protected override void CreateNodeActions()
		{
			NodeActionsList.Clear();
			
			_canEdit = CurrentPermissionService.ValidateEntityPermission(typeof(Payment)).CanUpdate;
			
			var editAction = new JournalAction("Изменить",
				(selected) => _canEdit && selected.Any(),
				(selected) => VisibleEditAction,
				(selected) => selected.OfType<UnAllocatedBalancesJournalNode>().ToList().ForEach(EditEntityDialog)
			);
			NodeActionsList.Add(editAction);

			if(SelectionMode == JournalSelectionMode.None)
			{
				RowActivatedAction = editAction;
			}
		}

		protected override IQueryOver<Payment> ItemsQuery(IUnitOfWork uow)
		{
			UnAllocatedBalancesJournalNode resultAlias = null;
			VodOrder orderAlias = null;
			VodOrder orderAlias2 = null;
			OrderItem orderItemAlias = null;
			PaymentItem paymentItemAlias = null;
			Counterparty counterpartyAlias = null;
			Organization organizationAlias = null;
			CounterpartyContract counterpartyContractAlias = null;
			Organization orderOrganizationAlias = null;
			DeliverySchedule deliveryScheduleAlias = null;
			DeliverySchedule deliveryScheduleAlias2 = null;
			CashlessMovementOperation cashlessMovementOperationAlias = null;

			var query = uow.Session.QueryOver<Payment>()
				.Inner.JoinAlias(cmo => cmo.Counterparty, () => counterpartyAlias)
				.Inner.JoinAlias(cmo => cmo.Organization, () => organizationAlias);

			var income = QueryOver.Of<CashlessMovementOperation>()
				.Where(cmo => cmo.Counterparty.Id == counterpartyAlias.Id)
				.And(cmo => cmo.Organization.Id == organizationAlias.Id)
				.Select(Projections.Sum<CashlessMovementOperation>(cmo => cmo.Income));
			
			var expense = QueryOver.Of<CashlessMovementOperation>()
				.Where(cmo => cmo.Counterparty.Id == counterpartyAlias.Id)
				.And(cmo => cmo.Organization.Id == organizationAlias.Id)
				.Select(Projections.Sum<CashlessMovementOperation>(cmo => cmo.Expense));

			var balanceProjection = Projections.SqlFunction(new SQLFunctionTemplate(NHibernateUtil.Decimal, "?1 - ?2"),
					NHibernateUtil.Decimal, new IProjection[] {
						Projections.SubQuery(income),
						Projections.SubQuery(expense)});

			var orderSumProjection = OrderRepository.GetOrderSumProjection(orderItemAlias);
			
			var totalNotPaidOrders = QueryOver.Of(() => orderAlias)
				.Inner.JoinAlias(o => o.OrderItems, () => orderItemAlias)
				.Inner.JoinAlias(o => o.Contract, () => counterpartyContractAlias)
				.Inner.JoinAlias(() => counterpartyContractAlias.Organization, () => orderOrganizationAlias)
				.Inner.JoinAlias(o => o.DeliverySchedule, () => deliveryScheduleAlias)
				.Where(() => orderAlias.Client.Id == counterpartyAlias.Id)
				.And(() => orderOrganizationAlias.Id == organizationAlias.Id)
				.And(() => orderAlias.OrderStatus == OrderStatus.Shipped
					|| orderAlias.OrderStatus == OrderStatus.UnloadingOnStock
					|| orderAlias.OrderStatus == OrderStatus.Closed)
				.And(() => orderAlias.PaymentType == PaymentType.cashless)
				.And(() => orderAlias.OrderPaymentStatus != OrderPaymentStatus.Paid)
				.And(() => deliveryScheduleAlias.Id != _closingDocumentDeliveryScheduleId)
				.Select(orderSumProjection)
				.Where(Restrictions.Gt(orderSumProjection, 0));

			var totalPayPartiallyPaidOrders = QueryOver.Of(() => paymentItemAlias)
				.JoinEntityAlias(() => orderAlias2, () => paymentItemAlias.Order.Id == orderAlias2.Id, JoinType.InnerJoin)
				.Inner.JoinAlias(() => orderAlias2.Contract, () => counterpartyContractAlias)
				.Inner.JoinAlias(() => counterpartyContractAlias.Organization, () => orderOrganizationAlias)
				.Inner.JoinAlias(() => paymentItemAlias.CashlessMovementOperation, () => cashlessMovementOperationAlias)
				.Inner.JoinAlias(() => orderAlias2.DeliverySchedule, () => deliveryScheduleAlias2)
				.Where(() => orderAlias2.Client.Id == counterpartyAlias.Id)
				.And(() => orderOrganizationAlias.Id == organizationAlias.Id)
				.And(() => orderAlias2.OrderStatus == OrderStatus.Shipped
					|| orderAlias2.OrderStatus == OrderStatus.UnloadingOnStock
					|| orderAlias2.OrderStatus == OrderStatus.Closed)
				.And(() => orderAlias2.PaymentType == PaymentType.cashless)
				.And(() => orderAlias2.OrderPaymentStatus == OrderPaymentStatus.PartiallyPaid)
				.And(() => deliveryScheduleAlias2.Id != _closingDocumentDeliveryScheduleId)
				.Select(Projections.Sum(() => cashlessMovementOperationAlias.Expense));
			
			var counterpartyDebtProjection = Projections.SqlFunction(new SQLFunctionTemplate(NHibernateUtil.Decimal, "?1 - IFNULL(?2, ?3)"),
				NHibernateUtil.Decimal, new IProjection[] {
					Projections.SubQuery(totalNotPaidOrders),
					Projections.SubQuery(totalPayPartiallyPaidOrders),
					Projections.Constant(0)});
			
			query.Where(GetSearchCriterion(
				() => counterpartyAlias.Id,
				() => counterpartyAlias.Name,
				() => balanceProjection,
				() => counterpartyDebtProjection));
			
			return query.SelectList(list => list
				.SelectGroup(() => counterpartyAlias.Id).WithAlias(() => resultAlias.CounterpartyId)
				.SelectGroup(() => organizationAlias.Id).WithAlias(() => resultAlias.OrganizationId)
				.Select(p => counterpartyAlias.INN).WithAlias(() => resultAlias.CounterpartyINN)
				.Select(p => counterpartyAlias.Name).WithAlias(() => resultAlias.CounterpartyName)
				.Select(p =>organizationAlias.Name).WithAlias(() => resultAlias.OrganizationName)
				.Select(balanceProjection).WithAlias(() => resultAlias.CounterpartyBalance)
				.Select(counterpartyDebtProjection).WithAlias(() => resultAlias.CounterpartyDebt))
				.Where(Restrictions.Gt(balanceProjection, 0))
				.And(Restrictions.Gt(counterpartyDebtProjection, 0))
				.OrderBy(balanceProjection).Desc
				.TransformUsing(Transformers.AliasToBean<UnAllocatedBalancesJournalNode>())
				.SetTimeout(120);
		}

		protected override void CreateEntityDialog()
		{
			throw new InvalidOperationException("Что-то пошло не так...");
		}

		protected override void EditEntityDialog(UnAllocatedBalancesJournalNode node)
		{
			var filterParams = new Action<PaymentsJournalFilterViewModel>[]
			{
				f => f.Counterparty = UoW.GetById<Counterparty>(node.CounterpartyId),
				f => f.IsSortingDescByUnAllocatedSum = true,
				f => f.HideAllocatedPayments = true
			};
			
			NavigationManager.OpenViewModel<PaymentsJournalViewModel, Action<PaymentsJournalFilterViewModel>[]>(
				this, filterParams, OpenPageOptions.IgnoreHash);
		}
	}
}
