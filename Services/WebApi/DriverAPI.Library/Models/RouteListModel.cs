﻿using DriverAPI.Library.Converters;
using DriverAPI.Library.DTOs;
using Microsoft.Extensions.Logging;
using QS.DomainModel.UoW;
using System;
using System.Collections.Generic;
using System.Data;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Logistic;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.Logistic;

namespace DriverAPI.Library.Models
{
	public class RouteListModel : IRouteListModel
	{
		private readonly ILogger<RouteListModel> _logger;
		private readonly IRouteListRepository _routeListRepository;
		private readonly IRouteListItemRepository _routeListItemRepository;
		private readonly RouteListConverter _routeListConverter;
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IUnitOfWork _unitOfWork;

		public RouteListModel(ILogger<RouteListModel> logger,
			IRouteListRepository routeListRepository,
			IRouteListItemRepository routeListItemRepository,
			RouteListConverter routeListConverter,
			IEmployeeRepository employeeRepository,
			IUnitOfWork unitOfWork)
		{
			this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
			this._routeListRepository = routeListRepository ?? throw new ArgumentNullException(nameof(routeListRepository));
			this._routeListItemRepository = routeListItemRepository ?? throw new ArgumentNullException(nameof(routeListItemRepository));
			this._routeListConverter = routeListConverter ?? throw new ArgumentNullException(nameof(routeListConverter));
			this._employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
			this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		/// <summary>
		/// Получение информации о маошрутном листе в требуемом формате
		/// </summary>
		/// <param name="routeListId">Идентификатор МЛ</param>
		/// <returns>APIRouteList</returns>
		public RouteListDto Get(int routeListId)
		{
			var routeList = _routeListRepository.GetRouteListById(_unitOfWork, routeListId)
				?? throw new DataNotFoundException(nameof(routeListId), $"Маршрутный лист {routeListId} не найден");

			return _routeListConverter.convertToAPIRouteList(routeList, _routeListRepository.GetDeliveryItemsToReturn(_unitOfWork, routeListId));
		}

		/// <summary>
		/// Получение информации о маршрутных листах в требуемом формате
		/// </summary>
		/// <param name="routeListsIds">Список идентификаторов МЛ</param>
		/// <returns>IEnumerable APIRouteList</returns>
		public IEnumerable<RouteListDto> Get(int[] routeListsIds)
		{
			var vodovozRouteLists = _routeListRepository.GetRouteListsByIds(_unitOfWork, routeListsIds);
			var routeLists = new List<RouteListDto>();

			foreach (var routelist in vodovozRouteLists)
			{
				try
				{
					routeLists.Add(_routeListConverter.convertToAPIRouteList(routelist, _routeListRepository.GetDeliveryItemsToReturn(_unitOfWork, routelist.Id)));
				}
				catch (ConverterException e)
				{
					_logger.LogWarning(e, $"Ошибка конвертирования маршрутного листа {routelist.Id}");
				}
			}

			return routeLists;
		}

		/// <summary>
		/// Получение списка идентификаторов МЛ для водителя по его Email адресу
		/// </summary>
		/// <param name="login">Android - login</param>
		/// <returns>Список идентификаторов</returns>
		public IEnumerable<int> GetRouteListsIdsForDriverByAndroidLogin(string login)
		{
			var driver = _employeeRepository.GetDriverByAndroidLogin(_unitOfWork, login)
				?? throw new DataNotFoundException(nameof(login), $"Водитель не найден");

			return _routeListRepository.GetDriverRouteListsIds(
					_unitOfWork,
					driver,
					Vodovoz.Domain.Logistic.RouteListStatus.EnRoute
				);
		}

		public void RegisterCoordinateForRouteListItem(int routeListAddressId, decimal latitude, decimal longitude, DateTime actionTime)
		{
			var deliveryPoint = _routeListItemRepository.GetRouteListItemById(_unitOfWork, routeListAddressId)?.Order?.DeliveryPoint
				?? throw new DataNotFoundException(nameof(routeListAddressId), $"Точка доставки для адреса не найдена");

			var coordinate = new DeliveryPointEstimatedCoordinate()
			{
				DeliveryPointId = deliveryPoint.Id,
				Latitude = latitude,
				Longitude = longitude,
				RegistrationTime = actionTime
			};

			deliveryPoint.DeliveryPointEstimatedCoordinates.Add(coordinate);

			_unitOfWork.Save(coordinate);
			_unitOfWork.Save(deliveryPoint);
			_unitOfWork.Commit();
		}

		public string GetActualDriverPushNotificationsTokenByOrderId(int orderId)
		{
			return _employeeRepository.GetEmployeePushTokenByOrderId(_unitOfWork, orderId)
				?? throw new DataNotFoundException(nameof(orderId), $"Не найден токен для PUSH-сообщения водителя заказа {orderId}");
		}

		public void RollbackRouteListAddressStatusEnRoute(int routeListAddressId)
		{
			if(routeListAddressId <= 0)
			{
				throw new DataNotFoundException(nameof(routeListAddressId), routeListAddressId, "Идентификатор адреса МЛ не может быть меньше или равен нулю");
			}

			var routeListAddress = _routeListItemRepository.GetRouteListItemById(_unitOfWork, routeListAddressId)
				?? throw new DataNotFoundException(nameof(routeListAddressId), routeListAddressId, "Указан идентификатор несуществующего адреса МЛ");

			if(routeListAddress.Status == RouteListItemStatus.Transfered)
			{
				throw new InvalidOperationException("Перенесенный адрес нельзя вернуть в путь");
			}

			routeListAddress.UpdateStatus(_unitOfWork, RouteListItemStatus.EnRoute);

			_unitOfWork.Save(routeListAddress);
			_unitOfWork.Commit();
		}
	}
}
