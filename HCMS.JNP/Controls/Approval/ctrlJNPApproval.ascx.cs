using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Collections.Generic;

using HCMS.Business.Security;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.BasePages;
using HCMS.Business.JNP;
using HCMS.Business.PD;
using HCMS.WebFramework.Site.Utilities;
using JNPReports = HCMS.JNP.Reports;

namespace HCMS.JNP.Controls.Approval
{
    public partial class ctrlJNPApproval : JNPUserControlBase
    {
        private JNPApprovalManager approvalMgr = new JNPApprovalManager();
        private WorkflowObject workflowobj;

        private JNPApproval JNPApprovalEntity
        {
            get
            {

                if (ViewState["JNPApprovalEntity"] == null)
                {

                    ViewState["JNPApprovalEntity"] = new JNPApproval();

                }
                return (JNPApproval)ViewState["JNPApprovalEntity"];

            }
            set
            {
                ViewState["JNPApprovalEntity"] = value;
            }
        }

        #region Page Events

        protected override void OnInit(EventArgs e)
        {
            this.btnSupervisorSign.Click += new EventHandler(btnSupervisorSign_Click);
            base.OnInit(e);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                setupPage();
            }
        }

        private void setupPage()
        {
            //Making the approval info visible for published jnp
            bool isInViewMode = (base.CurrentNavMode == enumNavigationMode.View);

            if (base.CurrentJNPWS == enumJNPWorkflowStatus.Published)
            {
                LoadApprovalData();
                SetWorkflowActions();
                setCertificationMessages();
                setPageAppropriateView();
                setSignedDetail();
            }
            else
            {

                LoadApprovalData();
                ReloadCurrentJNP(this.CurrentJNPID);
                SetWorkflowActions();
                setCertificationMessages();
                setPageAppropriateView();
                setSignedDetail();

            }

            if (isInViewMode)
            {
                btnSupervisorSign.Enabled = false;
            }

        }

        private void LoadApprovalData()
        {

            this.CurrentApprovalObjectType = enumStaffingObjectType.JNP;
            
            this.JNPApprovalEntity = approvalMgr.GetJNPApprovalByStaffingObjectID(CurrentJNPID , this.CurrentApprovalObjectType);

        }

        private void SetWorkflowActions()
        {
            workflowobj = new WorkflowObject();
            workflowobj.StaffingObjectTypeID = enumStaffingObjectType.JNP;
            workflowobj.StaffingObjectID = this.CurrentJNPID;
            workflowobj.ParentObjectID = this.CurrentJNPID;
            workflowobj.ParentObjetTypeID = enumStaffingObjectType.JNP;
            workflowobj.UserID = CurrentUserID;
            ctrlworkflowManager.CurrentWorkflowObject = workflowobj;
            ctrlworkflowManager.BindActions();
        }

        private void setCertificationMessages()
        {
            litSupText.Text = supervisoryCertification;
        }

