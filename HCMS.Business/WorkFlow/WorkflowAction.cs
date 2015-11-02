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
    public class WorkflowAction : BusinessBase
    {                
        
        #region Private Members

        //Action
        private int _WorkflowActionRecID = -1;
        private int _WorkflowRuleID = -1;
        private int _ActionTypeID = -1;
        private string _ActionTypeName = String.Empty;        
 
        //Rule  
        private int _StaffingObjectCurrentStatusID = -1;
        private string _StaffingObjectCurrentStatusName = String.Empty;

        private int _WorkflowGroupID = -1;
        private string _WorkflowGroupName = String.Empty;

        private int _StaffingObjectTypeID = -1;
        private string _StaffingObjectTypeName = String.Empty;

        private string _WorkflowStatus = String.Empty;

        #endregion

        #region Properties

        //Action Properties
        public int WorkflowActionRecID
        {
            get
            {
                return this._WorkflowActionRecID;
            }
            set
            {
                this._WorkflowActionRecID = value;
            }
        }
        public int WorkflowRuleID
        {
            get
            {
                return this._WorkflowRuleID;
            }
            set
            {
                this._WorkflowRuleID = value;
            }
        }
        public int ActionTypeID
        {
            get
            {
                return this._ActionTypeID;
            }
            set
            {
                this._ActionTypeID = value;
            }
        }
        public string ActionTypeName
        {
            get
            {
                return this._ActionTypeName;
            }
            set
            {
                this._ActionTypeName = value;
            }
        }         

        //Rule Properties   
        public int StaffingObjectCurrentStatusID
        {
            get
            {
                return this._StaffingObjectCurrentStatusID;
            }
            set
            {
                this._StaffingObjectCurrentStatusID = value;
            }
        }
        public string StaffingObjectCurrentStatusName
        {
            get
            {
                return this._StaffingObjectCurrentStatusName;
            }
            set
            {
                this._StaffingObjectCurrentStatusName = value;
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

        public int StaffingObjectTypeID
        {
            get
            {
                return this._StaffingObjectTypeID;
            }
            set
            {
                this._StaffingObjectTypeID = value;
            }
        }
        public string StaffingObjectTypeName
        {
            get
            {
                return this._StaffingObjectTypeName;
            }
            set
            {
                this._StaffingObjectTypeName = value;
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
            return "WorkflowActionRecID:" + this.WorkflowActionRecID.ToString();
        }

        #endregion

        #region CompareMethods

        public bool Equals(Object obj)
        {
            WorkflowAction workflowActionObj = obj as WorkflowAction;

            return (workflowActionObj == null) ? false : (this.WorkflowActionRecID == workflowActionObj.WorkflowActionRecID);
        }

        public int GetHashCode()
        {
            return this.WorkflowActionRecID.GetHashCode();
        }

        #endregion
    }
}
