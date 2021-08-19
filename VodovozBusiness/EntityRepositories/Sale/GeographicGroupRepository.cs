﻿using System.Collections.Generic;
using System.Linq;
using NetTopologySuite.Geometries;
using NHibernate.Criterion;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Sale;
using Vodovoz.Domain.Sectors;

namespace Vodovoz.EntityRepositories.Sale
{
	public class GeographicGroupRepository : IGeographicGroupRepository
	{
		private QueryOver<GeographicGroup> GeographicGroupsWithCoordinatesQuery()
		{
			return QueryOver.Of<GeographicGroup>().Where(x => x.BaseLatitude != null && x.BaseLongitude != null);
		}

		public GeographicGroup GeographicGroupByCoordinates(double? lat, double? lon, IList<SectorVersion> source)
		{
			GeographicGroup gg = null;
			
			if(lat.HasValue && lon.HasValue)
			{
				var point = new Point(lat.Value, lon.Value);
				gg = source.FirstOrDefault(d => d.Polygon != null && d.Polygon.Contains(point))?
				           .GeographicGroup;
			}
			
			return gg;
		}

		public IList<GeographicGroup> GeographicGroupsWithCoordinates(IUnitOfWork uow)
		{
			return GeographicGroupsWithCoordinatesQuery()
							.GetExecutableQueryOver(uow.Session)
							.List();
		}
	}
}