        private void setPageAppropriateView()
        {

            bool isThisLastScreen = (base.LastScreen() == enumLastScreen.Approval);
            bool isJNPPublished = CurrentJNP.IsPublished();

            btnSupervisorSign.Enabled = false;
            rblSupSignType.Items[0].Enabled = false;
            rblSupSignType.Items[1].Enabled = false;
            btnSupervisorSign.Enabled = false;
            spanWorkflowManager.Visible = isThisLastScreen && !isJNPPublished;

            tblSupApprovals.Visible = false;
            tblMessageBeforSigning.Visible = true;

            if (CurrentJNPWS == enumJNPWorkflowStatus.Revise)
            {
                //JA issue: 965: Signature Right for SysAdms is factoring in SupStatus Code in JAX for HM role/sign even though it shouldn't 
                //System admin should be able to sign as supervisor regardless of their supervisory status code
                if (base.IsOrgCodeSupervisor(CurrentJNP.OrganizationCodeID)||base.IsSystemAdministrator )
                {
                    if (this.JNPApprovalEntity.SupervisorID <= 0)
                    {

                        if (base.CurrentNavMode == enumNavigationMode.View)
                        {
                            lblMessageBeforSigning.Text = "Please notify Supervisor that this Job Announcement is ready for their review and signature.";
                        }
                        else
                        {
                            rblSupSignType.Items[0].Enabled = true;
                            rblSupSignType.Items[0].Selected = true;
                            btnSupervisorSign.Enabled = true;
                            tblSupApprovals.Visible = true;
                            spanWorkflowManager.Visible = true;
                        }
                    }
                    else
                    {
                        if (base.CurrentNavMode == enumNavigationMode.View)
                        {
                            spanWorkflowManager.Visible = false;
                            lblMessageBeforSigning.Text = "Please notify Supervisor that this Job Announcement is ready for their review and signature.";
                        }
                        else
                        {
                            tblSupApprovals.Visible = true;
                            spanWorkflowManager.Visible = true;
                        }
                    }
                }
                else
                {
                    if (this.JNPApprovalEntity.SupervisorID <= 0)
                    {
                        if (base.CurrentNavMode == enumNavigationMode.View)
                        {
                            spanWorkflowManager.Visible = false;
                            lblMessageBeforSigning.Text = "Please notify Supervisor that this Job Announcement is ready for their review and signature.";
                        }
                        else
                        {
                            lblMessageBeforSigning.Text = "Please unlock this package and notify your Supervisor that this Job Announcement is ready for their review and signature.";
                            spanWorkflowManager.Visible = true;
                        }
                    }

                    if (base.CurrentNavMode == enumNavigationMode.View)
                    {
                        spanWorkflowManager.Visible = false;
                    }

                }
            }


            if ((CurrentJNPWS == enumJNPWorkflowStatus.FinalReview) && (base.CurrentUser.HasPermission(enumPermission.CompleteJNPCertification)))
            {
                if (this.JNPApprovalEntity.HRPersonnelID <= 0)
                {
                    rblSupSignType.Items[1].Enabled = true;
                    rblSupSignType.Items[1].Selected = true;
                    btnSupervisorSign.Enabled = true;
                    spanWorkflowManager.Visible = true;
                    tblSupApprovals.Visible = true;
                }
                else
                {
                    rblSupSignType.Items[0].Enabled = false;
                    rblSupSignType.Items[1].Enabled = false;
                    btnSupervisorSign.Enabled = false;
                    spanWorkflowManager.Visible = isThisLastScreen && !isJNPPublished;

                    tblSupApprovals.Visible = false;

                    //If HM signed and HR signed and status is in Final Review, it is ready to publish.
                    if (this.JNPApprovalEntity.SupervisorID > 0 && this.JNPApprovalEntity.HRPersonnelID > 0) 
                    {
                        lblMessageBeforSigning.Visible = false;
                        tblMessageBeforSigning.Visible = true;
                    }
                    else
                    {
                        lblMessageBeforSigning.Text = "Please unlock this package and notify the Staffing Specialist that this Job Announcement is ready for their review and signature.";
                        tblMessageBeforSigning.Visible = true;
                    }
 
                }
            }

            if (this.JNPApprovalEntity.SupervisorID > 0 && this.JNPApprovalEntity.HRPersonnelID > 0)
            {
                btnSupervisorSign.Enabled = false;                
                txtSupOrgTitle.Enabled = false;
                txtSupervisorPwd.Enabled = false;
                btnSupervisorSign.Enabled = false;
                ctrlworkflowManager.Visible = isThisLastScreen && !isJNPPublished;

                //Make the approval info visible for the published JNP
                if (CurrentJNPWS == enumJNPWorkflowStatus.Published)
                {
                    rblSupSignType.Items[0].Enabled = false;
                    rblSupSignType.Items[0].Selected = false;
                    btnSupervisorSign.Enabled = false;
                    spanWorkflowManager.Visible = false;

                    TableRow trSignAs = FindControl("trSignAs") as TableRow;

                    if (trSignAs != null)
                    {
                        trSignAs.Visible = false;
                    }

                    TableRow trOrgTitle = FindControl("trOrgTitle") as TableRow;

                    if (trOrgTitle != null)
                    {
                        trOrgTitle.Visible = false;
                    }

                    TableRow trSupPwd = FindControl("trSupPwd") as TableRow;
                    if (trSupPwd != null)
                    {
                        trSupPwd.Visible = false;
                    }
                }
            }

            if (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview) 
            {
                if (!(base.CurrentUser.HasPermission(enumPermission.CompleteJNPCertification)))
                {
                    lblMessageBeforSigning.Visible = true;
                    lblMessageBeforSigning.Text = "Please notify the HR that this Job Announcement is ready for signature and publish.";
                }
            }
            if (base.CurrentNavMode == enumNavigationMode.View)
            {
                spanWorkflowManager.Visible = false;
            }

        }

