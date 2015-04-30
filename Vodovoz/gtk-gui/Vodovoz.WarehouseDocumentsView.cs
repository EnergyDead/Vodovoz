
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class WarehouseDocumentsView
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox1;
		
		private global::QSOrmProject.EnumMenuButton buttonAdd;
		
		private global::Gtk.Button buttonEdit;
		
		private global::Gtk.Button buttonDelete;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.DataBindings.DataTreeView treeDocuments;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget Vodovoz.WarehouseDocumentsView
			global::Stetic.BinContainer.Attach (this);
			this.Name = "Vodovoz.WarehouseDocumentsView";
			// Container child Vodovoz.WarehouseDocumentsView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonAdd = new global::QSOrmProject.EnumMenuButton ();
			this.buttonAdd.CanFocus = true;
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.UseUnderline = true;
			this.buttonAdd.UseMarkup = false;
			this.buttonAdd.ItemsEnumName = "Vodovoz.DocumentType, Vodovoz";
			this.buttonAdd.Label = global::Mono.Unix.Catalog.GetString ("Добавить");
			global::Gtk.Image w1 = new global::Gtk.Image ();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			this.buttonAdd.Image = w1;
			this.hbox1.Add (this.buttonAdd);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonAdd]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonEdit = new global::Gtk.Button ();
			this.buttonEdit.CanFocus = true;
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.UseUnderline = true;
			this.buttonEdit.Label = global::Mono.Unix.Catalog.GetString ("Изменить");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-edit", global::Gtk.IconSize.Menu);
			this.buttonEdit.Image = w3;
			this.hbox1.Add (this.buttonEdit);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonEdit]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonDelete = new global::Gtk.Button ();
			this.buttonDelete.CanFocus = true;
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.UseUnderline = true;
			this.buttonDelete.Label = global::Mono.Unix.Catalog.GetString ("Удалить");
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.buttonDelete.Image = w5;
			this.hbox1.Add (this.buttonDelete);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonDelete]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeDocuments = new global::Gtk.DataBindings.DataTreeView ();
			this.treeDocuments.CanFocus = true;
			this.treeDocuments.Name = "treeDocuments";
			this.treeDocuments.CursorPointsEveryType = false;
			this.treeDocuments.InheritedDataSource = false;
			this.treeDocuments.InheritedBoundaryDataSource = false;
			this.treeDocuments.InheritedDataSource = false;
			this.treeDocuments.InheritedBoundaryDataSource = false;
			this.treeDocuments.ColumnMappings = "{Vodovoz.Document} Number[Номер]; DocType[Тип документа]; DateString[Дата]; Description[Детали];";
			this.GtkScrolledWindow.Add (this.treeDocuments);
			this.vbox1.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
			w9.Position = 1;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.buttonAdd.EnumItemClicked += new global::System.EventHandler<QSOrmProject.EnumItemClickedEventArgs> (this.OnButtonAddEnumItemClicked);
			this.buttonEdit.Clicked += new global::System.EventHandler (this.OnButtonEditClicked);
			this.buttonDelete.Clicked += new global::System.EventHandler (this.OnButtonDeleteClicked);
			this.treeDocuments.RowActivated += new global::Gtk.RowActivatedHandler (this.OnTreeDocumentsRowActivated);
		}
	}
}
