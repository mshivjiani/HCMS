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
    /// DutyCompetencyKSALog Business Object
    /// </summary>
    [Serializable]
    public class DutyCompetencyKSALog : BusinessBase
    {
        #region Private Members

        private int _dutyCompetencyKSALogID = -1;
        private int _dutyCompetencyKSAID = -1;
        private long _dutyID = -1;
        private string _competencyKSA = string.Empty;
        private string _certification = string.Empty;
        private int _qualificationTypeID = -1;
        private string _qualificationTypeName = string.Empty;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;
        private int _qualificationID = -1;
        private string _qualificationName = string.Empty;
        private int _workflowStatusID = -1;
        private DateTime _logRecCreateDate = DateTime.MinValue;
        private int _logRecCreatedByID = -1;
        private long? _ksaID;

        #endregion

        #region Properties

        public int DutyCompetencyKSALogID
        {
            get
            {
                return this._dutyCompetencyKSALogID;
            }
            set
            {
                this._dutyCompetencyKSALogID = value;
            }
        }

        public int DutyCompetencyKSAID
        {
            get
            {
                return this._dutyCompetencyKSAID;
            }
            set
            {
                this._dutyCompetencyKSAID = value;
            }
        }

        public long DutyID
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

        public string CompetencyKSA
        {
            get
            {
                return this._competencyKSA;
            }
            set
            {
                this._competencyKSA = value;
            }
        }

        public string Certification
        {
            get
            {
                return this._certification;
            }
            set
            {
                this._certification = value;
            }
        }

        public int QualificationTypeID
        {
            get
            {
                return this._qualificationTypeID;
            }
            set
            {
                this._qualificationTypeID = value;
            }
        }

        public string QualificationTypeName
        {
            get
            {
                return _qualificationTypeName;
            }
            set
            {
                _qualificationTypeName = value;
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

        public int QualificationID
        {
            get
            {
                return this._qualificationID;
            }
            set
            {
                this._qualificationID = value;
            }
        }

        public string QualificationName
        {
            get
            {
                return _qualificationName;
            }
            set
            {
                _qualificationName = value;
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

        public long? KSAID
        {
            get { return _ksaID; }
            set { _ksaID = value; }
        }
        #endregion

        #region Constructors

        public DutyCompetencyKSALog()
        {
            // Empty Constructor
        }

        public DutyCompetencyKSALog(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetDutyQualificationLogByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public DutyCompetencyKSALog(int loadByCompetencyKSAID, int workflowStatusID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetDutyQualificationLogByQualificationID", loadByCompetencyKSAID, workflowStatusID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public DutyCompetencyKSALog(DataRow singleRowData)
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
            this._dutyCompetencyKSALogID = (int)returnRow["DutyCompetencyKSALogID"];
            this._dutyCompetencyKSAID = (int)returnRow["DutyCompetencyKSAID"];
            this._dutyID = (int)returnRow["DutyID"];

            if (returnRow["CompetencyKSA"] != DBNull.Value)
                this._competencyKSA = returnRow["CompetencyKSA"].ToString();

            if (returnRow["Certification"] != DBNull.Value)
                this._certification = returnRow["Certification"].ToString();
            this._qualificationTypeID = (int)returnRow["QualificationTypeID"];
            this._qualificationTypeName = returnRow["QualificationTypeName"].ToString();
            this._createdByID = (int)returnRow["CreatedByID"];
            this._createDate = (DateTime)returnRow["CreateDate"];
            this._updatedByID = (int)returnRow["UpdatedByID"];
            this._updateDate = (DateTime)returnRow["UpdateDate"];
            this._qualificationID = (int)returnRow["QualificationID"];
            this._qualificationName = returnRow["QualificationName"].ToString();

            if (returnRow["WorkflowStatusID"] != DBNull.Value)
                this._workflowStatusID = (int)returnRow["WorkflowStatusID"];


            if (returnRow["LogRecCreateDate"] != DBNull.Value)
                this._logRecCreateDate = (DateTime)returnRow["LogRecCreateDate"];


            if (returnRow["LogRecCreatedByID"] != DBNull.Value)
                this._logRecCreatedByID = (int)returnRow["LogRecCreatedByID"];

            if (returnRow["KSAID"] != DBNull.Value)
                this._ksaID = (long)returnRow["KSAID"];

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
            return "DutyCompetencyKSALogID:" + DutyCompetencyKSALogID.ToString();
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
            DutyCompetencyKSALog DutyCompetencyKSALogobj = obj as DutyCompetencyKSALog;

            return (DutyCompetencyKSALogobj == null) ? false : (this.DutyCompetencyKSALogID == DutyCompetencyKSALogobj.DutyCompetencyKSALogID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return DutyCompetencyKSALogID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddDutyQualificationLog");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newDutyCompetencyKSALogID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new PositionCompetencyKSALogID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@dutyCompetencyKSAID", this._dutyCompetencyKSAID));
                commandWrapper.Parameters.Add(new SqlParameter("@dutyID", this._dutyID));
                commandWrapper.Parameters.Add(new SqlParameter("@competencyKSA", this._competencyKSA));
                commandWrapper.Parameters.Add(new SqlParameter("@certification", this._certification));
                commandWrapper.Parameters.Add(new SqlParameter("@qualificationTypeID", this._qualificationTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));
                commandWrapper.Parameters.Add(new SqlParameter("@qualificationID", this._qualificationID));

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

                commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this._ksaID));
                ExecuteNonQuery(commandWrapper);

                this._dutyCompetencyKSALogID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._dutyCompetencyKSALogID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateDutyQualificationLog");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@dutyCompetencyKSALogID", this._dutyCompetencyKSALogID));
                    commandWrapper.Parameters.Add(new SqlParameter("@dutyCompetencyKSAID", this._dutyCompetencyKSAID));
                    commandWrapper.Parameters.Add(new SqlParameter("@dutyID", this._dutyID));
                    commandWrapper.Parameters.Add(new SqlParameter("@competencyKSA", this._competencyKSA));
                    commandWrapper.Parameters.Add(new SqlParameter("@certification", this._certification));
                    commandWrapper.Parameters.Add(new SqlParameter("@qualificationTypeID", this._qualificationTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@qualificationID", this._qualificationID));

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

                    commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this._ksaID));
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
            if (base.ValidateKeyField(this._dutyCompetencyKSALogID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteDutyQualificationLog", this._dutyCompetencyKSALogID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static List<DutyCompetencyKSALog> GetCollection(DataTable dataItems)
        {
            List<DutyCompetencyKSALog> listCollection = new List<DutyCompetencyKSALog>();
            DutyCompetencyKSALog current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new DutyCompetencyKSALog(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a DutyCompetencyKSALog collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

    }
}

