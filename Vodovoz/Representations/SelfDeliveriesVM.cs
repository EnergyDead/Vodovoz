﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gamma.ColumnConfig;
using Gamma.Utilities;
using Gtk;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using QS.Dialog.Gtk;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QS.RepresentationModel.GtkUI;
using QS.Utilities.Text;
using QSProjectsLib;
using Vodovoz.Dialogs.Cash;
using Vodovoz.Domain.Cash;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Orders;
using VodovozOrder = Vodovoz.Domain.Orders.Order;

namespace Vodovoz.Representations
{
	public class SelfDeliveriesVM : QSOrmProject.RepresentationModel.RepresentationModelEntityBase<VodovozOrder, UnclosedSelfDeliveriesVMNode>
	{
		public OrdersFilter Filter {
			get { return RepresentationFilter as OrdersFilter; }
			set { RepresentationFilter = value as QSOrmProject.RepresentationModel.IRepresentationFilter; }
		}

		public SelfDeliveriesVM(OrdersFilter filter) : this(filter.UoW)
		{
			Filter = filter;
		}

		public SelfDeliveriesVM() : this(UnitOfWorkFactory.CreateWithoutRoot())
		{
			CreateRepresentationFilter = () => new OrdersFilter(UoW);
		}

		public SelfDeliveriesVM(IUnitOfWork uow) : base()
		{
			this.UoW = uow;
		}

		public override bool PopupMenuExist => true;

		IColumnsConfig columnsConfig = FluentColumnsConfig<UnclosedSelfDeliveriesVMNode>.Create()
			.AddColumn("Номер").SetDataProperty(node => node.Id.ToString())
			.AddColumn("Дата").SetDataProperty(node => node.Date.ToString("d"))
			.AddColumn("Автор").SetDataProperty(node => node.Author)
			.AddColumn("Статус").SetDataProperty(node => node.StatusEnum.GetEnumTitle())
			.AddColumn("Тип оплаты").SetDataProperty(node => node.PaymentTypeEnum.GetEnumTitle())
			.AddColumn("Бутыли").AddTextRenderer(node => node.BottleAmount.ToString())
			.AddColumn("Клиент").SetDataProperty(node => node.Counterparty)
			.AddColumn("Вариант оплаты").SetDataProperty(node => node.PayOption)
			.AddColumn("Сумма безнал").AddTextRenderer(node => CurrencyWorks.GetShortCurrencyString(node.OrderCashlessSumTotal))
			.AddColumn("Сумма нал").AddTextRenderer(node => CurrencyWorks.GetShortCurrencyString(node.OrderCashSumTotal))
			.AddColumn("Из них возврат").AddTextRenderer(node => CurrencyWorks.GetShortCurrencyString(node.OrderReturnSum))
			.AddColumn("Касса приход").AddTextRenderer(node => CurrencyWorks.GetShortCurrencyString(node.CashPaid))
			.AddColumn("Касса возврат").AddTextRenderer(node => CurrencyWorks.GetShortCurrencyString(node.CashReturn))
			.AddColumn("Касса итог").AddTextRenderer(node => CurrencyWorks.GetShortCurrencyString(node.CashTotal))
			.AddColumn("Расхождение по нал.").AddTextRenderer(node => CurrencyWorks.GetShortCurrencyString(node.TotalCashDiff))
			.RowCells().AddSetter<CellRendererText>((c, n) => c.Foreground = n.RowColor)
			.Finish();

		public override IColumnsConfig ColumnsConfig => columnsConfig;

		#region implemented abstract members of RepresentationModelBase

		protected override bool NeedUpdateFunc(VodovozOrder updatedSubject) => true;

