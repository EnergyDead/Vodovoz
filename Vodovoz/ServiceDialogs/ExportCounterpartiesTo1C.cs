﻿using System.Collections.Generic;
using QS.DomainModel.UoW;
using QSOrmProject;
using QSProjectsLib;
using Vodovoz.ServiceDialogs.ExportTo1c;
using System;
using Vodovoz.EntityRepositories.Counterparties;

namespace Vodovoz.ServiceDialogs
{
	public class ExportCounterpartiesTo1C : IDisposable
	{
		private readonly IUnitOfWork uow;
		private readonly ICounterpartyRepository counterpartyRepository;
		private IList<CounterpartyTo1CNode> counterparties;

		public int Steps => counterparties.Count;
		public ExportCounterpariesData Result { get; private set; }

		public ExportCounterpartiesTo1C(ICounterpartyRepository counterpartyRepository)
		{
			this.uow = UnitOfWorkFactory.CreateWithoutRoot();
			this.counterpartyRepository = counterpartyRepository ?? throw new ArgumentNullException(nameof(counterpartyRepository));
		}

		public void Run(IWorker worker)
		{
			worker.OperationName = "Подготовка данных";
			worker.ReportProgress(0, "Получение контрагентов");
			counterparties = counterpartyRepository.GetCounterpartiesWithInnAndAnyContact(uow);
			worker.OperationName = "Выгрузка имён и контактных данных";
			worker.StepsCount = Steps;
			Result = new ExportCounterpariesData(uow);
			int i = 0;
			while(!worker.IsCancelled && i < Steps) {
				worker.ReportProgress(i, "Контрагент");
				Result.AddCounterparty(counterparties[i]);
				i++;
			}
		}

		public void Dispose()
		{
			uow?.Dispose();
		}
	}
}
