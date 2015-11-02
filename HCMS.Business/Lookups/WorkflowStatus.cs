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
    /// WorkflowStatus Business Object
    /// </summary>
    [Serializable]
    public class WorkflowStatus : BusinessBase
    {
        #region Private Members

        private int _workflowStatusID = -1;
        private string _workflowStatus = string.Empty;
        private string _workflowStatusDescription = string.Empty;

        #endregion

        #region Properties

        public int WorkflowStatusID
        {
            get
            {
                return this._workflowStatusID;
            }
            set
            {
                this._workflowStatusID = value;
            }
        }

        public string WorkflowStatusName
        {
            get
            {
                return this._workflowStatus;
            }
            set
            {
                this._workflowStatus = value;
            }
        }

        public string WorkflowStatusDescription
        {
            get
            {
                return this._workflowStatusDescription;
            }
            set
            {
                this._workflowStatusDescription = value;
            }
        }

        #endregion

        #region Constructors
        public WorkflowStatus()
        {
            // empty constructor
        }
        public WorkflowStatus(DataRow singleRowData)
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
            this._workflowStatusID = (int)returnRow["WorkflowStatusID"];
            this._workflowStatus = returnRow["WorkflowStatus"].ToString();

            if (returnRow["WorkflowStatusDescription"] != DBNull.Value)
                this._workflowStatusDescription = returnRow["WorkflowStatusDescription"].ToString();
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
            return "WorkflowStatusID:" + WorkflowStatusID.ToString();
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
            WorkflowStatus WorkflowStatusobj = obj as WorkflowStatus;

            return (WorkflowStatusobj == null) ? false : (this.WorkflowStatusID == WorkflowStatusobj.WorkflowStatusID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return WorkflowStatusID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<WorkflowStatus> GetCollection(DataTable dataItems)
        {
            List<WorkflowStatus> listCollection = new List<WorkflowStatus>();
            WorkflowStatus current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new WorkflowStatus(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a WorkflowStatus collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

