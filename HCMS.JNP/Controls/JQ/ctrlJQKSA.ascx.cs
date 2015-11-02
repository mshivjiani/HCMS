using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.JQ;


namespace HCMS.JNP.Controls.JQ
{
    public partial class ctrlJQKSA : JNPUserControlBase
    {
        JQManager jqm = new JQManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // init Qualifications grid
               
                SetPageView();
                gridKSA.Rebind();
            }
        }
        
        #region KSA Grid events
        protected void gridKSA_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            GridItem gridItem = e.Item;
            //hide the refresh button Telerik.Web.UI.GridLinkButton
            if (gridItem is GridCommandItem)
            {
                gridItem.FindControl("RebindGridButton").Visible = false;

            }
        }

        protected void gridKSA_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            this.gridKSA.DataSource = jqm.GetJQKSAFactorsByJQID(this.CurrentJQID);
        }

        protected void gridKSA_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                case RadGrid.EditCommandName:
                case "View":
                    ShowKSA(sender, e);
                    break;
                case RadGrid.DeleteCommandName:
                    DeleteKSA(sender, e);
                    break;
                default:
                    break;
            }
        }
        #endregion

        protected void SetPageView()
        {
            if (base.CurrentJQID == -1)
                base.PrintErrorMessage(GetGlobalResourceObject("JNPMessages", "JQNotAvailable").ToString(), false);
            else
            {              
             
                if (base.IsInInsert)
                {
                    CurrentNavMode = enumNavigationMode.Edit;
                }
               
                GridColumn Editcolumn = gridKSA.MasterTableView.OwnerGrid.Columns.FindByUniqueName("EditCommandColumn");
                GridColumn Viewcolumn = gridKSA.MasterTableView.OwnerGrid.Columns.FindByUniqueName("ViewCommandColumn");
                 
                if (base.ShowEditFields(enumDocumentType.JQ))
                {
                    //gridKSA.Columns[0].Visible = base.ShowEditFields(enumDocumentType.JQ);
                    //gridKSA.Columns[0].Display = base.ShowEditFields(enumDocumentType.JQ);

                    //gridKSA.Columns[1].Visible = false; //view column
                    //gridKSA.Columns[1].Display = false;
                    Editcolumn.Visible = true;
                    Editcolumn.Display = true;

                    Viewcolumn.Visible = false;
                    Viewcolumn.Display = false;
                }
                else
                {
                    //gridKSA.Columns[0].Visible = false;
                    //gridKSA.Columns[0].Display = false; //edit column

                    //gridKSA.Columns[1].Visible = true;
                    //gridKSA.Columns[1].Display = true; //delete column

                    //gridKSA.Columns[2].Visible = true;
                    //gridKSA.Columns[2].Display = true; //view column

                    Editcolumn.Visible = false;
                    Editcolumn.Display = false;

                    Viewcolumn.Visible = true;
                    Viewcolumn.Display = true;

                }
            }
        }


        private void ShowKSA(object source, GridCommandEventArgs e)
        {
            RadWindowMangerKSA.Windows.Clear();
            GridDataItem gridItem;
            string navigateurl = string.Empty;
            string title = string.Empty;
            string script = string.Empty;
            long factorID;
            
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    long JQID = CurrentJQID;
                    base.CurrentJQFactorID = -1;
                    base.GoToLink("~/JQ/AddEditJQKSA.aspx", enumNavigationMode.Insert);
                    //script = string.Format("ShowDutyWindowClient('{0}','{1}');", "Insert", JAID);
                    break;
                case RadGrid.EditCommandName:
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    factorID = long.Parse(gridItem.GetDataKeyValue("ID").ToString());
                    base.CurrentJQFactorID = factorID;
                    GoToLink("~/JQ/AddEditJQKSA.aspx", enumNavigationMode.Edit );
                    //script = string.Format("ShowDutyWindowClient('{0}','{1}');", "Edit", dutyID);
                    break;
                case "View":
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    factorID = long.Parse(gridItem.GetDataKeyValue("ID").ToString());
                    base.CurrentJQFactorID = factorID;
                    //changed second argument of GoToLink from enumNavigationMode.View to CurrentNavMode
                    // because View option can be available when user in edit mode &
                    //if the current document is finalized or if the current document is not active(in case of
                    //package that is copied from existing package)
                    //so if you pass enumNavigationMode.View -then it was setting currentNavMode to view 
                    // that was causing issue 95-moving from editable section of a package to a read-only section
                    //and then back to an editable section leaves the package in read-only mode
                    GoToLink("~/JQ/AddEditJQKSA.aspx", CurrentNavMode);
                   // script = string.Format("ShowDutyWindowClient('{0}','{1}');", "View", dutyID);
                    break;
                default:
                    break;
            }
           // RadWindowMangerDuties.Windows.Add(rwJADuties);
           // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        private void DeleteKSA(object source, GridCommandEventArgs e)
        {
            try
            {
                if (source is RadGrid)
                {
                    GridDataItem gridItem = e.Item as GridDataItem;
                    long factorID = long.Parse(gridItem.GetDataKeyValue("ID").ToString());
                    jqm.DeleteJQFactor(factorID, this.CurrentUserID);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            base.GoToLink("~/JQ/FinalJQ.aspx", this.CurrentNavMode);
        }
    }
}