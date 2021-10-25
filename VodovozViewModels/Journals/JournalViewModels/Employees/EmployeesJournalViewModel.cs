﻿using System;
using System.Linq;
using Autofac;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.Transform;
using QS.Dialog;
using QS.DomainModel.UoW;
using QS.Navigation;
using QS.Project.DB;
using QS.Project.Journal;
using QS.Project.Services;
using QS.Services;
using Vodovoz.Domain.Documents.DriverTerminal;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Operations;
using Vodovoz.Domain.WageCalculation;
using Vodovoz.ViewModels.Infrastructure.Services;
using Vodovoz.ViewModels.Journals.Filters.Employees;
using Vodovoz.ViewModels.Journals.JournalNodes.Employees;
using Vodovoz.ViewModels.ViewModels.Employees;

namespace Vodovoz.ViewModels.Journals.JournalViewModels.Employees
{
	public class EmployeesJournalViewModel : EntityJournalViewModelBase<Employee, EmployeeViewModel, EmployeeJournalNode>
	{
		private EmployeeFilterViewModel FilterViewModel;
		private readonly IAuthorizationService _authorizationService;
		
		public EmployeesJournalViewModel(
			IUnitOfWorkFactory uowFactory,
			IInteractiveService interactiveService,
			INavigationManager navigationManager,
			ICurrentPermissionService currentPermissionService = null,
			IDeleteEntityService deleteEntityService = null,
			ILifetimeScope scope = null,
			Action<EmployeeFilterViewModel>[] filterParams = null)
			: base(uowFactory, interactiveService, navigationManager, deleteEntityService, currentPermissionService, scope)
		{
			TabName = "Журнал сотрудников";
			
			_authorizationService = Scope.Resolve<IAuthorizationService>();
			ConfigureFilter(filterParams);
		}

		private void ConfigureFilter(Action<EmployeeFilterViewModel>[] filterParams)
		{
			JournalFilter = FilterViewModel = Scope.Resolve<EmployeeFilterViewModel>();
			
			if(filterParams != null)
			{
				FilterViewModel.SetAndRefilterAtOnce(filterParams);
			}

			FilterViewModel.OnFiltered += (s, args) => Refresh();
		}

