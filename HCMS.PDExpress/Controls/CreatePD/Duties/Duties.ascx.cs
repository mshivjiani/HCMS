using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

using Telerik.Web.UI;
using Telerik.Web.UI.Editor.Diff;

using HCMS.Business.PD;
using HCMS.Business.LogObjects;
using HCMS.Business.Lookups;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.Duty;
using HCMS.PDExpress.Controls.Search;

namespace HCMS.PDExpress.Controls.CreatePD.Duties
{
    public partial class Duties : CreatePDUserControlBase
    {


        public List<PositionCompetencyKSA> QualList
        {
            get
            {
                if (ViewState["QualList"] == null)
                    ViewState["QualList"] = new List<PositionCompetencyKSA>();

                return (List<PositionCompetencyKSA>)ViewState["QualList"];
            }
            set
            {
                ViewState["QualList"] = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);


            this.btnContinue.Click += new EventHandler(btnContinue_Click);
            this.rgDuty.ItemCreated += new GridItemEventHandler(rgDuty_ItemCreated);
            this.rgQual.ItemCreated += new GridItemEventHandler(rgQual_ItemCreated);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //_searchKSA.ShowGradeSelection = false;
                //BindKSACombo(_radComboKSA);
                //radcomboKSAReqVal.Enabled = (CurrentMode == eMode.Insert);

                if (CurrentMode == eMode.Edit)
                {
                    BindData();
                }
            }
        }

        private int PositionCompetencyKSAID
        {
            get
            {
                if (ViewState["PositionCompetencyKSAID"] == null)
                {
                    string PositionCompetencyKSAIDParam = Request.QueryString["PositionCompetencyKSAID"];

                    if (String.IsNullOrEmpty(PositionCompetencyKSAIDParam))
                        ViewState["PositionCompetencyKSAID"] = -1;
                    else
                        ViewState["PositionCompetencyKSAID"] = int.Parse(PositionCompetencyKSAIDParam);
                }
                return (int)ViewState["PositionCompetencyKSAID"];

            }
            set
            {
                ViewState["PositionCompetencyKSAID"] = value;
            }
        }

        private bool IsInView
        {
            get
            {
                if (ViewState["IsInView"] == null)
                {
                    ViewState["IsInView"] = false;
                }
                return (bool)ViewState["IsInView"];
            }
            set
            {
                ViewState["IsInView"] = value;
            }
        }

        //private List<KSA> KSAList
        //{
        //    get
        //    {
        //        List<KSA> ksalist = new List<KSA>();
        //        int seriesid = -1;
        //        int grade = -1;
        //        string cacheKey = string.Empty;

        //        if (base.CurrentPD != null)
        //        {
        //            seriesid = base.CurrentPD.JobSeries;
        //            grade = base.CurrentPD.ProposedGrade;
        //            cacheKey = string.Format("{0}-{1}", seriesid.ToString(), grade.ToString());
        //            if (Cache[cacheKey] == null)
        //            {
        //                ksalist = Series.GetSeriesGradeKSA(seriesid, grade);
        //                Cache.Insert(cacheKey, ksalist, null, DateTime.UtcNow.AddMinutes(5), System.Web.Caching.Cache.NoSlidingExpiration);
        //            }
        //            else
        //            {
        //                ksalist = (List<KSA>)Cache[cacheKey];
        //            }

        //        }
        //        return ksalist;
        //    }
        //}

        protected void tbDutyDescriptionCustVal_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (String.IsNullOrEmpty(args.Value))
            {
                args.IsValid = false;
                customValidationFailed = true;
            }

