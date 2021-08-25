﻿using System;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QSOrmProject;
using QS.Validation;
using Vodovoz.Additions.Store;
using Vodovoz.Infrastructure.Permissions;
using Vodovoz.Domain.Documents;
using Vodovoz.Domain.Store;
using Vodovoz.PermissionExtensions;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories;
using QS.DomainModel.Entity.EntityPermissions.EntityExtendedPermission;
using QS.Project.Journal.EntitySelector;
using QS.Project.Services;
using Vodovoz.FilterViewModels.Goods;
using Vodovoz.TempAdapters;

namespace Vodovoz
{
	public partial class IncomingWaterDlg : QS.Dialog.Gtk.EntityDialogBase<IncomingWater>
	{
		static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
		private readonly IEmployeeRepository _employeeRepository = new EmployeeRepository();
		private readonly IUserRepository _userRepository = new UserRepository();
		private readonly IEntityAutocompleteSelectorFactory _warehouseAutocompleteSelectorFactory =
			new WarehouseSelectorFactory();

		public IncomingWaterDlg()
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<IncomingWater>();
			Entity.Author = _employeeRepository.GetEmployeeForCurrentUser(UoW);
			if(Entity.Author == null) {
				MessageDialogHelper.RunErrorDialog("Ваш пользователь не привязан к действующему сотруднику, вы не можете создавать складские документы, так как некого указывать в качестве кладовщика.");
				FailInitialize = true;
				return;
			}

			Entity.IncomingWarehouse = StoreDocumentHelper.GetDefaultWarehouse(UoW, WarehousePermissions.IncomingWaterEdit);
			Entity.WriteOffWarehouse = StoreDocumentHelper.GetDefaultWarehouse(UoW, WarehousePermissions.IncomingWaterEdit);

			ConfigureDlg();
		}

		public IncomingWaterDlg(int id)
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<IncomingWater>(id);
			ConfigureDlg();
		}

		public IncomingWaterDlg(IncomingWater sub) : this(sub.Id)
		{
		}

		void ConfigureDlg()
		{
			if(StoreDocumentHelper.CheckAllPermissions(UoW.IsNew, WarehousePermissions.IncomingWaterEdit, Entity.IncomingWarehouse, Entity.WriteOffWarehouse)) {
				FailInitialize = true;
				return;
			}

			var editing = StoreDocumentHelper.CanEditDocument(WarehousePermissions.IncomingWaterEdit, Entity.IncomingWarehouse, Entity.WriteOffWarehouse);
			buttonFill.Sensitive = yentryProduct.IsEditable = spinAmount.Sensitive = editing;
			incomingwatermaterialview1.Sensitive = editing;

			labelTimeStamp.Binding.AddBinding(Entity, e => e.DateString, w => w.LabelProp).InitializeFromSource();
			spinAmount.Binding.AddBinding(Entity, e => e.Amount, w => w.ValueAsInt).InitializeFromSource();

			var userHasOnlyAccessToWarehouseAndComplaints =
				ServicesConfig.CommonServices.CurrentPermissionService.ValidatePresetPermission("user_have_access_only_to_warehouse_and_complaints")
				&& !ServicesConfig.CommonServices.UserService.GetCurrentUser(UoW).IsAdmin;

			if(userHasOnlyAccessToWarehouseAndComplaints)
			{
				sourceWarehouseEntry.CanEditReference = destinationWarehouseEntry.CanEditReference = false;
			}
			else
			{
				sourceWarehouseEntry.CanEditReference = destinationWarehouseEntry.CanEditReference = true;
			}

			sourceWarehouseEntry.SetEntityAutocompleteSelectorFactory(_warehouseAutocompleteSelectorFactory);
			sourceWarehouseEntry.Binding.AddBinding(Entity, e => e.WriteOffWarehouse, w => w.Subject).InitializeFromSource();
			destinationWarehouseEntry.SetEntityAutocompleteSelectorFactory(_warehouseAutocompleteSelectorFactory);
			destinationWarehouseEntry.Binding.AddBinding(Entity, e => e.IncomingWarehouse, w => w.Subject).InitializeFromSource();

			incomingwatermaterialview1.DocumentUoW = UoWGeneric;

			var permmissionValidator =
				new EntityExtendedPermissionValidator(PermissionExtensionSingletonStore.GetInstance(), _employeeRepository);
			
			Entity.CanEdit =
				permmissionValidator.Validate(
					typeof(IncomingWater), _userRepository.GetCurrentUser(UoW).Id, nameof(RetroactivelyClosePermission));
			
			if(!Entity.CanEdit && Entity.TimeStamp.Date != DateTime.Now.Date) {
				spinAmount.Binding.AddFuncBinding(Entity, e => e.CanEdit, w => w.Sensitive).InitializeFromSource();
				yentryProduct.Sensitive = false;
				destinationWarehouseEntry.Sensitive = false;
				sourceWarehouseEntry.Sensitive = false;
				buttonFill.Sensitive = false;
				incomingwatermaterialview1.Sensitive = false;
				buttonSave.Sensitive = false;
			} else {
				Entity.CanEdit = true;
			}

			var nomenclatureFilter = new NomenclatureFilterViewModel() { HidenByDefault = true };
			
			var nomenclatureAutoCompleteSelectorFactory =
				new NomenclatureSelectorFactory().CreateNomenclatureAutocompleteSelectorFactory(nomenclatureFilter);
			
			yentryProduct.SetEntityAutocompleteSelectorFactory(nomenclatureAutoCompleteSelectorFactory);
			yentryProduct.Binding.AddBinding(Entity, e => e.Product, w => w.Subject).InitializeFromSource();
		}

		public override bool Save ()
		{
			if(!Entity.CanEdit)
				return false;

			if(CheckWarehouseItems() == false){
				MessageDialogHelper.RunErrorDialog("На складе не хватает материалов");
				return false;
			}
				
			var valid = new QSValidator<IncomingWater> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			Entity.LastEditor = _employeeRepository.GetEmployeeForCurrentUser (UoW);
			Entity.LastEditedTime = DateTime.Now;
			if(Entity.LastEditor == null)
			{
				MessageDialogHelper.RunErrorDialog ("Ваш пользователь не привязан к действующему сотруднику, вы не можете изменять складские документы, так как некого указывать в качестве кладовщика.");
				return false;
			}

			logger.Info ("Сохраняем документ производства...");
			UoWGeneric.Save ();
			logger.Info ("Ok.");
			return true;
		}

		private bool CheckWarehouseItems()
		{
			foreach(var mater in Entity.Materials){
				if(mater.Amount > mater.AmountOnSource)
					return false;
			} 
			return true;
		}

		protected void OnButtonFillClicked (object sender, EventArgs e)
		{
			OrmReference SelectDialog = new OrmReference (typeof(ProductSpecification), UoWGeneric);
			SelectDialog.Mode = OrmReferenceMode.Select;
			SelectDialog.ObjectSelected += SelectDialog_ObjectSelected;

			TabParent.AddSlaveTab (this, SelectDialog);
		}

		void SelectDialog_ObjectSelected (object sender, OrmReferenceObjectSectedEventArgs e)
		{
			var spec = e.Subject as ProductSpecification;
			UoWGeneric.Root.Product = spec.Product;
			UoWGeneric.Root.ObservableMaterials.Clear ();
			foreach (var material in spec.Materials) {
				UoWGeneric.Root.AddMaterial (material);
			}
		}
	}
}

