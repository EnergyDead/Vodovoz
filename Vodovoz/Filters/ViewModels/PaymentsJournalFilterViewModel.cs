﻿using System;
using QS.Project.Filter;
using Vodovoz.Domain.Payments;

namespace Vodovoz.Filters.ViewModels
{
	public class PaymentsJournalFilterViewModel : FilterViewModelBase<PaymentsJournalFilterViewModel>
	{
		public PaymentsJournalFilterViewModel(params Action<PaymentsJournalFilterViewModel>[] filterParams)
		{
			StartDate = null;
			EndDate = null;

			if(filterParams != null)
			{
				SetAndRefilterAtOnce(filterParams);
			}
		}

		private DateTime? startDate;
		public DateTime? StartDate {
			get => startDate;
			set => UpdateFilterField(ref startDate, value);
		}

		private DateTime? endDate;
		public DateTime? EndDate {
			get => endDate;
			set => UpdateFilterField(ref endDate, value);
		}

		private PaymentState? paymentState;
		public PaymentState? PaymentState {
			get => paymentState;
			set => UpdateFilterField(ref paymentState, value);
		}

		bool hideCompleted;
		public bool HideCompleted {
			get => hideCompleted;
			set => UpdateFilterField(ref hideCompleted, value);
		}
	}
}
