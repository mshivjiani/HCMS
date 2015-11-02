using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Lookups;
using HCMS.Business.Security;
using HCMS.Business.OrganizationChart.Exceptions;
using HCMS.Business.Common.Exceptions;
using HCMS.Business.WorkFlow.Exceptions;
using HCMS.Business.Positions.Exceptions;
using HCMS.Business.OrganizationChart.Adapters;

namespace HCMS.Business.OrganizationChart
{
    public class OrganizationChartManager : RepositoryBase<OrganizationChartManager, OrganizationChart, OrganizationChartDataAdapter>
    {
        #region General "Get" Methods

        public OrganizationChart GetByID(int orgChartID)
        {
            return base.GetItem("spr_GetOrganizationChartByID", orgChartID);
        }

        public OrganizationChart GetByOrgCodeAndChartType(int orgCodeID, enumOrgChartType chartType)
        {
            return base.GetItem("spr_GetOrganizationChartByOrgCodeAndChartType", orgCodeID, (int)chartType);
        }

        #endregion

        #region General "Get Collection" Methods

        public IList<OrganizationChart> GetInProcessOrganizationChartsByUserID(int UserID)
        {
            return base.GetItemList("spr_GetInProcessOrgChartsByUserID", UserID).ToList();
        }

        #endregion

        #region General Action Methods

        /// <summary>
        /// Create Organization Chart from object (new creation)
        /// </summary>
        /// <param name="newChart"></param>
        /// <returns></returns>
        public int CreateNew(OrganizationChart newChart, bool withCheckout = false)
        {
            int newChartID = -1;

            if (newChart == null)
                throw new NullOrganizationChartException("Cannot create a new organization chart with a null OrganizationChart object.");
            else if (newChart.OrganizationChartTypeID == enumOrgChartType.Undefined)
                throw new BusinessException("Cannot create a new org chart with an undefined chart type.");
            else if (newChart.OrganizationChartID != -1)
                throw new BusinessException("Cannot create a new chart while specifying an existing organization chart ID");
            else if (newChart.OrgCode == null || newChart.OrgCode.OrganizationCodeID == -1)
                throw new NullOrganizationCodeException("Cannot create a new organization chart with a null OrganizationCode");
            else if (newChart.CreatedBy == null || newChart.CreatedBy.UserID == -1)
                throw new NullActionUserException("Cannot create a new organization chart with a null 'Created By' Action User");
            else
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_CreateOrganizationChart");

                    SqlParameter newIDParam = new SqlParameter("@NewOrgChartID", SqlDbType.Int);
                    newIDParam.Direction = ParameterDirection.Output;

                    SqlParameter startPointIDParam = new SqlParameter("@StartPointWFPPositionID", SqlDbType.Int);
                    startPointIDParam.Direction = ParameterDirection.InputOutput;

                    // return parameter
                    commandWrapper.Parameters.Add(newIDParam);                   

                    commandWrapper.Parameters.Add(new SqlParameter("@OrgChartTypeID", (int)newChart.OrganizationChartTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@OrgCodeID", newChart.OrgCode.OrganizationCodeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@CreatedByUserID", newChart.CreatedBy.UserID));

                    if (newChart.StartPointWFPPositionID == -1)
                        startPointIDParam.Value = DBNull.Value;
                    else
                        startPointIDParam.Value = newChart.StartPointWFPPositionID;

                    commandWrapper.Parameters.Add(startPointIDParam);
                    commandWrapper.Parameters.Add(new SqlParameter("@WithCheckout", withCheckout));

                    ExecuteNonQuery(commandWrapper);

                    newChartID = (int)newIDParam.Value;                   
                    newChart.OrganizationChartID = newChartID;

                    // get ID value of newly added WFP
                    if (newChart.StartPointWFPPositionID == -1)
                    {
                        int startPointWFPID = (int)startPointIDParam.Value;
                        newChart.StartPointWFPPositionID = startPointWFPID;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Already In Progress")
                        throw new ChartAlreadyInProgressException();
                    else
                        HandleException(ex);
                }
            }

            return newChartID;
        }

