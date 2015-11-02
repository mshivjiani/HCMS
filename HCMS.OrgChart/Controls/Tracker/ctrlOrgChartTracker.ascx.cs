using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HCMS.Business.OrganizationChart;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.Base;


namespace HCMS.OrgChart.Controls.Tracker
{
    public partial class ctrlOrgChartTracker : OrgChartUserControlBase
    {
       

        protected void OrgChartTrackerGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            OrgChartTrackerItemCollection collection = OrgChartTrackerItem.GetCollectionForUser(CurrentUserID);
            OrgChartTrackerGrid.DataSource = collection;
        }
       
        protected void OrgChartTrackerGrid_ItemCreated(object sender, GridItemEventArgs e)
        {
            RadGrid grid = (RadGrid)sender;

            // when RadMenu item is selected, this event handler is being called without prior call to NeedDataSource
            // and as a result - the grid does not have data source assigned
            if (grid.DataSourceIsAssigned)
            {

                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    int OrgChartID = (int)item.GetDataKeyValue("OrganizationChartID");
                    
                    RadMenu menu = e.Item.FindControl("OrgChartTrackerMenu") as RadMenu;
                    if (menu != null)
                    {
                        menu.DataFieldID = OrgChartID.ToString();
                    }
                }

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

        protected void OrgChartTrackerGrid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                HideRefreshButton(e);

                if (e.Item is GridDataItem)
                {
                    GridDataItem gridDataItem = e.Item as GridDataItem;

                    if (gridDataItem.ItemType == GridItemType.Item || gridDataItem.ItemType == GridItemType.AlternatingItem || gridDataItem.ItemType == GridItemType.SelectedItem)
                    {
                        OrgChartTrackerItem trackerItem = e.Item.DataItem as OrgChartTrackerItem;
                        string checkedoutdt = string.Empty;
                        string editedBy = string.Empty;

                      
                        //Need to have new image for Org Chart
                        Image imgOrgChartCheckedOutStatus = gridDataItem.FindControl("imgOrgChartCheckedOutStatus") as Image;
                        imgOrgChartCheckedOutStatus.Visible = false;

                        if (trackerItem.CheckedOut)
                        {
                            if (trackerItem.CheckedOutBy.ActionDate != null)
                            {
                                DateTime? checkedoutbydate = trackerItem.CheckedOutBy.ActionDate;
                                checkedoutdt = string.Format("{0:MM/dd/yyyy}",checkedoutbydate);

                                editedBy = String.Format("Being edited by {0} since {1}", trackerItem.CheckedOutBy.FullNameReverse  , checkedoutdt);
                            }
                            imgOrgChartCheckedOutStatus.Visible = true;

                            if (trackerItem.CheckedOutBy.UserID  == CurrentUserID)
                            {
                                imgOrgChartCheckedOutStatus.ImageUrl = Page.ResolveUrl(String.Format("~/App_Themes/{0}/Images/Icons/icon_unlock.gif", Page.Theme));
                            }
                            else
                            {
                                imgOrgChartCheckedOutStatus.ImageUrl = Page.ResolveUrl(String.Format("~/App_Themes/{0}/Images/Icons/icon_lock.gif", Page.Theme));
                                
                            }
                            gridDataItem.ToolTip = editedBy;
                        }


                        RadMenu menuAction = gridDataItem.FindControl("OrgChartTrackerMenu") as RadMenu;

                        menuAction.Attributes["OrganizationChartID"] = trackerItem.OrganizationChartID.ToString();

                        RadMenuItem viewMenuItem = menuAction.FindItemByValue("View");
                        RadMenuItem editMenuItem = menuAction.FindItemByValue("Edit");
                        RadMenuItem continueMenuItem = menuAction.FindItemByValue("ContinueEdit");
                        RadMenuItem finishMenuItem = menuAction.FindItemByValue("FinishEdit");
                        RadMenuItem deleteMenuItem = menuAction.FindItemByValue("Delete");

                        viewMenuItem.Visible = (!trackerItem.CanContinueEdit) ;
                        editMenuItem.Visible = trackerItem.CanEdit;
                        continueMenuItem.Visible = trackerItem.CanContinueEdit;
                        finishMenuItem.Visible = trackerItem.CanFinishEdit;
                        deleteMenuItem.Visible = trackerItem.CanDelete;

                      
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }

        protected void OrgChartTrackerMenu_ItemClick(object sender, RadMenuEventArgs e)
        {
            RadMenu menu = (RadMenu)sender;
            int OrganizationChartID =int.Parse(menu.DataFieldID);
            base.ResetCurrentOrgChart(OrganizationChartID);

            enumNavigationMode currentNavigationMode = enumNavigationMode.None;
            try
            {

                switch (e.Item.Value)
                {
                    case "View":                        
                        currentNavigationMode = enumNavigationMode.View;
                        GoToOrgChartLink("~/OrgChart/OrgChartDetails.aspx", currentNavigationMode);
                        break;
                    case "Edit":
                        OrganizationChartManager.Instance.Check(CurrentOrgChartID, CurrentUserID, enumActionType.CheckOut);
                        currentNavigationMode = enumNavigationMode.Edit;
                        GoToOrgChartLink("~/OrgChart/OrgChartDetails.aspx", currentNavigationMode);
                        break;
                    case "ContinueEdit":
                       currentNavigationMode = enumNavigationMode.Edit;
                       GoToOrgChartLink("~/OrgChart/OrgChartDetails.aspx", currentNavigationMode);
                        break;
                    case "FinishEdit":
                        FinishEditOrgChart(CurrentOrgChartID, CurrentUserID);
                        break;
                    case "Delete":
                        DeleteOrgChart(CurrentOrgChartID);
                        break;
                    default:
                        break;
                }

                OrgChartTrackerGrid.Rebind();
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }

       

     
    }
}