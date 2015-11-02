using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.JQ;
using HCMS.Business.JQ.Collections;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Wrappers;

using Telerik.Web.UI;

namespace HCMS.JNP.Controls.JQ
{
    public partial class ctrlJQFinalDetails : JNPUserControlBase
    {
        #region Events/Delegates

        public delegate void ViewFactorsHandler();
        public event ViewFactorsHandler ViewFactors;

        #endregion

        #region Properties

        #region Maintain Expand/Collapse State of RadGrid

        private Hashtable ExpandedStates
        {
            get
            {
                if (Session["ExpandedStates"] == null)
                    Session["ExpandedStates"] = new Hashtable();

                return (Hashtable)Session["ExpandedStates"];
            }
            set
            {
                Session["ExpandedStates"] = value;
            }
        }

        #endregion

        private JQFactorItemCollection FactorItems
        {
            get
            {
                if (ViewState["FactorItems"] == null)
                    ViewState["FactorItems"] = new JQFactorItemCollection();

                return (JQFactorItemCollection)ViewState["FactorItems"];
            }
            set
            {
                ViewState["FactorItems"] = value;
            }
        }

        private RatingScaleResponseCollection RatingScaleResponses
        {
            get
            {
                if (ViewState["RatingScaleResponses"] == null)
                    ViewState["RatingScaleResponses"] = new RatingScaleResponseCollection();

                return (RatingScaleResponseCollection)ViewState["RatingScaleResponses"];
            }
            set
            {
                ViewState["RatingScaleResponses"] = value;
            }
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            this.gridJQFactorItems.DetailTableDataBind += new GridDetailTableDataBindEventHandler(gridJQFactorItems_DetailTableDataBind);
            this.gridJQFactorItems.ItemCommand += new GridCommandEventHandler(gridJQFactorItems_ItemCommand);
            this.gridJQFactorItems.RowDrop += new GridDragDropEventHandler(gridJQFactorItems_RowDrop);
            this.gridJQFactorItems.PreRender += new EventHandler(gridJQFactorItems_PreRender);
            this.buttonSaveOrder.Click += new EventHandler(buttonSaveOrder_Click);
            this.buttonCancel.Click += new EventHandler(buttonCancel_Click);
            base.OnInit(e);
        }

       

       

  

       

        private void cleanForm()
        {
            // clear all collections
            this.ExpandedStates = null;
            this.FactorItems.Clear();
            this.RatingScaleResponses.Clear();

            // disable save/order button
            //this.toggleButtons(false);
        }

