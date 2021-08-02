﻿using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using BitrixApi.REST;
using BitrixIntegration;
using BitrixIntegration.ServiceInterfaces;
using Mono.Unix;
using Mono.Unix.Native;
using MySql.Data.MySqlClient;
using Nini.Config;
using NLog;
using QS.DomainModel.UoW;
using QS.Project.DB;
using QSProjectsLib;
using Vodovoz.Core.DataService;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Common;
using Vodovoz.EntityRepositories.Counterparties;
using Vodovoz.EntityRepositories.Delivery;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.Models;
using Vodovoz.Parameters;
using Vodovoz.Repositories.Client;
using Vodovoz.Services;

namespace VodovozBitrixIntegrationService
{
	class Service
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		// private static readonly string configFile = "/home/gavr/vodovoz-bitrix-integration-service.conf"; 
		private static readonly string configFile = "/etc/vodovoz-bitrix-integration-service.conf"; 
			
		//Service
		private static string serviceHostName;
		private static string servicePort;
		private static string serviceWebPort;

		//Mysql
		private static string mysqlServerHostName;
		private static string mysqlServerPort;
		private static string mysqlUser;
		private static string mysqlPassword;
		private static string mysqlDatabase;
		
		//Bitrix
		private static string token;
		private static string userId;
		

		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += AppDomain_CurrentDomain_UnhandledException;
			AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
			logger.Info("Чтение конфигурационного файла...");

			#region ReadConfig

			try {
				IniConfigSource confFile = new IniConfigSource(configFile);
				confFile.Reload();
				IConfig serviceConfig = confFile.Configs["Service"];
				serviceHostName = serviceConfig.GetString("service_host_name");
				servicePort = serviceConfig.GetString("service_port");
				serviceWebPort = serviceConfig.GetString("service_web_port");

				IConfig mysqlConfig = confFile.Configs["Mysql"];
				mysqlServerHostName = mysqlConfig.GetString("mysql_server_host_name");
				mysqlServerPort = mysqlConfig.GetString("mysql_server_port", "3306");
				mysqlUser = mysqlConfig.GetString("mysql_user");
				mysqlPassword = mysqlConfig.GetString("mysql_password");
				mysqlDatabase = mysqlConfig.GetString("mysql_database");
				
				IConfig bitrixConfig = confFile.Configs["Bitrix"];
				token = bitrixConfig.GetString("api_key");
				userId = bitrixConfig.GetString("user_id");
			}
			catch(Exception ex) {
				logger.Fatal(ex, "Ошибка чтения конфигурационного файла.");
				return;
			}

			#endregion ReadCOnfig
			logger.Info("Настройка подключения к БД...");
			ConfigureDBConnection();
			
