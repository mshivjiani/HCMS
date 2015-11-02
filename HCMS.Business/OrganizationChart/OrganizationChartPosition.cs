using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Lookups;

namespace HCMS.Business.OrganizationChart
{
    [Serializable]
    public class OrganizationChartPosition : BusinessBase, IWorkforcePlanningPosition
    {
       public int WFPPositionID { get; set; }
       public int OrgPositionTypeID { get; set; }
       public string OrgPositionType { get; set; }
       public enumOrgPositionType eOrgPositionType { get; set; }
       public int ReportsToID { get; set; }
       public string PositionNumberBase { get; set; }
       public int? PositionNumberSuffix { get; set; }
       public string EmployeeName { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string MiddleName { get; set; }
       public int? EmployeeCommonID { get; set; }
       public string FPPSSupervisorID { get; set; }
       public int? SupervisoryStatus { get; set; }
       public int RegionID { get; set; }
       public int OrganizationCodeID { get; set; }
       public string OrganizationCode { get; set; }
       public int? OldOrganizationCode { get; set; }
       public string PositionTitle { get; set; }
       public int PayPlanID { get; set; }
       public string PayPlanAbbreviation { get; set; }
       public int SeriesID { get; set; }
       public string SeriesName { get; set; }
       public int Grade { get; set; }
       public int FPLGrade { get; set; }
       public string DutyStationDescription { get; set; }
       public int? DutyStationState { get; set; }
       public string DutyStationStateName { get; set; }
       public int? AppointmentTypeID { get; set; }
       public int? AppointmentTypeCode { get; set; }
       public enumAppointmentType eAppointmentType { get; set; }
       public int? WorkScheduleTypeID { get; set; }
       public string WorkScheduleTypeAbbreviation { get; set; }
       public enumWorkScheduleType eWorkScheduleType { get; set; }
       public DateTime LastDateFilled { get; set; }
       public DateTime CreateDate { get; set; }
       public int CreatedByID { get; set; }
       public int? PositionStatusHistory { get; set; }
       public string PhoneNumber { get; set; }

       public string LastNameFirstName 
       {      
            get     
            {
                return LastName + ", " + FirstName;
            }        
       } 

        // OrganizationChartPosition specific prop
       public 	int OrganizationChartID{get;set;}
	   public   int OrgPositionGroupTypeID{get;set;}
       public   string OrgPositionGroupType { get; set; }
       public   enumOrgPositionGroupType eOrgPositionGroupType { get; set; }




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
                return "OrganizationChartPositionID:" + WFPPositionID.ToString();
            }

            #endregion ToString Method

    }
}
