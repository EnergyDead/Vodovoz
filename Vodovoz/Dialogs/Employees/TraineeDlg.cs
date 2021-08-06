﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gamma.ColumnConfig;
using Gamma.Utilities;
using NLog;
using QS.Banks.Domain;
using QS.Dialog.Gtk;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using QS.Project.DB;
using QS.Project.Services;
using QSOrmProject;
using QS.Validation;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Service.BaseParametersServices;
using Vodovoz.EntityRepositories;
using Vodovoz.EntityRepositories.Employees;
using Vodovoz.EntityRepositories.WageCalculation;
using Vodovoz.Factories;
using Vodovoz.Parameters;
using Vodovoz.Services;
using Vodovoz.TempAdapters;
using Vodovoz.ViewModels.Infrastructure.Services;
using Vodovoz.ViewModels.Journals.JournalFactories;
using Vodovoz.ViewModels.Journals.JournalSelectors;
using Vodovoz.ViewModels.TempAdapters;
using Vodovoz.ViewModels.ViewModels.Employees;

namespace Vodovoz.Dialogs.Employees
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class TraineeDlg : QS.Dialog.Gtk.EntityDialogBase<Trainee>
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();
		private readonly IAuthorizationService _authorizationService = new AuthorizationServiceFactory().CreateNewAuthorizationService();
		private readonly IEmployeeWageParametersFactory _employeeWageParametersFactory = new EmployeeWageParametersFactory();
		private readonly IEmployeeJournalFactory _employeeJournalFactory = new EmployeeJournalFactory();
		private readonly ISubdivisionJournalFactory _subdivisionJournalFactory = new SubdivisionJournalFactory();
		private readonly IEmployeePostsJournalFactory _employeePostsJournalFactory = new EmployeePostsJournalFactory();
		private readonly ICashDistributionCommonOrganisationProvider _cashDistributionCommonOrganisationProvider =
			new CashDistributionCommonOrganisationProvider(new OrganizationParametersProvider(new ParametersProvider()));
		private readonly ISubdivisionService _subdivisionService = SubdivisionParametersProvider.Instance;
		private readonly IEmailServiceSettingAdapter _emailServiceSettingAdapter = new EmailServiceSettingAdapter();
		private readonly IWageCalculationRepository _wageCalculationRepository  = WageSingletonRepository.GetInstance();
		private readonly IEmployeeRepository _employeeRepository = EmployeeSingletonRepository.GetInstance();
		private readonly IValidationContextFactory _validationContextFactory = new ValidationContextFactory();
		private readonly IPhonesViewModelFactory _phonesViewModelFactory = new PhonesViewModelFactory(new PhoneRepository());

		public TraineeDlg()
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<Trainee>();
			ConfigureDlg();
		}

		public TraineeDlg(int id)
		{
			this.Build();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<Trainee>(id);
			ConfigureDlg();
		}

		public TraineeDlg(Trainee sub) : this(sub.Id)
		{
		}

		public void ConfigureDlg()
		{
			OnRussianCitizenToggled(null, EventArgs.Empty);
			notebookMain.Page = 0;
			notebookMain.ShowTabs = false;

			ConfigureBindings();
		}

		public void ConfigureBindings()
		{
			logger.Info("Настройка биндинга компонентов диалога стажера");
			//Основные
			dataentryLastName.Binding.AddBinding(Entity, e => e.LastName, w => w.Text).InitializeFromSource();
			dataentryName.Binding.AddBinding(Entity, e => e.Name, w => w.Text).InitializeFromSource();
			dataentryPatronymic.Binding.AddBinding(Entity, e => e.Patronymic, w => w.Text).InitializeFromSource();
			entryAddressCurrent.Binding.AddBinding(Entity, e => e.AddressCurrent, w => w.Text).InitializeFromSource();
			entryAddressRegistration.Binding.AddBinding(Entity, e => e.AddressRegistration, w => w.Text).InitializeFromSource();
			entryInn.Binding.AddBinding(Entity, e => e.INN, w => w.Text).InitializeFromSource();
			dataentryDrivingNumber.MaxLength = 20;
			dataentryDrivingNumber.Binding.AddBinding(Entity, e => e.DrivingLicense, w => w.Text).InitializeFromSource();
			referenceNationality.SubjectType = typeof(Nationality);
			referenceNationality.Binding.AddBinding(Entity, e => e.Nationality, w => w.Subject).InitializeFromSource();
			referenceCitizenship.SubjectType = typeof(Citizenship);
			referenceCitizenship.Binding.AddBinding(Entity, e => e.Citizenship, w => w.Subject).InitializeFromSource();
			photoviewEmployee.Binding.AddBinding(Entity, e => e.Photo, w => w.ImageFile).InitializeFromSource();
			photoviewEmployee.GetSaveFileName = () => Entity.FullName;
			phonesView.UoW = UoWGeneric;
			checkbuttonRussianCitizen.Binding.AddBinding(Entity, e => e.IsRussianCitizen, w => w.Active).InitializeFromSource();
			if(Entity.Phones == null) {
				Entity.Phones = new List<Vodovoz.Domain.Contacts.Phone>();
			}
			phonesView.Phones = Entity.Phones;

			ytreeviewEmployeeDocument.ColumnsConfig = FluentColumnsConfig<EmployeeDocument>.Create()
				.AddColumn("Документ").AddTextRenderer(x => x.Document.GetEnumTitle())
				.AddColumn("Доп. название").AddTextRenderer(x => x.Name)
				.Finish();
			ytreeviewEmployeeDocument.SetItemsSource(Entity.ObservableDocuments);

			//Реквизиты
			accountsView.ParentReference = new ParentReferenceGeneric<Trainee, Account>(UoWGeneric, o => o.Accounts);
			accountsView.SetTitle("Банковские счета стажера");

			//Файлы
			attachmentFiles.AttachToTable = OrmConfig.GetDBTableName(typeof(Trainee));
			if(Entity.Id != 0) {
				attachmentFiles.ItemId = Entity.Id;
				attachmentFiles.UpdateFileList();
			}
			logger.Info("Ok");
		}

		public override bool HasChanges {
			get { return UoWGeneric.HasChanges || attachmentFiles.HasChanges; }
		}

		public override bool Save()
		{
			var valid = new QSValidator<Trainee>(Entity);
			if(valid.RunDlgIfNotValid((Gtk.Window)this.Toplevel)) {
				return false;
			}
			phonesView.RemoveEmpty();
			logger.Info("Сохраняем стажера...");
			try {
				UoWGeneric.Save();
				if(Entity.Id != 0) {
					attachmentFiles.ItemId = Entity.Id;
				}
				attachmentFiles.SaveChanges();
			} catch(Exception ex) {
				logger.Error(ex, "Не удалось записать стажера.");
				QSProjectsLib.QSMain.ErrorMessage((Gtk.Window)this.Toplevel, ex);
				return false;
			}
			logger.Info("Ok");
			return true;
		}

		protected void OnRadioTabInfoToggled(object sender, EventArgs e)
		{
			if(radioTabInfo.Active)
				notebookMain.CurrentPage = 0;
		}

		protected void OnRadioTabAccountingToggled(object sender, EventArgs e)
		{
			if(radioTabAccounting.Active)
				notebookMain.CurrentPage = 1;
		}

		protected void OnRadioTabFilesToggled(object sender, EventArgs e)
		{
			if(radioTabFiles.Active)
				notebookMain.CurrentPage = 2;
		}

		protected void OnRadioTabDocumentsToggled(object sender, EventArgs e)
		{
			if(radioTabDocuments.Active)
				notebookMain.CurrentPage = 3;
		}

		protected void OnButtonChangeToEmployeeClicked(object sender, EventArgs e)
		{
			if(UoW.HasChanges || Entity.Id == 0) {
				if(!MessageDialogHelper.RunQuestionDialog("Для продолжения необходимо сохранить изменения, сохранить и продолжить?")) {
					return;
				}
				if(Save()) {
					OnEntitySaved(true);
				} else {
					return;
				}
			}
			var employeeUow = UnitOfWorkFactory.CreateWithNewRoot<Employee>();
			Personnel.ChangeTraineeToEmployee(employeeUow, Entity);

			var employeeViewModel = new EmployeeViewModel(
				_authorizationService,
				_employeeWageParametersFactory,
				_employeeJournalFactory,
				_subdivisionJournalFactory,
				_employeePostsJournalFactory,
				_cashDistributionCommonOrganisationProvider,
				_subdivisionService,
				_emailServiceSettingAdapter,
				_wageCalculationRepository,
				_employeeRepository,
				employeeUow,
				ServicesConfig.CommonServices,
				_validationContextFactory,
				_phonesViewModelFactory,
				true);
			
			TabParent.OpenTab(DialogHelper.GenerateDialogHashName<Employee>(Entity.Id),
							  () => employeeViewModel);
			OnCloseTab(false);
		}

		protected void OnRussianCitizenToggled(object sender, EventArgs e)
		{
			if(Entity.IsRussianCitizen == false) {
				labelCitizenship.Visible = true;
				referenceCitizenship.Visible = true;
			} else {
				labelCitizenship.Visible = false;
				referenceCitizenship.Visible = false;
				Entity.Citizenship = null;
			}
		}

		#region Document

		protected void OnButtonAddDocumentClicked(object sender, EventArgs e)
		{
			EmployeeDocDlg dlg = new EmployeeDocDlg(UoW,null);
			dlg.Save += (object sender1, EventArgs e1)=>Entity.ObservableDocuments.Add(dlg.Entity);
			TabParent.AddSlaveTab(this, dlg);
		}

		protected void OnButtonRemoveDocumentClicked(object sender, EventArgs e)
		{
			var toRemoveDistricts = ytreeviewEmployeeDocument.GetSelectedObjects<EmployeeDocument>().ToList();
			toRemoveDistricts.ForEach(x => Entity.ObservableDocuments.Remove(x));
		}

		protected void OnButtonEditDocumentClicked(object sender, EventArgs e)
		{
			if(ytreeviewEmployeeDocument.GetSelectedObject<EmployeeDocument>() != null) 
			{
				EmployeeDocDlg dlg = new EmployeeDocDlg(((EmployeeDocument)ytreeviewEmployeeDocument.GetSelectedObjects()[0]).Id, UoW);
				TabParent.AddSlaveTab(this, dlg);
			}

		}

		protected void OnEmployeeDocumentRowActivated(object o, Gtk.RowActivatedArgs args)
		{
			buttonDocumentEdit.Click();
		}
		#endregion
	}
}
