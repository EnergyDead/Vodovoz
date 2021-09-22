using System;
using System.Collections.Generic;
using System.Linq;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Orders.OrdersWithoutShipment;
using Vodovoz.Domain.Organizations;
using Vodovoz.Services;

namespace Vodovoz.Models
{
	public class Stage2OrganizationProvider : IOrganizationProvider
	{
		private readonly IOrganizationParametersProvider _organizationParametersProvider;
		private readonly IOrderParametersProvider _orderParametersProvider;

		public Stage2OrganizationProvider(
			IOrganizationParametersProvider organizationParametersProvider,
			IOrderParametersProvider orderParametersProvider)
		{
			_organizationParametersProvider =
				organizationParametersProvider ?? throw new ArgumentNullException(nameof(organizationParametersProvider));
			_orderParametersProvider = orderParametersProvider ?? throw new ArgumentNullException(nameof(orderParametersProvider));
		}

		public Organization GetOrganization(IUnitOfWork uow, Order order)
		{
			if(order == null)
			{
				throw new ArgumentNullException(nameof(order));
			}

			var isSelfDelivery = order.SelfDelivery || order.DeliveryPoint == null;
			return GetOrganization(uow, order.PaymentType, isSelfDelivery, order.OrderItems, order.PaymentByCardFrom);
		}

		public Organization GetOrganization(IUnitOfWork uow, PaymentType paymentType, bool isSelfDelivery,
			IEnumerable<OrderItem> orderItems = null, PaymentFrom paymentFrom = null)
		{
			if(uow == null)
			{
				throw new ArgumentNullException(nameof(uow));
			}

			if(HasAnyOnlineStoreNomenclature(orderItems))
			{
				return GetOrganizationForOnlineStore(uow);
			}

			return isSelfDelivery
				? GetOrganizationForSelfDelivery(uow, paymentType, paymentFrom)
				: GetOrganizationForOtherOptions(uow, paymentType, paymentFrom);
		}

		private Organization GetOrganizationForSelfDelivery(IUnitOfWork uow, PaymentType paymentType, PaymentFrom paymentFrom = null)
		{
			int organizationId;
			switch(paymentType)
			{
				case PaymentType.barter:
				case PaymentType.cashless:
				case PaymentType.ContractDoc:
					organizationId = _organizationParametersProvider.VodovozOrganizationId;
					break;
				case PaymentType.cash:
					organizationId = _organizationParametersProvider.VodovozNorthOrganizationId;
					break;
				case PaymentType.Terminal:
				case PaymentType.ByCard:
					organizationId =
						paymentFrom != null
						&& _orderParametersProvider.PaymentsByCardFromForNorthOrganization.Contains(paymentFrom.Id)
							? _organizationParametersProvider.VodovozNorthOrganizationId
							: _organizationParametersProvider.VodovozSouthOrganizationId;
					break;
				case PaymentType.BeveragesWorld:
					organizationId = _organizationParametersProvider.BeveragesWorldOrganizationId;
					break;
				default:
					throw new NotSupportedException(
						$"Невозможно подобрать организацию, так как тип оплаты {paymentType} не поддерживается.");
			}

			return uow.GetById<Organization>(organizationId);
		}

		private bool HasAnyOnlineStoreNomenclature(IEnumerable<OrderItem> orderItems)
		{
			return orderItems != null
				&& orderItems.Any(x =>
					x.Nomenclature.OnlineStore != null &&
					x.Nomenclature.OnlineStore.Id != _orderParametersProvider.OldInternalOnlineStoreId);
		}

		private Organization GetOrganizationForOnlineStore(IUnitOfWork uow)
		{
			return uow.GetById<Organization>(_organizationParametersProvider.VodovozSouthOrganizationId);
		}

		private Organization GetOrganizationForOtherOptions(IUnitOfWork uow, PaymentType paymentType, PaymentFrom paymentFrom = null)
		{
			int organizationId;
			switch(paymentType)
			{
				case PaymentType.barter:
				case PaymentType.cashless:
				case PaymentType.ContractDoc:
					organizationId = _organizationParametersProvider.VodovozOrganizationId;
					break;
				case PaymentType.cash:
					organizationId = _organizationParametersProvider.VodovozNorthOrganizationId;
					break;
				case PaymentType.Terminal:
				case PaymentType.ByCard:
					organizationId =
						paymentFrom != null
						&& _orderParametersProvider.PaymentsByCardFromForNorthOrganization.Contains(paymentFrom.Id)
							? _organizationParametersProvider.VodovozNorthOrganizationId
							: _organizationParametersProvider.VodovozSouthOrganizationId;
					break;
				case PaymentType.BeveragesWorld:
					organizationId = _organizationParametersProvider.BeveragesWorldOrganizationId;
					break;
				default:
					throw new NotSupportedException($"Тип оплаты {paymentType} не поддерживается, невозможно подобрать организацию.");
			}

			return uow.GetById<Organization>(organizationId);
		}

		public Organization GetOrganizationForOrderWithoutShipment(IUnitOfWork uow, OrderWithoutShipmentForAdvancePayment order)
		{
			if(uow == null)
			{
				throw new ArgumentNullException(nameof(uow));
			}
			if(order == null)
			{
				throw new ArgumentNullException(nameof(order));
			}

			var organizationId = IsOnlineStoreOrderWithoutShipment(order)
				? _organizationParametersProvider.VodovozSouthOrganizationId
				: _organizationParametersProvider.VodovozOrganizationId;

			return uow.GetById<Organization>(organizationId);
		}

		private bool IsOnlineStoreOrderWithoutShipment(OrderWithoutShipmentForAdvancePayment order)
		{
			return order.OrderWithoutDeliveryForAdvancePaymentItems.Any(x =>
				x.Nomenclature.OnlineStore != null && x.Nomenclature.OnlineStore.Id != _orderParametersProvider.OldInternalOnlineStoreId);
		}
	}
}
