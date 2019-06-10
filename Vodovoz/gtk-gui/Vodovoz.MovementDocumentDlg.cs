﻿
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class MovementDocumentDlg
	{
		private global::Gtk.VBox vbox3;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Table tableCommon;

		private global::Gamma.Widgets.yEnumComboBox enumMovementType;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gamma.GtkWidgets.yTextView textComment;

		private global::Gtk.HBox hboxTransportation;

		private global::Gamma.GtkWidgets.yLabel ylabelTransportationStatus;

		private global::Gtk.Button buttonDelivered;

		private global::Gtk.Label label1;

		private global::Gtk.Label label12;

		private global::Gtk.Label label13;

		private global::Gtk.Label label3;

		private global::Gamma.GtkWidgets.yLabel labelTimeStamp;

		private global::Gtk.Label labelTransportationTitle;

		private global::Gtk.Label labelWagon;

		private global::QS.Widgets.GtkUI.RepresentationEntry repEntryEmployee;

		private global::Gamma.Widgets.yEntryReference yentryrefWagon;

		private global::Gtk.HBox hbox3;

		private global::Gtk.VBox vbox2;

		private global::Gtk.Label label11;

		private global::Gtk.Table tableSender;

		private global::Gtk.Label labelClientFrom;

		private global::Gtk.Label labelPointFrom;

		private global::Gtk.Label labelStockFrom;

		private global::QS.Widgets.GtkUI.RepresentationEntry referenceCounterpartyFrom;

		private global::Gamma.Widgets.yEntryReference referenceDeliveryPointFrom;

		private global::Gamma.Widgets.yEntryReference referenceWarehouseFrom;

		private global::Gtk.VSeparator vseparator1;

		private global::Gtk.VBox vbox4;

		private global::Gtk.Label label10;

		private global::Gtk.Table tableReceiver;

		private global::Gtk.Label labelClientTo;

		private global::Gtk.Label labelPointTo;

		private global::Gtk.Label labelStockTo;

		private global::QS.Widgets.GtkUI.RepresentationEntry referenceCounterpartyTo;

		private global::Gamma.Widgets.yEntryReference referenceDeliveryPointTo;

		private global::Gamma.Widgets.yEntryReference referenceWarehouseTo;

		private global::Vodovoz.MovementDocumentItemsView movementdocumentitemsview1;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button buttonPrint;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.MovementDocumentDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.MovementDocumentDlg";
			// Container child Vodovoz.MovementDocumentDlg.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			this.vbox3.BorderWidth = ((uint)(6));
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox4.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox4.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox3.Add(this.hbox4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox4]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.tableCommon = new global::Gtk.Table(((uint)(4)), ((uint)(4)), false);
			this.tableCommon.Name = "tableCommon";
			this.tableCommon.RowSpacing = ((uint)(6));
			this.tableCommon.ColumnSpacing = ((uint)(6));
			// Container child tableCommon.Gtk.Table+TableChild
			this.enumMovementType = new global::Gamma.Widgets.yEnumComboBox();
			this.enumMovementType.Name = "enumMovementType";
			this.enumMovementType.ShowSpecialStateAll = false;
			this.enumMovementType.ShowSpecialStateNot = false;
			this.enumMovementType.UseShortTitle = false;
			this.enumMovementType.DefaultFirst = true;
			this.tableCommon.Add(this.enumMovementType);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.enumMovementType]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableCommon.Gtk.Table+TableChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.textComment = new global::Gamma.GtkWidgets.yTextView();
			this.textComment.CanFocus = true;
			this.textComment.Name = "textComment";
			this.GtkScrolledWindow1.Add(this.textComment);
			this.tableCommon.Add(this.GtkScrolledWindow1);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.GtkScrolledWindow1]));
			w8.TopAttach = ((uint)(3));
			w8.BottomAttach = ((uint)(4));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(4));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableCommon.Gtk.Table+TableChild
			this.hboxTransportation = new global::Gtk.HBox();
			this.hboxTransportation.Name = "hboxTransportation";
			this.hboxTransportation.Spacing = 6;
			// Container child hboxTransportation.Gtk.Box+BoxChild
			this.ylabelTransportationStatus = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelTransportationStatus.Name = "ylabelTransportationStatus";
			this.ylabelTransportationStatus.LabelProp = global::Mono.Unix.Catalog.GetString("ylabel1");
			this.hboxTransportation.Add(this.ylabelTransportationStatus);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hboxTransportation[this.ylabelTransportationStatus]));
			w9.Position = 0;
			// Container child hboxTransportation.Gtk.Box+BoxChild
			this.buttonDelivered = new global::Gtk.Button();
			this.buttonDelivered.CanFocus = true;
			this.buttonDelivered.Name = "buttonDelivered";
			this.buttonDelivered.UseUnderline = true;
			this.buttonDelivered.Label = global::Mono.Unix.Catalog.GetString("Доставлено");
			this.hboxTransportation.Add(this.buttonDelivered);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hboxTransportation[this.buttonDelivered]));
			w10.Position = 1;
			w10.Expand = false;
			w10.Fill = false;
			this.tableCommon.Add(this.hboxTransportation);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.hboxTransportation]));
			w11.TopAttach = ((uint)(2));
			w11.BottomAttach = ((uint)(3));
			w11.LeftAttach = ((uint)(3));
			w11.RightAttach = ((uint)(4));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableCommon.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Дата:");
			this.tableCommon.Add(this.label1);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.label1]));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableCommon.Gtk.Table+TableChild
			this.label12 = new global::Gtk.Label();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString("Ответственное лицо:");
			this.tableCommon.Add(this.label12);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.label12]));
			w13.LeftAttach = ((uint)(2));
			w13.RightAttach = ((uint)(3));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableCommon.Gtk.Table+TableChild
			this.label13 = new global::Gtk.Label();
			this.label13.Name = "label13";
			this.label13.Xalign = 1F;
			this.label13.Yalign = 0F;
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString("Комментарий:");
			this.tableCommon.Add(this.label13);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.label13]));
			w14.TopAttach = ((uint)(3));
			w14.BottomAttach = ((uint)(4));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableCommon.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Тип документа:");
			this.tableCommon.Add(this.label3);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.label3]));
			w15.TopAttach = ((uint)(1));
			w15.BottomAttach = ((uint)(2));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableCommon.Gtk.Table+TableChild
			this.labelTimeStamp = new global::Gamma.GtkWidgets.yLabel();
			this.labelTimeStamp.Name = "labelTimeStamp";
			this.labelTimeStamp.Xalign = 0F;
			this.tableCommon.Add(this.labelTimeStamp);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.labelTimeStamp]));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableCommon.Gtk.Table+TableChild
			this.labelTransportationTitle = new global::Gtk.Label();
			this.labelTransportationTitle.Name = "labelTransportationTitle";
			this.labelTransportationTitle.LabelProp = global::Mono.Unix.Catalog.GetString("Статус траспортировки:");
			this.tableCommon.Add(this.labelTransportationTitle);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.labelTransportationTitle]));
			w17.TopAttach = ((uint)(2));
			w17.BottomAttach = ((uint)(3));
			w17.LeftAttach = ((uint)(2));
			w17.RightAttach = ((uint)(3));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableCommon.Gtk.Table+TableChild
			this.labelWagon = new global::Gtk.Label();
			this.labelWagon.Name = "labelWagon";
			this.labelWagon.Xalign = 1F;
			this.labelWagon.LabelProp = global::Mono.Unix.Catalog.GetString("Фура:");
			this.tableCommon.Add(this.labelWagon);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.labelWagon]));
			w18.TopAttach = ((uint)(1));
			w18.BottomAttach = ((uint)(2));
			w18.LeftAttach = ((uint)(2));
			w18.RightAttach = ((uint)(3));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableCommon.Gtk.Table+TableChild
			this.repEntryEmployee = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.repEntryEmployee.Events = ((global::Gdk.EventMask)(256));
			this.repEntryEmployee.Name = "repEntryEmployee";
			this.tableCommon.Add(this.repEntryEmployee);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.repEntryEmployee]));
			w19.LeftAttach = ((uint)(3));
			w19.RightAttach = ((uint)(4));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableCommon.Gtk.Table+TableChild
			this.yentryrefWagon = new global::Gamma.Widgets.yEntryReference();
			this.yentryrefWagon.Events = ((global::Gdk.EventMask)(256));
			this.yentryrefWagon.Name = "yentryrefWagon";
			this.tableCommon.Add(this.yentryrefWagon);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.tableCommon[this.yentryrefWagon]));
			w20.TopAttach = ((uint)(1));
			w20.BottomAttach = ((uint)(2));
			w20.LeftAttach = ((uint)(3));
			w20.RightAttach = ((uint)(4));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox3.Add(this.tableCommon);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.tableCommon]));
			w21.Position = 1;
			w21.Expand = false;
			w21.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label11 = new global::Gtk.Label();
			this.label11.Name = "label11";
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString("Отправитель");
			this.vbox2.Add(this.label11);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.label11]));
			w22.Position = 0;
			w22.Expand = false;
			w22.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.tableSender = new global::Gtk.Table(((uint)(3)), ((uint)(2)), false);
			this.tableSender.Name = "tableSender";
			this.tableSender.RowSpacing = ((uint)(6));
			this.tableSender.ColumnSpacing = ((uint)(6));
			// Container child tableSender.Gtk.Table+TableChild
			this.labelClientFrom = new global::Gtk.Label();
			this.labelClientFrom.Name = "labelClientFrom";
			this.labelClientFrom.Xalign = 1F;
			this.labelClientFrom.LabelProp = global::Mono.Unix.Catalog.GetString("Клиент:");
			this.tableSender.Add(this.labelClientFrom);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.tableSender[this.labelClientFrom]));
			w23.TopAttach = ((uint)(1));
			w23.BottomAttach = ((uint)(2));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableSender.Gtk.Table+TableChild
			this.labelPointFrom = new global::Gtk.Label();
			this.labelPointFrom.Name = "labelPointFrom";
			this.labelPointFrom.Xalign = 1F;
			this.labelPointFrom.LabelProp = global::Mono.Unix.Catalog.GetString("Точка доставки:");
			this.tableSender.Add(this.labelPointFrom);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.tableSender[this.labelPointFrom]));
			w24.TopAttach = ((uint)(2));
			w24.BottomAttach = ((uint)(3));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableSender.Gtk.Table+TableChild
			this.labelStockFrom = new global::Gtk.Label();
			this.labelStockFrom.Name = "labelStockFrom";
			this.labelStockFrom.Xalign = 1F;
			this.labelStockFrom.LabelProp = global::Mono.Unix.Catalog.GetString("Склад:");
			this.tableSender.Add(this.labelStockFrom);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.tableSender[this.labelStockFrom]));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableSender.Gtk.Table+TableChild
			this.referenceCounterpartyFrom = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.referenceCounterpartyFrom.Events = ((global::Gdk.EventMask)(256));
			this.referenceCounterpartyFrom.Name = "referenceCounterpartyFrom";
			this.tableSender.Add(this.referenceCounterpartyFrom);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.tableSender[this.referenceCounterpartyFrom]));
			w26.TopAttach = ((uint)(1));
			w26.BottomAttach = ((uint)(2));
			w26.LeftAttach = ((uint)(1));
			w26.RightAttach = ((uint)(2));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableSender.Gtk.Table+TableChild
			this.referenceDeliveryPointFrom = new global::Gamma.Widgets.yEntryReference();
			this.referenceDeliveryPointFrom.Events = ((global::Gdk.EventMask)(256));
			this.referenceDeliveryPointFrom.Name = "referenceDeliveryPointFrom";
			this.tableSender.Add(this.referenceDeliveryPointFrom);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.tableSender[this.referenceDeliveryPointFrom]));
			w27.TopAttach = ((uint)(2));
			w27.BottomAttach = ((uint)(3));
			w27.LeftAttach = ((uint)(1));
			w27.RightAttach = ((uint)(2));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableSender.Gtk.Table+TableChild
			this.referenceWarehouseFrom = new global::Gamma.Widgets.yEntryReference();
			this.referenceWarehouseFrom.Events = ((global::Gdk.EventMask)(256));
			this.referenceWarehouseFrom.Name = "referenceWarehouseFrom";
			this.tableSender.Add(this.referenceWarehouseFrom);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.tableSender[this.referenceWarehouseFrom]));
			w28.LeftAttach = ((uint)(1));
			w28.RightAttach = ((uint)(2));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add(this.tableSender);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.tableSender]));
			w29.Position = 1;
			w29.Expand = false;
			w29.Fill = false;
			this.hbox3.Add(this.vbox2);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vbox2]));
			w30.Position = 0;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator();
			this.vseparator1.Name = "vseparator1";
			this.hbox3.Add(this.vseparator1);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vseparator1]));
			w31.Position = 1;
			w31.Expand = false;
			w31.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("Получатель");
			this.vbox4.Add(this.label10);
			global::Gtk.Box.BoxChild w32 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.label10]));
			w32.Position = 0;
			w32.Expand = false;
			w32.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.tableReceiver = new global::Gtk.Table(((uint)(3)), ((uint)(2)), false);
			this.tableReceiver.Name = "tableReceiver";
			this.tableReceiver.RowSpacing = ((uint)(6));
			this.tableReceiver.ColumnSpacing = ((uint)(6));
			// Container child tableReceiver.Gtk.Table+TableChild
			this.labelClientTo = new global::Gtk.Label();
			this.labelClientTo.Name = "labelClientTo";
			this.labelClientTo.Xalign = 1F;
			this.labelClientTo.LabelProp = global::Mono.Unix.Catalog.GetString("Клиент:");
			this.tableReceiver.Add(this.labelClientTo);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.tableReceiver[this.labelClientTo]));
			w33.TopAttach = ((uint)(1));
			w33.BottomAttach = ((uint)(2));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableReceiver.Gtk.Table+TableChild
			this.labelPointTo = new global::Gtk.Label();
			this.labelPointTo.Name = "labelPointTo";
			this.labelPointTo.Xalign = 1F;
			this.labelPointTo.LabelProp = global::Mono.Unix.Catalog.GetString("Точка доставки:");
			this.tableReceiver.Add(this.labelPointTo);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.tableReceiver[this.labelPointTo]));
			w34.TopAttach = ((uint)(2));
			w34.BottomAttach = ((uint)(3));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableReceiver.Gtk.Table+TableChild
			this.labelStockTo = new global::Gtk.Label();
			this.labelStockTo.Name = "labelStockTo";
			this.labelStockTo.Xalign = 1F;
			this.labelStockTo.LabelProp = global::Mono.Unix.Catalog.GetString("Склад:");
			this.tableReceiver.Add(this.labelStockTo);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.tableReceiver[this.labelStockTo]));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableReceiver.Gtk.Table+TableChild
			this.referenceCounterpartyTo = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.referenceCounterpartyTo.Events = ((global::Gdk.EventMask)(256));
			this.referenceCounterpartyTo.Name = "referenceCounterpartyTo";
			this.tableReceiver.Add(this.referenceCounterpartyTo);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.tableReceiver[this.referenceCounterpartyTo]));
			w36.TopAttach = ((uint)(1));
			w36.BottomAttach = ((uint)(2));
			w36.LeftAttach = ((uint)(1));
			w36.RightAttach = ((uint)(2));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableReceiver.Gtk.Table+TableChild
			this.referenceDeliveryPointTo = new global::Gamma.Widgets.yEntryReference();
			this.referenceDeliveryPointTo.Events = ((global::Gdk.EventMask)(256));
			this.referenceDeliveryPointTo.Name = "referenceDeliveryPointTo";
			this.tableReceiver.Add(this.referenceDeliveryPointTo);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.tableReceiver[this.referenceDeliveryPointTo]));
			w37.TopAttach = ((uint)(2));
			w37.BottomAttach = ((uint)(3));
			w37.LeftAttach = ((uint)(1));
			w37.RightAttach = ((uint)(2));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableReceiver.Gtk.Table+TableChild
			this.referenceWarehouseTo = new global::Gamma.Widgets.yEntryReference();
			this.referenceWarehouseTo.Events = ((global::Gdk.EventMask)(256));
			this.referenceWarehouseTo.Name = "referenceWarehouseTo";
			this.tableReceiver.Add(this.referenceWarehouseTo);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.tableReceiver[this.referenceWarehouseTo]));
			w38.LeftAttach = ((uint)(1));
			w38.RightAttach = ((uint)(2));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox4.Add(this.tableReceiver);
			global::Gtk.Box.BoxChild w39 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.tableReceiver]));
			w39.Position = 1;
			w39.Expand = false;
			w39.Fill = false;
			this.hbox3.Add(this.vbox4);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.vbox4]));
			w40.Position = 2;
			this.vbox3.Add(this.hbox3);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox3]));
			w41.Position = 2;
			w41.Expand = false;
			w41.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.movementdocumentitemsview1 = new global::Vodovoz.MovementDocumentItemsView();
			this.movementdocumentitemsview1.Events = ((global::Gdk.EventMask)(256));
			this.movementdocumentitemsview1.Name = "movementdocumentitemsview1";
			this.vbox3.Add(this.movementdocumentitemsview1);
			global::Gtk.Box.BoxChild w42 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.movementdocumentitemsview1]));
			w42.Position = 3;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonPrint = new global::Gtk.Button();
			this.buttonPrint.CanFocus = true;
			this.buttonPrint.Name = "buttonPrint";
			this.buttonPrint.UseUnderline = true;
			this.buttonPrint.Label = global::Mono.Unix.Catalog.GetString("Печать документа перемещения");
			global::Gtk.Image w43 = new global::Gtk.Image();
			w43.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-print", global::Gtk.IconSize.Menu);
			this.buttonPrint.Image = w43;
			this.hbox2.Add(this.buttonPrint);
			global::Gtk.Box.BoxChild w44 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonPrint]));
			w44.Position = 2;
			w44.Expand = false;
			w44.Fill = false;
			this.vbox3.Add(this.hbox2);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox2]));
			w45.PackType = ((global::Gtk.PackType)(1));
			w45.Position = 4;
			w45.Expand = false;
			w45.Fill = false;
			this.Add(this.vbox3);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonDelivered.Clicked += new global::System.EventHandler(this.OnButtonDeliveredClicked);
			this.enumMovementType.Changed += new global::System.EventHandler(this.OnEnumMovementTypeChanged);
			this.referenceCounterpartyFrom.Changed += new global::System.EventHandler(this.OnReferenceCounterpartyFromChanged);
			this.referenceCounterpartyTo.Changed += new global::System.EventHandler(this.OnReferenceCounterpartyToChanged);
			this.buttonPrint.Clicked += new global::System.EventHandler(this.OnButtonPrintClicked);
		}
	}
}
