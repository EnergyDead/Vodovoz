
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

		private global::QS.Widgets.GtkUI.EntityViewModelEntry evmeOldUndeliveredOrder;

		private global::Gtk.Table tblUndeliveryFields;

		private global::QS.Widgets.GtkUI.SpecialListComboBox comboProblemSource;

		private global::QS.Widgets.GtkUI.SpecialListComboBox comboTransferAbsenceReason;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry entryNewDeliverySchedule;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry evmeRegisteredBy;

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

		private global::QS.Widgets.GtkUI.DatePicker yDateDispatcherCallTime;

		private global::QS.Widgets.GtkUI.DatePicker yDateDriverCallTime;

		private global::Gamma.Widgets.yEnumComboBox yEnumCMBDriverCallPlace;

		private global::Gamma.GtkWidgets.yLabel ylabelProblemSource;

		private global::Gamma.GtkWidgets.yLabel ylabelTransferAbsenceReason;

		private global::Gtk.VBox vbxReasonAndFines;

		private global::Gtk.Frame frame2;

		private global::Gtk.Alignment GtkAlignment9;

		private global::Gtk.ScrolledWindow GtkScrolledWindow2;

		private global::Gamma.GtkWidgets.yTextView txtReason;

		private global::Gtk.Label lblReason;

		private global::Gtk.Frame frame3;

		private global::Gtk.Alignment GtkAlignment10;

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
			this.evmeOldUndeliveredOrder = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.evmeOldUndeliveredOrder.Events = ((global::Gdk.EventMask)(256));
			this.evmeOldUndeliveredOrder.Name = "evmeOldUndeliveredOrder";
			this.evmeOldUndeliveredOrder.CanEditReference = true;
			this.hbxUndelivery.Add(this.evmeOldUndeliveredOrder);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbxUndelivery[this.evmeOldUndeliveredOrder]));
			w9.Position = 1;
			this.vbxWithControls.Add(this.hbxUndelivery);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbxWithControls[this.hbxUndelivery]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbxWithControls.Gtk.Box+BoxChild
			this.tblUndeliveryFields = new global::Gtk.Table(((uint)(9)), ((uint)(3)), false);
			this.tblUndeliveryFields.Name = "tblUndeliveryFields";
			this.tblUndeliveryFields.RowSpacing = ((uint)(6));
			this.tblUndeliveryFields.ColumnSpacing = ((uint)(6));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.comboProblemSource = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.comboProblemSource.Name = "comboProblemSource";
			this.comboProblemSource.AddIfNotExist = false;
			this.comboProblemSource.DefaultFirst = false;
			this.comboProblemSource.ShowSpecialStateAll = false;
			this.comboProblemSource.ShowSpecialStateNot = false;
			this.tblUndeliveryFields.Add(this.comboProblemSource);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.comboProblemSource]));
			w11.TopAttach = ((uint)(7));
			w11.BottomAttach = ((uint)(8));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.comboTransferAbsenceReason = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.comboTransferAbsenceReason.Name = "comboTransferAbsenceReason";
			this.comboTransferAbsenceReason.AddIfNotExist = false;
			this.comboTransferAbsenceReason.DefaultFirst = false;
			this.comboTransferAbsenceReason.ShowSpecialStateAll = false;
			this.comboTransferAbsenceReason.ShowSpecialStateNot = false;
			this.tblUndeliveryFields.Add(this.comboTransferAbsenceReason);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.comboTransferAbsenceReason]));
			w12.TopAttach = ((uint)(8));
			w12.BottomAttach = ((uint)(9));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.entryNewDeliverySchedule = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.entryNewDeliverySchedule.Events = ((global::Gdk.EventMask)(256));
			this.entryNewDeliverySchedule.Name = "entryNewDeliverySchedule";
			this.entryNewDeliverySchedule.CanEditReference = false;
			this.tblUndeliveryFields.Add(this.entryNewDeliverySchedule);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.entryNewDeliverySchedule]));
			w13.TopAttach = ((uint)(5));
			w13.BottomAttach = ((uint)(6));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.evmeRegisteredBy = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.evmeRegisteredBy.Events = ((global::Gdk.EventMask)(256));
			this.evmeRegisteredBy.Name = "evmeRegisteredBy";
			this.evmeRegisteredBy.CanEditReference = true;
			this.tblUndeliveryFields.Add(this.evmeRegisteredBy);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.evmeRegisteredBy]));
			w14.TopAttach = ((uint)(6));
			w14.BottomAttach = ((uint)(7));
			w14.LeftAttach = ((uint)(1));
			w14.RightAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.frame1 = new global::Gtk.Frame();
			this.frame1.Name = "frame1";
			this.frame1.BorderWidth = ((uint)(3));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			global::Gtk.Viewport w15 = new global::Gtk.Viewport();
			w15.ShadowType = ((global::Gtk.ShadowType)(0));
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
			w15.Add(this.GtkAlignment6);
			this.GtkScrolledWindow1.Add(w15);
			this.frame1.Add(this.GtkScrolledWindow1);
			this.lblInfoCaption = new global::Gtk.Label();
			this.lblInfoCaption.Name = "lblInfoCaption";
			this.lblInfoCaption.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Информация</b>");
			this.lblInfoCaption.UseMarkup = true;
			this.frame1.LabelWidget = this.lblInfoCaption;
			this.tblUndeliveryFields.Add(this.frame1);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.frame1]));
			w20.BottomAttach = ((uint)(8));
			w20.LeftAttach = ((uint)(2));
			w20.RightAttach = ((uint)(3));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.guiltyInUndeliveryView = new global::Vodovoz.ViewWidgets.GuiltyInUndeliveryView();
			this.guiltyInUndeliveryView.Events = ((global::Gdk.EventMask)(256));
			this.guiltyInUndeliveryView.Name = "guiltyInUndeliveryView";
			this.tblUndeliveryFields.Add(this.guiltyInUndeliveryView);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.guiltyInUndeliveryView]));
			w21.LeftAttach = ((uint)(1));
			w21.RightAttach = ((uint)(2));
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
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbxForNewOrder[this.lblTransferDate]));
			w22.Position = 0;
			w22.Expand = false;
			// Container child hbxForNewOrder.Gtk.Box+BoxChild
			this.btnChooseOrder = new global::Gtk.Button();
			this.btnChooseOrder.CanFocus = true;
			this.btnChooseOrder.Name = "btnChooseOrder";
			this.btnChooseOrder.UseUnderline = true;
			this.btnChooseOrder.Label = global::Mono.Unix.Catalog.GetString("Выбрать заказ");
			this.hbxForNewOrder.Add(this.btnChooseOrder);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbxForNewOrder[this.btnChooseOrder]));
			w23.Position = 1;
			w23.Expand = false;
			w23.Fill = false;
			// Container child hbxForNewOrder.Gtk.Box+BoxChild
			this.btnNewOrder = new global::Gtk.Button();
			this.btnNewOrder.CanFocus = true;
			this.btnNewOrder.Name = "btnNewOrder";
			this.btnNewOrder.UseUnderline = true;
			this.btnNewOrder.Label = global::Mono.Unix.Catalog.GetString("Создать заказ");
			this.hbxForNewOrder.Add(this.btnNewOrder);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbxForNewOrder[this.btnNewOrder]));
			w24.Position = 2;
			w24.Expand = false;
			// Container child hbxForNewOrder.Gtk.Box+BoxChild
			this.yenumcomboboxTransferType = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumcomboboxTransferType.Name = "yenumcomboboxTransferType";
			this.yenumcomboboxTransferType.ShowSpecialStateAll = false;
			this.yenumcomboboxTransferType.ShowSpecialStateNot = false;
			this.yenumcomboboxTransferType.UseShortTitle = false;
			this.yenumcomboboxTransferType.DefaultFirst = false;
			this.hbxForNewOrder.Add(this.yenumcomboboxTransferType);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbxForNewOrder[this.yenumcomboboxTransferType]));
			w25.Position = 3;
			w25.Expand = false;
			w25.Fill = false;
			this.tblUndeliveryFields.Add(this.hbxForNewOrder);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.hbxForNewOrder]));
			w26.TopAttach = ((uint)(4));
			w26.BottomAttach = ((uint)(5));
			w26.LeftAttach = ((uint)(1));
			w26.RightAttach = ((uint)(2));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblDispatcherCallTime = new global::Gtk.Label();
			this.lblDispatcherCallTime.Name = "lblDispatcherCallTime";
			this.lblDispatcherCallTime.Xalign = 1F;
			this.lblDispatcherCallTime.LabelProp = global::Mono.Unix.Catalog.GetString("Время звонка клиенту:");
			this.tblUndeliveryFields.Add(this.lblDispatcherCallTime);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblDispatcherCallTime]));
			w27.TopAttach = ((uint)(3));
			w27.BottomAttach = ((uint)(4));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblDriverCallPlace = new global::Gtk.Label();
			this.lblDriverCallPlace.Name = "lblDriverCallPlace";
			this.lblDriverCallPlace.Xalign = 1F;
			this.lblDriverCallPlace.LabelProp = global::Mono.Unix.Catalog.GetString("Место звонка водителя:");
			this.tblUndeliveryFields.Add(this.lblDriverCallPlace);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblDriverCallPlace]));
			w28.TopAttach = ((uint)(1));
			w28.BottomAttach = ((uint)(2));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblDriverCallTime = new global::Gtk.Label();
			this.lblDriverCallTime.Name = "lblDriverCallTime";
			this.lblDriverCallTime.Xalign = 1F;
			this.lblDriverCallTime.LabelProp = global::Mono.Unix.Catalog.GetString("Время звонка водителя:");
			this.tblUndeliveryFields.Add(this.lblDriverCallTime);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblDriverCallTime]));
			w29.TopAttach = ((uint)(2));
			w29.BottomAttach = ((uint)(3));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblGuilty = new global::Gtk.Label();
			this.lblGuilty.Name = "lblGuilty";
			this.lblGuilty.Xalign = 1F;
			this.lblGuilty.LabelProp = global::Mono.Unix.Catalog.GetString("Виновники:");
			this.tblUndeliveryFields.Add(this.lblGuilty);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblGuilty]));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblNewDeliverySchedule = new global::Gtk.Label();
			this.lblNewDeliverySchedule.Name = "lblNewDeliverySchedule";
			this.lblNewDeliverySchedule.Xalign = 1F;
			this.lblNewDeliverySchedule.LabelProp = global::Mono.Unix.Catalog.GetString("Новый интервал переноса:");
			this.tblUndeliveryFields.Add(this.lblNewDeliverySchedule);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblNewDeliverySchedule]));
			w31.TopAttach = ((uint)(5));
			w31.BottomAttach = ((uint)(6));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblRegisteredBy = new global::Gtk.Label();
			this.lblRegisteredBy.Name = "lblRegisteredBy";
			this.lblRegisteredBy.Xalign = 1F;
			this.lblRegisteredBy.LabelProp = global::Mono.Unix.Catalog.GetString("Зарегистрировал:");
			this.tblUndeliveryFields.Add(this.lblRegisteredBy);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblRegisteredBy]));
			w32.TopAttach = ((uint)(6));
			w32.BottomAttach = ((uint)(7));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.lblTransferDateCaption = new global::Gtk.Label();
			this.lblTransferDateCaption.Name = "lblTransferDateCaption";
			this.lblTransferDateCaption.Xalign = 1F;
			this.lblTransferDateCaption.LabelProp = global::Mono.Unix.Catalog.GetString("Дата переноса:");
			this.tblUndeliveryFields.Add(this.lblTransferDateCaption);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.lblTransferDateCaption]));
			w33.TopAttach = ((uint)(4));
			w33.BottomAttach = ((uint)(5));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
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
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.yDateDispatcherCallTime]));
			w34.TopAttach = ((uint)(3));
			w34.BottomAttach = ((uint)(4));
			w34.LeftAttach = ((uint)(1));
			w34.RightAttach = ((uint)(2));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
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
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.yDateDriverCallTime]));
			w35.TopAttach = ((uint)(2));
			w35.BottomAttach = ((uint)(3));
			w35.LeftAttach = ((uint)(1));
			w35.RightAttach = ((uint)(2));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.yEnumCMBDriverCallPlace = new global::Gamma.Widgets.yEnumComboBox();
			this.yEnumCMBDriverCallPlace.Name = "yEnumCMBDriverCallPlace";
			this.yEnumCMBDriverCallPlace.ShowSpecialStateAll = false;
			this.yEnumCMBDriverCallPlace.ShowSpecialStateNot = false;
			this.yEnumCMBDriverCallPlace.UseShortTitle = false;
			this.yEnumCMBDriverCallPlace.DefaultFirst = false;
			this.tblUndeliveryFields.Add(this.yEnumCMBDriverCallPlace);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.yEnumCMBDriverCallPlace]));
			w36.TopAttach = ((uint)(1));
			w36.BottomAttach = ((uint)(2));
			w36.LeftAttach = ((uint)(1));
			w36.RightAttach = ((uint)(2));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.ylabelProblemSource = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelProblemSource.Name = "ylabelProblemSource";
			this.ylabelProblemSource.Xalign = 1F;
			this.ylabelProblemSource.LabelProp = global::Mono.Unix.Catalog.GetString("Источник проблемы:");
			this.tblUndeliveryFields.Add(this.ylabelProblemSource);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.ylabelProblemSource]));
			w37.TopAttach = ((uint)(7));
			w37.BottomAttach = ((uint)(8));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tblUndeliveryFields.Gtk.Table+TableChild
			this.ylabelTransferAbsenceReason = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelTransferAbsenceReason.Name = "ylabelTransferAbsenceReason";
			this.ylabelTransferAbsenceReason.Xalign = 1F;
			this.ylabelTransferAbsenceReason.LabelProp = global::Mono.Unix.Catalog.GetString("Причина отсутствия переноса:");
			this.tblUndeliveryFields.Add(this.ylabelTransferAbsenceReason);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.tblUndeliveryFields[this.ylabelTransferAbsenceReason]));
			w38.TopAttach = ((uint)(8));
			w38.BottomAttach = ((uint)(9));
			w38.XOptions = ((global::Gtk.AttachOptions)(4));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbxWithControls.Add(this.tblUndeliveryFields);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.vbxWithControls[this.tblUndeliveryFields]));
			w39.Position = 1;
			w39.Expand = false;
			w39.Fill = false;
			// Container child vbxWithControls.Gtk.Box+BoxChild
			this.vbxReasonAndFines = new global::Gtk.VBox();
			this.vbxReasonAndFines.Name = "vbxReasonAndFines";
			this.vbxReasonAndFines.Spacing = 6;
			// Container child vbxReasonAndFines.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame();
			this.frame2.Name = "frame2";
			this.frame2.BorderWidth = ((uint)(3));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment9 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment9.Name = "GtkAlignment9";
			this.GtkAlignment9.LeftPadding = ((uint)(12));
			// Container child GtkAlignment9.Gtk.Container+ContainerChild
			this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
			this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
			this.txtReason = new global::Gamma.GtkWidgets.yTextView();
			this.txtReason.CanFocus = true;
			this.txtReason.Name = "txtReason";
			this.txtReason.WrapMode = ((global::Gtk.WrapMode)(2));
			this.GtkScrolledWindow2.Add(this.txtReason);
			this.GtkAlignment9.Add(this.GtkScrolledWindow2);
			this.frame2.Add(this.GtkAlignment9);
			this.lblReason = new global::Gtk.Label();
			this.lblReason.Name = "lblReason";
			this.lblReason.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Что случилось?</b>");
			this.lblReason.UseMarkup = true;
			this.frame2.LabelWidget = this.lblReason;
			this.vbxReasonAndFines.Add(this.frame2);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.vbxReasonAndFines[this.frame2]));
			w43.Position = 0;
			// Container child vbxReasonAndFines.Gtk.Box+BoxChild
			this.frame3 = new global::Gtk.Frame();
			this.frame3.Name = "frame3";
			this.frame3.BorderWidth = ((uint)(3));
			// Container child frame3.Gtk.Container+ContainerChild
			this.GtkAlignment10 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment10.Name = "GtkAlignment10";
			this.GtkAlignment10.LeftPadding = ((uint)(12));
			// Container child GtkAlignment10.Gtk.Container+ContainerChild
			this.GtkScrolledWindow3 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow3.Name = "GtkScrolledWindow3";
			this.GtkScrolledWindow3.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow3.Gtk.Container+ContainerChild
			this.yTreeFines = new global::Gamma.GtkWidgets.yTreeView();
			this.yTreeFines.CanFocus = true;
			this.yTreeFines.Name = "yTreeFines";
			this.GtkScrolledWindow3.Add(this.yTreeFines);
			this.GtkAlignment10.Add(this.GtkScrolledWindow3);
			this.frame3.Add(this.GtkAlignment10);
			this.lblFines = new global::Gtk.Label();
			this.lblFines.Name = "lblFines";
			this.lblFines.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Штрафы</b>");
			this.lblFines.UseMarkup = true;
			this.frame3.LabelWidget = this.lblFines;
			this.vbxReasonAndFines.Add(this.frame3);
			global::Gtk.Box.BoxChild w47 = ((global::Gtk.Box.BoxChild)(this.vbxReasonAndFines[this.frame3]));
			w47.Position = 1;
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
			w49.Position = 2;
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
