
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ReportsParameters.Orders
{
	public partial class NomenclaturePlanReport
	{
		private global::Gtk.ScrolledWindow scrolledwindow1;

		private global::Gtk.VBox vbox4;

		private global::Gtk.HBox hbox11;

		private global::Gtk.Label label3;

		private global::QSWidgetLib.DatePeriodPicker dateperiodReportDate;

		private global::Gtk.Button buttonHelp;

		private global::Gtk.Button buttonNomenclaturePlan;

		private global::Gtk.HSeparator hseparator1;

		private global::Gtk.Table table1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow3;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewSelectedEmployees;

		private global::Gtk.HSeparator hseparator3;

		private global::Gtk.HSeparator hseparator5;

		private global::Gtk.HSeparator hseparator6;

		private global::Gtk.VBox vbox1;

		private global::Gtk.Label label4;

		private global::Gtk.HBox hbox4;

		private global::Gtk.VBox vbox15;

		private global::Gtk.Table table4;

		private global::Gamma.Widgets.yEnumComboBox enumType;

		private global::Gtk.Label label6;

		private global::Gtk.Label label7;

		private global::QS.Widgets.GtkUI.RepresentationEntry yentryProductGroup;

		private global::Gtk.HBox hboxNomenclatureSearch;

		private global::Gtk.Label label11;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewNomenclatures;

		private global::Gtk.VBox vbox10;

		private global::Gtk.VSeparator vseparator3;

		private global::Gtk.VBox vbox11;

		private global::Gtk.VBox vbox12;

		private global::Gtk.Label label14;

		private global::Gtk.Button btnNomenclatureAdd;

		private global::Gtk.Button btnNomenclatureDelete;

		private global::Gtk.Label label15;

		private global::Gtk.VBox vbox13;

		private global::Gtk.VBox vbox14;

		private global::Gtk.Label label16;

		private global::Gtk.Button btnEmployeeAdd;

		private global::Gtk.Button btnEmployeeDelete;

		private global::Gtk.Label label17;

		private global::Gtk.VBox vbox2;

		private global::Gtk.ScrolledWindow GtkScrolledWindow2;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewSelectedNomenclatures;

		private global::Gamma.GtkWidgets.yButton ybuttonSave;

		private global::Gtk.VBox vbox6;

		private global::Gtk.Label label9;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Label label13;

		private global::Gtk.VBox vbox8;

		private global::Gamma.Widgets.ySpecComboBox ycomboboxSubdivision;

		private global::Gtk.HBox hboxEmployeeSearch;

		private global::Gtk.Label label12;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewEmployees;

		private global::Gtk.VBox vbox9;

		private global::Gtk.VSeparator vseparator6;

		private global::Gtk.VSeparator vseparator4;

		private global::Gtk.VSeparator vseparator5;

		private global::Gtk.Button buttonCreateReport;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ReportsParameters.Orders.NomenclaturePlanReport
			global::Stetic.BinContainer.Attach(this);
			this.WidthRequest = 750;
			this.Name = "Vodovoz.ReportsParameters.Orders.NomenclaturePlanReport";
			// Container child Vodovoz.ReportsParameters.Orders.NomenclaturePlanReport.Gtk.Container+ContainerChild
			this.scrolledwindow1 = new global::Gtk.ScrolledWindow();
			this.scrolledwindow1.CanFocus = true;
			this.scrolledwindow1.Name = "scrolledwindow1";
			this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow1.Gtk.Container+ContainerChild
			global::Gtk.Viewport w1 = new global::Gtk.Viewport();
			w1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox11 = new global::Gtk.HBox();
			this.hbox11.Name = "hbox11";
			this.hbox11.Spacing = 6;
			// Container child hbox11.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Дата:");
			this.hbox11.Add(this.label3);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox11[this.label3]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox11.Gtk.Box+BoxChild
			this.dateperiodReportDate = new global::QSWidgetLib.DatePeriodPicker();
			this.dateperiodReportDate.WidthRequest = 285;
			this.dateperiodReportDate.Events = ((global::Gdk.EventMask)(256));
			this.dateperiodReportDate.Name = "dateperiodReportDate";
			this.dateperiodReportDate.StartDate = new global::System.DateTime(0);
			this.dateperiodReportDate.EndDate = new global::System.DateTime(0);
			this.hbox11.Add(this.dateperiodReportDate);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox11[this.dateperiodReportDate]));
			w3.Position = 1;
			w3.Expand = false;
			// Container child hbox11.Gtk.Box+BoxChild
			this.buttonHelp = new global::Gtk.Button();
			this.buttonHelp.CanFocus = true;
			this.buttonHelp.Name = "buttonHelp";
			this.buttonHelp.UseUnderline = true;
			this.buttonHelp.Label = global::Mono.Unix.Catalog.GetString("Справка");
			global::Gtk.Image w4 = new global::Gtk.Image();
			w4.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-help", global::Gtk.IconSize.Menu);
			this.buttonHelp.Image = w4;
			this.hbox11.Add(this.buttonHelp);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox11[this.buttonHelp]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox11.Gtk.Box+BoxChild
			this.buttonNomenclaturePlan = new global::Gtk.Button();
			this.buttonNomenclaturePlan.CanFocus = true;
			this.buttonNomenclaturePlan.Name = "buttonNomenclaturePlan";
			this.buttonNomenclaturePlan.UseUnderline = true;
			this.buttonNomenclaturePlan.Label = global::Mono.Unix.Catalog.GetString("План продаж");
			global::Gtk.Image w6 = new global::Gtk.Image();
			w6.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-preferences", global::Gtk.IconSize.Menu);
			this.buttonNomenclaturePlan.Image = w6;
			this.hbox11.Add(this.buttonNomenclaturePlan);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox11[this.buttonNomenclaturePlan]));
			w7.PackType = ((global::Gtk.PackType)(1));
			w7.Position = 3;
			w7.Expand = false;
			w7.Fill = false;
			this.vbox4.Add(this.hbox11);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox11]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hseparator1 = new global::Gtk.HSeparator();
			this.hseparator1.Name = "hseparator1";
			this.vbox4.Add(this.hseparator1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hseparator1]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(3)), ((uint)(5)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow3 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow3.WidthRequest = 320;
			this.GtkScrolledWindow3.Name = "GtkScrolledWindow3";
			this.GtkScrolledWindow3.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow3.Gtk.Container+ContainerChild
			this.ytreeviewSelectedEmployees = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewSelectedEmployees.CanFocus = true;
			this.ytreeviewSelectedEmployees.Name = "ytreeviewSelectedEmployees";
			this.GtkScrolledWindow3.Add(this.ytreeviewSelectedEmployees);
			this.table1.Add(this.GtkScrolledWindow3);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.GtkScrolledWindow3]));
			w11.TopAttach = ((uint)(2));
			w11.BottomAttach = ((uint)(3));
			w11.LeftAttach = ((uint)(4));
			w11.RightAttach = ((uint)(5));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hseparator3 = new global::Gtk.HSeparator();
			this.hseparator3.Name = "hseparator3";
			this.table1.Add(this.hseparator3);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.hseparator3]));
			w12.TopAttach = ((uint)(1));
			w12.BottomAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hseparator5 = new global::Gtk.HSeparator();
			this.hseparator5.Name = "hseparator5";
			this.table1.Add(this.hseparator5);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.hseparator5]));
			w13.TopAttach = ((uint)(1));
			w13.BottomAttach = ((uint)(2));
			w13.LeftAttach = ((uint)(4));
			w13.RightAttach = ((uint)(5));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hseparator6 = new global::Gtk.HSeparator();
			this.hseparator6.Name = "hseparator6";
			this.table1.Add(this.hseparator6);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.hseparator6]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(2));
			w14.LeftAttach = ((uint)(2));
			w14.RightAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 0F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("ТМЦ");
			this.vbox1.Add(this.label4);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.label4]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.vbox15 = new global::Gtk.VBox();
			this.vbox15.Name = "vbox15";
			this.vbox15.Spacing = 6;
			// Container child vbox15.Gtk.Box+BoxChild
			this.table4 = new global::Gtk.Table(((uint)(2)), ((uint)(2)), false);
			this.table4.Name = "table4";
			this.table4.RowSpacing = ((uint)(6));
			this.table4.ColumnSpacing = ((uint)(6));
			// Container child table4.Gtk.Table+TableChild
			this.enumType = new global::Gamma.Widgets.yEnumComboBox();
			this.enumType.WidthRequest = 270;
			this.enumType.Name = "enumType";
			this.enumType.ShowSpecialStateAll = false;
			this.enumType.ShowSpecialStateNot = false;
			this.enumType.UseShortTitle = false;
			this.enumType.DefaultFirst = true;
			this.table4.Add(this.enumType);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table4[this.enumType]));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.Xalign = 0F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Тип:");
			this.table4.Add(this.label6);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table4[this.label6]));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 0F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Группа:");
			this.table4.Add(this.label7);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table4[this.label7]));
			w18.TopAttach = ((uint)(1));
			w18.BottomAttach = ((uint)(2));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.yentryProductGroup = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.yentryProductGroup.Events = ((global::Gdk.EventMask)(256));
			this.yentryProductGroup.Name = "yentryProductGroup";
			this.table4.Add(this.yentryProductGroup);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table4[this.yentryProductGroup]));
			w19.TopAttach = ((uint)(1));
			w19.BottomAttach = ((uint)(2));
			w19.LeftAttach = ((uint)(1));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox15.Add(this.table4);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox15[this.table4]));
			w20.Position = 0;
			w20.Expand = false;
			w20.Fill = false;
			this.hbox4.Add(this.vbox15);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.vbox15]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			this.vbox1.Add(this.hbox4);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox4]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hboxNomenclatureSearch = new global::Gtk.HBox();
			this.hboxNomenclatureSearch.Name = "hboxNomenclatureSearch";
			this.hboxNomenclatureSearch.Spacing = 6;
			this.vbox1.Add(this.hboxNomenclatureSearch);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hboxNomenclatureSearch]));
			w23.Position = 2;
			// Container child vbox1.Gtk.Box+BoxChild
			this.label11 = new global::Gtk.Label();
			this.label11.Name = "label11";
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString("Номенклатура");
			this.vbox1.Add(this.label11);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.label11]));
			w24.Position = 3;
			w24.Expand = false;
			w24.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.WidthRequest = 320;
			this.GtkScrolledWindow.HeightRequest = 200;
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewNomenclatures = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewNomenclatures.CanFocus = true;
			this.ytreeviewNomenclatures.Name = "ytreeviewNomenclatures";
			this.GtkScrolledWindow.Add(this.ytreeviewNomenclatures);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w26.Position = 4;
			this.table1.Add(this.vbox1);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.table1[this.vbox1]));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.vbox10 = new global::Gtk.VBox();
			this.vbox10.Name = "vbox10";
			this.vbox10.Spacing = 6;
			// Container child vbox10.Gtk.Box+BoxChild
			this.vseparator3 = new global::Gtk.VSeparator();
			this.vseparator3.Name = "vseparator3";
			this.vbox10.Add(this.vseparator3);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.vbox10[this.vseparator3]));
			w28.Position = 0;
			this.table1.Add(this.vbox10);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.table1[this.vbox10]));
			w29.TopAttach = ((uint)(2));
			w29.BottomAttach = ((uint)(3));
			w29.LeftAttach = ((uint)(1));
			w29.RightAttach = ((uint)(2));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.vbox11 = new global::Gtk.VBox();
			this.vbox11.Name = "vbox11";
			this.vbox11.Spacing = 6;
			// Container child vbox11.Gtk.Box+BoxChild
			this.vbox12 = new global::Gtk.VBox();
			this.vbox12.Name = "vbox12";
			this.vbox12.Spacing = 6;
			// Container child vbox12.Gtk.Box+BoxChild
			this.label14 = new global::Gtk.Label();
			this.label14.Name = "label14";
			this.vbox12.Add(this.label14);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox12[this.label14]));
			w30.Position = 0;
			w30.Fill = false;
			// Container child vbox12.Gtk.Box+BoxChild
			this.btnNomenclatureAdd = new global::Gtk.Button();
			this.btnNomenclatureAdd.CanFocus = true;
			this.btnNomenclatureAdd.Name = "btnNomenclatureAdd";
			this.btnNomenclatureAdd.UseUnderline = true;
			global::Gtk.Image w31 = new global::Gtk.Image();
			w31.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-go-forward", global::Gtk.IconSize.Button);
			this.btnNomenclatureAdd.Image = w31;
			this.vbox12.Add(this.btnNomenclatureAdd);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox12[this.btnNomenclatureAdd]));
			w32.Position = 1;
			w32.Expand = false;
			w32.Fill = false;
			// Container child vbox12.Gtk.Box+BoxChild
			this.btnNomenclatureDelete = new global::Gtk.Button();
			this.btnNomenclatureDelete.CanFocus = true;
			this.btnNomenclatureDelete.Name = "btnNomenclatureDelete";
			this.btnNomenclatureDelete.UseUnderline = true;
			global::Gtk.Image w33 = new global::Gtk.Image();
			w33.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-go-back", global::Gtk.IconSize.Button);
			this.btnNomenclatureDelete.Image = w33;
			this.vbox12.Add(this.btnNomenclatureDelete);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.vbox12[this.btnNomenclatureDelete]));
			w34.Position = 2;
			w34.Expand = false;
			w34.Fill = false;
			// Container child vbox12.Gtk.Box+BoxChild
			this.label15 = new global::Gtk.Label();
			this.label15.Name = "label15";
			this.vbox12.Add(this.label15);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vbox12[this.label15]));
			w35.Position = 3;
			w35.Fill = false;
			this.vbox11.Add(this.vbox12);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox11[this.vbox12]));
			w36.Position = 0;
			w36.Expand = false;
			w36.Fill = false;
			this.table1.Add(this.vbox11);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.table1[this.vbox11]));
			w37.LeftAttach = ((uint)(2));
			w37.RightAttach = ((uint)(3));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(1));
			// Container child table1.Gtk.Table+TableChild
			this.vbox13 = new global::Gtk.VBox();
			this.vbox13.Name = "vbox13";
			this.vbox13.Spacing = 6;
			// Container child vbox13.Gtk.Box+BoxChild
			this.vbox14 = new global::Gtk.VBox();
			this.vbox14.Name = "vbox14";
			this.vbox14.Spacing = 6;
			// Container child vbox14.Gtk.Box+BoxChild
			this.label16 = new global::Gtk.Label();
			this.label16.Name = "label16";
			this.vbox14.Add(this.label16);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.vbox14[this.label16]));
			w38.Position = 0;
			w38.Fill = false;
			// Container child vbox14.Gtk.Box+BoxChild
			this.btnEmployeeAdd = new global::Gtk.Button();
			this.btnEmployeeAdd.CanFocus = true;
			this.btnEmployeeAdd.Name = "btnEmployeeAdd";
			this.btnEmployeeAdd.UseUnderline = true;
			global::Gtk.Image w39 = new global::Gtk.Image();
			w39.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-go-forward", global::Gtk.IconSize.Button);
			this.btnEmployeeAdd.Image = w39;
			this.vbox14.Add(this.btnEmployeeAdd);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.vbox14[this.btnEmployeeAdd]));
			w40.Position = 1;
			w40.Expand = false;
			w40.Fill = false;
			// Container child vbox14.Gtk.Box+BoxChild
			this.btnEmployeeDelete = new global::Gtk.Button();
			this.btnEmployeeDelete.CanFocus = true;
			this.btnEmployeeDelete.Name = "btnEmployeeDelete";
			this.btnEmployeeDelete.UseUnderline = true;
			global::Gtk.Image w41 = new global::Gtk.Image();
			w41.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-go-back", global::Gtk.IconSize.Button);
			this.btnEmployeeDelete.Image = w41;
			this.vbox14.Add(this.btnEmployeeDelete);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.vbox14[this.btnEmployeeDelete]));
			w42.Position = 2;
			w42.Expand = false;
			w42.Fill = false;
			// Container child vbox14.Gtk.Box+BoxChild
			this.label17 = new global::Gtk.Label();
			this.label17.Name = "label17";
			this.vbox14.Add(this.label17);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.vbox14[this.label17]));
			w43.Position = 3;
			w43.Fill = false;
			this.vbox13.Add(this.vbox14);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.vbox13[this.vbox14]));
			w44.Position = 0;
			w44.Expand = false;
			w44.Fill = false;
			this.table1.Add(this.vbox13);
			global::Gtk.Table.TableChild w45 = ((global::Gtk.Table.TableChild)(this.table1[this.vbox13]));
			w45.TopAttach = ((uint)(2));
			w45.BottomAttach = ((uint)(3));
			w45.LeftAttach = ((uint)(2));
			w45.RightAttach = ((uint)(3));
			w45.XOptions = ((global::Gtk.AttachOptions)(4));
			w45.YOptions = ((global::Gtk.AttachOptions)(1));
			// Container child table1.Gtk.Table+TableChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow2.WidthRequest = 320;
			this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
			this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
			this.ytreeviewSelectedNomenclatures = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewSelectedNomenclatures.CanFocus = true;
			this.ytreeviewSelectedNomenclatures.Name = "ytreeviewSelectedNomenclatures";
			this.GtkScrolledWindow2.Add(this.ytreeviewSelectedNomenclatures);
			this.vbox2.Add(this.GtkScrolledWindow2);
			global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow2]));
			w47.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.ybuttonSave = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonSave.CanFocus = true;
			this.ybuttonSave.Name = "ybuttonSave";
			this.ybuttonSave.UseUnderline = true;
			this.ybuttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить по умолчанию");
			this.vbox2.Add(this.ybuttonSave);
			global::Gtk.Box.BoxChild w48 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.ybuttonSave]));
			w48.Position = 1;
			w48.Expand = false;
			w48.Fill = false;
			this.table1.Add(this.vbox2);
			global::Gtk.Table.TableChild w49 = ((global::Gtk.Table.TableChild)(this.table1[this.vbox2]));
			w49.LeftAttach = ((uint)(4));
			w49.RightAttach = ((uint)(5));
			w49.XOptions = ((global::Gtk.AttachOptions)(4));
			w49.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.vbox6 = new global::Gtk.VBox();
			this.vbox6.Name = "vbox6";
			this.vbox6.Spacing = 6;
			// Container child vbox6.Gtk.Box+BoxChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.Xalign = 0F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("Сотрудники");
			this.vbox6.Add(this.label9);
			global::Gtk.Box.BoxChild w50 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.label9]));
			w50.Position = 0;
			w50.Expand = false;
			w50.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label13 = new global::Gtk.Label();
			this.label13.Name = "label13";
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString("Подразделение:");
			this.hbox7.Add(this.label13);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.label13]));
			w51.Position = 0;
			w51.Expand = false;
			w51.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.vbox8 = new global::Gtk.VBox();
			this.vbox8.Name = "vbox8";
			this.vbox8.Spacing = 6;
			// Container child vbox8.Gtk.Box+BoxChild
			this.ycomboboxSubdivision = new global::Gamma.Widgets.ySpecComboBox();
            this.ycomboboxSubdivision.WidthRequest = 220;
			this.ycomboboxSubdivision.Name = "ycomboboxSubdivision";
			this.ycomboboxSubdivision.AddIfNotExist = false;
			this.ycomboboxSubdivision.DefaultFirst = true;
			this.ycomboboxSubdivision.ShowSpecialStateAll = true;
			this.ycomboboxSubdivision.ShowSpecialStateNot = false;
			this.vbox8.Add(this.ycomboboxSubdivision);
			global::Gtk.Box.BoxChild w52 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.ycomboboxSubdivision]));
			w52.Position = 0;
			w52.Expand = false;
			w52.Fill = false;
			this.hbox7.Add(this.vbox8);
			global::Gtk.Box.BoxChild w53 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.vbox8]));
			w53.Position = 1;
			w53.Expand = false;
			w53.Fill = false;
			this.vbox6.Add(this.hbox7);
			global::Gtk.Box.BoxChild w54 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.hbox7]));
			w54.Position = 1;
			w54.Expand = false;
			w54.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.hboxEmployeeSearch = new global::Gtk.HBox();
			this.hboxEmployeeSearch.Name = "hboxEmployeeSearch";
			this.hboxEmployeeSearch.Spacing = 6;
			this.vbox6.Add(this.hboxEmployeeSearch);
			global::Gtk.Box.BoxChild w55 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.hboxEmployeeSearch]));
			w55.Position = 2;
			// Container child vbox6.Gtk.Box+BoxChild
			this.label12 = new global::Gtk.Label();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString("Сотрудники");
			this.vbox6.Add(this.label12);
			global::Gtk.Box.BoxChild w56 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.label12]));
			w56.Position = 3;
			w56.Expand = false;
			w56.Fill = false;
			// Container child vbox6.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.WidthRequest = 320;
			this.GtkScrolledWindow1.HeightRequest = 200;
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.ytreeviewEmployees = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewEmployees.CanFocus = true;
			this.ytreeviewEmployees.Name = "ytreeviewEmployees";
			this.GtkScrolledWindow1.Add(this.ytreeviewEmployees);
			this.vbox6.Add(this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w58 = ((global::Gtk.Box.BoxChild)(this.vbox6[this.GtkScrolledWindow1]));
			w58.Position = 4;
			this.table1.Add(this.vbox6);
			global::Gtk.Table.TableChild w59 = ((global::Gtk.Table.TableChild)(this.table1[this.vbox6]));
			w59.TopAttach = ((uint)(2));
			w59.BottomAttach = ((uint)(3));
			w59.XOptions = ((global::Gtk.AttachOptions)(4));
			w59.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.vbox9 = new global::Gtk.VBox();
			this.vbox9.Name = "vbox9";
			this.vbox9.Spacing = 6;
			// Container child vbox9.Gtk.Box+BoxChild
			this.vseparator6 = new global::Gtk.VSeparator();
			this.vseparator6.Name = "vseparator6";
			this.vbox9.Add(this.vseparator6);
			global::Gtk.Box.BoxChild w60 = ((global::Gtk.Box.BoxChild)(this.vbox9[this.vseparator6]));
			w60.Position = 0;
			this.table1.Add(this.vbox9);
			global::Gtk.Table.TableChild w61 = ((global::Gtk.Table.TableChild)(this.table1[this.vbox9]));
			w61.LeftAttach = ((uint)(1));
			w61.RightAttach = ((uint)(2));
			w61.XOptions = ((global::Gtk.AttachOptions)(4));
			w61.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.vseparator4 = new global::Gtk.VSeparator();
			this.vseparator4.Name = "vseparator4";
			this.table1.Add(this.vseparator4);
			global::Gtk.Table.TableChild w62 = ((global::Gtk.Table.TableChild)(this.table1[this.vseparator4]));
			w62.LeftAttach = ((uint)(3));
			w62.RightAttach = ((uint)(4));
			w62.XOptions = ((global::Gtk.AttachOptions)(4));
			w62.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.vseparator5 = new global::Gtk.VSeparator();
			this.vseparator5.Name = "vseparator5";
			this.table1.Add(this.vseparator5);
			global::Gtk.Table.TableChild w63 = ((global::Gtk.Table.TableChild)(this.table1[this.vseparator5]));
			w63.TopAttach = ((uint)(2));
			w63.BottomAttach = ((uint)(3));
			w63.LeftAttach = ((uint)(3));
			w63.RightAttach = ((uint)(4));
			w63.XOptions = ((global::Gtk.AttachOptions)(4));
			w63.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox4.Add(this.table1);
			global::Gtk.Box.BoxChild w64 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.table1]));
			w64.Position = 2;
			w64.Expand = false;
			w64.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.buttonCreateReport = new global::Gtk.Button();
			this.buttonCreateReport.CanFocus = true;
			this.buttonCreateReport.Name = "buttonCreateReport";
			this.buttonCreateReport.UseUnderline = true;
			this.buttonCreateReport.Label = global::Mono.Unix.Catalog.GetString("Сформировать отчет");
			this.vbox4.Add(this.buttonCreateReport);
			global::Gtk.Box.BoxChild w65 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.buttonCreateReport]));
			w65.Position = 3;
			w65.Expand = false;
			w65.Fill = false;
			w65.Padding = ((uint)(15));
			w1.Add(this.vbox4);
			this.scrolledwindow1.Add(w1);
			this.Add(this.scrolledwindow1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
