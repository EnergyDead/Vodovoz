﻿using System;
using System.Collections.Generic;

namespace DriverAPI.Library.DTOs
{
	public class OrderDto
	{
		public int OrderId { get; set; }
		public SmsPaymentDtoStatus? SmsPaymentStatus { get; set; }
		public string DeliveryTime { get; set; }
		public int FullBottleCount { get; set; }
		public int EmptyBottlesToReturn { get; set; }
		public string Counterparty { get; set; }
		public IEnumerable<string> PhoneNumbers { get; set; }
		public PaymentDtoType PaymentType { get; set; }
		public AddressDto Address { get; set; }
		public string OrderComment { get; set; }
		public decimal OrderSum { get; set; }
		public bool IsFastDelivery { get; set; }
		public string AddedToRouteListTime { get; set; }
		public IEnumerable<OrderSaleItemDto> OrderSaleItems { get; set; }
		public IEnumerable<OrderDeliveryItemDto> OrderDeliveryItems { get; set; }
		public IEnumerable<OrderReceptionItemDto> OrderReceptionItems { get; set; }
		public OrderAdditionalInfoDto OrderAdditionalInfo { get; set; }
	}
}
