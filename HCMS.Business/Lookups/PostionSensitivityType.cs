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
    /// PostionSensitivityType Business Object
    /// </summary>
    [Serializable]
    public class PostionSensitivityType : BusinessBase
    {
        #region Private Members

        private int _postionSensitivityTypeID = -1;
        private string _positionSenesitivityType = string.Empty;
        private string _positionSensitivityTypeDescription = string.Empty;

        #endregion

        #region Properties

        public int PostionSensitivityTypeID
        {
            get
            {
                return this._postionSensitivityTypeID;
            }
            set
            {
                this._postionSensitivityTypeID = value;
            }
        }

        public string PositionSenesitivityTypeName
        {
            get
            {
                return this._positionSenesitivityType;
            }
            set
            {
                this._positionSenesitivityType = value;
            }
        }

        public string PositionSensitivityTypeDescription
        {
            get
            {
                return this._positionSensitivityTypeDescription;
            }
            set
            {
                this._positionSensitivityTypeDescription = value;
            }
        }

        #endregion

        #region Constructors

        public PostionSensitivityType(DataRow singleRowData)
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
            this._postionSensitivityTypeID = (int)returnRow["PostionSensitivityTypeID"];
            this._positionSenesitivityType = returnRow["PositionSenesitivityType"].ToString();

            if (returnRow["PositionSensitivityTypeDescription"] != DBNull.Value)
                this._positionSensitivityTypeDescription = returnRow["PositionSensitivityTypeDescription"].ToString();
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
            return "PostionSensitivityTypeID:" + PostionSensitivityTypeID.ToString();
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
            PostionSensitivityType PostionSensitivityTypeobj = obj as PostionSensitivityType;

            return (PostionSensitivityTypeobj == null) ? false : (this.PostionSensitivityTypeID == PostionSensitivityTypeobj.PostionSensitivityTypeID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return PostionSensitivityTypeID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<PostionSensitivityType> GetCollection(DataTable dataItems)
        {
            List<PostionSensitivityType> listCollection = new List<PostionSensitivityType>();
            PostionSensitivityType current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PostionSensitivityType(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PostionSensitivityType collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

