﻿using DriverAPI.Library.Converters;
using DriverAPI.Library.DTOs;
using QS.DomainModel.UoW;
using System;
using System.Collections.Generic;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Logistic.Drivers;

namespace DriverAPI.Library.Models
{
	public class DriverMobileAppActionRecordModel : IDriverMobileAppActionRecordModel
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ActionTypeConverter _actionTypeConverter;

		public DriverMobileAppActionRecordModel(IUnitOfWork unitOfWork, ActionTypeConverter actionTypeConverter)
		{
			this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
			this._actionTypeConverter = actionTypeConverter ?? throw new ArgumentNullException(nameof(actionTypeConverter));
		}

		public void RegisterAction(Employee driver, DriverActionDto driverAction)
		{
			var record = new DriverMobileAppActionRecord()
			{
				Driver = driver,
				Action = _actionTypeConverter.ConvertToDriverMobileAppActionType(driverAction.ActionType),
				ActionDatetime = driverAction.ActionTime,
				RecievedDatetime = DateTime.Now
			};

			_unitOfWork.Save(record);
			_unitOfWork.Commit();
		}

		public void RegisterAction(int driverId, DriverMobileAppActionType actionType, DateTime actionTime, DateTime recievedTime, string result)
			=> RegisterAction(_unitOfWork.GetById<Employee>(driverId), actionType, actionTime, recievedTime, result);

		public void RegisterAction(Employee driver, DriverMobileAppActionType actionType, DateTime actionTime, DateTime recievedTime, string result)
		{
			var record = new DriverMobileAppActionRecord()
			{
				Driver = driver,
				Action = actionType,
				ActionDatetime = actionTime,
				Result = result,
				RecievedDatetime = recievedTime
			};

			_unitOfWork.Save(record);
			_unitOfWork.Commit();
		}

		public void RegisterActionsRangeForDriver(Employee driver, IEnumerable<DriverActionDto> driverActions)
		{
			foreach (var action in driverActions)
			{
				var record = new DriverMobileAppActionRecord()
				{
					Driver = driver,
					Action = _actionTypeConverter.ConvertToDriverMobileAppActionType(action.ActionType),
					ActionDatetime = action.ActionTime,
					RecievedDatetime = DateTime.Now
				};

				_unitOfWork.Save(record);
			}

			_unitOfWork.Commit();
		}
	}
}
