﻿using System;
using System.Collections.Generic;
using Autofac;
using QS.DomainModel.UoW;
using QS.Dialog;
using QS.Report;
using QSReport;
using Vodovoz.Domain.Client;
using QS.Dialog.GtkUI;
using Vodovoz.Filters.ViewModels;
using Vodovoz.TempAdapters;
using Vodovoz.ViewModels.Journals.JournalViewModels.Client;
using Vodovoz.ViewModels.TempAdapters;

namespace Vodovoz.ReportsParameters
{
	public partial class ReportForBigClient : SingleUoWWidgetBase, IParametersWidget
	{
		private readonly IDeliveryPointJournalFactory _deliveryPointJournalFactory;

		public ReportForBigClient(ILifetimeScope scope)
		{
			if(scope == null)
			{
				throw new ArgumentNullException(nameof(scope));
			}
			
			this.Build();
			UoW = UnitOfWorkFactory.CreateWithoutRoot();
			_deliveryPointJournalFactory = new DeliveryPointJournalFactory();

			evmeCounterparty
				.SetEntityAutocompleteSelectorFactory(new CounterpartyJournalFactory().CreateCounterpartyAutocompleteSelectorFactory(scope));
			evmeCounterparty.Changed += OnCounterpartyChanged;

			evmeDeliveryPoint
				.SetEntityAutocompleteSelectorFactory(_deliveryPointJournalFactory
					.CreateDeliveryPointByClientAutocompleteSelectorFactory(scope));
		}

		#region IParametersWidget implementation

		public string Title => "Отчёт \"Куньголово\"";

		public event EventHandler<LoadReportEventArgs> LoadReport;

		#endregion

		private void OnUpdate(bool hide = false)
		{
			LoadReport?.Invoke(this, new LoadReportEventArgs(GetReportInfo(), hide));
		}

		protected void OnButtonRunClicked(object sender, EventArgs e)
		{
			OnUpdate(true);
		}

		private ReportInfo GetReportInfo()
		{
			return new ReportInfo
			{
				Identifier = "Client.SummaryBottlesAndDepositsKungolovo",
				Parameters = new Dictionary<string, object>
				{
					{ "startDate", dateperiodpicker1.StartDateOrNull },
					{ "endDate", dateperiodpicker1.EndDateOrNull },
					{ "client_id", evmeCounterparty.SubjectId },
					{ "delivery_point_id", evmeDeliveryPoint.Subject == null ? -1 : evmeDeliveryPoint.SubjectId }
				}
			};
		}

		protected void OnDateperiodpicker1PeriodChanged(object sender, EventArgs e)
		{
			ValidateParameters();
		}

		private void ValidateParameters()
		{
			buttonRun.Sensitive = evmeCounterparty.Subject != null;
		}

		//TODO проверить работоспособность
		private void OnCounterpartyChanged(object sender, EventArgs e)
		{
			ValidateParameters();
			if(evmeCounterparty.Subject == null)
			{
				evmeDeliveryPoint.Subject = null;
				evmeDeliveryPoint.Sensitive = false;
			}
			else
			{
				_deliveryPointJournalFactory.SetDeliveryPointJournalFilterViewModel(
					new Action<DeliveryPointJournalFilterViewModel>[]
					{
						x => x.Counterparty = evmeCounterparty.Subject as Counterparty
					});
				evmeDeliveryPoint.Subject = null;
				evmeDeliveryPoint.Sensitive = true;
			}
		}
	}
}
