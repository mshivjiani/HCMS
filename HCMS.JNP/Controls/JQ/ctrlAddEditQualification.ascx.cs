using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.JQ;
using HCMS.Lookups;
using HCMS.Business.JNP; 
using HCMS.Business.Lookups;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.Lookups.Collections;
using System.Configuration;

namespace HCMS.JNP.Controls.JQ
{
    public partial class ctrlAddEditQualification : JNPUserControlBase
    {
        JQManager jqm = new JQManager();
        JQFactorEntity entity;

        System.Web.UI.HtmlControls.HtmlTableRow trInst;
        System.Web.UI.HtmlControls.HtmlTableRow trInstText;
        System.Web.UI.HtmlControls.HtmlTableRow trQInstButton;

        string postbackControlName = "";

        #region Events/Delegates

            public delegate void NonExistentJQFactorHandler();
            public event NonExistentJQFactorHandler NonExistentJQFactorEncountered;
        
        #endregion
        
        #region [Private Properties]

            private bool isDisplayCRUDColumns = true;

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


            // Filter out Selective Factor and Condition of Employment
            private bool filterFactorTypes(RadComboBoxItem listItem)
            {
                int val = int.Parse (listItem.Value);
                if (val == (int)enumJQFactorType.ConditionOfEmployment || val == (int)enumJQFactorType.SelectiveFactor)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        #endregion

        protected override void OnInit(EventArgs e)
        {   
            base.OnInit(e); 
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            postbackControlName = Page.Request.Params.Get("__EVENTTARGET");

            if (!Page.IsPostBack)
            {

                LoadPage();
               
            }
        }

        private void Page_PreRender(object sender, System.EventArgs e)
        {

            if ((CurrentNavMode == enumNavigationMode.Edit) || (CurrentNavMode == enumNavigationMode.View))
            {
                if (gridQuestions.Items.Count > 0)
                {

                    GridEditFormItem editform = gridQuestions.MasterTableView.GetItems(GridItemType.EditFormItem)[0] as GridEditFormItem;

                  //hide the main cancel button when editing qualification statement
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

        #region [Factor Related]

        private void LoadPage()
        {
            if (CurrentNavMode == enumNavigationMode.Insert)
            {
                JQFactorID = -1;
                //filtering COE/SF
                InitFactorType(true);
                this.qualificationDetail.Visible = false;
            }
            else if ((CurrentNavMode == enumNavigationMode.Edit) || (CurrentNavMode == enumNavigationMode.View))
            {
                InitFactorType(false);
                this.qualificationDetail.Visible = true;
                //gets factor information based on factor id and sets the value in controls
                BindData();
                gridQuestions.Rebind();

            }

            SetPageView();
        }
        private void InitFactorType(bool filter)
        {
            rcbFactorTypes.Items.Clear(); 
            
            List<JQFactorTypeEntity> items = jqm.GetAllNonKSAFactorTypes();
            if (filter)
            {
                ControlUtility.BindRadComboBoxControl(rcbFactorTypes, items, filterFactorTypes, "Name", "ID", "[-- Select Qualification Type --]");
            }
            else
            {
                ControlUtility.BindRadComboBoxControl(rcbFactorTypes, items, null, "Name", "ID", "[-- Select Qualification Type --]");
            }
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
               
                entity = jqm.GetJQFactorByJQFactorID(JQFactorID);
                txtTitle.Text = entity.Title;
                rcbFactorTypes.SelectedValue = entity.FactorTypeID.ToString();
                enumJQFactorType selectedFactorType = (enumJQFactorType)int.Parse (rcbFactorTypes.SelectedValue);
                if (selectedFactorType==enumJQFactorType.MinimumQualification )
                {
                    hlMinimumQualifications.Visible = true;
                    ToolTipMinQual.Visible = true;
                    BindMinQualHyperLink();

                    hlMinimumQualifications2.Visible = true;
                    ToolTipMinQual2.Visible = true;
                }
                else
                {
                    hlMinimumQualifications.Visible = false;
                    ToolTipMinQual.Visible = false;

                    hlMinimumQualifications2.Visible = false;
                    ToolTipMinQual2.Visible = false;

                }
                JQFactorID = entity.ID;
                this.CurrentJQFactorID = entity.ID;

                //Issue 974 - Qualification Instruction has a break. 
                //To resolve the issue of hyphen causing the line break in Instrucition control.
                //For this issue the line below is commented.
                //string instruction = entity.Instruction.Replace(" ", "&nbsp;");
                string instruction = entity.Instruction.Replace("\n", "<br />");

                RadEditQualificationInstruction.Content = instruction;
   
            }
        }

        private void SetPageView()
        {
             
            bool isInViewMode = (base.CurrentNavMode == enumNavigationMode.View);
            //JAX: 1056 : JQ Qualification and KSA: Hide the factor instruction (completely) for all users in JAX (KSA and qual screen) 
            bool blnshowbtnInst =false;
            bool.TryParse ( ConfigurationManager.AppSettings["ShowQualFactorInstructionButton"].ToString(),out blnshowbtnInst);
            btnShowQUalInst.Visible = blnshowbtnInst;
            ToolTipQualInstructions.Visible = blnshowbtnInst;
            enumJNPWorkflowStatus currentws = base.CurrentJNPWS;
            bool blnshowEdit = base.ShowEditFields(enumDocumentType.JQ);

            //Qualification
            rcbFactorType_row.Visible = base.IsInInsert;
            txtTitle.Enabled = false;
            //RadEditQualificationInstruction.Enabled = false;
            btnSave.Enabled = false;
            
            //Qualification statements
            GridColumn EditQuestioncolumn = gridQuestions.MasterTableView.OwnerGrid.Columns.FindByUniqueName("EditCommandColumn");//gridQualifications.Columns[0];//gridQualifications.MasterTableView.EditFormSettings.EditColumn;
            GridColumn DeleteQuestioncolumn = gridQuestions.MasterTableView.OwnerGrid.Columns.FindByUniqueName("DeleteCommandColumn");
            GridColumn ViewQuestioncolumn = gridQuestions.MasterTableView.OwnerGrid.Columns.FindByUniqueName("ViewCommandColumn");

            gridQuestions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            EditQuestioncolumn.Visible =false;// edit column            
            DeleteQuestioncolumn.Visible = false;//delete column
            DeleteQuestioncolumn.Display = false;//setting the visible=false does not hide the gridbuttoncolumn --delete column
            ViewQuestioncolumn.Visible =(CurrentNavMode == enumNavigationMode.View);        
            btnSave.Enabled = false;
           
                if (base.IsInEdit || base.IsInInsert)
                {
                    if (base.IsAdmin)
                    {
                        if (base.IsInInsert)
                        {
                            rcbFactorTypes.Enabled = true;
                            txtTitle.Enabled = true;
                            btnSave.Enabled = true;
                            RadEditQualificationInstruction.Enabled = true;
                        }
                        else
                        {
                            //txtTitle.Enabled = true;
                            RadEditQualificationInstruction.Enabled = true;
                            btnSave.Enabled = true;
                            gridQuestions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                            EditQuestioncolumn.Visible = true;
                            DeleteQuestioncolumn.Visible = true;
                            DeleteQuestioncolumn.Display = true;

                            if (entity.FactorTypeID == (int)enumJQFactorType.ConditionOfEmployment  || entity.FactorTypeID ==(int)enumJQFactorType.SelectiveFactor )
                            {
                                txtTitle.Enabled = false;

                            }
                            else
                            {
                                txtTitle.Enabled = true;
                            }
                        }


                    } //end of base.IsAdmin

                    ////Issue 1060 Editable for HR in FinalReview
                    //else if ((base.HasHRGroupPermission) && (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview) && (!CurrentJNP.IsJNPSignedByHR))
                    //{
                    //    if (base.IsInInsert)
                    //    {
                    //        rcbFactorTypes.Enabled = true;
                    //        txtTitle.Enabled = true;
                    //        btnSave.Enabled = true;
                    //        RadEditQualificationInstruction.Enabled = true;
                    //    }
                    //    else
                    //    {
                    //        //txtTitle.Enabled = true;
                    //        RadEditQualificationInstruction.Enabled = true;
                    //        btnSave.Enabled = true;
                    //        gridQuestions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                    //        EditQuestioncolumn.Visible = true;
                    //        DeleteQuestioncolumn.Visible = true;
                    //        DeleteQuestioncolumn.Display = true;

                    //        if (entity.FactorTypeID == (int)enumJQFactorType.ConditionOfEmployment || entity.FactorTypeID == (int)enumJQFactorType.SelectiveFactor)
                    //        {
                    //            txtTitle.Enabled = false;

                    //        }
                    //        else
                    //        {
                    //            txtTitle.Enabled = true;
                    //        }
                    //    }
                    //}

                    else if (base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR) //Not Admin
                    {
                        if (base.IsInInsert)
                        {
                            rcbFactorTypes.Enabled = true;
                            btnSave.Enabled = true;
                            txtTitle.Enabled = true;
                            RadEditQualificationInstruction.Enabled = true;
                        }
                        else  //HR in edit
                        {
                            if (blnshowEdit)
                            {

                                if (entity.FactorTypeID == (int)enumJQFactorType.ConditionOfEmployment || entity.FactorTypeID == (int)enumJQFactorType.SelectiveFactor)
                                {
                                    txtTitle.Enabled = false;
                                }
                                else
                                {
                                    txtTitle.Enabled = true;
                                }

                                RadEditQualificationInstruction.Enabled = true;
                                btnSave.Enabled = true;
                                EditQuestioncolumn.Visible = true;
                                if (currentws == enumJNPWorkflowStatus.Draft || currentws == enumJNPWorkflowStatus.Review || currentws == enumJNPWorkflowStatus.Revise)
                                {
                                    gridQuestions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                                    DeleteQuestioncolumn.Visible = true;
                                    DeleteQuestioncolumn.Display = true;
                                }
                                else
                                {  
                                    gridQuestions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                                }
                            }


                            //Issue 1060 Editable for HR in FinalReview
                            //if ((base.HasHRGroupPermission) && (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview) && (!CurrentJNP.IsJNPSignedByHR))
                            if (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview)
                            {
                                RadEditQualificationInstruction.Enabled = true;
                                btnSave.Enabled = true;
                                gridQuestions.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                                EditQuestioncolumn.Visible = true;
                                DeleteQuestioncolumn.Visible = true;
                                DeleteQuestioncolumn.Display = true;

                                if (entity.FactorTypeID == (int)enumJQFactorType.ConditionOfEmployment || entity.FactorTypeID == (int)enumJQFactorType.SelectiveFactor)
                                {
                                    txtTitle.Enabled = false;

                                }
                                else
                                {
                                    txtTitle.Enabled = true;
                                }
                            }


                        }// end of HR in edit
                    } //end of base.HasHRGroupPermission

                    else if (base.HasHRGroupPermission && CurrentJNP.IsJNPSignedByHR)
                    {
                        btnSave.Enabled = false;

                        //We don't want to disable it. Desabling this control causes failure in word wrapping.
                        //Take a look at line 263. Manisha and Keshab did the same logic.
                        //RadEditQualificationInstruction.Enabled = false;
                    } 
                    // Issue # Modify ctrlAddEditQualification For Revise 
                    // Modify ctrlAddEditqualification to take care of following requirements. 
                    // In Revise Status Supervisors and PD Developers can make edits to Qualification Title & 
                    // Qualification Statements on JQ. However, HMs do not have the capability to add new or delete 
                    // existing qualification titles or qualification statements in Revise Status.                  
                    else // no Admin/no hr -- Supervisor/PD Developer
                    {
                        if (currentws == enumJNPWorkflowStatus.Revise)
                        {
                            txtTitle.Enabled = true;
                            txtTitle.ReadOnly = true;
                            btnSave.Enabled = false;
                            EditQuestioncolumn.Visible = true; 

                        }
                    }
                }           

            //Showing Qualification Instruction based on visibility of btnShowInstr and also if the role is Admin/HR
            trInst = FindControl("QInst") as System.Web.UI.HtmlControls.HtmlTableRow;

            trQInstButton = FindControl("QInstButton") as System.Web.UI.HtmlControls.HtmlTableRow;

            trInstText = FindControl("QInstText") as System.Web.UI.HtmlControls.HtmlTableRow;

            if (trInst != null)
            {
                trInst.Visible = ((blnshowbtnInst)&&(base.IsAdmin || base.HasHRGroupPermission));
            }

            if (trInstText != null)
            {
                trInstText.Visible = ((blnshowbtnInst)&&(base.IsAdmin || base.HasHRGroupPermission));
            }


            if (trInst.Visible)
                btnShowQUalInst.Text = "Hide Instruction";
            else
                btnShowQUalInst.Text = "Show Instruction";


            if (rcbFactorTypes.SelectedValue == "-1")
            {
                btnSave.Enabled = false;
                RadEditQualificationInstruction.Content = "";
            }
            else
            {
                btnSave.Enabled = true;
            }

            //Issue 1056 - Implementing ShowQualFactorInstructionButton
            if (System.Configuration.ConfigurationManager.AppSettings["ShowQualFactorInstructionButton"] != null)
            {
                trInst.Visible = System.Configuration.ConfigurationManager.AppSettings["ShowQualFactorInstructionButton"].ToString().ToLower() == "false" ? false : true;
                trQInstButton.Visible = System.Configuration.ConfigurationManager.AppSettings["ShowQualFactorInstructionButton"].ToString().ToLower() == "false" ? false : true;
                trInstText.Visible = System.Configuration.ConfigurationManager.AppSettings["ShowQualFactorInstructionButton"].ToString().ToLower() == "false" ? false : true;

                if (entity != null)
                {
                    if (entity.FactorTypeID == (int)enumJQFactorType.ConditionOfEmployment || entity.FactorTypeID == (int)enumJQFactorType.SelectiveFactor)
                    {
                        trQSave = FindControl("trQSave") as System.Web.UI.HtmlControls.HtmlTableRow;

                        if (System.Configuration.ConfigurationManager.AppSettings["ShowQualFactorInstructionButton"].ToString().ToLower() == "false")
                            trQSave.Visible = false;
                        else
                            trQSave.Visible = true;
                    }
                }
            }

            gridQuestions.Rebind();
        }

        //Show and Hide the instruction.
        protected void btnShowQUalInst_Click(object sender, EventArgs e)
        {
            trInst = FindControl("QInst") as System.Web.UI.HtmlControls.HtmlTableRow;
            trInstText = FindControl("QInstText") as System.Web.UI.HtmlControls.HtmlTableRow;

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
            {
                btnShowQUalInst.Text = "Hide Instruction";

                ShowHideSaveRow();
            }

            if (!trInst.Visible)
            {
                btnShowQUalInst.Text = "Show Instruction";

                ShowHideSaveRow();
            }

            
        }

        private void ShowHideSaveRow()
        {
            trQSave = FindControl("trQSave") as System.Web.UI.HtmlControls.HtmlTableRow;
            //entity = jqm.GetJQFactorByJQFactorID(JQFactorID);

            if (System.Configuration.ConfigurationManager.AppSettings["ShowQualFactorInstructionButton"].ToString().ToLower() == "false")
                trQSave.Visible = false;
            else
                trQSave.Visible = true;

            if (txtTitle.Enabled == true)
                trQSave.Visible = true;
            else
                trQSave.Visible = false;

            if ((QInstText.Visible) || (txtTitle.Enabled))
                trQSave.Visible = true;
        }

        private void AssignValues(JQFactorEntity entity)
        {

            string qualTitle = txtTitle.Text;

            string qualIntruction = "";

            //using the hidden field because RadEditQualificationInstruction.Text was not showing the updated text on posting back
            //so when the text was modified,  updated text was not stored in text property
            //hidden field was updated on btnSave - client click event 
            // testing the value of hidden field also because if you don't "Show Instruction", the hidden field was "" and thereby causing null exception when
            //saving.
            if (!string.IsNullOrEmpty(hdquains.Value))
            {
                qualIntruction = hdquains.Value;
            }

            else
            {
                qualIntruction = RadEditQualificationInstruction.Text;
            }

            entity.ID = JQFactorID;
            if (base.CurrentJQID > 0)
            {
                entity.JQID = base.CurrentJQID;
            }
            else
            {
                JQManager jQManager = new JQManager();
                entity.JQID = base.CurrentJQID = jQManager.GetJQFactorByJQFactorID(JQFactorID).JQID;
            }
            entity.FactorTypeID = int.Parse(rcbFactorTypes.SelectedValue);
            entity.Title = qualTitle;

            //Issue 1056 - Saving Qualification Title will have the save text for instruction too since we have hidden the Factor instruction.
            if (System.Configuration.ConfigurationManager.AppSettings["ShowQualFactorInstructionButton"].ToString().ToLower() == "false")
                qualIntruction = qualTitle;

            entity.Instruction = qualIntruction;
            entity.KSAID = entity.KSAID > -1 ? entity.KSAID : -1;

            if (CurrentNavMode == enumNavigationMode.Insert)
            {
                entity.CreatedByID = base.CurrentUserID;
            }
            else
            {
                entity.UpdatedByID = base.CurrentUserID;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
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
                        lblmsg.Text = "Qualification added successfully.";
                        CurrentNavMode = enumNavigationMode.Edit;
                        LoadPage();

                        System.Web.UI.HtmlControls.HtmlTableRow trInst = FindControl("QInst") as System.Web.UI.HtmlControls.HtmlTableRow;
                        if (!trInst.Visible)
                        {
                            btnShowQUalInst.Text = "Show Instruction";
                        }
                    }
                    else 
                    {
                        jqm.UpdateJobQuestionnaireFactor(entity);
                        lblmsg.Text = "Qualification updated successfully.";

                        //Issue 974 - Qualification Instruction has a break. 
                        //To resolve the issue of hyphen causing the line break in Instrucition control.
                        //For this issue the line below is commented.
                        //string instruction = entity.Instruction.Replace(" ", "&nbsp;");
                        string instruction = entity.Instruction.Replace("\n", "<br />");

                        RadEditQualificationInstruction.Content = instruction;
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

            if (int.Parse(rcbFactorTypes.SelectedValue) == (int)enumJQFactorType.MinimumQualification )
            {
                hlMinimumQualifications2.Visible = true;
                ToolTipMinQual2.Visible = true;
                BindMinQualHyperLink();
            }
            
        }

        #endregion

        #region [Questions]
        
        private void SetEditForm(object sender, GridItemEventArgs e)
        {
            GridItem griditem = e.Item as GridItem;
            enumJNPWorkflowStatus currentws = base.CurrentJNPWS;

            if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            {
                GridEditFormItem editform = (GridEditFormItem)e.Item;
                RadTextBox txtQuestion = editform.FindControl("txtQuestion") as RadTextBox;
                RadComboBox rcbRatingScaleType = editform.FindControl("rcbRatingScaleType") as RadComboBox;
                RadTextBox txtInstruction = editform.FindControl("txtInstruction") as RadTextBox;
                Button btnSaveQS = editform.FindControl("btnSaveQS") as Button;
                RadGrid gridResponses = editform.FindControl("gridResponses") as RadGrid;

                RadComboBox rcbApptEligQuestion = editform.FindControl("rcbApptEligQuestion") as RadComboBox;

                 //insert mode
                if (e.Item is GridEditFormInsertItem)
                {
                    gridResponses.Visible = false;
                    rcbRatingScaleType.SelectedValue = ((int)enumRatingScaleType.DefaultYN ).ToString();
                    string ratingscaleinstruction = jqm.GetDefaultJQRatingScaleInstructionByRatingScaleType((int)enumRatingScaleType.DefaultYN);
                    txtInstruction.Text = ratingscaleinstruction;
                    btnSaveQS.CommandName = RadGrid.PerformInsertCommandName;
                    btnSaveQS.Text = "Add Qualification Statement";
                    //rating scale type - response type is enabled only to Admin & to HR --HR only if the package is not signed
                    if ((base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR) || base.IsSystemAdministrator)
                    { 
                        rcbRatingScaleType.Enabled = true;
                    }
                    else
                    { 
                        rcbRatingScaleType.Enabled = false;
                    }

                    ////Issue 1060 Editable for HR in FinalReview
                    //if ((base.HasHRGroupPermission && CurrentJNPWS == enumJNPWorkflowStatus.FinalReview && !CurrentJNP.IsJNPSignedByHR))
                    //{
                    //    rcbRatingScaleType.Enabled = true;
                    //}


                    if (gridQuestions.Items.Count <= 0)
                    {
                        this.gridQuestions.MasterTableView.NoMasterRecordsText = "";
                        this.gridQuestions.MasterTableView.EnableNoRecordsTemplate = false;
                    }


                    AppointmentEligibiltyManager AppEligMgr = new AppointmentEligibiltyManager();
                    List<AppointmentEligibilty> ApptElig = AppEligMgr.GetAllActiveAppointmentEligibiltyQuestion();

                    ApptElig = AppEligMgr.FilterAddedApptEligibilityQuestions(ApptElig, (List<JQFactorItemEntity>)this.gridQuestions.DataSource);
                
                    ControlUtility.BindRadComboBoxControlWithBackground(rcbApptEligQuestion, ApptElig, null, "AEQuestion", "AEQuestionID", "[-- Select Appointment Eligibility Question --]");

                    enumJQFactorType selectedFactorType = (enumJQFactorType)int.Parse(rcbFactorTypes.SelectedValue);

                    if (selectedFactorType == enumJQFactorType.AppointmentEligibility)
                    {
                        System.Web.UI.HtmlControls.HtmlTableRow ApptEligRow = editform.FindControl("ApptEligRow") as System.Web.UI.HtmlControls.HtmlTableRow;

                        if (ApptEligRow != null)
                        {
                            ApptEligRow.Visible = true;
                            btnSaveQS.Enabled = false;
                        }
                    }
                   
                    CurrentMode = eMode.Insert;
                     
                }
                //edit/view mode
                if (griditem.DataItem is JQFactorItemEntity)
                {
                    CurrentMode = eMode.Edit;
                    JQFactorItemEntity entity = griditem.DataItem as JQFactorItemEntity;
                    txtQuestion.Text = entity.ItemText;
                    rcbRatingScaleType.SelectedValue = entity.RatingScaleTypeID.ToString();
                    JQFactorID = entity.FactorID;
                    this.CurrentJQFactorID = entity.FactorID;
                    this.CurrentRatingScaleID = entity.RatingScaleID;
                    this.CurrentRatingScaleTypeID = entity.RatingScaleTypeID;
                    txtInstruction.Text = entity.RatingScaleInstruction;
                    gridResponses.Rebind();


                    if (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview)
                    {
                        if (base.IsAdmin)
                        {
                            txtInstruction.ReadOnly = false;
                        }
                        else if (base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR)
                        {
                            txtInstruction.ReadOnly = false;
                        }
                    }

                    rcbRatingScaleType.SelectedValue = entity.RatingScaleTypeID.ToString();
                    btnSaveQS.CommandName = RadGrid.UpdateCommandName;
                    btnSaveQS.Text = "Save Qualification Statement";
                    //rating scale type - response type is enabled only to Admin & to HR --HR only if the package is not signed
                    if ((base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR) || base.IsSystemAdministrator)
                    {
                        rcbRatingScaleType.Enabled = true;
                    }
                    else
                    {
                        rcbRatingScaleType.Enabled = false;
                    }
                    if (IsInView)
                    {
                        btnSaveQS.Enabled = false;
                        rcbRatingScaleType.Enabled = false;
                        txtQuestion.ReadOnly = true;
                        txtInstruction.ReadOnly = true;
                    }

                    //In Revise custom response type can only be modified by Admin/HR until package is signed
                    //In Revise HM can not edit/delete custom responses
                    if (!base.IsAdmin && currentws == enumJNPWorkflowStatus.Revise && !base.HasHRGroupPermission)
                    {
                        if (rcbRatingScaleType.SelectedValue == Convert.ToInt32(enumRatingScaleType.CustomYN).ToString() || rcbRatingScaleType.SelectedValue == Convert.ToInt32(enumRatingScaleType.CustomMultiChoice).ToString())
                        {
                            gridResponses.Columns[0].Visible = false;//edit
                            gridResponses.Columns[1].Visible = false;//delete
                        }
                    }

                    RadSpell rs = griditem.FindControl("RadSpellQualifyingStatements") as RadSpell;

                    if (IsInView)
                    {
                        if (rs != null) rs.Visible = false;
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
            
            RadTextBox txtQuestion = editform.FindControl("txtQuestion") as RadTextBox;
            RadComboBox rcbRatingScaleType = editform.FindControl("rcbRatingScaleType") as RadComboBox;
            RadTextBox txtInstruction = editform.FindControl("txtInstruction") as RadTextBox;

            RadComboBox rcbApptEligQuestion = editform.FindControl("rcbApptEligQuestion") as RadComboBox;

            int ratingScaleTypeID = int.Parse(rcbRatingScaleType.SelectedValue);
            string ratingScaleInstruction = txtInstruction.Text;
            entity.RatingScaleTypeID = ratingScaleTypeID;
            entity.IsDefault = (ratingScaleTypeID == (int)enumRatingScaleType.DefaultYN || ratingScaleTypeID == (int)enumRatingScaleType.DefaultMultiChoice) ? true : false;
            entity.ItemText = txtQuestion.Text;
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
                //setting taskstatement id equal to "Other" - 0
                entity.TaskStatementID = 0;//Convert.ToInt64(rcbTaskStatements.SelectedValue);

                entity.AEQuestionID = int.Parse(rcbApptEligQuestion.SelectedValue);
            }
        }

        protected void gridQuestions_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            {
                GridEditFormItem editform = (GridEditFormItem)e.Item;
                
                RadComboBox rcbTaskStatements = editform.FindControl("rcbTaskStatements") as RadComboBox;
                RadComboBox rcbRatingScaleType = editform.FindControl("rcbRatingScaleType") as RadComboBox;
                Button btnAddToLibrary = editform.FindControl("btnAddToLibrary") as Button;              
                rcbRatingScaleType.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbRatingScaleType_SelectedIndexChanged);               
                RadGrid gridResponses = editform.FindControl("gridResponses") as RadGrid;
                gridResponses.ItemDataBound += new GridItemEventHandler(gridResponses_ItemDataBound);
                gridResponses.NeedDataSource += new GridNeedDataSourceEventHandler(gridResponses_NeedDataSource);
                gridResponses.ItemCommand += new GridCommandEventHandler(gridResponses_ItemCommand);
                gridResponses.UpdateCommand += new GridCommandEventHandler(gridResponses_UpdateCommand);
                gridResponses.DeleteCommand += new GridCommandEventHandler(gridResponses_DeleteCommand);
                gridResponses.PreRender += new EventHandler(gridResponses_PreRender);

                RadComboBox rcbApptEligQuestion = editform.FindControl("rcbApptEligQuestion") as RadComboBox;
                rcbApptEligQuestion.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbApptEligQuestion_SelectedIndexChanged);

              }
        }
        
        protected void gridQuestions_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            this.gridQuestions.DataSource = jqm.GetJQFactorItemsByJQFactorID(this.JQFactorID);

            
        }
        
        protected void gridQuestions_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            {
                SetEditForm(sender, e);
            }
            
        }

        protected void gridQuestions_ItemCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem gridItem;
            switch (e.CommandName)
            {
                case RadGrid.PerformInsertCommandName:
                    AddQuestion(sender, e);
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
                default:
                    break;
            }

            if (gridQuestions.Items.Count <= 0)
            {
                this.gridQuestions.MasterTableView.NoMasterRecordsText = "No records to display.";
                this.gridQuestions.MasterTableView.EnableNoRecordsTemplate = true;
            }
        } 

