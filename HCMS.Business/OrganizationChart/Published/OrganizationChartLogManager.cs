using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Security;
using HCMS.Business.Base;
using HCMS.Business.OrganizationChart.Published.Adapters;

namespace HCMS.Business.OrganizationChart.Published
{
    public class OrganizationChartLogManager : RepositoryBase<OrganizationChartLogManager, OrganizationChartLog, OrganizationChartLogDataAdapter>
    {
        #region General "Get" Methods

        public OrganizationChartLog GetByID(int orgChartLogID)
        {
            return base.GetItem("spr_GetOrganizationChartLogByID", orgChartLogID);
        }

        public OrganizationChartLog GetByOrgCodeAndChartType(int organizationCodeID, enumOrgChartType organizationChartTypeID)
        {
            return base.GetItem("spr_GetLastPublishedOrganizationChartForOrganizationByOrgChartType", organizationCodeID, (int)organizationChartTypeID);
        }

        #endregion

        #region General "Get Collection" Methods

        public List<OrganizationChartLog> GetOrganizationChartLogsByOrgCode(int organizationCodeID)
        {
            return base.GetItemList("spr_GetAllPublishedOrganizationChartsByOrganizationCodeID", organizationCodeID).ToList();
        }

        public List<OrganizationChartLog> GetOrganizationChartLogsByUser(int userID)
        {
            return base.GetItemList("spr_GetOrganizationChartLogByUserID", userID).ToList();
        }

        #endregion

        #region General Action Methods

        public List<int> GetOrgChartPublishedYears()
        {
            List<int> publishedYears = new List<int>();

            try
            {
                DataTable tblData = ExecuteDataTable("spr_GetAllOrgChartPublishedYear");

                foreach (DataRow rowItem in tblData.Rows)
                    publishedYears.Add((int) rowItem[0]);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return publishedYears;
        }

        #endregion
    }
}
