
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.ReportsParameters.Sales
{
	public partial class SalaryRatesReport
	{
		private global::Gtk.HBox hbox2;

		private global::Gtk.VBox vbox1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView treeViewSalaryProperties;

		private global::Gtk.Button buttonCreateReport;

		private global::Gtk.VBox vbox2;

		private global::Gamma.GtkWidgets.yButton ycheckAll;

		private global::Gamma.GtkWidgets.yButton yUnCheckAll;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.ReportsParameters.Sales.SalaryRatesReport
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.ReportsParameters.Sales.SalaryRatesReport";
			// Container child Vodovoz.ReportsParameters.Sales.SalaryRatesReport.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.WidthRequest = 500;
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeViewSalaryProperties = new global::Gamma.GtkWidgets.yTreeView();
			this.treeViewSalaryProperties.CanFocus = true;
			this.treeViewSalaryProperties.Name = "treeViewSalaryProperties";
			this.GtkScrolledWindow.Add(this.treeViewSalaryProperties);
			this.vbox1.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child vbox1.Gtk.Box+BoxChild
			this.buttonCreateReport = new global::Gtk.Button();
			this.buttonCreateReport.CanFocus = true;
			this.buttonCreateReport.Name = "buttonCreateReport";
			this.buttonCreateReport.UseUnderline = true;
			this.buttonCreateReport.Label = global::Mono.Unix.Catalog.GetString("Сформировать отчет");
			this.vbox1.Add(this.buttonCreateReport);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.buttonCreateReport]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.hbox2.Add(this.vbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox1]));
			w4.Position = 0;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.ycheckAll = new global::Gamma.GtkWidgets.yButton();
			this.ycheckAll.CanFocus = true;
			this.ycheckAll.Name = "ycheckAll";
			this.ycheckAll.UseUnderline = true;
			this.ycheckAll.Label = global::Mono.Unix.Catalog.GetString(" Выбрать всё");
			this.vbox2.Add(this.ycheckAll);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.ycheckAll]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.yUnCheckAll = new global::Gamma.GtkWidgets.yButton();
			this.yUnCheckAll.CanFocus = true;
			this.yUnCheckAll.Name = "yUnCheckAll";
			this.yUnCheckAll.UseUnderline = true;
			this.yUnCheckAll.Label = global::Mono.Unix.Catalog.GetString("Снять выбор");
			this.vbox2.Add(this.yUnCheckAll);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.yUnCheckAll]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			this.hbox2.Add(this.vbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.vbox2]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.Add(this.hbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonCreateReport.Clicked += new global::System.EventHandler(this.OnButtonCreateReportClicked);
			this.ycheckAll.Clicked += new global::System.EventHandler(this.OnYcheckAllClicked);
			this.yUnCheckAll.Clicked += new global::System.EventHandler(this.OnYUnCheckAllClicked);
		}
	}
}
