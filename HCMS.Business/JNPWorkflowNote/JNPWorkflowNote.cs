using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
using HCMS.Business.Common;

namespace HCMS.Business.JNP
{
    /// <summary>
    /// JNP Workflow Note Business Object
    /// </summary>
    [Serializable]
    public class JNPWorkflowNote : BusinessBase
    {
        #region [ Constructors ]
        public JNPWorkflowNote()
        {
        }
        private JNPWorkflowNote(DataRow dataRow)
        {
            FillObjectFromRowData(dataRow);
        }
        #endregion

        #region [ Constructor Helper Methods ]
        protected virtual void FillObjectFromRowData(DataRow dataRow)
        {
            JNPWorkflowNoteID = (long)dataRow["JNPWorkflowNoteID"];
            JNPWorkflowRecID = (long)dataRow["JNPWorkflowRecID"];
            JNPWorkflowNoteStatusID = (int)dataRow["JNPWorkflowNoteStatusID"];
            if (DBNull.Value.Equals(dataRow["Note"]) == false) Note = (string)dataRow["Note"];
            CreatedByID = (int)dataRow["CreatedByID"];
            CreateDate = (DateTime)dataRow["CreateDate"];
            if (DBNull.Value.Equals(dataRow["UpdateNote"]) == false) UpdateNote = (string)dataRow["UpdateNote"];
            UpdatedByID = (int)dataRow["UpdatedByID"];
            UpdateDate = (DateTime)dataRow["UpdateDate"];
            //
            if (DBNull.Value.Equals(dataRow["JNPWorkflowNoteStatus"]) == false) JNPWorkflowNoteStatus = (string)dataRow["JNPWorkflowNoteStatus"];
            if (DBNull.Value.Equals(dataRow["CreatedBy"]) == false) CreatedBy = (string)dataRow["CreatedBy"];
            if (DBNull.Value.Equals(dataRow["UpdatedBy"]) == false) UpdatedBy = (string)dataRow["UpdatedBy"];
        }
        #endregion

        #region [ Static Helper Methods ]
        public static JNPWorkflowNote GetByID(long jnpWorkflowNoteID)
        {
            JNPWorkflowNote item = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetJNPWorkflowNoteByNoteID", jnpWorkflowNoteID);

                if (dataTable.Rows.Count == 1)
                {
                    DataRow dataRow = dataTable.Rows[0];

                    if (dataRow != null)
                    {
                        item = new JNPWorkflowNote(dataRow);
                    }
                }

            }
            catch (Exception ex)
            {
                item = null;
                ExceptionBase.HandleException(ex);
            }

            return item;
        }
        public static JNPWorkflowNote GetByRecID(long jnpWorkflowRecID)
        {
            JNPWorkflowNote item = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetJNPWorkflowNoteByRecID", jnpWorkflowRecID);

                if (dataTable.Rows.Count == 1)
                {
                    DataRow dataRow = dataTable.Rows[0];

                    if (dataRow != null)
                    {
                        item = new JNPWorkflowNote(dataRow);
                    }
                }

            }
            catch (Exception ex)
            {
                item = null;
                ExceptionBase.HandleException(ex);
            }

            return item;
        }
        
        /// <summary>
        /// NOTE: DataSet contains extra information comparing to JNPWorkflowNote object
        /// </summary>
        /// <param name="jnpID">JNP ID</param>
        /// <returns>DataSet</returns>
        public static DataSet GetByJNPID(long jnpID)
        {
            DataSet dataSet = new DataSet();

            try
            {
                object[] parameters = new object[]
                {
                    jnpID
                };

                dataSet = BusinessBase.ExecuteDataSet("spr_GetJNPWorkflowNoteByJNPID", parameters);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return dataSet;
        }

        #region [ the stored procedure returns a list of records, not one record! ]
        //public static JNPWorkflowNote GetByJNPID(long jnpID)
        //{
        //    JNPWorkflowNote item = null;
        //
        //    try
        //    {
        //        DataTable dataTable = ExecuteDataTable("spr_GetJNPWorkflowNoteByJNPID", jnpID);
        //
        //        if (dataTable.Rows.Count == 1)
        //        {
        //            DataRow dataRow = dataTable.Rows[0];

        //            if (dataRow != null)
        //            {
        //                item = new JNPWorkflowNote(dataRow);
        //            }
        //        }
        //
        //    }
        //    catch (Exception ex)
        //    {
        //        item = null;
        //        ExceptionBase.HandleException(ex);
        //    }
        //
        //    return item;
        //}
        #endregion
        #endregion
        #region [ General Methods ]
        public void Add()
        {
            JNPWorkflowNoteID = (long)ExecuteScalar("spr_AddJNPWorkflowNote", JNPWorkflowRecID, JNPWorkflowNoteStatusID, Note, CreatedByID, CreateDate, UpdateNote, UpdatedByID, UpdateDate);
        }
        public void Update()
        {
            ExecuteNonQuery("spr_UpdateJNPWorkflowNote", JNPWorkflowNoteID, JNPWorkflowRecID, JNPWorkflowNoteStatusID, Note, CreatedByID, CreateDate, UpdateNote, UpdatedByID, UpdateDate);
        }
        public void Delete(int currentUserId)
        {
            ExecuteNonQuery("spr_DeleteJNPWorkflowNote", JNPWorkflowNoteID, currentUserId);
        }
        #endregion

        #region [ Properties ]
        public long JNPWorkflowNoteID { get; set; }
        public long JNPWorkflowRecID { get; set; }
        public int JNPWorkflowNoteStatusID { get; set; }
        public string Note { get; set; } // nullable
        public int CreatedByID { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateNote { get; set; } // nullable
        public int UpdatedByID { get; set; }
        public DateTime UpdateDate { get; set; }
        //
        public string JNPWorkflowNoteStatus { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        #endregion
    }
}
