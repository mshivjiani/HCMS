using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Xml.Serialization;
using System.IO;
using HCMS.Business.Security;
using HCMS.Business.Lookups;

namespace HCMS.Business.OrganizationChart
{
    [Serializable]
    public abstract class OrganizationChartBase : IOrganizationChart
    {
        #region Properties

        public int OrganizationChartID { get; set; }
        public enumOrgChartType OrganizationChartTypeID { get; set; }
        public string OrganizationChartTypeName { get; set; }
        public string OrganizationName { get; set; }
        public enumOrgWorkflowStatus OrgWorkflowStatusID { get; set; }
        public string OrgWorkflowStatusName { get; set; }
        public DateTime? OrgWorkflowStatusCreateDate { get; set; }
        public string Header1 { get; set; }
        public string Header2 { get; set; }
        public string Header3 { get; set; }
        public string Header4 { get; set; }
        public string Footer { get; set; }
        public OrganizationCode OrgCode { get; set; }
        public ActionUser CreatedBy { get; set; }
        public ActionUser UpdatedBy { get; set; }
        
        public int StartPointWFPPositionID { get; set; }
        public string StartPointWFPFirstName { get; set; }
        public string StartPointWFPLastName { get; set; }
        public string StartPointWFPPositionTitle { get; set; }
        public enumOrgPositionStatusHistoryType StartPointWFPPositionStatusHistory { get; set; }
        
        public string StartPointWFPFullName 
        {
            get
            {
                return string.Format("{0} {1}", this.StartPointWFPFirstName.Trim(), this.StartPointWFPLastName).Trim();
            }
        }
        public string StartPointWFPFullNameReverse 
        {
            get
            {
                string tempString = string.Empty;

                bool hasFirstName = !string.IsNullOrWhiteSpace(this.StartPointWFPFirstName);
                bool hasLastName = !string.IsNullOrWhiteSpace(this.StartPointWFPLastName);
                
                if (hasFirstName && hasLastName)
                    tempString = string.Format("{0}, {1}", this.StartPointWFPLastName.Trim(), this.StartPointWFPFirstName.Trim());
                else if (hasFirstName)
                    tempString = this.StartPointWFPFirstName.Trim();
                else if (hasLastName)
                    tempString = this.StartPointWFPLastName.Trim();

                return tempString;
            }
        }

        public string StartPointPositionLineItemFullName
        {
            get
            {
                string name = string.IsNullOrWhiteSpace(this.StartPointWFPFullName) || 
                            (StartPointWFPPositionStatusHistory == enumOrgPositionStatusHistoryType.ActiveVacant) ? "Vacant" : this.StartPointWFPFullName;

                return string.Format("{0} ({1})", name, this.StartPointWFPPositionTitle);
            }
        }

        public string StartPointPositionLineItemFullNameReverse
        {
            get
            {
                string name = string.IsNullOrWhiteSpace(this.StartPointWFPFullName) ||
                            (StartPointWFPPositionStatusHistory == enumOrgPositionStatusHistoryType.ActiveVacant) ? "Vacant" : this.StartPointPositionLineItemFullNameReverse;

                return string.Format("{0} ({1})", name, this.StartPointWFPPositionTitle);
            }
        }
        
        #endregion

        #region Constructors

        public OrganizationChartBase()
        {
            // set default values for auto-implemented properties
            this.OrganizationChartID = -1;
            this.OrganizationChartTypeID = enumOrgChartType.Undefined;
            this.OrganizationChartTypeName = string.Empty;
            this.OrganizationName = string.Empty;
            this.OrgWorkflowStatusID = enumOrgWorkflowStatus.Undefined;
            this.OrgWorkflowStatusName = string.Empty;
            this.Header1 = string.Empty;
            this.Header2 = string.Empty;
            this.Header3 = string.Empty;
            this.Header4 = string.Empty;
            this.Footer = string.Empty;

            this.StartPointWFPPositionID = -1;
            this.StartPointWFPFirstName = string.Empty;
            this.StartPointWFPLastName = string.Empty;
            this.StartPointWFPPositionTitle = string.Empty;
            this.StartPointWFPPositionStatusHistory = enumOrgPositionStatusHistoryType.Undefined;
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
            return "OrganizationChartID:" + this.OrganizationChartID.ToString();
        }

        #endregion ToString Method
    }
}
