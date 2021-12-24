﻿using System;
using System.Linq;
using Cairo;
using Gamma.GtkWidgets;
using NHibernate.Hql.Ast;
using QS.Dialog.GtkUI;
using QS.Services;
using SmsPaymentService;
using Vodovoz.Additions;
using Vodovoz.Domain.Client;
using Vodovoz.Domain.Contacts;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.Services;
using Vodovoz.SidePanel.InfoProviders;

namespace Vodovoz.SidePanel.InfoViews
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class SmsSendPanelView : Gtk.Bin, IPanelView
	{
		private readonly bool _canSendSmsForAdditionalOrderStatuses;
		
		public SmsSendPanelView(ICurrentPermissionService currentPermissionService)
		{
			if(currentPermissionService == null)
			{
				throw new ArgumentNullException(nameof(currentPermissionService));
			}
			_canSendSmsForAdditionalOrderStatuses = currentPermissionService.ValidatePresetPermission("can_send_sms_for_additional_order_statuses");

			this.Build();
			validatedPhoneEntry.WidthRequest = 135;
			validatedPhoneEntry.ValidationMode = QSWidgetLib.ValidationType.phone;
			yPhonesListTreeView.ColumnsConfig = ColumnsConfigFactory.Create<Phone>()
				.AddColumn("Телефоны")
				.AddTextRenderer(x => x.Number)
				.Finish();

			yPhonesListTreeView.Selection.Changed += (sender, args) =>
			{
				selectedPhone = yPhonesListTreeView.GetSelectedObject() as Phone;
				validatedPhoneEntry.Text = selectedPhone?.Number ?? "";
			};

			ySendSmsButton.Pressed += (btn, args) =>
			{
				if (string.IsNullOrWhiteSpace(validatedPhoneEntry.Text))
				{
					MessageDialogHelper.RunErrorDialog("Вы забыли выбрать номер.", "Ошибка при отправке Sms");
					return;
				}

				ySendSmsButton.Sensitive = false;
				GLib.Timeout.Add(10000, () =>
				{
					ySendSmsButton.Sensitive = true;
					return false;
				});

				var smsSender = new SmsPaymentSender();
				var result = smsSender.SendSmsPaymentToNumber(Order.Id, validatedPhoneEntry.Text);
				switch (result.Status)
				{
					case PaymentResult.MessageStatus.Ok:
						MessageDialogHelper.RunInfoDialog("Sms отправлена успешно");
						break;
					case PaymentResult.MessageStatus.Error:
						MessageDialogHelper.RunErrorDialog(result.ErrorDescription, "Ошибка при отправке Sms");
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

			};
		}

		private Phone selectedPhone;

		Counterparty Counterparty { get; set; }
		Order Order { get; set; }


		public IInfoProvider InfoProvider { get; set; }

		public void Refresh()
		{
			if (InfoProvider is ISmsSendProvider smsSendProvider)
			{
				Counterparty = smsSendProvider.Counterparty;
				Order = smsSendProvider.Order;
			}

			if (Counterparty == null || Order == null)
				return;

			ySendSmsButton.Sensitive = true;
			yPhonesListTreeView.ItemsDataSource = Counterparty.Phones;


		}

		public void OnCurrentObjectChanged(object changedObject) => Refresh();

		public bool VisibleOnPanel
		{
			get
			{
				var isStatusAllowedByDefaultForSendingSms =
					new OrderStatus[]
					{
						OrderStatus.Accepted,
						OrderStatus.OnTheWay,
						OrderStatus.Shipped,
						OrderStatus.InTravelList,
						OrderStatus.OnLoading
					}.Contains(Order.OrderStatus);

				var isAdditionalOrderStatus =
					new OrderStatus[]
					{
						OrderStatus.Closed,
						OrderStatus.UnloadingOnStock,
					}.Contains(Order.OrderStatus);

				return isStatusAllowedByDefaultForSendingSms
					   || (isAdditionalOrderStatus && _canSendSmsForAdditionalOrderStatuses);
			}
		}
	}
}
