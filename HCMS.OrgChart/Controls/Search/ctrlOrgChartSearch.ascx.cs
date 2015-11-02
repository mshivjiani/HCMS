using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using Telerik.Web.UI;

using System.Web.UI.HtmlControls;
using HCMS.Business.Lookups;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.Lookups.Collections;
using System.Data;
using HCMS.Business.OrganizationChart;
using HCMS.Business.Base;
using HCMS.Business.OrganizationChart.Search;

using System.Collections.ObjectModel;
using HCMS.Business.Lookups.Repositories;
using HCMS.Business.OrganizationChart.Published;

namespace HCMS.OrgChart.Controls.Search
{

    public partial class ctrlOrgChartSearch : OrgChartUserControlBase
    {
        

        #region [ Protected Page Event Handlers ]
        protected override void OnInit(EventArgs e)
        {
            MasterPage master=this.Page.Master ;
            RadAjaxManager rmanager = master.FindControl("mainRadAJAXManagerMaster") as RadAjaxManager;
            if (rmanager != null)
            {
                rmanager.ClientEvents.OnRequestStart = "RequestStart";
                rmanager.ClientEvents.OnResponseEnd = "ResponseEnd";
            }

            base.OnInit(e);
        }  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtOrganizationChartID.Text = string.Empty;
                ResetAdvancedSearchFields();
            }
        }
        protected override void OnPreRender(EventArgs e)
        {

            base.OnPreRender(e);
        }

        #endregion

        #region [ Load Controls]
        private void ResetAdvancedSearchFields()
        {
            LoadRegion();
            LoadOrganizationCode();
            LoadOrgChartType();
            LoadChartStatus();
            LoadJobSeries();
            LoadPublishedYear();
            rdOrgCode.SelectedIndex = 0;
           
            txtChartApprover.Text = string.Empty;
            txtChartCreator.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            trPublishedYear.Visible = false;
            trApprover.Visible = false;
        }
        private void LoadRegion()
        {
            List<Region> regions = CurrentUser.GetListOfAssignedRegions();
            if (regions.Count == 1)
            {
                ControlUtility.BindRadComboBoxControl(rcbRegion, regions, null, "RegionName", "RegionID", "<<--Select Region-->>", regions[0].RegionID.ToString());
                rcbRegion.Enabled = false;
                
            }
            else
                ControlUtility.BindRadComboBoxControl(rcbRegion, regions, null, "RegionName", "RegionID", "<<--Select Region-->>",null);

        }
        private void LoadOrganizationCode()
        {
            OrganizationCodeCollection orgCodeColl = new OrganizationCodeCollection();
            orgCodeColl = CurrentUser.GetAssignedOrganizationCodes();
            //remove Org Code 0 from the list
            OrganizationCode spdOrgCode = new OrganizationCode();
            spdOrgCode.OrganizationCodeID = 1;
            orgCodeColl.Remove(spdOrgCode);

            rcbOrganizationCode.Items.Clear();

            int RegionID = -1;
            RegionID = Convert.ToInt32(rcbRegion.SelectedValue);
            enumOrgFormat format =enumOrgFormat.New;
            if (rdOrgCode.SelectedIndex > -1)
            {
                string strformat = rdOrgCode.SelectedValue;
                Enum.TryParse<enumOrgFormat>(strformat, true, out format);
            }
           
            if (RegionID > 0)
            {
                OrganizationCodeCollection filteredbyregion = orgCodeColl.GetByRegion(RegionID);
                if (format==enumOrgFormat.New)
                {
                    ControlUtility.BindRadComboBoxControl(rcbOrganizationCode, filteredbyregion, null, "NewOrgCodeLine", "OrganizationCodeID","<<--Select Organization -->>");
                }
                else
                {
                    ControlUtility.BindRadComboBoxControl(rcbOrganizationCode, filteredbyregion, null, "OldOrgCodeLine", "OrganizationCodeID", "<<--Select Organization -->>");
                }
               
            }
            else
            {
                if (format==enumOrgFormat.New)
                {
                    ControlUtility.BindRadComboBoxControl(rcbOrganizationCode, orgCodeColl, null, "NewOrgCodeLine", "OrganizationCodeID", "<<--Select Organization -->>");
                }
                else
                {
                    ControlUtility.BindRadComboBoxControl(rcbOrganizationCode, orgCodeColl, null, "OldOrgCodeLine", "OrganizationCodeID", "<<--Select Organization -->>");
                }

            }

            
        }
        private void LoadOrgChartType()
        {
            List<OrgChartType> ocTypeList = OrgChartTypeRepository.Instance.GetAllOrgChartTypes();

            ControlUtility.BindRadComboBoxControl(rcbOrgChartType, ocTypeList, null, "OrgChartTypeDesc", "OrgChartTypeID","<<--Select Chart Type-->>");
        }
        private void LoadChartStatus()
        {

            List<OrgWorkflowStatus> wfList = OrgWorkflowStatusManager.GetAllOrgWorkflowStatus();

            ControlUtility.BindRadComboBoxControl(rcbChartStatus, wfList, null, "OrgWorkflowStatusDesc", "OrgWorkflowStatusID","<<--Select Chart Status-->>" );

        }
        private void LoadJobSeries() 
        {
            List<Series> seriesList = LookupWrapper.GetAllSeries(true);

            ControlUtility.BindRadComboBoxControl(rcbJobSeries, seriesList, null, "DetailLine", "SeriesID", "<<--Select Series-->>");

        } 
        private void LoadPublishedYear()
        {
            List<int> yearList = OrganizationChartLogManager.Instance.GetOrgChartPublishedYears();
            rcbPublishedYear.DataSource = yearList;
            rcbPublishedYear.DataBind();
            rcbPublishedYear.Items.Insert(0, new RadComboBoxItem("<<--Select Published Year-->>", "-1"));

        }

        #endregion

        #region [ Event Handlers ]
        protected void ResetAll()
        {
           
            txtOrganizationChartID.Text = string.Empty;
            ResetAdvancedSearchFields();
            rgSearchResults.DataSource = null;
            rgSearchResults.DataBind();
        }
        protected void rdOrgCode0_Changed(object sender, EventArgs e)
        {
            
            LoadOrganizationCode();

        }
        protected void rdOrgCode_Changed(object sender, EventArgs e)
        {
             
             LoadOrganizationCode();

        }

        protected void rcbRegion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            //added this to clear the grid source otherwise if it was  populated once and then reset was clicked and then region is selected,
            //the grid used to show empty rows 
            rgSearchResults.DataSource = null;
            rgSearchResults.DataBind();

            LoadOrganizationCode();
        }

        protected void rcbChartStatus_OnSelectedIndexChange(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (ChartStatusID == enumOrgWorkflowStatus.Published)
            {
                trPublishedYear.Visible = true;
                trApprover.Visible = true;
            }
            else
            {
                trPublishedYear.Visible = false;
                trApprover.Visible = false;
            }
        }
        protected void btnSearchByID_Click(object sender, EventArgs e)
        {
           
            ResetAdvancedSearchFields();
            RebindGrid();
        }
      
        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            
           txtOrganizationChartID.Text = string.Empty;
           RebindGrid();
        }
      
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();

        } 
        private void RebindGrid()
        {

            rgSearchResults.CurrentPageIndex = 0;
            rgSearchResults.Rebind();
            h2Caption.Visible = rgSearchResults.Visible = rgSearchResults.Items.Count >= 0;
            divOrgCodemsg.Visible = rgSearchResults.Items.Count > 0;
        }

        #endregion

        #region [ Rad Grid event handlers ]

        private void HideRefreshButton(GridItemEventArgs e)
        {
            GridItem gridItem = e.Item;
            //hide the refresh button Telerik.Web.UI.GridLinkButton
            if (gridItem is GridCommandItem)
            {
                gridItem.FindControl("RebindGridButton").Visible = false;

            }
        }
        protected OrgChartSearchResultCollection  GetSearchResults()
        {
            OrgChartSearchResultCollection search_results = new OrgChartSearchResultCollection ();
            try
            {
                List<OrgChartSearchResult> loadresults=OrgChartSearchManager.Instance.LoadSearchResults(CurrentUserID, OrgChartID, OrgChartTypeID, OrganizationCodeID, ChartStatusID, RegionID, Creater, Approver, PublishedYear, JobSeriesID, EmployeeName);
                
                foreach (OrgChartSearchResult item in loadresults)
                {
                    search_results.Add(item);
                }
                search_results.OrderBy(enumOrgChartResultSortField.OrganizationChartID, enumSortDirection.ASC);
            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex.Message, true);
            }


            return search_results;

        }
        protected void rgSearchResults_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            rgSearchResults.MasterTableView.NoMasterRecordsText = "No Organization Chart are found for the selected search criteria. Please search again.";
            rgSearchResults.DataSource = GetSearchResults();
        }
        protected void rgSearchResults_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                try
                {
                    HideRefreshButton(e);

                    GridDataItem dataItem = e.Item as GridDataItem;

                    if (dataItem.ItemType == GridItemType.Item || dataItem.ItemType == GridItemType.AlternatingItem || dataItem.ItemType == GridItemType.SelectedItem)
                    {
                        OrgChartSearchResult searchResult = (OrgChartSearchResult)e.Item.DataItem;

                        Image imgORGCHARTCheckedOutStatus = dataItem.FindControl("imgORGCHARTCheckedOutStatus") as Image;
                        imgORGCHARTCheckedOutStatus.Visible = false;
                        string checkedoutdt = string.Empty;
                        string editedBy = string.Empty;





                        #region [ Action menu/ Document Menu]

                        //Action Menu
                        RadMenu menuAction = dataItem.FindControl("rmOrgChartMenuAction") as RadMenu;                        
                        RadMenuItem viewMenuItem = menuAction.FindItemByValue("View");
                        RadMenuItem viewPublishedMenuItem = menuAction.FindItemByValue("ViewPublished");
                        RadMenuItem editMenuItem = menuAction.FindItemByValue("Edit");
                        RadMenuItem continueMenuItem = menuAction.FindItemByValue("ContinueEdit");
                        RadMenuItem finishMenuItem = menuAction.FindItemByValue("FinishEdit");
                        RadMenuItem deleteMenuItem = menuAction.FindItemByValue("Delete");

                        //Document Menu
                        RadMenu menuDocument = dataItem.FindControl("rmDocument") as RadMenu;
                        RadMenuItem InProcessPDFMenuItem = menuDocument.FindItemByValue("1");
                        RadMenuItem PublishedPDFMenuItem = menuDocument.FindItemByValue("2");


                        if (searchResult.IsCheckedOut)
                        {
                            // At this point, we know this has to be an OrgChart because it is checked out
                            // But let's be safe

                            if (searchResult.ChartEntity is OrganizationChart)
                            {
                                OrganizationChart chart = searchResult.ChartEntity as OrganizationChart;

                                if (chart != null)
                                {
                                    if (chart.CheckedOutBy.ActionDate.HasValue)
                                    {
                                        checkedoutdt = string.Format(chart.CheckedOutBy.ActionDate.Value.ToString(), "d");

                                        editedBy = String.Format("Being edited by {0} since {1}", chart.CheckedOutBy.FullName, checkedoutdt);

                                        imgORGCHARTCheckedOutStatus.Visible = true;

                                    }

                                    if (chart.CheckedOutBy.UserID == base.CurrentUserID)
                                    {
                                        imgORGCHARTCheckedOutStatus.ImageUrl = Page.ResolveUrl(String.Format("~/App_Themes/{0}/Images/Icons/icon_unlock.gif", Page.Theme));
                                    }
                                    else
                                    {
                                        imgORGCHARTCheckedOutStatus.ImageUrl = Page.ResolveUrl(String.Format("~/App_Themes/{0}/Images/Icons/icon_lock.gif", Page.Theme));
                                        imgORGCHARTCheckedOutStatus.ToolTip = editedBy;
                                        dataItem.ToolTip = editedBy;
                                    }
                                }
                            }
                        }
                            
                        //Action Menu visibility    
                        deleteMenuItem.Visible = searchResult.CanDelete;
                        editMenuItem.Visible = searchResult.CanEdit;
                        finishMenuItem.Visible = searchResult.CanFinishEdit;
                        continueMenuItem.Visible = searchResult.CanContinueEdit;

                        //Action/Document Menu visibility and data field setting
                        if (searchResult.ChartEntity is OrganizationChartLog)
                        {
                            OrganizationChartLog orgchartlog=(OrganizationChartLog)searchResult.ChartEntity ;

                            menuAction.DataFieldID =orgchartlog.OrganizationChartLogID.ToString();
                            menuAction.Attributes["OrganizationChartLogID"] = orgchartlog.OrganizationChartLogID.ToString();
                            
                            viewPublishedMenuItem.Visible = true;
                            viewMenuItem.Visible = false;


                            menuDocument.DataFieldID = orgchartlog.OrganizationChartLogID.ToString();
                            menuDocument.Attributes["OrganizationChartLogID"] = orgchartlog.OrganizationChartLogID.ToString();
                            menuDocument.Attributes["OrganizationChartID"] = string.Empty;
                            //this is for Export to excel
                            menuDocument.Attributes["OrgChartID"] = orgchartlog.OrganizationChartID.ToString();

                            PublishedPDFMenuItem.Visible = true;
                            InProcessPDFMenuItem.Visible = false;
                        }
                        else
                        {
                            menuAction.DataFieldID = searchResult.ChartEntity.OrganizationChartID.ToString();
                            menuAction.Attributes["OrganizationChartID"] = searchResult.ChartEntity.OrganizationChartID.ToString();
                            
                            viewPublishedMenuItem.Visible = false;

                            if ((searchResult.ChartEntity is OrganizationChart) && (!searchResult.CanContinueEdit))
                            { viewMenuItem.Visible = true; }
                            else
                            { viewMenuItem.Visible = false; }


                            menuDocument.DataFieldID = searchResult.ChartEntity.OrganizationChartID.ToString();
                            menuDocument.Attributes["OrganizationChartID"] = searchResult.ChartEntity.OrganizationChartID.ToString();
                            menuDocument.Attributes["OrganizationChartLogID"] = string.Empty;
                            //this is for Export to excel
                            menuDocument.Attributes["OrgChartID"] = searchResult.ChartEntity.OrganizationChartID.ToString();
                            InProcessPDFMenuItem.Visible = true;
                            PublishedPDFMenuItem.Visible = false;
                        }
                        #endregion


                       
                    }

                }
                catch (Exception ex)
                {
                    base.HandleException(ex);
                }
            }
        }
        protected void rgSearchResults_ItemClick(object sender, RadMenuEventArgs e)
        {
            RadMenu menu = (RadMenu)sender;

            int OrganizatinChartID = int.Parse(menu.DataFieldID);

            enumNavigationMode currentNavigationMode = enumNavigationMode.None;
            if (OrganizatinChartID > 0)
            {
                
                try
                {

                    switch (e.Item.Value)
                    {
                        case "View":
                            ResetCurrentOrgChart(OrganizatinChartID);
                            currentNavigationMode = enumNavigationMode.View;
                            GoToOrgChartLink("~/OrgChart/OrgChartDetails.aspx", currentNavigationMode);
                            break;
                        case "ViewPublished":
                            ResetCurrentOrgChartLog(OrganizatinChartID);
                            currentNavigationMode = enumNavigationMode.View;                            
                            GoToOrgChartLink("~/PubOrgChart/OrgChartDetails.aspx", currentNavigationMode);
                            break;
                        case "Edit":
                            ResetCurrentOrgChart(OrganizatinChartID);
                            OrganizationChartManager.Instance.Check(CurrentOrgChartID, CurrentUserID, enumActionType.CheckOut);
                            currentNavigationMode = enumNavigationMode.Edit;
                            GoToOrgChartLink("~/OrgChart/OrgChartDetails.aspx", currentNavigationMode);
                            break;
                        case "ContinueEdit":
                            ResetCurrentOrgChart(OrganizatinChartID);
                            currentNavigationMode = enumNavigationMode.Edit;
                            GoToOrgChartLink("~/OrgChart/OrgChartDetails.aspx", currentNavigationMode);
                            break;
                        case "FinishEdit":
                            ResetCurrentOrgChart(OrganizatinChartID);
                            FinishEditOrgChart(CurrentOrgChartID, CurrentUserID);
                            break;
                        case "Delete":
                            DeleteOrgChart(OrganizatinChartID);
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
        }
        protected void rgSearchResults_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            OrgChartSearchResultCollection  searchresults = GetSearchResults();

            enumSortDirection sortdirection = enumSortDirection.ASC;

            if (e.SortExpression == SortExpression)
            {

                if (SortDirection == enumSortDirection.undefined || SortDirection == enumSortDirection.DESC)
                {
                    sortdirection = enumSortDirection.ASC;
                    SortDirection = enumSortDirection.ASC;
                }
                else
                {
                    sortdirection = enumSortDirection.DESC;
                    SortDirection = enumSortDirection.DESC;
                }
            }
            else
            {
                SortDirection = enumSortDirection.ASC;
            }

            SortExpression = e.SortExpression; 

            switch (e.SortExpression)
            {
                case "OrganizationChartID":
                    searchresults.OrderBy(enumOrgChartResultSortField.OrganizationChartID, sortdirection);                    
                    break;
                case "Region":
                   // searchresults.Sort(delegate(OrgChartSearchResult result1, OrgChartSearchResult result2)
                   // {
                   //     return result1.ChartEntity.OrgCode.RegionID.CompareTo(result2.ChartEntity.OrgCode.RegionID);
                   // }
                   //);
                    searchresults.OrderBy(enumOrgChartResultSortField.Region, sortdirection);
                    break;
                case "OrganizationCode":
                    searchresults.OrderBy(enumOrgChartResultSortField.OrganizationCode, sortdirection);
                     break;
                case "CreatedByFNR":
                    searchresults.OrderBy(enumOrgChartResultSortField.CreatedByFNR, sortdirection);                   
                    break;
                case "CreateDate":
                    searchresults.OrderBy(enumOrgChartResultSortField.CreateDate, sortdirection);                   
                    break;
                case "UpdatedByFNR":
                    searchresults.OrderBy(enumOrgChartResultSortField.UpdatedByFNR, sortdirection);
                    break;
                case "UpdateDate":
                    searchresults.OrderBy(enumOrgChartResultSortField.UpdateDate, sortdirection);
                    break;
                case "StatusID":
                    searchresults.OrderBy(enumOrgChartResultSortField.WorkflowStatus, sortdirection);
                    break;
                case "ChartType":
                    searchresults.OrderBy(enumOrgChartResultSortField.ChartType, sortdirection);
                    break;
                default:
                    break;
            }
            //SearchResults = searchresults;
            //e.Item.OwnerTableView.DataSource = searchresults;
            
            //e.Item.OwnerTableView.Rebind();
            rgSearchResults.DataSource = searchresults;
            rgSearchResults.DataBind();
            e.Canceled = true;
        }
        #endregion        

        #region [ Context Menu handlers ]
        protected void rmDocument_ItemClick(object sender, RadMenuEventArgs e)
        {
            RadMenu menuDocument = sender as RadMenu;
            string strUrl = string.Empty;

            switch (e.Item.Value)
            {
                //need to work on this
                case "1": //(PDF) --InProcess
                    if (!string.IsNullOrEmpty(menuDocument.Attributes["OrganizationChartID"]))
                    {
                        int OrgChartID = int.Parse(menuDocument.Attributes["OrganizationChartID"]);
                        ResetCurrentOrgChart(OrgChartID);
//strUrl = string.Format("<iframe src='../OrgChart/DisplayChart.aspx?id={0}' frameborder='0' width='0' height='0' style='display: block;'></iframe>", OrgChartID);
                       strUrl = string.Format ("../OrgChart/DisplayChart.aspx?id={0}",OrgChartID );                       
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + strUrl + "','_blank')", true);
                       //GoToOrgChartLink("~/OrgChart/ViewChart.aspx",enumNavigationMode.View);
                    }
                    break;
                case "2"://(PDF) --Published
                    if (!string.IsNullOrEmpty(menuDocument.Attributes["OrganizationChartLogID"]))
                    {
                        int OrgChartLogID = int.Parse(menuDocument.Attributes["OrganizationChartLogID"]);
                        ResetCurrentOrgChartLog(OrgChartLogID);
                        strUrl = string.Format("../PubOrgChart/DisplayChart.aspx?id={0}", OrgChartLogID);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + strUrl + "','_blank')", true);
                        //GoToOrgChartLink("~/PubOrgChart/DisplayChart.aspx?id=<Organization Chart Log ID>", enumNavigationMode.View);
                    }
                    break;
                case "3"://Export To Excel
                    if (!string.IsNullOrEmpty(menuDocument.Attributes["OrgChartID"]))
                    {
                        int OrgChartID = int.Parse(menuDocument.Attributes["OrgChartID"]);
                        base.ExportToExcel(OrgChartID);
                    }
                    break;
                default:
                break;
            }

            e.Item.Selected = false;
        }

        #endregion

        #region [ Private Properties ]
        private enum enumOrgFormat:int
        {
            Null=-1,
            Old=1,
            New=2
        }
        private int UserID
        {
            get
            {
                return base.CurrentUser.UserID;
            }
        }

        private int? OrgChartID
        {
            get
            {
                int? OrgChartID = null;
                if(!string.IsNullOrEmpty (txtOrganizationChartID.Text))
                    OrgChartID =int.Parse (txtOrganizationChartID.Text);
                return OrgChartID;
            }
        }
        private int? OrgChartTypeID
        {
            get
            {
                int? OrgChartTypeID = null;

                if(int.Parse(rcbOrgChartType.SelectedValue) > 0)
                {
                    OrgChartTypeID = int.Parse(rcbOrgChartType.SelectedValue);
                }

                return OrgChartTypeID;
            }
        }


        private int? RegionID
        {
            get
            {
                int? return_var = null;

                int selectedval = Convert.ToInt32(rcbRegion.SelectedValue);

                if (selectedval > 0)
                    return_var = selectedval;

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

        private enumOrgWorkflowStatus  ChartStatusID
        {
            get
            {
               enumOrgWorkflowStatus status=enumOrgWorkflowStatus.Undefined ;
                int selectedval = Convert.ToInt32(rcbChartStatus.SelectedValue);

                if (selectedval > 0)
                    Enum.TryParse<enumOrgWorkflowStatus>(rcbChartStatus.SelectedValue, out status);
                 return status;
            }
        }

        private string Creater
        {
            get
            {
                string return_var = null;

                if (!string.IsNullOrWhiteSpace(this.txtChartCreator.Text))
                {
                    return_var = txtChartCreator.Text;
                }

                return return_var;
            }
        }

        private string Approver
        {
            get
            {
                string return_var = null;

                if (!string.IsNullOrWhiteSpace(this.txtChartApprover.Text))
                {
                    return_var = txtChartApprover.Text;
                }

                return return_var;
            }
        }
        private string EmployeeName
        {
            get
            {
                string return_var = null;

                if (!string.IsNullOrWhiteSpace(this.txtEmployeeName.Text))
                {
                    return_var = txtEmployeeName.Text;
                }

                return return_var;
            }
        }
        
        private int? PublishedYear
        {
            get
            {
                int? return_var = null;

                if (rcbPublishedYear.SelectedIndex > 0)
                {
                    int selectedval = Convert.ToInt32(rcbPublishedYear.SelectedValue);

                    if (selectedval > 0)
                        return_var = selectedval;
                }

                return return_var;
            }
        }

        private int? OrganizationCodeID
        {
            get
            {
                int? return_var = null;

                if (rcbOrganizationCode.SelectedIndex  > 0)
                {
                    int selectedval = Convert.ToInt32(this.rcbOrganizationCode.SelectedValue);

                    if (selectedval > 0)
                        return_var = selectedval;
                }

                return return_var;
            }
        }

        private enumSortDirection SortDirection
        {
            get
            {
                enumSortDirection sortdirection = enumSortDirection.ASC;
                if (ViewState["SortDirection"] != null)
                {
                    sortdirection = (enumSortDirection)ViewState["SortDirection"];
                }
                return sortdirection;
            
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }

        private String SortExpression
        {
            get
            {
                String sortexpression = "OrganizationChartID";
                if (ViewState["SortExpression"] != null)
                {
                    sortexpression = ViewState["SortExpression"].ToString();
                }
                return sortexpression;
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }
        #endregion

       

    }
}