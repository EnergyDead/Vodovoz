﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vodovoz.Domain.Logistic
{
	public class AtWorkDriver : AtWorkBase
	{
		private Car car;

		[Display(Name = "Автомобиль")]
		public virtual Car Car
		{
			get { return car; }
			set { SetField(ref car, value, () => Car); }
		}

		private short priorityAtDay;

		[Display(Name = "Приоритет для текущего дня")]
		public virtual short PriorityAtDay
		{
			get { return priorityAtDay; }
			set { SetField(ref priorityAtDay, value, () => PriorityAtDay); }
		}

		private TimeSpan? endOfDay;

		[Display(Name = "Конец рабочего дня")]
		public virtual TimeSpan? EndOfDay
		{
			get { return endOfDay; }
			set { SetField(ref endOfDay, value, () => EndOfDay); }
		}

		public virtual string EndOfDayText{
			get { return EndOfDay?.ToString("hh\\:mm"); }
			set{
				if (String.IsNullOrWhiteSpace(value))
				{
					EndOfDay = null;
					return;
				}
				TimeSpan temp;
				if(TimeSpan.TryParse(value, out temp))
					EndOfDay = temp;
			}
		}

		public AtWorkDriver()
		{
		}
	}
}
