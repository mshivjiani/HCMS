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
using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using Telerik.Web.UI;

namespace HCMS.JNP.Controls.Package
{
    public partial class ctrlCreateJNP : JNPUserControlBase
    {
        #region Object Declarations

        private const string PayPlanFirstTopOption = "[-- Select Pay Plan First --]";
        private const string SeriesFirstTopOption = "[-- Select Series First --]";
        private const string highPDTopOptionEmpty = "[-- Select Series, High Grade and Organization Code --]";
        private const string lowPDTopOptionEmpty = "[-- Select Series, Low Grade and Organization Code --]";
        private const string highPDTopOptionFull = "[-- Select Full Position Description --]";
        private const string lowPDTopOptionFull = "[-- Select Additional Position Description --]";
        private const string noJNPTitle = "-- Select Full Position Description First --";
        private const string JNPListTopOptionEmpty = "[-- Select Series and High Grade First --]";

        #endregion

        #region Events/Delegates

        public delegate void JNPSavedHandler (JNPackage currentPackage);
        public event JNPSavedHandler JNPSaved;

        #endregion

        #region Properties

        public bool UseJNPTemplates
        {
            get
            {
                if (ViewState["UseJNPTemplates"] == null)
                    ViewState["UseJNPTemplates"] = false;

                return (bool)ViewState["UseJNPTemplates"];
            }
            set
            {
                ViewState["UseJNPTemplates"] = value;
            }
        }

       
        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.dropdownPayPlan.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropdownPayPlan_SelectedIndexChanged);
            this.dropdownRegion.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropdownRegion_SelectedIndexChanged);
            this.dropdownOrganizationCode.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropdownOrganizationCode_SelectedIndexChanged);
            this.dropdownSeries.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropdownSeries_SelectedIndexChanged);
            this.dropdownHighestAdvertisedGrade.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropdownHighestAdvertisedGrade_SelectedIndexChanged);
            this.dropdownLowestAdvertisedGrade.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropdownLowestAdvertisedGrade_SelectedIndexChanged);
            this.dropdownFullPD.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropdownFullPD_SelectedIndexChanged);
            this.dropdownFullPD.ItemDataBound += new RadComboBoxItemEventHandler(dropdownFullPD_ItemDataBound);
            this.dropdownAdditionalPD.ItemDataBound += new RadComboBoxItemEventHandler(dropdownAdditionalPD_ItemDataBound);
            this.dropdownJNPTemplates.ItemDataBound += new RadComboBoxItemEventHandler(dropdownJNPTemplates_ItemDataBound);
            this.checkboxIsInterdisciplinary.CheckedChanged += new EventHandler(checkboxIsInterdisciplinary_CheckedChanged);
            this.checkboxTwoGrade.CheckedChanged += new EventHandler(checkboxTwoGrade_CheckedChanged);
            this.checkboxStandardJNP.CheckedChanged += new EventHandler(checkboxStandardJNP_CheckedChanged);

            // button/link button click events
            this.buttonSave.Click += new EventHandler(buttonSave_Click);
            this.buttonReset.Click += new EventHandler(buttonReset_Click);
            base.OnInit(e);
        }

        private void dropdownAdditionalPD_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            try
            {
                PositionDescription pd = e.Item.DataItem as PositionDescription;

                if (pd != null)
                {
                    //Issue Id: 23
                    //Author: Deepali Anuje
                    //Date Fixed: 1/23/2012
                    //Description: When a user selects a PD ID/Title/etc. from the dropdown list of options, 
                    //             please display both the PD ID and the PD Title of the selection. Right now, 
                    //             it's only displaying the title.
                    e.Item.Text = pd.PositionDescriptionID.ToString() + " | " + pd.OPMJobTitle;
                    e.Item.Value = pd.PositionDescriptionID.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void dropdownFullPD_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            try
            {
                PositionDescription pd = e.Item.DataItem as PositionDescription;

                if (pd != null)
                {
                    //Issue Id: 23
                    //Author: Deepali Anuje
                    //Date Fixed: 1/23/2012
                    //Description: When a user selects a PD ID/Title/etc. from the dropdown list of options, 
                    //             please display both the PD ID and the PD Title of the selection. Right now, 
                    //             it's only displaying the title.  
                    e.Item.Text =  pd.PositionDescriptionID.ToString() + " | " + pd.OPMJobTitle;
                    e.Item.Value = pd.PositionDescriptionID.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void dropdownJNPTemplates_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            try
            {
                JNPackage selectedPackage = e.Item.DataItem as JNPackage;

                if (selectedPackage != null)
                {
                    e.Item.Text = selectedPackage.JNPTitle;
                    e.Item.Value = selectedPackage.JNPID.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void printTopOptionOnly(RadComboBox dropdown, string topOption)
        {
            dropdown.Items.Clear();
            dropdown.Items.Add(new RadComboBoxItem(topOption, "-1"));
        }

        private void buildSeriesDropdown(bool isEmpty)
        {
            int selectedPayPlanID = isEmpty ? -1 : ControlUtility.GetDropdownValue(this.dropdownPayPlan);
            bool isTrulyEmpty = selectedPayPlanID == -1;
            SeriesCollection seriesList = LookupWrapper.GetPayPlanSeries(true, selectedPayPlanID);

            if (isTrulyEmpty)
            {
                printTopOptionOnly(this.dropdownSeries, PayPlanFirstTopOption);
                printTopOptionOnly(this.dropdownAdditionalSeries, PayPlanFirstTopOption);

                // grades
                printTopOptionOnly(this.dropdownHighestAdvertisedGrade, SeriesFirstTopOption);
                printTopOptionOnly(this.dropdownLowestAdvertisedGrade, SeriesFirstTopOption);

                // full/additional PD
                printTopOptionOnly(this.dropdownFullPD, highPDTopOptionEmpty);
                printTopOptionOnly(this.dropdownAdditionalPD, lowPDTopOptionEmpty);

                // clear JNP fields that are loaded from Full PD
                clearJNPDataFromFullPD();

                // JNP Templates
                printTopOptionOnly(this.dropdownJNPTemplates, JNPListTopOptionEmpty);
            }
            else
            {
                ControlUtility.BindRadComboBoxControl(this.dropdownSeries, seriesList, null, "DetailLine", "SeriesID", "[-- Select Series --]");
                ControlUtility.BindRadComboBoxControl(this.dropdownAdditionalSeries, seriesList, null, "DetailLine", "SeriesID", "[-- Select Additional Series --]");

                buildGradeDropdown();
            }
        }

        private void buildOrganizationCodeDropdown(int regionID)
        {
            bool isNilRegionID = regionID == -1;
            //JA issue 897 not able to see recently assigned orgcode in JAX create new package
            //fixed by always reloading instead of getting from cache.
            OrganizationCodeCollection orgCodes = LookupWrapper.GetOrganizationCodesByUser(true,CurrentUserID).GetByRegion(regionID);
            //JA id :957:JAX: Remove Standard Org code 0 from HR's list in JAX 
            //removing standard organization code from the dropdown list since we no longer support standard packages.
            OrganizationCode standardOrgCode = new OrganizationCode();
            standardOrgCode.OrganizationCodeID = 1;
            orgCodes.Remove(standardOrgCode);
            
            if (isNilRegionID)
                printTopOptionOnly(this.dropdownOrganizationCode, "[-- Select Region First --]");
            else
                ControlUtility.BindRadComboBoxControl(this.dropdownOrganizationCode, orgCodes, null, "DetailLineLegacy", "OrganizationCodeID", "[-- Select Organization Code --]");
       }

        private void buildJNPTemplateList()
        {
            if (this.UseJNPTemplates)
            {
                int seriesID = ControlUtility.GetDropdownValue(this.dropdownSeries);
                int highGradeID = ControlUtility.GetDropdownValue(this.dropdownHighestAdvertisedGrade);
                
                if (seriesID == -1 || highGradeID == -1)
                    printTopOptionOnly(this.dropdownJNPTemplates, JNPListTopOptionEmpty);
                else
                {
                    JNPackageCollection JNPList = JNPSearch.Search(seriesID, highGradeID);
                    
                    if (JNPList.Count == 0)
                        printTopOptionOnly(this.dropdownJNPTemplates, "[-- No Matching Job Announcement were found --]");
                    else
                        ControlUtility.BindRadComboBoxControl(this.dropdownJNPTemplates, JNPList, null, "JNPTitle", "JNPID", "[-- Select Job Announcement --]");
                }
            }
        }

        private void buildGradeDropdown()
        {
            int selectedSeriesID = ControlUtility.GetDropdownValue(this.dropdownSeries);
            bool isEmpty = selectedSeriesID == -1;

            GradeCollection gradeList = LookupWrapper.GetAllGrades(false);
            ControlUtility.BindRadComboBoxControl(this.dropdownHighestAdvertisedGrade, gradeList, null, "GradeName", "GradeID", "[-- Select High Grade --]");

            // remove other from list
            if (gradeList.Count > 0 && gradeList.Contains("Other")) 
                gradeList.RemoveAt(gradeList.Count - 1);

            GradeCollection lowGradeList = new GradeCollection();
            lowGradeList.AddRange(gradeList);

            // remove highest grade from list and bind as Low Grade List
            if (lowGradeList.Count > 0)
                lowGradeList.RemoveAt(lowGradeList.Count - 1);

            ControlUtility.BindRadComboBoxControl(this.dropdownLowestAdvertisedGrade, lowGradeList, null, "GradeName", "GradeID", "[-- Select Low Grade --]");

            // position descriptions
            buildPositionDescriptionList();

            // build JNP Template list
            buildJNPTemplateList();
        }

        private void bindDropdownLists()
        {
            // pay plan
            ControlUtility.BindRadComboBoxControl(this.dropdownPayPlan, LookupWrapper.GetAllInUsePayPlans(false), null, "PayPlanTitle", "PayPlanID", "[-- Select Pay Plan --]");

            // regions
            ControlUtility.BindRadComboBoxControl(this.dropdownRegion, LookupWrapper.GetAllRegions(false), null, "RegionName", "RegionID", "[-- Select Region --]");
            
            // organization codes
            buildOrganizationCodeDropdown(base.CurrentUser.RegionID);

            // series -- initial setup
            // grades are built from within series
            buildSeriesDropdown(true);
        }

        private void setView()
        {
            // set the page view based on roles/permissions
            bool isHRUserOrSysAdmin = (base.HasHRGroupPermission || base.IsSystemAdministrator);
            
            // show/hide standard JNP checkbox
            checkboxStandardJNP.Enabled = isHRUserOrSysAdmin;  // show checkbox if user is an HR

            // set default "blank" JNP Title
            this.literalJNPTitle.Text = noJNPTitle;

            // set region view
            setRegionView();

            
            this.rowJNPTemplate.Visible = this.UseJNPTemplates;
            //show this row only when stand alone document option is implemented and this.UseJNPTemplates is not selected
            //for now since the stand alone document option is not implemented - making it invisible
            this.rowCreateJAFromPD.Visible = false; // !this.UseJNPTemplates;
        }

        private void setRegionView()
        {
            // if user is: System Administrator, Classifier 15 or Staffing Manager -- show dropdown
            // otherwise: show region literal
            // first step -- set region ID

            
            ControlUtility.SafeListControlSelect(this.dropdownRegion, base.CurrentUser.RegionID);

            //JA issue id 120 - Staffing Manager is at Classifier 15 level - changed the Staffing Speicalist to Staffing Manager 
            // Covers roles -- System Administrator, Classifier 15 and Staffing Manager
            bool isValidRegionEditRole = base.IsSystemAdministrator ||
                    base.HasClassifier15Permission ||
                    base.IsStaffingManager ;

            //JA issue id 212 --Region is locked on Create Screen but should be editable if user has access to more than 1 region 
            List<Region> regions = CurrentUser.GetListOfAssignedRegions();
            if ((regions.Count > 1) || (isValidRegionEditRole))
            {
                this.dropdownRegion.Visible = true;
                // toggle enable/disable of region autopostback -- we don't need to do a postback
                // if the user only has acces to his/her region
                this.dropdownRegion.AutoPostBack =true;
                this.literalRegion.Text = string.Empty;
                //if user is not an admin/hr user and has access to different region orgcodes
                //then populate region dropdown with only regions that user has access to.
                if (!isValidRegionEditRole)
                {
                    this.dropdownRegion.ClearSelection();
                    ControlUtility.BindRadComboBoxControl(this.dropdownRegion, regions, null, "RegionName", "RegionID", "[-- Select Region --]",base.CurrentUser.RegionID.ToString() );
                }
            }
            else
            {
                this.dropdownRegion.Visible = false;
                this.dropdownRegion.AutoPostBack =false;
                this.literalRegion.Text = base.CurrentUser.RegionName;
            }
            
   
           

           
                
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    bindDropdownLists();
                    setView();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void dropdownPayPlan_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                buildSeriesDropdown(false);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void dropdownRegion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                int selectedRegionID = ControlUtility.GetDropdownValue(this.dropdownRegion);
    
                buildOrganizationCodeDropdown(selectedRegionID);
                //To fix JA issue id 402: Create JNP Screen: If user forgets to select region 
                //before submitting first, the system does not allow user 
                //to select the Advertised Grade Series 
                // grades
                //printTopOptionOnly(this.dropdownHighestAdvertisedGrade, SeriesFirstTopOption);
                //printTopOptionOnly(this.dropdownLowestAdvertisedGrade, SeriesFirstTopOption);

                // full/additional PD
                printTopOptionOnly(this.dropdownFullPD, highPDTopOptionEmpty);
                printTopOptionOnly(this.dropdownAdditionalPD, lowPDTopOptionEmpty);

                // clear JNP fields that are loaded from Full PD
                clearJNPDataFromFullPD();

                // JNP Templates
                printTopOptionOnly(this.dropdownJNPTemplates, JNPListTopOptionEmpty);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void dropdownOrganizationCode_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                buildPositionDescriptionList();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void dropdownSeries_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                buildGradeDropdown();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void checkboxIsInterdisciplinary_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool enableAdditionalSeries = this.checkboxIsInterdisciplinary.Checked;
                this.spanAdditionalSeries.Visible = enableAdditionalSeries;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void checkboxTwoGrade_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool isTwoGradeChecked = this.checkboxTwoGrade.Checked;

                this.spanLowestAdvertisedGrade.Visible = isTwoGradeChecked;
                this.divAdditionalPD.Visible = isTwoGradeChecked;                
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void checkboxStandardJNP_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkboxStandardJNP.Checked)
                {
                    OrganizationCode stdOrgCode = new OrganizationCode(1);

                    literalOrgCodeStandardJNP.Text = stdOrgCode.DetailLineLegacy ;
                    spanOrganizationCodeDropdown.Visible = false;
                }
                else
                { 
                    literalOrgCodeStandardJNP.Text = string.Empty;
                    spanOrganizationCodeDropdown.Visible = true;

                    int selectedRegionID = ControlUtility.GetDropdownValue(this.dropdownRegion);
                    buildOrganizationCodeDropdown(selectedRegionID);
                }
                buildGradeDropdown();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void dropdownHighestAdvertisedGrade_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                int seriesID = ControlUtility.GetDropdownValue(this.dropdownSeries);
                int highGradeID = ControlUtility.GetDropdownValue(this.dropdownHighestAdvertisedGrade);
                int organizationCodeID = this.checkboxStandardJNP.Checked ? 1: ControlUtility.GetDropdownValue(this.dropdownOrganizationCode);

                buildSinglePositionDescriptionList(this.dropdownFullPD, seriesID, highGradeID, organizationCodeID, highPDTopOptionEmpty, highPDTopOptionFull, true);

                // build JNP Template list
                buildJNPTemplateList();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void dropdownLowestAdvertisedGrade_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                int seriesID = ControlUtility.GetDropdownValue(this.dropdownSeries);
                int lowGradeID = ControlUtility.GetDropdownValue(this.dropdownLowestAdvertisedGrade);
                int organizationCodeID = this.checkboxStandardJNP.Checked ? 1 : ControlUtility.GetDropdownValue(this.dropdownOrganizationCode);

                buildSinglePositionDescriptionList(this.dropdownAdditionalPD, seriesID, lowGradeID, organizationCodeID, lowPDTopOptionEmpty, lowPDTopOptionFull, false);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void clearJNPDataFromFullPD()
        {
            this.literalJNPTitle.Text = noJNPTitle;
            textboxDutyLocation.Text = string.Empty;
        }

        private void dropdownFullPD_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                // load duty location from Full PD
                long fullPDID = long.Parse(this.dropdownFullPD.SelectedValue);

                if (fullPDID == -1)
                {
                    this.literalJNPTitle.Text = noJNPTitle;
                    textboxDutyLocation.Text = string.Empty;
                }
                else
                {
                    PositionDescription selectedPD = new PositionDescription(fullPDID);

                    if (selectedPD.PositionDescriptionID != -1)
                    {
                        this.literalJNPTitle.Text = selectedPD.OPMJobTitle;
                        textboxDutyLocation.Text = selectedPD.DutyLocation;
                    }
                }

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        

        private void buildSinglePositionDescriptionList(RadComboBox dropdown, int seriesID, int gradeID, int organizationCode, string topOptionEmpty, string topOptionFull, bool isFullPD)
        {
            PositionDescriptionCollection pdList = PositionDescriptionSearcher.Search(seriesID, gradeID, organizationCode, PublishTypes.PublishedOnly);

            if (seriesID == -1 || gradeID == -1 || organizationCode == -1)
            {
                printTopOptionOnly(dropdown, topOptionEmpty);

                // clear JNP fields that are loaded from Full PD
                if (isFullPD)
                    clearJNPDataFromFullPD();
            }
            else
            {
                if (pdList.Count == 0)
                {
                    printTopOptionOnly(dropdown, "[-- No Matching Position Descriptions were found --]");

                    // clear JNP fields that are loaded from Full PD
                    if (isFullPD)
                        clearJNPDataFromFullPD();
                }
                else
                    ControlUtility.BindRadComboBoxControl(dropdown, pdList, null, "OPMJobTitle", "PositionDescriptionID", topOptionFull);
            }
        }

        private void buildPositionDescriptionList()
        {
            int seriesID = ControlUtility.GetDropdownValue(this.dropdownSeries);
            int highGradeID = ControlUtility.GetDropdownValue(this.dropdownHighestAdvertisedGrade);
            int lowGradeID = ControlUtility.GetDropdownValue(this.dropdownLowestAdvertisedGrade);
            int organizationCodeID = this.checkboxStandardJNP.Checked ? 1 : ControlUtility.GetDropdownValue(this.dropdownOrganizationCode);
            // to take care of Issues ID 53: Performance Issue -- populate pd dropdowns only when grade is selected 
            if (highGradeID > 0)
            {
                buildSinglePositionDescriptionList(this.dropdownFullPD, seriesID, highGradeID, organizationCodeID, highPDTopOptionEmpty, highPDTopOptionFull, true);
                if (lowGradeID > 0)
                {
                    buildSinglePositionDescriptionList(this.dropdownAdditionalPD, seriesID, lowGradeID, organizationCodeID, lowPDTopOptionEmpty, lowPDTopOptionFull, false);
                }
            }
        }

        #region Button Click Events

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    // save the JNP
                    JNPackage currentPackage = new JNPackage();

                    currentPackage.PayPlanID = ControlUtility.GetDropdownValue(this.dropdownPayPlan);
                    currentPackage.RegionID = ControlUtility.GetDropdownValue(this.dropdownRegion);
                    currentPackage.SeriesID = ControlUtility.GetDropdownValue(this.dropdownSeries);
                    currentPackage.OrganizationCodeID = this.checkboxStandardJNP.Checked ? 1 : ControlUtility.GetDropdownValue(this.dropdownOrganizationCode);
                    currentPackage.IsStandardJNP = this.checkboxStandardJNP.Checked;
                    currentPackage.JNPTitle = this.literalJNPTitle.Text;
                    currentPackage.IsInterdisciplinary = this.checkboxIsInterdisciplinary.Checked;
                    currentPackage.AdditionalSeriesID = ControlUtility.GetDropdownValue(this.dropdownAdditionalSeries);
                    currentPackage.JNPTypeID = this.checkboxTwoGrade.Checked ? enumJNPType.TwoGrade : enumJNPType.SingleGrade;
                    
                
                   
                    currentPackage.LowestAdvertisedGrade = ControlUtility.GetDropdownValue(this.dropdownLowestAdvertisedGrade);
                    currentPackage.HighestAdvertisedGrade = ControlUtility.GetDropdownValue(this.dropdownHighestAdvertisedGrade);
                    currentPackage.FullPDID = ControlUtility.GetDropdownValue(this.dropdownFullPD);
                    currentPackage.AdditionalPDID = ControlUtility.GetDropdownValue(this.dropdownAdditionalPD);
                    currentPackage.DutyLocation = this.textboxDutyLocation.Text;
                    currentPackage.IsDEU = this.checkboxDEU.Checked;
                    currentPackage.IsMP = this.checkboxMP.Checked;
                    currentPackage.IsExceptedService = this.checkboxException.Checked;
                    currentPackage.CreatedByID = base.CurrentUserID;
                    
                    // Create JNP Package
                    if (this.UseJNPTemplates)
                    {
                        currentPackage.JNPOptionTypeID = eJNPOptionType.CreateFromExisting;
                        currentPackage.CopyFromJNPID = long.Parse(this.dropdownJNPTemplates.SelectedValue);
                        currentPackage.AddBasedOnExistingJNP();
                    }
                    else
                    {
                        // For the pilot release -- we are only using the createNew option
                        // In a future release, this will be updated to support more options
                        currentPackage.JNPOptionTypeID = eJNPOptionType.CreateNew;
                        currentPackage.Add(this.checkboxCreateJAFromPD.Checked);
                    }

                    // set values
                    base.CurrentJNPID = currentPackage.JNPID;
                    base.CurrentJAID = currentPackage.JAID;
                    base.CurrentNavMode = enumNavigationMode.Edit;

                    //Bypassing information page
                    base.GoToLink("~/JA/JADuties.aspx", enumNavigationMode.Edit);
                  
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
                base.SafeRedirect(Request.RawUrl);
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