		public override void UpdateNodes()
		{
			UnclosedSelfDeliveriesVMNode resultAlias = null;
			VodovozOrder orderAlias = null;
			Nomenclature nomenclatureAlias = null;
			OrderItem orderItemAlias = null;
			OrderDepositItem orderDepositItemAlias = null;
			Income incomeAlias = null;
			Expense expenseAlias = null;
			Counterparty counterpartyAlias = null;
			DeliveryPoint deliveryPointAlias = null;
			Employee authorAlias = null;

			var query = UoW.Session.QueryOver<VodovozOrder>(() => orderAlias)
				.Where(() => orderAlias.SelfDelivery)
				.Where(() => !orderAlias.IsService);

			if(Filter.RestrictStatus != null) {
				query.Where(o => o.OrderStatus == Filter.RestrictStatus);
			} else if(Filter.AllowStatuses.Any()) {
				query.WhereRestrictionOn(o => o.OrderStatus).IsIn(Filter.AllowStatuses);
			}

			if(Filter.RestrictPaymentType != null) {
				query.Where(o => o.PaymentType == Filter.RestrictPaymentType);
			} else if(Filter.AllowPaymentTypes.Any()) {
				query.WhereRestrictionOn(o => o.PaymentType).IsIn(Filter.AllowPaymentTypes);
			}

			if(Filter.RestrictCounterparty != null) {
				query.Where(o => o.Client == Filter.RestrictCounterparty);
			}

			if(Filter.RestrictDeliveryPoint != null) {
				query.Where(o => o.DeliveryPoint == Filter.RestrictDeliveryPoint);
			}

			if(Filter.RestrictStartDate != null) {
				query.Where(o => o.DeliveryDate >= Filter.RestrictStartDate);
			}

			if(Filter.RestrictEndDate != null) {
				query.Where(o => o.DeliveryDate <= Filter.RestrictEndDate.Value.AddDays(1).AddTicks(-1));
			}

			var result = query
				.JoinAlias(o => o.DeliveryPoint, () => deliveryPointAlias, JoinType.LeftOuterJoin)
				.JoinAlias(o => o.Client, () => counterpartyAlias)
				.JoinAlias(o => o.Author, () => authorAlias, JoinType.LeftOuterJoin)
				.JoinAlias(() => orderAlias.OrderItems, () => orderItemAlias, JoinType.LeftOuterJoin)
				.JoinAlias(() => orderItemAlias.Nomenclature, () => nomenclatureAlias, JoinType.LeftOuterJoin)
				.JoinAlias(() => orderAlias.OrderDepositItems, () => orderDepositItemAlias, JoinType.LeftOuterJoin)
				.JoinEntityAlias(() => incomeAlias, () => orderAlias.Id == incomeAlias.Order.Id, JoinType.LeftOuterJoin)
				.JoinEntityAlias(() => expenseAlias, () => orderAlias.Id == expenseAlias.Order.Id, JoinType.LeftOuterJoin)
				.SelectList(list => list
				   .SelectGroup(() => orderAlias.Id).WithAlias(() => resultAlias.Id)
				   .Select(() => orderAlias.DeliveryDate).WithAlias(() => resultAlias.Date)
				   .Select(() => orderAlias.OrderStatus).WithAlias(() => resultAlias.StatusEnum)
				   .Select(() => authorAlias.LastName).WithAlias(() => resultAlias.AuthorLastName)
				   .Select(() => authorAlias.Name).WithAlias(() => resultAlias.AuthorName)
				   .Select(() => authorAlias.Patronymic).WithAlias(() => resultAlias.AuthorPatronymic)
				   .Select(() => counterpartyAlias.Name).WithAlias(() => resultAlias.Counterparty)
				   .Select(() => orderAlias.PayAfterShipment).WithAlias(() => resultAlias.PayAfterLoad)
				   .Select(() => orderAlias.PaymentType).WithAlias(() => resultAlias.PaymentTypeEnum)
				   .Select(Projections.Sum(
					   	Projections.Conditional(
					   		Restrictions.Where(() => nomenclatureAlias.Category == NomenclatureCategory.water && nomenclatureAlias.TareVolume == TareVolume.Vol19L), 
						   	Projections.Property(() => orderItemAlias.Count), 
							Projections.Constant(0, NHibernateUtil.Int32)
						)
					)).WithAlias(() => resultAlias.BottleAmount)
				   .Select(Projections.Sum(
						Projections.SqlFunction(
							new SQLFunctionTemplate(NHibernateUtil.Decimal, "IFNULL(?2, ?1) * ?3 - ?4"),
							NHibernateUtil.Decimal,
							Projections.Property(() => orderItemAlias.Count),
							Projections.Property(() => orderItemAlias.ActualCount),
							Projections.Property(() => orderItemAlias.Price),
							Projections.Property(() => orderItemAlias.DiscountMoney)
						   )
					)).WithAlias(() => resultAlias.OrderSum)
				   .Select(Projections.Sum(
						Projections.SqlFunction(
							new SQLFunctionTemplate(NHibernateUtil.Decimal, "IFNULL(?2, ?1) * ?3"),
							NHibernateUtil.Decimal,
							Projections.Property(() => orderDepositItemAlias.Count),
							Projections.Property(() => orderItemAlias.ActualCount),
							Projections.Property(() => orderDepositItemAlias.Deposit)
						   )
					)).WithAlias(() => resultAlias.OrderReturnSum)
				   .Select(Projections.Property(() => incomeAlias.Money)).WithAlias(() => resultAlias.CashPaid)
				   .Select(Projections.Property(() => expenseAlias.Money)).WithAlias(() => resultAlias.CashReturn)
				).OrderBy(x => x.DeliveryDate).Desc.ThenBy(x => x.Id).Desc
				.TransformUsing(Transformers.AliasToBean<UnclosedSelfDeliveriesVMNode>())
				.List<UnclosedSelfDeliveriesVMNode>()
				.ToList();

			SetItemsSource(result);
		}

