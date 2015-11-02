using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using HCMS.Business.JA;
using HCMS.Business.CR;
using HCMS.Business.Common;
using HCMS.Business.Lookups;
using HCMS.Business.JQ;
using HCMS.Business.Error;
namespace HCMS.Business.PD
{
    [System.ComponentModel.DataObject]
    public class WorkflowManager : BusinessBase  
    {          

        #region General CRUD Methods

        public long Add(WorkflowRule workflowRule)
        {
            long returnCode = -1;
            DbCommand commandWrapper = GetDbCommand("spr_AddWorkflowRule");

            try
            {

                SqlParameter returnParam = new SqlParameter("@newWorkflowRuleID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;
                commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@staffingObjectCurrentStatusID", workflowRule.StaffingObjectCurrentStatusID));                
                commandWrapper.Parameters.Add(new SqlParameter("@workflowGroupID", workflowRule.WorkflowGroupID));                                        
                commandWrapper.Parameters.Add(new SqlParameter("@staffingObjectTypeID", workflowRule.StaffingObjectTypeID));

                ExecuteNonQuery(commandWrapper);

                returnCode = Convert.ToInt64(returnParam.Value);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnCode;
        }

        public bool Update(WorkflowRule workflowRule)
        {
            bool isSuccessful = false; 
            if (base.ValidateKeyField(workflowRule.WorkflowRuleID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateWorkflowRule");

                try
                {
                    if (workflowRule.WorkflowRuleID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowRuleID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowRuleID", workflowRule.WorkflowRuleID));

                    if (workflowRule.StaffingObjectCurrentStatusID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectCurrentStatusID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectCurrentStatusID", workflowRule.StaffingObjectCurrentStatusID));

                    if (workflowRule.WorkflowGroupID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupID", workflowRule.WorkflowGroupID));

                    if (workflowRule.StaffingObjectTypeID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectTypeID", workflowRule.StaffingObjectTypeID));

                    ExecuteNonQuery(commandWrapper);
                    isSuccessful = true;

                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
            return isSuccessful;
        }

        public void DeleteRule(int workflowRuleID)
        {
            if (base.ValidateKeyField(workflowRuleID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteWorkflowRule", workflowRuleID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Constructor Helper Methods

        public WorkflowRule GetWorkflowRule(int loadByID)
        {
            WorkflowRule workflowRule = new WorkflowRule();
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetWorkflowRuleByID", loadByID);
                workflowRule = loadWorkflowRuleData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return workflowRule;
        }

        public WorkflowRule GetWorkflowRule(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.FillWorkflowRuleObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        private WorkflowRule loadWorkflowRuleData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillWorkflowRuleObjectFromRowData(returnRow);
            }

            return null;
        }

        protected virtual WorkflowRule FillWorkflowRuleObjectFromRowData(DataRow returnRow)
        {
            WorkflowRule actionType = new WorkflowRule();
           
            if (returnRow["WorkflowRuleID"] != DBNull.Value)
                actionType.WorkflowRuleID = (int)returnRow["WorkflowRuleID"];
            
            if (returnRow["StaffingObjectCurrentStatusID"] != DBNull.Value)
                actionType.StaffingObjectCurrentStatusID = (int)returnRow["StaffingObjectCurrentStatusID"];

            if (returnRow["WorkflowGroupID"] != DBNull.Value)
                actionType.WorkflowGroupID = (int)returnRow["WorkflowGroupID"];
            
            if (returnRow["StaffingObjectTypeID"] != DBNull.Value)
                actionType.StaffingObjectTypeID = (int)returnRow["StaffingObjectTypeID"];

            return null;     
        }

        #endregion         

        #region Collection Methods

        public List<WorkflowRule> GetAllWorkflowRules()
        {
            List<WorkflowRule> listCollection = new List<WorkflowRule>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllWorkflowRules");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    WorkflowRule item = new WorkflowRule();

                    item.WorkflowRuleID = Convert.ToInt32(dataItems.Rows[i]["WorkflowRuleID"]);

                    item.StaffingObjectCurrentStatusID = Convert.ToInt32(dataItems.Rows[i]["StaffingObjectCurrentStatusID"]);
                    item.StaffingObjectCurrentStatusName = dataItems.Rows[i]["WorkflowStatus"].ToString();

                    item.StaffingObjectTypeID = Convert.ToInt32(dataItems.Rows[i]["StaffingObjectTypeID"]);
                    item.StaffingObjectTypeName = dataItems.Rows[i]["StaffingObjectTypeName"].ToString();

                    item.WorkflowGroupID = Convert.ToInt32(dataItems.Rows[i]["WorkflowGroupID"]);
                    item.WorkflowGroupName = dataItems.Rows[i]["WorkflowGroupName"].ToString();

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Workflow Rule collection from a null data table.");
            }

            return listCollection;
        }     

        public List<WorkflowRule> GetAllWorkflowGroupRulesByGroupID(int workflowGroupID, int staffingObjectTypeID)
        {
            List<WorkflowRule> listCollection = new List<WorkflowRule>();

            if (workflowGroupID > 0)
            {

                DataTable dataItems = ExecuteDataTable("spr_GetAllRulesByGroupID", workflowGroupID, staffingObjectTypeID);

                if (dataItems != null)
                {
                    for (int i = 0; i < dataItems.Rows.Count; i++)
                    {

                        WorkflowRule item = new WorkflowRule();

                        item.WorkflowRuleID = dataItems.Rows[i].Field<int>("WorkflowRuleID");

                        item.StaffingObjectCurrentStatusID = dataItems.Rows[i].Field<int>("StaffingObjectCurrentStatusID");
                        item.StaffingObjectCurrentStatusName = dataItems.Rows[i].Field<string>("WorkflowStatus");

                        item.StaffingObjectTypeID = dataItems.Rows[i].Field<int>("StaffingObjectTypeID");
                        item.StaffingObjectTypeName = dataItems.Rows[i].Field<string>("StaffingObjectTypeName");

                        item.WorkflowGroupID = dataItems.Rows[i].Field<int>("WorkflowGroupID");
                        item.WorkflowGroupName = dataItems.Rows[i].Field<string>("WorkflowGroupName");

                        listCollection.Add(item);
                    }
                }
                else
                {
                    throw new Exception("You cannot create a Workflow Group Rule collection from a null data table.");
                }
            }
            return listCollection;
        }


        #endregion       

        //Workflow Action

        #region General CRUD Methods

        public long Add(WorkflowAction workflowAction)
        {
            long returnCode = -1;
            DbCommand commandWrapper = GetDbCommand("spr_AddWorkflowAction");   
            try
            {
                SqlParameter returnParam = new SqlParameter("@newWorkflowActionRecID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;
                commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@workflowRuleID", workflowAction.WorkflowRuleID));
                commandWrapper.Parameters.Add(new SqlParameter("@actionTypeID", workflowAction.ActionTypeID)); 
               
                ExecuteNonQuery(commandWrapper);              

                returnCode = Convert.ToInt64(returnParam.Value);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnCode;
        }

        public bool Update(WorkflowAction workflowAction)
        {
            bool isSuccessful = false;
            if (base.ValidateKeyField(workflowAction.WorkflowActionRecID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateWorkflowAction");

                try
                {
                    if (workflowAction.WorkflowActionRecID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowActionRecID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowActionRecID", workflowAction.WorkflowActionRecID));

                    if (workflowAction.WorkflowRuleID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowRuleID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowRuleID", workflowAction.WorkflowRuleID));

                    if (workflowAction.ActionTypeID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@ActionTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ActionTypeID", workflowAction.ActionTypeID));
                                        
                    ExecuteNonQuery(commandWrapper);

                    isSuccessful = true;
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                } 
            }
            return isSuccessful;
        }

        public void DeleteAction(int workflowActionRecID)
        {
            if (base.ValidateKeyField(workflowActionRecID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteWorkflowAction", workflowActionRecID);                    
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }           
        }

        #endregion

        #region Constructor Helper Methods

        public WorkflowAction GetWorkflowAction(int loadByID)
        {
            WorkflowAction workflowAction = new WorkflowAction();
            
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetWorkflowActionByID", loadByID);
                workflowAction = loadWorkflowActionData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return workflowAction;
        }

        public WorkflowAction GetWorkflowAction(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.FillWorkflowActionObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        private WorkflowAction loadWorkflowActionData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillWorkflowActionObjectFromRowData(returnRow);
            }

            return null;
        }

        protected virtual WorkflowAction FillWorkflowActionObjectFromRowData(DataRow returnRow)
        {
            WorkflowAction workflowAction = new WorkflowAction();

            if (returnRow["WorkflowActionRecID"] != DBNull.Value)
                workflowAction.WorkflowActionRecID = Convert.ToInt32(returnRow["WorkflowActionRecID"]);

            if (returnRow["WorkflowRuleID"] != DBNull.Value)
                workflowAction.WorkflowRuleID = Convert.ToInt32(returnRow["WorkflowRuleID"]);

            if (returnRow["ActionTypeID"] != DBNull.Value)
                workflowAction.ActionTypeID = Convert.ToInt32(returnRow["ActionTypeID"]);

             if (returnRow["ActionTypeName"] != DBNull.Value)
                workflowAction.ActionTypeName = returnRow["ActionTypeName"].ToString();

              if (returnRow["StaffingObjectCurrentStatusID"] != DBNull.Value)
                workflowAction.StaffingObjectCurrentStatusID = Convert.ToInt32(returnRow["StaffingObjectCurrentStatusID"]);

             if (returnRow["WorkflowStatus"] != DBNull.Value)
                 workflowAction.StaffingObjectCurrentStatusName = returnRow["WorkflowStatus"].ToString();
            
              if (returnRow["WorkflowGroupID"] != DBNull.Value)
                workflowAction.WorkflowGroupID = Convert.ToInt32(returnRow["WorkflowGroupID"]);

             if (returnRow["WorkflowGroupName"] != DBNull.Value)
                workflowAction.WorkflowGroupName = returnRow["WorkflowGroupName"].ToString();

              if (returnRow["StaffingObjectTypeID"] != DBNull.Value)
                workflowAction.StaffingObjectTypeID = Convert.ToInt32(returnRow["StaffingObjectTypeID"]);

             if (returnRow["StaffingObjectTypeName"] != DBNull.Value)
                workflowAction.StaffingObjectTypeName = returnRow["StaffingObjectTypeName"].ToString();

            return workflowAction;
        }

        #endregion

        #region Collection Methods

        public List<WorkflowAction> GetAllWorkflowActions()
        {
            List<WorkflowAction> listCollection = new List<WorkflowAction>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllWorkflowActions");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    WorkflowAction item = new WorkflowAction();

                    item.WorkflowActionRecID = dataItems.Rows[i].Field<int>("WorkflowActionRecID");
                    item.WorkflowRuleID = dataItems.Rows[i].Field<int>("WorkflowRuleID");  
                    item.ActionTypeID = dataItems.Rows[i].Field<int>("ActionTypeID");
                    item.ActionTypeName = dataItems.Rows[i].Field<string>("ActionTypeName");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Workflow Action collection from a null data table.");
            }

            return listCollection;
        }

        #endregion       

        //Workflow Group Permission

        #region General CRUD Methods             
    
        public long Add(WorkflowGroupPermission workflowGroupPermission)
        {
            long returnCode = -1;
            DbCommand commandWrapper = GetDbCommand("spr_AddWorkflowGroupPermission");
            try
            {
                SqlParameter returnParam = new SqlParameter("@WorkflowGroupRecID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                commandWrapper.Parameters.Add(returnParam);

                if (workflowGroupPermission.WorkflowGroupRecID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupRecID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupRecID", workflowGroupPermission.WorkflowGroupRecID));

                if (workflowGroupPermission.WorkflowGroupID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupID", workflowGroupPermission.WorkflowGroupID));

                if (workflowGroupPermission.PermissionID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@PermissionID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@PermissionID", workflowGroupPermission.PermissionID));

                ExecuteNonQuery(commandWrapper);

                workflowGroupPermission.WorkflowGroupRecID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnCode;
        }

        public void Update(WorkflowGroupPermission workflowGroupPermission)
        {
            if (base.ValidateKeyField(workflowGroupPermission.WorkflowGroupRecID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateWorkflowGroupPermission");

                try
                {
                    if (workflowGroupPermission.WorkflowGroupRecID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupRecID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupRecID", workflowGroupPermission.WorkflowGroupRecID));

                    if (workflowGroupPermission.WorkflowGroupID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkflowGroupID", workflowGroupPermission.WorkflowGroupID));

                    if (workflowGroupPermission.PermissionID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@PermissionID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PermissionID", workflowGroupPermission.PermissionID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void Delete(WorkflowGroupPermission workflowGroupPermission)
        {
            if (base.ValidateKeyField(workflowGroupPermission.WorkflowGroupRecID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteWorkflowGroupPermission", workflowGroupPermission.WorkflowGroupRecID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Constructor Helper Methods

        public WorkflowGroupPermission GetWorkflowGroupPermission(int loadByID)
        {
            WorkflowGroupPermission workflowGroupPermission = new WorkflowGroupPermission();
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetWorkflowGroupPermissionByID", loadByID);
                workflowGroupPermission = loadWorkflowGroupPermissionData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return workflowGroupPermission;
        }

        public WorkflowGroupPermission GetWorkflowGroupPermission(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.FillWorkflowGroupPermissionObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        private WorkflowGroupPermission loadWorkflowGroupPermissionData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillWorkflowGroupPermissionObjectFromRowData(returnRow);
            }

            return null;
        }

        protected virtual WorkflowGroupPermission FillWorkflowGroupPermissionObjectFromRowData(DataRow returnRow)
        {
            WorkflowGroupPermission workflowGroupPermission = new WorkflowGroupPermission();

            if (returnRow["WorkflowGroupRecID"] != DBNull.Value)
                workflowGroupPermission.WorkflowGroupRecID = Convert.ToInt32(returnRow["WorkflowGroupRecID"]);

            if (returnRow["WorkflowGroupID"] != DBNull.Value)
                workflowGroupPermission.WorkflowGroupID = Convert.ToInt32(returnRow["WorkflowGroupID"]);

            if (returnRow["PermissionID"] != DBNull.Value)
                workflowGroupPermission.PermissionID = Convert.ToInt32(returnRow["PermissionID"]);

            return workflowGroupPermission;
        }

        #endregion

        #region Collection Methods

        public List<WorkflowGroupPermission> GetAllWorkflowGroupPermissions()
        {
            List<WorkflowGroupPermission> listCollection = new List<WorkflowGroupPermission>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllWorkflowGroupPermissions");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    WorkflowGroupPermission item = new WorkflowGroupPermission();

                    item.WorkflowGroupRecID = dataItems.Rows[i].Field<int>("WorkflowGroupRecID");

                    item.WorkflowGroupID = dataItems.Rows[i].Field<int>("WorkflowGroupID");
                    item.WorkflowGroupName = dataItems.Rows[i].Field<string>("WorkflowGroupName");

                    item.PermissionID = dataItems.Rows[i].Field<int>("PermissionID");
                    item.PermissionName = dataItems.Rows[i].Field<string>("PermissionName");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Workflow Group Permission collection from a null data table.");
            }

            return listCollection;
        }

        public List<WorkflowGroupPermission> GetAllWorkflowGroupPermissionsByGroupID(int workflowGroupID)
        {
            List<WorkflowGroupPermission> listCollection = new List<WorkflowGroupPermission>();

            if (workflowGroupID > 0)
            {      
            
                DataTable dataItems = ExecuteDataTable("spr_GetAllPermissionsByGroupID", workflowGroupID);

                if (dataItems != null)
                {
                    for (int i = 0; i < dataItems.Rows.Count; i++)
                    {
                        WorkflowGroupPermission item = new WorkflowGroupPermission();

                        item.WorkflowGroupRecID = dataItems.Rows[i].Field<int>("WorkflowGroupRecID");

                        item.WorkflowGroupID = dataItems.Rows[i].Field<int>("WorkflowGroupID");
                        item.WorkflowGroupName = dataItems.Rows[i].Field<string>("WorkflowGroupName");

                        item.PermissionID = dataItems.Rows[i].Field<int>("PermissionID");
                        item.PermissionName = dataItems.Rows[i].Field<string>("PermissionName");

                        listCollection.Add(item);
                    }
                }
                else
                {
                    throw new Exception("You cannot create a Workflow Group Permission collection from a null data table.");
                }
            }
            return listCollection;
        }
        #endregion       

        //Common Methods

        public List<WorkflowAction> GetAllWorkflowRuleActions()
        {
            List<WorkflowAction> listCollection = new List<WorkflowAction>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllWorkflowRuleActions");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    WorkflowAction item = new WorkflowAction();
                    
                    item.WorkflowRuleID = dataItems.Rows[i].Field<int>("WorkflowRuleID");

                    item.StaffingObjectTypeID = dataItems.Rows[i].Field<int>("StaffingObjectTypeID");
                    item.StaffingObjectTypeName = dataItems.Rows[i].Field<string>("StaffingObjectTypeName");

                    item.StaffingObjectCurrentStatusID = dataItems.Rows[i].Field<int>("StaffingObjectCurrentStatusID");
                    item.StaffingObjectCurrentStatusName = dataItems.Rows[i].Field<string>("WorkflowStatus");

                    item.WorkflowGroupID = dataItems.Rows[i].Field<int>("WorkflowGroupID");
                    item.WorkflowGroupName = dataItems.Rows[i].Field<string>("WorkflowGroupName");

                    item.ActionTypeID = dataItems.Rows[i].Field<int>("ActionTypeID");
                    item.ActionTypeName = dataItems.Rows[i].Field<string>("ActionTypeName");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Workflow Rule Action collection from a null data table.");
            }

            return listCollection;
        }
        public List<WorkflowAction> GetActionTypesForWorkflowRuleId(int workflowRuleID)
        {
            List<WorkflowAction> listCollection = new List<WorkflowAction>();

            DataTable dataItems = Business.Base.BusinessBase.ExecuteDataTable("spr_GetActionTypesForWorkflowRuleId", workflowRuleID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    WorkflowAction item = new WorkflowAction();

                    item.ActionTypeID = Convert.ToInt32(dataItems.Rows[i]["ActionTypeID"]);
                    item.ActionTypeName = dataItems.Rows[i]["ActionTypeName"].ToString();

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Workflow Rule Action collection from a null data table.");
            }

            return listCollection;
        }
        public List<WorkflowStatus> GetWorkflowStatusByGroupObjectType(int currentGroupID, int currentStaffingObjectTypeID, bool isExistingStatus)
        {
            List<WorkflowStatus> listCollection = new List<WorkflowStatus>();

            if (currentGroupID > 0 && currentStaffingObjectTypeID > 0)
            {                                                                        

                DataTable dataItems = ExecuteDataTable("spr_GetWorkflowStatusByGroupObjectType", currentGroupID, currentStaffingObjectTypeID, isExistingStatus);

                if (dataItems != null)
                {
                    for (int i = 0; i < dataItems.Rows.Count; i++)
                    {
                        WorkflowStatus item = new WorkflowStatus();

                        item.WorkflowStatusID = dataItems.Rows[i].Field<int>("WorkflowStatusID");
                        item.WorkflowStatusName = dataItems.Rows[i].Field<string>("WorkflowStatus");

                        listCollection.Add(item);
                    }
                }
                else
                {
                    throw new Exception("You cannot create a Workflow Status collection from a null data table.");
                }

            }
            return listCollection;

        }
        public static List<WorkflowAction> GetNextWorkflowActions(WorkflowObject wo)
        {
            List<WorkflowAction> listCollection = new List<WorkflowAction>();
            int sobjecttypeid = (int) (wo.StaffingObjectTypeID);
            DataTable dataItems = ExecuteDataTable("spr_GetNextWorkflowActions", wo.StaffingObjectID , sobjecttypeid, wo.UserID , wo.ParentObjectID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    WorkflowAction item = new WorkflowAction();                    

                    item.ActionTypeID = dataItems.Rows[i].Field<int>("ActionTypeID");
                    item.ActionTypeName = dataItems.Rows[i].Field<string>("ActionTypeName");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Workflow Rule Action collection from a null data table.");
            }

            return listCollection;
        }
        public List<WorkflowRule> GetWorkflowRulesByGroupObjectTypeStatus(int currentGroupID, int currentStaffingObjectTypeID)
        {
            List<WorkflowRule> listCollection = new List<WorkflowRule>();
            listCollection = GetAllWorkflowRules();

            listCollection = listCollection.Where(p => (p.WorkflowGroupID == currentGroupID
                && p.StaffingObjectTypeID == currentStaffingObjectTypeID                
                )).ToList();          

            return listCollection;

        }

        #region Static Workflow Related Methods
        
        public static long CheckStaffingObject(long staffingObjectID, enumStaffingObjectType staffingObjectTypeID, enumActionType checkActionTypeID, int userID)
        {
            return CheckStaffingObject(staffingObjectID, staffingObjectTypeID, checkActionTypeID, userID, null); 
        }
        public static long CheckStaffingObject(long staffingObjectID, enumStaffingObjectType staffingObjectTypeID, enumActionType checkActionTypeID, int userID, TransactionManager currentTransaction)
        { 
            long checkID = -1;
            try
            {
               
                if (checkActionTypeID == enumActionType.CheckIn || checkActionTypeID == enumActionType.CheckOut)
                {
                    if (currentTransaction != null)
                    {
                        checkID = (long)ExecuteScalar(currentTransaction, "spr_JNPCheck", staffingObjectID, staffingObjectTypeID, (int)checkActionTypeID, userID);
                    }
                    else
                    {
                        checkID = (long)ExecuteScalar("spr_JNPCheck", staffingObjectID, staffingObjectTypeID, (int)checkActionTypeID, userID);

                    }
                }
                else
                {
                    throw new ApplicationException("You can either Check in or Check Out the object.<br/>Provided action value is not correct.");
                }
            }
            catch (Exception ex)
            {
                if ((currentTransaction != null) && (currentTransaction.IsOpen))
                    currentTransaction.Rollback();

                HandleException(ex);
            }
            return checkID;
        }
        public static long CheckJNP(WorkflowObject wo)
        {
            return CheckJNP(wo, null);
        }
        public static long CheckJNP(WorkflowObject wo, TransactionManager currentTransaction)
        { 
            long checkID = -1;

            try
            {
                if (wo.StaffingObjectTypeID == enumStaffingObjectType.JNP)
                {
                    if ((wo.ActionTypeID == enumActionType.CheckIn) || (wo.ActionTypeID == enumActionType.CheckOut))
                    {
                        int CheckStaffingObjectTypeID = (int)wo.StaffingObjectTypeID;
                        int CheckActionTypeID = (int)wo.ActionTypeID;
                        if (currentTransaction != null)
                        {
                            checkID = (long)ExecuteScalar(currentTransaction, "spr_JNPCheck", wo.StaffingObjectID, CheckStaffingObjectTypeID, CheckActionTypeID, wo.UserID);
                        }
                        else
                        {
                            checkID = (long)ExecuteScalar("spr_JNPCheck", wo.StaffingObjectID, CheckStaffingObjectTypeID, CheckActionTypeID, wo.UserID);
                        }
                    }
                    else
                    { throw new ApplicationException("Action type can either be Check In or Check Out."); }
                }
                else
                {
                    throw new ApplicationException("Staffing object should be of type JNP.");
                }
            }
            catch (Exception ex)
            {
                if ((currentTransaction != null) && (currentTransaction.IsOpen))
                    currentTransaction.Rollback();
                HandleException(ex);
            }

            return checkID;
           
        }
        public static int SetJNPCurrentWorkflowStatus(long jnpID, int workflowstatusid,enumWorkflowStatusType workflowstatustype,int currentuserid, bool checkIn)
        {
            int workflowstatustypeid = (int)workflowstatustype;
            int retcode = -1;
            DbCommand commandWrapper = GetDbCommand("spr_SetJNPCurrentWorkflowStatus");
            try
            {

                commandWrapper.Parameters.Add(new SqlParameter("@JNPID", jnpID));
                commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusID",workflowstatusid));
                commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusTypeID", workflowstatustypeid));
                commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", currentuserid));

                retcode=(int)ExecuteScalar(commandWrapper);

                if ((retcode > 0)&& (checkIn))
                {
                    CheckStaffingObject(jnpID, enumStaffingObjectType.JNP, enumActionType.CheckIn, currentuserid);
                }
               
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return retcode;
             
        }
        /// <summary>
        /// supports setting workflowstatus related to documents 
        /// For documents with in JNP - it supports setting all the workflowstatus that are associated with JNP - In Process
        /// </summary>
        /// <param name="wo"></param>
        /// <param name="workflowstatusid"></param>
        /// <param name="checkIn"></param>
        /// <returns></returns>
        public static long SetCurrentWorkflowStatus(WorkflowObject wo, int workflowstatusid,bool checkIn)
        {
            long workflowrecid = -1;
            try
            {
                switch (wo.StaffingObjectTypeID)
                {
                    case enumStaffingObjectType.Unknown:
                        break;
                    case enumStaffingObjectType.JNP:
                        workflowrecid = SetJNPCurrentWorkflowStatus(wo.StaffingObjectID, workflowstatusid, enumWorkflowStatusType.JNP, wo.UserID, checkIn);
                        break;
                    case enumStaffingObjectType.JNPJA:
                    case enumStaffingObjectType.JA:
                        workflowrecid= SetJAWorkflowStatus(wo, workflowstatusid,checkIn);
                        break;
                    case enumStaffingObjectType.JNPCR:
                    case enumStaffingObjectType.CR:
                        workflowrecid = SetCRWorkflowStatus(wo, workflowstatusid, checkIn);
                        break;
                    case enumStaffingObjectType.JNPJQ:
                    case enumStaffingObjectType.JQ:
                        workflowrecid = SetJQWorkflowStatus(wo, workflowstatusid, checkIn);
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {

                HandleException(ex);

            }
            return workflowrecid;

        }
        public static enumDocWorkflowStatus GetJNPCurrentDocumentWorklfowStatus(long jnpID)
        {
            int workflowstatusid = -1;
            workflowstatusid = (int)ExecuteScalar("spr_GetJNPDocumentStatus", jnpID);
            return (enumDocWorkflowStatus)workflowstatusid;

        }
        private static long SetJAWorkflowStatus(WorkflowObject wo,int workflowstatusid, bool checkIn)
        {
            long workflowrecid = -1;
            JAWorkflowStatus jaw = new JAWorkflowStatus();
            //jaw.JAID = wo.StaffingObjectID; // StaffObjId is not the JAID
            jaw.JAID = wo.ParentObjectID;
            jaw.JAWorkflowStatusID = workflowstatusid;
            jaw.CreatedByID = wo.UserID;
            jaw.IsCurrent = true;
            TransactionManager currentTransaction = new TransactionManager(BusinessBase.CurrentDb);
            currentTransaction.BeginTransaction();
            try
            {

                workflowrecid = JAWorkflowStatusManager.SetCurrentWorkflowStatus(jaw, currentTransaction);

            //if JA is document finalize and within JNP 
                if ((workflowstatusid == (int)enumDocWorkflowStatus.FinalReview) && (wo.ParentObjectID > 0) && (wo.ParentObjetTypeID == enumStaffingObjectType.JNP))
                {   //JA issue id : 337
                    //sync the Final KSA from JA to JQ ( spr will check if JQ exists and has new Final KSA(COE/Business Necessity) in JA then will add those to JQ)

                    SynFinalFactorsFromJA(wo.UserID, wo.ParentObjectID, null, null, currentTransaction);
                }

                if (checkIn)
                { 
                
                    if ((workflowrecid > 0) && (wo.StaffingObjectTypeID == enumStaffingObjectType.JNPJA))
                    {
                        if ((wo.ParentObjectID>0) && (wo.ParentObjetTypeID ==enumStaffingObjectType.JNP))
                        {
                        CheckStaffingObject(wo.ParentObjectID ,wo.ParentObjetTypeID,  enumActionType.CheckIn,wo.UserID,currentTransaction);
                        }
                    }               
                }     
            currentTransaction.Commit();
            }
            catch (Exception ex)
            {
                if (currentTransaction.IsOpen)
                    currentTransaction.Rollback();
                HandleException(ex);
            }
            return workflowrecid;
        }
        private static long SetCRWorkflowStatus(WorkflowObject wo,int workflowstatusid,bool checkIn)
        {
            long workflowrecid = -1;
            CRWorkflowStatus ws = new CRWorkflowStatus();
            ws.CRID = wo.StaffingObjectID;
            ws.CRWorkflowStatusID = workflowstatusid;
            ws.CreatedByID = wo.UserID;
            ws.IsCurrent = true;

            if (checkIn)
            {
                TransactionManager currentTransaction = new TransactionManager(BusinessBase.CurrentDb);
                currentTransaction.BeginTransaction();
                try
                {
                    workflowrecid = CRWorkflowStatusManager.SetCurrentWorkflowStatus(ws, currentTransaction);
                    if ((workflowrecid > 0) && (wo.StaffingObjectTypeID == enumStaffingObjectType.JNPCR ))
                    {
                        if ((wo.ParentObjectID > 0) && (wo.ParentObjetTypeID == enumStaffingObjectType.JNP))
                        {
                            CheckStaffingObject(wo.ParentObjectID, wo.ParentObjetTypeID, enumActionType.CheckIn, wo.UserID, currentTransaction);
                        }
                    }
                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
            else
            {
                try
                {
                    workflowrecid = CRWorkflowStatusManager.SetCurrentWorkflowStatus(ws);
                }
                catch (Exception ex)
                {

                    HandleException(ex);
                }

            }
            return workflowrecid;
        }
        private static long SetJQWorkflowStatus(WorkflowObject wo, int workflowstatusid, bool checkIn)
        {
            long workflowrecid = -1;
            JQWorkflowStatus ws = new JQWorkflowStatus ();
            ws.JQID = wo.StaffingObjectID;
            ws.JQWorkflowStatusID  = workflowstatusid;
            ws.CreatedByID = wo.UserID;
            ws.IsCurrent = true;

            if (checkIn)
            {
                TransactionManager currentTransaction = new TransactionManager(BusinessBase.CurrentDb);
                currentTransaction.BeginTransaction();
                try
                {
                    workflowrecid = JQWorkflowStatusManager.SetCurrentWorkflowStatus(ws, currentTransaction);
                    if ((workflowrecid > 0) && (wo.StaffingObjectTypeID == enumStaffingObjectType.JNPJQ))
                    {
                        if ((wo.ParentObjectID > 0) && (wo.ParentObjetTypeID == enumStaffingObjectType.JNP))
                        {
                            CheckStaffingObject(wo.ParentObjectID, wo.ParentObjetTypeID, enumActionType.CheckIn, wo.UserID, currentTransaction);
                        }
                    }
                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
            else
            {
                try
                {
                    workflowrecid = JQWorkflowStatusManager.SetCurrentWorkflowStatus(ws);
                }
                catch (Exception ex)
                {

                    HandleException(ex);
                }

            }
            return workflowrecid;
        }

        #endregion


        #region static validation related Methods
        public static List<ValidationError> ValidateStaffingObject(long StaffingObjectID, enumStaffingObjectType StaffingObjectTypeID, bool ValidateSignature)
        {
            List<ValidationError> errorList = new List<ValidationError>();
            DbCommand commandWrapper = GetDbCommand("spr_ValidateStaffingObjectAndGetErrorMessages");
            try
            {

                commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectTypeID", (int)StaffingObjectTypeID ));
                commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectID", StaffingObjectID ));
                commandWrapper.Parameters.Add(new SqlParameter("@validateSignature", ValidateSignature));

                SqlParameter returnParam = new SqlParameter("@validationSuccessful", SqlDbType.Bit);
                returnParam.Direction = ParameterDirection.Output;
                commandWrapper.Parameters.Add(returnParam);
                
                errorList = ValidationError.GetCollection(ExecuteDataTable(commandWrapper));
               
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return errorList;
        }

        public static string GetStaffingObjetValidationErros(long StaffingObjectID, enumStaffingObjectType StaffingObjectTypeID, ref bool hasErrors, bool ValidateSignature)
        {
            StringBuilder finalError = new StringBuilder();
            List<ValidationError> errorList = new List<ValidationError>();
            errorList = ValidateStaffingObject(StaffingObjectID, StaffingObjectTypeID, ValidateSignature);
            int i = 1;
            if (errorList.Count > 0)
            {
                hasErrors = true;
                
                foreach (ValidationError item in errorList)
                {
                    if (i == 1) // This is to prevent extra bullet that appears in validation summary control
                    {
                        finalError.AppendFormat("{0}",item.ErrorMessage);
                    }
                    else
                    {
                        finalError.AppendFormat("<li>{0}</li>", item.ErrorMessage);
                    }
                    i = i + 1;

                }
            }
            else
            {
                hasErrors = false;
            }
            return finalError.ToString();
        }
        #endregion


        #region static Other methods
        public static int SynFinalFactorsFromJA(int userID, long? JNPID,long? JAID, long? JQID, TransactionManager currentTransaction)
        {
            int returnCode = -1;
            DbCommand commandWrapper = GetDbCommand("spr_SynFinalFactorsFromJA");
            try
            {
                if (JNPID == null)
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPID", JNPID));

                if (JAID == null)
                    commandWrapper.Parameters.Add(new SqlParameter("@JAID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JAID",JAID));

                if (JAID == null)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQID", JQID));


                commandWrapper.Parameters.Add(new SqlParameter("@UserID", userID));
                                        
                if (currentTransaction != null)
                {
                    returnCode = DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                }
                else
                {
                    returnCode = commandWrapper.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                if ((currentTransaction != null) && (currentTransaction.IsOpen))
                    currentTransaction.Rollback();
                HandleException(ex);
            }

            return returnCode;
        }

        #endregion

    }
}
