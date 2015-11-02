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

namespace HCMS.PDExpress.Controls.Search
{
    public partial class SearchReports : UserControlBase
    {
        #region [ Private Predicates ]

        private bool filterInactiveItem(RadComboBoxItem listItem)
        {
            return listItem.Value == ((int)PDStatus.Inactive).ToString() || listItem.Value == ((int)PDStatus.Escalated).ToString();
        }

        #endregion

        #region [ Protected Page Event Handlers ]

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadJobSeries();
                LoadPDStatus();

                if (SearchForCreatingSOD != null && SearchForCreatingSOD == true)
                {
                    SearchForCreatingSODPositionDescriptions();
                }

                else
                {
                    base.ClearCurrentPD();
                }
                if (!String.IsNullOrEmpty(Request.QueryString["StandardPDOnly"]))
                {
                    rblType.Items.FindByValue("a").Selected = false;
                    rblType.Items.FindByValue("y").Selected = true;
                }

            }

        }
        protected override void OnPreRender(EventArgs e)
        {
            TogglePDNumberRegExp();


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

        private void LoadPDStatus()
        {
            ControlUtility.BindRadComboBoxControl(rcbPDStatus, LookupWrapper.GetAllWorkflowStatuses(true), new ControlUtility.RadComboBoxItemFilter(filterInactiveItem), "WorkflowStatusName", "WorkflowStatusID");
            rcbPDStatus.Items.Insert(0, new RadComboBoxItem(String.Empty, "-1"));
        }

        private void ResetSerach1Fields()
        {
            txtPDNumber.Text = String.Empty;
            rblPDNumberType.SelectedIndex = 0;
        }

        private void ResetSearch2Fields()
        {
            rblType.SelectedIndex = -1;
            rcbJobSeries.SelectedIndex = -1;
            rcbPDStatus.SelectedIndex = -1;
        }

        private void SearchForCreatingSODPositionDescriptions()
        {
            try
            {
                SearchType = 4; //Search for Creating SOD
                rcbJobSeries.SelectedValue = "-1";
                rblType.SelectedIndex = 1;
                rblPDType.SelectedIndex = -1;
                rcbPDStatus.SelectedValue = ((int)PDStatus.Published).ToString(); //SOD can be created only from published PDs
                ResetSerach1Fields();
                rgPositionDescription.Rebind();
                h2Caption.Visible = rgPositionDescription.Visible = rgPositionDescription.Items.Count >= 0;
            }
            catch { }
        }

        #region [ Event Handlers ]

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            //Collect all possible parameters.
            /*
             PDExpress PD No - radio
             FPPS PD No - radio 
             PD No.
            
            */

            int pdnumbertype = int.Parse(this.rblPDNumberType.SelectedValue);
            if (pdnumbertype == 1)
            {
                Session["searchParam"] = "pdnumbertype=" + pdnumbertype.ToString() + "&PDID=" + PositionDescriptionID.ToString() + "&SearchType=1";
            }
            else
            {
                Session["searchParam"] = "pdnumbertype=" + pdnumbertype.ToString() + "&SearchType=1";
            }

            SearchType = 1;
            ResetSearch2Fields();
            rgPositionDescription.Rebind();
            h2Caption.Visible = rgPositionDescription.Visible = rgPositionDescription.Items.Count >= 0;
            divOrgCodemsg.Visible = rgPositionDescription.Items.Count > 0;
        }

        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            //Collect all possible parameters.
            /*
             Standard - radio
             Other - radio 
             All - radio
              
             SOD - radio
             Career Ladder - radio
             All - radio
              
             Job Series
             PD Status
            
             
           
             * 
              
            */
            // Session["searchParam"] = "IsStandardPD=" + IsStandardPD + "&
            //if (SearchType == 2)
            //{
            //    HCMS.Business.Search.Search.SearchPositionDescription(UserID, SearchType, null, IsStandardPD, PositionDescriptionTypeID, JobSeriesID, PDStatusID, null, null, null, null, null, null, null);
            //}
            //else if (SearchType == 4)
            //{
            //    HCMS.Business.Search.Search.SearchPositionDescription(UserID, SearchType, null, IsStandardPD, PositionDescriptionTypeID, null, PDStatusID, null, null, null, null, null, null, null);
            //}

            SearchType = 2;
            ResetSerach1Fields();

            rgPositionDescription.CurrentPageIndex = 0;
            rgPositionDescription.Rebind();
            h2Caption.Visible = rgPositionDescription.Visible = rgPositionDescription.Items.Count >= 0;
            divOrgCodemsg.Visible = rgPositionDescription.Items.Count > 0;
        }

        protected void btnSearchAdvanced_Click(object sender, EventArgs e)
        {
            Session["searchParam"] = string.Format("{0}:{1}:{2}:{3}", IsStandardPD, PositionDescriptionTypeID, JobSeriesID, PDStatusID);
            Response.Redirect(@"~/Search/SearchReportsAdvanced.aspx");
        }

        protected void rblPDNumberType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TogglePDNumberRegExp();
        }

        private void TogglePDNumberRegExp()
        { //if the selected PD Number Type is PDExpress PD Number type then
            // system should validate that it is a numeric input only.
            // For FPPSPDID  - it could be alphanumeric
            int pdnumbertype = int.Parse(this.rblPDNumberType.SelectedValue);
            if (pdnumbertype == 1)
            {
                this.txtPDNumberRegExpVal.Enabled = true;
            }
            else
            {
                this.txtPDNumberRegExpVal.Enabled = false;
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


        protected void rgPositionDescription_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataSet dataSet = null;

            if (SearchType == 1)
            {
                int pdnumbertype = int.Parse(this.rblPDNumberType.SelectedValue);
                if (pdnumbertype == 1)
                {
                    dataSet = HCMS.Business.Search.Search.SearchPositionDescription(UserID, SearchType, PositionDescriptionID, null, null, null, null, null, null, null, null, null, 1, null);
                }
                else
                {
                    dataSet = HCMS.Business.Search.Search.SearchPositionDescription(UserID, SearchType, null, null, null, null, null, null, null, null, null, null, 2, FPPSPDID);

                }
            }
            else if (SearchType == 2)
            {
                dataSet = HCMS.Business.Search.Search.SearchPositionDescription(UserID, SearchType, null, IsStandardPD, PositionDescriptionTypeID, JobSeriesID, PDStatusID, null, null, null, null, null, null, null);
            }
            else if (SearchType == 4)
            {
                dataSet = HCMS.Business.Search.Search.SearchPositionDescription(UserID, SearchType, null, IsStandardPD, PositionDescriptionTypeID, null, PDStatusID, null, null, null, null, null, null, null);
            }

            if (dataSet != null)
            {
                //Update the Org columne to have formatted with old and new as in tracker page to make it sortable in GridBoundColumn
                DataColumn OrganizationCodeLegacy = new DataColumn("OrganizationCodeLegacy");
                dataSet.Tables[0].Columns.Add(OrganizationCodeLegacy);
                dataSet.Tables[0].AcceptChanges();

                foreach (DataRow drr in dataSet.Tables[0].Rows)
                {
                    string orgLegacy = string.Format("{0} ({1})", drr["OrganizationCode"].ToString(), drr["OldOrganizationCode"] == DBNull.Value ? "N/A" : drr["OldOrganizationCode"].ToString());
                    drr["OrganizationCodeLegacy"] = orgLegacy;
                    dataSet.Tables[0].AcceptChanges();
                }
                 

                //Bind the regular PDs /SODs/ and CL FPL PDs to the Original Grid
                DataView dvFullPDs = new DataView(dataSet.Tables[0]);
                dvFullPDs.RowFilter = "AssociatedFullPD = -1 or AssociatedFullPD = 0 or AssociatedFullPD IS NULL or (PositionDescriptionTypeID<>4 and PositionDescriptionTypeID<>7)";
                rgPositionDescription.DataSource = dvFullPDs;

                //Bing just Ladder PDs to another grid
                DataView dvLadderPDs = new DataView(dataSet.Tables[0]);
                dvLadderPDs.RowFilter = "AssociatedFullPD > 0 and (PositionDescriptionTypeID = 4 or PositionDescriptionTypeID = 7)";
                rgHidden.DataSource = dvLadderPDs;

                //For sorting PD with the consideration of Full PD into account while sorting.
                string PD = "";
                string grade = "";
                DataColumn PDNo = new DataColumn("PDNo");
                dataSet.Tables[0].Columns.Add(PDNo);

                DataColumn gradeLvl = new DataColumn("grade");
                dataSet.Tables[0].Columns.Add(gradeLvl);
                dataSet.Tables[0].AcceptChanges();

                foreach (DataRow drr in dataSet.Tables[0].Rows)
                {
                    int positionDescriptionTypeID = (int)drr["PositionDescriptionTypeID"];
                    long PDID = Convert.ToInt64(drr["PositionDescriptionID"].ToString());

                    if (positionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD && (drr["AssociatedFullPD"].Equals(DBNull.Value) ? true : Convert.ToInt64(drr["AssociatedFullPD"]) == 0))
                    {
                        DataView dvHidden = (DataView)rgHidden.DataSource;
                        dvHidden.RowFilter = string.Format("AssociatedFullPD = {0}", PDID);

                        dvHidden.Sort = "JobGrade DESC";

                        string pdNumbersString = PDID.ToString();
                        string pdGradeString = drr["JobGrade"].ToString();

                        //Filter the dataset for the other ladder positions and bundle them up together.
                        for (int i = 0; i < dvHidden.Count; i++)
                        {
                            pdNumbersString += String.Format("<br/>{0}</span>", dvHidden[i]["PositionDescriptionID"].ToString());
                            pdGradeString += String.Format("<br/>{0}</span>", dvHidden[i]["JobGrade"].ToString());
                        }
                        PD = pdNumbersString;
                        grade = pdGradeString;
                    }
                    else
                    {
                        PD = PDID.ToString();
                        grade = drr["JobGrade"].ToString();
                    }

                    drr["PDNo"] = PD;
                    drr["grade"] = grade;
                    dataSet.Tables[0].AcceptChanges();
                }
            }
        }

        protected void rgPositionDescription_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                try
                {
                    GridDataItem dataItem = e.Item as GridDataItem;

                    if (dataItem.ItemType == GridItemType.Item || dataItem.ItemType == GridItemType.AlternatingItem || dataItem.ItemType == GridItemType.SelectedItem)
                    {
                        DataRowView dataRow = e.Item.DataItem as DataRowView;
                        long PDID = Convert.ToInt64(dataRow["PositionDescriptionID"].ToString());
                        Label lblPDType = dataItem.FindControl("lblPDType") as Label;
                        //Label lblOrgCode = dataItem.FindControl("lblOrgCode") as Label;
                        //Label lblPDNumber = dataItem.FindControl("lblPDNumber") as Label;
                        //Label lblGrade = dataItem.FindControl("lblGrade") as Label;

                        int positionDescriptionTypeID = (int)dataRow["PositionDescriptionTypeID"];
                        //string positionDescriptionTypeDisp = dataRow["PositionDescriptionTypeDisp"].ToString();
                        bool isInterdisciplinary = false;
                        if (dataRow["IsInterDisciplinaryPD"] != DBNull.Value)
                        {
                            isInterdisciplinary = (bool)dataRow["IsInterDisciplinaryPD"];
                        }
                        //lblOrgCode.Text = GetOrgCodeString(dataRow);
                        //if (positionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD && (dataRow["AssociatedFullPD"].Equals(DBNull.Value) ? true : Convert.ToInt64(dataRow["AssociatedFullPD"]) == 0))
                        //{
                        //    DataView dvHidden = (DataView)rgHidden.DataSource;
                        //    dvHidden.RowFilter = string.Format("AssociatedFullPD = {0}", PDID);
                        //    dvHidden.Sort = "JobGrade DESC";
                        //    string pdNumbersString = PDID.ToString();
                        //    string pdGradeString = dataRow["JobGrade"].ToString();

                        //    //Filter the dataset for the other ladder positions and bundle them up together.
                        //    for (int i = 0; i < dvHidden.Count; i++)
                        //    {
                        //        pdNumbersString += String.Format("<br/>{0}</span>", dvHidden[i]["PositionDescriptionID"].ToString());
                        //        pdGradeString += String.Format("<br/>{0}</span>", dvHidden[i]["JobGrade"].ToString());
                        //    }
                        //    lblPDNumber.Text = pdNumbersString;
                        //    lblGrade.Text = pdGradeString;
                        //}
                        //else
                        //{
                        //    lblPDNumber.Text = PDID.ToString();
                        //    lblGrade.Text = dataRow["JobGrade"].ToString();
                        //}

                        string displayValue = String.Empty;
                        //not getting PositionDescriptionTypeDisp from the db to improve performance
                        //Interpreting PositionDescriptionTypeDisp value 
                        //from PositionDescriptionTypeID/IsInterDisciplinaryPD column value

                        //if (!String.IsNullOrEmpty(positionDescriptionTypeDisp))
                        //{
                        //    //Just have it say "Ladder" for Career Ladder PDs
                        //    displayValue = (positionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD) ? "Ladder" : String.Format("<span style='white-space: nowrap;'>{0}</span>", positionDescriptionTypeDisp);
                        //}
                        switch (positionDescriptionTypeID)
                        {
                            case (int)PDChoiceType.StatementOfDifferencePD:
                                displayValue = "SOD";
                                break;
                            case (int)PDChoiceType.CareerLadderPD:
                                displayValue = "Ladder";
                                break;
                            default:
                                break;
                        }
                        if ((String.IsNullOrEmpty(displayValue)) && (isInterdisciplinary))
                        {
                            //Issue: 1510 - To shorten the word.
                            displayValue = "Interdisc."; //"Interdisciplinary"; 
                        }

                        lblPDType.Text = displayValue;


                        int checkedOutByID = -1;
                        DateTime checkOutDate = DateTime.MinValue;
                        string checkedOutBy = String.Empty;

                        int checkedInByID = -1;
                        DateTime checkInDate = DateTime.MinValue;
                        string checkedInBy = String.Empty;


                        if (dataRow["CheckedOutByID"] != DBNull.Value)
                            checkedOutByID = (int)dataRow["CheckedOutByID"];

                        if (dataRow["CheckOutDate"] != DBNull.Value)
                            checkOutDate = (DateTime)dataRow["CheckOutDate"];

                        if (dataRow["CheckedOutBy"] != DBNull.Value)
                            checkedOutBy = (String)dataRow["CheckedOutBy"];

                        if (dataRow["CheckedInByID"] != DBNull.Value)
                            checkedInByID = (int)dataRow["CheckedInByID"];

                        if (dataRow["CheckInDate"] != DBNull.Value)
                            checkInDate = (DateTime)dataRow["CheckInDate"];

                        if (dataRow["CheckedInBy"] != DBNull.Value)
                            checkedInBy = (String)dataRow["CheckedInBy"];

                        Image imgPDCheckedOutStatus = dataItem.FindControl("imgPDCheckedOutStatus") as Image;
                        string editedBy = String.Format("Being edited by {0} since {1}", checkedOutBy, checkOutDate.ToString("d"));

                        if (checkedOutByID != -1)
                        {
                            imgPDCheckedOutStatus.Visible = true;
                            imgPDCheckedOutStatus.ImageUrl = checkedOutBy.Equals(base.CurrentUser.FullNameReverse, StringComparison.InvariantCultureIgnoreCase) ? Page.ResolveUrl(string.Format ("~/App_Themes/{0}/Images/Icons/icon_unlock.gif",Page.Theme )) : Page.ResolveUrl(string.Format ("~/App_Themes/{0}/Images/Icons/icon_lock.gif",Page.Theme ));
                            imgPDCheckedOutStatus.ToolTip = editedBy;
                            dataItem.ToolTip = editedBy;
                        }


                        #region [ Action menu ]

                        RadMenu menuAction = dataItem.FindControl("rmPDAction") as RadMenu;
                        menuAction.Attributes["PositionDescriptionID"] = PDID.ToString();

                        RadMenuItem viewMenuItem = menuAction.FindItemByValue("View");
                        RadMenuItem editMenuItem = menuAction.FindItemByValue("Edit");
                        RadMenuItem continueMenuItem = menuAction.FindItemByValue("ContinueEdit");
                        RadMenuItem finishMenuItem = menuAction.FindItemByValue("FinishEdit");
                        RadMenuItem csnMenuItem = menuAction.FindItemByValue("CSN");
                        RadMenuItem sodMenuItem = menuAction.FindItemByValue("SOD");
                        RadMenuItem deleteMenuItem = menuAction.FindItemByValue("Delete");

                        //Hide SOD for StandardPD
                        string isStandardPD = dataRow["IsStandardPD"].ToString();
                        if (isStandardPD.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                        {
                            sodMenuItem.Visible = false;
                        }

                        if (positionDescriptionTypeID == (int)PDChoiceType.StatementOfDifferencePD)
                        {
                            //Hide SOD option for SOD PDs
                            sodMenuItem.Visible = false;
                            csnMenuItem.Visible = false;
                        }

                        //Hide SOD if PD is career ladder PD
                        if (positionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD)
                        {
                            sodMenuItem.Visible = false;
                        }

                        string PDStatus = dataRow["WorkflowStatusName"].ToString();
                        bool pdIsInactive = PDStatus.Equals("Inactive", StringComparison.InvariantCultureIgnoreCase);

                        //if Published - View, CSN, SOD
                        //if other - just View
                        if (PDStatus.Equals("Published", StringComparison.InvariantCultureIgnoreCase))
                        {
                            viewMenuItem.Visible = true;
                            editMenuItem.Visible = false;
                            continueMenuItem.Visible = false;
                            finishMenuItem.Visible = false;
                        }
                        else
                        {
                            //for In-Process PDs, view option is only available for PDs in edit mode
                            //but to the user who is not currently editing it.
                            viewMenuItem.Visible = !((checkedOutByID != -1) && checkedOutByID == CurrentUser.UserID);
                            //for In-Process PDs, edit option is only available 
                            //for PDs that are not inactive and that are not being edited
                            // and to the user who has permission to edit
                            editMenuItem.Visible = !(checkedOutByID != -1) && CanCheckOut(PDID) && !pdIsInactive;
                            //for In-Process PDs, continueEdit option is only available
                            // for PDs that are not inactive and that are being edited
                            // and to the user who is editing the given PD
                            continueMenuItem.Visible = (checkedOutByID != -1) && CanContinueEdit(checkedOutByID) && !pdIsInactive;

                            // for In-Process PDs, FinishEdit option is only available 
                            // for PDs that are not inactive and that are being edited
                            // and to the user who is editing the given PD  or if the user has access to PD's org code and belongs to
                            // one of these roles -- Evaluator/Classifier(14/15), Administrator (Regional/System)
                            finishMenuItem.Visible = (checkedOutByID != -1) && CanCheckIn(checkedOutByID) && !pdIsInactive;

                            if (finishMenuItem.Visible && checkedOutByID != CurrentUser.UserID)
                            {
                                finishMenuItem.Text += String.Format(" ({0})", editedBy);
                            }

                            csnMenuItem.Visible = false;
                            sodMenuItem.Visible = false;
                        }

                        if (PDStatus.Equals("Draft", StringComparison.InvariantCultureIgnoreCase))
                        {
                            if (base.IsAdmin)
                            {
                                deleteMenuItem.Visible = true;
                            }
                            else
                            {
                                deleteMenuItem.Visible = false;
                            }
                        }
                        else
                        {
                            deleteMenuItem.Visible = false;
                        }


                        #endregion

                        #region [ Document menu ]

                        RadMenu menuDocument = dataItem.FindControl("rmDocument") as RadMenu;
                        menuDocument.Attributes["PositionDescriptionID"] = PDID.ToString();

                        // Hide Evaluation Statement Document if not exists

                        int hasEvalStatement = Convert.ToInt32(dataRow["HasEvalStatement"]);
                        if (hasEvalStatement == 1)
                        {
                            menuDocument.FindItemByValue("4").Visible = true;
                        }
                        else
                        {
                            menuDocument.FindItemByValue("4").Visible = false;
                        }
                        //Hide comments document if not exists

                        bool hasPDCommentsRecommendations = Convert.ToBoolean(dataRow["HasPDCommentsRecommendations"]);
                        if (hasPDCommentsRecommendations)
                        {
                            menuDocument.FindItemByValue("5").Visible = true;
                        }
                        else
                        {
                            menuDocument.FindItemByValue("5").Visible = false;
                        }

                        //Hide coding info document for CL PDs
                        //commented following as there is no more conding info document available for any pds
                        //as pd-pdf and coding info is consolidated for all the pd types --issue 961
                        //menuDocument.FindItemByValue("3").Visible = positionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD ? false : true;

                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    base.HandleException(ex);
                }
            }
        }

        private string GetOrgCodeString(DataRowView dr)
        {
            string returnValue = string.Empty;
            if (dr["OrganizationCode"] == DBNull.Value)
                returnValue = "N/A";
            else
                returnValue = string.Format("{0} ({1})", dr["OrganizationCode"].ToString(), dr["OldOrganizationCode"] == DBNull.Value ? "N/A" : dr["OldOrganizationCode"].ToString());

            return returnValue;
        }

        #endregion

        #region [ Context Menu handlers ]

        protected void rmPDAction_ItemClick(object sender, RadMenuEventArgs e)
        {
            RadMenu rmPDAction = sender as RadMenu;
            long itemPDID = Convert.ToInt64(rmPDAction.Attributes["PositionDescriptionID"]);
            base.ClearCurrentPD();
            base.CurrentPDID = itemPDID;

            switch (e.Item.Value)
            {
                case "View":

                    base.CurrentNavMode = enumNavigationMode.View;

                    if (base.CurrentPD.PositionDescriptionTypeID == (int)PDChoiceType.StatementOfDifferencePD)
                        base.GoToPDLink("~/CreatePD/SOD.aspx", true);
                    else
                        base.GoToPDLink("~/CreatePD/Occupation.aspx", true);
                    break;

                case "Edit":
                case "ContinueEdit":
                    base.CurrentNavMode = enumNavigationMode.Edit;

                    //If PD is CL, checkout the whole ladder
                    if (base.CurrentPD.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD)
                        base.CheckOutCLPositionDescription(itemPDID, CurrentUser.UserID);
                    else
                        base.CheckOutPositionDescription(itemPDID, CurrentUser.UserID);
                    //reloading the pd to get the new check out  information.
                    base.ReloadCurrentPD(CurrentPD.PositionDescriptionID);

                    if (base.CurrentPD.PositionDescriptionTypeID == (int)PDChoiceType.StatementOfDifferencePD)
                        base.GoToPDLink("~/CreatePD/SOD.aspx", false);
                    else
                        base.GoToPDLink("~/CreatePD/Occupation.aspx", false);
                    break;

                case "FinishEdit":
                    base.CurrentNavMode = enumNavigationMode.None;

                    //If PD is CL, checkin the whole ladder
                    if (base.CurrentPD.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD)
                        base.CheckInCLPositionDescription(itemPDID, CurrentUser.UserID);
                    else
                        base.CheckInPositionDescription(itemPDID, CurrentUser.UserID);
                    rgPositionDescription.Rebind();
                    break;

                case "CSN":
                    // Copy and Start New
                    base.CurrentNavMode = enumNavigationMode.Edit;

                    try
                    {
                        PositionDescription clonedPD = new PositionDescription();

                        // clone position description
                        clonedPD.PDCreatorID = base.CurrentUser.UserID;
                        if (base.CurrentPD.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD)
                            clonedPD.AddFromExistingCLBundle(itemPDID);
                        else
                            clonedPD.AddFromExisting(itemPDID);

                        if (clonedPD.PositionDescriptionID != NULLPDID)
                        {
                            // clear current sessions
                            base.ClearCurrentPD();
                            // set new position ID
                            base.CurrentPDID = clonedPD.PositionDescriptionID;
                            if (base.CurrentPD.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD)
                                base.CheckOutCLPositionDescription(clonedPD.PositionDescriptionID, base.CurrentUser.UserID);
                            else
                                base.CheckOutPositionDescription(clonedPD.PositionDescriptionID, base.CurrentUser.UserID);

                            base.SafeRedirect("~/CreatePD/Occupation.aspx");
                        }
                        else
                        {
                            base.PrintErrorMessage("PD Express could not create a copy of the selected position description.", true);
                        }
                    }
                    catch (Exception ex)
                    {
                        base.HandleException(ex);
                    }

                    break;

                case "SOD":
                    // clear current sessions
                    base.ClearCurrentPD();
                    base.CurrentAssociatedPDID = itemPDID;
                    base.CurrentPDChoice = PDChoiceType.StatementOfDifferencePD;
                    base.SafeRedirect("~/CreatePD/SOD.aspx");
                    break;

                case "Delete":
                    base.CurrentPD.Delete();
                    rgPositionDescription.Rebind();
                    break;
            }

            e.Item.Selected = false;
        }

        protected void rmDocument_ItemClick(object sender, RadMenuEventArgs e)
        {
            RadMenu rmDocument = sender as RadMenu;

            long PositionDescriptionID = Convert.ToInt64(rmDocument.Attributes["PositionDescriptionID"]);

            switch (e.Item.Value)
            {
                case "1":
                    radAjaxmgrReports.Redirect(string.Format("~/Documents/PositionDescription/PositionDescriptionDocument.aspx?PDID={0}", PositionDescriptionID));
                    break;
                case "2":
                    radAjaxmgrReports.Redirect(string.Format("~/Documents/JobAnalysis/JobAnalysisDocument.aspx?PDID={0}", PositionDescriptionID));
                    break;
                case "3":
                    radAjaxmgrReports.Redirect(string.Format("~/Documents/CodingInfo/CodingInfoDocument.aspx?PDID={0}", PositionDescriptionID));
                    break;
                case "4":
                    radAjaxmgrReports.Redirect(string.Format("~/Documents/Evaluation/EvaluationStatementDocument.aspx?PDID={0}", PositionDescriptionID));
                    break;
                case "5":
                    radAjaxmgrReports.Redirect(string.Format("~/Documents/Comments/PDCommentsDocument.aspx?PDID={0}", PositionDescriptionID));
                    break;

            }

            e.Item.Selected = false;
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
                    //Staffing manager/staffing specialist should be able to checkout PD in review or final review
                    canCheckOut = (access != PDAccessType.ReadOnly) && (base.HasPermission(enumPermission.CompleteHRCertification)||(base.HasPermission(enumPermission.CompleteJNPCertification)));
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

        private int PositionDescriptionID
        {
            get
            {
                return Convert.ToInt32(txtPDNumber.Text.Trim());
            }
        }
        private string FPPSPDID
        {
            get
            {
                return this.txtPDNumber.Text;
            }
        }
        new private char? IsStandardPD
        {
            get
            {
                char? isStandardPD = null;

                if (rblType.SelectedIndex == 0)
                    isStandardPD = 'y';
                else if (rblType.SelectedIndex == 1)
                    isStandardPD = 'n';

                return isStandardPD;
            }

        }


        private int? PositionDescriptionTypeID
        {
            get
            {
                int? PDTypeID = null;

                if ((rblPDType.SelectedIndex == -1) || (rblPDType.SelectedValue == "-1"))
                {
                    PDTypeID = null;
                }
                else
                {


                    PDTypeID = Convert.ToInt32(rblPDType.SelectedValue);
                }
                return PDTypeID;
            }
        }
        private int? JobSeriesID
        {
            get
            {
                int? JSID = null;
                if (rcbJobSeries.SelectedValue == "-1")
                {
                    JSID = null;
                }
                else
                {
                    JSID = Convert.ToInt32(rcbJobSeries.SelectedValue);
                }
                return JSID;
            }

        }

        private int PDStatusID
        {
            get
            {
                return Convert.ToInt32(rcbPDStatus.SelectedValue);
            }
        }

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
