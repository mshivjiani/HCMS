using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Lookups;
using System.Data.Common;
using System.Data.SqlClient;
namespace HCMS.Business.OrganizationChart
{
    public class OrganizationChartPositionManager : BusinessBase
    {
        #region [Get Methods]
        public static OrganizationChartPosition GetOrganizationChartPositionByID(int OrganizationChartID, int WFPPositionID)
        {
            // Load Object by ID
            OrganizationChartPosition item=null;
            try
            {
               DataTable  returnTable = ExecuteDataTable("spr_GetOrgChartPositionByID", OrganizationChartID, WFPPositionID);
               item=loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return item ;
        }
        public static OrganizationChartPosition GetOrganizationChartPosition(DataRow singleRowData)
        {
            // Load Object by dataRow
            OrganizationChartPosition item = null;
            try
            {
              item= FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return item;
        }

        #endregion

        #region [Private Methods]
        private static OrganizationChartPosition loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }

            return null;
        }
        private static OrganizationChartPosition FillObjectFromRowData(DataRow returnRow)
        {
            OrganizationChartPosition  OrgChartPosition = new OrganizationChartPosition ();
            DataColumnCollection columns = returnRow.Table.Columns;
             if(returnRow ["OrganizationChartID"]!= DBNull.Value)
                 OrgChartPosition.OrganizationChartID = (int)returnRow["OrganizationChartID"];
             if(returnRow ["OrgPositionGroupTypeID"]!= DBNull.Value)
             {
                 OrgChartPosition.OrgPositionGroupTypeID = (int)returnRow["OrgPositionGroupTypeID"];
                 OrgChartPosition.eOrgPositionGroupType =(enumOrgPositionGroupType )OrgChartPosition.OrgPositionGroupTypeID ;
             }
             if (returnRow["OrgPositionGroupType"] != DBNull.Value)
                 OrgChartPosition.OrgPositionGroupType = returnRow["OrgPositionGroupType"].ToString();
                  
             if (returnRow["WFPPositionID"] != DBNull.Value)
                 OrgChartPosition.WFPPositionID = (int)returnRow["WFPPositionID"];
             if (returnRow["OrgPositionTypeID"] != DBNull.Value)
                 OrgChartPosition.OrgPositionTypeID = (int)returnRow["OrgPositionTypeID"];
             if (returnRow["OrgPositionType"] != DBNull.Value)
                 OrgChartPosition.OrgPositionType = returnRow["OrgPositionType"].ToString();
             if (returnRow["ReportsToID"] != DBNull.Value)
                 OrgChartPosition.ReportsToID = (int)returnRow["ReportsToID"];
             if (returnRow["PositionNumberBase"] != DBNull.Value)
                 OrgChartPosition.PositionNumberBase = returnRow["PositionNumberBase"].ToString();
             if (returnRow["PositionNumberSuffix"] != DBNull.Value)
                 OrgChartPosition.PositionNumberSuffix  = (int)returnRow["PositionNumberSuffix"];
             if (returnRow["EmployeeName"] != DBNull.Value)
                 OrgChartPosition.EmployeeName  = returnRow["EmployeeName"].ToString();
             if (returnRow["FirstName"] != DBNull.Value)
                 OrgChartPosition.FirstName = returnRow["FirstName"].ToString();
             if (returnRow["LastName"] != DBNull.Value)
                 OrgChartPosition.LastName = returnRow["LastName"].ToString();
             if (returnRow["MiddleName"] != DBNull.Value)
                 OrgChartPosition.MiddleName = returnRow["MiddleName"].ToString();
             if (returnRow["EmployeeCommonID"] != DBNull.Value)
                 OrgChartPosition.EmployeeCommonID = (int)returnRow["EmployeeCommonID"];
             if (returnRow["FPPSSupervisorID"] != DBNull.Value)
                 OrgChartPosition.FPPSSupervisorID  = returnRow["FPPSSupervisorID"].ToString ();
             if (returnRow["SupervisoryStatus"] != DBNull.Value)
                 OrgChartPosition.SupervisoryStatus  = (int) returnRow["SupervisoryStatus"];
             if (returnRow["RegionID"] != DBNull.Value)
                 OrgChartPosition.RegionID  = (int)returnRow["RegionID"];
             if (returnRow["OrganizationCodeID"] != DBNull.Value)
                 OrgChartPosition.OrganizationCodeID  = (int)returnRow["OrganizationCodeID"];
             if (returnRow["OldOrganizationCode"] != DBNull.Value)
                 OrgChartPosition.OldOrganizationCode   = (int)returnRow["OldOrganizationCode"];
             if (returnRow["OrganizationCode"] != DBNull.Value)
                 OrgChartPosition.OrganizationCode   = returnRow["OrganizationCode"].ToString ();
             if (returnRow["PositionTitle"] != DBNull.Value)
                 OrgChartPosition.PositionTitle = returnRow["PositionTitle"].ToString ();
             if (returnRow["PayPlanID"] != DBNull.Value)
                 OrgChartPosition.PayPlanID  = (int)returnRow["PayPlanID"];
             if (returnRow["PayPlanAbbreviation"] != DBNull.Value)
                 OrgChartPosition.PayPlanAbbreviation   = returnRow["PayPlanAbbreviation"].ToString();         
             if (returnRow["SeriesID"] != DBNull.Value)
                 OrgChartPosition.SeriesID  = (int)returnRow["SeriesID"];
             if (returnRow["SeriesName"] != DBNull.Value)
                 OrgChartPosition.SeriesName    = returnRow["SeriesName"].ToString();
             if (returnRow["Grade"] != DBNull.Value)
                 OrgChartPosition.Grade  = (int)returnRow["Grade"];
             if (returnRow["FPLGrade"] != DBNull.Value)
                 OrgChartPosition.FPLGrade = (int)returnRow["FPLGrade"];
             if (returnRow["DutyStationDescription"] != DBNull.Value)
                 OrgChartPosition.DutyStationDescription  = returnRow["DutyStationDescription"].ToString();            
             if (returnRow["DutyStationState"] != DBNull.Value)
                 OrgChartPosition.DutyStationState  = (int)returnRow["DutyStationState"];
            if (returnRow["DutyStationStateName"] != DBNull.Value)
                 OrgChartPosition.DutyStationDescription  = returnRow["DutyStationStateName"].ToString();

             if (returnRow["AppointmentTypeID"] != DBNull.Value)
             {
                 OrgChartPosition.AppointmentTypeID  = (int)returnRow["AppointmentTypeID"];
                 OrgChartPosition.eAppointmentType =(enumAppointmentType) OrgChartPosition.AppointmentTypeID ;
             }
             if (returnRow["AppointmentTypeCode"] != DBNull.Value)
                  OrgChartPosition.AppointmentTypeCode = (int)returnRow["AppointmentTypeCode"];

             if (returnRow["WorkScheduleTypeID"] != DBNull.Value)
             {   
                 OrgChartPosition.WorkScheduleTypeID  = (int)returnRow["WorkScheduleTypeID"];
                 OrgChartPosition.eWorkScheduleType = (enumWorkScheduleType)OrgChartPosition.WorkScheduleTypeID;

             }

              if (returnRow["WorkScheduleTypeAbbreviation"] != DBNull.Value)
                 OrgChartPosition.WorkScheduleTypeAbbreviation   = returnRow["WorkScheduleTypeAbbreviation"].ToString();

             if (returnRow["LastDateFilled"] != DBNull.Value)
                 OrgChartPosition.LastDateFilled  =(DateTime) returnRow["LastDateFilled"];
             if (returnRow["CreateDate"] != DBNull.Value)
                 OrgChartPosition.CreateDate  = (DateTime)returnRow["CreateDate"];
             if (returnRow["CreatedByID"] != DBNull.Value)
                 OrgChartPosition.CreatedByID  = (int)returnRow["CreatedByID"];


             if (columns.Contains("PhoneNumber"))
             {
                 if (returnRow["PhoneNumber"] != DBNull.Value)
                     OrgChartPosition.PhoneNumber = returnRow["PhoneNumber"].ToString();
             }
            return OrgChartPosition;

        }
        #endregion

