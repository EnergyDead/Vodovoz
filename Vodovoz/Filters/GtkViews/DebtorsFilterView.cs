﻿using System;
using QS.Views.GtkUI;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Orders;
using Vodovoz.Filters.ViewModels;
using Vodovoz.Infrastructure.Converters;

namespace Vodovoz.Filters.GtkViews
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class DebtorsFilterView : FilterViewBase<DebtorsJournalFilterViewModel>
	{
		public DebtorsFilterView(DebtorsJournalFilterViewModel filterViewModel) : base(filterViewModel)
		{
			this.Build();
			Configure();
		}

		private void Configure()
		{
			entryreferenceClient.SetEntityAutocompleteSelectorFactory(ViewModel.CounterpartySelectorFactory);
			entityVMEntryDeliveryPoint.SetEntityAutocompleteSelectorFactory(ViewModel.DeliveryPointSelectorFactory);
			entityviewmodelentryNomenclature.SetEntityAutocompleteSelectorFactory(ViewModel.NomenclatureSelectorFactory);

			yvalidatedentryDebtTo.ValidationMode = QSWidgetLib.ValidationType.numeric;
			yvalidatedentryDebtFrom.ValidationMode = QSWidgetLib.ValidationType.numeric;
			yvalidatedentryBottlesTo.ValidationMode = QSWidgetLib.ValidationType.numeric;
			yvalidatedentryBottlesFrom.ValidationMode = QSWidgetLib.ValidationType.numeric;

			yenumcomboboxOPF.ItemsEnum = typeof(PersonType);

			ycomboboxReason.SetRenderTextFunc<DiscountReason>(x => x.Name);
			ycomboboxReason.ItemsList = ViewModel.UoW?.Session.QueryOver<DiscountReason>().List();

			entryreferenceClient.Binding.AddBinding(ViewModel, x => x.Client, x => x.Subject).InitializeFromSource();
			entityVMEntryDeliveryPoint.Binding.AddBinding(ViewModel, x => x.Address, x => x.Subject).InitializeFromSource();
			entityviewmodelentryNomenclature.Binding.AddBinding(ViewModel, x => x.LastOrderNomenclature, x => x.Subject).InitializeFromSource();
			yvalidatedentryDebtTo.Binding.AddBinding(ViewModel, x => x.DebtBottlesTo, x => x.Text, new IntToStringConverter()).InitializeFromSource();
			yvalidatedentryDebtFrom.Binding.AddBinding(ViewModel, x => x.DebtBottlesFrom, x => x.Text, new IntToStringConverter()).InitializeFromSource();
			yvalidatedentryBottlesTo.Binding.AddBinding(ViewModel, x => x.LastOrderBottlesTo, x => x.Text, new IntToStringConverter()).InitializeFromSource();
			yvalidatedentryBottlesFrom.Binding.AddBinding(ViewModel, x => x.LastOrderBottlesFrom, x => x.Text, new IntToStringConverter()).InitializeFromSource();
			yenumcomboboxOPF.Binding.AddBinding(ViewModel, x => x.OPF, x => x.SelectedItemOrNull).InitializeFromSource();
			ycomboboxReason.Binding.AddBinding(ViewModel, x => x.DiscountReason, x => x.SelectedItem).InitializeFromSource();
			ydateperiodpickerLastOrder.Binding.AddSource(ViewModel).AddBinding(x => x.StartDate, x => x.StartDateOrNull)
				.AddBinding(x => x.EndDate, x => x.EndDateOrNull).InitializeFromSource();
			ycheckbuttonHideActive.Binding.AddSource(ViewModel).AddBinding(x => x.HideActiveCounterparty, x => x.Active)
				.AddFuncBinding(x => x.ShowHideActiveCheck && !x.ShowCancellationCounterparty && !x.ShowSuspendedCounterparty,
					x => x.Visible).InitializeFromSource();
			ycheckbuttonHideOneOrder.Binding.AddSource(ViewModel).AddBinding(x => x.HideWithOneOrder, x => x.Active).InitializeFromSource();
			ycheckbuttonShowSuspended.Binding.AddSource(ViewModel).AddBinding(x => x.ShowSuspendedCounterparty, x => x.Active)
				.AddFuncBinding(x => !x.ShowCancellationCounterparty && !x.HideActiveCounterparty, x => x.Visible).InitializeFromSource();
			ycheckbuttonShowCancellation.Binding.AddSource(ViewModel).AddBinding(x => x.ShowCancellationCounterparty, x => x.Active)
				.AddFuncBinding(x => !x.ShowSuspendedCounterparty && !x.HideActiveCounterparty, x => x.Visible).InitializeFromSource();
		}

		protected void OnEntryreferenceClientChanged(object sender, EventArgs e)
		{
			if(ViewModel?.Address?.Counterparty?.Id != ViewModel?.Client?.Id)
			{
				ViewModel.Address = null;
			}

			ViewModel?.DeliveryPointJournalFactory?.SetDeliveryPointJournalFilterViewModel(
				new Action<DeliveryPointJournalFilterViewModel>[]
				{
					x => x.Counterparty = ViewModel.Client
				});
		}
	}
}
