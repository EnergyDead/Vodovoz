
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class RouteListCreateDlg
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.Table dataRouteList;

		private global::QS.Widgets.GtkUI.DatePicker datepickerDate;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry entityviewmodelentryCar;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry evmeDriver;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry evmeForwarder;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry evmeLogistician;

		private global::Vodovoz.ViewWidgets.GeographicGroupsToStringWidget ggToStringWidget;

		private global::Gtk.HBox hbox7;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button btnCancel;

		private global::Gtk.HBox hboxCash;

		private global::Gamma.GtkWidgets.yLabel labelTerminalCondition;

		private global::Gtk.VSeparator vseparator1;

		private global::Gtk.Label label7;

		private global::Gamma.Widgets.ySpecComboBox yspeccomboboxCashSubdivision;

		private global::Gamma.GtkWidgets.yHBox hboxDriverComment;

		private global::Gamma.GtkWidgets.yLabel lblDriverCommentTitle;

		private global::Gamma.GtkWidgets.yLabel lblDriverComment;

		private global::Gamma.GtkWidgets.yHBox hboxForwarderComment;

		private global::Gamma.GtkWidgets.yLabel lblForwarderCommentTitle;

		private global::Gamma.GtkWidgets.yLabel lblForwarderComment;

		private global::Gtk.HSeparator hseparator2;

		private global::Gtk.HSeparator hseparator3;

		private global::Gtk.Label label1;

		private global::Gtk.Label label10;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gtk.Label label9;

		private global::Gamma.GtkWidgets.yLabel labelStatus;

		private global::Vodovoz.ViewWidgets.Mango.EmployeePhone phoneDriver;

		private global::Vodovoz.ViewWidgets.Mango.EmployeePhone phoneForwarder;

		private global::Vodovoz.ViewWidgets.Mango.EmployeePhone phoneLogistican;

		private global::Gamma.Widgets.ySpecComboBox speccomboShift;

		private global::Vodovoz.RouteListCreateItemsView createroutelistitemsview1;

		private global::Gtk.HBox hbox9;

		private global::Gamma.GtkWidgets.yButton printTimeButton;

		private global::QS.Widgets.EnumMenuButton enumPrint;

		private global::Gtk.Button buttonAccept;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.RouteListCreateDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.RouteListCreateDlg";
			// Container child Vodovoz.RouteListCreateDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(6));
			// Container child vbox1.Gtk.Box+BoxChild
			this.dataRouteList = new global::Gtk.Table(((uint)(8)), ((uint)(7)), false);
			this.dataRouteList.Name = "dataRouteList";
			this.dataRouteList.RowSpacing = ((uint)(6));
			this.dataRouteList.ColumnSpacing = ((uint)(6));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.datepickerDate = new global::QS.Widgets.GtkUI.DatePicker();
			this.datepickerDate.Events = ((global::Gdk.EventMask)(256));
			this.datepickerDate.Name = "datepickerDate";
			this.datepickerDate.WithTime = false;
			this.datepickerDate.HideCalendarButton = false;
			this.datepickerDate.Date = new global::System.DateTime(0);
			this.datepickerDate.IsEditable = true;
			this.datepickerDate.AutoSeparation = true;
			this.dataRouteList.Add(this.datepickerDate);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.datepickerDate]));
			w1.TopAttach = ((uint)(3));
			w1.BottomAttach = ((uint)(4));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.entityviewmodelentryCar = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.entityviewmodelentryCar.Events = ((global::Gdk.EventMask)(256));
			this.entityviewmodelentryCar.Name = "entityviewmodelentryCar";
			this.entityviewmodelentryCar.CanEditReference = true;
			this.dataRouteList.Add(this.entityviewmodelentryCar);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.entityviewmodelentryCar]));
			w2.TopAttach = ((uint)(2));
			w2.BottomAttach = ((uint)(3));
			w2.LeftAttach = ((uint)(5));
			w2.RightAttach = ((uint)(6));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.evmeDriver = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.evmeDriver.Events = ((global::Gdk.EventMask)(256));
			this.evmeDriver.Name = "evmeDriver";
			this.evmeDriver.CanEditReference = true;
			this.dataRouteList.Add(this.evmeDriver);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.evmeDriver]));
			w3.TopAttach = ((uint)(3));
			w3.BottomAttach = ((uint)(4));
			w3.LeftAttach = ((uint)(5));
			w3.RightAttach = ((uint)(6));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.evmeForwarder = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.evmeForwarder.Events = ((global::Gdk.EventMask)(256));
			this.evmeForwarder.Name = "evmeForwarder";
			this.evmeForwarder.CanEditReference = true;
			this.dataRouteList.Add(this.evmeForwarder);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.evmeForwarder]));
			w4.TopAttach = ((uint)(5));
			w4.BottomAttach = ((uint)(6));
			w4.LeftAttach = ((uint)(5));
			w4.RightAttach = ((uint)(6));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.evmeLogistician = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.evmeLogistician.Events = ((global::Gdk.EventMask)(256));
			this.evmeLogistician.Name = "evmeLogistician";
			this.evmeLogistician.CanEditReference = true;
			this.dataRouteList.Add(this.evmeLogistician);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.evmeLogistician]));
			w5.LeftAttach = ((uint)(5));
			w5.RightAttach = ((uint)(6));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.ggToStringWidget = new global::Vodovoz.ViewWidgets.GeographicGroupsToStringWidget();
			this.ggToStringWidget.Events = ((global::Gdk.EventMask)(256));
			this.ggToStringWidget.Name = "ggToStringWidget";
			this.dataRouteList.Add(this.ggToStringWidget);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.ggToStringWidget]));
			w6.TopAttach = ((uint)(5));
			w6.BottomAttach = ((uint)(6));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w7 = new global::Gtk.Image();
			w7.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w7;
			this.hbox7.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.buttonSave]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.btnCancel = new global::Gtk.Button();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString("Отмена");
			global::Gtk.Image w9 = new global::Gtk.Image();
			w9.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.btnCancel.Image = w9;
			this.hbox7.Add(this.btnCancel);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.btnCancel]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			this.dataRouteList.Add(this.hbox7);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.hbox7]));
			w11.XOptions = ((global::Gtk.AttachOptions)(0));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.hboxCash = new global::Gtk.HBox();
			this.hboxCash.Name = "hboxCash";
			this.hboxCash.Spacing = 6;
			// Container child hboxCash.Gtk.Box+BoxChild
			this.labelTerminalCondition = new global::Gamma.GtkWidgets.yLabel();
			this.labelTerminalCondition.Name = "labelTerminalCondition";
			this.labelTerminalCondition.LabelProp = global::Mono.Unix.Catalog.GetString("Состояние терминала: ");
			this.hboxCash.Add(this.labelTerminalCondition);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hboxCash[this.labelTerminalCondition]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hboxCash.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator();
			this.vseparator1.Name = "vseparator1";
			this.hboxCash.Add(this.vseparator1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hboxCash[this.vseparator1]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hboxCash.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Сдается в кассу:");
			this.hboxCash.Add(this.label7);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hboxCash[this.label7]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hboxCash.Gtk.Box+BoxChild
			this.yspeccomboboxCashSubdivision = new global::Gamma.Widgets.ySpecComboBox();
			this.yspeccomboboxCashSubdivision.Name = "yspeccomboboxCashSubdivision";
			this.yspeccomboboxCashSubdivision.AddIfNotExist = false;
			this.yspeccomboboxCashSubdivision.DefaultFirst = false;
			this.yspeccomboboxCashSubdivision.ShowSpecialStateAll = false;
			this.yspeccomboboxCashSubdivision.ShowSpecialStateNot = false;
			this.hboxCash.Add(this.yspeccomboboxCashSubdivision);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hboxCash[this.yspeccomboboxCashSubdivision]));
			w15.Position = 3;
			w15.Expand = false;
			w15.Fill = false;
			this.dataRouteList.Add(this.hboxCash);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.hboxCash]));
			w16.LeftAttach = ((uint)(2));
			w16.RightAttach = ((uint)(4));
			w16.XOptions = ((global::Gtk.AttachOptions)(0));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.hboxDriverComment = new global::Gamma.GtkWidgets.yHBox();
			this.hboxDriverComment.Name = "hboxDriverComment";
			this.hboxDriverComment.Spacing = 6;
			// Container child hboxDriverComment.Gtk.Box+BoxChild
			this.lblDriverCommentTitle = new global::Gamma.GtkWidgets.yLabel();
			this.lblDriverCommentTitle.Name = "lblDriverCommentTitle";
			this.lblDriverCommentTitle.Xalign = 1F;
			this.lblDriverCommentTitle.LabelProp = global::Mono.Unix.Catalog.GetString("Комментарий по водителю:");
			this.hboxDriverComment.Add(this.lblDriverCommentTitle);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hboxDriverComment[this.lblDriverCommentTitle]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hboxDriverComment.Gtk.Box+BoxChild
			this.lblDriverComment = new global::Gamma.GtkWidgets.yLabel();
			this.lblDriverComment.Name = "lblDriverComment";
			this.lblDriverComment.LabelProp = global::Mono.Unix.Catalog.GetString("\"Комментарий по водителю\"");
			this.hboxDriverComment.Add(this.lblDriverComment);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hboxDriverComment[this.lblDriverComment]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			this.dataRouteList.Add(this.hboxDriverComment);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.hboxDriverComment]));
			w19.TopAttach = ((uint)(4));
			w19.BottomAttach = ((uint)(5));
			w19.LeftAttach = ((uint)(3));
			w19.RightAttach = ((uint)(6));
			w19.XOptions = ((global::Gtk.AttachOptions)(0));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.hboxForwarderComment = new global::Gamma.GtkWidgets.yHBox();
			this.hboxForwarderComment.Name = "hboxForwarderComment";
			this.hboxForwarderComment.Spacing = 6;
			// Container child hboxForwarderComment.Gtk.Box+BoxChild
			this.lblForwarderCommentTitle = new global::Gamma.GtkWidgets.yLabel();
			this.lblForwarderCommentTitle.Name = "lblForwarderCommentTitle";
			this.lblForwarderCommentTitle.Xalign = 1F;
			this.lblForwarderCommentTitle.LabelProp = global::Mono.Unix.Catalog.GetString("Комментарий по экспедитору:");
			this.hboxForwarderComment.Add(this.lblForwarderCommentTitle);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hboxForwarderComment[this.lblForwarderCommentTitle]));
			w20.Position = 0;
			w20.Expand = false;
			w20.Fill = false;
			// Container child hboxForwarderComment.Gtk.Box+BoxChild
			this.lblForwarderComment = new global::Gamma.GtkWidgets.yLabel();
			this.lblForwarderComment.Name = "lblForwarderComment";
			this.lblForwarderComment.LabelProp = global::Mono.Unix.Catalog.GetString("\"Комментарий по экспедитору\"");
			this.hboxForwarderComment.Add(this.lblForwarderComment);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hboxForwarderComment[this.lblForwarderComment]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			this.dataRouteList.Add(this.hboxForwarderComment);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.hboxForwarderComment]));
			w22.TopAttach = ((uint)(6));
			w22.BottomAttach = ((uint)(7));
			w22.LeftAttach = ((uint)(3));
			w22.RightAttach = ((uint)(6));
			w22.XOptions = ((global::Gtk.AttachOptions)(0));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.hseparator2 = new global::Gtk.HSeparator();
			this.hseparator2.Name = "hseparator2";
			this.dataRouteList.Add(this.hseparator2);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.hseparator2]));
			w23.TopAttach = ((uint)(1));
			w23.BottomAttach = ((uint)(2));
			w23.RightAttach = ((uint)(6));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.hseparator3 = new global::Gtk.HSeparator();
			this.hseparator3.Name = "hseparator3";
			this.dataRouteList.Add(this.hseparator3);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.hseparator3]));
			w24.TopAttach = ((uint)(7));
			w24.BottomAttach = ((uint)(8));
			w24.RightAttach = ((uint)(6));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Смена:");
			this.dataRouteList.Add(this.label1);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.label1]));
			w25.TopAttach = ((uint)(3));
			w25.BottomAttach = ((uint)(4));
			w25.LeftAttach = ((uint)(2));
			w25.RightAttach = ((uint)(3));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.Xalign = 1F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("Логист:");
			this.dataRouteList.Add(this.label10);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.label10]));
			w26.LeftAttach = ((uint)(4));
			w26.RightAttach = ((uint)(5));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Дата:");
			this.dataRouteList.Add(this.label2);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.label2]));
			w27.TopAttach = ((uint)(3));
			w27.BottomAttach = ((uint)(4));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Водитель:");
			this.dataRouteList.Add(this.label3);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.label3]));
			w28.TopAttach = ((uint)(3));
			w28.BottomAttach = ((uint)(4));
			w28.LeftAttach = ((uint)(4));
			w28.RightAttach = ((uint)(5));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Машина:");
			this.dataRouteList.Add(this.label4);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.label4]));
			w29.TopAttach = ((uint)(2));
			w29.BottomAttach = ((uint)(3));
			w29.LeftAttach = ((uint)(4));
			w29.RightAttach = ((uint)(5));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Состояние:");
			this.dataRouteList.Add(this.label5);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.label5]));
			w30.TopAttach = ((uint)(2));
			w30.BottomAttach = ((uint)(3));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("Экспедитор:");
			this.dataRouteList.Add(this.label9);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.label9]));
			w31.TopAttach = ((uint)(5));
			w31.BottomAttach = ((uint)(6));
			w31.LeftAttach = ((uint)(4));
			w31.RightAttach = ((uint)(5));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.labelStatus = new global::Gamma.GtkWidgets.yLabel();
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Xalign = 0F;
			this.labelStatus.LabelProp = global::Mono.Unix.Catalog.GetString("--");
			this.dataRouteList.Add(this.labelStatus);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.labelStatus]));
			w32.TopAttach = ((uint)(2));
			w32.BottomAttach = ((uint)(3));
			w32.LeftAttach = ((uint)(1));
			w32.RightAttach = ((uint)(4));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.phoneDriver = new global::Vodovoz.ViewWidgets.Mango.EmployeePhone();
			this.phoneDriver.CanFocus = true;
			this.phoneDriver.Name = "phoneDriver";
			this.phoneDriver.UseUnderline = true;
			this.phoneDriver.UseMarkup = false;
			this.phoneDriver.LabelXAlign = 0F;
			this.dataRouteList.Add(this.phoneDriver);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.phoneDriver]));
			w33.TopAttach = ((uint)(3));
			w33.BottomAttach = ((uint)(4));
			w33.LeftAttach = ((uint)(6));
			w33.RightAttach = ((uint)(7));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.phoneForwarder = new global::Vodovoz.ViewWidgets.Mango.EmployeePhone();
			this.phoneForwarder.CanFocus = true;
			this.phoneForwarder.Name = "phoneForwarder";
			this.phoneForwarder.UseUnderline = true;
			this.phoneForwarder.UseMarkup = false;
			this.phoneForwarder.LabelXAlign = 0F;
			this.dataRouteList.Add(this.phoneForwarder);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.phoneForwarder]));
			w34.TopAttach = ((uint)(5));
			w34.BottomAttach = ((uint)(6));
			w34.LeftAttach = ((uint)(6));
			w34.RightAttach = ((uint)(7));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.phoneLogistican = new global::Vodovoz.ViewWidgets.Mango.EmployeePhone();
			this.phoneLogistican.CanFocus = true;
			this.phoneLogistican.Name = "phoneLogistican";
			this.phoneLogistican.UseUnderline = true;
			this.phoneLogistican.UseMarkup = false;
			this.phoneLogistican.LabelXAlign = 0F;
			this.dataRouteList.Add(this.phoneLogistican);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.phoneLogistican]));
			w35.LeftAttach = ((uint)(6));
			w35.RightAttach = ((uint)(7));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child dataRouteList.Gtk.Table+TableChild
			this.speccomboShift = new global::Gamma.Widgets.ySpecComboBox();
			this.speccomboShift.Name = "speccomboShift";
			this.speccomboShift.AddIfNotExist = false;
			this.speccomboShift.DefaultFirst = false;
			this.speccomboShift.ShowSpecialStateAll = false;
			this.speccomboShift.ShowSpecialStateNot = true;
			this.dataRouteList.Add(this.speccomboShift);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.dataRouteList[this.speccomboShift]));
			w36.TopAttach = ((uint)(3));
			w36.BottomAttach = ((uint)(4));
			w36.LeftAttach = ((uint)(3));
			w36.RightAttach = ((uint)(4));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add(this.dataRouteList);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.dataRouteList]));
			w37.Position = 0;
			w37.Expand = false;
			w37.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.createroutelistitemsview1 = new global::Vodovoz.RouteListCreateItemsView();
			this.createroutelistitemsview1.HeightRequest = 150;
			this.createroutelistitemsview1.Events = ((global::Gdk.EventMask)(256));
			this.createroutelistitemsview1.Name = "createroutelistitemsview1";
			this.createroutelistitemsview1.DisableColumnsUpdate = false;
			this.vbox1.Add(this.createroutelistitemsview1);
			global::Gtk.Box.BoxChild w38 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.createroutelistitemsview1]));
			w38.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox9 = new global::Gtk.HBox();
			this.hbox9.Name = "hbox9";
			this.hbox9.Spacing = 6;
			// Container child hbox9.Gtk.Box+BoxChild
			this.printTimeButton = new global::Gamma.GtkWidgets.yButton();
			this.printTimeButton.CanFocus = true;
			this.printTimeButton.Name = "printTimeButton";
			this.printTimeButton.UseUnderline = true;
			this.printTimeButton.Label = global::Mono.Unix.Catalog.GetString("Время печати МЛ");
			this.hbox9.Add(this.printTimeButton);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.printTimeButton]));
			w39.Position = 1;
			w39.Expand = false;
			w39.Fill = false;
			// Container child hbox9.Gtk.Box+BoxChild
			this.enumPrint = new global::QS.Widgets.EnumMenuButton();
			this.enumPrint.CanFocus = true;
			this.enumPrint.Name = "enumPrint";
			this.enumPrint.UseUnderline = true;
			this.enumPrint.UseMarkup = false;
			this.enumPrint.LabelXAlign = 0F;
			this.enumPrint.Label = global::Mono.Unix.Catalog.GetString("Распечатать");
			global::Gtk.Image w40 = new global::Gtk.Image();
			w40.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-print", global::Gtk.IconSize.Menu);
			this.enumPrint.Image = w40;
			this.hbox9.Add(this.enumPrint);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.enumPrint]));
			w41.PackType = ((global::Gtk.PackType)(1));
			w41.Position = 2;
			w41.Expand = false;
			w41.Fill = false;
			// Container child hbox9.Gtk.Box+BoxChild
			this.buttonAccept = new global::Gtk.Button();
			this.buttonAccept.CanFocus = true;
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.UseUnderline = true;
			this.buttonAccept.Label = global::Mono.Unix.Catalog.GetString("Подтвердить");
			global::Gtk.Image w42 = new global::Gtk.Image();
			w42.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-apply", global::Gtk.IconSize.Menu);
			this.buttonAccept.Image = w42;
			this.hbox9.Add(this.buttonAccept);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.hbox9[this.buttonAccept]));
			w43.PackType = ((global::Gtk.PackType)(1));
			w43.Position = 3;
			w43.Expand = false;
			w43.Fill = false;
			this.vbox1.Add(this.hbox9);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox9]));
			w44.Position = 2;
			w44.Expand = false;
			w44.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonAccept.Clicked += new global::System.EventHandler(this.OnButtonAcceptClicked);
		}
	}
}
