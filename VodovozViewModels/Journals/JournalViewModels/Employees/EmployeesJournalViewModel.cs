﻿using System;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using QS.Dialog;
using QS.DomainModel.UoW;
using QS.Project.DB;
using QS.Project.Domain;
using QS.Project.Journal;
using QS.Services;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.WageCalculation;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.WageCalculation;
using Vodovoz.Factories;
using Vodovoz.Services;
using Vodovoz.TempAdapters;
using Vodovoz.ViewModels.Infrastructure.Services;
using Vodovoz.ViewModels.Journals.FilterViewModels.Employees;
using Vodovoz.ViewModels.Journals.JournalFactories;
using Vodovoz.ViewModels.Journals.JournalNodes.Employees;
using Vodovoz.ViewModels.TempAdapters;
using Vodovoz.ViewModels.ViewModels.Employees;

namespace Vodovoz.ViewModels.Journals.JournalViewModels.Employees
{
	public class EmployeesJournalViewModel : FilterableSingleEntityJournalViewModelBase<Employee, EmployeeViewModel, EmployeeJournalNode, EmployeeFilterViewModel>
	{
		private readonly IAuthorizationServiceFactory _authorizationServiceFactory;
		private readonly IAuthorizationService _authorizationService;
		private readonly IEmployeeWageParametersFactory _employeeWageParametersFactory;
		private readonly IEmployeeJournalFactory _employeeJournalFactory;
		private readonly ISubdivisionJournalFactory _subdivisionJournalFactory;
		private readonly IEmployeePostsJournalFactory _employeePostsJournalFactory;
		private readonly ICashDistributionCommonOrganisationProvider _cashDistributionCommonOrganisationProvider;
		private readonly ISubdivisionService _subdivisionService;
		private readonly IEmailServiceSettingAdapter _emailServiceSettingAdapter;
		private readonly IWageCalculationRepository _wageCalculationRepository;
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IValidationContextFactory _validationContextFactory;
		private readonly IPhonesViewModelFactory _phonesViewModelFactory;
		
		public EmployeesJournalViewModel(
			EmployeeFilterViewModel filterViewModel,
			IAuthorizationServiceFactory authorizationServiceFactory,
			IEmployeeWageParametersFactory employeeWageParametersFactory,
			IEmployeeJournalFactory employeeJournalFactory,
			ISubdivisionJournalFactory subdivisionJournalFactory,
			IEmployeePostsJournalFactory employeePostsJournalFactory,
			ICashDistributionCommonOrganisationProvider cashDistributionCommonOrganisationProvider,
			ISubdivisionService subdivisionService,
			IEmailServiceSettingAdapter emailServiceSettingAdapter,
			IWageCalculationRepository wageCalculationRepository,
			IEmployeeRepository employeeRepository,
			IValidationContextFactory validationContextFactory,
			IPhonesViewModelFactory phonesViewModelFactory,
			ICommonServices commonServices,
			IUnitOfWorkFactory unitOfWorkFactory) : base(filterViewModel, unitOfWorkFactory, commonServices)
		{
			TabName = "Журнал сотрудников";
		
			_authorizationServiceFactory =
				authorizationServiceFactory ?? throw new ArgumentNullException(nameof(authorizationServiceFactory));
			_authorizationService = _authorizationServiceFactory.CreateNewAuthorizationService();
			_employeeWageParametersFactory =
				employeeWageParametersFactory ?? throw new ArgumentNullException(nameof(employeeWageParametersFactory));
			_employeeJournalFactory = employeeJournalFactory ?? throw new ArgumentNullException(nameof(employeeJournalFactory));
			_subdivisionJournalFactory = subdivisionJournalFactory ?? throw new ArgumentNullException(nameof(subdivisionJournalFactory));
			_employeePostsJournalFactory =
				employeePostsJournalFactory ?? throw new ArgumentNullException(nameof(employeePostsJournalFactory));
			_cashDistributionCommonOrganisationProvider =
				cashDistributionCommonOrganisationProvider ??
				throw new ArgumentNullException(nameof(cashDistributionCommonOrganisationProvider));
			_subdivisionService = subdivisionService ?? throw new ArgumentNullException(nameof(subdivisionService));
			_emailServiceSettingAdapter = emailServiceSettingAdapter ?? throw new ArgumentNullException(nameof(emailServiceSettingAdapter));
			_wageCalculationRepository = wageCalculationRepository ?? throw new ArgumentNullException(nameof(wageCalculationRepository));
			_employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
			_validationContextFactory = validationContextFactory ?? throw new ArgumentNullException(nameof(validationContextFactory));
			_phonesViewModelFactory = phonesViewModelFactory ?? throw new ArgumentNullException(nameof(phonesViewModelFactory));

			UpdateOnChanges(typeof(Employee));
		}

