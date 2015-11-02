﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.JQ;
using HCMS.Business.Lookups;
using HCMS.Business.Admin;
using System;

namespace HCMS.JNP.Controls.JQ
{
    public partial class ctrlAddEditKSAQuestion : JNPUserControlBase
    {
        private JQManager jqm = new JQManager();
        private bool isDisplayCRUDColumns = true;

        #region Events/Delegates
        public delegate void NonExistentJQFactorItemHandler();
        public event NonExistentJQFactorItemHandler NonExistentJQFactorItemEncountered;
        #endregion
        #region [Private Properties]

        private eMode CurrentMode
        {
            get
            {
                if (ViewState["CurrentMode"] == null)
                {
                    string currentMode = Request.QueryString["Mode"];
                    if (string.IsNullOrEmpty(currentMode) || currentMode.Equals("View"))
                    {
                        ViewState["CurrentMode"] = eMode.View;
                    }
                    else
                    {
                        if (currentMode.Equals("Insert"))
                        {
                            ViewState["CurrentMode"] = eMode.Insert;
                        }
                        else
                        {
                            ViewState["CurrentMode"] = eMode.Edit;
                        }

                    }
                }
                return (eMode)ViewState["CurrentMode"];
            }
            set { ViewState["CurrentMode"] = value; }
        }

