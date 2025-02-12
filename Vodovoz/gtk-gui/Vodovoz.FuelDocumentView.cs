
// This file has been generated by the GUI designer. Do not modify.
namespace Vodovoz
{
	public partial class FuelDocumentView
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox8;

		private global::Gamma.GtkWidgets.yButton buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Table table3;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry entityviewmodelentryCar;

		private global::QS.Widgets.GtkUI.EntityViewModelEntry evmeDriver;

		private global::Gtk.HBox hbox3;

		private global::Gamma.GtkWidgets.ySpinButton spinFuelPrice;

		private global::Gtk.HBox hbox4;

		private global::Gamma.Widgets.yEnumComboBox yenumcomboboxPaymentType;

		private global::QSOrmProject.DisableSpinButton disablespinMoney;

		private global::Gamma.GtkWidgets.yButton buttonSetRemain;

		private global::Gtk.HBox hbox5;

		private global::Gtk.HBox hbox6;

		private global::Gamma.GtkWidgets.ySpinButton yspinFuelTicketLiters;

		private global::Gamma.Widgets.ySpecComboBox yspeccomboboxSubdivision;

		private global::Gtk.HBox hbox7;

		private global::Gamma.GtkWidgets.yLabel labelExpenseInfo;

		private global::Gamma.GtkWidgets.yButton buttonOpenExpense;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gtk.Label label6;

		private global::Gtk.Label label7;

		private global::Gamma.GtkWidgets.yLabel labelAvalilableFuel;

		private global::Gamma.GtkWidgets.yLabel labelResultInfo;

		private global::QS.Widgets.GtkUI.DatePicker ydatepicker;

		private global::Gamma.Widgets.yEntryReference yentryfuel;

