using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.JQ;

namespace HCMS.JNP.Controls.JQ
{
    public partial class ctrlQualification : JNPUserControlBase
    {
        JQManager jqm = new JQManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetPageView();                
            }
        }
        protected void SetPageView()
        {
            if (base.CurrentJQID == -1)
                base.PrintErrorMessage(GetGlobalResourceObject("JNPMessages", "JQNotAvailable").ToString(), false);
            else
            {
                SetGridQualificationsView();
            }
        }
        private void SetGridQualificationsView()
        {
            enumJNPWorkflowStatus currentws = CurrentJNPWS;
            GridColumn Editcolumn = gridQualifications.MasterTableView.OwnerGrid.Columns.FindByUniqueName("EditCommandColumn");//gridQualifications.Columns[0];//gridQualifications.MasterTableView.EditFormSettings.EditColumn;
            GridColumn Deletecolumn = gridQualifications.MasterTableView.OwnerGrid.Columns.FindByUniqueName("DeleteCommandColumn");
            GridColumn Viewcolumn = gridQualifications.MasterTableView.OwnerGrid.Columns.FindByUniqueName("ViewCommandColumn");

            //View
            if (CurrentNavMode == enumNavigationMode.View)
            {
                //no add
                gridQualifications.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;               
                //edit column should not be visible              
                if (Editcolumn != null)
                {
                    Editcolumn.Visible = false;
                    Editcolumn.Display = false;
                }
                // no delete
                if (Deletecolumn != null)
                {
                    Deletecolumn.Visible = false;
                }
                //only View
                if (Viewcolumn != null)
                {
                    Viewcolumn.Visible = true;
                    Viewcolumn.Display = true;
                }
            }
            else //edit mode
            {

                if (Viewcolumn != null)
                {
                    Viewcolumn.Visible = false;
                    Viewcolumn.Display = false;
                }

                if (((currentws == enumJNPWorkflowStatus.Revise) && (CurrentJNP.IsJNPSignedBySupervisor))
                    || ((currentws == enumJNPWorkflowStatus.FinalReview) && (CurrentJNP.IsJNPSignedByHR)))
                {
                    //View column should display
                    if (Viewcolumn != null)
                    {
                        Viewcolumn.Display = true;
                        Viewcolumn.Visible = true;
                    }
                    //edit column should not be visible when package is signed            
                    if (Editcolumn != null)
                    {
                        Editcolumn.Visible = false;
                    }
                }
                else
                {
                    //edit column should be visible when currentnav mode is edit --and package is not signed            
                    if (Editcolumn != null)
                    {
                        Editcolumn.Visible = true;
                    }
                }
                //admin should be able to add/edit/ delete regard less of workflowstatus/even if the package is signed
                if (base.IsAdmin)
                {
                    //show add
                    gridQualifications.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = true;
                    gridQualifications.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                    //hide view
                    if (Viewcolumn != null)
                    {
                        Viewcolumn.Display = false;
                    }
                    //edit column should be visible when currentnav mode is edit             
                    if (Editcolumn != null)
                    {
                        Editcolumn.Visible = true;
                    }
                    //show delete
                    if (Deletecolumn != null)
                    {
                        Deletecolumn.Visible = true;
                    }
                }
                else if (base.HasHRGroupPermission)
                {
                    //HR should be able to add/delete in draft/review/revise (until signed)  
                    //In Final review only No add/No delete option even for HR

                    switch (currentws)
                    {
                        case enumJNPWorkflowStatus.Draft:
                        case enumJNPWorkflowStatus.Review:
                            //show ad
                            gridQualifications.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = true;
                            gridQualifications.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                            //show delete
                            if (Deletecolumn != null)
                            {
                                Deletecolumn.Visible = true;
                            }

                            break;

                        case enumJNPWorkflowStatus.Revise:

                            if (!CurrentJNP.IsJNPSignedBySupervisor)
                            {
                                //show add
                                gridQualifications.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = true;
                                gridQualifications.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;

                                //show delete
                                if (Deletecolumn != null)
                                {
                                    Deletecolumn.Visible = true;
                                }
                            }

                            break;
                        case enumJNPWorkflowStatus.FinalReview:

                            //Issue 1060 Editable for HR in FinalReview
                            if (CurrentJNP.IsJNPSignedByHR)
                            {
                                gridQualifications.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                                if (Deletecolumn != null)
                                { Deletecolumn.Visible = false; }
                            }
                            else
                            {
                                //show add
                                gridQualifications.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = true;
                                gridQualifications.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                                //hide view
                                if (Viewcolumn != null)
                                {
                                    Viewcolumn.Display = false;
                                }
                                //edit column should be visible when currentnav mode is edit             
                                if (Editcolumn != null)
                                {
                                    Editcolumn.Visible = true;
                                }
                                //show delete
                                if (Deletecolumn != null)
                                {
                                    Deletecolumn.Visible = true;
                                }

                            }

                            //if (CurrentJNP.IsJNPSignedByHR)
                            //    Deletecolumn.Visible = false;

                            break;

                    }
                }
                else //If user is not Admin/HR don't show add/delete option
                {
                    gridQualifications.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    if (Deletecolumn != null)
                    { Deletecolumn.Visible = false; }

                }
            }

            gridQualifications.Rebind();
        }
        #region Qualifications Grid events
        private void HideRefreshButton(GridItemEventArgs e)
        {
            GridItem gridItem = e.Item;
            //hide the refresh button Telerik.Web.UI.GridLinkButton
            if (gridItem is GridCommandItem)
            {
                gridItem.FindControl("RebindGridButton").Visible = false;

            }
        }        
       
        protected void gridQualifications_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            HideRefreshButton(e);


            //Making Delete icon invisible for factor type - SF/COE
            if (e.Item is GridDataItem)
            {
                GridDataItem gridDataItem = e.Item as GridDataItem;
                ImageButton btnDel = ((TableCell)gridDataItem["DeleteCommandColumn"]).Controls[0] as ImageButton;


                Label lblFactorTypeID = gridDataItem.FindControl("lblFactorTypeID") as Label;
                if (lblFactorTypeID != null)
                {
                    enumJQFactorType currentfactorType = (enumJQFactorType)int.Parse(lblFactorTypeID.Text);
                    if (btnDel != null && (currentfactorType == enumJQFactorType.SelectiveFactor || currentfactorType == enumJQFactorType.ConditionOfEmployment))
                    {
                        btnDel.Visible = false;
                    }
                }

            }

        }
        private bool IsNonKSA(JQFactorEntity current)
        {
            return (current.FactorTypeID != (int)enumJQFactorType.KSA);
        }
        protected void gridQualifications_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            List<JQFactorEntity> JQFactors = jqm.GetJQFactorsByJQID(this.CurrentJQID);
            List<JQFactorEntity> JQQualifications = JQFactors.FindAll(IsNonKSA);
            gridQualifications.DataSource = JQQualifications;
        }
        protected void gridQualifications_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                case RadGrid.EditCommandName:
                case "View":
                    ShowQualification(sender, e);
                    break;
                case RadGrid.DeleteCommandName:
                    DeleteQualification(sender, e);
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void ShowQualification(object source, GridCommandEventArgs e)
        {
            RadWindowMangerQualifications.Windows.Clear();
            GridDataItem gridItem;
            string navigateurl = string.Empty;
            string title = string.Empty;
            string script = string.Empty;
            long factorID;

            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    long JQID = CurrentJQID;
                    base.CurrentJQFactorID = -1;
                    base.GoToLink("~/JQ/AddEditQualification.aspx", enumNavigationMode.Insert);
                    //script = string.Format("ShowDutyWindowClient('{0}','{1}');", "Insert", JAID);
                    break;
                case RadGrid.EditCommandName:
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    factorID = long.Parse(gridItem.GetDataKeyValue("ID").ToString());
                    base.CurrentJQFactorID = factorID;
                    GoToLink("~/JQ/AddEditQualification.aspx", enumNavigationMode.Edit);
                    break;
                case "View":
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    factorID = long.Parse(gridItem.GetDataKeyValue("ID").ToString());
                    base.CurrentJQFactorID = factorID;
                    //changed second argument of GoToLink from enumNavigationMode.View to CurrentNavMode
                    // because View option can be available when user in edit mode & if current document is finalized
                    //so if you pass enumNavigationMode.View -then it was setting currentNavMode to view 
                    // that was causing issue 95-moving from editable section of a package to a read-only section
                    //and then back to an editable section leaves the package in read-only mode
                    GoToLink("~/JQ/AddEditQualification.aspx", CurrentNavMode);
                    break;
                default:
                    break;
            }

        }
        private void DeleteQualification(object source, GridCommandEventArgs e)
        {
            try
            {
                if (source is RadGrid)
                {
                    GridDataItem gridItem = e.Item as GridDataItem;
                    long factorID = long.Parse(gridItem.GetDataKeyValue("ID").ToString());
                    jqm.DeleteJQFactor(factorID, this.CurrentUserID);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void gridQuestions_ItemDataBound(object sender, GridItemEventArgs e)
        {
            HideRefreshButton(e);
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            GoToLink("~/JQ/JQKSA.aspx", CurrentNavMode);
        }
    }
}