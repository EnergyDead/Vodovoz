﻿using Autofac;
using Autofac.Core;
using QS.Services;
using Vodovoz.Domain.Orders;
using Vodovoz.EntityRepositories.Orders;
using Vodovoz.Factories;
using Vodovoz.Services;
using Vodovoz.ViewModels.Dialogs.Orders;

namespace Vodovoz.ViewModels.ViewModels.Orders
{
    public class SelfDeliveryOrderInfoViewModel : OrderInfoViewModelBase
    {
        public SelfDeliveryOrder SelfDeliveryOrder => Order as SelfDeliveryOrder;
        
        private SelfDeliveryOrderInfoPanelViewModel selfDeliveryOrderInfoPanelViewModel;
        public SelfDeliveryOrderInfoPanelViewModel SelfDeliveryOrderInfoPanelViewModel
        {
            get
            {
                if (selfDeliveryOrderInfoPanelViewModel == null)
                {
                    Parameter[] parameters = {
                        new TypedParameter(typeof(SelfDeliveryOrder), SelfDeliveryOrder),
                        new TypedParameter(typeof(ICommonServices), AutofacScope.Resolve<ICommonServices>()),
                        new TypedParameter(typeof(IOrderRepository), AutofacScope.Resolve<IOrderRepository>()),
                        new TypedParameter(typeof(IOrderParametersProvider), AutofacScope.Resolve<IOrderParametersProvider>())
                    };
                    selfDeliveryOrderInfoPanelViewModel = AutofacScope.Resolve<SelfDeliveryOrderInfoPanelViewModel>(parameters);
                    selfDeliveryOrderInfoPanelViewModel.AutofacScope = AutofacScope;
                    selfDeliveryOrderInfoPanelViewModel.ParentTab = ParentTab;
                }

                return selfDeliveryOrderInfoPanelViewModel;
            }
        }

        public SelfDeliveryOrderInfoViewModel(
            SelfDeliveryOrder selfDeliveryOrder,
            OrderInfoExpandedPanelViewModel expandedPanelViewModel,
            INomenclaturesJournalViewModelFactory nomenclaturesJournalViewModelFactory) 
            : base(selfDeliveryOrder, expandedPanelViewModel, nomenclaturesJournalViewModelFactory)
        {
            
        }
    }
}
