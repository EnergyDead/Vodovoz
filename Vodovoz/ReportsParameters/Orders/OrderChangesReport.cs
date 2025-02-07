﻿using System;
using System.Linq;
using System.Collections.Generic;
using QS.Report;
using QSReport;
using Vodovoz.Domain.Organizations;
using Gamma.ColumnConfig;
using QS.DomainModel.Entity;
using QS.Dialog.GtkUI;
using QS.DomainModel.UoW;
using Vodovoz.Parameters;

namespace Vodovoz.ReportsParameters.Orders
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class OrderChangesReport : SingleUoWWidgetBase, IParametersWidget
    {
        private List<SelectedChangeTypeNode> changeTypes = new List<SelectedChangeTypeNode>();
        private List<SelectedIssueTypeNode> issueTypes = new List<SelectedIssueTypeNode>();
        private readonly IReportDefaultsProvider reportDefaultsProvider;

        public OrderChangesReport(IReportDefaultsProvider reportDefaultsProvider)
        {
            this.reportDefaultsProvider = reportDefaultsProvider ?? throw new ArgumentNullException(nameof(reportDefaultsProvider));
            this.Build();
            Configure();
        }

        private void Configure()
        {
            UoW = UnitOfWorkFactory.CreateWithoutRoot();
            buttonCreateReport.Clicked += OnButtonCreateReportClicked;
            dateperiodpicker.StartDate = DateTime.Today.AddDays(-1);
            dateperiodpicker.EndDate = DateTime.Today.AddDays(-1);
            dateperiodpicker.PeriodChangedByUser += OnDateChanged;
            var organizations = UoW.GetAll<Organization>();
            comboOrganization.ItemsList = organizations;
            comboOrganization.SetRenderTextFunc<Organization>(x => x.FullName);
            comboOrganization.Changed += (sender, e) => UpdateSensitivity();
            comboOrganization.SelectedItem = organizations.Where(x => x.Id == reportDefaultsProvider.GetDefaultOrderChangesOrganizationId).FirstOrDefault();
            ytreeviewChangeTypes.ColumnsConfig = FluentColumnsConfig<SelectedChangeTypeNode>.Create()
                .AddColumn("✓").AddToggleRenderer(x => x.Selected)
                .AddColumn("Тип").AddTextRenderer(x => x.Title)
                .Finish();

            AddChangeType("Фактическое кол-во товара", "ActualCount");
            AddChangeType("Цена товара", "Price");
            AddChangeType("Добавление/Удаление товаров", "OrderItemsCount");
            AddChangeType("Тип оплаты заказа", "PaymentType");

            ytreeviewChangeTypes.ItemsDataSource = changeTypes;

            ytreeviewIssueTypes.ColumnsConfig = FluentColumnsConfig<SelectedIssueTypeNode>.Create()
                .AddColumn("✓").AddToggleRenderer(x => x.Selected)
                .AddColumn("Тип").AddTextRenderer(x => x.Title)
                .Finish();

            AddIssueType("Проблемы с смс", "SmsIssues");
            AddIssueType("Проблемы с терминалами", "TerminalIssues");
            AddIssueType("Проблемы менеджеров", "ManagersIssues");

            ytreeviewIssueTypes.ItemsDataSource = issueTypes;
        }

        private void AddChangeType(string title, string value)
        {
            var changeType = new SelectedChangeTypeNode();
            changeType.Title = title;
            changeType.Value = value;
            changeType.PropertyChanged += (sender, e) => UpdateSensitivity();
            changeType.Selected = true;
            changeTypes.Add(changeType);
        }

        private void AddIssueType(string title, string value)
        {
            var issueType = new SelectedIssueTypeNode();
            issueType.Title = title;
            issueType.Value = value;
            issueType.PropertyChanged += (sender, e) => UpdateSensitivity();
            issueType.Selected = true;
            issueTypes.Add(issueType);
        }

        #region IParametersWidget implementation

        public string Title => "Отчет по изменениям заказа при доставке";

        public event EventHandler<LoadReportEventArgs> LoadReport;

        #endregion IParametersWidget implementation

        private ReportInfo GetReportInfo()
        {
            var ordganizationId = ((Organization)comboOrganization.SelectedItem).Id;
            var selectedChangeTypes = string.Join(",", changeTypes.Where(x => x.Selected).Select(x => x.Value));
            var selectedIssueTypes = changeTypes.Any(x => x.Selected && x.Value == "PaymentType") ? string.Empty : string.Join(",", issueTypes.Where(x => x.Selected).Select(x => x.Value));
            var selectedChangeTypesTitles = string.Join(", ", changeTypes.Where(x => x.Selected).Select(x => x.Title));
            var selectedIssueTypesTitles = changeTypes.Any(x => x.Selected && x.Value == "PaymentType") ? string.Empty : string.Join(", ", issueTypes.Where(x => x.Selected).Select(x => x.Title));

            var parameters = new Dictionary<string, object>
                {
                    { "start_date", dateperiodpicker.StartDate },
                    { "end_date", dateperiodpicker.EndDate },
                    { "organization_id", ordganizationId },
                    { "change_types", selectedChangeTypes },
                    { "change_types_rus", selectedChangeTypesTitles },
                    { "issue_types", selectedIssueTypes },
                    { "issue_types_rus", selectedIssueTypesTitles }
                };

            return new ReportInfo
            {
                Identifier = "Orders.OrderChangesReport",
                UseUserVariables = true,
                Parameters = parameters
            };
        }

        private void OnButtonCreateReportClicked(object sender, EventArgs e)
        {
            if (dateperiodpicker.StartDateOrNull == null
                || (dateperiodpicker.StartDateOrNull != null && dateperiodpicker.StartDate >= DateTime.Now)
                || comboOrganization.SelectedItem == null
                || (!changeTypes.Any(x => x.Selected) && !issueTypes.Any(x => x.Selected))
                ) {
                return;
            }

            var reportInfo = GetReportInfo();
            LoadReport?.Invoke(this, new LoadReportEventArgs(reportInfo));
        }

        private bool issuesSensitive => changeTypes.Any(x => x.Value == "PaymentType" && !x.Selected);

        private void UpdateSensitivity()
        {
            bool hasValidDate = dateperiodpicker.StartDateOrNull != null && dateperiodpicker.StartDate < DateTime.Now;
            bool hasOrganization = comboOrganization.SelectedItem != null;
            bool hasChangeTypes = changeTypes.Any(x => x.Selected);
            bool hasIssueTypes = issueTypes.Any(x => x.Selected);
            buttonCreateReport.Sensitive = hasValidDate && hasOrganization && (hasChangeTypes || hasIssueTypes);
            ytreeviewIssueTypes.Sensitive = issuesSensitive;
        }

        private void UpdatePeriodMessage()
        {
            if(dateperiodpicker.StartDateOrNull == null) {
                ylabelDateWarning.Visible = false;
                return;
            }

            var period = DateTime.Now - dateperiodpicker.StartDate;
            ylabelDateWarning.Visible = period.Days > 14;
        }

        private void OnDateChanged(object sender, EventArgs e)
        {
            UpdateSensitivity();
            UpdatePeriodMessage();
        }
    }

    public class SelectedChangeTypeNode : PropertyChangedBase
    {
        private bool selected;
        public virtual bool Selected
        {
            get => selected;
            set => SetField(ref selected, value);
        }

        public string Title { get; set; }

        public string Value { get; set; }
    }

    public class SelectedIssueTypeNode : PropertyChangedBase
    {
        private bool selected;
        public virtual bool Selected
        {
            get => selected;
            set => SetField(ref selected, value);
        }

        public string Title { get; set; }

        public string Value { get; set; }
    }
}
