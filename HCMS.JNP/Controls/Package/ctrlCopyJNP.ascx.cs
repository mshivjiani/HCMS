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
    public partial class ctrlCopyJNP : JNPUserControlBase
    {
        #region Events/Delegates
        public delegate void NonExistentJNPHandler();
        public event NonExistentJNPHandler NonExistentJNPEncountered;
        #endregion

        #region Properties
        private const string highPDTopOptionEmpty = "[-- Select Organization Code --]";
        private const string lowPDTopOptionEmpty = "[-- Select Organization Code --]";
        private const string highPDTopOptionFull = "[-- Select Full Position Description --]";
        private const string lowPDTopOptionFull = "[-- Select Additional Position Description --]";
        private const string noJNPTitle = "-- Select Full Position Description First --";

   
        public long CopyJNPID
        {
            get
            {
                if (ViewState["CopyJNPID"] == null)
                    ViewState["CopyJNPID"] = -1;

                return (long)ViewState["CopyJNPID"];
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
                    ViewState["cpJNPType"] = enumJNPType.Unknown ;

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
        #endregion

        #region Page Events

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            
            this.dropdownRegion.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropdownRegion_SelectedIndexChanged);
            this.dropdownOrganizationCode.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropdownOrganizationCode_SelectedIndexChanged);
           
            this.dropdownFullPD.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropdownFullPD_SelectedIndexChanged);
            this.dropdownFullPD.ItemDataBound += new RadComboBoxItemEventHandler(dropdownFullPD_ItemDataBound);
            this.dropdownAdditionalPD.ItemDataBound += new RadComboBoxItemEventHandler(dropdownAdditionalPD_ItemDataBound);
            this.checkboxIsInterdisciplinary.CheckedChanged += new EventHandler(checkboxIsInterdisciplinary_CheckedChanged);
      

            // button/link button click events
            this.buttonSave.Click += new EventHandler(buttonSave_Click);
            this.buttonReset.Click += new EventHandler(buttonReset_Click);
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadData();
                    
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

        }

        #endregion
        #region Private Methods

        private void printTopOptionOnly(RadComboBox dropdown, string topOption)
        {
            dropdown.Items.Clear();
            dropdown.Items.Add(new RadComboBoxItem(topOption, "-1"));
        }

        private void clearJNPDataFromFullPD()
        {
            this.literalJNPTitle.Text = noJNPTitle;
            textboxDutyLocation.Text = string.Empty;
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
                    base.IsStaffingManager;

            //JA issue id 212 --Region is locked on Create Screen but should be editable if user has access to more than 1 region 
            List<Region> regions = CurrentUser.GetListOfAssignedRegions();
            hasManyRegions = (regions.Count > 1);
            if ((regions.Count > 1) || (isValidRegionEditRole))
            {
                this.dropdownRegion.Visible = true;
                // toggle enable/disable of region autopostback -- we don't need to do a postback
                // if the user only has acces to his/her region
                this.dropdownRegion.AutoPostBack = true;
                this.literalRegion.Text = string.Empty;
                //if user is not an admin/hr user and has access to different region orgcodes
                //then populate region dropdown with only regions that user has access to.
                if (!isValidRegionEditRole)
                {
                    this.dropdownRegion.ClearSelection();
                    ControlUtility.BindRadComboBoxControl(this.dropdownRegion, regions, null, "RegionName", "RegionID", "[-- Select Region --]", base.CurrentUser.RegionID.ToString());
                }
                else
                {
                    ControlUtility.BindRadComboBoxControl(this.dropdownRegion, regions, null, "RegionName", "RegionID", "[-- Select Region --]",base.CurrentUser.RegionID.ToString ());

                }
            }
            else
            {
                this.dropdownRegion.Visible = false;
                this.dropdownRegion.AutoPostBack = false;
                this.literalRegion.Text = base.CurrentUser.RegionName;
            }






        }

        private void buildOrganizationCodeDropdown(int regionID)
        {
            bool isNilRegionID = regionID == -1;
            OrganizationCodeCollection orgCodes = LookupWrapper.GetOrganizationCodesByUser(false, CurrentUserID).GetByRegion(regionID);

            if (isNilRegionID)
                printTopOptionOnly(this.dropdownOrganizationCode, "[-- Select Region First --]");
            else
                ControlUtility.BindRadComboBoxControl(this.dropdownOrganizationCode, orgCodes, null, "DetailLineLegacy", "OrganizationCodeID", "[-- Select Organization Code --]");
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
                {
                    ControlUtility.BindRadComboBoxControl(dropdown, pdList, null, "OPMJobTitle", "PositionDescriptionID", topOptionFull);

                    //dropdown.SelectedValue = dropdown.Items[1].Value;

                    //dropdown.Enabled = false;
                }
            }
        }

        private void buildPositionDescriptionList()
        {
          
            int organizationCodeID =  ControlUtility.GetDropdownValue(this.dropdownOrganizationCode);
            // to take care of Issues ID 53: Performance Issue -- populate pd dropdowns only when grade is selected 
            if (organizationCodeID > 0)
            {
                if (cpHighGrade > 0)
                {
                    buildSinglePositionDescriptionList(this.dropdownFullPD,CpSeriesID , cpHighGrade , organizationCodeID, highPDTopOptionEmpty, highPDTopOptionFull, true);
                    if ((cpJNPType==enumJNPType.TwoGrade) && (cpLowGrade  > 0))
                    {
                        buildSinglePositionDescriptionList(this.dropdownAdditionalPD, CpSeriesID , cpLowGrade , organizationCodeID, lowPDTopOptionEmpty, lowPDTopOptionFull, false);
                    }
                }
            }
        }

        private void buildAdditionalSeriesDropdown()
        {
            SeriesCollection seriesList = LookupWrapper.GetPayPlanSeries(true, cpPayPlanID);
            ControlUtility.BindRadComboBoxControl(this.dropdownAdditionalSeries, seriesList, null, "DetailLine", "SeriesID", "[-- Select Additional Series --]");
        }

        private void LoadData()
        {
            JNPackage ExistingPackage = new JNPackage(CopyJNPID);
            if (ExistingPackage == null || ExistingPackage.JNPID == -1)
            {
                // raise NonExistent JNP Encountered event
                if (NonExistentJNPEncountered != null)
                    NonExistentJNPEncountered();
            }
            else
            {
                enumJNPWorkflowStatus existingJNPWS=JNPackage.GetCurrentWorkflowStatusName (CopyJNPID);

                if (existingJNPWS== enumJNPWorkflowStatus.Published)
                {
                    literalExistingJNPID.Text = string.Format("JAX ID:{0}- Full Position Description:{1}", CopyJNPID.ToString(), ExistingPackage.FullPDID ) ;
                    cpPayPlanID = ExistingPackage.PayPlanID;
                    this.literalPayPlan.Text = ExistingPackage.PayPlanTitle;
                    CpSeriesID = ExistingPackage.SeriesID;
                    cpHighGrade = ExistingPackage.HighestAdvertisedGrade;
                    this.literalSeries.Text = string.Format("{0} | {1}", ExistingPackage.SeriesID.ToString(), ExistingPackage.SeriesName);
                    this.literalTwoGrade.Text = (ExistingPackage.JNPTypeID == enumJNPType.TwoGrade) ? GetGlobalResourceObject("JNPInfo", "TwoGradeMessage").ToString() : GetGlobalResourceObject("JNPInfo", "SingleGradeMessage").ToString();
                    literalHighGrade.Text = ExistingPackage.HighestAdvertisedGrade.ToString();

                    //IsTwoGrade 
                    cpJNPType = ExistingPackage.JNPTypeID;
                    if (ExistingPackage.JNPTypeID == enumJNPType.TwoGrade)
                    {
                        spanLowestAdvertisedGrade.Visible = true;
                        literalLowGrade.Text = ExistingPackage.LowestAdvertisedGrade.ToString();
                        divAdditionalPD.Visible = true;
                        cpLowGrade = ExistingPackage.LowestAdvertisedGrade;
                    }
                    else
                    {
                        spanLowestAdvertisedGrade.Visible = false;
                        divAdditionalPD.Visible = false;
                    }

                    //IsInterDisciplinary?
                    buildAdditionalSeriesDropdown();
                    if (ExistingPackage.IsInterdisciplinary)
                    {
                        checkboxIsInterdisciplinary.Checked = true;
                        spanAdditionalSeries.Visible = true;
                        //fill the dropdownadditional series - with selected value - existingpackage.additionalseries
                        ControlUtility.SafeListControlSelect(this.dropdownAdditionalSeries, ExistingPackage.AdditionalSeriesID);
                    }
                    else
                    {
                        checkboxIsInterdisciplinary.Checked = false;
                        spanAdditionalSeries.Visible = false;
                    }

                    
                    //Region
                    setRegionView();

                    // organization codes
                    buildOrganizationCodeDropdown(base.CurrentUser.RegionID);

                    //Recruitement Options

                    this.checkboxDEU.Checked = ExistingPackage.IsDEU ? true : false;
                    this.checkboxMP.Checked = ExistingPackage.IsMP ? true : false;
                    this.checkboxException.Checked = ExistingPackage.IsExceptedService ? true : false;


                }
                else
                {
                    string errormsg=GetGlobalResourceObject ("JNPMessages","JNPOnlyFromPublishedJNP").ToString ();
                    base.PrintErrorMessage(errormsg, false);
                }
            }
        }

        private void SetPageView()
        {
        }
        #endregion

        #region Control Events

        private void dropdownRegion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                int selectedRegionID = ControlUtility.GetDropdownValue(this.dropdownRegion);
                //OrganizationCode
                buildOrganizationCodeDropdown(selectedRegionID);
                // full/additional PD
                printTopOptionOnly(this.dropdownFullPD, highPDTopOptionEmpty);
                printTopOptionOnly(this.dropdownAdditionalPD, lowPDTopOptionEmpty);
                // clear JNP fields that are loaded from Full PD
                clearJNPDataFromFullPD();
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

        private void dropdownAdditionalPD_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            try
            {
                PositionDescription pd = e.Item.DataItem as PositionDescription;

                if (pd != null)
                {
                    //display both the PD ID and the PD Title of the selection
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
                    //display both the PD ID and the PD Title of the selection  
                    e.Item.Text = pd.PositionDescriptionID.ToString() + " | " + pd.OPMJobTitle;
                    e.Item.Value = pd.PositionDescriptionID.ToString();
                }
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


        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    // save the JNP
                    JNPackage currentPackage = new JNPackage();
                    currentPackage.PayPlanID = cpPayPlanID;
                    currentPackage.RegionID =(hasManyRegions)? ControlUtility.GetDropdownValue(this.dropdownRegion): base.CurrentUser.RegionID ;                 
                    currentPackage.SeriesID = CpSeriesID ;
                    currentPackage.OrganizationCodeID = ControlUtility.GetDropdownValue(this.dropdownOrganizationCode);
                    currentPackage.IsStandardJNP = false;
                    currentPackage.JNPTitle = this.literalJNPTitle.Text;
                    currentPackage.IsInterdisciplinary = this.checkboxIsInterdisciplinary.Checked;
                    currentPackage.AdditionalSeriesID = ControlUtility.GetDropdownValue(this.dropdownAdditionalSeries);
                    currentPackage.JNPTypeID = cpJNPType;
                    currentPackage.LowestAdvertisedGrade = cpLowGrade;
                    currentPackage.HighestAdvertisedGrade = cpHighGrade ;
                    currentPackage.FullPDID = ControlUtility.GetDropdownValue(this.dropdownFullPD);                                  
                    currentPackage.AdditionalPDID = (cpJNPType == enumJNPType.TwoGrade)? ControlUtility.GetDropdownValue(this.dropdownAdditionalPD):-1;                   
                    currentPackage.DutyLocation = this.textboxDutyLocation.Text;
                    currentPackage.IsDEU = this.checkboxDEU.Checked;
                    currentPackage.IsMP = this.checkboxMP.Checked;
                    currentPackage.IsExceptedService = this.checkboxException.Checked;
                    currentPackage.CreatedByID = base.CurrentUserID;
                    currentPackage.JNPOptionTypeID = eJNPOptionType.CreateFromExisting;
                    currentPackage.CopyFromJNPID = CopyJNPID;
                    currentPackage.AddBasedOnExistingJNP();

                    if (currentPackage.JNPID > 0)
                    {

                        // set values
                        base.CurrentJNPID = currentPackage.JNPID;
                        base.CurrentJAID = currentPackage.JAID;
                        base.CurrentNavMode = enumNavigationMode.Edit;
                        //Bypassing information page
                        base.GoToLink("~/JA/JADuties.aspx", enumNavigationMode.Edit);
                    }
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
    }
}