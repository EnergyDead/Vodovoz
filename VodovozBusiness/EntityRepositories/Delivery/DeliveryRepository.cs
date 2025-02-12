﻿using System;
using System.Collections.Generic;
using System.Linq;
using NetTopologySuite.Geometries;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Dialect.Function;
using NHibernate.Transform;
using QS.DomainModel.UoW;
using QS.Osm;
using QS.Osm.Osrm;
using QS.Utilities.Spatial;
using Vodovoz.Domain.Documents;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Orders;
using Vodovoz.Domain.Sale;
using Vodovoz.EntityRepositories.Goods;
using Vodovoz.Services;
using Order = Vodovoz.Domain.Orders.Order;

namespace Vodovoz.EntityRepositories.Delivery
{
	public class DeliveryRepository : IDeliveryRepository
	{
		#region Получение районов по координатам

		/// <summary>
		/// Возвращает первый попавшийся район, в котором содержатся переданные координаты
		/// </summary>
		/// <param name="uow">Unit of Work</param>
		/// <param name="latitude">Широта</param>
		/// <param name="longitude">Долгота</param>
		/// <param name="districtsSet">Версия районов, из которой будет подбираться район. Если равна null, то район подбирается из активной версии</param>
		public District GetDistrict(IUnitOfWork uow, decimal latitude, decimal longitude, DistrictsSet districtsSet = null)
		{
			var districts = GetDistricts(uow, latitude, longitude, districtsSet);
			return districts.FirstOrDefault();
		}

		/// <summary>
		/// Возвращает все районы, в которых содержатся переданные координаты
		/// </summary>
		/// <param name="uow">Unit of Work</param>
		/// <param name="latitude">Широта</param>
		/// <param name="longitude">Долгота</param>
		/// <param name="districtsSet">Версия районов, из которой будут подбираться районы. Если равна null, то районы подбираются из активной версии</param>
		public IEnumerable<District> GetDistricts(IUnitOfWork uow, decimal latitude, decimal longitude, DistrictsSet districtsSet = null)
		{
			Point point = new Point((double)latitude, (double)longitude);

			District districtAlias = null;
			DistrictsSet districtsSetAlias = null;

			var query = uow.Session.QueryOver<District>(() => districtAlias)
				.Left.JoinAlias(() => districtAlias.DistrictsSet, () => districtsSetAlias)
				.Where(x => x.DistrictBorder != null);

			if(districtsSet == null)
			{
				query.Where(() => districtsSetAlias.Status == DistrictsSetStatus.Active);
			}
			else
			{
				query.Where(() => districtsSetAlias.Id == districtsSet.Id);
			}

			var districtsWithBorders = query.List<District>();
			var districts = districtsWithBorders.Where(x => x.DistrictBorder.Contains(point)).ToList();

			if(districts.Any())
			{
				return districts;
			}

			foreach(var nearPoint in Get4PointsInRadiusOfXMetersFromBasePoint(point))
			{
				districts = districtsWithBorders.Where(x => x.DistrictBorder.Contains(nearPoint)).ToList();
				if(districts.Any())
				{
					return districts;
				}
			}
			return new List<District>();
		}

		/// <summary>
		/// Получение 4 точек, отстоящих от базовой точки на <paramref name="distanceInMeters"/> вправо, влево, вверх и вниз.
		/// </summary>
		/// <param name="basePoint">Базовая точка</param>
		/// <param name="distanceInMeters">Дистанция отступа от базовой точки <paramref name="basePoint"/></param>
		private Point[] Get4PointsInRadiusOfXMetersFromBasePoint(Point basePoint, double distanceInMeters = 100)
		{
			Point[] array = new Point[4];
			array[0] = new Point(GetNewLatitude(basePoint.X, distanceInMeters), basePoint.Y);
			array[1] = new Point(basePoint.X, GetNewLongitude(basePoint.Y, distanceInMeters));
			array[2] = new Point(GetNewLatitude(basePoint.X, -distanceInMeters), basePoint.Y);
			array[3] = new Point(basePoint.X, GetNewLongitude(basePoint.Y, -distanceInMeters));
			return array;
		}

