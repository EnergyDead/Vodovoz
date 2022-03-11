﻿using QS.Views.GtkUI;
using Vodovoz.ViewModels.Dialogs.Counterparty;
using Vodovoz.Views.Organization;

namespace Vodovoz.Views.Client
{
	public partial class RoboAtsCounterpartyNameView : TabViewBase<RoboAtsCounterpartyNameViewModel>
	{
		private RoboatsEntityView _roboatsEntityView;

		public RoboAtsCounterpartyNameView(RoboAtsCounterpartyNameViewModel viewModel) : base(viewModel)
		{
			this.Build();
			Configure();
		}

		private void Configure()
		{
			labelIdValue.Binding.AddFuncBinding(ViewModel.Entity, e => e.Id.ToString(), w => w.LabelProp).InitializeFromSource();
			yentryName.Binding.AddBinding(ViewModel.Entity, e => e.Name, w => w.Text).InitializeFromSource();
			yentryAccent.Binding.AddBinding(ViewModel.Entity, e => e.Accent, w => w.Text).InitializeFromSource();

			buttonSave.Clicked += (sender, args) => ViewModel.Save(true);
			buttonCancel.Clicked += (sender, args) => ViewModel.Cancel();

			ViewModel.PropertyChanged += ViewModel_PropertyChanged;
			UpdateRoboatsEntityView();
		}
		private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch(e.PropertyName)
			{
				case nameof(ViewModel.RoboatsEntityViewModel):
					UpdateRoboatsEntityView();
					break;
				default:
					break;
			}
		}

		private void UpdateRoboatsEntityView()
		{
			_roboatsEntityView?.Destroy();
			if(ViewModel.RoboatsEntityViewModel != null)
			{
				_roboatsEntityView = new RoboatsEntityView(ViewModel.RoboatsEntityViewModel);
				boxRoboatsHolder.Add(_roboatsEntityView);
				_roboatsEntityView.Show();
			}
		}
	}
}
