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
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlAddEditWorkflowRule : UserControlBase
    {
        #region Events/Delegates

        public delegate void AddEditRuleHandler();
        public event AddEditRuleHandler AddEditRuleClick;

        #endregion

        WorkflowGroupManager wgm = new WorkflowGroupManager();
        WorkflowManager wm = new WorkflowManager();

        private enumNavigationMode _navMode;
        public enumNavigationMode CurrentNavigationMode
        {
            get
            {
                if (_navMode == enumNavigationMode.None)
                    return base.CurrentNavMode;
                else
                    return _navMode;
            }
            set { this._navMode = value; }

        }

        public int StaffingObjectTypeID
        {
            set { base.CurrentStaffingObjectTypeID = value; }
        }

        #region methods

        protected override void OnInit(EventArgs e)
        {
            //Add Rule
            this.ddlGroup.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlGroup_SelectedIndexChanged);
            this.ddlStaffingObjectType.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlStaffingObjectType_SelectedIndexChanged);
            this.btnContinue.Click += new EventHandler(btnContinue_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);

            //Edit Rule
            this.ctrlAddEditWorkflowAction.AddEditActionClick += new ctrlAddEditWorkflowAction.AddEditActionHandler(ctrlAddEditWorkflowAction_AddEditActionClick);

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

                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void LoadData()
        {
            if (CurrentNavigationMode == enumNavigationMode.Edit)
            {
                if (base.CurrentWorkflowRuleID > 0)
                {
                    LoadWorkflowRulebyID();
                }

                LoadWorkflowActionsbyRuleID();
                tableWorkflowRuleInfo.Visible = true;

                divWorkflowRules.Visible = false;
                tableWorkflowRules.Visible = false;
            }
            else if (CurrentNavigationMode == enumNavigationMode.Insert)
            {
                //Add                
                tableWorkflowRuleInfo.Visible = false;
                rgAction.Visible = false;
                divActions.Visible = false;


                divWorkflowRules.Visible = true;
                lblAddEditHeader.Text = "Add New Rule";
                tableWorkflowRules.Visible = true;

                LoadGroups();
                LoadStaffingObjectTypes();
            }

            ctrlAddEditWorkflowAction.Visible = false;
            divAddEditWorkflowAction.Visible = false;
        }

        protected void SetPageView()
        {
            bool isInEditMode = base.IsInEdit;
            bool isInViewMode = (base.CurrentNavMode == enumNavigationMode.Edit);
        }

        private void LoadWorkflowRulebyID()
        {
            if (base.CurrentStaffingObjectTypeID > 0)
            {
                List<WorkflowRule> listCollection = wm.GetAllWorkflowGroupRulesByGroupID(base.CurrentGroupID, base.CurrentStaffingObjectTypeID);

                if (base.CurrentWorkflowRuleID > 0)
                {
                    listCollection = listCollection.Where(p => (p.WorkflowRuleID == base.CurrentWorkflowRuleID)).ToList();

                    if (listCollection.Count > 0)
                    {
                        base.CurrentGroupID = Convert.ToInt32(listCollection[0].WorkflowGroupID);
                        base.CurrentStaffingObjectTypeID = Convert.ToInt32(listCollection[0].StaffingObjectTypeID);
                        base.CurrentStatusID = Convert.ToInt32(listCollection[0].StaffingObjectCurrentStatusID);

                        lblWorkflowGroupNameValue.Text = "<b>Workflow Group Name: </b>" + listCollection[0].WorkflowGroupName.ToString();
                        lblStaffingObjectNameValue.Text = "<b>Staffing Object Name: </b>" + listCollection[0].StaffingObjectTypeName.ToString();
                        lblCurrentStatusValue.Text = "<b>Current Status: </b>" + listCollection[0].StaffingObjectCurrentStatusName.ToString();
                    }
                }
            }
        }

        private List<WorkflowAction> LoadWorkflowActionsbyRuleID()
        {
            List<WorkflowAction> listCollection = wm.GetAllWorkflowActions();

            if (base.CurrentWorkflowRuleID > 0)
            {
                listCollection = listCollection.Where(p => (p.WorkflowRuleID == base.CurrentWorkflowRuleID)).ToList();
            }
            return listCollection;
        }

        protected void ctrlAddEditWorkflowAction_AddEditActionClick()
        {
            try
            {
                rgAction.Rebind();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
           
        #endregion methods

        #region rgAction

        protected void rgAction_ItemCommand(object sender, GridCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    rgAction.Rebind();
                    ctrlAddEditWorkflowAction.Visible = true;
                    divAddEditWorkflowAction.Visible = true;
                    break;
               
                case RadGrid.DeleteCommandName:
                    GridDataItem gridActionItem = e.Item as GridDataItem;
                    int actionRecID = Convert.ToInt32(gridActionItem.GetDataKeyValue("WorkflowActionRecID"));
                    wm.DeleteAction(actionRecID);
                    ctrlAddEditWorkflowAction.LoadActions();
                    rgAction.Rebind();
                    break;
                default:
                    break;
            }
        }

        protected void rgAction_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgAction.DataSource = LoadWorkflowActionsbyRuleID();
        }

        protected void rgAction_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridCommandItem)
            {
                GridCommandItem item = (GridCommandItem)e.Item;

                //hide refresh linkbutton   
                ((LinkButton)item.FindControl("RebindGridButton")).Visible = false;

            }
        }

        #endregion rgAction

        #region Add Rule Functionality

        #region CRUD

        protected void AddRule(WorkflowRule workflowRule)
        {
            long success = wm.Add(workflowRule);
            if (success > 0)
            {
                lblmsg.Text = "Rule added successfully.";
                LoadData();
            }
            else
            {
                base.PrintErrorMessage("Rule insertion failed.", false);
            }
        }

        protected void EditRule(WorkflowRule workflowRule)
        {
            bool success = wm.Update(workflowRule);
            if (success == true)
            {
                lblmsg.Text = "Rule Updated successfully.";
                LoadData();
            }
            else
            {
                base.PrintErrorMessage("Rule updation failed.", false);
            }
        }

        #endregion CRUD

        #region events

        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStaffingObjectTypes();
            ddlWorkflowStatus.ClearSelection();
        }

        protected void ddlStaffingObjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWorkflowStatuses();
        }

        #endregion events

        #region Add Rule Methods
        private void LoadGroups()
        {
            try
            {
                ControlUtility.BindRadComboBoxControl(ddlGroup, wgm.GetAllWorkflowGroups(), null, "WorkflowGroupName", "WorkflowGroupID", "<<- Select Group ->>");
                if (base.CurrentGroupID > 0)
                {
                    ddlGroup.SelectedValue = base.CurrentGroupID.ToString();
                    ddlGroup.Enabled = false;

                    ddlStaffingObjectType.ClearSelection();
                    ddlWorkflowStatus.ClearSelection();
                }
                else
                {
                    ddlGroup.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        internal void LoadStaffingObjectTypes()
        {
            try
            {
                ddlWorkflowStatus.ClearSelection();

                List<StaffingObjectType> lstStaffingObjectTypes = LookupManager.GetAllStaffingObjectType();

                //filter list
                if (base.CurrentStaffingObjectTypeID > 0)
                {
                    lstStaffingObjectTypes = lstStaffingObjectTypes.Where(p => (p.StaffingObjectTypeID == base.CurrentStaffingObjectTypeID)).ToList();
                }

                ControlUtility.BindRadComboBoxControl(ddlStaffingObjectType, lstStaffingObjectTypes, null, "StaffingObjectTypeName", "StaffingObjectTypeID", "<<- Select Staffing Object Type ->>");

                //filter list
                if (lstStaffingObjectTypes.Count > 0)
                {
                    ddlStaffingObjectType.SelectedValue = lstStaffingObjectTypes[0].StaffingObjectTypeID.ToString();
                    ddlStaffingObjectType.Enabled = false;
                    LoadWorkflowStatuses();
                }
                else
                {
                    ddlStaffingObjectType.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void LoadWorkflowStatuses()
        {
            try
            {
                int selectedCurrentGroupID = -1;
                int selectedCurrentStaffingObjectTypeID = -1;

                if (!String.IsNullOrEmpty(ddlGroup.SelectedValue))
                    selectedCurrentGroupID = Convert.ToInt32(ddlGroup.SelectedValue);
                else
                    selectedCurrentGroupID = base.CurrentGroupID;

                if (!String.IsNullOrEmpty(ddlStaffingObjectType.SelectedValue))
                    selectedCurrentStaffingObjectTypeID = Convert.ToInt32(ddlStaffingObjectType.SelectedValue);
                else
                    selectedCurrentStaffingObjectTypeID = base.CurrentStaffingObjectTypeID;


                List<WorkflowStatus> lstWorkflowStatuses = wm.GetWorkflowStatusByGroupObjectType(selectedCurrentGroupID, selectedCurrentStaffingObjectTypeID, false);
                ControlUtility.BindRadComboBoxControl(ddlWorkflowStatus, lstWorkflowStatuses, null, "WorkflowStatusName", "WorkflowStatusID", "<<- Select WorkflowStatus ->>");
                if (lstWorkflowStatuses.Count > 0)
                {
                    lblmsg.Text = "";
                    ddlWorkflowStatus.Enabled = true;
                    btnContinue.Enabled = true;

                }
                else
                {
                    lblmsg.Text = "No Actions available.";
                    ddlWorkflowStatus.Enabled = false;
                    btnContinue.Enabled = false;
                    if (base.CurrentNavMode == enumNavigationMode.Edit)
                    {
                        divWorkflowRules.Style["display"] = "none";
                        tableWorkflowRules.Visible = false;
                    }

                }

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                WorkflowRule workflowRule = new WorkflowRule();

                if (!String.IsNullOrEmpty(ddlGroup.SelectedValue))
                    workflowRule.WorkflowGroupID = Convert.ToInt32(ddlGroup.SelectedValue);

                if (!String.IsNullOrEmpty(ddlStaffingObjectType.SelectedValue))
                    workflowRule.StaffingObjectTypeID = Convert.ToInt32(ddlStaffingObjectType.SelectedValue);

                if (!String.IsNullOrEmpty(ddlWorkflowStatus.SelectedValue))
                    workflowRule.StaffingObjectCurrentStatusID = Convert.ToInt32(ddlWorkflowStatus.SelectedValue);

                if (workflowRule.WorkflowGroupID > 0
                   && workflowRule.StaffingObjectTypeID > 0
                   && workflowRule.StaffingObjectCurrentStatusID > 0)
                {
                    if (CurrentNavigationMode == enumNavigationMode.Edit)
                    {

                        workflowRule.WorkflowRuleID = Convert.ToInt32(base.CurrentWorkflowRuleID);

                        if (workflowRule.WorkflowGroupID > 0
                            && workflowRule.StaffingObjectTypeID > 0
                            && workflowRule.StaffingObjectCurrentStatusID > 0
                            && base.CurrentWorkflowRuleID > 0)
                        {
                            EditRule(workflowRule);
                        }
                    }
                    else
                    {
                        if (workflowRule.WorkflowGroupID > 0
                            && workflowRule.StaffingObjectTypeID > 0
                            && workflowRule.StaffingObjectCurrentStatusID > 0)
                        {
                            AddRule(workflowRule);

                            if (AddEditRuleClick != null)
                                AddEditRuleClick();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                GoToLink("~/Admin/AddEditWorkflowGroup.aspx");
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion

        #endregion


    }
}
