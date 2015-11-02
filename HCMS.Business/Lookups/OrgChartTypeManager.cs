using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups
{
    public class OrgChartTypeManager : ManagerBase<OrgChartTypeManager, OrgChartType>
    {
        #region Constructors

        public OrgChartTypeManager()
        {
            // Empty constructor
        }

        #endregion

        #region Collection Methods

        public OrgChartTypeCollection GetAllOrgChartTypes()
        {
            return base.GetRelatedDataCollection<OrgChartTypeCollection>("spr_GetAllOrganizationChartTypes");
        }

        public OrgChartTypeCollection GetAvailableOrgChartTypes(int orgCodeID)
        {
            return base.GetRelatedDataCollection<OrgChartTypeCollection>("spr_GetAvailableOrganizationChartTypesByOrgCode", orgCodeID);
        }

        #endregion
    }
}
 