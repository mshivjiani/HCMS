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

namespace HCMS.Lookups
{
    /// <summary>
    /// DocWorkflowStatus Business Object
    /// </summary>
    [Serializable]
    public class DocWorkflowStatus : BusinessBase
    {
        #region Private Members

        private int _docWorkflowStatusID = -1;
        private string _docWorkflowStatus = string.Empty;
        private string _docWorkflowStatusDescription = string.Empty;

        #endregion

        #region Properties

        public int DocWorkflowStatusID
        {
            get
            {
                return this._docWorkflowStatusID;
            }
            set
            {
                this._docWorkflowStatusID = value;
            }
        }

        public string DocWorkflowStatusName
        {
            get
            {
                return this._docWorkflowStatus;
            }
            set
            {
                this._docWorkflowStatus = value;
            }
        }

        public string DocWorkflowStatusDescription
        {
            get
            {
                return this._docWorkflowStatusDescription;
            }
            set
            {
                this._docWorkflowStatusDescription = value;
            }
        }

        #endregion

        #region Constructors

        public DocWorkflowStatus(DataRow singleRowData)
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
            this._docWorkflowStatusID = (int)returnRow["DocWorkflowStatusID"];
            this._docWorkflowStatus = returnRow["DocWorkflowStatus"].ToString();

            if (returnRow["DocWorkflowStatusDescription"] != DBNull.Value)
                this._docWorkflowStatusDescription = returnRow["DocWorkflowStatusDescription"].ToString();
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
            return "DocWorkflowStatusID:" + DocWorkflowStatusID.ToString();
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
            DocWorkflowStatus DocWorkflowStatusobj = obj as DocWorkflowStatus;

            return (DocWorkflowStatusobj == null) ? false : (this.DocWorkflowStatusID == DocWorkflowStatusobj.DocWorkflowStatusID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return DocWorkflowStatusID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<DocWorkflowStatus> GetCollection(DataTable dataItems)
        {
            List<DocWorkflowStatus> listCollection = new List<DocWorkflowStatus>();
            DocWorkflowStatus current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new DocWorkflowStatus(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a DocWorkflowStatus collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