        private long JQFactorID
        {
            get
            {
                if (ViewState["JQFactorID"] == null)
                {
                    string JQFactorIDParam = Request.QueryString["JQFactorID"];

                    if (String.IsNullOrEmpty(JQFactorIDParam))
                        ViewState["JQFactorID"] = -1;
                    else
                        ViewState["JQFactorID"] = long.Parse(JQFactorIDParam);
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
                if (ViewState["JQFactorItemID"] == null)
                {
                    string JQFactorItemIDParam = Request.QueryString["JQFactorItemID"];

                    if (String.IsNullOrEmpty(JQFactorItemIDParam))
                        ViewState["JQFactorItemID"] = -1;
                    else
                        ViewState["JQFactorItemID"] = long.Parse(JQFactorItemIDParam);
                }
                return (long)ViewState["JQFactorItemID"];

            }
            set
            {
                ViewState["JQFactorItemID"] = value;
            }
        }

        private int JQRatingScaleTypeID
        {
            get
            {

                if (ViewState["JQRatingScaleTypeID"] == null)
                {

                    ViewState["JQRatingScaleTypeID"] = 0;

                }
                return (int)ViewState["JQRatingScaleTypeID"];

            }
            set
            {
                ViewState["JQRatingScaleTypeID"] = value;
            }
        }

        //added CurrentRsID (viewstate prop) - that replaces the session level -CurrentRatingScaleID prop of JNPUsercontrolBase 
        //CurrentRatingScaleID was causing issue
        //JA issue id 446: Once edits are made to instructions of either of the Customs, 
        //the instructions are replicated for the other custom. 
        private long CurrentRsID
        {
            get
            {
                long id = -1;

                if (ViewState["CurrentRsID"] != null)
                {
                    id = (long)ViewState["CurrentRsID"];
                }

                return id;
            }
            set
            {
                ViewState["CurrentRsID"] = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitTaskStatements();
                InitRatingScaleTypes();

                if (CurrentMode == eMode.Insert)
                {
                    JQFactorItemID = -1;
                    this.divSection.Visible = false;
                    this.gridResponses.Visible = false;
                    this.trTaskStatementSelection.Visible = true;
                    this.rcbRatingScaleType.SelectedValue = ((int)enumRatingScaleType.DefaultMultiChoice).ToString();

                    string ratingscaleinstruction = jqm.GetDefaultJQRatingScaleInstructionByRatingScaleType((int)enumRatingScaleType.DefaultMultiChoice);
                    txtInstruction.Text = ratingscaleinstruction;     

                    this.RequiredFieldValidatorTaskStatments.Enabled = true;
                }
                else if (CurrentMode == eMode.Edit)
                {
                    this.divSection.Visible = true;
                    this.gridResponses.Visible = true;
                    this.trTaskStatementSelection.Visible = true;
                    this.RequiredFieldValidatorTaskStatments.Enabled = false;
                    BindData();

                }
                else if (CurrentMode == eMode.View)
                {
                    this.divSection.Visible = true;
                    this.gridResponses.Visible = true;
                    this.trTaskStatementSelection.Visible = true;
                    this.RequiredFieldValidatorTaskStatments.Enabled = false;
                    BindData();
                    DisableControls();
                }

                if ((this.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR) || base.IsAdmin)
                {
                    this.rcbRatingScaleType.Enabled = true;
                }

                if(CurrentMode == eMode.View)
                {
                    this.rcbRatingScaleType.Enabled = true;
                }
            }
        }

        private void InitTaskStatements()
        {
            rcbTaskStatements.Items.Clear();
            RadComboBoxItem defaultItem = new RadComboBoxItem("Please Select...", "-1");
            rcbTaskStatements.Items.Insert(0, defaultItem);

            List<TSEntity> items = jqm.GetTaskStatementsByKSAIDAndJQID(this.CurrentKSAID, this.CurrentJQID);
            if (items.Count > 0)
            {
                foreach (TSEntity item in items)
                {
                    rcbTaskStatements.Items.Add(new RadComboBoxItem(item.TaskStatement , item.TaskStatementID .ToString()));
                }
            }
        }

        private void InitRatingScaleTypes()
        {
            rcbRatingScaleType.DataSource = LookupManager.GetAllRatingScaleTypes();
            rcbRatingScaleType.DataValueField = "ID";
            rcbRatingScaleType.DataTextField = "Name";
            rcbRatingScaleType.DataBind();
        }

        #region [KSA Related]

        private void BindData()
        {
            gridResponses.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;

            if (JQFactorItemID == -1)
            {
                if (NonExistentJQFactorItemEncountered != null)
                    NonExistentJQFactorItemEncountered();
            }
            else
            {
                JQFactorItemEntity entity = jqm.GetJQFactorItemByID(JQFactorItemID);
                txtQuestion.Text = entity.ItemText;
                rcbRatingScaleType.SelectedValue = entity.RatingScaleTypeID.ToString();
                JQRatingScaleTypeID = entity.RatingScaleTypeID;
                this.CurrentRsID  = entity.RatingScaleID;
                JQFactorID = entity.FactorID;
                this.CurrentJQFactorID = entity.FactorID;
                JQRatingScaleEntity ratingScaleEntity = jqm.GetJQRatingScaleByID(this.CurrentRsID);
                txtInstruction.Text = ratingScaleEntity.RatingScaleInstruction;

                // only HR users can edit instructions for existing custom responses and also create new custom responses
                if (!entity.IsDefault && (base.CurrentUser.HasPermission(enumPermission.MaintainHRSection)||base.IsSystemAdministrator ))
                {
                    txtInstruction.ReadOnly = false;

                    gridResponses.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.Top;
                }
                else
                {
                    txtInstruction.ReadOnly = true;
                }


                gridResponses.Rebind();
                gridResponses.Columns[0].Display = isDisplayCRUDColumns; //edit column
                //if there are only two responses don't display the delete column
                //minimum two responses are required
                if (gridResponses.MasterTableView.Items.Count == 2)
                {
                    gridResponses.Columns[1].Display = false; //delete column
                }
                else
                {
                    gridResponses.Columns[1].Display = isDisplayCRUDColumns; //delete column

                }

                if (CurrentNavMode == enumNavigationMode.Edit)
                {

                    if ((base.HasHRGroupPermission && !CurrentJNP.IsJNPSignedByHR) || base.IsSystemAdministrator)
                    {
                        if (entity.TaskStatementID == 0)
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
                        btnAddToLibrary.Visible = false;
                    }
                }
                else
                {
                    btnAddToLibrary.Visible = false;
                }
            }
        }

        private void DisableControls()
        {
            btnSave.Enabled = false;

            if (isDisplayCRUDColumns) // meaning crud columns will be present
            {
                gridResponses.Columns[0].Display = false;
                gridResponses.Columns[1].Display = false;
            }

            rcbTaskStatements.Enabled = false;
            txtQuestion.Enabled = false;
            rcbRatingScaleType.Enabled = false;
            txtInstruction.Enabled = false;
        }

        private void AssignValues(JQFactorItemEntity entity)
        {
            int ratingScaleTypeID = int.Parse(rcbRatingScaleType.SelectedValue);

            entity.ID = JQFactorItemID;
            entity.FactorID = this.CurrentJQFactorID;
            entity.ParentItemID = -1;
            entity.ItemTypeID = (int)enumJQItemType.Question;
            entity.ItemNo = -1;
            entity.ItemLetter = string.Empty;
            entity.ItemText = txtQuestion.Text;
            entity.RatingScaleID = -1;
            entity.RatingScaleTypeID = ratingScaleTypeID;
            entity.RatingScaleName = string.Empty;
            entity.TaskStatementID = Convert.ToInt64(rcbTaskStatements.SelectedValue);
            entity.IsDefault = (ratingScaleTypeID == (int)enumRatingScaleType.DefaultYN || ratingScaleTypeID == (int)enumRatingScaleType.DefaultMultiChoice) ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            JQFactorItemEntity entity = new JQFactorItemEntity();
            AssignValues(entity);
            string ratingScaleInstruction = txtInstruction.Text;
            try
            {
                if (base.CurrentJQFactorID > 0)
                {
                    if (CurrentMode == eMode.Insert)
                    {
                        base.CurrentJQFactorItemID = JQFactorItemID = entity.ID = jqm.AddQuestionWithRatingScale(entity, ratingScaleInstruction, this.CurrentUserID);
                        if (entity.ID > 0)
                        {
                            lblmsg.Text = "Task Statement added successfully.";
                            CurrentMode = eMode.Edit;
                            //this take care of the issue when they click save and then x out of the window
                            base.CurrentNavMode = enumNavigationMode.Edit;
                            BindData();
                            this.divSection.Visible = true;
                            this.gridResponses.Visible = true;
                        }
                        else
                        {
                            base.PrintErrorMessage("Error adding Task Statement.", false);
                        }
                    }
                    else if (CurrentMode == eMode.Edit)
                    {
                        jqm.UpdateJQFactorItem(entity, this.CurrentUserID);

                        // check if rating scale was changed by the user and delete the responses if that is the case
                        if (JQRatingScaleTypeID != entity.RatingScaleTypeID)
                        {
                            jqm.DeleteAllRatingScaleResponses(entity.ID, this.CurrentUserID);
                            this.CurrentRsID  = jqm.CopyResponsesFromRatingScaleType(entity.ID, JQRatingScaleTypeID, entity.RatingScaleTypeID, this.CurrentUserID);
                        }

                        // update the instruction - only HR users can edit instructions for custom responses
                        if (!entity.IsDefault && (base.CurrentUser.HasPermission(enumPermission.MaintainHRSection)||base.IsSystemAdministrator ))
                        {
                            jqm.UpdateJQRatingScaleInstruction(this.CurrentRsID, txtInstruction.Text, this.CurrentUserID);
                        }

                        BindData();
                        lblmsg.Text = "Task Statement updated successfully.";
                        this.divSection.Visible = true;
                        this.gridResponses.Visible = true;
                    }
                }
                else
                {
                    base.PrintErrorMessage("Current Job Questionnaire Factor is not set", false);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region Responses Grid events
        
        protected void gridResponses_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
           
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;

                if (!(item is GridDataInsertItem))
                {
                    Label lbl = (Label)item["TemplateResponseLetter"].FindControl("lblRatingScaleTypeID");
                    int ratingScaleTypeID = int.Parse(lbl.Text);

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
            }
        }

        protected void gridResponses_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            List<RatingScaleResponseEntity> items = new List<RatingScaleResponseEntity>();
            items = jqm.GetDefaultReponsesForQuestionByRatingScaleID(this.CurrentRsID);

            // in the case of "Custom Yes/No' only enable the "Add Responses" button if there are no more than 2 responses in the list
            if (JQRatingScaleTypeID == (int)enumRatingScaleType.CustomYN && (base.CurrentUser.HasPermission(enumPermission.MaintainHRSection )||base.IsSystemAdministrator ))
            {
                if (items.Count > 1)
                {
                    gridResponses.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                }
            }
            //if there are only two responses don't display the delete column
            //minimum number of required responses are two
            if (items.Count == 2)
            {
                gridResponses.Columns[1].Display = false;
            }

            this.gridResponses.DataSource = items;
        }

        protected void gridResponses_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                GridDataInsertItem gridItem = (GridDataInsertItem)e.Item;

                RadTextBox txtResponseLetter = gridItem.FindControl("txtResponseLetter") as RadTextBox;
                RadTextBox txtResponseText = gridItem.FindControl("txtResponseText") as RadTextBox;

                RatingScaleResponseEntity entity = new RatingScaleResponseEntity();
                entity.RatingScaleID = this.CurrentRsID;
                entity.ResponseLetter = txtResponseLetter.Text;
                entity.ResponseText = txtResponseText.Text;

                entity.ID = jqm.AddRatingScaleResponse(entity, this.CurrentUserID);

                BindData();
            }
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

            gridResponses.Rebind();
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

                BindData();
            }
        }
        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = string.Empty;
            switch (this.CurrentMode)
            {
                case eMode.None:
                    break;
                case eMode.Edit:
                case eMode.Insert:
                    base.CurrentJQFactorID = this.JQFactorID;
                    base.CurrentJQFactorItemID = this.JQFactorItemID;
                    base.CurrentNavMode = enumNavigationMode.Edit;
                    break;
                //commenting setting the currentnav mode when in view
                //becasue jq can be in view mode (if package was created from existing package)
                //but actual navigation  mode can be edit                  
                //setting currentNavMode to view  was causing issue 95-moving from editable section of a package to a read-only section
                //and then back to an editable section leaves the package in read-only mode 
                //case eMode.View:
                //    base.CurrentNavMode = enumNavigationMode.View;
                //break;
                default:
                    break;
            }
            script = string.Format("EditQuestionClose();");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnAddToLibraryOk_Click(object sender, EventArgs e)
        {
            long returnCode = -1;
            rwAddToLibrary.VisibleOnPageLoad = false;
            JQManager jqMgr = new JQManager();
            JQFactorEntity jqFactor = jqMgr.GetJQFactorByJQFactorID(this.JQFactorID);
            JQFactorItemEntity jqFactorItem = jqMgr.GetJQFactorItemByID(this.JQFactorItemID);
            if (jqFactor.KSAID == 0)
            {
                returnCode = JQManager.AddKSATaskStatementToLibrary(jqFactor.Title, jqFactorItem.ItemText, jqFactor, jqFactorItem, CurrentJNP.SeriesID, CurrentJNP.HighestAdvertisedGrade, this.CurrentUserID);
                if (returnCode > 0)
                {
                    lblmsg.Text = "Added KSA and Task Statment To Library Sucessfully.";
                }
                else
                {
                    lblmsg.Text = "Sorry, Could Not Add KSA and Task Statment to Library!";
                }
            }
            else
            {
                returnCode = JQManager.AddTaskStatementToLibrary(jqFactorItem.ItemText, jqFactorItem, CurrentJNP.SeriesID, CurrentJNP.HighestAdvertisedGrade, jqFactor.KSAID, this.CurrentUserID);
                if (returnCode > 0)
                {
                    lblmsg.Text = "Added Task Statment To Library Sucessfully.";
                }
                else
                {
                    lblmsg.Text = "Sorry, Could Not Add Task Statment to Library!";
                }
            }

            InitTaskStatements();
            btnAddToLibrary.Visible = false;
        }

        protected void btnAddToLibraryCancel_Click(object sender, EventArgs e)
        {
            rwAddToLibrary.VisibleOnPageLoad = false;
            BindData();
        }
        protected void rcbTaskStatements_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int index = int.Parse(e.Value);

            if (index > 0)
            {
                this.txtQuestion.Text = rcbTaskStatements.SelectedItem.Text;
            }
        }

        protected void rcbRatingScaleType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            
            lblmsg.Text = string.Empty;
            this.divSection.Visible = false;
            this.gridResponses.Visible = false;
            int ratingScaleTypeID = int.Parse(e.Value);
            // getting the default rating scale instructions based on the rating scale type
            //otherwise it was not setting the correct instruction if the new rating scale type was custom
            string ratingscaleinstruction = jqm.GetDefaultJQRatingScaleInstructionByRatingScaleType(ratingScaleTypeID);
            txtInstruction.Text = ratingscaleinstruction;

            if ((ratingScaleTypeID == (int)enumRatingScaleType.DefaultMultiChoice) ||
                 (ratingScaleTypeID == (int)enumRatingScaleType.DefaultYN))
            {
                txtInstruction.ReadOnly = true;
            }
            else
            {
                txtInstruction.ReadOnly = false;
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
        }

    }
}
