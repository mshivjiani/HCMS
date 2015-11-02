using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
using HCMS.Business.Factor;

namespace HCMS.Business.PD
{
    /// <summary>
    /// PositionFactor Business Object
    /// </summary>
    [Serializable]
    public class PositionFactor : BusinessBase
    {
        #region Private Members

        private long _positionDescriptionID = -1;
        private int _factorID = -1;
        private int _factorLevel = -1;
        private int _point = -1;
        private string _language = string.Empty;
        private string _factorJustification = string.Empty;
        private int _factorFormatTypeID = -1;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;
        private int _positionFactorID = -1;
        private string _factorTitle = string.Empty;
        private int _levelID = -1;
        private string _recommendationNote = string.Empty;
        private bool? _reviewed = null;
        #endregion

        #region Properties

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

        public int FactorID
        {
            get
            {
                return this._factorID;
            }
            set
            {
                this._factorID = value;
            }
        }

        public int FactorLevel
        {
            get
            {
                return this._factorLevel;
            }
            set
            {
                this._factorLevel = value;
            }
        }

        public int Point
        {
            get
            {
                return this._point;
            }
            set
            {
                this._point = value;
            }
        }

        public string Language
        {
            get
            {
                return this._language;
            }
            set
            {
                this._language = value;
            }
        }

        public string FactorJustification
        {
            get
            {
                return this._factorJustification;
            }
            set
            {
                this._factorJustification = value;
            }
        }

        public int FactorFormatTypeID
        {
            get
            {
                return this._factorFormatTypeID;
            }
            set
            {
                this._factorFormatTypeID = value;
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

        public int PositionFactorID
        {
            get
            {
                return this._positionFactorID;
            }
            set
            {
                this._positionFactorID = value;
            }
        }
        public string FactorTitle
        {
            get
            {
                return this._factorTitle;
            }
            set
            {
                this._factorTitle = value;
            }
        }
        public int LevelID
        {
            get
            {
                return this._levelID;
            }
            set
            {
                this._levelID = value;
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
                this._recommendationNote = value;
            }
        }
        public bool? Reviewed
        {
            get { return this._reviewed; }
            set { this._reviewed = value; }
        }
        #endregion

        #region Constructors

        public PositionFactor()
        {
            // Empty Constructor
        }

        public PositionFactor(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {//by PositionFactorID
                returnTable = ExecuteDataTable("spr_GetPositionFactorByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        public PositionFactor(long positionDescriptionID, int factorID, int factorFormatTypeID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionFactorByPositionDescriptionIDFactorIDFormatTypeID", positionDescriptionID, factorID, factorFormatTypeID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        public PositionFactor(DataRow singleRowData)
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
            this._positionFactorID = (int)returnRow["PositionFactorID"];
            this._positionDescriptionID = (long)returnRow["PositionDescriptionID"];
            // In case of Narrative Factor Format, level and point will be null
            this._factorID = (int)returnRow["FactorID"];
            if (returnRow["FactorLevel"] != DBNull.Value)
            {
                this._factorLevel = (int)returnRow["FactorLevel"];
            }
            if (returnRow["Point"] != DBNull.Value)
            {
                this._point = (int)returnRow["Point"];
            }
            this._language = returnRow["Language"].ToString();

            if (returnRow["FactorJustification"] != DBNull.Value)
                this._factorJustification = returnRow["FactorJustification"].ToString();
            this._factorFormatTypeID = (int)returnRow["FactorFormatTypeID"];
            this._createdByID = (int)returnRow["CreatedByID"];
            this._createDate = (DateTime)returnRow["CreateDate"];
            this._updatedByID = (int)returnRow["UpdatedByID"];
            this._updateDate = (DateTime)returnRow["UpdateDate"];



            DataColumnCollection columns = returnRow.Table.Columns;



            if (columns.Contains("FactorTitle"))
            {
                this._factorTitle = returnRow["FactorTitle"].ToString();
            }
            if (columns.Contains("LevelID"))
            {
                if (returnRow["LevelID"] != DBNull.Value)
                {
                    this._levelID = (int)returnRow["LevelID"];
                }
            }

            if (columns.Contains("RecommendationNote"))
            {
                if (returnRow["RecommendationNote"] != DBNull.Value)
                    this._recommendationNote = returnRow["RecommendationNote"].ToString();
            }
            if (columns.Contains("Reviewed"))
            {

                if (returnRow["Reviewed"] != DBNull.Value)
                    this._reviewed = (bool?)returnRow["Reviewed"];
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
            return "PositionFactorID:" + PositionFactorID.ToString();
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
            PositionFactor PositionFactorobj = obj as PositionFactor;

            return (PositionFactorobj == null) ? false : (this.PositionFactorID == PositionFactorobj.PositionFactorID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return PositionFactorID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddPositionFactor");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newPositionFactorID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new PositionFactorID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@factorID", this._factorID));
                commandWrapper.Parameters.Add(new SqlParameter("@factorLevel", this._factorLevel));
                commandWrapper.Parameters.Add(new SqlParameter("@point", this._point));
                commandWrapper.Parameters.Add(new SqlParameter("@language", this._language.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@factorJustification", this._factorJustification));
                commandWrapper.Parameters.Add(new SqlParameter("@factorFormatTypeID", this._factorFormatTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));

                ExecuteNonQuery(commandWrapper);

                this._positionFactorID = (int)returnParam.Value;
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
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionFactor");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@factorID", this._factorID));
                    commandWrapper.Parameters.Add(new SqlParameter("@factorLevel", this._factorLevel));
                    commandWrapper.Parameters.Add(new SqlParameter("@point", this._point));
                    commandWrapper.Parameters.Add(new SqlParameter("@language", this._language.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@factorJustification", this._factorJustification));
                    commandWrapper.Parameters.Add(new SqlParameter("@factorFormatTypeID", this._factorFormatTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@positionFactorID", this._positionFactorID));
                    commandWrapper.Parameters.Add(new SqlParameter("@recommendationNote", this._recommendationNote));
                    commandWrapper.Parameters.Add(new SqlParameter("@reviewed", this._reviewed));


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
            if (base.ValidateKeyField(this._positionFactorID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeletePositionFactor", this._positionFactorID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static List<PositionFactor> GetCollection(DataTable dataItems)
        {
            List<PositionFactor> listCollection = new List<PositionFactor>();
            PositionFactor current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PositionFactor(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PositionFactor collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        public List<FactorRevisionNote> GetFactorRevisionNote()
        {
            List<FactorRevisionNote> childDataCollection = null;
            if (base.ValidateKeyField(this._positionFactorID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetFactorRevisionNoteByPositionFactorID", this._positionFactorID);

                    // fill collection list
                    childDataCollection = FactorRevisionNote.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        #endregion

        #region Other Methods
        public DataTable GetPositionFactorComparision()
        {
            DataTable returnTable = null;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionFactorComparision", this._positionFactorID, (int)PDStatus.Draft);

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return returnTable;
        }
        #endregion
        public void UpdateRecommendation()
        {
            if (base.ValidateKeyField(this._positionFactorID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionFactorRecommendation");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionFactorID", this._positionFactorID));
                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }
    }
}