		private global::Gamma.GtkWidgets.yTextView ytextviewFuelInfo;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Vodovoz.FuelDocumentView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "Vodovoz.FuelDocumentView";
			// Container child Vodovoz.FuelDocumentView.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.buttonSave = new global::Gamma.GtkWidgets.yButton();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox8.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox8.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox8[this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add(this.hbox8);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox8]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.table3 = new global::Gtk.Table(((uint)(9)), ((uint)(3)), false);
			this.table3.Name = "table3";
			this.table3.RowSpacing = ((uint)(6));
			this.table3.ColumnSpacing = ((uint)(6));
			// Container child table3.Gtk.Table+TableChild
			this.entityviewmodelentryCar = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.entityviewmodelentryCar.Sensitive = false;
			this.entityviewmodelentryCar.Events = ((global::Gdk.EventMask)(256));
			this.entityviewmodelentryCar.Name = "entityviewmodelentryCar";
			this.entityviewmodelentryCar.CanEditReference = true;
			this.table3.Add(this.entityviewmodelentryCar);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table3[this.entityviewmodelentryCar]));
			w6.TopAttach = ((uint)(2));
			w6.BottomAttach = ((uint)(3));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.evmeDriver = new global::QS.Widgets.GtkUI.EntityViewModelEntry();
			this.evmeDriver.Sensitive = false;
			this.evmeDriver.Events = ((global::Gdk.EventMask)(256));
			this.evmeDriver.Name = "evmeDriver";
			this.evmeDriver.CanEditReference = true;
			this.table3.Add(this.evmeDriver);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table3[this.evmeDriver]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.hbox3 = new global::Gtk.HBox();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.spinFuelPrice = new global::Gamma.GtkWidgets.ySpinButton(0D, 200D, 0.01D);
			this.spinFuelPrice.WidthRequest = 100;
			this.spinFuelPrice.Sensitive = false;
			this.spinFuelPrice.CanFocus = true;
			this.spinFuelPrice.Name = "spinFuelPrice";
			this.spinFuelPrice.Adjustment.PageIncrement = 0.01D;
			this.spinFuelPrice.ClimbRate = 1D;
			this.spinFuelPrice.Digits = ((uint)(2));
			this.spinFuelPrice.Numeric = true;
			this.spinFuelPrice.ValueAsDecimal = 0m;
			this.spinFuelPrice.ValueAsInt = 0;
			this.hbox3.Add(this.spinFuelPrice);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.spinFuelPrice]));
			w8.Position = 0;
			w8.Expand = false;
			w8.Fill = false;
			this.table3.Add(this.hbox3);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table3[this.hbox3]));
			w9.TopAttach = ((uint)(6));
			w9.BottomAttach = ((uint)(7));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.yenumcomboboxPaymentType = new global::Gamma.Widgets.yEnumComboBox();
			this.yenumcomboboxPaymentType.Name = "yenumcomboboxPaymentType";
			this.yenumcomboboxPaymentType.ShowSpecialStateAll = false;
			this.yenumcomboboxPaymentType.ShowSpecialStateNot = false;
			this.yenumcomboboxPaymentType.UseShortTitle = false;
			this.yenumcomboboxPaymentType.DefaultFirst = false;
			this.hbox4.Add(this.yenumcomboboxPaymentType);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.yenumcomboboxPaymentType]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.disablespinMoney = new global::QSOrmProject.DisableSpinButton();
			this.disablespinMoney.Events = ((global::Gdk.EventMask)(256));
			this.disablespinMoney.Name = "disablespinMoney";
			this.disablespinMoney.Active = false;
			this.disablespinMoney.Upper = 100000D;
			this.disablespinMoney.Lower = 0D;
			this.disablespinMoney.Digits = ((uint)(2));
			this.hbox4.Add(this.disablespinMoney);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.disablespinMoney]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonSetRemain = new global::Gamma.GtkWidgets.yButton();
			this.buttonSetRemain.CanFocus = true;
			this.buttonSetRemain.Name = "buttonSetRemain";
			this.buttonSetRemain.UseUnderline = true;
			this.buttonSetRemain.Label = global::Mono.Unix.Catalog.GetString("Весь остаток");
			this.hbox4.Add(this.buttonSetRemain);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonSetRemain]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			this.table3.Add(this.hbox4);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table3[this.hbox4]));
			w13.TopAttach = ((uint)(7));
			w13.BottomAttach = ((uint)(8));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.hbox5 = new global::Gtk.HBox();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			this.table3.Add(this.hbox5);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table3[this.hbox5]));
			w14.TopAttach = ((uint)(6));
			w14.BottomAttach = ((uint)(7));
			w14.LeftAttach = ((uint)(2));
			w14.RightAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.hbox6 = new global::Gtk.HBox();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.yspinFuelTicketLiters = new global::Gamma.GtkWidgets.ySpinButton(0D, 1000D, 10D);
			this.yspinFuelTicketLiters.WidthRequest = 90;
			this.yspinFuelTicketLiters.CanFocus = true;
			this.yspinFuelTicketLiters.Name = "yspinFuelTicketLiters";
			this.yspinFuelTicketLiters.Adjustment.PageIncrement = 20D;
			this.yspinFuelTicketLiters.ClimbRate = 1D;
			this.yspinFuelTicketLiters.Numeric = true;
			this.yspinFuelTicketLiters.ValueAsDecimal = 0m;
			this.yspinFuelTicketLiters.ValueAsInt = 0;
			this.hbox6.Add(this.yspinFuelTicketLiters);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.yspinFuelTicketLiters]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.yspeccomboboxSubdivision = new global::Gamma.Widgets.ySpecComboBox();
			this.yspeccomboboxSubdivision.Name = "yspeccomboboxSubdivision";
			this.yspeccomboboxSubdivision.AddIfNotExist = false;
			this.yspeccomboboxSubdivision.DefaultFirst = false;
			this.yspeccomboboxSubdivision.ShowSpecialStateAll = false;
			this.yspeccomboboxSubdivision.ShowSpecialStateNot = false;
			this.hbox6.Add(this.yspeccomboboxSubdivision);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox6[this.yspeccomboboxSubdivision]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			this.table3.Add(this.hbox6);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table3[this.hbox6]));
			w17.TopAttach = ((uint)(4));
			w17.BottomAttach = ((uint)(5));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(2));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.hbox7 = new global::Gtk.HBox();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.labelExpenseInfo = new global::Gamma.GtkWidgets.yLabel();
			this.labelExpenseInfo.Name = "labelExpenseInfo";
			this.labelExpenseInfo.LabelProp = global::Mono.Unix.Catalog.GetString("ylabel1");
			this.hbox7.Add(this.labelExpenseInfo);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.labelExpenseInfo]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.buttonOpenExpense = new global::Gamma.GtkWidgets.yButton();
			this.buttonOpenExpense.CanFocus = true;
			this.buttonOpenExpense.Name = "buttonOpenExpense";
			this.buttonOpenExpense.UseUnderline = true;
			this.buttonOpenExpense.Label = global::Mono.Unix.Catalog.GetString("Открыть расходный ордер");
			this.hbox7.Add(this.buttonOpenExpense);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox7[this.buttonOpenExpense]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			this.table3.Add(this.hbox7);
			global::Gtk.Table.TableChild w20 = ((global::Gtk.Table.TableChild)(this.table3[this.hbox7]));
			w20.TopAttach = ((uint)(8));
			w20.BottomAttach = ((uint)(9));
			w20.LeftAttach = ((uint)(1));
			w20.RightAttach = ((uint)(2));
			w20.XOptions = ((global::Gtk.AttachOptions)(4));
			w20.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Дата:");
			this.table3.Add(this.label1);
			global::Gtk.Table.TableChild w21 = ((global::Gtk.Table.TableChild)(this.table3[this.label1]));
			w21.XOptions = ((global::Gtk.AttachOptions)(4));
			w21.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Водитель:");
			this.table3.Add(this.label2);
			global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.table3[this.label2]));
			w22.TopAttach = ((uint)(1));
			w22.BottomAttach = ((uint)(2));
			w22.XOptions = ((global::Gtk.AttachOptions)(4));
			w22.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Вид топлива:");
			this.table3.Add(this.label3);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.table3[this.label3]));
			w23.TopAttach = ((uint)(3));
			w23.BottomAttach = ((uint)(4));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Автомобиль:");
			this.table3.Add(this.label4);
			global::Gtk.Table.TableChild w24 = ((global::Gtk.Table.TableChild)(this.table3[this.label4]));
			w24.TopAttach = ((uint)(2));
			w24.BottomAttach = ((uint)(3));
			w24.XOptions = ((global::Gtk.AttachOptions)(4));
			w24.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Выдано деньгами:");
			this.table3.Add(this.label5);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.table3[this.label5]));
			w25.TopAttach = ((uint)(7));
			w25.BottomAttach = ((uint)(8));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Выдано талонами(л):");
			this.table3.Add(this.label6);
			global::Gtk.Table.TableChild w26 = ((global::Gtk.Table.TableChild)(this.table3[this.label6]));
			w26.TopAttach = ((uint)(4));
			w26.BottomAttach = ((uint)(5));
			w26.XOptions = ((global::Gtk.AttachOptions)(4));
			w26.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 1F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Стоимость, р/литр:");
			this.table3.Add(this.label7);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.table3[this.label7]));
			w27.TopAttach = ((uint)(6));
			w27.BottomAttach = ((uint)(7));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.labelAvalilableFuel = new global::Gamma.GtkWidgets.yLabel();
			this.labelAvalilableFuel.Name = "labelAvalilableFuel";
			this.labelAvalilableFuel.Xalign = 0F;
			this.labelAvalilableFuel.LabelProp = global::Mono.Unix.Catalog.GetString("label1");
			this.table3.Add(this.labelAvalilableFuel);
			global::Gtk.Table.TableChild w28 = ((global::Gtk.Table.TableChild)(this.table3[this.labelAvalilableFuel]));
			w28.TopAttach = ((uint)(5));
			w28.BottomAttach = ((uint)(6));
			w28.LeftAttach = ((uint)(1));
			w28.RightAttach = ((uint)(2));
			w28.XOptions = ((global::Gtk.AttachOptions)(4));
			w28.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.labelResultInfo = new global::Gamma.GtkWidgets.yLabel();
			this.labelResultInfo.Name = "labelResultInfo";
			this.labelResultInfo.LabelProp = global::Mono.Unix.Catalog.GetString("Итог");
			this.table3.Add(this.labelResultInfo);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.table3[this.labelResultInfo]));
			w29.TopAttach = ((uint)(7));
			w29.BottomAttach = ((uint)(8));
			w29.LeftAttach = ((uint)(2));
			w29.RightAttach = ((uint)(3));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.ydatepicker = new global::QS.Widgets.GtkUI.DatePicker();
			this.ydatepicker.Events = ((global::Gdk.EventMask)(256));
			this.ydatepicker.Name = "ydatepicker";
			this.ydatepicker.WithTime = false;
			this.ydatepicker.HideCalendarButton = false;
			this.ydatepicker.Date = new global::System.DateTime(0);
			this.ydatepicker.IsEditable = true;
			this.ydatepicker.AutoSeparation = false;
			this.table3.Add(this.ydatepicker);
			global::Gtk.Table.TableChild w30 = ((global::Gtk.Table.TableChild)(this.table3[this.ydatepicker]));
			w30.LeftAttach = ((uint)(1));
			w30.RightAttach = ((uint)(2));
			w30.XOptions = ((global::Gtk.AttachOptions)(4));
			w30.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.yentryfuel = new global::Gamma.Widgets.yEntryReference();
			this.yentryfuel.Sensitive = false;
			this.yentryfuel.Events = ((global::Gdk.EventMask)(256));
			this.yentryfuel.Name = "yentryfuel";
			this.table3.Add(this.yentryfuel);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.table3[this.yentryfuel]));
			w31.TopAttach = ((uint)(3));
			w31.BottomAttach = ((uint)(4));
			w31.LeftAttach = ((uint)(1));
			w31.RightAttach = ((uint)(2));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.ytextviewFuelInfo = new global::Gamma.GtkWidgets.yTextView();
			this.ytextviewFuelInfo.CanFocus = true;
			this.ytextviewFuelInfo.Name = "ytextviewFuelInfo";
			this.ytextviewFuelInfo.Editable = false;
			this.table3.Add(this.ytextviewFuelInfo);
			global::Gtk.Table.TableChild w32 = ((global::Gtk.Table.TableChild)(this.table3[this.ytextviewFuelInfo]));
			w32.BottomAttach = ((uint)(4));
			w32.LeftAttach = ((uint)(2));
			w32.RightAttach = ((uint)(3));
			w32.XOptions = ((global::Gtk.AttachOptions)(4));
			w32.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add(this.table3);
			global::Gtk.Box.BoxChild w33 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.table3]));
			w33.Position = 1;
			w33.Expand = false;
			w33.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.buttonSave.Clicked += new global::System.EventHandler(this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler(this.OnButtonCancelClicked);
			this.buttonOpenExpense.Clicked += new global::System.EventHandler(this.OnButtonOpenExpenseClicked);
			this.disablespinMoney.ValueChanged += new global::System.EventHandler(this.OnDisablespinMoneyValueChanged);
			this.buttonSetRemain.Clicked += new global::System.EventHandler(this.OnButtonSetRemainClicked);
		}
	}
}
