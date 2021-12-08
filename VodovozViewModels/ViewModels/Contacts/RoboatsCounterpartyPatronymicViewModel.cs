﻿using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Domain.Contacts;

namespace Vodovoz.ViewModels.ViewModels.Contacts
{
	public class RoboatsCounterpartyPatronymicViewModel : EntityTabViewModelBase<RoboAtsCounterpartyName>
	{
		public RoboatsCounterpartyPatronymicViewModel(IEntityUoWBuilder uowBuilder, IUnitOfWorkFactory unitOfWorkFactory, ICommonServices commonServices)
			: base(uowBuilder, unitOfWorkFactory, commonServices)
		{
			TabName = "Отчества контрагентов RoboATS";
		}
	}
}
