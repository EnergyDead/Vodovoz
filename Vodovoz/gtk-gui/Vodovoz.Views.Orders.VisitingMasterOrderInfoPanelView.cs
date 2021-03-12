
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Orders
{
	public partial class VisitingMasterOrderInfoPanelView
	{
		private global::Gtk.VBox vboxInfo;

		private global::Gtk.Table tableInfo;

		private global::QS.Views.Control.EntityEntry counterpartyEntry;

		private global::QS.Widgets.GtkUI.DatePicker datePickerDeliveryDate;

		private global::QS.Views.Control.EntityEntry deliveryPointEntry;

		private global::Gamma.Widgets.yEnumComboBox enumDocumentType;

		private global::Gamma.Widgets.yEnumComboBox enumPaymentType;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTextView ytxtViewComment;

		private global::Gtk.HBox hbxOnlineOrder;

		private global::Gtk.Label lblOnlineOrder;

		private global::Gamma.Widgets.yValidatedEntry entOnlineOrder1;

		private global::Gamma.Widgets.ySpecComboBox ySpecPaymentFrom1;

		private global::Gtk.HSeparator hseparator1;

		private global::Gtk.Label labelBillDate;

		private global::Gtk.Label labelDocumentType;

		private global::Gtk.Label lblPaymentType;

		private global::QS.Widgets.GtkUI.DatePicker pickerBillDate;

		private global::Gamma.Widgets.yEntryReference referenceDeliverySchedule;

		private global::Gamma.GtkWidgets.yCheckButton ycheckAddCertificates;

		private global::Gamma.GtkWidgets.yCheckButton ycheckContactlessDelivery;

		private global::Gamma.GtkWidgets.yCheckButton ycheckPaymentBySMS;

		private global::Gamma.GtkWidgets.yLabel ylblAuthor;

		private global::Gamma.GtkWidgets.yLabel ylblComment;

		private global::Gamma.GtkWidgets.yLabel ylblCounterparty;

		private global::Gamma.GtkWidgets.yLabel ylblCreated;

		private global::Gamma.GtkWidgets.yLabel ylblCreationDate;

		private global::Gamma.GtkWidgets.yLabel ylblDeliveryDate;

		private global::Gamma.GtkWidgets.yLabel ylblDeliveryPoint;

		private global::Gamma.GtkWidgets.yLabel ylblDeliveryTime;

		private global::Gamma.GtkWidgets.yLabel ylblExtraService;

		private global::Gamma.GtkWidgets.yLabel ylblOrderAuthor;

		private global::Gamma.GtkWidgets.yLabel ylblStatus;

		private global::Gamma.GtkWidgets.yLabel ylblStatusInfo;

		private global::Gtk.Expander expanderCommentForLogistician;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gamma.GtkWidgets.yTextView ytextview2;

		private global::Gtk.Label GtkLblCommentForLogistician;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Orders.VisitingMasterOrderInfoPanelView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Orders.VisitingMasterOrderInfoPanelView";
			// Container child Vodovoz.Views.Orders.VisitingMasterOrderInfoPanelView.Gtk.Container+ContainerChild
			this.vboxInfo = new global::Gtk.VBox();
			this.vboxInfo.Name = "vboxInfo";
			this.vboxInfo.Spacing = 6;
			// Container child vboxInfo.Gtk.Box+BoxChild
			this.tableInfo = new global::Gtk.Table(((uint)(13)), ((uint)(5)), false);
			this.tableInfo.Name = "tableInfo";
			this.tableInfo.RowSpacing = ((uint)(6));
			this.tableInfo.ColumnSpacing = ((uint)(6));
			// Container child tableInfo.Gtk.Table+TableChild
			this.counterpartyEntry = new global::QS.Views.Control.EntityEntry();
			this.counterpartyEntry.Events = ((global::Gdk.EventMask)(256));
			this.counterpartyEntry.Name = "counterpartyEntry";
			this.tableInfo.Add(this.counterpartyEntry);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.counterpartyEntry]));
			w1.TopAttach = ((uint)(2));
			w1.BottomAttach = ((uint)(3));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(5));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.datePickerDeliveryDate = new global::QS.Widgets.GtkUI.DatePicker();
			this.datePickerDeliveryDate.Events = ((global::Gdk.EventMask)(256));
			this.datePickerDeliveryDate.Name = "datePickerDeliveryDate";
			this.datePickerDeliveryDate.WithTime = false;
			this.datePickerDeliveryDate.HideCalendarButton = false;
			this.datePickerDeliveryDate.Date = new global::System.DateTime(0);
			this.datePickerDeliveryDate.IsEditable = false;
			this.datePickerDeliveryDate.AutoSeparation = false;
			this.tableInfo.Add(this.datePickerDeliveryDate);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.datePickerDeliveryDate]));
			w2.TopAttach = ((uint)(4));
			w2.BottomAttach = ((uint)(5));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.deliveryPointEntry = new global::QS.Views.Control.EntityEntry();
			this.deliveryPointEntry.Events = ((global::Gdk.EventMask)(256));
			this.deliveryPointEntry.Name = "deliveryPointEntry";
			this.tableInfo.Add(this.deliveryPointEntry);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.deliveryPointEntry]));
			w3.TopAttach = ((uint)(3));
			w3.BottomAttach = ((uint)(4));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(5));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.enumDocumentType = new global::Gamma.Widgets.yEnumComboBox();
			this.enumDocumentType.Name = "enumDocumentType";
			this.enumDocumentType.ShowSpecialStateAll = false;
			this.enumDocumentType.ShowSpecialStateNot = false;
			this.enumDocumentType.UseShortTitle = false;
			this.enumDocumentType.DefaultFirst = false;
			this.tableInfo.Add(this.enumDocumentType);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.enumDocumentType]));
			w4.TopAttach = ((uint)(6));
			w4.BottomAttach = ((uint)(7));
			w4.LeftAttach = ((uint)(4));
			w4.RightAttach = ((uint)(5));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.enumPaymentType = new global::Gamma.Widgets.yEnumComboBox();
			this.enumPaymentType.Name = "enumPaymentType";
			this.enumPaymentType.ShowSpecialStateAll = false;
			this.enumPaymentType.ShowSpecialStateNot = false;
			this.enumPaymentType.UseShortTitle = false;
			this.enumPaymentType.DefaultFirst = false;
			this.tableInfo.Add(this.enumPaymentType);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.enumPaymentType]));
			w5.TopAttach = ((uint)(5));
			w5.BottomAttach = ((uint)(6));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(3));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytxtViewComment = new global::Gamma.GtkWidgets.yTextView();
			this.ytxtViewComment.CanFocus = true;
			this.ytxtViewComment.Name = "ytxtViewComment";
			this.GtkScrolledWindow.Add(this.ytxtViewComment);
			this.tableInfo.Add(this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.GtkScrolledWindow]));
			w7.TopAttach = ((uint)(8));
			w7.BottomAttach = ((uint)(12));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.hbxOnlineOrder = new global::Gtk.HBox();
			this.hbxOnlineOrder.Name = "hbxOnlineOrder";
			this.hbxOnlineOrder.Spacing = 6;
			// Container child hbxOnlineOrder.Gtk.Box+BoxChild
			this.lblOnlineOrder = new global::Gtk.Label();
			this.lblOnlineOrder.Name = "lblOnlineOrder";
			this.lblOnlineOrder.Xalign = 1F;
			this.lblOnlineOrder.LabelProp = global::Mono.Unix.Catalog.GetString("Онлайн заказ:");
			this.hbxOnlineOrder.Add(this.lblOnlineOrder);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbxOnlineOrder[this.lblOnlineOrder]));
			w8.Position = 0;
			w8.Expand = false;
			// Container child hbxOnlineOrder.Gtk.Box+BoxChild
			this.entOnlineOrder1 = new global::Gamma.Widgets.yValidatedEntry();
			this.entOnlineOrder1.CanFocus = true;
			this.entOnlineOrder1.Name = "entOnlineOrder1";
			this.entOnlineOrder1.IsEditable = true;
			this.entOnlineOrder1.MaxLength = 10;
			this.entOnlineOrder1.InvisibleChar = '●';
			this.hbxOnlineOrder.Add(this.entOnlineOrder1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbxOnlineOrder[this.entOnlineOrder1]));
			w9.Position = 1;
			w9.Expand = false;
			// Container child hbxOnlineOrder.Gtk.Box+BoxChild
			this.ySpecPaymentFrom1 = new global::Gamma.Widgets.ySpecComboBox();
			this.ySpecPaymentFrom1.Name = "ySpecPaymentFrom1";
			this.ySpecPaymentFrom1.AddIfNotExist = false;
			this.ySpecPaymentFrom1.DefaultFirst = false;
			this.ySpecPaymentFrom1.ShowSpecialStateAll = false;
			this.ySpecPaymentFrom1.ShowSpecialStateNot = false;
			this.hbxOnlineOrder.Add(this.ySpecPaymentFrom1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbxOnlineOrder[this.ySpecPaymentFrom1]));
			w10.Position = 2;
			this.tableInfo.Add(this.hbxOnlineOrder);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.hbxOnlineOrder]));
			w11.TopAttach = ((uint)(5));
			w11.BottomAttach = ((uint)(6));
			w11.LeftAttach = ((uint)(3));
			w11.RightAttach = ((uint)(5));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.hseparator1 = new global::Gtk.HSeparator();
			this.hseparator1.Name = "hseparator1";
			this.tableInfo.Add(this.hseparator1);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.hseparator1]));
			w12.TopAttach = ((uint)(7));
			w12.BottomAttach = ((uint)(8));
			w12.RightAttach = ((uint)(5));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.labelBillDate = new global::Gtk.Label();
			this.labelBillDate.Name = "labelBillDate";
			this.labelBillDate.Xalign = 1F;
			this.labelBillDate.LabelProp = global::Mono.Unix.Catalog.GetString("Дата счета:");
			this.tableInfo.Add(this.labelBillDate);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.labelBillDate]));
			w13.TopAttach = ((uint)(6));
			w13.BottomAttach = ((uint)(7));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.labelDocumentType = new global::Gtk.Label();
			this.labelDocumentType.Name = "labelDocumentType";
			this.labelDocumentType.Xalign = 1F;
			this.labelDocumentType.LabelProp = global::Mono.Unix.Catalog.GetString("Тип документов:");
			this.tableInfo.Add(this.labelDocumentType);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.labelDocumentType]));
			w14.TopAttach = ((uint)(6));
			w14.BottomAttach = ((uint)(7));
			w14.LeftAttach = ((uint)(3));
			w14.RightAttach = ((uint)(4));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.lblPaymentType = new global::Gtk.Label();
			this.lblPaymentType.Name = "lblPaymentType";
			this.lblPaymentType.Xalign = 1F;
			this.lblPaymentType.LabelProp = global::Mono.Unix.Catalog.GetString("Форма оплаты:");
			this.tableInfo.Add(this.lblPaymentType);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.lblPaymentType]));
			w15.TopAttach = ((uint)(5));
			w15.BottomAttach = ((uint)(6));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.pickerBillDate = new global::QS.Widgets.GtkUI.DatePicker();
			this.pickerBillDate.Events = ((global::Gdk.EventMask)(256));
			this.pickerBillDate.Name = "pickerBillDate";
			this.pickerBillDate.WithTime = false;
			this.pickerBillDate.HideCalendarButton = false;
			this.pickerBillDate.Date = new global::System.DateTime(0);
			this.pickerBillDate.IsEditable = true;
			this.pickerBillDate.AutoSeparation = true;
			this.tableInfo.Add(this.pickerBillDate);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.pickerBillDate]));
			w16.TopAttach = ((uint)(6));
			w16.BottomAttach = ((uint)(7));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.referenceDeliverySchedule = new global::Gamma.Widgets.yEntryReference();
			this.referenceDeliverySchedule.Events = ((global::Gdk.EventMask)(256));
			this.referenceDeliverySchedule.Name = "referenceDeliverySchedule";
			this.tableInfo.Add(this.referenceDeliverySchedule);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.referenceDeliverySchedule]));
			w17.TopAttach = ((uint)(4));
			w17.BottomAttach = ((uint)(5));
			w17.LeftAttach = ((uint)(4));
			w17.RightAttach = ((uint)(5));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ycheckAddCertificates = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckAddCertificates.CanFocus = true;
			this.ycheckAddCertificates.Name = "ycheckAddCertificates";
			this.ycheckAddCertificates.Label = global::Mono.Unix.Catalog.GetString("Сертификаты");
			this.ycheckAddCertificates.DrawIndicator = true;
			this.ycheckAddCertificates.UseUnderline = true;
			this.tableInfo.Add(this.ycheckAddCertificates);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ycheckAddCertificates]));
			w18.TopAttach = ((uint)(11));
			w18.BottomAttach = ((uint)(12));
			w18.LeftAttach = ((uint)(4));
			w18.RightAttach = ((uint)(5));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ycheckContactlessDelivery = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckContactlessDelivery.CanFocus = true;
			this.ycheckContactlessDelivery.Name = "ycheckContactlessDelivery";
			this.ycheckContactlessDelivery.Label = global::Mono.Unix.Catalog.GetString("Бесконтактная\nдоставка");
			this.ycheckContactlessDelivery.DrawIndicator = true;
			this.ycheckContactlessDelivery.UseUnderline = true;
			this.tableInfo.Add(this.ycheckContactlessDelivery);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ycheckContactlessDelivery]));
			w19.TopAttach = ((uint)(10));
			w19.BottomAttach = ((uint)(11));
			w19.LeftAttach = ((uint)(4));
			w19.RightAttach = ((uint)(5));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ycheckPaymentBySMS = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckPaymentBySMS.CanFocus = true;
			this.ycheckPaymentBySMS.Name = "ycheckPaymentBySMS";
			this.ycheckPaymentBySMS.Label = global::Mono.Unix.Catalog.GetString("Оплата по СМС");
			this.ycheckPaymentBySMS.DrawIndicator = true;
			this.ycheckPaymentBySMS.UseUnderline = true;
			this.tableInfo.Add(this.ycheckPaymentBySMS);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ycheckPaymentBySMS]));
			w20.TopAttach = ((uint)(9));
			w20.BottomAttach = ((uint)(10));
			w20.LeftAttach = ((uint)(4));
			w20.RightAttach = ((uint)(5));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblAuthor = new global::Gamma.GtkWidgets.yLabel();
			this.ylblAuthor.Name = "ylblAuthor";
			this.ylblAuthor.Xalign = 1F;
			this.ylblAuthor.LabelProp = global::Mono.Unix.Catalog.GetString("Автор:");
			this.tableInfo.Add(this.ylblAuthor);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblAuthor]));
			w21.TopAttach = ((uint)(1));
			w21.BottomAttach = ((uint)(2));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblComment = new global::Gamma.GtkWidgets.yLabel();
			this.ylblComment.Name = "ylblComment";
			this.ylblComment.Xalign = 1F;
			this.ylblComment.LabelProp = global::Mono.Unix.Catalog.GetString("Комментарий:");
			this.tableInfo.Add(this.ylblComment);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblComment]));
			w22.TopAttach = ((uint)(8));
			w22.BottomAttach = ((uint)(9));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblCounterparty = new global::Gamma.GtkWidgets.yLabel();
			this.ylblCounterparty.Name = "ylblCounterparty";
			this.ylblCounterparty.Xalign = 1F;
			this.ylblCounterparty.LabelProp = global::Mono.Unix.Catalog.GetString("Клиент:");
			this.tableInfo.Add(this.ylblCounterparty);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblCounterparty]));
			w23.TopAttach = ((uint)(2));
			w23.BottomAttach = ((uint)(3));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblCreated = new global::Gamma.GtkWidgets.yLabel();
			this.ylblCreated.Name = "ylblCreated";
			this.ylblCreated.Xalign = 1F;
			this.ylblCreated.LabelProp = global::Mono.Unix.Catalog.GetString("Создан:");
			this.tableInfo.Add(this.ylblCreated);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblCreated]));
			w24.LeftAttach = ((uint)(2));
			w24.RightAttach = ((uint)(3));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblCreationDate = new global::Gamma.GtkWidgets.yLabel();
			this.ylblCreationDate.Name = "ylblCreationDate";
			this.ylblCreationDate.Xalign = 0F;
			this.ylblCreationDate.LabelProp = global::Mono.Unix.Catalog.GetString("\"Дата создания\"");
			this.tableInfo.Add(this.ylblCreationDate);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblCreationDate]));
			w25.LeftAttach = ((uint)(3));
			w25.RightAttach = ((uint)(4));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblDeliveryDate = new global::Gamma.GtkWidgets.yLabel();
			this.ylblDeliveryDate.Name = "ylblDeliveryDate";
			this.ylblDeliveryDate.Xalign = 1F;
			this.ylblDeliveryDate.LabelProp = global::Mono.Unix.Catalog.GetString("Дата доставки:");
			this.tableInfo.Add(this.ylblDeliveryDate);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblDeliveryDate]));
			w26.TopAttach = ((uint)(4));
			w26.BottomAttach = ((uint)(5));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblDeliveryPoint = new global::Gamma.GtkWidgets.yLabel();
			this.ylblDeliveryPoint.Name = "ylblDeliveryPoint";
			this.ylblDeliveryPoint.Xalign = 1F;
			this.ylblDeliveryPoint.LabelProp = global::Mono.Unix.Catalog.GetString("Точка доставки:");
			this.tableInfo.Add(this.ylblDeliveryPoint);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblDeliveryPoint]));
			w27.TopAttach = ((uint)(3));
			w27.BottomAttach = ((uint)(4));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblDeliveryTime = new global::Gamma.GtkWidgets.yLabel();
			this.ylblDeliveryTime.Name = "ylblDeliveryTime";
			this.ylblDeliveryTime.Xalign = 1F;
			this.ylblDeliveryTime.LabelProp = global::Mono.Unix.Catalog.GetString("Интервал:");
			this.tableInfo.Add(this.ylblDeliveryTime);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblDeliveryTime]));
			w28.TopAttach = ((uint)(4));
			w28.BottomAttach = ((uint)(5));
			w28.LeftAttach = ((uint)(3));
			w28.RightAttach = ((uint)(4));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblExtraService = new global::Gamma.GtkWidgets.yLabel();
			this.ylblExtraService.Name = "ylblExtraService";
			this.ylblExtraService.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Дополнительные\nуслуги</b>");
			this.ylblExtraService.UseMarkup = true;
			this.tableInfo.Add(this.ylblExtraService);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblExtraService]));
			w29.TopAttach = ((uint)(8));
			w29.BottomAttach = ((uint)(9));
			w29.LeftAttach = ((uint)(4));
			w29.RightAttach = ((uint)(5));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblOrderAuthor = new global::Gamma.GtkWidgets.yLabel();
			this.ylblOrderAuthor.Name = "ylblOrderAuthor";
			this.ylblOrderAuthor.Xalign = 0F;
			this.ylblOrderAuthor.LabelProp = global::Mono.Unix.Catalog.GetString("\"Автор заказа\"");
			this.tableInfo.Add(this.ylblOrderAuthor);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblOrderAuthor]));
			w30.TopAttach = ((uint)(1));
			w30.BottomAttach = ((uint)(2));
			w30.LeftAttach = ((uint)(1));
			w30.RightAttach = ((uint)(2));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblStatus = new global::Gamma.GtkWidgets.yLabel();
			this.ylblStatus.Name = "ylblStatus";
			this.ylblStatus.Xalign = 1F;
			this.ylblStatus.LabelProp = global::Mono.Unix.Catalog.GetString("Статус:");
			this.tableInfo.Add(this.ylblStatus);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblStatus]));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableInfo.Gtk.Table+TableChild
			this.ylblStatusInfo = new global::Gamma.GtkWidgets.yLabel();
			this.ylblStatusInfo.Name = "ylblStatusInfo";
			this.ylblStatusInfo.Xalign = 0F;
			this.ylblStatusInfo.LabelProp = global::Mono.Unix.Catalog.GetString("Статус заказа");
			this.tableInfo.Add(this.ylblStatusInfo);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.tableInfo[this.ylblStatusInfo]));
			w32.LeftAttach = ((uint)(1));
			w32.RightAttach = ((uint)(2));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vboxInfo.Add(this.tableInfo);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vboxInfo[this.tableInfo]));
			w33.Position = 0;
			// Container child vboxInfo.Gtk.Box+BoxChild
			this.expanderCommentForLogistician = new global::Gtk.Expander(null);
			this.expanderCommentForLogistician.CanFocus = true;
			this.expanderCommentForLogistician.Name = "expanderCommentForLogistician";
			// Container child expanderCommentForLogistician.Gtk.Container+ContainerChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.ytextview2 = new global::Gamma.GtkWidgets.yTextView();
			this.ytextview2.CanFocus = true;
			this.ytextview2.Name = "ytextview2";
			this.GtkScrolledWindow1.Add(this.ytextview2);
			this.expanderCommentForLogistician.Add(this.GtkScrolledWindow1);
			this.GtkLblCommentForLogistician = new global::Gtk.Label();
			this.GtkLblCommentForLogistician.Name = "GtkLblCommentForLogistician";
			this.GtkLblCommentForLogistician.LabelProp = global::Mono.Unix.Catalog.GetString("Комментарий логисту");
			this.GtkLblCommentForLogistician.UseUnderline = true;
			this.expanderCommentForLogistician.LabelWidget = this.GtkLblCommentForLogistician;
			this.vboxInfo.Add(this.expanderCommentForLogistician);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vboxInfo[this.expanderCommentForLogistician]));
			w36.Position = 1;
			this.Add(this.vboxInfo);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
