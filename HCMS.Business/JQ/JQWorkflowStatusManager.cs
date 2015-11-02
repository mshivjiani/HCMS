using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using HCMS.Business.Base;
using HCMS.Business.Common;

namespace HCMS.Business.JQ
{
    public class JQWorkflowStatusManager : BusinessBase
    {
        #region [Get Methods]
        public static JQWorkflowStatus GetByID (int loadByID)
	{
		// Load Object by ID
        JQWorkflowStatus item = null;
		try
        {
           DataTable returnTable = ExecuteDataTable("spr_GetJQWorkflowStatuByID", loadByID);
           item = loadData(returnTable);
		}
        catch (Exception ex)
        {
            item = null;
            HandleException(ex);
         }

        return item;
	}	
	
	
        #endregion
        #region [ Constructor Helper Methods ]
        private static JQWorkflowStatus loadData(DataTable returnTable)
        {
            JQWorkflowStatus jqw = new JQWorkflowStatus();
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                jqw = FillObjectFromDataRow(returnRow);
            }
            return jqw;
        }
        private static JQWorkflowStatus FillObjectFromDataRow(DataRow returnRow)
        {
            JQWorkflowStatus jqw = new JQWorkflowStatus();
            try
            {
                jqw.JQWorkflowRecID  = (long)returnRow["JQWorkflowRecID"];
                jqw.JQID  = (long)returnRow["JQID"];
                jqw.JQWorkflowStatusID  = (int)returnRow["JQWorkflowStatusID"];
                if (returnRow["IsCurrent"] != DBNull.Value)
                    jqw.IsCurrent  = (bool)returnRow["IsCurrent"];
                if (returnRow["CreatedByID"] != DBNull.Value)
                    jqw.CreatedByID  = (int)returnRow["CreatedByID"];
                if (returnRow["CreateDate"] != DBNull.Value)
                    jqw.CreateDate  = (DateTime)returnRow["CreateDate"];
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
                jqw = null;
            }
            return jqw;
        }
        #endregion

        #region [ General Static Methods ]
        public static long Add(JQWorkflowStatus jqw)
        {
            return Add(jqw, null);
        }
        public static long Add(JQWorkflowStatus jqw, TransactionManager currentTransaction)
        {
            long jqwRecID = -1;
            DbCommand commandWrapper = GetDbCommand("spr_AddJQWorkflowStatu");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newJQWorkflowRecID", SqlDbType.BigInt);
                returnParam.Direction = ParameterDirection.Output;

                // get the new JQWorkflowRecID of the record
                commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@jQID", jqw.JQID ));
                commandWrapper.Parameters.Add(new SqlParameter("@jQWorkflowStatusID", jqw.JQWorkflowStatusID));
                commandWrapper.Parameters.Add(new SqlParameter("@isCurrent", jqw.IsCurrent));

                if (jqw.CreatedByID  == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", jqw.CreatedByID ));

                if (jqw.CreateDate  == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@createDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@createDate", jqw.CreateDate));


                if (currentTransaction != null)
                {
                    ExecuteNonQuery( currentTransaction,commandWrapper);
                }
                else
                {
                    ExecuteNonQuery(commandWrapper);
                }

                jqwRecID = (long)returnParam.Value;
            }
            catch (Exception ex)
            {
                if ((currentTransaction != null) && (currentTransaction.IsOpen))
                    currentTransaction.Rollback();
                HandleException(ex);
            }
            return jqwRecID;
        }
        public static void Update(JQWorkflowStatus jqw)
        {

            if (jqw.JQWorkflowRecID ==-1)
            {
                throw new Exception("You must set the primary key before using this business object.");
            }
            else
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateJQWorkflowStatu");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@jQWorkflowRecID", jqw.JQWorkflowRecID ));
                    commandWrapper.Parameters.Add(new SqlParameter("@jQID", jqw.JQID ));
                    commandWrapper.Parameters.Add(new SqlParameter("@jQWorkflowStatusID", jqw.JQWorkflowStatusID ));
                    commandWrapper.Parameters.Add(new SqlParameter("@isCurrent", jqw.IsCurrent ));

                    if (jqw.CreatedByID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@createdByID", jqw.CreatedByID ));

                    if (jqw.CreateDate  == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@createDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@createDate", jqw.CreateDate ));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }
        public void Delete(JQWorkflowStatus jqw)
        {
            if (jqw.JQWorkflowRecID == -1)
            {
                throw new Exception("You must set the primary key before using this business object.");
            }
            else
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteJQWorkflowStatu", jqw.JQWorkflowRecID );
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public static long SetCurrentWorkflowStatus(JQWorkflowStatus jqw)
        {
            return SetCurrentWorkflowStatus(jqw, null);
        }

        public static long SetCurrentWorkflowStatus(JQWorkflowStatus jqw, TransactionManager currentTransaction)
        {

            long jqwRecID = -1;
            DbCommand commandWrapper = GetDbCommand("spr_SetCurrentWorkflowStatus");
            try
            {
                SqlParameter returnParam = new SqlParameter("@NewWorkflowRecID", SqlDbType.BigInt);
                returnParam.Direction = ParameterDirection.Output;

                // get the new JQWorkflowRecID of the record
                commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectID", jqw.JQID ));
                commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectTypeID", enumStaffingObjectType.JQ));
                commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusID", jqw.JQWorkflowStatusID));


                if (jqw.CreatedByID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", jqw.CreatedByID));


                if (currentTransaction != null)
                {
                    DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                }
                else
                {
                    ExecuteNonQuery(commandWrapper);
                }

                jqwRecID = (long)returnParam.Value;
            }
            catch (Exception ex)
            {
                if ((currentTransaction != null) && (currentTransaction.IsOpen))
                    currentTransaction.Rollback();
                HandleException(ex);
            }

            return jqwRecID;
        }
        #endregion


        #region Collection Helper Methods

        public static List<JQWorkflowStatus> GetCollection(DataTable dataItems)
        {
            List<JQWorkflowStatus> listCollection = new List<JQWorkflowStatus>();
            JQWorkflowStatus current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = FillObjectFromDataRow (dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a JQWorkflowStatus collection from a null data table.");

            return listCollection;
        }

        #endregion
    }
}