		private double GetNewLatitude(double lat, double metersToAdd)
		{
			double earth = 6378.137; //radius of the earth in kilometer
			double pi = Math.PI;
			double m = 1 / (2 * pi / 360 * earth) / 1000; //1 meter in degree

			double newLatitude = lat + (metersToAdd * m);

			return newLatitude;
		}

		private double GetNewLongitude(double lon, double metersToAdd)
		{
			double earth = 6378.137; //radius of the earth in kilometer
			double pi = Math.PI;
			double m = 1 / (2 * pi / 360 * earth) / 1000; //1 meter in degree

			double newLongitude = lon + metersToAdd * m / Math.Cos(lon * (pi / 180));
			return newLongitude;
		}

		#endregion Получение районов по координатам

		#region Fast Delivery

		public bool FastDeliveryAvailable(IUnitOfWork uow, double latitude, double longitude,
			IDeliveryRulesParametersProvider deliveryRulesParametersProvider, IList<NomenclatureAmountNode> nomenclatureNodes)
		{
			var routeList =
				GetRouteListForFastDelivery(uow, latitude, longitude, false, deliveryRulesParametersProvider, nomenclatureNodes);
			return routeList != null;
		}

		public RouteList GetRouteListForFastDelivery(IUnitOfWork uow, double latitude, double longitude, bool getClosestByRoute,
			IDeliveryRulesParametersProvider deliveryRulesParametersProvider, IEnumerable<NomenclatureAmountNode> nomenclatureNodes)
		{
			var maxDistanceToTrackPoint = deliveryRulesParametersProvider.MaxDistanceToLatestTrackPointKm;
			var driverGoodWeightLiftPerHand = deliveryRulesParametersProvider.DriverGoodWeightLiftPerHandInKg;
			var maxFastOrdersPerSpecificTime = deliveryRulesParametersProvider.MaxFastOrdersPerSpecificTime;

			//Переводим всё в минуты
			var trackPointTimeOffset = (int)deliveryRulesParametersProvider.MaxTimeOffsetForLatestTrackPoint.TotalMinutes;
			var maxTimeForFastDelivery = (int)deliveryRulesParametersProvider.MaxTimeForFastDelivery.TotalMinutes;
			var minTimeForNewOrder = (int)deliveryRulesParametersProvider.MinTimeForNewFastDeliveryOrder.TotalMinutes;
			var driverUnloadTime = (int)deliveryRulesParametersProvider.DriverUnloadTime.TotalMinutes;
			var specificTimeForFastOrdersCount = (int)deliveryRulesParametersProvider.SpecificTimeForMaxFastOrdersCount.TotalMinutes;

			var neededNomenclatures = nomenclatureNodes.ToDictionary(x => x.NomenclatureId, x => x.Amount);

			Track t = null;
			TrackPoint tp = null;
			RouteList rl = null;
			TrackPoint tpInner = null;
			RouteListWithCoordinateNode result = null;
			Employee e = null;

			RouteListItem rla = null;
			Order o = null;
			OrderItem oi = null;
			OrderEquipment oe = null;
			CarLoadDocument scld = null;
			CarLoadDocumentItem scldi = null;

			RouteListNomenclatureAmount ordersAmountAlias = null;
			RouteListNomenclatureAmount loadDocumentsAmountAlias = null;

			var lastTimeTrackQuery = QueryOver.Of(() => tpInner)
				.Where(() => tpInner.Track.Id == t.Id)
				.Select(Projections.Max(() => tpInner.TimeStamp));

			//МЛ только в пути + последняя координата не раньше указанного времени
			var routeListNodes = uow.Session.QueryOver(() => rl)
				.JoinEntityAlias(() => t, () => t.RouteList.Id == rl.Id)
				.Inner.JoinAlias(() => t.TrackPoints, () => tp)
				.Inner.JoinAlias(() => rl.Driver, () => e)
				.WithSubquery.WhereProperty(() => tp.TimeStamp).Eq(lastTimeTrackQuery)
				.And(() => rl.Status == RouteListStatus.EnRoute)
				.And(Restrictions.GeProperty(
					Projections.Property(() => tp.TimeStamp),
					Projections.SqlFunction(
						new SQLFunctionTemplate(
							NHibernateUtil.DateTime,
							$"TIMESTAMPADD(MINUTE, -{trackPointTimeOffset}, CURRENT_TIMESTAMP)"),
						NHibernateUtil.DateTime)))
				.SelectList(list => list
					.Select(() => tp.TimeStamp).WithAlias(() => result.TimeStamp)
					.Select(() => tp.Latitude).WithAlias(() => result.Latitude)
					.Select(() => tp.Longitude).WithAlias(() => result.Longitude)
					.Select(Projections.Entity(() => rl)).WithAlias(() => result.RouteList))
				.TransformUsing(Transformers.AliasToBean<RouteListWithCoordinateNode>())
				.List<RouteListWithCoordinateNode>();

			//Последняя координата в указанном радиусе
			routeListNodes = routeListNodes
				.Where(x => DistanceHelper.GetDistanceKm(x.Latitude, x.Longitude, latitude, longitude) < maxDistanceToTrackPoint)
				.ToList();

			//Сортировка по расстоянию на карте. getClosestByRoute - расстояние считается по дорогам на карте
			if(getClosestByRoute)
			{
				var deliveryPoint = new PointOnEarth(latitude, longitude);

				int OrderBySelector(RouteListWithCoordinateNode x)
				{
					var proposedRoute = OsrmMain
						.GetRoute(new List<PointOnEarth> { new PointOnEarth(x.Latitude, x.Longitude), deliveryPoint }).Routes
						.FirstOrDefault();

					//Если не удалось подобрать маршрут ставим самый низкий приоритет в сортировке
					return proposedRoute?.TotalDistance ?? int.MaxValue;
				}

				routeListNodes = routeListNodes
					.OrderBy(OrderBySelector)
					.ToList();
			}
			else
			{
				routeListNodes = routeListNodes
					.OrderBy(x => DistanceHelper.GetDistanceKm(x.Latitude, x.Longitude, latitude, longitude))
					.ToList();
			}

			//Не более определённого кол-ва заказов с быстрой доставкой в определённый промежуток времени
			var addressCountSubquery = QueryOver.Of(() => rla)
				.Inner.JoinAlias(() => rla.Order, () => o)
				.Where(() => rla.RouteList.Id == rl.Id)
				.WhereRestrictionOn(() => rla.Status).Not.IsIn(RouteListItem.GetNotDeliveredStatuses())
				.And(() => o.IsFastDelivery)
				.And(Restrictions.GtProperty(
					Projections.Property(() => rla.CreationDate),
					Projections.SqlFunction(
						new SQLFunctionTemplate(NHibernateUtil.DateTime,
							$"TIMESTAMPADD(MINUTE, -{specificTimeForFastOrdersCount}, CURRENT_TIMESTAMP)"),
						NHibernateUtil.DateTime)))
				.Select(Projections.Count(() => rla.Id));

			var routeListsWithoutTooMuchFastOrders = uow.Session.QueryOver(() => rl)
				.WhereRestrictionOn(() => rl.Id).IsInG(routeListNodes.Select(x => x.RouteList.Id))
				.And(Subqueries.Gt(maxFastOrdersPerSpecificTime, addressCountSubquery.DetachedCriteria))
				.Select(x => x.Id)
				.List<int>();

			routeListNodes = routeListNodes.Where(x => routeListsWithoutTooMuchFastOrders.Contains(x.RouteList.Id)).ToList();

			//Время доставки следующего (текущего) заказа позволяет взять быструю доставку
			foreach(var routeListNode in routeListNodes.ToList())
			{
				RouteListItem latestAddress = null;

				var orderedEnRouteAddresses = routeListNode.RouteList.Addresses
					.Where(x => x.Status == RouteListItemStatus.EnRoute).OrderBy(x => x.IndexInRoute).ToList();

				var orderedCompletedAddresses = routeListNode.RouteList.Addresses
					.Where(x => x.Status == RouteListItemStatus.Completed).OrderBy(x => x.IndexInRoute).ToList();

				var latestCompletedAddress = orderedCompletedAddresses.OrderByDescending(x => x.StatusLastUpdate).FirstOrDefault();

				if(latestCompletedAddress != null)
				{
					latestAddress = orderedEnRouteAddresses.FirstOrDefault(x => x.IndexInRoute > latestCompletedAddress.IndexInRoute);
				}
				if(latestAddress == null)
				{
					latestAddress = orderedEnRouteAddresses.FirstOrDefault();
				}

				if(latestAddress == null || maxTimeForFastDelivery - latestAddress.Order.DeliveryPoint.MinutesToUnload < minTimeForNewOrder)
				{
					routeListNodes.Remove(routeListNode);
					continue;
				}

				var water19Count = latestAddress.Order.OrderItems
					.Where(x => x.Nomenclature.TareVolume == TareVolume.Vol19L && x.Nomenclature.Category == NomenclatureCategory.water)
					.Sum(x => x.Count);

				var orderItemsSummaryWeight = latestAddress.Order.OrderItems
					.Where(x => x.Nomenclature.TareVolume != TareVolume.Vol19L || x.Nomenclature.Category != NomenclatureCategory.water)
					.Sum(x => x.Nomenclature.Weight * x.Count);

				var orderEquipmentsSummaryWeight = latestAddress.Order.OrderEquipments
					.Where(x => x.Direction == Direction.Deliver)
					.Sum(x => x.Nomenclature.Weight * x.Count);

				var goodsSummaryWeight = orderItemsSummaryWeight + orderEquipmentsSummaryWeight;

				//Время выгрузки след. заказа:
				//(Суммарный вес прочих товаров / кол-во кг, которое водитель может унести в одной руке + кол-во 19л) / 2 руки * время выгрузки в 2 руках 2 бутылей или товара
				var unloadTime = (goodsSummaryWeight / driverGoodWeightLiftPerHand + water19Count) / 2 * driverUnloadTime;

				if(maxTimeForFastDelivery - unloadTime < minTimeForNewOrder)
				{
					routeListNodes.Remove(routeListNode);
				}
			}

			var rlIds = routeListNodes.Select(x => x.RouteList.Id).ToArray();

			//OrderItems
			var orderItemsToDeliver = uow.Session.QueryOver<RouteListItem>(() => rla)
				.Inner.JoinAlias(() => rla.Order, () => o)
				.Inner.JoinAlias(() => o.OrderItems, () => oi)
				.WhereRestrictionOn(() => rla.RouteList.Id).IsIn(rlIds)
				.WhereRestrictionOn(() => oi.Nomenclature.Id).IsIn(neededNomenclatures.Keys)
				.SelectList(list => list
					.SelectGroup(() => rla.RouteList.Id).WithAlias(() => ordersAmountAlias.RouteListId)
					.SelectGroup(() => oi.Nomenclature.Id).WithAlias(() => ordersAmountAlias.NomenclatureId)
					.SelectSum(() => oi.Count).WithAlias(() => ordersAmountAlias.Amount))
				.TransformUsing(Transformers.AliasToBean<RouteListNomenclatureAmount>())
				.Future<RouteListNomenclatureAmount>();

			//OrderEquipments
			var orderEquipmentsToDeliver = uow.Session.QueryOver<RouteListItem>(() => rla)
				.Inner.JoinAlias(() => rla.Order, () => o)
				.Inner.JoinAlias(() => o.OrderEquipments, () => oe)
				.WhereRestrictionOn(() => rla.RouteList.Id).IsIn(rlIds)
				.WhereRestrictionOn(() => oe.Nomenclature.Id).IsIn(neededNomenclatures.Keys)
				.And(() => oe.Direction == Direction.Deliver)
				.SelectList(list => list
					.SelectGroup(() => rla.RouteList.Id).WithAlias(() => ordersAmountAlias.RouteListId)
					.SelectGroup(() => oe.Nomenclature.Id).WithAlias(() => ordersAmountAlias.NomenclatureId)
					.Select(Projections.Sum(Projections.Cast(NHibernateUtil.Decimal, Projections.Property(() => oe.Count)))
					).WithAlias(() => ordersAmountAlias.Amount))
				.TransformUsing(Transformers.AliasToBean<RouteListNomenclatureAmount>())
				.Future<RouteListNomenclatureAmount>();

			//CarLoadDocuments
			var allLoaded = uow.Session.QueryOver<CarLoadDocument>(() => scld)
				.Inner.JoinAlias(() => scld.Items, () => scldi)
				.WhereRestrictionOn(() => scld.RouteList.Id).IsIn(rlIds)
				.WhereRestrictionOn(() => scldi.Nomenclature.Id).IsIn(neededNomenclatures.Keys)
				.SelectList(list => list
					.SelectGroup(() => scld.RouteList.Id).WithAlias(() => loadDocumentsAmountAlias.RouteListId)
					.SelectGroup(() => scldi.Nomenclature.Id).WithAlias(() => loadDocumentsAmountAlias.NomenclatureId)
					.SelectSum(() => scldi.Amount).WithAlias(() => loadDocumentsAmountAlias.Amount))
				.TransformUsing(Transformers.AliasToBean<RouteListNomenclatureAmount>())
				.Future<RouteListNomenclatureAmount>();

			var allToDeliver = orderItemsToDeliver
				.Union(orderEquipmentsToDeliver)
				.GroupBy(x => new { x.RouteListId, x.NomenclatureId })
				.Select(group => new RouteListNomenclatureAmount
				{
					RouteListId = group.Key.RouteListId,
					NomenclatureId = group.Key.NomenclatureId,
					Amount = group.Sum(x => x.Amount)
				})
				.ToList();

			//Выбираем МЛ, в котором хватает запаса номенклатур на поступивший быстрый заказ
			foreach(var routeListNode in routeListNodes)
			{
				var toDeliverForRL = allToDeliver.Where(x => x.RouteListId == routeListNode.RouteList.Id).ToList();
				var loadedForRL = allLoaded.Where(x => x.RouteListId == routeListNode.RouteList.Id).ToList();
				var isValidRl = true;

				foreach(var need in neededNomenclatures)
				{
					var toDeliver = toDeliverForRL.FirstOrDefault(x => x.NomenclatureId == need.Key)?.Amount ?? 0;
					var loaded = loadedForRL.FirstOrDefault(x => x.NomenclatureId == need.Key)?.Amount ?? 0;

					if(loaded - toDeliver < need.Value)
					{
						isValidRl = false;
						break;
					}
				}

				if(isValidRl)
				{
					return routeListNode.RouteList;
				}
			}

			return null;
		}

		private class RouteListNomenclatureAmount
		{
			public int RouteListId { get; set; }
			public int NomenclatureId { get; set; }
			public decimal Amount { get; set; }
		}

		private class RouteListWithCoordinateNode
		{
			public DateTime TimeStamp { get; set; }
			public double Latitude { get; set; }
			public double Longitude { get; set; }
			public RouteList RouteList { get; set; }
		}

		#endregion
	}
}
