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
using HCMS.Business.Lookups;

namespace HCMS.JNP.Controls.JQ
{
    public partial class ctrlAddEditQuestion : JNPUserControlBase
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
                InitRatingScaleTypes();

                if (CurrentMode == eMode.Insert)
                {
                    JQFactorItemID = -1;
                    this.questionDetail.Visible = false;
                    int ratingScaleTypeID = int.Parse(rcbRatingScaleType.SelectedValue);
                    string ratingscaleinstruction = jqm.GetDefaultJQRatingScaleInstructionByRatingScaleType(ratingScaleTypeID);
                    txtInstruction.Text = ratingscaleinstruction;                   

                }
                else if (CurrentMode == eMode.Edit)
                {
                    this.questionDetail.Visible = true;
                    BindData();

                }
                else if (CurrentMode == eMode.View)
                {
                    this.questionDetail.Visible = true;
                    BindData();
                    DisableControls();
                }
            }
        }

        #region [Question- FactorItem Related]

        private void InitRatingScaleTypes()
        {
            rcbRatingScaleType.DataSource = LookupManager.GetAllRatingScaleTypes();
            rcbRatingScaleType.DataValueField = "ID";
            rcbRatingScaleType.DataTextField = "Name";
            rcbRatingScaleType.DataBind();
        }

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
                this.CurrentRsID = entity.RatingScaleID;
                JQFactorID = entity.FactorID;
                this.CurrentJQFactorID = entity.FactorID;
                JQRatingScaleEntity ratingScaleEntity = jqm.GetJQRatingScaleByID(this.CurrentRsID);
                txtInstruction.Text = ratingScaleEntity.RatingScaleInstruction;

                // only HR users can edit instructions for existing custom responses and also create new custom responses
                if (!entity.IsDefault && (base.CurrentUser.HasPermission(enumPermission.MaintainHRSection)|| base.IsSystemAdministrator))
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
                
                if (gridResponses.MasterTableView.Items.Count == 2)
                {
                    gridResponses.Columns[1].Display = false;
                }
                else
                {
                    gridResponses.Columns[1].Display = isDisplayCRUDColumns; //delete column

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

            txtQuestion.Enabled = false;
            rcbRatingScaleType.Enabled = false;
            txtInstruction.ReadOnly = true;
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
            entity.IsDefault = (ratingScaleTypeID == (int)enumRatingScaleType.DefaultYN || ratingScaleTypeID == (int)enumRatingScaleType.DefaultMultiChoice) ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            JQFactorItemEntity entity = new JQFactorItemEntity();
            AssignValues(entity);
            string ratingScaleInstruction=txtInstruction.Text;
            try
            {
                if (base.CurrentJQFactorID > 0)
                {
                    if (CurrentMode == eMode.Insert)
                    {
                        //JA issue id 455: JQ Qualification/KSA: Adding question and selecting custom instruction, selecting save overrides custom instructions to defaul instruction
                        base.CurrentJQFactorItemID = JQFactorItemID = entity.ID = jqm.AddQuestionWithRatingScale(entity, ratingScaleInstruction, this.CurrentUserID);
                        if (entity.ID > 0)
                        {
                            lblmsg.Text = "Task Statement added successfully.";
                            CurrentMode = eMode.Edit;
                            base.CurrentNavMode = enumNavigationMode.Edit;
                            BindData();
                            this.questionDetail.Visible = true;
                        }
                        else
                        {
                            base.PrintErrorMessage("Error adding Task Statement.",false);
                        }
                    }
                    else if (CurrentMode == eMode.Edit)
                    {
                        jqm.UpdateJQFactorItem(entity, this.CurrentUserID);

                        // check if rating scale was changed by the user and delete the responses if that is the case
                        if (JQRatingScaleTypeID != entity.RatingScaleTypeID)
                        {
                            jqm.DeleteAllRatingScaleResponses(entity.ID, this.CurrentUserID);
                            this.CurrentRsID = jqm.CopyResponsesFromRatingScaleType(entity.ID, JQRatingScaleTypeID, entity.RatingScaleTypeID, this.CurrentUserID);
                        }

                        // update the instruction - only HR users can edit instructions for custom responses
                        if (!entity.IsDefault && (base.CurrentUser.HasPermission(enumPermission.MaintainHRSection) || base.IsSystemAdministrator ))
                        {
                            jqm.UpdateJQRatingScaleInstruction(this.CurrentRsID, txtInstruction.Text, this.CurrentUserID);
                        }

                        BindData();
                        lblmsg.Text = "Task Statement updated successfully.";
                        this.questionDetail.Visible = true;
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
        private void HideRefreshButton(GridItemEventArgs e)
        {
            GridItem gridItem = e.Item;
            //hide the refresh button Telerik.Web.UI.GridLinkButton
            if (gridItem is GridCommandItem)
            {
                gridItem.FindControl("RebindGridButton").Visible = false;

            }
        }
        protected void gridResponses_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {               
            HideRefreshButton(e);

            if (e.Item is GridDataItem )
            {
                GridDataItem item = (GridDataItem)e.Item;

                if (!(item is GridDataInsertItem ))
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
            if (JQRatingScaleTypeID == (int)enumRatingScaleType.CustomYN && ( base.CurrentUser.HasPermission(enumPermission.MaintainHRSection)||base.IsSystemAdministrator ))
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

        protected void gridResponses_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if(e.CommandName == RadGrid.PerformInsertCommandName)
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

            jqm.UpdateRatingScaleResponse(entity,  this.CurrentUserID);

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
                //    break;
                default:
                    break;
            }
            script = string.Format("EditQuestionClose();");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void rcbRatingScaleType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            lblmsg.Text = string.Empty;
            this.questionDetail.Visible = false;
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
    }
}

