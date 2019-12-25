﻿using QS.Project.Journal;
using Vodovoz.Domain.Logistic;

namespace Vodovoz.JournalNodes
{
	public class CarJournalNode : JournalEntityNodeBase<Car>
	{
		public override string Title => Model;

		public string Model { get; set; }
		public string RegistrationNumber { get; set; }
		public string DriverName { get; set; }
	}
}
