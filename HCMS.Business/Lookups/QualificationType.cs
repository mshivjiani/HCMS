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
    /// QualificationType Business Object
    /// </summary>
    [Serializable]
    public class QualificationType : BusinessBase
    {
        #region Private Members

        private int _qualificationTypeID = -1;
        private string _qualificationTypeName = string.Empty;

        #endregion

        #region Properties

        public int QualificationTypeID
        {
            get
            {
                return this._qualificationTypeID;
            }
            set
            {
                this._qualificationTypeID = value;
            }
        }

        public string QualificationTypeName
        {
            get
            {
                return this._qualificationTypeName;
            }
            set
            {
                this._qualificationTypeName = value;
            }
        }

        #endregion

        #region Constructors
        public QualificationType()
        {
            // Empty Constructor
        }

        public QualificationType(DataRow singleRowData)
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
            this._qualificationTypeID = (int)returnRow["QualificationTypeID"];
            this._qualificationTypeName = returnRow["QualificationTypeName"].ToString();
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
            return "QualificationTypeID:" + QualificationTypeID.ToString();
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
            QualificationType QualificationTypeobj = obj as QualificationType;

            return (QualificationTypeobj == null) ? false : (this.QualificationTypeID == QualificationTypeobj.QualificationTypeID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return QualificationTypeID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<QualificationType> GetCollection(DataTable dataItems)
        {
            List<QualificationType> listCollection = new List<QualificationType>();
            QualificationType current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new QualificationType(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a QualificationType collection from a null data table.");

            return listCollection;
        }

        #endregion

    }

    [System.ComponentModel.DataObject]
    public class QualificationTypeDataSourceBusinessObject
    {
        public List<QualificationType> GetObjects()
        {
            return LookupManager.GetAllQualificationTypes();
        }

        public List<QualificationType> GetDutyQualificationTypes()
        {
            List<QualificationType> lstqualtype = LookupManager.GetAllQualificationTypes();
            QualificationType coe=new QualificationType ();
            coe.QualificationTypeID = (int)enumQualificationType.ConditionOfEmployment;
            lstqualtype.Remove(coe);
            return lstqualtype;
        }
    }

    public class QualificationTypeEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}


