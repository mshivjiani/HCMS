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
using HCMS.Business.Lookups;
using HCMS.Business.Duty;

namespace HCMS.Business.PD
{
    /// <summary>
    /// PositionDuty Business Object
    /// </summary>
    [Serializable]
    public class PositionDuty : BusinessBase
    {
        #region Private Members

        private int _dutyID = -1;
        private long _positionDescriptionID = -1;
        private int _percentageOfTime = -1;
        private string _dutyDescription = string.Empty;
        private int _dutyTypeID = -1;
        private string _dutyType = String.Empty;
        private string _dutyTypeDescription = String.Empty;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;

        #endregion

        #region Properties

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
                return _dutyType;
            }
        }

        public string DutyTypeDescription
        {
            get
            {
                return _dutyTypeDescription;
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

        #endregion

        #region Constructors

        public PositionDuty()
        {
            // Empty Constructor
        }

        public PositionDuty(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionDutyByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public PositionDuty(DataRow singleRowData)
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
            this._dutyID = (int)returnRow["DutyID"];
            this._positionDescriptionID = (long)returnRow["PositionDescriptionID"];

            if (returnRow["PercentageOfTime"] != DBNull.Value)
                this._percentageOfTime = (int)returnRow["PercentageOfTime"];

            this._dutyDescription = returnRow["DutyDescription"].ToString();
            this._dutyTypeID = (int)returnRow["DutyTypeID"];
            this._dutyType = returnRow["DutyType"].ToString();
            this._dutyTypeDescription = returnRow["DutyTypeDescription"].ToString();
            this._createdByID = (int)returnRow["CreatedByID"];
            this._createDate = (DateTime)returnRow["CreateDate"];
            this._updatedByID = (int)returnRow["UpdatedByID"];
            this._updateDate = (DateTime)returnRow["UpdateDate"];
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
            return "DutyID:" + DutyID.ToString();
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
            PositionDuty PositionDutyobj = obj as PositionDuty;

            return (PositionDutyobj == null) ? false : (this.DutyID == PositionDutyobj.DutyID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return DutyID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddPositionDuty");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newDutyID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new DutyID of the record
                commandWrapper.Parameters.Add(returnParam);

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

                ExecuteNonQuery(commandWrapper);

                this._dutyID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._dutyID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionDuty");

                try
                {
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
            if (base.ValidateKeyField(this._dutyID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeletePositionDuty", this._dutyID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static List<PositionDuty> GetCollection(DataTable dataItems)
        {
            List<PositionDuty> listCollection = new List<PositionDuty>();
            PositionDuty current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PositionDuty(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PositionDuty collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        public List<DutyCompetencyKSA> GetDutyCompetencyKSA()
        {
            List<DutyCompetencyKSA> childDataCollection = null;
            if (base.ValidateKeyField(this._dutyID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetDutyCompetencyKSAByDutyID", this._dutyID);

                    // fill collection list
                    childDataCollection = DutyCompetencyKSA.GetCollection(dt);
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

