﻿using NHibernate.Criterion;
using QS.DomainModel.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Goods;
using Vodovoz.Domain.Orders;
using Order = Vodovoz.Domain.Orders.Order;

namespace Vodovoz.EntityRepositories.Delivery
{
	public class DeliveryPointRepository : IDeliveryPointRepository
	{
		public IList<DeliveryPoint> DeliveryPointsForCounterpartyQuery(IUnitOfWork uow, Counterparty counterparty)
		{
			return uow.Session.QueryOver<DeliveryPoint>()
				.Where(dp => dp.Counterparty.Id == counterparty.Id)
				.List();
		}

		public decimal GetAvgBottlesOrdered(IUnitOfWork uow, DeliveryPoint deliveryPoint, int? countLastOrders)
		{
			Order orderAlias = null;
			OrderItem orderItemAlias = null;
			Nomenclature nomenclatureAlias = null;

			var confirmedQueryResult = uow.Session.QueryOver<Order>(() => orderAlias)
				.Where(() => orderAlias.DeliveryPoint.Id == deliveryPoint.Id)
				.Where(() => orderAlias.OrderStatus == OrderStatus.Closed)
				.JoinAlias(() => orderAlias.OrderItems, () => orderItemAlias)
				.JoinAlias(() => orderItemAlias.Nomenclature, () => nomenclatureAlias)
				.Where(() => nomenclatureAlias.Category == NomenclatureCategory.water && !nomenclatureAlias.IsDisposableTare)
				.OrderByAlias(() => orderAlias.DeliveryDate).Desc;
			if(countLastOrders.HasValue)
				confirmedQueryResult.Take(countLastOrders.Value);

			var list = confirmedQueryResult.Select(Projections.Group<Order>(x => x.Id),
				Projections.Sum(() => orderItemAlias.Count)).List<object[]>();

			return list.Count > 0 ? list.Average(x => (decimal)x[1]) : 0;
		}
		/*
		public int GetBottlesOrderedForPeriod(IUnitOfWork uow, DeliveryPoint deliveryPoint, DateTime start, DateTime end)
		{
			Order orderAlias = null;
			OrderItem orderItemAlias = null;
			Nomenclature nomenclatureAlias = null;

			var notConfirmedQueryResult = uow.Session.QueryOver<Order>(() => orderAlias)
				.Where(() => orderAlias.DeliveryPoint.Id == deliveryPoint.Id)
				.Where(() => start < orderAlias.DeliveryDate && orderAlias.DeliveryDate < end)
				.Where(() => orderAlias.OrderStatus != OrderStatus.Canceled)
				.JoinAlias(() => orderAlias.OrderItems, () => orderItemAlias)
				.JoinAlias(() => orderItemAlias.Nomenclature, () => nomenclatureAlias)
				.Where(() => nomenclatureAlias.Category == NomenclatureCategory.water && !nomenclatureAlias.IsDisposableTare)
				.Select(Projections.Sum(() => orderItemAlias.Count)).List<decimal?>();

			var confirmedQueryResult = uow.Session.QueryOver<Order>(() => orderAlias)
				.Where(() => orderAlias.DeliveryPoint.Id == deliveryPoint.Id)
				.Where(() => start < orderAlias.DeliveryDate && orderAlias.DeliveryDate < end)
				.Where(() => orderAlias.OrderStatus == OrderStatus.Closed)
				.JoinAlias(() => orderAlias.OrderItems, () => orderItemAlias)
				.JoinAlias(() => orderItemAlias.Nomenclature, () => nomenclatureAlias)
				.Where(() => nomenclatureAlias.Category == NomenclatureCategory.water && !nomenclatureAlias.IsDisposableTare)
				.Where(() => orderItemAlias.ActualCount != null)
				.Select(Projections.Sum(() => orderItemAlias.ActualCount)).List<decimal?>();

			var bottlesOrdered = notConfirmedQueryResult.FirstOrDefault().GetValueOrDefault()
				+ confirmedQueryResult.FirstOrDefault().GetValueOrDefault();
			return (int)bottlesOrdered;
		}
		*/

		public DeliveryPoint GetByAddress1c(IUnitOfWork uow, Counterparty counterparty, string address1cCode, string address1c)
		{
			if(String.IsNullOrWhiteSpace(address1c) || counterparty != null)
				return null;

			return uow.Session.QueryOver<DeliveryPoint>()
					  .Where(x => x.Counterparty.Id == counterparty.Id)
					  .Where(dp => (dp.Code1c != null && dp.Code1c == address1cCode) || dp.Address1c == address1c)
					  .Take(1)
					  .SingleOrDefault();
		}

		public IList<DeliveryPoint> GetDeliveryPointForCounterpartyByCoordinates(IUnitOfWork uow, decimal latitude, decimal longitude, int counterpartyId)
		{
			return uow.Session.QueryOver<DeliveryPoint>()
				.Where(x => x.Latitude == latitude)
				.Where(x => x.Longitude == longitude)
				.Where(x => x.Counterparty.Id == counterpartyId)
				.List();
		}
	}
}
