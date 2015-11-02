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
    /// FactorRevisionNote Business Object
    /// </summary>
    [Serializable]
    public class FactorRevisionNote : BusinessBase
    {
        #region Private Members

        private int _factorRevisionNoteID = -1;
        private string _factorRevisionNote = string.Empty;
        private int _positionFactorID = -1;
        private string _factorRevisionUpdateNote = string.Empty;
        private bool _reviewed = false;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;

        #endregion

        #region Properties

        public int FactorRevisionNoteID
        {
            get
            {
                return this._factorRevisionNoteID;
            }
            set
            {
                this._factorRevisionNoteID = value;
            }
        }

        public string FactorRevisionNoteName
        {
            get
            {
                return this._factorRevisionNote;
            }
            set
            {
                this._factorRevisionNote = value;
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

        public string FactorRevisionUpdateNote
        {
            get
            {
                return this._factorRevisionUpdateNote;
            }
            set
            {
                this._factorRevisionUpdateNote = value;
            }
        }

        public bool Reviewed
        {
            get
            {
                return this._reviewed;
            }
            set
            {
                this._reviewed = value;
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

        public FactorRevisionNote()
        {
            // Empty Constructor
        }

        public FactorRevisionNote(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetFactorRevisionNoteByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public FactorRevisionNote(DataRow singleRowData)
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
            this._factorRevisionNoteID = (int)returnRow["FactorRevisionNoteID"];
            this._factorRevisionNote = returnRow["FactorRevisionNote"].ToString();
            this._positionFactorID = (int)returnRow["PositionFactorID"];

            if (returnRow["FactorRevisionUpdateNote"] != DBNull.Value)
                this._factorRevisionUpdateNote = returnRow["FactorRevisionUpdateNote"].ToString();

            if (returnRow["Reviewed"] != DBNull.Value)
                this._reviewed = (bool)returnRow["Reviewed"];

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
            return "FactorRevisionNoteID:" + FactorRevisionNoteID.ToString();
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
            FactorRevisionNote FactorRevisionNoteobj = obj as FactorRevisionNote;

            return (FactorRevisionNoteobj == null) ? false : (this.FactorRevisionNoteID == FactorRevisionNoteobj.FactorRevisionNoteID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return FactorRevisionNoteID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddFactorRevisionNote");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newFactorRevisionNoteID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new FactorRevisionNoteID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@factorRevisionNote", this._factorRevisionNote.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@positionFactorID", this._positionFactorID));
                commandWrapper.Parameters.Add(new SqlParameter("@factorRevisionUpdateNote", this._factorRevisionUpdateNote));
                commandWrapper.Parameters.Add(new SqlParameter("@reviewed", this._reviewed));
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));

                ExecuteNonQuery(commandWrapper);

                this._factorRevisionNoteID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._factorRevisionNoteID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateFactorRevisionNote");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@factorRevisionNoteID", this._factorRevisionNoteID));
                    commandWrapper.Parameters.Add(new SqlParameter("@factorRevisionNote", this._factorRevisionNote.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@positionFactorID", this._positionFactorID));
                    commandWrapper.Parameters.Add(new SqlParameter("@factorRevisionUpdateNote", this._factorRevisionUpdateNote));
                    commandWrapper.Parameters.Add(new SqlParameter("@reviewed", this._reviewed));
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
            if (base.ValidateKeyField(this._factorRevisionNoteID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteFactorRevisionNote", this._factorRevisionNoteID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static List<FactorRevisionNote> GetCollection(DataTable dataItems)
        {
            List<FactorRevisionNote> listCollection = new List<FactorRevisionNote>();
            FactorRevisionNote current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new FactorRevisionNote(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a FactorRevisionNote collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

    }
}

