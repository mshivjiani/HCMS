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
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups
{
    /// <summary>
    /// Grade Business Object
    /// </summary>
    [Serializable]
    public class Grade : BusinessBase
    {
        #region Private Members

        private int _gradeID = -1;
        private string _gradeName = string.Empty;

        #endregion

        #region Properties

        public int GradeID
        {
            get
            {
                return this._gradeID;
            }
            set
            {
                this._gradeID = value;
            }
        }

        public string GradeName
        {
            get
            {
                return this._gradeName;
            }
            set
            {
                this._gradeName = value;
            }
        }

        #endregion

        #region Constructors
        public Grade()
        {
        }
        public Grade(DataRow singleRowData)
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
            this._gradeID = (int)returnRow["GradeID"];

            if (returnRow["GradeName"] != DBNull.Value)
                this._gradeName = returnRow["GradeName"].ToString();
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
            return "GradeID:" + GradeID.ToString();
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
            Grade Gradeobj = obj as Grade;

            return (Gradeobj == null) ? false : (this.GradeID == Gradeobj.GradeID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return GradeID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static GradeCollection GetCollection(DataTable dataItems)
        {
            GradeCollection listCollection = new GradeCollection();
            Grade current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new Grade(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a Grade collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

