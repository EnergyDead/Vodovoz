
// This file has been generated by the GUI designer. Do not modify.
namespace Dialogs.Employees
{
	public partial class EmployeeWorkChartDlg
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox1;

		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox5;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.HBox hbox7;

		private global::Gamma.GtkWidgets.yLabel ylabel1;

		private global::Gamma.Widgets.yEnumComboBox yenumcomboMonth;

		private global::Gtk.HBox hbox3;

		private global::Gtk.Label label2;

		private global::Gamma.GtkWidgets.ySpinButton yspinYear;

		private global::Gtk.HBox hbox6;

		private global::Gtk.Label label3;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry evmeEmployee;

		private global::Gtk.Label labelTotalHours;

		private global::ViewWidgets.WorkChartTable workcharttable;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Dialogs.Employees.EmployeeWorkChartDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Dialogs.Employees.EmployeeWorkChartDlg";
			// Container child Dialogs.Employees.EmployeeWorkChartDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
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
			this.vbox2.Add(this.hbox5);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox5]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.ylabel1 = new global::Gamma.GtkWidgets.yLabel();
			this.ylabel1.Name = "ylabel1";
			this.ylabel1.LabelProp = global::Mono.Unix.Catalog.GetString("Месяц:");
			this.hbox7.Add(this.ylabel1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.ylabel1]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.yenumcomboMonth = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumcomboMonth.Name = "yenumcomboMonth";
			this.yenumcomboMonth.ShowSpecialStateAll = false;
			this.yenumcomboMonth.ShowSpecialStateNot = false;
			this.yenumcomboMonth.UseShortTitle = false;
			this.yenumcomboMonth.DefaultFirst = false;
			this.hbox7.Add(this.yenumcomboMonth);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.yenumcomboMonth]));
			w7.Position = 1;
			this.vbox2.Add(this.hbox7);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox7]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Год:");
			this.hbox3.Add(this.label2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.label2]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.yspinYear = new global::Gamma.GtkWidgets.ySpinButton(1D, 5000D, 1D);
			this.yspinYear.CanFocus = true;
			this.yspinYear.Name = "yspinYear";
			this.yspinYear.Adjustment.PageIncrement = 10D;
			this.yspinYear.ClimbRate = 1D;
			this.yspinYear.Numeric = true;
			this.yspinYear.ValueAsDecimal = 0m;
			this.yspinYear.ValueAsInt = 0;
			this.hbox3.Add(this.yspinYear);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.yspinYear]));
			w10.Position = 1;
			this.vbox2.Add(this.hbox3);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox3]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Сотрудник:");
			this.hbox6.Add(this.label3);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.label3]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.evmeEmployee = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.evmeEmployee.Events = ((global::Gdk.EventMask)(256));
			this.evmeEmployee.Name = "evmeEmployee";
			this.evmeEmployee.CanEditReference = true;
			this.hbox6.Add(this.evmeEmployee);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.evmeEmployee]));
			w13.Position = 1;
			this.vbox2.Add(this.hbox6);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox6]));
			w14.Position = 3;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.labelTotalHours = new global::Gtk.Label();
			this.labelTotalHours.Name = "labelTotalHours";
			this.labelTotalHours.LabelProp = global::Mono.Unix.Catalog.GetString("Всего за месяц 0 часов");
			this.vbox2.Add(this.labelTotalHours);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.labelTotalHours]));
			w15.Position = 4;
			w15.Expand = false;
			w15.Fill = false;
			this.hbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.workcharttable = new global::ViewWidgets.WorkChartTable();
			this.workcharttable.Name = "workcharttable";
			this.workcharttable.Date = new global::System.DateTime(0);
			this.hbox1.Add(this.workcharttable);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.workcharttable]));
			w17.Position = 1;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w18.Position = 0;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonSave.Clicked += new global::System.EventHandler(this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler(this.OnButtonCancelClicked);
		}
	}
}
