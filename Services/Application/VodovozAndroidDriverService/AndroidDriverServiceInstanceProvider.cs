﻿using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Vodovoz.Domain.WageCalculation.CalculationServices.RouteList;
using Android;
using Vodovoz.Services;
using SmsPaymentService;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.Logistic;

namespace VodovozAndroidDriverService
{
	public class AndroidDriverServiceInstanceProvider : IInstanceProvider
	{
		private readonly WageParameterService _wageParameterService;
		private readonly IDriverServiceParametersProvider _parameters;
		private readonly ChannelFactory<ISmsPaymentService> _smsPaymentChannelFactory;
		private readonly IDriverNotificator _driverNotificator;
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IRouteListRepository _routeListRepository;
		private readonly IRouteListItemRepository _routeListItemRepository;

		public AndroidDriverServiceInstanceProvider(
			WageParameterService wageParameterService, 
			IDriverServiceParametersProvider parameters,
			ChannelFactory<ISmsPaymentService> smsPaymentChannelFactory,
			IDriverNotificator driverNotificator,
			IEmployeeRepository employeeRepository,
			IRouteListRepository routeListRepository,
			IRouteListItemRepository routeListItemRepository)
		{
			_wageParameterService = wageParameterService ?? throw new ArgumentNullException(nameof(wageParameterService));
			_parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
			_smsPaymentChannelFactory = smsPaymentChannelFactory ?? throw new ArgumentNullException(nameof(smsPaymentChannelFactory));
			_driverNotificator = driverNotificator ?? throw new ArgumentNullException(nameof(driverNotificator));
			_employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
			_routeListRepository = routeListRepository ?? throw new ArgumentNullException(nameof(routeListRepository));
			_routeListItemRepository = routeListItemRepository ?? throw new ArgumentNullException(nameof(routeListItemRepository));
		}

		#region IInstanceProvider implementation

		public object GetInstance(InstanceContext instanceContext)
		{
			return new AndroidDriverService(
				_wageParameterService, _parameters, _smsPaymentChannelFactory, _driverNotificator, _employeeRepository,
				_routeListRepository, _routeListItemRepository);
		}

		public object GetInstance(InstanceContext instanceContext, Message message)
		{
			return GetInstance(instanceContext);
		}

		public void ReleaseInstance(InstanceContext instanceContext, object instance)
		{
		}

		#endregion IInstanceProvider implementation
	}
}
