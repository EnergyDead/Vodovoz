﻿using System;
using NHibernate;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Project.Journal.DataLoader;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Domain.WageCalculation;
using Vodovoz.Journals.JournalNodes;
using Vodovoz.TempAdapters;
using Vodovoz.ViewModels.WageCalculation;

namespace Vodovoz.Journals.JournalViewModels.WageCalculation
{
	public class SalesPlanJournalViewModel : SingleEntityJournalViewModelBase<SalesPlan, SalesPlanViewModel, SalesPlanJournalNode>
	{
		private readonly INomenclatureSelectorFactory _nomenclatureSelectorFactory;

		public SalesPlanJournalViewModel(
			EntitiesJournalActionsViewModel journalActionsViewModel,
			IUnitOfWorkFactory unitOfWorkFactory,
			ICommonServices commonServices, 
			INomenclatureSelectorFactory nomenclatureSelectorFactory)
			: base(journalActionsViewModel, unitOfWorkFactory, commonServices)
		{
			_nomenclatureSelectorFactory = nomenclatureSelectorFactory ?? throw new ArgumentNullException(nameof(nomenclatureSelectorFactory));

			TabName = "Журнал планов продаж";

			var threadLoader = DataLoader as ThreadDataLoader<SalesPlanJournalNode>;
			threadLoader.MergeInOrderBy(x => x.IsArchive, false);
			threadLoader.MergeInOrderBy(x => x.Id, false);

			UpdateOnChanges(typeof(SalesPlan));
		}

		protected override Func<IUnitOfWork, IQueryOver<SalesPlan>> ItemsSourceQueryFunction => (uow) => {
			SalesPlanJournalNode resultAlias = null;

			var query = uow.Session.QueryOver<SalesPlan>();
			query.Where(
				GetSearchCriterion<SalesPlan>(
					x => x.Id
				)
			);

			var result = query.SelectList(list => list
									.Select(x => x.Id).WithAlias(() => resultAlias.Id)
									.Select(x => x.Name).WithAlias(() => resultAlias.Name)
									.Select(x => x.FullBottleToSell).WithAlias(() => resultAlias.FullBottleToSell)
									.Select(x => x.EmptyBottlesToTake).WithAlias(() => resultAlias.EmptyBottlesToTake)
									.Select(x => x.IsArchive).WithAlias(() => resultAlias.IsArchive)
					)
								.TransformUsing(Transformers.AliasToBean<SalesPlanJournalNode>())
								.OrderBy(x => x.Name).Asc
								.ThenBy(x => x.IsArchive).Asc
								;

			return result;
		};

		protected override Func<SalesPlanViewModel> CreateDialogFunction => () => new SalesPlanViewModel(
			EntityUoWBuilder.ForCreate(),
			UnitOfWorkFactory,
			CommonServices,
			_nomenclatureSelectorFactory
		);

		protected override Func<JournalEntityNodeBase, SalesPlanViewModel> OpenDialogFunction => node => new SalesPlanViewModel(
			EntityUoWBuilder.ForOpen(node.Id),
			UnitOfWorkFactory,
			CommonServices,
			_nomenclatureSelectorFactory
	   	);
	}
}
