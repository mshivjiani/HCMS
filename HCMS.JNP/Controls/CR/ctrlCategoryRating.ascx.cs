using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Text;

using HCMS.WebFramework.Common;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.CR;
using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.JQ;
using HCMS.Business.PD;
using HCMS.Business.Lookups;
using HCMS.Business.JNP;
using HCMS.JNP.Controls.Workflow; 

using Telerik.Reporting.Drawing;
using Telerik.Web.UI;


namespace HCMS.JNP.Controls.CR
{
    public partial class ctrlCategoryRating : JNPUserControlBase
    {
        #region [ event handlers ]
        protected override void OnInit(EventArgs e)
        {
            this.ctrlWActManager.ScreenValidationEvent += new Workflow.ctrlWorkflowActionManager.ScreenValidationHandler(ctrlWActManager_ScreenValidationEvent);
            this.ctrlWActManager.WorkflowObjectSaved += new Workflow.ctrlWorkflowActionManager.SaveHandler(ctrlWActManager_WorkflowObjectSaved);
            //this.ctrlWActManager.DocumentFinalizedEvent += new ctrlWorkflowActionManager.DocumentFinalizeCompleteHandler(ctrlWActManager_DocumentFinalizedEvent);
            this.btnWellQualified.Command += new CommandEventHandler(btnWellQualified_Command);
            base.OnInit(e);
        }



        //void ctrlWActManager_DocumentFinalizedEvent()
        //{
        //    SetPageView();
        //    SetContinueAndWFActionDD();
        //    BindData();
        //    //BindActionsDD(); 
        //    BindHyperLink();
        //}

        void ctrlWActManager_WorkflowObjectSaved(object sender, WorkflowObjectSavedEventArgs e)
        {
            bool savesuccessful = false;
            savesuccessful = ValidateSaveCR();
            //cancel if save was not successful
            e.Cancel = !savesuccessful;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (IsValidCR())
                {
                    BindData();
                    //BindActionsDD();
                    SetPageView();
                    SetContinueAndWFActionDD();
                    BindHyperLink();
                }
            }
        }

        private void ctrlWActManager_ScreenValidationEvent(object sender, Workflow.ScreenValidationEventArgs e)
        {
            e.IsValid = false;
            Page.Validate();
            if (Page.IsValid)
            {
                //JAX issue: 949: System should not require user to hit save on CR before sending the JAX to next status
                //The problem used to happen when user clicks Go button instead of hitting Save, after entering all required information related to CR
                //The problem happened because entered information in CR is not yet saved in db. 
                //CtrlWorkflowActionManager (Go button control) then calls GetStaffingObjetValidationErros before moving the JAX to next status.
                //GetStaffingObjetValidationErros will return the errors related to CR as well because db still does not have that information.
                //even if the screen is validated.
                                
                //So if the screen validation is passed then system should save CR to avoid raising
                //CR related errors by GetStaffingObjetValidationErros
                SaveCategoryRatingGroups();
                e.IsValid = true;
            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidCR())
            {
                // validate the Category Rating Groups
                ValidateSaveCR();
            }
        }

