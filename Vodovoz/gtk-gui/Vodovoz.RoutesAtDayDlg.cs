
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class RoutesAtDayDlg
	{
		private global::Gtk.VBox vbox5;

		private global::Gtk.Table table1;

		private global::Gtk.CheckButton checkShowCompleted;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Label label7;

		private global::Gtk.Table table2;

		private global::Gtk.Button buttonFilter;

		private global::Gtk.ScrolledWindow GtkScrolledWindow3;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewGeographicGroup;

		private global::Gtk.Label label3;

		private global::Gtk.Label label8;

		private global::Gtk.Label labelTimeFrom;

		private global::Gtk.Label labelTimeTo;

		private global::Gamma.GtkWidgets.ySpinButton ySpnMin19Btls;

		private global::Gamma.Widgets.yTimeEntry ytimeToDeliveryFrom;

		private global::Gamma.Widgets.yTimeEntry ytimeToDeliveryTo;

		private global::Gtk.TextView textOrdersInfo;

		private global::Gamma.Widgets.yDatePicker ydateForRoutes;

		private global::Gamma.Widgets.ySpecComboBox yspeccomboboxCashSubdivision;

		private global::Gamma.GtkWidgets.yTextView ytextFullOrdersInfo;

		private global::Gtk.HPaned hpaned3;

		private global::Gtk.VBox vbox3;

		private global::Gtk.HBox hbox8;

		private global::Gtk.ProgressBar progressOrders;

		private global::Gtk.Button buttonWarnings;

		private global::Gtk.Button buttonAutoCreate;

		private global::Gtk.Notebook notebook1;

		private global::Gtk.VBox vboxDrivers;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewOnDayDrivers;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Button buttonAddDriver;

		private global::Gtk.Button buttonRemoveDriver;

		private global::Gtk.Button buttonDriverSelectAuto;

		private global::Gtk.Label label4;

		private global::Gtk.VBox vbox4;

		private global::Gtk.ScrolledWindow GtkScrolledWindow2;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewOnDayForwarders;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Button buttonAddForwarder;

		private global::Gtk.Button buttonRemoveForwarder;

		private global::Gtk.Label label5;

		private global::Gtk.VBox vboxRouteLists;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeRoutes;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Button buttonOpen;

		private global::Gtk.Button buttonRebuildRoute;

		private global::Gtk.Button buttonRemoveAddress;

		private global::Gtk.Label label6;

		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Button btnRefresh;

		private global::Gtk.Label labelSelected;

		private global::QSWidgetLib.MenuButton menuAddToRL;

		private global::Gtk.CheckButton checkShowDistricts;

		private global::Gamma.GtkWidgets.ySpinButton yspinMaxTime;

		private global::Gtk.VSeparator vseparator2;

		private global::Gamma.Widgets.yEnumComboBox yenumcomboMapType;

		private global::Gtk.Button buttonMapHelp;

		private global::GMap.NET.GtkSharp.GMapControl gmapWidget;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.RoutesAtDayDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.RoutesAtDayDlg";
			// Container child Vodovoz.RoutesAtDayDlg.Gtk.Container+ContainerChild
			this.vbox5 = new global::Gtk.VBox();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(2)), ((uint)(7)), false);
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.checkShowCompleted = new global::Gtk.CheckButton();
			this.checkShowCompleted.CanFocus = true;
			this.checkShowCompleted.Name = "checkShowCompleted";
			this.checkShowCompleted.Label = global::Mono.Unix.Catalog.GetString("Показывать уехавшие");
			this.checkShowCompleted.DrawIndicator = true;
			this.checkShowCompleted.UseUnderline = true;
			this.table1.Add(this.checkShowCompleted);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.checkShowCompleted]));
			w1.TopAttach = ((uint)(1));
			w1.BottomAttach = ((uint)(2));
			w1.LeftAttach = ((uint)(2));
			w1.RightAttach = ((uint)(3));
			w1.XOptions = ((global::Gtk.AttachOptions)(0));
			w1.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Дата:");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Events = ((global::Gdk.EventMask)(768));
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.Yalign = 0F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Оперативная сводка:");
			this.label2.Selectable = true;
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w3.BottomAttach = ((uint)(2));
			w3.LeftAttach = ((uint)(4));
			w3.RightAttach = ((uint)(5));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table1.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Сдается \nв кассу:");
			this.label7.Justify = ((global::Gtk.Justification)(1));
			this.table1.Add(this.label7);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.label7]));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.table2 = new global::Gtk.Table(((uint)(2)), ((uint)(7)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.buttonFilter = new global::Gtk.Button();
			this.buttonFilter.CanFocus = true;
			this.buttonFilter.Name = "buttonFilter";
			this.buttonFilter.UseUnderline = true;
			this.buttonFilter.Label = global::Mono.Unix.Catalog.GetString("Фильтровать");
			this.table2.Add(this.buttonFilter);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table2[this.buttonFilter]));
			w5.BottomAttach = ((uint)(2));
			w5.LeftAttach = ((uint)(6));
			w5.RightAttach = ((uint)(7));
			// Container child table2.Gtk.Table+TableChild
			this.GtkScrolledWindow3 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow3.Name = "GtkScrolledWindow3";
			this.GtkScrolledWindow3.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow3.Gtk.Container+ContainerChild
			this.ytreeviewGeographicGroup = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewGeographicGroup.CanFocus = true;
			this.ytreeviewGeographicGroup.Name = "ytreeviewGeographicGroup";
			this.GtkScrolledWindow3.Add(this.ytreeviewGeographicGroup);
			this.table2.Add(this.GtkScrolledWindow3);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table2[this.GtkScrolledWindow3]));
			w7.BottomAttach = ((uint)(2));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Время доставки");
			this.table2.Add(this.label3);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table2[this.label3]));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(5));
			w8.XOptions = ((global::Gtk.AttachOptions)(0));
			w8.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table2.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label();
			this.label8.Name = "label8";
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString("Минимум 19л. бут.");
			this.table2.Add(this.label8);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table2[this.label8]));
			w9.LeftAttach = ((uint)(5));
			w9.RightAttach = ((uint)(6));
			w9.XOptions = ((global::Gtk.AttachOptions)(0));
			w9.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table2.Gtk.Table+TableChild
			this.labelTimeFrom = new global::Gtk.Label();
			this.labelTimeFrom.Name = "labelTimeFrom";
			this.labelTimeFrom.LabelProp = global::Mono.Unix.Catalog.GetString("с");
			this.table2.Add(this.labelTimeFrom);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table2[this.labelTimeFrom]));
			w10.TopAttach = ((uint)(1));
			w10.BottomAttach = ((uint)(2));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.labelTimeTo = new global::Gtk.Label();
			this.labelTimeTo.Name = "labelTimeTo";
			this.labelTimeTo.LabelProp = global::Mono.Unix.Catalog.GetString("по");
			this.table2.Add(this.labelTimeTo);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table2[this.labelTimeTo]));
			w11.TopAttach = ((uint)(1));
			w11.BottomAttach = ((uint)(2));
			w11.LeftAttach = ((uint)(3));
			w11.RightAttach = ((uint)(4));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.ySpnMin19Btls = new global::Gamma.GtkWidgets.ySpinButton(0D, 100D, 1D);
			this.ySpnMin19Btls.WidthRequest = 100;
			this.ySpnMin19Btls.CanFocus = true;
			this.ySpnMin19Btls.Name = "ySpnMin19Btls";
			this.ySpnMin19Btls.Adjustment.PageIncrement = 1D;
			this.ySpnMin19Btls.Adjustment.PageSize = 1D;
			this.ySpnMin19Btls.ClimbRate = 1D;
			this.ySpnMin19Btls.Numeric = true;
			this.ySpnMin19Btls.ValueAsDecimal = 0m;
			this.ySpnMin19Btls.ValueAsInt = 0;
			this.table2.Add(this.ySpnMin19Btls);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table2[this.ySpnMin19Btls]));
			w12.TopAttach = ((uint)(1));
			w12.BottomAttach = ((uint)(2));
			w12.LeftAttach = ((uint)(5));
			w12.RightAttach = ((uint)(6));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.ytimeToDeliveryFrom = new global::Gamma.Widgets.yTimeEntry();
			this.ytimeToDeliveryFrom.WidthRequest = 100;
			this.ytimeToDeliveryFrom.CanFocus = true;
			this.ytimeToDeliveryFrom.Events = ((global::Gdk.EventMask)(256));
			this.ytimeToDeliveryFrom.Name = "ytimeToDeliveryFrom";
			this.ytimeToDeliveryFrom.IsEditable = true;
			this.ytimeToDeliveryFrom.InvisibleChar = '●';
			this.ytimeToDeliveryFrom.ShowSeconds = false;
			this.ytimeToDeliveryFrom.AutocompleteStep = 15;
			this.ytimeToDeliveryFrom.DateTime = new global::System.DateTime(0);
			this.ytimeToDeliveryFrom.Time = new global::System.TimeSpan(0);
			this.table2.Add(this.ytimeToDeliveryFrom);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table2[this.ytimeToDeliveryFrom]));
			w13.TopAttach = ((uint)(1));
			w13.BottomAttach = ((uint)(2));
			w13.LeftAttach = ((uint)(2));
			w13.RightAttach = ((uint)(3));
			w13.XOptions = ((global::Gtk.AttachOptions)(0));
			w13.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table2.Gtk.Table+TableChild
			this.ytimeToDeliveryTo = new global::Gamma.Widgets.yTimeEntry();
			this.ytimeToDeliveryTo.WidthRequest = 100;
			this.ytimeToDeliveryTo.CanFocus = true;
			this.ytimeToDeliveryTo.Events = ((global::Gdk.EventMask)(256));
			this.ytimeToDeliveryTo.Name = "ytimeToDeliveryTo";
			this.ytimeToDeliveryTo.IsEditable = true;
			this.ytimeToDeliveryTo.InvisibleChar = '●';
			this.ytimeToDeliveryTo.ShowSeconds = false;
			this.ytimeToDeliveryTo.AutocompleteStep = 15;
			this.ytimeToDeliveryTo.DateTime = new global::System.DateTime(0);
			this.ytimeToDeliveryTo.Time = new global::System.TimeSpan(0);
			this.table2.Add(this.ytimeToDeliveryTo);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table2[this.ytimeToDeliveryTo]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(2));
			w14.LeftAttach = ((uint)(4));
			w14.RightAttach = ((uint)(5));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			this.table1.Add(this.table2);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1[this.table2]));
			w15.BottomAttach = ((uint)(2));
			w15.LeftAttach = ((uint)(3));
			w15.RightAttach = ((uint)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table1.Gtk.Table+TableChild
			this.textOrdersInfo = new global::Gtk.TextView();
			this.textOrdersInfo.CanFocus = true;
			this.textOrdersInfo.Name = "textOrdersInfo";
			this.textOrdersInfo.Editable = false;
			this.table1.Add(this.textOrdersInfo);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1[this.textOrdersInfo]));
			w16.BottomAttach = ((uint)(2));
			w16.LeftAttach = ((uint)(5));
			w16.RightAttach = ((uint)(6));
			w16.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table1.Gtk.Table+TableChild
			this.ydateForRoutes = new global::Gamma.Widgets.yDatePicker();
			this.ydateForRoutes.Events = ((global::Gdk.EventMask)(256));
			this.ydateForRoutes.Name = "ydateForRoutes";
			this.ydateForRoutes.WithTime = false;
			this.ydateForRoutes.Date = new global::System.DateTime(0);
			this.ydateForRoutes.IsEditable = true;
			this.ydateForRoutes.AutoSeparation = true;
			this.table1.Add(this.ydateForRoutes);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table1[this.ydateForRoutes]));
			w17.TopAttach = ((uint)(1));
			w17.BottomAttach = ((uint)(2));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.YOptions = ((global::Gtk.AttachOptions)(0));
			// Container child table1.Gtk.Table+TableChild
			this.yspeccomboboxCashSubdivision = new global::Gamma.Widgets.ySpecComboBox();
			this.yspeccomboboxCashSubdivision.Name = "yspeccomboboxCashSubdivision";
			this.yspeccomboboxCashSubdivision.AddIfNotExist = false;
			this.yspeccomboboxCashSubdivision.DefaultFirst = false;
			this.yspeccomboboxCashSubdivision.ShowSpecialStateAll = false;
			this.yspeccomboboxCashSubdivision.ShowSpecialStateNot = false;
			this.table1.Add(this.yspeccomboboxCashSubdivision);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table1[this.yspeccomboboxCashSubdivision]));
			w18.LeftAttach = ((uint)(1));
			w18.RightAttach = ((uint)(3));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ytextFullOrdersInfo = new global::Gamma.GtkWidgets.yTextView();
			this.ytextFullOrdersInfo.CanFocus = true;
			this.ytextFullOrdersInfo.Name = "ytextFullOrdersInfo";
			this.ytextFullOrdersInfo.Editable = false;
			this.table1.Add(this.ytextFullOrdersInfo);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table1[this.ytextFullOrdersInfo]));
			w19.BottomAttach = ((uint)(2));
			w19.LeftAttach = ((uint)(6));
			w19.RightAttach = ((uint)(7));
			w19.YOptions = ((global::Gtk.AttachOptions)(0));
			this.vbox5.Add(this.table1);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.table1]));
			w20.Position = 0;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this.hpaned3 = new global::Gtk.HPaned();
			this.hpaned3.CanFocus = true;
			this.hpaned3.Name = "hpaned3";
			this.hpaned3.Position = 664;
			// Container child hpaned3.Gtk.Paned+PanedChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.progressOrders = new global::Gtk.ProgressBar();
			this.progressOrders.Name = "progressOrders";
			this.progressOrders.Ellipsize = ((global::Pango.EllipsizeMode)(1));
			this.hbox8.Add(this.progressOrders);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.progressOrders]));
			w21.Position = 0;
			// Container child hbox8.Gtk.Box+BoxChild
			this.buttonWarnings = new global::Gtk.Button();
			this.buttonWarnings.TooltipMarkup = "Имеются перудупреждения. Нажмите что бы посмотреть.";
			this.buttonWarnings.CanFocus = true;
			this.buttonWarnings.Name = "buttonWarnings";
			this.buttonWarnings.UseUnderline = true;
			this.buttonWarnings.Relief = ((global::Gtk.ReliefStyle)(2));
			global::Gtk.Image w22 = new global::Gtk.Image();
			w22.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-dialog-warning", global::Gtk.IconSize.Menu);
			this.buttonWarnings.Image = w22;
			this.hbox8.Add(this.buttonWarnings);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.buttonWarnings]));
			w23.Position = 1;
			w23.Expand = false;
			w23.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.buttonAutoCreate = new global::Gtk.Button();
			this.buttonAutoCreate.CanFocus = true;
			this.buttonAutoCreate.Name = "buttonAutoCreate";
			this.buttonAutoCreate.UseUnderline = true;
			this.buttonAutoCreate.Label = global::Mono.Unix.Catalog.GetString("Создать маршруты");
			this.hbox8.Add(this.buttonAutoCreate);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.buttonAutoCreate]));
			w24.Position = 2;
			w24.Expand = false;
			w24.Fill = false;
			this.vbox3.Add(this.hbox8);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox8]));
			w25.Position = 0;
			w25.Expand = false;
			w25.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.notebook1 = new global::Gtk.Notebook();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 2;
			this.notebook1.TabPos = ((global::Gtk.PositionType)(0));
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vboxDrivers = new global::Gtk.VBox();
			this.vboxDrivers.Name = "vboxDrivers";
			this.vboxDrivers.Spacing = 6;
			// Container child vboxDrivers.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.ytreeviewOnDayDrivers = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewOnDayDrivers.CanFocus = true;
			this.ytreeviewOnDayDrivers.Name = "ytreeviewOnDayDrivers";
			this.GtkScrolledWindow1.Add(this.ytreeviewOnDayDrivers);
			this.vboxDrivers.Add(this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vboxDrivers[this.GtkScrolledWindow1]));
			w27.Position = 0;
			// Container child vboxDrivers.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonAddDriver = new global::Gtk.Button();
			this.buttonAddDriver.CanFocus = true;
			this.buttonAddDriver.Name = "buttonAddDriver";
			this.buttonAddDriver.UseUnderline = true;
			this.buttonAddDriver.Label = global::Mono.Unix.Catalog.GetString("Добавить водителя");
			global::Gtk.Image w28 = new global::Gtk.Image();
			w28.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.buttonAddDriver.Image = w28;
			this.hbox7.Add(this.buttonAddDriver);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.buttonAddDriver]));
			w29.Position = 0;
			w29.Expand = false;
			w29.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonRemoveDriver = new global::Gtk.Button();
			this.buttonRemoveDriver.CanFocus = true;
			this.buttonRemoveDriver.Name = "buttonRemoveDriver";
			this.buttonRemoveDriver.UseUnderline = true;
			this.buttonRemoveDriver.Label = global::Mono.Unix.Catalog.GetString("Снять водителя");
			global::Gtk.Image w30 = new global::Gtk.Image();
			w30.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-remove", global::Gtk.IconSize.Menu);
			this.buttonRemoveDriver.Image = w30;
			this.hbox7.Add(this.buttonRemoveDriver);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.buttonRemoveDriver]));
			w31.Position = 1;
			w31.Expand = false;
			w31.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonDriverSelectAuto = new global::Gtk.Button();
			this.buttonDriverSelectAuto.CanFocus = true;
			this.buttonDriverSelectAuto.Name = "buttonDriverSelectAuto";
			this.buttonDriverSelectAuto.UseUnderline = true;
			this.buttonDriverSelectAuto.Label = global::Mono.Unix.Catalog.GetString("Выбрать авто");
			global::Gtk.Image w32 = new global::Gtk.Image();
			w32.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("Vodovoz.icons.buttons.car.png");
			this.buttonDriverSelectAuto.Image = w32;
			this.hbox7.Add(this.buttonDriverSelectAuto);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.buttonDriverSelectAuto]));
			w33.Position = 2;
			w33.Expand = false;
			w33.Fill = false;
			this.vboxDrivers.Add(this.hbox7);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.vboxDrivers[this.hbox7]));
			w34.Position = 1;
			w34.Expand = false;
			w34.Fill = false;
			this.notebook1.Add(this.vboxDrivers);
			// Notebook tab
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Водители");
			this.label4.Angle = 270D;
			this.notebook1.SetTabLabel(this.vboxDrivers, this.label4);
			this.label4.ShowAll();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
			this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
			this.ytreeviewOnDayForwarders = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewOnDayForwarders.CanFocus = true;
			this.ytreeviewOnDayForwarders.Name = "ytreeviewOnDayForwarders";
			this.GtkScrolledWindow2.Add(this.ytreeviewOnDayForwarders);
			this.vbox4.Add(this.GtkScrolledWindow2);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.GtkScrolledWindow2]));
			w37.Position = 0;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.buttonAddForwarder = new global::Gtk.Button();
			this.buttonAddForwarder.CanFocus = true;
			this.buttonAddForwarder.Name = "buttonAddForwarder";
			this.buttonAddForwarder.UseUnderline = true;
			this.buttonAddForwarder.Label = global::Mono.Unix.Catalog.GetString("Добавить экспедитора");
			global::Gtk.Image w38 = new global::Gtk.Image();
			w38.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.buttonAddForwarder.Image = w38;
			this.hbox6.Add(this.buttonAddForwarder);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.buttonAddForwarder]));
			w39.Position = 0;
			w39.Expand = false;
			w39.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.buttonRemoveForwarder = new global::Gtk.Button();
			this.buttonRemoveForwarder.CanFocus = true;
			this.buttonRemoveForwarder.Name = "buttonRemoveForwarder";
			this.buttonRemoveForwarder.UseUnderline = true;
			this.buttonRemoveForwarder.Label = global::Mono.Unix.Catalog.GetString("Снять экспедитора");
			global::Gtk.Image w40 = new global::Gtk.Image();
			w40.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-remove", global::Gtk.IconSize.Menu);
			this.buttonRemoveForwarder.Image = w40;
			this.hbox6.Add(this.buttonRemoveForwarder);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.buttonRemoveForwarder]));
			w41.Position = 1;
			w41.Expand = false;
			w41.Fill = false;
			this.vbox4.Add(this.hbox6);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox6]));
			w42.Position = 1;
			w42.Expand = false;
			w42.Fill = false;
			this.notebook1.Add(this.vbox4);
			global::Gtk.Notebook.NotebookChild w43 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1[this.vbox4]));
			w43.Position = 1;
			// Notebook tab
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Экспедиторы");
			this.label5.Angle = 270D;
			this.notebook1.SetTabLabel(this.vbox4, this.label5);
			this.label5.ShowAll();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.vboxRouteLists = new global::Gtk.VBox();
			this.vboxRouteLists.Name = "vboxRouteLists";
			this.vboxRouteLists.Spacing = 6;
			// Container child vboxRouteLists.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeRoutes = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeRoutes.CanFocus = true;
			this.ytreeRoutes.Name = "ytreeRoutes";
			this.GtkScrolledWindow.Add(this.ytreeRoutes);
			this.vboxRouteLists.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.vboxRouteLists[this.GtkScrolledWindow]));
			w45.Position = 0;
			// Container child vboxRouteLists.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.buttonOpen = new global::Gtk.Button();
			this.buttonOpen.CanFocus = true;
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.UseUnderline = true;
			this.buttonOpen.Label = global::Mono.Unix.Catalog.GetString("Открыть");
			this.hbox5.Add(this.buttonOpen);
			global::Gtk.Box.BoxChild w46 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.buttonOpen]));
			w46.Position = 0;
			w46.Expand = false;
			w46.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.buttonRebuildRoute = new global::Gtk.Button();
			this.buttonRebuildRoute.CanFocus = true;
			this.buttonRebuildRoute.Name = "buttonRebuildRoute";
			this.buttonRebuildRoute.UseUnderline = true;
			this.buttonRebuildRoute.Label = global::Mono.Unix.Catalog.GetString("Перестроить маршрут");
			global::Gtk.Image w47 = new global::Gtk.Image();
			w47.Pixbuf = global::Gdk.Pixbuf.LoadFromResource("Vodovoz.icons.buttons.sort-ascending.png");
			this.buttonRebuildRoute.Image = w47;
			this.hbox5.Add(this.buttonRebuildRoute);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.buttonRebuildRoute]));
			w48.Position = 1;
			w48.Expand = false;
			w48.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.buttonRemoveAddress = new global::Gtk.Button();
			this.buttonRemoveAddress.CanFocus = true;
			this.buttonRemoveAddress.Name = "buttonRemoveAddress";
			this.buttonRemoveAddress.UseUnderline = true;
			this.buttonRemoveAddress.Label = global::Mono.Unix.Catalog.GetString("Убрать адрес");
			global::Gtk.Image w49 = new global::Gtk.Image();
			w49.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-remove", global::Gtk.IconSize.Menu);
			this.buttonRemoveAddress.Image = w49;
			this.hbox5.Add(this.buttonRemoveAddress);
			global::Gtk.Box.BoxChild w50 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.buttonRemoveAddress]));
			w50.Position = 2;
			w50.Expand = false;
			w50.Fill = false;
			this.vboxRouteLists.Add(this.hbox5);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(this.vboxRouteLists[this.hbox5]));
			w51.Position = 1;
			w51.Expand = false;
			w51.Fill = false;
			this.notebook1.Add(this.vboxRouteLists);
			global::Gtk.Notebook.NotebookChild w52 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1[this.vboxRouteLists]));
			w52.Position = 2;
			// Notebook tab
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Маршруты");
			this.label6.Angle = 270D;
			this.notebook1.SetTabLabel(this.vboxRouteLists, this.label6);
			this.label6.ShowAll();
			this.vbox3.Add(this.notebook1);
			global::Gtk.Box.BoxChild w53 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.notebook1]));
			w53.Position = 1;
			this.hpaned3.Add(this.vbox3);
			global::Gtk.Paned.PanedChild w54 = ((global::Gtk.Paned.PanedChild)(this.hpaned3[this.vbox3]));
			w54.Resize = false;
			// Container child hpaned3.Gtk.Paned+PanedChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.btnRefresh = new global::Gtk.Button();
			this.btnRefresh.TooltipMarkup = "Обновить";
			this.btnRefresh.CanFocus = true;
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.UseUnderline = true;
			global::Gtk.Image w55 = new global::Gtk.Image();
			w55.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-refresh", global::Gtk.IconSize.Menu);
			this.btnRefresh.Image = w55;
			this.hbox3.Add(this.btnRefresh);
			global::Gtk.Box.BoxChild w56 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.btnRefresh]));
			w56.Position = 0;
			w56.Expand = false;
			w56.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.labelSelected = new global::Gtk.Label();
			this.labelSelected.Name = "labelSelected";
			this.labelSelected.LabelProp = global::Mono.Unix.Catalog.GetString("Адресов\nне выбрано");
			this.labelSelected.Justify = ((global::Gtk.Justification)(2));
			this.hbox3.Add(this.labelSelected);
			global::Gtk.Box.BoxChild w57 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.labelSelected]));
			w57.Position = 1;
			w57.Expand = false;
			w57.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.menuAddToRL = new global::QSWidgetLib.MenuButton();
			this.menuAddToRL.Sensitive = false;
			this.menuAddToRL.CanFocus = true;
			this.menuAddToRL.Name = "menuAddToRL";
			this.menuAddToRL.UseUnderline = true;
			this.menuAddToRL.UseMarkup = false;
			this.menuAddToRL.LabelXAlign = 0F;
			this.menuAddToRL.Label = global::Mono.Unix.Catalog.GetString("В маршрутный лист");
			global::Gtk.Image w58 = new global::Gtk.Image();
			w58.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.menuAddToRL.Image = w58;
			this.hbox3.Add(this.menuAddToRL);
			global::Gtk.Box.BoxChild w59 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.menuAddToRL]));
			w59.Position = 2;
			w59.Expand = false;
			w59.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.checkShowDistricts = new global::Gtk.CheckButton();
			this.checkShowDistricts.CanFocus = true;
			this.checkShowDistricts.Name = "checkShowDistricts";
			this.checkShowDistricts.Label = global::Mono.Unix.Catalog.GetString("Районы");
			this.checkShowDistricts.DrawIndicator = true;
			this.checkShowDistricts.UseUnderline = true;
			this.hbox3.Add(this.checkShowDistricts);
			global::Gtk.Box.BoxChild w60 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.checkShowDistricts]));
			w60.Position = 3;
			w60.Expand = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.yspinMaxTime = new global::Gamma.GtkWidgets.ySpinButton(0D, 1000D, 1D);
			this.yspinMaxTime.TooltipMarkup = "Максимальное время оптимизаций, в секундах.";
			this.yspinMaxTime.CanFocus = true;
			this.yspinMaxTime.Name = "yspinMaxTime";
			this.yspinMaxTime.Adjustment.PageIncrement = 10D;
			this.yspinMaxTime.ClimbRate = 1D;
			this.yspinMaxTime.Numeric = true;
			this.yspinMaxTime.UpdatePolicy = ((global::Gtk.SpinButtonUpdatePolicy)(1));
			this.yspinMaxTime.Value = 30D;
			this.yspinMaxTime.ValueAsDecimal = 0m;
			this.yspinMaxTime.ValueAsInt = 0;
			this.hbox3.Add(this.yspinMaxTime);
			global::Gtk.Box.BoxChild w61 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.yspinMaxTime]));
			w61.Position = 4;
			w61.Expand = false;
			w61.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vseparator2 = new global::Gtk.VSeparator();
			this.vseparator2.Name = "vseparator2";
			this.hbox3.Add(this.vseparator2);
			global::Gtk.Box.BoxChild w62 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vseparator2]));
			w62.Position = 5;
			w62.Expand = false;
			w62.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.yenumcomboMapType = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumcomboMapType.Name = "yenumcomboMapType";
			this.yenumcomboMapType.ShowSpecialStateAll = false;
			this.yenumcomboMapType.ShowSpecialStateNot = false;
			this.yenumcomboMapType.UseShortTitle = false;
			this.yenumcomboMapType.DefaultFirst = true;
			this.hbox3.Add(this.yenumcomboMapType);
			global::Gtk.Box.BoxChild w63 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.yenumcomboMapType]));
			w63.Position = 6;
			w63.Expand = false;
			w63.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonMapHelp = new global::Gtk.Button();
			this.buttonMapHelp.TooltipMarkup = "Справка по работе с картой.";
			this.buttonMapHelp.CanFocus = true;
			this.buttonMapHelp.Name = "buttonMapHelp";
			this.buttonMapHelp.UseUnderline = true;
			this.buttonMapHelp.Relief = ((global::Gtk.ReliefStyle)(1));
			global::Gtk.Image w64 = new global::Gtk.Image();
			w64.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-help", global::Gtk.IconSize.Menu);
			this.buttonMapHelp.Image = w64;
			this.hbox3.Add(this.buttonMapHelp);
			global::Gtk.Box.BoxChild w65 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.buttonMapHelp]));
			w65.Position = 7;
			w65.Expand = false;
			this.vbox2.Add(this.hbox3);
			global::Gtk.Box.BoxChild w66 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox3]));
			w66.Position = 0;
			w66.Expand = false;
			w66.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.gmapWidget = new global::GMap.NET.GtkSharp.GMapControl();
			this.gmapWidget.Name = "gmapWidget";
			this.gmapWidget.MaxZoom = 24;
			this.gmapWidget.MinZoom = 0;
			this.gmapWidget.MouseWheelZoomEnabled = true;
			this.gmapWidget.ShowTileGridLines = false;
			this.gmapWidget.GrayScaleMode = false;
			this.gmapWidget.NegativeMode = false;
			this.gmapWidget.HasFrame = false;
			this.gmapWidget.Bearing = 0F;
			this.gmapWidget.Zoom = 9D;
			this.gmapWidget.RoutesEnabled = true;
			this.gmapWidget.PolygonsEnabled = true;
			this.gmapWidget.MarkersEnabled = true;
			this.gmapWidget.CanDragMap = true;
			this.vbox2.Add(this.gmapWidget);
			global::Gtk.Box.BoxChild w67 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.gmapWidget]));
			w67.Position = 1;
			this.hpaned3.Add(this.vbox2);
			this.vbox5.Add(this.hpaned3);
			global::Gtk.Box.BoxChild w69 = ((global::Gtk.Box.BoxChild)(this.vbox5[this.hpaned3]));
			w69.Position = 1;
			this.Add(this.vbox5);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.buttonWarnings.Hide();
			this.Hide();
			this.ydateForRoutes.DateChanged += new global::System.EventHandler(this.OnYdateForRoutesDateChanged);
			this.ytimeToDeliveryTo.WidgetEvent += new global::Gtk.WidgetEventHandler(this.OnFilterWidgetEvent);
			this.ytimeToDeliveryFrom.WidgetEvent += new global::Gtk.WidgetEventHandler(this.OnFilterWidgetEvent);
			this.ySpnMin19Btls.WidgetEvent += new global::Gtk.WidgetEventHandler(this.OnFilterWidgetEvent);
			this.buttonFilter.Clicked += new global::System.EventHandler(this.OnButtonLoadClicked);
			this.label2.WidgetEvent += new global::Gtk.WidgetEventHandler(this.OnLabel2WidgetEvent);
			this.checkShowCompleted.Toggled += new global::System.EventHandler(this.OnCheckShowCompletedToggled);
			this.buttonWarnings.Clicked += new global::System.EventHandler(this.OnButtonWarningsClicked);
			this.buttonAutoCreate.Clicked += new global::System.EventHandler(this.OnButtonAutoCreateClicked);
			this.ytreeviewOnDayDrivers.RowActivated += new global::Gtk.RowActivatedHandler(this.OnYtreeviewOnDayDriversRowActivated);
			this.buttonAddDriver.Clicked += new global::System.EventHandler(this.OnButtonAddDriverClicked);
			this.buttonRemoveDriver.Clicked += new global::System.EventHandler(this.OnButtonRemoveDriverClicked);
			this.buttonDriverSelectAuto.Clicked += new global::System.EventHandler(this.OnButtonDriverSelectAutoClicked);
			this.buttonAddForwarder.Clicked += new global::System.EventHandler(this.OnButtonAddForwarderClicked);
			this.buttonRemoveForwarder.Clicked += new global::System.EventHandler(this.OnButtonRemoveForwarderClicked);
			this.buttonOpen.Clicked += new global::System.EventHandler(this.OnButtonOpenClicked);
			this.buttonRebuildRoute.Clicked += new global::System.EventHandler(this.OnButtonRebuildRouteClicked);
			this.buttonRemoveAddress.Clicked += new global::System.EventHandler(this.OnButtonRemoveAddressClicked);
			this.checkShowDistricts.Toggled += new global::System.EventHandler(this.OnCheckShowDistrictsToggled);
			this.yenumcomboMapType.ChangedByUser += new global::System.EventHandler(this.OnYenumcomboMapTypeChangedByUser);
			this.buttonMapHelp.Clicked += new global::System.EventHandler(this.OnButtonMapHelpClicked);
		}
	}
}
