﻿using System.ComponentModel.DataAnnotations;
using QS.DomainModel.Entity;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Operations;
using System;
using QS.HistoryLog;

namespace Vodovoz.Domain.Payments
{
	[Appellative(Gender = GrammaticalGender.Feminine,
		NominativePlural = "строки платежа(куда распределены)",
		Nominative = "строка платежа(куда распределен)",
		Prepositional = "строке платежа(куда распределен)",
		PrepositionalPlural = "строках платежа(куда распределены)")]
	[HistoryTrace]
	public class PaymentItem : PropertyChangedBase, IDomainObject
	{
		public virtual int Id { get; set; }

		Order order;
		[Display(Name = "Заказ")]
		public virtual Order Order {
			get => order;
			set => SetField(ref order, value);
		}

		Payment payment;
		[Display(Name = "Платеж")]
		public virtual Payment Payment {
			get => payment;
			set => SetField(ref payment, value);
		}

		CashlessMovementOperation cashlessMovementOperation;
		public virtual CashlessMovementOperation CashlessMovementOperation {
			get => cashlessMovementOperation;
			set => SetField(ref cashlessMovementOperation, value);
		}

		decimal sum;
		public virtual decimal Sum {
			get => sum;
			set => SetField(ref sum, value);
		}

		public PaymentItem()
		{
		}

		public virtual void CreateExpenseOperation()
		{
			if (CashlessMovementOperation == null)
			{
				CashlessMovementOperation = new CashlessMovementOperation {
					Expense = sum, 
					Counterparty = Payment.Counterparty,
					OperationTime = DateTime.Now
				};
			}
			else
			{
				UpdateExpenseOperation();
			}
		}

		public virtual void UpdateExpenseOperation()
		{
			if (CashlessMovementOperation.Expense != sum)
			{
				CashlessMovementOperation.Expense = sum;
				CashlessMovementOperation.Counterparty = Payment.Counterparty;
				CashlessMovementOperation.OperationTime = DateTime.Now;
			}
		}
		
		public virtual void UpdateSum(decimal newSum) {
			Sum = newSum;
			
			if (CashlessMovementOperation != null)
			{
				UpdateExpenseOperation();
			}
		}
	}
}