        #region [CRUD Methods]
        public static int Add(OrganizationChartPosition OrgChartPosition)
        {
            int wfppositionid =-1;
         try
        {
            DbCommand commandWrapper = GetDbCommand("spr_CreateOrgChartPosition");
            SqlParameter returnParam = new SqlParameter("@WFPPositionID", SqlDbType.Int);
            returnParam.Direction = ParameterDirection.Output;
            commandWrapper.Parameters.Add(returnParam);
            commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionTypeID", OrgChartPosition.OrgPositionTypeID));
            commandWrapper.Parameters.Add(new SqlParameter("@ReportsToID", OrgChartPosition.ReportsToID));
            if (string.IsNullOrEmpty(OrgChartPosition.PositionNumberBase))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberBase", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberBase", OrgChartPosition.PositionNumberBase));
            }
            if (OrgChartPosition.PositionNumberSuffix == null)
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberSuffix", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberSuffix", OrgChartPosition.PositionNumberSuffix));
            }
            if (string.IsNullOrEmpty(OrgChartPosition.EmployeeName))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@EmployeeName", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@EmployeeName", OrgChartPosition.EmployeeName));
            }

            if (string.IsNullOrEmpty(OrgChartPosition.FirstName))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@FirstName", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@FirstName", OrgChartPosition.FirstName));
            }

            if (string.IsNullOrEmpty(OrgChartPosition.LastName))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@LastName", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@LastName", OrgChartPosition.LastName));
            }

            if (string.IsNullOrEmpty(OrgChartPosition.MiddleName))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@MiddleName", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@MiddleName", OrgChartPosition.MiddleName));
            }
            if (OrgChartPosition.EmployeeCommonID == null)
            { commandWrapper.Parameters.Add(new SqlParameter("@EmployeeCommonID", DBNull.Value )); }
            else
            { commandWrapper.Parameters.Add(new SqlParameter("@EmployeeCommonID", OrgChartPosition.EmployeeCommonID)); }

            if (string.IsNullOrEmpty(OrgChartPosition.FPPSSupervisorID))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@FPPSSupervisorID", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@FPPSSupervisorID", OrgChartPosition.FPPSSupervisorID));
            }

            if (OrgChartPosition.SupervisoryStatus == null)
            {
                commandWrapper.Parameters.Add(new SqlParameter("@SupervisoryStatus", DBNull.Value ));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@SupervisoryStatus", OrgChartPosition.SupervisoryStatus));
            }
            commandWrapper.Parameters.Add(new SqlParameter("@RegionID", OrgChartPosition.RegionID ));
            commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCodeID", OrgChartPosition.OrganizationCodeID ));
            commandWrapper.Parameters.Add(new SqlParameter("@PositionTitle", OrgChartPosition.PositionTitle ));
            commandWrapper.Parameters.Add(new SqlParameter("@PayPlanID", OrgChartPosition.PayPlanID ));
            commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", OrgChartPosition.SeriesID));
            commandWrapper.Parameters.Add(new SqlParameter("@Grade", OrgChartPosition.Grade));
            commandWrapper.Parameters.Add(new SqlParameter("@FPLGrade", OrgChartPosition.FPLGrade));

            commandWrapper.Parameters.Add(new SqlParameter("@DutyStationDescription", OrgChartPosition.DutyStationDescription ));
            if (OrgChartPosition.DutyStationState == null)
            { commandWrapper.Parameters.Add(new SqlParameter("@DutyStationState", DBNull.Value)); }
            else
            { commandWrapper.Parameters.Add(new SqlParameter("@DutyStationState", OrgChartPosition.DutyStationState)); }
            if (OrgChartPosition.AppointmentTypeID == null)
            {
                commandWrapper.Parameters.Add(new SqlParameter("@AppointmentTypeID", DBNull.Value ));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@AppointmentTypeID", OrgChartPosition.AppointmentTypeID));
            }
            if (OrgChartPosition.WorkScheduleTypeID == null)
            {
                commandWrapper.Parameters.Add(new SqlParameter("@WorkScheduleTypeID", DBNull.Value ));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@WorkScheduleTypeID", OrgChartPosition.WorkScheduleTypeID));
            }
            if (OrgChartPosition.LastDateFilled == DateTime.MinValue)
            { commandWrapper.Parameters.Add(new SqlParameter("@LastDateFilled", DBNull.Value)); }
            else
            {commandWrapper.Parameters.Add(new SqlParameter("@LastDateFilled", OrgChartPosition.LastDateFilled));  }

            if (OrgChartPosition.CreateDate == DateTime.MinValue)
            { OrgChartPosition.CreateDate = DateTime.Now; }
            commandWrapper.Parameters.Add(new SqlParameter("@CreateDate", OrgChartPosition.CreateDate ));           
            commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", OrgChartPosition.CreatedByID));

            if (OrgChartPosition.PositionStatusHistory == null)
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionStatusHistory", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionStatusHistory", OrgChartPosition.PositionStatusHistory));
            }
            commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", OrgChartPosition.OrganizationChartID ));
            commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionGroupTypeID", OrgChartPosition.OrgPositionGroupTypeID ));
            ExecuteNonQuery(commandWrapper);
            wfppositionid = (int)returnParam.Value; 
        }
        catch (Exception ex)
        {
            HandleException(ex);
          
        }
        return wfppositionid;
        }


        public static void Include(OrganizationChartPosition OrgChartPosition,bool blnUpdateReportsTo)
        {
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_IncludePositionInOrgChart");
                commandWrapper.Parameters.Add(new SqlParameter("@WFPPositionID", OrgChartPosition.WFPPositionID));
                commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", OrgChartPosition.OrganizationChartID));         
                commandWrapper.Parameters.Add(new SqlParameter("@UpdateReportsTo", blnUpdateReportsTo )); 
                commandWrapper.Parameters.Add(new SqlParameter("@ReportsToID", OrgChartPosition.ReportsToID));
                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
        }

        public static void Update(OrganizationChartPosition OrgChartPosition)
        {
	    try
        {
            DbCommand commandWrapper = GetDbCommand("spr_UpdateOrgChartPosition");
            commandWrapper.Parameters.Add(new SqlParameter("@WFPPositionID", OrgChartPosition.WFPPositionID));
            commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionTypeID", OrgChartPosition.OrgPositionTypeID));
            commandWrapper.Parameters.Add(new SqlParameter("@ReportsToID", OrgChartPosition.ReportsToID));
            if (string.IsNullOrEmpty (OrgChartPosition.PositionNumberBase))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberBase", DBNull.Value ));
            }
            else
            {
            commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberBase", OrgChartPosition.PositionNumberBase));
            }

            if (OrgChartPosition.PositionNumberSuffix==null)
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberSuffix", DBNull.Value ));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionNumberSuffix", OrgChartPosition.PositionNumberSuffix));
            }
            if (string.IsNullOrEmpty(OrgChartPosition.EmployeeName))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@EmployeeName", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@EmployeeName", OrgChartPosition.EmployeeName));
            }

            if (string.IsNullOrEmpty(OrgChartPosition.FirstName))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@FirstName", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@FirstName", OrgChartPosition.FirstName));
            }

            if (string.IsNullOrEmpty(OrgChartPosition.LastName ))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@LastName", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@LastName", OrgChartPosition.LastName));
            }

            if (string.IsNullOrEmpty(OrgChartPosition.MiddleName))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@MiddleName", DBNull.Value ));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@MiddleName", OrgChartPosition.MiddleName));
            }
            if (OrgChartPosition.EmployeeCommonID == null)
            { commandWrapper.Parameters.Add(new SqlParameter("@EmployeeCommonID", DBNull.Value )); }
            else
            { commandWrapper.Parameters.Add(new SqlParameter("@EmployeeCommonID", OrgChartPosition.EmployeeCommonID)); }

            if (string.IsNullOrEmpty(OrgChartPosition.FPPSSupervisorID))
            {
                commandWrapper.Parameters.Add(new SqlParameter("@FPPSSupervisorID", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@FPPSSupervisorID", OrgChartPosition.FPPSSupervisorID));
            }
            if (OrgChartPosition.SupervisoryStatus == null)
            {
                commandWrapper.Parameters.Add(new SqlParameter("@SupervisoryStatus", DBNull.Value ));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@SupervisoryStatus", OrgChartPosition.SupervisoryStatus));
            }
            commandWrapper.Parameters.Add(new SqlParameter("@RegionID", OrgChartPosition.RegionID ));
            commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCodeID", OrgChartPosition.OrganizationCodeID ));
            commandWrapper.Parameters.Add(new SqlParameter("@PositionTitle", OrgChartPosition.PositionTitle ));
            commandWrapper.Parameters.Add(new SqlParameter("@PayPlanID", OrgChartPosition.PayPlanID ));
            commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", OrgChartPosition.SeriesID));
            commandWrapper.Parameters.Add(new SqlParameter("@Grade", OrgChartPosition.Grade));
            commandWrapper.Parameters.Add(new SqlParameter("@FPLGrade", OrgChartPosition.FPLGrade));

            commandWrapper.Parameters.Add(new SqlParameter("@DutyStationDescription", OrgChartPosition.DutyStationDescription ));
            if (OrgChartPosition.DutyStationState == null)
            { commandWrapper.Parameters.Add(new SqlParameter("@DutyStationState", DBNull.Value)); }
            else
            { commandWrapper.Parameters.Add(new SqlParameter("@DutyStationState", OrgChartPosition.DutyStationState)); }
            if (OrgChartPosition.AppointmentTypeID == null)
            {
                commandWrapper.Parameters.Add(new SqlParameter("@AppointmentTypeID", DBNull.Value ));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@AppointmentTypeID", OrgChartPosition.AppointmentTypeID));
            }
            if (OrgChartPosition.WorkScheduleTypeID == null)
            {
                commandWrapper.Parameters.Add(new SqlParameter("@WorkScheduleTypeID", DBNull.Value ));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@WorkScheduleTypeID", OrgChartPosition.WorkScheduleTypeID));
            }
            if (OrgChartPosition.LastDateFilled == DateTime.MinValue)
            { commandWrapper.Parameters.Add(new SqlParameter("@LastDateFilled", DBNull.Value)); }
            else
            {commandWrapper.Parameters.Add(new SqlParameter("@LastDateFilled", OrgChartPosition.LastDateFilled));  }

            
            if (OrgChartPosition.PositionStatusHistory == null)
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionStatusHistory", DBNull.Value));
            }
            else
            {
                commandWrapper.Parameters.Add(new SqlParameter("@PositionStatusHistory", OrgChartPosition.PositionStatusHistory));
            }
            commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", OrgChartPosition.OrganizationChartID ));
            commandWrapper.Parameters.Add(new SqlParameter("@OrgPositionGroupTypeID", OrgChartPosition.OrgPositionGroupTypeID ));
            ExecuteNonQuery(commandWrapper);
        }
        catch (Exception ex)
        {
            HandleException(ex);
          
        }
        }
        /// <summary>
        /// Deleting the wfp position will delete this position from all charts and deletes permanently
        /// </summary>
        /// <param name="OrgChartPosition"></param>
        public static void Delete(OrganizationChartPosition OrgChartPosition)
        {
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_DeleteOrgChartPosition");
                commandWrapper.Parameters.Add(new SqlParameter("@WFPPositionID", OrgChartPosition.WFPPositionID));
                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
        }

        public static void Exclude (OrganizationChartPosition OrgChartPosition)
        {
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_ExcludePositionFromOrgChart");
                commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", OrgChartPosition.OrganizationChartID));
                commandWrapper.Parameters.Add(new SqlParameter("@WFPPositionID", OrgChartPosition.WFPPositionID));
                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
        }

        public static void ExcludePositions(int ChartID, string OrgChartPositionIDs)
        {
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_ExcludeMultiplePositionFromOrgChart");
                commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", ChartID));
                commandWrapper.Parameters.Add(new SqlParameter("@PositionIDs", OrgChartPositionIDs));
                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
        }
        #endregion

        #region [Collection Methods]
        private static List<OrganizationChartPosition> GetCollection(DataTable table)
        {
            List<OrganizationChartPosition> list = new List<OrganizationChartPosition>();

            try
            {
                if (table != null)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        OrganizationChartPosition item = FillObjectFromRowData(table.Rows[i]);
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }
        public static List<OrganizationChartPosition> GetOrganizationChartPositions(int OrganizationChartID)
        {
            List<OrganizationChartPosition> list = null;

            try
            {
                DataTable table = ExecuteDataTable("spr_GetOrgChartPositionsByOrgChartID", OrganizationChartID );

                // fill a list
                list = GetCollection(table);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }

        public static DataTable GetOrganizationChartPositionsData(int OrganizationChartID)
        {
            DataTable table = new DataTable();
            try
            {
                table = ExecuteDataTable("spr_GetOrgChartPositionsByOrgChartID", OrganizationChartID);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return table;
        }


        public static List<OrganizationChartPosition> GetOrganizationChartPositionsToDelete(int OrganizationChartID)
        {
            List<OrganizationChartPosition> list = null;

            try
            {
                DataTable table = ExecuteDataTable("spr_GetOrgChartPositionsToDeleteByOrgChartID", OrganizationChartID);

                // fill a list
                list = GetCollection(table);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }

        public static List<OrganizationChartPosition> GetOrganizationChartPositionsToInclude(int ReportToID)
        {
            List<OrganizationChartPosition> list = null;

            try
            {
                DataTable table = ExecuteDataTable("spr_GetAllWFPPositionsByReportToForInclude", ReportToID);

                // fill a list
                list = GetCollection(table);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }
        #endregion

    }
}
