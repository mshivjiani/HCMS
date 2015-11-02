using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using HCMS.Business.Base;

namespace HCMS.Business.Lookups
{
    /// <summary>
    /// DutyType Business Object
    /// </summary>
    [Serializable]
    public class DutyType : BusinessBase
    {
        #region Private Members

        private int _dutyTypeID = -1;
        private string _dutyType = string.Empty;
        private string _dutyTypeDescription = string.Empty;

        #endregion

        #region Properties

        public int DutyTypeID
        {
            get
            {
                return this._dutyTypeID;
            }
            set
            {
                this._dutyTypeID = value;
            }
        }

        public string DutyTypeName
        {
            get
            {
                return this._dutyType;
            }
            set
            {
                this._dutyType = value;
            }
        }

        public string DutyTypeDescription
        {
            get
            {
                return this._dutyTypeDescription;
            }
            set
            {
                this._dutyTypeDescription = value;
            }
        }

        #endregion

        #region Constructors

        public DutyType(DataRow singleRowData)
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

        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            this._dutyTypeID = (int)returnRow["DutyTypeID"];
            this._dutyType = returnRow["DutyType"].ToString();

            if (returnRow["DutyTypeDescription"] != DBNull.Value)
                this._dutyTypeDescription = returnRow["DutyTypeDescription"].ToString();
        }

        #endregion

        #region ToString Method

        ///<summary>
        /// Returns a String that represents the current object.
        ///</summary>
        public override string ToString()
        {
            
            return string.Concat (this.DutyTypeID.ToString(),this.DutyTypeName);
        }

        #endregion ToString Method


        /// <summary>
        /// Determines whether the specified System.Object is equal to the current object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current object.</param>
        /// <returns>Returns true if the specified System.Object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {
            DutyType dutyTypeobj = obj as DutyType ;
            return (dutyTypeobj == null) ? false : (this.DutyTypeID == dutyTypeobj.DutyTypeID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return DutyTypeID.GetHashCode();
        }

        #region Collection Helper Methods

        internal static List<DutyType> GetCollection(DataTable dataItems)
        {
            List<DutyType> listCollection = new List<DutyType>();
            DutyType current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new DutyType(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a DutyType collection from a null data table.");

            return listCollection;
        }

        #endregion

    }

    [System.ComponentModel.DataObject]
    public class DutyTypeDataSourceBusinessObject
    {
        public List<DutyType> GetObjects()
        {
            return LookupManager.GetAllDutyTypes();
        }
    }

    public enum DutyTypeID
    {
        Major = 1,
        Other = 2
    }
}

