using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Telerik.Web.UI;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.JQ;
using HCMS.Lookups;
using HCMS.Business.Lookups;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.BasePages;
using HCMS.Business.Admin;
using HCMS.JNP.Controls.Search;
using System.Data;
using System.Configuration;

namespace HCMS.JNP.Controls.JQ
{
    public partial class ctrlAddEditKSA : JNPUserControlBase
    {
        List<RatingScaleResponseEntity> lt = null;
        RadTextBox txtQuestionLibrary;

        JQManager jqm = new JQManager();
        private bool isDisplayCRUDColumns = true;

        #region Events/Delegates

        public delegate void NonExistentJQFactorHandler();
        public event NonExistentJQFactorHandler NonExistentJQFactorEncountered;

        #endregion

        #region [Private Properties]

      

        private long CurrentRatingScaleID
        {
            get
            {
                long ratingscaleid = -1;
                if (ViewState["CurrentRatingScaleID"] != null)
                {
                    ratingscaleid = (long)ViewState["CurrentRatingScaleID"];
                }
                return ratingscaleid;
            }
            set { ViewState["CurrentRatingScaleID"] = value; }
        }

        //public List<TSEntity> UncheckedTaskList
        //{
        //    get
        //    {
        //        List<TSEntity> dt = new List<TSEntity>();// originalRatingscaletype = "";
        //        if (ViewState["UncheckedTaskList"] != null)
        //        {
        //            dt = (List<TSEntity>)ViewState["UncheckedTaskList"];
        //        }
        //        return dt;
        //    }
        //    set { ViewState["UncheckedTaskList"] = value; }
        //}
        private int CurrentRatingScaleTypeID
        {
            get
            {
                int ratingscaletypeid = -1;
                if (ViewState["CurrentRatingScaleTypeID"] != null)
                { ratingscaletypeid = (int)ViewState["CurrentRatingScaleTypeID"]; }
                return ratingscaletypeid;
            }
            set { ViewState["CurrentRatingScaleTypeID"] = value; }
        }

        private long JQFactorID
        {
            get
            {
                if (ViewState["JQFactorID"] == null)
                {
                    ViewState["JQFactorID"] = base.CurrentJQFactorID;
                }

                return (long)ViewState["JQFactorID"];


            }
            set
            {
                ViewState["JQFactorID"] = value;
            }
        }

