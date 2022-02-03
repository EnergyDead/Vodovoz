
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Filters.Views
{
	public partial class PaymentsJournalFilterView
	{
		private global::Gtk.VBox vboxMain;

		private global::Gtk.HBox hboxMain;

		private global::Gtk.Label label28;

		private global::QS.Widgets.GtkUI.DateRangePicker dateRangeFilter;

		private global::Gamma.Widgets.yEnumComboBox yenumcomboPaymentState;

		private global::Gamma.GtkWidgets.yCheckButton ycheckbtnHideCompleted;

		private global::Gamma.GtkWidgets.yCheckButton chkIsManualCreate;

		private global::Gamma.GtkWidgets.yCheckButton chkHideAllocatedPayments;

		private global::Gamma.GtkWidgets.yHBox hboxCounterparty;

		private global::Gamma.GtkWidgets.yLabel lblCounterparty;

		private global::QS.Views.Control.EntityEntry counterpartyEntry;

		private global::Gamma.GtkWidgets.yCheckButton chkPaymentsWithoutCounterparty;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Filters.Views.PaymentsJournalFilterView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Filters.Views.PaymentsJournalFilterView";
			// Container child Vodovoz.Filters.Views.PaymentsJournalFilterView.Gtk.Container+ContainerChild
			this.vboxMain = new global::Gtk.VBox();
			this.vboxMain.Name = "vboxMain";
			this.vboxMain.Spacing = 6;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.hboxMain = new global::Gtk.HBox();
			this.hboxMain.Name = "hboxMain";
			this.hboxMain.Spacing = 6;
			// Container child hboxMain.Gtk.Box+BoxChild
			this.label28 = new global::Gtk.Label();
			this.label28.Name = "label28";
			this.label28.LabelProp = global::Mono.Unix.Catalog.GetString("Дата:");
			this.hboxMain.Add(this.label28);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hboxMain[this.label28]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hboxMain.Gtk.Box+BoxChild
			this.dateRangeFilter = new global::QS.Widgets.GtkUI.DateRangePicker();
			this.dateRangeFilter.Events = ((global::Gdk.EventMask)(256));
			this.dateRangeFilter.Name = "dateRangeFilter";
			this.dateRangeFilter.StartDate = new global::System.DateTime(0);
			this.dateRangeFilter.EndDate = new global::System.DateTime(0);
			this.hboxMain.Add(this.dateRangeFilter);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hboxMain[this.dateRangeFilter]));
			w2.Position = 1;
			w2.Expand = false;
			// Container child hboxMain.Gtk.Box+BoxChild
			this.yenumcomboPaymentState = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumcomboPaymentState.Name = "yenumcomboPaymentState";
			this.yenumcomboPaymentState.ShowSpecialStateAll = true;
			this.yenumcomboPaymentState.ShowSpecialStateNot = false;
			this.yenumcomboPaymentState.UseShortTitle = false;
			this.yenumcomboPaymentState.DefaultFirst = false;
			this.hboxMain.Add(this.yenumcomboPaymentState);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hboxMain[this.yenumcomboPaymentState]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hboxMain.Gtk.Box+BoxChild
			this.ycheckbtnHideCompleted = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckbtnHideCompleted.CanFocus = true;
			this.ycheckbtnHideCompleted.Name = "ycheckbtnHideCompleted";
			this.ycheckbtnHideCompleted.Label = global::Mono.Unix.Catalog.GetString("Скрыть завершенные");
			this.ycheckbtnHideCompleted.DrawIndicator = true;
			this.ycheckbtnHideCompleted.UseUnderline = true;
			this.hboxMain.Add(this.ycheckbtnHideCompleted);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hboxMain[this.ycheckbtnHideCompleted]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hboxMain.Gtk.Box+BoxChild
			this.chkIsManualCreate = new global::Gamma.GtkWidgets.yCheckButton();
			this.chkIsManualCreate.CanFocus = true;
			this.chkIsManualCreate.Name = "chkIsManualCreate";
			this.chkIsManualCreate.Label = global::Mono.Unix.Catalog.GetString("Созданы вручную");
			this.chkIsManualCreate.DrawIndicator = true;
			this.chkIsManualCreate.UseUnderline = true;
			this.hboxMain.Add(this.chkIsManualCreate);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hboxMain[this.chkIsManualCreate]));
			w5.Position = 4;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hboxMain.Gtk.Box+BoxChild
			this.chkHideAllocatedPayments = new global::Gamma.GtkWidgets.yCheckButton();
			this.chkHideAllocatedPayments.CanFocus = true;
			this.chkHideAllocatedPayments.Name = "chkHideAllocatedPayments";
			this.chkHideAllocatedPayments.Label = global::Mono.Unix.Catalog.GetString("Скрыть полностью\nраспределенные платежи");
			this.chkHideAllocatedPayments.DrawIndicator = true;
			this.chkHideAllocatedPayments.UseUnderline = true;
			this.hboxMain.Add(this.chkHideAllocatedPayments);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hboxMain[this.chkHideAllocatedPayments]));
			w6.Position = 5;
			w6.Expand = false;
			w6.Fill = false;
			this.vboxMain.Add(this.hboxMain);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.hboxMain]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.hboxCounterparty = new global::Gamma.GtkWidgets.yHBox();
			this.hboxCounterparty.Name = "hboxCounterparty";
			this.hboxCounterparty.Spacing = 6;
			// Container child hboxCounterparty.Gtk.Box+BoxChild
			this.lblCounterparty = new global::Gamma.GtkWidgets.yLabel();
			this.lblCounterparty.Name = "lblCounterparty";
			this.lblCounterparty.LabelProp = global::Mono.Unix.Catalog.GetString("Контрагент:");
			this.hboxCounterparty.Add(this.lblCounterparty);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hboxCounterparty[this.lblCounterparty]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hboxCounterparty.Gtk.Box+BoxChild
			this.counterpartyEntry = new global::QS.Views.Control.EntityEntry();
			this.counterpartyEntry.Events = ((global::Gdk.EventMask)(256));
			this.counterpartyEntry.Name = "counterpartyEntry";
			this.hboxCounterparty.Add(this.counterpartyEntry);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hboxCounterparty[this.counterpartyEntry]));
			w9.Position = 1;
			w9.Expand = false;
			// Container child hboxCounterparty.Gtk.Box+BoxChild
			this.chkPaymentsWithoutCounterparty = new global::Gamma.GtkWidgets.yCheckButton();
			this.chkPaymentsWithoutCounterparty.CanFocus = true;
			this.chkPaymentsWithoutCounterparty.Name = "chkPaymentsWithoutCounterparty";
			this.chkPaymentsWithoutCounterparty.Label = global::Mono.Unix.Catalog.GetString("Скрыть платежи без контрагента");
			this.chkPaymentsWithoutCounterparty.DrawIndicator = true;
			this.chkPaymentsWithoutCounterparty.UseUnderline = true;
			this.hboxCounterparty.Add(this.chkPaymentsWithoutCounterparty);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hboxCounterparty[this.chkPaymentsWithoutCounterparty]));
			w10.Position = 2;
			w10.Expand = false;
			w10.Fill = false;
			this.vboxMain.Add(this.hboxCounterparty);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.hboxCounterparty]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			this.Add(this.vboxMain);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
