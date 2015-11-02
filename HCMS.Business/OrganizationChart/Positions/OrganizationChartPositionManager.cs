using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Lookups;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.Business.OrganizationChart.Positions.Exceptions;
using HCMS.Business.OrganizationChart.Positions.Adapters;
using HCMS.Business.OrganizationChart.Exceptions;

namespace HCMS.Business.OrganizationChart.Positions
{
    public class OrganizationChartPositionManager : RepositoryBase<OrganizationChartPositionManager, OrganizationChartPosition, OrganizationChartPositionDataAdapter>
    {
        #region Get Methods

        public OrganizationChartPosition GetByID(int OrganizationChartID, int WFPPositionID)
        {
            return base.GetItem("spr_GetOrgChartPositionByID", OrganizationChartID, WFPPositionID);
        }
        
        #endregion
        
        #region CUD Methods

        public int Add(OrganizationChartPosition newPosition)
        {
            int newWFPPositionID = -1;

            if (string.IsNullOrWhiteSpace(newPosition.PositionTitle))
                throw new BusinessException("Position Title is required");
            else if (base.ValidateKeyField(newPosition.OrganizationChartID) && 
                        base.ValidateKeyField(newPosition.OrganizationCodeID) &&
                        base.ValidateKeyField(newPosition.CreatedByID))
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_CreateOrgChartPosition");

                    SqlParameter newIdentityParam = new SqlParameter();

                    // parameter for identity
                    newIdentityParam.ParameterName = "@newID";
                    newIdentityParam.Direction = ParameterDirection.Output;
                    newIdentityParam.DbType = DbType.Int32;
                    newIdentityParam.Size = 4;
                    commandWrapper.Parameters.Add(newIdentityParam);

                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", newPosition.OrganizationChartID));
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCodeID", newPosition.OrganizationCodeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionTitle", newPosition.PositionTitle.Trim()));

