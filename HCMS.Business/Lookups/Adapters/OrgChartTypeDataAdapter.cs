using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;

namespace HCMS.Business.Lookups.Adapters
{
    public class OrgChartTypeDataAdapter : IEntityDataAdapter<OrgChartType>
    {
        public virtual void Fill(DataRow singleRow, OrgChartType item)
        {
            if (singleRow != null)
            {
                if (singleRow["OrganizationChartTypeID"] != DBNull.Value)
                    item.OrgChartTypeID = (int)singleRow["OrganizationChartTypeID"];

                if (singleRow["OrganizationChartType"] != DBNull.Value)
                    item.OrgChartTypeDesc = singleRow["OrganizationChartType"].ToString();
            }
        }
    }
}
