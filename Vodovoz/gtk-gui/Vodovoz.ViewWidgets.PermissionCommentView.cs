
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ViewWidgets
{
	public partial class PermissionCommentView
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Label labelTitle;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTextView ytextviewComment;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Button buttonSaveComment;

		private global::Gtk.Button buttonEditComment;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ViewWidgets.PermissionCommentView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ViewWidgets.PermissionCommentView";
			// Container child Vodovoz.ViewWidgets.PermissionCommentView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.labelTitle = new global::Gtk.Label();
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Xalign = 0F;
			this.labelTitle.UseMarkup = true;
			this.vbox2.Add(this.labelTitle);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.labelTitle]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytextviewComment = new global::Gamma.GtkWidgets.yTextView();
			this.ytextviewComment.CanFocus = true;
			this.ytextviewComment.Name = "ytextviewComment";
			this.GtkScrolledWindow.Add(this.ytextviewComment);
			this.vbox2.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.GtkScrolledWindow]));
			w3.Position = 1;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonSaveComment = new global::Gtk.Button();
			this.buttonSaveComment.CanFocus = true;
			this.buttonSaveComment.Name = "buttonSaveComment";
			this.buttonSaveComment.UseUnderline = true;
			this.buttonSaveComment.Label = global::Mono.Unix.Catalog.GetString("Сохранить комментарий");
			global::Gtk.Image w4 = new global::Gtk.Image();
			w4.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSaveComment.Image = w4;
			this.hbox1.Add(this.buttonSaveComment);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonSaveComment]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonEditComment = new global::Gtk.Button();
			this.buttonEditComment.CanFocus = true;
			this.buttonEditComment.Name = "buttonEditComment";
			this.buttonEditComment.UseUnderline = true;
			this.buttonEditComment.Label = global::Mono.Unix.Catalog.GetString("Изменить комментарий");
			global::Gtk.Image w6 = new global::Gtk.Image();
			w6.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-edit", global::Gtk.IconSize.Menu);
			this.buttonEditComment.Image = w6;
			this.hbox1.Add(this.buttonEditComment);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.buttonEditComment]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.vbox2.Add(this.hbox1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.buttonSaveComment.Hide();
			this.buttonEditComment.Hide();
			this.Hide();
			this.buttonSaveComment.Clicked += new global::System.EventHandler(this.OnButtonSaveCloseCommentClicked);
			this.buttonEditComment.Clicked += new global::System.EventHandler(this.OnButtonEditCloseDeliveryCommentClicked);
		}
	}
}
