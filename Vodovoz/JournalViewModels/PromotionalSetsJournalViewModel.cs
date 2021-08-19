﻿using System;
using NHibernate;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Project.Journal.DataLoader;
using QS.Project.Journal.EntitySelector;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.Infrastructure.Services;
using Vodovoz.JournalNodes;
using Vodovoz.ViewModels.Orders;

namespace Vodovoz.JournalViewModels
{
	public class PromotionalSetsJournalViewModel : SingleEntityJournalViewModelBase<PromotionalSet, PromotionalSetViewModel, PromotionalSetJournalNode>
	{
		private readonly IUnitOfWorkFactory _unitOfWorkFactory;
		private readonly IEmployeeService _employeeService;
		private readonly INomenclatureRepository _nomenclatureRepository;
		private readonly IUserRepository _userRepository;
		private readonly IEntityAutocompleteSelectorFactory _counterpartySelectorFactory;
		private readonly IEntityAutocompleteSelectorFactory _nomenclatureSelectorFactory;
		
		public PromotionalSetsJournalViewModel(
			IUnitOfWorkFactory unitOfWorkFactory, 
			ICommonServices commonServices,
			IEmployeeService employeeService,
			IEntityAutocompleteSelectorFactory counterpartySelectorFactory,
			IEntityAutocompleteSelectorFactory nomenclatureSelectorFactory,
			INomenclatureRepository nomenclatureRepository,
			IUserRepository userRepository,
			bool hideJournalForOpenDialog = false, 
			bool hideJournalForCreateDialog = false)
			: base(unitOfWorkFactory, commonServices, hideJournalForOpenDialog, hideJournalForCreateDialog)
		{
			_unitOfWorkFactory = unitOfWorkFactory ?? throw new ArgumentNullException(nameof(unitOfWorkFactory));
			_employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
			_nomenclatureRepository = nomenclatureRepository ?? throw new ArgumentNullException(nameof(nomenclatureRepository));
			_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
			_counterpartySelectorFactory = counterpartySelectorFactory ?? throw new ArgumentNullException(nameof(counterpartySelectorFactory));
			_nomenclatureSelectorFactory = nomenclatureSelectorFactory ?? throw new ArgumentNullException(nameof(nomenclatureSelectorFactory));
			
			TabName = "Рекламные наборы";

			var threadLoader = DataLoader as ThreadDataLoader<PromotionalSetJournalNode>;
			threadLoader.MergeInOrderBy(x => x.IsArchive, false);
			threadLoader.MergeInOrderBy(x => x.Id, false);

			UpdateOnChanges(typeof(PromotionalSet));
		}

		protected override Func<IUnitOfWork, IQueryOver<PromotionalSet>> ItemsSourceQueryFunction => (uow) => {
			PromotionalSetJournalNode resultAlias = null;
			DiscountReason reasonAlias = null;

			var query = uow.Session.QueryOver<PromotionalSet>().Left.JoinAlias(x => x.PromoSetDiscountReason, () => reasonAlias);
			query.Where(
				GetSearchCriterion<PromotionalSet>(
					x => x.Id
				)
			);

			var result = query.SelectList(list => list
									.Select(x => x.Id).WithAlias(() => resultAlias.Id)
									.Select(x => x.IsArchive).WithAlias(() => resultAlias.IsArchive)
									.Select(x => x.Name).WithAlias(() => resultAlias.Name)
									.Select(() => reasonAlias.Name).WithAlias(() => resultAlias.PromoSetDiscountReasonName))
									.TransformUsing(Transformers.AliasToBean<PromotionalSetJournalNode>())
									.OrderBy(x => x.Name).Asc;
			return result;
		};

		protected override Func<PromotionalSetViewModel> CreateDialogFunction => () => new PromotionalSetViewModel(
			EntityUoWBuilder.ForCreate(),
			_unitOfWorkFactory,
			commonServices,
			_employeeService,
			_counterpartySelectorFactory,
			_nomenclatureSelectorFactory,
			_nomenclatureRepository,
			_userRepository
		);

		protected override Func<JournalEntityNodeBase, PromotionalSetViewModel> OpenDialogFunction => node => new PromotionalSetViewModel(
			EntityUoWBuilder.ForOpen(node.Id),
			_unitOfWorkFactory,
			commonServices,
			_employeeService,
			_counterpartySelectorFactory,
			_nomenclatureSelectorFactory,
			_nomenclatureRepository,
			_userRepository
	   	);

		protected override void InitializeJournalActionsViewModel()
		{
			EntitiesJournalActionsViewModel.Initialize(
				SelectionMode, EntityConfigs, this, HideJournal, OnItemsSelected,
				true, true, true, false);
		}
	}
}
