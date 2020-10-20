﻿using System;
using System.Collections.Generic;
using QS.Dialog;
using QS.DomainModel.UoW;
using QS.Navigation;
using Vodovoz.Infrastructure.Mango;

namespace Vodovoz.ViewModels.Mango.Talks
{
	public class InternalTalkViewModel : TalkViewModelBase
	{
		private readonly IUnitOfWorkFactory unitOfWorkFactory;
		private readonly IUnitOfWork UoW;
		private readonly ITdiCompatibilityNavigation tdiCompatibilityNavigation;
		private readonly IInteractiveQuestion interactive;


		public InternalTalkViewModel(IUnitOfWorkFactory unitOfWorkFactory,
			ITdiCompatibilityNavigation navigation,
			IInteractiveQuestion interactive,
			MangoManager manager) : base(navigation,manager)
		{
			this.unitOfWorkFactory = unitOfWorkFactory;
			this.tdiCompatibilityNavigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
			this.interactive = interactive ?? throw new ArgumentNullException(nameof(interactive));
			this.UoW = unitOfWorkFactory.CreateWithoutRoot();

			if(manager.IsOutgoing)
				Title = "Исходящий звонок";
			else
				Title = "Входящий звонок";
		}

		#region Свойства View

		public string OnLineText => MangoManager.CurrentTalk?.OnHoldText;
		public bool ShowTransferCaller => MangoManager.CurrentTalk.IsTransfer;
		public bool ShowReturnButton => MangoManager.CurrentTalk.IsTransfer && MangoManager.IsOutgoing;
		public bool ShowTransferButton => !MangoManager.CurrentTalk.IsTransfer;

		#endregion

		#region Действия View
		public string GetPhoneNumber()
		{
			return "+7"+Phone.Number;
		}

		public string GetCallerName()
		{
			return MangoManager.CallerName;
		}
		#endregion
	}
}
