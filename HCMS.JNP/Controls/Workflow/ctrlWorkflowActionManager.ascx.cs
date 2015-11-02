using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.PD;
using HCMS.Business.JNP;
using HCMS.Business.JA;
using HCMS.Business.CR;
using HCMS.Business.JQ;
using System.ComponentModel;
using Telerik.Web.UI;
namespace HCMS.JNP.Controls.Workflow
{
    public class ScreenValidationEventArgs : CancelEventArgs
    {
        public bool IsValid { get; set; }
    }

    public class WorkflowObjectSavedEventArgs : EventArgs
    {
        private bool _cancel = false;
        public bool Cancel { get { return _cancel; } set { _cancel = value; } }
    }
    public partial class ctrlWorkflowActionManager : JNPUserControlBase
    {
        public delegate void WorkflowObjectNotSetHandler();
        public event WorkflowObjectNotSetHandler WorkflowObjectNotSet;

        public event ScreenValidationHandler ScreenValidationEvent;
        public delegate void ScreenValidationHandler(object sender, ScreenValidationEventArgs e);


        public delegate void SaveHandler(object sender, WorkflowObjectSavedEventArgs e);
        public event SaveHandler WorkflowObjectSaved;

        public delegate void DocumentFinalizeCompleteHandler();
        public event DocumentFinalizeCompleteHandler DocumentFinalizedEvent;

        public delegate void HRSendForApprovalToHiringManagerHandler();
        public event HRSendForApprovalToHiringManagerHandler SendForApprovalToHiringManagerEvent;

        private bool _hasErrors = false;

        private bool _confirmQuestionnaireReadiness = false;




        private bool HasErrors
        {
            get { return _hasErrors; }
            set { _hasErrors = value; }
        }
        public void BindActions()
        {
            if (CurrentWorkflowObject == null)
            {
                if (WorkflowObjectNotSet != null)
                    WorkflowObjectNotSet();
            }

            else
            {

                List<WorkflowAction> listofActions = WorkflowManager.GetNextWorkflowActions(CurrentWorkflowObject);
                this.radComboActions.DataSource = listofActions;
                radComboActions.DataBind();
                radComboActions.Items.Insert(0, new RadComboBoxItem("[-- Select Action --]", "-1"));

            }

        }

        public WorkflowObject CurrentWorkflowObject
        {
            get
            {
                WorkflowObject _currentwo = null;
                if (ViewState["CurrentWorkflowObject"] == null)
                {
                    if (WorkflowObjectNotSet != null)
                        WorkflowObjectNotSet();
                }
                else
                {
                    _currentwo = (WorkflowObject)ViewState["CurrentWorkflowObject"];
                }
                return _currentwo;
            }
            set
            {
                ViewState["CurrentWorkflowObject"] = value;
            }
        }

        protected void btnConfirmReviseReady_OK_Click(object sender, EventArgs e)
        {
            radComboActions.Enabled = true;
            btnSubmit.Enabled = true;
            rwConfirmBeforeRevise.VisibleOnPageLoad = false;
            _confirmQuestionnaireReadiness = true;
            btnSubmit_Click(sender, e);
        }

