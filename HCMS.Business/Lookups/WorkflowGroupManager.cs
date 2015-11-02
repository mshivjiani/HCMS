using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;        

namespace HCMS.Business.Lookups
{
    [System.ComponentModel.DataObject]
    public class WorkflowGroupManager : BusinessBase
    {
        #region General CRUD Methods

        public long Add(WorkflowGroup workflowGroup)
        {
            long returnCode = -1;
            DbCommand commandWrapper = GetDbCommand("spr_AddWorkflowGroup");    
            try
            {
                SqlParameter returnParam = new SqlParameter("@WorkflowGroupID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                commandWrapper.Parameters.Add(returnParam);

                if (workflowGroup.WorkflowGroupID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupID", workflowGroup.WorkflowGroupID));

                if (string.IsNullOrWhiteSpace(workflowGroup.WorkflowGroupName))
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupName", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupName", workflowGroup.WorkflowGroupName.Trim()));

                ExecuteNonQuery(commandWrapper);

                workflowGroup.WorkflowGroupID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnCode;
        }

        public void Update(WorkflowGroup workflowGroupType)
        {

            if (base.ValidateKeyField(workflowGroupType.WorkflowGroupID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateWorkflowGroup");

                try
                {
                    if (workflowGroupType.WorkflowGroupID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupID", workflowGroupType.WorkflowGroupID));

                    if (string.IsNullOrWhiteSpace(workflowGroupType.WorkflowGroupName))
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupName", workflowGroupType.WorkflowGroupName.Trim()));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }
       
        public void Delete(long workflowID)
        {
            if (base.ValidateKeyField(workflowID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteWorkflowGroup", workflowID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }
        #endregion

        #region Constructor Helper Methods

        public WorkflowGroup GetWorkflowGroup(int loadByID)
        {
            WorkflowGroup workflowGroup = new WorkflowGroup();
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetWorkflowGroupByID", loadByID);
                workflowGroup = loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return workflowGroup;
        }

        public WorkflowGroup GetWorkflowGroup(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        private WorkflowGroup loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }

            return null;
        }

        protected virtual WorkflowGroup FillObjectFromRowData(DataRow returnRow)
        {
            WorkflowGroup workflowGroup = new WorkflowGroup();
            if (returnRow["WorkflowGroupID"] != DBNull.Value)
                workflowGroup.WorkflowGroupID = Convert.ToInt32(returnRow["WorkflowGroupID"]);

            if (returnRow["WorkflowGroupName"] != DBNull.Value)
                workflowGroup.WorkflowGroupName = returnRow["WorkflowGroupName"].ToString();

            return workflowGroup;

        }

        #endregion         

        #region Collection Methods

        public List<WorkflowGroup> GetAllWorkflowGroups()
        {
            List<WorkflowGroup> listCollection = new List<WorkflowGroup>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllWorkflowGroups");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    WorkflowGroup item = new WorkflowGroup();

                    item.WorkflowGroupID = dataItems.Rows[i].Field<int>("WorkflowGroupID");
                    item.WorkflowGroupName = dataItems.Rows[i].Field<string>("WorkflowGroupName");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Workflow Group collection from a null data table.");
            }

            return listCollection;
        }

        #endregion       

    }
}
