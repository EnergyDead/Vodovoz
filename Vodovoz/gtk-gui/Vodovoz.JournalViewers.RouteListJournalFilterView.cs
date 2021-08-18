
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz.JournalViewers
{
	public partial class RouteListJournalFilterView
	{
		private global::Gtk.Table table1;

		private global::Gtk.Button buttonStatusAll;

		private global::Gtk.Button buttonStatusNone;

		private global::Gamma.GtkWidgets.yCheckButton checkDriversWithAttachedTerminals;

		private global::QS.Widgets.GtkUI.DateRangePicker dateperiodOrders;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewRouteListStatuses;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gamma.Widgets.yEntryReference yentryreferenceShift;

		private global::Gamma.Widgets.yEnumComboBox yEnumCmbTransport;

		private global::Gamma.Widgets.ySpecComboBox ySpecCmbGeographicGroup;

		private global::Gamma.GtkWidgets.yTreeView ytreeviewAddressTypes;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.JournalViewers.RouteListJournalFilterView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.JournalViewers.RouteListJournalFilterView";
			// Container child Vodovoz.JournalViewers.RouteListJournalFilterView.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(2)), ((uint)(8)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.buttonStatusAll = new global::Gtk.Button();
			this.buttonStatusAll.CanFocus = true;
			this.buttonStatusAll.Name = "buttonStatusAll";
			this.buttonStatusAll.UseUnderline = true;
			this.buttonStatusAll.Label = global::Mono.Unix.Catalog.GetString("Выбрать все");
			this.table1.Add(this.buttonStatusAll);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.buttonStatusAll]));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.buttonStatusNone = new global::Gtk.Button();
			this.buttonStatusNone.CanFocus = true;
			this.buttonStatusNone.Name = "buttonStatusNone";
			this.buttonStatusNone.UseUnderline = true;
			this.buttonStatusNone.Label = global::Mono.Unix.Catalog.GetString("Снять выбор");
			this.table1.Add(this.buttonStatusNone);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.buttonStatusNone]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.checkDriversWithAttachedTerminals = new global::Gamma.GtkWidgets.yCheckButton();
			this.checkDriversWithAttachedTerminals.TooltipMarkup = "Будут показаны только те МЛ, к водителям которых привязан терминал";
			this.checkDriversWithAttachedTerminals.CanFocus = true;
			this.checkDriversWithAttachedTerminals.Name = "checkDriversWithAttachedTerminals";
			this.checkDriversWithAttachedTerminals.Label = global::Mono.Unix.Catalog.GetString("Показывать МЛ водителей с терминалами");
			this.checkDriversWithAttachedTerminals.DrawIndicator = true;
			this.checkDriversWithAttachedTerminals.UseUnderline = true;
			this.table1.Add(this.checkDriversWithAttachedTerminals);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.checkDriversWithAttachedTerminals]));
			w3.LeftAttach = ((uint)(7));
			w3.RightAttach = ((uint)(8));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.dateperiodOrders = new global::QS.Widgets.GtkUI.DateRangePicker();
			this.dateperiodOrders.Events = ((global::Gdk.EventMask)(256));
			this.dateperiodOrders.Name = "dateperiodOrders";
			this.dateperiodOrders.StartDate = new global::System.DateTime(0);
			this.dateperiodOrders.EndDate = new global::System.DateTime(0);
			this.table1.Add(this.dateperiodOrders);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.dateperiodOrders]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.LeftAttach = ((uint)(3));
			w4.RightAttach = ((uint)(4));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.WidthRequest = 220;
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.ytreeviewRouteListStatuses = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewRouteListStatuses.CanFocus = true;
			this.ytreeviewRouteListStatuses.Name = "ytreeviewRouteListStatuses";
			this.ytreeviewRouteListStatuses.HeadersVisible = false;
			this.GtkScrolledWindow.Add(this.ytreeviewRouteListStatuses);
			this.table1.Add(this.GtkScrolledWindow);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.GtkScrolledWindow]));
			w6.BottomAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(0));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Смена:");
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.LeftAttach = ((uint)(4));
			w7.RightAttach = ((uint)(5));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Район города:");
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w8.LeftAttach = ((uint)(2));
			w8.RightAttach = ((uint)(3));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Период:");
			this.table1.Add(this.label4);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.label4]));
			w9.TopAttach = ((uint)(1));
			w9.BottomAttach = ((uint)(2));
			w9.LeftAttach = ((uint)(2));
			w9.RightAttach = ((uint)(3));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Тип ТС:");
			this.table1.Add(this.label5);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.label5]));
			w10.LeftAttach = ((uint)(4));
			w10.RightAttach = ((uint)(5));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yentryreferenceShift = new global::Gamma.Widgets.yEntryReference();
			this.yentryreferenceShift.Events = ((global::Gdk.EventMask)(256));
			this.yentryreferenceShift.Name = "yentryreferenceShift";
			this.table1.Add(this.yentryreferenceShift);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.yentryreferenceShift]));
			w11.TopAttach = ((uint)(1));
			w11.BottomAttach = ((uint)(2));
			w11.LeftAttach = ((uint)(5));
			w11.RightAttach = ((uint)(6));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.yEnumCmbTransport = new global::Gamma.Widgets.yEnumComboBox();
			this.yEnumCmbTransport.Name = "yEnumCmbTransport";
			this.yEnumCmbTransport.ShowSpecialStateAll = true;
			this.yEnumCmbTransport.ShowSpecialStateNot = false;
			this.yEnumCmbTransport.UseShortTitle = false;
			this.yEnumCmbTransport.DefaultFirst = false;
			this.table1.Add(this.yEnumCmbTransport);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.yEnumCmbTransport]));
			w12.LeftAttach = ((uint)(5));
			w12.RightAttach = ((uint)(6));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ySpecCmbGeographicGroup = new global::Gamma.Widgets.ySpecComboBox();
			this.ySpecCmbGeographicGroup.Name = "ySpecCmbGeographicGroup";
			this.ySpecCmbGeographicGroup.AddIfNotExist = false;
			this.ySpecCmbGeographicGroup.DefaultFirst = false;
			this.ySpecCmbGeographicGroup.ShowSpecialStateAll = true;
			this.ySpecCmbGeographicGroup.ShowSpecialStateNot = false;
			this.table1.Add(this.ySpecCmbGeographicGroup);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.ySpecCmbGeographicGroup]));
			w13.LeftAttach = ((uint)(3));
			w13.RightAttach = ((uint)(4));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.ytreeviewAddressTypes = new global::Gamma.GtkWidgets.yTreeView();
			this.ytreeviewAddressTypes.CanFocus = true;
			this.ytreeviewAddressTypes.Name = "ytreeviewAddressTypes";
			this.ytreeviewAddressTypes.HeadersVisible = false;
			this.table1.Add(this.ytreeviewAddressTypes);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.ytreeviewAddressTypes]));
			w14.BottomAttach = ((uint)(2));
			w14.LeftAttach = ((uint)(6));
			w14.RightAttach = ((uint)(7));
			w14.XOptions = ((global::Gtk.AttachOptions)(0));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.ySpecCmbGeographicGroup.ItemSelected += new global::System.EventHandler<Gamma.Widgets.ItemSelectedEventArgs>(this.OnYSpecCmbGeographicGroupItemSelected);
			this.yEnumCmbTransport.ChangedByUser += new global::System.EventHandler(this.OnYEnumCmbTransportChangedByUser);
			this.yentryreferenceShift.ChangedByUser += new global::System.EventHandler(this.OnYentryreferenceShiftChangedByUser);
			this.dateperiodOrders.PeriodChangedByUser += new global::System.EventHandler(this.OnDateperiodOrdersPeriodChangedByUser);
			this.buttonStatusNone.Clicked += new global::System.EventHandler(this.OnButtonStatusNoneActivated);
			this.buttonStatusAll.Clicked += new global::System.EventHandler(this.OnButtonStatusAllActivated);
		}
	}
}
