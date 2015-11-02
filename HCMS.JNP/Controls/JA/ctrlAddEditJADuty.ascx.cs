using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using HCMS.Business.Lookups;
using HCMS.Business.JA;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;

using Telerik.Web.UI;
using HCMS.JNP.Controls.Search;
using System.Data;


namespace HCMS.JNP.Controls.JA 
{
    public partial class ctrlAddEditJADuty : JNPUserControlBase
    {
        #region Events/Delegates

        public delegate void NonExistentJADutyHandler();
        public event NonExistentJADutyHandler NonExistentJADutyEncountered;
        
        #endregion

        #region [Private Properties]

        private string CachedKSASelected
        {
            get
            {
                if (ViewState["CachedKSASelected"] == null)
                {
                    ViewState["CachedKSASelected"] = "";
                }
                return (string)ViewState["CachedKSASelected"];
            }
            set
            {
                ViewState["CachedKSASelected"] = value;
            }
        }

        private string CachedKSADescription
        {
            get
            {
                if (ViewState["CachedKSADescription"] == null)
                {
                    ViewState["CachedKSADescription"] = "";
                }
                return (string)ViewState["CachedKSADescription"];
            }
            set
            {
                ViewState["CachedKSADescription"] = value;
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

        private JobAnalysisDuty JADuty
        {
            get
            {
                if (ViewState["JADuty"] == null)
                {
                    JobAnalysisDuty jaduty = new JobAnalysisDuty(base.CurrentJADutyID);
                    ViewState["JADuty"] = jaduty;
                }
                return (JobAnalysisDuty)ViewState["JADuty"];
            }
            set
            {
                ViewState["JADuty"] = value;
            }

        }



        #endregion

        #region Page Related
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {                
                BindData();
                SetPageView();
            }
        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {
            if ((CurrentNavMode == enumNavigationMode.Edit) || (CurrentNavMode == enumNavigationMode.View))
            {
                if (rgDutyKSA.Items.Count > 0)
                {
                    GridEditFormItem editform = rgDutyKSA.MasterTableView.GetItems(GridItemType.EditFormItem)[0] as GridEditFormItem;

                    if ((editform != null) && (editform.IsInEditMode))
                    {
                        this.btnCancel.Visible = false;
                        
                    }
                    else
                    {
                        this.btnCancel.Visible = true;
                    }
                }
            }
            else
            {
                this.btnCancel.Visible = true;
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //setting the current navigation mode to edit so that ctrlDutyKSA will display the duties in edit mode
            //otherwise it was changing to view mode
            if (CurrentNavMode == enumNavigationMode.Insert)
            {
                CurrentNavMode = enumNavigationMode.Edit;
            }
            base.GoToLink("~/JA/JADuties.aspx", CurrentNavMode);

        }

        #endregion

        #region [Duty Related]

        private void BindData()
        {
            JobAnalysisDuty jaDuty = new JobAnalysisDuty(base.CurrentJADutyID);
            if (jaDuty.JADutyID == -1)
            {
                if (NonExistentJADutyEncountered != null)
                    NonExistentJADutyEncountered();
            }
            else
            {
                RadEditDutyDescription.Content = jaDuty.JADutyDescription.Replace("\n", "<br />");
                radcomboPercentageofTime.SelectedValue = jaDuty.JAPercentageOfTime.ToString();
                rgDutyKSA.Rebind();
                rgDutyQual.Rebind();
            }
        }

        protected void SetPageView()
        {
            bool isInViewMode = (base.CurrentNavMode == enumNavigationMode.View);


            GridColumn Viewcolumn = rgDutyKSA.MasterTableView.OwnerGrid.Columns.FindByUniqueName("ViewCommandColumn");

            //commenting this because instead of checking currentNaveMode, checking 
            //if current active document is JA to enable/disable controls
            //because a package can be in edit mode but current document is not 
            //an active document then edit controls should be disabled
            //
            //bool isInViewMode = (base.CurrentNavMode == enumNavigationMode.View);
            enumJNPWorkflowStatus currentws = base.CurrentJNPWS;
            //Author: Deepali Anuje
            //Issue: 294
            //Description: Create From Existing: Duty/KSA screen of JA not locked after JA Finalized

            //Issue: 423 Job Analysis is Editable in Approval Status (by HM / HR)  added check for currentws

            bool blnEnabled = (IsInEdit || IsInInsert)
                 && ((currentws == enumJNPWorkflowStatus.Draft || currentws == enumJNPWorkflowStatus.Review)
                || (currentws == enumJNPWorkflowStatus.Revise && !CurrentJNP.IsJNPSignedBySupervisor));

            //radcomboPercentageofTime.Enabled = blnEnabled;
            btnSave.Enabled = blnEnabled;

            rgDutyKSA.Columns[0].Display = blnEnabled; //edit column
            rgDutyKSA.Columns[1].Display = blnEnabled; //delete column
            rgDutyKSA.Columns[2].Display = !blnEnabled;//view column

            if (!blnEnabled)
            {
                rgDutyKSA.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None; //hiding add new commands
                rgDutyKSA.Rebind();
            }
            if (IsInInsert) //hiding duty qualification section when add new duty
            {
                this.dutyDetail.Visible = false;
            }
            else
            {
                this.dutyDetail.Visible = true;
            }

            if (base.IsAdmin)
            {
                if ((!isInViewMode) && (currentws != enumJNPWorkflowStatus.Published))
                {
                    rgDutyKSA.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                    rgDutyKSA.Rebind();
                    radcomboPercentageofTime.Enabled = true;
                    btnSave.Enabled = true;

                    rgDutyKSA.Columns[0].Display = true; //edit column
                    rgDutyKSA.Columns[1].Display = true; //delete column
                    rgDutyKSA.Columns[2].Display = true;//view column
                }
            }

            //Issue 1060 Editable for HR in FinalReview
            if ((base.HasHRGroupPermission) && (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview) && (!CurrentJNP.IsJNPSignedByHR))
            {
                rgDutyKSA.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                rgDutyKSA.Rebind();
                radcomboPercentageofTime.Enabled = true;
                btnSave.Enabled = true;

                rgDutyKSA.Columns[0].Display = true; //edit column
                rgDutyKSA.Columns[1].Display = true; //delete column
                rgDutyKSA.Columns[2].Display = true;//view column
            }


            if (isInViewMode)
            {
                rgDutyKSA.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                //radcomboPercentageofTime.Enabled = false;
                btnSave.Enabled = false;

                rgDutyKSA.Columns[0].Display = false; //edit column
                rgDutyKSA.Columns[1].Display = false; //delete column
                rgDutyKSA.Columns[2].Display = true;//view column

                // For Issue 991 - To make view column invisible
                Viewcolumn.Visible = false;
            }
            else
            {
                Viewcolumn.Visible = false;
            }
        }

        private void AssignValues(JobAnalysisDuty jaDuty)
        {
            string dutyDescr = RadEditDutyDescription.Text;
            int dutyperc = int.Parse(radcomboPercentageofTime.SelectedValue);
            jaDuty.JAID = base.CurrentJAID;
            jaDuty.JADutyDescription = dutyDescr;
            jaDuty.JAPercentageOfTime = dutyperc;
            jaDuty.UpdateDate = DateTime.Now;
            jaDuty.UpdatedByID = base.CurrentUserID;
            if (CurrentNavMode == enumNavigationMode.Insert)
            {
                jaDuty.CreateDate = DateTime.Now;
                jaDuty.CreatedByID = base.CurrentUserID;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            JobAnalysisDuty jaDuty;
            try
            {
                if (base.CurrentJAID > 0)
                {
                    if (CurrentNavMode == enumNavigationMode.Insert)
                    {
                        jaDuty = new JobAnalysisDuty();
                        AssignValues(jaDuty);
                        jaDuty.Add();
                        lblmsg.Text = "Duty added successfully.";
                        base.CurrentJADutyID = jaDuty.JADutyID;
                        this.JADuty = jaDuty;
                        base.CurrentNavMode = enumNavigationMode.Edit;
                        this.dutyDetail.Visible = true;
                        BindData();
                    }
                    else if (CurrentNavMode == enumNavigationMode.Edit)
                    {
                        jaDuty = new JobAnalysisDuty(base.CurrentJADutyID);
                        AssignValues(jaDuty);
                        jaDuty.Update();
                        lblmsg.Text = "Duty updated successfully.";
                    }
                }

                else
                {
                    base.PrintErrorMessage("Current Job Analysis is not set", false);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

        }

        #endregion

        #region [Duty Qualification Related]
        protected void rgDutyQual_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            pnlDutyQual.Visible = false;
            LinkDutyQual.Visible = false;

            if (base.CurrentJADutyID > 0)
            {
                List<JobAnalysisDutyQualification> qualList = JADuty.GetJobAnalysisDutyQualificationByJADutyID();
                this.rgDutyQual.DataSource = qualList;

                if (qualList.Count > 0)
                {
                    //pnlDutyQual.Visible = true;
                    //LinkDutyQual.Visible = true;
                }


            }
        }
        protected void rgDutyQual_ItemDataBound(object sender, GridItemEventArgs e)
        {
            HideRefreshButton(e);
        }
        private List<QualificationType> BindQualificationTypes()
        {
            List<QualificationType> qualificationType = LookupManager.GetAllQualificationTypes();
            return qualificationType = qualificationType.Where(p => (p.QualificationTypeID != (int)enumQualificationType.ConditionOfEmployment)).ToList();            
        }
        private List<Qualification> BindQualifications()
        {
            List<Qualification> qualificationList = LookupManager.GetAllQualifications();
            return qualificationList;
        }
        #endregion



        #region [Duty KSA Related]
        private void HideRefreshButton(GridItemEventArgs e)
        {
            GridItem gridItem = e.Item;
            //hide the refresh button Telerik.Web.UI.GridLinkButton
            if (gridItem is GridCommandItem)
            {
                gridItem.FindControl("RebindGridButton").Visible = false;

            }
        }
        #region [DutyKSA Edit Form Related]

        #region Private Properties
        private List<KSA> KSAList
        {
            get
            {
                List<KSA> ksalist = new List<KSA>();
                int seriesid = -1;
                int grade = -1;
                string cacheKey = string.Empty;
                if (base.CurrentJAID > 0)
                {
                    JobAnalysis currentJA = new JobAnalysis(base.CurrentJAID);
                    seriesid = currentJA.SeriesID;
                    grade = currentJA.HighestAdvertisedGrade;
                    cacheKey = string.Format("{0}-{1}", seriesid.ToString(), grade.ToString());
                    if (Cache[cacheKey] == null)
                    {
                        ksalist = Series.GetSeriesGradeKSA(seriesid, grade);
                        Cache.Insert(cacheKey, ksalist, null, DateTime.UtcNow.AddMinutes(5), System.Web.Caching.Cache.NoSlidingExpiration);
                    }
                    else
                    {
                        ksalist = (List<KSA>)Cache[cacheKey];
                    }

                }
                return ksalist;
            }
        }
        #endregion

        #region Private Methods

        private List<KSAEntity> convertKSAsToKSAEntities(List<KSA> ksaList)
        {
            var ksaEntityList = new List<KSAEntity>();

            foreach (var li in ksaList)
                ksaEntityList.Add(new KSAEntity() { KSAID = li.KSAID, KSAText = li.KSAText });

   

            return ksaEntityList;
        }

        private void setDefaultKSAOptionSelectedAndBindToControl(List<KSAEntity> ksaEntityList)
        {
        }

        private void setDefaultKSAOptionSelectedAndBindToControl(RadComboBox radcomboKSA, List<KSAEntity> ksaEntityList)
        {
            List<KSAEntity> orderedList = ksaEntityList.OrderBy(o => o.KSAText).ToList();
            KSAEntity otherksa = new KSAEntity() { KSAID = 0, KSAText = UserControlBase.OTHERKSATEXT };
            // JAX: issue 892:  Create New is not the first option in this drop-down
            //removing the the otherksa and reinserting so that it appears as first in the list
            orderedList.RemoveAll(m => m.KSAID == 0);
            orderedList.Insert(0, otherksa);
           ControlUtility.BindRadComboBoxControlWithBackground(radcomboKSA, orderedList, null, "KSAText", "KSAID", null, "0");
        }

        private void BindKSACombo(RadComboBox radcomboKSA)
        {
            setDefaultKSAOptionSelectedAndBindToControl(radcomboKSA, convertKSAsToKSAEntities(KSAList));

        }

        private void SetEditForm(object sender, GridItemEventArgs e)
        {
            GridItem griditem = e.Item as GridItem;
            GridEditFormItem editform = (GridEditFormItem)e.Item;
        
            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {
                
                RadComboBox radcomboKSA = (RadComboBox)editform.FindControl("radcomboKSA");
                RadEditor radEditorJAKSADescription = editform.FindControl("radEditorJAKSADescription") as RadEditor;
                //HtmlTableRow trsearch = editform.FindControl("trKSASearch") as HtmlTableRow;
                HtmlTableCell tdsearch = editform.FindControl("tdKSASearch") as HtmlTableCell;

                HtmlTableRow trksadd = editform.FindControl("trKSADD") as HtmlTableRow;
                HtmlTableRow trKSADutyOption = editform.FindControl("trKSADutyOption") as HtmlTableRow;
                ctrlSearchKSA searchKSA = editform.FindControl("SearchKSA") as ctrlSearchKSA;
                Button btnUpdate = editform.FindControl("btnUpdate") as Button;
                RadComboBox radComboDutyQualID = (RadComboBox)editform.FindControl("radComboDutyQualID");
                RadComboBox radcomboQualificationTypeID = (RadComboBox)editform.FindControl("radcomboQualificationTypeID");
                ControlUtility.BindRadComboBoxControl(radComboDutyQualID, BindQualifications(), null, "QualificationName", "QualificationID");
                ControlUtility.BindRadComboBoxControl(radcomboQualificationTypeID, BindQualificationTypes(), null, "QualificationTypeName", "QualificationTypeID");

                //Issue 1015 - Make "KSA" default instead of "KSA-Quality Ranking Factor"
                if (radcomboQualificationTypeID != null) radcomboQualificationTypeID.SelectedValue = "3";

                if (griditem.DataItem is JobAnalysisDutyKSAFactor)
                {
                    JobAnalysisDutyKSAFactor jaDutyKSAFactor = griditem.DataItem as JobAnalysisDutyKSAFactor;

                    radEditorJAKSADescription.Content = jaDutyKSAFactor.JQFactorTitle.Replace("\n", "<br />");
                    radComboDutyQualID.SelectedValue = jaDutyKSAFactor.QualificationID.ToString();
                    radcomboQualificationTypeID.SelectedValue = jaDutyKSAFactor.QualificationTypeID.ToString();
                }
                
                if (e.Item is GridEditFormInsertItem)
                {
                    tdsearch.Visible = true;
                    //trsearch.Visible = true;
                    trksadd.Visible = true;
                    searchKSA.SeriesID = base.CurrentJNP.SeriesID;
                    //searchKSA.ShowGradeSelection = false;
                    searchKSA.CurrentGrade = CurrentJNP.HighestAdvertisedGrade;
                    //searchKSA.BindData();
                    BindKSACombo(radcomboKSA);
                    btnUpdate.CommandName = RadGrid.PerformInsertCommandName;
                    btnUpdate.Text = "Add KSA";
                    rgDutyKSA.ShowFooter = false;
                    radcomboQualificationTypeID.Enabled = true;
                    trKSADutyOption.Visible = true;

                    HtmlTableRow rw = (HtmlTableRow)editform.FindControl("row1");
                    
                    if(rw != null)
                        rw.Visible = true;

                    //Hiring Managers should not be able to add SF to duties in Revise Status, but should be able to add KSAs and KSA -QRF. 
                    //System Admins and HR with Supervisory Access will still be able to add SF in Revise status. 
                  
                    if (CurrentJNPWS == enumJNPWorkflowStatus.Revise)
                    {
                        if (base.IsAdmin || base.HasHRGroupPermission)
                        {
                            //Don't remove SF in Revise status.
                        }
                        else
                        {
                            RadComboBoxItem itemSF = radcomboQualificationTypeID.FindItemByValue(Convert.ToInt32(enumQualificationType.SelectiveFactor).ToString());

                            if (itemSF != null)
                            {
                                radcomboQualificationTypeID.Items.Remove(itemSF);

                            }
                        }
                    }
                }
                else //edit duty ksa 
                {
                    tdsearch.Visible = false;
                    //trsearch.Visible = false;
                    trksadd.Visible = false;
                    trKSADutyOption.Visible = false;
                    // JA issue 920:Qualification type should not be allowed to be changed in edit mode.
                    radcomboQualificationTypeID.Enabled = false;
                    btnUpdate.CommandName = RadGrid.UpdateCommandName;
                    btnUpdate.Text = "Save KSA";

                    if (IsInView)
                    {
                        radComboDutyQualID.Enabled = false;
                        radcomboQualificationTypeID.Enabled = false;
                        btnUpdate.Enabled = false;

                    }
                    rgDutyKSA.ShowFooter = true;
                   
                }

                if (CurrentJNPWS != enumJNPWorkflowStatus.Published)
                {
                    if (base.IsAdmin)
                    {
                        //Qualification type should not be allowed to be changed in edit mode.
                        //radcomboQualificationTypeID.Enabled = true;

                        if (!IsInView) // For Issue 991 - To make uneditable in view mode
                            btnUpdate.Enabled = true;
                    }
                }

            }

        }

        private int GetJQFactorTypeIdFromQualificationTypeId(int qualificationTypeId)
        {
            int jqFactorTypeId = 0;

            if (qualificationTypeId > 0)
            {
                if (qualificationTypeId == (int)enumQualificationType.KSAQualityRankingFactor || qualificationTypeId == (int)enumQualificationType.KSA)
                {
                    jqFactorTypeId = (int)enumJQFactorType.KSA;
                }
                else if (qualificationTypeId == (int)enumQualificationType.SelectiveFactor)
                {
                    jqFactorTypeId = (int)enumJQFactorType.SelectiveFactor;
                }
                else if (qualificationTypeId == (int)enumQualificationType.ConditionOfEmployment)
                {
                    jqFactorTypeId = (int)enumJQFactorType.ConditionOfEmployment;
                }
            }

            return jqFactorTypeId;
        }

        private void AssignJADutyKSAFactorValues(JobAnalysisDutyKSAFactor jaDutyKSAFactor, GridCommandEventArgs e)
        {
            GridEditFormItem editform = (GridEditFormItem)e.Item;
            RadComboBox radcomboKSA = (RadComboBox)editform.FindControl("radcomboKSA");
            RadEditor radEditorJAKSADescription = editform.FindControl("radEditorJAKSADescription") as RadEditor;
            RadComboBox radComboDutyQualID = (RadComboBox)editform.FindControl("radComboDutyQualID");
            RadComboBox radcomboQualificationTypeID = (RadComboBox)editform.FindControl("radcomboQualificationTypeID");
            
            var jqFactorTypeId = GetJQFactorTypeIdFromQualificationTypeId(int.Parse(radcomboQualificationTypeID.SelectedValue));
            
            jaDutyKSAFactor.JADutyID = base.CurrentJADutyID;
            jaDutyKSAFactor.JQID = base.CurrentJQID;
            jaDutyKSAFactor.JQFactorTitle = radEditorJAKSADescription.Text;
            jaDutyKSAFactor.QualificationID = int.Parse(radComboDutyQualID.SelectedValue);
            jaDutyKSAFactor.QualificationTypeID = int.Parse(radcomboQualificationTypeID.SelectedValue);
            jaDutyKSAFactor.JQFactorTypeID = jqFactorTypeId;
            jaDutyKSAFactor.UpdatedByID = base.CurrentUserID;
            jaDutyKSAFactor.UpdateDate = DateTime.Now;
            
            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                jaDutyKSAFactor.KSAID = long.Parse(radcomboKSA.SelectedValue);
                jaDutyKSAFactor.IsFinalKSA = (jqFactorTypeId == (int)enumJQFactorType.SelectiveFactor);
                jaDutyKSAFactor.ImportanceID = enumImportanceScale.None;
                jaDutyKSAFactor.NeedAtEntryID = enumNeedAtEntryScale.None;
                jaDutyKSAFactor.DistinguishingValueScaleID = enumDistinguishingValueScale.None;
                jaDutyKSAFactor.CreatedByID = base.CurrentUserID;
                jaDutyKSAFactor.CreateDate = DateTime.Now;
            }
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                if (System.Configuration.ConfigurationManager.AppSettings["ShowQualFactorInstructionButton"].ToString().ToLower() == "false")
                    jaDutyKSAFactor.JQFactorInstruction = radEditorJAKSADescription.Text;
            }
        }

        #endregion

        #region [searchKSA Events]

        protected void trKSACombo_PreRender(object sender, EventArgs e)
        {
        }

        protected void dutyOption_Std_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            var trKSACombo = (HtmlTableRow)cb.Parent.FindControl("trKSACombo");
            trKSACombo.Visible = cb.Checked;
        }

        protected void dutyOption_Copy_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            var trKSACombo = (HtmlTableRow)cb.Parent.FindControl("trKSACombo");
            trKSACombo.Visible = !cb.Checked;
        }

        private void searchKSA_KSASearchCancelCompleted(object sender, EventArgs e)
        {
            GridEditFormItem editform = rgDutyKSA.MasterTableView.GetItems(GridItemType.EditFormItem)[0] as GridEditFormItem;
            RadComboBox radcomboKSA = editform.FindControl("radcomboKSA") as RadComboBox;
            BindKSACombo(radcomboKSA);
            Literal literalsearchmsg = editform.FindControl("literalSearchmsg") as Literal;
            if (literalsearchmsg != null) literalsearchmsg.Text = string.Empty;
        }

        private void searchKSA_KSASearchCompleted(object sender, EventArgs e)
        {
            GridEditFormItem editform = rgDutyKSA.MasterTableView.GetItems(GridItemType.EditFormItem)[0] as GridEditFormItem;
            ctrlSearchKSA searchKSA = editform.FindControl("SearchKSA") as ctrlSearchKSA;
            RadComboBox radcomboKSA = editform.FindControl("radcomboKSA") as RadComboBox;

            Literal literalsearchmsg = editform.FindControl("literalSearchmsg") as Literal;
            searchKSA.SetSearchResultMessage(ref literalsearchmsg);
            radcomboKSA.Items.Clear();
            setDefaultKSAOptionSelectedAndBindToControl(radcomboKSA, searchKSA.KSAList);
        }

        void searchKSA_KSASearchClearCompleted(object sender, EventArgs e)
        {
            GridEditFormItem editform = rgDutyKSA.MasterTableView.GetItems(GridItemType.EditFormItem)[0] as GridEditFormItem;
            Literal literalsearchmsg = editform.FindControl("literalSearchmsg") as Literal;
            if (literalsearchmsg != null) literalsearchmsg.Text = string.Empty;

            ctrlSearchKSA searchKSA = editform.FindControl("SearchKSA") as ctrlSearchKSA;
            RadComboBox radcomboKSA = (RadComboBox)editform.FindControl("radcomboKSA");
            radcomboKSA.Items.Clear();
            setDefaultKSAOptionSelectedAndBindToControl(radcomboKSA, searchKSA.KSAList);
        }

        #endregion

        #endregion

        protected void lblCopyDuty_PreRender(object sender, EventArgs e)
        {
            if (CurrentMode == eMode.View)
            {
                Label lblCopyDuty = (Label)sender;
                lblCopyDuty.Visible = false;
            }

        }

        protected void rgDutyKSA_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (base.CurrentJADutyID > 0)
            {
                List<JobAnalysisDutyKSAFactor> jadutyKSAFactorlist = JADuty.GetJobAnalysisDutyKSAFactorByJADutyID();
                this.rgDutyKSA.DataSource = jadutyKSAFactorlist;
            }

        }

