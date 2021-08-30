﻿using Gtk;
using QS.Project.Journal.Actions.Views;
using QS.Views;
using Vodovoz.Journals.JournalActionsViewModels;

namespace Vodovoz.ViewWidgets.JournalActions
{
	public partial class UndeliveredOrdersJournalActionsView : ViewBase<UndeliveredOrdersJournalActionsViewModel>
	{
		public UndeliveredOrdersJournalActionsView(
			UndeliveredOrdersJournalActionsViewModel viewModel) : base(viewModel)
		{
			Build();
			Configure();
		}

		private void Configure()
		{
			CreateDefaultButtons();

			btnPrint.Clicked += (sender, e) => ViewModel.PrintCommand.Execute();
		}

		private void CreateDefaultButtons()
		{
			Widget entitiesJournalActions = new EntitiesJournalActionsView(ViewModel);
			hboxDefaultBtns.Add(entitiesJournalActions);
			entitiesJournalActions.Show();
		}
	}
}
