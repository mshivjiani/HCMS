using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Telerik.Web.UI;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Search;
using HCMS.Business.PD;
using HCMS.Business.Lookups;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.BaseControls;

using HCMS.Business.JNP;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.PD;
using HCMS.Business.CR;

namespace HCMS.JNP.Controls.Search
{
    public partial class SearchReports : JNPUserControlBase
    {
        #region [ Private Predicates ]

        private JNPSearchManager search_manager = new JNPSearchManager();

        private bool filterInactiveItem(RadComboBoxItem listItem)
        {
            return listItem.Value == ((int)enumJNPWorkflowStatus.Inactive).ToString();
        }
        private bool filterOtherGrade(RadComboBoxItem listItem)
        {
            return listItem.Value == "100";
        }
        #endregion

        #region [ Protected Page Event Handlers ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadJobSeries();
                LoadJNPStatus();
                LoadGrade();
                LoadRegion();
                LoadOrganizationCode();
                LoadDocumentType();


                //if (!String.IsNullOrEmpty(Request.QueryString["StandardPDOnly"]))
                //{
                //    rblType.Items.FindByValue("a").Selected = false;
                //    rblType.Items.FindByValue("y").Selected = true;
                //}
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            ToggleSearchNumberRegExp();

            base.OnPreRender(e);
        }

        #endregion

        private void LoadJobSeries()
        {
            List<Series> seriesList = LookupWrapper.GetAllInUseSeries(true);

            foreach (Series series in seriesList)
            {
                RadComboBoxItem item = new RadComboBoxItem(String.Format("{0} | {1}", series.PaddedSeriesID, series.SeriesName), series.SeriesID.ToString());
                rcbJobSeries.Items.Add(item);
            }

            rcbJobSeries.Items.Insert(0, new RadComboBoxItem(String.Empty, "-1"));
        }

        private void LoadJNPStatus()
        {
            ControlUtility.BindRadComboBoxControl(rcbJNPStatus, LookupWrapper.GetAllJNPWorkflowStatus(true), new ControlUtility.RadComboBoxItemFilter(filterInactiveItem), "JNPWorkflowStatusName", "JNPWorkflowStatusID");
            rcbJNPStatus.Items.Insert(0, new RadComboBoxItem(String.Empty, "-1"));
        }

        private void LoadGrade()
        {
            ControlUtility.BindRadComboBoxControl(rcbGrade ,LookupWrapper.GetAllGrades(true),new ControlUtility.RadComboBoxItemFilter (filterOtherGrade ),"GradeName","GradeID");
           

            rcbGrade.Items.Insert(0, new RadComboBoxItem(String.Empty, "-1"));
        }

        private void LoadOrganizationCode()
        {
            OrganizationCodeCollection orgCodeColl;
            rcbOrganizationCode.Items.Clear();

            int RegionID = -1;

            RegionID = Convert.ToInt32(rcbRegion.SelectedValue);

            if (RegionID > 0)
            {
                int regionid = Convert.ToInt32(RegionID);
                orgCodeColl = LookupManager.GetOrganizationCodesByRegion(regionid);
            }
            else
            {
                orgCodeColl = LookupWrapper.GetAllOrganizationCodes(true);
            }
            foreach (OrganizationCode orgCode in orgCodeColl)
            {
                RadComboBoxItem item = new RadComboBoxItem(rdOrgCode.SelectedValue == "n" ? orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName : orgCode.OldOrganizationCode + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                rcbOrganizationCode.Items.Add(item);
            }

            rcbOrganizationCode.Items.Insert(0, new RadComboBoxItem(String.Empty, "-1"));
        }

        private void LoadRegion()
        {
            rcbRegion.DataSource = LookupWrapper.GetAllRegions(true);
            rcbRegion.DataBind();

            rcbRegion.Items.Insert(0, new RadComboBoxItem(string.Empty, "-1"));
        }

        private void LoadDocumentType()
        {
            rcbDocumentType.DataSource = LookupWrapper.GetAllJNPStaffingObjectType(true).Where(staffingObject => (enumStaffingObjectType)staffingObject.StaffingObjectTypeID != enumStaffingObjectType.JNP).ToList();
            rcbDocumentType.DataBind();

            rcbDocumentType.Items.Insert(0, new RadComboBoxItem(string.Empty, "-1"));
        }

        private void ResetSearch1Fields()
        {
            txtSearchNumber.Text = String.Empty;
            //            rblSearchNumberType.SelectedIndex = 0;
        }

        private void ResetSearch2Fields()
        {
            //rblType.SelectedIndex = -1;
            rcbJobSeries.SelectedIndex = -1;
            rcbJNPStatus.SelectedIndex = -1;
            rcbGrade.SelectedIndex = -1;
            txtOpmPositionTitle.Text = string.Empty;
            rcbRegion.SelectedIndex = -1;
            rcbOrganizationCode.SelectedIndex = -1;
            txtJNPCreator.Text = string.Empty;
            rblPackageSuccessRate.SelectedIndex = 0;
        }

        private void ResetSearch3Fields()
        {
            txtKeyword.Text = string.Empty;
            rcbDocumentType.SelectedIndex = -1;
        }

        //This method has no references and this search type is not required.
        //private void SearchForCreatingSODPositionDescriptions()
        //{
        //    try
        //    {
        //        SearchType = 4; //Search for Creating SOD
        //        rcbJobSeries.SelectedValue = "-1";
        //        rblType.SelectedIndex = 1;
        //        rcbJNPStatus.SelectedValue = ((int)PDStatus.Published).ToString(); //SOD can be created only from published PDs
        //        ResetSearch1Fields();
        //        rgSearchResults.Rebind();
        //        h2Caption.Visible = rgSearchResults.Visible = rgSearchResults.Items.Count >= 0;
        //    }
        //    catch { }
        //}

        #region [ Event Handlers ]

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            SearchType = 1;
            ResetSearch2Fields();
            ResetSearch3Fields();
            RebindGrid();
        }

