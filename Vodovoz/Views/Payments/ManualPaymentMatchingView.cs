﻿using Gamma.ColumnConfig;
using QS.Views.GtkUI;
using Gtk;
using Vodovoz.Domain.Orders;
using QS.Project.Journal.EntitySelector;
using Vodovoz.Domain.Client;
using Vodovoz.Filters.ViewModels;
using System;
using QS.Navigation;
using Vodovoz.Infrastructure.Converters;
using QS.Project.Search.GtkUI;
using QS.Project.Search;
using Vodovoz.JournalViewModels;
using Vodovoz.ViewModels.ViewModels.Payments;

namespace Vodovoz.Views
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ManualPaymentMatchingView : TabViewBase<ManualPaymentMatchingViewModel>
	{
		public ManualPaymentMatchingView(ManualPaymentMatchingViewModel manualPaymentLoaderViewModel) : base(manualPaymentLoaderViewModel)
		{
			this.Build();
			Configure();
		}

		void Configure()
        {
            notebook1.ShowTabs = false;

            #region Radio buttons

            radioBtnAllocateOrders.Active = true;
            radioBtnAllocateOrders.Toggled += RadioBtnAllocateOrdersOnToggled;
            radioBtnAllocatedOrders.Toggled += RadioBtnAllocatedOrdersOnToggled;
			radioBtnAllocatedOrders.Sensitive = ViewModel.HasPaymentItems;

            #endregion

            btnSave.Clicked += (sender, args) => ViewModel.SaveViewModelCommand.Execute();
			btnCancel.Clicked += (sender, args) => ViewModel.Close(false, CloseSource.Cancel);
            buttonComplete.Clicked += (sender, args) => ViewModel.CompleteAllocationCommand.Execute();
            btnAddCounterparty.Clicked += (sender, args) => ViewModel.AddCounterpatyCommand.Execute();
			btnAddCounterparty.Binding
				.AddBinding(ViewModel, vm => vm.CounterpartyIsNull, w => w.Sensitive)
				.InitializeFromSource();
            ybtnRevertPayment.Clicked += (sender, args) => ViewModel.RevertAllocatedSum.Execute();
            ybtnRevertPayment.Binding.AddBinding(ViewModel, vm => vm.CanRevertPay, w => w.Sensitive).InitializeFromSource();

            daterangepicker1.Binding.AddBinding(ViewModel, vm => vm.StartDate, w => w.StartDateOrNull).InitializeFromSource();
            daterangepicker1.Binding.AddBinding(ViewModel, vm => vm.EndDate, w => w.EndDateOrNull).InitializeFromSource();
            daterangepicker1.PeriodChangedByUser += (sender, e) => ViewModel.UpdateNodes();
            yenumcomboOrderStatus.ItemsEnum = typeof(OrderStatus);
            yenumcomboOrderStatus.Binding.AddBinding(ViewModel, vm => vm.OrderStatusVM, w => w.SelectedItemOrNull).InitializeFromSource();
            yenumcomboOrderStatus.ChangedByUser += (sender, e) => ViewModel.UpdateNodes();
            yenumcomboOrderPaymentStatus.ItemsEnum = typeof(OrderPaymentStatus);
            yenumcomboOrderPaymentStatus.Binding.AddBinding(ViewModel, vm => vm.OrderPaymentStatusVM, w => w.SelectedItemOrNull).InitializeFromSource();
            yenumcomboOrderPaymentStatus.ChangedByUser += (sender, e) => ViewModel.UpdateNodes();

            labelTotalSum.Text = ViewModel.Entity.Total.ToString();
            labelLastBalance.Binding.AddBinding(ViewModel, vm => vm.LastBalance, w => w.Text, new DecimalToStringConverter()).InitializeFromSource();
            labelToAllocate.Binding.AddBinding(ViewModel, vm => vm.SumToAllocate, w => w.Text, new DecimalToStringConverter()).InitializeFromSource();

            ylabelCurBalance.Binding.AddBinding(ViewModel, vm => vm.CurrentBalance, v => v.Text, new DecimalToStringConverter()).InitializeFromSource();
            ylabelAllocated.Binding.AddBinding(ViewModel, vm => vm.AllocatedSum, v => v.Text, new DecimalToStringConverter()).InitializeFromSource();
            ylabelCounterpartyDebt.Binding.AddBinding(ViewModel, vm => vm.CounterpartyDebt, v => v.Text, new DecimalToStringConverter()).InitializeFromSource();

            labelPayer.Text = ViewModel.Entity.CounterpartyName;
            labelPaymentNum.Text = ViewModel.Entity.PaymentNum.ToString();
            labelDate.Text = ViewModel.Entity.Date.ToShortDateString();

            ytextviewPaymentPurpose.Buffer.Text = ViewModel.Entity.PaymentPurpose;
            ytextviewComments.Binding.AddBinding(ViewModel.Entity, vm => vm.Comment, v => v.Buffer.Text).InitializeFromSource();

            entryCounterparty.SetEntityAutocompleteSelectorFactory(
                new DefaultEntityAutocompleteSelectorFactory<Counterparty, CounterpartyJournalViewModel, CounterpartyJournalFilterViewModel>(QS.Project.Services.ServicesConfig.CommonServices));

            entryCounterparty.Binding.AddBinding(ViewModel.Entity, vm => vm.Counterparty, w => w.Subject).InitializeFromSource();
            entryCounterparty.ChangedByUser += (sender, e) =>
            {
                ViewModel.UpdateNodes();
                ViewModel.GetLastBalance();
				ViewModel.UpdateSumToAllocate();
				ViewModel.UpdateCurrentBalance();
                ViewModel.GetCounterpartyDebt();
            };

            var searchView = new SearchView((SearchViewModel)ViewModel.Search);
            hboxSearch.Add(searchView);
            searchView.Show();

            ConfigureTrees();
        }

        private void ConfigureTrees()
        {
            ytreeviewOrdersAllocate.ColumnsConfig = FluentColumnsConfig<ManualPaymentMatchingViewModelNode>.Create()
                .AddColumn("№ заказа")
                    .AddTextRenderer(node => node.Id.ToString())
                    .XAlign(0.5f)
                .AddColumn("Статус")
                    .AddEnumRenderer(node => node.OrderStatus)
                .AddColumn("Дата заказа")
                    .AddTextRenderer(node => node.OrderDate.ToShortDateString())
                    .XAlign(0.5f)
                .AddColumn("Сумма заказа, р.")
                    .AddTextRenderer(node => $"{node.ActualOrderSum}")
                    .XAlign(0.5f)
                .AddColumn("Прошлые оплаты, р.")
                    .AddNumericRenderer(node => node.LastPayments)
                    .Digits(2)
                .AddColumn("Текущая оплата, р.")
                    .AddNumericRenderer(node => node.CurrentPayment).Editing().Digits(2)
                    .Adjustment(new Adjustment(0, 0, 10000000, 1, 10, 10))
                    .AddSetter((node, cell) => ViewModel.CurrentPaymentChangedByUser(cell))
                .AddColumn("Статус оплаты")
                    .AddEnumRenderer(node => node.OrderPaymentStatus)
                .AddColumn("Рассчитать остаток?")
                    .AddToggleRenderer(node => node.Calculate)
                    .ToggledEvent(UseFine_Toggled)
                .AddColumn("")
                .Finish();

            ytreeviewOrdersAllocate.ItemsDataSource = ViewModel.ListNodes;
            ytreeviewOrdersAllocate.ButtonReleaseEvent += YtreeviewOrdersAllocate_ButtonReleaseEvent;

            yTreeViewAllocatedOrders.ColumnsConfig = FluentColumnsConfig<ManualPaymentMatchingViewModelAllocatedNode>.Create()
                .AddColumn("№ заказа")
                    .AddNumericRenderer(node => node.OrderId)
                    .XAlign(0.5f)
                .AddColumn("Статус")
                    .AddEnumRenderer(node => node.OrderStatus)
                .AddColumn("Дата заказа")
                    .AddTextRenderer(node => node.OrderDate.ToShortDateString())
                    .XAlign(0.5f)
                .AddColumn("Сумма заказа, р.")
                    .AddNumericRenderer(node => node.OrderSum)
					.Digits(2)
                    .XAlign(0.5f)
                .AddColumn("Полная сумма оплаты\n(в т.ч. с др платежей), р.")
                    .AddNumericRenderer(node => node.AllAllocatedSum)
                    .Digits(2)
                    .XAlign(0.5f)
                .AddColumn("Распределенная сумма\n(с этого платежа), р.")
					.AddNumericRenderer(node => node.AllocatedSum)
                    .Digits(2)
                    .XAlign(0.5f)
				.AddColumn("Статус оплаты")
                    .AddEnumRenderer(node => node.OrderPaymentStatus)
                    .XAlign(0.5f)
				.AddColumn("Статус распределения")
					.AddEnumRenderer(node => node.PaymentItemStatus)
					.XAlign(0.5f)
                .AddColumn("")
                .Finish();

            yTreeViewAllocatedOrders.ItemsDataSource = ViewModel.ListAllocatedNodes;
            yTreeViewAllocatedOrders.Binding
				.AddSource(ViewModel)
				.AddBinding(vm => vm.CanRevertPayFromOrderPermission, w => w.Sensitive)
				.AddBinding(vm => vm.SelectedAllocatedNode, w => w.SelectedRow)
				.InitializeFromSource();
		}

		#region Переключение вкладок

        private void RadioBtnAllocateOrdersOnToggled(object sender, EventArgs e) {
			if (radioBtnAllocateOrders.Active)
				notebook1.CurrentPage = 0;
		}
		
		private void RadioBtnAllocatedOrdersOnToggled(object sender, EventArgs e) {
			if (radioBtnAllocatedOrders.Active)
				notebook1.CurrentPage = 1;
		}

		#endregion
		
		private void UseFine_Toggled(object o, ToggledArgs args) =>
			//Вызываем через Application.Invoke чтобы событие вызывалось уже после того как поле обновилось.
			Application.Invoke((sender, eventArgs) => OnToggleClicked(this, EventArgs.Empty));

		private void OnToggleClicked(object sender, EventArgs e)
		{
			var selectedObj = ytreeviewOrdersAllocate.GetSelectedObject();

			if(selectedObj == null)
				return;

			var node = selectedObj as ManualPaymentMatchingViewModelNode;

			if(node.Calculate)
				ViewModel.Calculate(node);
			else
				ViewModel.ReCalculate(node);
		}

		private void YtreeviewOrdersAllocate_ButtonReleaseEvent(object o, ButtonReleaseEventArgs args)
		{
			if(args.Event.Button == 3)
				ConfigureMenu();
		}

		private void ConfigureMenu()
		{
			var selectedObj = ytreeviewOrdersAllocate.GetSelectedObject();

			if(selectedObj == null)
				return;

			var order = ViewModel.UoW.GetById<Order>((selectedObj as ManualPaymentMatchingViewModelNode).Id);

			var menu = new Menu();

			var openOrder = new MenuItem($"Открыть заказ №{order.Id}");
			openOrder.Activated += (s, args) => ViewModel.OpenOrderCommand.Execute(order);
			openOrder.Visible = true;
			menu.Add(openOrder);

			menu.ShowAll();
			menu.Popup();
		}
	}
}
