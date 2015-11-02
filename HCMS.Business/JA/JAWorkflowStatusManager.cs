using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using HCMS.Business.Base;
using HCMS.Business.Common;
namespace HCMS.Business.JA
{
    public class JAWorkflowStatusManager : BusinessBase
    {
        #region [Get Methods]
        public static JAWorkflowStatus GetByID(int loadByID)
        {
            JAWorkflowStatus jaw = new JAWorkflowStatus();
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetJAWorkflowStatuByID", loadByID);
                jaw=loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return jaw;
        }
        #endregion
          
        #region Constructor Helper Methods

        private static JAWorkflowStatus  loadData(DataTable returnTable)
        {
            JAWorkflowStatus jaw = new JAWorkflowStatus();
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

              jaw= FillObjectFromRowData(returnRow);
            }
            return jaw;
        }

        private static JAWorkflowStatus  FillObjectFromRowData(DataRow returnRow)
        {
            JAWorkflowStatus jaw = new JAWorkflowStatus();
            try
            {
                jaw.JAWorkflowRecID = (long)returnRow["JAWorkflowRecID"];
                jaw.JAID = (long)returnRow["JAID"];
                jaw.JAWorkflowStatusID = (int)returnRow["JAWorkflowStatusID"];

                if (returnRow["IsCurrent"] != DBNull.Value)
                    jaw.IsCurrent = (bool)returnRow["IsCurrent"];


                if (returnRow["CreatedByID"] != DBNull.Value)
                    jaw.CreatedByID = (int)returnRow["CreatedByID"];


                if (returnRow["CreateDate"] != DBNull.Value)
                    jaw.CreateDate = (DateTime)returnRow["CreateDate"];


            }
            catch (Exception ex)
            {

                HandleException(ex);
                jaw = null;
            }
            return jaw;

        }

        #endregion

        #region [ General Static Methods ]
        public static long Add(JAWorkflowStatus jaw)
        {

            long jawRecID = -1;
            DbCommand commandWrapper = GetDbCommand("spr_AddJAWorkflowStatus");
            try
            {
                SqlParameter returnParam = new SqlParameter("@newJAWorkflowRecID", SqlDbType.BigInt);
                returnParam.Direction = ParameterDirection.Output;

                // get the new JAWorkflowRecID of the record
                commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@jAID", jaw.JAID ));
                commandWrapper.Parameters.Add(new SqlParameter("@jAWorkflowStatusID", jaw.JAWorkflowStatusID ));
                commandWrapper.Parameters.Add(new SqlParameter("@isCurrent", jaw.IsCurrent ));

                if (jaw.CreatedByID  == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", jaw.CreatedByID));


                ExecuteNonQuery(commandWrapper);

                jawRecID  = (long)returnParam.Value;
            }
            catch (Exception ex)
            {

                HandleException(ex);
            }

            return jawRecID;
           
        }
        public static void Update(JAWorkflowStatus jaw)
        {

            if (jaw.JAWorkflowRecID == -1)
                throw new Exception("You must set the primary key before using this business object.");

            else
            { 
                    DbCommand commandWrapper = GetDbCommand("spr_UpdateJAWorkflowStatus");
                    try
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@jAWorkflowRecID", jaw.JAWorkflowRecID));
                        commandWrapper.Parameters.Add(new SqlParameter("@jAID", jaw.JAID));
                        commandWrapper.Parameters.Add(new SqlParameter("@jAWorkflowStatusID", jaw.JAWorkflowStatusID));
                        commandWrapper.Parameters.Add(new SqlParameter("@isCurrent", jaw.IsCurrent));

                        if (jaw.CreatedByID == -1)
                            commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
                        else
                            commandWrapper.Parameters.Add(new SqlParameter("@createdByID", jaw.CreatedByID));

                      

                        ExecuteNonQuery(commandWrapper);
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                
            }
        }
        public static void Delete(JAWorkflowStatus jaw)
        {
            if (jaw.JAWorkflowRecID == -1)
                throw new Exception("You must set the primary key before using this business object.");
            else
            {
                DbCommand commandWrapper = GetDbCommand("spr_DeleteJAWorkflowStatus");
                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@jAWorkflowRecID", jaw.JAWorkflowRecID));
                    commandWrapper.Parameters.Add(new SqlParameter("@JAID", jaw.JAID));

                    if (jaw.CreatedByID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@createdByID", jaw.CreatedByID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }
        public static long SetCurrentWorkflowStatus(JAWorkflowStatus jaw)
        {
            return SetCurrentWorkflowStatus(jaw, null);
        }

        public static long SetCurrentWorkflowStatus(JAWorkflowStatus jaw, TransactionManager currentTransaction)
        {

            long jawRecID = -1;
            DbCommand commandWrapper = GetDbCommand("spr_SetCurrentWorkflowStatus");
            try
            {
                SqlParameter returnParam = new SqlParameter("@NewWorkflowRecID", SqlDbType.BigInt);
                returnParam.Direction = ParameterDirection.Output;

                // get the new JAWorkflowRecID of the record
                commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectID", jaw.JAID));
                commandWrapper.Parameters.Add(new SqlParameter("@StaffingObjectTypeID", enumStaffingObjectType.JA));
                commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusID", jaw.JAWorkflowStatusID));
                

                if (jaw.CreatedByID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", jaw.CreatedByID));


                if (currentTransaction != null)
                {
                    DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                }
                else
                {
                    ExecuteNonQuery(commandWrapper);
                }

                jawRecID = (long)returnParam.Value;
            }
            catch (Exception ex)
            {
                if ((currentTransaction != null) && (currentTransaction.IsOpen))
                    currentTransaction.Rollback();
                HandleException(ex);
            }

            return jawRecID;
        }
        #endregion

        #region Collection Helper Methods

        internal static List<JAWorkflowStatus> GetCollection(DataTable dataItems)
        {
            List<JAWorkflowStatus> listCollection = new List<JAWorkflowStatus>();
            JAWorkflowStatus current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = FillObjectFromRowData(dataItems.Rows[i]); ;
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a JAWorkflowStatus collection from a null data table.");

            return listCollection;
        }

        #endregion

       

      
    }
}
