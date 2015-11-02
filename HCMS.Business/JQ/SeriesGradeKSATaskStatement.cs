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

namespace HCMS.Business.JQ
{
    /// <summary>
    /// SeriesGradeKSATaskStatement Business Object
    /// </summary>
    [Serializable]
    public class SeriesGradeKSATaskStatement : BusinessBase
    {
        #region Private Members

        private int _seriesID = -1;
        private int _grade = -1;
        private long _kSAID = -1;
        private long _taskStatementID = -1;

        #endregion

        #region Properties

        public int SeriesID
        {
            get
            {
                return this._seriesID;
            }
            set
            {
                this._seriesID = value;
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

        public long KSAID
        {
            get
            {
                return this._kSAID;
            }
            set
            {
                this._kSAID = value;
            }
        }

        public long TaskStatementID
        {
            get
            {
                return this._taskStatementID;
            }
            set
            {
                this._taskStatementID = value;
            }
        }

        #endregion

        #region Constructors

        public SeriesGradeKSATaskStatement()
        {
            // Empty Constructor
        }

        public SeriesGradeKSATaskStatement(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetSeriesGradeKSATaskStatementByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public SeriesGradeKSATaskStatement(DataRow singleRowData)
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
            this._seriesID = (int)returnRow["SeriesID"];
            this._grade = (int)returnRow["Grade"];
            this._kSAID = (long)returnRow["KSAID"];
            this._taskStatementID = (long)returnRow["TaskStatementID"];
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
            return "SeriesID:" + SeriesID.ToString() + "Grade:" + Grade.ToString() + "KSAID:" + KSAID.ToString() + "TaskStatementID:" + TaskStatementID.ToString();
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
            SeriesGradeKSATaskStatement SeriesGradeKSATaskStatementobj = obj as SeriesGradeKSATaskStatement;

            return (SeriesGradeKSATaskStatementobj == null) ? false : ((((this.SeriesID == SeriesGradeKSATaskStatementobj.SeriesID) && (this.Grade == SeriesGradeKSATaskStatementobj.Grade)) && (this.KSAID == SeriesGradeKSATaskStatementobj.KSAID)) && (this.TaskStatementID == SeriesGradeKSATaskStatementobj.TaskStatementID));
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return SeriesID.GetHashCode() ^ Grade.GetHashCode() ^ KSAID.GetHashCode() ^ TaskStatementID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void AddSeriesGradeKSATaskStatement()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddSeriesGradeKSATaskStatement");

            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@seriesID", this._seriesID));
                commandWrapper.Parameters.Add(new SqlParameter("@grade", this._grade));
                commandWrapper.Parameters.Add(new SqlParameter("@kSAID", this._kSAID));
                commandWrapper.Parameters.Add(new SqlParameter("@taskStatementID", this._taskStatementID));

                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void AddWithTaskStatementIDNull()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddSeriesGradeKSATaskStatement");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newSeriesID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new SeriesID of the record
                commandWrapper.Parameters.Add(returnParam);


                ExecuteNonQuery(commandWrapper);

                this._seriesID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        public void Update()
        {

            if (base.ValidateKeyField(this._seriesID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateSeriesGradeKSATaskStatement");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@seriesID", this._seriesID));
                    commandWrapper.Parameters.Add(new SqlParameter("@grade", this._grade));
                    commandWrapper.Parameters.Add(new SqlParameter("@kSAID", this._kSAID));
                    commandWrapper.Parameters.Add(new SqlParameter("@taskStatementID", this._taskStatementID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void Delete(int currentUserID)
        {
            DbCommand commandWrapper = GetDbCommand("spr_DeleteSeriesGradeKSATaskStatement");
            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@seriesID", this._seriesID));
                commandWrapper.Parameters.Add(new SqlParameter("@grade", this._grade));
                commandWrapper.Parameters.Add(new SqlParameter("@kSAID", this._kSAID));
                commandWrapper.Parameters.Add(new SqlParameter("@taskStatementID", this._taskStatementID));
                //commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", currentUserID));

                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        #endregion

        #region Collection Helper Methods

        internal static List<SeriesGradeKSATaskStatement> GetCollection(DataTable dataItems)
        {
            List<SeriesGradeKSATaskStatement> listCollection = new List<SeriesGradeKSATaskStatement>();
            SeriesGradeKSATaskStatement current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new SeriesGradeKSATaskStatement(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a SeriesGradeKSATaskStatement collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

    }
}

