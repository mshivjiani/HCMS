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
    /// ClassificationStandardSource Business Object
    /// </summary>
    [Serializable]
    public class ClassificationStandardSource : BusinessBase
    {
        #region Private Members

        private int _classificationSourceID = -1;
        private string _classificationSourceTitle = string.Empty;
        private string _classificationSourceDescription = string.Empty;
        private int _factorFormatTypeID = -1;
        private string _factorFormatType = string.Empty;

        #endregion

        #region Properties

        public int ClassificationSourceID
        {
            get
            {
                return this._classificationSourceID;
            }
            set
            {
                this._classificationSourceID = value;
            }
        }

        public string ClassificationSourceTitle
        {
            get
            {
                return this._classificationSourceTitle;
            }
            set
            {
                this._classificationSourceTitle = value;
            }
        }

        public string ClassificationSourceDescription
        {
            get
            {
                return this._classificationSourceDescription;
            }
            set
            {
                this._classificationSourceDescription = value;
            }
        }

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
        public string FactorFormatType
        {
            get
            {
                return this._factorFormatType;
            }
            set
            {
                this._factorFormatType = value;
            }
        }

        #endregion

        #region Constructors
        public ClassificationStandardSource()
        {
        }
        public ClassificationStandardSource(DataRow singleRowData)
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
            this._classificationSourceID = (int)returnRow["ClassificationSourceID"];
            this._classificationSourceTitle = returnRow["ClassificationSourceTitle"].ToString();

            if (returnRow["ClassificationSourceDescription"] != DBNull.Value)
                this._classificationSourceDescription = returnRow["ClassificationSourceDescription"].ToString();

            if (returnRow["FactorFormatTypeID"] != DBNull.Value)
                this._factorFormatTypeID = (int)returnRow["FactorFormatTypeID"];
            DataColumnCollection columns = returnRow.Table.Columns;
            if (columns.Contains("FactorFormatType"))
            {
                this._factorFormatType = returnRow["FactorFormatType"].ToString();
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
            return "ClassificationSourceID:" + ClassificationSourceID.ToString();
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
            ClassificationStandardSource ClassificationStandardSourceobj = obj as ClassificationStandardSource;

            return (ClassificationStandardSourceobj == null) ? false : (this.ClassificationSourceID == ClassificationStandardSourceobj.ClassificationSourceID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ClassificationSourceID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<ClassificationStandardSource> GetCollection(DataTable dataItems)
        {
            List<ClassificationStandardSource> listCollection = new List<ClassificationStandardSource>();
            ClassificationStandardSource current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new ClassificationStandardSource(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a ClassificationStandardSource collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

