using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
namespace HCMS.Business.PD
{
    [Serializable]
    public class PositionFactorLog : BusinessBase
    {

        #region Private Members

        private long _positionfactorLogID = -1;
        private long _positionDescriptionID = -1;
        private int _positionFactorID = -1;
        private enumFactorFormatType _factorFormatTypeID = enumFactorFormatType.None;
        private int _factorID = -1;
        private int _factorLevelID = -1;
        private int _point = -1;
        private string _language = string.Empty;
        private string _justification = string.Empty;
        private string _recommendationNote = string.Empty;
        private PDStatus _workflowStatusID = PDStatus.Null;
        private DateTime _workflowCreateDate = DateTime.MinValue;
        private int _workflowCreatedByID = -1;
        #endregion

        #region Properties

        public long PositionFactorLogID
        {
            get { return this._positionfactorLogID; }
            set { this._positionfactorLogID = value; }
        }
        public long PositionDescriptionID
        {
            get { return this._positionDescriptionID; }
            set { this._positionDescriptionID = value; }
        }

        public int PositionFactorID
        {
            get { return this._positionFactorID; }
            set
            {
                this._positionFactorID = value;
            }
        }

        public enumFactorFormatType FactorFormatTypeID
        {
            get { return this._factorFormatTypeID; }
            set { this._factorFormatTypeID = value; }
        }
        public int FactorID
        {
            get { return this._factorID; }
            set { this._factorID = value; }
        }
        public int FactorLevelID
        {
            get { return this._factorLevelID; }
            set { this._factorLevelID = value; }
        }

        public int Point
        {
            get { return this._point; }
            set
            {
                this._point = value;
            }
        }

        public string Language
        {
            get { return this._language; }
            set
            {
                this._language = value;
            }
        }
        public string Justification
        {
            get { return this._justification; }
            set
            {
                this._justification = value;
            }
        }

        public string RecommendationNote
        {
            get
            {
                return this._recommendationNote;
            }
            set
            {
                this._recommendationNote = value; ;
            }
        }

        public PDStatus WorkflowStatusID
        {
            get { return this._workflowStatusID; }
            set { this._workflowStatusID = value; }
        }

        public DateTime WorkflowCreateDate
        {
            get { return this._workflowCreateDate; }
            set { this._workflowCreateDate = value; }
        }
        public int WorkflowCreatedByID
        {
            get { return this._workflowCreatedByID; }
            set
            {
                this._workflowCreatedByID = value;
            }
        }
        #endregion

        #region Constructors

        public PositionFactorLog()
        {
            //Empty Constructor
        }
        public PositionFactorLog(int loadByID, enumIDType idtype)
        {
            // Load Object by ID
            DataTable returnTable = null;

            try
            {//by PositionFactorID
                if (idtype == enumIDType.PositionFactorLogID)
                {
                    returnTable = ExecuteDataTable("spr_GetPositionFactorLogByID", loadByID);
                }
                else if (idtype == enumIDType.PositionFactorID)
                {
                    returnTable = ExecuteDataTable("spr_GetPositionFactorLogByPositionFactorID", PositionFactorID);

                }
                else
                {
                    throw new ApplicationException("You can not create PositionFactorLog object because the ID Type is not supported");
                }
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }
        
        public PositionFactorLog(DataRow singleRowData)
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

        #region  Constructor Helper Methods
        private void loadData(DataTable returnTable)
        {
            if (returnTable != null)
            {
                if (returnTable.Rows.Count > 0)
                {
                    DataRow returnRow = returnTable.Rows[0];

                    this.FillObjectFromRowData(returnRow);
                }
            }
        }
        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            this._positionfactorLogID = (long)returnRow["PositionFactorLogID"];
            this._positionDescriptionID = (long)returnRow["PositionDescriptionID"];
            this._positionFactorID = (int)returnRow["PositionFactorID"];
            this._factorFormatTypeID = (enumFactorFormatType)returnRow["FactorFormatTypeID"];
            this._factorLevelID = (int)returnRow["FactorLevelID"];
            this._point = (int)returnRow["Point"];
            this._language = returnRow["Language"].ToString();
            this._justification = returnRow["Justification"].ToString();
            this._recommendationNote = returnRow["RecommendationNote"].ToString();
            this._workflowStatusID = (PDStatus)returnRow["WorkflowStatusID"];
            this._workflowCreateDate = (DateTime)returnRow["WorkflowCreateDate"];
            this._workflowCreatedByID = (int)returnRow["WorkflowCreatedByID"];
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
            return "PositionFactorLogID:" + PositionFactorLogID.ToString();
        }
        #endregion

        #region CompareMethods

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current object.</param>
        /// <returns>Returns true if the specified System.Object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {
            PositionFactorLog PositionFactorLogobj = obj as PositionFactorLog;

            return (PositionFactorLogobj == null) ? false : (this.PositionFactorLogID == PositionFactorLogobj.PositionFactorLogID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return PositionFactorLogID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddPositionFactorLog");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newPositionFactorLogID", SqlDbType.BigInt);
                returnParam.Direction = ParameterDirection.Output;

                // get the new PositionFactorID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@PositionFactorID", this._positionFactorID));
                commandWrapper.Parameters.Add(new SqlParameter("@FactorFormatTypeID", (int)this._factorFormatTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@FactorID", this._factorID));
                commandWrapper.Parameters.Add(new SqlParameter("@FactorLevelID", this._factorLevelID));
                commandWrapper.Parameters.Add(new SqlParameter("@Point", this._point));
                commandWrapper.Parameters.Add(new SqlParameter("@Language", this._language.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@Justification", this._justification));
                commandWrapper.Parameters.Add(new SqlParameter("@RecommendationNote", this._recommendationNote));
                commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusID", (int)this._workflowStatusID));
                commandWrapper.Parameters.Add(new SqlParameter("@WorkflowCreatedByID", this.WorkflowCreatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@WorkflowCreateDate", this._workflowCreateDate));


                ExecuteNonQuery(commandWrapper);

                this._positionfactorLogID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._positionFactorID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionFactorLog");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionFactorLogID", this._positionfactorLogID));
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionFactorID", this._positionFactorID));
                    commandWrapper.Parameters.Add(new SqlParameter("@FactorFormatTypeID", (int)this._factorFormatTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@FactorID", this._factorID));
                    commandWrapper.Parameters.Add(new SqlParameter("@FactorLevelID", this._factorLevelID));
                    commandWrapper.Parameters.Add(new SqlParameter("@Point", this._point));
                    commandWrapper.Parameters.Add(new SqlParameter("@Language", this._language.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@Justification", this._justification));
                    commandWrapper.Parameters.Add(new SqlParameter("@RecommendationNote", this._recommendationNote));
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusID", (int)this._workflowStatusID));
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowCreatedByID", this.WorkflowCreatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowCreateDate", this._workflowCreateDate));



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
            if (base.ValidateKeyField(this._positionfactorLogID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeletePositionFactorLog", this._positionfactorLogID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }
        #endregion

        #region Collection Helper Methods

        internal static List<PositionFactorLog> GetCollection(DataTable dataItems)
        {
            List<PositionFactorLog> listCollection = new List<PositionFactorLog>();
            PositionFactorLog current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PositionFactorLog(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PositionFactorLog collection from a null data table.");

            return listCollection;
        }

        #endregion

    }


}
