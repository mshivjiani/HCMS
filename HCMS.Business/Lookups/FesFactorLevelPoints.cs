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
    /// FesFactorLevelPoints Business Object
    /// </summary>
    [Serializable]
    public class FesFactorLevelPoints : BusinessBase, HCMS.Business.Lookups.IFactorLevelPoint
    {
        #region Private Members

        private int _factorLevelID = -1;
        private int _factorID = -1;
        private int _levelID = -1;
        private int _point = -1;

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

        #endregion

        #region Constructors
        public FesFactorLevelPoints()
        { }
        public FesFactorLevelPoints(DataRow singleRowData)
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
        public FesFactorLevelPoints(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetFESFactorLevelPointByID", loadByID);
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
            this._factorLevelID = (int)returnRow["FESFactorLevelID"];
            this._factorID = (int)returnRow["FESFactorID"];
            this._levelID = (int)returnRow["LevelID"];
            this._point = (int)returnRow["Point"];
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
            return "FESFactorLevelID:" + FactorLevelID.ToString();
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
            FesFactorLevelPoints FesFactorLevelPointsobj = obj as FesFactorLevelPoints;

            return (FesFactorLevelPointsobj == null) ? false : (this.FactorLevelID == FesFactorLevelPointsobj.FactorLevelID);
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
        #region other Methods
        public static List<FesFactorLevelPoints> GetFesFactorLevelPointsByFactorID(int FactorID)
        {
            DataTable returnTable;

            returnTable = ExecuteDataTable("spr_GetFESFactorLevelPointByFactorID",FactorID);

            return FesFactorLevelPoints.GetCollection(returnTable);

        }
        #endregion
        #region Collection Helper Methods

        internal static List<FesFactorLevelPoints> GetCollection(DataTable dataItems)
        {
            List<FesFactorLevelPoints> listCollection = new List<FesFactorLevelPoints>();
            FesFactorLevelPoints current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new FesFactorLevelPoints(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a FesFactorLevelPoints collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

