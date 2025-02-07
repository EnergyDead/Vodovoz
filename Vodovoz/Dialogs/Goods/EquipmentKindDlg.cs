﻿using System;
using Gamma.Utilities;
using QS.Dialog.Gtk;
using QS.DomainModel.UoW;
using Vodovoz.Domain;

namespace Vodovoz
{
	public partial class EquipmentKindDlg : QS.Dialog.Gtk.EntityDialogBase<EquipmentKind>{
		protected static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public EquipmentKindDlg ()
		{			
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<EquipmentKind> ();
			ConfigureDialog ();
		}

		public EquipmentKindDlg (int id)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<EquipmentKind> (id);
			ConfigureDialog ();
		}

		public EquipmentKindDlg (EquipmentKind sub): this(sub.Id) {}


		protected void ConfigureDialog(){
			yentryName.Binding
				.AddBinding (UoWGeneric.Root, equipmentKind => equipmentKind.Name, widget => widget.Text)
				.InitializeFromSource ();
			
			enumWarrantyType.ItemsEnum = typeof(WarrantyCardType);					
				
			enumWarrantyType.Binding
				.AddBinding (UoWGeneric.Root, equipmentKind => equipmentKind.WarrantyCardType, widget => widget.SelectedItem)
				.InitializeFromSource ();

			enumEquipmentType.ItemsEnum = typeof(EquipmentType);

			enumEquipmentType.Binding
				.AddBinding(UoWGeneric.Root, equipmentKind => equipmentKind.EquipmentType, widget => widget.SelectedItem)
				.InitializeFromSource();
		}

		#region implemented abstract members of OrmGtkDialogBase

		public override bool Save ()
		{
			var valid = new QS.Validation.QSValidator<EquipmentKind> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			logger.Info ("Сохраняем вид оборудования...");
			UoWGeneric.Save ();
			return true;
		}

		#endregion
	}
}


