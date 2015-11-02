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
using System.ComponentModel;

namespace HCMS.Business.Lookups
{
    /// <summary>
    /// TaskStatement Business Object
    /// </summary>
    [Serializable]
    [DataObject]
    public class TaskStatement : BusinessBase
    {
        #region Private Members

        private long _taskStatementID = -1;
        private string _taskStatement = string.Empty;

        #endregion

        #region Properties

        public long TaskStatementID
        {
            get
            {
                return this._taskStatementID;
            }
            set
            {
                this._taskStatementID = value;
            }
        }

        public string TaskStatementText
        {
            get
            {
                return this._taskStatement;
            }
            set
            {
                this._taskStatement = value;
            }
        }

        #endregion

        #region Constructors

        public TaskStatement()
        {
            //Empty Constructor
        }

        public TaskStatement(DataRow singleRowData)
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
        }

        public TaskStatement(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetTaskStatementByTaskStatementID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion

        #region Constructor Helper Methods

        private void loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                this.FillObjectFromRowData(returnRow);
            }
        }

        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            this._taskStatementID = (long)returnRow["TaskStatementID"];
            this._taskStatement = returnRow["TaskStatement"].ToString();
        }

        #endregion

        #region ToXML Method

        ///<summary>
        /// Returns an XML String that represents the current object.
        ///</summary>
        public string ToXML()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StreamReader sr = new StreamReader(new MemoryStream()))
            {
                serializer.Serialize(sr.BaseStream, this);
                sr.BaseStream.Position = 0;
                return sr.ReadToEnd();
            }
        }

        #endregion ToXML Method

        #region ToString Method

        ///<summary>
        /// Returns a String that represents the current object.
        ///</summary>
        public override string ToString()
        {
            return "TaskStatementID:" + TaskStatementID.ToString();
        }

        #endregion ToString Method

        #region CompareMethods

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current object.</param>
        /// <returns>Returns true if the specified System.Object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {
            TaskStatement TaskStatementobj = obj as TaskStatement;

            return (TaskStatementobj == null) ? false : (this.TaskStatementID == TaskStatementobj.TaskStatementID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return TaskStatementID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<TaskStatement> GetCollection(DataTable dataItems)
        {
            List<TaskStatement> listCollection = new List<TaskStatement>();
            TaskStatement current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new TaskStatement(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a TaskStatement collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region General Methods
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddTaskStatement");
            try
            {
                SqlParameter returnParam = new SqlParameter("@newTaskStatementID", SqlDbType.BigInt);
                returnParam.Direction = ParameterDirection.Output;
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@TaskStatement", this._taskStatement));
                ExecuteNonQuery(commandWrapper);

                this._taskStatementID = (long)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }


        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void Update()
        {
            DbCommand commandWrapper = GetDbCommand("spr_UpdateTaskStatement");
            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@TaskStatementID", this._taskStatementID));
                commandWrapper.Parameters.Add(new SqlParameter("@TaskStatement", this._taskStatement));
                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {

                HandleException(ex);
            }

        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete()
        {
            DbCommand commandWrapper = GetDbCommand("spr_DeleteTaskStatement");
            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@TaskStatementID", this._taskStatementID));
                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {

                HandleException(ex);
            }

        }

        #endregion

        #region Static Methods
        public static DataTable dtTS = null;
        public static DataTable dtTSAdv = null;

         [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataTable GetTSPaged(int startRowIndex, int maximumRows)
        {
            DataTable table = ExecuteDataTable("spr_GetTaskStatementsPaged", startRowIndex, maximumRows);

            dtTS = table;
            return table;
        }

        public static List<TaskStatement> SelectTaskStatement(int startRowIndex, int maximumRows)
        {
            DataTable dt;
            List<TaskStatement> pagedTaskStatement = new List<TaskStatement>();
            DbCommand commandWrapper = GetDbCommand("spr_GetTaskStatementsPaged");
            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@startRowIndex", startRowIndex));
                commandWrapper.Parameters.Add(new SqlParameter("@maximumRows", maximumRows));

                dt = ExecuteDataTable(commandWrapper);
                pagedTaskStatement = GetCollection(dt);

            }
            catch (Exception ex)
            {

                HandleException(ex);

            }

            return pagedTaskStatement;

        }

        public static int SelectTaskStatementTotalCount(int startRowIndex, int maximumRows)
        {

            int count = (int)ExecuteScalar("spr_GetTaskStatementsTotalCount");
            return count;
        }


        public  void AddTaskStatement(string taskStatementText)
        {
            TaskStatement currentTaskStatement = new TaskStatement();
            currentTaskStatement.TaskStatementID = -1;
            currentTaskStatement.TaskStatementText = taskStatementText;
            currentTaskStatement.Add();
        }


        public  void UpdateTaskStatement(long taskStatementID, string taskStatementText)
        {
            TaskStatement currentTaskStatement = new TaskStatement(taskStatementID);
            currentTaskStatement.TaskStatementID = taskStatementID;
            currentTaskStatement.TaskStatementText = taskStatementText;

            currentTaskStatement.Update();
        }


        public  void DeleteTaskStatement(long taskStatementID)
        {
            TaskStatement currentTaskStatement = new TaskStatement(taskStatementID);
            currentTaskStatement.Delete();
        }


        public static DataTable SearchTaskStatement(long? TaskStatementID = null, int? SeriesID = null, int? GradeID = null, string Keyword="")
        {
            DbCommand commandWrapper = GetDbCommand("spr_SearchTaskStatement");
            DataTable dt = new DataTable();
           
            try
            {
                const int defaultValue = -1;
                SetParameter<long>(commandWrapper, "@TaskStatementID", TaskStatementID, defaultValue);
                SetParameter<int>(commandWrapper, "@SeriesID", SeriesID, defaultValue);
                SetParameter<int>(commandWrapper, "@GradeID", GradeID, defaultValue);
                if (string.IsNullOrEmpty(Keyword))
                {  Keyword = string.Empty; }

                SetParameter<string>(commandWrapper, "@Keyword", Keyword, string.Empty);

                dt = ExecuteDataTable(commandWrapper);

                dtTSAdv = dt;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return dt;
        }
        #endregion

    }
}

