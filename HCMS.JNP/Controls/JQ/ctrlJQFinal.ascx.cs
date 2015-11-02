using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.JQ;
using HCMS.Business.JNP;
using HCMS.Business.JQ.Collections;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.Business.PD;
using Telerik.Web.UI;

using JNPReports = HCMS.JNP.Reports;
using HCMS.WebFramework.Site.Utilities;
using HCMS.JNP.Controls.Workflow;


namespace HCMS.JNP.Controls.JQ
{
    public partial class ctrlJQFinal : JNPUserControlBase
    {



        #region Events/Delegates

        public delegate void ViewFactorDetailsHandler(long factorID, string factorTitle);
        public event ViewFactorDetailsHandler ViewFactorDetails;

        #endregion

        #region Properties

        private JQFactorCollection Factors
        {
            get
            {
                if (ViewState["Factors"] == null)
                    ViewState["Factors"] = new JQFactorCollection();

                return (JQFactorCollection)ViewState["Factors"];
            }
            set
            {
                ViewState["Factors"] = value;
            }
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            this.gridJQFactors.ItemDataBound += new GridItemEventHandler(gridJQFactors_ItemDataBound);
            this.gridJQFactors.ItemCommand += new GridCommandEventHandler(gridJQFactors_ItemCommand);
            this.gridJQFactors.RowDrop += new GridDragDropEventHandler(gridJQFactors_RowDrop);
            this.buttonSaveOrder.Click += new EventHandler(buttonSaveOrder_Click);
            this.btnPreview.Click += new EventHandler(btnPreview_Click);

            this.ctrlWActManager.DocumentFinalizedEvent += new ctrlWorkflowActionManager.DocumentFinalizeCompleteHandler(ctrlWorkflowActionManager_DocumentFinalizeComplete);
            this.ctrlWActManager.SendForApprovalToHiringManagerEvent += new ctrlWorkflowActionManager.HRSendForApprovalToHiringManagerHandler(ctrlWorkflowActionManager_HRSendForApprovalToHiringManager);
            base.OnInit(e);
        }

