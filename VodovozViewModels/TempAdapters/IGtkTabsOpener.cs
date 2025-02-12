﻿using QS.Tdi;
using Vodovoz.Domain.Cash;
using Vodovoz.ViewModels.Journals.FilterViewModels.Orders;

namespace Vodovoz.TempAdapters
{
	public interface IGtkTabsOpener
	{
		void OpenOrderDlg(ITdiTab tab, int id);
		void OpenRouteListCreateDlg(ITdiTab tab, int id);
		ITdiTab OpenRouteListClosingDlg(ITdiTab master, int routelistId);
		ITdiTab OpenUndeliveredOrderDlg(ITdiTab tab, int id = 0);
		ITdiTab OpenUndeliveriesWithCommentsPrintDlg(ITdiTab tab, UndeliveredOrdersFilterViewModel filter);
		ITdiTab OpenCounterpartyDlg(ITdiTab master, int counterpartyId);
		void OpenCashExpenseDlg(ITdiTab master, int employeeId, decimal balance, bool canChangeEmployee, ExpenseType expenseType);
		void OpenRouteListChangeGiveoutExpenceDlg(ITdiTab master, int employeeId, decimal balance, string description);
	}
}
