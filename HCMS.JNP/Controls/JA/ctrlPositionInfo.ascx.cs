using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.JNP;
using HCMS.Business.JNP.Collections;
using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.CR;
using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using Telerik.Web.UI;

namespace HCMS.JNP.Controls.JA
{
    public partial class ctrlPositionInfo : JNPUserControlBase
    {
        #region Object Declarations

        private const string highPDTopOptionEmpty = "[-- Select Series, High Grade and Organization Code --]";
        private const string lowPDTopOptionEmpty = "[-- Select Series, Low Grade and Organization Code --]";
        private const string highPDTopOptionFull = "[-- Select Full Position Description --]";
        private const string lowPDTopOptionFull = "[-- Select Additional Position Description --]";
        private const string noJNPTitle = "-- Select Full Position Description First --";
        private const string CURRENTPKG = "CurrentPackage";
        private const string SHOWCREATEMSSG = "ShowCreateMessage";
        private const string CONFIRMDELCR = "ConfirmDeleteCR";
        private const string DEUCHKCHANGE = "DidDEUCheckboxChange";

        private const string MPAutomaticallyCheckedIfDEUChecked = "MPAutomaticallyCheckedIfDEUChecked";
        
        #endregion

        #region Events/Delegates

        public delegate void JNPSavedHandler(JNPackage currentPackage, enumNavigationMode navigationMode);
        public event JNPSavedHandler JNPSaved;

        public delegate void NonExistentJNPHandler();
        public event NonExistentJNPHandler NonExistentJNPEncountered;

        #endregion

        #region Properties

        public int CopyJNPID
        {
            get
            {
                if (ViewState["CopyJNPID"] == null)
                    ViewState["CopyJNPID"] = -1;

                return (int)ViewState["CopyJNPID"];
            }
            set
            {
                ViewState["CopyJNPID"] = value;
            }
        }

        public int cpPayPlanID
        {
            get
            {
                if (ViewState["cpPayPlanID"] == null)
                    ViewState["cpPayPlanID"] = -1;

                return (int)ViewState["cpPayPlanID"];
            }
            set
            {
                ViewState["cpPayPlanID"] = value;
            }
        }
        public int CpSeriesID
        {
            get
            {
                if (ViewState["CpSeriesID"] == null)
                    ViewState["CpSeriesID"] = -1;

                return (int)ViewState["CpSeriesID"];
            }
            set
            {
                ViewState["CpSeriesID"] = value;
            }
        }

        public int cpHighGrade
        {
            get
            {
                if (ViewState["cpHighGrade"] == null)
                    ViewState["cpHighGrade"] = -1;

                return (int)ViewState["cpHighGrade"];
            }
            set
            {
                ViewState["cpHighGrade"] = value;
            }
        }

        public int cpLowGrade
        {
            get
            {
                if (ViewState["cpLowGrade"] == null)
                    ViewState["cpLowGrade"] = -1;

                return (int)ViewState["cpLowGrade"];
            }
            set
            {
                ViewState["cpLowGrade"] = value;
            }
        }

        public enumJNPType cpJNPType
        {
            get
            {
                if (ViewState["cpJNPType"] == null)
                    ViewState["cpJNPType"] = enumJNPType.Unknown;

                return (enumJNPType)ViewState["cpJNPType"];
            }
            set
            {
                ViewState["cpJNPType"] = value;
            }
        }

        public bool hasManyRegions
        {
            get
            {
                if (ViewState["hasManyRegions"] == null)
                    ViewState["hasManyRegions"] = false;

                return (bool)ViewState["hasManyRegions"];
            }
            set
            {
                ViewState["hasManyRegions"] = value;
            }

        }

        private bool ConfirmDeleteCR
        {
            get
            {
                if (ViewState[CONFIRMDELCR] == null) ViewState[CONFIRMDELCR] = false;
                return (bool)ViewState[CONFIRMDELCR];
            }
            set
            {
                ViewState[CONFIRMDELCR] = value;
            }
        }

