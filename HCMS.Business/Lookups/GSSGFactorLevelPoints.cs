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

namespace HCMS.Business.Lookups
{
    /// <summary>
    /// GSSGFactorLevelPoints Business Object
    /// </summary>
    [Serializable]
    public class GSSGFactorLevelPoints : BusinessBase, HCMS.Business.Lookups.IFactorLevelPoint
    {
        #region Private Members

        private int _factorLevelID = -1;
        private int _factorID = -1;
        private int _levelID = -1;
        private int _point = -1;
        private string _factorLevelLanguage = string.Empty;

        #endregion

        #region Properties

        public int FactorLevelID
        {
            get
            {
                return this._factorLevelID;
            }
            set
            {
                this._factorLevelID = value;
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
                this._levelID = value;
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

        #endregion

        #region Constructors
        public GSSGFactorLevelPoints()
        { }
        public GSSGFactorLevelPoints(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetGSSGFactorLevelPointByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
   

       
        public GSSGFactorLevelPoints(DataRow singleRowData)
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
            this._factorLevelID = (int)returnRow["GSSGFactorLevelID"];

            if (returnRow["GSSGFactorID"] != DBNull.Value)
                this._factorID = (int)returnRow["GSSGFactorID"];

            this._levelID = (int)returnRow["LevelID"];
            this._point = (int)returnRow["Point"];

            if (returnRow["GSSGFactorLevelLanguage"] != DBNull.Value)
                this._factorLevelLanguage = returnRow["GSSGFactorLevelLanguage"].ToString();
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
            return "GSSGFactorLevelID:" + FactorLevelID.ToString();
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
            GSSGFactorLevelPoints GSSGFactorLevelPointsobj = obj as GSSGFactorLevelPoints;

            return (GSSGFactorLevelPointsobj == null) ? false : (this.FactorLevelID == GSSGFactorLevelPointsobj.FactorLevelID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return FactorLevelID.GetHashCode();
        }
        #endregion
        #region Other Methods
        public static List<GSSGFactorLevelPoints> GetGSSGFactorLevelPointsByFactorID(int FactorID)
        {
            DataTable returnTable;

            returnTable = ExecuteDataTable("spr_GetGSSGFactorLevelPointByFactorID", FactorID);
            return GSSGFactorLevelPoints.GetCollection(returnTable);

        }
        #endregion
        #region Collection Helper Methods

        internal static List<GSSGFactorLevelPoints> GetCollection(DataTable dataItems)
        {
            List<GSSGFactorLevelPoints> listCollection = new List<GSSGFactorLevelPoints>();
            GSSGFactorLevelPoints current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new GSSGFactorLevelPoints(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a GSSGFactorLevelPoints collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

