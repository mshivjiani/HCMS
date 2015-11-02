using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;
using HCMS.Business.Security;

namespace HCMS.Business.OrganizationChart.Adapters
{
    public class OrganizationChartDataAdapter : OrganizationChartBaseDataAdapter<OrganizationChart>, IEntityDataAdapter<OrganizationChart>
    {
        public override void Fill(DataRow dataItem, OrganizationChart objectItem)
        {
            if (dataItem != null)
            {
                if (dataItem["AbolishedPositionCount"] != DBNull.Value)
                    objectItem.AbolishedPositionCount = (int)dataItem["AbolishedPositionCount"];

                if (dataItem["NewFPPSPositionCount"] != DBNull.Value)
                    objectItem.NewFPPSPositionCount = (int)dataItem["NewFPPSPositionCount"];

                if (dataItem["BrokenHierarchyCount"] != DBNull.Value)
                    objectItem.BrokenHierarchyCount = (int)dataItem["BrokenHierarchyCount"];

                objectItem.CheckedOutBy = new ActionUser()
                {
                    UserID = dataItem["CheckedOutByID"] == DBNull.Value ? -1 : (int)dataItem["CheckedOutByID"],
                    FirstName = dataItem["CheckedOutByFirstName"] == DBNull.Value ? string.Empty : dataItem["CheckedOutByFirstName"].ToString(),
                    LastName = dataItem["CheckedOutByLastName"] == DBNull.Value ? string.Empty : dataItem["CheckedOutByLastName"].ToString(),
                    ActionDate = dataItem["CheckedOutByDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dataItem["CheckedOutByDate"]
                };

                if (dataItem["PublishedVersionCount"] != DBNull.Value)
                    objectItem.PublishedVersionCount = (int)dataItem["PublishedVersionCount"];

                if (dataItem["PublishedOrganizationChartLogID"] != DBNull.Value)
                    objectItem.PublishedOrganizationChartLogID = (int)dataItem["PublishedOrganizationChartLogID"];

                if (dataItem["IsRootAcknowledged"] != DBNull.Value)
                    objectItem.IsRootAcknowledged = (bool)dataItem["IsRootAcknowledged"];

                base.Fill(dataItem, objectItem);
            }
        }
    }
}
