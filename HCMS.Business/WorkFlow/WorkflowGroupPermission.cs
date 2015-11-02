using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Xml.Serialization;
using System.IO;

namespace HCMS.Business.PD
{
    [Serializable]
    public class WorkflowGroupPermission : BusinessBase
    {         
        
        #region Private Members

        private int _WorkflowGroupRecID = -1;
        private int _WorkflowGroupID = -1;
        private string _WorkflowGroupName = String.Empty;

        private int _PermissionID = -1;
        private string _PermissionName = String.Empty;

        #endregion

        #region Properties

        public int WorkflowGroupRecID
        {
            get
            {
                return this._WorkflowGroupRecID;
            }
            set
            {
                this._WorkflowGroupRecID = value;
            }
        }
        public int WorkflowGroupID
        {
            get
            {
                return this._WorkflowGroupID;
            }
            set
            {
                this._WorkflowGroupID = value;
            }
        }
        public string WorkflowGroupName
        {
            get
            {
                return this._WorkflowGroupName;
            }
            set
            {
                this._WorkflowGroupName = value;
            }
        }

        public int PermissionID
        {
            get
            {
                return this._PermissionID;
            }
            set
            {
                this._PermissionID = value;
            }
        }
        public string PermissionName
        {
            get
            {
                return this._PermissionName;
            }
            set
            {
                this._PermissionName = value;
            }
        }

        #endregion                                 

        #region ToXML Method

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

        public string ToString()
        {
            return "WorkflowGroupRecID:" + this.WorkflowGroupRecID.ToString();
        }

        #endregion

        #region CompareMethods

        public bool Equals(Object obj)
        {
            WorkflowGroupPermission workflowGroupPermissionObj = obj as WorkflowGroupPermission;

            return (workflowGroupPermissionObj == null) ? false : (this.WorkflowGroupRecID == workflowGroupPermissionObj.WorkflowGroupRecID);
        }

        public int GetHashCode()
        {
            return this.WorkflowGroupRecID.GetHashCode();
        }

        #endregion
    }
}
