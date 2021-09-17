﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gamma.GtkWidgets;
using QS.Dialog.GtkUI;
using Vodovoz.Domain.Employees;
using QSProjectsLib;
using QS.DomainModel.UoW;
using QS.Project.Journal;
using Vodovoz.TempAdapters;

namespace Vodovoz
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class FineItemsView : QS.Dialog.Gtk.WidgetOnDialogBase
	{
		public FineItemsView()
		{
			this.Build();

			UpdateControlsState();
			ytreeviewItems.Selection.Changed += YtreeviewItems_Selection_Changed;
		}
		bool isFuelOverspending;

		public bool IsFuelOverspending {
			get {
				return isFuelOverspending;
			}

			set {
				if(value != isFuelOverspending) {
					isFuelOverspending = value;
					UpdateControlsState();
				}
			}
		}

		void UpdateControlsState()
		{
			if(IsFuelOverspending) {
				buttonAdd.Sensitive = false;
				buttonRemove.Sensitive = false;
			}else {
				buttonAdd.Sensitive = true;
				buttonRemove.Sensitive = true;
			}

			ytreeviewItems.ColumnsConfig = ColumnsConfigFactory.Create<FineItem>()
				.AddColumn("Сотрудник").AddTextRenderer(x => x.Employee.FullName)
				.AddColumn("Штраф").AddNumericRenderer(x => x.Money).Editing(!IsFuelOverspending).Digits(2)
				.Adjustment(new Gtk.Adjustment(0, 0, 10000000, 1, 10, 10))
				.AddColumn("Причина штрафа").AddTextRenderer(x => x.Fine.FineReasonString)
				.Finish();
		}

		void YtreeviewItems_Selection_Changed (object sender, EventArgs e)
		{
			UpdateControlsState();
		}

		private IUnitOfWorkGeneric<Fine> fineUoW;

		public IUnitOfWorkGeneric<Fine> FineUoW {
			get { return fineUoW; }
			set {
				if (fineUoW == value)
					return;
				fineUoW = value;
				if (FineUoW.Root.Items == null)
					FineUoW.Root.Items = new List<FineItem> ();

				ytreeviewItems.ItemsDataSource = FineUoW.Root.ObservableItems;
				FineUoW.Root.ObservableItems.ListContentChanged += FineUoW_Root_ObservableItems_ListContentChanged;
			}
		}

		void FineUoW_Root_ObservableItems_ListContentChanged (object sender, EventArgs e)
		{
			CalculateTotal();
		}

		protected void OnButtonAddClicked(object sender, EventArgs e)
		{
			var employeeFactory = new EmployeeJournalFactory();
			var employeeJournal = employeeFactory.CreateEmployeeJournal();
			employeeJournal.SelectionMode = JournalSelectionMode.Single;
			employeeJournal.OnEntitySelectedResult += AddEmployeeDlg_ObjectSelected;
			MyTab.TabParent.AddSlaveTab(MyTab, employeeJournal);
		}
		
		void AddEmployeeDlg_ObjectSelected(object sender, JournalSelectedNodesEventArgs e)
		{
			var selectedId = e.SelectedNodes.FirstOrDefault()?.Id ?? 0;
			if(selectedId == 0) {
				return;
			}
			var employee = FineUoW.GetById<Employee>(selectedId);
			if(FineUoW.Root.Items.Any(x => x.Employee.Id == employee.Id)) {
				MessageDialogHelper.RunErrorDialog("Сотрудник {0} уже присутствует в списке.", employee.ShortName);
				return;
			}
			FineUoW.Root.AddItem(employee);
		}

		void CalculateTotal()
		{
			decimal sum = FineUoW.Root.Items.Sum(x => x.Money);
			labelTotal.LabelProp = String.Format("Итого по сотрудникам: {0}", CurrencyWorks.GetShortCurrencyString(sum));
		}

		protected void OnButtonRemoveClicked(object sender, EventArgs e)
		{
			var row = ytreeviewItems.GetSelectedObject<FineItem>();

			if(row == null)
			{
				return;
			}
			
			if (row.Id > 0) 
			{
				FineUoW.Delete(row);
				
				if(row.WageOperation != null)
				{
					FineUoW.Delete(row.WageOperation);
				}
			}
			FineUoW.Root.ObservableItems.Remove(row);
		}
	}
}
