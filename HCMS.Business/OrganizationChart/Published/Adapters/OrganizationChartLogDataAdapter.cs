using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using HCMS.Business.OrganizationChart.Adapters;
using HCMS.Business.Security;
using HCMS.Business.Base;

namespace HCMS.Business.OrganizationChart.Published.Adapters
{
    public class OrganizationChartLogDataAdapter : OrganizationChartBaseDataAdapter<OrganizationChartLog>, IEntityDataAdapter<OrganizationChartLog>
    {
        public override void Fill(DataRow dataItem, OrganizationChartLog objectItem)
        {
            if (dataItem != null)
            {
                if (dataItem["OrganizationChartLogID"] != DBNull.Value)
                    objectItem.OrganizationChartLogID = (int)dataItem["OrganizationChartLogID"];

                objectItem.ApprovedBy = new ActionUser()
                {
                    UserID = dataItem["ApprovedByID"] == DBNull.Value ? -1 : (int)dataItem["ApprovedByID"],
                    FirstName = dataItem["ApprovedByFirstName"] == DBNull.Value ? string.Empty : dataItem["ApprovedByFirstName"].ToString(),
                    LastName = dataItem["ApprovedByLastName"] == DBNull.Value ? string.Empty : dataItem["ApprovedByLastName"].ToString(),
                    ActionDate = dataItem["ApprovedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dataItem["ApprovedDate"]
                };

                if (dataItem["ApprovedByTitle"] != DBNull.Value)
                    objectItem.ApprovedByTitle = dataItem["ApprovedByTitle"].ToString();

                if (dataItem["ApprovedFor"] != DBNull.Value)
                    objectItem.ApprovedFor = dataItem["ApprovedFor"].ToString();

                base.Fill(dataItem, objectItem);
            }
        }
    }
}
