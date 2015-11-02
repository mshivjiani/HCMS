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
    /// Qualification Business Object
    /// </summary>
    [Serializable]
    public class Qualification : BusinessBase
    {
        #region Private Members

        private int _qualificationID = -1;
        private string _qualificationName = string.Empty;

        #endregion

        #region Properties

        public int QualificationID
        {
            get
            {
                return this._qualificationID;
            }
            set
            {
                this._qualificationID = value;
            }
        }

        public string QualificationName
        {
            get
            {
                return this._qualificationName;
            }
            set
            {
                this._qualificationName = value;
            }
        }

        #endregion

        #region Constructors

        public Qualification(DataRow singleRowData)
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
            this._qualificationID = (int)returnRow["QualificationID"];
            this._qualificationName = returnRow["QualificationName"].ToString();
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
            return "QualificationID:" + QualificationID.ToString();
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
            Qualification Qualificationobj = obj as Qualification;

            return (Qualificationobj == null) ? false : (this.QualificationID == Qualificationobj.QualificationID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return QualificationID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<Qualification> GetCollection(DataTable dataItems)
        {
            List<Qualification> listCollection = new List<Qualification>();
            Qualification current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new Qualification(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a Qualification collection from a null data table.");

            return listCollection;
        }

        #endregion

    }

    [System.ComponentModel.DataObject]
    public class QualificationDataSourceBusinessObject
    {
        public List<Qualification> GetObjects()
        {
            return LookupManager.GetAllQualifications();
        }
    }
}

