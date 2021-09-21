﻿using System;
using System.Runtime.Serialization;
using Vodovoz.Domain.Logistic;

namespace Vodovoz.Domain.Cash
{
	[Serializable]
	public class MissingOrdersWithCashlessPaymentTypeException : InvalidOperationException
	{
		public MissingOrdersWithCashlessPaymentTypeException(RouteList routeList)
		{
			RouteList = routeList;
		}

		public RouteList RouteList { get; }
	}
}
