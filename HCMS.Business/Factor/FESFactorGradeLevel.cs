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

namespace HCMS.Business.Factor
{
    /// <summary>
    /// FesFactorGradeLevelPoint Business Object
    /// </summary>
    [Serializable]
    public class FesFactorGradeLevel : BusinessBase
    {
        #region Private Members

        private int _fESFactorGradeLevelID = -1;
        private int _grade = -1;
        private int _typeOfWorkID = -1;
        private int _fESFactorLevelID = -1;

        #endregion

        #region Properties

        public int FESFactorGradeLevelID
        {
            get
            {
                return this._fESFactorGradeLevelID;
            }
            set
            {
                this._fESFactorGradeLevelID = value;
            }
        }

        public int Grade
        {
            get
            {
                return this._grade;
            }
            set
            {
                this._grade = value;
            }
        }

        public int TypeOfWorkID
        {
            get
            {
                return this._typeOfWorkID;
            }
            set
            {
                this._typeOfWorkID = value;
            }
        }

        public int FESFactorLevelID
        {
            get
            {
                return this._fESFactorLevelID;
            }
            set
            {
                this._fESFactorLevelID = value;
            }
        }

        #endregion

        #region Constructors

        public FesFactorGradeLevel()
        {
            // Empty Constructor
        }

        public FesFactorGradeLevel(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetFESFactorGradeLevelRelationshipByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public FesFactorGradeLevel(DataRow singleRowData)
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
            this._fESFactorGradeLevelID = (int)returnRow["FESFactorGradeLevelID"];
            this._grade = (int)returnRow["Grade"];
            this._typeOfWorkID = (int)returnRow["TypeOfWorkID"];

            if (returnRow["FESFactorLevelID"] != DBNull.Value)
                this._fESFactorLevelID = (int)returnRow["FESFactorLevelID"];

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
            return "FESFactorGradeLevelID:" + FESFactorGradeLevelID.ToString();
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
            FesFactorGradeLevel FesFactorGradeLevelobj = obj as FesFactorGradeLevel;

            return (FesFactorGradeLevelobj == null) ? false : (this.FESFactorGradeLevelID == FesFactorGradeLevelobj.FESFactorGradeLevelID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return FESFactorGradeLevelID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddFESFactorGradeLevelRelationship");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newFESFactorGradeLevelID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new FESFactorGradeLevelID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@grade", this._grade));
                commandWrapper.Parameters.Add(new SqlParameter("@typeOfWorkID", this._typeOfWorkID));

                if (this._fESFactorLevelID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@fESFactorLevelID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@fESFactorLevelID", this._fESFactorLevelID));

                ExecuteNonQuery(commandWrapper);

                this._fESFactorGradeLevelID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._fESFactorGradeLevelID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateFESFactorGradeLevelRelationship");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@fESFactorGradeLevelID", this._fESFactorGradeLevelID));
                    commandWrapper.Parameters.Add(new SqlParameter("@grade", this._grade));
                    commandWrapper.Parameters.Add(new SqlParameter("@typeOfWorkID", this._typeOfWorkID));

                    if (this._fESFactorLevelID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@fESFactorLevelID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@fESFactorLevelID", this._fESFactorLevelID));

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
            if (base.ValidateKeyField(this._fESFactorGradeLevelID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteFESFactorGradeLevelRelationship", this._fESFactorGradeLevelID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static List<FesFactorGradeLevel> GetCollection(DataTable dataItems)
        {
            List<FesFactorGradeLevel> listCollection = new List<FesFactorGradeLevel>();
            FesFactorGradeLevel current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new FesFactorGradeLevel(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a FesFactorGradeLevelPoint collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

    }
}