        private bool DidDEUCheckboxChange
        {
            get
            {
                if (ViewState[DEUCHKCHANGE] == null) ViewState[DEUCHKCHANGE] = false;
                return (bool)ViewState[DEUCHKCHANGE];
            }
            set
            {
                ViewState[DEUCHKCHANGE] = value;
            }
        }
        private bool MPCheckedIfDEUChecked
        {
            get
            {
                if (ViewState[MPAutomaticallyCheckedIfDEUChecked] == null) ViewState[MPAutomaticallyCheckedIfDEUChecked] = false;
                return (bool)ViewState[MPAutomaticallyCheckedIfDEUChecked];
            }
            set
            {
                ViewState[MPAutomaticallyCheckedIfDEUChecked] = value;
            }
        }

        private JNPackage CurrentPackage
        {
            get
            {
                if (ViewState[CURRENTPKG] == null)
                    ViewState[CURRENTPKG] = null;

                return (JNPackage)ViewState[CURRENTPKG];
            }
            set
            {
                ViewState[CURRENTPKG] = value;
            }
        }

        private bool IsShowCreateMessage
        {
            get
            {
                if (ViewState[SHOWCREATEMSSG] == null)
                    ViewState[SHOWCREATEMSSG] = false;

                return (bool)ViewState[SHOWCREATEMSSG];
            }
            set
            {
                ViewState[SHOWCREATEMSSG] = value;
            }
        }

        private bool _isDEUCheckChanged;

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            this.checkboxIsInterdisciplinary.CheckedChanged += new EventHandler(checkboxIsInterdisciplinary_CheckedChanged);

