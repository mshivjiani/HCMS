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
namespace HCMS.Business.PD
{
    /// <summary>
    /// WorkflowNote Business Object
    /// </summary>
    [Serializable]
    public class WorkflowNote : BusinessBase
    {
        #region Private Members

        private int _workflowNoteID = -1;
        private int _workflowRecID = -1;
        private string _note = string.Empty;
        private int _noteStatusID = -1;
        private string _noteStatus = string.Empty;
        private int _createdByID = -1;
        private string _createdBy = String.Empty;
        private DateTime _createDate = DateTime.MinValue;
        private int _updatedByID = -1;
        private string _updatedBy = String.Empty;
        private DateTime _updateDate = DateTime.MinValue;
        private string _updateNote = string.Empty;

        #endregion

        #region Properties

        public int WorkflowNoteID
        {
            get
            {
                return this._workflowNoteID;
            }
            set
            {
                this._workflowNoteID = value;
            }
        }

        public int WorkflowRecID
        {
            get
            {
                return this._workflowRecID;
            }
            set
            {
                this._workflowRecID = value;
            }
        }

        public string Note
        {
            get
            {
                return this._note;
            }
            set
            {
                this._note = value;
            }
        }

        public int NoteStatusID
        {
            get
            {
                return this._noteStatusID;
            }
            set
            {
                this._noteStatusID = value;
            }
        }

        public string NoteStatus
        {
            get
            {
                return this._noteStatus;
            }
            set
            {
                this._noteStatus = value;
            }
        }

        public int CreatedByID
        {
            get
            {
                return this._createdByID;
            }
            set
            {
                this._createdByID = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return this._createdBy;
            }
            set
            {
                this._createdBy = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return this._createDate;
            }
            set
            {
                this._createDate = value;
            }
        }

        public int UpdatedByID
        {
            get
            {
                return this._updatedByID;
            }
            set
            {
                this._updatedByID = value;
            }
        }

        public string UpdatedBy
        {
            get
            {
                return this._updatedBy;
            }
            set
            {
                this._updatedBy = value;
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                return this._updateDate;
            }
            set
            {
                this._updateDate = value;
            }
        }

        public string UpdateNote
        {
            get
            {
                return this._updateNote;
            }
            set
            {
                this._updateNote = value;
            }
        }

        #endregion

        #region Constructors

        public WorkflowNote()
        {
            // Empty Constructor
        }

        public WorkflowNote(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetWorkflowNoteByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public WorkflowNote(DataRow singleRowData)
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
            this._workflowNoteID = (int)returnRow["WorkflowNoteID"];
            this._workflowRecID = (int)returnRow["WorkflowRecID"];
            this._note = returnRow["Note"].ToString();
            this._noteStatusID = (int)returnRow["NoteStatusID"];
            this._noteStatus = returnRow["NoteStatus"].ToString();
            this._createdByID = (int)returnRow["CreatedByID"];
            this._createdBy = returnRow["CreatedBy"].ToString();
            this._createDate = (DateTime)returnRow["CreateDate"];
            this._updatedByID = (int)returnRow["UpdatedByID"];
            this._updatedBy = returnRow["UpdatedBy"].ToString();
            this._updateDate = (DateTime)returnRow["UpdateDate"];

            if (returnRow["UpdateNote"] != DBNull.Value)
                this._updateNote = returnRow["UpdateNote"].ToString();
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
            return "WorkflowNoteID:" + WorkflowNoteID.ToString();
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
            WorkflowNote WorkflowNoteobj = obj as WorkflowNote;

            return (WorkflowNoteobj == null) ? false : (this.WorkflowNoteID == WorkflowNoteobj.WorkflowNoteID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return WorkflowNoteID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddWorkflowNote");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newWorkflowNoteID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new WorkflowNoteID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@workflowRecID", this._workflowRecID));
                commandWrapper.Parameters.Add(new SqlParameter("@note", this._note.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@noteStatusID", this._noteStatusID));
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));
                commandWrapper.Parameters.Add(new SqlParameter("@updateNote", this._updateNote));

                ExecuteNonQuery(commandWrapper);

                this._workflowNoteID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._workflowNoteID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateWorkflowNote");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@workflowNoteID", this._workflowNoteID));
                    commandWrapper.Parameters.Add(new SqlParameter("@workflowRecID", this._workflowRecID));
                    commandWrapper.Parameters.Add(new SqlParameter("@note", this._note.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@noteStatusID", this._noteStatusID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateNote", this._updateNote));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void Delete()
        {
            if (base.ValidateKeyField(this._workflowNoteID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteWorkflowNote", this._workflowNoteID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static List<WorkflowNote> GetCollection(DataTable dataItems)
        {
            List<WorkflowNote> listCollection = new List<WorkflowNote>();
            WorkflowNote current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new WorkflowNote(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a WorkflowNote collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

        public static List<WorkflowNote> GetByWorkflowRecordID(int workflowRecordID)
        {
            List<WorkflowNote> list = null;

            DbCommand commandWrapper = GetDbCommand("spr_GetWorkflowNoteByWorkflowRecID");

            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@workflowRecID", workflowRecordID));

                DataTable table = ExecuteDataTable(commandWrapper);

                list = WorkflowNote.GetCollection(table);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }

        /// <summary>
        /// NOTE: DataSet contains extra information comparing to WorkflowNote object
        /// </summary>
        /// <param name="positionDescriptionID">Position Description ID</param>
        /// <returns>DataSet</returns>
        public static DataSet GetByPositionDescriptionID(long positionDescriptionID)
        {
            DataSet dataSet = new DataSet();

            try
            {
                object[] parameters = new object[]
                {
                    positionDescriptionID
                };

                dataSet = BusinessBase.ExecuteDataSet("dbo.spr_GetWorkflowNoteByPositionDescriptionID", parameters);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return dataSet;
        }
        /// <summary>
        /// Returns a list of WorkflowNote objects
        /// </summary>
        /// <param name="positionDescriptionID">Position Description ID</param>
        /// <param name="dummy">Not used. Any value would be fine. This parameter is uses solely to resolve function signature ambiguity (same function  name, same number of parameters and parameter type)</param>
        /// <returns>a list of WorkflowNote objects</returns>
        public static List<WorkflowNote> GetByPositionDescriptionID(long positionDescriptionID, bool dummy)
        {
            List<WorkflowNote> list = null;

            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_GetWorkflowNoteByPositionDescriptionID");
                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", positionDescriptionID));

                DataTable table = ExecuteDataTable(commandWrapper);

                list = WorkflowNote.GetCollection(table);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }


    }
}

