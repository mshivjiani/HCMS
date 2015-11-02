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
    /// PositionEvalCriteria Business Object
    /// </summary>
    [Serializable]
    public class PositionEvalCriteria : BusinessBase
    {
        #region Private Members

        private long _positionDescriptionID = -1;
        private int _evalCriteriaID = -1;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;

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

        public int EvalCriteriaID
        {
            get
            {
                return this._evalCriteriaID;
            }
            set
            {
                this._evalCriteriaID = value;
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

        public PositionEvalCriteria()
        {
            // Empty Constructor
        }

        public PositionEvalCriteria(long positionDescriptionID,int evalCriteriaID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionEvalCriteriaByID",positionDescriptionID ,evalCriteriaID );
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        
        public PositionEvalCriteria(DataRow singleRowData)
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
            this._positionDescriptionID = (long)returnRow["PositionDescriptionID"];
            this._evalCriteriaID = (int)returnRow["EvalCriteriaID"];
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
            return "PositionDescriptionID:" + PositionDescriptionID.ToString() + "EvalCriteriaID:" + EvalCriteriaID.ToString();
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
            PositionEvalCriteria PositionEvalCriteriaobj = obj as PositionEvalCriteria;

            return (PositionEvalCriteriaobj == null) ? false : ((this.PositionDescriptionID == PositionEvalCriteriaobj.PositionDescriptionID) && (this.EvalCriteriaID == PositionEvalCriteriaobj.EvalCriteriaID));
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return PositionDescriptionID.GetHashCode() ^ EvalCriteriaID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddPositionEvalCriteria");

            try
            {
                
                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID ));
                commandWrapper.Parameters.Add(new SqlParameter("@evalCriteriaID", this._evalCriteriaID ));


                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));

                ExecuteNonQuery(commandWrapper);

                
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionEvalCriteria");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@evalCriteriaID", this._evalCriteriaID));
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
        public void Save()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_AddUpdatePositionEvalCriteria");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@evalCriteriaID", this._evalCriteriaID));
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
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeletePositionEvalCriteria", this._positionDescriptionID,this._evalCriteriaID );
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static List<PositionEvalCriteria> GetCollection(DataTable dataItems)
        {
            List<PositionEvalCriteria> listCollection = new List<PositionEvalCriteria>();
            PositionEvalCriteria current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PositionEvalCriteria(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PositionEvalCriteria collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

    }
}

