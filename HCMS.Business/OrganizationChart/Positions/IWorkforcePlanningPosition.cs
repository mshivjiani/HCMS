using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.OrganizationChart.Positions
{
   public interface IWorkforcePlanningPosition
    {
       int WFPPositionID { get; set; }
       //int OrgPositionTypeID { get; set; }
       string OrgPositionType { get; set; }
       enumOrgPositionType eOrgPositionType { get; set; }
       int ReportsToID { get; set; }
       string ReportsToFirstName { get; set; }
       string ReportsToLastName { get; set; }
       string PositionNumberBase { get; set; }
       string PositionNumberSuffix { get; set; }
       string EmployeeName { get; set; }
       string FirstName { get; set; }
       string LastName { get; set; }
       string MiddleName { get; set; }
       int? EmployeeCommonID { get; set; }
       string FPPSSupervisorID { get; set; }
       int? SupervisoryStatus { get; set; }
       string SupervisorStatusTitle { get; set; }
       int RegionID { get; set; }
       int OrganizationCodeID { get; set; }
       string OrganizationCode { get; set; }
       string OrganizationName { get; set; }
       int? OldOrganizationCode { get; set; }
       string PositionTitle { get; set; }
       int PayPlanID { get; set; }
       string PayPlanAbbreviation { get; set; }
       int SeriesID { get; set; }
       string SeriesName { get; set; }
       int Grade { get; set; }
       int FPLGrade { get; set; }
       int DutyStationCountryID { get; set; }
       string DutyStationCountryName { get; set; }
       string DutyStationDescription { get; set; }
       int? DutyStationStateID { get; set; }
       string DutyStationStateName { get; set; }
       //int? AppointmentTypeID { get; set; }
       string AppointmentType { get; set; }
       int? AppointmentTypeCode { get; set; }
       string AppointmentTypeDisplayAs { get; set; }
       enumAppointmentType eAppointmentType { get; set; }
       //int? WorkScheduleTypeID { get; set; }
       string WorkScheduleTypeAbbreviation { get; set; }
       string WorkScheduleTypeDesc { get; set; }
       string WorkScheduleTypeDisplayAs { get; set; }
       enumWorkScheduleType eWorkScheduleType { get; set; }
       DateTime ? LastDateFilled { get; set; }
       DateTime ? CreateDate { get; set; }
       int CreatedByID { get; set; }
       int? PositionStatusHistory { get; set; }
       string PhoneNumber { get; set; }
       string EmailAddress { get; set; }
       int DirectChildCount { get; set; }
       int UpdatedByID { get; set; }

       #region Custom Properties

       string PaddedSeriesID { get; }
       string ReportsToFullName { get; }
       string ReportsToFullNameReverse { get; }
       string FullName { get; }
       string FullNameReverse { get; }
       string PositionLineItemFullName { get; }
       string PositionLineItemFullNameReverse { get; }
       string EmploymentStatus { get; }
       string GradeFPLLineItem { get; }

       #endregion
    }
}
