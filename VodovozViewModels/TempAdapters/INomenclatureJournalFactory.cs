﻿using QS.Project.Journal.EntitySelector;
using System.Collections.Generic;
using Vodovoz.Domain.Store;
using Vodovoz.ViewModels.Journals.FilterViewModels.Goods;
using Vodovoz.ViewModels.Journals.JournalViewModels.Goods;

namespace Vodovoz.TempAdapters
{
	public interface INomenclatureJournalFactory
	{
		IEntitySelector CreateNomenclatureSelectorForWarehouse(Warehouse warehouse, IEnumerable<int> excludedNomenclatures);
		IEntitySelector CreateNomenclatureSelector(IEnumerable<int> excludedNomenclatures = null, bool multipleSelect = true);
		IEntitySelector CreateNomenclatureOfGoodsWithoutEmptyBottlesSelector(IEnumerable<int> excludedNomenclatures = null);
		IEntitySelector CreateNomenclatureSelectorForFuelSelect();
		IEntityAutocompleteSelectorFactory GetWaterJournalFactory();
		IEntityAutocompleteSelectorFactory GetDefaultWaterSelectorFactory();
		IEntityAutocompleteSelectorFactory CreateNomenclatureForFlyerJournalFactory();
		IEntityAutocompleteSelectorFactory GetDefaultNomenclatureSelectorFactory(NomenclatureFilterViewModel filter = null);
		NomenclaturesJournalViewModel CreateNomenclaturesJournalViewModel(bool multiselect = false);
	}
}
