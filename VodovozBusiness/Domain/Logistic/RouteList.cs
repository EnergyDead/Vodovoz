﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using System.Linq;
using Gamma.Utilities;
using QS.Dialog;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using QS.DomainModel.UoW;
using QS.HistoryLog;
using QS.Osm;
using QS.Osm.Osrm;
using QS.Project.Services;
using QS.Report;
using QS.Tools;
using QS.Validation;
using Vodovoz.Controllers;
using Vodovoz.Core.DataService;
using Vodovoz.Domain.Cash;
using Vodovoz.Domain.Documents;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Operations;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Sale;
using Vodovoz.Domain.WageCalculation;
using Vodovoz.Domain.WageCalculation.CalculationServices.RouteList;
using Vodovoz.EntityRepositories.Cash;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.Logistic;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.EntityRepositories.Permissions;
using Vodovoz.EntityRepositories.Store;
using Vodovoz.EntityRepositories.Subdivisions;
using Vodovoz.Models;
using Vodovoz.Parameters;
using Vodovoz.Repositories.HumanResources;
using Vodovoz.Repository.Cash;
using Vodovoz.Repository.Store;
using Vodovoz.Services;
using Vodovoz.Tools.CallTasks;
using Vodovoz.Tools.Logistic;
using CashRepository = Vodovoz.Repository.Cash.CashRepository;

namespace Vodovoz.Domain.Logistic
{
	[Appellative(Gender = GrammaticalGender.Masculine,
		NominativePlural = "Журнал МЛ",
		Nominative = "маршрутный лист")]
	[HistoryTrace]
	[EntityPermission]
	public class RouteList : BusinessObjectBase<RouteList>, IDomainObject, IValidatableObject
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
		
		private RouteListCashOrganisationDistributor routeListCashOrganisationDistributor = 
			new RouteListCashOrganisationDistributor(
				new CashDistributionCommonOrganisationProvider(
					new OrganizationParametersProvider(SingletonParametersProvider.Instance)),
				new RouteListItemCashDistributionDocumentRepository(),
				OrderSingletonRepository.GetInstance());
		
		private ExpenseCashOrganisationDistributor expenseCashOrganisationDistributor = 
			new ExpenseCashOrganisationDistributor();

		private CashDistributionCommonOrganisationProvider commonOrganisationProvider =
			new CashDistributionCommonOrganisationProvider(
				new OrganizationParametersProvider(SingletonParametersProvider.Instance));

		private readonly ICarLoadDocumentRepository carLoadDocumentRepository = new CarLoadDocumentRepository(new RouteListRepository());
		private readonly ICarUnloadRepository carUnloadRepository = CarUnloadSingletonRepository.GetInstance();
		private readonly ICashRepository cashRepository = new EntityRepositories.Cash.CashRepository(); 
		
		#region Свойства

		public virtual int Id { get; set; }

		DateTime version;
		[Display(Name = "Версия")]
		public virtual DateTime Version {
			get => version;
			set => SetField(ref version, value, () => Version);
		}

		Employee driver;

		[Display(Name = "Водитель")]
		public virtual Employee Driver {
			get => driver;
			set {
				Employee oldDriver = driver;
				if(SetField(ref driver, value, () => Driver)) {
					ChangeFuelDocumentsOnChangeDriver(oldDriver);
					if(Id == 0 || oldDriver != driver)
						Forwarder = GetDefaultForwarder(driver);
				}
			}
		}

		Employee forwarder;

		[Display(Name = "Экспедитор")]
		public virtual Employee Forwarder {
			get => forwarder;
			set {
				if(NHibernate.NHibernateUtil.IsInitialized(Addresses) && (forwarder == null || value == null)) {
					foreach(var address in Addresses)
						address.WithForwarder = value != null;
				}
				SetField(ref forwarder, value, () => Forwarder);
			}
		}

		Employee logistician;

		[Display(Name = "Логист")]
		public virtual Employee Logistician {
			get => logistician;
			set => SetField(ref logistician, value, () => Logistician);
		}

		Car car;

		[Display(Name = "Машина")]
		public virtual Car Car {
			get => car;
			set {
				Car oldCar = car;
				if(SetField(ref car, value, () => Car)) {
					ChangeFuelDocumentsChangeCar(oldCar);

					if(value?.Driver != null && value?.Driver.Status != EmployeeStatus.IsFired)
						Driver = value.Driver;

					if(Id == 0) {
						while(ObservableGeographicGroups.Any())
							ObservableGeographicGroups.Remove(ObservableGeographicGroups.FirstOrDefault());
						if(value != null)
							foreach(var group in value.GeographicGroups)
								ObservableGeographicGroups.Add(group);
					}
				}
			}
		}

		DeliveryShift shift;

		[Display(Name = "Смена доставки")]
		public virtual DeliveryShift Shift {
			get => shift;
			set => SetField(ref shift, value, () => Shift);
		}

		DateTime date;

		[Display(Name = "Дата")]
		[HistoryDateOnly]
		public virtual DateTime Date {
			get => date;
			set => SetField(ref date, value, () => Date);
		}

		Decimal confirmedDistance;

		/// <summary>
		/// Расстояние в километрах
		/// </summary>
		[Display(Name = "Подтверждённое расстояние")]
		public virtual Decimal ConfirmedDistance {
			get => confirmedDistance;
			set => SetField(ref confirmedDistance, value, () => ConfirmedDistance);
		}

		private decimal? planedDistance;

		/// <summary>
		/// Расстояние в километрах
		/// </summary>
		[Display(Name = "Планируемое расстояние")]
		public virtual decimal? PlanedDistance {
			get => planedDistance;
			protected set => SetField(ref planedDistance, value, () => PlanedDistance);
		}

		decimal? recalculatedDistance;

		/// <summary>
		/// Расстояние в километрах.
		/// </summary>
		[Display(Name = "Пересчитанное расстояние")]
		public virtual decimal? RecalculatedDistance {
			get => recalculatedDistance;
			set => SetField(ref recalculatedDistance, value, () => RecalculatedDistance);
		}

		RouteListStatus status;

		[Display(Name = "Статус")]
		public virtual RouteListStatus Status {
			get => status;
			protected set => SetField(ref status, value, () => Status);
		}

		DateTime? closingDate;
		[Display(Name = "Дата закрытия")]
		[HistoryDateOnly]
		public virtual DateTime? ClosingDate {
			get => closingDate;
			set => SetField(ref closingDate, value, () => ClosingDate);
		}

		string closingComment;

		[Display(Name = "Комментарий")]
		public virtual string ClosingComment {
			get => closingComment;
			set => SetField(ref closingComment, value, () => ClosingComment);
		}
		
		string logisticiansComment;
		[Display(Name = "Комментарий ЛО")]
		public virtual string LogisticiansComment {
			get => logisticiansComment;
			set => SetField(ref logisticiansComment, value);
		}
		
		Employee logisticiansCommentAuthor;
		[Display(Name = "Последний редактор комментария ЛО")]
		public virtual Employee LogisticiansCommentAuthor {
			get => logisticiansCommentAuthor;
			set => SetField(ref logisticiansCommentAuthor, value);
		}

		string cashierReviewComment;
		[Display(Name = "Комментарий по закрытию кассы")]
		public virtual string CashierReviewComment {
			get => cashierReviewComment;
			set => SetField(ref cashierReviewComment, value, () => CashierReviewComment);
		}

		private bool wasAcceptedByCashier;
		[Display(Name = "Был подтверждён в диалоге закрытия МЛ")]
		public virtual bool WasAcceptedByCashier {
			get => wasAcceptedByCashier;
			set => SetField(ref wasAcceptedByCashier, value);
		}

		Employee cashier;
		[IgnoreHistoryTrace]
		public virtual Employee Cashier {
			get => cashier;
			set => SetField(ref cashier, value, () => Cashier);
		}

		decimal fixedDriverWage;

		[Display(Name = "Фиксированная заработанная плата водителя")]
		[IgnoreHistoryTrace]
		public virtual decimal FixedDriverWage {
			get => fixedDriverWage;
			set => SetField(ref fixedDriverWage, value, () => FixedDriverWage);
		}

		decimal fixedForwarderWage;

		[Display(Name = "Фиксированная заработанная плата экспедитора")]
		[IgnoreHistoryTrace]
		public virtual decimal FixedForwarderWage {
			get => fixedForwarderWage;
			set => SetField(ref fixedForwarderWage, value, () => FixedForwarderWage);
		}

		Fine bottleFine;

		[Display(Name = "Штраф за бутыли")]
		public virtual Fine BottleFine {
			get => bottleFine;
			set => SetField(ref bottleFine, value, () => BottleFine);
		}

		private FuelOperation fuelOutlayedOperation;

		[Display(Name = "Операции расхода топлива")]
		[IgnoreHistoryTrace]
		public virtual FuelOperation FuelOutlayedOperation {
			get => fuelOutlayedOperation;
			set => SetField(ref fuelOutlayedOperation, value, () => FuelOutlayedOperation);
		}

		private bool differencesConfirmed;

		[Display(Name = "Расхождения подтверждены")]
		public virtual bool DifferencesConfirmed {
			get => differencesConfirmed;
			set => SetField(ref differencesConfirmed, value, () => DifferencesConfirmed);
		}

		private DateTime? lastCallTime;

		[Display(Name = "Время последнего созвона")]
		public virtual DateTime? LastCallTime {
			get => lastCallTime;
			set => SetField(ref lastCallTime, value, () => LastCallTime);
		}

		private bool closingFilled;

		/// <summary>
		/// Внутренее поле говорящее о том что первоначалная подготовка маршрутного листа к закрытию выполнена.
		/// Эта операция выполняется 1 раз при первом открытии диалога закрытия МЛ, тут оставляется пометка о том что операция выполнена.
		/// </summary>
		public virtual bool ClosingFilled {
			get => closingFilled;
			set => SetField(ref closingFilled, value, () => ClosingFilled);
		}

		IList<RouteListItem> addresses = new List<RouteListItem>();

		[Display(Name = "Адреса в маршрутном листе")]
		public virtual IList<RouteListItem> Addresses {
			get => addresses;
			set {
				SetField(ref addresses, value, () => Addresses);
				SetNullToObservableAddresses();
			}
		}

		GenericObservableList<RouteListItem> observableAddresses;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<RouteListItem> ObservableAddresses {
			get {
				if(observableAddresses == null) {
					observableAddresses = new GenericObservableList<RouteListItem>(addresses);
					observableAddresses.ElementAdded += ObservableAddresses_ElementAdded;
					observableAddresses.ElementRemoved += ObservableAddresses_ElementRemoved;
				}
				return observableAddresses;
			}
		}

		IList<FuelDocument> fuelDocuments = new List<FuelDocument>();

		[Display(Name = "Документы выдачи топлива")]
		public virtual IList<FuelDocument> FuelDocuments {
			get => fuelDocuments;
			set => SetField(ref fuelDocuments, value, () => FuelDocuments);
		}

		GenericObservableList<FuelDocument> observableFuelDocuments;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<FuelDocument> ObservableFuelDocuments {
			get {
				if(observableFuelDocuments == null) {
					observableFuelDocuments = new GenericObservableList<FuelDocument>(fuelDocuments);
				}
				return observableFuelDocuments;
			}
		}

