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
using HCMS.Business.Series;
using HCMS.Business.Series.Collections;
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups
{
    /// <summary>
    /// Series Business Object
    /// </summary>
    [Serializable]
    public class Series : BusinessBase
    {
        #region Private Members

        private int _seriesID = -1;
        private string _seriesName = string.Empty;
        private string _seriesDefinition = string.Empty;
        private string _seriesOccupationalInformation = string.Empty;
        private int _payPlanID = -1;
        private int _typeOfWorkID = -1;
        private string _paddedSeriesID = String.Empty;
        private bool? _inUse = null;
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

        public string SeriesName
        {
            get
            {
                return this._seriesName;
            }
            set
            {
                this._seriesName = value;
            }
        }

        public string SeriesDefinition
        {
            get
            {
                return this._seriesDefinition;
            }
            set
            {
                this._seriesDefinition = value;
            }
        }

        public string DetailLine
        {
            get
            {
                return string.Format("{0} | {1}", PaddedSeriesID, this._seriesName).Trim();
            }
        }

        public string SeriesOccupationalInformation
        {
            get
            {
                return this._seriesOccupationalInformation;
            }
            set
            {
                this._seriesOccupationalInformation = value;
            }
        }

        public int PayPlanID
        {
            get
            {
                return this._payPlanID;
            }
            set
            {
                this._payPlanID = value;
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

        public string PaddedSeriesID
        {
            get
            {
                return this._paddedSeriesID;
            }
        }

        public bool? InUse
        {
            get { return this._inUse; }
            set { this._inUse = value; }
        }

        #endregion

        #region Constructors

        public Series()
        {
            // empty constructor
        }

        public Series(DataRow singleRowData)
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

        public Series(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetSeriesBySeriesID", loadByID);
                loadData(returnTable);
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
            DataColumnCollection columns = returnRow.Table.Columns;
            if (returnRow["SeriesID"] != DBNull.Value)
            {
                this._seriesID = (int)returnRow["SeriesID"];
                string seriesWorkPad = string.Format("0000{0}", this._seriesID);
                this._paddedSeriesID = seriesWorkPad.Substring(seriesWorkPad.Length - 4);
            }

            if (returnRow["SeriesName"] != DBNull.Value)
                this._seriesName = returnRow["SeriesName"].ToString();

            if (returnRow["SeriesDefinition"] != DBNull.Value)
                this._seriesDefinition = returnRow["SeriesDefinition"].ToString();

            if (returnRow["SeriesOccupationalInformation"] != DBNull.Value)
                this._seriesOccupationalInformation = returnRow["SeriesOccupationalInformation"].ToString();

            if (returnRow["PayPlanID"] != DBNull.Value)
                this._payPlanID = (int)returnRow["PayPlanID"];

            if (returnRow["TypeOfWorkID"] != DBNull.Value)
                this._typeOfWorkID = (int)returnRow["TypeOfWorkID"];

            if (columns.Contains("InUse"))
            {
                if (returnRow["InUse"] != DBNull.Value)
                {
                    this._inUse = (bool)returnRow["InUse"];
                }
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
            return "SeriesID:" + SeriesID.ToString();
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
            Series Seriesobj = obj as Series;

            return (Seriesobj == null) ? false : (this.SeriesID == Seriesobj.SeriesID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return SeriesID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static SeriesCollection GetCollection(DataTable dataItems)
        {
            SeriesCollection listCollection = new SeriesCollection();
            Series current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new Series(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a Series collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        public GradeCollection GetGrades()
        {
            GradeCollection childDataCollection = null;

            if (base.ValidateKeyField(this._seriesID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetGradesByseriesID", this._seriesID);

                    // fill collection list
                    childDataCollection = Grade.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public SeriesOPMTitleCollection GetSeriesOPMTitles()
        {
            SeriesOPMTitleCollection childDataCollection = null;

            if (base.ValidateKeyField(this._seriesID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetSeriesOPMTitleBySeriesID", this._seriesID);

                    // fill collection list
                    childDataCollection = SeriesOPMTitle.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

               
        #endregion

        #region Static Methods
        public static List<KSA> GetSeriesGradeKSA(int seriesID, int grade)
        {
            List<KSA> ksaCollection = new List<KSA>();
            KSA current = null;
            DataTable dataItems = ExecuteDataTable("spr_GetAllKSABySeriesGrade", seriesID, grade);
            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new KSA(dataItems.Rows[i]);
                    ksaCollection.Add(current);
                }
            }
            else
                throw new Exception("KSA collection could not be populated for this series and grade.");

            return ksaCollection;
        }
        #endregion

    }
    [System.ComponentModel.DataObject]
    public class SeriesEntity
    {
        public int ID { get; set; }
        public string SeriesName { get; set; }
        public string SeriesDefinition { get; set; }
        public string OccupationalInformation { get; set; }
        public int PayPlanID { get; set; }
        public int TypeOfWorkID { get; set; }
        
        public string PaddedID
        {
            get
            {
                return this.ID.ToString("D4");
            }
        }

        public string DetailLine
        {
            get
            {
                return string.Format("{0} | {1}", this.PaddedID, this.SeriesName).Trim();
            }
        }

       
    }
}

