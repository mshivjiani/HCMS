using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Xml.Serialization;
using System.IO;

namespace HCMS.Business.Lookups
{
    [Serializable]
    public class WorkflowGroup : BusinessBase
    {
        #region Private Members

        private int _WorkflowGroupID = -1;
        private string _WorkflowGroupName = string.Empty;

        #endregion

        #region Properties

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
            return "WorkflowGroupID:" + this.WorkflowGroupID.ToString();
        }

        #endregion

        #region CompareMethods

        public bool Equals(Object obj)
        {
            WorkflowGroup workflowGroupObj = obj as WorkflowGroup;

            return (workflowGroupObj == null) ? false : (this.WorkflowGroupID == workflowGroupObj.WorkflowGroupID);
        }

        public int GetHashCode()
        {
            return this.WorkflowGroupID.GetHashCode();
        }

        #endregion
    }
}