		private bool normalWage;

		/// <summary>
		/// Расчет ЗП по нормальной ставке, вне зависимости от того какой тип ЗП стоит у водителя.
		/// </summary>
		public virtual bool NormalWage {
			get => normalWage;
			set => SetField(ref normalWage, value, () => NormalWage);
		}

		private WagesMovementOperations driverWageOperation;

		[Display(Name = "Операция начисления зарплаты водителю")]
		[IgnoreHistoryTrace]
		public virtual WagesMovementOperations DriverWageOperation {
			get => driverWageOperation;
			set => SetField(ref driverWageOperation, value, () => DriverWageOperation);
		}

		private WagesMovementOperations forwarderWageOperation;

		[Display(Name = "Операция начисления зарплаты экспедитору")]
		[IgnoreHistoryTrace]
		public virtual WagesMovementOperations ForwarderWageOperation {
			get => forwarderWageOperation;
			set => SetField(ref forwarderWageOperation, value, () => ForwarderWageOperation);
		}

		private bool isManualAccounting;
		[Display(Name = "Расчёт наличных вручную?")]
		public virtual bool IsManualAccounting {
			get => isManualAccounting;
			set => SetField(ref isManualAccounting, value, () => IsManualAccounting);
		}

		private TimeSpan? onLoadTimeStart;

		[Display(Name = "На погрузку в")]
		public virtual TimeSpan? OnLoadTimeStart {
			get => onLoadTimeStart;
			set => SetField(ref onLoadTimeStart, value, () => OnLoadTimeStart);
		}

		private TimeSpan? onLoadTimeEnd;

		[Display(Name = "Закончить погрузку в")]
		public virtual TimeSpan? OnLoadTimeEnd {
			get => onLoadTimeEnd;
			set => SetField(ref onLoadTimeEnd, value, () => OnLoadTimeEnd);
		}

		private int? onLoadGate;

		[Display(Name = "Ворота на погрузку")]
		public virtual int? OnLoadGate {
			get => onLoadGate;
			set => SetField(ref onLoadGate, value, () => OnLoadGate);
		}

		private bool onLoadTimeFixed;

		[Display(Name = "Время погрузки установлено в ручную")]
		public virtual bool OnloadTimeFixed {
			get => onLoadTimeFixed;
			set => SetField(ref onLoadTimeFixed, value, () => OnloadTimeFixed);
		}

		private bool addressesOrderWasChangedAfterPrinted;
		[Display(Name = "Был изменен порядок адресов после печати")]
		public virtual bool AddressesOrderWasChangedAfterPrinted {
			get => addressesOrderWasChangedAfterPrinted;
			set => SetField(ref addressesOrderWasChangedAfterPrinted, value, () => AddressesOrderWasChangedAfterPrinted);
		}

		string mileageComment;

		[Display(Name = "Комментарий к километражу")]
		public virtual string MileageComment {
			get => mileageComment;
			set => SetField(ref mileageComment, value, () => MileageComment);
		}

		bool mileageCheck;

		[Display(Name = "Проверка километража")]
		public virtual bool MileageCheck {
			get => mileageCheck;
			set => SetField(ref mileageCheck, value, () => MileageCheck);
		}

		Employee closedBy;
		[Display(Name = "Закрыт сотрудником")]
		[IgnoreHistoryTrace]
		public virtual Employee ClosedBy {
			get => closedBy;
			set => SetField(ref closedBy, value, () => ClosedBy);
		}

		private Subdivision closingSubdivision;
		[Display(Name = "Сдается в подразделение")]
		public virtual Subdivision ClosingSubdivision {
			get => closingSubdivision;
			set => SetField(ref closingSubdivision, value, () => ClosingSubdivision);
		}
		
		IList<GeographicGroup> geographicGroups = new List<GeographicGroup>();
		[Display(Name = "Группа района")]
		public virtual IList<GeographicGroup> GeographicGroups {
			get => geographicGroups;
			set => SetField(ref geographicGroups, value, () => GeographicGroups);
		}

		GenericObservableList<GeographicGroup> observableGeographicGroups;
		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<GeographicGroup> ObservableGeographicGroups {
			get {
				if(observableGeographicGroups == null)
					observableGeographicGroups = new GenericObservableList<GeographicGroup>(GeographicGroups);
				return observableGeographicGroups;
			}
		}

		bool? notFullyLoaded;
		[Display(Name = "МЛ погружен не полностью")]
		public virtual bool? NotFullyLoaded {
			get => notFullyLoaded;
			set => SetField(ref notFullyLoaded, value, () => NotFullyLoaded);
		}

		private IList<DocumentPrintHistory> _printsHistory = new List<DocumentPrintHistory>();
		[Display(Name = "История печати маршрутного листа")]
		public virtual IList<DocumentPrintHistory> PrintsHistory
		{
			get => _printsHistory;
			set => SetField(ref _printsHistory, value);
		}

		#endregion

		#region readonly Свойства

		public virtual string Title => string.Format("МЛ №{0}", Id);

		public virtual decimal UniqueAddressCount => Addresses.Where(item => item.IsDelivered())
															  .Select(item => item.Order.DeliveryPoint.Id)
															  .Distinct()
															  .Count();

		public virtual bool NeedMileageCheck => Car.TypeOfUse != CarTypeOfUse.CompanyTruck && Car.IsCompanyCar;

		public virtual decimal PhoneSum {
			get {
				if(Car.TypeOfUse == CarTypeOfUse.CompanyTruck || Driver.VisitingMaster)
					return 0;

				return Wages.GetDriverRates(Date).PhoneServiceCompensationRate * UniqueAddressCount;
			}
		}

		public virtual decimal Total => Addresses.Sum(x => x.TotalCash) - PhoneSum;

		public virtual decimal MoneyToReturn {
			get {
				decimal payedForFuel = FuelDocuments.Where(x => x.PayedForFuel.HasValue && x.FuelPaymentType.HasValue && x.FuelPaymentType == FuelPaymentType.Cash).Sum(x => x.PayedForFuel.Value);

				return Total - payedForFuel;
			}
		}

		/// <summary>
		/// Количество полных 19л бутылей в МЛ для клиентов
		/// </summary>
		/// <returns>Количество полных 19л бутылей</returns>
		public virtual int TotalFullBottlesToClient => Addresses.Sum(a => a.GetFullBottlesToDeliverCount());

		public virtual bool NeedToLoad => Addresses.Any(address => address.NeedToLoad);

		public virtual bool HasMoneyDiscrepancy => Total != cashRepository.CurrentRouteListCash(UoW, Id);

		#endregion

		void ObservableAddresses_ElementRemoved(object aList, int[] aIdx, object aObject)
		{
			CheckAddressOrder();
		}

		void ObservableAddresses_ElementAdded(object aList, int[] aIdx)
		{
			CheckAddressOrder();
		}

		#region Функции

		/// <summary>
		/// Возврат экспедитора по умолчанию для водителя <paramref name="driver"/>
		/// </summary>
		/// <returns>Экспедитор по умолчание если не уволен</returns>
		/// <param name="driver">Водитель</param>
		Employee GetDefaultForwarder(Employee driver)
		{
			if(driver?.DefaultForwarder?.Status == EmployeeStatus.IsFired) {
				//если больше не с нами,то не нужно его держать умолчальным в водителе
				driver.DefaultForwarder = null;
			} else if(driver != null && driver.DefaultForwarder != null) {
				return driver.DefaultForwarder;
			}
			return null;
		}

		public virtual void ChangeFuelDocumentsChangeCar(Car oldCar)
		{
			if(oldCar == null || Car == oldCar || !FuelDocuments.Any()) {
				return;
			}

			foreach(FuelDocument item in ObservableFuelDocuments) {
				item.Car = Car;
				item.FuelOperation.Car = Car;
			}
		}

		public virtual void ChangeFuelDocumentsOnChangeDriver(Employee oldDriver)
		{
			if(Driver == null || oldDriver == null || Driver == oldDriver || !FuelDocuments.Any())
				return;

			foreach(FuelDocument item in ObservableFuelDocuments) {
				item.Driver = Driver;
				item.FuelOperation.Driver = Driver;
			}
		}

		public virtual bool FuelOperationHaveDiscrepancy()
		{
			if(FuelOutlayedOperation == null) {
				return false;
			}
			var carDiff = FuelDocuments.Select(x => x.FuelOperation).Any(x => x.Car != null && x.Car.Id != Car.Id)
									   || (FuelOutlayedOperation.Car != null && FuelOutlayedOperation.Car.Id != Car.Id);
			var driverDiff = FuelDocuments.Select(x => x.FuelOperation).Any(x => x.Driver != null && x.Driver.Id != Driver.Id)
										  || (FuelOutlayedOperation.Driver != null && FuelOutlayedOperation.Driver.Id != Driver.Id);
			return carDiff || driverDiff;
		}

		public virtual RouteListItem AddAddressFromOrder(Order order)
		{
			if(order == null) throw new ArgumentNullException(nameof(order));

			if(order.DeliveryPoint == null)
				throw new NullReferenceException("В маршрутный нельзя добавить заказ без точки доставки.");
			var item = new RouteListItem(this, order, RouteListItemStatus.EnRoute) {
				WithForwarder = Forwarder != null
			};
			ObservableAddresses.Add(item);
			return item;
		}

		public virtual bool TryRemoveAddress(RouteListItem address, out string msg, IRouteListItemRepository routeListItemRepository)
		{
			if(routeListItemRepository == null)
				throw new ArgumentNullException(nameof(routeListItemRepository));

			msg = string.Empty;
			if(address.WasTransfered) {
				var from = routeListItemRepository.GetTransferedFrom(UoW, address)?.RouteList?.Id;
				msg = string.Format(
					"Адрес \"{0}\" не может быть удалён, т.к. был перенесён из МЛ №{1}. Воспользуйтесь функционалом из вкладки \"Перенос адресов маршрутных листов\" для возврата этого адреса в исходный МЛ.",
					address.Order.DeliveryPoint?.ShortAddress,
					from.HasValue ? from.Value.ToString() : "???"
				);
				return false;
			}
			address.RemovedFromRoute();
			UoW.Delete(address);
			ObservableAddresses.Remove(address);
			return true;
		}

		public virtual void RemoveAddress(RouteListItem address)
		{
			if(!TryRemoveAddress(address, out string message, new RouteListItemRepository()))
				throw new NotSupportedException(string.Format("\n\n{0}\n", message));
		}

		public virtual void CheckAddressOrder()
		{
			for(int i = 0; i < Addresses.Count; i++) {
				if(Addresses[i] == null) {
					Addresses.RemoveAt(i);
					i--;
					continue;
				}

				if(Addresses[i].IndexInRoute != i) {
					if(PrintsHistory?.Any() ?? false) {
						AddressesOrderWasChangedAfterPrinted = true;
					}
					Addresses[i].IndexInRoute = i;
				}
			}
		}

		public virtual void CheckFuelDocumentOrder()
		{
			for(int i = 0; i < FuelDocuments.Count; i++) {
				if(FuelDocuments[i] == null) {
					FuelDocuments.RemoveAt(i);
					i--;
					continue;
				}

				if(FuelDocuments[i].RouteList.Id != i)
					FuelDocuments[i].RouteList.Id = i;
			}
		}

