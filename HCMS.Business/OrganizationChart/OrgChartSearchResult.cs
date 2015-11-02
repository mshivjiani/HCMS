using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;
using System.Collections;

namespace HCMS.Business.OrganizationChart
{
    [Serializable]
    public class OrgChartSearchResult : BusinessBase
    {

        public int? OrganizationChartID { get; set; }
        public int? OrganizationChartTypeID { get; set; } 
		public string OrganizationChartType { get; set; }
        public int? OrganizationCodeID { get; set; } 
		public string OrganizationCode { get; set; }
		public string OrganizationName { get; set; }
        public int? RegionID { get; set; } 
		public string ReportingOrganizationCode { get; set; }
		public string OldOrganizationCode { get; set; }
        public int? LevelID { get; set; } 
		public DateTime? CreateDate { get; set; }
        public int? CreatedByID { get; set; } 
		public string CreatedByName  { get; set; }
		public int OrgWorkflowStatusID{ get; set; } 
		public DateTime OrgWorkflowStatusCreateDate { get; set; }
		public string OrgWorkflowStatus{ get; set; }
		public DateTime? CheckedOutByDate { get; set; }
        public int? CheckedOutByID { get; set; } 
		public string CheckedOutByName  { get; set; }
		public DateTime? UpdatedByDate  { get; set; }
        public int? UpdateByID { get; set; } 
		public string UpdatedByName  { get; set; }		
		public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanContinueEdit { get; set; }
        public bool CanFinishEdit { get; set; }
        public bool CanViewOnly { get; set; }
        public bool CheckedOut { get; set; }
        public int CheckedOutTypeID { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedByID { get; set; }
		public string ApprovedByName  { get; set; }
		public string ApprovedByTitle { get; set; }

        public OrgChartSearchResult()
        {


        }

        List<OrgChartSearchResult> ls = new List<OrgChartSearchResult>();

        public List<OrgChartSearchResult> LoadSearchResults(int? UserId, int? OrganizationChartID,
                                                            int? OrganizationChartTypeID, int? OrganizationCodeID,
                                                            int? OrgChartWorkflowStatusID, int? RegionID, string OrganizationCode,
                                                            string OldOrganizationCode, string Author, string Approver,
                                                            int? PublishedYear, int? SeriesID, string EmployeeName)
        {
            try
            {

                object[] parameters = new object[] 
                    { 
                        UserId,
                        OrganizationChartID,
                        OrganizationChartTypeID,
                        OrganizationCodeID, 
                        OrgChartWorkflowStatusID,
                        RegionID,
                        OrganizationCode,
                        OldOrganizationCode,
                        Author,
                        Approver,
                        PublishedYear,
                        SeriesID,
                        EmployeeName

                    };

                DataTable tblData = ExecuteDataTable("spr_SearchOrganizationCharts", parameters);

                foreach (DataRow dr in tblData.Rows)
                {
                    FillObjectFromDataRow(dr);
                }

                return ls;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        private void FillObjectFromDataRow(DataRow dataRow)
        {
            try
            {

                OrgChartSearchResult schR = new OrgChartSearchResult();
                
                schR.OrganizationChartID = (int)dataRow["OrganizationChartID"];
                schR.OrganizationChartTypeID = (int)dataRow["OrganizationChartTypeID"];
                schR.OrganizationChartType = (string)dataRow["OrganizationChartType"];
                schR.OrganizationCodeID = (int)dataRow["OrganizationCodeID"];
                schR.OrganizationCode = (string)dataRow["OrganizationCode"];
                schR.OrganizationName = (string)dataRow["OrganizationName"];
                schR.RegionID = (int)dataRow["RegionID"];
                schR.ReportingOrganizationCode = (string)dataRow["ReportingOrganizationCode"];

                if (dataRow["OldOrganizationCode"] != DBNull.Value) schR.OldOrganizationCode = (string)dataRow["OldOrganizationCode"];
                if (dataRow["LevelID"] != DBNull.Value) schR.LevelID = (int)dataRow["LevelID"];
                if (dataRow["CreateDate"] != DBNull.Value) schR.CreateDate = (DateTime)dataRow["CreateDate"];
                if (dataRow["CreatedByID"] != DBNull.Value) schR.CreatedByID = (int)dataRow["CreatedByID"];
                if (dataRow["CreatedByName"] != DBNull.Value) schR.CreatedByName = (string)dataRow["CreatedByName"];
                if (dataRow["OrgWorkflowStatusID"] != DBNull.Value) schR.OrgWorkflowStatusID = (int)dataRow["OrgWorkflowStatusID"];
                if (dataRow["OrgWorkflowStatusCreateDate"] != DBNull.Value) schR.OrgWorkflowStatusCreateDate = (DateTime)dataRow["OrgWorkflowStatusCreateDate"];

                if (dataRow["OrgWorkflowStatus"] != DBNull.Value) schR.OrgWorkflowStatus = (string)dataRow["OrgWorkflowStatus"];
                if (dataRow["CheckedOutByDate"] != DBNull.Value) schR.CheckedOutByDate = (DateTime)dataRow["CheckedOutByDate"];

                if (dataRow["CheckedOutByID"] != DBNull.Value) schR.CheckedOutByID = (int)dataRow["CheckedOutByID"];

                if (dataRow["CheckedOutByName"] != DBNull.Value) schR.CheckedOutByName = (string)dataRow["CheckedOutByName"];
                if (dataRow["UpdatedByDate"] != DBNull.Value) schR.UpdatedByDate = (DateTime)dataRow["UpdatedByDate"];

                if (dataRow["UpdateByID"] != DBNull.Value) schR.UpdateByID =(int)(dataRow["UpdateByID"]);
                if (dataRow["UpdatedByName"] != DBNull.Value) schR.UpdatedByName = (string)(dataRow["UpdatedByName"]);

                if (dataRow["CanEdit"] != DBNull.Value) schR.CanEdit = (bool)dataRow["CanEdit"];
                if (dataRow["CanDelete"] != DBNull.Value) schR.CanDelete = (bool)dataRow["CanDelete"];

                schR.CheckedOutTypeID = schR.CheckedOutByID > 0 ?1:0;

                if (dataRow["CanContinueEdit"] != DBNull.Value) schR.CanContinueEdit = (bool)dataRow["CanContinueEdit"];
                if (dataRow["CanFinishEdit"] != DBNull.Value) schR.CanFinishEdit = (bool)dataRow["CanFinishEdit"];
                if (dataRow["CanViewOnly"] != DBNull.Value) schR.CanViewOnly = (bool)dataRow["CanViewOnly"];
                if (dataRow["CheckedOut"] != DBNull.Value) schR.CheckedOut = (bool)dataRow["CheckedOut"];

                if (dataRow["ApprovedDate"] != DBNull.Value) schR.ApprovedDate = (DateTime)dataRow["ApprovedDate"];
                if (dataRow["ApprovedByID"] != DBNull.Value) schR.ApprovedByID = (int)dataRow["ApprovedByID"];
                if (dataRow["ApprovedByName"] != DBNull.Value) schR.ApprovedByName = (string)dataRow["ApprovedByName"];
                if (dataRow["ApprovedByTitle"] != DBNull.Value) schR.ApprovedByTitle = (string)dataRow["ApprovedByTitle"];

                ls.Add(schR);

            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }

       
    }
}
