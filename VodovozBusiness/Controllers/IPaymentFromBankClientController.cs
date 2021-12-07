﻿using QS.DomainModel.UoW;
using Vodovoz.Domain.Orders;

namespace Vodovoz.Controllers
{
	public interface IPaymentFromBankClientController
	{
		void UpdateAllocatedSum(IUnitOfWork uow, Order order);
		void ReturnAllocatedSumToClientBalance(IUnitOfWork uow, int orderId);
	}
}