		private void SetNullToObservableAddresses()
		{
			if(observableAddresses == null)
				return;
			observableAddresses.ElementAdded -= ObservableAddresses_ElementAdded;
			observableAddresses.ElementRemoved -= ObservableAddresses_ElementRemoved;
			observableAddresses = null;
		}

		public virtual void RollBackEnRouteStatus()
		{
			Status = RouteListStatus.EnRoute;
			ClosingFilled = false;
			foreach(var item in Addresses.Where(x => x.Status == RouteListItemStatus.Completed)) {
				item.Order.OrderStatus = OrderStatus.OnTheWay;
			}

			UoW.Save(this);
		}

		public virtual bool ShipIfCan(IUnitOfWork uow, CallTaskWorker callTaskWorker)
		{
			var routeListRepository = new RouteListRepository();

			var terminalId = new BaseParametersProvider().GetNomenclatureIdForTerminal;

			var terminalsTransferedToThisRL = routeListRepository.TerminalTransferedCountToRouteList(uow, this);

			var inLoaded = routeListRepository.AllGoodsLoaded(uow, this);
			var goods = routeListRepository.GetGoodsAndEquipsInRL(uow, this);

			bool closed = true;
			foreach(var good in goods) {
				var loaded = inLoaded.FirstOrDefault(x => x.NomenclatureId == good.NomenclatureId);

				if(good.NomenclatureId == terminalId 
					&& (loaded?.Amount ?? 0) + terminalsTransferedToThisRL == good.Amount)
				{
					continue;
				}

				if(loaded == null || loaded.Amount < good.Amount) {
					closed = false;
					break;
				}
			}

			if(closed) {
				if(NotFullyLoaded.HasValue)
					NotFullyLoaded = false;
				if(new[] { RouteListStatus.Confirmed, RouteListStatus.InLoading }.Contains(Status))
					ChangeStatusAndCreateTask(RouteListStatus.EnRoute, callTaskWorker);
			}

			return closed;
		}


		public virtual List<Discrepancy> GetDiscrepancies(IList<RouteListControlNotLoadedNode> itemsLoaded,
		                                                  List<ReturnsNode> allReturnsToWarehouse)
		{
			List<Discrepancy> result = new List<Discrepancy>();

			#region Товары

			foreach(var address in Addresses) {
				foreach(var orderItem in address.Order.OrderItems) {
					if(!Nomenclature.GetCategoriesForShipment().Contains(orderItem.Nomenclature.Category)
						|| orderItem.Nomenclature.Category == NomenclatureCategory.bottle) 
					{
						continue;
					}
					Discrepancy discrepancy = null;
					
					if(address.TransferedTo == null) {
						discrepancy = new Discrepancy {
							ClientRejected = orderItem.ReturnedCount, 
							Nomenclature = orderItem.Nomenclature, 
							Name = orderItem.Nomenclature.Name
						};
					} else if(address.TransferedTo.NeedToReload) {
						discrepancy = new Discrepancy {
							ClientRejected = orderItem.Count, 
							Nomenclature = orderItem.Nomenclature, 
							Name = orderItem.Nomenclature.Name
						};
					}
					if(discrepancy != null && discrepancy.ClientRejected != 0) {
						AddDiscrepancy(result, discrepancy);
					}
				}
			}

			#endregion

			//Терминал для оплаты
			var terminalId = new BaseParametersProvider().GetNomenclatureIdForTerminal;
			var loadedTerminalAmount = carLoadDocumentRepository.LoadedTerminalAmount(UoW, Id, terminalId);
			var unloadedTerminalAmount = carUnloadRepository.UnloadedTerminalAmount(UoW, Id, terminalId);

			if (loadedTerminalAmount > 0) {
				var terminal = UoW.GetById<Nomenclature>(terminalId);

				var discrepancyTerminal = new Discrepancy {
					Nomenclature = terminal,
					PickedUpFromClient = loadedTerminalAmount,
					Name = terminal.Name
				};

				if (unloadedTerminalAmount > 0) discrepancyTerminal.ToWarehouse = unloadedTerminalAmount;

				AddDiscrepancy(result, discrepancyTerminal);
			}

			//ОБОРУДОВАНИЕ

			foreach (var address in Addresses)
			{
				foreach (var orderEquipment in address.Order.OrderEquipments)
				{
					if (!Nomenclature.GetCategoriesForShipment().Contains(orderEquipment.Nomenclature.Category))
					{
						continue;
					}
					var discrepancy = new Discrepancy
					{
						Nomenclature = orderEquipment.Nomenclature,
						Name = orderEquipment.Nomenclature.Name
					};

					if (address.TransferedTo == null)
					{
						if (orderEquipment.Direction == Direction.Deliver)
						{
							discrepancy.ClientRejected = orderEquipment.ReturnedCount;
						}
						else
						{
							discrepancy.PickedUpFromClient = orderEquipment.ActualCount ?? 0;
						}
						AddDiscrepancy(result, discrepancy);
					}
					else if (address.TransferedTo.NeedToReload)
					{
						if (orderEquipment.Direction == Direction.Deliver)
						{// не обрабатываем pickup, т.к. водитель физически не был на адресе, чтобы забрать оборудование
							discrepancy.ClientRejected = orderEquipment.Count;
							AddDiscrepancy(result, discrepancy);
						}
					}
				}
			}

			//ДОСТАВЛЕНО НА СКЛАД
			var warehouseItems = allReturnsToWarehouse.Where(x => x.NomenclatureCategory != NomenclatureCategory.bottle)
													  .ToList();
			foreach(var whItem in warehouseItems) {
				var discrepancy = new Discrepancy {
					Nomenclature = whItem.Nomenclature,
					ToWarehouse = whItem.Amount,
					Name = whItem.Name
				};
				AddDiscrepancy(result, discrepancy);
			}

			if(itemsLoaded != null && itemsLoaded.Any()) {
				var loadedItems = itemsLoaded.Where(x => x.Nomenclature.Category != NomenclatureCategory.bottle);
				foreach(var item in loadedItems) {
					var discrepancy = new Discrepancy {
						Nomenclature = item.Nomenclature,
						FromWarehouse = item.CountNotLoaded,
						Name = item.Nomenclature.Name
					};

					AddDiscrepancy(result, discrepancy);
				}
			}

			return result;
		}

		/// <summary>
		/// Добавляет новое расхождение если такой номенклатуры нет в списке, 
		/// иначе прибавляет все значения к найденной в списке номенклатуре
		/// </summary>
		void AddDiscrepancy(List<Discrepancy> list, Discrepancy item)
		{
			var existingDiscrepancy = list.FirstOrDefault(x => x.Nomenclature == item.Nomenclature);
			if(existingDiscrepancy == null) {
				list.Add(item);
			} else {
				existingDiscrepancy.ClientRejected += item.ClientRejected;
				existingDiscrepancy.PickedUpFromClient += item.PickedUpFromClient;
				existingDiscrepancy.ToWarehouse += item.ToWarehouse;
				existingDiscrepancy.FromWarehouse += item.FromWarehouse;
			}
		}

		public virtual bool IsConsistentWithUnloadDocument()
		{
			var returnedBottlesNom = int.Parse(SingletonParametersProvider.Instance.GetParameterValue("returned_bottle_nomenclature_id"));
			var bottlesReturnedToWarehouse = (int)new RouteListRepository().GetReturnsToWarehouse(
				UoW,
				Id,
				returnedBottlesNom)
			.Sum(item => item.Amount);

			var notloadedNomenclatures = NotLoadedNomenclatures(true);
			var allReturnsToWarehouse = new RouteListRepository().GetReturnsToWarehouse(UoW, Id, Nomenclature.GetCategoriesForShipment());
			var discrepancies = GetDiscrepancies(notloadedNomenclatures, allReturnsToWarehouse);

			var hasItemsDiscrepancies = discrepancies.Any(discrepancy => discrepancy.Remainder != 0);
			bool hasFine = BottleFine != null;
			var items = Addresses.Where(item => item.IsDelivered());
			int bottlesReturnedTotal = items.Sum(item => item.BottlesReturned);
			var hasTotalBottlesDiscrepancy = bottlesReturnedToWarehouse != bottlesReturnedTotal;
			return hasFine || (!hasTotalBottlesDiscrepancy && !hasItemsDiscrepancies) || DifferencesConfirmed;
		}

