using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;

namespace HCMS.Business.OrganizationChart.Positions.Adapters
{
    public class WorkforcePlanningPositionDataAdapter : IEntityDataAdapter<WorkforcePlanningPosition>
    {
        public virtual void Fill(DataRow itemRow, WorkforcePlanningPosition item)
        {
            if (itemRow != null)
            {
                if (itemRow["WFPPositionID"] != DBNull.Value)
                    item.WFPPositionID = (int)itemRow["WFPPositionID"];

                if (itemRow["OrgPositionType"] != DBNull.Value)
                    item.OrgPositionType = itemRow["OrgPositionType"].ToString();

                if (itemRow["OrgPositionTypeID"] != DBNull.Value)
                {
                    if (Enum.IsDefined(typeof(enumOrgPositionType), itemRow["OrgPositionTypeID"]))
                        item.eOrgPositionType = (enumOrgPositionType)((int)itemRow["OrgPositionTypeID"]);
                }

                if (itemRow["ReportsToID"] != DBNull.Value)
                    item.ReportsToID = (int)itemRow["ReportsToID"];

                if (itemRow["ReportsToFirstName"] != DBNull.Value)
                    item.ReportsToFirstName = itemRow["ReportsToFirstName"].ToString();

                if (itemRow["ReportsToLastName"] != DBNull.Value)
                    item.ReportsToLastName = itemRow["ReportsToLastName"].ToString();

                if (itemRow["PositionNumberBase"] != DBNull.Value)
                    item.PositionNumberBase = itemRow["PositionNumberBase"].ToString();

                if (itemRow["PositionNumberSuffix"] != DBNull.Value)
                    item.PositionNumberSuffix = itemRow["PositionNumberSuffix"].ToString();

                if (itemRow["EmployeeName"] != DBNull.Value)
                    item.EmployeeName = itemRow["EmployeeName"].ToString();

                if (itemRow["FirstName"] != DBNull.Value)
                    item.FirstName = itemRow["FirstName"].ToString();

                if (itemRow["LastName"] != DBNull.Value)
                    item.LastName = itemRow["LastName"].ToString();

                if (itemRow["MiddleName"] != DBNull.Value)
                    item.MiddleName = itemRow["MiddleName"].ToString();

                if (itemRow["EmployeeCommonID"] != DBNull.Value)
                    item.EmployeeCommonID = (int)itemRow["EmployeeCommonID"];

                if (itemRow["FPPSSupervisorID"] != DBNull.Value)
                    item.FPPSSupervisorID = itemRow["FPPSSupervisorID"].ToString();

                if (itemRow["SupervisoryStatus"] != DBNull.Value)
                    item.SupervisoryStatus = (int)itemRow["SupervisoryStatus"];

                if (itemRow["SupervisorStatusTitle"] != DBNull.Value)
                    item.SupervisorStatusTitle = itemRow["SupervisorStatusTitle"].ToString();

                if (itemRow["RegionID"] != DBNull.Value)
                    item.RegionID = (int)itemRow["RegionID"];

                if (itemRow["OrganizationCodeID"] != DBNull.Value)
                    item.OrganizationCodeID = (int)itemRow["OrganizationCodeID"];

                if (itemRow["OrganizationCode"] != DBNull.Value)
                    item.OrganizationCode = itemRow["OrganizationCode"].ToString();

                if (itemRow["OldOrganizationCode"] != DBNull.Value)
                    item.OldOrganizationCode = (int)itemRow["OldOrganizationCode"];

                if (itemRow["OrganizationName"] != DBNull.Value)
                    item.OrganizationName = itemRow["OrganizationName"].ToString();

                if (itemRow["PositionTitle"] != DBNull.Value)
                    item.PositionTitle = itemRow["PositionTitle"].ToString();

                if (itemRow["PayPlanID"] != DBNull.Value)
                    item.PayPlanID = (int)itemRow["PayPlanID"];

                if (itemRow["PayPlanAbbrev"] != DBNull.Value)
                    item.PayPlanAbbreviation = itemRow["PayPlanAbbrev"].ToString();

                if (itemRow["SeriesID"] != DBNull.Value)
                    item.SeriesID = (int)itemRow["SeriesID"];

                if (itemRow["SeriesName"] != DBNull.Value)
                    item.SeriesName = itemRow["SeriesName"].ToString();

                if (itemRow["Grade"] != DBNull.Value)
                    item.Grade = (int)itemRow["Grade"];

                if (itemRow["FPLGrade"] != DBNull.Value)
                    item.FPLGrade = (int)itemRow["FPLGrade"];

                if (itemRow["DutyStationCountryID"] != DBNull.Value)
                    item.DutyStationCountryID = (int)itemRow["DutyStationCountryID"];

                if (itemRow["DutyStationCountryName"] != DBNull.Value)
                    item.DutyStationCountryName = itemRow["DutyStationCountryName"].ToString();

                if (itemRow["DutyStationStateID"] != DBNull.Value)
                    item.DutyStationStateID = (int)itemRow["DutyStationStateID"];

                if (itemRow["DutyStationStateName"] != DBNull.Value)
                    item.DutyStationStateName = itemRow["DutyStationStateName"].ToString();

                if (itemRow["DutyStationDescription"] != DBNull.Value)
                    item.DutyStationDescription = itemRow["DutyStationDescription"].ToString();
                
                if (itemRow["AppointmentTypeID"] != DBNull.Value)
                {
                    if (Enum.IsDefined(typeof(enumAppointmentType), itemRow["AppointmentTypeID"]))
                        item.eAppointmentType = (enumAppointmentType)((int)itemRow["AppointmentTypeID"]);
                }

                if (itemRow["AppointmentTypeCode"] != DBNull.Value)
                    item.AppointmentTypeCode = (int)itemRow["AppointmentTypeCode"];

                if (itemRow["AppointmentTypeDisplayAs"] != DBNull.Value)
                    item.AppointmentTypeDisplayAs = itemRow["AppointmentTypeDisplayAs"].ToString();

                if (itemRow["WorkScheduleTypeAbbrev"] != DBNull.Value)
                    item.WorkScheduleTypeAbbreviation = itemRow["WorkScheduleTypeAbbrev"].ToString();

                if (itemRow["WorkScheduleTypeDisplayAs"] != DBNull.Value)
                    item.WorkScheduleTypeDisplayAs = itemRow["WorkScheduleTypeDisplayAs"].ToString();

                if (itemRow["WorkScheduleTypeID"] != DBNull.Value)
                {
                    if (Enum.IsDefined(typeof(enumWorkScheduleType), itemRow["WorkScheduleTypeID"]))
                        item.eWorkScheduleType = (enumWorkScheduleType)((int)itemRow["WorkScheduleTypeID"]);
                }

                if (itemRow["LastDateFilled"] != DBNull.Value)
                    item.LastDateFilled = (DateTime)itemRow["LastDateFilled"];

                if (itemRow["CreateDate"] != DBNull.Value)
                    item.CreateDate = (DateTime)itemRow["CreateDate"];

                if (itemRow["CreatedByID"] != DBNull.Value)
                    item.CreatedByID = (int)itemRow["CreatedByID"];

                if (itemRow["PositionStatusHistory"] != DBNull.Value)
                    item.PositionStatusHistory = (int)itemRow["PositionStatusHistory"];

                if (itemRow["PhoneNumber"] != DBNull.Value)
                    item.PhoneNumber = itemRow["PhoneNumber"].ToString();

                if (itemRow["EmailAddress"] != DBNull.Value)
                    item.EmailAddress = itemRow["EmailAddress"].ToString();

                if (itemRow["WorkScheduleTypeDesc"] != DBNull.Value)
                    item.WorkScheduleTypeDesc = itemRow["WorkScheduleTypeDesc"].ToString();

                if (itemRow["AppointmentType"] != DBNull.Value)
                    item.AppointmentType = itemRow["AppointmentType"].ToString();

                if (itemRow["DirectChildCount"] != DBNull.Value)
                    item.DirectChildCount = (int)itemRow["DirectChildCount"];
            }
        }
    }
}
