
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class CounterpartyFilter
	{
		private global::Gtk.Table table1;

		private global::Gtk.CheckButton checkIncludeArhive;

		private global::Gtk.HBox hbox2;

		private global::Gamma.Widgets.yEnumComboBox yenumCounterpartyType;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::QS.Widgets.GtkUI.RepresentationEntry yentryTag;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.CounterpartyFilter
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.CounterpartyFilter";
			// Container child Vodovoz.CounterpartyFilter.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(2)), ((uint)(3)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.checkIncludeArhive = new global::Gtk.CheckButton();
			this.checkIncludeArhive.CanFocus = true;
			this.checkIncludeArhive.Name = "checkIncludeArhive";
			this.checkIncludeArhive.Label = global::Mono.Unix.Catalog.GetString("Включая архивных");
			this.checkIncludeArhive.DrawIndicator = true;
			this.checkIncludeArhive.UseUnderline = true;
			this.table1.Add(this.checkIncludeArhive);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.checkIncludeArhive]));
			w1.TopAttach = ((uint)(1));
			w1.BottomAttach = ((uint)(2));
			w1.LeftAttach = ((uint)(2));
			w1.RightAttach = ((uint)(3));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.yenumCounterpartyType = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumCounterpartyType.Name = "yenumCounterpartyType";
			this.yenumCounterpartyType.ShowSpecialStateAll = true;
			this.yenumCounterpartyType.ShowSpecialStateNot = false;
			this.yenumCounterpartyType.UseShortTitle = false;
			this.yenumCounterpartyType.DefaultFirst = false;
			this.hbox2.Add(this.yenumCounterpartyType);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.yenumCounterpartyType]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			this.table1.Add(this.hbox2);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox2]));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Показывать только:");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Тег:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w5.TopAttach = ((uint)(1));
			w5.BottomAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryTag = new global::QS.Widgets.GtkUI.RepresentationEntry();
			this.yentryTag.Events = ((global::Gdk.EventMask)(256));
			this.yentryTag.Name = "yentryTag";
			this.table1.Add(this.yentryTag);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryTag]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.yentryTag.Changed += new global::System.EventHandler(this.OnYentryTagChanged);
			this.yenumCounterpartyType.EnumItemSelected += new global::System.EventHandler<Gamma.Widgets.ItemSelectedEventArgs>(this.OnyenumCounterpartyTypeItemSelected);
			this.checkIncludeArhive.Toggled += new global::System.EventHandler(this.OnCheckIncludeArhiveToggled);
		}
	}
}
