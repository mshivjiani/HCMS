using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using HCMS.Business.Lookups.Adapters;
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups.Repositories
{
    public class OrgChartTypeRepository : RepositoryBase<OrgChartTypeRepository, OrgChartType, OrgChartTypeDataAdapter>
    {
        public OrgChartTypeCollection GetAllOrgChartTypes()
        {
            return base.GetItemCustomCollection<OrgChartTypeCollection>("spr_GetAllOrganizationChartTypes");
        }

        public OrgChartTypeCollection GetAvailableOrgChartTypes(int orgCodeID)
        {
            return base.GetItemCustomCollection<OrgChartTypeCollection>("spr_GetAvailableOrganizationChartTypesByOrgCode", orgCodeID);
        }
    }
}
