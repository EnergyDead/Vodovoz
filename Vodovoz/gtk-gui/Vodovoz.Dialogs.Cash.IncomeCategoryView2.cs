
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Dialogs.Cash
{
	public partial class IncomeCategoryView2
	{
		private global::Gtk.Table table1;

		private global::Gtk.HBox hbox3;

		private global::Gamma.GtkWidgets.yButton buttonSave;

		private global::Gamma.GtkWidgets.yButton buttonCancel;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry ParentEntityviewmodelentry;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry SubdivisionEntityviewmodelentry;

		private global::Gamma.GtkWidgets.yCheckButton ycheckArchived;

		private global::Gamma.GtkWidgets.yEntry yentryName;

		private global::Gamma.GtkWidgets.yEntry yentryNumbering;

		private global::Gamma.Widgets.yEnumComboBox yenumTypeDocument;

		private global::Gamma.GtkWidgets.yLabel ylabel3;

		private global::Gamma.GtkWidgets.yLabel ylabel4;

		private global::Gamma.GtkWidgets.yLabel ylabel5;

		private global::Gamma.GtkWidgets.yLabel ylabel6;

		private global::Gamma.GtkWidgets.yLabel ylabel7;

		private global::Gamma.GtkWidgets.yLabel ylabel8;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Dialogs.Cash.IncomeCategoryView2
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Dialogs.Cash.IncomeCategoryView2";
			// Container child Vodovoz.Dialogs.Cash.IncomeCategoryView2.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(7)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonSave = new global::Gamma.GtkWidgets.yButton();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			this.hbox3.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.buttonSave]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gamma.GtkWidgets.yButton();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			this.hbox3.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.buttonCancel]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.table1.Add(this.hbox3);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.hbox3]));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ParentEntityviewmodelentry = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.ParentEntityviewmodelentry.Events = ((global::Gdk.EventMask)(256));
			this.ParentEntityviewmodelentry.Name = "ParentEntityviewmodelentry";
			this.ParentEntityviewmodelentry.CanEditReference = false;
			this.table1.Add(this.ParentEntityviewmodelentry);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.ParentEntityviewmodelentry]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.SubdivisionEntityviewmodelentry = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.SubdivisionEntityviewmodelentry.Events = ((global::Gdk.EventMask)(256));
			this.SubdivisionEntityviewmodelentry.Name = "SubdivisionEntityviewmodelentry";
			this.SubdivisionEntityviewmodelentry.CanEditReference = false;
			this.table1.Add(this.SubdivisionEntityviewmodelentry);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.SubdivisionEntityviewmodelentry]));
			w5.TopAttach = ((uint)(5));
			w5.BottomAttach = ((uint)(6));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckArchived = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckArchived.CanFocus = true;
			this.ycheckArchived.Name = "ycheckArchived";
			this.ycheckArchived.Label = "";
			this.ycheckArchived.DrawIndicator = true;
			this.ycheckArchived.UseUnderline = true;
			this.table1.Add(this.ycheckArchived);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.ycheckArchived]));
			w6.TopAttach = ((uint)(4));
			w6.BottomAttach = ((uint)(5));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryName = new global::Gamma.GtkWidgets.yEntry();
			this.yentryName.CanFocus = true;
			this.yentryName.Name = "yentryName";
			this.yentryName.IsEditable = true;
			this.yentryName.InvisibleChar = '•';
			this.table1.Add(this.yentryName);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryName]));
			w7.TopAttach = ((uint)(2));
			w7.BottomAttach = ((uint)(3));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryNumbering = new global::Gamma.GtkWidgets.yEntry();
			this.yentryNumbering.CanFocus = true;
			this.yentryNumbering.Name = "yentryNumbering";
			this.yentryNumbering.IsEditable = true;
			this.yentryNumbering.InvisibleChar = '•';
			this.table1.Add(this.yentryNumbering);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryNumbering]));
			w8.TopAttach = ((uint)(6));
			w8.BottomAttach = ((uint)(7));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yenumTypeDocument = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumTypeDocument.Name = "yenumTypeDocument";
			this.yenumTypeDocument.ShowSpecialStateAll = false;
			this.yenumTypeDocument.ShowSpecialStateNot = false;
			this.yenumTypeDocument.UseShortTitle = false;
			this.yenumTypeDocument.DefaultFirst = false;
			this.table1.Add(this.yenumTypeDocument);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.yenumTypeDocument]));
			w9.TopAttach = ((uint)(3));
			w9.BottomAttach = ((uint)(4));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabel3 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel3.Name = "ylabel3";
			this.ylabel3.LabelProp = global::Mono.Unix.Catalog.GetString("Родитель");
			this.table1.Add(this.ylabel3);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabel3]));
			w10.TopAttach = ((uint)(1));
			w10.BottomAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabel4 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel4.Name = "ylabel4";
			this.ylabel4.LabelProp = global::Mono.Unix.Catalog.GetString("Название:");
			this.table1.Add(this.ylabel4);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabel4]));
			w11.TopAttach = ((uint)(2));
			w11.BottomAttach = ((uint)(3));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabel5 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel5.Name = "ylabel5";
			this.ylabel5.LabelProp = global::Mono.Unix.Catalog.GetString("Тип документа:");
			this.table1.Add(this.ylabel5);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabel5]));
			w12.TopAttach = ((uint)(3));
			w12.BottomAttach = ((uint)(4));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabel6 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel6.Name = "ylabel6";
			this.ylabel6.LabelProp = global::Mono.Unix.Catalog.GetString("Архивировать:");
			this.table1.Add(this.ylabel6);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabel6]));
			w13.TopAttach = ((uint)(4));
			w13.BottomAttach = ((uint)(5));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabel7 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel7.Name = "ylabel7";
			this.ylabel7.LabelProp = global::Mono.Unix.Catalog.GetString("Подразделение:");
			this.table1.Add(this.ylabel7);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabel7]));
			w14.TopAttach = ((uint)(5));
			w14.BottomAttach = ((uint)(6));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ylabel8 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel8.Name = "ylabel8";
			this.ylabel8.LabelProp = global::Mono.Unix.Catalog.GetString("Нумерация:");
			this.table1.Add(this.ylabel8);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1[this.ylabel8]));
			w15.TopAttach = ((uint)(6));
			w15.BottomAttach = ((uint)(7));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