        public void BuildPage(long factorID, string factorTitle)
        {
            try
            {
                JQManager jqm = new JQManager();

                this.literalFactorTitle.Text = factorTitle;
                cleanForm();  // clean form collections and set form controls

                JQFactorItemCollection listFactorItems = jqm.GetJQFactorItemCollectionByFactorID(factorID);  // load factor items
                this.FactorItems = listFactorItems;

                bindData(listFactorItems);

                SetControls();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void SetControls()
        {
            divReorderFactorItemInstruction.Visible = false;
            gridJQFactorItems.ClientSettings.AllowRowsDragDrop = false;
            gridJQFactorItems.Columns[0].Visible = false;//hide arrow column
            buttonSaveOrder.Enabled = false;

            if (base.ShowEditFields(enumDocumentType.JQ))
            {
                if (base.HasHRGroupPermission)
                {
                    divReorderFactorItemInstruction.Visible = true;
                    gridJQFactorItems.ClientSettings.AllowRowsDragDrop = true;
                    gridJQFactorItems.Columns[0].Visible = true;//show arrow column
                    buttonSaveOrder.Enabled = true;

                }
            }
            

        }

     


        private void bindData(JQFactorItemCollection FactorLoadList)
        {
            this.gridJQFactorItems.DataSource = FactorLoadList;
            this.gridJQFactorItems.DataBind();
        }

        #endregion

        #region RadGrid Events
     

        private void toggleExpansionRecursive(GridTableView parentView, bool expandValue, bool reload = false)
        {
            //bool showEditFields = ShowEditFields();

            GridItem[] childViewItems = parentView.GetItems(GridItemType.NestedView);
            foreach (GridNestedViewItem childView in childViewItems)
            {
                foreach (GridTableView nestedView in childView.NestedTableViews)
                {
                    // nestedView.ParentItem.ItemIndexHierarchical
                    GridDataItem item = nestedView.ParentItem as GridDataItem;
                    string keyName = item.GetDataKeyValue("TagName").ToString();

                    if (reload || !Page.IsPostBack)
                    {
                        // on new load -- store in expandedStates
                        this.ExpandedStates[keyName] = expandValue;
                    }
                    else
                    {
                        // after initial load -- storage in expandedStates is handled by ItemCommand
                        // set expandValue from expandedStates
                        expandValue = this.ExpandedStates[keyName] != null && (bool)this.ExpandedStates[keyName];
                    }
                    // GridColumn dragcolumn = nestedView.Columns.FindByUniqueName("DragResponse") ;
                    //if ((base.ShowEditFields(enumDocumentType.JQ)) && (base.HasHRGroupPermission))
                    //{
                       
                    //     if (dragcolumn!=null)
                    //     {dragcolumn.Visible =true;}
                       
                    //}
                    //else
                    //{
                    //    if (dragcolumn != null)
                    //    { dragcolumn.Visible = false; }
                    //}
                    nestedView.ParentItem.Expanded = expandValue;
                    toggleExpansionRecursive(nestedView, expandValue);
                }
            }
        }

        private void returnToParent()
        {
            if (ViewFactors != null)
                ViewFactors();
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
        protected void gridJQFactorItems_ItemDataBound(object sender, GridItemEventArgs e)
        {                        
            HideRefreshButton(e);           
        }
        void gridJQFactorItems_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == RadGrid.ExpandCollapseCommandName)
                {
                    // e.Item.ItemIndexHierarchical
                    // unique key (over all records factors, factorItems and reponses)
                    // that won't change with record movement
                    GridDataItem item = e.Item as GridDataItem;
                    string keyName = item.GetDataKeyValue("TagName").ToString();

                    //Is the item about to be expanded or collapsed
                    if (!e.Item.Expanded)
                    {
                        //Save its unique index among all the items in the hierarchy
                        this.ExpandedStates[keyName] = true;
                    }
                    else //collapsed
                        this.ExpandedStates.Remove(keyName);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
       
        void gridJQFactorItems_DetailTableDataBind(object sender, GridDetailTableDataBindEventArgs e)
        {
            try
            {
                GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
                JQManager jqm = new JQManager();

                switch (e.DetailTableView.Name)
                {
                    case "RatingScale":
                        {
                            long ratingScaleID = (long)dataItem.GetDataKeyValue("RatingScaleID");

                            // pull rating scale from cached version
                            JQRatingScaleCollection cachedScaleList = LookupWrapper.GetJQRatingScale(false);
                            JQRatingScale ratingScale = cachedScaleList.Find(ratingScaleID);
                            JQRatingScaleCollection newScaleList = new JQRatingScaleCollection();

                            if (ratingScale != null)
                            {
                                // account for blank/null instructions
                                ratingScale.RatingScaleInstruction = string.IsNullOrWhiteSpace(ratingScale.RatingScaleInstruction) ? GetLocalResourceObject("MissingInstructionsText").ToString() : ratingScale.RatingScaleInstruction;
                                newScaleList.Add(ratingScale);
                            }

                            e.DetailTableView.DataSource = newScaleList;
                            break;
                        }
                    case "RatingScaleResponses":
                        {
                            long ratingScaleID = (long)dataItem.GetDataKeyValue("RatingScaleID");
                            RatingScaleResponseCollection responseItemList = this.RatingScaleResponses.FindByScale(ratingScaleID);

                            if (responseItemList.Count == 0)
                            {
                                RatingScaleResponseCollection listResponses = jqm.GetJQRatingScaleResponseCollectionByFactorItemID(ratingScaleID);
                                this.RatingScaleResponses.AddRange(listResponses);
                                responseItemList = listResponses;
                            }

                            e.DetailTableView.DataSource = responseItemList;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private int getNewIndex(ref int destinationIndex, GridDragDropEventArgs e)
        {
            if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                destinationIndex -= 1;

            if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                destinationIndex += 1;

            return destinationIndex;
        }

        void gridJQFactorItems_RowDrop(object sender, GridDragDropEventArgs e)
        {
            try
            {
                // make sure items are not null AND that the source table is equal to the destination table
                if ((e.DestDataItem != null && e.DraggedItems != null) &&
                    (string.Compare(e.DraggedItems[0].OwnerTableView.Name, e.DestDataItem.OwnerTableView.Name, true) == 0))
                {
                    switch (e.DestDataItem.OwnerTableView.Name)
                    {
                        case "FactorItems":
                            long sourceFactorItemID = (long)e.DraggedItems[0].GetDataKeyValue("JQFactorItemID");
                            long destinationFactorItemID = (long)e.DestDataItem.GetDataKeyValue("JQFactorItemID");
                            long factorID = (long)e.DestDataItem.GetDataKeyValue("JQFactorID");

                            JQFactorItemCollection workFactorItems = this.FactorItems.FindByFactor(factorID);
                            JQFactorItem sourceFactorItem = workFactorItems.Find(sourceFactorItemID);
                            JQFactorItem destinationFactorItem = workFactorItems.Find(destinationFactorItemID);

                            if (sourceFactorItem != null && destinationFactorItem != null)
                            {
                                int destinationIndex = workFactorItems.IndexOf(destinationFactorItem);
                                destinationIndex = getNewIndex(ref destinationIndex, e);

                                // remove and add in new position
                                workFactorItems.Remove(sourceFactorItem);
                                workFactorItems.Insert(destinationIndex, sourceFactorItem);

                                // remove entire group
                                this.FactorItems.RemoveByFactor(factorID);

                                // now add back into batch with corrected order
                                this.FactorItems.AddRange(workFactorItems);
                            }

                            bindData(this.FactorItems);

                            //removing toggling of save order button because it was 
                            //enabled even when the ShowEditFields was returning false or when user was not an HR user
                            //toggleButtons(true);

                            break;
                        case "RatingScaleResponses":
                            long sourceJQResponseID = (long)e.DraggedItems[0].GetDataKeyValue("JQResponseID");
                            long destinationJQResponseID = (long)e.DestDataItem.GetDataKeyValue("JQResponseID");
                            long ratingScaleID = (long)e.DestDataItem.GetDataKeyValue("JQRatingScaleID");

                            RatingScaleResponseCollection workResponses = this.RatingScaleResponses.FindByScale(ratingScaleID);
                            RatingScaleResponse sourceResponse = workResponses.Find(sourceJQResponseID);
                            RatingScaleResponse destinationResponse = workResponses.Find(destinationJQResponseID);

                            if (sourceResponse != null && destinationResponse != null)
                            {
                                int destinationIndex = workResponses.IndexOf(destinationResponse);
                                destinationIndex = getNewIndex(ref destinationIndex, e);

                                // remove and add in new position
                                workResponses.Remove(sourceResponse);
                                workResponses.Insert(destinationIndex, sourceResponse);

                                // remove entire scale
                                this.RatingScaleResponses.RemoveByScale(ratingScaleID);

                                // now add back into batch with corrected order
                                this.RatingScaleResponses.AddRange(workResponses);
                            }

                            e.DestDataItem.OwnerTableView.Rebind();
                            //removing toggling of save order button because it was 
                            //enabled even when the ShowEditFields was returning false or when user was not an HR user
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
       
        void gridJQFactorItems_PreRender(object sender, EventArgs e)
        {
            try
            {
                toggleExpansionRecursive(this.gridJQFactorItems.MasterTableView, false);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion

        #region Button Click Events

        private void buttonSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                // save new order
                JQManager jqm = new JQManager();

               // jqm.UpdateOrder(base.CurrentJQID, this.FactorItems, this.RatingScaleResponses, this.CurrentUserID);
                // JA issue id 904/702 Issue 702 is re-occuring. Dashes and periods missing after responses missing in JAX which in turn are missing in UTF-8 (See screenshots) 
                //not updating responses -- because it was overwritting the default responses as well
                jqm.UpdateOrder(base.CurrentJQID, this.FactorItems, null, this.CurrentUserID);

                //JA issue id:921:  	Clicking Save Order when re-ordering task statements under KSAs on Final screen returns you to Factor list 
                bindData(this.FactorItems);
                // show system message
                base.PrintSystemMessage(GetGlobalResourceObject("JNPMessages", "OrderUpdatedMessage").ToString(),true);
                //commenting returning to parent to support the requirement specified in jA issue id 921
                //returnToParent();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                returnToParent();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion
    }
}