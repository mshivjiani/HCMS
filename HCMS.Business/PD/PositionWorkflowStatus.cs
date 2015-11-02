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
using HCMS.Business.PD.Collections;

namespace HCMS.Business.PD
{
    /// <summary>
    /// PositionWorkflowStatus Business Object
    /// </summary>
    [Serializable]
    public class PositionWorkflowStatus : BusinessBase
    {
        #region Private Members

        private int _workflowRecID = -1;
        private long _positionDescriptionID = -1;
        private string _agencyPositionTitle = string.Empty;
        private int _workflowStatusID = -1;
        private string _workflowStatusName = string.Empty;      
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;
        private bool _isCurrent = false;
        private int _positionDescriptionTypeID = -1;
        private long _associatedFullPD = -1;
        private int _ladderPosition = -1;

        #endregion

        #region Properties

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

        public long PositionDescriptionID
        {
            get
            {
                return this._positionDescriptionID;
            }
            set
            {
                this._positionDescriptionID = value;
            }
        }

        public string AgencyPositionTitle
        {
            get
            {
                return this._agencyPositionTitle;
            }
        }

        public int WorkflowStatusID
        {
            get
            {
                return this._workflowStatusID;
            }
            set
            {
                this._workflowStatusID = value;
            }
        }

        public string WorkflowStatusName
        {
            get
            {
                return this._workflowStatusName;
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

        public bool IsCurrent
        {
            get
            {
                return this._isCurrent;
            }
            set
            {
                this._isCurrent = value;
            }
        }



        public int PositionDescriptionTypeID
        {
            get { return this._positionDescriptionTypeID; }
        }

        public long AssociatedFullPD
        {
            get { return this._associatedFullPD; }
        }

        public int LadderPosition
        {
            get { return this._ladderPosition; }
        }
        #endregion

        #region Constructors

        public PositionWorkflowStatus()
        {
            // Empty Constructor
        }

        public PositionWorkflowStatus(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionWorkflowStatusByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public PositionWorkflowStatus(DataRow singleRowData)
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
            DataColumnCollection columns = returnRow.Table.Columns;
            this._workflowRecID = (int)returnRow["WorkflowRecID"];
            this._positionDescriptionID = (long)returnRow["PositionDescriptionID"];
            this._workflowStatusID = (int)returnRow["WorkflowStatusID"];

            if (returnRow["AgencyPositionTitle"] != DBNull.Value)
                this._agencyPositionTitle = returnRow["AgencyPositionTitle"].ToString();

            if (returnRow["WorkflowStatusName"] != DBNull.Value)
                this._workflowStatusName = returnRow["WorkflowStatusName"].ToString();

            this._createdByID = (int)returnRow["CreatedByID"];
            this._createDate = (DateTime)returnRow["CreateDate"];
            this._isCurrent = (bool)returnRow["IsCurrent"];

            if (columns.Contains("PositionDescriptionTypeID"))
            {
                if (returnRow["PositionDescriptionTypeID"] != DBNull.Value)
                    this._positionDescriptionTypeID = (int)returnRow["PositionDescriptionTypeID"];
            }
            if (columns.Contains("AssociatedFullPD"))
            {
                if(returnRow["AssociatedFullPD"] !=DBNull.Value )
                    this._associatedFullPD = (long)returnRow["AssociatedFullPD"];
            }
            if (columns.Contains("LadderPosition"))
            {
                if (returnRow["LadderPosition"] != DBNull.Value)
                    this._ladderPosition = (int)returnRow["LadderPosition"];
            }
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
            return "WorkflowRecID:" + WorkflowRecID.ToString();
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
            PositionWorkflowStatus PositionWorkflowStatusobj = obj as PositionWorkflowStatus;

            return (PositionWorkflowStatusobj == null) ? false : (this.WorkflowRecID == PositionWorkflowStatusobj.WorkflowRecID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return WorkflowRecID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            try
            {
                this.Add(null);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Add(TransactionManager currentTransaction)
        {
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_AdvancePDStatus");

                SqlParameter returnParam = new SqlParameter("@newWorkflowRecID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new WorkflowRecID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@workflowStatusID", this._workflowStatusID));
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                commandWrapper.Parameters.Add(new SqlParameter("@isCurrent", this._isCurrent));

                if (currentTransaction != null)
                    DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                else
                    ExecuteNonQuery(commandWrapper);

                this._workflowRecID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._workflowRecID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionWorkflowStatus");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@workflowRecID", this._workflowRecID));
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@workflowStatusID", this._workflowStatusID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@isCurrent", this._isCurrent));

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
            if (base.ValidateKeyField(this._workflowRecID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeletePositionWorkflowStatus", this._workflowRecID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static PositionWorkflowStatusCollection GetCollection(DataTable dataItems)
        {
            PositionWorkflowStatusCollection listCollection = new PositionWorkflowStatusCollection();
            PositionWorkflowStatus current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PositionWorkflowStatus(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PositionWorkflowStatus collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        public List<WorkflowNote> GetWorkflowNote()
        {
            List<WorkflowNote> childDataCollection = null;
            if (base.ValidateKeyField(this._workflowRecID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetWorkflowNoteByWorkflowStatusID", this._workflowRecID);

                    // fill collection list
                    childDataCollection = WorkflowNote.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        #endregion

    }
}

