﻿using DriverAPI.Library.Converters;
using DriverAPI.Library.DataAccess;
using DriverAPI.Library.Helpers;
using DriverAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace DriverAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class SmsPaymentsController : ControllerBase
	{
		private readonly ILogger<SmsPaymentsController> logger;
		private readonly ISmsPaymentModel aPISmsPaymentData;
		private readonly SmsPaymentStatusConverter smsPaymentConverter;
		private readonly ISmsPaymentServiceAPIHelper smsPaymentServiceAPIHelper;
		private readonly IOrderModel aPIOrderData;

		public SmsPaymentsController(ILogger<SmsPaymentsController> logger,
			ISmsPaymentModel aPISmsPaymentData,
			SmsPaymentStatusConverter smsPaymentConverter,
			ISmsPaymentServiceAPIHelper smsPaymentServiceAPIHelper,
			IOrderModel aPIOrderData)
		{
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
			this.aPISmsPaymentData = aPISmsPaymentData ?? throw new ArgumentNullException(nameof(aPISmsPaymentData));
			this.smsPaymentConverter = smsPaymentConverter ?? throw new ArgumentNullException(nameof(smsPaymentConverter));
			this.smsPaymentServiceAPIHelper = smsPaymentServiceAPIHelper ?? throw new ArgumentNullException(nameof(smsPaymentServiceAPIHelper));
			this.aPIOrderData = aPIOrderData ?? throw new ArgumentNullException(nameof(aPIOrderData));
		}

		/// <summary>
		/// Эндпоинт получения статуса оплаты через СМС
		/// </summary>
		/// <param name="orderId">Идентификатор заказа</param>
		/// <returns>OrderPaymentStatusResponseModel или null</returns>
		[HttpGet]
		[Route("/api/GetOrderSmsPaymentStatus")]
		public OrderPaymentStatusResponseDto GetOrderSmsPaymentStatus(int orderId)
		{
			var additionalInfo = aPIOrderData.GetAdditionalInfo(orderId)
				?? throw new Exception($"Не удалось получить информацию о заказе {orderId}");

			var response = new OrderPaymentStatusResponseDto()
			{
				AvailablePaymentTypes = additionalInfo.AvailablePaymentTypes,
				CanSendSms = additionalInfo.CanSendSms,
				SmsPaymentStatus = smsPaymentConverter.convertToAPIPaymentStatus(
					aPISmsPaymentData.GetOrderPaymentStatus(orderId)
				)
			};

			return response;
		}

		/// <summary>
		/// Эндпоинт запроса СМС для оплаты заказа
		/// </summary>
		/// <param name="payBySmsRequestModel"></param>
		[HttpPost]
		[Route("/api/PayBySms")]
		public void PayBySms(PayBySmsRequestDto payBySmsRequestModel)
		{
			smsPaymentServiceAPIHelper.SendPayment(payBySmsRequestModel.OrderId, payBySmsRequestModel.PhoneNumber).Wait();
		}
	}
}
