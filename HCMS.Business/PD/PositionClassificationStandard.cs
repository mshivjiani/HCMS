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

namespace HCMS.Business.PD
{
    /// <summary>
    /// PositionClassificationStandard Business Object
    /// </summary>
    [Serializable]
    public class PositionClassificationStandard : BusinessBase
    {
        #region Private Members

        private long _positionClassificationStandardID = -1;
        private long _positionDescriptionID = -1;
        private int _classificationSourceID = -1;
        private string _classificationSourceName = string.Empty;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;

        private string _classificationSourceTitle = string.Empty;
        private int _factorformatTypeID = -1;
        private string _factorformatType = string.Empty;
        private string _classificationSourceTitleFormat = string.Empty;
        #endregion

        #region Properties

        public long PositionClassificationStandardID
        {
            get
            {
                return this._positionClassificationStandardID;
            }
            set
            {
                this._positionClassificationStandardID = value;
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

        public int ClassificationSourceID
        {
            get
            {
                return this._classificationSourceID;
            }
            set
            {
                this._classificationSourceID = value;
            }
        }

        public string ClassificationSourceName
        {
            get
            {
                return this._classificationSourceName;
            }
            set
            {
                this._classificationSourceName = value;
            }
        }
        public int FactorFormatTypeID
        {
            get
            {
                return this._factorformatTypeID;
            }
            set
            {
                this._factorformatTypeID = value;
            }
        }
        public string ClassificationSourceTitle
        {
            get
            {
                return this._classificationSourceTitle;
            }
            set
            {
                this._classificationSourceTitle = value;
            }
        }
        public string ClassificationSourceTitleFormat
        {
            get
            {
                if ((this._factorformatType.Length > 0) && (this.ClassificationSourceTitle.Length > 0))
                {
                    this._classificationSourceTitleFormat = string.Format("{0}-{1}", this._factorformatType, this._classificationSourceTitleFormat);
                }
                return this._classificationSourceTitleFormat;
            }
        }
        public string FactorFormatType
        {
            get
            {
                return this._factorformatType;
            }
            set
            {
                this._factorformatType = value;
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

        public bool? IsRecommended
        {
            get
            {

                bool ret = false;
                DbCommand commandWrapper = GetDbCommand("spr_IsRecommendedClassificationSource");
                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@ClassificationStandardSourceID", this._classificationSourceID));
                    SqlParameter returnParam = new SqlParameter("@ret", SqlDbType.Bit);
                    returnParam.Direction = ParameterDirection.Output;
                    commandWrapper.Parameters.Add(returnParam);
                    ExecuteNonQuery(commandWrapper);
                    ret = (bool)returnParam.Value;

                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
                return ret;
            }
        }
        #endregion

        #region Constructors

        public PositionClassificationStandard()
        {
            // Empty Constructor
        }

        public PositionClassificationStandard(long loadByID)
        {
            // Load Object by PositionClassificationStandardID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionClassificationStandardByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }


        public PositionClassificationStandard(DataRow singleRowData)
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
            this._positionClassificationStandardID = (long)returnRow["PositionClassificationStandardID"];
            this._positionDescriptionID = (long)returnRow["PositionDescriptionID"];
            this._classificationSourceID = (int)returnRow["ClassificationSourceID"];
            this._createdByID = (int)returnRow["CreatedByID"];
            this._createDate = (DateTime)returnRow["CreateDate"];

            if (returnRow["ClassificationSourceName"] != DBNull.Value)
                this._classificationSourceName = returnRow["ClassificationSourceName"].ToString();
            DataColumnCollection columns = returnRow.Table.Columns;
            if (columns.Contains("ClassificationSourceTitle"))
            {
                this._classificationSourceTitle = returnRow["ClassificationSourceTitle"].ToString();

            }
            if (columns.Contains("FactorFormatTypeID"))
            {
                this._factorformatTypeID = (int)returnRow["FactorFormatTypeID"];
            }

            if (columns.Contains("FactorFormatType"))
            {
                this._factorformatType = returnRow["FactorFormatType"].ToString();
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
            return "PositionClassificationStandardID:" + PositionClassificationStandardID.ToString();
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
            PositionClassificationStandard PositionClassificationStandardobj = obj as PositionClassificationStandard;

            return (PositionClassificationStandardobj == null) ? false : (this.PositionClassificationStandardID == PositionClassificationStandardobj.PositionClassificationStandardID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return PositionClassificationStandardID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddPositionClassificationStandard");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newPositionClassificationStandardID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new PositionClassificationStandardID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@classificationSourceID", this._classificationSourceID));
                commandWrapper.Parameters.Add(new SqlParameter("@classificationSourceName", this._classificationSourceName));
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));

                ExecuteNonQuery(commandWrapper);

                this._positionClassificationStandardID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._positionClassificationStandardID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionClassificationStandard");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionClassificationStandardID", this._positionClassificationStandardID));
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@classificationSourceID", this._classificationSourceID));
                    commandWrapper.Parameters.Add(new SqlParameter("@classificationSourceName", this._classificationSourceName));
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
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
            if (base.ValidateKeyField(this._positionClassificationStandardID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeletePositionClassificationStandard", this._positionClassificationStandardID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion
        #region Other Methods
        public void Delete(int factorformatTypeID)
        {
            if (base.ValidateKeyField(this._positionClassificationStandardID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeletePositionClassificationStandardByFactorFormatTypeID", this._positionClassificationStandardID, this._positionDescriptionID, factorformatTypeID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

        }

        #endregion
        #region Collection Helper Methods

        internal static List<PositionClassificationStandard> GetCollection(DataTable dataItems)
        {
            List<PositionClassificationStandard> listCollection = new List<PositionClassificationStandard>();
            PositionClassificationStandard current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PositionClassificationStandard(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PositionClassificationStandard collection from a null data table.");

            return listCollection;
        }

        #endregion


    }
}

