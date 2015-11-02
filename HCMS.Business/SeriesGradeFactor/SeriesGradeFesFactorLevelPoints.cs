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
namespace HCMS.Business.SeriesGradeFactor
{    /// <summary>
    /// SeriesGradeFesFactorLevelPoints Business Object
    /// </summary>
    [Serializable]
   public class SeriesGradeFesFactorLevelPoints:BusinessBase 
    {
    
     #region Private Members

        private int _seriesID = -1;
        private int _grade=-1;
        private int _factorlevel = -1;
        private int _levelID=-1;
        private int _fesfactorgradelevelID=-1;
        private int _typeOfWorkID=-1;
        private int _points=-1;
        private int _factorID = -1;
        private string _fesFactorTitle = string.Empty;
        

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
                return this._grade ;
                
            }
            set
            {
                 this._grade = value;
            }
        }
        public int FactorLevel
        {
            get
            {
                return this._factorlevel ;
            }
            set
            {
             this._factorlevel    = value;
            }
        }
           public int LevelID
        {
            get
            {
                return this._levelID ;
            }
            set
            {
             this._levelID    = value;
            }
        }
           public int FESFactorGradeLevelID
        {
            get
            {
                return this._fesfactorgradelevelID ;
            }
            set
            {
             this._fesfactorgradelevelID = value;
            }
        }
           public int TypeOfWorkID
        {
            get
            {
                return this._typeOfWorkID ;
            }
            set
            {
             this._typeOfWorkID     = value;
            }
        }
           public int Points
        {
            get
            {
                return this._points ;
            }
            set
            {
             this._points  = value;
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
             this._factorID   = value;
            }
        }
           public string FESFactorTitle
           {
               get { return this._fesFactorTitle; }
               set { this._fesFactorTitle = value; }
           }
        #endregion

        #region Constructors

        public SeriesGradeFesFactorLevelPoints()
        {
            // Empty Constructor
        }

        public SeriesGradeFesFactorLevelPoints(int seriesID,int gradeID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetSeriesGradeFESFactorLevelPoints.sql", seriesID,gradeID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        

        public SeriesGradeFesFactorLevelPoints(DataRow singleRowData)
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
            this._grade  = (int)returnRow["Grade"];
            this._factorlevel  = (int)returnRow["FesFactorLevelID"];
            this._levelID = (int)returnRow["LevelID"];
            this._fesfactorgradelevelID  = (int)returnRow["FESFactorGradeLevelID"];
            this._typeOfWorkID  = (int)returnRow["TypeOfWorkID"];
            this._points  = (int)returnRow["Point"];
            this._factorID = (int)returnRow["FesFactorID"];
            this._fesFactorTitle = returnRow["FesFactorTitle"].ToString();
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

        #region Collection Helper Methods

        internal static List<SeriesGradeFesFactorLevelPoints> GetCollection(DataTable dataItems)
        {
            List<SeriesGradeFesFactorLevelPoints> listCollection = new List<SeriesGradeFesFactorLevelPoints>();
            SeriesGradeFesFactorLevelPoints current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new SeriesGradeFesFactorLevelPoints(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a SeriesGradeFesFactorLevelPoints collection from a null data table.");

            return listCollection;
        }

        #endregion


 
}
}