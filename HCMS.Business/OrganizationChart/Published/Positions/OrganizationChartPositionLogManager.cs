using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using HCMS.Business.OrganizationChart.Published.Positions.Adapters;

namespace HCMS.Business.OrganizationChart.Published.Positions
{
    public class OrganizationChartPositionLogManager : RepositoryBase<OrganizationChartPositionLogManager, OrganizationChartPositionLog, OrganizationChartPositionLogDataAdapter>
    {
        #region General "Get" Methods

        public OrganizationChartPositionLog GetByID(int orgChartLogID, int WFPPositionID)
        {
            return base.GetItem("spr_GetOrganizationChartPositionLogByID", orgChartLogID, WFPPositionID);
        }

        #endregion

        #region General "Get Collection" Methods

        public IList<OrganizationChartPositionLog> GetOrganizationChartPositionLogs(int orgChartLogID)
        {
            return base.GetItemList("spr_GetAllOrganizationChartPositionLogsByID", orgChartLogID);
        }

        public IList<OrganizationChartPositionLog> GetSubordinateOrganizationChartPositionLogsByParent(int orgChartLogID, int WFPPositionID)
        {
            return base.GetItemList("spr_GetSubordinateOrganizationChartPositionLogsByParent", orgChartLogID, WFPPositionID);
        }

        #endregion
    }
}