        private void setSignedDetail()
        {
            if (this.JNPApprovalEntity.SupervisorID > 0)
            {
                tblSignDetail.Visible = true;
                lblSignedSup.Text = string.Format("Signed By Supervisor: {0} on {1}<br/>", this.JNPApprovalEntity.SupervisorFullName, this.JNPApprovalEntity.SupervisorSignDate.Value.ToShortDateString());
            }

            if (this.JNPApprovalEntity.HRPersonnelID > 0)
            {
                tblSignDetail.Visible = true;
                lblsignedHR.Text = string.Format("Signed By HR Personnel: {0} on {1}<br/>", this.JNPApprovalEntity.HRPersonnelFullName, this.JNPApprovalEntity.HRPersonnelSignDate.Value.ToShortDateString());
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        #endregion

        #region [ SupCertification ]
        private bool _hasErrors = false;
        private bool HasErrors
        {
            get { return _hasErrors; }
            set { _hasErrors = value; }
        }
        private void btnSupervisorSign_Click(Object sender, EventArgs e)
        {
            SetWorkflowActions();

            string validationErrors = string.Empty;
            
            bool blnhaserror = false;
            HasErrors = false;
            User thisUser = base.CurrentUser;
            try
            {
                SignatureType currentsigntype = (SignatureType)int.Parse(this.rblSupSignType.SelectedValue);

                //For Issue 995 - to show the message for wrong password
                if (IsValidSignature(thisUser.MappedUserName, txtSupervisorPwd.Text))
                {
                    if (currentsigntype == SignatureType.Supervisor || base.IsSystemAdministrator)
                    {
                        //For Issue 995 - this logic is not needed. It has taken care above.
                        //if (IsValidSignature(thisUser.MappedUserName, txtSupervisorPwd.Text))
                        //{
                            //Validate without Signature
                            validationErrors = WorkflowManager.GetStaffingObjetValidationErros(workflowobj.StaffingObjectID, workflowobj.StaffingObjectTypeID, ref blnhaserror, false);
                            if (blnhaserror)
                            {
                                HasErrors = true;
                                customValidator.ErrorMessage = validationErrors;
                                Page.Validate();

                            }
                            else
                            {
                                if (SignJNP(txtSupervisorPwd.Text, currentsigntype, txtSupOrgTitle.Text, supervisoryCertification))
                                {
                                    base.PrintSystemMessage("Supervisory Certification has been Accepted.", true);
                                    txtSupOrgTitle.Text = string.Empty;
                                    setupPage();
                                }
                            }
                        //}
                        //else
                        //{
                        //    base.PrintErrorMessage("Signature not valid. Please provide your valid password.", true);
                        //}

                    }

                    if (currentsigntype == SignatureType.Classifier || base.IsSystemAdministrator)
                    {
                        //if (IsValidSignature(thisUser.MappedUserName, txtSupervisorPwd.Text))
                        //{
                            //Validate without Signature
                            validationErrors = WorkflowManager.GetStaffingObjetValidationErros(workflowobj.StaffingObjectID, workflowobj.StaffingObjectTypeID, ref blnhaserror, false);
                            if (blnhaserror)
                            {
                                HasErrors = true;
                                customValidator.ErrorMessage = validationErrors;
                                Page.Validate();

                            }
                            else
                            {
                                if (SignJNP(txtSupervisorPwd.Text, currentsigntype, txtSupOrgTitle.Text, classifierCertification))
                                {
                                    //Validate without Signature

                                    //base.PrintSystemMessage("HR Certification has been Accepted.", true);

                                    if (rblSupSignType.SelectedValue == "1")
                                    {
                                        base.PrintSystemMessage("Supervisor Certification has been Accepted.", true);
                                    }
                                    if (rblSupSignType.SelectedValue == "4")
                                    {
                                        base.PrintSystemMessage("HR Certification has been Accepted.", true);
                                    }

                                    txtSupOrgTitle.Text = string.Empty;
                                    setupPage();
                                }
                            }
                        //}
                        //else
                        //{
                        //    base.PrintErrorMessage("Signature not valid. Please provide your valid password.", true);
                        //}

                    }
                }
                else
                {
                    base.PrintErrorMessage("Signature not valid. Please provide your valid password.", true);

                }
            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex, true);
            }
        }
        protected void customValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !(HasErrors);
        }
        #endregion

    
       