        int jQFactorIDForTS = 0;

        protected void rgDutyKSA_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditFormItem)
            {
                if (e.Item.IsInEditMode) SetEditForm(sender, e);

            }

            if (e.Item is GridDataItem)
            {
                GridDataItem gridItem = (GridDataItem)e.Item;
                jQFactorIDForTS = int.Parse(gridItem.GetDataKeyValue("JQFactorID").ToString());

                DataTable dtAddedTS = TaskStatementEntityManager.GetAllAddedTaskStatementsForKSA(jQFactorIDForTS);

                int iRow = gridItem.ItemIndex;

                if (dtAddedTS.Rows.Count > 0)
                { 
                    ImageButton btnDel = ((TableCell)gridItem["DeleteCommandColumn"]).Controls[0] as ImageButton;                  
                    if (btnDel != null)
                    {
                        btnDel.Attributes.Add("onclick", "javascript:return " +
                        "confirm('Deleting this KSA will delete associated Task Statements on the Job Questionnaire. Are you sure you want to continue?')");
                    }
                }
            }

        }                                         

        protected void rgDutyKSA_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {

                case "View":
                    IsInView = true;
                    e.Item.Edit = true;
                    rgDutyKSA.Rebind();
                    break;
                case RadGrid.UpdateCommandName:

                    UpdateDutyKSA(sender, e);
                    break;
                case RadGrid.PerformInsertCommandName:

                    AddDutyKSA(sender, e);
                    break;
                case RadGrid.DeleteCommandName:
                    DeleteDutyKSA(sender, e);
                    break;

                default:
                    break;
            }
        }
        protected void rgDutyKSA_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            {
                GridEditFormItem editform = (GridEditFormItem)e.Item;
                ctrlSearchKSA searchKSA = editform.FindControl("SearchKSA") as ctrlSearchKSA;
                RadComboBox radcomboKSA = (RadComboBox)editform.FindControl("radcomboKSA");
                searchKSA.KSASearchCompleted += new ctrlSearchKSA.KSASearchCompletedHandler(searchKSA_KSASearchCompleted);
                searchKSA.KSASearchCancelCompleted += new ctrlSearchKSA.KSASearchCancelCompleteHandler(searchKSA_KSASearchCancelCompleted);
                searchKSA.KSASearchClearCompleted += new ctrlSearchKSA.KSASearchClearCompleteHandler(searchKSA_KSASearchClearCompleted);
                radcomboKSA.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(radcomboKSA_SelectedIndexChanged);
            }
        }


        protected void rgDutyKSA_PreRender(object sender, EventArgs e)
        {//making all other items invisible except edit form when adding new or editing
            GridItem[] gridcommanditems = rgDutyKSA.MasterTableView.GetItems(GridItemType.CommandItem);

            if ((rgDutyKSA.MasterTableView.IsItemInserted) || (rgDutyKSA.EditItems.Count > 0))
            {
                foreach (GridItem item in rgDutyKSA.Items)
                {
                    item.Visible = false;
                }

                //hiding all command items
                foreach (GridItem item in gridcommanditems)
                {
                    item.Visible = false;
                }
                //hiding headers
                rgDutyKSA.MasterTableView.ShowHeader = false;
                rgDutyKSA.MasterTableView.ShowFooter = false;
                rgDutyKSA.ShowFooter = false;
                this.btnCancel.Visible = false;
            }
            else
            {
                //hiding refresh button
                foreach (GridItem item in gridcommanditems)
                {
                    item.FindControl("RebindGridButton").Visible = false;
                }
                rgDutyKSA.MasterTableView.ShowHeader = true;
                rgDutyKSA.ShowFooter = true;
                this.btnCancel.Visible = true;
            }


            //showHideKSAComboTR(false);

        }

        protected void radEditorJAKSADescription_TextChanged(object sender, EventArgs e)
        {
            ////var editform = (GridEditFormItem)rgDutyKSA.MasterTableView.GetItems(GridItemType.EditFormItem)[0];
            ////var radcomboKSA = editform.FindControl("radcomboKSA") as RadComboBox;
            //if (CachedKSASelected == ControlUtility.KSA_COMBOBOX_DEFAULT)
            //{
            //    CachedKSADescription = ((RadEditor)sender).Text;
            //}
        }

        void radcomboKSA_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var editform = (GridEditFormItem)rgDutyKSA.MasterTableView.GetItems(GridItemType.EditFormItem)[0];
            var radcomboKSA = editform.FindControl("radcomboKSA") as RadComboBox;
            var radEditorJAKSADescription = editform.FindControl("radEditorJAKSADescription") as RadEditor;
            radEditorJAKSADescription.Content = e.Text;
            //radEditorJAKSADescription.Content =
            //    (radcomboKSA.SelectedItem.Text == ControlUtility.KSA_COMBOBOX_DEFAULT ? CachedKSADescription : e.Text);
            //CachedKSASelected = radcomboKSA.SelectedItem.Text;
        }

        protected void DeleteDutyKSA(object sender, GridCommandEventArgs e)
        {
            if (sender is RadGrid)
            {
                GridDataItem gridItem = e.Item as GridDataItem;

                int jQFactorID = int.Parse(gridItem.GetDataKeyValue("JQFactorID").ToString());
                JobAnalysisDutyKSAFactor dutyKSAFactor = new JobAnalysisDutyKSAFactor(jQFactorID);
                dutyKSAFactor.UpdatedByID = base.CurrentUserID;
                dutyKSAFactor.Delete();
                rgDutyKSA.Rebind();

            }
        }
        protected void UpdateDutyKSA(object sender, GridCommandEventArgs e)
        {
            GridEditFormItem editform = (GridEditFormItem)e.Item;
            long jQFactorID = (long)editform.GetDataKeyValue("JQFactorID");
            if (jQFactorID > 0)
            {
                JobAnalysisDutyKSAFactor jaDutyKSAFactor = new JobAnalysisDutyKSAFactor(jQFactorID);
                AssignJADutyKSAFactorValues(jaDutyKSAFactor, e);
                jaDutyKSAFactor.Update();
            }



        }
        protected void AddDutyKSA(object sender, GridCommandEventArgs e)
        {
            JobAnalysisDutyKSAFactor jaDutyKSAFactor = new JobAnalysisDutyKSAFactor();
            AssignJADutyKSAFactorValues(jaDutyKSAFactor, e);
            jaDutyKSAFactor.Add();

        }

        #endregion








        #region [Popup DutyKSA]
        //private void ShowDutyKSA(object source, GridCommandEventArgs e, eMode showmode)
        //{
        //    RadWindowMangerDutyKSA.Windows.Clear();
        //    GridDataItem gridItem;
        //    string script = string.Empty;
        //    string navigateurl = string.Empty;
        //    lblmsg.Text = string.Empty;
        //    e.Canceled = true;
        //    gridItem = e.Item as GridDataItem;
        //    long jadutyksaid = -1; 

        //    switch (showmode)
        //    {
        //        case eMode.Insert:                    
        //            script = string.Format("ShowKSAWindowClient('{0}','{1}');", "Insert", base.CurrentJADutyID );
        //            break;
        //        case eMode.Edit:
        //            jadutyksaid=long.Parse(gridItem.GetDataKeyValue("JADutyKSAID").ToString());
        //            script = string.Format("ShowKSAWindowClient('{0}','{1}');", "Edit", jadutyksaid);
        //            break;
        //        case eMode.View :
        //            jadutyksaid = long.Parse(gridItem.GetDataKeyValue("JADutyKSAID").ToString());
        //            script = string.Format("ShowKSAWindowClient('{0}','{1}');", "View", jadutyksaid);
        //            break;  
        //        default:
        //             break;                                

        //    }

        //    RadWindowMangerDutyKSA.Windows.Add(rwJADutyKSA);
        //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowKSAWindowClient", script, true);
        //}
        #endregion

    }
}