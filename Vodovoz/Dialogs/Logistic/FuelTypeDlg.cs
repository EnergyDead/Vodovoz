﻿using QS.DomainModel.UoW;
using QS.Validation;
using Vodovoz.Domain.Logistic;

namespace Vodovoz
{
	public partial class FuelTypeDlg : QS.Dialog.Gtk.EntityDialogBase<FuelType>
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public FuelTypeDlg ()
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<FuelType>();
			ConfigureDlg ();
		}

		public FuelTypeDlg (int id)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<FuelType> (id);
			ConfigureDlg ();
		}

		public FuelTypeDlg (FuelType sub) : this (sub.Id) {}

		private void ConfigureDlg ()
		{
			var canEdit = permissionResult.CanUpdate
			              || (permissionResult.CanCreate && Entity.Id == 0);
			yentryName.Sensitive = yspinbuttonCost.Sensitive = buttonSave.Sensitive = canEdit;

			yentryName.Binding.AddBinding(Entity, e => e.Name, w => w.Text).InitializeFromSource();
			yspinbuttonCost.Binding.AddBinding(Entity, e => e.Cost, w => w.ValueAsDecimal).InitializeFromSource();
		}

		public override bool Save ()
		{
			var valid = new QSValidator<FuelType> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			logger.Info ("Сохраняем график доставки...");
			UoWGeneric.Save();
			return true;
		}
	}
}

