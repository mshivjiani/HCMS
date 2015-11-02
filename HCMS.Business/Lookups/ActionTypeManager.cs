using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;        

namespace HCMS.Business.Lookups.Collections
{
    [System.ComponentModel.DataObject]
    public class ActionTypeManager:BusinessBase
    {
        #region General CRUD Methods

        public long Add(ActionType actionType)
        {
            long returnCode = -1;
            DbCommand commandWrapper = GetDbCommand("spr_AddActionType");

            try
            {
                SqlParameter returnParam = new SqlParameter("@ActionTypeID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                commandWrapper.Parameters.Add(returnParam);

                if (actionType.ActionTypeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@ActionTypeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@ActionTypeID", actionType.ActionTypeID));

                if (string.IsNullOrWhiteSpace(actionType.ActionTypeName))
                    commandWrapper.Parameters.Add(new SqlParameter("@ActionTypeName", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@ActionTypeName", actionType.ActionTypeName.Trim()));

                ExecuteNonQuery(commandWrapper);

                actionType.ActionTypeID = (long)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnCode;
        }

        public void Update(ActionType actionType)
        {

            if (base.ValidateKeyField(actionType.ActionTypeID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateActionType");

                try
                {
                    if (actionType.ActionTypeID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@ActionTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ActionTypeID", actionType.ActionTypeID));

                    if (string.IsNullOrWhiteSpace(actionType.ActionTypeName))
                        commandWrapper.Parameters.Add(new SqlParameter("@ActionTypeName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ActionTypeName", actionType.ActionTypeName.Trim()));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void Delete(ActionType actionType)
        {
            if (base.ValidateKeyField(actionType.ActionTypeID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteActionType", actionType.ActionTypeID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Constructor Helper Methods           
              
        public ActionType GetActionType(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetActionTypeByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        public ActionType GetActionType(DataRow singleRowData)
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
         
        private ActionType loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }

            return null;
        }

        protected virtual ActionType FillObjectFromRowData(DataRow returnRow)
        {
            ActionType actionType = new ActionType();
            if (returnRow["ActionTypeID"] != DBNull.Value)
                actionType.ActionTypeID = (long)returnRow["ActionTypeID"];

            if (returnRow["ActionTypeName"] != DBNull.Value)
                actionType.ActionTypeName = returnRow["ActionTypeName"].ToString();

            return actionType;

        }

        #endregion                

        #region Collection Methods

        public List<ActionType> GetAllActionTypes()
        {
            List<ActionType> listCollection = new List<ActionType>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllActionTypes");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    ActionType item = new ActionType();

                    item.ActionTypeID = dataItems.Rows[i].Field<int>("ActionTypeID");
                    item.ActionTypeName = dataItems.Rows[i].Field<string>("ActionTypeName");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Action Type collection from a null data table.");
            }

            return listCollection;
        }

        #endregion       

    }
}
