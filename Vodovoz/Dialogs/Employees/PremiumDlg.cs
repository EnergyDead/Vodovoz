﻿using System;
using System.Linq;
using Gamma.GtkWidgets;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QS.Project.Dialogs;
using QS.Project.Dialogs.GtkUI;
using QSOrmProject;
using QSProjectsLib;
using Vodovoz.Domain.Employees;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.ViewModel;

namespace Vodovoz.Dialogs.Employees
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class PremiumDlg : QS.Dialog.Gtk.EntityDialogBase<Premium>
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

		private readonly IEmployeeRepository _employeeRepository = new EmployeeRepository();

		public PremiumDlg()
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Premium>();
			ConfigureDlg();
		}

		public PremiumDlg(int id)
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<Premium>(id);
			ConfigureDlg();
		}

		public PremiumDlg(Fine sub) : this (sub.Id)
		{
		}

		void ConfigureDlg()
		{
			ylabelDate.Binding.AddFuncBinding(Entity, e => e.Date.ToString("D"), w => w.LabelProp).InitializeFromSource();
			yspinMoney.Binding.AddBinding(Entity, e => e.TotalMoney, w => w.ValueAsDecimal).InitializeFromSource();
			yentryPremiumReasonString.Binding.AddBinding(Entity, e => e.PremiumReasonString, w => w.Text).InitializeFromSource();

			var filterRouteList = new RouteListsFilter(UoW);
			filterRouteList.SetFilterDates(DateTime.Today.AddDays(-7), DateTime.Today.AddDays(1));

			Entity.ObservableItems.ListContentChanged += ObservableItems_ListContentChanged;

			yentryAuthor.RepresentationModel = new EmployeesVM();
			yentryAuthor.Binding.AddBinding(Entity, e => e.Author, w => w.Subject).InitializeFromSource();

			ytreeviewItems.ColumnsConfig = ColumnsConfigFactory.Create<PremiumItem>()
				.AddColumn("Сотрудник")
					.AddTextRenderer(x => x.Employee.FullName)
				.AddColumn("Премия")
					.AddNumericRenderer(x => x.Money).Editing().Digits(2)
					.Adjustment(new Gtk.Adjustment(0, 0, 10000000, 1, 10, 10))
				.AddColumn("Причина премии")
					.AddTextRenderer(x => x.Premium.PremiumReasonString)
				.Finish();

			ytreeviewItems.ItemsDataSource = Entity.ObservableItems;
		}

		public override bool Save()
		{
			Employee author;
			if(!GetAuthor(out author)) return false;

			if(Entity.Author == null) {
				Entity.Author = author;
			}
			var valid = new QS.Validation.QSValidator<Premium>(UoWGeneric.Root);
			if(valid.RunDlgIfNotValid((Gtk.Window)this.Toplevel))
				return false;

			Entity.UpdateWageOperations(UoW);

			logger.Info("Сохраняем премию...");
			UoWGeneric.Save();
			logger.Info("Ok.");
			return true;
		}

		private bool GetAuthor(out Employee cashier)
		{
			cashier = _employeeRepository.GetEmployeeForCurrentUser(UoW);
			if(cashier == null) {
				MessageDialogHelper.RunErrorDialog(
					"Ваш пользователь не привязан к действующему сотруднику.");
				return false;
			}
			return true;
		}

		void ObservableItems_ListContentChanged(object sender, EventArgs e)
		{
			CalculateTotal();
		}

		protected void OnButtonDivideAtAllClicked(object sender, EventArgs e)
		{
			Entity.DivideAtAll();
		}

		protected void OnButtonGetReasonFromTemplateClicked(object sender, EventArgs e)
		{
			OrmReference SelectDialog = new OrmReference(typeof(PremiumTemplate), UoWGeneric);
			SelectDialog.Mode = OrmReferenceMode.Select;
			SelectDialog.ButtonMode = ReferenceButtonMode.CanAdd;
			SelectDialog.ObjectSelected += (s, ea) => {
				if(ea.Subject != null) {
					Entity.PremiumReasonString = (ea.Subject as PremiumTemplate).Reason;
					Entity.TotalMoney = (ea.Subject as PremiumTemplate).PremiumMoney;
				}
			};
			TabParent.AddSlaveTab(this, SelectDialog);
		}

		protected void OnButtonAddClicked(object sender, EventArgs e)
		{
			var addEmployeeDlg = new PermissionControlledRepresentationJournal(new EmployeesVM());
			addEmployeeDlg.Mode = JournalSelectMode.Single;
			addEmployeeDlg.ObjectSelected += AddEmployeeDlg_ObjectSelected;
			TabParent.AddSlaveTab(this, addEmployeeDlg);
		}

		void AddEmployeeDlg_ObjectSelected(object sender, JournalObjectSelectedEventArgs e)
		{
			var selectedId = e.GetSelectedIds().FirstOrDefault();
			if(selectedId == 0) {
				return;
			}
			var employee = UoW.GetById<Employee>(selectedId);
			if(Entity.Items.Any(x => x.Employee.Id == employee.Id)) {
				MessageDialogHelper.RunErrorDialog($"Сотрудник {employee.ShortName} уже присутствует в списке.");
				return;
			}
			Entity.AddItem(employee);
		}

		void CalculateTotal()
		{
			decimal sum = Entity.Items.Sum(x => x.Money);
			labelTotal.LabelProp = String.Format("Итого по сотрудникам: {0}", CurrencyWorks.GetShortCurrencyString(sum));
		}

		protected void OnButtonRemoveClicked(object sender, EventArgs e)
		{
			var row = ytreeviewItems.GetSelectedObject<PremiumItem>();
			if(row.Id > 0) {
				UoW.Delete(row);
				if(row.WageOperation != null)
					UoW.Delete(row.WageOperation);
			}
			Entity.ObservableItems.Remove(row);
		}
	}
}
