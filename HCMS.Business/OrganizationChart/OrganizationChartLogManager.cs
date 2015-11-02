using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.OrganizationChart.Managers;
using System.Data;
using HCMS.Business.Security;

namespace HCMS.Business.OrganizationChart
{
    public class OrganizationChartLogManager : OrganizationManagerBase<OrganizationChartLog>
    {
        #region Object Declarations

        private static readonly Lazy<OrganizationChartLogManager> _instance = new Lazy<OrganizationChartLogManager>(() => new OrganizationChartLogManager());

        #endregion

        #region Singleton Property

        public static OrganizationChartLogManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        #endregion

        #region Constructor

        private OrganizationChartLogManager()
        {
            // Alternative to all static -- private constructor w/ singleton access through instance
        }

        #endregion

        #region Private Methods

        private void getObjectFromDataRow(OrganizationChartLog chart, DataRow returnRow)
        {
            if (returnRow["OrganizationChartLogID"] != DBNull.Value)
                chart.OrganizationChartLogID = (int)returnRow["OrganizationChartLogID"];

            chart.ApprovedBy = new ActionUser()
            {
                UserID = returnRow["ApprovedByID"] == DBNull.Value ? -1 : (int)returnRow["ApprovedByID"],
                FirstName = returnRow["ApprovedByFirstName"] == DBNull.Value ? string.Empty : returnRow["ApprovedByFirstName"].ToString(),
                LastName = returnRow["ApprovedByLastName"] == DBNull.Value ? string.Empty : returnRow["ApprovedByLastName"].ToString(),
                ActionDate = returnRow["ApprovedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)returnRow["ApprovedDate"]
            };

            if (returnRow["ApprovedByTitle"] != DBNull.Value)
                chart.ApprovedByTitle = returnRow["ApprovedByTitle"].ToString();

            if (returnRow["ApprovedFor"] != DBNull.Value)
                chart.ApprovedFor = returnRow["ApprovedFor"].ToString();
        }

        #endregion

        #region General "Get" Methods

        internal OrganizationChartLog BuildFromDataRow(DataRow rowItem)
        {
            return base.BuildFromDataRow(getObjectFromDataRow, rowItem);
        }

        public OrganizationChartLog GetByID(int orgChartLogID)
        {
            return base.GetOrganizationChartEntity(getObjectFromDataRow, "spr_GetOrganizationChartLogByID", orgChartLogID);
        }

        public OrganizationChartLog GetOrganizationChartLogByOrgCodeAndChartType(enumOrgChartType organizationChartTypeID, int organizationCodeID)
        {
            return base.GetOrganizationChartEntity(getObjectFromDataRow, "spr_GetLastPublishedOrganizationChartForOrganizationByOrgChartType", organizationCodeID, (int)organizationChartTypeID);
        }

        #endregion

        #region General "Get Collection" Methods

        public List<OrganizationChartLog> GetOrganizationChartLogsByOrgCode(int organizationCodeID)
        {
            return base.GetOrganizationChartEntityCollection(getObjectFromDataRow, "spr_GetAllPublishedOrganizationChartsByOrganizationCodeID", organizationCodeID);
        }

        public List<OrganizationChartLog> GetOrganizationChartLogsByUser(int userID)
        {
            return base.GetOrganizationChartEntityCollection(getObjectFromDataRow, "spr_GetOrganizationChartLogByUserID", userID);
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
