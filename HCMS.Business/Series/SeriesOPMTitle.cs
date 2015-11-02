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
using HCMS.Business.Series.Collections;

namespace HCMS.Business.Series
{
    /// <summary>
    /// SeriesOPMTitle Business Object
    /// </summary>
    [Serializable]
    public class SeriesOPMTitle : BusinessBase
    {
        #region Private Members

        private int _series = -1;
        private string _seriesOPMTitleName = string.Empty;
        private string _seriesOPMTitleDescription = string.Empty;

        #endregion

        #region Properties

        public int Series
        {
            get
            {
                return this._series;
            }
            set
            {
                this._series = value;
            }
        }

        public string SeriesOPMTitleName
        {
            get
            {
                return this._seriesOPMTitleName;
            }
            set
            {
                this._seriesOPMTitleName = value;
            }
        }

        public string SeriesOPMTitleDescription
        {
            get { return this._seriesOPMTitleDescription; }
            set { this._seriesOPMTitleDescription = value; }
        }
        #endregion

        #region Constructors

        public SeriesOPMTitle()
        {
            // Empty Constructor
        }

        public SeriesOPMTitle(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetSeriesOPMTitleByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public SeriesOPMTitle(DataRow singleRowData)
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
            this._series = (int)returnRow["Series"];
            this._seriesOPMTitleName = returnRow["SeriesOPMTitle"].ToString();
            this._seriesOPMTitleDescription = returnRow["SeriesOPMTitleDescription"].ToString();
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
            return "Series:" + Series.ToString() + "SeriesOPMTitle:" + SeriesOPMTitleName;
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
            SeriesOPMTitle SeriesOPMTitleobj = obj as SeriesOPMTitle;

            return (SeriesOPMTitleobj == null) ? false : ((this.Series == SeriesOPMTitleobj.Series) && (this.SeriesOPMTitleName.Trim().ToLower() == SeriesOPMTitleobj.SeriesOPMTitleName.Trim().ToLower()));
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return Series.GetHashCode() ^ SeriesOPMTitleName.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddSeriesOPMTitle");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newSeries", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new Series of the record
                commandWrapper.Parameters.Add(returnParam);


                ExecuteNonQuery(commandWrapper);

                this._series = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._series))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateSeriesOPMTitle");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@series", this._series));
                    commandWrapper.Parameters.Add(new SqlParameter("@seriesOPMTitle", this._seriesOPMTitleName.Trim()));

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
            if (base.ValidateKeyField(this._series))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteSeriesOPMTitle", this._series);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static SeriesOPMTitleCollection GetCollection(DataTable dataItems)
        {
            SeriesOPMTitleCollection listCollection = new SeriesOPMTitleCollection();

            SeriesOPMTitle current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new SeriesOPMTitle(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a SeriesOPMTitle collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

    }

    public class SeriesOPMTitleEntity
    {
        public int SeriesID { get; set; }
        public string OPMTitle { get; set; }
        public string OPMDescription { get; set; }
    }
}