        protected void ctrlWorkflowActionManager_HRSendForApprovalToHiringManager()
        {
            try
            {
                SaveOrder(false);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

        }
        protected void ctrlWorkflowActionManager_DocumentFinalizeComplete()
        {
            try
            {
                SaveOrder(false);
                BuildPage();

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public void BuildPage()
        {
            try
            {
                if (base.CurrentJQID == -1)
                    base.PrintErrorMessage(GetGlobalResourceObject("JNPMessages", "JQNotAvailable").ToString(), false);
                else
                {
                    JQManager jm = new JQManager();
                    JobQuestionnaire jqDoc = jm.GetJobQuestionnaire(base.CurrentJQID);

                    if (jqDoc == null || jqDoc.JQID == -1)
                        // Non-existent JQ
                        base.PrintSystemMessage(GetLocalResourceObject("JQIDNotFoundMessage").ToString(), false);
                    else
                    {
                        // load Factors
                        JQFactorCollection listFactors = jm.GetJQFactorCollectionByJQID(base.CurrentJQID);

                        this.Factors = listFactors;
                        //Added this because factor numbers are not aligned properly.
                        SaveOrder(false);
                        //this method will be called from SaveOrder()
                        //bindData(listFactors);
                        SetControls();
                        

                    }
                }



            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }


      

        private void SetControls()
        {

            //find out edit capability of controls other than action dropdown
            //action dropdown should be available even when document is finalized
            //Since we are trying to find out the edit capability of controls other than
            //action dropdown, we don't want to ignoreDocumentFinalize status and therefore 
            //passing ignoreDocumentFinalize=false

            //JA issue : 752: JQ Final KSA screen - HMs see instructions about arrows and abilities to reorder 

            divReorderInstruction.Visible = false; //hide reorder instruction 
            gridJQFactors.ClientSettings.AllowRowsDragDrop = false;
            gridJQFactors.Columns[0].Visible = false;//hide arrow column 
            btnPreview.Enabled = true;
            buttonSaveOrder.Enabled = false; //disable save order
            divPreviewOptions.Visible = false; //do not show option to select report type
            this.ctrlWActManager.Visible = false;
            if (base.ShowEditFields(enumDocumentType.JQ))
            {

                if (base.HasHRGroupPermission)
                {
                    if (!CurrentJNP.IsJNPSignedByHR) //not signed by HR
                    {
                        divReorderInstruction.Visible = true;
                        gridJQFactors.ClientSettings.AllowRowsDragDrop = true;
                        gridJQFactors.Columns[0].Visible = true;//show arrow column
                        buttonSaveOrder.Enabled = true;
                        divPreviewOptions.Visible = true; //show option to select report type
                    }

                }
                //set continue/action dropdown
                SetContinueAndWFActionDD();
            }
            else
            {
                bool isThisLastScreen = (base.LastScreen() == enumLastScreen.JQ);
                this.btnContinue.Visible = !isThisLastScreen;
            }

            
        }

        private void SetContinueAndWFActionDD()
        {
            // Get a fresh JNP load in case some piece has changed since it was cached
            ReloadCurrentJNP(base.CurrentJNPID);
            bool isThisLastScreen = (base.LastScreen() == enumLastScreen.JQ);
            bool isJNPPublished = CurrentJNP.IsPublished();

            this.btnContinue.Visible = !isThisLastScreen;
            this.ctrlWActManager.Visible = base.IsInEdit && isThisLastScreen && !isJNPPublished;
            if (this.ctrlWActManager.Visible) BindActionsDD();
        }

        private void bindData(JQFactorCollection FactorLoadList)
        {
            this.gridJQFactors.DataSource = FactorLoadList;
            this.gridJQFactors.DataBind();
        }

        private void BindActionsDD()
        {
            WorkflowObject wo = new WorkflowObject();
            wo.StaffingObjectID = base.CurrentJNPID;
            wo.StaffingObjectTypeID = enumStaffingObjectType.JNP;
            wo.ParentObjectID = CurrentJNPID;
            wo.ParentObjetTypeID = enumStaffingObjectType.JNP;
            wo.UserID = CurrentUserID;
            this.ctrlWActManager.CurrentWorkflowObject = wo;
            this.ctrlWActManager.BindActions();
        }
        #endregion

        #region RadGrid Events

        private void toggleButtons(bool enableButton)
        {
            this.buttonSaveOrder.Enabled = enableButton;
        }

        private int getNewIndex(ref int destinationIndex, GridDragDropEventArgs e)
        {
            if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                destinationIndex -= 1;

            if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                destinationIndex += 1;

            return destinationIndex;
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
        protected void gridJQFactors_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                HideRefreshButton(e);
                if (e.Item is GridDataItem)
                {
                    JQFactor itemFactor = e.Item.DataItem as JQFactor;

                    if (itemFactor != null)
                    {
                        LinkButton linkFactorTitle = e.Item.FindControl("linkButtonFactorTitle") as LinkButton;
                        linkFactorTitle.Text = itemFactor.JQFactorTitle;
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridJQFactors_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ViewFactorDetails")
                {
                    GridDataItem item = e.Item as GridDataItem;
                    LinkButton linkButtonFactorTitle = e.Item.FindControl("linkButtonFactorTitle") as LinkButton;
                    long factorID = (long)item.GetDataKeyValue("JQFactorID");

                    // Get sender command argument and raise event
                    if (ViewFactorDetails != null)
                        ViewFactorDetails(factorID, linkButtonFactorTitle.Text);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridJQFactors_RowDrop(object sender, GridDragDropEventArgs e)
        {
            try
            {
                // make sure items are not null AND that the source table is equal to the destination table
                if ((e.DestDataItem != null && e.DraggedItems != null) &&
                    (string.Compare(e.DraggedItems[0].OwnerTableView.Name, e.DestDataItem.OwnerTableView.Name, true) == 0))
                {
                    switch (e.DestDataItem.OwnerTableView.Name)
                    {
                        case "Factors":
                            long sourceFactorID = (long)e.DraggedItems[0].GetDataKeyValue("JQFactorID");
                            long destinationFactorID = (long)e.DestDataItem.GetDataKeyValue("JQFactorID");

                            JQFactor sourceFactor = this.Factors.Find(sourceFactorID);
                            JQFactor destinationFactor = this.Factors.Find(destinationFactorID);

                            if (sourceFactor != null && destinationFactor != null)
                            {
                                int destinationIndex = this.Factors.IndexOf(destinationFactor);
                                destinationIndex = getNewIndex(ref destinationIndex, e);

                                this.Factors.Remove(sourceFactor);
                                this.Factors.Insert(destinationIndex, sourceFactor);
                            }

                            bindData(this.Factors);
                            //toggleButtons(true);

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region Button Click Events
        private void SaveOrder(bool printMessage)
        {
            // save new order
            JQManager jqm = new JQManager();


            // For Issue 991 - To avoid updating while in view mode
            if (CurrentNavMode != enumNavigationMode.View)
                jqm.UpdateOrder(base.CurrentJQID, this.Factors, this.CurrentUserID);


            // clear all collections
            this.Factors.Clear();

            // re-bind grid
            this.Factors = jqm.GetJQFactorCollectionByJQID(base.CurrentJQID);
            bindData(this.Factors);

            // disable save/order button
            //this.toggleButtons(false);

            // show system message
            if (printMessage)
            {
                base.PrintSystemMessage(GetLocalResourceObject("OrderUpdatedMessage").ToString(), true);
            }
        }

        private void buttonSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                SaveOrder(true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //If document is not finalized, allow to save order and vice versa.
            if (base.ShowEditFields(enumDocumentType.JQ))
            {
                SaveOrder(false);
            }
            string documentFormat = string.Empty;


            if (!base.HasHRGroupPermission)
            {
                documentFormat = enumDocumentFormat.PDF.ToString();
            }
            else
            {
                if (optPDF.Checked)
                {
                    documentFormat = enumDocumentFormat.PDF.ToString();
                }
                else
                {
                    documentFormat = enumDocumentFormat.UTF8.ToString();
                }
            }

            Response.Redirect(Page.ResolveUrl(string.Format("~/JQ/JQReport.aspx?JNPID={0}&ReportFormat={1}", base.CurrentJNPID.ToString(), documentFormat)));

        }


        #endregion

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            string url = string.Empty;
            switch (base.LastScreen())
            {
                case enumLastScreen.JQ:
                    url = Page.ResolveUrl("~/JQ/FinalJQ.aspx");
                    break;
                case enumLastScreen.CR:
                    url = Page.ResolveUrl("~/CR/CategoryRating.aspx");
                    break;
                case enumLastScreen.Approval:
                    //url = Page.ResolveUrl("~/Approval/Approval.aspx");
                    if (base.HasActiveCR())
                        url = Page.ResolveUrl("~/CR/CategoryRating.aspx");
                    else
                        url = Page.ResolveUrl("~/Approval/Approval.aspx");
                    break;
            }
            GoToLink(url, base.CurrentNavMode);
        }
    }
}