﻿using System;
using System.Collections.Generic;
using QS.DomainModel.UoW;
using QS.Dialog;
using QS.Report;
using QSReport;
using Vodovoz.Domain.Employees;
using Vodovoz.ViewModel;
using Vodovoz.Filters.ViewModels;
using QS.Dialog.GtkUI;
using Vodovoz.JournalFilters;
using Vodovoz.ViewModels.Journals.FilterViewModels.Employees;

namespace Vodovoz.Reports
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ForwarderWageReport : SingleUoWWidgetBase, IParametersWidget
	{
		public ForwarderWageReport()
		{
			this.Build();
			UoW = UnitOfWorkFactory.CreateWithoutRoot ();

			var filterForwarder = new EmployeeRepresentationFilterViewModel();
			filterForwarder.SetAndRefilterAtOnce(
				x => x.RestrictCategory = EmployeeCategory.forwarder,
				x => x.Status = EmployeeStatus.IsWorking
			);
			yentryreferenceForwarder.RepresentationModel = new EmployeesVM(filterForwarder);
		}

		#region IParametersWidget implementation

		public event EventHandler<LoadReportEventArgs> LoadReport;

		public string Title {
			get	{
				return "Отчет по зарплате экспедитора";
			}
		}

		#endregion

		private ReportInfo GetReportInfo()
		{
			var parameters = new Dictionary<string, object>
				{
					{ "start_date", dateperiodpicker.StartDateOrNull },
					{ "end_date", dateperiodpicker.EndDateOrNull },
					{ "forwarder_id", (yentryreferenceForwarder.Subject as Employee)?.Id }
			};

			if(checkShowBalance.Active) {
				parameters.Add("showbalance", "1");
			} else {
				parameters.Add("showbalance", "0");
			}

			return new ReportInfo {
				Identifier = "Employees.ForwarderWage",
				Parameters = parameters
			};
		}

		void OnUpdate(bool hide = false)
		{
			if (LoadReport != null)
			{
				LoadReport(this, new LoadReportEventArgs(GetReportInfo(), hide));
			}
		}

		void CanRun()
		{
			buttonCreateReport.Sensitive = 
				(dateperiodpicker.EndDateOrNull != null && dateperiodpicker.StartDateOrNull != null
					&& yentryreferenceForwarder.Subject != null);
		}

		protected void OnButtonCreateReportClicked (object sender, EventArgs e)
		{
			OnUpdate(true);
		}

		protected void OnDateperiodpickerPeriodChanged (object sender, EventArgs e)
		{
			CanRun();
		}

		protected void OnYentryreferenceForwarderChanged (object sender, EventArgs e)
		{
			CanRun();
		}
	}
}

