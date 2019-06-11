﻿using System;
using System.Collections.Generic;
using System.Data.Bindings.Collections.Generic;
using System.Linq;
using QS.Dialog;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QS.Report;
using QSReport;
using Vodovoz.Domain.Sale;

namespace Vodovoz.ReportsParameters.Logistic
{
	public partial class FuelConsumptionReport : Gtk.Bin, IParametersWidget, ISingleUoWDialog
	{
		GenericObservableList<GeographicGroup> geographicGroups;

		#region IOrmDialog implementation

		public IUnitOfWork UoW { get; private set; }

		#endregion

		public FuelConsumptionReport(bool orderById = false)
		{
			this.Build();
			ConfigureDlg();
		}

		void ConfigureDlg()
		{
			UoW = UnitOfWorkFactory.CreateWithoutRoot();
			geographicGroup.UoW = UoW;
			geographicGroup.Label = "Часть города:";
			geographicGroups = new GenericObservableList<GeographicGroup>();
			geographicGroup.Items = geographicGroups;
			foreach(var gg in UoW.Session.QueryOver<GeographicGroup>().List())
				geographicGroups.Add(gg);
		}

		#region IParametersWidget implementation

		public event EventHandler<LoadReportEventArgs> LoadReport;

		public string Title => "Отчет по выдаче топлива по МЛ";

		#endregion

		private int[] GetResultIds(IEnumerable<int> ids)
		{
			return ids.Any() ? ids.ToArray() : new int[] { 0 };
		}

		void OnUpdate(bool hide = false)
		{
			LoadReport?.Invoke(this, new LoadReportEventArgs(GetReportInfo(), hide));
		}

		private ReportInfo GetReportInfo()
		{
			return new ReportInfo {
				Identifier = chkDetailed.Active ? "Logistic.FuelConsumptionDetailedReport" : "Logistic.FuelConsumptionReport",
				Parameters = new Dictionary<string, object>
				{
					{ "start_date", dateperiodpicker.StartDateOrNull },
					{ "end_date", dateperiodpicker.EndDateOrNull },
					{ "geo_group_ids", GetResultIds(geographicGroups.Select(g => g.Id)) }
				}
			};
		}

		protected void OnButtonCreateReportClicked(object sender, EventArgs e)
		{
			if(dateperiodpicker.StartDateOrNull == null) {
				MessageDialogHelper.RunErrorDialog("Необходимо выбрать дату");
				return;
			}
			OnUpdate(true);
		}
	}
}
