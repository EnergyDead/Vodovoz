
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Filters.GtkViews
{
	public partial class OrderFilterView
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Table table1;

		private global::QS.Widgets.GtkUI.DateRangePicker dateperiodOrders;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry entryCounterparty;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry entryDeliveryPoint;

		private global::Gamma.Widgets.yEnumComboBox enumcomboPaymentType;

		private global::Gamma.Widgets.yEnumComboBox enumcomboStatus;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label5;

		private global::Gtk.Label label7;

		private global::QS.Widgets.GtkUI.SpecialListComboBox speciallistCmbOrganisations;

		private global::QS.Widgets.GtkUI.SpecialListComboBox speciallistCmbPaymentsFrom;

		private global::Gamma.GtkWidgets.yCheckButton ycheckSortDeliveryDate;

		private global::Gamma.Widgets.yEnumComboBox yenumcomboboxDateType;

		private global::Gamma.Widgets.yEnumComboBox yenumcomboboxPaymentOrder;

		private global::Gamma.Widgets.yEnumComboBox yenumcomboboxViewTypes;

		private global::Gamma.Widgets.yEnumComboBox yenumСmbboxOrderPaymentStatus;

		private global::Gamma.GtkWidgets.yLabel ylabel1;

		private global::Gamma.GtkWidgets.yLabel ylabel2;

		private global::Gamma.GtkWidgets.yLabel ylblOrganisation;

		private global::Gamma.GtkWidgets.yLabel ylblPaymentFrom;

		private global::Gamma.Widgets.ySpecComboBox ySpecCmbGeographicGroup;

		private global::Gtk.HBox hbox5;

		private global::Gamma.GtkWidgets.yCheckButton ycheckOnlySelfdelivery;

		private global::Gamma.GtkWidgets.yCheckButton ycheckWithoutSelfdelivery;

		private global::Gamma.GtkWidgets.yCheckButton ycheckOnlyServices;

		private global::Gamma.GtkWidgets.yCheckButton ycheckHideServices;

		private global::Gamma.GtkWidgets.yCheckButton ycheckLessThreeHours;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Filters.GtkViews.OrderFilterView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Filters.GtkViews.OrderFilterView";
			// Container child Vodovoz.Filters.GtkViews.OrderFilterView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(5)), ((uint)(7)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.dateperiodOrders = new global::QS.Widgets.GtkUI.DateRangePicker();
			this.dateperiodOrders.Events = ((global::Gdk.EventMask)(256));
			this.dateperiodOrders.Name = "dateperiodOrders";
			this.dateperiodOrders.StartDate = new global::System.DateTime(0);
			this.dateperiodOrders.EndDate = new global::System.DateTime(0);
			this.table1.Add(this.dateperiodOrders);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.dateperiodOrders]));
			w1.LeftAttach = ((uint)(5));
			w1.RightAttach = ((uint)(6));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryCounterparty = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.entryCounterparty.Events = ((global::Gdk.EventMask)(256));
			this.entryCounterparty.Name = "entryCounterparty";
			this.entryCounterparty.CanEditReference = true;
			this.table1.Add(this.entryCounterparty);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.entryCounterparty]));
			w2.TopAttach = ((uint)(3));
			w2.BottomAttach = ((uint)(4));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entryDeliveryPoint = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.entryDeliveryPoint.Events = ((global::Gdk.EventMask)(256));
			this.entryDeliveryPoint.Name = "entryDeliveryPoint";
			this.entryDeliveryPoint.CanEditReference = true;
			this.table1.Add(this.entryDeliveryPoint);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.entryDeliveryPoint]));
			w3.TopAttach = ((uint)(3));
			w3.BottomAttach = ((uint)(4));
			w3.LeftAttach = ((uint)(3));
			w3.RightAttach = ((uint)(6));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.enumcomboPaymentType = new global::Gamma.Widgets.yEnumComboBox();
			this.enumcomboPaymentType.Name = "enumcomboPaymentType";
			this.enumcomboPaymentType.ShowSpecialStateAll = true;
			this.enumcomboPaymentType.ShowSpecialStateNot = false;
			this.enumcomboPaymentType.UseShortTitle = false;
			this.enumcomboPaymentType.DefaultFirst = false;
			this.table1.Add(this.enumcomboPaymentType);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.enumcomboPaymentType]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.LeftAttach = ((uint)(3));
			w4.RightAttach = ((uint)(4));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.enumcomboStatus = new global::Gamma.Widgets.yEnumComboBox();
			this.enumcomboStatus.Name = "enumcomboStatus";
			this.enumcomboStatus.ShowSpecialStateAll = true;
			this.enumcomboStatus.ShowSpecialStateNot = false;
			this.enumcomboStatus.UseShortTitle = false;
			this.enumcomboStatus.DefaultFirst = false;
			this.table1.Add(this.enumcomboStatus);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.enumcomboStatus]));
			w5.TopAttach = ((uint)(1));
			w5.BottomAttach = ((uint)(2));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Статус:");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Контрагент:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w7.TopAttach = ((uint)(3));
			w7.BottomAttach = ((uint)(4));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Точка доставки:");
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w8.TopAttach = ((uint)(3));
			w8.BottomAttach = ((uint)(4));
			w8.LeftAttach = ((uint)(2));
			w8.RightAttach = ((uint)(3));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Тип оплаты:");
			this.table1.Add(this.label5);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.label5]));
			w9.TopAttach = ((uint)(1));
			w9.BottomAttach = ((uint)(2));
			w9.LeftAttach = ((uint)(2));
			w9.RightAttach = ((uint)(3));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Район города:");
			this.table1.Add(this.label7);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.label7]));
			w10.TopAttach = ((uint)(4));
			w10.BottomAttach = ((uint)(5));
			w10.LeftAttach = ((uint)(2));
			w10.RightAttach = ((uint)(3));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.speciallistCmbOrganisations = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.speciallistCmbOrganisations.Name = "speciallistCmbOrganisations";
			this.speciallistCmbOrganisations.AddIfNotExist = false;
			this.speciallistCmbOrganisations.DefaultFirst = false;
			this.speciallistCmbOrganisations.ShowSpecialStateAll = true;
			this.speciallistCmbOrganisations.ShowSpecialStateNot = false;
			this.table1.Add(this.speciallistCmbOrganisations);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.speciallistCmbOrganisations]));
			w11.TopAttach = ((uint)(2));
			w11.BottomAttach = ((uint)(3));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.speciallistCmbPaymentsFrom = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.speciallistCmbPaymentsFrom.Name = "speciallistCmbPaymentsFrom";
			this.speciallistCmbPaymentsFrom.AddIfNotExist = false;
			this.speciallistCmbPaymentsFrom.DefaultFirst = false;
			this.speciallistCmbPaymentsFrom.ShowSpecialStateAll = true;
			this.speciallistCmbPaymentsFrom.ShowSpecialStateNot = false;
			this.table1.Add(this.speciallistCmbPaymentsFrom);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.speciallistCmbPaymentsFrom]));
			w12.TopAttach = ((uint)(2));
			w12.BottomAttach = ((uint)(3));
			w12.LeftAttach = ((uint)(3));
			w12.RightAttach = ((uint)(4));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckSortDeliveryDate = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckSortDeliveryDate.CanFocus = true;
			this.ycheckSortDeliveryDate.Name = "ycheckSortDeliveryDate";
			this.ycheckSortDeliveryDate.Label = global::Mono.Unix.Catalog.GetString("По дате доставки");
			this.ycheckSortDeliveryDate.DrawIndicator = true;
			this.ycheckSortDeliveryDate.UseUnderline = true;
			this.table1.Add(this.ycheckSortDeliveryDate);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.ycheckSortDeliveryDate]));
			w13.TopAttach = ((uint)(4));
			w13.BottomAttach = ((uint)(5));
			w13.LeftAttach = ((uint)(5));
			w13.RightAttach = ((uint)(6));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yenumcomboboxDateType = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumcomboboxDateType.Name = "yenumcomboboxDateType";
			this.yenumcomboboxDateType.ShowSpecialStateAll = false;
			this.yenumcomboboxDateType.ShowSpecialStateNot = false;
			this.yenumcomboboxDateType.UseShortTitle = false;
			this.yenumcomboboxDateType.DefaultFirst = false;
			this.table1.Add(this.yenumcomboboxDateType);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.yenumcomboboxDateType]));
			w14.LeftAttach = ((uint)(4));
			w14.RightAttach = ((uint)(5));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yenumcomboboxPaymentOrder = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumcomboboxPaymentOrder.Name = "yenumcomboboxPaymentOrder";
			this.yenumcomboboxPaymentOrder.ShowSpecialStateAll = true;
			this.yenumcomboboxPaymentOrder.ShowSpecialStateNot = false;
			this.yenumcomboboxPaymentOrder.UseShortTitle = false;
			this.yenumcomboboxPaymentOrder.DefaultFirst = false;
			this.table1.Add(this.yenumcomboboxPaymentOrder);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1[this.yenumcomboboxPaymentOrder]));
			w15.TopAttach = ((uint)(1));
			w15.BottomAttach = ((uint)(2));
			w15.LeftAttach = ((uint)(5));
			w15.RightAttach = ((uint)(6));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yenumcomboboxViewTypes = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumcomboboxViewTypes.Name = "yenumcomboboxViewTypes";
			this.yenumcomboboxViewTypes.ShowSpecialStateAll = false;
			this.yenumcomboboxViewTypes.ShowSpecialStateNot = false;
			this.yenumcomboboxViewTypes.UseShortTitle = false;
			this.yenumcomboboxViewTypes.DefaultFirst = false;
			this.table1.Add(this.yenumcomboboxViewTypes);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table1[this.yenumcomboboxViewTypes]));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yenumСmbboxOrderPaymentStatus = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumСmbboxOrderPaymentStatus.Name = "yenumСmbboxOrderPaymentStatus";
			this.yenumСmbboxOrderPaymentStatus.ShowSpecialStateAll = true;
			this.yenumСmbboxOrderPaymentStatus.ShowSpecialStateNot = false;
			this.yenumСmbboxOrderPaymentStatus.UseShortTitle = false;
			this.yenumСmbboxOrderPaymentStatus.DefaultFirst = false;
			this.table1.Add(this.yenumСmbboxOrderPaymentStatus);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table1[this.yenumСmbboxOrderPaymentStatus]));
			w17.LeftAttach = ((uint)(3));
			w17.RightAttach = ((uint)(4));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabel1 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel1.Name = "ylabel1";
			this.ylabel1.LabelProp = global::Mono.Unix.Catalog.GetString("Отображать:");
			this.table1.Add(this.ylabel1);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabel1]));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabel2 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel2.Name = "ylabel2";
			this.ylabel2.Xalign = 1F;
			this.ylabel2.LabelProp = global::Mono.Unix.Catalog.GetString("Статус оплаты: ");
			this.table1.Add(this.ylabel2);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabel2]));
			w19.LeftAttach = ((uint)(2));
			w19.RightAttach = ((uint)(3));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylblOrganisation = new global::Gamma.GtkWidgets.yLabel();
			this.ylblOrganisation.Name = "ylblOrganisation";
			this.ylblOrganisation.Xalign = 1F;
			this.ylblOrganisation.LabelProp = global::Mono.Unix.Catalog.GetString("Организация:");
			this.table1.Add(this.ylblOrganisation);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table1[this.ylblOrganisation]));
			w20.TopAttach = ((uint)(2));
			w20.BottomAttach = ((uint)(3));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylblPaymentFrom = new global::Gamma.GtkWidgets.yLabel();
			this.ylblPaymentFrom.Name = "ylblPaymentFrom";
			this.ylblPaymentFrom.Xalign = 1F;
			this.ylblPaymentFrom.LabelProp = global::Mono.Unix.Catalog.GetString("Откуда оплата:");
			this.table1.Add(this.ylblPaymentFrom);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.table1[this.ylblPaymentFrom]));
			w21.TopAttach = ((uint)(2));
			w21.BottomAttach = ((uint)(3));
			w21.LeftAttach = ((uint)(2));
			w21.RightAttach = ((uint)(3));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ySpecCmbGeographicGroup = new global::Gamma.Widgets.ySpecComboBox();
			this.ySpecCmbGeographicGroup.Name = "ySpecCmbGeographicGroup";
			this.ySpecCmbGeographicGroup.AddIfNotExist = false;
			this.ySpecCmbGeographicGroup.DefaultFirst = false;
			this.ySpecCmbGeographicGroup.ShowSpecialStateAll = true;
			this.ySpecCmbGeographicGroup.ShowSpecialStateNot = false;
			this.table1.Add(this.ySpecCmbGeographicGroup);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.table1[this.ySpecCmbGeographicGroup]));
			w22.TopAttach = ((uint)(4));
			w22.BottomAttach = ((uint)(5));
			w22.LeftAttach = ((uint)(3));
			w22.RightAttach = ((uint)(4));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add(this.table1);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.table1]));
			w23.Position = 0;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.ycheckOnlySelfdelivery = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckOnlySelfdelivery.CanFocus = true;
			this.ycheckOnlySelfdelivery.Name = "ycheckOnlySelfdelivery";
			this.ycheckOnlySelfdelivery.Label = global::Mono.Unix.Catalog.GetString("Только самовывоз");
			this.ycheckOnlySelfdelivery.DrawIndicator = true;
			this.ycheckOnlySelfdelivery.UseUnderline = true;
			this.hbox5.Add(this.ycheckOnlySelfdelivery);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.ycheckOnlySelfdelivery]));
			w24.Position = 0;
			w24.Expand = false;
			w24.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.ycheckWithoutSelfdelivery = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckWithoutSelfdelivery.CanFocus = true;
			this.ycheckWithoutSelfdelivery.Name = "ycheckWithoutSelfdelivery";
			this.ycheckWithoutSelfdelivery.Label = global::Mono.Unix.Catalog.GetString("Скрыть самовывозы");
			this.ycheckWithoutSelfdelivery.DrawIndicator = true;
			this.ycheckWithoutSelfdelivery.UseUnderline = true;
			this.hbox5.Add(this.ycheckWithoutSelfdelivery);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.ycheckWithoutSelfdelivery]));
			w25.Position = 1;
			w25.Expand = false;
			w25.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.ycheckOnlyServices = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckOnlyServices.CanFocus = true;
			this.ycheckOnlyServices.Name = "ycheckOnlyServices";
			this.ycheckOnlyServices.Label = global::Mono.Unix.Catalog.GetString("Только выезд мастера");
			this.ycheckOnlyServices.DrawIndicator = true;
			this.ycheckOnlyServices.UseUnderline = true;
			this.hbox5.Add(this.ycheckOnlyServices);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.ycheckOnlyServices]));
			w26.Position = 2;
			w26.Expand = false;
			w26.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.ycheckHideServices = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckHideServices.CanFocus = true;
			this.ycheckHideServices.Name = "ycheckHideServices";
			this.ycheckHideServices.Label = global::Mono.Unix.Catalog.GetString("Скрыть выезд мастера");
			this.ycheckHideServices.DrawIndicator = true;
			this.ycheckHideServices.UseUnderline = true;
			this.hbox5.Add(this.ycheckHideServices);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.ycheckHideServices]));
			w27.Position = 3;
			w27.Expand = false;
			w27.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.ycheckLessThreeHours = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckLessThreeHours.CanFocus = true;
			this.ycheckLessThreeHours.Name = "ycheckLessThreeHours";
			this.ycheckLessThreeHours.Label = global::Mono.Unix.Catalog.GetString("Менее 3-х часов");
			this.ycheckLessThreeHours.DrawIndicator = true;
			this.ycheckLessThreeHours.UseUnderline = true;
			this.hbox5.Add(this.ycheckLessThreeHours);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.ycheckLessThreeHours]));
			w28.Position = 4;
			w28.Expand = false;
			w28.Fill = false;
			this.vbox2.Add(this.hbox5);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox5]));
			w29.Position = 1;
			w29.Expand = false;
			w29.Fill = false;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
