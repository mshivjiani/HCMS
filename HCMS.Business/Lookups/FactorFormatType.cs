﻿using System;
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
    /// FactorFormatType Business Object
    /// </summary>
    [Serializable]
    public class FactorFormatType : BusinessBase
    {
        #region Private Members

        private int _factorFormatTypeID = -1;
        private string _factorFormatTypeName = string.Empty;

        #endregion

        #region Properties

        public int FactorFormatTypeID
        {
            get
            {
                return this._factorFormatTypeID;
            }
            set
            {
                this._factorFormatTypeID = value;
            }
        }

        public string FactorFormatTypeName
        {
            get
            {
                return this._factorFormatTypeName;
            }
            set
            {
                this._factorFormatTypeName = value;
            }
        }

        #endregion

        #region Constructors

        public FactorFormatType(DataRow singleRowData)
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
            this._factorFormatTypeID = (int)returnRow["FactorFormatTypeID"];
            this._factorFormatTypeName = returnRow["FactorFormatType"].ToString();
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
            return "FactorFormatTypeID:" + FactorFormatTypeID.ToString();
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
            FactorFormatType FactorFormatTypeobj = obj as FactorFormatType;

            return (FactorFormatTypeobj == null) ? false : (this.FactorFormatTypeID == FactorFormatTypeobj.FactorFormatTypeID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return FactorFormatTypeID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<FactorFormatType> GetCollection(DataTable dataItems)
        {
            List<FactorFormatType> listCollection = new List<FactorFormatType>();
            FactorFormatType current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new FactorFormatType(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a FactorFormatType collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

