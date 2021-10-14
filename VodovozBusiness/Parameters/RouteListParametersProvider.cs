using System;
using Vodovoz.Services;

namespace Vodovoz.Parameters
{
    public class RouteListParametersProvider : IRouteListParametersProvider
    {
        private readonly IParametersProvider parametersProvider;

        public RouteListParametersProvider(IParametersProvider parametersProvider)
        {
            this.parametersProvider = parametersProvider ?? throw new ArgumentNullException(nameof(parametersProvider));
        }
        
        public int CashSubdivisionSofiiskayaId => parametersProvider.GetIntValue("cashsubdivision_sofiiskaya_id");
        public int CashSubdivisionParnasId => parametersProvider.GetIntValue("cashsubdivision_parnas_id");
        public int WarehouseSofiiskayaId => parametersProvider.GetIntValue("warehouse_sofiiskaya_id");
        public int WarehouseParnasId => parametersProvider.GetIntValue("warehouse_parnas_id");
		
		//Склад Бугры
        public int WarehouseHillocksId => parametersProvider.GetIntValue("warehouse_hillocks_id");
        public int SouthGeographicGroupId => parametersProvider.GetIntValue("south_geographic_group_id");
    }
}
