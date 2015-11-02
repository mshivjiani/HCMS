using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Lookups;
using HCMS.Business.OrganizationChart.Positions.Collections ;
using HCMS.Business.OrganizationChart.Positions.Adapters;
using System.Data.Common;
using System.Data.SqlClient;
using HCMS.Business.OrganizationChart.Positions.Exceptions;

namespace HCMS.Business.OrganizationChart.Positions
{
    public class WorkforcePlanningPositionManager : RepositoryBase<WorkforcePlanningPositionManager, WorkforcePlanningPosition, WorkforcePlanningPositionDataAdapter>
    {
        #region Get Methods

        public WorkforcePlanningPosition GetByID(int WFPPositionID)
        {
            return base.GetItem("spr_GetWFPPositionByID", WFPPositionID);
        }

        public WorkforcePlanningPosition GetAbolishedPositionByID(int WFPPositionID)
        {
            return base.GetItem("spr_GetAbolishedWFPPositionByID", WFPPositionID);
        }
        
        #endregion

        #region Additional Methods

        /// <summary>
        /// This method deletes a position completely (from all org charts).
        /// </summary>
        /// <param name="OrgChartPosition"></param>
        public void Delete(int loadWFPPositionID, int OrganizationChartID, int UpdatedByID)
        {
            if (base.ValidateKeyField(loadWFPPositionID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteWFPPosition", loadWFPPositionID,OrganizationChartID ,UpdatedByID );
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

        #endregion

        #region Collection Methods

        public WorkforcePlanningPositionCollection GetByOrgCode(int organizationCodeID)
        {
            return base.GetItemCustomCollection<WorkforcePlanningPositionCollection>("spr_GetWFPPositionsByOrgCode", organizationCodeID);
        }

        public WorkforcePlanningPositionCollection GetRootNodeParentPositionsForChart(int organizationChartID)
        {
            return base.GetItemCustomCollection<WorkforcePlanningPositionCollection>("spr_GetOrgChartPositions_RootNode_ReplacementParentPositions", organizationChartID);
        }

        public WorkforcePlanningPositionCollection GetPositionsByOrganizationCode(int OrganizationCodeID, bool blnIncludeChildOrgPositions, bool blnIncludeVacantPositions)
        {
            return base.GetItemCustomCollection<WorkforcePlanningPositionCollection>("spr_GetAllWFPPositionsByOrganizationCode", OrganizationCodeID, blnIncludeChildOrgPositions, blnIncludeVacantPositions);
        }

        public WorkforcePlanningPositionCollection GetPotentialRootReplacementPositions(int OrganizationChartID)
        {
            return base.GetItemCustomCollection<WorkforcePlanningPositionCollection>("spr_OrganizationChart_RootNode_GetReplacementPositions", OrganizationChartID);
        }

        public WorkforcePlanningPositionCollection GetNewFPPSPositionsByOrganizationChart(int organizationChartID)
        {
            return base.GetItemCustomCollection<WorkforcePlanningPositionCollection>("spr_GetNewFPPSPositionsByOrganizationChart", organizationChartID);
        }

        public WorkforcePlanningPositionCollection GetAbolishedPositionsByOrganizationChart(int organizationChartID)
        {
            return base.GetItemCustomCollection<WorkforcePlanningPositionCollection>("spr_GetAbolishedPositionsByOrganizationChart", organizationChartID);
        }

        //public WorkforcePlanningPositionCollection GetChildPositionsForInclusion(int ReportToID)
        //{
        //    // ARJ:
        //    // Is this being used?
        //    return base.GetItemCustomCollection<WorkforcePlanningPositionCollection>("spr_GetAllWFPPositionsByReportToForInclude", ReportToID);
        //}

        //public WorkforcePlanningPositionCollection GetPositionsToIncludeInChart(int OrganizationChartID, int ReportToID)
        //{
        //    return base.GetItemCustomCollection<WorkforcePlanningPositionCollection>("spr_GetOrgChartPositionsForInclude", OrganizationChartID, ReportToID);
        //}

        public WorkforcePlanningPositionCollection GetPositionsForInclusionInChart(int organizationChartID, int ? orgChildCodeID = null)
        {
            WorkforcePlanningPositionCollection returnList = null;

            if (base.ValidateKeyField(organizationChartID))
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_GetOrgChartPositionsForInclusion");

                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", organizationChartID));

                    if (orgChildCodeID.HasValue && orgChildCodeID.Value != -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgChildCodeID", orgChildCodeID.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgChildCodeID", DBNull.Value));

                    DataTable dt = ExecuteDataTable(commandWrapper);
                    returnList = new WorkforcePlanningPositionCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return returnList ?? new WorkforcePlanningPositionCollection();
        }

        #endregion
    }
}
