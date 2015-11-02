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

namespace HCMS.Business.LogObjects
{
    /// <summary>
    /// PositionDutyLog Business Object
    /// </summary>
    [Serializable]
    public class PositionDutyLog : BusinessBase
    {
        #region Private Members

        private int _dutyLogID = -1;
        private int _dutyID = -1;
        private long _positionDescriptionID = -1;
        private int _percentageOfTime = -1;
        private string _dutyDescription = string.Empty;
        private int _dutyTypeID = -1;
        private string _dutyType = string.Empty;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;
        private int _workflowStatusID = -1;
        private DateTime _logRecCreateDate = DateTime.MinValue;
        private int _logRecCreatedByID = -1;

        #endregion

        #region Properties

        public int DutyLogID
        {
            get
            {
                return this._dutyLogID;
            }
            set
            {
                this._dutyLogID = value;
            }
        }

        public int DutyID
        {
            get
            {
                return this._dutyID;
            }
            set
            {
                this._dutyID = value;
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

        public int PercentageOfTime
        {
            get
            {
                return this._percentageOfTime;
            }
            set
            {
                this._percentageOfTime = value;
            }
        }

        public string DutyDescription
        {
            get
            {
                return this._dutyDescription;
            }
            set
            {
                this._dutyDescription = value;
            }
        }

        public int DutyTypeID
        {
            get
            {
                return this._dutyTypeID;
            }
            set
            {
                this._dutyTypeID = value;
            }
        }

        public string DutyType
        {
            get 
            { 
                return this._dutyType; 
            }
            set 
            { 
                this._dutyType = value; 
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

        public DateTime LogRecCreateDate
        {
            get
            {
                return this._logRecCreateDate;
            }
            set
            {
                this._logRecCreateDate = value;
            }
        }

        public int LogRecCreatedByID
        {
            get
            {
                return this._logRecCreatedByID;
            }
            set
            {
                this._logRecCreatedByID = value;
            }
        }

        #endregion

        #region Constructors

        public PositionDutyLog()
        {
            // Empty Constructor
        }

        public PositionDutyLog(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionDutyLogByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public PositionDutyLog(int loadByDutyID, int workflowStatusID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionDutyLogByDutyID", loadByDutyID, workflowStatusID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        
        public PositionDutyLog(DataRow singleRowData)
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
            this._dutyLogID = (int)returnRow["DutyLogID"];
            this._dutyID = (int)returnRow["DutyID"];
            this._positionDescriptionID = (long)returnRow["PositionDescriptionID"];

            if (returnRow["PercentageOfTime"] != DBNull.Value)
                this._percentageOfTime = (int)returnRow["PercentageOfTime"];

            this._dutyDescription = returnRow["DutyDescription"].ToString();
            this._dutyTypeID = (int)returnRow["DutyTypeID"];
            this._dutyType = returnRow["DutyType"].ToString();
            this._createdByID = (int)returnRow["CreatedByID"];
            this._createDate = (DateTime)returnRow["CreateDate"];
            this._updatedByID = (int)returnRow["UpdatedByID"];
            this._updateDate = (DateTime)returnRow["UpdateDate"];

            if (returnRow["WorkflowStatusID"] != DBNull.Value)
                this._workflowStatusID = (int)returnRow["WorkflowStatusID"];


            if (returnRow["LogRecCreateDate"] != DBNull.Value)
                this._logRecCreateDate = (DateTime)returnRow["LogRecCreateDate"];


            if (returnRow["LogRecCreatedByID"] != DBNull.Value)
                this._logRecCreatedByID = (int)returnRow["LogRecCreatedByID"];

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
            return "DutyLogID:" + DutyLogID.ToString();
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
            PositionDutyLog PositionDutyLogobj = obj as PositionDutyLog;

            return (PositionDutyLogobj == null) ? false : (this.DutyLogID == PositionDutyLogobj.DutyLogID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return DutyLogID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddPositionDutyLog");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newDutyLogID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new DutyLogID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@dutyID", this._dutyID));
                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));

                if (this._percentageOfTime == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@percentageOfTime", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@percentageOfTime", this._percentageOfTime));
                commandWrapper.Parameters.Add(new SqlParameter("@dutyDescription", this._dutyDescription.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@dutyTypeID", this._dutyTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));

                if (this._workflowStatusID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@workflowStatusID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@workflowStatusID", this._workflowStatusID));

                if (this._logRecCreateDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@logRecCreateDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@logRecCreateDate", this._logRecCreateDate));

                if (this._logRecCreatedByID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@logRecCreatedByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@logRecCreatedByID", this._logRecCreatedByID));

                ExecuteNonQuery(commandWrapper);

                this._dutyLogID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._dutyLogID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionDutyLog");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@dutyLogID", this._dutyLogID));
                    commandWrapper.Parameters.Add(new SqlParameter("@dutyID", this._dutyID));
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));

                    if (this._percentageOfTime == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@percentageOfTime", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@percentageOfTime", this._percentageOfTime));
                    commandWrapper.Parameters.Add(new SqlParameter("@dutyDescription", this._dutyDescription.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@dutyTypeID", this._dutyTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));

                    if (this._workflowStatusID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@workflowStatusID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@workflowStatusID", this._workflowStatusID));

                    if (this._logRecCreateDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@logRecCreateDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@logRecCreateDate", this._logRecCreateDate));

                    if (this._logRecCreatedByID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@logRecCreatedByID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@logRecCreatedByID", this._logRecCreatedByID));

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
            if (base.ValidateKeyField(this._dutyLogID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeletePositionDutyLog", this._dutyLogID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static List<PositionDutyLog> GetCollection(DataTable dataItems)
        {
            List<PositionDutyLog> listCollection = new List<PositionDutyLog>();
            PositionDutyLog current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PositionDutyLog(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PositionDutyLog collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

        #region DutyCompetencyKSALog

        public DataTable GetDutyCompetencyKSAModifiedDuringReview()
        {
            DataTable returnTable = null;

            if (base.ValidateKeyField(this._dutyID))
            {
                try
                {
                    returnTable = ExecuteDataTable("dbo.spr_GetEditedReviewDutyQualifications", this._dutyID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return returnTable;
        }

        public List<DutyCompetencyKSALog> GetDutyCompetencyKSAAddedDuringReview()
        {
            List<DutyCompetencyKSALog> childDataCollection = null;
            if (base.ValidateKeyField(this._dutyID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("dbo.spr_GetAddedReviewDutyQualifications", this._dutyID);

                    // fill collection list
                    childDataCollection = DutyCompetencyKSALog.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<DutyCompetencyKSALog> GetDutyCompetencyKSADeletedDuringReview()
        {
            List<DutyCompetencyKSALog> childDataCollection = null;
            if (base.ValidateKeyField(this._dutyID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("dbo.spr_GetDeletedDraftDutyQualifications", this._dutyID);

                    // fill collection list
                    childDataCollection = DutyCompetencyKSALog.GetCollection(dt);
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

