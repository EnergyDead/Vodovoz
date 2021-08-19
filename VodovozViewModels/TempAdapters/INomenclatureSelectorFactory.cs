﻿using QS.Project.Journal.EntitySelector;
using System.Collections.Generic;
using Vodovoz.Domain.Store;

namespace Vodovoz.TempAdapters
{
	public interface INomenclatureSelectorFactory
	{
		IEntitySelector CreateNomenclatureSelectorForWarehouse(Warehouse warehouse, IEnumerable<int> excludedNomenclatures);
		IEntitySelector CreateNomenclatureSelector(IEnumerable<int> excludedNomenclatures = null);
		IEntitySelector CreateNomenclatureSelectorForFuelSelect();
		IEntityAutocompleteSelectorFactory GetWaterJournalFactory();
		IEntityAutocompleteSelectorFactory GetDefaultWaterSelectorFactory();
		IEntityAutocompleteSelectorFactory CreateNomenclatureForFlyerJournalFactory();
	}
}
