using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HCMS.Business.Lookups;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.PD;
namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlWorkflowGroup : UserControlBase
    {
        WorkflowGroupManager wgm = new WorkflowGroupManager();
        WorkflowManager wm = new WorkflowManager();              

        #region Methods
        
        protected override void OnLoad(EventArgs e)
        {
            
            if (!IsPostBack)
            {
              BindWorkflowGroup();
                   
              SetPageView(); 
            }
            
            base.OnLoad(e);                        
        }
      
        private void BindWorkflowGroup()
        {

            List<WorkflowGroup> lstWorkflowGroup = new List<WorkflowGroup>();
            lstWorkflowGroup = wgm.GetAllWorkflowGroups();
            this.rgWorkflowGroup.DataSource = lstWorkflowGroup;

        }

        //private List<WorkflowGroupPermission> GetWorkflowGroupPermissions()
        //{
        //    List<WorkflowGroupPermission> workflowGroupPermission = new List<WorkflowGroupPermission>();
        //    if (base.CurrentGroupID > 0)
        //    {                      
        //        pnlPermission.Visible = true;
        //        List<WorkflowGroupPermission> lstWorkflowPermission = wm.GetAllWorkflowGroupPermissionsByGroupID(base.CurrentGroupID);

        //        workflowGroupPermission = lstWorkflowPermission;                
                
        //    }
        //    return workflowGroupPermission;  
        //}
        //private List<WorkflowRule> GetWorkflowGroupRules()
        //{
        //    List<WorkflowRule> workflowGroupRule = new List<WorkflowRule>();
        //    if (base.CurrentGroupID > 0)
        //    {
        //        pnlRule.Visible = true;
        //        List<WorkflowRule> lstWorkflowRule = wm.GetAllWorkflowGroupRulesByGroupID(base.CurrentGroupID);

        //        workflowGroupRule = lstWorkflowRule;

        //    }
        //    return workflowGroupRule;
        //}
      
        protected void SetPageView()
        {             
            bool isInEditMode = base.IsInEdit;
            bool isInViewMode = (base.CurrentNavMode == enumNavigationMode.Insert);
            
            isInEditMode = true;
            isInViewMode = true;
            rgWorkflowGroup.HeaderContextMenu.Visible = isInEditMode;//delete column
            rgWorkflowGroup.Columns[0].Visible = isInEditMode; // edit column
            rgWorkflowGroup.Columns[1].Visible = isInEditMode;//delete column
            rgWorkflowGroup.Columns[1].Display = isInEditMode;//setting the visible=false does not hide the gridbuttoncolumn --delete column
            rgWorkflowGroup.Columns[2].Display = isInViewMode; //view column
            
            if (isInViewMode)
            {
                rgWorkflowGroup.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            }

            //rgPermission.Columns[0].Visible = isInEditMode; // edit column
            //rgPermission.Columns[1].Visible = isInEditMode;//delete column
            //rgPermission.Columns[1].Display = isInEditMode;//setting the visible=false does not hide the gridbuttoncolumn --delete column
            //rgPermission.Columns[2].Display = isInViewMode; //view column
            //if (isInViewMode)
            //{
            //    rgPermission.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            //}

            
            //rgRule.Columns[0].Visible = isInEditMode; // edit column
            //rgRule.Columns[1].Visible = isInEditMode;//delete column
            //rgRule.Columns[1].Display = isInEditMode;//setting the visible=false does not hide the gridbuttoncolumn --delete column
            //rgRule.Columns[2].Display = isInViewMode; //view column
            //if (isInViewMode)
            //{
            //    rgRule.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            //}

        }        
        protected void ShowWorkflowGroup(object source, GridCommandEventArgs e)
        {
            RadWindowManagerGroups.Windows.Clear();
            GridDataItem gridItem;

            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    GoToLink("~/Admin/AddEditWorkflowGroup.aspx", enumNavigationMode.Insert);
                    break;
                case RadGrid.EditCommandName:
                    gridItem = e.Item as GridDataItem;
                    base.CurrentGroupID = int.Parse(gridItem.GetDataKeyValue("WorkflowGroupID").ToString());
                    base.CurrentStaffingObjectTypeID = -1;
                    GoToLink("~/Admin/AddEditWorkflowGroup.aspx", enumNavigationMode.Edit);
                    //rgPermission.Rebind();
                    //rgRule.Rebind();
                    break;
                case "View":
                  
                   
                    break;
                default:
                    break;
            }

        }
        //protected void ShowWorkflowGroupPermission(object source, GridCommandEventArgs e)
        //{
        //    RadWindowManagerPermissions.Windows.Clear();
        //    GridDataItem gridItem;
        //    switch (e.CommandName)
        //    {
        //        case RadGrid.InitInsertCommandName:
        //            //gridItem = e.Item as GridDataItem;
        //            //base.CurrentWorkflowRuleID = long.Parse(gridItem.GetDataKeyValue("WorkflowRuleID").ToString());
        //            //base.CurrentGroupID = long.Parse(gridItem.GetDataKeyValue("WorkflowGroupID").ToString());
        //            //base.CurrentStaffingObjectTypeID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectTypeID").ToString());
        //            //base.CurrentStatusID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectCurrentStatusID").ToString());
        //            //GoToLink("~/Admin/WorkflowRuleAdministration.aspx", enumNavigationMode.Insert);
        //            break;
        //        case RadGrid.EditCommandName:
        //            //gridItem = e.Item as GridDataItem;
        //            //base.CurrentWorkflowRuleID = long.Parse(gridItem.GetDataKeyValue("WorkflowRuleID").ToString());
        //            //base.CurrentGroupID = long.Parse(gridItem.GetDataKeyValue("WorkflowGroupID").ToString());
        //            //base.CurrentStaffingObjectTypeID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectTypeID").ToString());
        //            //base.CurrentStatusID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectCurrentStatusID").ToString());
        //            //GoToLink("~/Admin/WorkflowRuleAdministration.aspx", enumNavigationMode.Edit);
        //            break;
        //        case "View":
        //            gridItem = e.Item as GridDataItem;
        //            //base.CurrentWorkflowRuleID = long.Parse(gridItem.GetDataKeyValue("WorkflowRuleID").ToString());
        //            //base.CurrentGroupID = long.Parse(gridItem.GetDataKeyValue("WorkflowGroupID").ToString());
        //            //base.CurrentStaffingObjectTypeID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectTypeID").ToString());
        //            //base.CurrentStatusID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectCurrentStatusID").ToString());
        //            //GoToLink("~/Admin/WorkflowRuleAdministration.aspx", enumNavigationMode.View);                   
        //            break;
        //        default:
        //            break;
        //    }

        //}
        //protected void ShowWorkflowGroupRules(object source, GridCommandEventArgs e)
        //{
        //    RadWindowManagerRules.Windows.Clear();
        //    GridDataItem gridRuleItem;            

        //    switch (e.CommandName)
        //    {
        //        case RadGrid.InitInsertCommandName:     
        //            GoToLink("~/Admin/WorkflowRuleAdministration.aspx", enumNavigationMode.Insert);
        //            break;
        //        case RadGrid.EditCommandName:
        //            gridRuleItem = e.Item as GridDataItem;
        //            base.CurrentWorkflowRuleID = long.Parse(gridRuleItem.GetDataKeyValue("WorkflowRuleID").ToString());
        //            base.CurrentGroupID = long.Parse(gridRuleItem.GetDataKeyValue("WorkflowGroupID").ToString());
        //            base.CurrentStaffingObjectTypeID = long.Parse(gridRuleItem.GetDataKeyValue("StaffingObjectTypeID").ToString());
        //            base.CurrentStatusID = long.Parse(gridRuleItem.GetDataKeyValue("StaffingObjectCurrentStatusID").ToString());
        //            GoToLink("~/Admin/WorkflowActionAdministration.aspx", enumNavigationMode.Edit);
        //            break;
        //        case "View":
        //            gridRuleItem = e.Item as GridDataItem;
        //            base.CurrentWorkflowRuleID = long.Parse(gridRuleItem.GetDataKeyValue("WorkflowRuleID").ToString());
        //           // base.CurrentGroupID = long.Parse(gridItem.GetDataKeyValue("WorkflowGroupID").ToString());
        //            //base.CurrentStaffingObjectTypeID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectTypeID").ToString());
        //            //base.CurrentStatusID = long.Parse(gridItem.GetDataKeyValue("StaffingObjectCurrentStatusID").ToString());
        //            GoToLink("~/Admin/WorkflowActionAdministration.aspx", enumNavigationMode.View);                   
        //            break;
        //        default:
        //            break;
        //    }

        //}         
        #endregion

        #region rgWorkflowGroup  

        protected void rgWorkflowGroup_ItemCommand(object sender, GridCommandEventArgs e)
        {
            
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    break;
                case RadGrid.EditCommandName:
                    ShowWorkflowGroup(sender, e);
                    break;
                case "View":
                    
                    break;
                case RadGrid.DeleteCommandName:
                    
                    break;
                default:
                    break;
            }
        }       

        protected void rgWorkflowGroup_ItemDataBound(object sender, GridItemEventArgs e)
        {
            GridItem gridItem = e.Item;
            //hide the refresh button Telerik.Web.UI.GridLinkButton
            if (gridItem is GridCommandItem)
            {
                gridItem.FindControl("RebindGridButton").Visible = false;            
            }

        }
       
        #endregion

            
       
    }
}
