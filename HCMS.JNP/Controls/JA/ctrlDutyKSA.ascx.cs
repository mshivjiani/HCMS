using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using Telerik.Web.UI;
using HCMS.Business.JA;
using HCMS.Business.PD;
using HCMS.Business.Duty;
using JNPReports = HCMS.JNP.Reports;
using HCMS.WebFramework.Site.Utilities;
using HCMS.JNP.Controls.Search;
using System.Web.UI.HtmlControls;
using HCMS.Business.Lookups;
using HCMS.Business.JQ;
namespace HCMS.JNP.Controls.JA
{
    public partial class ctrlDutyKSA : JNPUserControlBase
    {
        private const string DELETECOLUMN = "DeleteCommandColumn";
        private const string JADUTYID = "JADutyID";
        private const string RADEDITQUALDESCR = "radEditorQualDescription";
        private const string RADCOMBOQUALID = "radComboQualID";


        #region Private Properties

        //Keshab - These variables are no longer in use hence it needs to be removed
        //private GridEditFormItem _rgQualEditForm;
        private RadEditor _radEditorQualDescription;
        //private RadComboBox _radComboQualID;
        private RadComboBox _radcomboQualificationTypeID;
        //private Button _btnUpdate;

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
        private PositionDescription pd = null;
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
        #endregion

        #region Methods
        
        protected override void OnLoad(EventArgs e)
        {

            if (!IsPostBack)
            {
                if (IsValidJA())
                {
                    BindDuty();
                 
                    SetPageView();
                }
            }
            base.OnLoad(e);
        }

        private void BindDuty()
        {
            if (base.CurrentJobAnalysis != null)
            {
                // Issue: 729/768
                // Mark Deibert, 9/16/2013
                // Using exact same sorting as in ctrlJAFinalKSA
                List<JobAnalysisDuty> currentJADuties = base.CurrentJobAnalysis.GetJobAnalysisDuty();
                this.rgJADuty.DataSource = currentJADuties
                    .OrderByDescending(ob => ob.JAPercentageOfTime)
                    .ThenBy(ob2 => ob2.JADutyID);
                //commenting DataBind here because  BindDuty() is also called in rgJADuty.NeedDataSource.
                //That caused it throw the exception. --Fixing JA Issue ID:818 Error when I delete a duty that came over from a PD 
                //this.rgJADuty.DataBind();
            }
        }

