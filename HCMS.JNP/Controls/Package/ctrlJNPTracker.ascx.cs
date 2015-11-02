using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;


using Telerik.Web;
using Telerik.Web.UI;

using HCMS.Business.Common;
using HCMS.Business.Base;
using HCMS.Business.JNPTracker;


using HCMS.Business.PD;
using HCMS.Business.JNP;
using HCMS.WebFramework.BaseControls;


// http://demos.telerik.com/aspnet-ajax/grid/examples/hierarchy/nestedviewtemplatedeclarativerelations/defaultcs.aspx

// http://demos.telerik.com/aspnet-ajax/grid/examples/programming/detailtabledatabind/defaultcs.aspx
//
// Note that hierarchical grid structure is not supported with simple data-binding (calling DataBind()). 
// See the Simple data binding demo from the Populating with data section for more info about the limitations of this binding mode. 

namespace HCMS.JNP.Controls.Package
{
    public partial class ctrlJNPTracker : JNPUserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region [ Event Handlers ]
        protected void jnpTrackerGrid_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            TrackerItemCollection collection = TrackerItem.GetCollectionForUser(CurrentUserID);
            jnpTrackerGrid.DataSource = collection;
        }

        protected void jnpTrackerGrid_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem item in jnpTrackerGrid.MasterTableView.Items)
            {
                // when the grid is loading - expand the row so that you could see JA, CR and JQ data
                if (item.CanExpand)
                {
                    item.Expanded = true;
                }
            }
        }

        protected void jnpTrackerGrid_ItemCreated(object sender, GridItemEventArgs e)
        {
            RadGrid grid = (RadGrid)sender;

            // when RadMenu item is selected, this event handler is being called without prior call to NeedDataSource
            // and as a result - the grid does not have data source assigned
            if (grid.DataSourceIsAssigned)
            {

                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    long JNPID = (long)item.GetDataKeyValue("JNPID");

                    RadMenu menu = e.Item.FindControl("jnpTrackerMenu") as RadMenu;
                    if (menu != null)
                    {
                        menu.DataFieldID = JNPID.ToString();
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

        protected void jnpTrackerGrid_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                HideRefreshButton(e);

                if (e.Item is GridDataItem)
                {
                    GridDataItem gridDataItem = e.Item as GridDataItem;

                    if (gridDataItem.ItemType == GridItemType.Item || gridDataItem.ItemType == GridItemType.AlternatingItem || gridDataItem.ItemType == GridItemType.SelectedItem)
                    {
                        TrackerItem trackerItem = e.Item.DataItem as TrackerItem;
                        string checkedoutdt = string.Empty;
                        string editedBy = string.Empty;
                        Image imgJNPCheckedOutStatus = gridDataItem.FindControl("imgJNPCheckedOutStatus") as Image;
                        Image scheduleStatusImage = gridDataItem.FindControl("imgScheduleStatus") as Image;
                        Label scheduleStatusLabel = gridDataItem.FindControl("lblScheduleStatus") as Label;
                        imgJNPCheckedOutStatus.Visible = false;

                        if (trackerItem.IsCheckedOut)
                        {
                            if (trackerItem.CheckedOutDate != null)
                            {
                                checkedoutdt = string.Format(trackerItem.CheckedOutDate.ToString(), "d");

                                editedBy = String.Format("Being edited by {0} since {1}", trackerItem.CheckedOutBy, checkedoutdt);
                            }
                            imgJNPCheckedOutStatus.Visible = true;
                            if (trackerItem.CheckedOutByID == CurrentUserID)
                            {
                                imgJNPCheckedOutStatus.ImageUrl = Page.ResolveUrl(String.Format("~/App_Themes/{0}/Images/Icons/icon_unlock.gif", Page.Theme));
                            }
                            else
                            {
                                imgJNPCheckedOutStatus.ImageUrl = Page.ResolveUrl(String.Format("~/App_Themes/{0}/Images/Icons/icon_lock.gif", Page.Theme));
                                imgJNPCheckedOutStatus.ToolTip = editedBy;
                                gridDataItem.ToolTip = editedBy;
                            }
                        }


                        RadMenu menuAction = gridDataItem.FindControl("jnpTrackerMenu") as RadMenu;

                        menuAction.Attributes["JNPID"] = trackerItem.JNPID.ToString();

                        RadMenuItem viewMenuItem = menuAction.FindItemByValue("View");
                        RadMenuItem editMenuItem = menuAction.FindItemByValue("Edit");
                        RadMenuItem continueMenuItem = menuAction.FindItemByValue("ContinueEdit");
                        RadMenuItem finishMenuItem = menuAction.FindItemByValue("FinishEdit");

                        viewMenuItem.Visible = trackerItem.CanViewJNP;
                        editMenuItem.Visible = trackerItem.CanEditJNP;
                        continueMenuItem.Visible = trackerItem.CanContinueEditJNP;
                        finishMenuItem.Visible = trackerItem.CanFinishEditJNP;

                        enumScheduleStatus scheduleStatus = trackerItem.JNPScheduleStatus;
                        scheduleStatusImage.ImageUrl = Page.ResolveUrl(ScheduleStatusIconURL(scheduleStatus));
                        string scaduleStatusName = EnumHelper<enumScheduleStatus>.GetEnumDescription(scheduleStatus.ToString());
                        scheduleStatusImage.ToolTip = scaduleStatusName;
                        scheduleStatusLabel.Text = scaduleStatusName;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }

        protected void jnpTrackerMenu_ItemClick(object sender, RadMenuEventArgs e)
        {
            RadMenu menu = (RadMenu)sender;

            long JNPID = long.Parse(menu.DataFieldID);
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
                        CurrentJNPID = JNPID;
                        //navigateToActiveDocument = true;
                        currentNavigationMode = enumNavigationMode.View;
                        GoToLink("~/JA/JAPositionInformation.aspx", currentNavigationMode);
                        break;
                    case "Edit":
                        wo.ActionTypeID = enumActionType.CheckOut;
                        WorkflowManager.CheckJNP(wo);
                        CurrentJNPID = JNPID;
                        //navigateToActiveDocument = true;
                        currentNavigationMode = enumNavigationMode.Edit;
                        GoToLink("~/JA/JAPositionInformation.aspx", currentNavigationMode);
                        break;
                    case "ContinueEdit":
                        CurrentJNPID = JNPID;
                        //navigateToActiveDocument = true;
                        currentNavigationMode = enumNavigationMode.Edit;
                        GoToLink("~/JA/JAPositionInformation.aspx", currentNavigationMode);
                        break;
                    case "FinishEdit":
                        wo.ActionTypeID = enumActionType.CheckIn;
                        WorkflowManager.CheckJNP(wo);
                        break;
                    default:
                        break;
                }
                
                jnpTrackerGrid.Rebind();

                //if (navigateToActiveDocument)
                //{


                //    if (base.CurrentJNPWS == enumJNPWorkflowStatus.Draft)
                //    {
                //        enumDocumentType activeDocumentType = TrackerItem.GetActiveDocumentType(JNPID);

                //        switch (activeDocumentType)
                //        {
                //            // GoToLink method of UserControlBase provide screen mode as parameter

                //            case enumDocumentType.JNP:
                //            case enumDocumentType.JA:
                //                GoToLink("~/JA/JAPositionInformation.aspx", currentNavigationMode);
                //                break;
                //            case enumDocumentType.CR:
                //                GoToLink("~/CR/CategoryRating.aspx", currentNavigationMode);
                //                break;
                //            case enumDocumentType.JQ:
                //                if ((base.HasHRGroupPermission) || (base.IsAdmin))
                //                {
                //                    GoToLink("~/JQ/Qualifications.aspx", currentNavigationMode);
                //                }
                //                else
                //                {
                //                    GoToLink("~/JQ/JQKSA.aspx", currentNavigationMode);
                //                }

                //                break;
                //            default:
                //                throw new Exception(String.Format("Unexpected JNP Active Document Type: {0}", (int)activeDocumentType));
                //        }
                //    }
                //    else if (base.CurrentJNPWS == enumJNPWorkflowStatus.FinalReview)
                //    {
                //        GoToLink("~/JA/JAPositionInformation.aspx", currentNavigationMode);
                //    }
                //    // Issue # 77 - Modify CommonEnum.cs - Modify enumJNPWorkflowStatus as per the new workflow statuses
                //    //else if (base.CurrentJNPWS  == enumJNPWorkflowStatus.Approval)
                //    //{
                //    //    base.CurrentApprovalObjectType = enumStaffingObjectType.JNP;
                //    //    GoToLink("~/Approval/Approval.aspx", currentNavigationMode);
                //    //}

                //}
                //else
                //{
                //    e.Item.Selected = false;
                //    jnpTrackerGrid.Rebind();
                //}
                
                
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }
        #endregion


        #region [Private Methods]
        protected string ScheduleStatusIconURL(enumScheduleStatus scheduleStatus)
        {
            string url = string.Empty;

            if (scheduleStatus == enumScheduleStatus.OnTrack)
                url = string.Format("~/App_Themes/{0}/Images/Icons/icon_ontrack.gif", Page.Theme);
            else if (scheduleStatus == enumScheduleStatus.Warning)
                url = string.Format("~/App_Themes/{0}/Images/Icons/icon_warning.gif", Page.Theme);
            else if (scheduleStatus == enumScheduleStatus.Escalated)
                url = string.Format("~/App_Themes/{0}/Images/Icons/icon_escalated.gif", Page.Theme);
            else if (scheduleStatus == enumScheduleStatus.Inactive)
                url = string.Format("~/App_Themes/{0}/Images/Icons/icon_Inactive.gif", Page.Theme);

            return url;
        }

        #endregion
    }
}