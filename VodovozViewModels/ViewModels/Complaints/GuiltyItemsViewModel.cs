﻿using System;
using Autofac;
using QS.Commands;
using QS.DomainModel.UoW;
using QS.Project.Services;
using QS.Services;
using QS.ViewModels;
using QS.ViewModels.Dialog;
using Vodovoz.Domain.Complaints;

namespace Vodovoz.ViewModels.Complaints
{
	public class GuiltyItemsViewModel : EntityWidgetViewModelBase<Complaint>
	{
		private readonly ILifetimeScope _scope;
		private readonly DialogViewModelBase _parrentViewModel;

		public GuiltyItemsViewModel(
			Complaint entity,
			IUnitOfWork uow,
			ICommonServices commonServices,
			ILifetimeScope scope,
			DialogViewModelBase parrentViewModel) : base(entity, commonServices)
		{
			_scope = scope ?? throw new ArgumentNullException(nameof(scope));
			_parrentViewModel = parrentViewModel ?? throw new ArgumentNullException(nameof(parrentViewModel));
			UoW = uow ?? throw new ArgumentNullException(nameof(uow));
			
			CreateCommands();
		}

		GuiltyItemViewModel currentGuiltyVM;
		public virtual GuiltyItemViewModel CurrentGuiltyVM
		{
			get => currentGuiltyVM;
			set
			{
				SetField(ref currentGuiltyVM, value, () => CurrentGuiltyVM);
				OnPropertyChanged(nameof(CanAddGuilty));
			}
		}

		private bool canRemoveGuilty;
		public virtual bool CanRemoveGuilty {
			get => canRemoveGuilty;
			set => SetField(ref canRemoveGuilty, value, () => CanRemoveGuilty);
		}


		bool canEditGuilty;
		public bool CanEditGuilty {
			get => canEditGuilty;
			set => SetField(ref canEditGuilty, value, () => CanEditGuilty);
		}

        public bool CanAddGuilty => ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("can_add_guilty_in_complaints")
			&& CurrentGuiltyVM == null;

		void UpdateAcessibility()
		{
			CanEditGuilty = !CanAddGuilty;
		}

		void CreateItem()
		{
			CurrentGuiltyVM = _scope.Resolve<GuiltyItemViewModel>(
				new TypedParameter(typeof(DialogViewModelBase), _parrentViewModel),
				new TypedParameter(typeof(IUnitOfWork), UoW));
			UpdateAcessibility();
		}

		void ClearItem()
		{
			CurrentGuiltyVM = null;
			UpdateAcessibility();
		}

		#region Commands

		void CreateCommands()
		{
			CreateAddGuiltyCommand();
			CreateRemoveGuiltyCommand();
			CreateSaveGuiltyCommand();
			CreateCancelCommand();
		}

		#region AddGuiltyCommand

		public DelegateCommand AddGuiltyCommand { get; private set; }
		private void CreateAddGuiltyCommand()
		{
			AddGuiltyCommand = new DelegateCommand(
				CreateItem,
				() => CanAddGuilty
			);
		}

		#endregion AddGuiltyCommand

		#region SaveGuiltyCommand

		public DelegateCommand SaveGuiltyCommand { get; private set; }

		private void CreateSaveGuiltyCommand()
		{
			SaveGuiltyCommand = new DelegateCommand(
				() => {
					if(CurrentGuiltyVM.Entity.GuiltyType != ComplaintGuiltyTypes.Employee)
						CurrentGuiltyVM.Entity.Employee = null;
					if(CurrentGuiltyVM.Entity.GuiltyType != ComplaintGuiltyTypes.Subdivision)
						CurrentGuiltyVM.Entity.Subdivision = null;
					CurrentGuiltyVM.Entity.Complaint = Entity;
					Entity.ObservableGuilties.Add(CurrentGuiltyVM.Entity);
					ClearItem();
				},
				() => CanEditGuilty
			);
		}

		#endregion SaveGuiltyCommand

		#region CancelCommand

		public DelegateCommand CancelCommand { get; private set; }

		private void CreateCancelCommand()
		{
			CancelCommand = new DelegateCommand(
				ClearItem,
				() => CanEditGuilty
			);
		}

		#endregion CancelCommand

		#region RemoveGuiltyCommand

		public DelegateCommand<ComplaintGuiltyItem> RemoveGuiltyCommand { get; private set; }
		private void CreateRemoveGuiltyCommand()
		{
			RemoveGuiltyCommand = new DelegateCommand<ComplaintGuiltyItem>(
				g => Entity.ObservableGuilties.Remove(g),
				g => CanRemoveGuilty
			);
			RemoveGuiltyCommand.CanExecuteChangedWith(this, x => x.CanRemoveGuilty);
		}

		#endregion RemoveGuiltyCommand

		#endregion Commands
	}
}
