﻿using Newtonsoft.Json;

namespace Bitrix.DTO
{
	public class CompanyResponse
	{
		[JsonProperty("result")]
		public Company Result { get; set; }

		[JsonProperty("time")]
		public ResponseTime ResponseTime { get; set; }
	}
}