		public virtual void ChangeStatusAndCreateTask(RouteListStatus newStatus, CallTaskWorker callTaskWorker)
		{
			if(newStatus == Status)
				return;

			string exceptionMessage = $"Некорректная операция. Не предусмотрена смена статуса с {Status} на {newStatus}";

			switch(newStatus) {
				case RouteListStatus.New:
					if(Status == RouteListStatus.Confirmed || Status == RouteListStatus.InLoading) {
						Status = RouteListStatus.New;
						foreach(var address in Addresses) {
							if(address.Order.OrderStatus == OrderStatus.OnLoading) {
								address.Order.ChangeStatusAndCreateTasks(OrderStatus.InTravelList, callTaskWorker);
							}
						}
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.Confirmed:
					if(Status == RouteListStatus.New || Status == RouteListStatus.InLoading) {
						Status = RouteListStatus.Confirmed;
						foreach(var address in Addresses) {
							if(address.Order.OrderStatus < OrderStatus.OnLoading) {
								address.Order.ChangeStatusAndCreateTasks(OrderStatus.OnLoading, callTaskWorker);
							}
						}
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.InLoading:
					if(Status == RouteListStatus.EnRoute) {
						Status = RouteListStatus.InLoading;
						foreach(var item in Addresses) {
							if(item.Order.OrderStatus != OrderStatus.OnLoading) {
								item.Order.ChangeStatusAndCreateTasks(OrderStatus.OnLoading, callTaskWorker);
							}
						}
					} else if(Status == RouteListStatus.Confirmed) {
						Status = RouteListStatus.InLoading;
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.EnRoute:
					if(Status == RouteListStatus.InLoading || Status == RouteListStatus.Confirmed
					|| Status == RouteListStatus.Delivered) {
						if(Status != RouteListStatus.Delivered) {
							foreach(var item in Addresses) {
								bool isInvalidStatus = OrderSingletonRepository.GetInstance().GetUndeliveryStatuses().Contains(item.Order.OrderStatus);

								if(!isInvalidStatus)
									item.Order.OrderStatus = OrderStatus.OnTheWay;
							}
						}
						Status = RouteListStatus.EnRoute;
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.Delivered:
					if (Status == RouteListStatus.EnRoute)
					{
						Status = newStatus;
					}
					else
					{
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.OnClosing:
					if(
					(Status == RouteListStatus.Delivered && (Car.TypeOfUse == CarTypeOfUse.CompanyTruck || Driver.VisitingMaster || !NeedMileageCheckByWage))
					|| (Status == RouteListStatus.Confirmed && (Car.TypeOfUse == CarTypeOfUse.CompanyTruck))
					|| Status == RouteListStatus.MileageCheck || Status == RouteListStatus.Delivered
					|| Status == RouteListStatus.Closed) {
						Status = newStatus;
						foreach(var item in Addresses.Where(x => x.Status == RouteListItemStatus.Completed || x.Status == RouteListItemStatus.EnRoute)) {
							item.Order.ChangeStatusAndCreateTasks(OrderStatus.UnloadingOnStock, callTaskWorker);
						}
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.MileageCheck:
					if(Status == RouteListStatus.Delivered || Status == RouteListStatus.OnClosing) {
						Status = newStatus;
						foreach(var item in Addresses.Where(x => x.Status == RouteListItemStatus.Completed || x.Status == RouteListItemStatus.EnRoute)) {
							item.Order.ChangeStatusAndCreateTasks(OrderStatus.UnloadingOnStock, callTaskWorker);
						}
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.Closed:
					if(Status == RouteListStatus.OnClosing
					|| Status == RouteListStatus.MileageCheck
					|| Status == RouteListStatus.Delivered) {
						Status = newStatus;
						CloseAddressesAndCreateTask(callTaskWorker);
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				default:
					throw new NotImplementedException($"Не реализовано изменение статуса для {newStatus}");
			}

			UpdateDeliveryDocuments(UoW);
			UpdateClosedInformation();
		}
		
		public virtual void ChangeStatus(RouteListStatus newStatus)
		{
			if(newStatus == Status)
				return;

			string exceptionMessage = $"Некорректная операция. Не предусмотрена смена статуса с {Status} на {newStatus}";

			switch(newStatus) {
				case RouteListStatus.New:
					if(Status == RouteListStatus.Confirmed || Status == RouteListStatus.InLoading) {
						Status = RouteListStatus.New;
						foreach(var address in Addresses) {
							if(address.Order.OrderStatus == OrderStatus.OnLoading) {
								address.Order.ChangeStatus(OrderStatus.InTravelList);
							}
						}
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.Confirmed:
					if(Status == RouteListStatus.New || Status == RouteListStatus.InLoading) {
						Status = RouteListStatus.Confirmed;
						foreach(var address in Addresses) {
							if(address.Order.OrderStatus < OrderStatus.OnLoading) {
								address.Order.ChangeStatus(OrderStatus.OnLoading);
							}
						}
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.InLoading:
					if(Status == RouteListStatus.EnRoute) {
						Status = RouteListStatus.InLoading;
						foreach(var item in Addresses) {
							if(item.Order.OrderStatus != OrderStatus.OnLoading) {
								item.Order.ChangeStatus(OrderStatus.OnLoading);
							}
						}
					} else if(Status == RouteListStatus.Confirmed) {
						Status = RouteListStatus.InLoading;
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.EnRoute:
					if(Status == RouteListStatus.InLoading 
					   || Status == RouteListStatus.Confirmed
					   || Status == RouteListStatus.Delivered) {
						foreach(var item in Addresses) {
							bool isInvalidStatus =  OrderSingletonRepository.GetInstance().GetUndeliveryStatuses().Contains(item.Order.OrderStatus);

							if(!isInvalidStatus)
								item.Order.OrderStatus = OrderStatus.OnTheWay;
						}
						Status = RouteListStatus.EnRoute;
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.Delivered:
					if (Status == RouteListStatus.EnRoute) {
						Status = newStatus;
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.OnClosing:
					if(
					(Status == RouteListStatus.EnRoute && (Car.TypeOfUse == CarTypeOfUse.CompanyTruck || Driver.VisitingMaster || !NeedMileageCheckByWage))
					|| (Status == RouteListStatus.Confirmed && (Car.TypeOfUse == CarTypeOfUse.CompanyTruck))
					|| Status == RouteListStatus.MileageCheck 
					|| Status == RouteListStatus.Delivered
					|| Status == RouteListStatus.Closed) {
						Status = newStatus;
						foreach(var item in Addresses.Where(x => x.Status == RouteListItemStatus.Completed || x.Status == RouteListItemStatus.EnRoute)) {
							item.Order.ChangeStatus(OrderStatus.UnloadingOnStock);
						}
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.MileageCheck:
					if(Status == RouteListStatus.Delivered || Status == RouteListStatus.OnClosing) {
						Status = newStatus;
						foreach(var item in Addresses.Where(x => x.Status == RouteListItemStatus.Completed || x.Status == RouteListItemStatus.EnRoute)) {
							item.Order.ChangeStatus(OrderStatus.UnloadingOnStock);
						}
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				case RouteListStatus.Closed:
					if(Status == RouteListStatus.OnClosing 
					   || Status == RouteListStatus.MileageCheck
					   || Status == RouteListStatus.Delivered) {
						Status = newStatus;
						CloseAddresses();
					} else {
						throw new InvalidOperationException(exceptionMessage);
					}
					break;
				default:
					throw new NotImplementedException($"Не реализовано изменение статуса для {newStatus}");
			}

			UpdateDeliveryDocuments(UoW);
			UpdateClosedInformation();
		}

		private void UpdateClosedInformation()
		{
			if(Status == RouteListStatus.Closed) {
				ClosedBy = EmployeeRepository.GetEmployeeForCurrentUser(UoW);
				ClosingDate = DateTime.Now;
			} else {
				ClosedBy = null;
				ClosingDate = null;
			}
		}

		private void CloseAddressesAndCreateTask(CallTaskWorker callTaskWorker)
		{
			if(Status != RouteListStatus.Closed) {
				return;
			}

			foreach(var address in Addresses) {
				if(address.Status == RouteListItemStatus.Completed || address.Status == RouteListItemStatus.EnRoute) {
					if(address.Status == RouteListItemStatus.EnRoute) {
						address.UpdateStatusAndCreateTask(UoW, RouteListItemStatus.Completed, callTaskWorker);
					}
					address.Order.ChangeStatusAndCreateTasks(OrderStatus.Closed, callTaskWorker);
				}

				if(address.Status == RouteListItemStatus.Canceled) {
					address.Order.ChangeStatusAndCreateTasks(OrderStatus.DeliveryCanceled, callTaskWorker);
				}

				if(address.Status == RouteListItemStatus.Overdue) {
					address.Order.ChangeStatusAndCreateTasks(OrderStatus.NotDelivered, callTaskWorker);
				}
			}
		}
		
		private void CloseAddresses()
		{
			if(Status != RouteListStatus.Closed) {
				return;
			}

			foreach(var address in Addresses) {
				if(address.Status == RouteListItemStatus.Completed || address.Status == RouteListItemStatus.EnRoute) {
					if(address.Status == RouteListItemStatus.EnRoute) {
						address.UpdateStatus(UoW, RouteListItemStatus.Completed);
					}
					address.Order.ChangeStatus(OrderStatus.Closed);
				}

				if(address.Status == RouteListItemStatus.Canceled) {
					address.Order.ChangeStatus(OrderStatus.DeliveryCanceled);
				}

				if(address.Status == RouteListItemStatus.Overdue) {
					address.Order.ChangeStatus(OrderStatus.NotDelivered);
				}
			}
		}

		public virtual void AddPrintHistory()
		{
			var newHistory = new DocumentPrintHistory
			{
				PrintingTime = DateTime.Now,
				DocumentType = PrintAsClosed() ? PrintedDocumentType.ClosedRouteList : PrintedDocumentType.RouteList,
				RouteList = this
			};
			_printsHistory.Add(newHistory);
		}
		
		/// <summary>
		/// Указывает, находится ли МЛ в таком статусе, что его надо печатать как ClosedRouteList.rdl
		/// </summary>
		public virtual bool PrintAsClosed() =>
			new[] { RouteListStatus.Delivered, RouteListStatus.MileageCheck, RouteListStatus.OnClosing, RouteListStatus.Closed }
				.Contains(Status);

		#endregion

		#region IValidatableObject implementation

		public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
            bool cashOrderClose = false;
            if (validationContext.Items.ContainsKey("cash_order_close"))
            {
                cashOrderClose = (bool)validationContext.Items["cash_order_close"];
            }
            if (validationContext.Items.ContainsKey("NewStatus")) {
				RouteListStatus newStatus = (RouteListStatus)validationContext.Items["NewStatus"];
				switch(newStatus) {
					case RouteListStatus.New:
					case RouteListStatus.Confirmed:
					case RouteListStatus.InLoading:
					case RouteListStatus.Closed: break;
					case RouteListStatus.MileageCheck:
						foreach(var address in Addresses) {
							var orderValidator = new ObjectValidator();
							orderValidator.Validate(
									address.Order,
									new ValidationContext(
										address.Order,
										null,
										new Dictionary<object, object> {
											{ "NewStatus", OrderStatus.Closed},
                                            { "cash_order_close", cashOrderClose},
											{ "AddressStatus", address.Status}
										}
									)
								);

							foreach(var result in orderValidator.Results)
								yield return result;
						}
						break;
					case RouteListStatus.EnRoute: break;
					case RouteListStatus.OnClosing: break;
				}
			}

			if(validationContext.Items.ContainsKey(nameof(IRouteListItemRepository))) {
				IRouteListItemRepository rliRepository = (IRouteListItemRepository)validationContext.Items[nameof(IRouteListItemRepository)];
				foreach(var address in Addresses) {
					if(rliRepository.AnotherRouteListItemForOrderExist(UoW, address))
						yield return new ValidationResult($"Один из адрессов, находится в другом МЛ");
					
					foreach (var result in address.Validate(new ValidationContext(address)))
						yield return result;
				}
			} else {
				throw new ArgumentException($"Для валидации МЛ должен быть доступен {typeof(IRouteListRepository)}");
			}


			if(!GeographicGroups.Any())
				yield return new ValidationResult(
						"Необходимо указать район",
						new[] { Gamma.Utilities.PropertyUtil.GetPropertyName(this, o => o.GeographicGroups) }
					);

			if(ClosingSubdivision == null)
				yield return new ValidationResult("Не выбрана касса в которую должен будет сдаваться водитель.",
					new[] { Gamma.Utilities.PropertyUtil.GetPropertyName(this, o => o.ClosingSubdivision) });

			if(Driver == null)
				yield return new ValidationResult("Не заполнен водитель.",
					new[] { Gamma.Utilities.PropertyUtil.GetPropertyName(this, o => o.Driver) });

			if(Car == null)
				yield return new ValidationResult("На заполнен автомобиль.",
					new[] { Gamma.Utilities.PropertyUtil.GetPropertyName(this, o => o.Car) });
		}

		#endregion

		#region Функции относящиеся к закрытию МЛ

		/// <summary>
		/// Проверка по установленным вариантам расчета зарплаты, должен ли водитель на данном автомобилей проходить проверку километража
		/// </summary>
		private bool NeedMileageCheckByWage {
			get {
				if(Car.IsCompanyCar) {
					return true;
				}
				var actualWageParameter = Driver.GetActualWageParameter(Date);
				return actualWageParameter == null || actualWageParameter.WageParameterItem.WageParameterItemType != WageParameterItemTypes.RatesLevel;
			}
		}
		
		public virtual void CompleteRouteAndCreateTask(WageParameterService wageParameterService, CallTaskWorker callTaskWorker)
		{
			if(wageParameterService == null) {
				throw new ArgumentNullException(nameof(wageParameterService));
			}

			if(NeedMileageCheck) {
				ChangeStatusAndCreateTask(RouteListStatus.MileageCheck, callTaskWorker);
			} else {
				ChangeStatusAndCreateTask(RouteListStatus.OnClosing, callTaskWorker);
			}

			var track = Repository.Logistics.TrackRepository.GetTrackForRouteList(UoW, Id);
			if(track != null) {
				track.CalculateDistance();
				track.CalculateDistanceToBase();
				UoW.Save(track);
			}
			
			FirstFillClosing(wageParameterService);
			UoW.Save(this);
		}
		
		public virtual void CompleteRoute(WageParameterService wageParameterService)
		{
			if(wageParameterService == null) {
				throw new ArgumentNullException(nameof(wageParameterService));
			}

			ChangeStatus(RouteListStatus.Delivered);

			var track = Repository.Logistics.TrackRepository.GetTrackForRouteList(UoW, Id);
			if(track != null) {
				track.CalculateDistance();
				track.CalculateDistanceToBase();
				UoW.Save(track);
			}
			
			FirstFillClosing(wageParameterService);
			UoW.Save(this);
		}
		
		//FIXME потом метод скрыть. Должен вызываться только при переходе в статус на закрытии.
		public virtual void FirstFillClosing(WageParameterService wageParameterService)
		{
			if(wageParameterService == null) {
				throw new ArgumentNullException(nameof(wageParameterService));
			}

			PerformanceHelper.StartMeasurement("Первоначальное заполнение");
			var addresesDelivered = Addresses.Where(x => x.Status != RouteListItemStatus.Transfered);
			foreach(var routeListItem in addresesDelivered) {
				PerformanceHelper.StartPointsGroup($"Заказ {routeListItem.Order.Id}");

				logger.Debug("Количество элементов в заказе {0}", routeListItem.Order.OrderItems.Count);
				routeListItem.FirstFillClosing(UoW, wageParameterService);
				PerformanceHelper.EndPointsGroup();
			}

			PerformanceHelper.AddTimePoint("Закончили");
			PerformanceHelper.Main.PrintAllPoints(logger);
			ClosingFilled = true;
		}

		public virtual void UpdateBottlesMovementOperation(IStandartNomenclatures standartNomenclatures)
		{
			foreach(RouteListItem address in addresses.Where(x => x.Status != RouteListItemStatus.Transfered))
				address.Order.UpdateBottleMovementOperation(UoW, standartNomenclatures, returnByStock: address.BottlesReturned);
		}

		public virtual List<CounterpartyMovementOperation> UpdateCounterpartyMovementOperations()
		{
			var result = new List<CounterpartyMovementOperation>();
			var addresesDelivered = Addresses.Where(x => x.Status != RouteListItemStatus.Transfered).ToList();
			foreach(var orderItem in addresesDelivered.SelectMany(item => item.Order.OrderItems)
				.Where(item => Nomenclature.GetCategoriesForShipment().Contains(item.Nomenclature.Category))
				.Where(item => !item.Nomenclature.IsSerial)) {
				var operation = orderItem.UpdateCounterpartyOperation(UoW);
				if(operation != null)
					result.Add(operation);
			}

			foreach(var orderEquipment in addresesDelivered.SelectMany(item => item.Order.OrderEquipments)
					.Where(item => Nomenclature.GetCategoriesForShipment().Contains(item.Nomenclature.Category))
				   ) {
				var operation = orderEquipment.UpdateCounterpartyOperation();
				if(operation != null)
					result.Add(operation);
			}
			return result;
		}

		public virtual List<DepositOperation> UpdateDepositOperations(IUnitOfWork UoW)
		{
			var result = new List<DepositOperation>();
			var addresesDelivered = Addresses.Where(x => x.Status != RouteListItemStatus.Transfered).ToList();
			foreach(RouteListItem item in addresesDelivered) {

				//Возврат залогов
				var bottleRefundDeposit = Math.Abs(item.BottleDepositsCollected);
				var equipmentRefundDeposit = Math.Abs(item.EquipmentDepositsCollected);

				var operations = item.Order.UpdateDepositOperations(UoW, equipmentRefundDeposit, bottleRefundDeposit);

				operations?.ForEach(x => result.Add(x));
			}
			return result;
		}

		public virtual List<MoneyMovementOperation> UpdateMoneyMovementOperations()
		{
			var result = new List<MoneyMovementOperation>();
			var addresesDelivered = Addresses.Where(x => x.Status != RouteListItemStatus.Transfered).ToList();
			foreach(var address in addresesDelivered) {
				var order = address.Order;
				var depositsTotal = order.OrderDepositItems.Sum(dep => dep.ActualCount ?? 0 * dep.Deposit);
				decimal? money = null;
				if(address.TotalCash != 0)
					money = address.TotalCash;
				MoneyMovementOperation moneyMovementOperation = order.MoneyMovementOperation;
				if(moneyMovementOperation == null) {
					moneyMovementOperation = new MoneyMovementOperation {
						OperationTime = order.DeliveryDate.Value.Date.AddHours(23).AddMinutes(59),
						Order = order,
						Counterparty = order.Client,
						PaymentType = order.PaymentType,
						Debt = order.ActualGoodsTotalSum,
						Money = money,
						Deposit = depositsTotal
					};
				} else {
					moneyMovementOperation.PaymentType = order.PaymentType;
					moneyMovementOperation.Debt = order.ActualGoodsTotalSum;
					moneyMovementOperation.Money = money;
					moneyMovementOperation.Deposit = depositsTotal;
				}
				order.MoneyMovementOperation = moneyMovementOperation;
				result.Add(moneyMovementOperation);
			}
			return result;
		}

		public virtual string[] ManualCashOperations(ref Income cashIncome, ref Expense cashExpense, decimal casheInput)
		{
			var messages = new List<string>();

			if(Cashier?.Subdivision == null) {
				messages.Add("Создающий кассовые документы пользователь - не привязан к сотруднику!");
				return messages.ToArray();
			}

			if(casheInput > 0) {
				cashIncome = new Income {
					IncomeCategory = CategoryRepository.RouteListClosingIncomeCategory(UoW),
					TypeOperation = IncomeType.DriverReport,
					Date = DateTime.Now,
					Casher = this.Cashier,
					Employee = Driver,
					Description = $"Дополнение к МЛ №{this.Id} от {Date:d}",
					Money = Math.Round(casheInput, 0, MidpointRounding.AwayFromZero),
					RouteListClosing = this,
					RelatedToSubdivision = Cashier.Subdivision
				};

				messages.Add($"Создан приходный ордер на сумму {cashIncome.Money:C0}");
				routeListCashOrganisationDistributor.DistributeIncomeCash(UoW, this, cashIncome, cashIncome.Money);
			} else {
				cashExpense = new Expense {
					ExpenseCategory = CategoryRepository.RouteListClosingExpenseCategory(UoW),
					TypeOperation = ExpenseType.Expense,
					Date = DateTime.Now,
					Casher = this.Cashier,
					Employee = Driver,
					Description = $"Дополнение к МЛ #{this.Id} от {Date:d}",
					Money = Math.Round(-casheInput, 0, MidpointRounding.AwayFromZero),
					RouteListClosing = this,
					RelatedToSubdivision = Cashier.Subdivision
				};
				messages.Add($"Создан расходный ордер на сумму {cashExpense.Money:C0}");
				routeListCashOrganisationDistributor.DistributeExpenseCash(UoW, this, cashExpense, cashExpense.Money);
			}
			IsManualAccounting = true;
			return messages.ToArray();
		}

		public virtual string EmployeeAdvanceOperation(ref Expense cashExpense, decimal cashInput)
		{
			string message;
			if(Cashier?.Subdivision == null)
				return "Создающий кассовый документ пользователь - не привязан к сотруднику!";

			cashExpense = new Expense {
				ExpenseCategory = CategoryRepository.EmployeeSalaryExpenseCategory(UoW),
				TypeOperation = ExpenseType.EmployeeAdvance,
				Date = DateTime.Now,
				Casher = this.Cashier,
				Employee = Driver,
				Organisation = commonOrganisationProvider.GetCommonOrganisation(UoW),
				Description = $"Выдача аванса к МЛ #{this.Id} от {Date:d}",
				Money = Math.Round(cashInput, 0, MidpointRounding.AwayFromZero),
				RouteListClosing = this,
				RelatedToSubdivision = Cashier.Subdivision
			};

			message = $"Создан расходный ордер на сумму {cashExpense.Money:C0}";
			expenseCashOrganisationDistributor.DistributeCashForExpense(UoW, cashExpense, true);			
			return (message);
		}

		private void ConfirmAndClose(CallTaskWorker callTaskWorker)
		{
			if(Status != RouteListStatus.OnClosing && Status != RouteListStatus.MileageCheck) {
				throw new InvalidOperationException(String.Format("Закрыть маршрутный лист можно только если он находится в статусе {0} или  {1}", RouteListStatus.OnClosing, RouteListStatus.MileageCheck));
			}

			if(Driver != null && Driver.FirstWorkDay == null) {
				Driver.FirstWorkDay = date;
				UoW.Save(Driver);
			}

			if(Forwarder != null && Forwarder.FirstWorkDay == null) {
				Forwarder.FirstWorkDay = date;
				UoW.Save(Forwarder);
			}

			switch(Status) {
				case RouteListStatus.OnClosing:
					CloseFromOnClosing(callTaskWorker);
					break;
				case RouteListStatus.MileageCheck:
					CloseFromOnMileageCheck(callTaskWorker);
					break;
			}
		}

		private void CloseFromOnMileageCheck(CallTaskWorker callTaskWorker)
		{
			if(Status != RouteListStatus.MileageCheck) {
				return;
			}

			if(WasAcceptedByCashier && IsConsistentWithUnloadDocument() && !HasMoneyDiscrepancy) {
				ChangeStatusAndCreateTask(RouteListStatus.Closed, callTaskWorker);
			}
			else {
				ChangeStatusAndCreateTask(RouteListStatus.OnClosing, callTaskWorker);
			}
		}

		/// <summary>
		/// Закрывает МЛ, либо переводит в проверку км, при необходимых условиях, из статуса "Сдается" 
		/// </summary>
		private void CloseFromOnClosing(CallTaskWorker callTaskWorker)
		{
			if(Status != RouteListStatus.OnClosing) {
				return;
			}

			if((!NeedMileageCheck || (NeedMileageCheck && ConfirmedDistance > 0)) && IsConsistentWithUnloadDocument() 
				&& new PermissionRepository().HasAccessToClosingRoutelist(UoW, new SubdivisionRepository(), EmployeeSingletonRepository.GetInstance(), ServicesConfig.UserService)) {
				ChangeStatusAndCreateTask(RouteListStatus.Closed, callTaskWorker);
				return;
			}

			if(NeedMileageCheck && ConfirmedDistance <= 0) {
				ChangeStatusAndCreateTask(RouteListStatus.MileageCheck, callTaskWorker);
				return;
			}
		}

		public virtual void AcceptCash(CallTaskWorker callTaskWorker)
		{
			if(Status != RouteListStatus.OnClosing) {
				return;
			}

			if(cashier == null) {
				throw new InvalidOperationException(String.Format("Должен быть заполнен кассир"));
			}

			ConfirmAndClose(callTaskWorker);
		}

		public virtual void AcceptMileage(CallTaskWorker callTaskWorker)
		{
			if(Status != RouteListStatus.MileageCheck) {
				return;
			}

			RecalculateFuelOutlay();
			ConfirmAndClose(callTaskWorker);
		}

		public virtual void UpdateFuelOperation()
		{
			//Необходимо для того что бы случайно не пересчитать операцию расхода топлива. После массовой смены расхода.
			if(FuelOutlayedOperation != null && Date < new DateTime(2017, 6, 6)) {
				return;
			}

			if(ConfirmedDistance == 0) {
				if(FuelOutlayedOperation != null) {
					UoW.Delete(FuelOutlayedOperation);
					FuelOutlayedOperation = null;
				}
			} else {
				if(FuelOutlayedOperation == null) {
					FuelOutlayedOperation = new FuelOperation();
				}
				decimal litresOutlayed = (decimal)Car.FuelConsumption / 100 * ConfirmedDistance;

				FuelOutlayedOperation.Driver = Car.IsCompanyCar ? null : Driver;
				FuelOutlayedOperation.Car = Car.IsCompanyCar ? Car : null;
				FuelOutlayedOperation.Fuel = Car.FuelType;
				FuelOutlayedOperation.OperationTime = Date;
				FuelOutlayedOperation.LitersOutlayed = litresOutlayed;
			}
		}

		public virtual void RecalculateFuelOutlay()
		{
			if(this.ConfirmedDistance == 0)
				return;

			if(FuelOutlayedOperation == null) {
				FuelOutlayedOperation = new FuelOperation() {
					OperationTime = DateTime.Now,
					Driver = this.Driver,
					Car = this.Car,
					Fuel = this.Car.FuelType
				};
			}

			FuelOutlayedOperation.LitersOutlayed = GetLitersOutlayed();
		}

		public virtual decimal GetLitersOutlayed()
		{
			return (decimal)Car.FuelConsumption
				/ 100 * this.ConfirmedDistance;
		}

		public virtual decimal GetLitersOutlayed(decimal km)
		{
			return (decimal)Car.FuelConsumption
				/ 100 * km;
		}

		public virtual void UpdateDeliveryDocuments(IUnitOfWork uow)
		{
			var parametersProvider = new BaseParametersProvider();
			var controller = new RouteListClosingDocumentsController(parametersProvider, EmployeeSingletonRepository.GetInstance(), new RouteListRepository(), parametersProvider);
			controller.UpdateDocuments(this, uow);
		}

		#endregion

		public RouteList()
		{
			date = DateTime.Today;
		}

		public virtual ReportInfo OrderOfAddressesRep(int id)
		{
			var reportInfo = new ReportInfo {
				Title = String.Format("Отчёт по порядку адресов в МЛ №{0}", id),
				Identifier = "Logistic.OrderOfAddresses",
				Parameters = new Dictionary<string, object> {
						{ "RouteListId",  id }
				}
			};

			return reportInfo;
		}

		public virtual IEnumerable<string> UpdateCashOperations()
		{
			var messages = new List<string>();
			//Закрываем наличку.
			Income cashIncome = null;
			Expense cashExpense = null;

			var currentRouteListCash = CashRepository.CurrentRouteListCash(UoW, this.Id);
			var different = Total - currentRouteListCash;
			if(different == 0M) {
				return messages.ToArray();
			}

			if(Cashier?.Subdivision == null) {
				messages.Add("Создающий кассовые документы пользователь - не привязан к сотруднику!");
				return messages.ToArray();
			}

			if(different > 0) {
				cashIncome = new Income {
					IncomeCategory = CategoryRepository.RouteListClosingIncomeCategory(UoW),
					TypeOperation = IncomeType.DriverReport,
					Date = DateTime.Now,
					Casher = this.Cashier,
					Employee = Driver,
					Description = $"Закрытие МЛ №{Id} от {Date:d}",
					Money = Math.Round(different, 2, MidpointRounding.AwayFromZero),
					RouteListClosing = this,
					RelatedToSubdivision = Cashier.Subdivision
				};
				
				messages.Add($"Создан приходный ордер на сумму {cashIncome.Money}");
				routeListCashOrganisationDistributor.DistributeIncomeCash(UoW, this, cashIncome, cashIncome.Money);
			} else {
				cashExpense = new Expense {
					ExpenseCategory = CategoryRepository.RouteListClosingExpenseCategory(UoW),
					TypeOperation = ExpenseType.Expense,
					Date = DateTime.Now,
					Casher = this.Cashier,
					Employee = Driver,
					Description = $"Закрытие МЛ #{Id} от {Date:d}",
					Money = Math.Round(-different, 2, MidpointRounding.AwayFromZero),
					RouteListClosing = this,
					RelatedToSubdivision = Cashier.Subdivision
				};
				
				messages.Add($"Создан расходный ордер на сумму {cashExpense.Money}");
				routeListCashOrganisationDistributor.DistributeExpenseCash(UoW, this, cashExpense, cashExpense.Money);
			}

			// Если хотя бы один fuelDocument имеет PayedForFuel то добавить пустую строку разделитель и сообщения о расходных ордерах топлива
			bool wasEmptyLineAdded = false;
			foreach(var fuelDocument in fuelDocuments) {
				if (fuelDocument.PayedForFuel != null && fuelDocument.PayedForFuel != 0 && fuelDocument.FuelPaymentType == FuelPaymentType.Cash) {
					if(!wasEmptyLineAdded) {
						messages.Add("\n");
						wasEmptyLineAdded = true;
					}
					messages.Add($"Создан расходный ордер топлива на сумму {fuelDocument.PayedForFuel}");
				}
			}

			if (cashIncome != null) UoW.Save(cashIncome);
			if (cashExpense != null) UoW.Save(cashExpense);
			
			return messages;
		}

		public virtual IEnumerable<string> UpdateMovementOperations()
		{
			var result = UpdateCashOperations();
			UpdateOperations();
			return result;
		}

		public virtual void UpdateOperations()
		{
			this.UpdateFuelOperation();

			var counterpartyMovementOperations = this.UpdateCounterpartyMovementOperations();
			var moneyMovementOperations = this.UpdateMoneyMovementOperations();
			var depositsOperations = this.UpdateDepositOperations(UoW);

			counterpartyMovementOperations.ForEach(op => UoW.Save(op));
			UpdateBottlesMovementOperation(new BaseParametersProvider());
			depositsOperations.ForEach(op => UoW.Save(op));
			moneyMovementOperations.ForEach(op => UoW.Save(op));

			UpdateWageOperation();

			var premiumRaskatGAZelleWageModel = new PremiumRaskatGAZelleWageModel(EmployeeSingletonRepository.GetInstance(), new BaseParametersProvider(),
				new PremiumRaskatGAZelleParametersProvider(SingletonParametersProvider.Instance), this);
			premiumRaskatGAZelleWageModel.UpdatePremiumRaskatGAZelle(UoW);
		}

		#region Для логистических расчетов

		public virtual TimeSpan? FirstAddressTime {
			get {
				return Addresses.FirstOrDefault()?.Order.DeliverySchedule.From;
			}
		}

		public virtual void RecalculatePlanTime(RouteGeometryCalculator sputnikCache)
		{
			TimeSpan minTime = new TimeSpan();
			//Расчет минимального времени к которому нужно\можно подъехать.
			for(int ix = 0; ix < Addresses.Count; ix++) {

				if(ix == 0) {
					minTime = Addresses[ix].Order.DeliverySchedule.From;

					var timeFromBase = TimeSpan.FromSeconds(sputnikCache.TimeFromBase(GeographicGroups.FirstOrDefault(), Addresses[ix].Order.DeliveryPoint));
					var onBase = minTime - timeFromBase;
					if(Shift != null && onBase < Shift.StartTime)
						minTime = Shift.StartTime + timeFromBase;
				} else
					minTime += TimeSpan.FromSeconds(sputnikCache.TimeSec(Addresses[ix - 1].Order.DeliveryPoint, Addresses[ix].Order.DeliveryPoint));

				Addresses[ix].PlanTimeStart = minTime > Addresses[ix].Order.DeliverySchedule.From ? minTime : Addresses[ix].Order.DeliverySchedule.From;

				minTime += TimeSpan.FromSeconds(Addresses[ix].TimeOnPoint);
			}
			//Расчет максимального времени до которого нужно подъехать.
			TimeSpan maxTime = new TimeSpan();
			for(int ix = Addresses.Count - 1; ix >= 0; ix--) {

				if(ix == Addresses.Count - 1) {
					maxTime = Addresses[ix].Order.DeliverySchedule.To;
					var timeToBase = TimeSpan.FromSeconds(sputnikCache.TimeToBase(Addresses[ix].Order.DeliveryPoint, GeographicGroups.FirstOrDefault()));
					var onBase = maxTime + timeToBase;
					if(Shift != null && onBase > Shift.EndTime)
						maxTime = Shift.EndTime - timeToBase;
				} else
					maxTime -= TimeSpan.FromSeconds(sputnikCache.TimeSec(Addresses[ix].Order.DeliveryPoint, Addresses[ix + 1].Order.DeliveryPoint));

				if(maxTime > Addresses[ix].Order.DeliverySchedule.To)
					maxTime = Addresses[ix].Order.DeliverySchedule.To;

				maxTime -= TimeSpan.FromSeconds(Addresses[ix].TimeOnPoint);

				if(maxTime < Addresses[ix].PlanTimeStart) { //Расписание испорчено, успеть нельзя. Пытаемся его более менее адекватно отобразить.
					TimeSpan beforeMin = new TimeSpan(1, 0, 0, 0);
					if(ix > 0)
						beforeMin = Addresses[ix - 1].PlanTimeStart.Value
													 + TimeSpan.FromSeconds(sputnikCache.TimeSec(Addresses[ix - 1].Order.DeliveryPoint, Addresses[ix].Order.DeliveryPoint))
													 + TimeSpan.FromSeconds(Addresses[ix - 1].TimeOnPoint);
					if(beforeMin < Addresses[ix].Order.DeliverySchedule.From) {
						Addresses[ix].PlanTimeStart = beforeMin < maxTime ? maxTime : beforeMin;
					}
					maxTime = Addresses[ix].PlanTimeStart.Value;
				}
				Addresses[ix].PlanTimeEnd = maxTime;
			}
		}

		public virtual void RecalculatePlanedDistance(RouteGeometryCalculator distanceCalculator)
		{
			if(Addresses.Count == 0)
				PlanedDistance = 0;
			else
				PlanedDistance = distanceCalculator.GetRouteDistance(GenerateHashPointsOfRoute()) / 1000m;
		}

		public static void RecalculateOnLoadTime(IList<RouteList> routelists, RouteGeometryCalculator sputnikCache)
		{
			var sorted = routelists.Where(x => x.Addresses.Any() && !x.OnloadTimeFixed)
								   .Select(
										x => new Tuple<TimeSpan, RouteList>(
											x.FirstAddressTime.Value - TimeSpan.FromSeconds(sputnikCache.TimeFromBase(x.GeographicGroups.FirstOrDefault(), x.Addresses.First().Order.DeliveryPoint)),
											x
										)
									)
								   .OrderByDescending(x => x.Item1);
			var fixedTime = routelists.Where(x => x.Addresses.Any() && x.OnloadTimeFixed).ToList();
			var paralellLoading = 4;
			var loadingPlaces = Enumerable.Range(0, paralellLoading).Select(x => new TimeSpan(1, 0, 0, 0)).ToArray();
			foreach(var route in sorted) {
			repeat:
				int selectedPlace = Array.IndexOf(loadingPlaces, loadingPlaces.Max());
				var endLoading = loadingPlaces[selectedPlace] < route.Item1 ? loadingPlaces[selectedPlace] : route.Item1;
				var startLoading = endLoading - TimeSpan.FromMinutes(route.Item2.TimeOnLoadMinuts);
				//Проверяем, не перекрываем ли мы фиксированное время.
				var interfere = fixedTime.Where(x => x.OnLoadTimeEnd >= startLoading).ToList();
				var freeplaces = interfere.Count == 0 ? paralellLoading
										  : loadingPlaces.Count(x => x.TotalSeconds >= interfere.Min(y => y.OnLoadTimeEnd.Value.TotalSeconds));
				if(endLoading == loadingPlaces[selectedPlace])
					logger.Debug("Нехватило места на погрузке");

				if(freeplaces <= interfere.Count || endLoading <= interfere.Min(x => x.OnLoadTimeStart)) {
					var selectedTime = interfere.Max(x => x.OnLoadTimeEnd);
					var selectedFixed = interfere.First(x => x.OnLoadTimeEnd == selectedTime);
					if(loadingPlaces[selectedPlace] >= selectedFixed.OnLoadTimeEnd.Value) {
						loadingPlaces[selectedPlace] = selectedFixed.onLoadTimeStart.Value;
						selectedFixed.OnLoadGate = selectedPlace + 1;
					} else {
						logger.Warn("Маршрутный лист {0} с фиксированным временем погрузки {1:hh\\:mm}-{2:hh\\:mm} не влезает целиком в расписание прогрузки.",
									selectedFixed.Id, selectedFixed.onLoadTimeStart, selectedFixed.OnLoadTimeEnd
								   );
						selectedFixed.OnLoadGate = null;
						if(loadingPlaces[selectedPlace] < selectedFixed.onLoadTimeStart.Value)
							loadingPlaces[selectedPlace] = selectedFixed.onLoadTimeStart.Value;
					}
					fixedTime.Remove(selectedFixed);
					goto repeat;
				}

				route.Item2.OnLoadTimeEnd = endLoading;
				route.Item2.onLoadTimeStart = loadingPlaces[selectedPlace] = startLoading;
				route.Item2.onLoadGate = selectedPlace + 1;
			}
		}

		public virtual long TimeOnLoadMinuts {
			get {
				return Car.TypeOfUse == CarTypeOfUse.CompanyLargus ? 15 : 30;
			}
		}

		public virtual long[] GenerateHashPointsOfRoute()
		{
			var result = new List<long>();
			result.Add(CachedDistance.GetHash(GeographicGroups.FirstOrDefault()));
			result.AddRange(Addresses.Where(x => x.Order.DeliveryPoint.CoordinatesExist).Select(x => CachedDistance.GetHash(x.Order.DeliveryPoint)));
			result.Add(CachedDistance.GetHash(GeographicGroups.FirstOrDefault()));
			return result.ToArray();
		}

		#region Вес
		/// <summary>
		/// Полный вес товаров и оборудования в маршрутном листе
		/// </summary>
		/// <returns>Вес в килограммах</returns>
		public virtual double GetTotalWeight() => Addresses.Where(item => item.Status != RouteListItemStatus.Transfered)
														   .Sum(item => item.Order.FullWeight());
		/// <summary>
		/// Проверка на перегруз автомобиля
		/// </summary>
		/// <returns><c>true</c>, если автомобиль "Ларгус" или "раскат" и имеется его перегруз, <c>false</c> в остальных случаях.</returns>
		public virtual bool HasOverweight() => Car != null && (Car.IsRaskat || Car.TypeOfUse == CarTypeOfUse.CompanyLargus || Car.TypeOfUse == CarTypeOfUse.CompanyGAZelle) && Car.MaxWeight < GetTotalWeight();

		/// <summary>
		/// Перегруз в килограммах
		/// </summary>
		/// <returns>Возрат значения перегруза в килограммах.</returns>
		public virtual double Overweight() => HasOverweight() ? Math.Round(GetTotalWeight() - Car.MaxWeight, 2) : 0;
		#endregion Вес

		#region Объём
		/// <summary>
		/// Полный объём товаров и оборудования в маршрутном листе
		/// </summary>
		/// <returns>Объём в кубических метрах</returns>
		public virtual double GetTotalVolume() => Addresses.Where(item => item.Status != RouteListItemStatus.Transfered)
														   .Sum(item => item.Order.FullVolume());
		/// <summary>
		/// Проверка на превышение объёма груза автомобиля
		/// </summary>
		/// <returns><c>true</c>, если имеется превышение объёма, <c>false</c> в остальных случаях.</returns>
		public virtual bool HasVolumeExecess() => Car.MaxVolume < GetTotalVolume();

		/// <summary>
		/// Величина, на оторую превышен объём груза
		/// </summary>
		/// <returns>Возрат значения превышения объёма груза в метрах кубических.</returns>
		public virtual double VolumeExecess() => HasVolumeExecess() ? Math.Round(GetTotalVolume() - Car.MaxVolume, 3) : 0;
		#endregion Объём

		/// <summary>
		/// Нода с номенклатурами и различными количествами после погрузки МЛ на складе
		/// </summary>
		public virtual List<RouteListControlNotLoadedNode> NotLoadedNomenclatures(bool needTerminalAccounting, int? terminalId = null)
		{
			List<RouteListControlNotLoadedNode> notLoadedNomenclatures = new List<RouteListControlNotLoadedNode>();
			if(Id > 0) {
				var loadedNomenclatures = new RouteListRepository().AllGoodsLoaded(UoW, this);
				var nomenclaturesToLoad = new RouteListRepository().GetGoodsAndEquipsInRL(UoW, this);
				
				foreach(var n in nomenclaturesToLoad) {
					
					if(!needTerminalAccounting && n.NomenclatureId == terminalId)
						continue;
					
					var loaded = loadedNomenclatures.FirstOrDefault(x => x.NomenclatureId == n.NomenclatureId);
					decimal loadedAmount = 0;
					if(loaded != null)
						loadedAmount = loaded.Amount;
					if(loadedAmount < n.Amount) {
						notLoadedNomenclatures.Add(new RouteListControlNotLoadedNode {
							NomenclatureId = n.NomenclatureId,
							CountTotal = n.Amount,
							CountNotLoaded = (n.Amount - loadedAmount)
						});
					}
				}
				DomainHelper.FillPropertyByEntity<RouteListControlNotLoadedNode, Nomenclature>(
								UoW,
								notLoadedNomenclatures,
								x => x.NomenclatureId,
								(node, obj) => node.Nomenclature = obj
							);
			}
			return notLoadedNomenclatures;
		}

		public virtual void RecountMileage()
		{
			var pointsToRecalculate = new List<PointOnEarth>();
			var pointsToBase = new List<PointOnEarth>();
			var baseLat = (double)GeographicGroups.FirstOrDefault().BaseLatitude.Value;
			var baseLon = (double)GeographicGroups.FirstOrDefault().BaseLongitude.Value;

			decimal totalDistanceTrack = 0;

			IEnumerable<RouteListItem> completedAddresses = Addresses.Where(x => x.Status == RouteListItemStatus.Completed);

			if(!completedAddresses.Any())
			{
				ServicesConfig.InteractiveService.ShowMessage(ImportanceLevel.Warning, "Для МЛ нет завершенных адресов, невозможно расчитать трек", "");
				return;
			}

			if(completedAddresses.Count() > 1)
			{
				foreach(RouteListItem address in Addresses.OrderBy(x => x.StatusLastUpdate))
				{
					if(address.Status == RouteListItemStatus.Completed)
					{
						pointsToRecalculate.Add(new PointOnEarth((double)address.Order.DeliveryPoint.Latitude, (double)address.Order.DeliveryPoint.Longitude));
					}
				}

				var recalculatedTrackResponse = OsrmMain.GetRoute(pointsToRecalculate, false, GeometryOverview.Full);
				var recalculatedTrack = recalculatedTrackResponse.Routes.First();

				totalDistanceTrack = recalculatedTrack.TotalDistanceKm;
			}
			else
			{
				var point = Addresses.First(x => x.Status == RouteListItemStatus.Completed).Order.DeliveryPoint;
				pointsToRecalculate.Add(new PointOnEarth((double)point.Latitude, (double)point.Longitude));
			}

			pointsToBase.Add(pointsToRecalculate.Last());
			pointsToBase.Add(new PointOnEarth(baseLat, baseLon));
			pointsToBase.Add(pointsToRecalculate.First());

			var recalculatedToBaseResponse = OsrmMain.GetRoute(pointsToBase, false, GeometryOverview.Full);
			var recalculatedToBase = recalculatedToBaseResponse.Routes.First();

			RecalculatedDistance = decimal.Round(totalDistanceTrack + recalculatedToBase.TotalDistanceKm);
		}

		#endregion

		#region Зарплата

		private IRouteListWageCalculationService GetDriverWageCalculationService(WageParameterService wageParameterService)
		{
			if(wageParameterService == null) {
				throw new ArgumentNullException(nameof(wageParameterService));
			}

			return wageParameterService.ActualizeWageParameterAndGetCalculationService(UoW, Driver, DriverWageCalculationSrc);
		}

		private IRouteListWageCalculationService GetForwarderWageCalculationService(WageParameterService wageParameterService)
		{
			if(wageParameterService == null) {
				throw new ArgumentNullException(nameof(wageParameterService));
			}

			if(Forwarder == null) {
				return null;
			}
			return wageParameterService.ActualizeWageParameterAndGetCalculationService(UoW, Forwarder, ForwarderWageCalculationSrc);
		}


		/// <summary>
		/// Возвращает пересчитанную заново зарплату водителя (не записывает)
		/// </summary>
		public virtual decimal GetRecalculatedDriverWage(WageParameterService wageParameterService)
		{
			var routeListWageCalculationService = GetDriverWageCalculationService(wageParameterService);
			var wageResult = routeListWageCalculationService.CalculateWage();
			return wageResult.Wage;
		}

		/// <summary>
		/// Возвращает пересчитанную заного зарплату экспедитора (не записывает)
		/// </summary>
		public virtual decimal GetRecalculatedForwarderWage(WageParameterService wageParameterService)
		{
			if(wageParameterService == null) {
				throw new ArgumentNullException(nameof(wageParameterService));
			}

			if(Forwarder == null) {
				return 0;
			}

			var routeListWageCalculationService = GetForwarderWageCalculationService(wageParameterService);
			var wageResult = routeListWageCalculationService.CalculateWage();
			return wageResult.Wage;
		}

		/// <summary>
		/// Возвращает текущую зарплату водителя
		/// </summary>
		public virtual decimal GetDriversTotalWage()
		{
			if(FixedDriverWage > 0) {
				//Если все заказы не выполнены, то нет зарплаты
				return DriverWageCalculationSrc.HasAnyCompletedAddress ? FixedDriverWage : 0;
			}
			return Addresses.Sum(item => (item.DriverWage + item.DriverWageSurcharge));
		}

		/// <summary>
		/// Возвращает текущую зарплату экспедитора
		/// </summary>
		public virtual decimal GetForwardersTotalWage()
		{
			if(Forwarder == null)
				return 0;
			if(FixedForwarderWage > 0)
				//Если все заказы не выполнены, то нет зарплаты
				return ForwarderWageCalculationSrc.HasAnyCompletedAddress ? FixedForwarderWage : 0;
			return Addresses.Sum(item => item.ForwarderWage);
		}

		public virtual void RecalculateWagesForRouteListItem(RouteListItem address, WageParameterService wageParameterService)
		{
			if(!Addresses.Contains(address)) {
				throw new InvalidOperationException("Расчет зарплаты возможен только для адресов текущего маршрутного листа.");
			}

			var routeListDriverWageCalculationService = GetDriverWageCalculationService(wageParameterService);
			var drvWageResult = routeListDriverWageCalculationService.CalculateWageForRouteListItem(address.DriverWageCalculationSrc);
			address.DriverWage = drvWageResult.Wage;
			address.DriverWageCalcMethodicTemporaryStore = drvWageResult.WageDistrictLevelRate;
			if(Forwarder != null) {
				var routeListForwarderWageCalculationService = GetForwarderWageCalculationService(wageParameterService);
				var fwdWageResult = routeListForwarderWageCalculationService.CalculateWageForRouteListItem(address.ForwarderWageCalculationSrc);
				address.ForwarderWage = fwdWageResult.Wage;
				address.ForwarderWageCalcMethodicTemporaryStore = fwdWageResult.WageDistrictLevelRate;
			}
		}

		/// <summary>
		/// Расчитывает и записывает зарплату
		/// </summary>
		public virtual void CalculateWages(WageParameterService wageParameterService)
		{
			if(wageParameterService == null) {
				throw new ArgumentNullException(nameof(wageParameterService));
			}

			if (Status == RouteListStatus.New)
			{
				ClearWages();
				return;
			}

			var routeListDriverWageCalculationService = GetDriverWageCalculationService(wageParameterService);
			FixedDriverWage = routeListDriverWageCalculationService.CalculateWage().FixedWage;

			IRouteListWageCalculationService routeListForwarderWageCalculationService = null;
			if(Forwarder != null) {
				routeListForwarderWageCalculationService = GetForwarderWageCalculationService(wageParameterService);
				FixedForwarderWage = routeListForwarderWageCalculationService.CalculateWage().FixedWage;
			}

			foreach(var address in Addresses) {
				var drvWageResult = routeListDriverWageCalculationService.CalculateWageForRouteListItem(address.DriverWageCalculationSrc);
				address.DriverWage = drvWageResult.Wage;
				address.DriverWageCalcMethodicTemporaryStore = drvWageResult.WageDistrictLevelRate;
				if(Forwarder != null) {
					var fwdWageResult = routeListForwarderWageCalculationService.CalculateWageForRouteListItem(address.ForwarderWageCalculationSrc);
					address.ForwarderWage = fwdWageResult.Wage;
					address.ForwarderWageCalcMethodicTemporaryStore = fwdWageResult.WageDistrictLevelRate;
				}

				address.IsDriverForeignDistrict = address.DriverWageCalculationSrc.IsDriverForeignDistrict;
			}
		}

		/// <summary>
		/// Обнуляет зарплату в МЛ и его адресах
		/// </summary>
		public virtual void ClearWages()
		{
			FixedDriverWage = 0;
			FixedForwarderWage = 0;
			foreach(var address in Addresses)
			{
				address.DriverWage = 0;
				address.ForwarderWage = 0;
			}
		}

		public virtual void RecalculateAllWages(WageParameterService wageParameterService)
		{
			if(wageParameterService == null) {
				throw new ArgumentNullException(nameof(wageParameterService));
			}

			CalculateWages(wageParameterService);
		}

		public virtual void UpdateWageOperation()
		{
			decimal driverWage = GetDriversTotalWage();

			if(DriverWageOperation == null) {
				DriverWageOperation = new WagesMovementOperations {
					OperationTime = this.Date,
					Employee = Driver,
					Money = driverWage,
					OperationType = WagesType.AccrualWage
				};
			} else {
				DriverWageOperation.Employee = Driver;
				DriverWageOperation.Money = driverWage;
			}
			UoW.Save(DriverWageOperation);

			decimal forwarderWage = GetForwardersTotalWage();

			if(ForwarderWageOperation == null && forwarderWage > 0) {
				ForwarderWageOperation = new WagesMovementOperations {
					OperationTime = this.Date,
					Employee = Forwarder,
					Money = forwarderWage,
					OperationType = WagesType.AccrualWage
				};
			} else if(ForwarderWageOperation != null && forwarderWage > 0) {
				ForwarderWageOperation.Money = forwarderWage;
				ForwarderWageOperation.Employee = Forwarder;
			} else if(ForwarderWageOperation != null) {
				UoW.Delete(ForwarderWageOperation);
				ForwarderWageOperation = null;
			}

			if(ForwarderWageOperation != null)
				UoW.Save(ForwarderWageOperation);

			foreach(var address in Addresses) {
				address.SaveWageCalculationMethodics();
			}
		}

		IRouteListWageCalculationSource DriverWageCalculationSrc => new RouteListWageCalculationSource(this, EmployeeCategory.driver);

		IRouteListWageCalculationSource ForwarderWageCalculationSrc => new RouteListWageCalculationSource(this, EmployeeCategory.forwarder);

		private string CreateWageCalculationDetailsTextForAddress(RouteListItemWageCalculationDetails addressWageDetails, RouteListItem address,
			EmployeeCategory employeeCategory, string carOwner)
		{
			if(addressWageDetails == null)
			{
				return "";
			}

			string addressDetailsText =
				$"{ addressWageDetails.RouteListItemWageCalculationName } ({ carOwner }), адрес №{ address.Id }, заказ №{ address.Order.Id }" +
				$", категория \"{ employeeCategory.GetEnumTitle() }\":\n";

			var wageRateTypeTitles = Enum.GetValues(typeof(WageRateTypes)).OfType<WageRateTypes>().Select(w => w.GetEnumTitle());

			addressDetailsText += string.Join("\n",
				addressWageDetails.WageCalculationDetailsList
					.Where(d => d.Count > 0 || !wageRateTypeTitles.Contains(d.Name))
					.Select(d =>
					{
						var s = $"- {d.Name}";
						if(wageRateTypeTitles.Contains(d.Name))
						{
							if(d.Name == WageRateTypes.PackOfBottles600ml.GetEnumTitle())
							{
								s += $" = { decimal.Round(d.Price, 2) } руб. * {d.Count} шт. = { Math.Truncate(d.Price * d.Count) } руб.";
							}
							else
							{
								s += $" = { decimal.Round(d.Price, 2) } руб. * {d.Count} шт. = { decimal.Round(d.Price * d.Count, 2) } руб.";
							}
						}

						return s;
					})
				);

			var adsressSum = addressWageDetails.WageCalculationDetailsList.Sum(d =>
			{
				return d.Name == WageRateTypes.PackOfBottles600ml.GetEnumTitle() ? Math.Truncate(d.Price * d.Count) : decimal.Round(d.Price * d.Count, 2);
			});

			addressDetailsText += $"\nИтого за адрес: { Math.Round(adsressSum, 2) } руб.\n\n";

			return addressDetailsText;
		}

		public virtual string GetWageCalculationDetails(WageParameterService wageParameterService)
		{
			var routeListDriverWageCalculationService = GetDriverWageCalculationService(wageParameterService);
			var routeListForwarderWageCalculationService = GetForwarderWageCalculationService(wageParameterService);

			List<RouteListItemWageCalculationDetails> addressWageDetailsList = new List<RouteListItemWageCalculationDetails>();

			string resultText = "";

			string carOwner = DriverWageCalculationSrc.DriverOfOurCar ? "автомобиль компании" : "автомобиль водителя";

			if(routeListDriverWageCalculationService is RouteListWageCalculationService service
			   && service.GetWageCalculationService is RouteListFixedWageCalculationService)
			{
				resultText +=  $"Расчёт ЗП с фиксированной суммой за МЛ ({ carOwner }) = { routeListDriverWageCalculationService.CalculateWage().FixedWage } руб.";
				return resultText;
			}

			foreach(var address in addresses)
			{
				var driverAddressWageDetails = routeListDriverWageCalculationService?
					.GetWageCalculationDetailsForRouteListItem(address.DriverWageCalculationSrc);
				if(driverAddressWageDetails != null)
				{
					addressWageDetailsList.Add(driverAddressWageDetails);
				}

				var forwarderAddressWageDetails = routeListForwarderWageCalculationService?
					.GetWageCalculationDetailsForRouteListItem(address.ForwarderWageCalculationSrc);
				if(forwarderAddressWageDetails != null)
				{
					addressWageDetailsList.Add(forwarderAddressWageDetails);
				}

				resultText += CreateWageCalculationDetailsTextForAddress(driverAddressWageDetails, address, EmployeeCategory.driver, carOwner) +
							  CreateWageCalculationDetailsTextForAddress(forwarderAddressWageDetails, address, EmployeeCategory.forwarder, carOwner);
			}

			var routeListSum = addressWageDetailsList.Sum(a => a.WageCalculationDetailsList.Sum(d =>
			{
				return d.Name == WageRateTypes.PackOfBottles600ml.GetEnumTitle() ? Math.Truncate(d.Price * d.Count) : decimal.Round(d.Price * d.Count, 2);
			}));

			resultText += $"\nИтого по МЛ: { routeListSum } руб.";

			return resultText;
		}

		#endregion Зарплата
	}

	public enum RouteListStatus
	{
		[Display(Name = "Новый")]
		New,
		[Display(Name = "Подтвержден")]
		Confirmed,
		[Display(Name = "На погрузке")]
		InLoading,
		[Display(Name = "В пути")]
		EnRoute,
		[Display(Name = "Доставлен")]
		Delivered,
		[Display(Name = "Сдаётся")]
		OnClosing,
		[Display(Name = "Проверка километража")]
		MileageCheck,
		[Display(Name = "Закрыт")]
		Closed
	}

	public class RouteListStatusStringType : NHibernate.Type.EnumStringType
	{
		public RouteListStatusStringType() : base(typeof(RouteListStatus)) { }
	}

	public class RouteListControlNotLoadedNode
	{
		public int NomenclatureId { get; set; }
		public Nomenclature Nomenclature { get; set; }
		public decimal CountNotLoaded { get; set; }
		public decimal CountTotal { get; set; }
		public decimal CountLoaded => CountTotal - CountNotLoaded;
		public string CountLoadedString => string.Format("<span foreground=\"{0}\">{1}</span>", CountLoaded > 0 ? "Orange" : "Red", CountLoaded);
	}
}