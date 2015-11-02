using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;

namespace HCMS.Business.Lookups
{
    public class OrgWorkflowStatusManager : BusinessBase
    {

        #region Constructor Helper Methods

        public OrgWorkflowStatus GetOrgWorkflowStatus(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetOrgWorkflowStatusByID", loadByID);
                return loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }

           
        }

        private static OrgWorkflowStatus GetOrgWorkflowStatus(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
               return FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);

                return null;
            }
            
        }

        private OrgWorkflowStatus loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }
            else
            {
                return null;
            }
        }

        private static OrgWorkflowStatus FillObjectFromRowData(DataRow returnRow)
        {
            OrgWorkflowStatus OrgWS = new OrgWorkflowStatus();
            if (returnRow["OrgWorkflowStatusID"] != DBNull.Value)
                OrgWS.OrgWorkflowStatusID = (int)returnRow["OrgWorkflowStatusID"];

            if (returnRow["OrgWorkflowStatus"] != DBNull.Value)
                OrgWS.OrgWorkflowStatusDesc = returnRow["OrgWorkflowStatus"].ToString();

            return OrgWS ;

        }

        #endregion

        #region Collection Methods

        public static List<OrgWorkflowStatus> GetAllOrgWorkflowStatus()
        {
            List<OrgWorkflowStatus> listCollection = new List<OrgWorkflowStatus>();
            OrgWorkflowStatus item;
            DataTable dataItems = ExecuteDataTable("spr_GetAllOrgWorkFlowStatuses");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    item = GetOrgWorkflowStatus(dataItems.Rows[i]);
                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Org Workflow Status collection from a null data table.");
            }

            return listCollection;
        }

        #endregion
    }
}
 