                    if (newPosition.eOrgPositionType == enumOrgPositionType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionTypeID", (int) newPosition.eOrgPositionType));
                    
                    if (string.IsNullOrWhiteSpace(newPosition.PositionNumberBase))
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberBase", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberBase", newPosition.PositionNumberBase.Trim()));

                    if (string.IsNullOrWhiteSpace(newPosition.PositionNumberSuffix))
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberSuffix", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberSuffix", newPosition.PositionNumberSuffix.Trim()));

                    if (string.IsNullOrWhiteSpace(newPosition.EmployeeName))
                        commandWrapper.Parameters.Add(new SqlParameter("@EmployeeName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@EmployeeName", newPosition.EmployeeName));

                    if (string.IsNullOrWhiteSpace(newPosition.FirstName))
                        commandWrapper.Parameters.Add(new SqlParameter("@FirstName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@FirstName", newPosition.FirstName.Trim()));

                    if (string.IsNullOrWhiteSpace(newPosition.LastName))
                        commandWrapper.Parameters.Add(new SqlParameter("@LastName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@LastName", newPosition.LastName.Trim()));

                    if (string.IsNullOrWhiteSpace(newPosition.MiddleName))
                        commandWrapper.Parameters.Add(new SqlParameter("@MiddleName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@MiddleName", newPosition.MiddleName.Trim()));

                    if (newPosition.EmployeeCommonID.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@EmployeeCommonID", newPosition.EmployeeCommonID));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@EmployeeCommonID", DBNull.Value));

                    if (string.IsNullOrWhiteSpace(newPosition.FPPSSupervisorID))
                        commandWrapper.Parameters.Add(new SqlParameter("@FPPSSupervisorID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@FPPSSupervisorID", newPosition.FPPSSupervisorID.Trim()));

                    if (newPosition.SupervisoryStatus.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@SupervisoryStatus", newPosition.SupervisoryStatus));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@SupervisoryStatus", DBNull.Value));

                    if (newPosition.RegionID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@RegionID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@RegionID", newPosition.RegionID));

                    if (newPosition.PayPlanID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@PayPlanID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PayPlanID", newPosition.PayPlanID));

                    if (newPosition.SeriesID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", newPosition.SeriesID));

                    if (newPosition.Grade == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@Grade", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@Grade", newPosition.Grade));

                    if (newPosition.FPLGrade == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@FPLGrade", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@FPLGrade", newPosition.FPLGrade));

                    if (newPosition.DutyStationCountryID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationCountryID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationCountryID", newPosition.DutyStationCountryID));

                    if (newPosition.DutyStationStateID.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationStateID", newPosition.DutyStationStateID));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationStateID", DBNull.Value));

                    if (string.IsNullOrWhiteSpace(newPosition.DutyStationDescription))
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationDescription", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationDescription", newPosition.DutyStationDescription.Trim()));

                    if (newPosition.eAppointmentType == enumAppointmentType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@AppointmentTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@AppointmentTypeID", newPosition.eAppointmentType));

                    if (newPosition.eWorkScheduleType == enumWorkScheduleType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkScheduleTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkScheduleTypeID", newPosition.eWorkScheduleType));

                    if (newPosition.LastDateFilled.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@LastDateFilled", newPosition.LastDateFilled.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@LastDateFilled", DBNull.Value));

                    commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", newPosition.CreatedByID));

                    if (newPosition.PositionStatusHistory.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionStatusHistory", newPosition.PositionStatusHistory));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionStatusHistory", DBNull.Value));
                    
                    if (newPosition.ReportsToID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@ReportsToID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ReportsToID", newPosition.ReportsToID));

                    if (newPosition.PositionGroupType == enumOrgPositionGroupType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@GroupTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@GroupTypeID", (int)newPosition.PositionGroupType));

                    if (newPosition.PositionPlacementType == enumOrgPositionPlacementType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@PlacementTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PlacementTypeID", (int) newPosition.PositionPlacementType));

                    ExecuteNonQuery(commandWrapper);

                    // set primary key field to new identity
                    newWFPPositionID = (int)newIdentityParam.Value;
                    newPosition.WFPPositionID = newWFPPositionID;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Parent Not In Chart")
                        throw new InvalidParentChartPositionException();
                    else
                        HandleException(ex);
                }
            }

            return newWFPPositionID;
        }

        public void UpdateFPPS(OrganizationChartPosition position)
        {
            if (base.ValidateKeyField(position.OrganizationChartID) && base.ValidateKeyField(position.WFPPositionID))
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_UpdateFPPSChartPosition");

                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", position.OrganizationChartID));
                    commandWrapper.Parameters.Add(new SqlParameter("@WFPPositionID", position.WFPPositionID));

                    if (position.eOrgPositionType == enumOrgPositionType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionTypeID", (int)position.eOrgPositionType));

                    if (position.ReportsToID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@ReportsToParentPositionID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ReportsToParentPositionID", position.ReportsToID));

                    if (position.PositionGroupType == enumOrgPositionGroupType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@GroupTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@GroupTypeID", (int) position.PositionGroupType));

                    if (position.PositionPlacementType == enumOrgPositionPlacementType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@PlacementTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PlacementTypeID", (int) position.PositionPlacementType));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByUserID", position.UpdatedByID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {	
                    if (ex.Message == "Invalid Parent Position" || ex.Message == "Invalid Root Parent Position")
                        throw new InvalidParentChartPositionException(ex.Message);
                    else
                        HandleException(ex);
                }
            }
        }

        public void UpdateWFP(OrganizationChartPosition position)
        {
            if (string.IsNullOrWhiteSpace(position.PositionTitle))
                throw new BusinessException("Position Title is required");
            else if (
                        base.ValidateKeyField(position.WFPPositionID) &&
                        base.ValidateKeyField(position.OrganizationChartID) &&
                        base.ValidateKeyField(position.OrganizationCodeID))
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_UpdateWFPChartPosition");

                    commandWrapper.Parameters.Add(new SqlParameter("@WFPPositionID", position.WFPPositionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", position.OrganizationChartID));
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCodeID", position.OrganizationCodeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionTitle", position.PositionTitle.Trim()));

                    if (position.eOrgPositionType == enumOrgPositionType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionTypeID", (int)position.eOrgPositionType));

                    if (string.IsNullOrWhiteSpace(position.PositionNumberBase))
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberBase", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberBase", position.PositionNumberBase.Trim()));

                    if (string.IsNullOrWhiteSpace(position.PositionNumberSuffix))
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberSuffix", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberSuffix", position.PositionNumberSuffix.Trim()));

                    if (string.IsNullOrWhiteSpace(position.EmployeeName))
                        commandWrapper.Parameters.Add(new SqlParameter("@EmployeeName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@EmployeeName", position.EmployeeName));

                    if (string.IsNullOrWhiteSpace(position.FirstName))
                        commandWrapper.Parameters.Add(new SqlParameter("@FirstName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@FirstName", position.FirstName.Trim()));

                    if (string.IsNullOrWhiteSpace(position.LastName))
                        commandWrapper.Parameters.Add(new SqlParameter("@LastName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@LastName", position.LastName.Trim()));

                    if (string.IsNullOrWhiteSpace(position.MiddleName))
                        commandWrapper.Parameters.Add(new SqlParameter("@MiddleName", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@MiddleName", position.MiddleName.Trim()));

                    if (position.EmployeeCommonID.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@EmployeeCommonID", position.EmployeeCommonID));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@EmployeeCommonID", DBNull.Value));

                    if (string.IsNullOrWhiteSpace(position.FPPSSupervisorID))
                        commandWrapper.Parameters.Add(new SqlParameter("@FPPSSupervisorID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@FPPSSupervisorID", position.FPPSSupervisorID.Trim()));

                    if (position.SupervisoryStatus.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@SupervisoryStatus", position.SupervisoryStatus));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@SupervisoryStatus", DBNull.Value));

                    if (position.RegionID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@RegionID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@RegionID", position.RegionID));

                    if (position.PayPlanID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@PayPlanID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PayPlanID", position.PayPlanID));

                    if (position.SeriesID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", position.SeriesID));

                    if (position.Grade == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@Grade", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@Grade", position.Grade));

                    if (position.FPLGrade == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@FPLGrade", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@FPLGrade", position.FPLGrade));

                    if (position.DutyStationCountryID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationCountryID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationCountryID", position.DutyStationCountryID));

                    if (position.DutyStationStateID.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationStateID", position.DutyStationStateID));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationStateID", DBNull.Value));

                    if (string.IsNullOrWhiteSpace(position.DutyStationDescription))
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationDescription", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyStationDescription", position.DutyStationDescription.Trim()));

                    if (position.eAppointmentType == enumAppointmentType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@AppointmentTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@AppointmentTypeID", position.eAppointmentType));

                    if (position.eWorkScheduleType == enumWorkScheduleType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkScheduleTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@WorkScheduleTypeID", position.eWorkScheduleType));

                    if (position.LastDateFilled.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@LastDateFilled", position.LastDateFilled.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@LastDateFilled", DBNull.Value));

                    if (position.PositionStatusHistory.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionStatusHistory", position.PositionStatusHistory));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PositionStatusHistory", DBNull.Value));

                    if (position.ReportsToID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@ReportsToParentPositionID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ReportsToParentPositionID", position.ReportsToID));

                    if (position.PositionGroupType == enumOrgPositionGroupType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@GroupTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@GroupTypeID", (int)position.PositionGroupType));

                    if (position.PositionPlacementType == enumOrgPositionPlacementType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@PlacementTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@PlacementTypeID", (int)position.PositionPlacementType));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByUserID", position.UpdatedByID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Invalid Parent Position")
                        throw new InvalidParentChartPositionException();
                    else
                        HandleException(ex);
                }
            }
        }

        public void Exclude(OrganizationChartPosition OrgChartPosition)
        {
            if (base.ValidateKeyField(OrgChartPosition.OrganizationChartID) && base.ValidateKeyField(OrgChartPosition.WFPPositionID))
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_ExcludePositionFromOrgChart");

                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", OrgChartPosition.OrganizationChartID));
                    commandWrapper.Parameters.Add(new SqlParameter("@WFPPositionID", OrgChartPosition.WFPPositionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByUserID", OrgChartPosition.UpdatedByID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Contains Subordinates")
                        throw new PositionContainsSubordinatesException();
                    else
                        HandleException(ex);
                }
            }
        }

        public void Include(OrganizationChartPosition chartPosition)
        {
            List<int> positionIDList = new List<int>();

            positionIDList.Add(chartPosition.WFPPositionID);
            this.Include(chartPosition.OrganizationChartID, chartPosition.ReportsToID, chartPosition.eOrgPositionType, 
                        chartPosition.PositionGroupType, chartPosition.PositionPlacementType, positionIDList, chartPosition.UpdatedByID );
        }

        public void Include(int organizationChartID, int parentWFPPositionID, enumOrgPositionType orgPositionType, enumOrgPositionGroupType groupType, enumOrgPositionPlacementType placementType, List<int> positionIDList,int UpdatedByID)
        {
            if (base.ValidateKeyField(organizationChartID) && base.ValidateKeyField(parentWFPPositionID))
            {
                if (positionIDList != null && positionIDList.Count > 0)
                {
                    try
                    {
                        DbCommand commandWrapper = GetDbCommand("spr_IncludePositionsInOrgChart");

                        commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", organizationChartID));
                        commandWrapper.Parameters.Add(new SqlParameter("@ParentWFPPositionID", parentWFPPositionID));

                        if (orgPositionType == enumOrgPositionType.Undefined)
                            commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionTypeID", DBNull.Value));
                        else
                            commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionTypeID", (int)orgPositionType));

                        if (groupType == enumOrgPositionGroupType.Undefined)
                            commandWrapper.Parameters.Add(new SqlParameter("@GroupTypeID", DBNull.Value));
                        else
                            commandWrapper.Parameters.Add(new SqlParameter("@GroupTypeID", (int) groupType));

                        if (placementType == enumOrgPositionPlacementType.Undefined)
                            commandWrapper.Parameters.Add(new SqlParameter("@PlacementTypeID", DBNull.Value));
                        else
                            commandWrapper.Parameters.Add(new SqlParameter("@PlacementTypeID", (int)placementType));

                        DataTable parameterTable = new DataTable("ParameterTable");
                        int rowCount = 0;
                        
                        // build table format
                        parameterTable.Columns.Add("ID", typeof(System.Int32));
                        parameterTable.Columns.Add("DataValue", typeof(System.Int32));

                        foreach (int itemValue in positionIDList)
                            parameterTable.Rows.Add(++rowCount, itemValue);

                        commandWrapper.Parameters.Add(new SqlParameter("@PositionIDList", parameterTable));
                        commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByUserID", UpdatedByID));
                        ExecuteNonQuery(commandWrapper);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Circular Reference")
                            throw new CircularPositionReferenceException();
                        else if (ex.Message == "Invalid Position In List")
                            throw new InvalidChartPositionException();
                        else
                            HandleException(ex);
                    }
                }
            }
        }

        public void FixAbolished(int organizationChartID, int fixWFPPositionID, int newParentPositionID, AbolishedFixActions selectedAction, int UpdatedByID)
        {
            if (base.ValidateKeyField(organizationChartID) && 
                base.ValidateKeyField(fixWFPPositionID) && 
                base.ValidateKeyField(newParentPositionID))
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_FixAbolishedChartPositionByID");

                    commandWrapper.Parameters.Add(new SqlParameter("@LoadOrganizationChartID", organizationChartID));
                    commandWrapper.Parameters.Add(new SqlParameter("@FixWFPPositionID", fixWFPPositionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@NewParentPositionID", newParentPositionID));

                    if (selectedAction == AbolishedFixActions.TakeNoAction)
                        commandWrapper.Parameters.Add(new SqlParameter("@ActionFix", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ActionFix", (int) selectedAction));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByUserID", UpdatedByID));
                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {	
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Methods

        public OrganizationChartPositionCollection GetOrganizationChartPositions(int OrganizationChartID)
        {
            return base.GetItemCustomCollection<OrganizationChartPositionCollection>("spr_GetOrgChartPositionsByOrgChartID", OrganizationChartID);
        }

        public OrganizationChartPositionCollection GetOrganizationChartPositionsExcludePath(int OrganizationChartID, int excludeWFPPositionID)
        {
            return base.GetItemCustomCollection<OrganizationChartPositionCollection>("spr_GetOrgChartPositionsByOrgChartIDExcludePath", OrganizationChartID, excludeWFPPositionID);
        }

        public OrganizationChartPositionCollection GetOrganizationChartSubordinatePositionsByPosition(int OrganizationChartID, int WFPPositionID)
        {
            return base.GetItemCustomCollection<OrganizationChartPositionCollection>("spr_GetOrganizationChartSubordinatePositionsByPosition", OrganizationChartID, WFPPositionID);
        }

        /// <summary>
        /// Special Method used by Manisha to generate Excel data
        /// </summary>
        public DataTable GetOrganizationChartPositionsData(int OrganizationChartID)
        {
            DataTable table = new DataTable();

            try
            {
                table = ExecuteDataTable("spr_GetOrgChartPositionsByOrgChartIDForExport", OrganizationChartID);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return table;
        }

        #endregion
    }
}
