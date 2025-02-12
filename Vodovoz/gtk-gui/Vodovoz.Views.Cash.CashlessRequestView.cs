
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Cash
{
	public partial class CashlessRequestView
	{
		private global::Gtk.VBox vboxDialog;

		private global::Gtk.HBox hboxDialogHeader;

		private global::Gamma.GtkWidgets.yButton buttonSave;

		private global::Gamma.GtkWidgets.yButton buttonCancel;

		private global::Gamma.GtkWidgets.yLabel labelRoleTitle;

		private global::Gamma.Widgets.yListComboBox comboRoleChooser;

		private global::Gamma.GtkWidgets.yLabel labelStatusTitle;

		private global::Gamma.GtkWidgets.yLabel labelStatus;

		private global::Gtk.ScrolledWindow scrolledMain;

		private global::Gtk.Table tableMain;

		private global::Gtk.Alignment alignmentFiles;

		private global::Vodovoz.Views.Cash.CashlessRequestFilesView filesView;

		private global::Gamma.GtkWidgets.yCheckButton checkNotToReconcile;

		private global::QS.Widgets.GtkUI.SpecialListComboBox comboOrganisation;

		private global::Gamma.GtkWidgets.yEventBox eventBoxCancelReason;

		private global::Gtk.ScrolledWindow scrollCancelReason;

		private global::Gamma.GtkWidgets.yTextView entryCancelReason;

		private global::Gamma.GtkWidgets.yEventBox eventBoxOrganisationSeparator;

		private global::Gtk.HSeparator hseparator1;

		private global::Gamma.GtkWidgets.yEventBox eventBoxReasonsSeparator;

		private global::Gtk.HSeparator hseparator2;

		private global::Gamma.GtkWidgets.yEventBox eventBoxWhySentToReapproval;

		private global::Gtk.ScrolledWindow scrollWhySentToReapproval;

		private global::Gamma.GtkWidgets.yTextView entryWhySentToReapproval;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry evmeAuthor;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry evmeCounterparty;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry evmeExpenceCategory;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry evmeSubdivision;

		private global::Gtk.HBox hbox5;

		private global::Gtk.VBox vbox3;

		private global::Gamma.GtkWidgets.yButton btnCancel;

		private global::Gamma.GtkWidgets.yButton btnReapprove;

		private global::Gtk.HBox hbox6;

		private global::Gtk.VBox vbox2;

		private global::Gamma.GtkWidgets.yButton buttonPayout;

		private global::Gamma.GtkWidgets.yButton btnConveyForPayout;

		private global::Gamma.GtkWidgets.yButton btnAccept;

		private global::Gamma.GtkWidgets.yButton btnApprove;

		private global::Gtk.HSeparator hseparator3;

		private global::Gtk.Label labelAuthor;

		private global::Gamma.GtkWidgets.yLabel labelBasis;

		private global::Gamma.GtkWidgets.yLabel labelCancelReason;

		private global::Gamma.GtkWidgets.yLabel labelComboOrganization;

		private global::Gamma.GtkWidgets.yLabel labelCounterparty;

		private global::Gamma.GtkWidgets.yLabel labelExpenceCategory;

		private global::Gamma.GtkWidgets.yLabel labelExplanation;

		private global::Gamma.GtkWidgets.yLabel labelFiles;

		private global::Gtk.Label labelSubdivision;

		private global::Gamma.GtkWidgets.yLabel labelSum;

		private global::Gamma.GtkWidgets.yLabel labelWhySentToReapproval;

		private global::Gtk.ScrolledWindow scrollBasis;

		private global::Gamma.GtkWidgets.yTextView entryBasis;

		private global::Gtk.ScrolledWindow scrollExplanation;

		private global::Gamma.GtkWidgets.yTextView entryExplanation;

		private global::Gamma.GtkWidgets.yHBox yhboxSum;

		private global::Gamma.GtkWidgets.ySpinButton spinSum;

		private global::QSProjectsLib.CurrencyLabel currencylabel1;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Cash.CashlessRequestView
			global::Stetic.BinContainer.Attach(this);
			this.WidthRequest = 450;
			this.Name = "Vodovoz.Views.Cash.CashlessRequestView";
			// Container child Vodovoz.Views.Cash.CashlessRequestView.Gtk.Container+ContainerChild
			this.vboxDialog = new global::Gtk.VBox();
			this.vboxDialog.Name = "vboxDialog";
			this.vboxDialog.Spacing = 6;
			// Container child vboxDialog.Gtk.Box+BoxChild
			this.hboxDialogHeader = new global::Gtk.HBox();
			this.hboxDialogHeader.Name = "hboxDialogHeader";
			this.hboxDialogHeader.Spacing = 6;
			// Container child hboxDialogHeader.Gtk.Box+BoxChild
			this.buttonSave = new global::Gamma.GtkWidgets.yButton();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hboxDialogHeader.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hboxDialogHeader[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hboxDialogHeader.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gamma.GtkWidgets.yButton();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hboxDialogHeader.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hboxDialogHeader[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hboxDialogHeader.Gtk.Box+BoxChild
			this.labelRoleTitle = new global::Gamma.GtkWidgets.yLabel();
			this.labelRoleTitle.Name = "labelRoleTitle";
			this.labelRoleTitle.LabelProp = global::Mono.Unix.Catalog.GetString("Роль:");
			this.hboxDialogHeader.Add(this.labelRoleTitle);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hboxDialogHeader[this.labelRoleTitle]));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hboxDialogHeader.Gtk.Box+BoxChild
			this.comboRoleChooser = new global::Gamma.Widgets.yListComboBox();
			this.comboRoleChooser.Name = "comboRoleChooser";
			this.comboRoleChooser.AddIfNotExist = false;
			this.comboRoleChooser.DefaultFirst = false;
			this.hboxDialogHeader.Add(this.comboRoleChooser);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hboxDialogHeader[this.comboRoleChooser]));
			w6.Position = 3;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hboxDialogHeader.Gtk.Box+BoxChild
			this.labelStatusTitle = new global::Gamma.GtkWidgets.yLabel();
			this.labelStatusTitle.Name = "labelStatusTitle";
			this.labelStatusTitle.LabelProp = global::Mono.Unix.Catalog.GetString("Статус заявки:");
			this.hboxDialogHeader.Add(this.labelStatusTitle);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hboxDialogHeader[this.labelStatusTitle]));
			w7.Position = 4;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hboxDialogHeader.Gtk.Box+BoxChild
			this.labelStatus = new global::Gamma.GtkWidgets.yLabel();
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.LabelProp = global::Mono.Unix.Catalog.GetString(".");
			this.hboxDialogHeader.Add(this.labelStatus);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hboxDialogHeader[this.labelStatus]));
			w8.Position = 5;
			w8.Expand = false;
			w8.Fill = false;
			this.vboxDialog.Add(this.hboxDialogHeader);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vboxDialog[this.hboxDialogHeader]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vboxDialog.Gtk.Box+BoxChild
			this.scrolledMain = new global::Gtk.ScrolledWindow();
			this.scrolledMain.CanFocus = true;
			this.scrolledMain.Name = "scrolledMain";
			this.scrolledMain.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledMain.Gtk.Container+ContainerChild
			global::Gtk.Viewport w10 = new global::Gtk.Viewport();
			w10.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.tableMain = new global::Gtk.Table(((uint)(16)), ((uint)(2)), false);
			this.tableMain.Name = "tableMain";
			this.tableMain.RowSpacing = ((uint)(6));
			this.tableMain.ColumnSpacing = ((uint)(6));
			this.tableMain.BorderWidth = ((uint)(10));
			// Container child tableMain.Gtk.Table+TableChild
			this.alignmentFiles = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
			this.alignmentFiles.WidthRequest = 400;
			this.alignmentFiles.HeightRequest = 100;
			this.alignmentFiles.Name = "alignmentFiles";
			// Container child alignmentFiles.Gtk.Container+ContainerChild
			this.filesView = new global::Vodovoz.Views.Cash.CashlessRequestFilesView();
			this.filesView.Events = ((global::Gdk.EventMask)(256));
			this.filesView.Name = "filesView";
			this.alignmentFiles.Add(this.filesView);
			this.tableMain.Add(this.alignmentFiles);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.tableMain[this.alignmentFiles]));
			w12.TopAttach = ((uint)(4));
			w12.BottomAttach = ((uint)(5));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(0));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.checkNotToReconcile = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkNotToReconcile.WidthRequest = 400;
			this.checkNotToReconcile.CanFocus = true;
			this.checkNotToReconcile.Name = "checkNotToReconcile";
			this.checkNotToReconcile.Label = global::Mono.Unix.Catalog.GetString("Утвердить возможность не пересогласовывать оплаты");
			this.checkNotToReconcile.DrawIndicator = true;
			this.checkNotToReconcile.UseUnderline = true;
			this.checkNotToReconcile.FocusOnClick = false;
			this.checkNotToReconcile.Xalign = 0F;
			this.checkNotToReconcile.Yalign = 0F;
			this.tableMain.Add(this.checkNotToReconcile);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.tableMain[this.checkNotToReconcile]));
			w13.TopAttach = ((uint)(7));
			w13.BottomAttach = ((uint)(8));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(0));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.comboOrganisation = new global::QS.Widgets.GtkUI.SpecialListComboBox();
			this.comboOrganisation.WidthRequest = 400;
			this.comboOrganisation.Name = "comboOrganisation";
			this.comboOrganisation.AddIfNotExist = false;
			this.comboOrganisation.DefaultFirst = false;
			this.comboOrganisation.ShowSpecialStateAll = false;
			this.comboOrganisation.ShowSpecialStateNot = false;
			this.tableMain.Add(this.comboOrganisation);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.tableMain[this.comboOrganisation]));
			w14.TopAttach = ((uint)(9));
			w14.BottomAttach = ((uint)(10));
			w14.LeftAttach = ((uint)(1));
			w14.RightAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(0));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.eventBoxCancelReason = new global::Gamma.GtkWidgets.yEventBox();
			this.eventBoxCancelReason.Name = "eventBoxCancelReason";
			// Container child eventBoxCancelReason.Gtk.Container+ContainerChild
			this.scrollCancelReason = new global::Gtk.ScrolledWindow();
			this.scrollCancelReason.WidthRequest = 400;
			this.scrollCancelReason.HeightRequest = 65;
			this.scrollCancelReason.Name = "scrollCancelReason";
			this.scrollCancelReason.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrollCancelReason.Gtk.Container+ContainerChild
			this.entryCancelReason = new global::Gamma.GtkWidgets.yTextView();
			this.entryCancelReason.CanFocus = true;
			this.entryCancelReason.Name = "entryCancelReason";
			this.entryCancelReason.WrapMode = ((global::Gtk.WrapMode)(3));
			this.scrollCancelReason.Add(this.entryCancelReason);
			this.eventBoxCancelReason.Add(this.scrollCancelReason);
			this.tableMain.Add(this.eventBoxCancelReason);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.tableMain[this.eventBoxCancelReason]));
			w17.TopAttach = ((uint)(13));
			w17.BottomAttach = ((uint)(14));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.eventBoxOrganisationSeparator = new global::Gamma.GtkWidgets.yEventBox();
			this.eventBoxOrganisationSeparator.Name = "eventBoxOrganisationSeparator";
			// Container child eventBoxOrganisationSeparator.Gtk.Container+ContainerChild
			this.hseparator1 = new global::Gtk.HSeparator();
			this.hseparator1.Name = "hseparator1";
			this.eventBoxOrganisationSeparator.Add(this.hseparator1);
			this.tableMain.Add(this.eventBoxOrganisationSeparator);
			global::Gtk.Table.TableChild w19 = ((global::Gtk.Table.TableChild)(this.tableMain[this.eventBoxOrganisationSeparator]));
			w19.TopAttach = ((uint)(8));
			w19.BottomAttach = ((uint)(9));
			w19.RightAttach = ((uint)(2));
			w19.XOptions = ((global::Gtk.AttachOptions)(4));
			w19.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.eventBoxReasonsSeparator = new global::Gamma.GtkWidgets.yEventBox();
			this.eventBoxReasonsSeparator.Name = "eventBoxReasonsSeparator";
			// Container child eventBoxReasonsSeparator.Gtk.Container+ContainerChild
			this.hseparator2 = new global::Gtk.HSeparator();
			this.hseparator2.Name = "hseparator2";
			this.eventBoxReasonsSeparator.Add(this.hseparator2);
			this.tableMain.Add(this.eventBoxReasonsSeparator);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.tableMain[this.eventBoxReasonsSeparator]));
			w21.TopAttach = ((uint)(11));
			w21.BottomAttach = ((uint)(12));
			w21.RightAttach = ((uint)(2));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.eventBoxWhySentToReapproval = new global::Gamma.GtkWidgets.yEventBox();
			this.eventBoxWhySentToReapproval.Name = "eventBoxWhySentToReapproval";
			// Container child eventBoxWhySentToReapproval.Gtk.Container+ContainerChild
			this.scrollWhySentToReapproval = new global::Gtk.ScrolledWindow();
			this.scrollWhySentToReapproval.WidthRequest = 400;
			this.scrollWhySentToReapproval.HeightRequest = 65;
			this.scrollWhySentToReapproval.Name = "scrollWhySentToReapproval";
			this.scrollWhySentToReapproval.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrollWhySentToReapproval.Gtk.Container+ContainerChild
			this.entryWhySentToReapproval = new global::Gamma.GtkWidgets.yTextView();
			this.entryWhySentToReapproval.CanFocus = true;
			this.entryWhySentToReapproval.Name = "entryWhySentToReapproval";
			this.entryWhySentToReapproval.WrapMode = ((global::Gtk.WrapMode)(3));
			this.scrollWhySentToReapproval.Add(this.entryWhySentToReapproval);
			this.eventBoxWhySentToReapproval.Add(this.scrollWhySentToReapproval);
			this.tableMain.Add(this.eventBoxWhySentToReapproval);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.tableMain[this.eventBoxWhySentToReapproval]));
			w24.TopAttach = ((uint)(12));
			w24.BottomAttach = ((uint)(13));
			w24.LeftAttach = ((uint)(1));
			w24.RightAttach = ((uint)(2));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.evmeAuthor = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.evmeAuthor.WidthRequest = 400;
			this.evmeAuthor.Events = ((global::Gdk.EventMask)(256));
			this.evmeAuthor.Name = "evmeAuthor";
			this.evmeAuthor.CanEditReference = false;
			this.tableMain.Add(this.evmeAuthor);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.tableMain[this.evmeAuthor]));
			w25.LeftAttach = ((uint)(1));
			w25.RightAttach = ((uint)(2));
			w25.XOptions = ((global::Gtk.AttachOptions)(0));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.evmeCounterparty = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.evmeCounterparty.WidthRequest = 400;
			this.evmeCounterparty.Events = ((global::Gdk.EventMask)(256));
			this.evmeCounterparty.Name = "evmeCounterparty";
			this.evmeCounterparty.CanEditReference = false;
			this.tableMain.Add(this.evmeCounterparty);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.tableMain[this.evmeCounterparty]));
			w26.TopAttach = ((uint)(2));
			w26.BottomAttach = ((uint)(3));
			w26.LeftAttach = ((uint)(1));
			w26.RightAttach = ((uint)(2));
			w26.XOptions = ((global::Gtk.AttachOptions)(0));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.evmeExpenceCategory = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.evmeExpenceCategory.WidthRequest = 400;
			this.evmeExpenceCategory.Events = ((global::Gdk.EventMask)(256));
			this.evmeExpenceCategory.Name = "evmeExpenceCategory";
			this.evmeExpenceCategory.CanEditReference = false;
			this.tableMain.Add(this.evmeExpenceCategory);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.tableMain[this.evmeExpenceCategory]));
			w27.TopAttach = ((uint)(10));
			w27.BottomAttach = ((uint)(11));
			w27.LeftAttach = ((uint)(1));
			w27.RightAttach = ((uint)(2));
			w27.XOptions = ((global::Gtk.AttachOptions)(0));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.evmeSubdivision = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.evmeSubdivision.WidthRequest = 400;
			this.evmeSubdivision.Events = ((global::Gdk.EventMask)(256));
			this.evmeSubdivision.Name = "evmeSubdivision";
			this.evmeSubdivision.CanEditReference = false;
			this.tableMain.Add(this.evmeSubdivision);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.tableMain[this.evmeSubdivision]));
			w28.TopAttach = ((uint)(1));
			w28.BottomAttach = ((uint)(2));
			w28.LeftAttach = ((uint)(1));
			w28.RightAttach = ((uint)(2));
			w28.XOptions = ((global::Gtk.AttachOptions)(0));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.btnCancel = new global::Gamma.GtkWidgets.yButton();
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить заявку");
			this.vbox3.Add(this.btnCancel);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.btnCancel]));
			w29.Position = 0;
			w29.Expand = false;
			w29.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.btnReapprove = new global::Gamma.GtkWidgets.yButton();
			this.btnReapprove.CanFocus = true;
			this.btnReapprove.Name = "btnReapprove";
			this.btnReapprove.UseUnderline = true;
			this.btnReapprove.Label = global::Mono.Unix.Catalog.GetString("Отправить на пересогласование");
			this.vbox3.Add(this.btnReapprove);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.btnReapprove]));
			w30.Position = 1;
			w30.Expand = false;
			w30.Fill = false;
			this.hbox5.Add(this.vbox3);
			global::Gtk.Box.BoxChild w31 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.vbox3]));
			w31.Position = 0;
			w31.Expand = false;
			w31.Fill = false;
			this.tableMain.Add(this.hbox5);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.tableMain[this.hbox5]));
			w32.TopAttach = ((uint)(15));
			w32.BottomAttach = ((uint)(16));
			w32.LeftAttach = ((uint)(1));
			w32.RightAttach = ((uint)(2));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.buttonPayout = new global::Gamma.GtkWidgets.yButton();
			this.buttonPayout.CanFocus = true;
			this.buttonPayout.Name = "buttonPayout";
			this.buttonPayout.UseUnderline = true;
			this.buttonPayout.Label = global::Mono.Unix.Catalog.GetString("Оплатить");
			this.vbox2.Add(this.buttonPayout);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.buttonPayout]));
			w33.Position = 0;
			w33.Expand = false;
			w33.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btnConveyForPayout = new global::Gamma.GtkWidgets.yButton();
			this.btnConveyForPayout.CanFocus = true;
			this.btnConveyForPayout.Name = "btnConveyForPayout";
			this.btnConveyForPayout.UseUnderline = true;
			this.btnConveyForPayout.Label = global::Mono.Unix.Catalog.GetString("Передать на выдачу");
			this.vbox2.Add(this.btnConveyForPayout);
			global::Gtk.Box.BoxChild w34 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.btnConveyForPayout]));
			w34.Position = 1;
			w34.Expand = false;
			w34.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btnAccept = new global::Gamma.GtkWidgets.yButton();
			this.btnAccept.CanFocus = true;
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.UseUnderline = true;
			this.btnAccept.Label = global::Mono.Unix.Catalog.GetString("Подтвердить");
			this.vbox2.Add(this.btnAccept);
			global::Gtk.Box.BoxChild w35 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.btnAccept]));
			w35.Position = 2;
			w35.Expand = false;
			w35.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btnApprove = new global::Gamma.GtkWidgets.yButton();
			this.btnApprove.CanFocus = true;
			this.btnApprove.Name = "btnApprove";
			this.btnApprove.UseUnderline = true;
			this.btnApprove.Label = global::Mono.Unix.Catalog.GetString("Согласовать");
			this.vbox2.Add(this.btnApprove);
			global::Gtk.Box.BoxChild w36 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.btnApprove]));
			w36.Position = 3;
			w36.Expand = false;
			w36.Fill = false;
			this.hbox6.Add(this.vbox2);
			global::Gtk.Box.BoxChild w37 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.vbox2]));
			w37.PackType = ((global::Gtk.PackType)(1));
			w37.Position = 0;
			w37.Expand = false;
			w37.Fill = false;
			this.tableMain.Add(this.hbox6);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.tableMain[this.hbox6]));
			w38.TopAttach = ((uint)(15));
			w38.BottomAttach = ((uint)(16));
			w38.XOptions = ((global::Gtk.AttachOptions)(4));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.hseparator3 = new global::Gtk.HSeparator();
			this.hseparator3.Name = "hseparator3";
			this.tableMain.Add(this.hseparator3);
			global::Gtk.Table.TableChild w39 = ((global::Gtk.Table.TableChild)(this.tableMain[this.hseparator3]));
			w39.TopAttach = ((uint)(14));
			w39.BottomAttach = ((uint)(15));
			w39.RightAttach = ((uint)(2));
			w39.XOptions = ((global::Gtk.AttachOptions)(4));
			w39.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.labelAuthor = new global::Gtk.Label();
			this.labelAuthor.Name = "labelAuthor";
			this.labelAuthor.Xalign = 1F;
			this.labelAuthor.LabelProp = global::Mono.Unix.Catalog.GetString("Автор:");
			this.tableMain.Add(this.labelAuthor);
			global::Gtk.Table.TableChild w40 = ((global::Gtk.Table.TableChild)(this.tableMain[this.labelAuthor]));
			w40.XOptions = ((global::Gtk.AttachOptions)(4));
			w40.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.labelBasis = new global::Gamma.GtkWidgets.yLabel();
			this.labelBasis.Name = "labelBasis";
			this.labelBasis.Xalign = 1F;
			this.labelBasis.Yalign = 0F;
			this.labelBasis.LabelProp = global::Mono.Unix.Catalog.GetString("Основание:");
			this.tableMain.Add(this.labelBasis);
			global::Gtk.Table.TableChild w41 = ((global::Gtk.Table.TableChild)(this.tableMain[this.labelBasis]));
			w41.TopAttach = ((uint)(5));
			w41.BottomAttach = ((uint)(6));
			w41.XOptions = ((global::Gtk.AttachOptions)(4));
			w41.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.labelCancelReason = new global::Gamma.GtkWidgets.yLabel();
			this.labelCancelReason.Name = "labelCancelReason";
			this.labelCancelReason.Xalign = 1F;
			this.labelCancelReason.Yalign = 0F;
			this.labelCancelReason.LabelProp = global::Mono.Unix.Catalog.GetString("Причина отмены:");
			this.tableMain.Add(this.labelCancelReason);
			global::Gtk.Table.TableChild w42 = ((global::Gtk.Table.TableChild)(this.tableMain[this.labelCancelReason]));
			w42.TopAttach = ((uint)(13));
			w42.BottomAttach = ((uint)(14));
			w42.XOptions = ((global::Gtk.AttachOptions)(4));
			w42.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.labelComboOrganization = new global::Gamma.GtkWidgets.yLabel();
			this.labelComboOrganization.Name = "labelComboOrganization";
			this.labelComboOrganization.Xalign = 1F;
			this.labelComboOrganization.LabelProp = global::Mono.Unix.Catalog.GetString("Наша организация:");
			this.tableMain.Add(this.labelComboOrganization);
			global::Gtk.Table.TableChild w43 = ((global::Gtk.Table.TableChild)(this.tableMain[this.labelComboOrganization]));
			w43.TopAttach = ((uint)(9));
			w43.BottomAttach = ((uint)(10));
			w43.XOptions = ((global::Gtk.AttachOptions)(4));
			w43.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.labelCounterparty = new global::Gamma.GtkWidgets.yLabel();
			this.labelCounterparty.Name = "labelCounterparty";
			this.labelCounterparty.Xalign = 1F;
			this.labelCounterparty.LabelProp = global::Mono.Unix.Catalog.GetString("Поставщик:");
			this.tableMain.Add(this.labelCounterparty);
			global::Gtk.Table.TableChild w44 = ((global::Gtk.Table.TableChild)(this.tableMain[this.labelCounterparty]));
			w44.TopAttach = ((uint)(2));
			w44.BottomAttach = ((uint)(3));
			w44.XOptions = ((global::Gtk.AttachOptions)(4));
			w44.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.labelExpenceCategory = new global::Gamma.GtkWidgets.yLabel();
			this.labelExpenceCategory.Name = "labelExpenceCategory";
			this.labelExpenceCategory.Xalign = 1F;
			this.labelExpenceCategory.LabelProp = global::Mono.Unix.Catalog.GetString("Статья расхода:");
			this.tableMain.Add(this.labelExpenceCategory);
			global::Gtk.Table.TableChild w45 = ((global::Gtk.Table.TableChild)(this.tableMain[this.labelExpenceCategory]));
			w45.TopAttach = ((uint)(10));
			w45.BottomAttach = ((uint)(11));
			w45.XOptions = ((global::Gtk.AttachOptions)(4));
			w45.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.labelExplanation = new global::Gamma.GtkWidgets.yLabel();
			this.labelExplanation.Name = "labelExplanation";
			this.labelExplanation.Xalign = 1F;
			this.labelExplanation.Yalign = 0F;
			this.labelExplanation.LabelProp = global::Mono.Unix.Catalog.GetString("Пояснение:");
			this.tableMain.Add(this.labelExplanation);
			global::Gtk.Table.TableChild w46 = ((global::Gtk.Table.TableChild)(this.tableMain[this.labelExplanation]));
			w46.TopAttach = ((uint)(6));
			w46.BottomAttach = ((uint)(7));
			w46.XOptions = ((global::Gtk.AttachOptions)(4));
			w46.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.labelFiles = new global::Gamma.GtkWidgets.yLabel();
			this.labelFiles.Name = "labelFiles";
			this.labelFiles.Xalign = 1F;
			this.labelFiles.Yalign = 0F;
			this.labelFiles.LabelProp = global::Mono.Unix.Catalog.GetString("Файлы:");
			this.tableMain.Add(this.labelFiles);
			global::Gtk.Table.TableChild w47 = ((global::Gtk.Table.TableChild)(this.tableMain[this.labelFiles]));
			w47.TopAttach = ((uint)(4));
			w47.BottomAttach = ((uint)(5));
			w47.XOptions = ((global::Gtk.AttachOptions)(4));
			w47.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.labelSubdivision = new global::Gtk.Label();
			this.labelSubdivision.Name = "labelSubdivision";
			this.labelSubdivision.Xalign = 1F;
			this.labelSubdivision.LabelProp = global::Mono.Unix.Catalog.GetString("Подразделение:");
			this.tableMain.Add(this.labelSubdivision);
			global::Gtk.Table.TableChild w48 = ((global::Gtk.Table.TableChild)(this.tableMain[this.labelSubdivision]));
			w48.TopAttach = ((uint)(1));
			w48.BottomAttach = ((uint)(2));
			w48.XOptions = ((global::Gtk.AttachOptions)(4));
			w48.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.labelSum = new global::Gamma.GtkWidgets.yLabel();
			this.labelSum.Name = "labelSum";
			this.labelSum.Xalign = 1F;
			this.labelSum.LabelProp = global::Mono.Unix.Catalog.GetString("Сумма:");
			this.tableMain.Add(this.labelSum);
			global::Gtk.Table.TableChild w49 = ((global::Gtk.Table.TableChild)(this.tableMain[this.labelSum]));
			w49.TopAttach = ((uint)(3));
			w49.BottomAttach = ((uint)(4));
			w49.XOptions = ((global::Gtk.AttachOptions)(4));
			w49.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.labelWhySentToReapproval = new global::Gamma.GtkWidgets.yLabel();
			this.labelWhySentToReapproval.Name = "labelWhySentToReapproval";
			this.labelWhySentToReapproval.Xalign = 1F;
			this.labelWhySentToReapproval.Yalign = 0F;
			this.labelWhySentToReapproval.LabelProp = global::Mono.Unix.Catalog.GetString("Причина отправки\nна пересогласование:\n");
			this.tableMain.Add(this.labelWhySentToReapproval);
			global::Gtk.Table.TableChild w50 = ((global::Gtk.Table.TableChild)(this.tableMain[this.labelWhySentToReapproval]));
			w50.TopAttach = ((uint)(12));
			w50.BottomAttach = ((uint)(13));
			w50.XOptions = ((global::Gtk.AttachOptions)(4));
			w50.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.scrollBasis = new global::Gtk.ScrolledWindow();
			this.scrollBasis.WidthRequest = 400;
			this.scrollBasis.HeightRequest = 65;
			this.scrollBasis.Name = "scrollBasis";
			this.scrollBasis.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrollBasis.Gtk.Container+ContainerChild
			this.entryBasis = new global::Gamma.GtkWidgets.yTextView();
			this.entryBasis.CanFocus = true;
			this.entryBasis.Name = "entryBasis";
			this.entryBasis.WrapMode = ((global::Gtk.WrapMode)(3));
			this.scrollBasis.Add(this.entryBasis);
			this.tableMain.Add(this.scrollBasis);
			global::Gtk.Table.TableChild w52 = ((global::Gtk.Table.TableChild)(this.tableMain[this.scrollBasis]));
			w52.TopAttach = ((uint)(5));
			w52.BottomAttach = ((uint)(6));
			w52.LeftAttach = ((uint)(1));
			w52.RightAttach = ((uint)(2));
			w52.XOptions = ((global::Gtk.AttachOptions)(0));
			w52.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.scrollExplanation = new global::Gtk.ScrolledWindow();
			this.scrollExplanation.WidthRequest = 400;
			this.scrollExplanation.HeightRequest = 65;
			this.scrollExplanation.Name = "scrollExplanation";
			this.scrollExplanation.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrollExplanation.Gtk.Container+ContainerChild
			this.entryExplanation = new global::Gamma.GtkWidgets.yTextView();
			this.entryExplanation.CanFocus = true;
			this.entryExplanation.Name = "entryExplanation";
			this.entryExplanation.WrapMode = ((global::Gtk.WrapMode)(3));
			this.scrollExplanation.Add(this.entryExplanation);
			this.tableMain.Add(this.scrollExplanation);
			global::Gtk.Table.TableChild w54 = ((global::Gtk.Table.TableChild)(this.tableMain[this.scrollExplanation]));
			w54.TopAttach = ((uint)(6));
			w54.BottomAttach = ((uint)(7));
			w54.LeftAttach = ((uint)(1));
			w54.RightAttach = ((uint)(2));
			w54.XOptions = ((global::Gtk.AttachOptions)(0));
			w54.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableMain.Gtk.Table+TableChild
			this.yhboxSum = new global::Gamma.GtkWidgets.yHBox();
			this.yhboxSum.WidthRequest = 400;
			this.yhboxSum.Name = "yhboxSum";
			this.yhboxSum.Spacing = 6;
			// Container child yhboxSum.Gtk.Box+BoxChild
			this.spinSum = new global::Gamma.GtkWidgets.ySpinButton(0D, 2147483647D, 100D);
			this.spinSum.WidthRequest = 190;
			this.spinSum.CanFocus = true;
			this.spinSum.Name = "spinSum";
			this.spinSum.Adjustment.PageIncrement = 1000D;
			this.spinSum.ClimbRate = 1D;
			this.spinSum.Digits = ((uint)(2));
			this.spinSum.Numeric = true;
			this.spinSum.ValueAsDecimal = 0m;
			this.spinSum.ValueAsInt = 0;
			this.yhboxSum.Add(this.spinSum);
			global::Gtk.Box.BoxChild w55 = ((global::Gtk.Box.BoxChild)(this.yhboxSum[this.spinSum]));
			w55.Position = 0;
			w55.Expand = false;
			w55.Fill = false;
			// Container child yhboxSum.Gtk.Box+BoxChild
			this.currencylabel1 = new global::QSProjectsLib.CurrencyLabel();
			this.currencylabel1.Name = "currencylabel1";
			this.currencylabel1.LabelProp = global::Mono.Unix.Catalog.GetString("currencylabel1");
			this.yhboxSum.Add(this.currencylabel1);
			global::Gtk.Box.BoxChild w56 = ((global::Gtk.Box.BoxChild)(this.yhboxSum[this.currencylabel1]));
			w56.Position = 1;
			w56.Expand = false;
			w56.Fill = false;
			this.tableMain.Add(this.yhboxSum);
			global::Gtk.Table.TableChild w57 = ((global::Gtk.Table.TableChild)(this.tableMain[this.yhboxSum]));
			w57.TopAttach = ((uint)(3));
			w57.BottomAttach = ((uint)(4));
			w57.LeftAttach = ((uint)(1));
			w57.RightAttach = ((uint)(2));
			w57.XOptions = ((global::Gtk.AttachOptions)(0));
			w57.YOptions = ((global::Gtk.AttachOptions)(4));
			w10.Add(this.tableMain);
			this.scrolledMain.Add(w10);
			this.vboxDialog.Add(this.scrolledMain);
			global::Gtk.Box.BoxChild w60 = ((global::Gtk.Box.BoxChild)(this.vboxDialog[this.scrolledMain]));
			w60.Position = 1;
			this.Add(this.vboxDialog);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
