using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;

namespace HCMS.Business.SeriesFactorLevelLanguage
    
{
    /// <summary>
    /// SeriesFesFactorLevelLanguage Business Object
    /// </summary>
    [Serializable]
    public class SeriesFesFactorLevelLanguage : BusinessBase, HCMS.Business.SeriesFactorLevelLanguage.ISeriesFactorLevelLanguage
    {
        #region Private Members
        private enumFactorFormatType _factorformattypeid = enumFactorFormatType.FES;
        private int _seriesID = -1;
        private int _factorlevelID = -1;
        private int _point = -1;
        private int _factorID = -1;
        private int _levelID = -1;
        private string _factorLevelLanguage = string.Empty;
        private string _factorLevelLanguage2 = string.Empty;
        private string _factorLevelLanguage3 = string.Empty;

        #endregion

        #region Properties
        public enumFactorFormatType FactorFormatTypeID
        {
            get
            {
                return this._factorformattypeid;
            }
            
        }

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

        public int FactorLevelID
        {
            get
            {
                return this._factorlevelID;
            }
            set
            {
                this._factorlevelID = value;
            }
        }

        public string FactorLevelLanguage
        {
            get
            {
                return this._factorLevelLanguage;
            }
            set
            {
                this._factorLevelLanguage = value;
            }
        }

        public string FactorLevelLanguage2
        {
            get
            {
                return this._factorLevelLanguage2;
            }
            set
            {
                this._factorLevelLanguage2 = value;
            }
        }

        public string FactorLevelLanguage3
        {
            get
            {
                return this._factorLevelLanguage3;
            }
            set
            {
                this._factorLevelLanguage3 = value;
            }
        }
   
        public int Point
        {
            get
            {
                return this._point;
            }
            set
            {
                this._point = value;
            }
        }

        public int FactorID
        {
            get
            {
                return this._factorID;
            }
            set
            {
                this._factorID = value;
            }
        }
           public int LevelID
        {
            get
            {
                return this._levelID;
            }
            set
            {
             this._levelID     = value;
            }
        }
        #endregion

        #region Constructors
        public SeriesFesFactorLevelLanguage()
        {
        }
        public SeriesFesFactorLevelLanguage(DataRow singleRowData)
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

        public SeriesFesFactorLevelLanguage(int seriesid, int fesfactorlevelid)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetSeriesFesFactorLevelLanguageByID", seriesid ,fesfactorlevelid );
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        public SeriesFesFactorLevelLanguage(int seriesid, int fesfactorid, int levelid)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetSeriesFesFactorLevelLanguage", seriesid,fesfactorid,levelid);
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
            this._seriesID = (int)returnRow["SeriesID"];
            this._factorlevelID = (int)returnRow["FESFactorLevelID"];

            if (returnRow["FESFactorLevelLanguage"] != DBNull.Value)
                this._factorLevelLanguage = returnRow["FESFactorLevelLanguage"].ToString();

            if (returnRow["FESFactorLevelLanguage2"] != DBNull.Value)
                this._factorLevelLanguage2 = returnRow["FESFactorLevelLanguage2"].ToString();

            if (returnRow["FESFactorLevelLanguage3"] != DBNull.Value)
                this._factorLevelLanguage3 = returnRow["FESFactorLevelLanguage3"].ToString();
            DataColumnCollection columns = returnRow.Table.Columns;
            if (columns.Contains("Point"))
            {
                this._point = (int)returnRow["Point"];
            }
            if (columns.Contains("FesFactorID"))
            {
                this._factorID = (int)returnRow["FesFactorID"];
            }
            if (columns.Contains("LevelID"))
            {
                this._levelID = (int)returnRow["LevelID"];
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
            return "SeriesID:" + SeriesID.ToString() + "FESFactorLevelID:" + FactorLevelID.ToString();
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
            SeriesFesFactorLevelLanguage SeriesFesFactorLevelLanguageobj = obj as SeriesFesFactorLevelLanguage;

            return (SeriesFesFactorLevelLanguageobj == null) ? false : ((this.SeriesID == SeriesFesFactorLevelLanguageobj.SeriesID) && (this.FactorLevelID == SeriesFesFactorLevelLanguageobj.FactorLevelID));
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return SeriesID.GetHashCode() ^ FactorLevelID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<SeriesFesFactorLevelLanguage> GetCollection(DataTable dataItems)
        {
            List<SeriesFesFactorLevelLanguage> listCollection = new List<SeriesFesFactorLevelLanguage>();
            SeriesFesFactorLevelLanguage current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new SeriesFesFactorLevelLanguage(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a SeriesFesFactorLevelLanguage collection from a null data table.");

            return listCollection;
        }

        #endregion




    }
}

