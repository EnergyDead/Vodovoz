﻿using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using BitrixIntegration.DTO;

namespace BitrixIntegration.ServiceInterfaces
{
	[ServiceContract(Name = "Bitrix", Namespace="urn:bitrixintegration:serviceinterfaces")]
	public interface IBitrixService
	{
		[WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
		[OperationContract]
		Tuple<bool, string> SendEmail(Email mail);
	}
}