            // button/link button click events
            this.buttonSaveAndContinue.Click += new EventHandler(buttonSaveAndContinue_Click);
            this.buttonReset.Click += new EventHandler(buttonReset_Click);
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack)
            {
                _isDEUCheckChanged = false;

                string urlReferrer = Request.UrlReferrer.ToString();

                if (urlReferrer.Contains("CreateJNP.aspx"))
                {
                    IsShowCreateMessage = true;
                }
                else
                {
                    IsShowCreateMessage = false;
                }


                if (isValidJNP())
                {
                    bindDropdownLists();
                    loadData();
                    setView();
                }
                //rwConfirmDeleteCR.VisibleOnPageLoad = false;
            }
            base.OnLoad(e);
        }
        private bool isValidJNP()
        {
            bool isValid = false;

            try
            {
                JNPackage queryPackage = new JNPackage(base.CurrentJNPID);

                if (queryPackage == null || queryPackage.JNPID == -1)
                {
                    // raise NonExistent JNP Encountered event
                    if (NonExistentJNPEncountered != null)
                        NonExistentJNPEncountered();
                }
                else
                {
                    this.CurrentPackage = queryPackage;
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
                base.LogExceptionOnly(ex.ToString());
            }

            return isValid;
        }



        private void printTopOptionOnly(RadComboBox dropdown, string topOption)
        {
            dropdown.Items.Clear();
            dropdown.Items.Add(new RadComboBoxItem(topOption, "-1"));
        }

        private void bindDropdownLists()
        {
            // Additional Series
            ControlUtility.BindRadComboBoxControl(this.dropdownAdditionalSeries, LookupWrapper.GetPayPlanSeries(true, this.CurrentPackage.PayPlanID), null, "DetailLine", "SeriesID", "[-- Select Additional Series --]");
        }

        //private bool ShowEditFields()
        //{
        //    enumJNPWorkflowStatus currentws = base.CurrentJNPWS;

        //    bool showEditFields = ((base.IsInEdit)
        //      && (currentws == enumJNPWorkflowStatus.Draft
        //      || currentws == enumJNPWorkflowStatus.Review
        //      || (currentws == enumJNPWorkflowStatus.Revise
        //      && !CurrentJNP.IsJNPSignedBySupervisor)));

        //    return showEditFields;
        //}

        private void EnableFields(bool enabled)
        {
            this.literalIsInterdisciplinary.Visible = !enabled;
            this.checkboxDEU.Enabled = enabled;
            this.checkboxMP.Enabled = enabled;
            this.checkboxException.Enabled = enabled;

            if (CopyJNPID > 1)
            {
                this.checkboxIsInterdisciplinary.Enabled = false;
                this.checkboxIsInterdisciplinary.Text = "";
            }
            else
                this.checkboxIsInterdisciplinary.Enabled = enabled;

            this.dropdownAdditionalSeries.Visible = enabled;

            this.textBoxFPPSPDID.Visible = enabled;
            this.literalFPPSPDID.Visible = !enabled;

            this.textboxDutyLocation.Visible = enabled;
            this.literalDutyLocation.Visible = !enabled;

            divAttributes.Visible = enabled;
            divAttributesReadOnly.Visible = !enabled;

            if (!spanAdditionalSeries.Visible)
            {
                if (!enabled)
                {
                    literalIsInterdisciplinary.Text = "No";
                    checkboxIsInterdisciplinary.Visible = false;
                }
            }
            else
            {
                literalIsInterdisciplinary.Text = "Yes";
                checkboxIsInterdisciplinary.Visible = false;
            }

            if (!base.IsAdmin)
            {
                if (CurrentJNPWS == enumJNPWorkflowStatus.Revise)
                {
                    if (!CurrentJNP.IsJNPSignedBySupervisor)
                    {
                        checkboxIsInterdisciplinary.Visible = true;
                    }
                }
                else if (CurrentJNPWS == enumJNPWorkflowStatus.Review)
                {
                    if (base.HasHRGroupPermission)
                    {
                        checkboxIsInterdisciplinary.Visible = true;
                    }
                }
                else if (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview)
                {
                    if (base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR)
                    {
                        checkboxIsInterdisciplinary.Visible = true;
                    }
                }
            }
            else
            {
                if (CurrentJNPWS != enumJNPWorkflowStatus.Published)
                {
                    checkboxIsInterdisciplinary.Visible = true;
                }
            }

            if (CurrentJNPWS == enumJNPWorkflowStatus.Draft)
            {
                checkboxIsInterdisciplinary.Visible = true;
            }
        }

        private void setView()
        {
            if (base.ShowEditFields(enumDocumentType.JA))
            {
                EnableFields(true);
                this.buttonSaveAndContinue.Text = "Save and Continue";
                this.buttonSaveAndContinue.ToolTip = "Save and Continue";
                this.buttonReset.Visible = true;
                this.literalAdditionalSeries.Visible = false;
            }
            else
            {
                EnableFields(false);
                this.buttonSaveAndContinue.Text = "Continue";
                this.buttonSaveAndContinue.ToolTip = "Continue";
                this.buttonReset.Visible = false;
                this.literalAdditionalSeries.Visible = true;
            }          
           

            if (IsShowCreateMessage)
            {
                this.createJNPMsg.Visible = true;
            }
            else
            {
                this.createJNPMsg.Visible = false;
            }

            //FPPSPDID, Duty location, Recruitment Options should not be required for standard Package
            //hide the * 
            if (CurrentJNP.IsStandardJNP)
            {
                spanFPPSPDID.Visible = false;
                spanDutyLocation.Visible = false;
                spanRecruitmentOptions.Visible = false;
            }
            else
            {
                spanFPPSPDID.Visible = true;
                spanDutyLocation.Visible = true;
                spanRecruitmentOptions.Visible = true;
            }

            //issue 712
            if (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview)
            {
                if (base.IsAdmin)
                {
                    textBoxFPPSPDID.ReadOnly = false;
                    textboxDutyLocation.ReadOnly = false;
                    checkboxIsInterdisciplinary.Enabled = true;
                    checkboxDEU.Enabled = true;
                    checkboxMP.Enabled = true;
                    checkboxException.Enabled = true;
                }
                else
                {
                    //Issue 1060 Editable for HR in FinalReview
                    if ((base.HasHRGroupPermission) && (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview) && (!CurrentJNP.IsJNPSignedByHR))
                    {
                        textBoxFPPSPDID.ReadOnly = false;
                        textboxDutyLocation.ReadOnly = false;
                        checkboxIsInterdisciplinary.Enabled = true;
                        checkboxDEU.Enabled = true;
                        checkboxMP.Enabled = true;
                        checkboxException.Enabled = true;
                    }
                    else
                    {
                        textBoxFPPSPDID.ReadOnly = true;
                        textboxDutyLocation.ReadOnly = true;

                        textBoxFPPSPDID.Enabled = false;
                        textboxDutyLocation.Enabled = false;

                        checkboxIsInterdisciplinary.Enabled = false;
                        checkboxDEU.Enabled = false;
                        checkboxMP.Enabled = false;
                        checkboxException.Enabled = false;

                        dropdownAdditionalSeries.Enabled = false;

                        this.buttonSaveAndContinue.Text = "Continue";
                    }
                }
            }
        }

        private void loadData()
        {
            if (CopyJNPID > 0)
            {
                JNPackage ExistingPackage = new JNPackage(CopyJNPID);
                ExistingPackage.CopyFromJNPID = CopyJNPID;
                ExistingPackage.AddBasedOnExistingJNP();

                base.CurrentJNPID = ExistingPackage.JNPID;
                base.CurrentJAID = ExistingPackage.JAID;
                base.CurrentNavMode = enumNavigationMode.Edit;

                ReloadCurrentJNP(ExistingPackage.JNPID);
                CurrentPackage = ExistingPackage;
            }

            this.literalPayPlan.Text = this.CurrentPackage.PayPlanTitle;
            this.literalRegion.Text = this.CurrentPackage.RegionName;
            this.literalSeries.Text = string.Format("{0} | {1}", this.CurrentPackage.SeriesID.ToString(), this.CurrentPackage.SeriesName);

            OrganizationCode organizationCode = new OrganizationCode(this.CurrentPackage.OrganizationCodeID);
            this.literalOrganizationCode.Text = organizationCode.DetailLineLegacy;

            this.lblIsStandardJNP.Text = this.CurrentPackage.IsStandardJNP ? GetLocalResourceObject("StandardJNPMessage").ToString() : GetLocalResourceObject("NonStandardJNPMessage").ToString();

            // IsInterdisciplinary field
            if (CopyJNPID > 1)
                this.checkboxIsInterdisciplinary.Enabled = false;

            if (this.CurrentPackage.IsInterdisciplinary)
            {
                this.checkboxIsInterdisciplinary.Checked = true;

                showAdditionalSeries(this.CurrentPackage.IsInterdisciplinary);
                ControlUtility.SafeListControlSelect(this.dropdownAdditionalSeries, this.CurrentPackage.AdditionalSeriesID);

                // IsInterdisciplinary read only fields
                this.literalAdditionalSeries.Text = string.Format("{0} | {1}", this.CurrentPackage.AdditionalSeriesID.ToString(), this.CurrentPackage.AdditionalSeriesName);
            }

            // IsInterdisciplinary read only fields
            this.literalIsInterdisciplinary.Text = this.CurrentPackage.IsInterdisciplinary ? GetLocalResourceObject("InterdisciplinaryMessage").ToString() : GetLocalResourceObject("NonInterdisciplinaryMessage").ToString();

            // load high values
            this.literalHighGrade.Text = this.CurrentPackage.HighestAdvertisedGrade.ToString();
            this.literalFullPD.Text = string.Format("{0} | {1}", this.CurrentPackage.FullPDID, this.CurrentPackage.FullPDName);

            // if twoGrade then show low grade and preselect additional PD
            this.literalTwoGrade.Text = this.CurrentPackage.AdditionalPDID == -1 ? GetLocalResourceObject("SingleGradeMessage").ToString() : GetLocalResourceObject("TwoGradeMessage").ToString();

            if (this.CurrentPackage.AdditionalPDID != -1L)
            {
                this.divAdditionalPD.Visible = true;
                this.spanLowestAdvertisedGrade.Visible = true;
                this.literalLowGrade.Text = this.CurrentPackage.LowestAdvertisedGrade.ToString();
                this.literalAdditionalPD.Text = string.Format("{0} | {1}", this.CurrentPackage.AdditionalPDID, this.CurrentPackage.AdditionalPDName);
            }

            this.literalJNPTitle.Text = this.CurrentPackage.JNPTitle;
            this.literalFPPSPDID.Text = this.textBoxFPPSPDID.Text = this.CurrentPackage.FPPSPDID;
            this.literalDutyLocation.Text = this.textboxDutyLocation.Text = this.CurrentPackage.DutyLocation;

            this.checkboxDEU.Checked = this.CurrentPackage.IsDEU;
            this.checkboxMP.Checked = this.CurrentPackage.IsMP;
            this.checkboxException.Checked = this.CurrentPackage.IsExceptedService;

            string yesValue = GetLocalResourceObject("AttributeYesValue").ToString();
            string noValue = GetLocalResourceObject("AttributeNoValue").ToString();

            this.literalIsDeu.Text = this.CurrentPackage.IsDEU ? yesValue : noValue;
            this.literalIsMP.Text = this.CurrentPackage.IsMP ? yesValue : noValue;
            this.literalIsException.Text = this.CurrentPackage.IsExceptedService ? yesValue : noValue;

            //For report purpose
            HCMS.Business.JNP.JNPManager.jnpid = base.CurrentJNPID;
        }

        private void showAdditionalSeries(bool display)
        {
            this.spanAdditionalSeries.Visible = display;
        }

        private void checkboxIsInterdisciplinary_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                showAdditionalSeries(this.checkboxIsInterdisciplinary.Checked);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #region Button Click Events

        protected void checkboxDEU_checkChanged(object sender, EventArgs e)
        {
            DidDEUCheckboxChange = true;
            MPCheckedIfDEUChecked = true;
        }

        protected void btnConfirmDeleteCR_OK_Click(object sender, EventArgs e)
        {
            ConfirmDeleteCR = true;
            rwConfirmDeleteCR.VisibleOnPageLoad = false;
            CategoryRatingManager.DeleteCategoryRating(CurrentCRID, CurrentUserID);
            buttonSaveAndContinue_Click(sender, e);
        }

        protected void btnConfirmDeleteCR_Cancel_Click(object sender, EventArgs e)
        {
            //this.checkboxDEU.Checked = true;
            ConfirmDeleteCR = true;
            rwConfirmDeleteCR.VisibleOnPageLoad = false;
            buttonSaveAndContinue_Click(sender, e);
        }

        private void buttonSaveAndContinue_Click(object sender, EventArgs e)
        {
            try
            {
                var navigateurl = Page.ResolveUrl("~/JA/JADuties.aspx");

                if (base.ShowEditFields(enumDocumentType.JA))
                {
                    if (Page.IsValid)
                    {
                        if (DidDEUCheckboxChange && !this.checkboxDEU.Checked && base.HasActiveCR() && !ConfirmDeleteCR)
                        {
                            rwConfirmDeleteCR.VisibleOnPageLoad = true;
                            return;
                        }

                        // save the JNP
                        JNPackage thisPackage = new JNPackage();

                        thisPackage.JNPID = base.CurrentJNPID;
                        thisPackage.IsInterdisciplinary = this.checkboxIsInterdisciplinary.Checked;
                        thisPackage.AdditionalSeriesID = ControlUtility.GetDropdownValue(this.dropdownAdditionalSeries);

                        thisPackage.FPPSPDID = this.textBoxFPPSPDID.Text;
                        thisPackage.DutyLocation = this.textboxDutyLocation.Text;
                        thisPackage.IsDEU = this.checkboxDEU.Checked;
                        thisPackage.IsMP = this.checkboxMP.Checked;
                        thisPackage.IsExceptedService = this.checkboxException.Checked;
                        thisPackage.UpdatedByID = base.CurrentUserID;

                        // Update JNP Package
                        thisPackage.Update();
                    }


                    ReloadCurrentJNP(CurrentJNPID);

                    base.GoToLink(navigateurl, eMode.Edit, false);
                }
                else
                {
                    base.GoToLink(navigateurl, eMode.View, true);
                }


            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                loadData();
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