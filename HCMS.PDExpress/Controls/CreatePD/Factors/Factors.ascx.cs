using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

using System.Web.Caching;

using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.Business.Lookups;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.Security;
using HCMS.PDExpress.Controls.Message;
using HCMS.PDExpress.Controls.ToolTip;
using Telerik.Web.UI;
using HCMS.WebFramework.Site.ConfigClasses;
namespace HCMS.PDExpress.Controls.CreatePD.Factors
{
    public partial class Factors : CreatePDUserControlBase
    {
        #region [ Page Event Handlers ]

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);

            this.repeaterClassStdSource.ItemDataBound += new RepeaterItemEventHandler(repeaterClassStdSource_ItemDataBound);

            this.btnSubmitClassStdSource.Click += new EventHandler(btnSubmitClassStdSource_Click);

            this.gvFesFactor.RowDataBound += new GridViewRowEventHandler(gvFesFactor_RowDataBound);
            this.gvFesFactor.RowCommand += new GridViewCommandEventHandler(gvFesFactor_RowCommand);
            this.gvFesFactor.RowDeleting += new GridViewDeleteEventHandler(gvFesFactor_RowDeleting);
            this.gvFesFactor.RowEditing += new GridViewEditEventHandler(gvFesFactor_RowEditing);
            this.gvFesFactor.PageIndexChanging += new GridViewPageEventHandler(gvFesFactor_PageIndexChanging);

            this.gvGSSGFactor.RowDataBound += new GridViewRowEventHandler(gvGSSGFactor_RowDataBound);
            this.gvGSSGFactor.RowEditing += new GridViewEditEventHandler(gvGSSGFactor_RowEditing);
            this.gvGSSGFactor.RowCommand += new GridViewCommandEventHandler(gvGSSGFactor_RowCommand);
            this.gvGSSGFactor.PageIndexChanging += new GridViewPageEventHandler(gvGSSGFactor_PageIndexChanging);

            this.gvNarrativeFactor.RowDataBound += new GridViewRowEventHandler(gvNarrativeFactor_RowDataBound);
            this.gvNarrativeFactor.RowCommand += new GridViewCommandEventHandler(gvNarrativeFactor_RowCommand);
            this.gvNarrativeFactor.RowEditing += new GridViewEditEventHandler(gvNarrativeFactor_RowEditing);
            this.gvNarrativeFactor.PageIndexChanging += new GridViewPageEventHandler(gvNarrativeFactor_PageIndexChanging);

            this.gvNarrativeSupFactor.RowDataBound += new GridViewRowEventHandler(gvNarrativeSupFactor_RowDataBound);
            this.gvNarrativeSupFactor.RowCommand += new GridViewCommandEventHandler(gvNarrativeSupFactor_RowCommand);
            this.gvNarrativeSupFactor.RowEditing += new GridViewEditEventHandler(gvNarrativeSupFactor_RowEditing);
            this.gvNarrativeSupFactor.PageIndexChanging += new GridViewPageEventHandler(gvNarrativeSupFactor_PageIndexChanging);


            this.btnSubmit.Click += new EventHandler(btnSubmit_Click);
            this.btnRefresh.Click += new EventHandler(btnRefresh_Click);
            this.ucCareerLadderProgressions.SuccessfulSave += new EventHandler(ucCareerLadderProgressions_SuccessfulSave);
            #region EvalStatementRelated
            //this.chkEvalCriteria.DataBinding += new EventHandler(chkEvalCriteria_DataBinding);
            //this.btnAddEval.Click += new EventHandler(btnAddEval_Click);
            //this.btnSubmitEvalCrit.Click += new EventHandler(btnSubmitEvalCrit_Click);
            //this.btnSaveEval.Click += new EventHandler(btnSaveEval_Click);
            #endregion
            this.btnViewPD.Click += new EventHandler(btnViewPD_Click);
            this.btnShowDiff.Click += new EventHandler(btnShowDiff_Click);
            //radajaxmgr = RadAjaxManager.GetCurrent(this.Page);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PD = base.CurrentPD;
                base.CurrentGoBackPDID = -1;
                enumPayPlan currentpayplanid = (enumPayPlan)PD.PayPlanID;

                currentStatus = base.CurrentPD.GetCurrentPDStatus();

                if (!Page.IsPostBack)
                {
                    BindClassificationStandardSource();
                    //BindEvalCriteria();
                    List<PositionFactor> positionfactors = PD.GetPositionFactor();
                    this.btnSubmit.Enabled = (positionfactors.Count > 0) ? true : false;
                    setPageView();
                }

                ValidationMessage = String.Empty;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            //DisplayEvalPanel();

            if (this.PD.PositionDescriptionTypeID == (int)PDChoiceType.StatementOfDifferencePD)
            {
                btnShowDiff.Enabled = false;
            }

