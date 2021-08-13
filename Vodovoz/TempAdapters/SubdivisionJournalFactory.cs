﻿using QS.DomainModel.UoW;
using QS.Project.Journal.EntitySelector;
using QS.Project.Services;
using Vodovoz.FilterViewModels.Organization;
using Vodovoz.Journals.JournalViewModels.Organization;
using Vodovoz.ViewModels.Journals.JournalFactories;

namespace Vodovoz.TempAdapters
{
	public class SubdivisionJournalFactory : ISubdivisionJournalFactory
	{
		private readonly SubdivisionFilterViewModel _filterViewModel;
		private IEmployeeJournalFactory _employeeJournalFactory;
		private ISalesPlanJournalFactory _salesPlanJournalFactory;
		private INomenclatureSelectorFactory _nomenclatureSelectorFactory;

		public SubdivisionJournalFactory(SubdivisionFilterViewModel filterViewModel = null)
		{
			_filterViewModel = filterViewModel;
		}
		
		private void CreateNewDependencies()
		{
			_employeeJournalFactory = new EmployeeJournalFactory();
			_salesPlanJournalFactory = new SalesPlanJournalFactory();
			_nomenclatureSelectorFactory = new NomenclatureSelectorFactory();
		}
		
		public IEntityAutocompleteSelectorFactory CreateSubdivisionAutocompleteSelectorFactory(
			IEntityAutocompleteSelectorFactory employeeSelectorFactory = null)
		{
			CreateNewDependencies();
			
			return new EntityAutocompleteSelectorFactory<SubdivisionsJournalViewModel>(
				typeof(Subdivision),
				() => new SubdivisionsJournalViewModel(
					_filterViewModel ?? new SubdivisionFilterViewModel(),
					UnitOfWorkFactory.GetDefaultFactory,
					ServicesConfig.CommonServices,
					employeeSelectorFactory ?? _employeeJournalFactory.CreateEmployeeAutocompleteSelectorFactory(),
					_salesPlanJournalFactory,
					_nomenclatureSelectorFactory));
		}
		
		public IEntityAutocompleteSelectorFactory CreateDefaultSubdivisionAutocompleteSelectorFactory(
			IEntityAutocompleteSelectorFactory employeeSelectorFactory = null)
		{
			CreateNewDependencies();
			
			return new EntityAutocompleteSelectorFactory<SubdivisionsJournalViewModel>(
				typeof(Subdivision),
				() => new SubdivisionsJournalViewModel(
					new SubdivisionFilterViewModel
					{
						SubdivisionType = SubdivisionType.Default
					},
					UnitOfWorkFactory.GetDefaultFactory,
					ServicesConfig.CommonServices,
					employeeSelectorFactory ?? _employeeJournalFactory.CreateEmployeeAutocompleteSelectorFactory(),
					_salesPlanJournalFactory,
					_nomenclatureSelectorFactory));
		}

		public IEntityAutocompleteSelectorFactory CreateLogisticSubdivisionAutocompleteSelectorFactory(
			IEntityAutocompleteSelectorFactory employeeSelectorFactory = null)
		{
			CreateNewDependencies();
			
			return new EntityAutocompleteSelectorFactory<SubdivisionsJournalViewModel>(
				typeof(Subdivision),
				() => new SubdivisionsJournalViewModel(
					new SubdivisionFilterViewModel
					{
						SubdivisionType = SubdivisionType.Logistic
					},
					UnitOfWorkFactory.GetDefaultFactory,
					ServicesConfig.CommonServices,
					employeeSelectorFactory ?? _employeeJournalFactory.CreateEmployeeAutocompleteSelectorFactory(),
					_salesPlanJournalFactory,
					_nomenclatureSelectorFactory));
		}
	}
}
