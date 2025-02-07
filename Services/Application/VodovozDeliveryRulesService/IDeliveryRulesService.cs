﻿using System.ServiceModel;
using System.ServiceModel.Web;

namespace VodovozDeliveryRulesService
{
	[ServiceContract]
	public interface IDeliveryRulesService
	{
		[WebGet(ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		DeliveryRulesDTO GetRulesByDistrict(decimal latitude, decimal longitude);

		[WebInvoke(ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		DeliveryRulesDTO GetRulesByDistrictAndNomenclatures(DeliveryRulesRequest request);

		[WebGet(ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		DeliveryInfoDTO GetDeliveryInfo(decimal latitude, decimal longitude);

		[OperationContract]
		[WebGet(ResponseFormat = WebMessageFormat.Json)]
		bool ServiceStatus();
	}
}