            base.OnPreRender(e);
        }
        private enumNextAct GetNextAction()
        {
            enumNextAct nextact;
            //reevaluating isPDCreatorSupervisor because when the PD is created from existing standard Pd without
            //organization code, isPDCreatorSupervisor returned false because PD did not have any associated org code
            bool isPDCreatorSupervisor = base.isPDCreatorSupervisor(true);
            bool isCL = base.CurrentPDChoice == PDChoiceType.CareerLadderPD;

               bool hasCompleteSupervisorCert = base.HasPermission(enumPermission.CompleteSupervisoryCertification);
           


            if (isCL)
            {//commenting this code as per discussion with Pam
                //button should always say "Save and Continue"
                //The logic to send to "Approvals"/ Tell user to Save and Unlock will be
                //placed in NextStep() method.
                //CL and Full Performance
                //if (base.CurrentPD.LadderPosition == 0)
                //{
                //    if (isPDCreatorSupervisor || hasHRGroupPermission)
                //    {

                //        nextact = enumNextAct.SaveandContinue;
                //    }
                //    else
                //    {
                //        nextact = enumNextAct.SaveandUnlock;
                //    }
                //}
                //else //ladder positions - no need to direct to approvals even if you are supervisor or HR
                //{
                //    nextact = enumNextAct.SaveandUnlock;
                //}
                nextact = enumNextAct.SaveandContinue;
            }
            else //not a career ladder 
            {// JA issue ID 824: modified: to check if HR user has complete Certification permissiion then only send them to approval otherwise save and unlock -
                //This was to fix the error - staffing manager/staffing specialist was  having -- 
                //added conditon -completeJNPCertification to the list to allow user to access approval page
                //this is to support Staffing Specialist/Staffing Manager Role to allow them to sign as evaluator
                //as they were given -Save and continue button - as they had other HR group permission but -- 
                //they could not sign so approval page was directing them to access denied page. --modified approval page to include completeJNPCertification 
 
                if (isPDCreatorSupervisor || base.HasPermission (enumPermission.CompleteHRCertification) || base.HasPermission (enumPermission.CompleteJNPCertification ))
                {

                    nextact = enumNextAct.SaveandContinue;
                }

                else
                {
                    nextact = enumNextAct.SaveandUnlock;
                }
            }
            return nextact;
        }
        private void setPageView()
        {
            bool okToUse = !base.IsPDReadOnly;
            bool isPDCreator = base.CurrentPD.PDCreatorID.Equals(base.CurrentUser.UserID);
            bool isAdmin = base.IsAdmin;
            bool isPDCreatorSupervisor = base.isPDCreatorSupervisor(false);
            bool isSOD = base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
            bool hasHRGroupPermission = (base.HasPermission(enumPermission.CompleteHRCertification) || base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
                    base.HasPermission(enumPermission.MaintainHRSection) || base.HasPermission(enumPermission.MaintainFactorRecommendation) ||
                        base.HasPermission(enumPermission.PublishPD));
            bool isCL = base.CurrentPDChoice == PDChoiceType.CareerLadderPD || base.CurrentPDChoice == PDChoiceType.CLStatementOfDifferencePD; ;

            enumNextAct nextAction = GetNextAction();
            if (nextAction == enumNextAct.SaveandContinue)
            {
                this.btnSubmit.Text = "Save and Continue";
            }
            else
            {
                this.btnSubmit.Text = "Save and Unlock";
            }
            //either not a career ladder pd or if career ladder then it is a Full performance
            // bool passedCareerLadderCheck = base.CurrentPDChoice != PDChoiceType.CareerLadderPD || (base.CurrentPDChoice == PDChoiceType.CareerLadderPD && ( base.CurrentPD.LadderPosition ==-1 ||base.CurrentPD.LadderPosition  == 0));
            PDStatus status = base.CurrentPD.GetCurrentPDStatus();
            List<PositionClassificationStandard> currentclassstd = base.CurrentPD.GetPositionClassificationStandard();


            lblFactorlangWarning.Visible = (currentclassstd.Count > 0);
            switch (status)
            {
                case PDStatus.Draft:
                    bool isHMEnabled = okToUse && (isPDCreator || isPDCreatorSupervisor||isAdmin);

                    btnSubmit.Enabled = btnSubmitClassStdSource.Enabled = isHMEnabled && !isSOD;
                    if (isCL && okToUse && (isPDCreator || isPDCreatorSupervisor||isAdmin))
                    {
                        this.ucCareerLadderProgressions.VisibleProgression = true;
                        //commented reloading the control as it was not showing the message
                        // that the ladder was generated successfully.
                        //this.ucCareerLadderProgressions.ReloadControl();



                    }
                    break;
                case PDStatus.Revise:
                    //Modified this condition to be more specific
                    bool isReviseEnabled = okToUse && (isPDCreator || isPDCreatorSupervisor||isAdmin);
                    btnSubmit.Enabled = isReviseEnabled && !isSOD;
                    //issue 687
                    //enabling the Submit button to de-select the
                    //classification standard guide that was pre-selected in Revise
                    btnSubmitClassStdSource.Enabled = isReviseEnabled && !isSOD;  //Submit associated with Classification Evaluation Guide List
                    //btnSubmitEvalCrit.Enabled = btnAddEval.Enabled = btnSaveEval.Enabled = isReviseEnabled && !isSOD;
                    break;
                case PDStatus.Review:
                    bool isEnabled = okToUse && (hasHRGroupPermission||isAdmin);
                    btnSubmit.Enabled = isEnabled && !isSOD;
                    btnSubmitClassStdSource.Enabled = isEnabled && !isSOD;
                    //btnSubmitEvalCrit.Enabled = btnAddEval.Enabled = btnSaveEval.Enabled = isEnabled  && !isSOD;
                    break;
                case PDStatus.FinalReview:
                    bool isFinalEnabled = okToUse && ( hasHRGroupPermission ||isAdmin );
                    btnSubmit.Enabled = isFinalEnabled && !isSOD;
                    btnSubmitClassStdSource.Enabled = true; //changed that from false to true as HR might want to add other references in final review as well
                    //btnSubmitEvalCrit.Enabled = btnAddEval.Enabled = btnSaveEval.Enabled = isFinalEnabled  && !isSOD;
                    break;
                default: //takes care of PUBLISHED Status as well
                    btnSubmit.Enabled = okToUse;
                    btnSubmitClassStdSource.Enabled = okToUse;
                    //btnSubmitEvalCrit.Enabled = okToUse;
                    //btnAddEval.Enabled = okToUse;
                    //btnSaveEval.Enabled = okToUse;
                    break;
            }
        }

        #endregion

        #region [ Classification Source Event Handlers ]

        protected void BindClassificationStandardSource()
        {
            this.repeaterClassStdSource.DataSource = LookupWrapper.GetAllClassificationStandardSources(true);
            this.repeaterClassStdSource.DataBind();
        }

        void repeaterClassStdSource_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int classStdCount = 0;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hiddenClassStdSource = e.Item.FindControl("hiddenClassStdSourceID") as HiddenField;
                HiddenField hiddenFormatType = e.Item.FindControl("hiddenFactorFormatTypeID") as HiddenField;
                CheckBox cbCurrentSource = e.Item.FindControl("cbClassStdSource") as CheckBox;
                TextBox txtOtherReferences = e.Item.FindControl("txtOtherReferences") as TextBox;
                HtmlGenericControl divOther = e.Item.FindControl("divOther") as HtmlGenericControl;
                ToolTip.ToolTip toolTip = e.Item.FindControl("toolTip") as ToolTip.ToolTip;

                int classStdSourceID = int.Parse(hiddenClassStdSource.Value);
                int factorFormatTypeID = int.Parse(hiddenFormatType.Value);
                enumFactorFormatType currentFormat = (enumFactorFormatType)factorFormatTypeID;
                ConfigMessagesSection cfms = ConfigMessagesSection.PDXMessagesSection;
                string message = string.Empty;
                string jsstring = string.Empty;


                //disable all (except other)classification standard guide selection in revise/finalreview 
                if (classStdSourceID == 6)
                {
                    cbCurrentSource.Attributes.Add("onclick", "javascript:toggleOtherReferences('" + cbCurrentSource.ClientID + "','" + divOther.ClientID + "')");
                }
                else
                {
                    //showing the confirmation message if user de-selects the preselected standard --issue 957
                    if (currentStatus == PDStatus.Revise || currentStatus == PDStatus.FinalReview)
                    {
                        cbCurrentSource.Enabled = false;
                    }
                }
                PositionClassificationStandard currentClassStd = PD.GetPositionClassificationStandardByClassSourceID(classStdSourceID);
                bool createdbycurrentUser = false;
                if (currentClassStd != null)
                {
                    createdbycurrentUser = (currentClassStd.CreatedByID == base.CurrentUser.UserID);
                    cbCurrentSource.Checked = true;
                    bool? isrecommended = currentClassStd.IsRecommended;
                    if (isrecommended != null && isrecommended == true)
                    {
                        message = cfms.PDXMessages["1"].Text;
                    }
                    else
                    {
                        message = cfms.PDXMessages["2"].Text;
                    }
                    jsstring = string.Format("javascript:return blockConfirm('{0}',event, 330, 100,'','Change Classification Standard Guide');", message);
                    cbCurrentSource.Attributes.Add("onclick", jsstring);

                    ++classStdCount;
                    // commenting permission check part of  this condition as we decided that
                    // we should not allow any body to delete the selected class standard in review and final review
                    //except for system admin
                    //or if it is in review/final review and if the creator of the standard is the same as current logged in user
                    //then allow them to delete it. --issue 707
                    if (base.HasPermission(enumPermission.AllSystemAdministrationPermissions))
                    {
                        cbCurrentSource.Enabled = true;
                    }
                    else
                    {
                        switch (currentStatus)
                        {
                            case PDStatus.Draft:
                                cbCurrentSource.Enabled = true;
                                break;
                            case PDStatus.Review:
                                //as per discussion with team enabling to deselct the standard for HR in review
                                if (createdbycurrentUser || base.HasHRGroupPermission)
                                {
                                    cbCurrentSource.Enabled = true;
                                }
                                else
                                {
                                    cbCurrentSource.Enabled = false;
                                }
                                break;
                            case PDStatus.Revise: //reverting back the capability to de-select the stadard in revise (issue 687)
                                cbCurrentSource.Enabled = false;
                                break;
                            case PDStatus.FinalReview:
                                cbCurrentSource.Enabled = base.HasHRGroupPermission;
                                break;
                            default:
                                cbCurrentSource.Enabled = false;
                                break;

                        }
                        //if (currentStatus == PDStatus.Review || currentStatus == PDStatus.FinalReview) //  &&  (base.HasPermission(enumPermission.MaintainFactorRecommendation) || base.HasPermission(enumPermission.MaintainHRSection) || base.HasPermission(enumPermission.MaintainEvaluationStatements)))
                        //{
                        //    //if the standard is created by current user, then allow them to deselect it
                        //    if (createdbycurrentUser)
                        //    { cbCurrentSource.Enabled = true; }
                        //    else
                        //    { cbCurrentSource.Enabled = false; }
                        //}
                        //else
                        //{
                        //    //in revise enabling classification standard guide checkbox that is already selected
                        //    //so that if they want to deselect it --issue 687
                        //    cbCurrentSource.Enabled = true;
                        //}

                    }

                    if (classStdSourceID == 6)
                    {
                        txtOtherReferences.Text = currentClassStd.ClassificationSourceName;
                        divOther.Style["display"] = "block";
                    }
                    else
                    {
                        BindGrid(currentFormat);
                    }
                }

                toolTip.ToolTipID = (50 + classStdSourceID).ToString();
                toolTip.ID = String.Format("{0}{1}", toolTip.ID, classStdSourceID.ToString());
                toolTip.ReloadControl();


            }
        }

        void btnSubmitClassStdSource_Click(object sender, EventArgs e)
        {
            try
            {
                List<PositionClassificationStandard> existingPositionClassificationStandards = PD.GetPositionClassificationStandard();
                int classStdCount = 0;

                foreach (RepeaterItem item in this.repeaterClassStdSource.Items)
                {
                    if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                    {
                        CheckBox cbCurrentSource = item.FindControl("cbClassStdSource") as CheckBox;
                        if (cbCurrentSource != null)
                        {
                            HiddenField hiddenClassStdSource = item.FindControl("hiddenClassStdSourceID") as HiddenField;
                            HiddenField hiddenClassSourceTitle = item.FindControl("hiddenClassSourceTitle") as HiddenField;
                            HiddenField hiddenFormatType = item.FindControl("hiddenFactorFormatTypeID") as HiddenField;
                            TextBox txtOtherReferences = item.FindControl("txtOtherReferences") as TextBox;

                            int classStdSourceID = int.Parse(hiddenClassStdSource.Value);
                            int factorFormatTypeID = int.Parse(hiddenFormatType.Value);
                            enumFactorFormatType currentFormat = (enumFactorFormatType)factorFormatTypeID;

                            PositionClassificationStandard currentClassStd = PD.GetPositionClassificationStandardByClassSourceID(classStdSourceID);

                            if (cbCurrentSource.Checked)
                            {
                                ++classStdCount;

                                if (currentClassStd == null)
                                {
                                    PositionClassificationStandard newPositionClassStd = new PositionClassificationStandard();
                                    newPositionClassStd.PositionDescriptionID = PD.PositionDescriptionID;
                                    newPositionClassStd.ClassificationSourceID = classStdSourceID;

                                    if (classStdSourceID == 6)
                                    {
                                        newPositionClassStd.ClassificationSourceName = txtOtherReferences.Text;
                                    }
                                    else
                                    {
                                        newPositionClassStd.ClassificationSourceName = hiddenClassSourceTitle.Value;
                                    }

                                    newPositionClassStd.CreatedByID = this.UserID;
                                    newPositionClassStd.CreateDate = DateTime.Now;
                                    newPositionClassStd.Add();
                                }
                                else
                                {
                                    if (classStdSourceID == 6)
                                    {
                                        currentClassStd.ClassificationSourceName = txtOtherReferences.Text;
                                        currentClassStd.Update();
                                    }
                                }
                            }
                            else // if current source is unchecked
                            {
                                if (currentClassStd != null)
                                {
                                    if (currentStatus == PDStatus.Draft)
                                    {
                                        string message = string.Empty;
                                        ConfigMessagesSection cfms = ConfigMessagesSection.PDXMessagesSection;
                                        bool? isrecommended = currentClassStd.IsRecommended;
                                        if (isrecommended != null && isrecommended == true)
                                        {
                                            message = cfms.PDXMessages["3"].Text;

                                        }
                                        else
                                        {
                                            message = cfms.PDXMessages["4"].Text;
                                        }
                                        ValidationMessage = message;
                                    }
                                    currentClassStd.Delete(factorFormatTypeID);
                                }
                            }

                            bool okToUse = !base.IsPDReadOnly;
                            bool passedCareerLadderCheck = base.CurrentPDChoice != PDChoiceType.CareerLadderPD || (base.CurrentPDChoice == PDChoiceType.CareerLadderPD && base.CurrentPD.LadderPosition == 0);

                            this.btnSubmit.Enabled = okToUse && (classStdCount > 0);
                            BindGrid(currentFormat);
                            this.ucCareerLadderProgressions.VisibleProgression = true;
                            this.ucCareerLadderProgressions.ReloadControl();
                            lblFactorlangWarning.Visible = (classStdCount > 0);
                        }
                    }
                }

                BindClassificationStandardSource();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region [ FES Grid Event Handlers ]

        private void gvFesFactor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvFesFactor.PageIndex = e.NewPageIndex;
                BindFESFactorGrid();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        void gvFesFactor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton editButton = e.Row.FindControl("imgEditFESFactor") as ImageButton;
                ImageButton deleteButton = e.Row.FindControl("imgDeleteFESFactor") as ImageButton;
                Label lblFactorLanguage = e.Row.FindControl("lblFactorLanguage") as Label;
                Image imgRecommendationNote = e.Row.FindControl("imgRecommendationNote") as Image;
                Image imgFactorLangAdded = e.Row.FindControl("imgFactorLangAdded") as Image;

                PositionFactor pf = e.Row.DataItem as PositionFactor;

                if (editButton != null)
                {
                    editButton.Attributes.Add("onclick", "javascript:ShowFactorLanguagePopup(" + pf.PositionFactorID.ToString() + ",'" + Server.UrlEncode(pf.FactorTitle) + "'); return false;");
                }

                if (deleteButton != null)
                {
                    deleteButton.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure you want to delete -" +
                    DataBinder.Eval(e.Row.DataItem, "FactorTitle") + "')");
                }
                bool reviewed = false;
                if (pf.Reviewed.HasValue)
                {

                    reviewed = (bool)pf.Reviewed;

                }
                if (!String.IsNullOrEmpty(pf.RecommendationNote) && !reviewed)
                {
                    imgRecommendationNote.Visible = true;
                }

                if (lblFactorLanguage.Text.Length > 0)
                {
                    imgFactorLangAdded.Visible = true;
                }
            }
        }

        void gvFesFactor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    break;
            }
        }

        void gvFesFactor_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        void gvFesFactor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void BindFESFactorGrid()
        {
            List<PositionFactor> currentpositionfactors = PD.GetPositionFactorBySeriesGrade(enumFactorFormatType.FES, this.UserID);
            if (currentpositionfactors.Count > 0)
            {
                this.pnlFESFactor.Visible = true;
                this.gvFesFactor.DataSource = currentpositionfactors;
                this.gvFesFactor.DataBind();
                this.ctrlCareerLadderBundle.ReloadControl();
                this.updatePanelActionValidate.Update();
            }
            else
            {
                this.pnlFESFactor.Visible = false;
            }
        }

        #endregion

        #region [ GSSG Grid Event Handlers ]

        private void gvGSSGFactor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvGSSGFactor.PageIndex = e.NewPageIndex;
                BindGSSGFactorGrid();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        void gvGSSGFactor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton editButton = e.Row.FindControl("imgEditGSSGFactor") as ImageButton;
                Label lblfactorlanguage = e.Row.FindControl("lblFactorLanguage") as Label;
                Image imgRecommendationNote = e.Row.FindControl("imgRecommendationNote") as Image;
                Image imgFactorLangAdded = e.Row.FindControl("imgFactorLangAdded") as Image;

                PositionFactor pf = e.Row.DataItem as PositionFactor;

                if (editButton != null)
                {
                    editButton.Attributes.Add("onclick", "javascript:ShowFactorLanguagePopup(" + pf.PositionFactorID.ToString() + ",'" + Server.UrlEncode(pf.FactorTitle) + "'); return false;");
                }
                bool reviewed = false;
                if (pf.Reviewed.HasValue)
                {

                    reviewed = (bool)pf.Reviewed;

                }
                if (!String.IsNullOrEmpty(pf.RecommendationNote) && !reviewed)
                {
                    imgRecommendationNote.Visible = true;
                }

                if (lblfactorlanguage.Text.Length > 0)
                {
                    imgFactorLangAdded.Visible = true;
                }
            }
        }

        void gvGSSGFactor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        void gvGSSGFactor_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void BindGSSGFactorGrid()
        {
            List<PositionFactor> currentpositionfactors = PD.GetPositionFactorBySeriesGrade(enumFactorFormatType.GSSG, this.UserID);
            if (currentpositionfactors.Count > 0)
            {
                this.pnlGSSGFactor.Visible = true;
                this.gvGSSGFactor.DataSource = currentpositionfactors;
                this.gvGSSGFactor.DataBind();
                this.ctrlCareerLadderBundle.ReloadControl();
                this.updatePanelActionValidate.Update();
            }
            else
            {
                this.pnlGSSGFactor.Visible = false;
            }
        }
        #endregion

        #region [ Narrative Grid Events ]

        private void gvNarrativeFactor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvNarrativeFactor.PageIndex = e.NewPageIndex;
                BindNarrativeFactorGrid(enumFactorFormatType.Narrative);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        void gvNarrativeFactor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton editButton = e.Row.FindControl("imgEditNarrativeFactor") as ImageButton;
                Label lblfactorlanguage = e.Row.FindControl("lblFactorLanguage") as Label;
                Image imgRecommendationNote = e.Row.FindControl("imgRecommendationNote") as Image;
                Image imgFactorLangAdded = e.Row.FindControl("imgFactorLangAdded") as Image;

                PositionFactor pf = e.Row.DataItem as PositionFactor;

                if (editButton != null)
                {
                    editButton.Attributes.Add("onclick", "javascript:ShowNarrativeFactorLanguagePopup(" + pf.PositionFactorID.ToString() + ",'" + Server.UrlEncode(pf.FactorTitle) + "'); return false;");
                }
                bool reviewed = false;
                if (pf.Reviewed.HasValue)
                {

                    reviewed = (bool)pf.Reviewed;

                }
                if (!String.IsNullOrEmpty(pf.RecommendationNote) && !reviewed)
                {
                    imgRecommendationNote.Visible = true;
                }

                if (lblfactorlanguage.Text.Length > 0)
                {
                    imgFactorLangAdded.Visible = true;
                }
            }
        }
        void gvNarrativeFactor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    break;
            }
        }
        void gvNarrativeFactor_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        #endregion

        #region [ Narrative Sup Grid Events ]

        private void gvNarrativeSupFactor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvNarrativeSupFactor.PageIndex = e.NewPageIndex;
                BindNarrativeFactorGrid(enumFactorFormatType.NarrativeSupervisory);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        void gvNarrativeSupFactor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton editButton = e.Row.FindControl("imgEditNarrativeFactor") as ImageButton;
                Image imgRecommendationNote = e.Row.FindControl("imgRecommendationNote") as Image;
                Label lblfactorlanguage = e.Row.FindControl("lblFactorLanguage") as Label;
                Image imgFactorLangAdded = e.Row.FindControl("imgFactorLangAdded") as Image;

                PositionFactor pf = e.Row.DataItem as PositionFactor;

                if (editButton != null)
                {
                    editButton.Attributes.Add("onclick", "javascript:ShowNarrativeFactorLanguagePopup(" + pf.PositionFactorID.ToString() + ",'" + Server.UrlEncode(pf.FactorTitle) + "'); return false;");
                }
                bool reviewed = false;
                if (pf.Reviewed.HasValue)
                {

                    reviewed = (bool)pf.Reviewed;

                }
                if (!String.IsNullOrEmpty(pf.RecommendationNote) && !reviewed)
                {
                    imgRecommendationNote.Visible = true;
                }
                if (lblfactorlanguage.Text.Length > 0)
                {
                    imgFactorLangAdded.Visible = true;
                }
            }
        }
        void gvNarrativeSupFactor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Delete":
                    break;
            }
        }
        void gvNarrativeSupFactor_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void BindNarrativeFactorGrid(enumFactorFormatType factorformattype)
        {
            List<PositionFactor> currentpositionfactors = PD.GetPositionFactorBySeriesGrade(factorformattype, this.UserID);
            if (currentpositionfactors.Count > 0)
            {
                if (factorformattype == enumFactorFormatType.Narrative)
                {
                    this.pnlNarrativeFactor.Visible = true;
                    this.gvNarrativeFactor.DataSource = currentpositionfactors;
                    this.gvNarrativeFactor.DataBind();
                }
                else if (factorformattype == enumFactorFormatType.NarrativeSupervisory)
                {
                    this.pnlNarrativeSupFactor.Visible = true;
                    this.gvNarrativeSupFactor.DataSource = currentpositionfactors;
                    this.gvNarrativeSupFactor.DataBind();
                }
                this.ctrlCareerLadderBundle.ReloadControl();
                this.updatePanelActionValidate.Update();
            }
            else
            {
                if (factorformattype == enumFactorFormatType.Narrative)
                {
                    this.pnlNarrativeFactor.Visible = false;
                }
                else if (factorformattype == enumFactorFormatType.NarrativeSupervisory)
                {
                    this.pnlNarrativeSupFactor.Visible = false;
                }
            }
        }
        #endregion

        #region [ User Control Events ]

        private void ucCareerLadderProgressions_SuccessfulSave(object sender, EventArgs e)
        {
            try
            {
                base.ReloadCurrentPD(base.CurrentPDID);
                setPageView();
                this.ctrlCareerLadderBundle.ReloadControl();
                this.updatePanelActionValidate.Update();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region [ Position Grade Point Events ]
        protected void BindFesPositionGradePoint()
        {
            PositionGradePoint currentPositionGradePoint = PD.GetPositionGradePointByFactorFormatTypeID((int)enumFactorFormatType.FES);

            if (currentPositionGradePoint.TotalPoints > 0)
            {
                //this.pnlGradeConversion.Visible = true;
                this.lblFesTotalPointsVal.Text = currentPositionGradePoint.TotalPoints.ToString();
                this.lblFesMinPoint.Text = currentPositionGradePoint.MinPoint.ToString();
                this.lblFesMaxPoint.Text = currentPositionGradePoint.MaxPoint.ToString();
                this.lblFesGradeRangeVal.Text = string.Format("GS - {0}", currentPositionGradePoint.Grade.ToString());

                if ((PD.PositionDescriptionTypeID != (int)PDChoiceType.StatementOfDifferencePD) && (PD.ProposedGrade != currentPositionGradePoint.Grade))
                {
                    this.lblFesGradeRangeMessage.Text = "* Position Description's selected proposed grade is not in sync with current grade range.";
                    this.lblFesGradeRangeVal.Text = string.Format("GS - {0}{1}", currentPositionGradePoint.Grade.ToString(), "*");
                }
                else
                {
                    this.lblFesGradeRangeMessage.Text = "";
                }
            }
            else
            {
                //this.pnlGradeConversion.Visible = false;
            }
        }

        protected void BindGssgPositionGradePoint()
        {
            PositionGradePoint currentPositionGradePoint = PD.GetPositionGradePointByFactorFormatTypeID((int)enumFactorFormatType.GSSG);

            if (currentPositionGradePoint.TotalPoints > 0)
            {
                //this.pnlGradeConversion.Visible = true;
                this.lblGssgTotalPointsVal.Text = currentPositionGradePoint.TotalPoints.ToString();
                this.lblGssgMinPoint.Text = currentPositionGradePoint.MinPoint.ToString();
                this.lblGssgMaxPoint.Text = currentPositionGradePoint.MaxPoint.ToString();
                this.lblGssgGradeRangeVal.Text = string.Format("GS - {0}", currentPositionGradePoint.Grade.ToString());

                if ((PD.PositionDescriptionTypeID != (int)PDChoiceType.StatementOfDifferencePD) && (PD.ProposedGrade != currentPositionGradePoint.Grade))
                {
                    this.lblGssgGradeRangeMessage.Text = "* Position Description's selected proposed grade is not in sync with current grade range.";
                    this.lblGssgGradeRangeVal.Text = string.Format("GS - {0}{1}", currentPositionGradePoint.Grade.ToString(), "*");

                }
                else
                {
                    this.lblGssgGradeRangeMessage.Text = "";
                }
            }

        }
        #endregion

        #region [ Evaluation ]

        //private void DisplayEvalPanel()
        //{
        //    int count = GetEvalCritCount();
        //    bool canEdit = CanEditEvaluation();
        //    if (base.HasPermission(enumPermission.MaintainEvaluationStatements))
        //    {
        //        this.tableEval.Visible = true;               

        //    }
        //    else
        //    {
        //        this.tableEval.Visible = this.pnlEvalCrit.Visible = this.pnlEval.Visible = false;
        //    }
        //    if (count > 0)
        //    {
        //        this.pnlEvalCrit.Visible = true;
        //        this.pnlEval.Visible = true;
        //        GetEvalValues();
        //    }

        //    this.btnAddEval.Enabled = this.pnlEvalCrit.Enabled = this.pnlEval.Enabled = canEdit;
        //}

        //private bool CanEditEvaluation()
        //{
        //    bool canEdit = false;

        //    bool isPDCreator = base.CurrentPD.PDCreatorID.Equals(base.CurrentUser.UserID);
        //    bool isPDCreatorSupervisor = base.isPDCreatorSupervisor(false);
        //    bool isSOD = base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
        //    bool hasHRGroupPermission = (base.HasPermission(enumPermission.CompleteHRCertification) || base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
        //                                base.HasPermission(enumPermission.MaintainHRSection) || base.HasPermission(enumPermission.MaintainFactorRecommendation) ||
        //                                base.HasPermission(enumPermission.PublishPD));


        //    if (!(base.IsPDReadOnly || isSOD))
        //    {
        //        if (hasHRGroupPermission)
        //        {
        //            if (isPDCreator || isPDCreatorSupervisor)
        //            {
        //                if (currentStatus == PDStatus.Draft || currentStatus == PDStatus.Review || currentStatus == PDStatus.Revise || currentStatus == PDStatus.FinalReview)
        //                {
        //                    canEdit = true;
        //                }
        //            }
        //            else
        //            {
        //                if (currentStatus == PDStatus.Review || currentStatus == PDStatus.FinalReview)
        //                {
        //                    canEdit = true;
        //                }
        //            }
        //        }
        //    }

        //    return canEdit;
        //}

        ////private void DisplayEvalPanel()
        ////{
        ////    if (GetEvalCritCount() > 0)
        ////    {
        ////        this.tableEval.Visible = this.pnlEvalCrit.Visible = this.pnlEval.Visible = true;
        ////        GetEvalValues();

        ////        bool canEdit = CanEditEvaluation();

        ////        // now enable or disable controls
        ////        this.tableEval.Disabled = !canEdit;
        ////        this.btnAddEval.Enabled = this.pnlEvalCrit.Enabled = this.pnlEval.Enabled = canEdit; 
        ////    }
        ////    else
        ////    {
        ////        this.tableEval.Visible = this.pnlEvalCrit.Visible = this.pnlEval.Visible = false;
        ////    }
        ////}

        //void btnAddEval_Click(object sender, EventArgs e)
        //{
        //    this.pnlEvalCrit.Visible = true;
        //    this.pnlEval.Visible = (GetEvalCritCount() > 0);
        //}

        //void chkEvalCriteria_DataBinding(object sender, EventArgs e)
        //{
        //}

        //void BindEvalCriteria()
        //{
        //    List<PositionEvalCriteria> currentevalCrit = new List<PositionEvalCriteria>();
        //    currentevalCrit = PD.GetPositionEvalCriteria();

        //    this.chkEvalCriteria.DataSource = LookupWrapper.GetAllEvalCriterias(true);

        //    this.chkEvalCriteria.DataBind();
        //    if (currentevalCrit.Count > 0)
        //    {
        //        foreach (ListItem item in this.chkEvalCriteria.Items)
        //        {
        //            PositionEvalCriteria peval = new PositionEvalCriteria();
        //            peval.PositionDescriptionID = PD.PositionDescriptionID;
        //            peval.EvalCriteriaID = int.Parse(item.Value);
        //            if (currentevalCrit.Contains(peval))
        //            {
        //                item.Selected = true;
        //            }
        //        }
        //    }
        //}

        //private int GetEvalCritCount()
        //{
        //    int count = 0;
        //    foreach (ListItem item in this.chkEvalCriteria.Items)
        //    {
        //        if (item.Selected)
        //        {
        //            count = count + 1;
        //        }
        //    }
        //    return count;
        //}

        //void btnSubmitEvalCrit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.ucFullPerformanceMessage.ReloadControl();
        //        int count = 0;
        //        foreach (ListItem item in this.chkEvalCriteria.Items)
        //        {
        //            int evalCriteriaID = int.Parse(item.Value);
        //            PositionEvalCriteria pdEvalCrit = new PositionEvalCriteria();
        //            pdEvalCrit.PositionDescriptionID = PD.PositionDescriptionID;
        //            pdEvalCrit.EvalCriteriaID = evalCriteriaID;
        //            pdEvalCrit.UpdatedByID = this.UserID;
        //            pdEvalCrit.UpdateDate = DateTime.Today;

        //            if (item.Selected)
        //            {
        //                count = count + 1;
        //                pdEvalCrit.Save();
        //            }
        //            else
        //            {
        //                pdEvalCrit.Delete();
        //            }
        //        }

        //        //putting the check here to see if there are no eval crit
        //        //then delete the eval statement so that data is in synch
        //        if (count == 0)
        //        { 
        //            DeleteEvalData();
        //            this.litEvalmsg.Text = String.Empty;
        //        }

        //        GetEvalValues();

        //        this.pnlEval.Visible = (count > 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.HandleException(ex);
        //    }            
        //}

        //private void GetEvalValues()
        //{
        //    ControlUtility.SafeTextBoxAssign(this.txtTitleJustification, PD.TitleJustification);
        //    ControlUtility.SafeTextBoxAssign(this.txtSeriesJustification, PD.SeriesJustification);
        //    ControlUtility.SafeTextBoxAssign(this.txtGradeJustification, PD.GradeJustification);
        //    ControlUtility.SafeTextBoxAssign(this.txtAdditionalJustification, PD.AdditionalJustification);
        //}

        //private void DeleteEvalData()
        //{
        //    //string titleJustification = string.Empty;
        //    //string seriesJustificaion = string.Empty;
        //    //string gradeJustification = string.Empty;
        //    //string additionalJustification = string.Empty;
        //    //SaveEvalValues(titleJustification, seriesJustificaion, gradeJustification, additionalJustification);
        //    try
        //    {
        //        PD.UpdatedByID = this.UserID;
        //        PD.UpdateDate = DateTime.Today;
        //        PD.DeletePositionEvaluation();
        //        this.litEvalmsg.Text = "Evaluation statement saved successfully!";
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
        //    }
        //}
        //private void SaveEvalValues(string titleJustification, string seriesJustificaion, string gradeJustification, string additionalJustification)
        //{


        //    try
        //    {
        //        //commenting the check to getEvalCrit count to avoid loosing the evaluation statement
        //        //incase user inadvertantly unchecked the option and did not click submit.

        //        //if (GetEvalCritCount() > 0)
        //        //{
        //            //titleJustification = this.txtTitleJustification.Text;
        //            //seriesJustificaion = this.txtSeriesJustification.Text;
        //            //gradeJustification = this.txtGradeJustification.Text;
        //            //additionalJustification = this.txtAdditionalJustification.Text;
        //        //}

        //        PD.TitleJustification = titleJustification;
        //        PD.SeriesJustification = seriesJustificaion;
        //        PD.GradeJustification = gradeJustification;
        //        PD.AdditionalJustification = additionalJustification;
        //        PD.UpdatedByID = this.UserID;
        //        PD.UpdateDate = DateTime.Today;

        //        PD.SaveEval(null);
        //        this.litEvalmsg.Text = "Evaluation statement saved successfully!";
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
        //    }
        //}

        //protected void btnSaveEval_Click(object sender, EventArgs e)
        //{
        //    string titleJustification = this.txtTitleJustification.Text;
        //    string seriesJustificaion = this.txtSeriesJustification.Text;
        //    string gradeJustification = this.txtGradeJustification.Text;
        //    string additionalJustification = this.txtAdditionalJustification.Text;
        //    SaveEvalValues(titleJustification ,seriesJustificaion ,gradeJustification ,additionalJustification );
        //}

        #endregion

        #region [ Other Button Events ]

        private void btnViewPD_Click(object sender, EventArgs e)
        {
            base.SafeRedirect(string.Format("~/Documents/PositionDescription/PositionDescriptionDocument.aspx?PDID={0}", base.CurrentPDID));
        }

        void btnShowDiff_Click(object sender, EventArgs e)
        {
            base.SafeRedirect(string.Format("~/CreatePD/ShowDiff.aspx?PDID={0}", base.CurrentPDID));
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //commenting this code as we decided to not validate a PD when clicking submit
                //because 
                //1. we want to add functionality to check-in the PD when the user is a  PD developer 
                //2. if PDDeveloper is logged in and if we do validation, it will always result error - "supervisory signature" and
                // will not allow them to check-in

                bool isCLPD = base.CurrentPDChoice == PDChoiceType.CareerLadderPD || base.CurrentPDChoice == PDChoiceType.CLStatementOfDifferencePD;
                StringBuilder sbMessage = new StringBuilder();
                bool haserrors = false;
                string validationErrors = string.Empty;
                if (Page.IsValid)
                {
                    validationErrors = base.GetValidationErros(ref haserrors);

                    if (isCLPD)
                    {
                        if (haserrors)
                        {
                            this.ctrlCareerLadderBundle.SetMessage(enumValidationcode.ValidationErrors, validationErrors);
                            this.ctrlCareerLadderBundle.ReloadControl();
                        }
                        else
                        {

                            bool hasCareerLadderErrors = false;
                            string careerLadderErrors = string.Empty;
                            //ladder is not generated
                            if ((base.CurrentPDChoice == PDChoiceType.CareerLadderPD) && (base.CurrentPD.LadderPosition == -1))
                            {
                                hasCareerLadderErrors = true;
                                careerLadderErrors = "No associated ladder position";

                            }
                            else
                            {
                                careerLadderErrors = base.GetCareerLadderErrors(ref hasCareerLadderErrors);
                            }
                            if (hasCareerLadderErrors)
                            {
                                //this.ctrlCareerLadderBundle.ValidationMessage = careerLadderErrors;
                                this.ctrlCareerLadderBundle.SetMessage(enumValidationcode.ValidationErrors, careerLadderErrors);
                                this.ctrlCareerLadderBundle.ReloadControl();

                            }
                            else
                                NextStep();
                        }
                        //string functioncall = string.Format("radalert('{0}',330,210,' Validation Errors');", validationErrors);
                        //RadAjaxManager1.ResponseScripts.Add(functioncall);
                    }
                    else if (haserrors)
                    {
                        ValidationMessage = validationErrors;
                    }
                    else //No errors
                    {
                        NextStep();
                    }
                }
                else
                {
                    //When the custom validators in the LadderProgression control
                    //are invalid, Page.IsValid will be false
                    //Custom validators message is displayed in ValSummary control
                    // of the Site.Master 
                    //since the control is on top of the page and the btnSubmit is 
                    // at the bottom, it is helpful to scroll to set the focus on valSummary control
                    
                    //calling SiteMaster.scrolltoTop() 
                    string script = "scrolltoTop();";
                    //using ScriptManger instead of Page.ClientScript because page has updatepanel. When
                    //page has updatepanel, Page.ClientScript.RegisterStartupScript won't update the response and 
                    //therefore won't execute javascript.

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "scrolltotop", script);
                    ScriptManager.RegisterStartupScript(this.updateValidationMessage, typeof(string), "scrollToValSumm", script, true);   
                    
                  
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void NextStep()
        {
            bool isCLPD = base.CurrentPDChoice == PDChoiceType.CareerLadderPD || base.CurrentPDChoice == PDChoiceType.CLStatementOfDifferencePD;


            StringBuilder sbMessage = new StringBuilder();
 // JA issue ID 824: modified: to check if HR user has complete Certification permissiion then only send them to approval otherwise save and unlock -
                //This was to fix the error - staffing manager/staffing specialist was  having -- 
                //added conditon -completeJNPCertification to the list to allow user to access approval page
                //this is to support Staffing Specialist/Staffing Manager Role to allow them to sign as evaluator
                //as they were given -Save and continue button - as they had other HR group permission but -- 
                //they could not sign so approval page was directing them to access denied page. --modified approval page to include completeJNPCertification 
            if (base.isPDCreatorSupervisor(false) || base.HasPermission (enumPermission.CompleteHRCertification) ||base.HasPermission (enumPermission.CompleteJNPCertification))
            {
                if (isCLPD && base.CurrentPD.LadderPosition > 0 && base.CurrentPD.AssociatedFullPD > 0)
                {
                    this.ctrlCareerLadderBundle.SetMessage(enumValidationcode.SignAndSubmit, string.Empty);
                    this.ctrlCareerLadderBundle.ReloadControl();
                    btnSubmit.Enabled = false;
                }
                else // full PD
                {
                    base.GoToPDLink("~/CreatePD/Approvals.aspx");

                }
            }
            else //don't have permission to go to approvals page
            {
                if (isCLPD)
                {
                    this.ctrlCareerLadderBundle.SetMessage(enumValidationcode.SaveAndUnlock, string.Empty);
                    this.ctrlCareerLadderBundle.ReloadControl();
                    btnSubmit.Enabled = false;
                }
                else
                {
                    CurrentPD.CheckIn(CurrentUser.UserID);

                    string redirectURL = System.Configuration.ConfigurationManager.AppSettings["PDExpressDefaultURL"].ToString();
                    base.SafeRedirect(redirectURL);
                }
            }
        }

        private void btnRefresh_Click(object source, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ShowMessage))
            {
                ValidationMessage = "You have made changes to the factor language, this may no longer be at grade level you initially selected.";
                ShowMessage = String.Empty;
            }

            if (!String.IsNullOrEmpty(RefreshGrid))
            {
                enumFactorFormatType fft = (enumFactorFormatType)Enum.Parse(typeof(enumFactorFormatType), RefreshGrid);
                BindGrid(fft);
            }
        }

        #endregion

        #region [ Other Event Handlers ]

        private void BindGrid(enumFactorFormatType currentformat)
        {


            if (currentformat == enumFactorFormatType.FES)
            {
                BindFESFactorGrid();
                BindFesPositionGradePoint();
            }

            if (currentformat == enumFactorFormatType.GSSG)
            {
                BindGSSGFactorGrid();
                BindGssgPositionGradePoint();
            }

            if ((currentformat == enumFactorFormatType.Narrative) || (currentformat == enumFactorFormatType.NarrativeSupervisory))
            {
                BindNarrativeFactorGrid(currentformat);
            }

            //RefreshPage();
        }

        private void RefreshPage()
        {
            List<PositionFactor> positionfactors = PD.GetPositionFactor();

            setPageView();
            if (positionfactors.Count == 0)
            {
                btnSubmit.Enabled = false;
            }

        }
        #endregion

        #region [ Properties ]

        private string ValidationMessage
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    lblValidationMessage.Text = String.Empty;
                    pnlValidationMessage.Visible = false;
                    lblValidationMessagebottom.Text = String.Empty;
                    pnlValidationMessagebottom.Visible = false;
                }
                else
                {
                    lblValidationMessage.Text = value;
                    pnlValidationMessage.Visible = true;
                    lblValidationMessagebottom.Text = value;
                    pnlValidationMessagebottom.Visible = true;
                    lblValidationMessage.Focus();
                    string script = "scrolltoTop();";
                    ScriptManager.RegisterStartupScript(this.updateValidationMessage, typeof(string), "scrollToValSumm", script, true);   




                }
            }
        }

        private int UserID
        {
            get
            {
                if (ViewState["CurrentUserID"] == null)
                {
                    ViewState["CurrentUserID"] = base.CurrentUser.UserID;
                }

                return (int)ViewState["CurrentUserID"];
            }
        }

        private string RefreshGrid
        {
            get
            {
                return hdnRefreshGrid.Value;
            }
            set
            {
                hdnRefreshGrid.Value = value;
            }
        }

        private string ShowMessage
        {
            get
            {
                return hdnShowMessage.Value;
            }
            set
            {
                hdnShowMessage.Value = value;
            }
        }

        #endregion

        #region [ Fields ]

        private PositionDescription PD = new PositionDescription();
        PDStatus currentStatus = PDStatus.Null;
        //private RadAjaxManager radajaxmgr;


        #endregion
    }
}
