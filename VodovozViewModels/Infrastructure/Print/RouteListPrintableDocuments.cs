﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vodovoz.ViewModels.Infrastructure.Print
{
	[Flags]
	public enum RouteListPrintableDocuments
	{
		[Display(Name = "Все")]
		All,
		[Display(Name = "Маршрутный лист")]
		RouteList,
		[Display(Name = "Карта маршрута")]
		RouteMap,
		[Display(Name = "Адреса по ежедневным номерам")]
		DailyList,
		[Display(Name = "Лист времени")]
		TimeList,
		[Display(Name = "Документ погрузки")]
		LoadDocument,
		[Display(Name = "Погрузка Софийская")]
		LoadSofiyskaya,
		[Display(Name = "Отчёт по порядку адресов")]
		OrderOfAddresses
	}
}