		protected override Func<IUnitOfWork, IQueryOver<Employee>> ItemsSourceQueryFunction => (uow) => 
		{
			EmployeeJournalNode resultAlias = null;
			Employee employeeAlias = null;

			var query = uow.Session.QueryOver(() => employeeAlias);

			if(FilterViewModel?.Status != null)
			{
				query.Where(e => e.Status == FilterViewModel.Status);
			}

			if(FilterViewModel?.Category != null)
			{
				query.Where(e => e.Category == FilterViewModel.Category);
			}

			if(FilterViewModel?.RestrictWageParameterItemType != null) {
				WageParameterItem wageParameterItemAlias = null;
				var subquery = QueryOver.Of<EmployeeWageParameter>()
					.Left.JoinAlias(x => x.WageParameterItem, () => wageParameterItemAlias)
					.Where(() => wageParameterItemAlias.WageParameterItemType == FilterViewModel.RestrictWageParameterItemType.Value)
					.Where(p => p.EndDate == null || p.EndDate >= DateTime.Today)
					.Select(p => p.Employee.Id)
				;
				query.WithSubquery.WhereProperty(e => e.Id).In(subquery);
			}
			
			var employeeProjection = CustomProjections.Concat_WS(
				" ",
				() => employeeAlias.LastName,
				() => employeeAlias.Name,
				() => employeeAlias.Patronymic
			);

			query.Where(GetSearchCriterion(
				() => employeeAlias.Id,
				() => employeeProjection
			));

			var result = query
				.SelectList(list => list
				   .Select(() => employeeAlias.Id).WithAlias(() => resultAlias.Id)
				   .Select(() => employeeAlias.Status).WithAlias(() => resultAlias.Status)
				   .Select(() => employeeAlias.Name).WithAlias(() => resultAlias.EmpFirstName)
				   .Select(() => employeeAlias.LastName).WithAlias(() => resultAlias.EmpLastName)
				   .Select(() => employeeAlias.Patronymic).WithAlias(() => resultAlias.EmpMiddleName)
				   .Select(() => employeeAlias.Category).WithAlias(() => resultAlias.EmpCatEnum)
				   .SelectGroup(() => employeeAlias.Id).WithAlias(() => resultAlias.Id)
				)
				.OrderBy(x => x.LastName).Asc
				.OrderBy(x => x.Name).Asc
				.OrderBy(x => x.Patronymic).Asc
				.TransformUsing(Transformers.AliasToBean<EmployeeJournalNode>())
				;
			return result;
		};

		private void ResetPasswordForEmployee(Employee employee)
		{
			if (string.IsNullOrWhiteSpace(employee.Email))
			{
				commonServices.InteractiveService.ShowMessage(ImportanceLevel.Info, "Нельзя сбросить пароль.\n У сотрудника не заполнено поле Email");
				return;
			}
			if (_authorizationService.ResetPasswordToGenerated(employee.User.Login, employee.Email))
			{
				commonServices.InteractiveService.ShowMessage(ImportanceLevel.Info, "Email с паролем отправлена успешно");
			}
			else
			{
				commonServices.InteractiveService.ShowMessage(ImportanceLevel.Info, "Ошибка при отправке Email");
			}
		}

		protected override void CreatePopupActions()
		{
			base.CreatePopupActions();
			
			var resetPassAction = new JournalAction(
				"Сбросить пароль",
				x => x.FirstOrDefault() != null,
				x => true, 
				selectedItems =>
			{
				var selectedNodes = selectedItems.Cast<EmployeeJournalNode>();
				var selectedNode = selectedNodes.FirstOrDefault();
				if (selectedNode != null)
				{
					using(var uow = UnitOfWorkFactory.CreateWithoutRoot("Сброс пароля пользователю"))
					{
						var employee = uow.GetById<Employee>(selectedNode.Id);

						if(employee.User == null)
						{
							commonServices.InteractiveService.ShowMessage(ImportanceLevel.Error,
								"К сотруднику не привязан пользователь!");

							return;
						}

						if(string.IsNullOrEmpty(employee.User.Login))
						{
							commonServices.InteractiveService.ShowMessage(ImportanceLevel.Error,
								"У пользователя не заполнен логин!");

							return;
						}

						if(commonServices.InteractiveService.Question("Вы уверены?"))
						{
							ResetPasswordForEmployee(employee);
						}
					}
				}
			});
			
			PopupActionsList.Add(resetPassAction);
			NodeActionsList.Add(resetPassAction);
		}

		protected override Func<EmployeeViewModel> CreateDialogFunction => () => new EmployeeViewModel(
			_authorizationServiceFactory.CreateNewAuthorizationService(),
			_employeeWageParametersFactory,
			_employeeJournalFactory,
			_subdivisionJournalFactory,
			_employeePostsJournalFactory,
			_cashDistributionCommonOrganisationProvider,
			_subdivisionService,
			_emailServiceSettingAdapter,
			_wageCalculationRepository,
			_employeeRepository,
			EntityUoWBuilder.ForCreate().CreateUoW<Employee>(UnitOfWorkFactory),
			commonServices,
			_validationContextFactory,
			_phonesViewModelFactory);

		protected override Func<EmployeeJournalNode, EmployeeViewModel> OpenDialogFunction =>
			n => new EmployeeViewModel(
				_authorizationServiceFactory.CreateNewAuthorizationService(),
				_employeeWageParametersFactory,
				_employeeJournalFactory,
				_subdivisionJournalFactory,
				_employeePostsJournalFactory,
				_cashDistributionCommonOrganisationProvider,
				_subdivisionService,
				_emailServiceSettingAdapter,
				_wageCalculationRepository,
				_employeeRepository,
				EntityUoWBuilder.ForOpen(n.Id).CreateUoW<Employee>(UnitOfWorkFactory),
				commonServices,
				_validationContextFactory,
				_phonesViewModelFactory);
	}
}
