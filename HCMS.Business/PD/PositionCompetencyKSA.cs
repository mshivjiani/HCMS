
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
using HCMS.Business.Common;
using HCMS.Business.JQ;

namespace HCMS.Business.PD
{
    /// <summary>
    /// PositionCompetencyKSA Business Object
    /// </summary>
    [Serializable]
    public class PositionCompetencyKSA : BusinessBase
    {
        #region Private Members

        private int _competencyKSAID = -1;
        private long _positionDescriptionID = -1;
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
        private int? _associatedPDDutyID;

        #endregion

        #region Properties

        public int CompetencyKSAID
        {
            get
            {
                return this._competencyKSAID;
            }
            set
            {
                this._competencyKSAID = value;
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

        public int? AssociatedPDDutyID
        {
            get { return _associatedPDDutyID; }
            set { _associatedPDDutyID = value; }
        }
        #endregion

        #region Constructors

        public PositionCompetencyKSA()
        {
            // Empty Constructor
        }

        public PositionCompetencyKSA(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionCompetencyKSAByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public PositionCompetencyKSA(DataRow singleRowData)
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
            this._competencyKSAID = (int)returnRow["CompetencyKSAID"];
            this._positionDescriptionID = (long)returnRow["PositionDescriptionID"];

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
                this._ksaID = (long)returnRow["KSAID"];
            if (returnRow["AssociatedPDDutyID"] != DBNull.Value)
                this._associatedPDDutyID = (int)returnRow["AssociatedPDDutyID"];
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
            return "CompetencyKSAID:" + CompetencyKSAID.ToString();
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
            PositionCompetencyKSA PositionCompetencyKSAobj = obj as PositionCompetencyKSA;

            return (PositionCompetencyKSAobj == null) ? false : (this.CompetencyKSAID == PositionCompetencyKSAobj.CompetencyKSAID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return CompetencyKSAID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddPositionCompetencyKSA");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newCompetencyKSAID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new CompetencyKSAID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@competencyKSA", this._competencyKSA));
                commandWrapper.Parameters.Add(new SqlParameter("@certification", this._certification));
                commandWrapper.Parameters.Add(new SqlParameter("@qualificationTypeID", this._qualificationTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));
                commandWrapper.Parameters.Add(new SqlParameter("@qualificationID", this._qualificationID));
                commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this._ksaID));
                if (this._associatedPDDutyID == null)
                    commandWrapper.Parameters.Add(new SqlParameter("@AssociatedPDDutyID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@AssociatedPDDutyID", this._associatedPDDutyID));


                ExecuteNonQuery(commandWrapper);

