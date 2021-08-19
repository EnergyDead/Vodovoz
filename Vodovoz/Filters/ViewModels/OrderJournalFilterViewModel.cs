﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QS.Project.Filter;
using QS.Project.Services;
using QS.RepresentationModel.GtkUI;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Organizations;
using Vodovoz.ViewModel;

namespace Vodovoz.Filters.ViewModels
{
	public class OrderJournalFilterViewModel : FilterViewModelBase<OrderJournalFilterViewModel>
	{
		public OrderJournalFilterViewModel()
		{
			DaysToBack = -CurrentUserSettings.Settings.JournalDaysToAft;
			DaysToForward = CurrentUserSettings.Settings.JournalDaysToFwd;
			Organisations = UoW.GetAll<Organization>();
			PaymentsFrom = UoW.GetAll<PaymentFrom>();
		}

		public int DaysToBack { get; }
		public int DaysToForward { get; }
		public int[] IncludeDistrictsIds { get; set; }
		public int[] ExceptIds { get; set; }

		public IEnumerable<Organization> Organisations { get; }
		public IEnumerable<PaymentFrom> PaymentsFrom { get; }

		IRepresentationModel counterpartyRepresentationModel;
		public IRepresentationModel CounterpartyRepresentationModel {
			get {
				if(counterpartyRepresentationModel == null) {
					var filter = new CounterpartyFilter(UoW);
					counterpartyRepresentationModel = new CounterpartyVM(filter);
				}
				return counterpartyRepresentationModel;
			}
		}

		private IRepresentationModel deliveryPointRepresentationModel;
		public virtual IRepresentationModel DeliveryPointRepresentationModel {
			get => deliveryPointRepresentationModel;
			private set => SetField(ref deliveryPointRepresentationModel, value, () => DeliveryPointRepresentationModel);
		}
		
		private Organization organisation;
		public virtual Organization Organisation {
			get => organisation;
			set {
				if(SetField(ref organisation, value)) {
					Update();
					CanChangeOrganisation = false;
				}
			}
		}
		public bool CanChangeOrganisation { get; private set; } = true;
		
		private PaymentFrom paymentByCardFrom;
		public virtual PaymentFrom PaymentByCardFrom {
			get => paymentByCardFrom;
			set {
				if(SetField(ref paymentByCardFrom, value)) {
					Update();
					CanChangePaymentFrom = false;
				}
			}
		}
		public bool CanChangePaymentFrom { get; private set; } = true;

		private bool paymentsFromVisibility;
		public bool PaymentsFromVisibility
		{
			get => paymentsFromVisibility;
			set => SetField(ref paymentsFromVisibility, value);
		}
		
		private OrderStatus? restrictStatus;
		public virtual OrderStatus? RestrictStatus {
			get => restrictStatus;
			set {
				if(SetField(ref restrictStatus, value, () => RestrictStatus)) {
					Update();
					CanChangeStatus = false;
				}
			}
		}
		public bool CanChangeStatus { get; private set; } = true;

		private object[] hideStatuses;
		public virtual object[] HideStatuses {
			get => hideStatuses;
			set {
				if(SetField(ref hideStatuses, value, () => HideStatuses)) {
					Update();
				}
			}
		}

		private OrderStatus[] allowStatuses;
		public virtual OrderStatus[] AllowStatuses {
			get => allowStatuses;
			set {
				if(SetField(ref allowStatuses, value, () => AllowStatuses)) {
					Update();
				}
			}
		}

		private PaymentType? restrictPaymentType;
		public virtual PaymentType? RestrictPaymentType {
			get => restrictPaymentType;
			set {
				if(SetField(ref restrictPaymentType, value, () => RestrictPaymentType)) {
					if (restrictPaymentType != PaymentType.ByCard && PaymentByCardFrom != null) {
						PaymentByCardFrom = null;
					}
					
					Update();
					CanChangePaymentType = false;
					PaymentsFromVisibility = restrictPaymentType == PaymentType.ByCard;
				}
			}
		}
		public bool CanChangePaymentType { get; private set; } = true;

		private PaymentType[] allowPaymentTypes;
		public virtual PaymentType[] AllowPaymentTypes {
			get => allowPaymentTypes;
			set {
				if(SetField(ref allowPaymentTypes, value, () => AllowPaymentTypes)) {
					Update();
				}
			}
		}

		private Counterparty restrictCounterparty;
		public virtual Counterparty RestrictCounterparty {
			get => restrictCounterparty;
			set {
				if(SetField(ref restrictCounterparty, value, () => RestrictCounterparty))
				{
					SortDeliveryDateVisibility = true;
					UpdateDeliveryPointRepresentationModel();
					Update();
					CanChangeCounterparty = false;
				}
			}
		}
		public bool CanChangeCounterparty { get; private set; } = true;

		private DeliveryPoint restrictDeliveryPoint;
		public virtual DeliveryPoint RestrictDeliveryPoint {
			get => restrictDeliveryPoint;
			set {
				if(SetField(ref restrictDeliveryPoint, value, () => RestrictDeliveryPoint)) {
					Update();
					CanChangeDeliveryPoint = false;
				}
			}
		}
		public bool CanChangeDeliveryPoint { get; private set; } = true;

		private DateTime? restrictStartDate;
		public virtual DateTime? RestrictStartDate {
			get => restrictStartDate;
			set {
				if(SetField(ref restrictStartDate, value, () => RestrictStartDate)) {
					Update();
					CanChangeStartDate = false;
				}
			}
		}
		public bool CanChangeStartDate { get; private set; } = true;