            if (customValidationFailed)
            {
                ValidationMessage = String.Empty;
            }
        }

        protected void tbQualificationDescriptionCustVal_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (String.IsNullOrEmpty(args.Value))
            {
                args.IsValid = false;
                customValidationFailed = true;
            }

            if (customValidationFailed)
            {
                ValidationMessage = String.Empty;
            }
        }

        #region [ Page Event Handlers ]

        protected override void OnLoad(EventArgs e)
        {
            if (base.CurrentPDID == NULLPDID)
            {
                string referringUrl = Context.Request.UrlReferrer.ToString().ToLower();
                base.HandleException("Current Position Description is not set.");
            }
            else
            {
                //Redirect to DutyDiff page if the PD is in Revise Status and Reviewed flag not set
                if (base.CurrentPD.GetCurrentPDStatus() == PDStatus.Revise && !(base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD) && !IsPDReadOnly)
                {
                    if (!base.CurrentPD.ArePositionDutiesReviewed && this.HasDutyDifferences())
                        base.SafeRedirect("~/CreatePD/ShowDutyDiff.aspx");
                    else
                    {
                        LoadDuties();
                    }
                }
                else
                {
                    LoadDuties();
                }
            }

            base.OnLoad(e);
        }

        private bool HasDutyDifferences()
        {
            bool returnValue = false;

            if (base.CurrentPD.HasDutyDifferences(false))
                returnValue = true;
            return returnValue;
        }

        private void LoadDuties()
        {
            if (!IsPostBack)
            {
                LoadData();
                SetPageView();

            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            rgDuty.Enabled = RGDutyEnabled;
            rgQual.Enabled = RGQualEnabled;
            base.OnPreRender(e);
        }

        #endregion

        #region [ Private Methods ]


        private void BindData()
        {
            if (PositionCompetencyKSAID > 0)
            {
                PositionCompetencyKSA pdQual = new PositionCompetencyKSA(PositionCompetencyKSAID);
                _radEditorQualDescription.Content = pdQual.CompetencyKSA.Replace("\n", "<br />");
                _radComboQualID.SelectedValue = pdQual.QualificationID.ToString();
                _radcomboQualificationTypeID.SelectedValue = pdQual.QualificationTypeID.ToString();
                //_radComboKSA.SelectedValue = pdQual.KSAID.ToString();
            }
        }

        private void LoadData()
        {
            try
            {
                //Get Introduction
                // ControlUtility.SafeTextBoxAssign(tbIntro, PD.GetIntroduction());
                //Set Show Existing PDs Url based on PD's job series and proposed grade
                string url = String.Format("~/Search/SearchReportsAdvanced.aspx?jobSeries={0}&proposedGrade={1}&workflowStatus={2}", PD.JobSeries, PD.ProposedGrade, (int)PDStatus.Published);
                hlShowExistingPDs.NavigateUrl = url;
                //Set url for Duty Difference page
                string urlDutyDiff = string.Format("~/CreatePD/ShowDutyDiff.aspx?PDID={0}", base.CurrentPDID);
                hlShowDutyDiffs.NavigateUrl = urlDutyDiff;
                //create client click functionality to display duty definition window 
                lbDutyDefinition.Attributes.Add("onClick", "ShowDutyDefinition('" + PD.JobSeries.ToString() + "'); return false;");
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void SetPageView()
        {
            bool editable = !IsPDReadOnly;
            bool okToUse = false;
            bool isSOD = base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
            PDStatus status = base.CurrentPD.GetCurrentPDStatus();
            bool isPDCreator = base.CurrentPD.PDCreatorID.Equals(base.CurrentUser.UserID);
            bool isPDCreatorSupervisor = base.isPDCreatorSupervisor(false);
            bool hasHRGroupPermission = editable && base.HasHRGroupPermission;
            bool isAdmin=base.IsAdmin ;

            //Show Duty Diff Link based on the conditions below.
            hlShowDutyDiffs.Visible = editable
                && ((status.Equals(PDStatus.Revise) || (status.Equals(PDStatus.FinalReview)))
                && (base.CurrentPD.ArePositionDutiesReviewed && this.HasDutyDifferences()))
                && !(isSOD);

            if (isSOD)
            {
                btnContinue.Enabled = false;
                //btnIntroSave.Enabled = false;
                rgDuty.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                rgQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                rgDuty.Columns[0].Visible = false; //duty edit
                rgDuty.Columns[1].Visible = false;//duty delete
                rgDuty.Columns[1].Display = false;//duty delete  --setting the visible=false does not hide the gridbuttoncolumn
                rgQual.Columns[0].Visible = false;//qual edit
                rgQual.Columns[1].Visible = false;//qual delete
            }

            else
            {
                switch (status)
                {
                    case PDStatus.Draft:
                        okToUse = editable && ((isPDCreator || isPDCreatorSupervisor||isAdmin));
                        break;
                    //Gives HR permission to Edit Duties
                    case PDStatus.Review:
                        okToUse = editable && (hasHRGroupPermission||isAdmin) ;
                        break;
                    case PDStatus.Revise:
                        okToUse = editable && ((isPDCreator || isPDCreatorSupervisor ||isAdmin));
                        break;
                    case PDStatus.FinalReview:
                        okToUse = editable && base.HasPermission(enumPermission.AllSystemAdministrationPermissions);
                        break;
                    default: //takes care of PUBLISHED Status as well
                        okToUse = editable;
                        break;
                }

                btnContinue.Enabled = okToUse;
                //btnIntroSave.Enabled = okToUse;
                rgDuty.Columns[0].Visible = okToUse;  // Edit column
                rgDuty.Columns[1].Visible = okToUse;  // Delete column
                rgDuty.Columns[1].Display = okToUse; //setting the visible=false does not hide the gridbuttoncolumn --delete column

                if (!base.IsAdmin && status.Equals(PDStatus.FinalReview) && base.HasHRGroupPermission)
                {
                    rgDuty.Columns[2].Display = true; //view column
                }
                else
                {
                    rgDuty.Columns[2].Display = IsPDReadOnly; //view column
                    rgDuty.Columns[2].Visible = IsPDReadOnly;
                }

                rgQual.Columns[0].Visible = okToUse;  // Edit column
                rgQual.Columns[1].Visible = okToUse;  // Delete column


                if (!okToUse)
                {
                    //tbIntro.ReadOnly = true;
                    //disable addnew link of the rgduty
                    rgDuty.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    rgQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                }
            }
        }

        #endregion

        #region [ Page button event handlers ]

        protected bool CheckIfEachMajorDutyHasOneDutyKSA()
        {

            List<PositionDuty> pdDuties = CurrentPD.GetPositionDuty();


            List<DutyCompetencyKSA> dutyCompetencyKSAList = new List<DutyCompetencyKSA>();

            foreach (PositionDuty pdDuty in pdDuties)
            {
                if (pdDuty.DutyTypeID == (int)DutyTypeID.Major)
                {
                    dutyCompetencyKSAList = pdDuty.GetDutyCompetencyKSA();

                    if (dutyCompetencyKSAList.Count <= 0)
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    if (isInEditMode(rgDuty))
                    {
                        ValidationMessage = "Please click 'Add Duty/Save Duty' to save the duty text.";

                    }
                    else
                    {
                        List<PositionDuty> duties = PD.GetPositionDuty();
                        int majorDutyCount = 0;
                        int totalMajorDutyPct = 0;
                        foreach (PositionDuty duty in duties)
                        {
                            if (duty.DutyTypeID == (int)DutyTypeID.Major)
                            {
                                majorDutyCount++;
                                totalMajorDutyPct += duty.PercentageOfTime;

                            }
                        }
                        if ((majorDutyCount >= 1 && majorDutyCount <= 8) && totalMajorDutyPct == 100)
                        {
                            //issue 941- Major Duties from Copied PDs can be left at 0% 
                            if (duties.Find(delegate(PositionDuty d) { return (d.DutyTypeID == 1 && d.PercentageOfTime == 0); }) != null)
                                ValidationMessage = "Major duty with 0 percentage of time.";
                            else if (!CheckIfEachMajorDutyHasOneDutyKSA())
                                ValidationMessage = "Please make sure each Major duty has at least one Duty KSA associated to it.";
                            else
                                base.GoToPDLink("~/CreatePD/PositionCharacteristics.aspx");

                        }
                        else
                        {

                            if (majorDutyCount == 0)
                            {
                                ValidationMessage = "No major duty is specified.";
                            }
                            else if (majorDutyCount > 8)
                            {
                                ValidationMessage = "More than 8 major duties specified.";
                            }
                            else
                            {
                                if (totalMajorDutyPct != 100)
                                {
                                    ValidationMessage = "Total '% of Time' for Major Duties should equal to 100%.";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is System.Threading.ThreadAbortException)
                    {
                        // there's nothing you can do. Even if you handle this exception - it will be raised again.
                    }
                    else
                    {
                        base.HandleException(ex);
                    }
                }
            }
            else
            {
                ValidationMessage = String.Empty;
            }
        }

        #endregion

        protected void radcomboQualificationTypeID_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            int qualtypeid = int.Parse(e.Item.Value);
            //only SF and COE are allowed at PD qual level
            if (qualtypeid != 2 && qualtypeid != 4)
            {
                e.Item.Remove();
            }
        }

        protected void radcomboKSA_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            _radEditorQualDescription.Content = e.Text;

            //GridEditFormItem editform = (GridEditFormItem)rgQual.MasterTableView.GetItems(GridItemType.EditFormItem)[0];

            //if (editform != null)
            //{
            //    RadEditor radEditorQualDescription = editform.FindControl("radEditorQualDescription") as RadEditor;
            //    radEditorQualDescription.Content = e.Text;
            //}
        }

        private void AssignValues(PositionCompetencyKSA pdCompetency)
        {
            if (CurrentMode == eMode.Insert)
            {
                pdCompetency.PositionDescriptionID = CurrentPDID;
                pdCompetency.CreatedByID = base.CurrentUser.UserID;
                pdCompetency.CreateDate = DateTime.Now;
            }
            //radeditor inserts extra '\r' and '\n' along with <br />
            //therefore replacing <br /> to '' to save it to db so that it does not create extra new line
            //saving radeditor's text because if user formats the text,it will insert
            //html tags with content. Don't want to save html tags in the database 
            pdCompetency.CompetencyKSA = _radEditorQualDescription.Text;
            pdCompetency.QualificationTypeID = Convert.ToInt32(_radcomboQualificationTypeID.SelectedValue);
            pdCompetency.QualificationID = Convert.ToInt32(_radComboQualID.SelectedValue);
            pdCompetency.UpdatedByID = base.CurrentUser.UserID;
            pdCompetency.UpdateDate = DateTime.Now;
            //pdCompetency.KSAID = long.Parse(_radComboKSA.SelectedValue);
            pdCompetency.KSAID = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            _closeButtonClicked = true;
            base.GoToLink("~/CreatePD/Duties.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            PositionCompetencyKSA pdCompetency;
            string CloseScript = string.Empty;

            try
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    if (CurrentMode == eMode.Insert)
                    {
                        pdCompetency = new PositionCompetencyKSA();
                        AssignValues(pdCompetency);
                        pdCompetency.Add();

                        //We are closing window hence this message is no longer required.
                        //lblmsg.Text = "Position KSA added successfully.";

                        PositionCompetencyKSAID = pdCompetency.CompetencyKSAID;
                        CurrentMode = eMode.Edit;

                    }
                    else if (CurrentMode == eMode.Edit)
                    {
                        pdCompetency = new PositionCompetencyKSA(PositionCompetencyKSAID);
                        AssignValues(pdCompetency);
                        pdCompetency.Update();

                        //We are closing window hence this message is no longer required.
                        //lblmsg.Text = "Position KSA updated successfully.";
                    }

                    //CloseScript = string.Format("CloseWindow();");
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", CloseScript, true);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

        }



        #region [ Duty Grid Event Handlers and Methods]

        protected void rgDuty_PreRender(object sender, EventArgs e)
        {
            if (isSOD)
            {
                rgDuty.MasterTableView.GetColumn("DeleteCommandColumn").Visible = false;
            }
            else
            {
                if (base.IsPDReadOnly || rgQual.EditIndexes.Count > 0)
                {
                    rgDuty.MasterTableView.GetColumn("DeleteCommandColumn").Visible = false;
                }
                //Make this visible in Revise Status so HR can edit.
                else if (base.HasPermission(enumPermission.CreatePD)
                    && (base.CurrentPDChoice != PDChoiceType.StatementOfDifferencePD)
                    && (base.CurrentPDWorkflowStatus.WorkflowStatusName == PDStatus.Draft.ToString()
                        || base.CurrentPDWorkflowStatus.WorkflowStatusName == PDStatus.Review.ToString() || base.CurrentPDWorkflowStatus.WorkflowStatusName == PDStatus.Revise.ToString()))
                {
                    rgDuty.MasterTableView.GetColumn("DeleteCommandColumn").Visible = true;
                }
            }

        }

        protected void rgDuty_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                List<PositionDuty> dutyList = PD.GetPositionDuty();
                dutyList.Sort(delegate(PositionDuty p1, PositionDuty p2) { return p1.PercentageOfTime.CompareTo(p2.PercentageOfTime); });
                dutyList.Reverse();
                rgDuty.DataSource = dutyList;

                ShowQualificationPanel(dutyList);

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rgDuty_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {
                SetEditForm(sender, e);
            }

            try
            {
                GridItem gridItem = e.Item;
                if (e.Item is GridGroupHeaderItem)
                {
                    GridGroupHeaderItem item = (GridGroupHeaderItem)e.Item;
                    DataRowView groupDataRow = (DataRowView)e.Item.DataItem;
                    item.DataCell.Text = string.Format("Duty  Type: {0} | Total: {1}"
                        , groupDataRow["DutyType"].ToString()
                        , groupDataRow["PercentageOfTime"].ToString());

                }

                if (gridItem.ItemType == GridItemType.Item || gridItem.ItemType == GridItemType.AlternatingItem)
                {
                    if (gridItem.DataItem is PositionDuty)
                    {
                        PositionDuty positionDuty = gridItem.DataItem as PositionDuty;
                        var _lblDutyDescription = gridItem.FindControl("lblDutyDescription") as Label;
                        var _lblPercentageOfTime = gridItem.FindControl("lblPercentageOfTime") as Label;
                        var _lblDutyTypeName = gridItem.FindControl("lblDutyTypeName") as Label;
                        var _btnAddEditDutyQualification = gridItem.FindControl("btnAddEditDutyQualification") as Button;
                        var _rdutyqual = gridItem.FindControl("radListDutyQual") as RadListBox;

                        var _lblQualificationName = gridItem.FindControl("lblQualificationName") as Label;
                        var _lblQualificationDescription = gridItem.FindControl("lblQualificationDescription") as Label;
                        var _lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;


                        _lblDutyDescription.Text = positionDuty.DutyDescription.Replace("\n", "<br />");

                        if (positionDuty.PercentageOfTime == -1)
                            _lblPercentageOfTime.Text = String.Empty;
                        else
                            _lblPercentageOfTime.Text = positionDuty.PercentageOfTime.ToString();
                        List<DutyCompetencyKSA> dutyQual = positionDuty.GetDutyCompetencyKSA();
                        _rdutyqual.DataSource = dutyQual;
                        _rdutyqual.DataBind();
                        _lblDutyTypeName.Text = positionDuty.DutyType;
                        _btnAddEditDutyQualification.Attributes.Add("onclick", "ShowDutyQualPopup('" + positionDuty.DutyID.ToString() + "'); return false;");
                    }
                }
                else if (gridItem.ItemType == GridItemType.EditItem)
                {
                    var _tbDutyDescription = gridItem.FindControl("tbDutyDescription") as TextBox;
                    var _rcbPercentageOfTime = gridItem.FindControl("rcbPercentageOfTime") as RadComboBox;
                    var _rcbDutyTypeName = gridItem.FindControl("rcbDutyTypeName") as RadComboBox;
                    var _btnAddEditDutyQualification = gridItem.FindControl("btnAddEditDutyQualification") as Button;
                    var _rdutyqual = gridItem.FindControl("radListDutyQual") as RadListBox;

                    if (gridItem.DataItem is PositionDuty)
                    {
                        // edit existing row
                        PositionDuty positionDuty = gridItem.DataItem as PositionDuty;
                        ControlUtility.SafeTextBoxAssign(_tbDutyDescription, positionDuty.DutyDescription);
                        _rcbPercentageOfTime.SelectedValue = positionDuty.PercentageOfTime.ToString();
                        _rcbDutyTypeName.SelectedValue = positionDuty.DutyTypeID.ToString();
                    }
                    else if (gridItem.DataItem is GridInsertionObject)
                    {
                        // edit row to be inserted

                        _tbDutyDescription.Text = String.Empty;
                        _rcbPercentageOfTime.SelectedIndex = -1;
                        _rcbDutyTypeName.SelectedIndex = -1;
                    }
                }
                if (gridItem is GridDataInsertItem && gridItem.IsInEditMode)
                {
                    GridDataInsertItem insertItem = (GridDataInsertItem)gridItem;
                    insertItem["DeleteCommandColumn"].Controls[0].Visible = false;
                    insertItem["DeleteCommandColumn"].Controls.Add(new LiteralControl("&nbsp;"));
                }
                //hide the refresh button Telerik.Web.UI.GridLinkButton
                if (gridItem is GridCommandItem)
                {
                    gridItem.FindControl("RebindGridButton").Visible = false;

                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rgDuty_ItemCreated(object source, GridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
                {
                    Button btnAddEditDutyQualification = (Button)e.Item.FindControl("btnAddEditDutyQualification");
                    bool isSOD = base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
                    bool isEditable = !base.IsPDReadOnly && (base.CurrentPD.GetCurrentPDStatus() == PDStatus.Draft || base.CurrentPD.GetCurrentPDStatus() == PDStatus.Review || base.CurrentPD.GetCurrentPDStatus() == PDStatus.Revise) && base.HasPermission(enumPermission.CreatePD);
                    btnAddEditDutyQualification.Text = (isEditable && !isSOD) ? "Add/Edit Qualifications" : "View Qualifications";
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rgDuty_ItemCommand(object source, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    RGQualEnabled = false;
                    ShowDuty(source, e);
                    break;
                //this command is called when EditMode=InPlace
                case RadGrid.PerformInsertCommandName:
                    if (!customValidationFailed)
                    {
                        AddDuty(source, e);
                    }
                    break;

                case RadGrid.EditCommandName:
                    RGQualEnabled = false;
                    ShowDuty(source, e);
                    break;

                case "View":
                    ShowDuty(source, e);
                    break;
                case RadGrid.CancelCommandName:
                    ValidationMessage = String.Empty;
                    break;
                //this command is called when EditMode=InPlace
                case RadGrid.UpdateCommandName:
                    if (!customValidationFailed)
                    {
                        UpdateDuty(source, e);
                    }
                    break;

                case RadGrid.DeleteCommandName:
                    DeleteDuty(source, e);

                    //reload
                    break;

                default:
                    RGQualEnabled = true;
                    break;
            }
        }

        private void ShowDuty(object source, GridCommandEventArgs e)
        {
            //radWindowManagerDuties.Windows.Clear();
            GridDataItem gridItem;
            string navigateurl = string.Empty;
            //string title = string.Empty;
            //string script = string.Empty;
            int dutyID;
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    long positionDescriptionID = CurrentPDID;
                    navigateurl = "~/CreatePD/AddEditDuty.aspx";
                    base.GoToLink(navigateurl, eMode.Insert, false);

                    //navigateurl = "~/CreatePD/AddEditDuty.aspx?mode=Insert&PositionDescriptionID=" + positionDescriptionID;
                    //title = "Add Duty";
                    //script = string.Format("ShowDutyWindowClient('{0}','{1}');", "Insert", positionDescriptionID);
                    break;
                case RadGrid.EditCommandName:
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    dutyID = int.Parse(gridItem.GetDataKeyValue("DutyID").ToString());
                    base.CurrentPDDutyID = dutyID;
                    navigateurl = "~/CreatePD/AddEditDuty.aspx";
                    base.GoToLink(navigateurl, eMode.Edit, false);

                    //navigateurl = "~/CreatePD/AddEditDuty.aspx?mode=Edit&DutyID=" + dutyID;
                    //title = "Edit Duty";
                    //script = string.Format("ShowDutyWindowClient('{0}','{1}');", "Edit", dutyID);
                    break;
                case "View":
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    dutyID = int.Parse(gridItem.GetDataKeyValue("DutyID").ToString());
                    base.CurrentPDDutyID = dutyID;
                    navigateurl = "~/CreatePD/AddEditDuty.aspx";
                    //JA issue id 890:Accessing Duty screen as HR Class in Final Review puts PD that was in edit mode into read only mode 
                    //changed the last argument to IsPDReadOnly -- as this is setting the PD's navigation mode
                    //where as 2nd argument is for EditDuty control only 
                    base.GoToLink(navigateurl, eMode.View, IsPDReadOnly);

                    //navigateurl = "~/CreatePD/AddEditDuty.aspx?mode=View&DutyID=" + dutyID;
                    //title = "View Duty";
                    //script = string.Format("ShowDutyWindowClient('{0}','{1}');", "View", dutyID);
                    break;
                default:
                    break;

            }

            //radWindowManagerDuties.Windows.Add(rwPDDuties);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        #region [Methods called When EditMode=InPlace]
        private void AddDuty(object source, GridCommandEventArgs e)
        {
            try
            {
                if (source is RadGrid)
                {
                    GridDataInsertItem gridItem = e.Item as GridDataInsertItem;

                    if (gridItem.ItemType == GridItemType.EditItem)
                    {
                        TextBox tbDutyDescription = gridItem.FindControl("tbDutyDescription") as TextBox;
                        RadComboBox rcbPercentageOfTime = gridItem.FindControl("rcbPercentageOfTime") as RadComboBox;
                        RadComboBox rcbDutyTypeName = gridItem.FindControl("rcbDutyTypeName") as RadComboBox;

                        string dutyDescription = tbDutyDescription.Text;
                        int percentageOfTime = int.Parse(rcbPercentageOfTime.SelectedValue);
                        int dutyTypeID = int.Parse(rcbDutyTypeName.SelectedValue);

                        if (ValidateDuty(dutyTypeID, percentageOfTime))
                        {
                            PositionDuty duty = new PositionDuty();

                            duty.PositionDescriptionID = PD.PositionDescriptionID;
                            duty.PercentageOfTime = percentageOfTime;
                            duty.DutyDescription = dutyDescription;
                            duty.DutyTypeID = dutyTypeID;
                            duty.CreatedByID = CurrentUser.UserID;
                            duty.CreateDate = DateTime.Now;
                            duty.UpdatedByID = CurrentUser.UserID;
                            duty.UpdateDate = DateTime.Now;

                            duty.Add();
                        }
                        else
                        {
                            e.Canceled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void UpdateDuty(object source, GridCommandEventArgs e)
        {
            try
            {
                if (source is RadGrid)
                {
                    RadGrid grid = source as RadGrid;

                    GridDataItem gridItem = e.Item as GridDataItem;
                    int dutyID = int.Parse(gridItem.GetDataKeyValue("DutyID").ToString());
                    long positionDescriptionID = long.Parse(gridItem.GetDataKeyValue("PositionDescriptionID").ToString());

                    TextBox tbDutyDescription = gridItem.FindControl("tbDutyDescription") as TextBox;
                    RadComboBox rcbPercentageOfTime = gridItem.FindControl("rcbPercentageOfTime") as RadComboBox;
                    RadComboBox rcbDutyTypeName = gridItem.FindControl("rcbDutyTypeName") as RadComboBox;

                    string dutyDescription = tbDutyDescription.Text;
                    int percentageOfTime = int.Parse(rcbPercentageOfTime.SelectedValue);
                    int dutyTypeID = int.Parse(rcbDutyTypeName.SelectedValue);

                    if (ValidateDuty(dutyTypeID, percentageOfTime))
                    {
                        PositionDuty duty = new PositionDuty(dutyID);

                        if (PD.CopyFromPDID != NULLPDID && (duty.PercentageOfTime != percentageOfTime || duty.DutyDescription.Equals(dutyDescription, StringComparison.InvariantCultureIgnoreCase) == false))
                        {
                            ValidationMessage = "Changing the duty percentage or description may result in full classification.";
                        }

                        duty.PercentageOfTime = percentageOfTime;
                        duty.DutyDescription = dutyDescription;
                        duty.DutyTypeID = dutyTypeID;

                        duty.Update();
                    }
                    else
                    {
                        e.Canceled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        private void DeleteDuty(object source, GridCommandEventArgs e)
        {
            try
            {
                if (source is RadGrid)
                {
                    GridDataItem gridItem = e.Item as GridDataItem;
                    int dutyID = int.Parse(gridItem.GetDataKeyValue("DutyID").ToString());
                    long positionDescriptionID = long.Parse(gridItem.GetDataKeyValue("PositionDescriptionID").ToString());

                    PositionDuty duty = new PositionDuty(dutyID);
                    duty.Delete();

                    //For issue 996 - to go to first page of grid when second page does not have any duty.
                    //Each page holds 5 duties.
                    int iSize = rgDuty.PageSize;
                    int iRowsInCurrentPage = rgDuty.MasterTableView.Items.Count;
                    int iGridPageCount = rgDuty.PageCount;

                    if (iRowsInCurrentPage == 1)
                    {
                        if (iGridPageCount == 1)
                            rgDuty.CurrentPageIndex = 0;
                        else
                            rgDuty.CurrentPageIndex = iGridPageCount - 2;
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        void ValidateQualDescriptionLength(object source, ServerValidateEventArgs args)
        {
            var qualDescr = (RadEditor)source;
            if (qualDescr.Content.Length > 9) throw new Exception("Length cannot be more than 10");

        }

        private bool ValidateDuty(int dutyTypeID, int percentageOfTime)
        {
            bool valid = false;
            ValidationMessage = String.Empty;

            if (dutyTypeID == (int)DutyTypeID.Major)
            {
                if (percentageOfTime != 0)
                    valid = true;
                else
                    ValidationMessage = "Major duty has to have \"% of Time\" greater than zero.";
            }
            else if (dutyTypeID == (int)DutyTypeID.Other)
            {
                if (percentageOfTime == 0)
                    valid = true;
                else
                    ValidationMessage = "Other duty cannot have \"% of Time\" other than zero.";
            }

            return valid;
        }

        private void ShowQualificationPanel(List<PositionDuty> dutyList)
        {
            try
            {
                bool shouldBeVisible = dutyList.Count > 0 ? true : false;

                if (shouldBeVisible)
                {
                    pnlQual.Visible = true;
                    rgQual.Rebind();
                }
                else if (!shouldBeVisible)
                {
                    pnlQual.Visible = false;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region [ Position Qualification Grid Event Handlers and Methods]
        protected void rgOverAllKSAs_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                List<PositionCompetencyKSA> overAllKSAList = QualList.Where
                                                   (p => (p.QualificationTypeID != (int)enumQualificationType.ConditionOfEmployment))
                                                   .ToList();
                rgOverAllKSAs.DataSource = overAllKSAList;


            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion

        #region [ Position Qualification Grid Event Handlers and Methods]

        protected void rgQual_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {

            try
            {
                QualList = PD.GetPositionCompetencyKSA();
                List<PositionCompetencyKSA> coeList = QualList.Where
                                    (p => (p.QualificationTypeID == (int)enumQualificationType.ConditionOfEmployment))
                                    .ToList();
                rgQual.DataSource = coeList;
                pnlOverallKSAs.Visible = QualList.Count > coeList.Count ? true : false;
                if (pnlOverallKSAs.Visible)
                    rgOverAllKSAs.Rebind();

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rgQual_ItemCreated(object sender, GridItemEventArgs e)
        {
            // The Qualification RadGrid is being created. If we are in EditMode, then find 
            //  and create pointers to all of the individual edit controls in the editform template
            if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            {
                _rgQualEditForm = (GridEditFormItem)e.Item;
                _btnUpdate = (_btnUpdate == null ? (Button)_rgQualEditForm.FindControl("btnUpdate") : _btnUpdate);
                _radEditorQualDescription = (_radEditorQualDescription == null ? (RadEditor)_rgQualEditForm.FindControl("radEditorQualDescription") : _radEditorQualDescription);
                _radComboQualID = (_radComboQualID == null ? (RadComboBox)_rgQualEditForm.FindControl("radComboQualID") : _radComboQualID);
                _radcomboQualificationTypeID = (_radcomboQualificationTypeID == null ? (RadComboBox)_rgQualEditForm.FindControl("radcomboQualificationTypeID") : _radcomboQualificationTypeID);
            }
        }

        protected void rgQual_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {
                SetEditForm(sender, e);
            }

        
            GridItem gridItem = e.Item;

            if (gridItem.ItemType == GridItemType.Item || gridItem.ItemType == GridItemType.AlternatingItem)
            {
                if (gridItem.DataItem is PositionCompetencyKSA)
                {
                    PositionCompetencyKSA positionQual = gridItem.DataItem as PositionCompetencyKSA;
                    var lblQualificationName = gridItem.FindControl("lblQualificationName") as Label;
                    var lblQualificationDescription = gridItem.FindControl("lblQualificationDescription") as Label;
                    var lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;

                    lblQualificationName.Text = positionQual.QualificationName;
                    lblQualificationDescription.Text = positionQual.CompetencyKSA;
                    lblQualificationTypeName.Text = positionQual.QualificationTypeName;
                }
            }
            else if (gridItem.ItemType == GridItemType.EditFormItem && gridItem.IsInEditMode)
            {
                if (gridItem.DataItem is PositionCompetencyKSA)
                {
                    // edit existing row
                    var qual = gridItem.DataItem as PositionCompetencyKSA;
                    _radComboQualID.SelectedValue = qual.QualificationID.ToString();
                    _radEditorQualDescription.Content = (qual.CompetencyKSA.Length > 0 ? qual.CompetencyKSA : string.Empty);
          

                }
                else if (gridItem.DataItem is GridInsertionObject)
                {
                    // edit row to be inserted

                    _radComboQualID.SelectedIndex = -1;
                    _radEditorQualDescription.Content = String.Empty;
                   
                }
            }

            if (gridItem is GridDataInsertItem && gridItem.IsInEditMode)
            {
                GridDataInsertItem insertItem = (GridDataInsertItem)gridItem;
                insertItem["DeleteCommandColumn"].Controls[0].Visible = false;
                insertItem["DeleteCommandColumn"].Controls.Add(new LiteralControl("&nbsp;"));
            }
            //hide the refresh button Telerik.Web.UI.GridLinkButton
            if (gridItem is GridCommandItem)
            {
                gridItem.FindControl("RebindGridButton").Visible = false;

            }

           
        }

        protected void rgQual_ItemCommand(object source, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    RGDutyEnabled = false;
                    break;
                //this command is called when EditMode=InPlace
                case RadGrid.PerformInsertCommandName:
                    if (!customValidationFailed)
                    {
                        AddQualification(source, e);
                    }
                    break;

                case RadGrid.EditCommandName:
                    RGDutyEnabled = false;
                    break;

                case RadGrid.CancelCommandName:
                    break;
                //this command is called when EditMode=InPlace
                case RadGrid.UpdateCommandName:
                    if (!customValidationFailed)
                    {
                        UpdateQualification(source, e);
                    }
                    break;

                case RadGrid.DeleteCommandName:
                    DeleteQualification(source, e);
                    break;

                default:
                    RGDutyEnabled = true;
                    break;
            }

            //// If you click "Close" button, hide the RadGrid editForm
            //if (_closeButtonClicked)
            //{
            //    rgQual.MasterTableView.ClearEditItems();
            //}
        }

        protected void rgQual_PreRender(object sender, EventArgs e)
        {
            // making all other items invisible except edit form when adding new or editing
            GridItem[] gridcommanditems = rgQual.MasterTableView.GetItems(GridItemType.CommandItem);

           
            if (rgQual.MasterTableView.IsItemInserted || rgQual.EditItems.Count > 0)
            {
                foreach (GridItem item in rgQual.Items)
                {
                    item.Visible = false;
                }

                //hiding all command items
                foreach (GridItem item in gridcommanditems)
                {
                    item.Visible = false;
                }
                //hiding headers
                rgQual.MasterTableView.ShowHeader = false;
                rgQual.MasterTableView.ShowFooter = false;
                rgQual.ShowFooter = false;
                // JA issueID :714 : PDX: Misleading - Save and Cont button doesn't save newly added COE 
                //hiding save and continue button while adding/editing PD coe                
                btnContinue.Visible = false;
            }
            else
            {
                foreach (GridItem item in gridcommanditems)
                {
                    item.Visible = true;
                   
                }
                foreach (GridItem item in rgQual.Items)
                {
                    item.Visible = true;
                }
                rgQual.MasterTableView.ShowHeader = true;
                rgQual.MasterTableView.ShowFooter = true;
                rgQual.ShowFooter = true;
                //JA Issue ID: 817: PDX: Save and continue button dissapears after adding a new COE on Duties Screen 
                btnContinue.Visible = true;
            }

            if (rgQual.EditIndexes.Count > 0)
            {
                if (isSOD || base.IsPDReadOnly)
                {
                    rgQual.MasterTableView.GetColumn("DeleteCommandColumn").Visible = false;

                }
                
            }
            

        }

        #region [Methods called When EditMode=InPlace]

        private void AddQualification(object source, GridCommandEventArgs e)
        {
            try
            {
                DateTime createDate = DateTime.Now;

                if (source is RadGrid)
                {
                    GridEditFormInsertItem gridItem = e.Item as GridEditFormInsertItem;
                    if (gridItem.ItemType == GridItemType.EditFormItem)
                    {

                        PositionCompetencyKSA positionCompetency = new PositionCompetencyKSA();
                        positionCompetency.KSAID = 0;
                        positionCompetency.PositionDescriptionID = PD.PositionDescriptionID;
                        positionCompetency.CompetencyKSA = _radEditorQualDescription.Text;
                        positionCompetency.Certification = String.Empty;
                        //positionCompetency.QualificationTypeID = Convert.ToInt32(_radcomboQualificationTypeID.SelectedValue);
                        positionCompetency.QualificationTypeID = (int)enumQualificationType.ConditionOfEmployment;
                        positionCompetency.CreatedByID = CurrentUser.UserID;
                        positionCompetency.CreateDate = createDate;
                        positionCompetency.UpdatedByID = CurrentUser.UserID;
                        positionCompetency.UpdateDate = createDate;
                        positionCompetency.QualificationID = Convert.ToInt32(_radComboQualID.SelectedValue);

                        positionCompetency.Add();

                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void UpdateQualification(object source, GridCommandEventArgs e)
        {
            try
            {
                if (source is RadGrid)
                {
                    GridEditFormItem gridItem = e.Item as GridEditFormItem;
                    int competencyKSAID = int.Parse(gridItem.GetDataKeyValue("CompetencyKSAID").ToString());
                    if (competencyKSAID > -1)
                    {
                        PositionCompetencyKSA positionCompetency = new PositionCompetencyKSA(competencyKSAID);
                        positionCompetency.CompetencyKSA = _radEditorQualDescription.Text;
                        //positionCompetency.QualificationTypeID = Convert.ToInt32(_radcomboQualificationTypeID.SelectedValue);
                        positionCompetency.QualificationID = Convert.ToInt32(_radComboQualID.SelectedValue);

                        positionCompetency.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        private void DeleteQualification(object source, GridCommandEventArgs e)
        {
            try
            {
                if (source is RadGrid)
                {
                    GridDataItem gridItem = e.Item as GridDataItem;
                    int competencyKSAID = int.Parse(gridItem.GetDataKeyValue("CompetencyKSAID").ToString());
                    long positionDescriptionID = long.Parse(gridItem.GetDataKeyValue("PositionDescriptionID").ToString());

                    PositionCompetencyKSA positionCompetency = new PositionCompetencyKSA(competencyKSAID);
                    positionCompetency.Delete();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }



        private void SetEditForm(object sender, GridItemEventArgs e)
        {
            GridItem griditem = e.Item as GridItem;

            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {

                GridEditFormItem editform = (GridEditFormItem)e.Item;

                if (e.Item is GridEditFormInsertItem)
                {

                    _btnUpdate.CommandName = RadGrid.PerformInsertCommandName;
                    _btnUpdate.Text = "Add KSA";
                    rgDuty.ShowFooter = false;

                    //if (rgQual.Items.Count <= 0)
                    //{
                        this.rgQual.MasterTableView.NoMasterRecordsText = "";
                        this.rgQual.MasterTableView.EnableNoRecordsTemplate = false;
                    //}
                }
                else
                {

                    _btnUpdate.CommandName = RadGrid.UpdateCommandName;
                    _btnUpdate.Text = "Save KSA";

                    if (IsInView)
                    {
                        _radComboQualID.Enabled = false;
                        _radcomboQualificationTypeID.Enabled = false;
                        _btnUpdate.Enabled = false;

                    }
                    rgDuty.ShowFooter = true;
                }
            }

        }

        //private void BindKSACombo(RadComboBox radcomboKSA)
        //{
        //    if (_searchKSA.KSAList.Count < 2) _searchKSA.RunSearchFillKSAList();
        //    var orderedList = _searchKSA.KSAList.OrderBy(o => o.KSAText).ToList();
        //    orderedList.RemoveAll(m => m.KSAText == UserControlBase.OTHERKSATEXT);
        //    var otherItem = new KSAEntity() { KSAID = 0, KSAText = UserControlBase.OTHERKSATEXT };
        //    orderedList.Insert(0, otherItem);
        //    ControlUtility.BindRadComboBoxControlWithBackground(radcomboKSA, orderedList, null, "KSAText", "KSAID", "<<--Select KSA First-->>");
        //}


        //private void PopulateKSAComboBox()
        //{
        //    _radComboKSA.Items.Clear();
        //    var orderedList = _searchKSA.KSAList.OrderBy(o => o.KSAText).ToList();
        //    orderedList.RemoveAll(m => m.KSAText == UserControlBase.OTHERKSATEXT);
        //    var otherItem = new KSAEntity() { KSAID = 0, KSAText = UserControlBase.OTHERKSATEXT };
        //    orderedList.Insert(0, otherItem);
        //    ControlUtility.BindRadComboBoxControlWithBackground(_radComboKSA, orderedList, null, "KSAText", "KSAID", "<<--Select KSA First-->>");
        //}


        #region [searchKSA Events]

        //private void searchKSA_KSASearchCancelCompleted(object sender, EventArgs e)
        //{
        //    BindKSACombo(_radComboKSA);
        //    _literalSearchMssg.Text = string.Empty;
        //}

        //private void searchKSA_KSASearchCompleted(object sender, EventArgs e)
        //{
        //    string ksaSelected = _radComboKSA.SelectedValue;
        //    BindKSACombo(_radComboKSA);
        //    if (ksaSelected.Length > 0) _radComboKSA.SelectedValue = ksaSelected;

        //    var keywordSearch = "";
        //    if (_searchKSA.KeywordSearched.Length > 0) keywordSearch = ". Searched on keyword: " + _searchKSA.KeywordSearched;

        //    if (_searchKSA.ShowAllGradesChecked)
        //        _literalSearchMssg.Text = string.Format("Search KSA in Series:{0}" + keywordSearch, _searchKSA.SeriesID.ToString());
        //    else
        //        _literalSearchMssg.Text = string.Format("Search KSA in Series:{0} - Grade:{1}" + keywordSearch, _searchKSA.SeriesID.ToString(), _searchKSA.CurrentGrade.ToString());
        //}

        //private void searchKSA_KSASearchClearCompleted(object sender, EventArgs e)
        //{
        //    BindKSACombo(_radComboKSA);
        //    _literalSearchMssg.Text = string.Empty;
        //}

        #endregion

        #endregion


        #region [ Private Properties ]

        private GridEditFormItem _rgQualEditForm;

        //private ctrlSearchKSA _searchKSA;
        //private RadComboBox _radComboKSA;
        private RadEditor _radEditorQualDescription;
        private RadComboBox _radComboQualID;
        private RadComboBox _radcomboQualificationTypeID;
        //private Label _literalSearchMssg;

        //private HtmlTableCell _tdsearch;
        //private HtmlTableRow _trksadd;
        private Button _btnUpdate;
        private bool _closeButtonClicked = false;

        private string ValidationMessage
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    lblValidationMessage.Text = String.Empty;
                    pnlValidationMessage.Visible = false;
                }
                else
                {
                    lblValidationMessage.Text = value;
                    pnlValidationMessage.Visible = true;
                }
            }
        }

        private PositionDescription PD
        {
            get
            {
                if (pd == null)
                {
                    pd = base.CurrentPD;
                }

                return pd;
            }
        }
        private bool isSOD
        {
            get { return base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD; }
        }

        private bool RGDutyEnabled
        {
            get
            {
                bool enabled = true;

                if (!String.IsNullOrEmpty(hfRGDutyEnabled.Value))
                {
                    enabled = Convert.ToBoolean(hfRGDutyEnabled.Value);
                }

                return enabled;
            }
            set
            {
                hfRGDutyEnabled.Value = value.ToString();
            }
        }

        private bool RGQualEnabled
        {
            get
            {
                bool enabled = true;

                if (!String.IsNullOrEmpty(hrRGQualEnabled.Value))
                {
                    enabled = Convert.ToBoolean(hrRGQualEnabled.Value);
                }

                return enabled;
            }
            set
            {
                hrRGQualEnabled.Value = value.ToString();
            }
        }
        /// <summary>
        /// Returns true if any item in the given grid is in edit mode
        /// </summary>
        /// <param name="rg"></param>
        /// <returns></returns>
        private bool isInEditMode(RadGrid rg)
        {
            bool isinedit = false;
            foreach (GridItem item in rg.MasterTableView.GetItems(GridItemType.EditItem))
            {
                if (item.IsInEditMode)
                {
                    isinedit = true;
                    break;
                }
            }
            return isinedit;

        }
        #endregion

        #region [ Private Fields ]
        private PositionDescription pd = null;
        private bool customValidationFailed = false;
        #endregion
    }
}
