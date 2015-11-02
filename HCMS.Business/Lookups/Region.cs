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
using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups
{
    /// <summary>
    /// Region Business Object
    /// </summary>
    [Serializable]
    public class Region : BusinessBase
    {
        #region Private Members

        private int _regionID = -1;
        private string _region = string.Empty;

        #endregion

        #region Properties

        public int RegionID
        {
            get
            {
                return this._regionID;
            }
            set
            {
                this._regionID = value;
            }
        }

        public string RegionName
        {
            get
            {
                return this._region;
            }
            set
            {
                this._region = value;
            }
        }

        #endregion

        #region Constructors

        public Region(DataRow singleRowData)
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
        public Region(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetRegionByRegionID", loadByID);
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
            this._regionID = (int)returnRow["RegionID"];
            this._region = returnRow["Region"].ToString();
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
            return "RegionID:" + RegionID.ToString();
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
            Region Regionobj = obj as Region;

            return (Regionobj == null) ? false : (this.RegionID == Regionobj.RegionID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return RegionID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<Region> GetCollection(DataTable dataItems)
        {
            List<Region> listCollection = new List<Region>();
            Region current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new Region(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a Region collection from a null data table.");

            return listCollection;
        }

        #endregion
    }
}

