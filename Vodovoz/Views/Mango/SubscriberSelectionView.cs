﻿using System;
using System.Linq;
using Gamma.GtkWidgets;
using MangoService;
using QS.Views.Dialog;
using Vodovoz.ViewModels.Mango;

namespace Vodovoz.Views.Mango
{
	public partial class SubscriberSelectionView : DialogViewBase<SubscriberSelectionViewModel>
	{
		private string Number;
		private Gdk.Pixbuf userIcon = Gdk.Pixbuf.LoadFromResource("Vodovoz.icons.buttons.user22.png");
		private Gdk.Pixbuf groupIcon = Gdk.Pixbuf.LoadFromResource("Vodovoz.icons.menu.users.png");

		public SubscriberSelectionView(SubscriberSelectionViewModel model) : base(model)
		{
			this.Build();
			Configure();
		}

		void Configure()
		{
			if(ViewModel.dialogType == SubscriberSelectionViewModel.DialogType.Transfer) {
				ForwardingToConsultationButton.Visible = true;
				ForwardingToConsultationButton.Clicked += Clicked_ForwardingToConsultationButton;
				ForwardingButton.Clicked += Clicked_ForwardingButton;
			} else if(ViewModel.dialogType == SubscriberSelectionViewModel.DialogType.Telephone) {
				ForwardingToConsultationButton.Visible = false;
				ForwardingButton.Label = "Позвонить";
				ForwardingButton.Clicked += Clicked_MakeCall;
			}

			ySearchTable.ColumnsConfig = ColumnsConfigFactory.Create<SearchTableEntity>()
				.AddColumn("Имя")
				.AddPixbufRenderer(x => x.IsGroup ? groupIcon : userIcon)
				.AddTextRenderer(entity => entity.Name).SearchHighlight()
				.AddColumn("Статус")
				.AddTextRenderer(entity => entity.IsReady ? "<span foreground=\"green\">☎ Свободен</span>" : "<span foreground=\"red\">☎ Занят</span>", useMarkup: true)
				.AddColumn("Номер")
				.AddTextRenderer(entity => entity.Extension).SearchHighlight()
				.AddColumn("Отдел")
				.AddTextRenderer(entity => entity.Department).SearchHighlight()
				.Finish();
			ySearchTable.SetItemsSource<SearchTableEntity>(ViewModel.SearchTableEntities);
			ySearchTable.RowActivated += SelectCursorRow_OrderYTreeView;
			ySearchTable.Selection.Changed += Selection_Changed;
		}

		void Selection_Changed(object sender, EventArgs e)
		{
			CheckSensetive();
		}

		void CheckSensetive()
		{
			Number = String.Copy(FilterEntry.Text);
			var row = ySearchTable.GetSelectedObject<SearchTableEntity>();
			ForwardingButton.Sensitive = ForwardingToConsultationButton.Sensitive = row?.IsReady == true 
				|| IsNumber(ref Number);
		}

		bool IsNumber(ref string s)
		{
			if(String.IsNullOrWhiteSpace(s))
				return false;

			s = s.Replace("+7", "").Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

			if(s.Length > 11)
				return false;
			else if(s.Length == 11 && s.First() == '8') {
				s = s.Remove(0, 1);
				s = "7" + s;
			} else if(s.Length == 10)
				s = "7" + s;
			else if(s.Length < 10 && s.Length > 3)
				return false;
			else if(s.Length < 3)
				return false;
				
			for(int i = 0; i < s.Length; i++) {
				if(s[i] < '0' || s[i] > '9')
					return false;
			}

			return true;
		}

		private void SelectCursorRow_OrderYTreeView(object sender, EventArgs e)
		{
			ForwardingToConsultationButton.Click();
		}

		protected void Clicked_MakeCall(object sender, EventArgs e)
		{
			var row = ySearchTable.GetSelectedObject<SearchTableEntity>();	
			if(row != null)
				ViewModel.MakeCall(row);
			else 
				ViewModel.MakeCall(Number);
		}
		protected void Clicked_ForwardingButton(object sender, EventArgs e)
		{
			var row = ySearchTable.GetSelectedObject<SearchTableEntity>();
			if(row != null) //Перевод реализован только на внутрение
				ViewModel.ForwardCall(row, ForwardingMethod.blind);
		}

		protected void Clicked_ForwardingToConsultationButton(object sender, EventArgs e)
		{
			var row = ySearchTable.GetSelectedObject<SearchTableEntity>();
			if(row != null) //Перевод реализован только на внутрение
				ViewModel.ForwardCall(row, ForwardingMethod.hold);
		}

		protected void Changed_FilterEntry(object sender, EventArgs args)
		{
			ySearchTable.SearchHighlightText = FilterEntry.Text;
			if(String.IsNullOrWhiteSpace(FilterEntry.Text)) {
				ySearchTable.SetItemsSource(ViewModel.SearchTableEntities);
			} else {
				string input = FilterEntry.Text.ToLower();
				ySearchTable.SetItemsSource(ViewModel.SearchTableEntities
					.Where(x => (x.Extension?.Contains(input) ?? false)
					 	|| (x.Name?.ToLower().Contains(input) ?? false)
						|| (x.Department?.ToLower().Contains(input) ?? false)
				).ToList());
			}
			CheckSensetive();
 		}

		protected void OnFilterEntryActivated(object sender, EventArgs e)
		{
			ySearchTable.Selection.SelectPath(new Gtk.TreePath("0"));
			if(ViewModel.dialogType == SubscriberSelectionViewModel.DialogType.Transfer)
				ForwardingToConsultationButton.Click();
			else
				ForwardingButton.Click();
		}
	}
}
