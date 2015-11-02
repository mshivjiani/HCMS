using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

using HCMS.Business.PD;
using HCMS.Business.DashBoard;
using HCMS.Business.DashBoard.Collections;
using HCMS.Business.Security;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.Security;
namespace HCMS.PDExpress.Controls.PDExpress
{
    public partial class PDTracker : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["searchParam"] = null;
        }

        #region [ DashBoard Grid Event Handlers ]

        protected void rgDashBoard_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                DashboardCollection dshCollection = DashBoard.GetDashBoardPDs(CurrentUser.UserID);
                
                RadGrid rgDashBoard = sender as RadGrid;
                rgDashBoard.DataSource = dshCollection.GetFilteredList();
                rgHidden.DataSource = dshCollection.GetLadderPDs();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rgDashBoard_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                RadGrid rgDashBoard = sender as RadGrid;

                if (e.Item is GridDataItem)
                {
                    GridDataItem gridDataItem = e.Item as GridDataItem;

                    if (gridDataItem.ItemType == GridItemType.Item || gridDataItem.ItemType == GridItemType.AlternatingItem || gridDataItem.ItemType == GridItemType.SelectedItem)
                    {
                        DashBoard dataItem = e.Item.DataItem as DashBoard;
                        Image imgPDCheckedOutStatus = gridDataItem.FindControl("imgPDCheckedOutStatus") as Image;
                        Label lblTitle = gridDataItem.FindControl("lblAgencyPositionTitle") as Label;
                        Label lblPDNumber = gridDataItem.FindControl("lblPDNumber") as Label;
                        Label lblGrade = gridDataItem.FindControl("lblGrade") as Label;

                        string strTitle = string.Format("{0}<br/>{1}-{2}-{3}", dataItem.AgencyPositionTitle, dataItem.PayPlanAbbrev, dataItem.PaddedSeries, dataItem.ProposedGrade.ToString());
                        string editedBy = String.Format("Being edited by {0} since {1}", dataItem.CheckedOutBy, dataItem.CheckOutDate.ToString("d"));
                        lblTitle.Text = strTitle;

                        //For Career Ladder bundlining
                        if (dataItem.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD && (dataItem.AssociatedFullPD == -1 ? true : dataItem.AssociatedFullPD == 0))
                        {
                            
                            DashboardCollection dshList = (DashboardCollection)rgHidden.DataSource;
                            List<DashBoard> ladderList = dshList.GetLadderPDs(dataItem.PositionDescriptionID);
                            string pdNumbersString = dataItem.PositionDescriptionID.ToString();
                            string pdGradeString = dataItem.ProposedGrade.ToString();

                            //Filter the dataset for the other ladder positions and bundle them up together.
                            foreach (DashBoard item in ladderList)
                            {
                                pdNumbersString += String.Format("<br/>{0}</span>", item.PositionDescriptionID.ToString());
                                pdGradeString += String.Format("<br/>{0}</span>", item.ProposedGrade.ToString());
                            }
                            lblPDNumber.Text = pdNumbersString;
                            lblGrade.Text = pdGradeString;
                        }
                        else
                        {
                            lblPDNumber.Text = dataItem.PositionDescriptionIDValue;
                            lblGrade.Text = dataItem.ProposedGrade.ToString();
                        }

                        if (dataItem.IsCheckedOut)
                        {
                            imgPDCheckedOutStatus.Visible = true;
                            imgPDCheckedOutStatus.ImageUrl = dataItem.CheckedOutBy == base.CurrentUser.FullNameReverse ? Page.ResolveUrl(string.Format("~/App_Themes/{0}/Images/Icons/icon_unlock.gif", Page.Theme)) : Page.ResolveUrl(string.Format("~/App_Themes/{0}/Images/Icons/icon_lock.gif", Page.Theme));
                            imgPDCheckedOutStatus.ToolTip = editedBy;
                            gridDataItem.ToolTip = editedBy;
                        }

                        RadMenu menuAction = gridDataItem.FindControl("rmPDAction") as RadMenu;

                        Label workflowStatusLabel = gridDataItem.FindControl("lblWorkflowStatus") as Label;
                        ImageButton workflowNoteButton = gridDataItem.FindControl("btnWorkflowNote") as ImageButton;

                        Image scheduleStatusImage = gridDataItem.FindControl("imgScheduleStatus") as Image;
                        Label scheduleStatusLabel = gridDataItem.FindControl("lblScheduleStatus") as Label;
                        Label nextStatusLabel = gridDataItem.FindControl("lblNextStatus") as Label;
                        bool pdIsInactive = (dataItem.WorkflowStatusID == (int)PDStatus.Inactive);

                        menuAction.Attributes["PositionDescriptionID"] = dataItem.PositionDescriptionID.ToString();

                        RadMenuItem viewMenuItem = menuAction.FindItemByValue("View");
                        RadMenuItem editMenuItem = menuAction.FindItemByValue("Edit");
                        RadMenuItem continueMenuItem = menuAction.FindItemByValue("ContinueEdit");
                        RadMenuItem finishMenuItem = menuAction.FindItemByValue("FinishEdit");
                        RadMenuItem deleteMenuItem = menuAction.FindItemByValue("Delete");
                        //Option to delete PD is available only when PD is in Draft status
                        //
                        if (dataItem.WorkflowStatusID == (int)PDStatus.Draft)
                        {
                            //if PD is checked out then option to delete pd should
                            //be available to users that can checkin that PD
                            if (dataItem.IsCheckedOut)
                            {
                                deleteMenuItem.Visible = CanCheckIn(dataItem);
                            }
                            //if PD is not checked out then option to delete pd should
                            //be available to all users having access this PD on their tracker
                            else
                            {
                                deleteMenuItem.Visible = true;
                            }
                        }
                        else
                        {
                            deleteMenuItem.Visible = false;
                        }

                        viewMenuItem.Visible = !(dataItem.IsCheckedOut && dataItem.CheckedOutByID == CurrentUser.UserID);

                        editMenuItem.Visible = !dataItem.IsCheckedOut && CanCheckOut(dataItem) && !pdIsInactive;
                        continueMenuItem.Visible = dataItem.IsCheckedOut && CanContinueEdit(dataItem) && !pdIsInactive;
                        finishMenuItem.Visible = dataItem.IsCheckedOut && CanCheckIn(dataItem) && !pdIsInactive;

                        if (finishMenuItem.Visible && dataItem.CheckedOutByID != CurrentUser.UserID)
                        {
                            finishMenuItem.Text += String.Format(" ({0})", editedBy);
                        }

                        if (dataItem.PositionDescriptionWorkflowNoteCount > 0)
                        {
                            workflowNoteButton.Visible = true;
                            workflowNoteButton.ImageUrl = Page.ResolveUrl(string.Format("~/App_Themes/{0}/Images/Icons/icon_edit.gif", Page.Theme));

                            //workflowNoteButton.Attributes.Add("onclick", "ShowAddEditNotePopup('" + dataItem.PositionDescriptionID.ToString() + "','" + dataItem.IsCheckedOut.ToString() + "'); return false;");
                            
                            //Added checkout query string
                            workflowNoteButton.Attributes.Add("onclick", "ShowAddEditNotePopup('" + dataItem.PositionDescriptionID.ToString() + "','" + dataItem.IsCheckedOut.ToString() + "','" + dataItem.CheckedOutByID +"'); return false;");
                        }
                        workflowStatusLabel.Text = dataItem.WorkflowStatus;
                        enumScheduleStatus scheduleStatus = (enumScheduleStatus)dataItem.ScheduleStatusID;
                        scheduleStatusImage.ImageUrl = Page.ResolveUrl(ScheduleStatusIconURL(scheduleStatus));
                        scheduleStatusImage.ToolTip = dataItem.ScheduleStatus;
                        scheduleStatusLabel.Text = dataItem.ScheduleStatus;
                        nextStatusLabel.Text = dataItem.NextStatusInfo;
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

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

        protected void rgDashBoard_ItemCommand(object sender, GridCommandEventArgs e)
        {
            //RadGrid rgDashBoard = sender as RadGrid;
        }

        #endregion

        #region [ Context Menu handlers ]

        protected void rmPDAction_ItemClick(object sender, RadMenuEventArgs e)
        {
            try
            {
                RadMenu rmPDAction = sender as RadMenu;
                long PositionDescriptionID = long.Parse(rmPDAction.Attributes["PositionDescriptionID"]);
                base.CurrentPDID = PositionDescriptionID;
                base.ReloadCurrentPD(PositionDescriptionID);
                PDChoiceType? currentPDChoiceType = (PDChoiceType)base.CurrentPD.PositionDescriptionTypeID;
                switch (e.Item.Value)
                {
                    case "View":
                        base.CurrentNavMode = enumNavigationMode.View;

                        if ((currentPDChoiceType == PDChoiceType.StatementOfDifferencePD) || (currentPDChoiceType == PDChoiceType.CLStatementOfDifferencePD))
                            base.GoToPDLink("~/CreatePD/SOD.aspx", true);
                        else
                            base.GoToPDLink("~/CreatePD/Occupation.aspx", true);
                        break;

                    case "Edit":
                    case "ContinueEdit":
                        base.CurrentNavMode = enumNavigationMode.Edit;

                        //If PD is CL, checkout the whole ladder
                        if (currentPDChoiceType == PDChoiceType.CareerLadderPD)
                            base.CheckOutCLPositionDescription(PositionDescriptionID, CurrentUser.UserID);
                        else
                            base.CheckOutPositionDescription(PositionDescriptionID, CurrentUser.UserID);

                        //reloading the pd to get the new check out  information.
                        base.ReloadCurrentPD(PositionDescriptionID);
                        if ((currentPDChoiceType == PDChoiceType.StatementOfDifferencePD) || (currentPDChoiceType == PDChoiceType.CLStatementOfDifferencePD))
                            base.GoToPDLink("~/CreatePD/SOD.aspx", false);
                        else
                            base.GoToPDLink("~/CreatePD/Occupation.aspx", false);
                        break;

                    case "FinishEdit":
                        base.CurrentNavMode = enumNavigationMode.None;

                        //If PD is CL, checkin the whole ladder
                        if (currentPDChoiceType == PDChoiceType.CareerLadderPD)
                            base.CheckInCLPositionDescription(PositionDescriptionID, CurrentUser.UserID);
                        else
                            base.CheckInPositionDescription(PositionDescriptionID, CurrentUser.UserID);
                            this.rgDashBoard.Rebind();
                        break;
                    case "Delete":
                        base.CurrentNavMode = enumNavigationMode.None;

                        base.CurrentPD.Delete();
                        rgDashBoard.Rebind();
                        break;
                    //case "Print":
                    //    base.SafeRedirect(string.Format("~/Documents/PositionDescription/PositionDescriptionDocument.aspx?PDID={0}", base.CurrentPDID));
                    //    Response.Redirect("~/Default.aspx");
                    //    break;
                }

                e.Item.Selected = false;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region [ Private Methods ]

        private bool CanCheckOut(DashBoard dashboard)
        {
            bool canCheckOut = false;

            try
            {
                PositionDescription thisPD = new PositionDescription(dashboard.PositionDescriptionID);
                // bool isPDCreator =thisPD.PDCreatorID.Equals(base.CurrentUser.UserID);
                // bool isPDCreatorSupervisor = base.CurrentUser.IsPDCreatorSupervisor(thisPD.PositionDescriptionID);
                PDAccessType access = base.GetPDAccessType(thisPD);
                if (thisPD.GetCurrentPDStatus() == PDStatus.Draft || thisPD.GetCurrentPDStatus() == PDStatus.Revise)
                    canCheckOut = (access != PDAccessType.ReadOnly); // commenting this check also because the check is already performed in GetPDAccessType function &&  (isPDCreator ||isPDCreatorSupervisor);
                else if (thisPD.GetCurrentPDStatus() == PDStatus.Review || thisPD.GetCurrentPDStatus() == PDStatus.FinalReview)
                    // Issue #: 633 : Evaluator isn't able to Edit PDs in Final Review status
                    // Date Modified : 06/17/2013
                    // Reason: Commenting this line because as per discussion with Pam, HR evaluator should have edit access 
                    // to the PD in final review if the PD appears under My Tracker.
                    // canCheckOut = (access != PDAccessType.ReadOnly) && (base.HasPermission(enumPermission.CompleteHRCertification));
                    canCheckOut = (access != PDAccessType.ReadOnly);
                else
                    canCheckOut = (access != PDAccessType.ReadOnly);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            return canCheckOut;
        }

        private bool CanContinueEdit(DashBoard dashboard)
        {
            bool canContinueEdit = false;

            try
            {
                if (dashboard.CheckedOutByID == CurrentUser.UserID)
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

        private bool CanCheckIn(DashBoard dashboard)
        {
            bool canCheckIn = false;

            try
            {

                if (base.HasPermission(enumPermission.CompleteHRCertification) ||
                    base.HasPermission(enumPermission.CompleteHRCertification15) ||
                    base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
                    dashboard.CheckedOutByID == base.CurrentUser.UserID)
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
    }
}