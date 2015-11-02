using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.Business.Series.Collections;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

using Telerik.Web.UI;

using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet;

namespace HCMS.PDExpress.Controls.CreatePD.Occupation
{
    public partial class Occupation : CreatePDUserControlBase
    {
        #region [ Protected Page Events ]
        protected override void OnInit(EventArgs e)
        {
            this.ddlPayPlan.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlPayPlan_SelectedIndexChanged);
            this.ddlJobSeries.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlJobSeries_SelectedIndexChanged);
            this.ddlProposedGrade.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlProposedGrade_SelectedIndexChanged);
            this.ddlFullGrade.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlFullGrade_SelectedIndexChanged);
            this.ddlOtherProposed.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlOtherProposed_SelectedIndexChanged);
            this.ddlOPMJobTitle.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlOPMJobTitle_SelectedIndexChanged);
            this.ddlPositionType.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlPositionType_SelectedIndexChanged);
            this.chkInterdisc.CheckedChanged += new EventHandler(chkInterdisc_CheckedChanged);
            //this.ddlOrgCode.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlOrgCode_SelectedIndexChanged);

            this.btnContinue.Click += new EventHandler(btnContinue_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
            this.btnShowExistingPDs.Click += new EventHandler(btnShowExistingPDs_Click);

            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    this.WarningShown = false;
                    loadData();
                }
                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region [ Private Methods ]

        private bool filterOtherItem(ListItem listItem)
        {
            return listItem.Value == "100";
        }

        private bool filterOtherRadComboBoxItem(RadComboBoxItem listItem)
        {
            return listItem.Value == "100";
        }

        private bool filterSODProposedGrade(RadComboBoxItem listItem)
        {
            return Convert.ToInt32(listItem.Value) >= base.CurrentPD.ProposedFPGrade;
        }
        private bool filterOtherSODProposedGrade(RadComboBoxItem listItem)
        {
            return (Convert.ToInt32(listItem.Value) >= base.CurrentPD.ProposedFPGrade);
        }

        /// <summary>
        /// Sets the ddlPositionType visibility to false.
        /// Selects "NEITHER" as option in ddlPositionType.
        /// Sets literalPositionType visibility to true. 
        /// For New PD - sets the rowProposedGrade visibility to false.
        /// For Non New PD- disables ddlProposedGrade.        
        /// </summary>
        /// <param name="isNewPD"></param>
        private void prepareCLForm(bool isNewPD)
        {

            this.ddlPositionType.Visible = false;
            this.literalPositionType.Visible = true;
            if (isNewPD)
            {
                this.rowProposedGrade.Visible = false;
            }
            else
            {
                this.ddlProposedGrade.Enabled = false;
            }
            // pre-select "NEITHER" for Position Type
            ControlUtility.SafeListControlSelect(this.ddlPositionType, (int)enumPositionType.Neither);
        }
        /// <summary>
        /// Steps: 
        /// 1.Checks if PD is new PD/not
        /// 2.Checks if user needs to be redirected to Show Occupation difference page
        /// 3.Loads Pay Plan
        /// 4.Populates PD's Introduction
        /// 5.If new PD
        ///     5.1 clears job series dd and sets 'Select Job series' option as selected
        ///     5.2 clears grades and opm title dropdowns, sets UseNonProposedGrade to false, set visibility of Other panels to false
        ///     5.3 sets txtFPPSID text to empty string 
        ///     5.4 sets txtAdditionalSeries text to empty string
        ///     5.4 sets txtAdditionalSeries and lblAdditionalSeries visibility to false
        ///     5.5 sets txtAdditionalSeriesreqval enabled to false
        ///     5.6 sets spn68 and ToolTip68 visiblity to false  -- help related to ID pd
        ///     5.7 sets chkInterdisc checked to false
        /// 6.Hides/Shows hlShowDiffs link that shows Occupation changed report
        /// 7.Loads all position types in ddlPositionType
        /// 8.Loads ddlOrgcode with list of orgcodes assigned to current user
        /// 9.Enables/Disables ddlPayPlan - enables if new PD
        /// 10.For CL - hides ddlPositionType and disables ddlProposedGrade
        /// 11.For Non-New PD
        ///     11.1 Shows ctrlCreatePDWorkflowNote
        ///     11.2 Selects current pds pay plan in ddlPayPlan
        ///     11.3 Selects current pds position type in ddlPositionType
        ///     11.4 Selects current pds organization code in ddlorganizationcode
        ///     11.5 Sets hiddenOrgCode.Value to current pds organization code
        ///     11.6 Sets lblPDNumberValue.Text to current pds Positiondescriptionid
        ///     11.7 Sets txtFPPSPDID.text to current pds FPPSPDID
        ///     11.8 Loads ddlJobSeries with list of job series associated with current pds pay plan
        ///     11.9 Calls loadGradesAndOPMTitle with current pd's job series
        ///     11.10 Select the current jobseries in the ddlJobSeries
        ///     11.11 Sets txtFWSPositionTitle.text with current pd's agency position title
        ///     11.12 Sets txtEqualEmploymentStatement.text with current pd's EEOD statement
        ///     11.13 Sets chkInterdisc.checked to currentPD.isInterdisciplinary
        ///     11.14 Based on currentPD.IsInterDisciplinary
        ///             --sets visibility of lblAdditionalSeries,txtAdditionalSeries,ToolTip68,spn68
        ///             --sets the text and enablity of txtAdditionalSeries
        ///     11.15 Calls SetReadOnlyFields() which - Disables/Enables Fields and buttons based on PD mode(Readonly/not),workflow status,type
        ///     11.16 Calls showEqualOpportunityStatement -based on position type     
        /// </summary>
        private void loadData()
        {
            bool isNewPD = base.CurrentPDID == NULLPDID;
            //redirecting user to Show Occupation difference screen in revise
            CheckToRedirectToShowDiff();
            // load dropdowns needed for new and existing PD's
            loadPayPlan(isNewPD);
            //populates introduction
            ControlUtility.SafeTextBoxAssign(txtIntroduction, base.CurrentPD.GetIntroduction());

            if (isNewPD)
            {
                clearJobSeries();
                clearGradesAndOPMTitle();
                this.txtFPPSID.Text = string.Empty;
                this.chkInterdisc.Checked = false;
                this.lblAdditionalSeries.Visible = false;
                this.txtAdditionalSeries.Text = string.Empty;
                this.txtAdditionalSeries.Visible = false;
                this.ToolTip68.Visible = false;
                this.spn68.Visible = false;
                this.txtAdditionalSeriesreqval.Enabled = false;
            }
            //Hides/Shows hlShowDiffs link that shows Occupation changed report
            SetShowDiffVisibility(isNewPD);
            //loads all position types in ddlPositionType
            loadPositionType();
            //loads the ddlOrgcode with list of orgcodes assigned to current user
            loadOrgCodes(isNewPD);

            // toggle enabling of controls
            this.ddlPayPlan.Enabled = isNewPD;
            //this.ddlPositionType.Enabled = isNewPD;


            // check to see if this is a Career Ladder and set the ddlPositionType visibility to false and disable ddlProposedGrade
            if ((Request.QueryString["type"] != null && Request.QueryString["type"] == "cl") ||
               (!isNewPD && this.IsCareerLadder))
            {
                prepareCLForm(isNewPD);
            }

            if (!isNewPD)
            {
                // existing PD
                this.ctrlCreatePDWorkflowNote.Visible = true;
                ControlUtility.SafeListControlSelect(ddlPayPlan, base.CurrentPD.PayPlanID);
                ControlUtility.SafeListControlSelect(ddlPositionType, base.CurrentPD.PositionTypeID);
                ControlUtility.SafeListControlSelect(ddlOrgCode, base.CurrentPD.OrganizationCodeID.ToString());
                hiddenOrgCode.Value = base.CurrentPD.OrganizationCode.ToString();
                this.lblPDNumberValue.Text = base.CurrentPD.PositionDescriptionID.ToString();
                ControlUtility.SafeTextBoxAssign(this.txtFPPSID, base.CurrentPD.FPPSPDID);
                //loads the ddlJobSeries based on payplanid
                loadJobSeries(base.CurrentPD.PayPlanID);

                loadGradesAndOPMTitle(base.CurrentPD.JobSeries);

                ControlUtility.SafeListControlSelect(ddlJobSeries, base.CurrentPD.JobSeries);
                ControlUtility.SafeTextBoxAssign(this.txtFWSPositionTitle, Server.HtmlDecode(base.CurrentPD.AgencyPositionTitle));
                ControlUtility.SafeTextBoxAssign(this.txtEqualEmploymentStatement, Server.HtmlDecode(base.CurrentPD.EEODStatement));
                this.chkInterdisc.Checked = base.CurrentPD.IsInterdisciplinaryPD;
                if (base.CurrentPD.IsInterdisciplinaryPD)
                {
                    this.lblAdditionalSeries.Visible = true;
                    this.txtAdditionalSeries.Visible = true;
                    ControlUtility.SafeTextBoxAssign(this.txtAdditionalSeries, Server.HtmlDecode(base.CurrentPD.AdditionalSeries));
                    this.ToolTip68.Visible = true;
                    this.spn68.Visible = true;
                    this.txtAdditionalSeriesreqval.Enabled = true;
                }
                else
                {
                    this.lblAdditionalSeries.Visible = false;
                    this.txtAdditionalSeries.Visible = false;
                    this.ToolTip68.Visible = false;
                    this.spn68.Visible = false;
                    this.txtAdditionalSeriesreqval.Enabled = false;
                    //added this to support reset click
                    this.txtAdditionalSeries.Text = string.Empty;
                }
                SetReadOnlyFields();
            }
            showEqualOpportunityStatement();
        }

        #region "Changes related to Review Permission To HR"
        /// <summary>
        /// Shows/Hides hlShowDiffs link that shows occupation changed report
        /// Dispaly hlShowDiffs link if the PD is in revise/final review and if PD has occupation changes made by HR during review
        /// Hides hlShowDiffs link if the PD is new PD/if the PD does not have occupation changes made by HR during review 
        /// </summary>
        /// <param name="isNewPD"></param>
        private void SetShowDiffVisibility(bool isNewPD)
        {
            if (isNewPD)
            {
                hlShowDiffs.Visible = false;
            }
            else
            {
                if ((CurrentPDStatus == PDStatus.Revise || CurrentPDStatus == PDStatus.FinalReview) && (CurrentPD.HasOccupationChangedDuringReview(false)))
                {
                    hlShowDiffs.Visible = true;
                }
                else
                {
                    hlShowDiffs.Visible = false;
                }
            }
        }
        /// <summary>
        /// It redirects the user to Show Occupation difference screen
        /// provided PD occupation was changed during review and PD is currently in revise and in edit mode and
        /// that occupation change review is not complete
        /// </summary>
        private void CheckToRedirectToShowDiff()
        {
            bool isNewPD = base.CurrentPDID == NULLPDID;
            if ((!isNewPD) && (!IsPDReadOnly) && (CurrentPDStatus == PDStatus.Revise))
            {
                if ((!CurrentPD.IsOccupationReviewComplete) && (CurrentPD.HasOccupationChangedDuringReview(false)))
                {
                    base.SafeRedirect("~/CreatePD/ShowOccupationDiff.aspx");
                }
            }
        }


        #endregion
        /// <summary>
        /// Disables/Enables Fields and buttons based on
        ///     --Is PD read-only
        ///     --current workflowStatus 
        ///     --current pd type - SOD/CL/CLSOD -- by calling SetEditableFields
        /// </summary>
        private void SetReadOnlyFields()
        {
            // set read-only fields/buttons
            bool okToUse = !base.IsPDReadOnly;
            bool isSOD = base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
            bool isCL = base.CurrentPDChoice == PDChoiceType.CareerLadderPD;
            bool isPDCreator = base.CurrentPD.PDCreatorID.Equals(base.CurrentUser.UserID);
            bool isPDCreatorSupervisor = base.isPDCreatorSupervisor(false);
            bool hasHRGroupPermission = okToUse && (base.HasPermission(enumPermission.CompleteHRCertification) || base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
                base.HasPermission(enumPermission.MaintainHRSection) || base.HasPermission(enumPermission.MaintainFactorRecommendation) ||
                base.HasPermission(enumPermission.PublishPD));
            PDStatus status = base.CurrentPD.GetCurrentPDStatus();
            if (base.IsPDReadOnly)
            {
                DisableFields();
                btnContinue.Enabled = btnReset.Enabled = false;
                txtFPPSID.Enabled = false;
            }
            else
            {
                switch (status)
                {
                    case PDStatus.Draft:
                    case PDStatus.Revise:
                    case PDStatus.Review:

                        bool isHMEnabled = (isPDCreator || isPDCreatorSupervisor);
                        bool isHREnabled = hasHRGroupPermission;
                        btnContinue.Enabled = btnReset.Enabled = okToUse && (isHMEnabled || isSOD || isHREnabled);
                        SetEditableFields();
                        break;

                    case PDStatus.FinalReview:
                        bool isEnabled = okToUse && hasHRGroupPermission;
                        btnContinue.Enabled = btnReset.Enabled = isEnabled; // okToUse  && (!isSOD || isCL);
                        DisableFields();
                        break;
                    default: //takes care of PUBLISHED Status as well
                        btnContinue.Enabled = btnReset.Enabled = okToUse && (!isSOD || isCL);
                        break;
                }
            }
        }
        /// <summary>
        /// Disables all fields on occupation screen
        /// </summary>
        private void DisableFields()
        {
            ddlProposedGrade.Enabled = false;
            ddlPayPlan.Enabled = false;
            ddlJobSeries.Enabled = false;
            ddlOtherProposed.Enabled = false;
            ddlFullGrade.Enabled = false;
            ddlOtherFull.Enabled = false;
            ddlOPMJobTitle.Enabled = false;
            txtFWSPositionTitle.Enabled = false;
            ddlPositionType.Enabled = false;
            ddlOrgCode.Enabled = false;
            txtEqualEmploymentStatement.Enabled = false;
            chkInterdisc.Enabled = false;
            txtAdditionalSeries.Enabled = false;
            txtAdditionalSeriesreqval.Enabled = false;
        }
        /// <summary>
        /// Enables/Disables controls for SOD/CL/CLSOD
        /// For SOD following controls are disabled
        ///     -ddlPayPlan,ddlJobSeries,ddlFullGrade,ddlOtherFull,txtFWSPositionTitle,ddlPositionType,chkInterdisc,txtAdditionalSeries
        ///     --if UseNonStandardGrade=false then ddlOtherProposed        ///     
        /// For CL/CLSOD -if Ladder is generated then following controls are disabled
        ///     --ddlPayPlan,ddlJobSeries,ddlProposedGrade,ddlFullGrade,ddlOtherProposed,ddlOtherFull,ddlPositionType,txtEqualEmploymentStatement        ///
        /// </summary>
        private void SetEditableFields()
        {
            bool isSOD = base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
            bool isCL = base.CurrentPDChoice == PDChoiceType.CareerLadderPD;
            bool isCLSOD = base.CurrentPDChoice == PDChoiceType.CLStatementOfDifferencePD;

            if (isSOD)
            {

                ddlPayPlan.Enabled = false;
                ddlJobSeries.Enabled = false;
                if (this.UseNonStandardGrade)
                {
                    ddlOtherProposed.Enabled = true;
                }
                else
                {
                    ddlOtherProposed.Enabled = false;
                }
                ddlFullGrade.Enabled = false;
                ddlOtherFull.Enabled = false;
                //Enabling OPMTitle to support publishing the SODs created from existing PDs that did not have OPM compliant titles.
                //so that user can select the correct OPM title
                //ddlOPMJobTitle.Enabled = false;
                txtFWSPositionTitle.Enabled = false;
                ddlPositionType.Enabled = false;
                txtEqualEmploymentStatement.Enabled = false;
                chkInterdisc.Enabled = false;
                txtAdditionalSeries.Enabled = false;
                ddlOrgCode.Enabled = true;
                ddlProposedGrade.Enabled = true;
            }
            if (isCL || isCLSOD)
            {
                //if ladder generated or not
                bool isLadderGenerated = base.CurrentPD.LadderPosition >= 0;
                bool isFullPerformanceCL = (base.CurrentPD.LadderPosition == 0) || (base.CurrentPD.LadderPosition == -1);

                if (isFullPerformanceCL && !isLadderGenerated)
                {
                    ddlPayPlan.Enabled = true;
                    ddlJobSeries.Enabled = true;
                    ddlOtherProposed.Enabled = true;
                    ddlFullGrade.Enabled = true;
                    ddlOtherFull.Enabled = true;
                    ddlOPMJobTitle.Enabled = true;
                    txtFWSPositionTitle.Enabled = true;
                    ddlPositionType.Enabled = true;
                    ddlOrgCode.Enabled = true;
                    txtEqualEmploymentStatement.Enabled = true;
                }
                else
                {
                    ddlPayPlan.Enabled = false;
                    ddlJobSeries.Enabled = false;
                    ddlOtherProposed.Enabled = false;
                    ddlFullGrade.Enabled = false;
                    ddlOtherFull.Enabled = false;
                    ddlPositionType.Enabled = false;
                    txtEqualEmploymentStatement.Enabled = false;
                    //this row is not shown when the PD is new 
                    //when the PD is not new this dd should be disabled
                    ddlProposedGrade.Enabled = false;

                    txtFWSPositionTitle.Enabled = true;
                    ddlOPMJobTitle.Enabled = true;
                    ddlOrgCode.Enabled = true;
                }
            }
        }

        private void loadPayPlan(bool isNewPD)
        {
            try
            {
                ControlUtility.BindRadComboBoxControl(ddlPayPlan, LookupWrapper.GetAllInUsePayPlans(true), null, "PayPlanTitle", "PayPlanID", "<<- Select Pay Plan ->>");
                if (isNewPD)
                {
                    this.ddlPayPlan.Items[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Loads list of job series in ddlJobSeries based on given pay plan id.
        /// Inserts 'Select Job Series' as first option
        /// Inserts 'No Associated Job Series' as first option, if there are no series associated with the given pay plan.
        /// </summary>
        /// <param name="payPlanID"></param>
        private void loadJobSeries(int payPlanID)
        {
            try
            {
                if (payPlanID == -1)
                {
                    this.ddlJobSeries.Items.Insert(0, new RadComboBoxItem("<<- Select Job Series ->>", "-1"));
                }
                // get Pay Plan Series for the specified Plan ID
                SeriesCollection seriesList = LookupWrapper.GetPayPlanSeries(true, payPlanID);

                if (seriesList.Count == 0)
                    setSingleDropDownItem(ddlJobSeries, "<<- No Associated Job Series ->>");
                else
                    ControlUtility.BindRadComboBoxControl(ddlJobSeries, seriesList, null, "DetailLine", "SeriesID", "<<- Select Job Series ->>");
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        /// <summary>
        /// Loads list of grades for the given jobSeriesID.
        /// Sets UseNonStandardGrade value to true if current pd's grade is not in given job series grade range. 
        ///     -For Non CL- if current pd's Proposed grade is not with in the given job series grade range.
        ///     -For CL- if current pd's Proposed Full performance grade is not with in the given job series grade range.
        /// Loads OtherProposedGrade and OtherFullPerformancegrade if UseNonStandardGrade=true
        /// Hides Other grade related panels if UseNonStandardGrade=false
        /// Calls loadProposedGrade with current seriesgradelist
        /// Calls loadPerformanceGrade with current seriesgradelist
        /// Calls loadOPMJobTitle with current jobseries
        /// </summary>
        /// <param name="jobSeriesID"></param>
        private void loadGradesAndOPMTitle(int jobSeriesID)
        {
            try
            {
                // get Series object for the specified Job Series ID
                GradeCollection seriesGradeList = null;
                Series series = new Series();
                series.SeriesID = jobSeriesID;

                // get a list of grades for the specific job series
                seriesGradeList = series.GetGrades();

                this.UseNonStandardGrade = base.CurrentPDID != NULLPDID &&
                    (
                    (this.IsCareerLadder && !seriesGradeList.Contains(base.CurrentPD.ProposedFPGrade)) ||
                    (!this.IsCareerLadder && !seriesGradeList.Contains(base.CurrentPD.ProposedGrade))
                    );


                if (this.UseNonStandardGrade)
                {
                    loadOtherProposedGrade();
                    loadOtherPerformanceGrade();
                }
                else
                {
                    panellblOtherProposed.Visible = false;
                    panellblOtherFull.Visible = false;
                    panelddlOtherProposed.Visible = false;
                    panelddlOtherFull.Visible = false;
                }
                loadProposedGrade(seriesGradeList);

                loadPerformanceGrade(seriesGradeList);


                loadOPMJobTitle(jobSeriesID);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        /// <summary>
        /// Clears ddlProposedGrade and sets its selected value to null
        /// Fills the ddlProposedGrade with given seriesGradeList with following filters
        ///     - For SOD filters grades that are lower than full performance grade
        /// Adds "Other" as option in the item list with value ="100"
        /// Sets the first item in the list as follows
        ///     -sets 'Select Proposed Grade' string as first item in the list
        ///     -For CL full pd, with non standard proposed grade,sets that grade as first item in the list 
        /// Sets UseNonStandardGrade=true for SOD PD when only option available to select is "Other"
        /// Displays the following item as selected
        ///      - when UseNonStandardGrade is true - then other
        ///      - otherwise current pd's proposed grade
        /// Displays Other dropdownlist and panels if UseNonStandardGrade=true
        /// </summary>
        /// <param name="seriesGradeList"></param>
        private void loadProposedGrade(GradeCollection seriesGradeList)
        {
            try
            {     //filter list for SOD to be less than FUll GRADE
                ddlProposedGrade.Items.Clear();
                ddlProposedGrade.SelectedValue = null;
                PositionDescription thisPD = base.CurrentPD;
                int calcProposedGrade = -1;
                if (this.IsSOD)
                {
                    ControlUtility.BindRadComboBoxControl(ddlProposedGrade, seriesGradeList, new ControlUtility.RadComboBoxItemFilter(filterSODProposedGrade), "GradeID", "GradeID", null, base.CurrentPD.ProposedGrade.ToString());

                }
                else
                {
                    //career ladder - ladder  pds having proposed grade out of seriesGradeList range.
                    if ((IsCareerLadder && thisPD.LadderPosition > 0) && (!seriesGradeList.Contains(thisPD.ProposedGrade)))
                    {
                        calcProposedGrade = thisPD.ProposedGrade;
                        ControlUtility.BindRadComboBoxControl(ddlProposedGrade, seriesGradeList, null, "GradeID", "GradeID", calcProposedGrade.ToString());
                    }
                    else
                    {
                        ControlUtility.BindRadComboBoxControl(ddlProposedGrade, seriesGradeList, null, "GradeID", "GradeID", "<<- Select Proposed Grade ->>");
                    }
                }

                ddlProposedGrade.Items.Add(new RadComboBoxItem("Other", "100"));

                //added this because if the SOD is created off of a FPL that has proposed grade that is 
                //lowest available, and we are filtering all the proposed grades that are equal and higer than fpl proposed grade for SOD,
                //the only option available for SOD will be "Other" - in that case system needs to know that 
                //this SOD PD needs to use non standard grade.
                if (this.IsSOD)
                {
                    if (ddlProposedGrade.Items.Count == 1 && ddlProposedGrade.Items[0].Value == "100")
                    {
                        this.UseNonStandardGrade = true;

                    }
                }


                if (calcProposedGrade < 0)
                {
                    ControlUtility.SafeListControlSelect(ddlProposedGrade, this.UseNonStandardGrade ? "100" : base.CurrentPD.ProposedGrade.ToString());
                }

                //this is add on to the SOD add on

                if (this.UseNonStandardGrade)
                {
                    loadOtherProposedGrade();
                    loadOtherPerformanceGrade();

                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        /// <summary>
        /// Clears ddlFullGrade and sets its selected value to null
        /// Gets current proposed grade value.
        /// Populates ddlFullGrade with provided SeriesGradeList
        /// For CL and CLSOD adds "Other" as option 
        /// Removes all grades from the ddlFullGrade that are lower than current proposed grade
        /// Disables ddlFullGrade for SOD PD/ non CL PD with non standard grade
        /// For SOD/CLSOD PD, if the current fp grade is non standard grade, then inserts that grade to the ddlFullGrade list so that it is available to be selected
        /// For Non SOD/Non CLSOD PD, shows the current pd's fp grade if present as selected, otherwise shows current pd's proposed grade as selected
        /// Calls updatePanelFullGrade.update
        /// </summary>
        /// <param name="seriesGradeList"></param>
        private void loadPerformanceGrade(GradeCollection seriesGradeList)
        {
            try
            {
                //added clear() and selectedvalue=null code to prevent the error
                // that was generated when the gradelist changed and the ddlFullgrade had
                //reference to the selectedvalue that was different.
                ddlFullGrade.Text = string.Empty;
                ddlFullGrade.Items.Clear();
                ddlFullGrade.SelectedValue = null;
                int selectedProposedGradeValue = -1;
                if (ddlProposedGrade.SelectedValue.Length > 0)
                {
                    selectedProposedGradeValue = int.Parse(ddlProposedGrade.SelectedValue);
                }
                else if (base.CurrentPD.ProposedGrade > 0)
                {
                    selectedProposedGradeValue = base.CurrentPD.ProposedGrade;
                }
                ControlUtility.BindRadComboBoxControl(ddlFullGrade, seriesGradeList, null, "GradeID", "GradeID", "<<- Select Proposed Grade ->>");

                if ((this.IsCareerLadder) || (this.isCLSOD))
                {
                    ddlFullGrade.Items.Add(new RadComboBoxItem("Other", "100"));
                }
                else
                {
                    // get total number of items in ddlFullGrade
                    int count = ddlFullGrade.Items.Count;

                    //remove the grades that are lower than proposed grade from the full performance dropdown
                    for (int idx = 0; idx < count; idx++)
                    {
                        int fullValue = int.Parse(ddlFullGrade.Items[0].Value);

                        if (fullValue < selectedProposedGradeValue)
                        {
                            ddlFullGrade.Items.Remove(0);
                        }
                        else
                            break;
                    }
                }
                //added condition if this is SOD otherwise it was changing
                //SOD Fullperformance grade to proposed grade and which should not happen
                if ((!this.IsCareerLadder && selectedProposedGradeValue == 100) || (this.IsSOD))
                    ddlFullGrade.Enabled = false;


                if ((this.IsSOD) || (this.isCLSOD))
                {
                    // added this check to support following scenario 
                    // when SOD's full performance grade is nonstandard but the proposed grade was from
                    // the standard list, in such case, UseNonStandardGrade will be false, but since the
                    // FP grade is non standard, it won't be in the series grade list and therefore dropdown will not
                    // show the FP grade. To avoid this, add FP grade to series grade list and there by the system will
                    // automatically select it.

                    if (!seriesGradeList.Contains(CurrentPD.ProposedFPGrade))
                    {
                        string strProposedFPGradeVal = CurrentPD.ProposedFPGrade.ToString();

                        ddlFullGrade.Items.Add(new RadComboBoxItem(strProposedFPGradeVal, strProposedFPGradeVal));
                    }
                    ControlUtility.SafeListControlSelect(ddlFullGrade, this.UseNonStandardGrade ? "100" : CurrentPD.ProposedFPGrade.ToString());


                }
                else
                {//added check to see both fp and proposed grade.
                    //because if fp is present the dd should show fp as selected or should show proposed grade as selected (this can happen when PD is new)
                    string strPropGradeValue = (selectedProposedGradeValue == -1) ? string.Empty : selectedProposedGradeValue.ToString();
                    string strFPGradeValue = (base.CurrentPD.ProposedFPGrade > 0) ? base.CurrentPD.ProposedFPGrade.ToString() : strPropGradeValue;

                    ControlUtility.SafeListControlSelect(ddlFullGrade, this.UseNonStandardGrade ? "100" : strFPGradeValue);
                }

                updatePanelFullGrade.Update();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        /// <summary>
        /// Only for Non Career Ladder PDs
        /// Makes the panel and ddlOtherProposed visibile
        /// Enables ddlOtherPropsoed
        /// Populates ddlOtherProposed with all grades filtering some
        ///     - For SOD PD filters grades above full performance grade and "Other"
        ///     - For rest of the  PDs filters "Other"
        /// Selects Current PD's proposed grade
        /// </summary>
        private void loadOtherProposedGrade()
        {
            try
            {
                if (!this.IsCareerLadder)
                {
                    panellblOtherProposed.Visible = panelddlOtherProposed.Visible = true;
                    ddlOtherProposed.Items.Clear();
                    ddlOtherProposed.Enabled = true;
                    ddlOtherProposed.SelectedValue = null;
                    if (IsSOD) //filter otherproposed by displaying only grades lower than current full performance and also filtering other
                    {

                        ControlUtility.BindRadComboBoxControl(ddlOtherProposed, LookupWrapper.GetAllGrades(false), new ControlUtility.RadComboBoxItemFilter(filterOtherSODProposedGrade), "GradeID", "GradeID");

                    }
                    else
                    {
                        ControlUtility.BindRadComboBoxControl(ddlOtherProposed, LookupWrapper.GetAllGrades(false), new ControlUtility.RadComboBoxItemFilter(filterOtherRadComboBoxItem), "GradeID", "GradeID");
                    }
                    ControlUtility.SafeListControlSelect(ddlOtherProposed, base.CurrentPD.ProposedGrade.ToString());

                    updatePanellblOtherProposed.Update();
                    updatePanelddlOtherProposed.Update();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        /// <summary>
        /// Only for Non Career Ladder PDs
        /// Populates ddlOtherFull with all grades except "Other"
        /// Gets current ddlOtherProposed value
        /// Removes all grades from ddlOtherFull that are lower than current ddlOtherProposed value
        /// Selects current PD's proposed fp grade        /// 
        /// Makes the panellblOtherFull and panelddlOtherFull visibile
        /// </summary>
        private void loadOtherPerformanceGrade()
        {
            try
            {
                ControlUtility.BindRadComboBoxControl(ddlOtherFull, LookupWrapper.GetAllGrades(false), new ControlUtility.RadComboBoxItemFilter(filterOtherRadComboBoxItem), "GradeID", "GradeID");
                int selectedOhterProposoedGradeValue = -1;
                if (!this.IsCareerLadder)
                {

                    //added check to see the selectedvalue is not an empty string                  
                    if (ddlOtherProposed.SelectedValue.Length > 0)
                    {
                        selectedOhterProposoedGradeValue = int.Parse(ddlOtherProposed.SelectedValue);
                    }

                    int count = ddlOtherFull.Items.Count;
                    //removing grades that are lower than proposed grade
                    for (int idx = 0; idx < count; idx++)
                    {
                        int otherFullValue = int.Parse(ddlOtherFull.Items[0].Value);

                        if (otherFullValue < selectedOhterProposoedGradeValue)
                            ddlOtherFull.Items.Remove(0);
                        else
                            break;
                    }
                }
                //selecting current PD's proposedfpgrade
                ControlUtility.SafeListControlSelect(ddlOtherFull, base.CurrentPD.ProposedFPGrade.ToString());
                panellblOtherFull.Visible = panelddlOtherFull.Visible = true;
                updatePanellblOtherFull.Update();
                updatePanelddlOtherFull.Update();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }


        /// <summary>
        /// Gets list of opm titles associated with given seriesID and populates ddlOPMJobTitle with it
        /// Sets or inserts the first item/topoption in the list as follows
        ///     -For New PD, sets topoption as 'Select OPM Title'
        ///     -For Non new PD,if PD's title exists in the list,then it sets topoption as null
        ///     -For Non new PD,if PD's title does not exist and if PD is read only, then it sets topoption as PD's title
        ///     -For Non new PD, if PD's title does not exist and if PD is not read-only, then it sets topoption as 'Select OPM Title'
        /// Displays Following item as selected
        ///     -For New PD,selects 'Select OPM Title' option 
        ///     -For Non new PD, selects the PD's title if exists. 
        ///     -For Non new PD, if the PD's title does not exist in the list and if PD is read-only then it selects current PD's title
        ///     -For Non new PD, if the PD's title does not exist in the list and if PD is not read-only then selects 'Select OPM Title'
        ///     
        /// </summary>
        /// <param name="seriesID"></param>
        private void loadOPMJobTitle(int seriesID)
        {
            try
            {
                SeriesOPMTitleCollection OPMTitleList = LookupWrapper.GetSeriesOPMTitle(true, seriesID);
                bool isNewPD = base.CurrentPDID == NULLPDID;

                if (!isNewPD)
                {
                    bool containsOPMTitle = OPMTitleList.Contains(base.CurrentPD.OPMJobTitle);

                    if (containsOPMTitle)
                    {
                        //changed the top option from base.CurrentPD.OPMJobTitle to "Select OPM Title". Otherwise it was duplicating the same title in dropdownlist.
                        ControlUtility.BindRadComboBoxControl(ddlOPMJobTitle, OPMTitleList, null, "SeriesOPMTitleName", "SeriesOPMTitleName", null, base.CurrentPD.OPMJobTitle);
                    }
                    //added this for the PDs that are not new and have non-opm compliant titles to display the non opm compliant title
                    // this is only for Read-only PDs. If user is trying to edit the PD, then user will have to select the
                    // OPM compliant title.
                    else if (!containsOPMTitle)
                    {
                        if (IsPDReadOnly)
                        {
                            ControlUtility.BindRadComboBoxControl(ddlOPMJobTitle, OPMTitleList, null, "SeriesOPMTitleName", "SeriesOPMTitleName", base.CurrentPD.OPMJobTitle, base.CurrentPD.OPMJobTitle);
                        }
                        else
                        {
                            ControlUtility.BindRadComboBoxControl(ddlOPMJobTitle, OPMTitleList, null, "SeriesOPMTitleName", "SeriesOPMTitleName", "<<- Select OPM Title ->>", base.CurrentPD.OPMJobTitle);

                        }

                    }

                }
                else
                {
                    ControlUtility.BindRadComboBoxControl(ddlOPMJobTitle, OPMTitleList, null, "SeriesOPMTitleName", "SeriesOPMTitleName", "<<- Select OPM Title ->>", base.CurrentPD.OPMJobTitle);
                }

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        /// <summary>
        /// loads all position types in ddlPositionType
        /// </summary>
        private void loadPositionType()
        {
            try
            {
                ControlUtility.BindRadComboBoxControl(ddlPositionType, LookupWrapper.GetAllPositionTypes(true), null, "PositionTypeName", "PositionTypeID", "<<- Select Position Type ->>");
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        /// <summary>
        /// Gets organization code list that is assigned to the current user, and populates ddlOrgcode with it.
        /// Inserts 'Select Organization Code' as the first-item in the list.
        /// For Read-only PD - sets/displays orgcode of the current PD as selected - (Even if the user does not have access to PD's orgcode).
        /// For New PD - sets the first item  'Select Organization Code' as selected.
        /// For a standard PD - disables ddlOrgCodereqval and removes the required indicator from spnOrgCodeReqVal.
        /// </summary>
        /// <param name="isNewPD"></param>
        private void loadOrgCodes(bool isNewPD)
        {
            try
            {
                OrganizationCodeCollection assignedOrganizationList = CurrentUser.GetAssignedOrganizationCodes();
                //If user does not have access to PD's orgcode, and PD is read-only then show the current pd's orgcode selected
                if ((base.IsPDReadOnly) && (!isNewPD) && (!assignedOrganizationList.Contains(base.CurrentPD.OrganizationCodeID)))
                {
                    OrganizationCode currentorgcode = new OrganizationCode(base.CurrentPD.OrganizationCodeID);
                    string preselval = currentorgcode.DetailLineLegacy;
                    ControlUtility.BindRadComboBoxControl(ddlOrgCode, assignedOrganizationList, null, "DetailLineLegacy", "OrganizationCodeID", preselval,preselval);
                }
                else
                {
                    //non new PDs that are not read-only - fill the ddlorgcode with user's assigned orgcode list and set the first item of the list as "<<- Select Organization Code ->>"
                    ControlUtility.BindRadComboBoxControl(ddlOrgCode, assignedOrganizationList, null, "DetailLineLegacy", "OrganizationCodeID", "<<- Select Organization Code ->>");
                    //new PD select the first item - "<<- Select Organization Code ->>" 
                    if (isNewPD)
                    {
                        this.ddlOrgCode.Items[0].Selected = true;
                    }
                }
                if (base.IsStandardPD)
                {
                    ddlOrgCodereqval.Enabled = false;
                    ddlOrgCodereqval.ValidationGroup = String.Empty;
                    spnOrgCodeReqVal.InnerHtml = "<span class=\"required\"></span>&nbsp;";
                }
                else
                {
                    ddlOrgCodereqval.Enabled = true;
                    spnOrgCodeReqVal.InnerHtml = "<span class=\"required\">*</span>&nbsp;";
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        /// <summary>
        /// Clears job series dd and shows 'Select Job series' option as first option
        /// </summary>
        private void clearJobSeries()
        {
            try
            {
                ddlJobSeries.Items.Clear();
                this.ddlJobSeries.Items.Insert(0, new RadComboBoxItem("<<- Select Job Series ->>", "-1"));
                this.ddlJobSeries.Items[0].Selected = true;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        /// <summary>
        /// 1.Clears ddlProposedGrade, ddlFullGrade,ddlOtherProposedGrade,ddlOtherFull, and ddlOPMJobTitle
        /// 2.Sets First item as "Select respected item"
        /// 3.Sets txtFwsTitle's Text to empty string
        /// 4.Sets the visibility of other panels to false
        /// 5.Sets property - UseNonStandard to false
        /// </summary>
        private void clearGradesAndOPMTitle()
        {
            try
            {
                ddlProposedGrade.Items.Clear();
                ddlProposedGrade.SelectedValue = null;
                ddlFullGrade.Items.Clear();
                ddlFullGrade.SelectedValue = null;
                ddlFullGrade.Enabled = true;

                UseNonStandardGrade = false;
                ddlOtherProposed.Items.Clear();
                ddlOtherFull.Items.Clear();
                ShowOtherPanels(false);

                ddlOPMJobTitle.Items.Clear();
                ddlOPMJobTitle.Text = string.Empty;
                txtFWSPositionTitle.Text = String.Empty;

                //for RADCombobox reqfield validator to work 
                this.ddlProposedGrade.Items.Insert(0, new RadComboBoxItem("<<- Select Proposed Grade ->>", "-1"));
                this.ddlProposedGrade.Items[0].Selected = true;
                this.ddlFullGrade.Items.Insert(0, new RadComboBoxItem("<<- Select Proposed Grade ->>", "-1"));
                this.ddlFullGrade.Items[0].Selected = true;
                this.ddlOPMJobTitle.Items.Insert(0, new RadComboBoxItem("<<- Select OPM Title ->>", "-1"));
                this.ddlOPMJobTitle.Items[0].Selected = true;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void ShowOtherPanels(bool show)
        {
            panellblOtherFull.Visible = panelddlOtherFull.Visible = panellblOtherProposed.Visible = panelddlOtherProposed.Visible = show;
        }

        private void toggleProposedGradeDependentControls()
        {
            try
            {
                if (ddlProposedGrade.SelectedIndex != -1)
                {
                    int gradeID = int.Parse(ddlProposedGrade.SelectedValue);
                    bool visible = gradeID.Equals(100);

                    ShowOtherPanels(visible);
                    ddlFullGrade.Enabled = !visible;

                    //Disable if it is SOD
                    if (base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD)
                        ddlFullGrade.Enabled = false;

                    ControlUtility.SafeListControlSelect(this.ddlFullGrade, "100");
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        /// <summary>
        /// Sets txtEqualEmploymentStatement.text with value of EEOText in config file
        /// Toggles visibility of divEOS based on the position type --displays it For Managerial/Supervisory positions 
        /// </summary>
        private void showEqualOpportunityStatement()
        {
            try
            {
                int positionTypeSelection = Convert.ToInt32(this.ddlPositionType.SelectedValue);
                bool EOSVisible = (positionTypeSelection == (int)enumPositionType.Managerial) || (positionTypeSelection == (int)enumPositionType.Supervisory);

                if (EOSVisible)
                {
                    if(String.IsNullOrEmpty(txtEqualEmploymentStatement.Text))
                    {
                        txtEqualEmploymentStatement.Text = ConfigWrapper.EEOText;
                    }
                }// Issue 1327 and 620 -- clear the EEO text if position is not supervisory or managerial
                else
                {
                    txtEqualEmploymentStatement.Text  = string.Empty;
                }
                string style = EOSVisible ? "block" : "none";
                divEOS.Style["display"] = style;
                updatePanelEOS.Update();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void assignValues(ref PositionDescription thisPD)
        {
            thisPD.FPPSPDID = this.txtFPPSID.Text;
            thisPD.PayPlanID = ControlUtility.GetDropdownValue(this.ddlPayPlan);
            thisPD.JobSeries = ControlUtility.GetDropdownValue(this.ddlJobSeries);
            int calcProposedGrade = -1;
            int calcFPGrade = -1;

            if (this.IsCareerLadder)
            {
                if (this.ddlFullGrade.SelectedValue.Equals("100"))
                    calcFPGrade = ControlUtility.GetDropdownValue(ddlOtherFull);
                else
                    calcFPGrade = ControlUtility.GetDropdownValue(ddlFullGrade);

                if ((thisPD.LadderPosition == 0 || thisPD.LadderPosition == -1))
                {
                    calcProposedGrade = calcFPGrade;
                }
                else
                {
                    calcProposedGrade = thisPD.ProposedGrade;
                }
            }
            else
            {
                if (this.ddlProposedGrade.SelectedValue.Equals("100"))
                {
                    calcProposedGrade = ControlUtility.GetDropdownValue(ddlOtherProposed);
                    calcFPGrade = ControlUtility.GetDropdownValue(ddlOtherFull);
                }
                else
                {
                    calcProposedGrade = ControlUtility.GetDropdownValue(ddlProposedGrade);
                    calcFPGrade = ControlUtility.GetDropdownValue(ddlFullGrade);

                }
            }

            thisPD.ProposedGrade = calcProposedGrade;
            thisPD.ProposedFPGrade = calcFPGrade;

            thisPD.OPMJobTitle = this.ddlOPMJobTitle.Text;
            thisPD.AgencyPositionTitle = this.txtFWSPositionTitle.Text;
            int selectedorgcode = ControlUtility.GetDropdownValue(this.ddlOrgCode);
            //if the current orgcode has changed, then change the introduction statement as well
            //plus because of this, if user changed the existing organization code's
            //introduction, it never was saved. -- issue 1317
            //commenting out this because this is done automatcally on ddlorgcode_selectedindexchanged.
            
            //if (!thisPD.OrganizationCodeID.Equals(selectedorgcode))
            //{
            //    OrganizationCode neworgcode = new OrganizationCode(selectedorgcode);
            //    thisPD.Introduction = neworgcode.Introduction;
            //}
            //assigning the value in the txtIntroduction to PD's introduction
            thisPD.Introduction = txtIntroduction.Text;
            thisPD.OrganizationCodeID = selectedorgcode;
            thisPD.PositionType = this.ddlPositionType.SelectedValue;
            thisPD.EEODStatement = this.txtEqualEmploymentStatement.Text;

            if (base.CurrentPDID == NULLPDID)
                thisPD.PositionDescriptionTypeID = (int)base.CurrentPDChoice; ;

            thisPD.IsStandardPD = base.IsStandardPD ? "Y" : "N";
            thisPD.PositionTypeID = ControlUtility.GetDropdownValue(this.ddlPositionType);

            thisPD.PDCreatorID = base.CurrentUser.UserID;
            thisPD.UpdatedByID = base.CurrentUser.UserID;
            thisPD.IsInterdisciplinaryPD = this.chkInterdisc.Checked;
            thisPD.AdditionalSeries = this.txtAdditionalSeries.Text;
        }

        private void setValRuleset(string Rulesetname)
        {
            try
            {
                foreach (IValidator validatorcontrol in Page.GetValidators(null))
                {
                    if (validatorcontrol is PropertyProxyValidator)
                    {
                        PropertyProxyValidator ctrl = (validatorcontrol as PropertyProxyValidator);
                        ctrl.RulesetName = Rulesetname;
                        ctrl.SourceTypeName = "HCMS.Business.PD.PositionDescription";
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private bool isPDValid()
        {
            bool isvalid = true;

            try
            {
                if (Page.IsValid)
                {
                    PositionDescription thisPD = base.CurrentPD;
                    ValidationResults results = null;

                    if (this.lblPDNumberValue.Text.Length == 0)
                    {
                        results = Validation.Validate<PositionDescription>(thisPD, "TestRuleset");
                        isvalid = results.IsValid;

                        if (!results.IsValid)
                        {
                            isvalid = false;
                            StringBuilder builder = new StringBuilder("Validation Errors");

                            foreach (ValidationResult result in results)
                                builder.AppendFormat("<br/>Error-{0}:{1}", result.Tag, result.Message);

                            string errormsg = builder.ToString();
                            base.PrintErrorMessage(errormsg, true);
                        }
                    }
                }
                else
                {
                    isvalid = false;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            return isvalid;
        }

        #endregion

        #region [ Protected Control Event Handlers ]

        private void setSingleDropDownItem(DropDownList dropDown, string itemDisplay)
        {
            dropDown.Items.Clear();
            dropDown.Items.Add(new ListItem(itemDisplay, "-1"));
        }

        private void setSingleDropDownItem(RadComboBox dropDown, string itemDisplay)
        {
            dropDown.Items.Clear();
            dropDown.Items.Add(new RadComboBoxItem(itemDisplay, "-1"));
        }

        private void ddlPayPlan_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                int payPlanID = int.Parse(ddlPayPlan.SelectedValue);

                if (payPlanID != -1)
                {
                    loadJobSeries(payPlanID);
                }
                else
                {
                    clearJobSeries();
                }

                if (this.ddlJobSeries.SelectedIndex == -1 || this.ddlJobSeries.SelectedIndex == 0)
                {
                    clearGradesAndOPMTitle();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void ddlJobSeries_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                clearGradesAndOPMTitle();

                if (this.ddlJobSeries.SelectedIndex != -1 && this.ddlJobSeries.SelectedIndex != 0)
                {
                    loadGradesAndOPMTitle(int.Parse(this.ddlJobSeries.SelectedValue));
                }

                Message.SetMessage();

                if (base.CurrentPD.PositionDescriptionID != -1)
                {
                    Message.SetMessage("Job Series", "You just selected a new Job Series.<br/> This might have caused the Factors to become invalid for this Position Description.");
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void ddlProposedGrade_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                //disable full pf grade if sod
                //hide/show other grade panel
                toggleProposedGradeDependentControls();

                if (ddlProposedGrade.SelectedIndex != -1)
                {
                    int gradeID = int.Parse(ddlProposedGrade.SelectedValue);

                    if (gradeID != 100) // NOT 'Other'
                    {
                        int seriesID = int.Parse(ddlJobSeries.SelectedValue);
                        Series currentSeries = new Series();

                        currentSeries.SeriesID = seriesID;
                        GradeCollection seriesGrades = currentSeries.GetGrades();
                        loadPerformanceGrade(seriesGrades);
                    }
                    else
                    {

                        loadOtherProposedGrade();

                        if (!this.IsCareerLadder)
                            loadOtherPerformanceGrade();
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void ddlFullGrade_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (this.IsCareerLadder)
            {
                try
                {
                    if (ddlFullGrade.SelectedValue.Equals("100"))
                    {
                        // Other selected
                        loadOtherPerformanceGrade();
                    }
                }
                catch (Exception ex)
                {
                    base.HandleException(ex);
                }
            }
        }

        private void ddlOtherProposed_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                loadOtherPerformanceGrade();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void ddlOPMJobTitle_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (ddlOPMJobTitle.SelectedIndex != -1 && ddlOPMJobTitle.SelectedIndex != 0)
                {
                    //changing the FWS title once they change the OPM title
                    //if (String.IsNullOrEmpty(txtFWSPositionTitle.Text))
                    //{
                    ControlUtility.SafeTextBoxAssign(txtFWSPositionTitle, ddlOPMJobTitle.SelectedItem.Text);
                    //}
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void ddlPositionType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                showEqualOpportunityStatement();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void ddlOrgCode_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (ddlOrgCode.SelectedIndex != -1)
            {
                bool isNewPD = base.CurrentPDID == NULLPDID;
                int selectedOrgCode = Convert.ToInt32(ddlOrgCode.SelectedValue);
                if (!isNewPD)
                {
                    OrganizationCodeCollection ogc = base.CurrentPDCreator.GetAssignedOrganizationCodes();
                    string oldValue = hiddenOrgCode.Value;
                    bool hasAccess = ogc.Contains(selectedOrgCode);
                    string sorg = ddlOrgCode.ClientID;
                    if (!hasAccess)
                    {
                        Message.SetMessage("Organization Code", "You have selected an Organization Code that the PD Creator does not have access.<br/> Proceeding with this change will result in the PD Creator no longer having access to this PD.");
                    }
                    else
                    {
                        Message.SetMessage();
                    }
                }
                #region confirmchange

                //    if (!hasAccess)
                //    {
                //        hiddenHasAccess.Value = hasAccess.ToString();
                //        string strScript = "Sys.Application.add_load(function() { ShowConfirmOrgCode('" + e.OldText + "', '" + sorg + "') });";
                //        //string orgcodefunctioncall=string.Format ("OnOrgCodeChange({0},{1});",ddlOrgCode ,e);
                //        //string strScript = "Sys.Application.add_load(function() {" + orgcodefunctioncall + "});";
                //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "OrgCodePopup", strScript, true);
                //    }
                //    else
                //    {
                //        hiddenOrgCode.Value = selectedOrgCode.ToString();
                //        OrganizationCode currentOrgcode = new OrganizationCode(selectedOrgCode);
                //        ControlUtility.SafeTextBoxAssign(txtIntroduction, currentOrgcode.Introduction);
                //    }


                #endregion

                OrganizationCode currentOrgcode = new OrganizationCode(selectedOrgCode);
                ControlUtility.SafeTextBoxAssign(txtIntroduction, currentOrgcode.Introduction);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                Message.SetMessage();

                if (isPDValid())
                {
                    try
                    {
                        PositionDescription thisPD = base.CurrentPD;
                        PositionWorkflowStatus currentWorkflowStatus = new PositionWorkflowStatus();

                        assignValues(ref thisPD);

                        bool saveAndContinue = true;

                        if (!(this.IsCareerLadder || this.IsStandardPD)) // do not show the similar pd exist warning for career ladder and standard pds
                        {
                            if (!this.WarningShown)
                            {
                                if (currentWorkflowStatus.WorkflowStatusID == -1 && base.CurrentPDID == -1)
                                {
                                    // check if similar PDs exist
                                    bool similarPDsExist = thisPD.DoSimilarPositionDescriptionsExist();

                                    if (similarPDsExist)
                                    {
                                        RadWindow rdwin = this.ShowExistingMsgWin;
                                        rdwin.NavigateUrl = "~/CreatePD/ShowExistingConfirmation.aspx";
                                        rdwin.Title = "Warning";
                                        rdwin.VisibleOnPageLoad = true;
                                        this.WarningShown = true;
                                        saveAndContinue = false;
                                    }
                                }
                            }
                        }
                        if (saveAndContinue)
                        {
                            if (base.CurrentPDID == -1)
                            {
                                DateTime now = DateTime.Now;

                                currentWorkflowStatus.CreateDate = now;
                                currentWorkflowStatus.CreatedByID = CurrentUser.UserID;
                                currentWorkflowStatus.WorkflowStatusID = (int)PDStatus.Draft;
                                currentWorkflowStatus.IsCurrent = true;

                                thisPD.CheckedOutByID = base.CurrentUser.UserID;
                                thisPD.CheckOutDate = now;
                                if (thisPD.IsStandardPD.Equals("Y") && thisPD.OrganizationCodeID == -1)
                                {
                                    thisPD.OrganizationCodeID = 0;
                                }
                                thisPD.Add(currentWorkflowStatus);
                                base.CurrentPDID = thisPD.PositionDescriptionID;
                            }
                            else
                            {
                                thisPD.Update();
                                if ((
                                   (thisPD.PositionDescriptionTypeID == (int)PDChoiceType.NewPD)
                                    || (thisPD.PositionDescriptionTypeID == (int)PDChoiceType.NewStandardPD)
                                    || ((thisPD.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD) && (thisPD.LadderPosition == -1 || thisPD.LadderPosition == 0))


                                    ) && (!thisPD.HasFactorLanguage))
                                {
                                    thisPD.SetPositionClassificationStandard();

                                }
                            }

                            if (thisPD.PositionDescriptionTypeID == (int)PDChoiceType.CLStatementOfDifferencePD)
                                base.GoToPDLink("~/CreatePD/PositionCharacteristics.aspx");
                            else
                                base.GoToPDLink("~/CreatePD/Duties.aspx");
                        }
                    }
                    catch (Exception ex)
                    {
                        base.HandleException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Message.SetMessage();
                loadData();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void btnShowExistingPDs_Click(object sender, EventArgs e)
        {
            try
            {
                int jobSeries = int.Parse(this.ddlJobSeries.SelectedValue);
                int proposedGrade = -1;

                if (this.IsCareerLadder)
                    proposedGrade = ddlFullGrade.SelectedValue.Equals("100") ? int.Parse(this.ddlOtherFull.SelectedValue) : int.Parse(this.ddlFullGrade.SelectedValue);
                else
                    proposedGrade = ddlProposedGrade.SelectedValue.Equals("100") ? int.Parse(this.ddlOtherProposed.SelectedValue) : int.Parse(this.ddlProposedGrade.SelectedValue);

                string url = String.Format("~/Search/SearchReportsAdvanced.aspx?showPDAction=yes&jobSeries={0}&proposedGrade={1}&workflowStatus={2}", jobSeries, proposedGrade, (int)PDStatus.Published);
                base.SafeRedirect(url);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void chkInterdisc_CheckedChanged(object sender, EventArgs e)
        {
            this.lblAdditionalSeries.Visible = chkInterdisc.Checked;
            this.spn68.Visible = chkInterdisc.Checked;
            this.ToolTip68.Visible = chkInterdisc.Checked;
            this.txtAdditionalSeries.Visible = chkInterdisc.Checked;
            this.txtAdditionalSeriesreqval.Enabled = chkInterdisc.Checked;


        }
        #endregion

        #region [ Private Properties ]

        private bool WarningShown
        {
            get
            {
                if (Session[WARNING_SHOWN] == null)
                    Session[WARNING_SHOWN] = false;

                return (bool)Session[WARNING_SHOWN];
            }
            set
            {
                Session[WARNING_SHOWN] = value;
            }
        }

        private bool UseNonStandardGrade
        {
            get
            {
                if (ViewState["UseNonStandardGrade"] == null)
                    ViewState["UseNonStandardGrade"] = false;

                return (bool)ViewState["UseNonStandardGrade"];
            }
            set
            {
                ViewState["UseNonStandardGrade"] = value;
            }
        }

        private bool IsCareerLadder
        {
            get
            {
                return base.CurrentPDChoice == PDChoiceType.CareerLadderPD;
            }
        }

        private bool IsSOD
        {
            get
            {
                return base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
            }
        }
        private bool IsReadOnly
        {
            get { return base.IsPDReadOnly; }
        }
        private PDStatus CurrentPDStatus
        {
            get { return base.CurrentPD.GetCurrentPDStatus(); }
        }
        private Message.Message Message
        {
            get
            {
                return ctrlCreatePDMessage;
            }
        }

        #endregion

        #region [ Private Fields ]
        private const string WARNING_SHOWN = "WARNING_SHOWN";
        #endregion


    }
}
