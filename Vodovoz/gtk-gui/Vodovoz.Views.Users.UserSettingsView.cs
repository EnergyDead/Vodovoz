
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Views.Users
{
	public partial class UserSettingsView
	{
		private global::Gtk.VBox vbox4;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Table tableWriteoff;

		private global::Gtk.Label label4;

		private global::Gamma.Widgets.yEntryReference yentryrefWarehouse;

		private global::Gamma.Widgets.yEnumComboBox yenumcomboDefaultCategory;

		private global::Gamma.GtkWidgets.yLabel ylabel1;

		private global::Gtk.VBox vbox7;

		private global::Gtk.Frame frame1;

		private global::Gtk.Alignment GtkAlignment2;

		private global::Gtk.VBox vbox8;

		private global::Gamma.GtkWidgets.yCheckButton ycheckbuttonDelivery;

		private global::Gamma.GtkWidgets.yCheckButton ycheckbuttonService;

		private global::Gamma.GtkWidgets.yCheckButton ycheckbuttonChainStore;

		private global::Gtk.Label GtkLabel2;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Views.Users.UserSettingsView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Views.Users.UserSettingsView";
			// Container child Vodovoz.Views.Users.UserSettingsView.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			this.vbox4.BorderWidth = ((uint)(6));
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox5.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox5.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox5[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox4.Add(this.hbox5);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox5]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.tableWriteoff = new global::Gtk.Table(((uint)(3)), ((uint)(2)), false);
			this.tableWriteoff.Name = "tableWriteoff";
			this.tableWriteoff.RowSpacing = ((uint)(6));
			this.tableWriteoff.ColumnSpacing = ((uint)(6));
			// Container child tableWriteoff.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Склад по умолчанию:");
			this.tableWriteoff.Add(this.label4);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.tableWriteoff[this.label4]));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWriteoff.Gtk.Table+TableChild
			this.yentryrefWarehouse = new global::Gamma.Widgets.yEntryReference();
			this.yentryrefWarehouse.Events = ((global::Gdk.EventMask)(256));
			this.yentryrefWarehouse.Name = "yentryrefWarehouse";
			this.tableWriteoff.Add(this.yentryrefWarehouse);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.tableWriteoff[this.yentryrefWarehouse]));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWriteoff.Gtk.Table+TableChild
			this.yenumcomboDefaultCategory = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumcomboDefaultCategory.Name = "yenumcomboDefaultCategory";
			this.yenumcomboDefaultCategory.ShowSpecialStateAll = false;
			this.yenumcomboDefaultCategory.ShowSpecialStateNot = true;
			this.yenumcomboDefaultCategory.UseShortTitle = false;
			this.yenumcomboDefaultCategory.DefaultFirst = false;
			this.tableWriteoff.Add(this.yenumcomboDefaultCategory);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.tableWriteoff[this.yenumcomboDefaultCategory]));
			w8.TopAttach = ((uint)(1));
			w8.BottomAttach = ((uint)(2));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child tableWriteoff.Gtk.Table+TableChild
			this.ylabel1 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel1.Name = "ylabel1";
			this.ylabel1.LabelProp = global::Mono.Unix.Catalog.GetString("Продажа по умолчанию:");
			this.tableWriteoff.Add(this.ylabel1);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.tableWriteoff[this.ylabel1]));
			w9.TopAttach = ((uint)(1));
			w9.BottomAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hbox6.Add(this.tableWriteoff);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.tableWriteoff]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.vbox7 = new global::Gtk.VBox();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment2.Name = "GtkAlignment2";
			this.GtkAlignment2.LeftPadding = ((uint)(12));
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.vbox8 = new global::Gtk.VBox();
			this.vbox8.Name = "vbox8";
			this.vbox8.Spacing = 6;
			// Container child vbox8.Gtk.Box+BoxChild
			this.ycheckbuttonDelivery = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckbuttonDelivery.CanFocus = true;
			this.ycheckbuttonDelivery.Name = "ycheckbuttonDelivery";
			this.ycheckbuttonDelivery.Label = global::Mono.Unix.Catalog.GetString("Доставка");
			this.ycheckbuttonDelivery.DrawIndicator = true;
			this.ycheckbuttonDelivery.UseUnderline = true;
			this.vbox8.Add(this.ycheckbuttonDelivery);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.ycheckbuttonDelivery]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox8.Gtk.Box+BoxChild
			this.ycheckbuttonService = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckbuttonService.CanFocus = true;
			this.ycheckbuttonService.Name = "ycheckbuttonService";
			this.ycheckbuttonService.Label = global::Mono.Unix.Catalog.GetString("Сервисное обслуживание");
			this.ycheckbuttonService.DrawIndicator = true;
			this.ycheckbuttonService.UseUnderline = true;
			this.vbox8.Add(this.ycheckbuttonService);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.ycheckbuttonService]));
			w12.Position = 1;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox8.Gtk.Box+BoxChild
			this.ycheckbuttonChainStore = new global::Gamma.GtkWidgets.yCheckButton();
			this.ycheckbuttonChainStore.CanFocus = true;
			this.ycheckbuttonChainStore.Name = "ycheckbuttonChainStore";
			this.ycheckbuttonChainStore.Label = global::Mono.Unix.Catalog.GetString("Сетевые магазины");
			this.ycheckbuttonChainStore.DrawIndicator = true;
			this.ycheckbuttonChainStore.UseUnderline = true;
			this.vbox8.Add(this.ycheckbuttonChainStore);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox8[this.ycheckbuttonChainStore]));
			w13.Position = 2;
			w13.Expand = false;
			w13.Fill = false;
			this.GtkAlignment2.Add(this.vbox8);
			this.frame1.Add(this.GtkAlignment2);
			this.GtkLabel2 = new global::Gtk.Label();
			this.GtkLabel2.Name = "GtkLabel2";
			this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Фильтр в журнале МЛ</b>");
			this.GtkLabel2.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel2;
			this.vbox7.Add(this.frame1);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox7[this.frame1]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			this.hbox6.Add(this.vbox7);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.vbox7]));
			w17.Position = 1;
			w17.Expand = false;
			w17.Fill = false;
			this.vbox4.Add(this.hbox6);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox6]));
			w18.Position = 1;
			this.Add(this.vbox4);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
