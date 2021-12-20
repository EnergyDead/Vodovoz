﻿using QS.Project.Journal.EntitySelector;

namespace Vodovoz.ViewModels.Journals.JournalFactories
{
	public interface IRoboAtsCounterpartyJournalFactory
	{
		IEntityAutocompleteSelectorFactory CreateRoboAtsCounterpartyNameAutocompleteSelectorFactory();
		IEntityAutocompleteSelectorFactory CreateRoboAtsCounterpartyPatronymicAutocompleteSelectorFactory();
	}
}
