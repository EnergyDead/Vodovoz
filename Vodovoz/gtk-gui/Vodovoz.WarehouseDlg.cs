
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class WarehouseDlg
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Table table1;

		private global::Gamma.Widgets.yEnumComboBox comboTypeOfUse;

		private global::Gtk.HSeparator hseparator1;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Label labelName;

		private global::Gamma.GtkWidgets.yCheckButton ycheckbuttonArchive;

		private global::Gamma.GtkWidgets.yCheckButton ycheckbuttonCanReceiveBottles;

		private global::Gamma.GtkWidgets.yCheckButton ycheckbuttonCanReceiveEquipment;

		private global::Gamma.GtkWidgets.yCheckButton ycheckOnlineStore;

		private global::Gamma.GtkWidgets.yEntry yentryName;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.WarehouseDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.WarehouseDlg";
			// Container child Vodovoz.WarehouseDlg.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox4.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox4.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox2.Add(this.hbox4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox4]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(8)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.comboTypeOfUse = new global::Gamma.Widgets.yEnumComboBox();
			this.comboTypeOfUse.Name = "comboTypeOfUse";
			this.comboTypeOfUse.ShowSpecialStateAll = false;
			this.comboTypeOfUse.ShowSpecialStateNot = false;
			this.comboTypeOfUse.UseShortTitle = false;
			this.comboTypeOfUse.DefaultFirst = false;
			this.table1.Add(this.comboTypeOfUse);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.comboTypeOfUse]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hseparator1 = new global::Gtk.HSeparator();
			this.hseparator1.Name = "hseparator1";
			this.table1.Add(this.hseparator1);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.hseparator1]));
			w7.TopAttach = ((uint)(3));
			w7.BottomAttach = ((uint)(4));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Тип использования:");
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Публиковать количество:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w9.TopAttach = ((uint)(2));
			w9.BottomAttach = ((uint)(3));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelName = new global::Gtk.Label();
			this.labelName.Name = "labelName";
			this.labelName.Xalign = 1F;
			this.labelName.LabelProp = global::Mono.Unix.Catalog.GetString("Название:");
			this.table1.Add(this.labelName);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.labelName]));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckbuttonArchive = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckbuttonArchive.CanFocus = true;
			this.ycheckbuttonArchive.Name = "ycheckbuttonArchive";
			this.ycheckbuttonArchive.Label = global::Mono.Unix.Catalog.GetString("Архивный");
			this.ycheckbuttonArchive.DrawIndicator = true;
			this.ycheckbuttonArchive.UseUnderline = true;
			this.table1.Add(this.ycheckbuttonArchive);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.ycheckbuttonArchive]));
			w11.TopAttach = ((uint)(6));
			w11.BottomAttach = ((uint)(7));
			w11.LeftAttach = ((uint)(1));
			w11.RightAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckbuttonCanReceiveBottles = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckbuttonCanReceiveBottles.CanFocus = true;
			this.ycheckbuttonCanReceiveBottles.Name = "ycheckbuttonCanReceiveBottles";
			this.ycheckbuttonCanReceiveBottles.Label = global::Mono.Unix.Catalog.GetString("Прием тары");
			this.ycheckbuttonCanReceiveBottles.DrawIndicator = true;
			this.ycheckbuttonCanReceiveBottles.UseUnderline = true;
			this.table1.Add(this.ycheckbuttonCanReceiveBottles);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.ycheckbuttonCanReceiveBottles]));
			w12.TopAttach = ((uint)(4));
			w12.BottomAttach = ((uint)(5));
			w12.LeftAttach = ((uint)(1));
			w12.RightAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckbuttonCanReceiveEquipment = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckbuttonCanReceiveEquipment.CanFocus = true;
			this.ycheckbuttonCanReceiveEquipment.Name = "ycheckbuttonCanReceiveEquipment";
			this.ycheckbuttonCanReceiveEquipment.Label = global::Mono.Unix.Catalog.GetString("Прием оборудования");
			this.ycheckbuttonCanReceiveEquipment.DrawIndicator = true;
			this.ycheckbuttonCanReceiveEquipment.UseUnderline = true;
			this.table1.Add(this.ycheckbuttonCanReceiveEquipment);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.ycheckbuttonCanReceiveEquipment]));
			w13.TopAttach = ((uint)(5));
			w13.BottomAttach = ((uint)(6));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ycheckOnlineStore = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckOnlineStore.CanFocus = true;
			this.ycheckOnlineStore.Name = "ycheckOnlineStore";
			this.ycheckOnlineStore.Label = global::Mono.Unix.Catalog.GetString("Интернет магазин");
			this.ycheckOnlineStore.DrawIndicator = true;
			this.ycheckOnlineStore.UseUnderline = true;
			this.table1.Add(this.ycheckOnlineStore);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.ycheckOnlineStore]));
			w14.TopAttach = ((uint)(2));
			w14.BottomAttach = ((uint)(3));
			w14.LeftAttach = ((uint)(1));
			w14.RightAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryName = new global::Gamma.GtkWidgets.yEntry();
			this.yentryName.CanFocus = true;
			this.yentryName.Name = "yentryName";
			this.yentryName.IsEditable = true;
			this.yentryName.InvisibleChar = '•';
			this.table1.Add(this.yentryName);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryName]));
			w15.LeftAttach = ((uint)(1));
			w15.RightAttach = ((uint)(2));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add(this.table1);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.table1]));
			w16.Position = 1;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
