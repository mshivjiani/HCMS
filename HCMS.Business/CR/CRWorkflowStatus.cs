using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using HCMS.Business.Base;
using HCMS.Business.Common;

namespace HCMS.Business.CR
{
    [Serializable]
    public class CRWorkflowStatus 
    {
        #region Private Members

        private long _crWorkflowRecID = -1;
        private long _crID = -1;
        private int _crWorkflowStatusID = -1;
        private bool _isCurrent = false;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;

        #endregion

        #region [ Public Properties ]
        public long CRWorkflowRecID { get { return this._crWorkflowRecID; } set { this._crWorkflowRecID = value; } }  // PK
        public long CRID { get { return this._crID; } set { this._crID = value; } }  // FK
        public int CRWorkflowStatusID { get { return this._crWorkflowStatusID; } set { this._crWorkflowStatusID = value; } }
        public bool IsCurrent { get { return this._isCurrent; } set { this._isCurrent = value; } }
        public int CreatedByID { get { return this._createdByID; } set { this._createdByID = value; } }
        public DateTime CreateDate { get { return this._createDate; } set { this._createDate = value; } }
        #endregion

        #region [ Constructors ]
        public CRWorkflowStatus()
        {
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
            return "CRWorkflowRecID:" + CRWorkflowRecID.ToString();
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
            CRWorkflowStatus CRWorkflowStatusobj = obj as CRWorkflowStatus;

            return (CRWorkflowStatusobj == null) ? false : (this.CRWorkflowRecID == CRWorkflowStatusobj.CRWorkflowRecID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return CRWorkflowRecID.GetHashCode();
        }
        #endregion
	
    }
}