        protected void SetPageView()
        {

            //Issue 1001 - Added a link in Duty KSA page to display the First Factor langauge in a popup screen.
            string urlhlFactor1 = string.Format("../JA/Factor1PopUp.aspx");
            hlFactor1.NavigateUrl = urlhlFactor1;
            hlFactor1.Attributes.Add("onclick", "javascript:ShowFirstFactorLanguagePopup(); return false;");

            enumJNPWorkflowStatus currentws = base.CurrentJNPWS;
            GridColumn Editcolumn = rgJADuty.MasterTableView.OwnerGrid.Columns.FindByUniqueName("EditCommandColumn");
            GridColumn Deletecolumn = rgJADuty.MasterTableView.OwnerGrid.Columns.FindByUniqueName("DeleteCommandColumn");
            GridColumn Viewcolumn = rgJADuty.MasterTableView.OwnerGrid.Columns.FindByUniqueName("ViewCommandColumn");


           //View
            if (CurrentNavMode == enumNavigationMode.View)
            {
                //no add
                rgJADuty.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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

                btnContinue.Text = "Continue";
                btnContinue.ToolTip = "Continue";

                rgJADuty.Rebind(); // To hide the Add New Duty link in View mode.
            }
        //Edit
            else 
            {
                //admin
                if ((base.IsAdmin) && (base.InProcessJNPWorkflowStatuses.Contains(currentws)))
                {
                        //allow add
                        rgJADuty.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                        //allow edit     
                        if (Editcolumn != null)
                        {
                            Editcolumn.Visible = true;
                            Editcolumn.Display = true;
                        }
                        // allow delete
                        if (Deletecolumn != null)
                        {
                            Deletecolumn.Visible = true;
                        }
                        //hide View
                        if (Viewcolumn != null)
                        {
                            Viewcolumn.Visible = false;
                            Viewcolumn.Display = false;
                        }
                 }
                else //non -admin --edit
                {
                    //Issue 1060 Editable for HR in FinalReview
                    if ((base.HasHRGroupPermission) && (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview) && (!CurrentJNP.IsJNPSignedByHR))
                    {
                        //allow add
                        rgJADuty.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                        //allow edit     
                        if (Editcolumn != null)
                        {
                            Editcolumn.Visible = true;
                            Editcolumn.Display = true;
                        }
                        // allow delete
                        if (Deletecolumn != null)
                        {
                            Deletecolumn.Visible = true;
                        }
                        //hide View
                        if (Viewcolumn != null)
                        {
                            Viewcolumn.Visible = false;
                            Viewcolumn.Display = false;
                        }
                    }
                    else
                    {
                        bool showedit = base.ShowEditFields(enumDocumentType.JA);
                        Editcolumn.Visible = showedit;
                        Deletecolumn.Visible = showedit;
                        Viewcolumn.Visible = !showedit;
                        //add
                        if (showedit)
                        {
                            rgJADuty.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                        }
                        else
                        {
                            rgJADuty.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                        }
                        // In Final Review: User should not be allowed to add new duty/edit/delete existing duty regardless of signatures

                        if (currentws == enumJNPWorkflowStatus.FinalReview)
                        {
                            rgJADuty.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                            Editcolumn.Visible = false;
                            Deletecolumn.Visible = false;
                            Viewcolumn.Visible = true;

                        }
                    }
                }

                rgJADuty.Rebind();
                
               
            }


            SetGridQualView();

            //Scroll to the top to dispaly the validation message.
            List<JobAnalysisDuty> currentJADuties = CurrentJobAnalysis.GetJobAnalysisDuty();
            int totalDutyPct = 0;
            foreach (JobAnalysisDuty duty in currentJADuties)
            {
                totalDutyPct += duty.JAPercentageOfTime;
            }

            if ((totalDutyPct != 100) || (!CheckIfEachMajorDutyHasOneDutyKSA()))
            {
                btnContinue.OnClientClick = "scrolltoTopDuty()";
            }

        }
        private void ShowDuty(object source, GridCommandEventArgs e)
        {
            RadWindowMangerDuties.Windows.Clear();
            GridDataItem gridItem;
            string navigateurl = string.Empty;
            string title = string.Empty;
            string script = string.Empty;
            long dutyID;

            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    long JAID = CurrentJAID;
                    base.CurrentJADutyID = -1;
                    base.GoToLink("~/JA/AddEditJADuty.aspx", enumNavigationMode.Insert);
                    break;
                case RadGrid.EditCommandName:
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    dutyID = long.Parse(gridItem.GetDataKeyValue(JADUTYID).ToString());
                    base.CurrentJADutyID = dutyID;
                    GoToLink("~/JA/AddEditJADuty.aspx", enumNavigationMode.Edit);

                    break;
                case "View":
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    dutyID = long.Parse(gridItem.GetDataKeyValue(JADUTYID).ToString());
                    base.CurrentJADutyID = dutyID;
                    //changed second argument of GoToLink from enumNavigationMode.View to CurrentNavMode
                    // because View option can be available when user in edit mode & if current document is finalized
                    //so if you pass enumNavigationMode.View -then it was setting currentNavMode to view 
                    // that was causing issue 95-moving from editable section of a package to a read-only section
                    //and then back to an editable section leaves the package in read-only mode

                    GoToLink("~/JA/AddEditJADuty.aspx", CurrentNavMode);
                    break;
                default:
                    break;
            }

        }
        private void DeleteDuty(object source, GridCommandEventArgs e)
        {
            try
            {
                if (source is RadGrid)
                {
                    GridDataItem gridItem = e.Item as GridDataItem;
                    long jadutyID = long.Parse(gridItem.GetDataKeyValue(JADUTYID).ToString());
                    JobAnalysisDuty duty = new JobAnalysisDuty(jadutyID);
                    duty.UpdatedByID = this.CurrentUserID;
                    duty.Delete();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        private void BindPDQuals()
        {
            //need to get information from fullpd
            //stand-alone job analysis will not have full pd information.
            //need to check if current job analysis is with in a JNP
            if (base.CurrentJNPID > 0)
            {

                PositionDescription currentpd = new PositionDescription(base.CurrentFullPDID);
                List<PositionCompetencyKSA> pdQuals = new List<PositionCompetencyKSA>();
                this.rgQual.DataSource = pdQuals = currentpd.GetPositionCompetencyKSA().Where(p => (p.QualificationTypeID == (int)enumQualificationType.ConditionOfEmployment)).ToList();
                
                pnlQual.Visible = (pdQuals.Count > 0);
            }
            else
            {
                pnlQual.Visible = false;
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
        protected bool CheckIfEachMajorDutyHasOneDutyKSA()
        {

            List<JobAnalysisDuty> jaDuties = CurrentJobAnalysis.GetJobAnalysisDuty();


            List<JobAnalysisDutyKSAFactor> jaDutyKSAFactorList = new List<JobAnalysisDutyKSAFactor>();

            foreach (JobAnalysisDuty jaDuty in jaDuties)
            {
                jaDutyKSAFactorList = jaDuty.GetJobAnalysisDutyKSAFactorByJADutyID();
                if (jaDutyKSAFactorList.Count <= 0)
                {
                    return false;
                }
            }

            return true;

        }
        private void SetEditForm(object sender, GridItemEventArgs e)
        {
            GridItem griditem = e.Item as GridItem;

            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {

                GridEditFormItem editform = (GridEditFormItem)e.Item;
                RadEditor _radEditorQualDescription = editform.FindControl(RADEDITQUALDESCR) as RadEditor;
                RadComboBox _radComboQualID = (RadComboBox)editform.FindControl(RADCOMBOQUALID);
                Button _btnUpdate = (Button)editform.FindControl("btnUpdate");
               
             
                if (griditem.DataItem is PositionCompetencyKSA )
                {
                    PositionCompetencyKSA  PDCompetencyKSA = griditem.DataItem as PositionCompetencyKSA ;

                    _radEditorQualDescription.Content = PDCompetencyKSA.CompetencyKSA;
                    _radComboQualID.SelectedValue = PDCompetencyKSA.QualificationID.ToString();
                

                }
                if (e.Item is GridEditFormInsertItem)
                {
                    //if (_tdsearch != null) _tdsearch.Visible = true;
                    ////BindKSACombo(_radComboKSA);
                    if (_btnUpdate != null)
                    {
                        _btnUpdate.CommandName = RadGrid.PerformInsertCommandName;
                        _btnUpdate.Text = "Add KSA";
                    }
                    rgJADuty.ShowFooter = false;

                    if (rgQual.Items.Count <= 0)
                    {
                        this.rgQual.MasterTableView.NoMasterRecordsText = "";
                        this.rgQual.MasterTableView.EnableNoRecordsTemplate = false;
                    }
                }
                else
                {
                    ////if (_tdsearch != null) _tdsearch.Visible = false;
                    //if (_trksadd != null) _trksadd.Visible = false;
                    if (_btnUpdate != null)
                    {
                        _btnUpdate.CommandName = RadGrid.UpdateCommandName;
                        _btnUpdate.Text = "Save KSA";
                    }
                    if (IsInView)
                    {
                        _radComboQualID.Enabled = false;
                        _radcomboQualificationTypeID.Enabled = false;
                        if (_btnUpdate != null)
                        {
                            _btnUpdate.Enabled = false;
                        }

                    }
                    rgJADuty.ShowFooter = true;
                }
            }

        }

        private void QualifiationsGrid_ShowHideColumn(string colUniqueName, bool isVisible)
        {
            rgQual.MasterTableView.OwnerGrid.Columns.FindByUniqueName(colUniqueName).Visible = isVisible;
        }

        private void QualifiationsGrid_ShowHideEditColumn(bool isVisible)
        {
            rgQual.MasterTableView.EditFormSettings.EditColumn.Visible = isVisible;
        }


        private void SetQualificationGridInView()
        {
            GridColumn Editcolumn = rgQual.MasterTableView.OwnerGrid.Columns.FindByUniqueName("EditCommandColumn");
            GridColumn Deletecolumn = rgQual.MasterTableView.OwnerGrid.Columns.FindByUniqueName("DeleteCommandColumn");
            //GridColumn Viewcolumn = rgQual.MasterTableView.OwnerGrid.Columns.FindByUniqueName("ViewCommandColumn");


            //no add
            rgQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
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
            //if (Viewcolumn != null)
            //{
            //    Viewcolumn.Visible = true;
            //    Viewcolumn.Display = true;
            //}
        }
        private void SetGridQualView()
        {

            //COE grid
            //Admin can add/delete/edit COE from Draft - Final Review
            //HR can add/delete/edit COE through Revise.
            //HR can only edit COE in Final Review --Can not add/delete
            //PDDeveloper/Supervisor can not make any changes to this in any status
            enumJNPWorkflowStatus currentws = base.CurrentJNPWS;
            GridColumn Editcolumn = rgQual.MasterTableView.OwnerGrid.Columns.FindByUniqueName("EditCommandColumn");
            GridColumn Deletecolumn = rgQual.MasterTableView.OwnerGrid.Columns.FindByUniqueName("DeleteCommandColumn");
          //  GridColumn Viewcolumn = rgQual.MasterTableView.OwnerGrid.Columns.FindByUniqueName("ViewCommandColumn");

            //View
            if (CurrentNavMode == enumNavigationMode.View)
            {
                SetQualificationGridInView();
            }
            //Edit
            else
            {
               //admin
                if ((base.IsAdmin) && (base.InProcessJNPWorkflowStatuses.Contains(currentws)))
                {
                    //allow add
                    rgQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                    //allow edit     
                    if (Editcolumn != null)
                    {
                        Editcolumn.Visible = true;
                        Editcolumn.Display = true;
                    }
                    // allow delete
                    if (Deletecolumn != null)
                    {
                        Deletecolumn.Visible = true;
                    }
                    //hide View
                    //if (Viewcolumn != null)
                    //{
                    //    Viewcolumn.Visible = false;
                    //    Viewcolumn.Display = false;
                    //}
                }
                else //non -admin --edit
                {
                    //HR can add/delete/edit COE through Revise.
                    if (base.HasHRGroupPermission)
                    {

                        if ((currentws == enumJNPWorkflowStatus.Draft)
                            || (currentws == enumJNPWorkflowStatus.Review)
                                || ((currentws == enumJNPWorkflowStatus.Revise) && (!CurrentJNP.IsJNPSignedBySupervisor)))
                        {
                            //allow add
                            rgQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                            //allow edit     
                            if (Editcolumn != null)
                            {
                                Editcolumn.Visible = true;
                                Editcolumn.Display = true;
                            }
                            // allow delete
                            if (Deletecolumn != null)
                            {
                                Deletecolumn.Visible = true;
                            }
                            //hide View
                            //if (Viewcolumn != null)
                            //{
                            //    Viewcolumn.Visible = false;
                            //    Viewcolumn.Display = false;
                            //}

                        }
                        else if ((currentws == enumJNPWorkflowStatus.FinalReview) && (!CurrentJNP.IsJNPSignedByHR))
                        {

                            //no add
                            rgQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                            // no delete
                            if (Deletecolumn != null)
                            {
                                Deletecolumn.Visible = false;
                            }
                            //allow only edit     
                            if (Editcolumn != null)
                            {
                                Editcolumn.Visible = true;
                                Editcolumn.Display = true;
                            }
                        }
                        else //Revise & signed/Final Review & signed
                        {
                            SetQualificationGridInView();
                        }
                    }
                    else //PD Developer/Supervisor
                    {
                        SetQualificationGridInView();
                    }
                } //end of non admin

            } //end of edit 

            //Making to disable add/edit Overall Qualification i.e. Condition of Employment.
            rgQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            Editcolumn.Visible = false;
            Deletecolumn.Visible = false;

            rgQual.Rebind();
        }

        #endregion


        #region rgJADuty
        protected void rgJADuty_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                case RadGrid.EditCommandName:
                case "View":
                    ShowDuty(sender, e);
                    break;
                case RadGrid.DeleteCommandName:
                    DeleteDuty(sender, e);
                    break;
                default:
                    break;
            }
        }
        protected void rgJADuty_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            BindDuty();

        }
        protected void rgJADuty_ItemDataBound(object sender, GridItemEventArgs e)
        {
            HideRefreshButton(e);
            GridItem gridItem = e.Item;

            //Issue Id: 28
            //Author: Deepali Anuje
            //Date Fixed: 1/29/2012
            //Description: Duty/KSA Screen of JA: Display Duty KSAs on This Screen 
            if (gridItem.ItemType == GridItemType.Item || gridItem.ItemType == GridItemType.AlternatingItem)
            {

                RadListBox rdutyqual = gridItem.FindControl("radListDutyQual") as RadListBox;
                if (gridItem.DataItem is JobAnalysisDuty)
                {
                    JobAnalysisDuty JADuty = gridItem.DataItem as JobAnalysisDuty;
                    List<JobAnalysisDutyKSAFactor> qualList = JADuty.GetJobAnalysisDutyKSAFactorByJADutyID();
                    rdutyqual.DataSource = qualList;
                    rdutyqual.DataBind();
                    rdutyqual.Visible = (qualList.Count > 0);
                }
            }
        }
        #endregion

        #region rgQual
        protected void rgQual_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            BindPDQuals();
        }
        protected void rgQual_ItemDataBound(object sender, GridItemEventArgs e)
        {
            HideRefreshButton(e);

            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {
                SetEditForm(sender, e);
            }


        }
     
        protected void rgQual_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.PerformInsertCommandName:                                       
                    AddPDCompetencyKSAFactor(sender, e);
                    break;
                case RadGrid.UpdateCommandName:
                    UpdatePDCompetencyKSAFactor(sender, e);
                    break;
                case RadGrid.DeleteCommandName:
                    DeletePDCompetencyKSAFactor(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void AddPDCompetencyKSAFactor(object source, GridCommandEventArgs e)
        {
            try
            {
                DateTime createDate = DateTime.Now;

                if (source is RadGrid)
                {
                    GridEditFormInsertItem gridItem = e.Item as GridEditFormInsertItem;
                    RadComboBox _radComboQualID = gridItem.FindControl(RADCOMBOQUALID) as RadComboBox;
                    RadEditor _radEditorQualDescription = gridItem.FindControl(RADEDITQUALDESCR) as RadEditor;
                    if (gridItem.ItemType == GridItemType.EditFormItem)
                    {

                        PositionCompetencyKSA positionCompetency = new PositionCompetencyKSA();
                        positionCompetency.CompetencyKSAID = -1;
                        positionCompetency.KSAID = 0; //Other KSA
                        positionCompetency.PositionDescriptionID = CurrentJNP.FullPDID;
                        positionCompetency.CompetencyKSA = _radEditorQualDescription.Content;
                        positionCompetency.Certification = String.Empty;
                        positionCompetency.QualificationTypeID = (int)enumQualificationType.ConditionOfEmployment;
                        positionCompetency.CreatedByID = CurrentUser.UserID;
                        positionCompetency.CreateDate = createDate;
                        positionCompetency.UpdatedByID = CurrentUser.UserID;
                        positionCompetency.UpdateDate = createDate;
                        positionCompetency.QualificationID = Convert.ToInt32(_radComboQualID.SelectedValue);
                        positionCompetency.AssociatedPDDutyID = null;

                        JQFactor jqFactor = new JQFactor();
                        jqFactor.JQFactorID = -1;
                        jqFactor.JQFactorTypeID = (int)enumJQFactorType.ConditionOfEmployment;
                        jqFactor.KSAID = 0; //Other KSA
                        jqFactor.IsSF = false;
                        jqFactor.JQID = CurrentJNP.JQID;

                        positionCompetency.AddPDCompetencyKSAFactor(positionCompetency, jqFactor);


                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void UpdatePDCompetencyKSAFactor(object source, GridCommandEventArgs e)
        {
            try
            {
                DateTime createDate = DateTime.Now;

                if (source is RadGrid)
                {
                    GridEditFormItem gridItem = e.Item as GridEditFormItem;
                    RadComboBox _radComboQualID = gridItem.FindControl(RADCOMBOQUALID) as RadComboBox;
                    RadEditor _radEditorQualDescription = gridItem.FindControl(RADEDITQUALDESCR) as RadEditor;
                    int competencyKSAID = int.Parse(gridItem.GetDataKeyValue("CompetencyKSAID").ToString());
                    if (competencyKSAID > -1)
                    {
                        PositionCompetencyKSA positionCompetency = new PositionCompetencyKSA(competencyKSAID);
                        positionCompetency.KSAID = 0; //Other KSA
                        positionCompetency.PositionDescriptionID = CurrentJNP.FullPDID;
                        positionCompetency.CompetencyKSA = _radEditorQualDescription.Content;
                        positionCompetency.Certification = String.Empty;
                        positionCompetency.QualificationTypeID = (int)enumQualificationType.ConditionOfEmployment;
                        positionCompetency.CreatedByID = CurrentUser.UserID;
                        positionCompetency.CreateDate = createDate;
                        positionCompetency.UpdatedByID = CurrentUser.UserID;
                        positionCompetency.UpdateDate = createDate;
                        positionCompetency.QualificationID = Convert.ToInt32(_radComboQualID.SelectedValue);
                        
                        //Don't want to overwrite the exsiting value with null
                        //positionCompetency.AssociatedPDDutyID = null;

                        JQFactor jqFactor = new JQFactor(Convert.ToInt32(CurrentJNP.JQID));
                        jqFactor.JQFactorTypeID = (int)enumJQFactorType.ConditionOfEmployment;
                        jqFactor.KSAID = 0; //Other KSA
                        jqFactor.IsSF = false;
                        jqFactor.JQID = CurrentJNP.JQID;

                        positionCompetency.UpdatePDCompetencyKSAFactor(positionCompetency, jqFactor);
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void DeletePDCompetencyKSAFactor(object source, GridCommandEventArgs e)
        {
            try
            {

                if (source is RadGrid)
                {
                    GridDataItem gridItem = e.Item as GridDataItem;
                    int competencyKSAID = int.Parse(gridItem.GetDataKeyValue("CompetencyKSAID").ToString());

                    PositionCompetencyKSA positionCompetency = new PositionCompetencyKSA(competencyKSAID);


                    positionCompetency.DeletePDCompetencyKSAFactor(positionCompetency.CompetencyKSAID, CurrentUser.UserID);
                }

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rgJADuty_PreRender(object sender, EventArgs e)
        {

            //HCMS.WebFramework.Site.ConfigClasses.ConfigMessagesSection cfms = HCMS.WebFramework.Site.ConfigClasses.ConfigMessagesSection.JAnPMessagesSection;
            //base.OnPreRender(e);
            //((GridButtonColumn)rgJADuty.MasterTableView.GetColumnSafe("DeleteCommandColumn")).ConfirmText = cfms.JAnPMessages[3].Text; 

        }

        protected void rgQual_PreRender(object sender, EventArgs e)
        {
            //SetGridQualView();
            GridItem[] gridcommanditems = rgQual.MasterTableView.GetItems(GridItemType.CommandItem);

            if ((rgQual.MasterTableView.IsItemInserted) || (rgQual.EditItems.Count > 0))
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
                //hiding btnCancel of the main page
                btnContinue.Visible = false;
            }

            else
            {
                //hiding refresh button
                foreach (GridItem item in gridcommanditems)
                {
                    item.FindControl("RebindGridButton").Visible = false;
                }

                rgQual.MasterTableView.ShowHeader = true;
                btnContinue.Visible = true;
            }
        }

        #endregion

        #region Events
        protected void customValTotalPercTime_ServerValidate(object source, ServerValidateEventArgs args)
        {
            List<JobAnalysisDuty> currentJADuties = CurrentJobAnalysis.GetJobAnalysisDuty();
            int totalDutyPct = 0;
            foreach (JobAnalysisDuty duty in currentJADuties)
            {
                totalDutyPct += duty.JAPercentageOfTime;
            }
            if (totalDutyPct != 100)
            {
                string valmsg = GetLocalResourceObject("DutyPercentageTotal").ToString();
                args.IsValid = false;
                customValTotalPercTime.ErrorMessage = valmsg;
            }
            else
            {
                args.IsValid = true;
                customValTotalPercTime.ErrorMessage = string.Empty;
            }

        }
        protected void customValEachMajorDutyHasAtLeastOneDutyKSA_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (!CheckIfEachMajorDutyHasOneDutyKSA())
            {
                args.IsValid = false;
                string valmsg = GetLocalResourceObject("MajorDutyValidation").ToString();
                this.customValEachMajorDutyHasAtLeastOneDutyKSA.ErrorMessage = valmsg;
            }
            else
            {
                args.IsValid = true;
                customValEachMajorDutyHasAtLeastOneDutyKSA.ErrorMessage = string.Empty;
            }

        }
        
        //Keshab - This event is no longer in use hence it needs to be removed
        protected void radcomboKSA_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            _radEditorQualDescription.Content = e.Text;
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                base.GoToLink("~/JA/FinalKSA.aspx", base.CurrentNavMode);
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (CurrentNavMode == enumNavigationMode.Insert)
            {
                CurrentNavMode = enumNavigationMode.Edit;
            }
            base.GoToLink("~/JA/JADuties.aspx", CurrentNavMode);
        }
        protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            if (e.Argument.ToString() == "ok")
            {

            }
            else
            {

            }
        }

        #endregion
    }
}
