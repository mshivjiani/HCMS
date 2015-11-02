using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.OrganizationChart
{
   public interface IWorkforcePlanningPosition
    {
       int WFPPositionID { get; set; }
       int OrgPositionTypeID { get; set; }
       string OrgPositionType { get; set; }
       enumOrgPositionType eOrgPositionType { get; set; }
       int ReportsToID { get; set; }
       string PositionNumberBase { get; set; }
       int? PositionNumberSuffix { get; set; }
       string EmployeeName { get; set; }
       string FirstName { get; set; }
       string LastName { get; set; }
       string MiddleName { get; set; }
       int? EmployeeCommonID { get; set; }
       string FPPSSupervisorID { get; set; }
       int? SupervisoryStatus { get; set; }
       int RegionID { get; set; }
       int OrganizationCodeID { get; set; }
       string OrganizationCode { get; set; }
       int? OldOrganizationCode { get; set; }
       string PositionTitle { get; set; }
       int PayPlanID { get; set; }
       string PayPlanAbbreviation { get; set; }
       int SeriesID { get; set; }
       string SeriesName { get; set; }
       int Grade { get; set; }
       int FPLGrade { get; set; }
       string DutyStationDescription { get; set; }
       int? DutyStationState { get; set; }
       string DutyStationStateName { get; set; }
       int? AppointmentTypeID { get; set; }
       int? AppointmentTypeCode { get; set; }
       enumAppointmentType eAppointmentType { get; set; }
       int? WorkScheduleTypeID { get; set; }
       string WorkScheduleTypeAbbreviation { get; set; }
       enumWorkScheduleType eWorkScheduleType { get; set; }
       DateTime LastDateFilled { get; set; }
       DateTime CreateDate { get; set; }
       int CreatedByID { get; set; }
       int? PositionStatusHistory { get; set; }

    }
}
