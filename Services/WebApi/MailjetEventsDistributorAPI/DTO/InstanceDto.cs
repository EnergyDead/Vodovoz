﻿namespace MailjetEventsDistributorAPI.DTO
{
	public class InstanceDto
	{
		public int Id { get; set; }
		public int DatabaseId { get; set; }
		public string MessageBrockerHost { get; set; }
		public string MessageBrockerVirtualHost { get; set; }
	}
}
