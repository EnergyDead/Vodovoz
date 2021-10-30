
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Orders
{
	public partial class PromotionalSetView
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox1;

		private global::Gamma.GtkWidgets.yButton ybuttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.VSeparator vseparator1;

		private global::Gtk.HBox hbox16;

		private global::Gamma.GtkWidgets.yCheckButton yChkIsArchive;

		private global::Gtk.VSeparator vseparator2;

		private global::Gtk.Label lblCreationDateTitle;

		private global::Gamma.GtkWidgets.yLabel ylblCreationDate;

		private global::Gtk.Table table2;

		private global::Gtk.Label labelPromoSetName;

		private global::Gtk.Label lblName;

		private global::Gtk.VSeparator vseparator3;

		private global::Gtk.VSeparator vseparator4;

		private global::Vodovoz.Core.WidgetContainerView widgetcontainerview;

		private global::Gamma.GtkWidgets.yEntry yentryDiscountReason;

		private global::Gamma.GtkWidgets.yEntry yentryPromotionalSetName;

		private global::QS.Widgets.EnumMenuButton yEnumButtonAddAction;

		private global::Gtk.HBox hbox5;

		private global::Gamma.GtkWidgets.yCheckButton ycheckbCanEditNomCount;

		private global::Gtk.VSeparator vseparator5;

		private global::Gamma.GtkWidgets.yCheckButton ycheckCanBeAddedWithOtherPromoSets;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Frame frame1;

		private global::Gtk.Alignment GtkAlignment3;

		private global::Gtk.VBox vbxNomenclatures;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView yTreePromoSetItems;

		private global::Gtk.HBox hbox2;

		private global::Gamma.GtkWidgets.yButton ybtnAddNomenclature;

		private global::Gamma.GtkWidgets.yButton ybtnRemoveNomenclature;

		private global::Gtk.Label lblNomTblTitle;

		private global::Gtk.Frame frame2;

		private global::Gtk.Alignment GtkAlignment4;

		private global::Gtk.VBox vbxNomenclatures1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gamma.GtkWidgets.yTreeView yTreeActionsItems;

		private global::Gtk.HBox hbox4;

		private global::Gamma.GtkWidgets.yButton ybtnRemoveAction;

		private global::Gtk.Label lblNomTblTitle1;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Orders.PromotionalSetView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Orders.PromotionalSetView";
			// Container child Vodovoz.Views.Orders.PromotionalSetView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.ybuttonSave = new global::Gamma.GtkWidgets.yButton();
			this.ybuttonSave.CanFocus = true;
			this.ybuttonSave.Name = "ybuttonSave";
			this.ybuttonSave.UseUnderline = true;
			this.ybuttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-floppy", global::Gtk.IconSize.Menu);
			this.ybuttonSave.Image = w1;
			this.hbox1.Add(this.ybuttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.ybuttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox1.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator();
			this.vseparator1.Name = "vseparator1";
			this.hbox1.Add(this.vseparator1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vseparator1]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.hbox16 = new global::Gtk.HBox();
			this.hbox16.Name = "hbox16";
			this.hbox16.Spacing = 6;
			// Container child hbox16.Gtk.Box+BoxChild
			this.yChkIsArchive = new global::Gamma.GtkWidgets.yCheckButton();
			this.yChkIsArchive.CanFocus = true;
			this.yChkIsArchive.Name = "yChkIsArchive";
			this.yChkIsArchive.Label = global::Mono.Unix.Catalog.GetString("Архивный");
			this.yChkIsArchive.DrawIndicator = true;
			this.yChkIsArchive.UseUnderline = true;
			this.hbox16.Add(this.yChkIsArchive);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox16[this.yChkIsArchive]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox16.Gtk.Box+BoxChild
			this.vseparator2 = new global::Gtk.VSeparator();
			this.vseparator2.Name = "vseparator2";
			this.hbox16.Add(this.vseparator2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox16[this.vseparator2]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox16.Gtk.Box+BoxChild
			this.lblCreationDateTitle = new global::Gtk.Label();
			this.lblCreationDateTitle.Name = "lblCreationDateTitle";
			this.lblCreationDateTitle.LabelProp = global::Mono.Unix.Catalog.GetString("Создан:");
			this.hbox16.Add(this.lblCreationDateTitle);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox16[this.lblCreationDateTitle]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox16.Gtk.Box+BoxChild
			this.ylblCreationDate = new global::Gamma.GtkWidgets.yLabel();
			this.ylblCreationDate.Name = "ylblCreationDate";
			this.hbox16.Add(this.ylblCreationDate);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox16[this.ylblCreationDate]));
			w9.Position = 3;
			w9.Expand = false;
			w9.Fill = false;
			this.hbox1.Add(this.hbox16);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.hbox16]));
			w10.Position = 3;
			w10.Expand = false;
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w11.Position = 0;
			w11.Expand = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table2 = new global::Gtk.Table(((uint)(2)), ((uint)(4)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(6));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.labelPromoSetName = new global::Gtk.Label();
			this.labelPromoSetName.Name = "labelPromoSetName";
			this.labelPromoSetName.Xalign = 1F;
			this.labelPromoSetName.LabelProp = global::Mono.Unix.Catalog.GetString("Название набора:");
			this.table2.Add(this.labelPromoSetName);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table2[this.labelPromoSetName]));
			w12.TopAttach = ((uint)(1));
			w12.BottomAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.lblName = new global::Gtk.Label();
			this.lblName.Name = "lblName";
			this.lblName.Xalign = 1F;
			this.lblName.LabelProp = global::Mono.Unix.Catalog.GetString("Основание скидки:");
			this.table2.Add(this.lblName);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table2[this.lblName]));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.vseparator3 = new global::Gtk.VSeparator();
			this.vseparator3.Name = "vseparator3";
			this.table2.Add(this.vseparator3);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table2[this.vseparator3]));
			w14.LeftAttach = ((uint)(2));
			w14.RightAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.vseparator4 = new global::Gtk.VSeparator();
			this.vseparator4.Name = "vseparator4";
			this.table2.Add(this.vseparator4);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table2[this.vseparator4]));
			w15.TopAttach = ((uint)(1));
			w15.BottomAttach = ((uint)(2));
			w15.LeftAttach = ((uint)(2));
			w15.RightAttach = ((uint)(3));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.widgetcontainerview = new global::Vodovoz.Core.WidgetContainerView();
			this.widgetcontainerview.Events = ((global::Gdk.EventMask)(256));
			this.widgetcontainerview.Name = "widgetcontainerview";
			this.table2.Add(this.widgetcontainerview);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.table2[this.widgetcontainerview]));
			w16.TopAttach = ((uint)(1));
			w16.BottomAttach = ((uint)(2));
			w16.LeftAttach = ((uint)(3));
			w16.RightAttach = ((uint)(4));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.yentryDiscountReason = new global::Gamma.GtkWidgets.yEntry();
			this.yentryDiscountReason.CanFocus = true;
			this.yentryDiscountReason.Name = "yentryDiscountReason";
			this.yentryDiscountReason.IsEditable = true;
			this.yentryDiscountReason.InvisibleChar = '•';
			this.table2.Add(this.yentryDiscountReason);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table2[this.yentryDiscountReason]));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.yentryPromotionalSetName = new global::Gamma.GtkWidgets.yEntry();
			this.yentryPromotionalSetName.CanFocus = true;
			this.yentryPromotionalSetName.Name = "yentryPromotionalSetName";
			this.yentryPromotionalSetName.IsEditable = true;
			this.yentryPromotionalSetName.InvisibleChar = '•';
			this.table2.Add(this.yentryPromotionalSetName);
			global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table2[this.yentryPromotionalSetName]));
			w18.TopAttach = ((uint)(1));
			w18.BottomAttach = ((uint)(2));
			w18.LeftAttach = ((uint)(1));
			w18.RightAttach = ((uint)(2));
			w18.XOptions = ((global::Gtk.AttachOptions)(4));
			w18.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.yEnumButtonAddAction = new global::QS.Widgets.EnumMenuButton();
			this.yEnumButtonAddAction.CanFocus = true;
			this.yEnumButtonAddAction.Name = "yEnumButtonAddAction";
			this.yEnumButtonAddAction.UseUnderline = true;
			this.yEnumButtonAddAction.UseMarkup = false;
			this.yEnumButtonAddAction.LabelXAlign = 0F;
			this.yEnumButtonAddAction.Label = global::Mono.Unix.Catalog.GetString("Добавить действие");
			global::Gtk.Image w19 = new global::Gtk.Image();
			w19.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-add", global::Gtk.IconSize.Menu);
			this.yEnumButtonAddAction.Image = w19;
			this.table2.Add(this.yEnumButtonAddAction);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table2[this.yEnumButtonAddAction]));
			w20.LeftAttach = ((uint)(3));
			w20.RightAttach = ((uint)(4));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add(this.table2);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.table2]));
			w21.Position = 1;
			w21.Expand = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.ycheckbCanEditNomCount = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckbCanEditNomCount.CanFocus = true;
			this.ycheckbCanEditNomCount.Name = "ycheckbCanEditNomCount";
			this.ycheckbCanEditNomCount.Label = global::Mono.Unix.Catalog.GetString("Можно менять количество номенклатур в заказе");
			this.ycheckbCanEditNomCount.DrawIndicator = true;
			this.ycheckbCanEditNomCount.UseUnderline = true;
			this.hbox5.Add(this.ycheckbCanEditNomCount);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.ycheckbCanEditNomCount]));
			w22.Position = 0;
			w22.Expand = false;
			w22.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.vseparator5 = new global::Gtk.VSeparator();
			this.vseparator5.Name = "vseparator5";
			this.hbox5.Add(this.vseparator5);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.vseparator5]));
			w23.Position = 1;
			w23.Expand = false;
			w23.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.ycheckCanBeAddedWithOtherPromoSets = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckCanBeAddedWithOtherPromoSets.CanFocus = true;
			this.ycheckCanBeAddedWithOtherPromoSets.Name = "ycheckCanBeAddedWithOtherPromoSets";
			this.ycheckCanBeAddedWithOtherPromoSets.Label = global::Mono.Unix.Catalog.GetString("Можно добавить вместе с другими промонаборами");
			this.ycheckCanBeAddedWithOtherPromoSets.DrawIndicator = true;
			this.ycheckCanBeAddedWithOtherPromoSets.UseUnderline = true;
			this.hbox5.Add(this.ycheckCanBeAddedWithOtherPromoSets);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.ycheckCanBeAddedWithOtherPromoSets]));
			w24.Position = 2;
			w24.Expand = false;
			w24.Fill = false;
			this.vbox2.Add(this.hbox5);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox5]));
			w25.Position = 2;
			w25.Expand = false;
			w25.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment3 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment3.Name = "GtkAlignment3";
			this.GtkAlignment3.LeftPadding = ((uint)(12));
			// Container child GtkAlignment3.Gtk.Container+ContainerChild
			this.vbxNomenclatures = new global::Gtk.VBox();
			this.vbxNomenclatures.Name = "vbxNomenclatures";
			this.vbxNomenclatures.Spacing = 6;
			// Container child vbxNomenclatures.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.yTreePromoSetItems = new global::Gamma.GtkWidgets.yTreeView();
			this.yTreePromoSetItems.CanFocus = true;
			this.yTreePromoSetItems.Name = "yTreePromoSetItems";
			this.GtkScrolledWindow.Add(this.yTreePromoSetItems);
			this.vbxNomenclatures.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbxNomenclatures[this.GtkScrolledWindow]));
			w27.Position = 0;
			// Container child vbxNomenclatures.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.ybtnAddNomenclature = new global::Gamma.GtkWidgets.yButton();
			this.ybtnAddNomenclature.CanFocus = true;
			this.ybtnAddNomenclature.Name = "ybtnAddNomenclature";
			this.ybtnAddNomenclature.UseUnderline = true;
			this.ybtnAddNomenclature.Label = global::Mono.Unix.Catalog.GetString("Добавить");
			this.hbox2.Add(this.ybtnAddNomenclature);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.ybtnAddNomenclature]));
			w28.Position = 0;
			w28.Expand = false;
			w28.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.ybtnRemoveNomenclature = new global::Gamma.GtkWidgets.yButton();
			this.ybtnRemoveNomenclature.CanFocus = true;
			this.ybtnRemoveNomenclature.Name = "ybtnRemoveNomenclature";
			this.ybtnRemoveNomenclature.UseUnderline = true;
			this.ybtnRemoveNomenclature.Label = global::Mono.Unix.Catalog.GetString("  Удалить  ");
			this.hbox2.Add(this.ybtnRemoveNomenclature);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.ybtnRemoveNomenclature]));
			w29.Position = 1;
			w29.Expand = false;
			w29.Fill = false;
			this.vbxNomenclatures.Add(this.hbox2);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbxNomenclatures[this.hbox2]));
			w30.Position = 1;
			w30.Expand = false;
			w30.Fill = false;
			this.GtkAlignment3.Add(this.vbxNomenclatures);
			this.frame1.Add(this.GtkAlignment3);
			this.lblNomTblTitle = new global::Gtk.Label();
			this.lblNomTblTitle.Name = "lblNomTblTitle";
			this.lblNomTblTitle.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Номенклатуры со скидкой:</b>");
			this.lblNomTblTitle.UseMarkup = true;
			this.frame1.LabelWidget = this.lblNomTblTitle;
			this.hbox3.Add(this.frame1);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.frame1]));
			w33.Position = 0;
			// Container child hbox3.Gtk.Box+BoxChild
			this.frame2 = new global::Gtk.Frame();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment4 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment4.Name = "GtkAlignment4";
			this.GtkAlignment4.LeftPadding = ((uint)(12));
			// Container child GtkAlignment4.Gtk.Container+ContainerChild
			this.vbxNomenclatures1 = new global::Gtk.VBox();
			this.vbxNomenclatures1.Name = "vbxNomenclatures1";
			this.vbxNomenclatures1.Spacing = 6;
			// Container child vbxNomenclatures1.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.yTreeActionsItems = new global::Gamma.GtkWidgets.yTreeView();
			this.yTreeActionsItems.CanFocus = true;
			this.yTreeActionsItems.Name = "yTreeActionsItems";
			this.GtkScrolledWindow1.Add(this.yTreeActionsItems);
			this.vbxNomenclatures1.Add(this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vbxNomenclatures1[this.GtkScrolledWindow1]));
			w35.Position = 0;
			// Container child vbxNomenclatures1.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.ybtnRemoveAction = new global::Gamma.GtkWidgets.yButton();
			this.ybtnRemoveAction.CanFocus = true;
			this.ybtnRemoveAction.Name = "ybtnRemoveAction";
			this.ybtnRemoveAction.UseUnderline = true;
			this.ybtnRemoveAction.Label = global::Mono.Unix.Catalog.GetString("  Удалить  ");
			this.hbox4.Add(this.ybtnRemoveAction);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.ybtnRemoveAction]));
			w36.Position = 0;
			w36.Expand = false;
			w36.Fill = false;
			this.vbxNomenclatures1.Add(this.hbox4);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.vbxNomenclatures1[this.hbox4]));
			w37.Position = 1;
			w37.Expand = false;
			w37.Fill = false;
			this.GtkAlignment4.Add(this.vbxNomenclatures1);
			this.frame2.Add(this.GtkAlignment4);
			this.lblNomTblTitle1 = new global::Gtk.Label();
			this.lblNomTblTitle1.Name = "lblNomTblTitle1";
			this.lblNomTblTitle1.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Спец. действия:</b>");
			this.lblNomTblTitle1.UseMarkup = true;
			this.frame2.LabelWidget = this.lblNomTblTitle1;
			this.hbox3.Add(this.frame2);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.frame2]));
			w40.Position = 1;
			this.vbox2.Add(this.hbox3);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox3]));
			w41.PackType = ((global::Gtk.PackType)(1));
			w41.Position = 3;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
