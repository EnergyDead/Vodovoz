﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Gamma.Utilities;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Payments;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.EntityRepositories.Payments;

namespace Vodovoz.Controllers
{
	public class PaymentFromBankClientController : IPaymentFromBankClientController
	{
		private readonly IPaymentItemsRepository _paymentItemsRepository;
		private readonly IOrderRepository _orderRepository;
		private readonly IPaymentsRepository _paymentsRepository;

		public PaymentFromBankClientController(
			IPaymentItemsRepository paymentItemsRepository,
			IOrderRepository orderRepository,
			IPaymentsRepository paymentsRepository)
		{
			_paymentItemsRepository = paymentItemsRepository ?? throw new ArgumentNullException(nameof(paymentItemsRepository));
			_orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
			_paymentsRepository = paymentsRepository ?? throw new ArgumentNullException(nameof(paymentsRepository));
		}
		
		/// <summary>
		/// Обновление распределенной суммы на заказ
		/// Выполнение происходит только если заказ находится в неотмененном статусе и с типом оплаты Безнал,
		/// а также имеет распределенную на себя сумму.
		/// Если сумма заказа увеличилась, т.е. больше распределенной суммы - ставим статус Частично оплачен
		/// Иначе, если сумма заказа уменьшилась - корректируем распределенную сумму в соответствии с заказом и ставим в Оплачен
		/// Иначе просто ставим в оплачен, т.е. сумма заказа и распределенная сумма совпадают
		/// </summary>
		/// <param name="uow">Unit of work</param>
		/// <param name="order">Заказ</param>
		public void UpdateAllocatedSum(IUnitOfWork uow, Order order)
		{
			if(HasOrderUndeliveredStatus(order.OrderStatus) || order.PaymentType != PaymentType.cashless)
			{
				return;
			}
			if(!HasAllocatedSum(uow, order.Id, out var paymentItems, out var allocatedSum))
			{
				return;
			}
			
			if(order.OrderSum > allocatedSum)
			{
				order.OrderPaymentStatus = OrderPaymentStatus.PartiallyPaid;
			}
			else if(order.OrderSum < allocatedSum)
			{
				var diff = allocatedSum - order.OrderSum;
				
				foreach(var paymentItem in paymentItems)
				{
					if(paymentItem.Sum > diff)
					{
						paymentItem.UpdateSum(paymentItem.Sum - diff);
						uow.Save(paymentItem);
						break;
					}
					if(paymentItem.Sum <= diff)
					{
						paymentItem.Payment.RemovePaymentItem(paymentItem.Id);
						uow.Save(paymentItem.Payment);
						diff -= paymentItem.Sum;
					}
					if(diff == 0)
					{
						break;
					}
				}
				order.OrderPaymentStatus = OrderPaymentStatus.Paid;
			}
			else
			{
				order.OrderPaymentStatus = OrderPaymentStatus.Paid;
			}
		}

		/// <summary>
		/// Возвращаем распределенную сумму на заказ, если менялся тип оплаты с безнала на любой другой
		/// </summary>
		/// <param name="uow">Unit of work</param>
		/// <param name="order">Заказ</param>
		public void ReturnAllocatedSumToClientBalanceIfChangedPaymentTypeFromCashless(IUnitOfWork uow, Order order)
		{
			if(_orderRepository.GetCurrentOrderPaymentTypeInDB(uow, order.Id) == PaymentType.cashless
				&& order.PaymentType != PaymentType.cashless)
			{
				ReturnAllocatedSumToClientBalance(uow, order, RefundPaymentReason.ChangeOrderPaymentType);
			}
		}
		
		/// <summary>
		/// Возврат распределенной суммы на баланс клиента
		/// Если есть распределение на этот заказ, то создаем новый платеж с распределенной суммой
		/// для ее возврата на баланс клиента и последующего перераспределения
		/// </summary>
		/// <param name="uow">Unit of work</param>
		/// <param name="order">Заказ</param>
		/// <param name="refundPaymentReason">Причина возврата суммы на баланс</param>
		public void ReturnAllocatedSumToClientBalance(
			IUnitOfWork uow, Order order, RefundPaymentReason refundPaymentReason = RefundPaymentReason.OrderCancellation)
		{
			if(!HasAllocatedSum(uow, order.Id, out var paymentItems, out var allocatedSum))
			{
				return;
			}
			
			CreateNewPaymentForReturnAllocatedSumToClientBalance(uow, order, allocatedSum, paymentItems, refundPaymentReason);
		}

