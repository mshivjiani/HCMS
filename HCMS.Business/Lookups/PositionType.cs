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
    /// PositionType Business Object
    /// </summary>
    [Serializable]
    public class PositionType : BusinessBase
    {
        #region Private Members

        private int _positionTypeID = -1;
        private string _positionType = string.Empty;
        private string _positionTypeDescription = string.Empty;

        #endregion

        #region Properties

        public int PositionTypeID
        {
            get
            {
                return this._positionTypeID;
            }
            set
            {
                this._positionTypeID = value;
            }
        }

        public string PositionTypeName
        {
            get
            {
                return this._positionType;
            }
            set
            {
                this._positionType = value;
            }
        }

        public string PositionTypeDescription
        {
            get
            {
                return this._positionTypeDescription;
            }
            set
            {
                this._positionTypeDescription = value;
            }
        }

        #endregion

        #region Constructors

        public PositionType(DataRow singleRowData)
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
            this._positionTypeID = (int)returnRow["PositionTypeID"];
            this._positionType = returnRow["PositionType"].ToString();

            if (returnRow["PositionTypeDescription"] != DBNull.Value)
                this._positionTypeDescription = returnRow["PositionTypeDescription"].ToString();
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
            return "PositionTypeID:" + PositionTypeID.ToString();
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
            PositionType PositionTypeobj = obj as PositionType;

            return (PositionTypeobj == null) ? false : (this.PositionTypeID == PositionTypeobj.PositionTypeID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return PositionTypeID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<PositionType> GetCollection(DataTable dataItems)
        {
            List<PositionType> listCollection = new List<PositionType>();
            PositionType current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PositionType(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PositionType collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