        #region Private Methods

        private bool IsValidSignature(string username, string pwd)
        {
            //If we need to jump login to bypass active direcotry account validation
            //if(HCMS.WebFramework.Site.Wrappers.ConfigWrapper.JumpLogin)
                //return true;

            bool isvalidSign = false;
            isvalidSign = Membership.ValidateUser(username, pwd);
            return isvalidSign;

        }

        private bool SignJNP(string pwd, SignatureType signtype, string signedbyOrgTitle, string certification)
        {
            bool signatureOK = false;

            try
            {
                User thisUser = base.CurrentUser;

                //bool passwGood = true;
                //if (passwGood)

                //For Issue 995 - to show the message for wrong password
                //if (IsValidSignature(thisUser.MappedUserName, pwd))
                //{
                    
                    if (signtype == SignatureType.Supervisor)
                    {
                        this.JNPApprovalEntity.SupervisorID = thisUser.UserID;
                        this.JNPApprovalEntity.SupervisorFullName = thisUser.FullName;
                        this.JNPApprovalEntity.SupervisorOrgTitle = signedbyOrgTitle;
                        this.JNPApprovalEntity.SupervisorSignDate = DateTime.Now;
                    }
                    if (signtype == SignatureType.Classifier)
                    {
                        this.JNPApprovalEntity.HRPersonnelID = thisUser.UserID;
                        this.JNPApprovalEntity.HRPersonnelFullName = thisUser.FullName;
                        this.JNPApprovalEntity.HRPersonnelOrgTitle = signedbyOrgTitle;
                        this.JNPApprovalEntity.HRPersonnelSignDate = DateTime.Now;
                    }

                    this.JNPApprovalEntity.JNPID = base.CurrentJNPID;
                    this.JNPApprovalEntity.JAID = base.CurrentJAID;
                    this.JNPApprovalEntity.CRID = base.CurrentCRID;
                    this.JNPApprovalEntity.JQID = base.CurrentJQID;


                    if (this.JNPApprovalEntity.ID <= 0)
                    {
                        this.JNPApprovalEntity.ID = approvalMgr.Add(this.JNPApprovalEntity, signtype);
                        //ApprovalID = approvalEntity.ID;
                    }
                    else
                    {
                        //approvalMgr.Update(this.JNPApprovalEntity, signtype);
                    }

                    approvalMgr.Update(this.JNPApprovalEntity, signtype);

                    this.litmsg.Text = "Job Announcement signed successfully.";
                    signatureOK = true;
                //}
                //else
                //{
                //    base.PrintErrorMessage("Signature not valid. Please provide your valid password.", true);
                //}
            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex.Message, true);
            }

            return signatureOK;
        }

        //protected void lnkPrintJNP_Click(object sender, EventArgs e)
        //{
        //    JNPReports.JNPReport currentJNPReportDoc = new JNPReports.JNPReport();            
        //    currentJNPReportDoc.ReportParameters["jNPID"].Value = CurrentJNP.JNPID;
        //   // currentJobAnalysisDoc.ReportParameters["documentObjectTypeId"].Value = enumDocumentType.Unknown;
        //    ControlUtility.ExportToPDF("JNP Report", currentJNPReportDoc);
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

        #region [ Private Members ]
        private const string supervisoryCertification = "I certify that this package is an accurate statement of the major duties and responsibilities of this package and its organizational relationships, and that the package is necessary to carry out Government functions for which I am responsible. This certification is made with the knowledge that this information is to be used for statutory purpose relating to appointment and payment of public funds, and that false or misleading statements may constitute violations of such statutes or their implementing regulations.";
        private const string classifierCertification = "I certify that this package has been classified / graded as required by Title 5, U.S. Code, in conformance with standards published by the U.S. Office of Personnel Management or, if no published standards apply directly, consistently with the most applicable published standards.";

        #endregion

    }
}