		/// <summary>
		/// Отмена возврата суммы на баланс клиента со всеми распределениями, если они есть,
		/// при возвращении заказа по безналу в работу
		/// </summary>
		/// <param name="uow">Unit of work</param>
		/// <param name="order">Заказ</param>
		/// <param name="previousOrderStatus">Предыдущий статус заказа</param>
		public void CancelRefundedPaymentIfOrderRevertFromUndelivery(IUnitOfWork uow, Order order, OrderStatus previousOrderStatus)
		{
			if(HasOrderUndeliveredStatus(previousOrderStatus)
				&& order.PaymentType == PaymentType.cashless
				&& HasNotCancelledRefundedPayment(uow, order.Id, out var refundedPayment))
			{
				refundedPayment.CancelAllocation(
					$"Причина отмены: заказ №{order.Id} вернули в статус" +
					$" {order.OrderStatus.GetEnumTitle()} из {previousOrderStatus.GetEnumTitle()}",
					true);
				uow.Save(refundedPayment);

				var cancelledPaymentItems =
					_paymentItemsRepository.GetCancelledPaymentItemsForOrderFromNotCancelledPayments(uow, order.Id);

				foreach(var paymentItem in cancelledPaymentItems)
				{
					paymentItem.ReturnFromCancelled();
					uow.Save(paymentItem);
				}

				var allocatedSum = cancelledPaymentItems.Sum(pi => pi.Sum);
				order.OrderPaymentStatus = allocatedSum >= order.OrderSum ? OrderPaymentStatus.Paid : OrderPaymentStatus.PartiallyPaid;
			}
		}

		private bool HasOrderUndeliveredStatus(OrderStatus orderStatus)
		{
			return _orderRepository.GetUndeliveryStatuses().Contains(orderStatus);
		}
		
		private bool HasAllocatedSum(IUnitOfWork uow, int orderId, out IList<PaymentItem> paymentItems, out decimal allocatedSum)
		{
			paymentItems = _paymentItemsRepository.GetAllocatedPaymentItemsForOrder(uow, orderId);
			allocatedSum = paymentItems.Select(pi => pi.CashlessMovementOperation).Sum(cmo => cmo.Expense);

			return paymentItems.Any();
		}
		
		private bool HasNotCancelledRefundedPayment(IUnitOfWork uow, int orderId, out Payment refundedPayment)
		{
			refundedPayment = _paymentsRepository.GetNotCancelledRefundedPayment(uow, orderId);
			
			return refundedPayment != null;
		}

		private void CreateNewPaymentForReturnAllocatedSumToClientBalance(
			IUnitOfWork uow, Order order, decimal allocatedSum, IList<PaymentItem> paymentItems, RefundPaymentReason refundPaymentReason)
		{
			foreach(var paymentItem in paymentItems)
			{
				paymentItem.CancelAllocation();
				uow.Save(paymentItem);
			}

			var payment = paymentItems.Select(x => x.Payment).First();
			
			var newPayment =
				payment.CreatePaymentForReturnAllocatedSumToClientBalance(
					allocatedSum <= order.OrderSum
						? allocatedSum
						: order.OrderSum,
					order.Id,
					refundPaymentReason);

			if(order.OrderPaymentStatus != OrderPaymentStatus.UnPaid)
			{
				order.OrderPaymentStatus =
					order.PaymentType == PaymentType.cashless
						? OrderPaymentStatus.UnPaid
						: OrderPaymentStatus.None;
			}
			
			uow.Save(newPayment);
		}
	}

	public enum RefundPaymentReason
	{
		[Display(Name = "Отмена доставки/заказа")]
		OrderCancellation,
		[Display(Name = "Смена типа оплаты заказа")]
		ChangeOrderPaymentType
	}
}