        protected void btnSearch3_Click(object sender, EventArgs e)
        {
            SearchType = 3;
            ResetSearch1Fields();
            ResetSearch2Fields();
            RebindGrid();
        }

        protected void btnSearch4_Click(object sender, EventArgs e)
        {
            SearchType = 2;
            ResetSearch1Fields();
            ResetSearch3Fields();
            RebindGrid();
        }

        private void RebindGrid()
        {
            
            rgSearchResults.CurrentPageIndex = 0;
            rgSearchResults.Rebind();

            h2Caption.Visible = rgSearchResults.Visible = rgSearchResults.Items.Count >= 0;
            divOrgCodemsg.Visible = rgSearchResults.Items.Count > 0;
        }

        protected void rblSearchNumberType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rblSearchNumberType.SelectedValue)
            {
                case "1": lblSearchNumber.Text = "Enter JAX ID: ";
                    break;
                case "2": lblSearchNumber.Text = "Enter PD No.: ";
                    break;
                case "3": lblSearchNumber.Text = "Enter FPPS PD No: ";
                    break;
                case "4": lblSearchNumber.Text = "Enter Vacancy ID: ";
                    break;
            }

            ToggleSearchNumberRegExp();

            // reset the results grid
            //SearchType = 0;
            //RebindGrid();
        }

        private void ToggleSearchNumberRegExp()
        {
            // if the selected Search Number Type is JNP, PDExpress PD Number then
            // the system should validate that it is a numeric input only.
            // For Vacancy ID or FPPSPDID  - it could be alphanumeric
            int searchNumberType = int.Parse(this.rblSearchNumberType.SelectedValue);
            if (searchNumberType == 3 || searchNumberType == 4)
            {
                this.txtSearchNumberRegExpVal.Enabled = false;
            }
            else
            {
                this.txtSearchNumberRegExpVal.Enabled = true;
            }
        }

        #endregion

        #region [ Rad Grid event handlers ]

        private DataTable _dtFiltered = new DataTable();

        private DataTable DTFiltered
        {
            get
            {
                return _dtFiltered;
            }
            set
            {
                _dtFiltered = value;
            }
        }

        private void HideRefreshButton(GridItemEventArgs e)
        {
            GridItem gridItem = e.Item;
            //hide the refresh button Telerik.Web.UI.GridLinkButton
            if (gridItem is GridCommandItem)
            {
                gridItem.FindControl("RebindGridButton").Visible = false;

            }
        }

        protected void rgSearchResults_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            rgSearchResults.MasterTableView.NoMasterRecordsText = "No Job Announcements are found for the selected search criteria. Please search again.";

            if (SearchType == 0)
            {
                rgSearchResults.MasterTableView.NoMasterRecordsText = string.Empty;
            }

            IList<JNPSearchResult> search_results = new List<JNPSearchResult>();

            if (SearchType == 1)
            {
                search_results = search_manager.JNPBasicSearch(UserID, SearchType, JobAnnouncementID, PositionDescriptionID, FPPSPDID, VacancyID);
            }

            if (SearchType == 2 || SearchType == 3)
            {
                search_results = search_manager.JNPAdvanceSearch(UserID, SearchType, IsStandardJNP, JobSeriesID, JNPStatusID, Author, OPMPositionTitle, this.Region, Grade, OrganizationCodeID, PackageSuccessRate, SearchKeyword, SearchKeywordDocumentType);
            }

            rgSearchResults.DataSource = search_results;
        }

        //private void UpdateHiringMenuAttributes(RadMenuItem updateHiringResult, string JNPID)
        //{
        //    updateHiringResult.Attributes.Add("onClick", "javascript:ShowJNPUpdateHiringResultPopUp(" + JNPID + "); return false;");
        //}

        protected void rgSearchResults_ItemDataBound(object sender, GridItemEventArgs e)
        {
            HideRefreshButton(e);
            if (e.Item is GridDataItem)
            {
                try
                {
                    HideRefreshButton(e);

                    GridDataItem dataItem = e.Item as GridDataItem;

                    if (dataItem.ItemType == GridItemType.Item || dataItem.ItemType == GridItemType.AlternatingItem || dataItem.ItemType == GridItemType.SelectedItem)
                    {


                        JNPSearchResult searchResult = (JNPSearchResult)e.Item.DataItem;

                        //Label lblJNPID = dataItem.FindControl("lblJNPID") as Label;
                        Label lblGrade = dataItem.FindControl("lblGrade") as Label;

                        //lblJNPID.Text = searchResult.JNPID.ToString();
                        // 5/7/13 MD: Bug 481 specifically mentions matching how JNPTracker formats the grade field (low/high). 
                        //            Set this condition to 2 to match conditional field formatting found in vw_JNPTrackerItems around line 23
                        if (searchResult.JNPTypeID == 2)
                        {
                            lblGrade.Text = searchResult.LowestAdvertisedGrade.ToString() + "/" + searchResult.HighestAdvertisedGrade.ToString();
                        }
                        else
                        {
                            lblGrade.Text = searchResult.HighestAdvertisedGrade.ToString();
                        }

                        Image imgJNPCheckedOutStatus = dataItem.FindControl("imgJNPCheckedOutStatus") as Image;
                        imgJNPCheckedOutStatus.Visible = false;
                        string checkedoutdt = string.Empty;
                        string editedBy = string.Empty;


                        #region [ Action menu ]

                        RadMenu menuAction = dataItem.FindControl("rmJNPAction") as RadMenu;
                        menuAction.Attributes["JNPID"] = searchResult.JNPID.ToString();
                        RadMenuItem viewMenuItem = menuAction.FindItemByValue("View");
                        RadMenuItem editMenuItem = menuAction.FindItemByValue("Edit");
                        RadMenuItem continueMenuItem = menuAction.FindItemByValue("ContinueEdit");
                        RadMenuItem finishMenuItem = menuAction.FindItemByValue("FinishEdit");
                        RadMenuItem csnMenuItem = menuAction.FindItemByValue("CSN");
                        RadMenuItem updateHiringResult = menuAction.FindItemByValue("UpdateHiringResult");

                        viewMenuItem.Visible = searchResult.CanView;
                        editMenuItem.Visible = searchResult.CanEdit;
                        continueMenuItem.Visible = searchResult.CanContinueEdit;
                        finishMenuItem.Visible = searchResult.CanFinishEdit;
                        //csnMenuItem.Visible = searchResult.CanCopyStartNew;

                        if (searchResult.CheckedActionTypeID == (int)enumActionType.CheckOut)
                        {
                            if (searchResult.CheckedDate.HasValue)
                            {
                                checkedoutdt = string.Format(searchResult.CheckedDate.ToString(), "d");

                                editedBy = String.Format("Being edited by {0} since {1}", searchResult.CheckedByFullName, checkedoutdt);

                                imgJNPCheckedOutStatus.Visible = true;

                            }

                            if (searchResult.CheckedByID == base.CurrentUserID)
                            {
                                imgJNPCheckedOutStatus.ImageUrl = Page.ResolveUrl(String.Format("~/App_Themes/{0}/Images/Icons/icon_unlock.gif", Page.Theme));
                            }
                            else
                            {
                                imgJNPCheckedOutStatus.ImageUrl = Page.ResolveUrl(String.Format("~/App_Themes/{0}/Images/Icons/icon_lock.gif", Page.Theme));
                                imgJNPCheckedOutStatus.ToolTip = editedBy;
                                dataItem.ToolTip = editedBy;
                            }
                        }

                        // Hide these two dropdown options unless the package is published
                        updateHiringResult.Visible = false;
                        csnMenuItem.Visible = false;
                        if (searchResult.JNPWorkflowStatus == enumJNPWorkflowStatus.Published.ToString())
                        {
                            // Make sure user has org code matching org code of published package
                            if (IsAdmin || CurrentUser.GetAssignedOrganizationCodes().Contains(searchResult.OrganizationCodeID))
                            {
                                updateHiringResult.Visible = true;
                                csnMenuItem.Visible = true;
                                //UpdateHiringMenuAttributes(updateHiringResult, lblJNPID.Text);
                            }
                        }


                        #endregion

                        #region [ Document menu ]

                        bool hasComments = JNPackage.JNPHasComments(Convert.ToInt64(searchResult.JNPID.ToString()));
                        //bool hasComments = JNPackage.JNPHasComments(Convert.ToInt64(lblJNPID.Text));


                        RadMenu menuDocument = dataItem.FindControl("rmDocument") as RadMenu;
                        menuDocument.Attributes["JNPID"] = searchResult.JNPID.ToString();
                        menuDocument.Attributes["JAID"] = searchResult.JobAnalysisID.ToString();
                        menuDocument.Attributes["CRID"] = searchResult.CategoryRatingID.ToString();
                        menuDocument.Attributes["JQID"] = searchResult.JobQuestionnaireID.ToString();


                        ToggleDocumentMenuItem(menuDocument, (int)enumDocumentType.JA, searchResult.JobAnalysisID);                        
                        ToggleDocumentMenuItem(menuDocument, (int)enumDocumentType.JQ, searchResult.JobQuestionnaireID);
                        ToggleDocumentMenuItem(menuDocument, (int)enumDocumentType.JQ, searchResult.JobQuestionnaireID);

                        //Issue #124 - Modify SearchReports  -  Modify to not display CR if not active under documents column 
                        RadMenuItem categoryRating = menuDocument.FindItemByValue("2");
                        RadMenuItem categoryRating22 = menuDocument.FindItemByValue("22");
                        if (CheckIfCRIsActive(Convert.ToInt64(searchResult.CategoryRatingID)) == true)
                        {
                            categoryRating.Visible = true;
                            if (categoryRating22 != null) categoryRating22.Visible = true;
                        }
                        else
                        {
                            categoryRating.Visible = false;
                            if (categoryRating22 != null) categoryRating22.Visible = false;
                        }

                        //Shot Comment item only if comment is available.
                        RadMenuItem CommentsPDF = menuDocument.FindItemByValue("4");
                        RadMenuItem CommentsDOC = menuDocument.FindItemByValue("44");
                        if (hasComments)
                        {
                            if (CommentsPDF != null) CommentsPDF.Visible = true;
                            if (CommentsDOC != null) CommentsDOC.Visible = true;
                        }
                        else
                        {
                            if (CommentsPDF != null) CommentsPDF.Visible = false;
                            if (CommentsDOC != null) CommentsDOC.Visible = false;
                        }

                        //Date: 06/27/2013                        
                        //Issue # 210: Hiring Manager can preview extract in UTF-8 format via search. 
                        // HM shouldn't be able to preview an extract in UTF-8 format via search.
                        RadMenuItem UTF8Doc = menuDocument.FindItemByValue("5");
                        if (base.HasHRGroupPermission)
                            UTF8Doc.Visible = true;
                        else
                            UTF8Doc.Visible = false;

                        #endregion
                    }

                }
                catch (Exception ex)
                {
                    base.HandleException(ex);
                }
            }
        }

        #endregion
        private bool? CheckIfCRIsActive(long crid)
        {
            if (crid > 0)
            {
                CategoryRating categoryRating = CategoryRatingManager.GetByID(Convert.ToInt64(crid));
                return categoryRating.IsActive;
            }
            else
                return false;
        }
        

        private void ToggleDocumentMenuItem(RadMenu menuDocument, int menuId, long? valueId)
        {
            if (valueId.HasValue && valueId.Value > 0)
            {
                menuDocument.Items[0].Items[menuId].Visible = true;
            }
            else
            {
                menuDocument.Items[0].Items[menuId].Visible = false;
            }
        }
        #region [ Context Menu handlers ]

        protected void rmJNPAction_ItemClick(object sender, RadMenuEventArgs e)
        {
            RadMenu rmJNPAction = sender as RadMenu;
            long JNPID = Convert.ToInt64(rmJNPAction.Attributes["JNPID"]);
            enumNavigationMode currentNavigationMode = enumNavigationMode.None;
            WorkflowObject wo = new WorkflowObject();
            wo.StaffingObjectTypeID = enumStaffingObjectType.JNP;
            wo.StaffingObjectID = JNPID;
            wo.UserID = CurrentUserID;
            base.CurrentJNPID = JNPID;
            try
            {
                //bool navigateToActiveDocument = false;
                switch (e.Item.Value)
                {
                    case "View":
                        this.CurrentJNPID = JNPID;
                        //navigateToActiveDocument = true;
                        currentNavigationMode = enumNavigationMode.View;
                        GoToLink("~/JA/JAPositionInformation.aspx", currentNavigationMode);
                        break;
                    case "Edit":
                        wo.ActionTypeID = enumActionType.CheckOut;
                        WorkflowManager.CheckJNP(wo);
                        this.CurrentJNPID = JNPID;
                        //navigateToActiveDocument = true;
                        currentNavigationMode = enumNavigationMode.Edit;
                        GoToLink("~/JA/JAPositionInformation.aspx", currentNavigationMode);
                        break;
                    case "ContinueEdit":
                        this.CurrentJNPID = JNPID;
                        //navigateToActiveDocument = true;
                        currentNavigationMode = enumNavigationMode.Edit;
                        GoToLink("~/JA/JAPositionInformation.aspx", currentNavigationMode);
                        break;
                    case "FinishEdit":
                        wo.ActionTypeID = enumActionType.CheckIn;
                        WorkflowManager.CheckJNP(wo);
                        break;
                    case "UpdateHiringResult":
                        //GoToLink("~/Package/UpdateHiringResult.aspx");                                           
                        //CurrentJNPID = JNPID;
                        //rmJNPAction.Attributes.Add("onClick", "javascript:ShowJNPUpdateHiringResultPopUp(" + JNPID.ToString() + "); return false;");
                        ShowUpdateHiringResultWindow(JNPID);
                        break;
                    case "CSN":
                        //GoToLink("~/Package/CopyJNPFromExisting.aspx?CopyJNPID=" + JNPID.ToString());

                        if (JNPID > 0)
                        {
                            //Fixed JA issue 906 -Classifier 14's My Tracker missing packages that Classifier creates by copying from existing pacakges. 
                            //addjnpfrom existing jnp - newpackage.createdbyid is set based on current userid
                            
                            JNPackage NewPackage = new JNPackage();
                            JNPackage existingPackage = new JNPackage(JNPID);
                            NewPackage.PayPlanID = existingPackage.PayPlanID;
                            NewPackage.RegionID = existingPackage.RegionID;
                            NewPackage.SeriesID = existingPackage.SeriesID;
                            NewPackage.OrganizationCodeID = existingPackage.OrganizationCodeID;
                            NewPackage.IsStandardJNP = existingPackage.IsStandardJNP;
                            NewPackage.JNPTitle = existingPackage.JNPTitle;
                            NewPackage.IsInterdisciplinary = existingPackage.IsInterdisciplinary;
                            NewPackage.AdditionalSeriesID = existingPackage.AdditionalSeriesID;
                            NewPackage.JNPTypeID = existingPackage.JNPTypeID;
                            NewPackage.LowestAdvertisedGrade = existingPackage.LowestAdvertisedGrade;
                            NewPackage.HighestAdvertisedGrade = existingPackage.HighestAdvertisedGrade;
                            NewPackage.FullPDID = existingPackage.FullPDID;
                            NewPackage.AdditionalPDID = existingPackage.AdditionalPDID;
                            NewPackage.DutyLocation = existingPackage.DutyLocation;
                            NewPackage.IsDEU = existingPackage.IsDEU;
                            NewPackage.IsMP = existingPackage.IsMP;
                            NewPackage.IsExceptedService = existingPackage.IsExceptedService;
                            NewPackage.CreatedByID = base.CurrentUserID;
                            NewPackage.JNPOptionTypeID = eJNPOptionType.CreateFromExisting;
                            NewPackage.CopyFromJNPID = JNPID;
                            NewPackage.AddBasedOnExistingJNP();

                            base.CurrentJNPID = NewPackage.JNPID;
                            base.CurrentJAID = NewPackage.JAID;
                            base.CurrentNavMode = enumNavigationMode.Edit;

                            ReloadCurrentJNP(NewPackage.JNPID);

                            GoToLink("~/JA/JAPositionInformation.aspx");
                        }

                        
                        break;
                    default:
                        break;
                }

                rgSearchResults.Rebind();               
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }

        private void ShowUpdateHiringResultWindow(long JNPID)
        {
            RadWindowManager1.Windows.Clear();
            string script = string.Format("ShowJNPUpdateHiringResultPopUp('{0}');", JNPID);
            RadWindowManager1.Windows.Add(rwJNPUpdateHiringResult);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowJNPUpdateHiringResultPopUp", script, true);
        }

        protected void rmDocument_ItemClick(object sender, RadMenuEventArgs e)
        {
            RadMenu rmDocument = sender as RadMenu;

            long JNPID = Convert.ToInt64(rmDocument.Attributes["JNPID"]);
            long JAID = Convert.ToInt64(rmDocument.Attributes["JAID"]);
            long CRID = Convert.ToInt64(rmDocument.Attributes["CRID"]);
            long JQID = Convert.ToInt64(rmDocument.Attributes["JQID"]);

            //For report purpose
            HCMS.Business.JNP.JNPManager.jnpid = JNPID;

            //Issue Id: 40
            //Author: Deepali Anuje
            //Date Fixed: 1/23/2012
            //Description: Not able to View Docs: Error Msg 
            //Resolution: Added Resolve URL to URLStrings.
            switch (e.Item.Value)
            {
                /*
                "Job Analysis(PDF)" Value="1" />
                "Job Analysis(DOC)" Value="11" />
                "Category Rating(PDF)" Value="2" />
                "Category Rating(DOC)" Value="22" />
                "Job Questionnaire(PDF)" Value="3" />
                "Job Questionnaire(DOC)" Value="33" />
                "Job Questionnaire-UTF8" Value="5" />
                "Comments(PDF)" Value="4" />
                "Comments(DOC)" Value="44" />
                "All(PDF)" Value="6" />
                "All(DOC)" Value="66" />
                 */

                case "1": //Job Analysis(PDF)
                    radAjaxmgrReports.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}", JNPID, (int)enumDocumentType.JA, enumDocumentFormat.PDF, JAID)));
                    break;
                case "11"://Job Analysis(DOC)
                    radAjaxmgrReports.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}", JNPID, (int)enumDocumentType.JA, enumDocumentFormat.DOCX, JAID)));
                    break;
                case "2"://Category Rating(PDF)
                    radAjaxmgrReports.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}&crid={4}", JNPID, (int)enumDocumentType.CR, enumDocumentFormat.PDF, JAID,CRID)));
                    break;
                case "22"://Category Rating(DOC)
                    radAjaxmgrReports.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}&crid={4}", JNPID, (int)enumDocumentType.CR, enumDocumentFormat.DOCX, JAID,CRID)));
                    break;
                case "3"://Job Questionnaire(PDF)
                    radAjaxmgrReports.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}", JNPID, (int)enumDocumentType.JQ, enumDocumentFormat.PDF, JAID)));
                    break;
                case "33"://Job Questionnaire(DOC)
                    radAjaxmgrReports.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}", JNPID, (int)enumDocumentType.JQ, enumDocumentFormat.DOCX, JAID)));
                    break;
                case "4"://Comments(PDF)
                    radAjaxmgrReports.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}", JNPID, (int)enumDocumentType.Comments, enumDocumentFormat.PDF, JAID)));
                    break;
                case "44"://Comments(DOC)
                    radAjaxmgrReports.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}", JNPID, (int)enumDocumentType.Comments, enumDocumentFormat.DOCX, JAID)));
                    break;
                case "5"://Job Questionnaire-UTF8
                    radAjaxmgrReports.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}", JNPID, (int)enumDocumentType.JQ, enumDocumentFormat.UTF8, JAID)));
                    break;
                case "6": // All documents
                    radAjaxmgrReports.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}&jqid={4}&crid={5}", JNPID, (int)enumDocumentType.All , enumDocumentFormat.PDF, JAID, JQID, CRID)));
                    break;
                case "66": // All documents
                    radAjaxmgrReports.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}&jqid={4}&crid={5}", JNPID, (int)enumDocumentType.All, enumDocumentFormat.DOCX, JAID, JQID, CRID)));
                    break;
            } 

            e.Item.Selected = false;
        }

        protected void rdOrgCode_Changed(object sender, EventArgs e)
        {

            OrganizationCodeCollection orgCodeColl;
            rcbOrganizationCode.Items.Clear();

            int RegionID = -1;

            RegionID = Convert.ToInt32(rcbRegion.SelectedValue);

            if (RegionID > 0)
            {
                int regionid = Convert.ToInt32(RegionID);
                orgCodeColl = LookupManager.GetOrganizationCodesByRegion(regionid);
            }
            else
            {
                orgCodeColl = LookupWrapper.GetAllOrganizationCodes(true);
            }

            switch (rdOrgCode.SelectedValue)
            {
                case "n":

                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        rcbOrganizationCode.Items.Add(item);
                    }
                    break;
                case "o":
                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OldOrganizationCode + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        rcbOrganizationCode.Items.Add(item);
                    }
                    break;
                default:
                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        rcbOrganizationCode.Items.Add(item);
                    }
                    break;
            }

            rcbOrganizationCode.Items.Insert(0, new RadComboBoxItem(String.Empty, "-1"));
        }

        protected void rcbRegion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LoadOrganizationCode();
        }


        #endregion

        #region [ Check in / check out ]

        private bool CanCheckOut(long positionDescriptionID)
        {
            bool canCheckOut = false;

            try
            {
                PositionDescription thisPD = new PositionDescription(positionDescriptionID);
                //bool isPDCreator =thisPD.PDCreatorID.Equals(base.CurrentUser.UserID);
                //bool isPDCreatorSupervisor = base.CurrentUser.IsPDCreatorSupervisor(thisPD.PositionDescriptionID);
                PDAccessType access = base.GetPDAccessType(thisPD);
                if (thisPD.GetCurrentPDStatus() == PDStatus.Draft || thisPD.GetCurrentPDStatus() == PDStatus.Revise)
                    canCheckOut = (access != PDAccessType.ReadOnly); // commenting this check also because the check is already performed in GetPDAccessType function && (isPDCreator ||isPDCreatorSupervisor);// base.HasPermission(enumPermission.CreatePD) && !base.HasPermission(enumPermission.CompleteHRCertification);
                else if (thisPD.GetCurrentPDStatus() == PDStatus.Review || thisPD.GetCurrentPDStatus() == PDStatus.FinalReview)
                    canCheckOut = (access != PDAccessType.ReadOnly) && (base.HasPermission(enumPermission.CompleteHRCertification));
                else
                    canCheckOut = (access != PDAccessType.ReadOnly);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            return canCheckOut;
        }

        private bool CanContinueEdit(int checkedOutByID)
        {
            bool canContinueEdit = false;

            try
            {
                if (checkedOutByID == CurrentUser.UserID)
                {
                    canContinueEdit = true;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            return canContinueEdit;
        }

        private bool CanCheckIn(int checkedOutByID)
        {
            bool canCheckIn = false;

            try
            {
                if (base.HasPermission(enumPermission.CompleteHRCertification) ||
                    base.HasPermission(enumPermission.CompleteHRCertification15) ||
                    base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
                    checkedOutByID == base.CurrentUser.UserID)
                {
                    canCheckIn = true;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            return canCheckIn;
        }

        #endregion

        #region [ Private Properties ]

        private int SearchType
        {
            get
            {
                int searchType = 0;

                if (!String.IsNullOrEmpty(hfSearchType.Value))
                    searchType = Convert.ToInt32(hfSearchType.Value);

                return searchType;
            }
            set
            {
                if (!String.IsNullOrEmpty(hfSearchType.Value))
                    hfSearchType.Value = value.ToString();
                else
                    hfSearchType.Value = "0";
            }
        }

        private int UserID
        {
            get
            {
                return base.CurrentUser.UserID;
            }
        }

        private long? JobAnnouncementID
        {
            get
            {
                long? return_var = null;

                if (int.Parse(this.rblSearchNumberType.SelectedValue) == 1)
                {
                    return_var = Convert.ToInt64(txtSearchNumber.Text);
                }

                return return_var;
            }
        }

        private int? PositionDescriptionID
        {
            get
            {
                int? return_var = null;

                if (int.Parse(this.rblSearchNumberType.SelectedValue) == 2)
                {
                    return_var = Convert.ToInt32(txtSearchNumber.Text);
                }

                return return_var;
            }
        }

        private string FPPSPDID
        {
            get
            {
                string return_var = null;

                if (int.Parse(this.rblSearchNumberType.SelectedValue) == 3)
                {
                    return_var = txtSearchNumber.Text;
                }

                return return_var;
            }
        }

        private string VacancyID
        {
            get
            {
                string return_var = null;

                if (int.Parse(this.rblSearchNumberType.SelectedValue) == 4)
                {
                    return_var = txtSearchNumber.Text;
                }

                return return_var;
            }
        }

        private bool? IsStandardJNP
        {
            get
            {
                bool? return_var = null;

                //if (rblType.SelectedValue == "1")
                //    return_var = true;

                //if (rblType.SelectedValue == "2")
                //    return_var = false;

                // if SelectedValue == 3 then var is already null meaning All status will be considered

                return return_var;
            }
        }



        private int? JobSeriesID
        {
            get
            {
                int? return_var = null;

                int selectedval = Convert.ToInt32(rcbJobSeries.SelectedValue);

                if (selectedval > 0)
                    return_var = selectedval;

                return return_var;
            }

        }

        private int? JNPStatusID
        {
            get
            {
                int? return_var = null;

                int selectedval = Convert.ToInt32(rcbJNPStatus.SelectedValue);

                if (selectedval > 0)
                    return_var = selectedval;

                return return_var;
            }
        }


        // this.PackageSucccessRate, this.Keyword

        private string Author
        {
            get
            {
                string return_var = null;

                if (!string.IsNullOrWhiteSpace(this.txtJNPCreator.Text))
                {
                    return_var = txtJNPCreator.Text;
                }

                return return_var;
            }
        }

        private string OPMPositionTitle
        {
            get
            {
                string return_var = null;

                if (!string.IsNullOrWhiteSpace(this.txtOpmPositionTitle.Text))
                {
                    return_var = txtOpmPositionTitle.Text;
                }

                return return_var;
            }
        }

        private int? Region
        {
            get
            {
                int? return_var = null;

                int selectedval = Convert.ToInt32(this.rcbRegion.SelectedValue);

                if (selectedval > 0)
                    return_var = selectedval;

                return return_var;
            }
        }

        private int? Grade
        {
            get
            {
                int? return_var = null;

                int selectedval = Convert.ToInt32(this.rcbGrade.SelectedValue);

                if (selectedval > 0)
                    return_var = selectedval;

                return return_var;
            }
        }

        private int? OrganizationCodeID
        {
            get
            {
                int? return_var = null;

                int selectedval = Convert.ToInt32(this.rcbOrganizationCode.SelectedValue);

                if (selectedval > 0)
                    return_var = selectedval;

                return return_var;
            }
        }

        public bool? PackageSuccessRate
        {
            get
            {
                bool? return_var = null;

                if (rblPackageSuccessRate.SelectedValue == "1")
                    return_var = true;

                if (rblPackageSuccessRate.SelectedValue == "2")
                    return_var = false;

                // if SelectedValue == 3 then var is already null meaning All Package Success Rate will be considered

                return return_var;
            }

        }

        private string SearchKeyword
        {
            get
            {
                string return_var = null;

                if (!string.IsNullOrWhiteSpace(this.txtKeyword.Text))
                {
                    return_var = txtKeyword.Text;
                }

                return return_var;
            }
        }

        private int? SearchKeywordDocumentType
        {
            get
            {
                int? return_var = null;

                int selectedval = Convert.ToInt32(this.rcbDocumentType.SelectedValue);

                if (selectedval > 0)
                    return_var = selectedval;

                return return_var;
            }
        }


        //Keshab - this property is no longer in use. It needs to be removed
        private bool? SearchForCreatingSOD
        {
            get
            {
                bool? searchforcreatesod = null;
                if (!String.IsNullOrEmpty(Request.QueryString["SOD"]))
                    searchforcreatesod = Convert.ToBoolean(Request.QueryString["SOD"]);

                return searchforcreatesod;
            }
        }

        #endregion

    }
}
