
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Cash
{
	public partial class PaymentByCardView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox2;

		private global::Gamma.GtkWidgets.yButton ybuttonSave;

		private global::Gamma.GtkWidgets.yButton ybuttonCancel;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label label1;

		private global::QS.Widgets.ValidatedEntry entryOnlineOrder;

		private global::Gamma.Widgets.ySpecComboBox comboPaymentFrom;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Cash.PaymentByCardView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Cash.PaymentByCardView";
			// Container child Vodovoz.Views.Cash.PaymentByCardView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.ybuttonSave = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonSave.CanFocus = true;
			this.ybuttonSave.Name = "ybuttonSave";
			this.ybuttonSave.UseUnderline = true;
			this.ybuttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			this.hbox2.Add(this.ybuttonSave);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.ybuttonSave]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.ybuttonCancel = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonCancel.CanFocus = true;
			this.ybuttonCancel.Name = "ybuttonCancel";
			this.ybuttonCancel.UseUnderline = true;
			this.ybuttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			this.hbox2.Add(this.ybuttonCancel);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.ybuttonCancel]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.vbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Онлайн заказ:");
			this.hbox1.Add(this.label1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.label1]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entryOnlineOrder = new global::QS.Widgets.ValidatedEntry();
			this.entryOnlineOrder.CanFocus = true;
			this.entryOnlineOrder.Name = "entryOnlineOrder";
			this.entryOnlineOrder.IsEditable = true;
			this.entryOnlineOrder.InvisibleChar = '•';
			this.hbox1.Add(this.entryOnlineOrder);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.entryOnlineOrder]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.comboPaymentFrom = new global::Gamma.Widgets.ySpecComboBox();
			this.comboPaymentFrom.Name = "comboPaymentFrom";
			this.comboPaymentFrom.AddIfNotExist = false;
			this.comboPaymentFrom.DefaultFirst = false;
			this.comboPaymentFrom.ShowSpecialStateAll = false;
			this.comboPaymentFrom.ShowSpecialStateNot = false;
			this.hbox1.Add(this.comboPaymentFrom);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.comboPaymentFrom]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
