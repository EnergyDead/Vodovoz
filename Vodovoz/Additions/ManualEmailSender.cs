﻿using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NLog.Extensions.Logging;
using QS.DomainModel.UoW;
using RabbitMQ.Infrastructure;
using RabbitMQ.MailSending;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Vodovoz.Domain.Orders.Documents;
using Vodovoz.Domain.StoredEmails;
using VodovozInfrastructure.Configuration;

namespace Vodovoz.Additions
{
	public class ManualEmailSender
	{
		public ManualEmailSender()
		{
		}

		public void ResendEmailWithErrorSendingStatus(DateTime date)
		{
			IList<StoredEmail> errorSendedEmails;
			using(var uowLocal = UnitOfWorkFactory.CreateWithoutRoot())
			{
				var configuration = uowLocal.GetAll<InstanceMailingConfiguration>().FirstOrDefault();

				StoredEmail unsendedEmailAlias = null;

				var dateCriterion = Projections.SqlFunction(
				   new SQLFunctionTemplate(
					   NHibernateUtil.Date,
					   "Date(?1)"
					  ),
				   NHibernateUtil.Date,
				   Projections.Property<StoredEmail>(x => x.SendDate)
				);
				ICriterion dateResctict = Restrictions.Eq(dateCriterion, date.Date);
				ICriterion dateResctictGe = Restrictions.Ge(dateCriterion, date.Date);

				var resendedQuery = QueryOver.Of<StoredEmail>()
					.Where(Restrictions.EqProperty(Projections.Property<StoredEmail>(x => x.Order.Id), Projections.Property(() => unsendedEmailAlias.Order.Id)))
					.Where(x => x.State != StoredEmailStates.SendingError)
					.Where(dateResctictGe)
					.Select(Projections.Count(Projections.Id()));

				errorSendedEmails = uowLocal.Session.QueryOver<StoredEmail>(() => unsendedEmailAlias)
					.Where(x => x.State == StoredEmailStates.SendingError)
					.Where(dateResctict)
					.WithSubquery.WhereValue(0).Eq(resendedQuery)
					.List();

				foreach(var sendedEmail in errorSendedEmails)
				{
					if(!(sendedEmail.Order.OrderDocuments.FirstOrDefault(y => y.Type == OrderDocumentType.Bill) is BillDocument billDocument))
					{
						continue;
					}

					try
					{
						var prepareMailMessage = new PrepareEmailMessage
						{
							StoredEmailId = sendedEmail.Id,
							SendAttemptsCount = 5
						};

						var serializedMessage = JsonSerializer.Serialize(prepareMailMessage);
						var preparingBody = Encoding.UTF8.GetBytes(serializedMessage);

						var Logger = new Logger<RabbitMQConnectionFactory>(new NLogLoggerFactory());

						var connectionFactory = new RabbitMQConnectionFactory(Logger);
						var connection = connectionFactory.CreateConnection(configuration.MessageBrokerHost, configuration.MessageBrokerUsername, configuration.MessageBrokerPassword, configuration.MessageBrokerVirtualHost);
						var channel = connection.CreateModel();

						channel.BasicPublish(configuration.EmailPrepareExchange, configuration.EmailPrepareKey, false, null, preparingBody);
					}
					catch(Exception e)
					{
						Console.WriteLine($"Ошибка отправки { sendedEmail.Id } : { e.Message }");
					}
				}
			}
		}
	}
}