        private long JQFactorItemID
        {
            get
            {
                long jqfactoritemid = -1;
                if (ViewState["JQFactorItemID"] != null)
                { jqfactoritemid = (long)(ViewState["JQFactorItemID"]); }
                return jqfactoritemid;
            }
            set { ViewState["JQFactorItemID"] = value; }
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

        private long TaskStatementID
        {
            get
            {
                return (long)ViewState["TaskStatementID"];
            }
            set
            {
                ViewState["TaskStatementID"] = value;
            }
        }

        #endregion]

        #region Page Events

        protected override void OnInit(EventArgs e)
        {

            ctrlSearchKSA searchKSA = this.FindControl("SearchKSA") as ctrlSearchKSA;
            searchKSA.KSASearchUnckecked += new ctrlSearchKSA.KSASearchUnckeckedHandler(searchKSA_KSASearchUnckecked);
            base.OnInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        string postbackControlName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            postbackControlName = Page.Request.Params.Get("__EVENTTARGET");


            if (!Page.IsPostBack)
            {
                LoadPage();
            }
            // Give the search control a reference to the KSA combo box and Search Message label control
            SearchKSA.KSAComboBox = rcbFinalKSA;
            SearchKSA.SearchMessageLabel = literalSearchmsg;

        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {

            if ((CurrentNavMode == enumNavigationMode.Edit) || (CurrentNavMode == enumNavigationMode.View))
            {
                if (gridQuestions.Items.Count > 0)
                {

                    GridEditFormItem editform = gridQuestions.MasterTableView.GetItems(GridItemType.EditFormItem)[0] as GridEditFormItem;

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



        #endregion

        #region [KSA Related]

        private void LoadPage()
        {
            //Keshab - These two function calls below are no longer required for current business design. 
            //Hence these functions should be removed.
            InitFinalKSA();
            setSearchControl();
            
            //Keshab - The "if statement" below is no longer required because it is always in edit mode for KSA
            //Hence the controls trKSASelection, trKSASearch should be removed.
            if (CurrentNavMode == enumNavigationMode.Insert)
            {
                JQFactorID = -1;
                this.ksaDetail.Visible = false;
                this.trKSASelection.Visible = true;
                this.trKSASearch.Visible = true;
            }
            else if ((CurrentNavMode == enumNavigationMode.Edit) || (CurrentNavMode == enumNavigationMode.View))
            {
                this.trKSASelection.Visible = false;
                this.trKSASearch.Visible = false;
                this.ksaDetail.Visible = true;
                BindData();
            }

            SetPageView();

        }

        
        //Keshab - This function is no longer valid for current business design hence needs to be removed.
        private void InitFinalKSA()
        {
            rcbFinalKSA.Items.Clear();
            List<KSAEntity> items = GetSeriesGradeKSAListExceptJQ(true);
            items.RemoveAll(rm => rm.KSAText == UserControlBase.OTHERKSATEXT);
            var orderedList = items.OrderBy(o => o.KSAText).ToList();
            orderedList.Insert(0, new KSAEntity() { KSAID = 0, KSAText = "Other" });

            ControlUtility.BindRadComboBoxControlWithBackground(rcbFinalKSA, orderedList, null, "KSAText", "KSAID", "<<-- Select KSA -->>");
            
        }

        //Keshab - This function is no longer valid for current business design hence needs to be removed.
        private void setSearchControl()
        {
            //for search control
            GetCurrentJQKSAList(true);
            this.SearchKSA.SeriesID = CurrentJNP.SeriesID;
            this.SearchKSA.CurrentGrade = CurrentJNP.HighestAdvertisedGrade;
        }

        //Keshab - This function is no longer valid for current business design hence needs to be removed.
        private List<KSAEntity> GetCurrentJQKSAList(bool reload)
        {
            if ((ViewState["CurrentJQKSAList"] == null) || (reload))
            {

                ViewState["CurrentJQKSAList"] = KSAEntityManager.GetKSAEntityListForADocument(enumDocumentType.JQ, CurrentJQID);
            }

            return (List<KSAEntity>)ViewState["CurrentJQKSAList"];
        }
        
        private void BindData()
        {
            if (JQFactorID == -1)
            {
                if (NonExistentJQFactorEncountered != null)
                    NonExistentJQFactorEncountered();
            }
            else
            {
                JQFactorEntity entity = jqm.GetJQFactorByJQFactorID(JQFactorID);
                this.lblTitle.Text = entity.Title;
                JQFactorID = entity.ID;
                this.CurrentJQFactorID = entity.ID;
                this.CurrentKSAID = entity.KSAID;

                //Issue 974 - Qualification Instruction has a break. 
                //To resolve the issue of hyphen causing the line break in Instrucition control.
                //For this issue the line below is commented.
                //string instruction = entity.Instruction.Replace(" ", "&nbsp;");
                string instruction = entity.Instruction.Replace("\n", "<br />");

                RadEditKSAInstruction.Content = instruction;
                gridQuestions.Rebind();

            }
        }

        private void SetPageView()
        {//JAX 1056 : JQ Qualification and KSA: Hide the factor instruction (completely) for all users in JAX (KSA and qual screen) 
            bool blnshowbtnInst = false;
            bool.TryParse(ConfigurationManager.AppSettings["ShowKSAFactorInstructionButton"].ToString(), out blnshowbtnInst);
            
            //btnShowKSAInst.Visible = blnshowbtnInst;
            //ToolTipKSAInstructions.Visible = blnshowbtnInst;
                            //Hiding KSA Instruction by default 
            HtmlTableRow trInst = FindControl("ksaInst") as HtmlTableRow;
            HtmlTableRow trInstText = FindControl("ksaInstText") as HtmlTableRow;

            enumJNPWorkflowStatus currentws = base.CurrentJNPWS;
            
            GridColumn Editcolumn = gridQuestions.MasterTableView.Columns.FindByUniqueName("EditCommandColumn");
            GridColumn Deletecolumn = gridQuestions.MasterTableView.OwnerGrid.Columns.FindByUniqueName("DeleteCommandColumn");
            GridColumn Viewcolumn = gridQuestions.MasterTableView.OwnerGrid.Columns.FindByUniqueName("ViewCommandColumn");

            if (CurrentNavMode == enumNavigationMode.View)
            {
                gridQuestions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                Editcolumn.Visible = false;
                Deletecolumn.Visible = false;
                btnSave.Enabled = false;
            }
            else
            {
                Viewcolumn.Visible = false;

                if (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview)
                {
                    if (base.IsAdmin)
                    {

                    }
                    else
                    {
                        //Issue 1060 Editable for HR in FinalReview
                        if (base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR)
                        {

                        }
                        else
                        {
                            gridQuestions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                            Deletecolumn.Visible = false;
                            Editcolumn.Visible = false;
                            btnSave.Enabled = false;
                        }

                        if (base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR)
                        {
                            rcbFinalKSA.Enabled = true;
                            RadEditKSAInstruction.Enabled = true;
                            btnSave.Enabled = true;
                            Viewcolumn.Display = false;
                            Editcolumn.Visible = true;
                        }
                        else
                        {
                            rcbFinalKSA.Enabled = false;
                            RadEditKSAInstruction.Enabled = false;
                            btnSave.Enabled = false;
                            Viewcolumn.Display = true;
                            Viewcolumn.Visible = true;
                        }
                    }
                }
                else if (CurrentJNPWS == enumJNPWorkflowStatus.Review)
                {
                    if (!base.IsAdmin)
                    {
                        if (base.HasHRGroupPermission)
                        {
                            gridQuestions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                            Deletecolumn.Visible = true;
                            Editcolumn.Visible = true;
                            btnSave.Enabled = true;

                        }
                    }
                }
                else if (CurrentJNPWS == enumJNPWorkflowStatus.Revise)
                {
                    if (!base.IsAdmin)
                    {
                        if (!base.HasHRGroupPermission)
                        {
                            if (CurrentJNP.IsJNPSignedBySupervisor)
                            {
                                btnSave.Enabled = false;
                                RadEditKSAInstruction.Enabled = false;

                                gridQuestions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                                Deletecolumn.Visible = false;
                                Editcolumn.Visible = false;
                                btnSave.Enabled = false;
                                Viewcolumn.Visible = true;
                            }
                            else
                            {
                                btnSave.Enabled = false;
                            }
                        }
                    }
                }
                else if (CurrentJNPWS == enumJNPWorkflowStatus.Draft)
                {
                    if (!base.IsAdmin)
                    {
                        if (!base.HasHRGroupPermission )
                        {
                            btnSave.Enabled = false;
                        }
                    }
                }

                if (trInst != null)
                {
                    trInst.Visible = false;
                }

                if (trInstText != null)
                {
                    trInstText.Visible = false;
                }

            }

            HtmlTableCell tdRadSpell = gridQuestions.FindControl("tdRadSpell") as HtmlTableCell;
            //RadSpell rs = griditem.FindControl("RadSpellTaskStatements") as RadSpell;

            if (!IsInView)
            {
                if (tdRadSpell != null) tdRadSpell.Visible = true;
            }
            else
            {
                if (tdRadSpell != null)
                {
                    tdRadSpell.Visible = false;
                    // rs.Visible = false;
                }
            }

            //Issue 1056 - Implementing ShowKSAFactorInstructionButton
            if (System.Configuration.ConfigurationManager.AppSettings["ShowKSAFactorInstructionButton"] != null)
            {
                bool bShow = System.Configuration.ConfigurationManager.AppSettings["ShowKSAFactorInstructionButton"].ToString().ToLower() == "false" ? false : true;
                trInst.Visible = bShow;
                trInstText.Visible = bShow;
                trbtnShowKSAInst.Visible = bShow;
                btnSave.Visible = bShow;

                if (bShow)
                {
                    btnShowKSAInst.Text = "Hide Instruction";
                }

                if (btnShowKSAInst.Text == "Show Instruction") btnSave.Visible = false;
            }


            gridQuestions.Rebind();
            
        }
        
        //Keshab - This function is no longer valid for current business design hence needs to be removed.
        private List<KSAEntity> GetSeriesGradeKSAListExceptJQ(bool reload)
        {

            int seriesid = base.CurrentJNP.SeriesID;
            int highestadvgrade = base.CurrentJNP.HighestAdvertisedGrade;
            List<KSAEntity> items = new List<KSAEntity>();
            if ((ViewState["SGJQKSAList"] == null) || (reload))
            {
                items = jqm.GetSeriesGradeKSAExceptJQ(seriesid, highestadvgrade, this.CurrentJQID);
                ViewState["SGJQKSAList"] = items;
            }
            else
            {
                items = (List<KSAEntity>)ViewState["SGJQKSAList"];
            }
            return items;
        }

        //Keshab - this function is no longer in use, hence needs to be removed. 
        private bool filterExistingKSA(RadComboBoxItem listItem)
        {
            List<KSAEntity> items = GetCurrentJQKSAList(false);
            KSAEntity current = new KSAEntity();
            current.KSAID = long.Parse(listItem.Value);

            if (items.Contains(current))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        private void AssignValues(JQFactorEntity entity)
        {
            string ksaTitle = lblTitle.Text;

            string ksaIntruction = "";// RadEditKSAInstruction.Text;
            //using the hidden field because RadEditQualificationInstruction.Text was not showing the updated text on posting back
            //so when the text was modified,  updated text was not stored in text property
            //hidden field was updated on btnSave - client click event 
            // testing the value of hidden field also because if you don't "Show Instruction", the hidden field was "" and thereby causing null exception when
            //saving.

            if (!string.IsNullOrEmpty(hdksains.Value))
            {
                ksaIntruction = hdksains.Value;
            }

            else
            {
                ksaIntruction = RadEditKSAInstruction.Text;
            }

            entity.ID = JQFactorID;
            entity.JQID = base.CurrentJQID;
            entity.Title = ksaTitle;
            entity.Instruction = ksaIntruction;
            entity.FactorTypeID = (int)enumJQFactorType.KSA;

            if (CurrentNavMode == enumNavigationMode.Insert)
            {
                entity.KSAID = long.Parse(rcbFinalKSA.SelectedValue);
                entity.CreatedByID = base.CurrentUserID;
            }
            else
            {
                entity.UpdatedByID = base.CurrentUserID;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Page.Validate();
            if (Page.IsValid)
            {
                JQFactorEntity entity = new JQFactorEntity();
                AssignValues(entity);

                try
                {
                    if (base.CurrentJQID > 0)
                    {
                        if (CurrentNavMode == enumNavigationMode.Insert)
                        {
                            base.CurrentJQFactorID = JQFactorID = jqm.AddJobQuestionnaireFactor(entity);
                            lblmsg.Text = "KSA added successfully.";
                            //reload current jq KSAlist
                            CurrentNavMode = enumNavigationMode.Edit;
                            LoadPage();

                        }
                        else if (CurrentNavMode == enumNavigationMode.Edit)
                        {
                            jqm.UpdateJobQuestionnaireFactor(entity);
                            lblmsg.Text = "KSA updated successfully.";

                            //Issue 974 - Qualification Instruction has a break. 
                            //To resolve the issue of hyphen causing the line break in Instrucition control.
                            //For this issue the line below is commented.
                            //string instruction = entity.Instruction.Replace(" ", "&nbsp;");
                            string instruction = entity.Instruction.Replace("\n", "<br />");

                            RadEditKSAInstruction.Content = instruction;
                           
                        }
                    }

                    else
                    {
                        base.PrintErrorMessage("Current Job Questionnaire is not set", false);
                    }
                }
                catch (Exception ex)
                {
                    base.HandleException(ex);
                }
            }
        }

        #endregion
         

        #region [Task Statments]


        private void InitTaskStatements(RadListBox lsTaskStatements)
        {

            List<TSEntity> TSList = jqm.GetTaskStatementsByKSAIDAndJQID(this.CurrentKSAID, this.CurrentJQID);
            //List<TSEntity> TSList = jqm.GetTaskStatementsByJAXID(this.CurrentJNPID);

            lsTaskStatements.Items.Clear();
            if (TSList.Any(a => a.TaskStatement == UserControlBase.JUSTOTHER))
            {
                TSList.RemoveAll(rm => rm.TaskStatement == UserControlBase.JUSTOTHER);
            }

            var orderedList = TSList.OrderBy(o => o.TaskStatement).ToList();
            Session["InitialTaskList"] = orderedList;

            //Removed Create New in Listbox
            //orderedList.Insert(0, new TSEntity() { TaskStatementID = 0, TaskStatement = UserControlBase.OTHERTASKSTATEMENTTEXT });

            //Session["InitialTaskList"] = TSList;
            //UncheckedTaskList = TSList;

            TaskStatementEntityManager.RemoveExistingFromListForJAX(orderedList, Convert.ToInt32(this.CurrentJNPID));

            ControlUtility.BindRadListBoxControlWithBackground(lsTaskStatements, orderedList,  "TaskStatement", "TaskStatementID", "<<-- Select Task Statement -->>", "-1");

        }

        private void SetEditForm(object sender, GridItemEventArgs e)
        {
           
            GridItem griditem = e.Item as GridItem;

            //bool isInViewMode = (base.CurrentNavMode == enumNavigationMode.View);

            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {

                //TS related
                HtmlTableRow trtsLabel = griditem.FindControl("tsLabel") as HtmlTableRow;
                HtmlTableRow trtsText = griditem.FindControl("tsText") as HtmlTableRow;
                HtmlTableRow trtsRow = griditem.FindControl("lbTaskStatement") as HtmlTableRow;
                HtmlTableCell trSearch = griditem.FindControl("rSearch") as HtmlTableCell;
                RadButton rdCreate = griditem.FindControl("radCreate") as RadButton;
                RadButton rdSelect = griditem.FindControl("radSelect") as RadButton;

                GridEditFormItem editform = (GridEditFormItem)e.Item;
                RadTextBox txtQuestion = editform.FindControl("txtQuestion") as RadTextBox;

                txtQuestionLibrary = editform.FindControl("txtQuestion") as RadTextBox;

                RadComboBox rcbRatingScaleType = editform.FindControl("rcbRatingScaleType") as RadComboBox;
                RadTextBox txtInstruction = editform.FindControl("txtInstruction") as RadTextBox;
                Button btnAddToLibrary = editform.FindControl("btnAddToLibrary") as Button;

                HtmlTableRow trTaskStatementSelection1 = editform.FindControl("trTaskStatementSelection1") as HtmlTableRow;
                //HtmlTableRow trTaskStatementSelection2 = editform.FindControl("trTaskStatementSelection2") as HtmlTableRow;

                HtmlTableRow trSearchTS = editform.FindControl("trSearchTS") as HtmlTableRow;
                ctrlSearchTaskStatement searchTS = editform.FindControl("TSSearch") as ctrlSearchTaskStatement;
                //RequiredFieldValidator RequiredFieldValidatorTaskStatments = editform.FindControl("RequiredFieldValidatorTaskStatments") as RequiredFieldValidator;
                Button btnSaveTS = editform.FindControl("btnSaveTS") as Button;
                //RadComboBox rcbTaskStatements = editform.FindControl("rcbTaskStatements") as RadComboBox;
                Label lblSearchMssg = editform.FindControl("literalSearchTSmsg") as Label;
                RadGrid gridResponses = editform.FindControl("gridResponses") as RadGrid;
                string script = string.Empty;
                //CurrentEditIndex = editform.ItemIndex;

                //Listbox for Task Statement
                RadListBox lsTaskStatements = editform.FindControl("rlbTSList") as RadListBox;

                HtmlTableRow trInst = editform.FindControl("inst") as HtmlTableRow;
                HtmlTableRow trInstText = editform.FindControl("instText") as HtmlTableRow;
                
                CustomValidator CustomValidatorTS = editform.FindControl("CustomValidator1") as CustomValidator;

                //Only HR and Admin can change the Rating Scale Type
                if ((base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR) || base.IsSystemAdministrator)
                {
                    gridResponses.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = true;
                }
                else
                {
                    rcbRatingScaleType.Enabled = false; ;
                    gridResponses.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
                }

                
                //insert mode
                if (e.Item is GridEditFormInsertItem)
                {
                    gridResponses.Visible = true;

                    // Set search TS control
                    searchTS.CurrentGrade = CurrentJNP.HighestAdvertisedGrade;
                    searchTS.SeriesID = CurrentJNP.SeriesID;
                    searchTS.KSAID = this.CurrentKSAID;

                    //searchTS.TaskComboBox = rcbTaskStatements;
                    //searchTS.SearchMessageLabel = lblSearchMssg;

                    //TS list box
                    searchTS.TaskListBox = lsTaskStatements;
                    InitTaskStatements(lsTaskStatements);

                    //populate rcbTaskStatements
                    //InitTaskStatements(rcbTaskStatements);
                    rcbRatingScaleType.SelectedValue = ((int)enumRatingScaleType.DefaultMultiChoice).ToString();
                    string ratingscaleinstruction = jqm.GetDefaultJQRatingScaleInstructionByRatingScaleType((int)enumRatingScaleType.DefaultMultiChoice);
                    txtInstruction.Text = ratingscaleinstruction;
                    
                    //RequiredFieldValidatorTaskStatments.Enabled = true;
                    if(CustomValidatorTS!=null) CustomValidatorTS.Enabled = true;

                    btnSaveTS.CommandName = RadGrid.PerformInsertCommandName;
                    btnSaveTS.Text = "Save Task Statement";

                    trInst.Visible = false;
                    trInstText.Visible = false;

                    //Issue 932 - lt variable below need to be global variable in order to maintain the response list.
                    //We don't want to get fresh set of responses based on response type.
                    //List<RatingScaleResponseEntity> lt = GetResponses(Convert.ToInt32(rcbRatingScaleType.SelectedValue));
                    lt = GetResponses(Convert.ToInt32(rcbRatingScaleType.SelectedValue));

                    gridResponses.DataSource = lt;
                    gridResponses.DataBind();

                    if (gridResponses != null)
                        gridResponses.Visible = true;

                    gridResponses.Columns[0].Visible = false;
                    gridResponses.Columns[1].Visible = false;

                    //In add mode make "AddNewRecord" invisible
                    gridResponses.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
                    gridResponses.MasterTableView.ShowFooter = false;

                    if (gridQuestions.Items.Count <= 0)
                    {
                        this.gridQuestions.MasterTableView.NoMasterRecordsText = "";
                    }

                    CurrentMode = eMode.Insert;

                    if (trtsText != null)
                    {
                        trtsText.Visible = false;
                        trtsRow.Visible = true;
                    }

                    HtmlTableCell tdRadSpell = griditem.FindControl("tdRadSpell") as HtmlTableCell;
                    //RadSpell rs = griditem.FindControl("RadSpellTaskStatements") as RadSpell;

                    if (!IsInView)
                    {
                        if (tdRadSpell != null) tdRadSpell.Visible = true;
                    }
                    else
                    {
                        if (tdRadSpell != null)
                        {
                            tdRadSpell.Visible = false;
                            // rs.Visible = false;
                        }
                    }
                }

                //edit/view mode
                if (griditem.DataItem is JQFactorItemEntity)
                {

                    trtsLabel.Visible = true;
                    HtmlTableRow trRadio = griditem.FindControl("trRadio") as HtmlTableRow;
                    trRadio.Visible = false;


                    CurrentMode = eMode.Edit;

                    JQFactorItemEntity entity = griditem.DataItem as JQFactorItemEntity;
                    txtQuestion.Text = entity.ItemText;
                    rcbRatingScaleType.SelectedValue = entity.RatingScaleTypeID.ToString();
                    JQFactorID = entity.FactorID;
                    this.CurrentJQFactorID = entity.FactorID;
                    this.CurrentRatingScaleID = entity.RatingScaleID;
                    this.CurrentRatingScaleTypeID = entity.RatingScaleTypeID;
                    txtInstruction.Text = entity.RatingScaleInstruction;

                    //Issue 932 - lt variable below need to be global variable in order to maintain the response list.
                    //We don't want to get fresh set of responses based on response type.
                    //List<RatingScaleResponseEntity> lt = GetResponses(Convert.ToInt32(CurrentRatingScaleID));
                    lt = GetResponses(Convert.ToInt32(CurrentRatingScaleID));

                    gridResponses.DataSource = lt;
                    gridResponses.DataBind();
                    if (gridResponses != null)
                        gridResponses.Visible = true;

                    if (CurrentRatingScaleID == 1 || CurrentRatingScaleID == 2)
                    {
                        gridResponses.Columns[0].Visible = false;
                        gridResponses.Columns[1].Visible = false;
                    }

                    if (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview)
                    {
                        if (base.IsAdmin)
                        {
                            txtInstruction.ReadOnly = false;
                        }
                        else if(base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR)
                        {
                            txtInstruction.ReadOnly = false;
                        }
                    }

                    rcbRatingScaleType.SelectedValue = entity.RatingScaleTypeID.ToString();

                    trTaskStatementSelection1.Visible = false;

                    if (CustomValidatorTS != null) CustomValidatorTS.Enabled = false;

                    btnSaveTS.CommandName = RadGrid.UpdateCommandName;
                    btnSaveTS.Text = "Save Task Statement";

                    trInst.Visible = false;
                    trInstText.Visible = false;

                    if ((base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR) || base.IsSystemAdministrator)
                    {
                        rcbRatingScaleType.Enabled = true;
                        if ((entity.TaskStatementID == 0) && (!IsInView))
                        {
                            btnAddToLibrary.Visible = true;

                        }
                        else
                        {
                            btnAddToLibrary.Visible = false;
                        }
                    }
                    else
                    {
                        rcbRatingScaleType.Enabled = false;
                        btnAddToLibrary.Visible = false;
                    }

                    if (IsInView)
                    {
                        btnSaveTS.Enabled = false;
                        rcbRatingScaleType.Enabled = false;
                        txtQuestion.ReadOnly = true;
                        txtInstruction.ReadOnly = true;
                    }

                    int ratingScaleTypeID = Convert.ToInt32(rcbRatingScaleType.SelectedValue);

                    if (ratingScaleTypeID == 1 || ratingScaleTypeID == 2)
                    {
                        gridResponses.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
                    }
                    else
                    {
                        gridResponses.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = true;
                    }

                    if (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview)
                    {
                        //JAX: 1075 HR unable to make edits in Final Review to Task Statements 
                        if ((base.IsAdmin)||(base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR))
                            txtQuestion.ReadOnly = false;
                        else
                            txtQuestion.ReadOnly = true;
                    }

                    if (trtsText != null)
                    {
                        trtsText.Visible = true;
                        trtsRow.Visible = false;
                    }


                    HtmlTableCell tdRadSpell = griditem.FindControl("tdRadSpell") as HtmlTableCell;
                    //RadSpell rs = griditem.FindControl("RadSpellTaskStatements") as RadSpell;

                    if (!IsInView)
                    {
                        if (tdRadSpell != null) tdRadSpell.Visible = true;
                    }
                    else
                    {
                        if (tdRadSpell != null)
                        {
                            tdRadSpell.Visible = false;
                           // rs.Visible = false;
                        } 
                    }
                }

              
            }
        }

        //Keshab - This function is no longer valid for current business design hence needs to be removed.
        private void AssignJQFactorItemEntityValues(JQFactorItemEntity entity, GridCommandEventArgs e)
        {
            GridEditFormItem editform = (GridEditFormItem)e.Item;
            AssignJQFactorItemEntityValues(entity, editform);
        }

        private void AssignJQFactorItemEntityValues(JQFactorItemEntity entity, GridEditFormItem editform)
        {
            //RadTextBox txtQuestion = editform.FindControl("txtQuestion") as RadTextBox;
            RadComboBox rcbRatingScaleType = editform.FindControl("rcbRatingScaleType") as RadComboBox;
            //RadComboBox rcbTaskStatements = editform.FindControl("rcbTaskStatements") as RadComboBox;
            RadTextBox txtInstruction = editform.FindControl("txtInstruction") as RadTextBox;

            int ratingScaleTypeID = int.Parse(rcbRatingScaleType.SelectedValue);
            string ratingScaleInstruction = txtInstruction.Text;
            entity.RatingScaleTypeID = ratingScaleTypeID;
            entity.IsDefault = (ratingScaleTypeID == (int)enumRatingScaleType.DefaultYN || ratingScaleTypeID == (int)enumRatingScaleType.DefaultMultiChoice) ? true : false;
            entity.RatingScaleInstruction = txtInstruction.Text;
            
            if (gridQuestions.MasterTableView.IsItemInserted)
            {
              
                entity.FactorID = base.CurrentJQFactorID;
                entity.ParentItemID = -1;
                entity.ItemTypeID = (int)enumJQItemType.Question;
                entity.ItemNo = -1;
                entity.ItemLetter = string.Empty;
                entity.RatingScaleID = -1;
                entity.RatingScaleName = string.Empty;
                //entity.TaskStatementID = Convert.ToInt64(rcbTaskStatements.SelectedValue);

            }
        }

        protected void gridQuestion_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            {
                GridEditFormItem editform = (GridEditFormItem)e.Item;

                //RadComboBox rcbTaskStatements = editform.FindControl("rcbTaskStatements") as RadComboBox;
                ctrlSearchTaskStatement searchTS = editform.FindControl("TSSearch") as ctrlSearchTaskStatement;
                searchTS.TSSearchCompleted += new ctrlSearchTaskStatement.TSSearchCompletedHandler(searchTS_TSSearchCompleted);
                searchTS.TSSearchCancelCompleted += new ctrlSearchTaskStatement.TSSearchCancelCompleteHandler(searchTS_TSSearchCancelCompleted);
                searchTS.TSSearchClearCompleted += new ctrlSearchTaskStatement.TSSearchClearCompleteHandler(searchTS_TSSearchClearCompleted);

                searchTS.TSSearchUnckecked += new ctrlSearchTaskStatement.TSSearchUnckeckedHandler(searchTS_TSSearchUnckecked);
                searchTS.TSSearchClickGlass += new ctrlSearchTaskStatement.TSSearchClickGlassHandler(searchTS_TSClickGlass);

                RadComboBox rcbRatingScaleType = editform.FindControl("rcbRatingScaleType") as RadComboBox;
                Button btnAddToLibrary = editform.FindControl("btnAddToLibrary") as Button;
                //rcbTaskStatements.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbTaskStatements_SelectedIndexChanged);

                rcbRatingScaleType.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbRatingScaleType_SelectedIndexChanged);
                btnAddToLibrary.Click += new EventHandler(btnAddToLibrary_Click);

                txtQuestionLibrary = editform.FindControl("txtQuestion") as RadTextBox;

                RadGrid gridResponses = editform.FindControl("gridResponses") as RadGrid;
                gridResponses.ItemDataBound += new GridItemEventHandler(gridResponses_ItemDataBound);
                gridResponses.NeedDataSource += new GridNeedDataSourceEventHandler(gridResponses_NeedDataSource);
                gridResponses.ItemCommand += new GridCommandEventHandler(gridResponses_ItemCommand);
                gridResponses.UpdateCommand += new GridCommandEventHandler(gridResponses_UpdateCommand);
                gridResponses.DeleteCommand += new GridCommandEventHandler(gridResponses_DeleteCommand);
                gridResponses.PreRender += new EventHandler(gridResponses_PreRender);

            }
        }

        protected void gridQuestions_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditFormItem)
            {
                SetEditForm(sender, e);

                if (CurrentMode == eMode.Edit)
                {
                    e.Item.Edit = true;
                }

            }
        }

        protected void gridQuestions_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            List<JQFactorItemEntity> questions = jqm.GetJQFactorItemsByJQFactorID(this.JQFactorID);
            this.gridQuestions.DataSource = questions;

            //To use later for getting the added task statements that will be excluded in the 
            //dropdown task statements upon cheking the check box of "Search in All Grade" in ctrlSearchTaskStatement.ascs.cs page.
            if (IsPostBack)
            {
                if (questions.Count <= 0)
                {
                    this.gridQuestions.MasterTableView.NoMasterRecordsText = "No records to display.";
                }
            }
           
        }

        protected void gridQuestions_ItemCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem gridItem;
       
            switch (e.CommandName)
            {
                case RadGrid.PerformInsertCommandName:
                    AddQuestion(sender, e);
                    e.Item.Edit = true;                    
                    break;
                case RadGrid.UpdateCommandName:
                    UpdateQuestion(sender, e);                   
                    break;
                case RadGrid.DeleteCommandName:
                    DeleteQuestion(sender, e);
                    break;
                case "View":
                    IsInView = true;
                    e.Item.Edit = true;
                    gridQuestions.Rebind();

                    break;
                case RadGrid.EditCommandName:
                        gridItem = e.Item as GridDataItem;
                        JQFactorItemID = long.Parse(gridItem.GetDataKeyValue("ID").ToString());                

                    break;

                case RadGrid.InitInsertCommandName:

                    break;
                default:
                    break;
            }
        }
        protected void gridQuestions_PreRender(object sender, EventArgs e)
        {
            //making all other items invisible except edit form when adding new or editing
            GridItem[] gridcommanditems = gridQuestions.MasterTableView.GetItems(GridItemType.CommandItem);

            if ((gridQuestions.MasterTableView.IsItemInserted) || (gridQuestions.EditItems.Count > 0))
            {

                foreach (GridItem item in gridQuestions.Items)
                {
                    item.Visible = false;
                }

                //hiding all command items
                foreach (GridItem item in gridcommanditems)
                {
                    item.Visible = false;
                }
                //hiding headers
                gridQuestions.MasterTableView.ShowHeader = false;
                //hiding btnCancel of the main page
                btnCancel.Visible = false;

                //disabling the save button if in edit/insert qualification statement
                btnSave.Enabled = false;
            }

            else
            {
                //hiding refresh button
                foreach (GridItem item in gridcommanditems)
                {
                    item.FindControl("RebindGridButton").Visible = false;
                }

                gridQuestions.MasterTableView.ShowHeader = true;
                btnCancel.Visible = true;

                //enabling save button if not in view mode and user is either admin/hr and Package is not signed
                bool blnSaveEnable = (base.CurrentNavMode != enumNavigationMode.View) && (base.IsAdmin || (base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR));
                btnSave.Enabled = blnSaveEnable;
            }

        }
        protected void DeleteQuestion(object sender, GridCommandEventArgs e)
        {
            if (sender is RadGrid)
            {
                GridDataItem gridItem = e.Item as GridDataItem;

                int questionID = int.Parse(gridItem.GetDataKeyValue("ID").ToString());
                jqm.DeleteJQFactorItem(questionID, this.CurrentUserID);
                gridQuestions.Rebind();
            }
        }
        protected void UpdateQuestion(object sender, GridCommandEventArgs e)
        {
            GridEditFormItem editform = (GridEditFormItem)e.Item;
            UpdateQuestion(sender, editform);
            
        }
        protected void UpdateQuestion(object sender, GridEditFormItem editform)
        {
            RadComboBox rcbRatingScaleType = editform.FindControl("rcbRatingScaleType") as RadComboBox;
            RadGrid gridResponses = editform.FindControl("gridResponses") as RadGrid;

            int ratingScaleTypeID = int.Parse(rcbRatingScaleType.SelectedValue);
            long jqfactoritemid = (long)editform.GetDataKeyValue("ID");
            if (jqfactoritemid > 0)
            {
                try
                {
                    JQFactorItemEntity entity = jqm.GetJQFactorItemByID(jqfactoritemid);
                    int oldRatingScaleTypeID = entity.RatingScaleTypeID;

                    RadTextBox txtQuestion = editform.FindControl("txtQuestion") as RadTextBox;
                    entity.ItemText = txtQuestion.Text;
                  
                    AssignJQFactorItemEntityValues(entity, editform);
                    
                    jqm.UpdateJQFactorItem(entity, CurrentUserID);

                    // check if rating scale was changed by the user and delete the responses if that is the case
                    if (oldRatingScaleTypeID != entity.RatingScaleTypeID)
                    {
                        jqm.DeleteAllRatingScaleResponses(entity.ID, this.CurrentUserID);
                        entity.RatingScaleID = jqm.CopyResponsesFromRatingScaleType(entity.ID, ratingScaleTypeID, entity.RatingScaleTypeID, this.CurrentUserID);
                    }

                    // update the instruction - only HR users can edit instructions for custom responses
                    if (!entity.IsDefault && (base.CurrentUser.HasPermission(enumPermission.MaintainHRSection) || base.IsSystemAdministrator))
                    {
                        jqm.UpdateJQRatingScaleInstruction(entity.RatingScaleID, entity.RatingScaleInstruction, this.CurrentUserID);
                    }

                    CurrentRatingScaleID = entity.RatingScaleID;
                    CurrentRatingScaleTypeID = entity.RatingScaleTypeID;
                    gridResponses.Rebind();
                    gridResponses.Visible = true;
                    CurrentMode = eMode.Edit;
                    gridQuestions.Rebind();
                    
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

        }
        protected void AddQuestion(object sender, GridCommandEventArgs e)
        {

            GridEditFormItem editform = (GridEditFormItem)e.Item;

            RadTextBox txtQuestion = editform.FindControl("txtQuestion") as RadTextBox;
            RadButton rdCreate = editform.FindControl("radCreate") as RadButton;
            if (rdCreate.Checked)
            {
                if (txtQuestion.Text.Trim() != System.String.Empty)
                {
                    AddQuestion(sender, editform, false);
                    e.Item.Edit = true;
                }
            }
            else
            {
                AddQuestion(sender, editform, false);
                e.Item.Edit = true;
            }
       
        }

        private void AddQuestion(object sender, GridEditFormItem editform,bool blnKeepInEditMode)
        {
            try
            {
                JQFactorItemEntity entity = new JQFactorItemEntity();

                //Get Task Statement from the ListBox
                RadListBox tsListBox = editform.FindControl("rlbTSList") as RadListBox;
                IList<RadListBoxItem> collection = tsListBox.CheckedItems;

                RadButton rdCreate = editform.FindControl("radCreate") as RadButton;
                RadButton rdSelect = editform.FindControl("radSelect") as RadButton;
                RadTextBox txtQuestion = editform.FindControl("txtQuestion") as RadTextBox;

                if (rdCreate.Checked)
                {
                     entity.TaskStatementID = 0;
                     entity.ItemText = txtQuestion.Text; 
                     AssignJQFactorItemEntityValues(entity, editform);
                     JQFactorItemID = jqm.AddQuestionWithRatingScale(entity, entity.RatingScaleInstruction, CurrentUserID);
                }
                else
                {
                    foreach (RadListBoxItem item in collection)
                    {
                        entity.TaskStatementID = Convert.ToInt64(item.Value);
                        entity.ItemText = item.Text;
                        AssignJQFactorItemEntityValues(entity, editform);
                        JQFactorItemID = jqm.AddQuestionWithRatingScale(entity, entity.RatingScaleInstruction, CurrentUserID);
                         
                    }
                }

                if (JQFactorItemID > 0)
                {
                    entity = jqm.GetJQFactorItemByID(JQFactorItemID); 
                    CurrentRatingScaleTypeID = entity.RatingScaleTypeID;
                    CurrentRatingScaleID = entity.RatingScaleID;
                    TaskStatementID = entity.TaskStatementID;
                    
                                      
                    gridQuestions.MasterTableView.IsItemInserted = false;
                    CurrentMode = eMode.Edit;

                    gridQuestions.Rebind();

                    if (blnKeepInEditMode)
                    {
                        SetGridInEditMode(gridQuestions);
                    }

                   Label lblmsgTS= editform.FindControl("lblmsgTS") as Label;
                   if (lblmsgTS != null)
                   {
                       lblmsgTS.Text = "Task Statement added successfully.";
                   }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        protected void rcbRatingScaleType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            //Cancel button bypasses all execution. We don't want to save the form data while cancel button is clicked.
            //And the client side validation should be in place while Rating Scale type is changed and there is not question text provided.
            if (Page.FindControl(postbackControlName).GetType() == typeof(System.Web.UI.WebControls.Button))
            {
                Button butcancel;
                butcancel = (Button)Page.FindControl(postbackControlName);
                if (butcancel != null)
                {
                    if (butcancel.ID == "btnCancel")
                    {
                        return;
                    }
                }
            }

            int ratingScaleTypeID = int.Parse(e.Value);
            // getting the default rating scale instructions based on the rating scale type
            //otherwise it was not setting the correct instruction if the new rating scale type was custom
            string ratingscaleinstruction = jqm.GetDefaultJQRatingScaleInstructionByRatingScaleType(ratingScaleTypeID);
            RadComboBox cmd = (RadComboBox)sender;
            var editform = (GridEditFormItem)cmd.NamingContainer;

            if (editform != null)
            {
                RadTextBox txtInstruction = editform.FindControl("txtInstruction") as RadTextBox;
                RadGrid gridResponses = editform.FindControl("gridResponses") as RadGrid;
                txtInstruction.Text = ratingscaleinstruction;



                if ((ratingScaleTypeID == (int)enumRatingScaleType.DefaultMultiChoice) ||
                     (ratingScaleTypeID == (int)enumRatingScaleType.DefaultYN))
                {
                    txtInstruction.ReadOnly = true;
                }
                else
                    txtInstruction.ReadOnly = false;

                // Save the task statement when user select response type
                RadTextBox txtQuestion = editform.FindControl("txtQuestion") as RadTextBox;
                RadButton rdCreate = editform.FindControl("radCreate") as RadButton;
                RadButton rdSelect = editform.FindControl("radSelect") as RadButton;
                RadListBox tsListBox = editform.FindControl("rlbTSList") as RadListBox;

                if (CurrentMode == eMode.Insert)
                {
                    if (rdCreate.Checked)
                    {
                        if (txtQuestion.Text.Trim() != System.String.Empty)
                        {
                            AddQuestion(sender, editform, true);
                        }
                    }
                    else if (rdSelect.Checked)
                    {
                        if (TSItemsChecked(tsListBox))
                        {
                            //AddQuestion(sender, editform, true);
                        }
                    }
                } 
                else
                {
                    if (txtQuestion.Text.Trim() != System.String.Empty)
                    {
                        UpdateQuestion(sender, editform);
                    }
                }
            }
            showRespones();

       }

        protected void btnAddToLibrary_Click(object sender, EventArgs e)
        {
            long returnCode = -1;

            JQManager jqMgr = new JQManager();
            JQFactorEntity jqFactor = jqMgr.GetJQFactorByJQFactorID(this.JQFactorID);
            GridTableView gtv = ((sender as Button).NamingContainer.NamingContainer) as GridTableView;

            string msg = string.Empty;

            if (JQFactorItemID > 0)
            {
                JQFactorItemEntity jqFactorItem = jqMgr.GetJQFactorItemByID(JQFactorItemID);
                if (jqFactor.KSAID == 0)
                {
                    returnCode = JQManager.AddKSATaskStatementToLibrary(jqFactor.Title, jqFactorItem.ItemText, jqFactor, jqFactorItem, CurrentJNP.SeriesID, CurrentJNP.HighestAdvertisedGrade, this.CurrentUserID);
                    if (returnCode > 0)
                    {
                        msg = "KSA and Task Statment added successfully to library.";
                    }
                    else
                    {
                        msg = "Sorry, Could Not add KSA and Task Statment to library!";
                    }
                }
                else
                {
                    //Need to update the FactorItem table to match the string that goes to library.
                    //Hence it updates first before sending it to the library
                    jqFactorItem.ItemText = txtQuestionLibrary.Text.Trim();
                    jqm.UpdateJQFactorItem(jqFactorItem, CurrentUserID);

                    //We need to get the actural string from the browser rather that the old one that comes from db.
                    //Hence, commented the line below and added new line for new string from browser.
                    //returnCode = JQManager.AddTaskStatementToLibrary(jqFactorItem.ItemText, jqFactorItem, CurrentJNP.SeriesID, CurrentJNP.HighestAdvertisedGrade, jqFactor.KSAID, this.CurrentUserID);
                    returnCode = JQManager.AddTaskStatementToLibrary(txtQuestionLibrary.Text.Trim(), jqFactorItem, CurrentJNP.SeriesID, CurrentJNP.HighestAdvertisedGrade, jqFactor.KSAID, this.CurrentUserID);

                    if (returnCode > 0)
                    {
                        msg = "Task Statment was added successfully.";
                    }
                    else
                    {
                        msg = "Sorry, Could Not add Task Statment to library!";
                    }
                }
                string script = string.Format("radalert('{0}',330,180,'{1}');", msg, "Add To Library");
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "myScript", script, true);

                gridQuestions.Rebind();
            }

        }


        #region Search Task Statement

        private void ClearCancelTSSearch()
        {
            GridEditFormItem editform = (GridEditFormItem)gridQuestions.MasterTableView.GetItems(GridItemType.EditFormItem)[0];

            if (editform != null)
            {
                showRespones();
            
            }

            //Literal searchMssgLabel = editform.FindControl("literalSearchTSmsg") as Literal;
            //if (searchMssgLabel != null) searchMssgLabel.Visible = true;

            Literal searchMssgLabel = editform.FindControl("literalSearchTSmsg") as Literal;
            if (searchMssgLabel != null) searchMssgLabel.Text = searchMssgLabel.Text;

        }

        protected void searchTS_TSSearchClearCompleted(object sender, EventArgs e)
        {

            ClearCancelTSSearch();

            GridEditFormItem editform = (GridEditFormItem)gridQuestions.MasterTableView.GetItems(GridItemType.EditFormItem)[0];
            RadListBox lsTS = editform.FindControl("rlbTSList") as RadListBox;

            ctrlSearchTaskStatement searchTS = editform.FindControl("TSSearch") as ctrlSearchTaskStatement;

            var orderedList = searchTS.TaskStatementList.OrderBy(o => o.TaskStatement).ToList();
            orderedList.RemoveAll(rm => rm.TaskStatement == UserControlBase.OTHERTASKSTATEMENTTEXT);

            //For List box
            if (orderedList.Count > 0)
            {
                TaskStatementEntityManager.RemoveExistingFromListForJAX(orderedList, Convert.ToInt32(this.CurrentJNPID));

                ControlUtility.BindRadListBoxControlWithBackground(lsTS, orderedList, "TaskStatement", "TaskStatementID", "<<-- Select Task Statement -->>");
            }
            else
            {
                InitTaskStatements(lsTS);
            }
        }

        protected void searchTS_TSSearchCancelCompleted(object sender, EventArgs e)
        {
            ClearCancelTSSearch();
        }

        protected void searchTS_TSSearchCompleted(object sender, EventArgs e)
        {
            GridEditFormItem editform = (GridEditFormItem)gridQuestions.MasterTableView.GetItems(GridItemType.EditFormItem)[0];

            if (editform != null)
            {
                try
                {
                    ctrlSearchTaskStatement searchTS = editform.FindControl("TSSearch") as ctrlSearchTaskStatement;

                    //Issue 799 - Check if the selected value is "Create New" i.e. SelectedValue is 0. If it is "Create New" hold it to refetch.
                    //string holdvalue = rcbTS.SelectedValue ;

                    // NOTE MD 6/5: This conditional (I commented it out) was added by someone in versions 11 - 27 in source control
                    //  This -completely disables- the TaskSearch control unless the checkbox is checked. Not sure why this was done...

                    //rcbTS.Items.Clear();
                    var orderedList = searchTS.TaskStatementList.OrderBy(o => o.TaskStatement).ToList();
                    orderedList.RemoveAll(rm => rm.TaskStatement == UserControlBase.OTHERTASKSTATEMENTTEXT);

                    //Get added TS and remove from TS Listbox.
                    TaskStatementEntityManager.RemoveExistingFromListForJAX(orderedList,Convert.ToInt32(this.CurrentJNPID));

                    //For List box
                    RadListBox lsTS = editform.FindControl("rlbTSList") as RadListBox;
                    ControlUtility.BindRadListBoxControlWithBackground(lsTS, orderedList, "TaskStatement", "TaskStatementID", "<<-- Select Task Statement -->>");
                                   
                    // Search control will determine and set the form search result message, just pass a ref to the label element
                    // NOTE MD 6/5: This should be changed to an asp:Label control to match the KSA search message control
                    Literal searchMssgLabel = editform.FindControl("literalSearchTSmsg") as Literal;
                    if (searchMssgLabel != null) searchMssgLabel.Text = searchTS.SetSearchResultMessage();


                    showRespones();

                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

        }
        protected void searchTS_TSSearchUnckecked(object sender, EventArgs e)
        {
            GridEditFormItem editform = (GridEditFormItem)gridQuestions.MasterTableView.GetItems(GridItemType.EditFormItem)[0];

            ctrlSearchTaskStatement searchTS = editform.FindControl("TSSearch") as ctrlSearchTaskStatement;

            RadListBox lsTS = editform.FindControl("rlbTSList") as RadListBox;
            InitTaskStatements(lsTS);

            Literal searchMssgLabel = editform.FindControl("literalSearchTSmsg") as Literal;
            if (searchMssgLabel != null) searchMssgLabel.Text = "";

            showRespones();
        }
        protected void searchKSA_KSASearchUnckecked(object sender, EventArgs e)
        {
            Label txtQuestion = this.FindControl("lblTitle") as Label;

            if (txtQuestion != null)
                txtQuestion.Text = "";

            HtmlTableRow tr1 = this.FindControl("valMsgRow1") as HtmlTableRow;
            if (tr1 != null)
            {
                tr1.Visible = false;
            }

            HtmlTableRow tr2 = this.FindControl("valMsgRow2") as HtmlTableRow;
            if (tr2 != null)
            {
                tr2.Visible = false; 
            }
        }

        protected void searchTS_TSClickGlass(object sender, EventArgs e)
        {
            GridEditFormItem editform = (GridEditFormItem)gridQuestions.MasterTableView.GetItems(GridItemType.EditFormItem)[0];
            showRespones();
        }

        protected void searchTS_TSSearchObjectNotSet()
        {
            PrintErrorMessage("Please set current grade and series for the task statement search.");
        }

        #endregion

        #region Responses Grid events

        private List<RatingScaleResponseEntity> GetResponses(long ratingscaleid)
        {
            ratingscaleid = ratingscaleid == 3 ? 1 : ratingscaleid; //if custom Y/N, make it regular Y/N
            ratingscaleid = ratingscaleid == 4 ? 2 : ratingscaleid; //if custom multiple, make it regular multiple

            List<RatingScaleResponseEntity> items = new List<RatingScaleResponseEntity>();
            if (ratingscaleid > 0)
            {
                items = jqm.GetDefaultReponsesForQuestionByRatingScaleID(ratingscaleid);
            }
            return items;
        }

        protected void gridResponses_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            GridEditFormItem editform = (GridEditFormItem)gridQuestions.MasterTableView.GetItems(GridItemType.EditFormItem)[0];

            RadComboBox rcbRatingScaleType = editform.FindControl("rcbRatingScaleType") as RadComboBox;

            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;

                if (!(item is GridDataInsertItem))
                {
                    Label lbl = (Label)item["TemplateResponseLetter"].FindControl("lblRatingScaleTypeID");
                    int ratingScaleTypeID = int.Parse(lbl.Text);

                    if (rcbRatingScaleType != null)
                    {
                        ratingScaleTypeID = int.Parse(rcbRatingScaleType.SelectedValue);
                    }
                    if (base.IsAdmin || base.HasHRGroupPermission)
                    {

                        if ((ratingScaleTypeID == (int)enumRatingScaleType.DefaultMultiChoice) ||
                                 (ratingScaleTypeID == (int)enumRatingScaleType.DefaultYN))
                        {
                            this.isDisplayCRUDColumns = false;

                        }
                        else
                        {
                            this.isDisplayCRUDColumns = true;
                        }
                    }
                    else //JA issue id 918 : HM has ability to change text of custom responses
                    {
                        this.isDisplayCRUDColumns = false;
                    }
                }
            }
        }

        protected void gridResponses_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RadGrid gridResponses = sender as RadGrid;
            gridResponses.DataSource = GetResponses(CurrentRatingScaleID);

        }

        protected void gridResponses_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditFormItem editform = (GridEditFormItem)gridQuestions.MasterTableView.GetItems(GridItemType.EditFormItem)[0];
            RadGrid gridResponses = editform.FindControl("gridResponses") as RadGrid;

            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                var gridItem = (GridDataInsertItem)e.Item;

                RadTextBox txtResponseLetter = gridItem.FindControl("txtResponseLetter") as RadTextBox;
                RadTextBox txtResponseText = gridItem.FindControl("txtResponseText") as RadTextBox;

                RatingScaleResponseEntity entity = new RatingScaleResponseEntity();
                entity.ResponseLetter = txtResponseLetter.Text;
                entity.ResponseText = txtResponseText.Text;
                entity.RatingScaleID = CurrentRatingScaleID;
                entity.ID = jqm.AddRatingScaleResponse(entity, this.CurrentUserID);
                BindData();
            }

            if (e.CommandName == RadGrid.EditCommandName)
            {
                var gridItem = (GridEditableItem)e.Item;
                gridItem.Edit = true;
                gridItem.OwnerTableView.IsItemInserted = false;

            }

            if (e.CommandName == RadGrid.InitInsertCommandName)
            {
                if (gridResponses != null)
                {
                    gridResponses.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
                    this.isDisplayCRUDColumns = false;

                }
                else
                {
                    //No need to do this because gridResponses is null and can't have statement like this below.
                    this.isDisplayCRUDColumns = true;
                }

            }
        }

        protected void gridResponses_PreRender(object sender, EventArgs e)
        {
            RadGrid gridResponses = sender as RadGrid;
            GridItem[] gridcommanditems = gridResponses.MasterTableView.GetItems(GridItemType.CommandItem);
            if (IsInView)
            {
                gridResponses.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                gridResponses.Columns[0].Display = false; //edit
                gridResponses.Columns[1].Display = false;//delete

            }
            else
            {
                //JA issue id 918 : HM has ability to change text of custom responses
                if (!base.IsAdmin && !base.HasHRGroupPermission)
                {
                    isDisplayCRUDColumns = false;
                }


                if (isDisplayCRUDColumns)
                {
                    if (base.CurrentUser.HasPermission(enumPermission.MaintainHRSection) || base.IsSystemAdministrator)
                    {

                        gridResponses.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                    }
                }
                else
                {
                    gridResponses.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    foreach (GridItem item in gridcommanditems)
                    {
                        item.Visible = false;
                    }
                }
                gridResponses.Columns[0].Display = isDisplayCRUDColumns; //edit column
                //if there are only two responses don't display the delete column
                //minimum two responses are required
                if (gridResponses.MasterTableView.Items.Count == 2)
                {
                    gridResponses.Columns[1].Display = false; //delete column
                    //if ratingscale is customY/N and there are already 2 respnses then don't show add new response
                    if (CurrentRatingScaleTypeID == (int)enumRatingScaleType.CustomYN)
                    {
                        gridResponses.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                    }

                }
                else
                {
                    gridResponses.Columns[1].Display = isDisplayCRUDColumns; //delete column

                }
            }
            gridResponses.Rebind();
        }

        protected void gridResponses_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridDataItem gridItem = (GridDataItem)e.Item;

            long reponseID = long.Parse(gridItem.GetDataKeyValue("ID").ToString());
            RadTextBox txtResponseLetter = gridItem.FindControl("txtResponseLetter") as RadTextBox;
            RadTextBox txtResponseText = gridItem.FindControl("txtResponseText") as RadTextBox;

            RatingScaleResponseEntity entity = new RatingScaleResponseEntity();
            entity.ID = reponseID;
            entity.ResponseLetter = txtResponseLetter.Text;
            entity.ResponseText = txtResponseText.Text;

            jqm.UpdateRatingScaleResponse(entity, this.CurrentUserID);
        }

