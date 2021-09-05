﻿using System;
using System.Collections.Generic;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QS.Report;
using QSProjectsLib;
using QSReport;
using Vodovoz.Domain.Sale;

namespace Vodovoz.Reports.Logistic
{
	public partial class DeliveriesLateReport : SingleUoWWidgetBase, IParametersWidget
	{
		//FEDOS по 4 пункту минуты и кол во адресов
		public DeliveriesLateReport ()
		{
			this.Build ();
			UoW = UnitOfWorkFactory.CreateWithoutRoot();
			ySpecCmbGeographicGroup.ItemsList = UoW.GetAll<GeographicGroup>();
		}

		#region IParametersWidget implementation

		public event EventHandler<LoadReportEventArgs> LoadReport;

		public string Title {
			get {
				return "Отчет по опозданиям";
			}
		}

		#endregion

		void OnUpdate (bool hide = false)
		{
			if (LoadReport != null) {
				LoadReport (this, new LoadReportEventArgs (GetReportInfo (), hide));
			}
		}

		private ReportInfo GetReportInfo ()
		{
			return new ReportInfo {
				Identifier = "Logistic.DeliveriesLate",
				Parameters = new Dictionary<string, object>
				{
					{ "start_date", dateperiodpicker.StartDate },
					{ "end_date", dateperiodpicker.EndDate.AddHours(3) },
					{ "is_driver_sort", ychkDriverSort.Active },
					{ "geographic_group_id", (ySpecCmbGeographicGroup.SelectedItem as GeographicGroup)?.Id ?? 0 },
					{ "geographic_group_name", (ySpecCmbGeographicGroup.SelectedItem as GeographicGroup)?.Name ?? "Все" }
				}
			};
		}

		protected void OnButtonCreateReportClicked (object sender, EventArgs e)
		{
			if (dateperiodpicker.StartDateOrNull == null) {
				MessageDialogWorks.RunErrorDialog ("Необходимо выбрать дату");
				return;
			}
			OnUpdate (true);
		}

	}
}