        protected void btnConfirmReviseReady_Cancel_Click(object sender, EventArgs e)
        {
            radComboActions.Enabled = true;
            btnSubmit.Enabled = true;
            rwConfirmBeforeRevise.VisibleOnPageLoad = false;
            _confirmQuestionnaireReadiness = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            //var wfStatus = WorkflowManager.GetJNPCurrentDocumentWorklfowStatus(CurrentJNPID);
            enumJNPWorkflowStatus  wfStatus = base.CurrentJNPWS;
            
            if (wfStatus != enumJNPWorkflowStatus.Revise && 
                int.Parse(radComboActions.SelectedValue) == (int)enumActionType.SendToReviseToHiringManager &&
                !_confirmQuestionnaireReadiness)
            {
                radComboActions.Enabled = false;
                btnSubmit.Enabled = false;
                rwConfirmBeforeRevise.VisibleOnPageLoad = true;
                return;
            }

            if (int.Parse(radComboActions.SelectedValue) != (int)enumActionType.DeleteCategoryRating)
            {
                if (ScreenValidationEvent != null)
                {
                    ScreenValidationEventArgs validationArgs = new ScreenValidationEventArgs();
                    ScreenValidationEvent(this, validationArgs);
                    isValid = validationArgs.IsValid;
                }
            }


            if (isValid)
            {
                enumActionType actiontypeid = (enumActionType)(int.Parse(radComboActions.SelectedValue));
                WorkflowObject wo = CurrentWorkflowObject;
                long parentobjectid = wo.ParentObjectID;
                string url = string.Empty;
                string validationErrors = string.Empty;
                bool blnhaserror = false;
                HasErrors = false;
                long checkid = -1;
                WorkflowObjectSavedEventArgs we;

                try
                {
                    switch (actiontypeid)
                    {
                        case enumActionType.SendToReviewToHiringManager:
                        case enumActionType.SendToReviewToHumanResources:

                             validationErrors = WorkflowManager.GetStaffingObjetValidationErros(wo.StaffingObjectID, wo.StaffingObjectTypeID, ref blnhaserror, true);


                             if (blnhaserror)
                             {
                                 HasErrors = true;
                                 customValidator.ErrorMessage = validationErrors;
                                 Page.Validate();

                             }
                             else
                             {
                                 we = new WorkflowObjectSavedEventArgs();
                                 if (WorkflowObjectSaved != null) { WorkflowObjectSaved(this, we); }
                                 if (!we.Cancel)
                                 {
                                     if (WorkflowManager.SetCurrentWorkflowStatus(wo, (int)enumJNPWorkflowStatus.Review, true) > 0)
                                     {
                                         GoToLink(Page.ResolveUrl("~/Package/JNPTracker.aspx"));
                                     }
                                 }
                             }
                            break;

                        case enumActionType.SendToReviseToHiringManager:
                        case enumActionType.SendToReviseToHumanResources:
                             validationErrors = WorkflowManager.GetStaffingObjetValidationErros(wo.StaffingObjectID, wo.StaffingObjectTypeID, ref blnhaserror,true);

                             if (blnhaserror)
                             {
                                 HasErrors = true;
                                 customValidator.ErrorMessage = validationErrors;
                                 Page.Validate();

                             }
                             else
                             {
                                 we = new WorkflowObjectSavedEventArgs();
                                 if (WorkflowObjectSaved != null) { WorkflowObjectSaved(this, we); }
                                 if (!we.Cancel)
                                 {
                                     if (WorkflowManager.SetCurrentWorkflowStatus(wo, (int)enumJNPWorkflowStatus.Revise, true) > 0)
                                     {
                                         GoToLink(Page.ResolveUrl("~/Package/JNPTracker.aspx"));
                                     }
                                 }
                             }
                            break;

                        case enumActionType.SendForFinalReviewToHumanResources:
                             validationErrors = WorkflowManager.GetStaffingObjetValidationErros(wo.StaffingObjectID, wo.StaffingObjectTypeID, ref blnhaserror,true);

                             if (blnhaserror)
                             {
                                 HasErrors = true;
                                 customValidator.ErrorMessage = validationErrors;
                                 Page.Validate();

                             }
                             else
                             {
                                 we = new WorkflowObjectSavedEventArgs();
                                 if (WorkflowObjectSaved != null) { WorkflowObjectSaved(this, we); }
                                 if (!we.Cancel)
                                 {
                                     if (WorkflowManager.SetJNPCurrentWorkflowStatus(CurrentJNPID, (int)enumJNPWorkflowStatus.FinalReview, enumWorkflowStatusType.JNP, CurrentUserID, true) > 0)
                                     {
                                         GoToLink(Page.ResolveUrl("~/Package/JNPTracker.aspx"));
                                     }
                                 }
                             }
                            break;

                        case enumActionType.SaveAndUnlock:
                            we = new WorkflowObjectSavedEventArgs();
                            if (WorkflowObjectSaved != null) { WorkflowObjectSaved(this, we); }
                            if (!we.Cancel)
                            {
                                if ((wo.ParentObjectID > 0) && (wo.ParentObjetTypeID == enumStaffingObjectType.JNP))
                                {
                                    checkid = WorkflowManager.CheckStaffingObject(wo.ParentObjectID, wo.ParentObjetTypeID, enumActionType.CheckIn, wo.UserID);
                                }

                                if (checkid > 0) { GoToLink(Page.ResolveUrl("~/Package/JNPTracker.aspx")); }
                            }
                            break;

                        case enumActionType.CreateCategoryRatingOptional:
                            if (CategoryRatingManager.CreateCategoryRatingFromJobAnalysis(CurrentJNPID, CurrentJAID, false, CurrentUserID) > 0)
                            {
                                ReloadCurrentJNP(base.CurrentJNPID);
                                GoToLink(Page.ResolveUrl("~/CR/CategoryRating.aspx"), base.CurrentNavMode);
                            }
                            break;

                        case enumActionType.RestoreCategoryRatingOptional:
                            if (CategoryRatingManager.RestoreCategoryRating(CurrentCRID, CurrentUserID) > 0)
                            {
                                ReloadCurrentJNP(base.CurrentJNPID);
                                GoToLink(Page.ResolveUrl("~/CR/CategoryRating.aspx"), base.CurrentNavMode);
                            }
                            break;

                        case enumActionType.CheckAndPublish :
                            validationErrors = WorkflowManager.GetStaffingObjetValidationErros(wo.StaffingObjectID, wo.StaffingObjectTypeID, ref blnhaserror, true);
                            
                            if (blnhaserror)
                            {
                                HasErrors = true;
                                customValidator.ErrorMessage = validationErrors;
                                Page.Validate();

                            }
                            else
                            {
                                if (WorkflowManager.SetJNPCurrentWorkflowStatus(CurrentJNPID, (int)enumJNPWorkflowStatus.Published, enumWorkflowStatusType.JNP, CurrentUserID, true) > 0)
                                {
                                    lblmsg.Text = "Document is published.";
                                    BindActions();
                                    base.GetActiveDocumentType(true);
                                    
                                    //Below is no longer in scope for new requirement.
                                    //base.GetJNPCurrentDocumentWorklfowStatus(true);
                                    
                                    GoToLink(Page.ResolveUrl(string.Format("~/Package/Publish.aspx?JNPID={0}", CurrentJNPID)));
                                }

                            }
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        protected void customValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !(HasErrors);
        }
    }


}