			RunServiceLoop();
		}

		#region Configure

		static void ConfigureDBConnection()
		{
			try
			{
				var conStrBuilder = new MySqlConnectionStringBuilder
				{
					Server = mysqlServerHostName,
					Port = UInt32.Parse(mysqlServerPort),
					Database = mysqlDatabase,
					UserID = mysqlUser,
					Password = mysqlPassword,
					SslMode = MySqlSslMode.None
				};
				
				QSMain.ConnectionString = conStrBuilder.GetConnectionString(true);
				var dbConfig = FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard
					.ConnectionString(conStrBuilder.GetConnectionString(true)); 

				OrmConfig.ConfigureOrm(
					dbConfig,
					new[]
					{
						System.Reflection.Assembly.GetAssembly(typeof(Vodovoz.HibernateMapping.OrganizationMap)),
						System.Reflection.Assembly.GetAssembly(typeof(QS.Banks.Domain.Bank)),
						System.Reflection.Assembly.GetAssembly(typeof(QS.HistoryLog.HistoryMain)),
						System.Reflection.Assembly.GetAssembly(typeof(QS.Project.Domain.UserBase))
					});

				QS.HistoryLog.HistoryMain.Enable();
			}
			catch (Exception ex)
			{
				logger.Fatal(ex, "Ошибка в настройке подключения к БД.");
			}
		}
		
		#endregion

		#region StartService
		static void RunServiceLoop()
		{
			try
			{
				StartService();
				logger.Info("Server started.");

				if(Environment.OSVersion.Platform == PlatformID.Unix) {
					UnixSignal[] signals = {
						new UnixSignal (Signum.SIGINT),
						new UnixSignal (Signum.SIGHUP),
						new UnixSignal (Signum.SIGTERM)
					};
					UnixSignal.WaitAny(signals);
				}
				else {
					Console.ReadLine();
				}
			}
			catch(Exception e) {
				logger.Fatal(e);
			}
			finally {
				if(Environment.OSVersion.Platform == PlatformID.Unix)
					Thread.CurrentThread.Abort();
				Environment.Exit(0);
			}
		}
		
		static async void StartService()
		{
			try
			{
				IBitrixServiceSettings bitrixServiceSettings = new BitrixServiceSettings(SingletonParametersProvider.Instance);
				var bitrixInstanceProvider = new BitrixInstanceProvider(bitrixServiceSettings);

				IMeasurementUnitsRepository measurementUnitsRepository = new MeasurementUnitsRepository();
				
				var bitrixHost = new BitrixServiceHost(bitrixInstanceProvider);

				var webContract = typeof(IBitrixServiceWeb);
				var webBinding = new WebHttpBinding();
				var webAddress = $"http://{serviceHostName}:{serviceWebPort}/BitrixServiceWeb";

				var webEndPoint = bitrixHost.AddServiceEndpoint(webContract, webBinding, webAddress);
				
				
				WebHttpBehavior httpBehavior = new WebHttpBehavior();
				webEndPoint.Behaviors.Add(httpBehavior);

				var contract = typeof(IBitrixService);
				var binding = new BasicHttpBinding();
				var address = $"http://{serviceHostName}:{servicePort}/BitrixService";


				BitrixManager.SetToken(token);

				var uow = UnitOfWorkFactory.CreateWithoutRoot();
				var deliveryPointRepository = new DeliveryPointRepository();
				var matcher = new Matcher(deliveryPointRepository);
				var bitrixApi = BitrixRestApiFactory.CreateBitrixRestApi(userId, token);
				var orderOrganizationProviderFactory = new OrderOrganizationProviderFactory();
				var orderOrganizationProvider = orderOrganizationProviderFactory.CreateOrderOrganizationProvider();
				var counterpartyContractRepository = new CounterpartyContractRepository(orderOrganizationProvider);
				var counterpartyContractFactory = new CounterpartyContractFactory(orderOrganizationProvider, counterpartyContractRepository);
				var orderRepository = OrderSingletonRepository.GetInstance();
				var counterpartyRepository = new CounterpartyRepository();
				
					var dealProcessor = new DealProcessor(
						bitrixApi,
						matcher,
						counterpartyContractRepository,
						counterpartyContractFactory,
						measurementUnitsRepository,
						bitrixServiceSettings,
						orderRepository,
						counterpartyRepository
					);
					
					var dealCollector = new DealCollector(bitrixApi, new DealFromBitrixRepository());
					var mainCycle = new MainCycle(uow, dealCollector, dealProcessor);
					
					await mainCycle.RunProcessCycle();
					
				BitrixManager.SetDealProcessor(dealProcessor);

				bitrixHost.AddServiceEndpoint(contract, binding, address);
				
				bitrixHost.Description.Behaviors.Add(new PreFilter());
				ServiceDebugBehavior debug = bitrixHost.Description.Behaviors.Find<ServiceDebugBehavior>();
				debug.IncludeExceptionDetailInFaults = true;
				
				bitrixHost.Open();

				logger.Log(LogLevel.Info, "Сервис запущен");

			}
			catch (Exception e)
			{
				logger.Error($"!Ошибка дошла до самого верхнего уровня! Ошибка: {e.Message}\n\n{e.InnerException?.Message}");
			}

#if DEBUG
			// MailjetEventsHost.Description.Behaviors.Add(new PreFilter());
#endif
			// EmailSendingHost.Open();
			// MailjetEventsHost.Open();
		}

		#endregion StartService

		#region Signals

		static void CurrentDomain_ProcessExit(object sender, EventArgs e)
		{
			BitrixManager.StopWorkers();
		}

		static void AppDomain_CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			logger.Fatal((Exception)e.ExceptionObject, "UnhandledException");
		}

		#endregion
		
	}
}
