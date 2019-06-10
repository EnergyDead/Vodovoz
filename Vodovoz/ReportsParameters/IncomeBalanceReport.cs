﻿using System;
using System.Collections.Generic;
using QS.DomainModel.UoW;
using QS.Dialog;
using QS.Report;
using QSReport;
using System.ComponentModel.DataAnnotations;

namespace Vodovoz.ReportsParameters
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class IncomeBalanceReport : Gtk.Bin, ISingleUoWDialog, IParametersWidget
	{
		private string reportPath = "Sales.CommonIncomeBalance";

		public IncomeBalanceReport()
		{
			this.Build();
			dateperiodpicker.StartDate = DateTime.Now.Date;
			dateperiodpicker.EndDate = DateTime.Now.Date;
			yenumcomboboxReportType.ItemsEnum = typeof(IncomeReportType);
			yenumcomboboxReportType.SelectedItem = IncomeReportType.Сommon;
		}

		#region IOrmDialog implementation

		public IUnitOfWork UoW { get; private set; }

		#endregion

		#region IParametersWidget implementation

		public string Title {
			get {
				return "Отчет по приходу по кассе";
			}
		}

		public event EventHandler<LoadReportEventArgs> LoadReport;

		#endregion

		private ReportInfo GetReportInfo()
		{

			string startDate = String.Format("{0:yyyy-MM-dd}", dateperiodpicker.StartDate);
			string endDate = String.Format("{0:yyyy-MM-dd}", dateperiodpicker.EndDate);

			var parameters = new Dictionary<string, object> {
				{ "StartDate", startDate },
				{ "EndDate", endDate }
			};

			return new ReportInfo {
				Identifier = reportPath,
				UseUserVariables = true,
				Parameters = parameters
			};
		}

		void OnUpdate(bool hide = false)
		{
			LoadReport?.Invoke(this, new LoadReportEventArgs(GetReportInfo(), hide));
		}

		protected void OnButtonCreateRepotClicked(object sender, EventArgs e)
		{
			switch(yenumcomboboxReportType.SelectedItem as IncomeReportType?)
			{
				case IncomeReportType.ByRouteList:
					reportPath = "Sales.IncomeBalanceByMl";
					break;
				case IncomeReportType.BySelfDelivery:
					reportPath = "Sales.IncomeBalanceBySelfDelivery";
					break;
				default:
					reportPath = "Sales.CommonIncomeBalance";
					break;
			}

			OnUpdate(true);
		}
	}

	public enum IncomeReportType
	{
		[Display(Name = "Общий отчет")]
		Сommon,
		[Display(Name = "По МЛ")]
		ByRouteList,
		[Display(Name = "По Самовывозу")]
		BySelfDelivery

	}
}
