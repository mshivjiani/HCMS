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
    /// Service Business Object
    /// </summary>
    [Serializable]
    public class Service : BusinessBase
    {
        #region Private Members

        private int _serviceID = -1;
        private string _service = string.Empty;

        #endregion

        #region Properties

        public int ServiceID
        {
            get
            {
                return this._serviceID;
            }
            set
            {
                this._serviceID = value;
            }
        }

        public string ServiceName
        {
            get
            {
                return this._service;
            }
            set
            {
                this._service = value;
            }
        }

        #endregion

        #region Constructors

        public Service(DataRow singleRowData)
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
            this._serviceID = (int)returnRow["ServiceID"];
            this._service = returnRow["Service"].ToString();
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
            return "ServiceID:" + ServiceID.ToString();
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
            Service Serviceobj = obj as Service;

            return (Serviceobj == null) ? false : (this.ServiceID == Serviceobj.ServiceID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ServiceID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<Service> GetCollection(DataTable dataItems)
        {
            List<Service> listCollection = new List<Service>();
            Service current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new Service(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a Service collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

