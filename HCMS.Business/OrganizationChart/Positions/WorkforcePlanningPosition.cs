using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Lookups;    

namespace HCMS.Business.OrganizationChart.Positions
{
    public class WorkforcePlanningPosition : BusinessBase, IWorkforcePlanningPosition
    {
        #region Properties

        public int WFPPositionID { get; set; }
       //public int OrgPositionTypeID { get; set; }
       public string OrgPositionType { get; set; }
       public enumOrgPositionType eOrgPositionType { get; set; }
       public int ReportsToID { get; set; }
       public string ReportsToFirstName { get; set; }
       public string ReportsToLastName { get; set; }
       public string PositionNumberBase { get; set; }
       public string PositionNumberSuffix { get; set; }
       public string EmployeeName { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string MiddleName { get; set; }
       public int? EmployeeCommonID { get; set; }
       public string FPPSSupervisorID { get; set; }
       public int? SupervisoryStatus { get; set; }
       public string SupervisorStatusTitle { get; set; }
       public int RegionID { get; set; }
       public int OrganizationCodeID { get; set; }
       public string OrganizationCode { get; set; }
       public string OrganizationName { get; set; }
       public int? OldOrganizationCode { get; set; }
       public string PositionTitle { get; set; }
       public int PayPlanID { get; set; }
       public string PayPlanAbbreviation { get; set; }
       public int SeriesID { get; set; }
       public string SeriesName { get; set; }
       public int Grade { get; set; }
       public int FPLGrade { get; set; }
       public int DutyStationCountryID { get; set; }
       public string DutyStationCountryName { get; set; }
       public string DutyStationDescription { get; set; }
       public int? DutyStationStateID { get; set; }
       public string DutyStationStateName { get; set; }
        //public int? AppointmentTypeID { get; set; }
       public string AppointmentType { get; set; }
       public int? AppointmentTypeCode { get; set; }
       public string AppointmentTypeDisplayAs { get; set; }
       public enumAppointmentType eAppointmentType { get; set; }
       //public int? WorkScheduleTypeID { get; set; }
       public string WorkScheduleTypeAbbreviation { get; set; }
       public string WorkScheduleTypeDesc { get; set; }
       public string WorkScheduleTypeDisplayAs { get; set; }
       public enumWorkScheduleType eWorkScheduleType { get; set; }
       public DateTime ? LastDateFilled { get; set; }
       public DateTime ? CreateDate { get; set; }
       public int CreatedByID { get; set; }
       public int? PositionStatusHistory { get; set; }
       public string PhoneNumber { get; set; }
       public string EmailAddress { get; set; }
       public int DirectChildCount { get; set; }
       public int UpdatedByID { get; set; }

       #region Custom Properties

       public string PaddedSeriesID
       {
           get
           {
               return this.SeriesID.ToString().PadLeft(4, '0');
           }
       }

       public string ReportsToFullName
       {
           get
           {
               return string.Format("{0} {1}", this.ReportsToFirstName.Trim(), this.ReportsToLastName).Trim();
           }
       }

       public string ReportsToFullNameReverse
       {
           get
           {
               string tempName = string.Empty;

               bool hasFirstName = !string.IsNullOrWhiteSpace(this.ReportsToFirstName);
               bool hasLastName = !string.IsNullOrWhiteSpace(this.ReportsToLastName);

               if (hasFirstName && hasLastName)
                   tempName = string.Format("{0}, {1}", this.ReportsToLastName.Trim(), this.ReportsToFirstName.Trim());
               else if (hasFirstName)
                   tempName = this.ReportsToFirstName;
               else if (hasLastName)
                   tempName = this.ReportsToLastName;

               return tempName;
           }
       }

       public string FullName
       {
           get
           {
               return string.Format("{0} {1}", this.FirstName.Trim(), this.LastName).Trim();
           }
       }

       public string FullNameReverse
       {
           get
           {
               string tempName = string.Empty;

               bool hasFirstName = !string.IsNullOrWhiteSpace(this.FirstName);
               bool hasLastName = !string.IsNullOrWhiteSpace(this.LastName);

               if (hasFirstName && hasLastName)
                   tempName = string.Format("{0}, {1}", this.LastName.Trim(), this.FirstName.Trim());
               else if (hasFirstName)
                   tempName = this.FirstName;
               else if (hasLastName)
                   tempName = this.LastName;

               return tempName;
           }
       }

       public string PositionLineItemFullName
       {
           get
           {
               string name = string.Empty;

               // terminology change based on design document
               if (this.PositionStatusHistory == null || this.PositionStatusHistory.Value == (int)enumOrgPositionStatusHistoryType.ActiveVacant)
                   name = string.IsNullOrWhiteSpace(this.PositionNumberBase) && string.IsNullOrWhiteSpace(this.PositionNumberSuffix) ?
                                    "Proposed Vacant" : "Vacant";
               else
                   // check to see if name is blank
                   name = string.IsNullOrWhiteSpace(this.FullName) ? "Vacant" : this.FullName;

               return string.Format("{0} ({1})", name, this.PositionTitle);
           }
       }

       public string PositionLineItemFullNameReverse
       {
           get
           {
               string name = string.Empty;

               // terminology change based on design document
               if (this.PositionStatusHistory == null || this.PositionStatusHistory.Value == (int)enumOrgPositionStatusHistoryType.ActiveVacant)
                   name = string.IsNullOrWhiteSpace(this.PositionNumberBase) && string.IsNullOrWhiteSpace(this.PositionNumberSuffix) ?
                                    "Proposed Vacant" : "Vacant";
               else
                   // check to see if name is blank
                   name = string.IsNullOrWhiteSpace(this.FullName) ? "Vacant" : this.FullNameReverse;

               return string.Format("{0} ({1})", name, this.PositionTitle);
           }
       }

       public string EmploymentStatus
       {
           get
           {
               return string.Format("{0} {1}", this.WorkScheduleTypeDisplayAs, this.AppointmentTypeDisplayAs);
           }
       }

       public string GradeFPLLineItem
       {
           get
           {
               string lineItem = string.Format("{0}{1}", this.Grade,
                    (this.FPLGrade == -1 ? string.Empty : string.Format("/{0}", this.FPLGrade)));

               return lineItem;
           }
       }

       #endregion

        #endregion

       #region Constructors

       public WorkforcePlanningPosition()
       {
           // setting the default values on auto-implemented properties
           this.WFPPositionID = -1;
           //this.OrgPositionTypeID = -1;
           this.OrgPositionType = string.Empty;
           this.eOrgPositionType = enumOrgPositionType.Undefined;
           this.ReportsToID = -1;
           this.ReportsToFirstName = string.Empty;
           this.ReportsToLastName = string.Empty;
           this.PositionNumberBase = string.Empty;
           this.PositionNumberSuffix = string.Empty;
           this.EmployeeName = string.Empty;
           this.FirstName = string.Empty;
           this.LastName = string.Empty;
           this.MiddleName = string.Empty;
           this.EmployeeCommonID = null;
           this.FPPSSupervisorID = string.Empty;
           this.SupervisoryStatus = null;
           this.SupervisorStatusTitle = string.Empty;
           this.RegionID = -1;
           this.OrganizationCodeID = -1;
           this.OrganizationCode = string.Empty;
           this.OldOrganizationCode = null;
           this.OrganizationName = string.Empty;
           this.PositionTitle = string.Empty;
           this.PayPlanID = -1;
           this.PayPlanAbbreviation = string.Empty;
           this.SeriesID = -1;
           this.SeriesName = string.Empty;
           this.Grade = -1;
           this.FPLGrade = -1;
           this.DutyStationCountryID = -1;
           this.DutyStationCountryName = string.Empty;
           this.DutyStationStateID = null;
           this.DutyStationStateName = string.Empty;
           this.DutyStationDescription = string.Empty;
           //this.AppointmentTypeID = null;
           this.AppointmentTypeCode = null;
           this.AppointmentTypeDisplayAs = string.Empty;
           this.eAppointmentType = enumAppointmentType.Undefined;
           //this.WorkScheduleTypeID = null;
           this.WorkScheduleTypeAbbreviation = string.Empty;
           this.WorkScheduleTypeDesc = string.Empty;
           this.WorkScheduleTypeDisplayAs = string.Empty;
           this.eWorkScheduleType = enumWorkScheduleType.Undefined;
           this.LastDateFilled = null;
           this.CreateDate = null;
           this.CreatedByID = -1;
           this.PositionStatusHistory = null;
           this.PhoneNumber = string.Empty;
           this.EmailAddress = string.Empty;
           this.DirectChildCount = 0;
           this.UpdatedByID = -1;
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
            return "WFPPositionID:" + WFPPositionID.ToString();
        }

        #endregion ToString Method
    }
}
