﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using NLog.Web;
using QS.Attachments.Domain;
using QS.Banks.Domain;
using QS.DomainModel.UoW;
using QS.HistoryLog;
using QS.Project.DB;
using Vodovoz.Core.DataService;
using Vodovoz.EntityRepositories.Cash;
using Vodovoz.EntityRepositories.FastPayments;
using Vodovoz.EntityRepositories.Logistic;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.EntityRepositories.Store;
using Vodovoz.NhibernateExtensions;
using Vodovoz.Parameters;
using Vodovoz.Services;
using Vodovoz.Tools;
using FastPaymentsAPI.Library.Converters;
using FastPaymentsAPI.Library.Factories;
using FastPaymentsAPI.Library.Managers;
using FastPaymentsAPI.Library.Models;
using FastPaymentsAPI.Library.Services;
using FastPaymentsAPI.Library.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddControllers()
	.AddXmlSerializerFormatters();

builder.Services.AddHttpClient();

Logger<Program> logger;
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FastPaymentsAPI v1"));
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void CreateBaseConfig()
{
	logger.LogInformation("Настройка параметров Nhibernate...");

	var conStrBuilder = new MySqlConnectionStringBuilder();

	var domainDBConfig = builder.Configuration.GetSection("DomainDB");

	conStrBuilder.Server = domainDBConfig.GetValue<string>("Server");
	conStrBuilder.Port = domainDBConfig.GetValue<uint>("Port");
	conStrBuilder.Database = domainDBConfig.GetValue<string>("Database");
	conStrBuilder.UserID = domainDBConfig.GetValue<string>("UserID");
	conStrBuilder.Password = domainDBConfig.GetValue<string>("Password");
	conStrBuilder.SslMode = MySqlSslMode.None;

	var connectionString = conStrBuilder.GetConnectionString(true);

	var db_config = FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard
		.Dialect<MySQL57SpatialExtendedDialect>()
		.ConnectionString(connectionString)
		.Driver<LoggedMySqlClientDriver>();

	// Настройка ORM
	OrmConfig.ConfigureOrm(
		db_config,
		new System.Reflection.Assembly[]
		{
			System.Reflection.Assembly.GetAssembly(typeof(QS.Project.HibernateMapping.UserBaseMap)),
			System.Reflection.Assembly.GetAssembly(typeof(QS.Project.HibernateMapping.TypeOfEntityMap)),
			System.Reflection.Assembly.GetAssembly(typeof(Vodovoz.HibernateMapping.OrganizationMap)),
			System.Reflection.Assembly.GetAssembly(typeof(Bank)),
			System.Reflection.Assembly.GetAssembly(typeof(HistoryMain)),
			System.Reflection.Assembly.GetAssembly(typeof(Attachment))
		}
	);

	var serviceUserId = 0;

	using(var unitOfWork = UnitOfWorkFactory.CreateWithoutRoot("Получение пользователя"))
	{
		serviceUserId = unitOfWork.Session.Query<Vodovoz.Domain.Employees.User>()
			.Where(u => u.Login == domainDBConfig.GetValue<string>("UserID"))
			.Select(u => u.Id)
			.FirstOrDefault();
	}

	QS.Project.Repositories.UserRepository.GetCurrentUserId = () => serviceUserId;
	HistoryMain.Enable();
}

void ConfigureServices(IServiceCollection services)
{
	services.AddLogging(
		logging =>
		{
			logging.ClearProviders();
			logging.AddNLogWeb();
		});

	logger = new Logger<Program>(LoggerFactory.Create(logging =>
		logging.AddNLogWeb(NLogBuilder.ConfigureNLog("NLog.config").Configuration)));
	
	// Подключение к БД
	
	services.AddScoped(_ => UnitOfWorkFactory.CreateWithoutRoot("Сервис быстрых платежей"));

	// Конфигурация Nhibernate

	try
	{
		CreateBaseConfig();
	}
	catch (Exception e)
	{
		logger.LogCritical(e, e.Message);
		throw;
	}
	
	services.AddSwaggerGen(c =>
	{
		c.SwaggerDoc("v1", new OpenApiInfo { Title = "FastPaymentsAPI", Version = "v1" });
	});
	
	services.AddHttpClient<IOrderService, OrderService>(c =>
	{
		c.BaseAddress = new Uri(builder.Configuration.GetSection("OrderService").GetValue<string>("ApiBase"));
		c.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");
	});
	
	services.AddHttpClient<IDriverAPIService, DriverAPIService>(c =>
	{
		c.BaseAddress = new Uri(builder.Configuration.GetSection("DriverAPIService").GetValue<string>("ApiBase"));
		c.DefaultRequestHeaders.Add("Accept", "application/json");
	});

	//backgroundServices
	services.AddHostedService<FastPaymentStatusUpdater>();
	services.AddHostedService<CachePaymentManager>();

	//repositories
	services.AddSingleton<IOrderRepository, OrderRepository>();
	services.AddSingleton<IFastPaymentRepository, FastPaymentRepository>();
	services.AddSingleton<IStandartNomenclatures, BaseParametersProvider>();
	services.AddSingleton<IRouteListItemRepository, RouteListItemRepository>();
	services.AddSingleton<ISelfDeliveryRepository, SelfDeliveryRepository>();
	services.AddSingleton<ICashRepository, CashRepository>();
	
	//providers
	services.AddSingleton<IParametersProvider, ParametersProvider>();
	services.AddSingleton<IOrderParametersProvider, OrderParametersProvider>();
	services.AddSingleton<IFastPaymentParametersProvider, FastPaymentParametersProvider>();
	services.AddSingleton<IEmailParametersProvider, EmailParametersProvider>();
	
	//factories
	services.AddSingleton<IFastPaymentAPIFactory, FastPaymentAPIFactory>();

	//converters
	services.AddSingleton<IOrderSumConverter, OrderSumConverter>();
	services.AddSingleton<IResponseCodeConverter, ResponseCodeConverter>();
	
	//models
	services.AddScoped<IOrderModel, OrderModel>();
	services.AddScoped<IFastPaymentModel, FastPaymentModel>();
	
	//validators
	services.AddScoped<IFastPaymentValidator, FastPaymentValidator>();
	
	//helpers
	services.AddSingleton<IDTOManager, DTOManager>();
	services.AddSingleton<ISignatureManager, SignatureManager>();
	services.AddSingleton<IFastPaymentManager, FastPaymentManager>();
	services.AddSingleton(_ => new FastPaymentFileCache("/tmp/VodovozFastPaymentServiceTemp.txt"));
	services.AddScoped<IOrderRequestManager, OrderRequestManager>();
}
