﻿using System;
using System.Collections.Generic;
using QS.Project.Filter;
using Vodovoz.Domain.Complaints;

namespace Vodovoz.ViewModels.Journals.FilterViewModels.Complaints
{
	public class ComplaintKindJournalFilterViewModel : FilterViewModelBase<ComplaintKindJournalFilterViewModel>
	{
		private ComplaintObject _complaintObject;

		public ComplaintKindJournalFilterViewModel(params Action<ComplaintKindJournalFilterViewModel>[] filterParams)
		{
			ComplaintObjects = UoW.Session.QueryOver<ComplaintObject>().List();

			if(filterParams != null)
			{
				SetAndRefilterAtOnce(filterParams);
			}
		}

		public ComplaintObject ComplaintObject
		{
			get => _complaintObject;
			set => UpdateFilterField(ref _complaintObject, value);
		}

		public IList<ComplaintObject> ComplaintObjects { get; }
	}
}
