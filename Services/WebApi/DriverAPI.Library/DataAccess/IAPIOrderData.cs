﻿using DriverAPI.Library.Models;
using System;
using System.Collections.Generic;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Orders;

namespace DriverAPI.Library.DataAccess
{
	public interface IAPIOrderData
	{
		APIOrder Get(int orderId);
		IEnumerable<APIOrder> Get(int[] orderIds);
		APIOrderAdditionalInfo GetAdditionalInfo(int orderId);
		void ChangeOrderPaymentType(int orderId, PaymentType paymentType);
		IEnumerable<PaymentDtoType> GetAvailableToChangePaymentTypes(Order order);
		IEnumerable<PaymentDtoType> GetAvailableToChangePaymentTypes(int orderId);
		void CompleteOrderDelivery(Employee driver, int orderId, int bottlesReturnCount, int rating, int driverComplaintReasonId, string otherDriverComplaintReasonComment, DateTime actionTime);
	}
}