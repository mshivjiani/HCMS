using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.Lookups;
using HCMS.Business.PD;
using Telerik.Web.UI;
using HCMS.WebFramework.Site.Utilities;

namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlAddEditWorkflowGroup : UserControlBase
    {
        WorkflowGroupManager wgm = new WorkflowGroupManager();
        WorkflowManager wm = new WorkflowManager();

        private enumNavigationMode _navMode;
        public enumNavigationMode CurrentNavigationMode
        {
            get { return _navMode; }
            set { this._navMode = value; }

        }

        #region Methods
        protected void ctrlAddEditWorkflowRule_AddEditRuleClick()
        {
            try
            {
                rgRule.Rebind();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected override void OnInit(EventArgs e)
        {
      

            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadData();
                    SetPageView();
                }

                this.ctrlAddEditWorkflowRule.AddEditRuleClick += new ctrlAddEditWorkflowRule.AddEditRuleHandler(ctrlAddEditWorkflowRule_AddEditRuleClick);
                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void LoadData()
        {            
            LoadStaffingObjectTypes();
            SetPageHeader();
            SetObjectText();

        }

        private void SetPageHeader()
        {
            if (CurrentNavigationMode == enumNavigationMode.Edit)
            {
                lblAddEditHeader.Text = "Edit Group";
            }
            else
            {  
                lblAddEditHeader.Text = "Add Group";
            }   
            
        }

        private void SetObjectText()
        {
            if (base.CurrentGroupID > 0)
            {
                WorkflowGroupManager workflowGroupManager = new WorkflowGroupManager();
                WorkflowGroup workflowGroup = workflowGroupManager.GetWorkflowGroup(base.CurrentGroupID);

                lblHeaderPermissionGroup.Text = "Permissions for Group: " + workflowGroup.WorkflowGroupName;
                lblHeaderRulesGroup.Text = "Rules for Group: " + workflowGroup.WorkflowGroupName;                       

            }
            else
            {
                lblHeaderPermissionGroup.Text = "Permissions ";
                lblHeaderRulesGroup.Text = "Rules ";
            }
        }

        protected void SetPageView()
        {
            bool isInEditMode = base.IsInEdit;
            bool isInViewMode = (base.CurrentNavMode == CurrentNavigationMode);

            ctrlAddEditWorkflowRule.Visible = false;
        }
        
        private List<WorkflowRule> GetWorkflowGroupRules()
        {
            List<WorkflowRule> workflowGroupRule = new List<WorkflowRule>();
            if (base.CurrentGroupID > 0 && base.CurrentStaffingObjectTypeID > 0)
            {
                rgRule.Visible = true;               

                List<WorkflowRule> lstWorkflowRule = wm.GetAllWorkflowGroupRulesByGroupID(base.CurrentGroupID, base.CurrentStaffingObjectTypeID);
                lstWorkflowRule = lstWorkflowRule.Where(p => (p.StaffingObjectTypeID == base.CurrentStaffingObjectTypeID))
                                                 .OrderBy(p => (p.StaffingObjectCurrentStatusName)).ToList();

                workflowGroupRule = lstWorkflowRule;

            }
            else
            {
                rgRule.Visible = false;               
            }
            return workflowGroupRule;
        }
        
        //protected void ShowWorkflowGroupRules(object source, GridCommandEventArgs e)
        //{
        //    RadWindowManagerRules.Windows.Clear();
        //    GridDataItem gridRuleItem;

        //    switch (e.CommandName)
        //    {
        //        case RadGrid.InitInsertCommandName:                   
        //            e.Canceled = true;
        //            rgRule.Rebind();
        //            ctrlAddEditWorkflowRule.Visible = true;
        //            break;
        //        case RadGrid.EditCommandName:                  
        //            gridRuleItem = e.Item as GridDataItem;
        //            base.CurrentWorkflowRuleID = Convert.ToInt32(gridRuleItem.GetDataKeyValue("WorkflowRuleID"));
        //            ctrlAddEditWorkflowRule.CurrentNavigationMode = enumNavigationMode.Edit;
        //            GoToLink("~/Admin/WorkflowRuleAdministration.aspx");
        //            break;
        //        case "View":
        //            //gridRuleItem = e.Item as GridDataItem;
        //            //base.CurrentWorkflowRuleID = long.Parse(gridRuleItem.GetDataKeyValue("WorkflowRuleID").ToString());
        //            //// base.CurrentGroupID = long.Parse(gridItem.GetDataKeyValue("WorkflowGroupID").ToString());
        //            ////base.CurrentStaffingObjectTypeID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectTypeID").ToString());
        //            ////base.CurrentStatusID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectCurrentStatusID").ToString());
        //            //GoToLink("~/Admin/WorkflowActionAdministration.aspx", enumNavigationMode.View);
        //            break;
        //        default:
        //            break;
        //    }

        //}

        private void LoadStaffingObjectTypes()
        {
            try
            {

                List<StaffingObjectType> lstStaffingObjectTypes = LookupManager.GetAllStaffingObjectType();

                ControlUtility.BindRadComboBoxControl(ddlStaffingObjectType, lstStaffingObjectTypes, null, "StaffingObjectTypeName", "StaffingObjectTypeID", "<<- Select Staffing Object Type ->>");
                if (base.CurrentStaffingObjectTypeID > 0)
                {
                    ddlStaffingObjectType.SelectedValue = base.CurrentStaffingObjectTypeID.ToString();
                    rgRule.Rebind();
                    accGroup.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion
        
        #region rgWorkflowGroupRules

        protected void rgRule_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgRule.DataSource = GetWorkflowGroupRules();
        }

        protected void rgRule_ItemCommand(object sender, GridCommandEventArgs e)
        {
            RadWindowManagerRules.Windows.Clear();
            GridDataItem gridRuleItem;
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    rgRule.Rebind();
                    ctrlAddEditWorkflowRule.Visible = true;
                    break;
                case RadGrid.EditCommandName:
                    gridRuleItem = e.Item as GridDataItem;
                    base.CurrentWorkflowRuleID = Convert.ToInt32(gridRuleItem.GetDataKeyValue("WorkflowRuleID"));
                    ctrlAddEditWorkflowRule.CurrentNavigationMode = enumNavigationMode.Edit;
                    GoToLink("~/Admin/WorkflowRuleAdministration.aspx");
                    break;                
                case RadGrid.DeleteCommandName:
                    gridRuleItem = e.Item as GridDataItem;
                    int ruleId = Convert.ToInt32(gridRuleItem.GetDataKeyValue("WorkflowRuleID"));
                    wm.DeleteRule(ruleId);
                    rgRule.Rebind();
                    ctrlAddEditWorkflowRule.LoadStaffingObjectTypes();
                    break;
                default:
                    break;
            }
        }

        protected void rgRule_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridCommandItem)
            {
                GridCommandItem item = (GridCommandItem)e.Item;

                //hide refresh linkbutton   
                ((LinkButton)item.FindControl("RebindGridButton")).Visible = false;

            }
        }  

        #endregion

        #region events

        protected void ddlStaffingObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.CurrentStaffingObjectTypeID = Convert.ToInt32(this.ddlStaffingObjectType.SelectedValue);
            rgRule.Rebind();

            ctrlAddEditWorkflowRule.LoadStaffingObjectTypes();

        }

        #endregion

        #region Permission

        private List<WorkflowGroupPermission> GetWorkflowGroupPermissions()
        {
            List<WorkflowGroupPermission> workflowGroupPermission = new List<WorkflowGroupPermission>();
            if (base.CurrentGroupID > 0)
            {
                pnlPermission.Visible = true;
                List<WorkflowGroupPermission> lstWorkflowPermission = wm.GetAllWorkflowGroupPermissionsByGroupID(base.CurrentGroupID);
                workflowGroupPermission = lstWorkflowPermission;

            }
            return workflowGroupPermission;
        }

        protected void ShowWorkflowGroupPermission(object source, GridCommandEventArgs e)
        {
            RadWindowManagerPermissions.Windows.Clear();
            GridDataItem gridItem;
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    //gridItem = e.Item as GridDataItem;
                    //base.CurrentWorkflowRuleID = long.Parse(gridItem.GetDataKeyValue("WorkflowRuleID").ToString());
                    //base.CurrentGroupID = long.Parse(gridItem.GetDataKeyValue("WorkflowGroupID").ToString());
                    //base.CurrentStaffingObjectTypeID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectTypeID").ToString());
                    //base.CurrentStatusID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectCurrentStatusID").ToString());
                    //GoToLink("~/Admin/WorkflowRuleAdministration.aspx", enumNavigationMode.Insert);
                    break;
                case RadGrid.EditCommandName:
                    //gridItem = e.Item as GridDataItem;
                    //base.CurrentWorkflowRuleID = long.Parse(gridItem.GetDataKeyValue("WorkflowRuleID").ToString());
                    //base.CurrentGroupID = long.Parse(gridItem.GetDataKeyValue("WorkflowGroupID").ToString());
                    //base.CurrentStaffingObjectTypeID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectTypeID").ToString());
                    //base.CurrentStatusID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectCurrentStatusID").ToString());
                    //GoToLink("~/Admin/WorkflowRuleAdministration.aspx", enumNavigationMode.Edit);
                    break;
                case "View":
                    gridItem = e.Item as GridDataItem;
                    //base.CurrentWorkflowRuleID = long.Parse(gridItem.GetDataKeyValue("WorkflowRuleID").ToString());
                    //base.CurrentGroupID = long.Parse(gridItem.GetDataKeyValue("WorkflowGroupID").ToString());
                    //base.CurrentStaffingObjectTypeID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectTypeID").ToString());
                    //base.CurrentStatusID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectCurrentStatusID").ToString());
                    //GoToLink("~/Admin/WorkflowRuleAdministration.aspx", enumNavigationMode.View);                   
                    break;
                default:
                    break;
            }

        }

      

       private void DeleteWorkflowGroupPermission(object source, GridCommandEventArgs e)
       {
           GridDataItem gridItem = e.Item as GridDataItem;
           int workflowGroupRecID = int.Parse(gridItem.GetDataKeyValue("WorkflowGroupRecID").ToString());        
           
           WorkflowManager wm = new WorkflowManager();
           WorkflowGroupPermission workflowGroupPermission = wm.GetWorkflowGroupPermission(workflowGroupRecID);
           wm.Delete(workflowGroupPermission);      
       }

        #region rgWorkflowGroupPermissions

        protected void rgPermission_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            this.rgPermission.DataSource = GetWorkflowGroupPermissions();
        }

        protected void rgPermission_ItemCommand(object sender, GridCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                case RadGrid.EditCommandName:
                case "View":
                    ShowWorkflowGroupPermission(sender, e);
                    break;
                case RadGrid.DeleteCommandName:
                    DeleteWorkflowGroupPermission(sender, e);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #endregion
    }
}