        private bool ValidateSaveCR()
        {
            bool blnret = false;
            // validate the Category Rating Groups
            string message = ValidateCategoryRatingGroups();
            if (string.IsNullOrEmpty(message))
            {
                SaveCategoryRatingGroups();
                blnret = true;
            }

            return blnret;
        }
        protected void btnWellQualified_Command(object sender, CommandEventArgs e)
        {

            try
            {
                if (e.CommandName == "Delete")
                {
                    CategoryRatingGroup group = CategoryRatingGroupManager.GetWellQuilifiedGroup(CurrentCRID);
                    if (group != null)
                    {
                        CategoryRatingGroupManager.Delete(group, this.CurrentUserID);
                        wellQualified.Visible = false;
                        btnWellQualified.Text = "Add Well Qualified Section";
                        btnWellQualified.CommandName = "Add";

                    }
                }
                else if (e.CommandName == "Add")
                {

                    long crGroupID = CategoryRatingGroupManager.AddCRGroupByScoringRangeGroupType(enumScoringRangeGroupType.WellQualified, CurrentCRID, CurrentUserID);
                    if (crGroupID > 0)
                    {
                        wellQualified.Visible = true;
                        CategoryRatingGroup wellQuilifiedGroup = CategoryRatingGroupManager.GetByID(crGroupID);
                        if (wellQuilifiedGroup != null)
                        {
                            rtbWQGroupTypeName.Text = wellQuilifiedGroup.ScoringRangeGroupTypeName;
                            rtbWQRangeMin.Text = wellQuilifiedGroup.RangeMin.ToString();
                            rtbWQRangeMax.Text = wellQuilifiedGroup.RangeMax.ToString();
                            rtbWQQualifyingStatements.Text = wellQuilifiedGroup.QualifyingStatements;

                            btnWellQualified.Text = "Remove Well Qualified Section";
                            btnWellQualified.CommandName = "Delete";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }

        }


        #endregion

        private void SetContinueAndWFActionDD()
        {
            // Get a fresh JNP load in case some piece has changed since it was cached
            ReloadCurrentJNP(base.CurrentJNPID);
            bool isThisLastScreen = (base.LastScreen() == enumLastScreen.CR);
            bool isJNPPublished = CurrentJNP.IsPublished();

            this.btnContinue.Visible = base.ShowEditFields(enumDocumentType.CR) && !isThisLastScreen;
            this.ctrlWActManager.Visible = base.ShowEditFields(enumDocumentType.CR) && isThisLastScreen && !isJNPPublished;
            if (this.ctrlWActManager.Visible) BindActionsDD();

            // If we're in edit mode, the JNP is not DEU and we actually have a CR
            // then allow/show the delete button.
            this.btnDelete.Visible = base.ShowEditFields(enumDocumentType.CR);

            if (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview)
            {
                this.btnContinue.Visible = true;
            }
        }

        private void BindActionsDD()
        {
            WorkflowObject wo = new WorkflowObject();
            wo.StaffingObjectID = CurrentJNPID;
            wo.StaffingObjectTypeID = enumStaffingObjectType.JNP;
            wo.ParentObjectID = CurrentJNPID;
            wo.ParentObjetTypeID = enumStaffingObjectType.JNP;
            wo.UserID = CurrentUserID;
            this.ctrlWActManager.CurrentWorkflowObject = wo;
            this.ctrlWActManager.BindActions();
        }

        //private bool ShowEditFields()
        //{
        //    enumJNPWorkflowStatus currentws = base.CurrentJNPWS;

        //    bool showEditFields = ((base.IsInEdit)
        //      && (currentws == enumJNPWorkflowStatus.Draft
        //      || currentws == enumJNPWorkflowStatus.Review
        //      || (currentws == enumJNPWorkflowStatus.Revise && !CurrentJNP.IsJNPSignedBySupervisor)
        //      || (currentws == enumJNPWorkflowStatus.FinalReview && !CurrentJNP.IsJNPSignedByHR))
        //      );

        //    return showEditFields;
        //}

        private void SetPageView()
        {
            bool isInViewMode = (base.CurrentNavMode == enumNavigationMode.View);
             bool isThisLastScreen = (base.LastScreen() == enumLastScreen.CR);
            if (isInViewMode)
            {
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                RadSpellQualifyingStatements.Enabled = false;
                btnWellQualified.Enabled = false;
            }
            else
            {
                if (HasWellQuilifiedGroup)
                {
                    wellQualified.Visible = true;
                    btnWellQualified.Text = "Remove Well Qualified Section";
                    btnWellQualified.CommandName = "Delete";
                }
                else
                {
                    wellQualified.Visible = false;
                    btnWellQualified.Text = "Add Well Qualified Section";
                    btnWellQualified.CommandName = "Add";

                }

                //added condition to check if active document is in finalized status then it should not be editable
                //moved the ctrlWActManger outside of this because it should be visible if the 
                //showEditFields is true.
                if ((isInViewMode) || (!base.ShowEditFields(enumDocumentType.CR))) //|| (currentdocws == enumDocWorkflowStatus.DocumentFinalize))
                {
                    btnSave.Enabled = false;
                    this.btnWellQualified.Enabled = false;
                    this.RadSpellQualifyingStatements.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                    this.btnWellQualified.Enabled = true;
                    this.RadSpellQualifyingStatements.Enabled = true;
                    this.btnContinue.Visible = false;
                }

                if (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview)
                {
                    if (base.IsAdmin)
                    {
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                        btnWellQualified.Enabled = true;
                    }
                    else
                    {
                        //Issue 1060 Editable for HR in FinalReview
                        if ((base.HasHRGroupPermission) && (!CurrentJNP.IsJNPSignedByHR))
                        {
                            btnSave.Enabled = true;
                            btnDelete.Enabled = true;
                            btnWellQualified.Enabled = true;
                        }
                        else
                        {
                            btnSave.Enabled = false;
                            btnDelete.Enabled = false;
                            btnWellQualified.Enabled = false;
                        }
                    }

                }
            }
        }

        private void BindData()
        {
            try
            {
                rtbFinalKSA.Text = CategoryRatingManager.GetFinalKSAS(CurrentJAID);

                PopulateCategoryRatingGroups();
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }

        private void BindHyperLink()
        {
            JNPackage jnpPackage = new JNPackage(base.CurrentJNPID);
            Series series = new Series(jnpPackage.SeriesID);
            string urlhlMinimumQualifications = string.Format("~/CR/MinimumQualifications.aspx");
            hlMinimumQualifications.NavigateUrl = urlhlMinimumQualifications;
            hlMinimumQualifications.Attributes.Add("onClick", "javascript:ShowMinimumQualificationsPopUp(" + series.SeriesID + "," + series.TypeOfWorkID + "," + jnpPackage.HighestAdvertisedGrade + ",'" + CurrentNavMode + "'); return false;");
        }
        private void PopulateCategoryRatingGroups()
        {
            CategoryRatingGroup bestQuilifiedGroup = CategoryRatingGroupManager.GetBestQuilifiedGroup(CurrentCRID);
            if (bestQuilifiedGroup != null)
            {
                rtbBQGroupTypeName.Text = bestQuilifiedGroup.ScoringRangeGroupTypeName;
                rtbBQRangeMin.Text = bestQuilifiedGroup.RangeMin.ToString();
                rtbBQRangeMax.Text = bestQuilifiedGroup.RangeMax.ToString();
                rtbBQQualifyingStatements.Text = bestQuilifiedGroup.QualifyingStatements;
            }

            CategoryRatingGroup wellQuilifiedGroup = CategoryRatingGroupManager.GetWellQuilifiedGroup(CurrentCRID);
            if (wellQuilifiedGroup != null)
            {
                rtbWQGroupTypeName.Text = wellQuilifiedGroup.ScoringRangeGroupTypeName;
                rtbWQRangeMin.Text = wellQuilifiedGroup.RangeMin.ToString();
                rtbWQRangeMax.Text = wellQuilifiedGroup.RangeMax.ToString(); 
                rtbWQQualifyingStatements.Text = wellQuilifiedGroup.QualifyingStatements;
            }

            CategoryRatingGroup quilifiedGroup = CategoryRatingGroupManager.GetQuilifiedGroup(CurrentCRID);
            if (quilifiedGroup != null)
            {
                rtbQGroupTypeName.Text = quilifiedGroup.ScoringRangeGroupTypeName;
                rtbQGroupTypeName.Font.Bold = true;

                rtbQRangeMin.Text = quilifiedGroup.RangeMin.ToString();
                rtbQRangeMax.Text = quilifiedGroup.RangeMax.ToString();
                rtbQQualifyingStatements.Text = quilifiedGroup.QualifyingStatements;

                if (string.IsNullOrEmpty (quilifiedGroup.QualifyingStatements))
                {
                    JNPackage jnpPackage = new JNPackage(base.CurrentJNPID);
                    Series series = new Series(jnpPackage.SeriesID);

                    rtbQQualifyingStatements.Text = CategoryRatingManager.GetMinimumQualification(series.TypeOfWorkID, jnpPackage.HighestAdvertisedGrade); ;
                }
            }
        }

        protected void customValCR_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string message = ValidateCategoryRatingGroups();

            if (!string.IsNullOrEmpty(message))
            {
                args.IsValid = false;
                customValCR.ErrorMessage = message;
            }
            else
            {
                args.IsValid = true;
                customValCR.ErrorMessage = string.Empty;
            }
        }


        private string ValidateCategoryRatingGroups()
        {
            bool hasWellQuilifiedGroup = HasWellQuilifiedGroup;

            //string message = String.Empty;
            StringBuilder message = new StringBuilder();
            string xmessage = string.Empty;


            int floor = 70;
            int ceiling = 100;

            // best qualified
            int bqRangeMin = Int32.Parse(rtbBQRangeMin.Text);
            int bqRangeMax = Int32.Parse(rtbBQRangeMax.Text);

            // well qualified
            int wqRangeMin = hasWellQuilifiedGroup ? Int32.Parse(rtbWQRangeMin.Text) : -1;
            int wqRangeMax = hasWellQuilifiedGroup ? Int32.Parse(rtbWQRangeMax.Text) : -1;

            // qualified
            int qRangeMin = Int32.Parse(rtbQRangeMin.Text);
            int qRangeMax = Int32.Parse(rtbQRangeMax.Text);

            // start checking rules from bottom - up...
            if (qRangeMin < floor)
                message.Append(String.Format("The Min range for Qualified should be greater than {0}", floor));
            else if (qRangeMax <= qRangeMin)
                message.Append("The Max range for Qualified should be greater than Min");
            else if (qRangeMax >= ceiling)
                message.Append(String.Format("The Max range for Qualified should be less than {0}", ceiling));

            if (hasWellQuilifiedGroup)
            {
                xmessage = string.Empty;

                if (wqRangeMin <= qRangeMax)
                    xmessage = "The Min range for Well Qualified should be greater than Max for Qualified";
                else if (wqRangeMin > qRangeMax + 1)
                    xmessage = "There should not be a gap in value between Min range for Well Qualified and Max for Qualified";
                else if (wqRangeMax <= wqRangeMin)
                    xmessage = "The Max range for Well Qualified should be greater than Min";
                else if (wqRangeMax >= ceiling)
                    xmessage = String.Format("The Max range for Well Qualified should be less than {0}", ceiling);
                else if (bqRangeMin <= wqRangeMax)
                    xmessage = "The Min range for Best Qualified should be greater than Max for Well Qualified";
                else if (bqRangeMin > wqRangeMax + 1)
                    xmessage = "There should not be a gap in value between Min range for Best Qualified and Max for Well Qualified";
                else if (bqRangeMax <= wqRangeMin)
                    xmessage = "The Max range for Best Qualified should be greater than Min for Well Qualified";
                else if (bqRangeMax > ceiling)
                    xmessage = String.Format("The Max range for Best Qualified should be less or equal to {0}", ceiling);

                if (string.IsNullOrEmpty(message.ToString()))
                {
                    message.Append(xmessage);
                }
                else
                {
                    message.Append("<li>" + xmessage + "</li>");
                }
            }
            else
            {
                xmessage = string.Empty;

                if (bqRangeMin <= qRangeMax)
                    xmessage = "The Min range for Best Qualified should be greater than Max for Qualified";
                else if (bqRangeMin > qRangeMax + 1)
                    xmessage = "There should not be a gap in value between Min range for Best Qualified and Max for Qualified";
                else if (bqRangeMax <= qRangeMin)
                    xmessage = "The Max range for Best Qualified should be greater than Min for Qualified";
                else if (bqRangeMax > ceiling)
                    xmessage = String.Format("The Max range for Best Qualified should be less or equal to {0}", ceiling);

                if (string.IsNullOrEmpty(message.ToString()))
                {
                    message.Append(xmessage);
                }
                else
                {
                    message.Append("<li>" + xmessage + "</li>");
                }
            }


            string smessage = message.ToString();

            return smessage;
        }

        private string AddBeginningListTagToString(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                return "<li>";
            }
            else
            {
                return string.Empty;
            }
        }

        private string AddEndingListTagToString(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                return "</li>";
            }
            else
            {
                return string.Empty;
            }
        }

        private void SaveCategoryRatingGroups()
        {
            try
            {
                CategoryRatingGroup bestQuilifiedGroup = CategoryRatingGroupManager.GetBestQuilifiedGroup(CurrentCRID);
                bestQuilifiedGroup.ScoringRangeGroupTypeName = rtbBQGroupTypeName.Text.Trim();
                bestQuilifiedGroup.RangeMin = Int32.Parse(rtbBQRangeMin.Text);
                bestQuilifiedGroup.RangeMax = Int32.Parse(rtbBQRangeMax.Text);
                bestQuilifiedGroup.QualifyingStatements = rtbBQQualifyingStatements.Text.Trim();
                CategoryRatingGroupManager.Update(bestQuilifiedGroup, base.CurrentUserID);

                CategoryRatingGroup wellQuilifiedGroup = CategoryRatingGroupManager.GetWellQuilifiedGroup(CurrentCRID);
                if (wellQuilifiedGroup != null)
                {
                    wellQuilifiedGroup.ScoringRangeGroupTypeName = rtbWQGroupTypeName.Text.Trim();
                    wellQuilifiedGroup.RangeMin = Int32.Parse(rtbWQRangeMin.Text);
                    wellQuilifiedGroup.RangeMax = Int32.Parse(rtbWQRangeMax.Text);
                    wellQuilifiedGroup.QualifyingStatements = rtbWQQualifyingStatements.Text.Trim();
                    CategoryRatingGroupManager.Update(wellQuilifiedGroup, base.CurrentUserID);
                }

                CategoryRatingGroup quilifiedGroup = CategoryRatingGroupManager.GetQuilifiedGroup(CurrentCRID);
                quilifiedGroup.ScoringRangeGroupTypeName = rtbQGroupTypeName.Text.Trim();
                quilifiedGroup.RangeMin = Int32.Parse(rtbQRangeMin.Text);
                quilifiedGroup.RangeMax = Int32.Parse(rtbQRangeMax.Text);
                quilifiedGroup.QualifyingStatements = rtbQQualifyingStatements.Text.Trim();
                CategoryRatingGroupManager.Update(quilifiedGroup, base.CurrentUserID);
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }

        #region [ Properties ]

        private bool _confirmDelete = false;

        private bool HasWellQuilifiedGroup
        {
            get
            {
                return CategoryRatingGroupManager.GetWellQuilifiedGroup(CurrentCRID) != null;
            }
        }
        #endregion

        protected void btnConfirmDelete_OK_Click(object sender, EventArgs e)
        {
            rwConfirmBeforeDelete.VisibleOnPageLoad = false;

            try
            {
                CategoryRatingManager.DeleteCategoryRating(CurrentCRID, CurrentUserID);

                // MD 8/1: Stay on same page after delete
                //string url = Page.ResolveUrl("~/Package/JNPTracker.aspx");
                //GoToLink(url, CurrentNavMode);

                ReloadCurrentJNP(CurrentJNPID);

                base.GoToLink("~/JQ/FinalJQ.aspx", enumNavigationMode.Edit);
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }

        }

        protected void btnConfirmDelete_Cancel_Click(object sender, EventArgs e)
        {
            rwConfirmBeforeDelete.VisibleOnPageLoad = false;

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Only show the alert if DEU, otherwise just delete the CR
            if (CurrentJNP.IsDEU)
            {
                rwConfirmBeforeDelete.VisibleOnPageLoad = true;
            }
            else
            {
                btnConfirmDelete_OK_Click(sender, e);
            }

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            var url = Page.ResolveUrl("~/Approval/Approval.aspx");
            GoToLink(url, CurrentNavMode);

        }
    }

    /*
     * Dev task #120
     * Modify ctrlCategoryRating -- add Delete button and optional CR message
     * 
     * - See the tab called CR Options in the JAnP Workflow Options spreadsheet for the rules around when delete button should be visible and what should it do? 
     * - Y:\HCMS Pilot\Job Assessment\Design Specifications\Design Doc\New System Enhancements 
     * 
     * - 6.13.13 
     * 1. If a CR exists (because the package is DEU and is required or because the package is MP / Excepted and the user has opted to create a 
     * Category Rating), users will have the ability to delete (inactivate) the Category Rating from this screen. If the package was DEU, deletion (inactivation)
     * of CR will de-select the Recruitment Option as DEU (in Draft, Review and Revise status only). Since this is a required field, the user will have to select
     * a new Recruitment Option on the Position Info screen, before submitting the package to the next status. They can also delete the Category Rating if they
     * generated it for an MP position, doing so will not change the Recruitment Option (or show the user a validation message of any sort), it will simply hide 
     * and inactivate the CR so it is no longer visible (or generated as a PDF from on the Search screen). For an MP / Excepted package the user can delete the CR 
     * through Revise status (not in Final Review). The Category Rating will display the Final KSAs from the JA. 
     * 
     * If the user selects to Delete the CR, a message should pop-up saying “Are you sure you want to delete this Category Rating? Doing so will require you to 
     * update the Recruitment Option of this package on the Position Information screen). Select OK to delete this document or Cancel to continue editing the 
     * Category Rating.” (If user selects OK, DEU is unchecked and CR is inactivated. If user clicks cancel, package remains DEU and CR remains active. 
    
     
     */

}