		#endregion

		public override IEnumerable<IJournalPopupItem> PopupItems {
			get {
				var result = new List<IJournalPopupItem>();

				result.Add(JournalPopupItemFactory.CreateNewAlwaysVisible("Открыть заказ",
					(selectedItems) => {
						var selectedNodes = selectedItems.Cast<UnclosedSelfDeliveriesVMNode>();
						var selectedNode = selectedNodes.FirstOrDefault();
						MainClass.MainWin.TdiMain.OpenTab(
							DialogHelper.GenerateDialogHashName<VodovozOrder>(selectedNode.Id),
							() => new OrderDlg(selectedNode.Id)
						);
					},
					(selectedItems) => {
						var selectedNodes = selectedItems.Cast<UnclosedSelfDeliveriesVMNode>();
						return selectedNodes.Count() == 1;
					}
				));

				result.Add(JournalPopupItemFactory.CreateNewAlwaysVisible("Создать кассовые ордера",
					(selectedItems) => {
						var selectedNodes = selectedItems.Cast<UnclosedSelfDeliveriesVMNode>();
						var selectedNode = selectedNodes.FirstOrDefault();
						if(selectedNode != null) {
							CreateSelfDeliveryCashInvoices(selectedNode.Id);
						}
					},
					(selectedItems) => {
						var selectedNodes = selectedItems.Cast<UnclosedSelfDeliveriesVMNode>();
						return selectedNodes.Count() == 1 && selectedNodes.First().StatusEnum == OrderStatus.WaitForPayment;
					}
				));

				return result;
			}
		}

		void CreateSelfDeliveryCashInvoices(int orderId)
		{
			var order = UoW.GetById<VodovozOrder>(orderId);

			if(order.SelfDeliveryIsFullyPaid()) {
				MessageDialogHelper.RunInfoDialog("Заказ уже оплачен полностью");
				return;
			}

			if(order.OrderSum > 0 && !order.SelfDeliveryIsFullyIncomePaid()) {
				MainClass.MainWin.TdiMain.OpenTab(
					"selfDelivery_" + DialogHelper.GenerateDialogHashName<Income>(orderId),
					() => new CashIncomeSelfDeliveryDlg(order)
				);
			}

			if(order.OrderSumReturn > 0 && !order.SelfDeliveryIsFullyExpenseReturned()) {
				MainClass.MainWin.TdiMain.OpenTab(
					"selfDelivery_" + DialogHelper.GenerateDialogHashName<Expense>(orderId),
					() => new CashExpenseSelfDeliveryDlg(order)
				);
			}
		}
	}

	public class UnclosedSelfDeliveriesVMNode
	{
		[UseForSearch]
		[SearchHighlight]
		public int Id { get; set; }

		public OrderStatus StatusEnum { get; set; }

		public DateTime Date { get; set; }
		public int BottleAmount { get; set; }

		[UseForSearch]
		[SearchHighlight]
		public string Counterparty { get; set; }

		public PaymentType PaymentTypeEnum { get; set; }
		public bool PayAfterLoad { get; set; }
		public string PayOption => PayAfterLoad ? "После погрузки" : "До погрузки";

		//заказ
		public decimal OrderSum { get; set; }
		public decimal OrderCashSum => PaymentTypeEnum == PaymentType.cash || PaymentTypeEnum == PaymentType.BeveragesWorld ? OrderSum : 0;
		public decimal OrderCashlessSum => PaymentTypeEnum == PaymentType.cashless || PaymentTypeEnum == PaymentType.ByCard ? OrderSum : 0;
		public decimal OrderReturnSum { get; set; }
		public decimal OrderCashSumTotal => OrderCashSum - OrderReturnSum;
		public decimal OrderCashlessSumTotal => OrderCashlessSum - OrderReturnSum;

		//наличные по кассе
		public decimal CashPaid { get; set; }
		public decimal CashReturn { get; set; }
		public decimal CashTotal => CashPaid - CashReturn;

		public decimal TotalCashDiff => OrderCashSumTotal - CashTotal;

		public bool HasCashDiff => OrderCashSumTotal != CashTotal;

		public string AuthorLastName { get; set; }
		public string AuthorName { get; set; }
		public string AuthorPatronymic { get; set; }

		[UseForSearch]
		[SearchHighlight]
		public string Author { get { return PersonHelper.PersonNameWithInitials(AuthorLastName, AuthorName, AuthorPatronymic); } }

		public string RowColor {
			get {
				if(CashPaid > 0 && HasCashDiff) {
					//light red
					return "#f97777";
				}
				if(StatusEnum == OrderStatus.Closed && HasCashDiff) {
					//red
					return "#ee0000";
				}
				return "black";

			}
		}
	}
}
