﻿using System;
using System.Linq;
using Gamma.GtkWidgets;
using QS.DomainModel.UoW;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories.Subdivisions;
using Vodovoz.Parameters;

namespace Vodovoz.ViewWidgets
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class GuiltyInUndeliveryView : QS.Dialog.Gtk.WidgetOnDialogBase
	{
		private readonly ISubdivisionRepository _subdivisionRepository = new SubdivisionRepository(new ParametersProvider());

		private IUnitOfWork _uow;
		private UndeliveredOrder _undeliveredOrder;

		public GuiltyInUndeliveryView()
		{
			this.Build();
		}

		public void ConfigureWidget(IUnitOfWork uow, UndeliveredOrder undeliveredOrder, bool driverCanBeGuilty)
		{
			_uow = uow;
			_undeliveredOrder = undeliveredOrder;
			enumBtnGuiltySide.ItemsEnum = typeof(GuiltyTypes);
			enumBtnGuiltySide.SetSensitive(GuiltyTypes.Driver, driverCanBeGuilty);
			enumBtnGuiltySide.SetSensitive(GuiltyTypes.None, !undeliveredOrder.ObservableGuilty.Any());
			undeliveredOrder.ObservableGuilty.ElementAdded += ObservableGuilty_ElementAdded;
			undeliveredOrder.ObservableGuilty.ElementRemoved += ObservableGuilty_ElementRemoved;
			enumBtnGuiltySide.EnumItemClicked += (sender, e) => {
				undeliveredOrder.AddGuilty(
					new GuiltyInUndelivery {
						GuiltySide = (GuiltyTypes)e.ItemEnum,
						UndeliveredOrder = undeliveredOrder
					}
				);
				SetWidgetApperance();
			};

			var colorBlack = new Gdk.Color(0, 0, 0);
			var colorGrey = new Gdk.Color(96, 96, 96);
			var colorWhite = new Gdk.Color(255, 255, 255);
			var hideEnums = !driverCanBeGuilty ? new Enum[] { GuiltyTypes.Driver } : new Enum[] { };
			var allDepartments = _subdivisionRepository.GetAllDepartmentsOrderedByName(_uow);
			treeViewGuilty.ColumnsConfig = ColumnsConfigFactory.Create<GuiltyInUndelivery>()
				.AddColumn("Сторона")
					.HeaderAlignment(0.5f)
					.AddEnumRenderer(n => n.GuiltySide, true, hideEnums)
				.AddColumn("Отдел ВВ")
					.HeaderAlignment(0.5f)
					.AddComboRenderer(n => n.GuiltyDepartment)
					.SetDisplayFunc(x => x.Name)
					.FillItems(allDepartments)
					.AddSetter(
						(c, n) => {
							c.Editable = n.GuiltySide == GuiltyTypes.Department;
							if(n.GuiltySide != GuiltyTypes.Department)
								n.GuiltyDepartment = null;
							if(n.GuiltySide == GuiltyTypes.Department && n.GuiltyDepartment == null) {
								c.ForegroundGdk = colorGrey;
								c.Style = Pango.Style.Italic;
								c.Text = "(Нажмите для выбора отдела)";
								c.BackgroundGdk = colorWhite;
							} else {
								c.ForegroundGdk = colorBlack;
								c.Style = Pango.Style.Normal;
								c.Background = null;
							}
						}
					)
				.Finish();
			treeViewGuilty.HeadersVisible = false;
			treeViewGuilty.ItemsDataSource = undeliveredOrder.ObservableGuilty;
			SetWidgetApperance();
		}

		void ObservableGuilty_ElementAdded(object aList, int[] aIdx)
		{
			enumBtnGuiltySide.SetSensitive(GuiltyTypes.None, !_undeliveredOrder.ObservableGuilty.Any());
		}

		void ObservableGuilty_ElementRemoved(object aList, int[] aIdx, object aObject)
		{
			enumBtnGuiltySide.SetSensitive(GuiltyTypes.None, !_undeliveredOrder.ObservableGuilty.Any());
		}

		protected void OnBtnRemoveClicked(object sender, EventArgs e)
		{
			var guilty = treeViewGuilty.GetSelectedObject<GuiltyInUndelivery>();
			_undeliveredOrder.ObservableGuilty.Remove(guilty);
			SetWidgetApperance();
		}

		void SetWidgetApperance()
		{
			if(_undeliveredOrder.ObservableGuilty.Count > 3) {
				GtkScrolledWindow.VscrollbarPolicy = Gtk.PolicyType.Always;
				this.HeightRequest = 120;
			} else {
				GtkScrolledWindow.VscrollbarPolicy = Gtk.PolicyType.Never;
				this.HeightRequest = 0;
			}
		}
	}
}
