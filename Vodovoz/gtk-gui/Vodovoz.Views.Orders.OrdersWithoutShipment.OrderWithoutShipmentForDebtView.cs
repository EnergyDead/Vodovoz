
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Orders.OrdersWithoutShipment
{
	public partial class OrderWithoutShipmentForDebtView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox5;

		private global::Gamma.GtkWidgets.yButton btnCancel;

		private global::Gtk.HBox hbox1;

		private global::Gamma.GtkWidgets.yLabel ylabel1;

		private global::Gamma.GtkWidgets.yLabel ylabelOrderNum;

		private global::Gamma.GtkWidgets.yLabel ylabel3;

		private global::Gamma.GtkWidgets.yLabel ylabelOrderDate;

		private global::Gamma.GtkWidgets.yLabel ylabel5;

		private global::Gamma.GtkWidgets.yLabel ylabelOrderAuthor;

		private global::Gtk.HBox hbox2;

		private global::Gamma.GtkWidgets.yLabel ylabel7;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry entityViewModelEntryCounterparty;

		private global::Gtk.HBox hbox4;

		private global::Gamma.GtkWidgets.yEntry yentryDebtName;

		private global::Gamma.GtkWidgets.ySpinButton yspinbtnDebtSum;

		private global::Gamma.GtkWidgets.yButton ybtnOpenBill;

		private global::Gamma.GtkWidgets.yCheckButton yCheckBtnHideSignature;

		private global::Gtk.HBox hbox7;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Orders.OrdersWithoutShipment.OrderWithoutShipmentForDebtView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Orders.OrdersWithoutShipment.OrderWithoutShipmentForDebtView";
			// Container child Vodovoz.Views.Orders.OrdersWithoutShipment.OrderWithoutShipmentForDebtView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.btnCancel = new global::Gamma.GtkWidgets.yButton();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString("Отмена");
			this.hbox5.Add(this.btnCancel);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.btnCancel]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			this.vbox1.Add(this.hbox5);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox5]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.ylabel1 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel1.Name = "ylabel1";
			this.ylabel1.LabelProp = global::Mono.Unix.Catalog.GetString("Счет без отгрузки на долг № Ф");
			this.hbox1.Add(this.ylabel1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.ylabel1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.ylabelOrderNum = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelOrderNum.Name = "ylabelOrderNum";
			this.ylabelOrderNum.LabelProp = global::Mono.Unix.Catalog.GetString("orderNum");
			this.hbox1.Add(this.ylabelOrderNum);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.ylabelOrderNum]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.ylabel3 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel3.Name = "ylabel3";
			this.ylabel3.LabelProp = global::Mono.Unix.Catalog.GetString(" от ");
			this.hbox1.Add(this.ylabel3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.ylabel3]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.ylabelOrderDate = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelOrderDate.Name = "ylabelOrderDate";
			this.ylabelOrderDate.LabelProp = global::Mono.Unix.Catalog.GetString("orderDate");
			this.hbox1.Add(this.ylabelOrderDate);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.ylabelOrderDate]));
			w6.Position = 3;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.ylabel5 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel5.Name = "ylabel5";
			this.ylabel5.LabelProp = global::Mono.Unix.Catalog.GetString(" Автор: ");
			this.hbox1.Add(this.ylabel5);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.ylabel5]));
			w7.Position = 4;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.ylabelOrderAuthor = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelOrderAuthor.Name = "ylabelOrderAuthor";
			this.ylabelOrderAuthor.LabelProp = global::Mono.Unix.Catalog.GetString("author");
			this.hbox1.Add(this.ylabelOrderAuthor);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.ylabelOrderAuthor]));
			w8.Position = 5;
			w8.Expand = false;
			w8.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.ylabel7 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel7.Name = "ylabel7";
			this.ylabel7.LabelProp = global::Mono.Unix.Catalog.GetString("Контрагент: ");
			this.hbox2.Add(this.ylabel7);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.ylabel7]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.entityViewModelEntryCounterparty = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.entityViewModelEntryCounterparty.Events = ((global::Gdk.EventMask)(256));
			this.entityViewModelEntryCounterparty.Name = "entityViewModelEntryCounterparty";
			this.entityViewModelEntryCounterparty.CanEditReference = false;
			this.hbox2.Add(this.entityViewModelEntryCounterparty);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.entityViewModelEntryCounterparty]));
			w11.Position = 1;
			this.vbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.yentryDebtName = new global::Gamma.GtkWidgets.yEntry();
			this.yentryDebtName.WidthRequest = 350;
			this.yentryDebtName.CanFocus = true;
			this.yentryDebtName.Name = "yentryDebtName";
			this.yentryDebtName.IsEditable = true;
			this.yentryDebtName.InvisibleChar = '•';
			this.hbox4.Add(this.yentryDebtName);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.yentryDebtName]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.yspinbtnDebtSum = new global::Gamma.GtkWidgets.ySpinButton(0D, 1000000D, 1D);
			this.yspinbtnDebtSum.CanFocus = true;
			this.yspinbtnDebtSum.Name = "yspinbtnDebtSum";
			this.yspinbtnDebtSum.Adjustment.PageIncrement = 10D;
			this.yspinbtnDebtSum.ClimbRate = 1D;
			this.yspinbtnDebtSum.Digits = ((uint)(2));
			this.yspinbtnDebtSum.Numeric = true;
			this.yspinbtnDebtSum.ValueAsDecimal = 0m;
			this.yspinbtnDebtSum.ValueAsInt = 0;
			this.hbox4.Add(this.yspinbtnDebtSum);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.yspinbtnDebtSum]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.ybtnOpenBill = new global::Gamma.GtkWidgets.yButton();
			this.ybtnOpenBill.CanFocus = true;
			this.ybtnOpenBill.Name = "ybtnOpenBill";
			this.ybtnOpenBill.UseUnderline = true;
			this.ybtnOpenBill.Label = global::Mono.Unix.Catalog.GetString("Открыть счет");
			this.hbox4.Add(this.ybtnOpenBill);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ybtnOpenBill]));
			w15.Position = 2;
			w15.Expand = false;
			w15.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.yCheckBtnHideSignature = new global::Gamma.GtkWidgets.yCheckButton();
			this.yCheckBtnHideSignature.CanFocus = true;
			this.yCheckBtnHideSignature.Name = "yCheckBtnHideSignature";
			this.yCheckBtnHideSignature.Label = global::Mono.Unix.Catalog.GetString("Счет без печати и подписей");
			this.yCheckBtnHideSignature.DrawIndicator = true;
			this.yCheckBtnHideSignature.UseUnderline = true;
			this.hbox4.Add(this.yCheckBtnHideSignature);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.yCheckBtnHideSignature]));
			w16.Position = 3;
			w16.Expand = false;
			w16.Fill = false;
			this.vbox1.Add(this.hbox4);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox4]));
			w17.Position = 3;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			this.vbox1.Add(this.hbox7);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox7]));
			w18.Position = 4;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
