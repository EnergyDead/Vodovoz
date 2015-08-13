﻿using System;
using System.Collections.Generic;
using System.Data.Bindings;
using System.Data.Bindings.Collections.Generic;
using Gtk;
using Gtk.DataBindings;
using NLog;
using QSOrmProject;
using QSTDI;
using Vodovoz.Domain;
using Vodovoz.Domain.Logistic;
using Vodovoz.Repository;
using System.Linq;
using Vodovoz.Domain.Orders;

namespace Vodovoz
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class CreateRouteListItemsView : WidgetOnTdiTabBase
	{
		static Logger logger = LogManager.GetCurrentClassLogger ();

		private int goodsColumnsCount = -1;

		private IList<RouteColumn> _columnsInfo;

		private IList<RouteColumn> columnsInfo{
			get{
				if (_columnsInfo == null)
					_columnsInfo = Repository.Logistics.RouteColumnRepository.ActiveColumns (RouteListUoW);
				return _columnsInfo;
			}
		}

		private IUnitOfWorkGeneric<RouteList> routeListUoW;

		public IUnitOfWorkGeneric<RouteList> RouteListUoW {
			get { return routeListUoW; }
			set {
				if (routeListUoW == value)
					return;
				routeListUoW = value;
				if (RouteListUoW.Root.Addresses == null)
					RouteListUoW.Root.Addresses = new List<RouteListItem> ();
				items = RouteListUoW.Root.ObservableAddresses;
				items.ElementChanged += Items_ElementChanged;
				items.ListChanged += Items_ListChanged;

				UpdateColumns ();

				treeItemsList.ItemsDataSource = items;
				CalculateTotal ();
			}
		}

		void Items_ListChanged (object aList)
		{
			UpdateColumns ();
		}

		private void UpdateColumns()
		{
			var goodsColumns = items.SelectMany (i => i.GoodsByRouteColumns.Keys).Distinct ().ToArray ();
			if (goodsColumnsCount == goodsColumns.Length)
				return;

			goodsColumnsCount = goodsColumns.Length;

			var config = FluentMappingConfig<RouteListItem>.Create ()
				.AddColumn ("Заказ").SetDataProperty (node => node.Order.Id)
				.AddColumn ("Адрес").AddTextRenderer (node => String.Format ("{0} д.{1}", node.Order.DeliveryPoint.Street, node.Order.DeliveryPoint.Building))
				.AddColumn ("Время").AddTextRenderer (node => node.Order.DeliverySchedule == null ? "" : node.Order.DeliverySchedule.Name);
			foreach(var column in columnsInfo)
			{
				if (!goodsColumns.Contains (column.Id))
					continue;
				int id = column.Id;
				config = config.AddColumn (column.Name).AddTextRenderer (a => a.GetGoodsAmountForColumn (id).ToString ());
			}
				//					.AddColumn ("Логистический район").SetDataProperty (node => node.Order.DeliveryPoint.LogisticsArea == null ? 
				//						"Не указан" : 
				//						node.Order.DeliveryPoint.LogisticsArea.Name)
			treeItemsList.ColumnMappingConfig = 
				config.RowCells ().AddSetter<CellRendererText> ((c, n) => c.Foreground = n.Order.RowColor)
				.Finish ();
		}

		public void IsEditable (bool val = false)
		{
			enumbuttonAddOrder.Sensitive = buttonDelete.Sensitive = val;
		}

		void Items_ElementChanged (object aList, int[] aIdx)
		{
			CalculateTotal ();
		}

		public CreateRouteListItemsView ()
		{
			this.Build ();
			treeItemsList.Selection.Changed += OnSelectionChanged;
		}

		void OnSelectionChanged (object sender, EventArgs e)
		{
			buttonDelete.Sensitive = treeItemsList.Selection.CountSelectedRows () > 0;
		}

		GenericObservableList<RouteListItem> items;

		protected void OnButtonDeleteClicked (object sender, EventArgs e)
		{
			RouteListUoW.Root.RemoveAddress (treeItemsList.GetSelectedObject () as RouteListItem);
			CalculateTotal ();
		}

		protected void OnEnumbuttonAddOrderEnumItemClicked (object sender, EnumItemClickedEventArgs e)
		{
			AddOrderEnum choice = (AddOrderEnum)e.ItemEnum;
			switch (choice) {
			case AddOrderEnum.AddOne:
				AddOrder ();
				break;
			case AddOrderEnum.AddAllForRegion:
				AddOrdersFromRegion ();
				break;
			default:
				break;
			}
		}

		protected void AddOrder ()
		{
			var filter = new OrdersFilter (UnitOfWorkFactory.CreateWithoutRoot ());
			filter.RestrictStartDate = filter.RestrictEndDate = RouteListUoW.Root.Date;

			ReferenceRepresentation SelectDialog = new ReferenceRepresentation (new ViewModel.OrdersVM (filter));
			SelectDialog.Mode = OrmReferenceMode.Select;
			//SelectDialog.ButtonMode = ReferenceButtonMode.CanEdit;
			SelectDialog.ObjectSelected += (s, ea) => {
				var order = RouteListUoW.GetById<Order> (ea.ObjectId);
				RouteListUoW.Root.AddAddressFromOrder (order);
			};
			MyTab.TabParent.AddSlaveTab (MyTab, SelectDialog);
		}

		protected void AddOrdersFromRegion ()
		{
			OrmReference SelectDialog = new OrmReference (typeof(LogisticsArea), RouteListUoW);
			SelectDialog.Mode = OrmReferenceMode.Select;
			SelectDialog.ButtonMode = ReferenceButtonMode.CanEdit;
			SelectDialog.ObjectSelected += (s, ea) => {
				if (ea.Subject != null) {
					foreach (var order in OrderRepository.GetAcceptedOrdersForRegion(RouteListUoW, RouteListUoW.Root.Date, ea.Subject as LogisticsArea))
						RouteListUoW.Root.AddAddressFromOrder (order);
				}
			};
			MyTab.TabParent.AddSlaveTab (MyTab, SelectDialog);
		}
			
		void CalculateTotal ()
		{
/*			decimal total = 0;
			foreach (var item in routeListUoW.Root.Items) {
				total += item.Sum;
			}

			labelSum.LabelProp = String.Format ("Итого: {0}", CurrencyWorks.GetShortCurrencyString (total));
*/		}
			
		protected void OnTreeItemsListRowActivated (object o, RowActivatedArgs args)
		{
			var selected = treeItemsList.GetSelectedObject ();
			if (selected != null) {
				ITdiDialog dlg = null;
				dlg = OrmMain.CreateObjectDialog ((selected as RouteListItem).Order);
				MyTab.TabParent.AddSlaveTab (MyTab, dlg);
			}
		}
	}

	public enum AddOrderEnum
	{
		[ItemTitleAttribute ("Один заказ")] AddOne,
		[ItemTitleAttribute ("Все заказы для логистического района")]AddAllForRegion
	}

}

