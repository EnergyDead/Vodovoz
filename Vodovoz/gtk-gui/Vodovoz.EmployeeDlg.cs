
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class EmployeeDlg
	{
		private global::Gtk.UIManager UIManager;
		
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button buttonSave;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.VSeparator vseparator1;
		
		private global::Gtk.RadioButton radioTabInfo;
		
		private global::Gtk.RadioButton radioTabFiles;
		
		private global::Gtk.Notebook notebookMain;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.DataBindings.DataTable datatableMain;
		
		private global::Gtk.DataBindings.DataCheckButton checkIsFired;
		
		private global::Gtk.DataBindings.DataEntry dataentryDrivingNumber;
		
		private global::Gtk.DataBindings.DataEntry dataentryLastName;
		
		private global::Gtk.DataBindings.DataEntry dataentryName;
		
		private global::Gtk.DataBindings.DataEntry dataentryPatronymic;
		
		private global::Gtk.DataBindings.DataEnumComboBox dataenumcomboCategory;
		
		private global::Gtk.DataBindings.DataHBox datahbox2;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.DataBindings.DataEntry dataentryPassportSeria;
		
		private global::Gtk.Label label13;
		
		private global::Gtk.DataBindings.DataEntry dataentryPassportNumber;
		
		private global::Gtk.DataBindings.DataEntry entryAddressCurrent;
		
		private global::Gtk.DataBindings.DataEntry entryAddressRegistration;
		
		private global::Gtk.Label label10;
		
		private global::Gtk.Label label11;
		
		private global::Gtk.Label label14;
		
		private global::Gtk.Label label15;
		
		private global::Gtk.Label label16;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Label label5;
		
		private global::Gtk.Label label6;
		
		private global::Gtk.Label label7;
		
		private global::Gtk.Label label8;
		
		private global::Gtk.Label label9;
		
		private global::QSContacts.PhonesView phonesView;
		
		private global::Gtk.DataBindings.DataEntryReference referenceNationality;
		
		private global::Gtk.DataBindings.DataEntryReference referenceUser;
		
		private global::Gtk.DataBindings.DataVBox vbox3;
		
		private global::QSOrmProject.DataImageViewer dataimageviewerPhoto;
		
		private global::Gtk.HButtonBox hbuttonbox1;
		
		private global::Gtk.Button buttonLoadPhoto;
		
		private global::Gtk.Button buttonSavePhoto;
		
		private global::Gtk.Label label1;
		
		private global::QSAttachment.Attachment attachmentFiles;
		
		private global::Gtk.Label label12;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Vodovoz.EmployeeDlg
			Stetic.BinContainer w1 = global::Stetic.BinContainer.Attach (this);
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup ("Default");
			this.UIManager.InsertActionGroup (w2, 0);
			this.Name = "Vodovoz.EmployeeDlg";
			// Container child Vodovoz.EmployeeDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button ();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString ("Сохранить");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w3;
			this.hbox1.Add (this.buttonSave);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonSave]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Отменить");
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w5;
			this.hbox1.Add (this.buttonCancel);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonCancel]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator ();
			this.vseparator1.Name = "vseparator1";
			this.hbox1.Add (this.vseparator1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vseparator1]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.radioTabInfo = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Основное"));
			this.radioTabInfo.CanFocus = true;
			this.radioTabInfo.Name = "radioTabInfo";
			this.radioTabInfo.DrawIndicator = false;
			this.radioTabInfo.UseUnderline = true;
			this.radioTabInfo.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.hbox1.Add (this.radioTabInfo);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.radioTabInfo]));
			w8.Position = 3;
			// Container child hbox1.Gtk.Box+BoxChild
			this.radioTabFiles = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Файлы"));
			this.radioTabFiles.CanFocus = true;
			this.radioTabFiles.Name = "radioTabFiles";
			this.radioTabFiles.DrawIndicator = false;
			this.radioTabFiles.UseUnderline = true;
			this.radioTabFiles.Group = this.radioTabInfo.Group;
			this.hbox1.Add (this.radioTabFiles);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.radioTabFiles]));
			w9.Position = 4;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.notebookMain = new global::Gtk.Notebook ();
			this.notebookMain.CanFocus = true;
			this.notebookMain.Name = "notebookMain";
			this.notebookMain.CurrentPage = 0;
			// Container child notebookMain.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			global::Gtk.Viewport w11 = new global::Gtk.Viewport ();
			w11.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.datatableMain = new global::Gtk.DataBindings.DataTable (((uint)(12)), ((uint)(3)), false);
			this.datatableMain.Name = "datatableMain";
			this.datatableMain.RowSpacing = ((uint)(6));
			this.datatableMain.ColumnSpacing = ((uint)(6));
			this.datatableMain.InheritedDataSource = false;
			this.datatableMain.InheritedBoundaryDataSource = false;
			this.datatableMain.InheritedDataSource = false;
			this.datatableMain.InheritedBoundaryDataSource = false;
			// Container child datatableMain.Gtk.Table+TableChild
			this.checkIsFired = new global::Gtk.DataBindings.DataCheckButton ();
			this.checkIsFired.CanFocus = true;
			this.checkIsFired.Name = "checkIsFired";
			this.checkIsFired.Label = "";
			this.checkIsFired.DrawIndicator = true;
			this.checkIsFired.UseUnderline = true;
			this.checkIsFired.InheritedDataSource = true;
			this.checkIsFired.Mappings = "IsFired";
			this.checkIsFired.InheritedBoundaryDataSource = false;
			this.checkIsFired.Editable = true;
			this.checkIsFired.AutomaticTitle = false;
			this.checkIsFired.InheritedBoundaryDataSource = false;
			this.checkIsFired.InheritedDataSource = true;
			this.checkIsFired.Mappings = "IsFired";
			this.datatableMain.Add (this.checkIsFired);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.checkIsFired]));
			w12.TopAttach = ((uint)(11));
			w12.BottomAttach = ((uint)(12));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(3));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryDrivingNumber = new global::Gtk.DataBindings.DataEntry ();
			this.dataentryDrivingNumber.TooltipMarkup = "Десять символов серии и номера без пробелов.";
			this.dataentryDrivingNumber.CanFocus = true;
			this.dataentryDrivingNumber.Name = "dataentryDrivingNumber";
			this.dataentryDrivingNumber.IsEditable = true;
			this.dataentryDrivingNumber.MaxLength = 45;
			this.dataentryDrivingNumber.InvisibleChar = '●';
			this.dataentryDrivingNumber.InheritedDataSource = true;
			this.dataentryDrivingNumber.Mappings = "DrivingNumber";
			this.dataentryDrivingNumber.InheritedBoundaryDataSource = false;
			this.dataentryDrivingNumber.InheritedDataSource = true;
			this.dataentryDrivingNumber.Mappings = "DrivingNumber";
			this.dataentryDrivingNumber.InheritedBoundaryDataSource = false;
			this.datatableMain.Add (this.dataentryDrivingNumber);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.dataentryDrivingNumber]));
			w13.TopAttach = ((uint)(7));
			w13.BottomAttach = ((uint)(8));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(3));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryLastName = new global::Gtk.DataBindings.DataEntry ();
			this.dataentryLastName.CanFocus = true;
			this.dataentryLastName.Name = "dataentryLastName";
			this.dataentryLastName.IsEditable = true;
			this.dataentryLastName.InvisibleChar = '●';
			this.dataentryLastName.InheritedDataSource = true;
			this.dataentryLastName.Mappings = "LastName";
			this.dataentryLastName.InheritedBoundaryDataSource = false;
			this.dataentryLastName.InheritedDataSource = true;
			this.dataentryLastName.Mappings = "LastName";
			this.dataentryLastName.InheritedBoundaryDataSource = false;
			this.datatableMain.Add (this.dataentryLastName);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.dataentryLastName]));
			w14.LeftAttach = ((uint)(1));
			w14.RightAttach = ((uint)(2));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryName = new global::Gtk.DataBindings.DataEntry ();
			this.dataentryName.CanFocus = true;
			this.dataentryName.Name = "dataentryName";
			this.dataentryName.IsEditable = true;
			this.dataentryName.MaxLength = 100;
			this.dataentryName.InvisibleChar = '●';
			this.dataentryName.InheritedDataSource = true;
			this.dataentryName.Mappings = "Name";
			this.dataentryName.InheritedBoundaryDataSource = false;
			this.dataentryName.InheritedDataSource = true;
			this.dataentryName.Mappings = "Name";
			this.dataentryName.InheritedBoundaryDataSource = false;
			this.datatableMain.Add (this.dataentryName);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.dataentryName]));
			w15.TopAttach = ((uint)(1));
			w15.BottomAttach = ((uint)(2));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataentryPatronymic = new global::Gtk.DataBindings.DataEntry ();
			this.dataentryPatronymic.CanFocus = true;
			this.dataentryPatronymic.Name = "dataentryPatronymic";
			this.dataentryPatronymic.IsEditable = true;
			this.dataentryPatronymic.InvisibleChar = '●';
			this.dataentryPatronymic.InheritedDataSource = true;
			this.dataentryPatronymic.Mappings = "Patronymic";
			this.dataentryPatronymic.InheritedBoundaryDataSource = false;
			this.dataentryPatronymic.InheritedDataSource = true;
			this.dataentryPatronymic.Mappings = "Patronymic";
			this.dataentryPatronymic.InheritedBoundaryDataSource = false;
			this.datatableMain.Add (this.dataentryPatronymic);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.dataentryPatronymic]));
			w16.TopAttach = ((uint)(2));
			w16.BottomAttach = ((uint)(3));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.dataenumcomboCategory = new global::Gtk.DataBindings.DataEnumComboBox ();
			this.dataenumcomboCategory.Name = "dataenumcomboCategory";
			this.dataenumcomboCategory.InheritedBoundaryDataSource = false;
			this.dataenumcomboCategory.InheritedDataSource = true;
			this.dataenumcomboCategory.Mappings = "Category";
			this.dataenumcomboCategory.InheritedBoundaryDataSource = false;
			this.dataenumcomboCategory.InheritedDataSource = true;
			this.dataenumcomboCategory.Mappings = "Category";
			this.datatableMain.Add (this.dataenumcomboCategory);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.dataenumcomboCategory]));
			w17.TopAttach = ((uint)(3));
			w17.BottomAttach = ((uint)(4));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.datahbox2 = new global::Gtk.DataBindings.DataHBox ();
			this.datahbox2.Name = "datahbox2";
			this.datahbox2.Spacing = 6;
			this.datahbox2.InheritedDataSource = true;
			this.datahbox2.InheritedBoundaryDataSource = false;
			this.datahbox2.InheritedDataSource = true;
			this.datahbox2.InheritedBoundaryDataSource = false;
			// Container child datahbox2.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("серия");
			this.datahbox2.Add (this.label4);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.datahbox2 [this.label4]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Container child datahbox2.Gtk.Box+BoxChild
			this.dataentryPassportSeria = new global::Gtk.DataBindings.DataEntry ();
			this.dataentryPassportSeria.CanFocus = true;
			this.dataentryPassportSeria.Name = "dataentryPassportSeria";
			this.dataentryPassportSeria.IsEditable = true;
			this.dataentryPassportSeria.InvisibleChar = '●';
			this.dataentryPassportSeria.InheritedDataSource = true;
			this.dataentryPassportSeria.Mappings = "PassportSeria";
			this.dataentryPassportSeria.InheritedBoundaryDataSource = false;
			this.dataentryPassportSeria.InheritedDataSource = true;
			this.dataentryPassportSeria.Mappings = "PassportSeria";
			this.dataentryPassportSeria.InheritedBoundaryDataSource = false;
			this.datahbox2.Add (this.dataentryPassportSeria);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.datahbox2 [this.dataentryPassportSeria]));
			w19.Position = 1;
			// Container child datahbox2.Gtk.Box+BoxChild
			this.label13 = new global::Gtk.Label ();
			this.label13.Name = "label13";
			this.label13.LabelProp = global::Mono.Unix.Catalog.GetString ("номер");
			this.datahbox2.Add (this.label13);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.datahbox2 [this.label13]));
			w20.Position = 2;
			w20.Expand = false;
			w20.Fill = false;
			// Container child datahbox2.Gtk.Box+BoxChild
			this.dataentryPassportNumber = new global::Gtk.DataBindings.DataEntry ();
			this.dataentryPassportNumber.CanFocus = true;
			this.dataentryPassportNumber.Name = "dataentryPassportNumber";
			this.dataentryPassportNumber.IsEditable = true;
			this.dataentryPassportNumber.InvisibleChar = '●';
			this.dataentryPassportNumber.InheritedDataSource = true;
			this.dataentryPassportNumber.Mappings = "PassportNumber";
			this.dataentryPassportNumber.InheritedBoundaryDataSource = false;
			this.dataentryPassportNumber.InheritedDataSource = true;
			this.dataentryPassportNumber.Mappings = "PassportNumber";
			this.dataentryPassportNumber.InheritedBoundaryDataSource = false;
			this.datahbox2.Add (this.dataentryPassportNumber);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.datahbox2 [this.dataentryPassportNumber]));
			w21.Position = 3;
			this.datatableMain.Add (this.datahbox2);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.datahbox2]));
			w22.TopAttach = ((uint)(6));
			w22.BottomAttach = ((uint)(7));
			w22.LeftAttach = ((uint)(1));
			w22.RightAttach = ((uint)(3));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.entryAddressCurrent = new global::Gtk.DataBindings.DataEntry ();
			this.entryAddressCurrent.CanFocus = true;
			this.entryAddressCurrent.Name = "entryAddressCurrent";
			this.entryAddressCurrent.IsEditable = true;
			this.entryAddressCurrent.InvisibleChar = '●';
			this.entryAddressCurrent.InheritedDataSource = true;
			this.entryAddressCurrent.Mappings = "AddressCurrent";
			this.entryAddressCurrent.InheritedBoundaryDataSource = false;
			this.entryAddressCurrent.InheritedDataSource = true;
			this.entryAddressCurrent.Mappings = "AddressCurrent";
			this.entryAddressCurrent.InheritedBoundaryDataSource = false;
			this.datatableMain.Add (this.entryAddressCurrent);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.entryAddressCurrent]));
			w23.TopAttach = ((uint)(10));
			w23.BottomAttach = ((uint)(11));
			w23.LeftAttach = ((uint)(1));
			w23.RightAttach = ((uint)(3));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.entryAddressRegistration = new global::Gtk.DataBindings.DataEntry ();
			this.entryAddressRegistration.CanFocus = true;
			this.entryAddressRegistration.Name = "entryAddressRegistration";
			this.entryAddressRegistration.IsEditable = true;
			this.entryAddressRegistration.InvisibleChar = '●';
			this.entryAddressRegistration.InheritedDataSource = true;
			this.entryAddressRegistration.Mappings = "AddressRegistration";
			this.entryAddressRegistration.InheritedBoundaryDataSource = false;
			this.entryAddressRegistration.InheritedDataSource = true;
			this.entryAddressRegistration.Mappings = "AddressRegistration";
			this.entryAddressRegistration.InheritedBoundaryDataSource = false;
			this.datatableMain.Add (this.entryAddressRegistration);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.entryAddressRegistration]));
			w24.TopAttach = ((uint)(9));
			w24.BottomAttach = ((uint)(10));
			w24.LeftAttach = ((uint)(1));
			w24.RightAttach = ((uint)(3));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label10 = new global::Gtk.Label ();
			this.label10.Name = "label10";
			this.label10.Xalign = 1F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString ("Телефон:");
			this.datatableMain.Add (this.label10);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label10]));
			w25.TopAttach = ((uint)(8));
			w25.BottomAttach = ((uint)(9));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label11 = new global::Gtk.Label ();
			this.label11.Name = "label11";
			this.label11.Xalign = 1F;
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString ("Водительское\nудостоверение:");
			this.datatableMain.Add (this.label11);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label11]));
			w26.TopAttach = ((uint)(7));
			w26.BottomAttach = ((uint)(8));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label14 = new global::Gtk.Label ();
			this.label14.Name = "label14";
			this.label14.Xalign = 1F;
			this.label14.LabelProp = global::Mono.Unix.Catalog.GetString ("Адрес регистрации:");
			this.datatableMain.Add (this.label14);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label14]));
			w27.TopAttach = ((uint)(9));
			w27.BottomAttach = ((uint)(10));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label15 = new global::Gtk.Label ();
			this.label15.Name = "label15";
			this.label15.Xalign = 1F;
			this.label15.LabelProp = global::Mono.Unix.Catalog.GetString ("Фактический адрес:");
			this.datatableMain.Add (this.label15);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label15]));
			w28.TopAttach = ((uint)(10));
			w28.BottomAttach = ((uint)(11));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label16 = new global::Gtk.Label ();
			this.label16.Name = "label16";
			this.label16.Xalign = 1F;
			this.label16.LabelProp = global::Mono.Unix.Catalog.GetString ("Сотрудник уволен:");
			this.datatableMain.Add (this.label16);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label16]));
			w29.TopAttach = ((uint)(11));
			w29.BottomAttach = ((uint)(12));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Фамилия<span foreground=\"red\">*</span>:");
			this.label2.UseMarkup = true;
			this.datatableMain.Add (this.label2);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label2]));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Категория:");
			this.datatableMain.Add (this.label3);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label3]));
			w31.TopAttach = ((uint)(3));
			w31.BottomAttach = ((uint)(4));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Имя:");
			this.datatableMain.Add (this.label5);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label5]));
			w32.TopAttach = ((uint)(1));
			w32.BottomAttach = ((uint)(2));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Отчество:");
			this.datatableMain.Add (this.label6);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label6]));
			w33.TopAttach = ((uint)(2));
			w33.BottomAttach = ((uint)(3));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Национальность:");
			this.datatableMain.Add (this.label7);
			global::Gtk.Table.TableChild w34 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label7]));
			w34.TopAttach = ((uint)(4));
			w34.BottomAttach = ((uint)(5));
			w34.XOptions = ((global::Gtk.AttachOptions)(4));
			w34.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Пользователь:");
			this.datatableMain.Add (this.label8);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label8]));
			w35.TopAttach = ((uint)(5));
			w35.BottomAttach = ((uint)(6));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.label9 = new global::Gtk.Label ();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString ("Паспорт:");
			this.datatableMain.Add (this.label9);
			global::Gtk.Table.TableChild w36 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.label9]));
			w36.TopAttach = ((uint)(6));
			w36.BottomAttach = ((uint)(7));
			w36.XOptions = ((global::Gtk.AttachOptions)(4));
			w36.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.phonesView = new global::QSContacts.PhonesView ();
			this.phonesView.Events = ((global::Gdk.EventMask)(256));
			this.phonesView.Name = "phonesView";
			this.datatableMain.Add (this.phonesView);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.phonesView]));
			w37.TopAttach = ((uint)(8));
			w37.BottomAttach = ((uint)(9));
			w37.LeftAttach = ((uint)(1));
			w37.RightAttach = ((uint)(3));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.referenceNationality = new global::Gtk.DataBindings.DataEntryReference ();
			this.referenceNationality.Events = ((global::Gdk.EventMask)(256));
			this.referenceNationality.Name = "referenceNationality";
			this.referenceNationality.DisplayFields = new string[] {
				"Name"
			};
			this.referenceNationality.InheritedDataSource = true;
			this.referenceNationality.Mappings = "Nationality";
			this.referenceNationality.InheritedBoundaryDataSource = false;
			this.referenceNationality.CursorPointsEveryType = false;
			this.datatableMain.Add (this.referenceNationality);
			global::Gtk.Table.TableChild w38 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.referenceNationality]));
			w38.TopAttach = ((uint)(4));
			w38.BottomAttach = ((uint)(5));
			w38.LeftAttach = ((uint)(1));
			w38.RightAttach = ((uint)(2));
			w38.XOptions = ((global::Gtk.AttachOptions)(4));
			w38.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.referenceUser = new global::Gtk.DataBindings.DataEntryReference ();
			this.referenceUser.Events = ((global::Gdk.EventMask)(256));
			this.referenceUser.Name = "referenceUser";
			this.referenceUser.DisplayFields = new string[] {
				"Name"
			};
			this.referenceUser.InheritedDataSource = true;
			this.referenceUser.Mappings = "User";
			this.referenceUser.InheritedBoundaryDataSource = false;
			this.referenceUser.CursorPointsEveryType = false;
			this.datatableMain.Add (this.referenceUser);
			global::Gtk.Table.TableChild w39 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.referenceUser]));
			w39.TopAttach = ((uint)(5));
			w39.BottomAttach = ((uint)(6));
			w39.LeftAttach = ((uint)(1));
			w39.RightAttach = ((uint)(2));
			w39.XOptions = ((global::Gtk.AttachOptions)(4));
			w39.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableMain.Gtk.Table+TableChild
			this.vbox3 = new global::Gtk.DataBindings.DataVBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			this.vbox3.InheritedDataSource = true;
			this.vbox3.InheritedBoundaryDataSource = false;
			this.vbox3.InheritedDataSource = true;
			this.vbox3.InheritedBoundaryDataSource = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.dataimageviewerPhoto = new global::QSOrmProject.DataImageViewer ();
			this.dataimageviewerPhoto.Name = "dataimageviewerPhoto";
			this.dataimageviewerPhoto.VerticalFit = true;
			this.dataimageviewerPhoto.HorizontalFit = false;
			this.dataimageviewerPhoto.InheritedBoundaryDataSource = false;
			this.dataimageviewerPhoto.InheritedDataSource = true;
			this.dataimageviewerPhoto.Mappings = "Photo";
			this.vbox3.Add (this.dataimageviewerPhoto);
			global::Gtk.Box.BoxChild w40 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.dataimageviewerPhoto]));
			w40.Position = 0;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbuttonbox1 = new global::Gtk.HButtonBox ();
			this.hbuttonbox1.Name = "hbuttonbox1";
			// Container child hbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.buttonLoadPhoto = new global::Gtk.Button ();
			this.buttonLoadPhoto.CanFocus = true;
			this.buttonLoadPhoto.Name = "buttonLoadPhoto";
			this.buttonLoadPhoto.UseUnderline = true;
			this.buttonLoadPhoto.Label = global::Mono.Unix.Catalog.GetString ("Загрузить");
			global::Gtk.Image w41 = new global::Gtk.Image ();
			w41.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Vodovoz.icons.insert-image.png");
			this.buttonLoadPhoto.Image = w41;
			this.hbuttonbox1.Add (this.buttonLoadPhoto);
			global::Gtk.ButtonBox.ButtonBoxChild w42 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox1 [this.buttonLoadPhoto]));
			w42.Expand = false;
			w42.Fill = false;
			// Container child hbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			this.buttonSavePhoto = new global::Gtk.Button ();
			this.buttonSavePhoto.Sensitive = false;
			this.buttonSavePhoto.CanFocus = true;
			this.buttonSavePhoto.Name = "buttonSavePhoto";
			this.buttonSavePhoto.UseUnderline = true;
			this.buttonSavePhoto.Label = global::Mono.Unix.Catalog.GetString ("Сохранить");
			global::Gtk.Image w43 = new global::Gtk.Image ();
			w43.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("Vodovoz.icons.drive-harddisk.png");
			this.buttonSavePhoto.Image = w43;
			this.hbuttonbox1.Add (this.buttonSavePhoto);
			global::Gtk.ButtonBox.ButtonBoxChild w44 = ((global::Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox1 [this.buttonSavePhoto]));
			w44.Position = 1;
			w44.Expand = false;
			w44.Fill = false;
			this.vbox3.Add (this.hbuttonbox1);
			global::Gtk.Box.BoxChild w45 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbuttonbox1]));
			w45.Position = 1;
			w45.Expand = false;
			this.datatableMain.Add (this.vbox3);
			global::Gtk.Table.TableChild w46 = ((global::Gtk.Table.TableChild)(this.datatableMain [this.vbox3]));
			w46.BottomAttach = ((uint)(6));
			w46.LeftAttach = ((uint)(2));
			w46.RightAttach = ((uint)(3));
			w46.XOptions = ((global::Gtk.AttachOptions)(4));
			w46.YOptions = ((global::Gtk.AttachOptions)(4));
			w11.Add (this.datatableMain);
			this.GtkScrolledWindow.Add (w11);
			this.notebookMain.Add (this.GtkScrolledWindow);
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Информация");
			this.notebookMain.SetTabLabel (this.GtkScrolledWindow, this.label1);
			this.label1.ShowAll ();
			// Container child notebookMain.Gtk.Notebook+NotebookChild
			this.attachmentFiles = new global::QSAttachment.Attachment ();
			this.attachmentFiles.Events = ((global::Gdk.EventMask)(256));
			this.attachmentFiles.Name = "attachmentFiles";
			this.notebookMain.Add (this.attachmentFiles);
			global::Gtk.Notebook.NotebookChild w50 = ((global::Gtk.Notebook.NotebookChild)(this.notebookMain [this.attachmentFiles]));
			w50.Position = 1;
			// Notebook tab
			this.label12 = new global::Gtk.Label ();
			this.label12.Name = "label12";
			this.label12.LabelProp = global::Mono.Unix.Catalog.GetString ("Файлы");
			this.notebookMain.SetTabLabel (this.attachmentFiles, this.label12);
			this.label12.ShowAll ();
			this.vbox1.Add (this.notebookMain);
			global::Gtk.Box.BoxChild w51 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.notebookMain]));
			w51.Position = 1;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			w1.SetUiManager (UIManager);
			this.Hide ();
			this.buttonSave.Clicked += new global::System.EventHandler (this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
			this.radioTabInfo.Toggled += new global::System.EventHandler (this.OnRadioTabInfoToggled);
			this.radioTabFiles.Toggled += new global::System.EventHandler (this.OnRadioTabAccountsToggled);
			this.dataimageviewerPhoto.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnDataimageviewerPhotoButtonPressEvent);
			this.buttonLoadPhoto.Clicked += new global::System.EventHandler (this.OnButtonLoadClicked);
			this.buttonSavePhoto.Clicked += new global::System.EventHandler (this.OnButtonSavePhotoClicked);
		}
	}
}