        protected void gridResponses_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                GridDataItem item = (GridDataItem)e.Item;
                long jqResponseID = (long)item.GetDataKeyValue("ID");
                Label lbl = (Label)item["TemplateResponseLetter"].FindControl("lblRatingScaleTypeID");
                int ratingScaleTypeID = int.Parse(lbl.Text);

                // just double check, if is custom response, erase it
                if ((ratingScaleTypeID == (int)enumRatingScaleType.CustomYN) ||
                    (ratingScaleTypeID == (int)enumRatingScaleType.CustomMultiChoice))
                {
                    jqm.DeleteRatingScaleResponse(jqResponseID);
                }

                //showRespones();
            }
        }

        #endregion

        #region [Pop up Form]

        private void showRespones()
        {
            GridEditFormItem editform = (GridEditFormItem)gridQuestions.MasterTableView.GetItems(GridItemType.EditFormItem)[0];

            RadGrid gridResponses = editform.FindControl("gridResponses") as RadGrid;

            RadComboBox rcbRatingScaleType = editform.FindControl("rcbRatingScaleType") as RadComboBox;

            long ratingScaleTypeID = 0;

            if (rcbRatingScaleType != null)
            {
                ratingScaleTypeID = Convert.ToInt32(rcbRatingScaleType.SelectedValue);

                if (ratingScaleTypeID == 1 || ratingScaleTypeID == 2)
                {
                    gridResponses.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
                }
                else
                {
                    if (CurrentMode == eMode.Edit)
                        gridResponses.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = true;
                }

                //Issue 932 - lt variable below need to be global variable in order to maintain the response list.
                //We don't want to get fresh set of responses based on response type.
                //List<RatingScaleResponseEntity> lt = GetResponses(ratingScaleTypeID);
                lt = GetResponses(ratingScaleTypeID);

                gridResponses.DataSource = lt;
                gridResponses.DataBind();

                if (gridResponses != null)
                    gridResponses.Visible = true;

                if (lt.Count <= 0)
                {
                    gridResponses.MasterTableView.ShowFooter = false;
                }
            }
        }

        //Keshab - This function is no longer valid for current business design hence needs to be removed.
        private void ShowQuestion(object source, GridCommandEventArgs e)
        {
            RWM.Windows.Clear();
            GridDataItem gridItem;
            string script = string.Empty;

            string navigateurl = string.Empty;
            lblmsg.Text = string.Empty;
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    script = string.Format("ShowQuestionWindowClient('{0}','{1}');", "Insert", JQFactorID);
                    break;
                case RadGrid.EditCommandName:
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    long questionID = long.Parse(gridItem.GetDataKeyValue("ID").ToString());
                    script = string.Format("ShowQuestionWindowClient('{0}','{1}');", "Edit", questionID);
                    break;
                case "View":
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    questionID = long.Parse(gridItem.GetDataKeyValue("ID").ToString());
                    script = string.Format("ShowQuestionWindowClient('{0}','{1}');", "View", questionID);
                    break;
                default:
                    break;

            }

            RWM.Windows.Add(rwQ);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowQuestionWindowClient", script, true);
        }

        #endregion

        #endregion

        #region [Control Events]

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //setting current mode to edit - this prevents system to go in view mode if user cancels out without adding
            if (CurrentNavMode == enumNavigationMode.Insert)
            {
                CurrentNavMode = enumNavigationMode.Edit;
            }

            base.GoToLink("~/JQ/JQKSA.aspx", CurrentNavMode);

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void rcbFinalKSA_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int index = int.Parse(e.Value);

            if (CurrentNavMode == enumNavigationMode.Insert)
            {
                if (index != -1)
                {
                    if (index == 0)  // "Other" was selected
                    {
                        //this.divOtherKSASelection.Visible = true;
                    }
                    else
                    {
                        this.lblTitle.Text = rcbFinalKSA.SelectedItem.Text;
                        RadEditKSAInstruction.Content = rcbFinalKSA.SelectedItem.Text;
                        //this.divOtherKSASelection.Visible = false;
                    }
                }
                else
                {
                    this.lblTitle.Text = "";
                    RadEditKSAInstruction.Content = "";
                }
            }

            HtmlTableRow tr1 = this.FindControl("valMsgRow1") as HtmlTableRow;
            if (tr1 != null)
            {
                tr1.Visible = false;
            }

            HtmlTableRow tr2 = this.FindControl("valMsgRow2") as HtmlTableRow;
            if (tr2 != null)
            {
                tr2.Visible = false;
            }
        }

        //Show and Hide the instruction.
        protected void btnShowKSAInst_Click(object sender, EventArgs e)
        {
            HtmlTableRow trInst = FindControl("ksaInst") as HtmlTableRow;
            HtmlTableRow trInstText = FindControl("ksaInstText") as HtmlTableRow;

            if (trInst != null)
            {
                if (!trInst.Visible)
                    trInst.Visible = true;
                else
                    trInst.Visible = false;
            }

            if (trInstText != null)
            {
                if (!trInstText.Visible)
                    trInstText.Visible = true;
                else
                    trInstText.Visible = false;
            }

            if (trInst.Visible)
                btnShowKSAInst.Text = "Hide Instruction";

            if (!trInst.Visible)
                btnShowKSAInst.Text = "Show Instruction";

            //Issue 1056 - Implementing ShowKSAFactorInstructionButton
            if (System.Configuration.ConfigurationManager.AppSettings["ShowKSAFactorInstructionButton"] != null)
            {
                bool bShow = System.Configuration.ConfigurationManager.AppSettings["ShowKSAFactorInstructionButton"].ToString().ToLower() == "false" ? false : true;

                if (bShow)
                {
                    if (btnShowKSAInst.Text == "Show Instruction") 
                        btnSave.Visible = false;
                    else
                        btnSave.Visible = true;
                }
            }


        }
        //Show and Hide the instruction.
        protected void btnShowInst_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridEditableItem gridItem = (GridEditableItem)btn.NamingContainer;

            HtmlTableRow trInst = gridItem.FindControl("inst") as HtmlTableRow;
            HtmlTableRow trInstText = gridItem.FindControl("instText") as HtmlTableRow;

            if (trInst != null)
            {
                if (!trInst.Visible)
                    trInst.Visible = true;
                else
                    trInst.Visible = false;
            } 

            if (trInstText != null)
            {
                if (!trInstText.Visible)
                    trInstText.Visible = true;
                else
                    trInstText.Visible = false;
            }

            if (trInst.Visible)
                btn.Text = "Hide Instruction";

            if (!trInst.Visible)
                btn.Text = "Show Instruction";
            

            RadComboBox rcbRatingScaleType = gridItem.FindControl("rcbRatingScaleType") as RadComboBox;
            RadGrid gridResponses = gridItem.FindControl("gridResponses") as RadGrid;

            //Issue 932 - lt variable below need to be global variable in order to maintain the response list.
            //We don't want to get fresh set of default responses based on custom response type.
            //List<RatingScaleResponseEntity> lt = GetResponses(Convert.ToInt32(rcbRatingScaleType.SelectedValue));
            gridResponses.DataSource = lt;


            if (gridItem != null)
            {
                RadTextBox txtInstruction = gridItem.FindControl("txtInstruction") as RadTextBox;

                if (CurrentJNPWS == enumJNPWorkflowStatus.Revise)
                {
                    if (!base.IsAdmin)
                    {
                        if (!base.HasHRGroupPermission)
                        {
                            txtInstruction.ReadOnly = true;
                        }
                    }
                }
            }

            showRespones();
        }


        protected void radio_Checked(object sender, EventArgs e)
        {
            CustomValidator CustValidatorTS;

            RadButton btn = (RadButton)sender;

            GridEditableItem gridItem = (GridEditableItem)btn.NamingContainer;

            HtmlTableRow trtsLabel = gridItem.FindControl("tsLabel") as HtmlTableRow;
            HtmlTableRow trtsText = gridItem.FindControl("tsText") as HtmlTableRow;
            HtmlTableRow trtsRow = gridItem.FindControl("lbTaskStatement") as HtmlTableRow;
            
            //HtmlTableRow trSearch = gridItem.FindControl("rSearch") as HtmlTableRow;
            HtmlTableCell trSearch = gridItem.FindControl("rSearch") as HtmlTableCell;

            RadButton rdCreate = gridItem.FindControl("radCreate") as RadButton;
            RadButton rdSelect = gridItem.FindControl("radSelect") as RadButton;

            CustValidatorTS = gridItem.FindControl("CustomValidator1") as CustomValidator;

            if (rdCreate.Checked)
            {
                if (trtsLabel != null)
                {
                    RadComboBox rcbRatingScaleType = gridItem.FindControl("rcbRatingScaleType") as RadComboBox;
                    Button btnSaveTS = gridItem.FindControl("btnSaveTS") as Button;

                    trtsLabel.Visible = false;
                    trtsText.Visible = true;
                    trtsRow.Visible = false;
                    trSearch.Visible = false;
                    //rcbRatingScaleType.Enabled = true;
                    //btnSaveTS.Enabled = true;

                    //if (CustValidatorTS != null) CustValidatorTS.Enabled = false;

                    Literal searchMssgLabel = gridItem.FindControl("literalSearchTSmsg") as Literal;
                    if (searchMssgLabel != null) searchMssgLabel.Visible = false;
                }

                HtmlTableCell tdRadSpell = gridItem.FindControl("tdRadSpell") as HtmlTableCell;
                //RadSpell rs = griditem.FindControl("RadSpellTaskStatements") as RadSpell;

                if (!IsInView)
                {
                    if (tdRadSpell != null) tdRadSpell.Visible = true;
                }
                else
                {
                    if (tdRadSpell != null)
                    {
                        tdRadSpell.Visible = false;
                        // rs.Visible = false;
                    }
                }
            }

            if (rdSelect.Checked)
            {
                if (trtsLabel != null)
                {

                    trtsLabel.Visible = false;
                    trtsText.Visible = false;
                    trtsRow.Visible = true;
                    trSearch.Visible = true;

                    //if (CustValidatorTS != null) CustValidatorTS.Enabled = true;

                    Literal searchMssgLabel = gridItem.FindControl("literalSearchTSmsg") as Literal;
                    if (searchMssgLabel != null) searchMssgLabel.Visible = true;

                    HtmlTableCell tdRadSpell = gridItem.FindControl("tdRadSpell") as HtmlTableCell;
                    //RadSpell rs = griditem.FindControl("RadSpellTaskStatements") as RadSpell;

                    if (!IsInView)
                    {
                        if (tdRadSpell != null) tdRadSpell.Visible = true;
                    }
                    else
                    {
                        if (tdRadSpell != null)
                        {
                            tdRadSpell.Visible = false;
                            // rs.Visible = false;
                        }
                    }
                }
            }

            showRespones();
        }

        //protected void rlbTSList_checked(object sender, EventArgs e)
        //{
            
        //    RadListBox lst = (RadListBox)sender;

        //    GridEditableItem gridItem = (GridEditableItem)lst.NamingContainer;
            
        //    //if(gridItem !=null)
        //    //    EnableDisableResponseCombo(gridItem);

        //    showRespones();
        //}

        protected void EnableDisableResponseCombo(GridEditableItem gridItem)
        {
            RadListBox tsListBox = gridItem.FindControl("rlbTSList") as RadListBox;

            RadComboBox rcbRatingScaleType = gridItem.FindControl("rcbRatingScaleType") as RadComboBox;

            if (tsListBox != null)
            {
                if (TSItemsChecked(tsListBox))
                {
                    if (rcbRatingScaleType != null)
                    {
                        if ((base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR) || base.IsSystemAdministrator)
                        {
                            rcbRatingScaleType.Enabled = true;
                        }
                        else
                        {
                            rcbRatingScaleType.Enabled = false; ;
                        }
                    }
                }
                else
                {
                    if (rcbRatingScaleType != null)
                    {
                        rcbRatingScaleType.Enabled = false;
                    }
                }
            }
        }

        protected bool TSItemsChecked(RadListBox lb)
        {
            bool TSChecked = false;
            IList<RadListBoxItem> collection = lb.CheckedItems;

            foreach (RadListBoxItem item in collection)
            {
                if (item.Checked)
                {
                    TSChecked = true;
                    break;
                }
            }

            return TSChecked;  
        }
        #endregion


    }
}