                this._competencyKSAID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._competencyKSAID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionCompetencyKSA");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@competencyKSAID", this._competencyKSAID));
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@competencyKSA", this._competencyKSA));
                    commandWrapper.Parameters.Add(new SqlParameter("@certification", this._certification));
                    commandWrapper.Parameters.Add(new SqlParameter("@qualificationTypeID", this._qualificationTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@qualificationID", this._qualificationID));
                    commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this._ksaID));
                    if (this._associatedPDDutyID == null)
                        commandWrapper.Parameters.Add(new SqlParameter("@AssociatedPDDutyID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@AssociatedPDDutyID", this._associatedPDDutyID));

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
            if (base.ValidateKeyField(this._competencyKSAID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeletePositionCompetencyKSA", this._competencyKSAID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region PDCompetencyKSAFactor CRUD     

        public void AddPDCompetencyKSAFactor(PositionCompetencyKSA positionCompetencyKSA, JQFactor jqFactor)
        {
           
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();
                DbCommand commandWrapper = GetDbCommand("spr_AddPositionCompetencyKSAFactor");

                try
                {
                    
                    
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", positionCompetencyKSA.PositionDescriptionID));

                    if (positionCompetencyKSA.CompetencyKSA == null)
                        commandWrapper.Parameters.Add(new SqlParameter("@competencyKSA", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@competencyKSA", positionCompetencyKSA.CompetencyKSA));

                    if (positionCompetencyKSA.Certification == null)
                        commandWrapper.Parameters.Add(new SqlParameter("@certification", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@certification", positionCompetencyKSA.Certification));

                    if (positionCompetencyKSA.QualificationID < 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@qualificationID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@qualificationID", positionCompetencyKSA.QualificationID));

                    if (positionCompetencyKSA.QualificationTypeID < 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@qualificationTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@qualificationTypeID", positionCompetencyKSA.QualificationTypeID));

                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", positionCompetencyKSA.CreatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createDate", positionCompetencyKSA.CreateDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", positionCompetencyKSA.UpdatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", positionCompetencyKSA.UpdateDate));               

                    if (positionCompetencyKSA.AssociatedPDDutyID == null)
                        commandWrapper.Parameters.Add(new SqlParameter("@AssociatedPDDutyID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@AssociatedPDDutyID", positionCompetencyKSA.AssociatedPDDutyID));

                    if (jqFactor.JQFactorTypeID < 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@jQFactorTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@jQFactorTypeID", jqFactor.JQFactorTypeID));

                    if (jqFactor.KSAID < 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@KSAID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@KSAID", jqFactor.KSAID));

                    commandWrapper.Parameters.Add(new SqlParameter("@isSF", jqFactor.IsSF));

                    if (jqFactor.JQID < 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@jQID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@jQID", jqFactor.JQID));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }

                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    currentTransaction.Rollback();
                    HandleException(ex);
                }
            
        }

        public void UpdatePDCompetencyKSAFactor(PositionCompetencyKSA positionCompetencyKSA, JQFactor jqFactor)
        {
            if (base.ValidateKeyField(positionCompetencyKSA.CompetencyKSAID))
            {
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionCompetencyKSAFactor");

                try
                {

                    commandWrapper.Parameters.Add(new SqlParameter("@PositionCompetencyKSAID", positionCompetencyKSA.CompetencyKSAID));
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", positionCompetencyKSA.PositionDescriptionID));

                    if (positionCompetencyKSA.CompetencyKSA == null)
                        commandWrapper.Parameters.Add(new SqlParameter("@competencyKSA", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@competencyKSA", positionCompetencyKSA.CompetencyKSA));

                    if (positionCompetencyKSA.Certification == null)
                        commandWrapper.Parameters.Add(new SqlParameter("@certification", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@certification", positionCompetencyKSA.Certification));

                    if (positionCompetencyKSA.QualificationID < 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@qualificationID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@qualificationID", positionCompetencyKSA.QualificationID));

                    if (positionCompetencyKSA.QualificationTypeID < 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@qualificationTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@qualificationTypeID", positionCompetencyKSA.QualificationTypeID));

                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", positionCompetencyKSA.CreatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createDate", positionCompetencyKSA.CreateDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", positionCompetencyKSA.UpdatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", positionCompetencyKSA.UpdateDate));

                    if (positionCompetencyKSA.AssociatedPDDutyID == null)
                        commandWrapper.Parameters.Add(new SqlParameter("@AssociatedPDDutyID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@AssociatedPDDutyID", positionCompetencyKSA.AssociatedPDDutyID));

                    if (jqFactor.JQFactorTypeID < 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@jQFactorTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@jQFactorTypeID", jqFactor.JQFactorTypeID));

                    if (jqFactor.KSAID < 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@KSAID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@KSAID", jqFactor.KSAID));

                    commandWrapper.Parameters.Add(new SqlParameter("@isSF", jqFactor.IsSF));

                    if (jqFactor.JQID < 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@jQID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@jQID", jqFactor.JQID));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }

                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }

        public void DeletePDCompetencyKSAFactor(long positionCompetencyKSAID, int userId)
        {          
            TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
            currentTransaction.BeginTransaction();
            
            DbCommand commandWrapper = GetDbCommand("spr_DeletePositionCompetencyKSAFactor");
            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionCompetencyKSAID", positionCompetencyKSAID));                
                commandWrapper.Parameters.Add(new SqlParameter("@userId", userId));

                if (currentTransaction != null)
                {
                    DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                }
                else
                {
                    ExecuteNonQuery(commandWrapper);
                }

                currentTransaction.Commit();

            }
            catch (Exception ex)
            {
                currentTransaction.Rollback();
                HandleException(ex);
            }


        }

        #endregion

        #region Collection Helper Methods

        internal static List<PositionCompetencyKSA> GetCollection(DataTable dataItems)
        {
            List<PositionCompetencyKSA> listCollection = new List<PositionCompetencyKSA>();
            PositionCompetencyKSA current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PositionCompetencyKSA(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PositionCompetencyKSA collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

    }
}
