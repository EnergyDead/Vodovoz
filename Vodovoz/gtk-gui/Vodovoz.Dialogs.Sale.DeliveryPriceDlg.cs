﻿
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.Dialogs.Sale
{
	public partial class DeliveryPriceDlg
	{
		private global::Gtk.HBox hbox1;

		private global::Gtk.Table datatable1;

		private global::VodovozFiasWidgets.HouseEntry entryBuilding;

		private global::VodovozFiasWidgets.CityEntry entryCity;

		private global::VodovozFiasWidgets.StreetEntry entryStreet;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Vodovoz.ViewWidgets.DeliveryPriceView deliverypriceview;

		private global::Gtk.HBox hbox7;

		private global::Gamma.GtkWidgets.yLabel ylabelFoundOnOsm;

		private global::Gtk.Button buttonInsertFromBuffer;

		private global::Gtk.Label label1;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gtk.Label label6;

		private global::Gtk.Label label7;

		private global::Gamma.GtkWidgets.ySpinButton yspinBottles;

		private global::Gtk.VBox vbox3;

		private global::Gamma.Widgets.yEnumComboBox yenumcomboMapType;

		private global::GMap.NET.GtkSharp.GMapControl MapWidget;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.Dialogs.Sale.DeliveryPriceDlg
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.Dialogs.Sale.DeliveryPriceDlg";
			// Container child Vodovoz.Dialogs.Sale.DeliveryPriceDlg.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.datatable1 = new global::Gtk.Table(((uint)(6)), ((uint)(2)), false);
			this.datatable1.Name = "datatable1";
			this.datatable1.RowSpacing = ((uint)(6));
			this.datatable1.ColumnSpacing = ((uint)(6));
			this.datatable1.BorderWidth = ((uint)(6));
			// Container child datatable1.Gtk.Table+TableChild
			this.entryBuilding = new global::VodovozFiasWidgets.HouseEntry();
			this.entryBuilding.CanFocus = true;
			this.entryBuilding.Name = "entryBuilding";
			this.entryBuilding.IsEditable = true;
			this.entryBuilding.WidthChars = 20;
			this.entryBuilding.MaxLength = 20;
			this.entryBuilding.InvisibleChar = '●';
			this.datatable1.Add(this.entryBuilding);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.datatable1[this.entryBuilding]));
			w1.TopAttach = ((uint)(2));
			w1.BottomAttach = ((uint)(3));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.entryCity = new global::VodovozFiasWidgets.CityEntry();
			this.entryCity.CanFocus = true;
			this.entryCity.Name = "entryCity";
			this.entryCity.IsEditable = true;
			this.entryCity.InvisibleChar = '●';
			this.datatable1.Add(this.entryCity);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.datatable1[this.entryCity]));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.entryStreet = new global::VodovozFiasWidgets.StreetEntry();
			this.entryStreet.CanFocus = true;
			this.entryStreet.Name = "entryStreet";
			this.entryStreet.IsEditable = true;
			this.entryStreet.InvisibleChar = '●';
			this.datatable1.Add(this.entryStreet);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.datatable1[this.entryStreet]));
			w3.TopAttach = ((uint)(1));
			w3.BottomAttach = ((uint)(2));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			global::Gtk.Viewport w4 = new global::Gtk.Viewport();
			w4.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.deliverypriceview = new global::Vodovoz.ViewWidgets.DeliveryPriceView();
			this.deliverypriceview.Events = ((global::Gdk.EventMask)(256));
			this.deliverypriceview.Name = "deliverypriceview";
			w4.Add(this.deliverypriceview);
			this.GtkScrolledWindow.Add(w4);
			this.datatable1.Add(this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.datatable1[this.GtkScrolledWindow]));
			w7.TopAttach = ((uint)(5));
			w7.BottomAttach = ((uint)(6));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.ylabelFoundOnOsm = new global::Gamma.GtkWidgets.yLabel();
			this.ylabelFoundOnOsm.Name = "ylabelFoundOnOsm";
			this.ylabelFoundOnOsm.LabelProp = global::Mono.Unix.Catalog.GetString("нет координат");
			this.ylabelFoundOnOsm.UseMarkup = true;
			this.ylabelFoundOnOsm.Selectable = true;
			this.hbox7.Add(this.ylabelFoundOnOsm);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.ylabelFoundOnOsm]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonInsertFromBuffer = new global::Gtk.Button();
			this.buttonInsertFromBuffer.CanFocus = true;
			this.buttonInsertFromBuffer.Name = "buttonInsertFromBuffer";
			this.buttonInsertFromBuffer.UseUnderline = true;
			this.buttonInsertFromBuffer.Label = global::Mono.Unix.Catalog.GetString("Вставить из буфера обмена");
			this.hbox7.Add(this.buttonInsertFromBuffer);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.buttonInsertFromBuffer]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			this.datatable1.Add(this.hbox7);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.datatable1[this.hbox7]));
			w10.TopAttach = ((uint)(3));
			w10.BottomAttach = ((uint)(4));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Координаты:");
			this.datatable1.Add(this.label1);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label1]));
			w11.TopAttach = ((uint)(3));
			w11.BottomAttach = ((uint)(4));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Город:");
			this.datatable1.Add(this.label4);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label4]));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Количество бутылей:");
			this.datatable1.Add(this.label5);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label5]));
			w13.TopAttach = ((uint)(4));
			w13.BottomAttach = ((uint)(5));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Улица:");
			this.datatable1.Add(this.label6);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label6]));
			w14.TopAttach = ((uint)(1));
			w14.BottomAttach = ((uint)(2));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Дом:");
			this.datatable1.Add(this.label7);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label7]));
			w15.TopAttach = ((uint)(2));
			w15.BottomAttach = ((uint)(3));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.yspinBottles = new global::Gamma.GtkWidgets.ySpinButton(1D, 1000D, 1D);
			this.yspinBottles.CanFocus = true;
			this.yspinBottles.Name = "yspinBottles";
			this.yspinBottles.Adjustment.PageIncrement = 10D;
			this.yspinBottles.ClimbRate = 1D;
			this.yspinBottles.Numeric = true;
			this.yspinBottles.Value = 1D;
			this.yspinBottles.ValueAsDecimal = 0m;
			this.yspinBottles.ValueAsInt = 0;
			this.datatable1.Add(this.yspinBottles);
			global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.datatable1[this.yspinBottles]));
			w16.TopAttach = ((uint)(4));
			w16.BottomAttach = ((uint)(5));
			w16.LeftAttach = ((uint)(1));
			w16.RightAttach = ((uint)(2));
			w16.XOptions = ((global::Gtk.AttachOptions)(4));
			w16.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hbox1.Add(this.datatable1);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.datatable1]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.yenumcomboMapType = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumcomboMapType.Name = "yenumcomboMapType";
			this.yenumcomboMapType.ShowSpecialStateAll = false;
			this.yenumcomboMapType.ShowSpecialStateNot = false;
			this.yenumcomboMapType.UseShortTitle = false;
			this.yenumcomboMapType.DefaultFirst = true;
			this.vbox3.Add(this.yenumcomboMapType);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.yenumcomboMapType]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.MapWidget = new global::GMap.NET.GtkSharp.GMapControl();
			this.MapWidget.Name = "MapWidget";
			this.MapWidget.MaxZoom = 24;
			this.MapWidget.MinZoom = 0;
			this.MapWidget.MouseWheelZoomEnabled = true;
			this.MapWidget.ShowTileGridLines = false;
			this.MapWidget.GrayScaleMode = false;
			this.MapWidget.NegativeMode = false;
			this.MapWidget.HasFrame = true;
			this.MapWidget.Bearing = 0F;
			this.MapWidget.Zoom = 9D;
			this.MapWidget.RoutesEnabled = false;
			this.MapWidget.PolygonsEnabled = false;
			this.MapWidget.MarkersEnabled = true;
			this.MapWidget.CanDragMap = true;
			this.vbox3.Add(this.MapWidget);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.MapWidget]));
			w19.Position = 1;
			this.hbox1.Add(this.vbox3);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox3]));
			w20.Position = 1;
			this.Add(this.hbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.yspinBottles.ValueChanged += new global::System.EventHandler(this.OnYspinBottlesValueChanged);
			this.buttonInsertFromBuffer.Clicked += new global::System.EventHandler(this.OnButtonInsertFromBufferClicked);
		}
	}
}
