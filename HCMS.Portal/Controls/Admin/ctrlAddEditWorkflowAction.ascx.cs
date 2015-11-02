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
using System.Data;

namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlAddEditWorkflowAction : UserControlBase
    {
        WorkflowGroupManager wgm = new WorkflowGroupManager();
        WorkflowManager wm = new WorkflowManager();

        #region Events/Delegates

        public delegate void AddEditActionHandler();
        public event AddEditActionHandler AddEditActionClick;

        #endregion

        protected override void OnInit(EventArgs e)
        {
            this.ddlActionType.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlActionType_SelectedIndexChanged);
            this.btnContinue.Click += new EventHandler(btnContinue_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            //this.btnEditRule.Click += new EventHandler(btnEditRule_Click);

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

        #region methods

        private void LoadData()
        {
            LoadActions();
        }

        protected void SetPageView()
        {
            bool isInEditMode = base.IsInEdit;
            bool isInViewMode = (base.CurrentNavMode == enumNavigationMode.Edit);

            //divWorkflowRuleInfo.Visible = true;
            //tableWorkflowRuleInfo.Visible = true;

            lblHeader.Text = "Add New Action";
            //divWorkflowRuleInfo.Visible = true;
            //tableWorkflowRuleInfo.Visible = true;



        }

        private void LoadWorkflowRuleInfo()
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

                    //lblWorkflowGroupNameValue.Text = "<b>Workflow Group Name: </b>" + listCollection[0].WorkflowGroupName.ToString();
                    //lblStaffingObjectNameValue.Text = "<b>Staffing Object Name: </b>" + listCollection[0].StaffingObjectTypeName.ToString();
                    //lblCurrentStatusValue.Text = "<b>Current Status: </b>" + listCollection[0].StaffingObjectCurrentStatusName.ToString();
                }
            }
        }

        internal void LoadActions()
        {
            try
            {
                LoadWorkflowRuleInfo();
                ControlUtility.BindRadComboBoxControl(ddlActionType, wm.GetActionTypesForWorkflowRuleId(base.CurrentWorkflowRuleID), null, "ActionTypeName", "ActionTypeID", "<<- Select Action ->>");
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private bool EnableSubmitButton()
        {
            bool enableSubmitButton = false;

            if (!String.IsNullOrEmpty(ddlActionType.SelectedValue))
            {
                enableSubmitButton = true;
            }

            return enableSubmitButton;

        }

        protected void AddAction(WorkflowAction workflowAction)
        {
            long success = wm.Add(workflowAction);
            if (success > 0)
            {
                lblmsg.Text = "Action added successfully.";
                LoadData();
            }
            else
            {
                base.PrintErrorMessage("Action insertion failed.", false);
            }
        }

        protected void EditAction(WorkflowAction workflowAction)
        {
            bool success = wm.Update(workflowAction);
            if (success == true)
            {
                lblmsg.Text = "Action updated successfully.";
                LoadData();
            }
            else
            {
                base.PrintErrorMessage("Action updation failed.", false);
            }
        }

        #endregion

        #region events

        protected void ddlActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlActionType.Enabled = EnableSubmitButton();
        }

        //protected void btnEditRule_Click(object sender, EventArgs e)
        //{
        //    GoToLink("~/Admin/WorkflowRuleAdministration.aspx", enumNavigationMode.Edit);
        //}

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                WorkflowAction workflowAction = new WorkflowAction();

                if (base.CurrentWorkflowRuleID > 0)
                    workflowAction.WorkflowRuleID = Convert.ToInt32(base.CurrentWorkflowRuleID);

                if (!String.IsNullOrEmpty(ddlActionType.SelectedValue))
                    workflowAction.ActionTypeID = Convert.ToInt32(ddlActionType.SelectedValue);

                //if (CurrentNavigationMode == enumNavigationMode.Edit)
                //{
                //    workflowAction.WorkflowActionRecID = Convert.ToInt32(base.CurrentActionRecID);

                //    if (workflowAction.WorkflowRuleID > 0
                //        && workflowAction.ActionTypeID > 0
                //        && workflowAction.WorkflowActionRecID > 0)
                //    {
                //        EditAction(workflowAction);
                //    }
                //}
                //else
                //{
                if (workflowAction.WorkflowRuleID > 0
                    && workflowAction.ActionTypeID > 0)
                {
                    AddAction(workflowAction);

                    if (AddEditActionClick != null)
                        AddEditActionClick();
                }
                //}

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
                GoToLink("~/Admin/WorkflowRuleAdministration.aspx");
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion

    }
}