        /// <summary>
        /// Create Organization Chart from Published chart
        /// </summary>
        /// <param name="chartType"></param>
        /// <param name="organizationChartLogID"></param>
        /// <returns></returns>
        public int CreateFromPublished(OrganizationChart newChart, bool withCheckout = false)
        {
            int newChartID = -1;

            if (newChart == null)
                throw new NullOrganizationChartException("Cannot create a new organization chart with a null OrganizationChart object.");
            else if (newChart.OrganizationChartTypeID == enumOrgChartType.Undefined)
                throw new BusinessException("Cannot create a new org chart with an undefined chart type.");
            else if (newChart.OrganizationChartID != -1)
                throw new BusinessException("Cannot create a new chart while specifying an existing organization chart ID");
            else if (newChart.OrgCode == null || newChart.OrgCode.OrganizationCodeID == -1)
                throw new BusinessException("Cannot create a new org chart without first specifying an organization.");
            else if (newChart.CreatedBy == null || newChart.CreatedBy.UserID == -1)
                throw new BusinessException("Cannot create a new org chart without first specifying the creator.");
            else
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_CreateOrganizationChart_FromPublished");

                    SqlParameter returnParam = new SqlParameter("@NewOrgChartID", SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.Output;

                    // return parameter
                    commandWrapper.Parameters.Add(returnParam);

                    commandWrapper.Parameters.Add(new SqlParameter("@OrgChartTypeID", (int) newChart.OrganizationChartTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@OrgCodeID", newChart.OrgCode.OrganizationCodeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@CreatedByUserID", newChart.CreatedBy.UserID));
                    commandWrapper.Parameters.Add(new SqlParameter("@WithCheckout", withCheckout));

                    // run command
                    ExecuteNonQuery(commandWrapper);

                    // get new chart ID
                    newChartID = (int)returnParam.Value;
                    newChart.OrganizationChartID = newChartID;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "No Published Chart")
                        throw new NoPublishedChartAvailableException();
                    else if (ex.Message == "Already In Progress")
                        throw new ChartAlreadyInProgressException();
                    else
                        HandleException(ex);
                }
            }

            return newChartID;
        }
        
        public void Update(OrganizationChart chart)
        {
            if (chart == null)
                throw new NullOrganizationChartException("Cannot update an organization chart with a null OrganizationChart object.");
            else if (chart.OrganizationChartID == -1)
                throw new DBPrimaryKeyNotSetException("Cannot update organization chart -- OrganizationChartID not set");
            else if (chart.UpdatedBy == null || chart.UpdatedBy.UserID == -1)
                throw new NullActionUserException("Cannot update an organization chart with a null 'Updated By' Action User");
            else
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_UpdateOrganizationChart");

                    // Don't have to worry about null/empty values here -- validation checks ensure that these have values
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", chart.OrganizationChartID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByUserID", chart.UpdatedBy.UserID));

                    // Fields may be empty
                    if (string.IsNullOrWhiteSpace(chart.Header1))
                        commandWrapper.Parameters.Add(new SqlParameter("@Header1", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@Header1", chart.Header1.Trim()));

                    if (string.IsNullOrWhiteSpace(chart.Header2))
                        commandWrapper.Parameters.Add(new SqlParameter("@Header2", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@Header2", chart.Header2.Trim()));

                    if (string.IsNullOrWhiteSpace(chart.Header3))
                        commandWrapper.Parameters.Add(new SqlParameter("@Header3", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@Header3", chart.Header3.Trim()));

                    if (string.IsNullOrWhiteSpace(chart.Header4))
                        commandWrapper.Parameters.Add(new SqlParameter("@Header4", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@Header4", chart.Header4.Trim()));

                    if (string.IsNullOrWhiteSpace(chart.Footer))
                        commandWrapper.Parameters.Add(new SqlParameter("@Footer", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@Footer", chart.Footer.Trim()));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void UpdateRootNode(OrganizationChart chart)
        {
            if (chart == null)
                throw new NullOrganizationChartException("Cannot update the root position of an organization chart with a null OrganizationChart object.");
            else if (chart.OrganizationChartID == -1)
                throw new DBPrimaryKeyNotSetException("Cannot update organization chart -- OrganizationChartID not set");
            else if (chart.UpdatedBy == null || chart.UpdatedBy.UserID == -1)
                throw new NullActionUserException("Cannot update an organization chart with a null 'Updated By' Action User");
            else
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_UpdateOrganizationChart_RootNode");

                    // Don't have to worry about null/empty values here -- validation checks ensure that these have values
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", chart.OrganizationChartID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByUserID", chart.UpdatedBy.UserID));

                    if (chart.StartPointWFPPositionID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@RootWFPPositionID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@RootWFPPositionID", chart.StartPointWFPPositionID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Invalid Root Replacement")
                        throw new InvalidRootNodePositionReplacementException();
                    else
                        HandleException(ex);
                }
            }
        }

        public void Delete(int organizationChartID)
        {
            if (organizationChartID == -1)
                throw new DBPrimaryKeyNotSetException("Cannot delete organization chart -- OrganizationChartID not set");
            else
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteOrganizationChart", organizationChartID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void SubmitToNextStatus(int organizationChartID, enumOrgWorkflowStatus orgWorkflowStatusID, int updatedByUserID)
        {
            if (organizationChartID == -1)
                throw new DBPrimaryKeyNotSetException("Cannot delete organization chart -- OrganizationChartID not set");
            else if (orgWorkflowStatusID == enumOrgWorkflowStatus.Undefined || orgWorkflowStatusID == enumOrgWorkflowStatus.Published)
                throw new WorkflowNotSupportedException("Cannot submit the organization chart to 'Publish' -- Valid statuses are Draft, Review, Approval.");
            else if (updatedByUserID == -1)
                throw new NullActionUserException("Cannot submit organization chart to next status with a null 'Updated By User ID'");
            else
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_SubmitOrgChartToNextStatus");

                    // primary key field validated above
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", organizationChartID));

                    // field values handled with validation checks above
                    commandWrapper.Parameters.Add(new SqlParameter("@OrgWorkflowStatusID", (int) orgWorkflowStatusID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByUserID", updatedByUserID));
                    
                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Workflow status not supported")
                        throw new WorkflowNotSupportedException("Cannot submit the organization chart to 'Publish' -- Valid statuses are Draft, Review, Approval.");
                    else if (ex.Message == "No Root Position")
                        throw new MissingRootNodePositionException();
                    else if (ex.Message == "Abolished Positions Exist")
                        throw new AbolishedPositionsExistException();
                    else if (ex.Message == "Broken Hierarchy")
                        throw new ChartBrokenHierarchyException();
                    else
                        HandleException(ex);
                }
            }
        }
        
        public void ChangeOrganizationChartOwner(int organizationChartID, int newUserID)
        {
            if (organizationChartID == -1)
                throw new DBPrimaryKeyNotSetException("Cannot change organization chart owner -- OrganizationChartID not set");
            else if (newUserID == -1)
                throw new NullNewUserException("Cannot change organization chart owner with a null 'New User ID'");
            else
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_ChangeOrganizationChartOwner");

                    // primary key field validated above
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", organizationChartID));

                    // field values handled with validation checks above
                    commandWrapper.Parameters.Add(new SqlParameter("@NewOwnerUserID", newUserID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        /// <summary>
        /// Check-in or Check-out the organization chart
        /// </summary>
        /// <param name="OrganizationChartID"></param>
        /// <param name="UserID"></param>
        /// <param name="CheckAction">enumActionType -- Valid actions are "Check-In" and "Check-Out"</param>
        public void Check(int organizationChartID, int checkedActionByUserID, enumActionType checkAction)
        {
            if (organizationChartID == -1)
                throw new DBPrimaryKeyNotSetException("Cannot edit organization chart -- OrganizationChartID not set");
            else if (checkedActionByUserID == -1)
                throw new NullActionUserException("Cannot check-in/check-out organization chart with a null 'Checked Action User ID'");
            else if (checkAction != enumActionType.CheckIn && checkAction != enumActionType.CheckOut)
                throw new BusinessException("Cannot check-in/check-out organization chart -- invalid action request received.");
            else
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_OrganizationChartCheck");

                    // primary key field validated above
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", organizationChartID));
                    commandWrapper.Parameters.Add(new SqlParameter("@CheckActionID", (int) checkAction));
                    commandWrapper.Parameters.Add(new SqlParameter("@CheckedActionByUserID", checkedActionByUserID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public int Publish(int organizationChartID, int approvedByID, int lastUpdatedByUserID, string approvedFor)
        { 
            int newOrgChartLogID = -1;

            if (organizationChartID == -1)
                throw new DBPrimaryKeyNotSetException("Cannot publish an organization chart -- OrganizationChartID not set");
            else if (approvedByID == -1)
                throw new NullActionUserException("Cannot publish an organizaton chart with a null 'Approved By' Action User");
            else if (lastUpdatedByUserID == -1)
                throw new NullActionUserException("Cannot publish an organizaton chart with a null 'Updated By' Action User");
            else
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_PublishOrganizationChart");

                    SqlParameter returnParam = new SqlParameter("@newOrganizationChartLogID", SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.Output;

                    commandWrapper.Parameters.Add(returnParam);

                    // fields with validation checks
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartID", organizationChartID));
                    commandWrapper.Parameters.Add(new SqlParameter("@ApprovedByID", approvedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByUserID", lastUpdatedByUserID));

                    if (string.IsNullOrWhiteSpace(approvedFor))
                        commandWrapper.Parameters.Add(new SqlParameter("@ApprovedFor", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ApprovedFor", approvedFor.Trim()));

                    ExecuteNonQuery(commandWrapper);
                    newOrgChartLogID = (int)returnParam.Value;
                }
                catch (Exception ex)
                {
                    if (ex.Message == "No Root Position")
                        throw new MissingRootNodePositionException();
                    else if (ex.Message == "Abolished Positions Exist")
                        throw new AbolishedPositionsExistException();
                    else if (ex.Message == "Broken Hierarchy")
                        throw new ChartBrokenHierarchyException();
                    else
                        HandleException(ex);
                }
            }

            return newOrgChartLogID;
        }
                
        #endregion
    }
}
