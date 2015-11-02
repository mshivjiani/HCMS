using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Collections.Generic;

using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.Business.Security;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.BasePages;
using System.Configuration;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.PDExpress.Controls.CreatePD.Approvals
{
    public partial class Approvals : CreatePDUserControlBase
    {
        #region Page Events

        protected override void OnInit(EventArgs e)
        {
            //this.Load += new EventHandler(Page_Load);
            this.buttonSubmitNextStatus.Click += new EventHandler(buttonSubmitNextStatus_Click);
            this.btnSupervisorSign.Click += new EventHandler(btnSupervisorSign_Click);

            this.btnClassifierSign.Click += new EventHandler(btnClassifierSign_Click);
            this.btnHCOSign.Click += new EventHandler(btnHCOSign_Click);
            this.btnHigherApprovalSave.Click += new EventHandler(btnHigherApprovalSave_Click);
            this.btnCheckPublish.Click += new EventHandler(btnCheckPublish_Click);
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setupPage();
            }
        }

        private void setupPage()
        {
            setCertificationMessages();
            setPageAppropriateView();
            setSignedDetail();
            //commenting this as HCO signature is no longer required through PDExpress

            //setHCOSignDetail();
        }

        private void setCertificationMessages()
        {
            litSupText.Text = supervisoryCertification;
            litClassifierText.Text = classifierCertification;
        }

        private bool IsPDReviewed()
        {
            bool returnValue = false;
            bool areDutiesReviewed = false;
            bool isOccupationReviewed = false;
            bool areFactorRecommendationsReviewed = CurrentPD.ArePositionFactorRecommendationsReviewed();

            // no changes to PD occupation and no changes to PD duties  and no factor recommendations to be reviewed
            if ((!CurrentPD.HasOccupationChangedDuringReview(true))
                             && (!CurrentPD.HasDutyDifferences(true))
                             && (CurrentPD.ArePositionFactorRecommendationsReviewed()))
            { returnValue = true; }
            else
            {
                if (base.isCLFullPerformancePD)
                {
                    PositionDescriptionCollection otherCLPDs = base.CurrentPD.GetOtherCareerLadderPositionDescriptions();
                    //checking for ladder positions as well
                    //if any of the ladder has occupation changes then this will return true
                    //if there are no occupation changes to bundled pds then
                    //this will return false indicating no changes to bundle
                    if (!CurrentPD.HasOccupationChangedDuringReview(true))
                    {
                        isOccupationReviewed = true;
                    }
                    else
                    {
                        isOccupationReviewed = base.CurrentPD.IsOccupationReviewComplete;
                        foreach (PositionDescription item in otherCLPDs)
                        {

                            isOccupationReviewed = isOccupationReviewed && item.IsOccupationReviewComplete;
                        }
                    }

                    if (!CurrentPD.HasDutyDifferences(true))
                    { areDutiesReviewed = true; }
                    else
                    {
                        areDutiesReviewed = base.CurrentPD.ArePositionDutiesReviewed;
                        foreach (PositionDescription item in otherCLPDs)
                        {
                            areDutiesReviewed = areDutiesReviewed && item.ArePositionDutiesReviewed;
                        }
                    }
                }

                else
                {
                    if (!CurrentPD.HasOccupationChangedDuringReview(false))
                    { isOccupationReviewed = true; }
                    else
                    {
                        isOccupationReviewed = base.CurrentPD.IsOccupationReviewComplete;
                    }
                    if (!CurrentPD.HasDutyDifferences(false))
                    {
                        areDutiesReviewed = true;
                    }
                    else
                    {
                        areDutiesReviewed = base.CurrentPD.ArePositionDutiesReviewed;
                    }
                }

                returnValue = ((isOccupationReviewed) && (areDutiesReviewed) && (areFactorRecommendationsReviewed));

            }
            return returnValue;
        }

        private void setPageAppropriateView()
        {
            try
            {
                bool okToUse = !base.IsPDReadOnly;

                PDStatus status = base.CurrentPD.GetCurrentPDStatus();

                enumNextAct nextaction = GetNextAction();

                if (base.IsPDReadOnly && status == PDStatus.Published)
                {

                    tblSupApprovals.Visible = !base.IsStandardPD;
                    tblClasifierApprovals.Visible = true;
                    this.trOrgTitle.Visible = false;
                    this.trSignAs.Visible = false;
                    this.trSupPwd.Visible = false;
                    this.trClassOrgTitle.Visible = false;
                    this.trClassSignAs.Visible = false;
                    this.trClassPwd.Visible = false;
                    this.trHighGradeReview.Visible = false;
                    this.tblmsg.Visible = false;
                    divSubmitAction.Visible = false;
                    tblHCOApproval.Visible = false;
                }
                else
                {
                    if (status == PDStatus.Draft || status == PDStatus.Revise)
                    {
                        tblmsg.Visible = true;
                        tblHCOApproval.Visible = false;
                        this.litwarning.Visible = (hasHMGroupPermission);
                        if (hasHMGroupPermission)
                        {

                            this.litwarning.Visible = true;
                            this.lblSupSignWarning.Visible = false;
                            tblSupApprovals.Visible = true;
                        }
                        else // no HM Group Permission
                        {

                            if (base.IsStandardPD)
                            {
                                tblmsg.Visible = false;
                            }
                            else
                            {

                               

                                //JA issued id: 718 : HR should not be seeing this message -- it is only for PD Developers
                                if (base.HasHRGroupPermission) 
                                {
                                    this.tblmsg.Visible = false;
                                }
                                else
                                {   this.litwarning.Visible = false;
                                    this.lblSupSignWarning.Visible = true;
                                }
                            }
                            tblSupApprovals.Visible = false;

                        }
                    }
                    else // Review/Final Review
                    {
                        tblmsg.Visible = false;
                        tblSupApprovals.Visible = false;

                    }



                    if (base.IsHighGradeApprovalRequired)
                    {
                        this.trHighGradeReview.Visible = true;
                        btnHigherApprovalSave.Enabled = okToUse && base.HasPermission(enumPermission.CompleteHighGradeApproval);
                        chkHigherGradeApproval.Enabled = okToUse && base.HasPermission(enumPermission.CompleteHighGradeApproval);
                    }
                    else
                    {
                        this.trHighGradeReview.Visible = false;
                    }

                    if (base.CurrentPD.ProposedGrade == 15)
                        btnClassifierSign.Enabled = okToUse && base.HasPermission(enumPermission.CompleteHRCertification15);
                    else
                        btnClassifierSign.Enabled = okToUse && (base.HasPermission(enumPermission.CompleteHRCertification)||(base.HasPermission (enumPermission.CompleteJNPCertification)));
                    //disable sign as classfier option if you are not a classifier ( evaluator/staffing manager/staffing specialist - should not be able to sign as classifier)
                    if ((isEvaluator)||(isStaffingManager)||(isStaffingSpecialist))
                        rblClassSignAs.Items[1].Enabled = false;

                    bool showNextStatusButton = false;
                    bool showCheckPublishButton = false;
                    if (okToUse && (base.HasPermission(enumPermission.PublishPD)))
                    {
                        if (status == PDStatus.Review)
                        {
                            if (IsPDReviewed())
                            {
                                //to tackle the issue where PD is highgrade PD and highgrade approval is missing
                                //but user does not have high grade permission then
                                //user can not publish the PD  -- then in this case there is no point displaying Check and publish button
                                if (base.IsHighGradeApprovalRequired)
                                {
                                    if (CurrentPD.HighGradeApproval)
                                    {
                                        showCheckPublishButton = true;
                                    }
                                    else
                                    {
                                        if (base.HasPermission(enumPermission.CompleteHighGradeApproval))
                                        {
                                            showCheckPublishButton = true;
                                        }
                                    }
                                }
                                else
                                {
                                    showCheckPublishButton = true;
                                }
                            }
                        }
                        else //final review
                        {
                            if (status == PDStatus.FinalReview)
                            {
                                if (base.IsHighGradeApprovalRequired)
                                {
                                    if (CurrentPD.HighGradeApproval)
                                    {
                                        showCheckPublishButton = true;
                                    }
                                    else
                                    {
                                        if (base.HasPermission(enumPermission.CompleteHighGradeApproval))
                                        {
                                            showCheckPublishButton = true;
                                        }
                                    }
                                }
                                else
                                {
                                    showCheckPublishButton = true;
                                }
                            }

                        }
                    }

                    // set button<NextStatus> text and permissions
                    switch (status)
                    {
                        case PDStatus.Draft:
                            if (nextaction == enumNextAct.SaveandUnlock)
                            {
                                buttonSubmitNextStatus.Text = "Save and Unlock";

                            }
                            else
                            {
                                buttonSubmitNextStatus.Text = "Submit for Review";
                            }
                            showNextStatusButton = hasHMGroupPermission || hasHRGroupPermission;
                            break;
                        case PDStatus.Review:
                            //not checking the value of nextaction as
                            //in review, it should always allow to submit for Revise
                           
                            buttonSubmitNextStatus.Text = "Submit for Revise";                         

                            showNextStatusButton = hasHRGroupPermission;
                            break;
                        case PDStatus.Revise:
                            if (nextaction == enumNextAct.SaveandUnlock)
                            {
                                buttonSubmitNextStatus.Text = "Save and Unlock";
                            }
                            else
                            {
                                buttonSubmitNextStatus.Text = "Submit for Final Review";
                            }
                            showNextStatusButton = hasHMGroupPermission || hasHRGroupPermission;
                            break;
                        case PDStatus.FinalReview:

                            if (nextaction == enumNextAct.SaveandUnlock)
                            {
                                buttonSubmitNextStatus.Text = "Save and Unlock";
                                this.btnCheckPublish.Enabled = false;
                                showNextStatusButton = hasHRGroupPermission;
                            }
                            else
                            {
                                showNextStatusButton = false;
                            }
                            break;
                        default:
                            showNextStatusButton = false;
                            break;
                    }

                    //added this check because if staffing manager/specialist logs in and sends the PD to revise
                    //pd is sent to revise and checked in -- nextaction is evaluated as save and  unlock but there is nothing to save and unlock because
                    //pd is already saved and unlocked.
                    //by putting this check we are redirecting user to tracker --if the PD is checked in
                    if (CurrentPD.IsCheckedOut)
                    {
                        buttonSubmitNextStatus.Visible = showNextStatusButton;
                        btnCheckPublish.Visible = showCheckPublishButton;

                        // only show the panel if the button<NextStatus> or buttonCheckAndPublish are visible
                        divSubmitAction.Visible = showNextStatusButton || showCheckPublishButton;
                    }
                    else //PD is checked in
                    {
                        nextaction = GetNextAction();
                        if (nextaction == enumNextAct.SaveandUnlock)
                        {
                            string redirectUrl = ConfigurationManager.AppSettings["PDExpressDefaultURL"].ToString();
                            base.SafeRedirect(redirectUrl);
                        }
                        else
                        {
                            if ((base.IsAdmin) || (base.HasHRGroupPermission))
                            {
                                //don't show action panel for hr group in revise
                                if ((status == PDStatus.Revise) && (!base.IsAdmin))
                                {
                                    divSubmitAction.Visible = false;

                                }

                                else //if admin show the action panel
                                {
                                    //JA issue id 885 -- PD Stuck in Review and no option to move revise or check and publish
                                    //admin and Classifiers should be able to move the PD to next status -- because if the action is save and continue
                                    buttonSubmitNextStatus.Visible = showNextStatusButton;
                                    btnCheckPublish.Visible = showCheckPublishButton;

                                    // only show the panel if the button<NextStatus> or buttonCheckAndPublish are visible
                                    divSubmitAction.Visible = showNextStatusButton || showCheckPublishButton;
                                }
                            }

                            else //non admin/non HR -- PD is checked in -- don't show action panel
                            {
                                divSubmitAction.Visible = false;
                            }
                         
                        }
                    }
                    //JA issue 864 : Staffing Manager/Staffing Specialist should be able to sign as evaluator
                    if (okToUse && (status == PDStatus.Review || status == PDStatus.FinalReview) && (base.HasPermission(enumPermission.CompleteHRCertification)||base.HasPermission(enumPermission.CompleteJNPCertification)))
                    {
                        tblClasifierApprovals.Visible = true;

                        if (this.trHighGradeReview.Visible)
                        {
                            chkHigherGradeApproval.Checked = CurrentPD.HighGradeApproval;

                        }
                    }
                    else
                    {
                        tblClasifierApprovals.Visible = false;
                    }

                    divFastrackMessage.Visible = (status == PDStatus.Review) && showCheckPublishButton;
                    panelMessage.Visible = false;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void setSignedDetail()
        {
            bool showDualsignMsg = false;
            bool showHighGradeApprMsg = false;
            PDStatus status = base.CurrentPD.GetCurrentPDStatus();
            this.tblSignDetail.Visible = false;

            if (base.IsDualSignRequired && (CurrentPD.SupervisorID == -1 || CurrentPD.AdditionalSupervisorID == -1))
            {
                showDualsignMsg = true;

            }
            if ((status == PDStatus.Review || status == PDStatus.FinalReview) && (base.IsHighGradeApprovalRequired && (!CurrentPD.HighGradeApproval)))
            {
                showHighGradeApprMsg = true;
            }

            if ((base.IsStandardPD) && (status == PDStatus.Draft || status == PDStatus.Revise))
            {
                tblSignDetail.Visible = true;
                lblStandardPDMsg.Visible = true;
            }
            if ((base.CurrentPD.SupervisorID != -1))
            {
                tblSignDetail.Visible = true;
                if (showDualsignMsg)
                {

                    if (base.CurrentPD.SupervisorSignDate != DateTime.MinValue)
                    {
                        this.lblSignedSup.Text = string.Format("Signed By Supervisor: {0} on {1}<br/> This Position Description requires two supervisory signatures. Save and Unlock this position description and email Supervisor for approval.", base.CurrentPD.SupervisorFullName, base.CurrentPD.SupervisorSignDate.ToShortDateString());
                    }
                    else
                    {
                        this.lblSignedSup.Text = string.Format("Signed By Supervisor: {0}<br/> This Position Description requires two supervisory signatures. Save and Unlock this position description and email Supervisor for approval.", base.CurrentPD.SupervisorFullName);

                    }
                }
                else
                {

                    if (base.CurrentPD.SupervisorSignDate != DateTime.MinValue)
                    {

                        this.lblSignedSup.Text = string.Format("Signed By Supervisor: {0} on {1}", base.CurrentPD.SupervisorFullName, base.CurrentPD.SupervisorSignDate.ToShortDateString());
                    }
                    else
                    {
                        this.lblSignedSup.Text = string.Format("Signed By Supervisor: {0}", base.CurrentPD.SupervisorFullName);

                    }
                }

            }

            if ((base.CurrentPD.AdditionalSupervisorID != -1))
            {
                tblSignDetail.Visible = true;
                if (showDualsignMsg)
                {
                    if (base.CurrentPD.AdditionalSupervisorSignDate != DateTime.MinValue)
                    {
                        this.lblAdditionalSignedSup.Text = string.Format("Signed By Approving Official: {0} on {1}<br/> This Position Description requires two supervisory signatures. Save and Unlock this position description and email Supervisor for approval.", base.CurrentPD.AdditionalSupervisorFullName, base.CurrentPD.AdditionalSupervisorSignDate.ToShortDateString());
                    }
                    else
                    {
                        this.lblAdditionalSignedSup.Text = string.Format("Signed By Approving Official: {0}<br/> This Position Description requires two supervisory signatures. Save and Unlock this position description and email Supervisor for approval.", base.CurrentPD.AdditionalSupervisorFullName);

                    }
                }
                else
                {
                    if (base.CurrentPD.AdditionalSupervisorSignDate != DateTime.MinValue)
                    {
                        this.lblAdditionalSignedSup.Text = string.Format("Signed By Approving Official: {0} on {1}", base.CurrentPD.AdditionalSupervisorFullName, base.CurrentPD.AdditionalSupervisorSignDate.ToShortDateString());
                    }
                    else
                    {
                        this.lblAdditionalSignedSup.Text = string.Format("Signed By Approving Official: {0}", base.CurrentPD.AdditionalSupervisorFullName);

                    }

                }

            }

            if (base.CurrentPD.EvaluatorID != -1)
            {
                tblSignDetail.Visible = true;
                if (CurrentPD.EvaluatorSignDate != DateTime.MinValue)
                {
                    this.lblsignedEvalauator.Text = string.Format("Signed By Evaluator: {0} on {1}", base.CurrentPD.EvaluatorFullName, base.CurrentPD.EvaluatorSignDate.ToShortDateString());
                }
                else
                {
                    this.lblsignedEvalauator.Text = string.Format("Signed By Evaluator: {0}", base.CurrentPD.EvaluatorFullName);

                }
            }

            if (base.CurrentPD.ClassifierID != -1)
            {
                tblSignDetail.Visible = true;
                if (CurrentPD.ClassifierSignDate != DateTime.MinValue)
                {
                    this.lblsignedClassifier.Text = string.Format("Signed By Classifier: {0} on {1}", base.CurrentPD.ClassifierFullName, base.CurrentPD.ClassifierSignDate.ToShortDateString());
                }
                else
                {
                    this.lblsignedClassifier.Text = string.Format("Signed By Classifier: {0}", base.CurrentPD.ClassifierFullName);

                }
            }
            this.lblHighGradeApprWarning.Visible = showHighGradeApprMsg;
        }

        private void setHCOSignDetail()
        {
            PDStatus status = base.CurrentPD.GetCurrentPDStatus();
            tblHCOApproval.Visible = false;


            if (CurrentPD.HCOID > 0)
            {
                lblsignedHCO.Text = string.Format("Signed by Human Capital Officer: {0} on {1}", base.CurrentPD.HCOFullName, base.CurrentPD.HCOSignDate.ToShortDateString());
                this.lblHCOSignWarning.Visible = false;
            }
            else
            {
                if ((!base.IsPDReadOnly) && (status == PDStatus.Review || status == PDStatus.FinalReview))
                {

                    int proposedgrade = base.CurrentPD.ProposedGrade;
                    if (proposedgrade == 14 || proposedgrade == 15)
                    {
                        if (CurrentPD.HighGradeApproval)
                        {
                            this.lblHCOSignWarning.Visible = true;
                            if (base.HasPermission(enumPermission.CompleteHCOCertification) || base.IsSystemAdministrator)
                            {
                                tblHCOApproval.Visible = true;
                            }
                        }


                    }
                }
            }

        }

        private enumNextAct GetNextAction()
        {
            enumNextAct nextaction = enumNextAct.SaveandContinue;
            PDStatus status = base.CurrentPD.GetCurrentPDStatus();
            if (isEvaluator && !hasHMGroupPermission)
            {
                if ((base.IsStandardPD) && (status != PDStatus.FinalReview))
                {
                    nextaction = enumNextAct.SaveandContinue;
                }
                else if (status == PDStatus.Review)
                {
                    nextaction = enumNextAct.SaveandContinue;
                }
                else
                {
                    nextaction = enumNextAct.SaveandUnlock;
                }
            }

            //In Draft/Revise: Checking for Dual signature requirements 
            //                 If Dual Signanture is required and one of the sup signature is missing then action should be "Save and Unlock"
            //In Final Review: Checking for High Grade Review requirements
            //                  If High Grade Review is required and not been done and user does not have permission to perform high grade review
            //                  then action should be "Save and Unlock"



            //Commented if and changed to switch statement for better readability

            //if (((status == PDStatus.Draft || status == PDStatus.Revise)
            //    && (base.IsDualSignRequired && (CurrentPD.SupervisorID == -1 || CurrentPD.AdditionalSupervisorID == -1)))
            //    //deleted the PDStatus.Review because HR was not able to sumit for Revise if they wanted to do so even if it did not
            //    // have highgradeapproval checked 
            //    || (status == PDStatus.FinalReview && base.IsHighGradeApprovalRequired && (!CurrentPD.HighGradeApproval) && (!base.HasPermission(enumPermission.CompleteHighGradeApproval))))
            //{
            //    nextaction = enumNextAct.SaveandUnlock;
            //}


            switch (status)
            {
                case PDStatus.Draft:
                case PDStatus.Revise:
                    if ((base.IsDualSignRequired && (CurrentPD.SupervisorID == -1 || CurrentPD.AdditionalSupervisorID == -1)))
                    {
                        nextaction = enumNextAct.SaveandUnlock;
                    }
                    break;
                case PDStatus.FinalReview:
                    if (base.IsHighGradeApprovalRequired)
                    {
                        if ((!CurrentPD.HighGradeApproval) && (!base.HasPermission(enumPermission.CompleteHighGradeApproval)))
                        {
                            nextaction = enumNextAct.SaveandUnlock;
                        }
                        //commenting this as HCO signature is no longer required through PDExpress
                        //else
                        //{
                        //    if ((CurrentPD.HCOID <= 0) && (!base.HasPermission(enumPermission.CompleteHCOCertification)))
                        //    {
                        //        nextaction = enumNextAct.SaveandUnlock;
                        //    }
                        //}
                    }
                    else
                    {
                        //this was added because if evaluator/staffingmanager/staffing specialist had supervisory permission 
                        //next action was evaluated as save and continue and then in SetPageView that action button was not available because there is nothing to save and continue
                        //at this point and they did not have publish permission.
                        if (isEvaluator || isStaffingManager || isStaffingSpecialist)
                        {
                            nextaction = enumNextAct.SaveandUnlock;
                        }
                    }
                    break;

            }

            return nextaction;

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        #endregion

        #region [ SupCertification ]
        private void btnSupervisorSign_Click(Object sender, EventArgs e)
        {
            try
            {
                ValidationMessage = String.Empty;

                PositionDescription PD = new PositionDescription(base.CurrentPDID);

                SignatureType currentsigntype = (SignatureType)int.Parse(this.rblSupSignType.SelectedValue);
                if (SignPD(txtSupervisorPwd.Text, base.CurrentPDID, currentsigntype, txtSupOrgTitle.Text, supervisoryCertification))
                {
                    base.PrintSystemMessage("Supervisory Certification has been Accepted.", true);
                    txtSupOrgTitle.Text = string.Empty;
                    base.ReloadCurrentPD(base.CurrentPD.PositionDescriptionID);
                    setupPage();
                }
            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex, true);
            }
        }
        #endregion

        #region [ ClassCertification ]

        private void btnClassifierSign_Click(object sender, EventArgs e)
        {
            try
            {
                ValidationMessage = String.Empty;

                SignatureType currentsigntype = (SignatureType)int.Parse(this.rblClassSignAs.SelectedValue);

                if (SignPD(txtClassPwd.Text, base.CurrentPDID, currentsigntype, txtClassOrgTitle.Text, classifierCertification))
                {
                    base.PrintSystemMessage(string.Format("{0} Certification has been Accepted.", currentsigntype.ToString()), true);
                    txtClassOrgTitle.Text = string.Empty;
                    base.ReloadCurrentPD(base.CurrentPD.PositionDescriptionID);
                    setupPage();
                }
            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex, true);
            }
        }

        private void btnHigherApprovalSave_Click(object sender, EventArgs e)
        {

            try
            {
                ValidationMessage = String.Empty;
                PositionDescription PD = base.CurrentPD;
                PD.HighGradeApproval = this.chkHigherGradeApproval.Checked;
                PD.UpdateHighGradeApproval();
                string strmsg = "High Grade Review has been Accepted.";
                base.PrintSystemMessage(strmsg, true);

                base.ReloadCurrentPD(base.CurrentPD.PositionDescriptionID);
                setupPage();

            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex, true);
            }
        }
        private void btnHCOSign_Click(object sender, EventArgs e)
        {
            try
            {
                ValidationMessage = String.Empty;

                SignatureType currentsigntype = SignatureType.HCO;

                if (SignPD(txtHCOPwd.Text, base.CurrentPDID, currentsigntype, txtHCOOrgTitle.Text, string.Empty))
                {
                    base.PrintSystemMessage(string.Format("{0} Certification has been Accepted.", currentsigntype.ToString()), true);

                    base.ReloadCurrentPD(base.CurrentPD.PositionDescriptionID);
                    setupPage();
                }

            }
            catch (Exception ex)
            {

                base.PrintErrorMessage(ex, true);
            }

        }
        private void btnCheckPublish_Click(object sender, EventArgs e)
        {
            try
            {
                ValidationMessage = String.Empty;

                PDStatus nextStatus = base.GetNextPDStatus();
                bool useFastTrack = !(nextStatus == PDStatus.Published);
                bool isCLFPL = false;
                string qrystring = string.Empty;
                if (validateAllPDInformation(true))
                {
                    qrystring = string.Format("PD={0}", base.CurrentPDID);
                    if (base.CurrentPDChoice == PDChoiceType.CareerLadderPD && base.CurrentPD.LadderPosition == 0)
                    {
                        isCLFPL = true;
                        PositionDescriptionCollection ladders = CurrentPD.GetAssociatedCareerLadderPositionDescriptions();
                        ladders.Reverse(); //to print the ladder numbers in order
                        foreach (PositionDescription current in ladders)
                        {
                            qrystring = string.Format("{0}&PD={1}", qrystring, current.PositionDescriptionID.ToString());
                        }
                    }
                    base.CurrentPD.Publish(base.CurrentUser.UserID, useFastTrack);
                    base.ClearCurrentPD();
                    Response.Redirect(string.Format("~/CreatePD/Published.aspx?{0}", qrystring));
                }
            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex, true);

            }
        }

        #endregion

        private string getCareerLadderErrors(ref bool hasCareerLadderErrors)
        {
            StringBuilder finalError = new StringBuilder();
            bool foundError = false;

            try
            {
                PositionDescriptionCollection ladders = base.CurrentPD.GetAssociatedCareerLadderPositionDescriptions();

                foreach (PositionDescription current in ladders)
                {
                    // validate each PD and get a high-level count of each
                    PDValidationErrorCollection errorList = current.GetValidationErrors(false, false);
                    int totalErrors = errorList.Count;
                    string errorMessage = "No Errors";

                    if (totalErrors > 0)
                        foundError = true;

                    if (totalErrors == 1)
                        errorMessage = "1 Total Error";
                    else if (totalErrors > 1)
                        errorMessage = string.Concat(totalErrors, " Total Errors");

                    finalError.Append(string.Format("{0}: {1} -- {2}<br />", current.PositionDescriptionID, current.AgencyPositionTitle, errorMessage));
                }
                hasCareerLadderErrors = foundError;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            return finalError.ToString();
        }

        private bool validateAllPDInformation(bool fastTrack)
        {
            bool validatesOK = false;

            try
            {
                string thisPDErrors = CurrentPD.Validate(fastTrack, false).Trim();   // get errors for the current PD
                string validationErrors = string.Empty;
                bool hasCareerLadderErrors = false;

                if (base.CurrentPDChoice == PDChoiceType.CareerLadderPD && base.CurrentPD.LadderPosition == 0)
                {
                    // check to make sure that the current PD is the full performance PD
                    string careerLadderErrors = getCareerLadderErrors(ref hasCareerLadderErrors);
                    if (hasCareerLadderErrors)
                    {
                        string ladderErrorTitle = "Career Ladder Errors -- Be sure to validate each position description to fix any errors listed below.<br /><br />";
                        validationErrors = string.Format("{0}<div><hr class=\"separator\" /></div>{1}{2}", thisPDErrors.Length.Equals(0) ? "There are no errors within the full performance PD.<br />" : thisPDErrors, ladderErrorTitle, careerLadderErrors);
                    }
                    else
                    {
                        validationErrors = thisPDErrors;
                    }
                }
                else
                {
                    validationErrors = thisPDErrors;
                }

                if (validationErrors.Length == 0)
                {
                    validatesOK = true;
                    ValidationMessage = String.Empty;
                }
                else
                {
                    //base.PrintMessage(validationErrors, true, true);
                    ValidationMessage = validationErrors;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            return validatesOK;
        }

        private void buttonSubmitNextStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    ValidationMessage = String.Empty;

                    PDStatus status = base.CurrentPD.GetCurrentPDStatus();
                    enumNextAct nextaction = enumNextAct.SaveandContinue;
                    string statusUpdateMessage = string.Empty;
                    bool isCLFPL = false;
                    //if (status == PDStatus.Draft || status == PDStatus.Revise )
                    //{

                    nextaction = GetNextAction();

                    //}
                    if (nextaction == enumNextAct.SaveandUnlock)
                    {
                        CurrentPD.CheckIn(base.CurrentUser.UserID);
                        string redirectUrl = ConfigurationManager.AppSettings["PDExpressDefaultURL"].ToString();
                        base.SafeRedirect(redirectUrl);

                    }
                    else
                    {
                        if (validateAllPDInformation(false))
                        {
                            PDStatus nextStatus = base.GetNextPDStatus();


                            base.CurrentPD.SetPositionCurrentStatus(nextStatus, base.CurrentUser.UserID, true);
                            base.ReloadCurrentPD(base.CurrentPDID);
                            setupPage();
                            string strCLPDs = string.Empty;
                            if ((CurrentPD.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD) && (base.CurrentPD.LadderPosition == 0))
                            {
                                isCLFPL = true;
                                strCLPDs = string.Format("Position Descriptions: {0}", base.CurrentPDID);

                                PositionDescriptionCollection ladders = CurrentPD.GetAssociatedCareerLadderPositionDescriptions();
                                ladders.Reverse();
                                foreach (PositionDescription current in ladders)
                                {
                                    strCLPDs = string.Format("{0},{1}", strCLPDs, current.PositionDescriptionID.ToString());
                                }
                            }

                            string strPDNumber = string.Empty;
                            if (isCLFPL)
                            {
                                strPDNumber = string.Format("{0} have been sent to ", strCLPDs);
                            }
                            else
                            {
                                strPDNumber = string.Format("Position Description: {0} has been sent to ", base.CurrentPDID);
                            }
                            if (nextStatus == PDStatus.Review)

                                statusUpdateMessage = string.Format("{0} HR for Review.", strPDNumber);
                            else if (nextStatus == PDStatus.Revise)
                                statusUpdateMessage = string.Format("{0} PD Creator to Revise.", strPDNumber);
                            else if (nextStatus == PDStatus.FinalReview)
                                statusUpdateMessage = string.Format("{0} HR for Final Review.", strPDNumber);

                            base.PrintSystemMessage(statusUpdateMessage, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex, true);
            }
        }

        #region Private Methods

        private bool IsValidSignature(string username, string pwd)
        {
            bool isvalidSign = false;
            //if (ConfigWrapper.JumpLogin)
            //{ 
            //    isvalidSign = true;
            //}
            //else
            //{
                isvalidSign = Membership.ValidateUser(username, pwd);
            //}
            return isvalidSign;

        }

        private bool SignPD(string pwd, long pdid, SignatureType signtype, string signedbyOrgTitle, string certification)
        {
            bool signatureOK = false;

            try
            {
                User thisUser = base.CurrentUser;
                PositionDescription PD = new PositionDescription(pdid);


                if (IsValidSignature(thisUser.MappedUserName, pwd))
                {
                    PD.Sign(thisUser.UserID, thisUser.FullName, signtype, signedbyOrgTitle, certification);
                    // base.PrintSystemMessage("Position Description signed successfully.", true);
                    this.litmsg.Text = "Position Description signed successfully.";
                    signatureOK = true;
                }
                else
                {
                    base.PrintErrorMessage("Signature not valid. Please provide your valid password.", true);
                }

            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex.Message, true);
            }

            return signatureOK;
        }

        //private bool IsPDValid()
        //{
        //    string validationerrors = string.Empty;
        //    validationerrors = CurrentPD.Validate();
        //    if (validationerrors.Length == 0)
        //    { return true; }
        //    else
        //    {
        //        base.PrintMessage(validationerrors, true, true);
        //        return false;
        //    }
        //}

        private void PrintReqFieldMessage()
        {
            MasterPage master = this.Page.Master;
            if (master != null)
            {

                ((MasterPageBase)master).ShowRequiredFieldMessage = true;
            }
        }

        #endregion

        #region [ Private Properties ]
        public bool isPDCreator
        {
            get
            {
                bool returnVal = base.CurrentPD.PDCreatorID.Equals(base.CurrentUser.UserID);
                return returnVal;
            }
        }
        public bool isPDCreatorSup
        {
            get
            {
                bool returnVal = base.isPDCreatorSupervisor(false);
                return returnVal;
            }
        }

        public bool hasCompleteSupervisorCert
        {
            get
            {
                bool returnVal = base.HasPermission(enumPermission.CompleteSupervisoryCertification);
                return returnVal;
            }
        }
        public bool hasPublishPermission
        {
            get
            {
                bool returnVal = base.HasPermission(enumPermission.PublishPD);
                return returnVal;
            }
        }

        public bool hasHMGroupPermission
        {
            get
            {
                //(!base.IsPDReadOnly) && 
                bool returnVal = (((isPDCreator && hasCompleteSupervisorCert) || isPDCreatorSup));
                return returnVal;
            }
        }
        public bool hasHRGroupPermission
        {
            get
            {//(!base.IsPDReadOnly) && 
                bool returnVal = ((base.HasPermission(enumPermission.CompleteHRCertification) || base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
                    base.HasPermission(enumPermission.MaintainHRSection) || base.HasPermission(enumPermission.MaintainFactorRecommendation) ||
                    hasPublishPermission));
                return returnVal;
            }

        }

        public bool isEvaluator
        {
            get
            {
                bool returnVal = hasHRGroupPermission && (!base.HasPermission(enumPermission.PublishPD));
                return returnVal;
            }
        }

        public bool isStaffingManager
        {
            get
            {
                bool returnVal = hasHRGroupPermission && (!base.HasPermission(enumPermission.PublishPD));
                return returnVal;
            }
        }

        public bool isStaffingSpecialist
        {
            get
            {
                bool returnVal = hasHRGroupPermission && (!base.HasPermission(enumPermission.PublishPD));
                return returnVal;
            }
        }
        private string ValidationMessage
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    lblValidationMessage.Text = String.Empty;
                    pnlValidationMessage.Visible = false;
                }
                else
                {
                    lblValidationMessage.Text = value;
                    pnlValidationMessage.Visible = true;
                }
            }
        }
        #endregion

        #region [ Private Members ]
        private const string supervisoryCertification = "I certify that this is an accurate statement of the major duties and responsibilities of this position and its organizational relationships, and that the position is necessary to carry out Government functions for which I am responsible. This certification is made with the knowledge that this information is to be used for statutory purpose relating to appointment and payment of public funds, and that false or misleading statements may constitute violations of such statutes or their implementing regulations.";
        private const string classifierCertification = "I certify that this position has been classified / graded as required by Title 5, U.S. Code, in conformance with standards published by the U.S. Office of Personnel Management or, if no published standards apply directly, consistently with the most applicable published standards.";
        #endregion

    }
}
