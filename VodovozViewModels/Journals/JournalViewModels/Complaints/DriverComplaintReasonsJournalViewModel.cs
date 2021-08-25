﻿using NHibernate;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Services;
using System;
using QS.ViewModels;
using Vodovoz.Domain.Complaints;
using Vodovoz.ViewModels.Journals.FilterViewModels.Complaints;
using Vodovoz.ViewModels.Journals.JournalNodes.Complaints;
using Vodovoz.ViewModels.ViewModels.Complaints;

namespace Vodovoz.ViewModels.Journals.JournalViewModels.Complaints
{
	public class DriverComplaintReasonsJournalViewModel : FilterableSingleEntityJournalViewModelBase<DriverComplaintReason, DriverComplaintReasonViewModel, DriverComplaintReasonJournalNode, DriverComplaintReasonJournalFilterViewModel>
	{
		public DriverComplaintReasonsJournalViewModel(
			EntitiesJournalActionsViewModel journalActionsViewModel,
			DriverComplaintReasonJournalFilterViewModel filterViewModel,
			IUnitOfWorkFactory unitOfWorkFactory,
			ICommonServices commonServices)
			: base(journalActionsViewModel, filterViewModel, unitOfWorkFactory, commonServices)
		{
			TabName = "Журнал причин оценки адреса";

			UpdateOnChanges(typeof(DriverComplaintReason));
		}

		protected override Func<IUnitOfWork, IQueryOver<DriverComplaintReason>> ItemsSourceQueryFunction => (unitOfWork) =>
		{
			DriverComplaintReasonJournalNode driverComplaintReasonJournalNodeAlias = null;
			DriverComplaintReason driverComplaintReasonAlias = null;

			var query = unitOfWork.Session.QueryOver<DriverComplaintReason>(() => driverComplaintReasonAlias);

			if(FilterViewModel.IsPopular)
			{
				query.Where(() => driverComplaintReasonAlias.IsPopular);
			}

			query.Where(GetSearchCriterion(
				() => driverComplaintReasonAlias.Id,
				() => driverComplaintReasonAlias.Name
			));

			var result = query.SelectList(list => list
				.Select(u => u.Id).WithAlias(() => driverComplaintReasonJournalNodeAlias.Id)
				.Select(u => u.Name).WithAlias(() => driverComplaintReasonJournalNodeAlias.Name)
				.Select(u => u.IsPopular).WithAlias(() => driverComplaintReasonJournalNodeAlias.IsPopular))
				.TransformUsing(Transformers.AliasToBean<DriverComplaintReasonJournalNode>());

			return result;
		};

		protected override Func<DriverComplaintReasonViewModel> CreateDialogFunction => () => new DriverComplaintReasonViewModel(
			  EntityUoWBuilder.ForCreate(),
			  UnitOfWorkFactory,
			  CommonServices
		  );

		protected override Func<JournalEntityNodeBase, DriverComplaintReasonViewModel> OpenDialogFunction => (node) => new DriverComplaintReasonViewModel(
			   EntityUoWBuilder.ForOpen(node.Id),
			   UnitOfWorkFactory,
			   CommonServices
		   );
	}
}