		private DateTime? restrictEndDate;
		public virtual DateTime? RestrictEndDate {
			get => restrictEndDate;
			set {
				if(SetField(ref restrictEndDate, value, () => RestrictEndDate)) {
					Update();
					CanChangeEndDate = false;
				}
			}
		}
		public bool CanChangeEndDate { get; private set; } = true;

		private bool? restrictLessThreeHours;
		public virtual bool? RestrictLessThreeHours {
			get => restrictLessThreeHours;
			set {
				if(SetField(ref restrictLessThreeHours, value, () => RestrictLessThreeHours)) {
					Update();
					CanChangeLessThreeHours = false;
				}
			}
		}
		public bool CanChangeLessThreeHours { get; private set; } = true;

		private ViewTypes viewTypes;
		public virtual ViewTypes ViewTypes {
			get => viewTypes;
			set {
				if(SetField(ref viewTypes, value)) {
					Update();
				}
			}
		}

		private OrderPaymentStatus? orderPaymentStatus;
		public OrderPaymentStatus? OrderPaymentStatus {
			get => orderPaymentStatus;
			set {
				SetField(ref orderPaymentStatus, value);
				Update();
			}
		}

		private bool? isForRetail;
		public bool? IsForRetail
		{
			get => isForRetail;
			set => SetField(ref isForRetail, value);
		}

		#region Selfdelivery

		private bool? restrictOnlySelfDelivery;
		public virtual bool? RestrictOnlySelfDelivery {
			get => restrictOnlySelfDelivery;
			set {
				if(SetField(ref restrictOnlySelfDelivery, value, () => RestrictOnlySelfDelivery)) {
					if(restrictOnlySelfDelivery.HasValue && restrictOnlySelfDelivery.Value && RestrictWithoutSelfDelivery.HasValue) {
						RestrictWithoutSelfDelivery = false;
					}
					Update();
					CanChangeOnlySelfDelivery = false;
				}
			}
		}
		public bool CanChangeOnlySelfDelivery { get; private set; } = true;

		private bool? restrictWithoutSelfDelivery;
		public virtual bool? RestrictWithoutSelfDelivery {
			get => restrictWithoutSelfDelivery;
			set {
				if(SetField(ref restrictWithoutSelfDelivery, value, () => RestrictWithoutSelfDelivery)) {
					if(restrictWithoutSelfDelivery.HasValue && restrictWithoutSelfDelivery.Value && RestrictOnlySelfDelivery.HasValue) {
						RestrictOnlySelfDelivery = false;
					}
					Update();
					CanChangeWithoutSelfDelivery = false;
				}
			}
		}
		public bool CanChangeWithoutSelfDelivery { get; private set; } = true;


		private PaymentOrder? paymentOrder;
		public PaymentOrder? PaymentOrder{
			get => paymentOrder;
			set { 
				SetField(ref paymentOrder, value, () => PaymentOrder); 
				Update(); 
			}
		}


		#endregion

		#region Services

		private bool? restrictHideService;
		public virtual bool? RestrictHideService {
			get => restrictHideService;
			set {
				if(SetField(ref restrictHideService, value, () => RestrictHideService)) {
					if(restrictHideService.HasValue && restrictHideService.Value && RestrictOnlyService.HasValue) {
						RestrictOnlyService = false;
					}
					Update();
				}
			}
		}
		public bool CanChangeHideService { get; private set; } = true;

		private bool? restrictOnlyService;
		public virtual bool? RestrictOnlyService {
			get => restrictOnlyService;
			set {
				if(SetField(ref restrictOnlyService, value, () => RestrictOnlyService)) {
					if(restrictOnlyService.HasValue && restrictOnlyService.Value && RestrictHideService.HasValue) {
						RestrictHideService = false;
					}
					Update();
					CanChangeOnlyService = false;
				}
			}
		}
		public bool CanChangeOnlyService { get; private set; } = true;

		#endregion

		#region Sorting

		private bool? _sortOnlyDeliveryDate;
		public virtual bool? SortOnlyDeliveryDate {
			get => _sortOnlyDeliveryDate;
			set {
				if(SetField(ref _sortOnlyDeliveryDate, value)) 
				{
					Update();
					CanChangeOnlyDeliveryDate = false;
				}
			}
		}
		public bool CanChangeOnlyDeliveryDate { get; private set; } = true;
		
		private bool _sortDeliveryDateVisibility;
		public bool SortDeliveryDateVisibility
		{
			get => _sortDeliveryDateVisibility;
			set => SetField(ref _sortDeliveryDateVisibility, value);
		}

		#endregion

		private void SetDefaultValues()
		{
			RestrictHideService = true;
		}


		private void UpdateDeliveryPointRepresentationModel()
		{
			if(RestrictCounterparty == null) {
				DeliveryPointRepresentationModel = null;
				return;
			}
			DeliveryPointRepresentationModel = new ClientDeliveryPointsVM(UoW, RestrictCounterparty);
		}
	}

	public enum PaymentOrder
	{
		[Display(Name = "Оплата после отгрузки")]
		AfterShipment,
		[Display(Name = "Оплата до отгрузки")]
		BeforeShipment
	}

	public enum ViewTypes
	{
		[Display(Name = "Все")]
		All,
		[Display(Name = "Заказы")]
		Order,
		[Display(Name = "Счета без отгрузки на долг")]
		OrderWSFD,
		[Display(Name = "Счета без отгрузки на предоплату")]
		OrderWSFAP,
		[Display(Name = "Счета без отгрузки на постоплату")]
		OrderWSFP
	}
}
