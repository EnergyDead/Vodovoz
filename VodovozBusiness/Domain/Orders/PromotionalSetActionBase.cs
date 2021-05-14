﻿using System.ComponentModel.DataAnnotations;
using QS.DomainModel.Entity;
using QS.DomainModel.UoW;

namespace Vodovoz.Domain.Orders
{
	public abstract class PromotionalSetActionBase : PropertyChangedBase, IDomainObject
	{
		public virtual int Id { get; set; }

		PromotionalSet promotionalSet;
		[Display(Name = "Промо-набор")]
		public virtual PromotionalSet PromotionalSet {
			get { return promotionalSet; }
			set { SetField(ref promotionalSet, value, () => PromotionalSet); }
		}

		public abstract void Activate(Order order);
		public abstract void Deactivate(Order order);
		public abstract bool IsValidForOrder(Order order);
		public abstract bool IsValidForOrder(OrderBase order, IUnitOfWork uow);
		public abstract string Title { get; }
	}
}
