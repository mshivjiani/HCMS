using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using HCMS.Business.Security;
using System.Data;
using HCMS.Business.Lookups;

namespace HCMS.Business.OrganizationChart
{
    public class OrgChartTrackerItem : BusinessBase
    {

        public int OrganizationChartID { get; set; }
        public int OrganizationChartTypeID { get; set; }
        public string OrganizationChartType { get; set; }
        public enumOrgChartType eOrganizationChartType { get; set; }

        public OrganizationCode ChartOrganizationCode { get; set; }

        public string Region { get; set; }

        public ActionUser CreatedBy { get; set; }
        
        public int OrgWorkflowStatusID { get; set; }
        public DateTime OrgWorkflowStatusCreateDate { get; set; }
        public string OrgWorkflowStatus { get; set; }
        public enumOrgWorkflowStatus eOrgWorkflowStatus { get; set; }


        public ActionUser  CheckedOutBy { get; set; }
        public ActionUser UpdatedBy { get; set; }

        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanContinueEdit { get; set; }
        public bool CanFinishEdit { get; set; }
        public bool CanViewOnly { get; set; }
        public bool CheckedOut { get; set; }

       
       #region [ Constructors ]
        private OrgChartTrackerItem(DataRow dataRow)
        {
            FillObjectFromDataRow(dataRow);
        }

        #endregion


        #region [ Collection Helper Methods ]
        public static OrgChartTrackerItemCollection GetCollectionForUser(int userID)
        {
            OrgChartTrackerItemCollection collection = null;

            try
            {
                DataTable table = ExecuteDataTable("spr_GetAllOrgChartTrackerItemsByUserID", userID);

                // fill collection list
                collection = OrgChartTrackerItem.GetCollection(table);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return collection;
        }
        private static OrgChartTrackerItemCollection GetCollection(DataTable table)
        {
            OrgChartTrackerItemCollection collection = new OrgChartTrackerItemCollection();

            try
            {
                if (table != null)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        OrgChartTrackerItem item = new OrgChartTrackerItem(table.Rows[i]);
                        collection.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return collection;
        }
        #endregion

        private void FillObjectFromDataRow(DataRow dataRow)
        {
            try
            {
                if (dataRow["OrganizationChartID"] != DBNull.Value)
                {
                    OrganizationChartID = (int)dataRow["OrganizationChartID"];
                }
                if (dataRow["OrganizationChartTypeID"] != DBNull.Value)
                {
                    OrganizationChartTypeID = (int)dataRow["OrganizationChartTypeID"];
                    eOrganizationChartType = (enumOrgChartType)OrganizationChartTypeID;
                }
                if (dataRow["OrganizationChartType"] != DBNull.Value)
                {
                    OrganizationChartType = dataRow["OrganizationChartType"].ToString();
                }

                this.ChartOrganizationCode = new OrganizationCode();
                if (dataRow["OrganizationCodeID"] != DBNull.Value)
                {
                     int orgcodeid = (int)dataRow["OrganizationCodeID"];
                     this.ChartOrganizationCode =new OrganizationCode(orgcodeid);
                }

                if (dataRow["Region"] != DBNull.Value)
                {
                    Region = dataRow["Region"].ToString();
                }
                               
                this.CreatedBy = new ActionUser()
                {
                    UserID = dataRow["CreatedByID"] == DBNull.Value ? -1 : (int)dataRow["CreatedByID"],
                    FirstName = dataRow["CreatedByFirstName"] == DBNull.Value ? string.Empty : dataRow["CreatedByFirstName"].ToString(),
                    LastName = dataRow["CreatedByLastName"] == DBNull.Value ? string.Empty : dataRow["CreatedByLastName"].ToString(),
                    ActionDate = dataRow["CreateDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dataRow["CreateDate"]
                };


                if (dataRow["OrgWorkflowStatusID"] != DBNull.Value)
                {
                    OrgWorkflowStatusID = (int)dataRow["OrgWorkflowStatusID"];
                    eOrgWorkflowStatus = (enumOrgWorkflowStatus)OrgWorkflowStatusID;
                }
                if (dataRow["OrgWorkflowStatusCreateDate"] != DBNull.Value)
                {
                    OrgWorkflowStatusCreateDate = Convert.ToDateTime(dataRow["OrgWorkflowStatusCreateDate"]);
                }
                if (dataRow["OrgWorkflowStatus"] != DBNull.Value)
                {
                    OrgWorkflowStatus = dataRow["OrgWorkflowStatus"].ToString();
                }

                this.CheckedOutBy = new ActionUser()
                {
                    UserID = dataRow["CheckedOutByID"] == DBNull.Value ? -1 : (int)dataRow["CheckedOutByID"],
                    FirstName = dataRow["CheckedOutByFirstName"] == DBNull.Value ? string.Empty : dataRow["CheckedOutByFirstName"].ToString(),
                    LastName = dataRow["CheckedOutByLastName"] == DBNull.Value ? string.Empty : dataRow["CheckedOutByLastName"].ToString(),
                    ActionDate = dataRow["CheckedOutByDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dataRow["CheckedOutByDate"]
                };

                this.UpdatedBy = new ActionUser()
                {
                    UserID = dataRow["UpdatedByID"] == DBNull.Value ? -1 : (int)dataRow["UpdatedByID"],
                    FirstName = dataRow["UpdatedByFirstName"] == DBNull.Value ? string.Empty : dataRow["UpdatedByFirstName"].ToString(),
                    LastName = dataRow["UpdatedByLastName"] == DBNull.Value ? string.Empty : dataRow["UpdatedByLastName"].ToString(),
                    ActionDate = dataRow["UpdatedByDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dataRow["UpdatedByDate"]
                };


                if (dataRow["CanEdit"] != DBNull.Value)
                {
                    CanEdit = (bool)dataRow["CanEdit"];
                }
                if (dataRow["CanDelete"] != DBNull.Value)
                {
                    CanDelete  = (bool)dataRow["CanDelete"];
                }
                if (dataRow["CanContinueEdit"] != DBNull.Value)
                {
                    CanContinueEdit = (bool)dataRow["CanContinueEdit"];
                }
                if (dataRow["CanFinishEdit"] != DBNull.Value)
                {
                    CanFinishEdit = (bool)dataRow["CanFinishEdit"];
                }
                if (dataRow["CanViewOnly"] != DBNull.Value)
                {
                    CanViewOnly = (bool)dataRow["CanViewOnly"];
                }
                if (dataRow["CheckedOut"] != DBNull.Value)
                {
                    CheckedOut = (bool)dataRow["CheckedOut"];
                }

            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }
    }
}