        protected void gridQuestions_PreRender(object sender, EventArgs e)
        {
            
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
                //btnSave.Enabled  = false;

                //Issue 1064 - Hide qualification save/update message while attempting to add qualification statement.
                lblmsg.Text = "";
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
                //bool blnSaveEnable = (base.CurrentNavMode != enumNavigationMode.View) && (base.IsAdmin || (base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR));
                //btnSave.Enabled = blnSaveEnable;
                
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
            Label lblmsgQS = editform.FindControl("lblmsgQS") as Label;
            int ratingScaleTypeID = int.Parse(rcbRatingScaleType.SelectedValue);
            long jqfactoritemid = (long)editform.GetDataKeyValue("ID");
            if (jqfactoritemid > 0)
            {
                try
                {
                    JQFactorItemEntity entity = jqm.GetJQFactorItemByID(jqfactoritemid);
                    int oldRatingScaleTypeID = entity.RatingScaleTypeID;
                    AssignJQFactorItemEntityValues(entity, editform);
                    jqm.UpdateJQFactorItem(entity, CurrentUserID);

                    // check if rating scale was changed by the user and delete the responses if that is the case
                    if (oldRatingScaleTypeID != entity.RatingScaleTypeID)
                    {
                        jqm.DeleteAllRatingScaleResponses(entity.ID, this.CurrentUserID);

                        //5 - Multiple Qual ; 6 - Custum Multiple Qual
                        //if (ratingScaleTypeID == 6) ratingScaleTypeID = 5;

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
            try
            {
                GridEditFormItem editform = (GridEditFormItem)e.Item;
                AddQuestion(sender, editform, false);
                e.Item.Edit = true;

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        protected void AddQuestion(object sender, GridEditFormItem editform, bool blnKeepInEditMode)
        {
            try
            {
                JQFactorItemEntity entity = new JQFactorItemEntity();
                AssignJQFactorItemEntityValues(entity, editform);
                JQFactorItemID = jqm.AddQuestionWithRatingScale(entity, entity.RatingScaleInstruction, CurrentUserID);
                CurrentRatingScaleTypeID = entity.RatingScaleTypeID;
                CurrentRatingScaleID = entity.RatingScaleID;
                gridQuestions.MasterTableView.IsItemInserted = false;
                CurrentMode = eMode.Edit;
                //need to rebind here before setting the grid in editmode 
                //If you don't rebind before setting the grid in edit mode 
                //-- then when you are inserting the first record -Current grid will not have any editable items in
                // collection and there by will not call set editforms and will close the form.
                //also when you are inserting the second record, it will call the seteditform with editable item
                //as first item and will display first questions' information in the second question. 
                
                gridQuestions.Rebind();
                
                if (blnKeepInEditMode)
                {
                    SetGridInEditMode(gridQuestions);
                   
                }
               
                Label lblmsgQS = editform.FindControl("lblmsgQS") as Label;
                if (lblmsgQS != null)
                {
                    lblmsgQS.Text = "Qualification Statement added successfully.";
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        protected void rcbRatingScaleType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int ratingScaleTypeID = int.Parse(e.Value);
            // getting the default rating scale instructions based on the rating scale type
            //otherwise it was not setting the correct instruction if the new rating scale type was custom
            string ratingscaleinstruction = jqm.GetDefaultJQRatingScaleInstructionByRatingScaleType(ratingScaleTypeID);
            
            RadComboBox cmd = (RadComboBox)sender;
            GridEditFormItem editform = (GridEditFormItem)cmd.NamingContainer;
           
           
            if (editform != null)
            {
                RadTextBox txtQuestion = editform.FindControl("txtQuestion") as RadTextBox;
                RadTextBox txtInstruction = editform.FindControl("txtInstruction") as RadTextBox;
                RadGrid gridResponses = editform.FindControl("gridResponses") as RadGrid;
                txtInstruction.Text = ratingscaleinstruction;
                gridResponses.Visible = false;
                if ((ratingScaleTypeID == (int)enumRatingScaleType.DefaultMultiChoice) ||
                     (ratingScaleTypeID == (int)enumRatingScaleType.DefaultYN))
                {
                    txtInstruction.ReadOnly = true;
                }
                else
                {
                    txtInstruction.ReadOnly = false;
                }

                //if (string.IsNullOrEmpty(txtQuestion.Text))
                //{

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
                else
                {

                    if (CurrentMode == eMode.Insert)
                    {
                        // Save the task statement when user select response type
                        AddQuestion(sender, editform, true);
                    }

                    else
                    {
                        UpdateQuestion(sender, editform);
                    }
                }
            }

        }
        protected void rcbApptEligQuestion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {           
            RadComboBox cmd = (RadComboBox)sender;
            GridEditFormItem editform = (GridEditFormItem)cmd.NamingContainer;
            RadTextBox txtQuestion = editform.FindControl("txtQuestion") as RadTextBox;
            Button btnSaveQS = editform.FindControl("btnSaveQS") as Button;

            if (editform != null)
            {
                txtQuestion.Text = cmd.Text;
            }

            if (Convert.ToInt32(cmd.SelectedValue) == -1)
            {
                txtQuestion.Text = "";

                if (btnSaveQS != null)
                    btnSaveQS.Enabled = false;
            }
            else if (Convert.ToInt32(cmd.SelectedValue) == 0)
            {
                txtQuestion.Text = "";

                if (btnSaveQS != null)
                    btnSaveQS.Enabled = true;
            }
            else
            {
                if(btnSaveQS != null)
                    btnSaveQS.Enabled = true;
            }
        }
        
        private void BindMinQualHyperLink()
        {

            JNPackage jnpPackage = new JNPackage(base.CurrentJNPID);
            Series series = new Series(jnpPackage.SeriesID);
            string urlhlMinimumQualifications = string.Format("~/CR/MinimumQualifications.aspx");
            hlMinimumQualifications.NavigateUrl = urlhlMinimumQualifications;
            hlMinimumQualifications.Attributes.Add("onClick", "javascript:ShowMinimumQualificationsPopUp(" + series.SeriesID + "," + series.TypeOfWorkID + "," + jnpPackage.HighestAdvertisedGrade + ",'" + CurrentNavMode  + "'); return false;");

            hlMinimumQualifications2.NavigateUrl = urlhlMinimumQualifications;
            hlMinimumQualifications2.Attributes.Add("onClick", "javascript:ShowMinimumQualificationsPopUp(" + series.SeriesID + "," + series.TypeOfWorkID + "," + jnpPackage.HighestAdvertisedGrade + ",'" + CurrentNavMode + "'); return false;");
        }

        //Keshab - This function is no longer valid for current business design hence needs to be removed.
        private void ShowQuestion(object source, GridCommandEventArgs e)
        {
            RWM.Windows.Clear();
            GridDataItem gridItem;
            string script = string.Empty;

            string navigateurl = string.Empty;
            lblmsg.Text = string.Empty;
            long questionID = -1;
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    script = string.Format("ShowQuestionWindowClient('{0}','{1}');", "Insert", JQFactorID);
                    break;
                case RadGrid.EditCommandName:
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    questionID = long.Parse(gridItem.GetDataKeyValue("ID").ToString());
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


        #region Responses Grid events
        private List<RatingScaleResponseEntity> GetResponses(long ratingscaleid)
        {
            List<RatingScaleResponseEntity> items = new List<RatingScaleResponseEntity>();
            if (ratingscaleid > 0)
            {
                items = jqm.GetDefaultReponsesForQuestionByRatingScaleID(ratingscaleid);
            }
            return items;
        }

        protected void gridResponses_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {

            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;

                if (!(item is GridDataInsertItem))
                {
                    Label lbl = (Label)item["TemplateResponseLetter"].FindControl("lblRatingScaleTypeID");
                    int ratingScaleTypeID = int.Parse(lbl.Text);


                    if (base.IsAdmin || base.HasHRGroupPermission)
                    {
                        if ((ratingScaleTypeID == (int)enumRatingScaleType.DefaultMultiChoice) ||
                                 (ratingScaleTypeID == (int)enumRatingScaleType.DefaultYN) || ratingScaleTypeID == (int)enumRatingScaleType.MultipleChoiceQual)
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
            var gridResponses = sender as RadGrid;
            gridResponses.DataSource = GetResponses(CurrentRatingScaleID);

        }

        protected void gridResponses_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                GridDataInsertItem gridItem = (GridDataInsertItem)e.Item;

                RadTextBox txtResponseLetter = gridItem.FindControl("txtResponseLetter") as RadTextBox;
                RadTextBox txtResponseText = gridItem.FindControl("txtResponseText") as RadTextBox;

                RatingScaleResponseEntity entity = new RatingScaleResponseEntity();
                entity.ResponseLetter = txtResponseLetter.Text;
                entity.ResponseText = txtResponseText.Text;
                entity.RatingScaleID = CurrentRatingScaleID;
                entity.ID = jqm.AddRatingScaleResponse(entity, this.CurrentUserID);
                BindData();
            }

        }

        protected void gridResponses_PreRender(object sender, EventArgs e)
        {
            var gridResponses = sender as RadGrid;
            GridItem[] gridcommanditems = gridResponses.MasterTableView.GetItems(GridItemType.CommandItem);
            if (CurrentNavMode==enumNavigationMode.View)
            {
                gridResponses.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                gridResponses.Columns[0].Display = false; //edit
                gridResponses.Columns[1].Display = false;//delete

            }
            else
            {
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
                //if ((ratingScaleTypeID == (int)enumRatingScaleType.CustomYN) ||
                //    (ratingScaleTypeID == (int)enumRatingScaleType.CustomMultiChoice))
                    if ((ratingScaleTypeID == (int)enumRatingScaleType.CustomYN) ||
                        (ratingScaleTypeID == (int)enumRatingScaleType.CustomMultiChoiceQual))
                {
                    jqm.DeleteRatingScaleResponse(jqResponseID);
                }


            }
        }
        #endregion
        
        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {//setting current mode to edit - this prevents system to go in view mode if user cancels out without adding
            if (CurrentNavMode == enumNavigationMode.Insert)
            {
                CurrentNavMode = enumNavigationMode.Edit;
            }
            base.GoToLink("~/JQ/Qualifications.aspx", CurrentNavMode);

        }

        protected void rcbFactorTypes_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (int.Parse(e.Value) != -1)
            {
                this.txtTitle.Text = rcbFactorTypes.SelectedItem.Text;
                RadEditQualificationInstruction.Content = rcbFactorTypes.SelectedItem.Text;

                if (int.Parse(rcbFactorTypes.SelectedValue) == (int)enumJQFactorType.MinimumQualification )
                {
                    hlMinimumQualifications.Visible = true;
                    ToolTipMinQual.Visible = true;
                    BindMinQualHyperLink();
                }
                else
                {
                    hlMinimumQualifications.Visible = false;
                    ToolTipMinQual.Visible = false;
                }
            }

            if (rcbFactorTypes.SelectedValue == "-1")
            {
                btnSave.Enabled = false;
                this.txtTitle.Text = "";
                RadEditQualificationInstruction.Content = "";
                hlMinimumQualifications.Visible = false;
                ToolTipMinQual.Visible = false;
            }
            else
                btnSave.Enabled = true;
        }
        
    }
}

