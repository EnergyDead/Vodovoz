
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Filters.GtkViews
{
	public partial class CarFilterView
	{
		private global::Gtk.Table table1;

		private global::Gamma.GtkWidgets.yCheckButton ycheckIncludeArchive;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Filters.GtkViews.CarFilterView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Filters.GtkViews.CarFilterView";
			// Container child Vodovoz.Filters.GtkViews.CarFilterView.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(1)), ((uint)(1)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckIncludeArchive = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckIncludeArchive.CanFocus = true;
			this.ycheckIncludeArchive.Name = "ycheckIncludeArchive";
			this.ycheckIncludeArchive.Label = global::Mono.Unix.Catalog.GetString("Включая архивных");
			this.ycheckIncludeArchive.DrawIndicator = true;
			this.ycheckIncludeArchive.UseUnderline = true;
			this.table1.Add(this.ycheckIncludeArchive);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.ycheckIncludeArchive]));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
