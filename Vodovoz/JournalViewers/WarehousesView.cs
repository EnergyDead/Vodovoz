﻿using System;
using Gtk;
using QS.Dialog.Gtk;
using QS.DomainModel.UoW;
using QSOrmProject;
using Vodovoz.Domain.Store;
using Vodovoz.Representations;

namespace Vodovoz.JournalViewers
{
	public partial class WarehousesView : QS.Dialog.Gtk.TdiTabBase
	{
		IUnitOfWork uow;
		private WarehousesVM _vm;
		public WarehousesView()
		{
			this.Build();
			this.TabName = "Журнал складов";
			ConfigureWidget();
		}

		void ConfigureWidget()
		{
			_vm = new WarehousesVM();
			tableWarehouses.ColumnsConfig = _vm.ColumnsConfig;
			_vm.UpdateNodes();
			tableWarehouses.YTreeModel = _vm.TreeModel;
			uow = _vm.UoW;
			tableWarehouses.Selection.Changed += OnSelectionChanged;
			tableWarehouses.ExpandAll();
			buttonEdit.Sensitive = buttonDelete.Sensitive = false;
		}

		void OnSelectionChanged(object sender, EventArgs e)
		{
			bool isSensitive = tableWarehouses.Selection.CountSelectedRows() > 0
				&& (tableWarehouses.GetSelectedObjects()[0] as SubdivisionWithWarehousesVMNode).WarehouseId.HasValue;

			buttonEdit.Sensitive = isSensitive;
			buttonDelete.Sensitive = isSensitive;
		}

		protected void OnBtnAddClicked(object sender, EventArgs e)
		{
			TabParent.OpenTab(
				DialogHelper.GenerateDialogHashName<Warehouse>(0),
				() => new WarehouseDlg(),
				this
			);
		}

		protected void OnTableWarehousesRowActivated(object o, RowActivatedArgs args)
		{
			buttonEdit.Click();
		}

		protected void OnButtonEditClicked(object sender, EventArgs e)
		{
			if(tableWarehouses.GetSelectedObjects().GetLength(0) > 0) {
				int? id = (tableWarehouses.GetSelectedObjects()[0] as SubdivisionWithWarehousesVMNode).WarehouseId;
				if(id.HasValue)
					TabParent.OpenTab(
							DialogHelper.GenerateDialogHashName<Warehouse>(id.Value),
							() => {
								var dlg = new WarehouseDlg(id.Value);
								dlg.EntitySaved += (s, ea) => ConfigureWidget();
								return dlg;
							},
							this
						);
			}
		}

		protected void OnButtonDeleteClicked(object sender, EventArgs e)
		{
			var item = tableWarehouses.GetSelectedObject<SubdivisionWithWarehousesVMNode>();
			if(item.WarehouseId.HasValue && OrmMain.DeleteObject<Warehouse>(item.WarehouseId.Value))
				tableWarehouses.RepresentationModel.UpdateNodes();
		}

		protected void OnButtonRefreshClicked(object sender, EventArgs e) => ConfigureWidget();

		protected override void OnDestroyed()
		{
			_vm?.Destroy();
			base.OnDestroyed();
		}
	}
}
