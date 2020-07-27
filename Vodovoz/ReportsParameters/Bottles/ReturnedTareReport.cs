﻿using System;
using System.Collections.Generic;
using QS.Report;
using QSReport;

namespace Vodovoz.ReportsParameters.Bottles
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ReturnedTareReport : Gtk.Bin, IParametersWidget
	{
		public ReturnedTareReport()
		{
			this.Build();
			btnCreateReport.Clicked += (sender, e) => OnUpdate(true);
			btnCreateReport.Sensitive = false;
			daterangepicker.PeriodChangedByUser += Daterangepicker_PeriodChangedByUser;
		}

		void Daterangepicker_PeriodChangedByUser(object sender, EventArgs e) =>
			btnCreateReport.Sensitive = daterangepicker.EndDateOrNull.HasValue && daterangepicker.StartDateOrNull.HasValue;


		#region IParametersWidget implementation

		public string Title => "Отчет по забору тары";

		public event EventHandler<LoadReportEventArgs> LoadReport;

		#endregion

		private ReportInfo GetReportInfo()
		{
			return new ReportInfo {
				Identifier = "Bottles.ReturnedTareReport",
				Parameters = new Dictionary<string, object> {
					{ "start_date", daterangepicker.StartDate },
					{ "end_date", daterangepicker.EndDate.AddHours(23).AddMinutes(59).AddSeconds(59) },
					{ "date", DateTime.Now }
				}
			};
		}

		void OnUpdate(bool hide = false) => LoadReport?.Invoke(this, new LoadReportEventArgs(GetReportInfo(), hide));
	}
}
