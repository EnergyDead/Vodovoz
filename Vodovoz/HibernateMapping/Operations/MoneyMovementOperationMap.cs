﻿using FluentNHibernate.Mapping;
using Vodovoz.Domain.Operations;
using Vodovoz.Domain;

namespace Vodovoz.HMap
{
	public class MoneyMovementOperationMap : ClassMap<MoneyMovementOperation>
	{
		public MoneyMovementOperationMap ()
		{
			Table ("money_movement_operations");
			Not.LazyLoad ();

			Id (x => x.Id).Column ("id").GeneratedBy.Native ();
			Map (x => x.OperationTime).Column ("operation_time");
			Map (x => x.Debt).Column ("debt");
			Map (x => x.Money).Column ("money");
			Map (x => x.Deposit).Column ("deposit");
			Map (x => x.PaymentType).Column ("payment_type").CustomType<PaymentTypeStringType> ();
			Map (x => x.DepositType).Column ("deposit_type").CustomType<DepositTypeStringType> ();
			References (x => x.Order).Column ("order_id");
			References (x => x.Counterparty).Column ("counterparty_id");
			References (x => x.DeliveryPoint).Column ("delivery_point_id");
			References (x => x.OrderItem).Column ("order_item_id");
		}
	}
}

