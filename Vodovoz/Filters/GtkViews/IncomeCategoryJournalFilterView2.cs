﻿using System;
using QS.Views.GtkUI;
using Vodovoz.Filters.ViewModels;
using Vodovoz.ViewModels.Journals.FilterViewModels;
using Vodovoz.ViewModels.Journals.FilterViewModels.Enums;
namespace Vodovoz.Filters.GtkViews
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class IncomeCategoryJournalFilterView2 : FilterViewBase<IncomeCategoryJournalFilterViewModel>
	{
		public IncomeCategoryJournalFilterView2(IncomeCategoryJournalFilterViewModel journalFilterViewModel) : base(journalFilterViewModel)
		{
			this.Build();
			this.Configure();
		}

		private void Configure()
		{
			ycheckArchived.Binding.AddBinding(ViewModel, e => e.ShowArchive, w => w.Active).InitializeFromSource();
			yLevelenumcombobox1.ItemsEnum = typeof(LevelsFilter);
			yLevelenumcombobox1.Binding.AddBinding(ViewModel, e => e.Level, w => w.SelectedItem).InitializeFromSource();
		}
	}
}