		protected override IQueryOver<Employee> ItemsQuery(IUnitOfWork uow) 
		{
			EmployeeJournalNode resultAlias = null;
			Employee employeeAlias = null;

			var query = uow.Session.QueryOver(() => employeeAlias);

			#region Фильтр
			
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

			if(FilterViewModel?.DriverTerminalRelation != null)
			{
				var relation = FilterViewModel?.DriverTerminalRelation;
				DriverAttachedTerminalDocumentBase baseAlias = null;
				DriverAttachedTerminalGiveoutDocument giveoutAlias = null;
				var baseQuery = QueryOver.Of(() => baseAlias)
					.Where(doc => doc.Driver.Id == employeeAlias.Id)
					.Select(doc => doc.Id)
					.OrderBy(doc => doc.CreationDate)
					.Desc.Take(1);
				var giveoutQuery = QueryOver.Of(() => giveoutAlias)
					.WithSubquery.WhereProperty(giveout => giveout.Id)
					.Eq(baseQuery)
					.Select(doc => doc.Driver.Id);

				if(relation == DriverTerminalRelation.WithTerminal)
				{
					query.WithSubquery.WhereProperty(e => e.Id).In(giveoutQuery);
				}
				else
				{
					query.WithSubquery.WhereProperty(e => e.Id).NotIn(giveoutQuery);
				}
			}

			if(FilterViewModel?.Subdivision != null)
			{
				query.Where(e => e.Subdivision.Id == FilterViewModel.Subdivision.Id);
			}

			if(FilterViewModel?.DriverOf != null)
			{
				query.Where(e => e.DriverOf == FilterViewModel.DriverOf);
			}

			if(FilterViewModel?.RegistrationType != null)
			{
				query.Where(e => e.Registration == FilterViewModel.RegistrationType);
			}

			if(FilterViewModel?.HiredDatePeriodStart != null)
			{
				query.Where(e => e.DateHired >= FilterViewModel.HiredDatePeriodStart);
			}

			if(FilterViewModel?.HiredDatePeriodEnd != null)
			{
				query.Where(e => e.DateHired <= FilterViewModel.HiredDatePeriodEnd);
			}

			if(FilterViewModel?.FirstDayOnWorkStart != null)
			{
				query.Where(e => e.FirstWorkDay >= FilterViewModel.FirstDayOnWorkStart);
			}

			if(FilterViewModel?.FirstDayOnWorkEnd != null)
			{
				query.Where(e => e.FirstWorkDay <= FilterViewModel.FirstDayOnWorkEnd);
			}

			if(FilterViewModel?.FiredDatePeriodStart != null)
			{
				query.Where(e => e.DateFired >= FilterViewModel.FiredDatePeriodStart);
			}

			if(FilterViewModel?.FiredDatePeriodEnd != null)
			{
				query.Where(e => e.DateFired <= FilterViewModel.FiredDatePeriodEnd);
			}

			if(FilterViewModel?.SettlementDateStart != null)
			{
				query.Where(e => e.DateCalculated >= FilterViewModel.SettlementDateStart);
			}

			if(FilterViewModel?.SettlementDateEnd != null)
			{
				query.Where(e => e.DateCalculated <= FilterViewModel.SettlementDateEnd);
			}

			if(FilterViewModel?.IsVisitingMaster ?? false)
			{
				query.Where(e => e.VisitingMaster);
			}

			if(FilterViewModel?.IsDriverForOneDay ?? false)
			{
				query.Where(e => e.IsDriverForOneDay);
			}

			if(FilterViewModel?.IsChainStoreDriver ?? false)
			{
				query.Where(e => e.IsChainStoreDriver);
			}

			if(FilterViewModel?.IsRFCitizen ?? false)
			{
				query.Where(e => e.IsRussianCitizen);
			}

			#endregion
			
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

			IQueryOver<Employee, Employee> result = null;

			if(FilterViewModel?.SortByPriority ?? false)
			{
				var endDate = DateTime.Today;
				var start3 = endDate.AddMonths(-3).AddDays(-2);
				var start2 = endDate.AddMonths(-2).AddDays(-1);
				var start1 = endDate.AddMonths(-1);
				endDate = endDate.AddDays(1).AddSeconds(-1);
				var timestampDiff = new SQLFunctionTemplate(
					NHibernateUtil.Int32, "CASE WHEN TIMESTAMPDIFF(MONTH, ?1, ?2) > 2 THEN 3 ELSE TIMESTAMPDIFF(MONTH, ?1, ?2) END");
				var avgSalary = new SQLFunctionTemplate(NHibernateUtil.Decimal, "(IFNULL(?1,0)+IFNULL(?2,0)+IFNULL(?3,0))/3");
				WagesMovementOperations wmo3 = null;
				WagesMovementOperations wmo2 = null;
				WagesMovementOperations wmo1 = null;
				const WagesType opType = WagesType.AccrualWage;

				result = query
						.SelectList(list => list
							.Select(() => employeeAlias.Id).WithAlias(() => resultAlias.Id)
							.Select(() => employeeAlias.Status).WithAlias(() => resultAlias.Status)
							.Select(() => employeeAlias.Name).WithAlias(() => resultAlias.EmpFirstName)
							.Select(() => employeeAlias.LastName).WithAlias(() => resultAlias.EmpLastName)
							.Select(() => employeeAlias.Patronymic).WithAlias(() => resultAlias.EmpMiddleName)
							.Select(() => employeeAlias.Category).WithAlias(() => resultAlias.EmpCatEnum)
						//расчет стажа работы в месяцах
							.Select(Projections.SqlFunction(timestampDiff, NHibernateUtil.Int32,
								Projections.Property(() => employeeAlias.CreationDate),
								Projections.Constant(endDate))
							).WithAlias(() => resultAlias.TotalMonths)
						//расчет средней зп за последние три месяца
							.Select(Projections.SqlFunction(avgSalary, NHibernateUtil.Decimal,
									Projections.SubQuery(QueryOver.Of(() => wmo3)
										.Where(() => wmo3.Employee.Id == employeeAlias.Id)
										.And(Restrictions.Ge(Projections.Property(() => wmo3.OperationTime), start3))
										.And(Restrictions.Lt(Projections.Property(() => wmo3.OperationTime), start2))
										.And(() => wmo3.OperationType == opType)
										.Select(Projections.Sum(() => wmo3.Money))),

									Projections.SubQuery(QueryOver.Of(() => wmo2)
										.Where(() => wmo2.Employee.Id == employeeAlias.Id)
										.And(Restrictions.Ge(Projections.Property(() => wmo2.OperationTime), start2))
										.And(Restrictions.Lt(Projections.Property(() => wmo2.OperationTime), start1))
										.And(() => wmo2.OperationType == opType)
										.Select(Projections.Sum(() => wmo2.Money))),

									Projections.SubQuery(QueryOver.Of(() => wmo1)
										.Where(() => wmo1.Employee.Id == employeeAlias.Id)
										.And(Restrictions.Ge(Projections.Property(() => wmo1.OperationTime), start1))
										.And(Restrictions.Le(Projections.Property(() => wmo1.OperationTime), endDate))
										.And(() => wmo1.OperationType == opType)
										.Select(Projections.Sum(() => wmo1.Money))))
							).WithAlias(() => resultAlias.AvgSalary)

							.SelectGroup(() => employeeAlias.Id).WithAlias(() => resultAlias.Id)
						)
						.OrderByAlias(() => resultAlias.TotalMonths).Desc
						.ThenByAlias(() => resultAlias.AvgSalary).Desc
						.TransformUsing(Transformers.AliasToBean<EmployeeJournalNode>());
				return result;
			}

			result = query
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
					.TransformUsing(Transformers.AliasToBean<EmployeeJournalNode>());
			return result;
		}

		private void ResetPasswordForEmployee(Employee employee)
		{
			if (string.IsNullOrWhiteSpace(employee.Email))
			{
				ShowInfoMessage("Нельзя сбросить пароль.\n У сотрудника не заполнено поле Email");
				return;
			}
			if (_authorizationService.ResetPasswordToGenerated(employee.User.Login, employee.Email))
			{
				ShowInfoMessage("Email с паролем отправлена успешно");
			}
			else
			{
				ShowInfoMessage("Ошибка при отправке Email");
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
							ShowErrorMessage("К сотруднику не привязан пользователь!");
							return;
						}

						if(string.IsNullOrEmpty(employee.User.Login))
						{
							ShowErrorMessage("У пользователя не заполнен логин!");
							return;
						}

						if(AskQuestion("Вы уверены?"))
						{
							ResetPasswordForEmployee(employee);
						}
					}
				}
			});
			
			PopupActionsList.Add(resetPassAction);
			NodeActionsList.Add(resetPassAction);
		}
	}
}
