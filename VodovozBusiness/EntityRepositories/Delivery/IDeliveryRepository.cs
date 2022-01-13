﻿using System.Collections.Generic;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Logistic;
using Vodovoz.Domain.Sale;

namespace Vodovoz.EntityRepositories.Delivery
{
	public interface IDeliveryRepository
	{
		/// <summary>
		/// Возвращает район для указанных координат, 
		/// если существует наложение районов, то возвращает первый попавшийся район 
		/// </summary>
		District GetDistrict(IUnitOfWork uow, decimal latitude, decimal longitude, DistrictsSet districtsSet = null);

		/// <summary>
		/// Возвращает список районов в границы которых входят указанные координаты
		/// </summary>
		IEnumerable<District> GetDistricts(IUnitOfWork uow, decimal latitude, decimal longitude, DistrictsSet districtsSet = null);
	}
}
