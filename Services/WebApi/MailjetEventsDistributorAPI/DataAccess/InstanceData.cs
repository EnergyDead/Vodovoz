﻿using Dapper;
using MailjetEventMessagesDistributorAPI.DTO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace MailjetEventMessagesDistributorAPI.DataAccess
{
	public class InstanceData : IInstanceData
	{
		private readonly IConfiguration _configuration;

		public InstanceData(IConfiguration configuration)
		{
			_configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
		}

		public InstanceDto GetInstanceByDatabaseId(int Id)
		{
			string connectionString = _configuration.GetConnectionString("Default");

			using IDbConnection connection = new MySqlConnection(connectionString);
			var output = connection.Query<InstanceDto>(
				"SELECT\n" +
				"	i.id AS Id,\n" +
				"	i.database_id AS DatabaseId,\n" +
				"	i.message_brocker_uri AS MessageBrockerUri,\n" +
				"	i.message_brocker_virtual_host AS MessageBrockerVirtualHost\n" +
				"FROM instances i\n" +
				$"WHERE i.database_id = { Id };"
				).ToList().FirstOrDefault();

			return output;
		}
	}
}
