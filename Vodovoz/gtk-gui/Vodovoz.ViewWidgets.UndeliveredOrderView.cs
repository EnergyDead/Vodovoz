
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ViewWidgets
{
	public partial class UndeliveredOrderView
	{
		private global::Gtk.VBox mainBox;

		private global::Gtk.HBox hbox4;

		private global::Gtk.HBox hbxInProcessAtDepartment;

		private global::Gtk.Label lblInProcAtDep;

		private global::Gamma.Widgets.yEntryReference yentInProcessAtDepartment;

		private global::Gtk.HBox hbxStatus;

		private global::Gtk.Label lblStatus;

		private global::Gamma.Widgets.yEnumComboBox yEnumCMBStatus;

		private global::Gtk.VBox vbxWithControls;

		private global::Gtk.HBox hbxUndelivery;

		private global::Gtk.Label lblUndeliveredOrder;

		private global::QS.Widgets.GtkUI.RepresentationEntry yEForUndeliveredOrder;

		private global::Gtk.Table tblUndeliveryFields;

		private global::Gtk.Frame frame1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gtk.Alignment GtkAlignment6;

		private global::Gtk.Label lblInfo;

		private global::Gtk.Label lblInfoCaption;

		private global::Vodovoz.ViewWidgets.GuiltyInUndeliveryView guiltyInUndeliveryView;

		private global::Gtk.HBox hbxForNewOrder;

		private global::Gtk.Label lblTransferDate;

		private global::Gtk.Button btnChooseOrder;

		private global::Gtk.Button btnNewOrder;

		private global::Gamma.Widgets.yEnumComboBox yenumcomboboxTransferType;

		private global::Gtk.Label lblDispatcherCallTime;

		private global::Gtk.Label lblDriverCallPlace;

		private global::Gtk.Label lblDriverCallTime;

		private global::Gtk.Label lblGuilty;

		private global::Gtk.Label lblNewDeliverySchedule;

		private global::Gtk.Label lblRegisteredBy;

		private global::Gtk.Label lblTransferDateCaption;

		private global::Gamma.Widgets.yEntryReference referenceNewDeliverySchedule;

		private global::QS.Widgets.GtkUI.RepresentationEntry refRegisteredBy;

		private global::QS.Widgets.GtkUI.DatePicker yDateDispatcherCallTime;

		private global::QS.Widgets.GtkUI.DatePicker yDateDriverCallTime;

		private global::Gamma.Widgets.yEnumComboBox yEnumCMBDriverCallPlace;

		private global::Gtk.VBox vbxReasonAndFines;

		private global::Gtk.Frame frame2;

		private global::Gtk.Alignment GtkAlignment7;

		private global::Gtk.ScrolledWindow GtkScrolledWindow2;

		private global::Gamma.GtkWidgets.yTextView txtReason;

		private global::Gtk.Label lblReason;

		private global::Gtk.Frame frameProblemSource;

		private global::Gtk.Alignment GtkAlignment9;

		private global::Gtk.ScrolledWindow GtkScrolledWindow4;

		private global::Gamma.GtkWidgets.yTextView ytextviewProblemSource;

		private global::Gtk.Label GtkLabelProblemSource;

		private global::Gtk.Frame frame3;

		private global::Gtk.Alignment GtkAlignment8;

		private global::Gtk.ScrolledWindow GtkScrolledWindow3;

		private global::Gamma.GtkWidgets.yTreeView yTreeFines;

		private global::Gtk.Label lblFines;

		private global::Gtk.Button buttonAddFine;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ViewWidgets.UndeliveredOrderView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ViewWidgets.UndeliveredOrderView";
			// Container child Vodovoz.ViewWidgets.UndeliveredOrderView.Gtk.Container+ContainerChild
			this.mainBox = new global::Gtk.VBox();
			this.mainBox.Name = "mainBox";
			this.mainBox.Spacing = 6;
			// Container child mainBox.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.hbxInProcessAtDepartment = new global::Gtk.HBox();
			this.hbxInProcessAtDepartment.Name = "hbxInProcessAtDepartment";
			this.hbxInProcessAtDepartment.Spacing = 6;
			// Container child hbxInProcessAtDepartment.Gtk.Box+BoxChild
			this.lblInProcAtDep = new global::Gtk.Label();
			this.lblInProcAtDep.Name = "lblInProcAtDep";
			this.lblInProcAtDep.Xalign = 1F;
			this.lblInProcAtDep.LabelProp = global::Mono.Unix.Catalog.GetString("В работе у отдела:");
			this.hbxInProcessAtDepartment.Add(this.lblInProcAtDep);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbxInProcessAtDepartment[this.lblInProcAtDep]));
			w1.Position = 0;
			w1.Expand = false;
			// Container child hbxInProcessAtDepartment.Gtk.Box+BoxChild
			this.yentInProcessAtDepartment = new global::Gamma.Widgets.yEntryReference();
			this.yentInProcessAtDepartment.Events = ((global::Gdk.EventMask)(256));
			this.yentInProcessAtDepartment.Name = "yentInProcessAtDepartment";
			this.hbxInProcessAtDepartment.Add(this.yentInProcessAtDepartment);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbxInProcessAtDepartment[this.yentInProcessAtDepartment]));
			w2.Position = 1;
			this.hbox4.Add(this.hbxInProcessAtDepartment);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.hbxInProcessAtDepartment]));
			w3.Position = 0;
			// Container child hbox4.Gtk.Box+BoxChild
			this.hbxStatus = new global::Gtk.HBox();
			this.hbxStatus.Name = "hbxStatus";
			this.hbxStatus.Spacing = 6;
			// Container child hbxStatus.Gtk.Box+BoxChild
			this.lblStatus = new global::Gtk.Label();
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Xalign = 1F;
			this.lblStatus.LabelProp = global::Mono.Unix.Catalog.GetString("Статус недовоза:");
			this.hbxStatus.Add(this.lblStatus);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbxStatus[this.lblStatus]));
			w4.Position = 0;
			w4.Expand = false;
			// Container child hbxStatus.Gtk.Box+BoxChild
			this.yEnumCMBStatus = new global::Gamma.Widgets.yEnumComboBox();
			this.yEnumCMBStatus.Name = "yEnumCMBStatus";
			this.yEnumCMBStatus.ShowSpecialStateAll = false;
			this.yEnumCMBStatus.ShowSpecialStateNot = false;
			this.yEnumCMBStatus.UseShortTitle = false;
			this.yEnumCMBStatus.DefaultFirst = false;
			this.hbxStatus.Add(this.yEnumCMBStatus);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbxStatus[this.yEnumCMBStatus]));
			w5.Position = 1;
			this.hbox4.Add(this.hbxStatus);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.hbxStatus]));
			w6.Position = 1;
			this.mainBox.Add(this.hbox4);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.mainBox[this.hbox4]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child mainBox.Gtk.Box+BoxChild
			this.vbxWithControls = new global::Gtk.VBox();
			this.vbxWithControls.Name = "vbxWithControls";
			this.vbxWithControls.Spacing = 6;
			// Container child vbxWithControls.Gtk.Box+BoxChild
			this.hbxUndelivery = new global::Gtk.HBox();
			this.hbxUndelivery.Name = "hbxUndelivery";
			this.hbxUndelivery.Spacing = 6;
			// Container child hbxUndelivery.Gtk.Box+BoxChild
			this.lblUndeliveredOrder = new global::Gtk.Label();
			this.lblUndeliveredOrder.Name = "lblUndeliveredOrder";
			this.lblUndeliveredOrder.Xalign = 1F;
			this.lblUndeliveredOrder.LabelProp = global::Mono.Unix.Catalog.GetString("Недовоз:");
			this.hbxUndelivery.Add(this.lblUndeliveredOrder);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbxUndelivery[this.lblUndeliveredOrder]));
			w8.Position = 0;
			w8.Expand = false;
			// Container child hbxUndelivery.Gtk.Box+BoxChild
			this.yEForUndeliveredOrder = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.yEForUndeliveredOrder.Events = ((global::Gdk.EventMask)(256));
			this.yEForUndeliveredOrder.Name = "yEForUndeliveredOrder";
			this.hbxUndelivery.Add(this.yEForUndeliveredOrder);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbxUndelivery[this.yEForUndeliveredOrder]));
			w9.Position = 1;
			this.vbxWithControls.Add(this.hbxUndelivery);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbxWithControls[this.hbxUndelivery]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbxWithControls.Gtk.Box+BoxChild
			this.tblUndeliveryFields = new global::Gtk.Table(((uint)(7)), ((uint)(3)), false);
			this.tblUndeliveryFields.Name = "tblUndeliveryFields";
			this.tblUndeliveryFields.RowSpacing = ((uint)(6));
			this.tblUndeliveryFields.ColumnSpacing = ((uint)(6));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.frame1 = new global::Gtk.Frame();
			this.frame1.Name = "frame1";
			this.frame1.BorderWidth = ((uint)(3));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			global::Gtk.Viewport w11 = new global::Gtk.Viewport();
			w11.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.GtkAlignment6 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment6.Name = "GtkAlignment6";
			this.GtkAlignment6.LeftPadding = ((uint)(12));
			// Container child GtkAlignment6.Gtk.Container+ContainerChild
			this.lblInfo = new global::Gtk.Label();
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Xalign = 0F;
			this.lblInfo.LabelProp = global::Mono.Unix.Catalog.GetString("<b>?</b>");
			this.lblInfo.UseMarkup = true;
			this.lblInfo.Selectable = true;
			this.GtkAlignment6.Add(this.lblInfo);
			w11.Add(this.GtkAlignment6);
			this.GtkScrolledWindow1.Add(w11);
			this.frame1.Add(this.GtkScrolledWindow1);
			this.lblInfoCaption = new global::Gtk.Label();
			this.lblInfoCaption.Name = "lblInfoCaption";
			this.lblInfoCaption.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Информация</b>");
			this.lblInfoCaption.UseMarkup = true;
			this.frame1.LabelWidget = this.lblInfoCaption;
			this.tblUndeliveryFields.Add(this.frame1);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.frame1]));
			w16.BottomAttach = ((uint)(7));
			w16.LeftAttach = ((uint)(2));
			w16.RightAttach = ((uint)(3));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.guiltyInUndeliveryView = new global::Vodovoz.ViewWidgets.GuiltyInUndeliveryView();
			this.guiltyInUndeliveryView.Events = ((global::Gdk.EventMask)(256));
			this.guiltyInUndeliveryView.Name = "guiltyInUndeliveryView";
			this.tblUndeliveryFields.Add(this.guiltyInUndeliveryView);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.guiltyInUndeliveryView]));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.hbxForNewOrder = new global::Gtk.HBox();
			this.hbxForNewOrder.Name = "hbxForNewOrder";
			this.hbxForNewOrder.Spacing = 6;
			// Container child hbxForNewOrder.Gtk.Box+BoxChild
			this.lblTransferDate = new global::Gtk.Label();
			this.lblTransferDate.Name = "lblTransferDate";
			this.lblTransferDate.LabelProp = global::Mono.Unix.Catalog.GetString("Заказ не\nсоздан ");
			this.lblTransferDate.Justify = ((global::Gtk.Justification)(2));
			this.hbxForNewOrder.Add(this.lblTransferDate);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbxForNewOrder[this.lblTransferDate]));
			w18.Position = 0;
			w18.Expand = false;
			// Container child hbxForNewOrder.Gtk.Box+BoxChild
			this.btnChooseOrder = new global::Gtk.Button();
			this.btnChooseOrder.CanFocus = true;
			this.btnChooseOrder.Name = "btnChooseOrder";
			this.btnChooseOrder.UseUnderline = true;
			this.btnChooseOrder.Label = global::Mono.Unix.Catalog.GetString("Выбрать заказ");
			this.hbxForNewOrder.Add(this.btnChooseOrder);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbxForNewOrder[this.btnChooseOrder]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			// Container child hbxForNewOrder.Gtk.Box+BoxChild
			this.btnNewOrder = new global::Gtk.Button();
			this.btnNewOrder.CanFocus = true;
			this.btnNewOrder.Name = "btnNewOrder";
			this.btnNewOrder.UseUnderline = true;
			this.btnNewOrder.Label = global::Mono.Unix.Catalog.GetString("Создать заказ");
			this.hbxForNewOrder.Add(this.btnNewOrder);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbxForNewOrder[this.btnNewOrder]));
			w20.Position = 2;
			w20.Expand = false;
			// Container child hbxForNewOrder.Gtk.Box+BoxChild
			this.yenumcomboboxTransferType = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumcomboboxTransferType.Name = "yenumcomboboxTransferType";
			this.yenumcomboboxTransferType.ShowSpecialStateAll = false;
			this.yenumcomboboxTransferType.ShowSpecialStateNot = true;
			this.yenumcomboboxTransferType.UseShortTitle = false;
			this.yenumcomboboxTransferType.DefaultFirst = false;
			this.hbxForNewOrder.Add(this.yenumcomboboxTransferType);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbxForNewOrder[this.yenumcomboboxTransferType]));
			w21.Position = 3;
			w21.Expand = false;
			w21.Fill = false;
			this.tblUndeliveryFields.Add(this.hbxForNewOrder);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.hbxForNewOrder]));
			w22.TopAttach = ((uint)(4));
			w22.BottomAttach = ((uint)(5));
			w22.LeftAttach = ((uint)(1));
			w22.RightAttach = ((uint)(2));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblDispatcherCallTime = new global::Gtk.Label();
			this.lblDispatcherCallTime.Name = "lblDispatcherCallTime";
			this.lblDispatcherCallTime.Xalign = 1F;
			this.lblDispatcherCallTime.LabelProp = global::Mono.Unix.Catalog.GetString("Время звонка клиенту:");
			this.tblUndeliveryFields.Add(this.lblDispatcherCallTime);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblDispatcherCallTime]));
			w23.TopAttach = ((uint)(3));
			w23.BottomAttach = ((uint)(4));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblDriverCallPlace = new global::Gtk.Label();
			this.lblDriverCallPlace.Name = "lblDriverCallPlace";
			this.lblDriverCallPlace.Xalign = 1F;
			this.lblDriverCallPlace.LabelProp = global::Mono.Unix.Catalog.GetString("Место звонка водителя:");
			this.tblUndeliveryFields.Add(this.lblDriverCallPlace);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblDriverCallPlace]));
			w24.TopAttach = ((uint)(1));
			w24.BottomAttach = ((uint)(2));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblDriverCallTime = new global::Gtk.Label();
			this.lblDriverCallTime.Name = "lblDriverCallTime";
			this.lblDriverCallTime.Xalign = 1F;
			this.lblDriverCallTime.LabelProp = global::Mono.Unix.Catalog.GetString("Время звонка водителя:");
			this.tblUndeliveryFields.Add(this.lblDriverCallTime);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblDriverCallTime]));
			w25.TopAttach = ((uint)(2));
			w25.BottomAttach = ((uint)(3));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblGuilty = new global::Gtk.Label();
			this.lblGuilty.Name = "lblGuilty";
			this.lblGuilty.Xalign = 1F;
			this.lblGuilty.LabelProp = global::Mono.Unix.Catalog.GetString("Виновники:");
			this.tblUndeliveryFields.Add(this.lblGuilty);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblGuilty]));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblNewDeliverySchedule = new global::Gtk.Label();
			this.lblNewDeliverySchedule.Name = "lblNewDeliverySchedule";
			this.lblNewDeliverySchedule.Xalign = 1F;
			this.lblNewDeliverySchedule.LabelProp = global::Mono.Unix.Catalog.GetString("Новый интервал переноса:");
			this.tblUndeliveryFields.Add(this.lblNewDeliverySchedule);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblNewDeliverySchedule]));
			w27.TopAttach = ((uint)(5));
			w27.BottomAttach = ((uint)(6));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblRegisteredBy = new global::Gtk.Label();
			this.lblRegisteredBy.Name = "lblRegisteredBy";
			this.lblRegisteredBy.Xalign = 1F;
			this.lblRegisteredBy.LabelProp = global::Mono.Unix.Catalog.GetString("Зарегистрировал:");
			this.tblUndeliveryFields.Add(this.lblRegisteredBy);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblRegisteredBy]));
			w28.TopAttach = ((uint)(6));
			w28.BottomAttach = ((uint)(7));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblTransferDateCaption = new global::Gtk.Label();
			this.lblTransferDateCaption.Name = "lblTransferDateCaption";
			this.lblTransferDateCaption.Xalign = 1F;
			this.lblTransferDateCaption.LabelProp = global::Mono.Unix.Catalog.GetString("Дата переноса:");
			this.tblUndeliveryFields.Add(this.lblTransferDateCaption);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblTransferDateCaption]));
			w29.TopAttach = ((uint)(4));
			w29.BottomAttach = ((uint)(5));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.referenceNewDeliverySchedule = new global::Gamma.Widgets.yEntryReference();
			this.referenceNewDeliverySchedule.Events = ((global::Gdk.EventMask)(256));
			this.referenceNewDeliverySchedule.Name = "referenceNewDeliverySchedule";
			this.tblUndeliveryFields.Add(this.referenceNewDeliverySchedule);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.referenceNewDeliverySchedule]));
			w30.TopAttach = ((uint)(5));
			w30.BottomAttach = ((uint)(6));
			w30.LeftAttach = ((uint)(1));
			w30.RightAttach = ((uint)(2));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.refRegisteredBy = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.refRegisteredBy.Events = ((global::Gdk.EventMask)(256));
			this.refRegisteredBy.Name = "refRegisteredBy";
			this.tblUndeliveryFields.Add(this.refRegisteredBy);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.refRegisteredBy]));
			w31.TopAttach = ((uint)(6));
			w31.BottomAttach = ((uint)(7));
			w31.LeftAttach = ((uint)(1));
			w31.RightAttach = ((uint)(2));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.yDateDispatcherCallTime = new global::QS.Widgets.GtkUI.DatePicker();
			this.yDateDispatcherCallTime.Events = ((global::Gdk.EventMask)(256));
			this.yDateDispatcherCallTime.Name = "yDateDispatcherCallTime";
			this.yDateDispatcherCallTime.WithTime = true;
			this.yDateDispatcherCallTime.HideCalendarButton = false;
			this.yDateDispatcherCallTime.Date = new global::System.DateTime(0);
			this.yDateDispatcherCallTime.IsEditable = true;
			this.yDateDispatcherCallTime.AutoSeparation = true;
			this.tblUndeliveryFields.Add(this.yDateDispatcherCallTime);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.yDateDispatcherCallTime]));
			w32.TopAttach = ((uint)(3));
			w32.BottomAttach = ((uint)(4));
			w32.LeftAttach = ((uint)(1));
			w32.RightAttach = ((uint)(2));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.yDateDriverCallTime = new global::QS.Widgets.GtkUI.DatePicker();
			this.yDateDriverCallTime.Events = ((global::Gdk.EventMask)(256));
			this.yDateDriverCallTime.Name = "yDateDriverCallTime";
			this.yDateDriverCallTime.WithTime = true;
			this.yDateDriverCallTime.HideCalendarButton = false;
			this.yDateDriverCallTime.Date = new global::System.DateTime(0);
			this.yDateDriverCallTime.IsEditable = true;
			this.yDateDriverCallTime.AutoSeparation = true;
			this.tblUndeliveryFields.Add(this.yDateDriverCallTime);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.yDateDriverCallTime]));
			w33.TopAttach = ((uint)(2));
			w33.BottomAttach = ((uint)(3));
			w33.LeftAttach = ((uint)(1));
			w33.RightAttach = ((uint)(2));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.yEnumCMBDriverCallPlace = new global::Gamma.Widgets.yEnumComboBox();
			this.yEnumCMBDriverCallPlace.Name = "yEnumCMBDriverCallPlace";
			this.yEnumCMBDriverCallPlace.ShowSpecialStateAll = false;
			this.yEnumCMBDriverCallPlace.ShowSpecialStateNot = false;
			this.yEnumCMBDriverCallPlace.UseShortTitle = false;
			this.yEnumCMBDriverCallPlace.DefaultFirst = false;
			this.tblUndeliveryFields.Add(this.yEnumCMBDriverCallPlace);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.yEnumCMBDriverCallPlace]));
			w34.TopAttach = ((uint)(1));
			w34.BottomAttach = ((uint)(2));
			w34.LeftAttach = ((uint)(1));
			w34.RightAttach = ((uint)(2));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbxWithControls.Add(this.tblUndeliveryFields);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vbxWithControls[this.tblUndeliveryFields]));
			w35.Position = 1;
			w35.Expand = false;
			w35.Fill = false;
			// Container child vbxWithControls.Gtk.Box+BoxChild
			this.vbxReasonAndFines = new global::Gtk.VBox();
			this.vbxReasonAndFines.Name = "vbxReasonAndFines";
			this.vbxReasonAndFines.Spacing = 6;
			// Container child vbxReasonAndFines.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame();
			this.frame2.Name = "frame2";
			this.frame2.BorderWidth = ((uint)(3));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment7 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment7.Name = "GtkAlignment7";
			this.GtkAlignment7.LeftPadding = ((uint)(12));
			// Container child GtkAlignment7.Gtk.Container+ContainerChild
			this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
			this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
			this.txtReason = new global::Gamma.GtkWidgets.yTextView();
			this.txtReason.CanFocus = true;
			this.txtReason.Name = "txtReason";
			this.txtReason.WrapMode = ((global::Gtk.WrapMode)(2));
			this.GtkScrolledWindow2.Add(this.txtReason);
			this.GtkAlignment7.Add(this.GtkScrolledWindow2);
			this.frame2.Add(this.GtkAlignment7);
			this.lblReason = new global::Gtk.Label();
			this.lblReason.Name = "lblReason";
			this.lblReason.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Что случилось?</b>");
			this.lblReason.UseMarkup = true;
			this.frame2.LabelWidget = this.lblReason;
			this.vbxReasonAndFines.Add(this.frame2);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.vbxReasonAndFines[this.frame2]));
			w39.Position = 0;
			// Container child vbxReasonAndFines.Gtk.Box+BoxChild
			this.frameProblemSource = new global::Gtk.Frame();
			this.frameProblemSource.Name = "frameProblemSource";
			this.frameProblemSource.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frameProblemSource.Gtk.Container+ContainerChild
			this.GtkAlignment9 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment9.Name = "GtkAlignment9";
			this.GtkAlignment9.LeftPadding = ((uint)(12));
			// Container child GtkAlignment9.Gtk.Container+ContainerChild
			this.GtkScrolledWindow4 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow4.Name = "GtkScrolledWindow4";
			this.GtkScrolledWindow4.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow4.Gtk.Container+ContainerChild
			this.ytextviewProblemSource = new global::Gamma.GtkWidgets.yTextView();
			this.ytextviewProblemSource.CanFocus = true;
			this.ytextviewProblemSource.Name = "ytextviewProblemSource";
			this.GtkScrolledWindow4.Add(this.ytextviewProblemSource);
			this.GtkAlignment9.Add(this.GtkScrolledWindow4);
			this.frameProblemSource.Add(this.GtkAlignment9);
			this.GtkLabelProblemSource = new global::Gtk.Label();
			this.GtkLabelProblemSource.Name = "GtkLabelProblemSource";
			this.GtkLabelProblemSource.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Источник проблемы</b>");
			this.GtkLabelProblemSource.UseMarkup = true;
			this.frameProblemSource.LabelWidget = this.GtkLabelProblemSource;
			this.vbxReasonAndFines.Add(this.frameProblemSource);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.vbxReasonAndFines[this.frameProblemSource]));
			w43.Position = 1;
			// Container child vbxReasonAndFines.Gtk.Box+BoxChild
			this.frame3 = new global::Gtk.Frame();
			this.frame3.Name = "frame3";
			this.frame3.BorderWidth = ((uint)(3));
			// Container child frame3.Gtk.Container+ContainerChild
			this.GtkAlignment8 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment8.Name = "GtkAlignment8";
			this.GtkAlignment8.LeftPadding = ((uint)(12));
			// Container child GtkAlignment8.Gtk.Container+ContainerChild
			this.GtkScrolledWindow3 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow3.Name = "GtkScrolledWindow3";
			this.GtkScrolledWindow3.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow3.Gtk.Container+ContainerChild
			this.yTreeFines = new global::Gamma.GtkWidgets.yTreeView();
			this.yTreeFines.CanFocus = true;
			this.yTreeFines.Name = "yTreeFines";
			this.GtkScrolledWindow3.Add(this.yTreeFines);
			this.GtkAlignment8.Add(this.GtkScrolledWindow3);
			this.frame3.Add(this.GtkAlignment8);
			this.lblFines = new global::Gtk.Label();
			this.lblFines.Name = "lblFines";
			this.lblFines.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Штрафы</b>");
			this.lblFines.UseMarkup = true;
			this.frame3.LabelWidget = this.lblFines;
			this.vbxReasonAndFines.Add(this.frame3);
			global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.vbxReasonAndFines[this.frame3]));
			w47.Position = 2;
			// Container child vbxReasonAndFines.Gtk.Box+BoxChild
			this.buttonAddFine = new global::Gtk.Button();
			this.buttonAddFine.CanFocus = true;
			this.buttonAddFine.Name = "buttonAddFine";
			this.buttonAddFine.UseUnderline = true;
			this.buttonAddFine.Label = global::Mono.Unix.Catalog.GetString("Добавить штраф");
			global::Gtk.Image w48 = new global::Gtk.Image();
			w48.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.buttonAddFine.Image = w48;
			this.vbxReasonAndFines.Add(this.buttonAddFine);
			global::Gtk.Box.BoxChild w49 = ((global::Gtk.Box.BoxChild)(this.vbxReasonAndFines[this.buttonAddFine]));
			w49.PackType = ((global::Gtk.PackType)(1));
			w49.Position = 3;
			w49.Fill = false;
			this.vbxWithControls.Add(this.vbxReasonAndFines);
			global::Gtk.Box.BoxChild w50 = ((global::Gtk.Box.BoxChild)(this.vbxWithControls[this.vbxReasonAndFines]));
			w50.Position = 2;
			this.mainBox.Add(this.vbxWithControls);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(this.mainBox[this.vbxWithControls]));
			w51.Position = 1;
			this.Add(this.mainBox);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.yenumcomboboxTransferType.Hide();
			this.Hide();
			this.yEnumCMBDriverCallPlace.EnumItemSelected += new global::System.EventHandler<Gamma.Widgets.ItemSelectedEventArgs>(this.OnYEnumCMBDriverCallPlaceEnumItemSelected);
			this.btnChooseOrder.Clicked += new global::System.EventHandler(this.OnBtnChooseOrderClicked);
			this.btnNewOrder.Clicked += new global::System.EventHandler(this.OnBtnNewOrderClicked);
			this.buttonAddFine.Clicked += new global::System.EventHandler(this.OnButtonAddFineClicked);
		}
	}
}
