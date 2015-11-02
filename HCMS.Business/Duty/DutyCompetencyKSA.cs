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

namespace HCMS.Business.Duty
{
    /// <summary>
    /// DutyCompetencyKSA Business Object
    /// </summary>
    [Serializable]
    public class DutyCompetencyKSA : BusinessBase
    {
        #region Private Members

        private int _dutyCompetencyKSAID = -1;
        private int _dutyID = -1;
        private string _competencyKSA = string.Empty;
        private string _certification = string.Empty;
        private int _qualificationTypeID = -1;
        private string _qualificationTypeName = String.Empty;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;
        private int _qualificationID = -1;
        private string _qualificationName = String.Empty;
        private long? _ksaID;

        #endregion

        #region Properties

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
        }

        public long? KSAID
        {
            get { return _ksaID; }
            set { _ksaID = value; }
        }
        #endregion

        #region Constructors

        public DutyCompetencyKSA()
        {
            // Empty Constructor
        }

        public DutyCompetencyKSA(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetDutyCompetencyKSAByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public DutyCompetencyKSA(DataRow singleRowData)
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
            if (returnRow["KSAID"] != DBNull.Value)
                this._ksaID =(long) returnRow["KSAID"];
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
            return "DutyCompetencyKSAID:" + DutyCompetencyKSAID.ToString();
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
            DutyCompetencyKSA DutyCompetencyKSAobj = obj as DutyCompetencyKSA;

            return (DutyCompetencyKSAobj == null) ? false : (this.DutyCompetencyKSAID == DutyCompetencyKSAobj.DutyCompetencyKSAID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return DutyCompetencyKSAID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddDutyCompetencyKSA");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newDutyCompetencyKSAID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new DutyCompetencyKSAID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@dutyID", this._dutyID));
                commandWrapper.Parameters.Add(new SqlParameter("@competencyKSA", this._competencyKSA));
                commandWrapper.Parameters.Add(new SqlParameter("@certification", this._certification));
                commandWrapper.Parameters.Add(new SqlParameter("@qualificationTypeID", this._qualificationTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));
                commandWrapper.Parameters.Add(new SqlParameter("@qualificationID", this._qualificationID));
                commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this._ksaID));
                ExecuteNonQuery(commandWrapper);

                this._dutyCompetencyKSAID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._dutyCompetencyKSAID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateDutyCompetencyKSA");

                try
                {
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
                    ////Issue fix for #681 - PDX: HR cannot edit a KSA associated to Major duty in Review status 
                    //// and Issue fix for #670 - PD Express: Mod to KSA will not save and KSA cannot be closed.

                    //commenting this check because if KSAID=0 following was changing it to be null.
                   
                    //if (this._ksaID > 0)


                        commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this._ksaID));
                    //else
                    //    commandWrapper.Parameters.Add(new SqlParameter("@KSAID", DBNull.Value));

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
            if (base.ValidateKeyField(this._dutyCompetencyKSAID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteDutyCompetencyKSA", this._dutyCompetencyKSAID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static List<DutyCompetencyKSA> GetCollection(DataTable dataItems)
        {
            List<DutyCompetencyKSA> listCollection = new List<DutyCompetencyKSA>();
            DutyCompetencyKSA current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new DutyCompetencyKSA(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a DutyCompetencyKSA collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

    }
}

