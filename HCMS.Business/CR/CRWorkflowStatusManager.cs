using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using HCMS.Business.Base;
using HCMS.Business.Common;

namespace HCMS.Business.CR
{
    public class CRWorkflowStatusManager : BusinessBase
    {
        #region [Get Methods]
        public static CRWorkflowStatus GetByID(long CRWorkflowRecID)
        {
            CRWorkflowStatus item = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetCRWorkflowStatusByID", CRWorkflowRecID);
                item = loadData(dataTable);                

            }
            catch (Exception ex)
            {
                item = null;
                ExceptionBase.HandleException(ex);
            }

            return item;
        }
        public static CRWorkflowStatus GetByCRID(long CRID)
        {
            CRWorkflowStatus item = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetCRWorkflowStatusByCRID", CRID);
                item = loadData(dataTable);

            }
            catch (Exception ex)
            {
                item = null;
                ExceptionBase.HandleException(ex);
            }

            return item;
        }
        #endregion

        #region [ Constructor Helper Methods ]
        private static CRWorkflowStatus  loadData(DataTable returnTable)
        {
            CRWorkflowStatus crw = new CRWorkflowStatus();
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                crw = FillObjectFromDataRow(returnRow);
            }
            return crw;
        }
        private static CRWorkflowStatus  FillObjectFromDataRow(DataRow dataRow)
        {
            CRWorkflowStatus crw = new CRWorkflowStatus();
            try
            {
                crw.CRWorkflowRecID = (long)dataRow["CRWorkflowRecID"];
                crw.CRID = (long)dataRow["CRID"];
                crw.CRWorkflowStatusID = (int)dataRow["CRWorkflowStatusID"];
                if (dataRow["IsCurrent"] != DBNull.Value) crw.IsCurrent = (bool)dataRow["IsCurrent"];
                if (dataRow["CreatedByID"] != DBNull.Value) crw.CreatedByID = (int)dataRow["CreatedByID"];
                if (dataRow["CreateDate"] != DBNull.Value) crw.CreateDate = (DateTime)dataRow["CreateDate"];
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
                crw = null;
            }
            return crw;
        }
        #endregion

       
        #region [ General Static Methods ]
        // do not catch exceptions - the caller must do that
        public static void Add(CRWorkflowStatus crw)
        {
            Add(crw,null);
        }
        public static void Add(CRWorkflowStatus crw,TransactionManager transactionManager)
        {
            if (transactionManager == null)
                crw.CRWorkflowRecID = (long)ExecuteScalar("spr_AddCRWorkflowStatus", crw.CRID, crw.CRWorkflowStatusID, crw.IsCurrent, crw.CreatedByID, crw.CreateDate);
            else
                crw.CRWorkflowRecID = (long)ExecuteScalar(transactionManager, "spr_AddCRWorkflowStatus", crw.CRID, crw.CRWorkflowStatusID, crw.IsCurrent, crw.CreatedByID, crw.CreateDate);
        }
        // do not catch exceptions - the caller must do that
        public static void Update(CRWorkflowStatus crw)
        {
            Update(crw,null);
        }
        public static void Update(CRWorkflowStatus crw,TransactionManager transactionManager)
        {
            DbCommand commandWrapper = GetDbCommand("spr_UpdateCRWorkflowStatus");

            commandWrapper.Parameters.Add(new SqlParameter("@cRWorkflowRecID", crw.CRWorkflowRecID));
            commandWrapper.Parameters.Add(new SqlParameter("@cRID", crw.CRID));
            commandWrapper.Parameters.Add(new SqlParameter("@cRWorkflowStatusID", (int)crw.CRWorkflowStatusID));
            commandWrapper.Parameters.Add(new SqlParameter("@isCurrent", crw.IsCurrent));
            commandWrapper.Parameters.Add(new SqlParameter("@createdByID", crw.CreatedByID));
            commandWrapper.Parameters.Add(new SqlParameter("@createDate", crw.CreateDate));

            if (transactionManager == null)
                ExecuteNonQuery(commandWrapper);
            else
                ExecuteNonQuery(transactionManager, commandWrapper);
        }
        // do not catch exceptions - the caller must do that
        public static void Delete(CRWorkflowStatus crw)
        {
            Delete(crw,null);
        }
        public static void Delete(CRWorkflowStatus crw,TransactionManager transactionManager)
        {
            DbCommand commandWrapper = GetDbCommand("spr_DeleteCRWorkflowStatus");
            commandWrapper.Parameters.Add(new SqlParameter("@cRWorkflowRecID", crw.CRWorkflowRecID));

            if (transactionManager == null)
                ExecuteNonQuery(commandWrapper);
            else
                ExecuteNonQuery(transactionManager, commandWrapper);
        }


        public static long SetCurrentWorkflowStatus(CRWorkflowStatus crw)
        {
            return SetCurrentWorkflowStatus(crw, null);
        }

        public static long SetCurrentWorkflowStatus(CRWorkflowStatus crw, TransactionManager currentTransaction)
        {

            long crwRecID = -1;
            DbCommand commandWrapper = GetDbCommand("spr_SetCurrentWorkflowStatus");
            try
            {
                SqlParameter returnParam = new SqlParameter("@NewWorkflowRecID", SqlDbType.BigInt);
                returnParam.Direction = ParameterDirection.Output;

                // get the new JAWorkflowRecID of the record
                commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectID", crw.CRID));
                commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectTypeID", enumStaffingObjectType.CR));
                commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusID", crw.CRWorkflowStatusID));
               

                if (crw.CreatedByID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", crw.CreatedByID));


                if (currentTransaction != null)
                {
                    DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                }
                else
                {
                    ExecuteNonQuery(commandWrapper);
                }

                crwRecID = (long)returnParam.Value;
            }
            catch (Exception ex)
            {
                if ((currentTransaction != null) && (currentTransaction.IsOpen))
                    currentTransaction.Rollback();
                HandleException(ex);
            }

            return crwRecID;
        }
        #endregion
    }
}
