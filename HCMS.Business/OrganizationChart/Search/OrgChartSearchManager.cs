using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.OrganizationChart.Adapters;
using HCMS.Business.OrganizationChart.Published.Adapters;
using HCMS.Business.OrganizationChart.Published;

namespace HCMS.Business.OrganizationChart.Search
{
    public sealed class OrgChartSearchManager : BusinessBase
    {
        #region Object Declarations

        private static readonly Lazy<OrgChartSearchManager> _instance = new Lazy<OrgChartSearchManager>(() => new OrgChartSearchManager());

        #endregion

        #region Singleton Property

        public static OrgChartSearchManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        #endregion

        #region Constructor

        private OrgChartSearchManager()
        {

        }

        #endregion

        #region Methods
       
        public List<OrgChartSearchResult> LoadSearchResults(int userID, int? organizationChartID = null,
                                                            int? organizationChartTypeID = null, int? organizationCodeID = null,
                                                            enumOrgWorkflowStatus orgChartWorkflowStatusID = enumOrgWorkflowStatus.Undefined, 
                                                            int? regionID = null, string authorName = null, string approverName = null,
                                                            int? publishedYear = null, int? seriesID = null, string employeeName = null)
        {
            List<OrgChartSearchResult> searchResults = new List<OrgChartSearchResult>();

            if (userID <=0)
                throw new BusinessException("UserID must be provided.");
            else if (organizationChartID == null && organizationChartTypeID == null && organizationCodeID == null && orgChartWorkflowStatusID == enumOrgWorkflowStatus.Undefined
                && regionID == null && string.IsNullOrEmpty(authorName) && string.IsNullOrEmpty(approverName) && publishedYear == null && seriesID == null &&
                string.IsNullOrEmpty(employeeName))
            {
                throw new BusinessException("No search criteria provided. At least one expected.");
            }
            else
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_SearchOrganizationCharts");

                    commandWrapper.Parameters.Add(new SqlParameter("@UserID", userID));


                    if (organizationChartID.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", organizationChartID.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", DBNull.Value));

                    if (organizationChartTypeID.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartTypeID", organizationChartTypeID.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartTypeID", DBNull.Value));

                    if (organizationCodeID.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCodeID", organizationCodeID.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCodeID", DBNull.Value));

                    if (orgChartWorkflowStatusID == enumOrgWorkflowStatus.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgChartWorkflowStatusID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgChartWorkflowStatusID", (int)orgChartWorkflowStatusID));

                    if (regionID.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@RegionID", regionID.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@RegionID", DBNull.Value));

                    if (string.IsNullOrWhiteSpace(authorName))
                        commandWrapper.Parameters.Add(new SqlParameter("@AuthorName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@AuthorName", authorName.Trim()));

                    if (string.IsNullOrWhiteSpace(approverName))
                        commandWrapper.Parameters.Add(new SqlParameter("@ApprovedByName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ApprovedByName", approverName.Trim()));

                    if (publishedYear.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@PublishedYear", publishedYear.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PublishedYear", DBNull.Value));

                    if (seriesID.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", seriesID.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", DBNull.Value));

                    if (string.IsNullOrWhiteSpace(employeeName))
                        commandWrapper.Parameters.Add(new SqlParameter("@EmployeeName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@EmployeeName", employeeName.Trim()));

                    // get data set
                    DataSet ds = ExecuteDataSet(commandWrapper);

                    if (ds.Tables.Count > 0)
                    {
                        // Table 0: OrganizationChart records
                        if (ds.Tables[0] != null)
                        {
                            DataTable tableOC = ds.Tables[0];
                            OrganizationChartDataAdapter OCAdapter = new OrganizationChartDataAdapter();

                            foreach (DataRow dr in tableOC.Rows)
                            {
                                OrgChartSearchResult resultItem = getSearchResultObject(dr);
                                OrganizationChart chart = new OrganizationChart();
                                OCAdapter.Fill(dr, chart);
                                resultItem.ChartEntity = chart;  // OrganizationChartManager.Instance.BuildFromDataRow(dr);

                                searchResults.Add(resultItem);
                            }
                        }

                        // Table 1: OrganizationChartLog records
                        if (ds.Tables[1] != null)
                        {
                            DataTable tableOCL = ds.Tables[1];
                            OrganizationChartLogDataAdapter OCLAdapter = new OrganizationChartLogDataAdapter();

                            foreach (DataRow dr in tableOCL.Rows)
                            {
                                OrgChartSearchResult resultItem = getSearchResultObject(dr);
                                OrganizationChartLog chartLog = new OrganizationChartLog();
                                OCLAdapter.Fill(dr, chartLog);
                                resultItem.ChartEntity = chartLog;   // OrganizationChartLogManager.Instance.BuildFromDataRow(dr);

                                searchResults.Add(resultItem);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
            return searchResults;
        }

        private OrgChartSearchResult getSearchResultObject(DataRow dataRow)
        {
            OrgChartSearchResult resultItem = new OrgChartSearchResult();

            try
            {
                if (dataRow["CanEdit"] != DBNull.Value)
                    resultItem.CanEdit = (bool)dataRow["CanEdit"];

                if (dataRow["CanDelete"] != DBNull.Value)
                    resultItem.CanDelete = (bool)dataRow["CanDelete"];

                if (dataRow["CanContinueEdit"] != DBNull.Value)
                    resultItem.CanContinueEdit = (bool)dataRow["CanContinueEdit"];

                if (dataRow["CanFinishEdit"] != DBNull.Value)
                    resultItem.CanFinishEdit = (bool)dataRow["CanFinishEdit"];

                if (dataRow["CanViewOnly"] != DBNull.Value)
                    resultItem.CanViewOnly = (bool)dataRow["CanViewOnly"];

                if (dataRow["IsCheckedOut"] != DBNull.Value)
                    resultItem.IsCheckedOut = (Convert.ToInt32(dataRow["IsCheckedOut"]) == 1);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return resultItem;
        }

        #endregion
    }
}
