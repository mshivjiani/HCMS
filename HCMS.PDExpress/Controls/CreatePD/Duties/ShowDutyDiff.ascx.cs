using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Text;
using Telerik.Web.UI;
using Telerik.Web.UI.Editor.Diff;

using HCMS.Business.PD;
using HCMS.Business.Duty;
using HCMS.Business.LogObjects;
using HCMS.Business.Lookups;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using System.Web;

namespace HCMS.PDExpress.Controls.CreatePD.Duties
{
    public partial class ShowDutyDiff : CreatePDUserControlBase
    {

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
                rgWrapper.DataSource = new string[] { " " };
                if (!IsPostBack)
                {
                    SetPageView();
                }
            }

            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        #endregion

        #region [ Private Methods ]

        private void SetPageView()
        {
            PDAccessType accessPD = base.GetPDAccessType(this.PD);
            bool blnVisible = !isSOD && (accessPD == PDAccessType.Write) && !base.CurrentPD.ArePositionDutiesReviewed;
            lblSubmitInfo.Visible = blnVisible;
            radComboActionTop.Visible = blnVisible;
            btnSaveTop.Enabled = btnSaveContinue.Enabled = blnVisible;
            this.ToolTip70.Visible = blnVisible;
        }

        #endregion

        #region [ Page button event handlers ]

        protected void GoBack(object sender, EventArgs e)
        {
            if (PD.ArePositionDutiesReviewed)
            {
                if (Request.UrlReferrer.ToString().IndexOf("ShowDutyDiff.aspx") > 0)
                {
                    SafeRedirect(String.Format("~/CreatePD/Duties.aspx{0}", Request.UrlReferrer.Query));
                }
                else
                {
                    SafeRedirect(Request.UrlReferrer.ToString());
                }

            }
            else
            {
                SafeRedirect(this.RedirectedFrom);
            }
        }

        protected void btnSaveTop_Click(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveChanges();
                    if (e.CommandName == "continue")
                        base.GoToPDLink("~/CreatePD/PositionCharacteristics.aspx");
                    else
                        base.GoToPDLink("~/CreatePD/Duties.aspx");
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
        }

        private void SaveChanges()
        {
            try
            {
                if (radComboActionTop.SelectedValue == "acceptall")
                {
                    PD.AcceptAllDutyDiffs();
                    pd.AcceptAllPositionCompetencyKSADiffs();
                }
                else if (radComboActionTop.SelectedValue == "rejectall")
                {
                    PD.RejectAllDutyDiffs();
                    PD.RejectAllPositionCompetencyKSADiffs();
                }
                else
                {
                    string dutyDiffXML = GetDiffXML("DutyMain", "DutyID", "dutydiffs", rgDutyAdds, rgDuty, rgDutyDeletes);
                    string PDQualDiffXML = GetDiffXML("QualMain", "CompetencyKSAID", "PDQualDiffs", rgQualAdds, rgQual, rgQualDeletes);
                    PD.SaveDutyDiffChanges(dutyDiffXML);
                    PD.SavePositionDescriptionDiffChanges(PDQualDiffXML);
                }

                //Update ArePositionDutiesReviewed flag in PD Table
                PD.ArePositionDutiesReviewed = true;
                PD.UpdatePositionDutiesReviewedFlag();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private string GetDiffXML(string ownerTableName, string dataKeyName, string xmlRoot, RadGrid gridAdded, RadGrid gridEdited, RadGrid gridDeleted)
        {
            string returnXML = string.Empty;

            ArrayList newAcceptedIDs = new ArrayList();
            ArrayList editedAcceptedIDs = new ArrayList();
            ArrayList deletedAcceptedIDs = new ArrayList();

            ArrayList newRejectedIDs = new ArrayList();
            ArrayList editedRejectedIDs = new ArrayList();
            ArrayList deletedRejectedIDs = new ArrayList();

            foreach (GridDataItem item in gridEdited.Items)
            {
                if (item.OwnerTableView.Name == ownerTableName && item is GridDataItem)
                {
                    RadComboBox combo = item.FindControl("rcbAction") as RadComboBox;
                    if (combo.SelectedValue == "accept")
                        editedAcceptedIDs.Add(item.GetDataKeyValue(dataKeyName));
                    else
                        editedRejectedIDs.Add(item.GetDataKeyValue(dataKeyName));
                }
            }

            foreach (GridDataItem item in gridAdded.Items)
            {
                if (item.OwnerTableView.Name == ownerTableName && item is GridDataItem)
                {
                    RadComboBox combo = item.FindControl("rcbAction") as RadComboBox;
                    if (combo.SelectedValue == "accept")
                        newAcceptedIDs.Add(item.GetDataKeyValue(dataKeyName));
                    else
                        newRejectedIDs.Add(item.GetDataKeyValue(dataKeyName));
                }
            }

            foreach (GridDataItem item in gridDeleted.Items)
            {
                if (item.OwnerTableView.Name == ownerTableName && item is GridDataItem)
                {
                    RadComboBox combo = item.FindControl("rcbAction") as RadComboBox;
                    if (combo.SelectedValue == "accept")
                        deletedAcceptedIDs.Add(item.GetDataKeyValue(dataKeyName));
                    else
                        deletedRejectedIDs.Add(item.GetDataKeyValue(dataKeyName));
                }
            }

            returnXML = BuildDutyDiffXmlString(xmlRoot, dataKeyName, editedAcceptedIDs, newAcceptedIDs, deletedAcceptedIDs, editedRejectedIDs, newRejectedIDs, deletedRejectedIDs);
            return returnXML;
        }

        private string BuildDutyDiffXmlString(string xmlRootName, string xmlNodeName, ArrayList editedAcceptIDs, ArrayList newAcceptIDs, ArrayList deletedAcceptIDs, ArrayList editedRejectIDs, ArrayList newRejectIDs, ArrayList deletedRejectIDs)
        {
            StringBuilder xmlString = new StringBuilder();

            xmlString.AppendFormat("<{0}>", xmlRootName);
            xmlString.Append("<accept>");
            xmlString.Append("<edited>");
            foreach (var id in editedAcceptIDs)
            {
                xmlString.AppendFormat("<{0}>{1}</{0}>", xmlNodeName, id);
            }
            xmlString.Append("</edited>");
            xmlString.Append("<added>");
            foreach (var id in newAcceptIDs)
            {
                xmlString.AppendFormat("<{0}>{1}</{0}>", xmlNodeName, id);
            }
            xmlString.Append("</added>");
            xmlString.Append("<deleted>");
            foreach (var id in deletedAcceptIDs)
            {
                xmlString.AppendFormat("<{0}>{1}</{0}>", xmlNodeName, id);
            }
            xmlString.Append("</deleted>");
            xmlString.Append("</accept>");

            xmlString.Append("<reject>");
            xmlString.Append("<edited>");
            foreach (var id in editedRejectIDs)
            {
                xmlString.AppendFormat("<{0}>{1}</{0}>", xmlNodeName, id);
            }
            xmlString.Append("</edited>");
            xmlString.Append("<added>");
            foreach (var id in newRejectIDs)
            {
                xmlString.AppendFormat("<{0}>{1}</{0}>", xmlNodeName, id);
            }
            xmlString.Append("</added>");
            xmlString.Append("<deleted>");
            foreach (var id in deletedRejectIDs)
            {
                xmlString.AppendFormat("<{0}>{1}</{0}>", xmlNodeName, id);
            }
            xmlString.Append("</deleted>");
            xmlString.Append("</reject>");
            xmlString.AppendFormat("</{0}>", xmlRootName);

            return xmlString.ToString();
        }

        private void ShowHideQualifications(GridTableView tableView)
        {
            GridItem[] nestedViewItems = tableView.GetItems(GridItemType.NestedView);
            bool atleastOneTableExists = false;
            foreach (GridNestedViewItem nestedViewItem in nestedViewItems)
            {
                foreach (GridTableView nestedView in nestedViewItem.NestedTableViews)
                {
                    TableCell cell = nestedView.ParentItem["ExpandColumn"];
                    if (nestedView.Items.Count > 0)
                    {
                        atleastOneTableExists = true;

                        //if the detail table is Edited Qualifications, loop thru to find out if any qualifications are edited in review
                        if (nestedView.Name == "EditedQualifications")
                        {
                            bool isQualEdited = false;
                            foreach (GridDataItem item in nestedView.Items)
                            {
                                Label lblQualification = item.FindControl("lblQualification") as Label;
                                Label lblCompetencyKSA = item.FindControl("lblCompetencyKSA") as Label;
                                Label lblQualificationTypeName = item.FindControl("lblQualificationTypeName") as Label;
                                isQualEdited = (lblQualification.Text.IndexOf("</span>") > 0) || (lblCompetencyKSA.Text.IndexOf("</span>") > 0) || (lblQualificationTypeName.Text.IndexOf("</span>") > 0);

                                //break the loop if at least one of the qualifications has been edited
                                if (isQualEdited)
                                    break;
                            }
                            atleastOneTableExists = atleastOneTableExists && isQualEdited;
                        }
                    }
                    if (nestedView.Items.Count == 0)
                    {
                        cell.Controls[0].Visible = false;
                        nestedView.Visible = false;
                    }
                    cell.Controls[0].Visible = nestedViewItem.Visible = atleastOneTableExists;
                }

                //Show the Duty only if it has been modified or one of the qualifications has been edited in review.
                if (nestedViewItem.OwnerTableView.Name == "DutyMain")
                {
                    GridDataItem itemDuty = nestedViewItem.ParentItem;
                    Label lblDutyDescription = itemDuty.FindControl("lblDutyDescription") as Label;
                    Label lblPercentageOfTime = itemDuty.FindControl("lblPercentageOfTime") as Label;
                    Label lblDutyTypeName = itemDuty.FindControl("lblDutyTypeName") as Label;

                    bool isDutyEdited = (lblDutyDescription.Text.IndexOf("</span>") > 0) || (lblPercentageOfTime.Text.IndexOf("</span>") > 0) || (lblDutyTypeName.Text.IndexOf("</span>") > 0);
                    nestedViewItem.ParentItem.Visible = atleastOneTableExists || isDutyEdited;
                }
                atleastOneTableExists = false;
            }
        }

        #endregion


        #region Export Related Methods
        //commenting this as this is achieved  by ShowHeader="false" property 
        //putting the ShowHeader="false" and this code caused javascript error - undefined object
        //protected void rgWrapper_ItemCreated(object sender, GridItemEventArgs e)
        //{
        //    if (e.Item is GridHeaderItem)
        //        e.Item.Visible = false;
        //}

        protected void btnExport_Click(object sender, EventArgs e)
        {
            RadGrid rg1 = (RadGrid)rgWrapper.Items[0].FindControl("rgDuty");
            HideColumnsForExport(rg1);
            RadGrid rg2 = (RadGrid)rgWrapper.Items[0].FindControl("rgDutyAdds");
            HideColumnsForExport(rg2);
            RadGrid rg3 = (RadGrid)rgWrapper.Items[0].FindControl("rgDutyDeletes");
            HideColumnsForExport(rg3);
            RadGrid rg4 = (RadGrid)rgWrapper.Items[0].FindControl("rgQual");
            HideColumnsForExport(rg4);
            RadGrid rg5 = (RadGrid)rgWrapper.Items[0].FindControl("rgQualAdds");
            HideColumnsForExport(rg5);
            RadGrid rg6 = (RadGrid)rgWrapper.Items[0].FindControl("rgQualDeletes");
            HideColumnsForExport(rg6);
            rg1.Page.Response.ClearHeaders();
            rg1.Page.Response.Cache.SetCacheability(HttpCacheability.Private);
            rgWrapper.ExportSettings.FileName = Server.HtmlEncode("ShowDutyDifference-PD" + PD.PositionDescriptionID.ToString());
            rgWrapper.MasterTableView.ExportToWord();

        }

        private void HideColumnsForExport(RadGrid rg)
        {
            if (rg != null)
            {
                rg.ShowHeader = true;
                //Hide Expand/Collapse column
                (rg.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem)["ExpandColumn"].Visible = false;
                foreach (GridDataItem dataItem in rg.MasterTableView.Items)
                {
                    dataItem["ExpandColumn"].Style["display"] = "none";
                    dataItem["ExpandColumn"].Visible = false;
                }
                //Hide action column
                rg.Columns[3].Visible = false;
            }
        }

        #endregion


        #region [ Duty Grid Event Handlers and Methods]

        protected void rgDuty_PreRender(object sender, EventArgs e)
        {
            //Set the Tooltips for Expand Collapse Icons
            rgDuty.HierarchySettings.ExpandTooltip = "Show Qualifications";
            rgDuty.HierarchySettings.CollapseTooltip = "Hide Qualifications";
            if (base.CurrentPD.ArePositionDutiesReviewed)
            {
                GridColumn gc;
                GridColumnCollection gcc = rgDuty.Columns;
                gc = gcc.FindByUniqueName("Action");
                gc.Visible = false;
                gc.Display = false;
            }


            //Hide Qualification View if no records are returned from the DB
            if (!IsPostBack)
                ShowHideQualifications(rgDuty.MasterTableView);
            if (rgDuty.MasterTableView.Items.Count == 0)
            {
                rgDuty.MasterTableView.Visible = false;
                pnlDuty.Visible = false;
            }
        }

        protected void rgDuty_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExpandCollapseCommandName)
            {
                if (!e.Item.Expanded)
                {
                    GridItem[] nestedViewItems = rgDuty.MasterTableView.GetItems(GridItemType.NestedView);
                    bool atleastOneTableExists = false;

                    foreach (GridNestedViewItem nestedViewItem in nestedViewItems)
                    {
                        if (nestedViewItem.ParentItem.ItemIndex == e.Item.ItemIndex)
                        {
                            foreach (GridTableView nestedView in nestedViewItem.NestedTableViews)
                            {
                                TableCell cell = nestedView.ParentItem["ExpandColumn"];
                                if (nestedView.Items.Count > 0)
                                {
                                    atleastOneTableExists = true;
                                }
                                if (nestedView.Items.Count == 0)
                                {
                                    cell.Controls[0].Visible = false;
                                    nestedView.Visible = false;
                                }
                                cell.Controls[0].Visible = nestedViewItem.Visible = atleastOneTableExists;
                            }
                            atleastOneTableExists = false;
                        }
                    }

                }
            }
        }

        //Bind Duty Grid
        protected void rgDuty_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (!e.IsFromDetailTable)
                {
                    this.rgDuty.DataSource = PD.GetPositionDutiesModifiedDuringReview();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        //Bind the DetailTable for Qualifications inside Duty Grid
        protected void rgDuty_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            int dutyLogID = int.Parse(dataItem.GetDataKeyValue("DutyLogID").ToString());
            positionDutyLog = new PositionDutyLog(dutyLogID);

            switch (e.DetailTableView.Name)
            {
                case "EditedQualifications":
                    {
                        DataTable qualList = positionDutyLog.GetDutyCompetencyKSAModifiedDuringReview();
                        e.DetailTableView.DataSource = qualList;
                        break;
                    }
                case "NewQualifications":
                    {
                        List<DutyCompetencyKSALog> qualList = positionDutyLog.GetDutyCompetencyKSAAddedDuringReview();
                        e.DetailTableView.DataSource = qualList;
                        break;
                    }
                case "DeletedQualifications":
                    {
                        List<DutyCompetencyKSALog> qualList = positionDutyLog.GetDutyCompetencyKSADeletedDuringReview();
                        e.DetailTableView.DataSource = qualList;
                        break;
                    }
            }
        }

        protected void rgDuty_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)(this.rgDuty.DataSource);

                if (dt.Rows.Count > 0)
                {
                    GridItem gridItem = e.Item;
                    if (gridItem.OwnerTableView.Name == "DutyMain" && e.Item is GridDataItem)
                    {
                        Label lblDutyDescription = gridItem.FindControl("lblDutyDescription") as Label;
                        Label lblPercentageOfTime = gridItem.FindControl("lblPercentageOfTime") as Label;
                        Label lblDutyTypeName = gridItem.FindControl("lblDutyTypeName") as Label;

                        DataRow currentRow = (gridItem.DataItem as DataRowView).Row;

                        if (currentRow != null)
                        {
                            if (Convert.ToInt32(currentRow["DraftPercentageOfTime"]) != -1 && Convert.ToInt32(currentRow["ReviewPercentageOfTime"]) != -1)
                            {
                                lblPercentageOfTime.Text = base.DiffCompareStrings(currentRow["ReviewPercentageOfTime"].ToString(), currentRow["DraftPercentageOfTime"].ToString());
                            }

                            lblDutyDescription.Text = base.DiffCompareStrings(currentRow["ReviewDutyDescription"].ToString(), currentRow["DraftDutyDescription"].ToString()).Replace("\n", "<br/>");
                            lblDutyTypeName.Text = base.DiffCompareStrings(currentRow["ReviewDutyType"].ToString(), currentRow["DraftDutyType"].ToString());
                        }
                    }
                    else if (gridItem.OwnerTableView.Name == "EditedQualifications" && gridItem is GridDataItem)
                    {
                        Label lblQualification = gridItem.FindControl("lblQualification") as Label;
                        Label lblCompetencyKSA = gridItem.FindControl("lblCompetencyKSA") as Label;
                        Label lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;

                        DataRow currentRow = (gridItem.DataItem as DataRowView).Row;

                        if (currentRow != null)
                        {
                            lblQualification.Text = base.DiffCompareStrings(currentRow["ReviewQualificationName"].ToString(), currentRow["DraftQualificationName"].ToString());
                            lblCompetencyKSA.Text = base.DiffCompareStrings(currentRow["ReviewCompetencyKSA"].ToString(), currentRow["DraftCompetencyKSA"].ToString()).Replace("\n", "<br/>");
                            lblQualificationTypeName.Text = base.DiffCompareStrings(currentRow["ReviewQualificationTypeName"].ToString(), currentRow["DraftQualificationTypeName"].ToString());
                        }
                    }
                    else if (gridItem.OwnerTableView.Name == "NewQualifications" && gridItem is GridDataItem)
                    {
                        Label lblQualification = gridItem.FindControl("lblQualification") as Label;
                        Label lblCompetencyKSA = gridItem.FindControl("lblCompetencyKSA") as Label;
                        Label lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;

                        if (gridItem.DataItem is DutyCompetencyKSALog)
                        {
                            DutyCompetencyKSALog dutyQual = gridItem.DataItem as DutyCompetencyKSALog;
                            if (dutyQual != null)
                            {
                                lblQualification.Text = dutyQual.QualificationName;
                                lblCompetencyKSA.Text = dutyQual.CompetencyKSA;
                                lblQualificationTypeName.Text = dutyQual.QualificationTypeName;

                                lblQualification.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblQualification.Text);
                                lblCompetencyKSA.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblCompetencyKSA.Text);
                                lblQualificationTypeName.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblQualificationTypeName.Text);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region Duty Adds Grid Event Handlers

        protected void rgDutyAdds_PreRender(object sender, EventArgs e)
        {
            //Set the Tooltips for Expand Collapse Icons
            rgDutyAdds.HierarchySettings.ExpandTooltip = "Show Qualifications";
            rgDutyAdds.HierarchySettings.CollapseTooltip = "Hide Qualifications";
            //Hide Qualification View if no records are returned from the DB
            if (!IsPostBack)
                ShowHideQualifications(rgDutyAdds.MasterTableView);

            if (rgDutyAdds.MasterTableView.Items.Count == 0)
            {
                rgDutyAdds.MasterTableView.Visible = false;
                pnlDutyAdds.Visible = false;
            }
            else
            {
                if (base.CurrentPD.ArePositionDutiesReviewed)
                {
                    GridColumn gc;
                    GridColumnCollection gcc = rgDutyAdds.Columns;
                    gc = gcc.FindByUniqueName("Action");
                    gc.Visible = false;
                    gc.Display = false;
                }
            }
        }

        protected void rgDutyAdds_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExpandCollapseCommandName)
            {
                //ShowHideQualifications(rgDuty.MasterTableView);
                if (!e.Item.Expanded)
                {
                    GridItem[] nestedViewItems = rgDutyAdds.MasterTableView.GetItems(GridItemType.NestedView);
                    bool atleastOneTableExists = false;

                    foreach (GridNestedViewItem nestedViewItem in nestedViewItems)
                    {
                        if (nestedViewItem.ParentItem.ItemIndex == e.Item.ItemIndex)
                        {
                            foreach (GridTableView nestedView in nestedViewItem.NestedTableViews)
                            {
                                TableCell cell = nestedView.ParentItem["ExpandColumn"];
                                if (nestedView.Items.Count > 0)
                                {
                                    atleastOneTableExists = true;
                                }
                                if (nestedView.Items.Count == 0)
                                {
                                    cell.Controls[0].Visible = false;
                                    nestedView.Visible = false;
                                }
                                cell.Controls[0].Visible = nestedViewItem.Visible = atleastOneTableExists;
                            }
                            atleastOneTableExists = false;
                        }
                    }

                }
            }
        }

        //Bind Duty Adds Grid
        protected void rgDutyAdds_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (!e.IsFromDetailTable)
                {
                    List<PositionDutyLog> dutyList = PD.GetPositionDutiesAddedDuringReview();
                    dutyList.Sort(delegate(PositionDutyLog p1, PositionDutyLog p2) { return p1.PercentageOfTime.CompareTo(p2.PercentageOfTime); });
                    dutyList.Reverse();
                    rgDutyAdds.DataSource = dutyList;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        //Bind the DetailTable for Qualifications inside Duty Adds Grid
        protected void rgDutyAdds_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            int dutyLogID = int.Parse(dataItem.GetDataKeyValue("DutyLogID").ToString());
            positionDutyLog = new PositionDutyLog(dutyLogID);

            switch (e.DetailTableView.Name)
            {
                case "EditedQualifications":
                    {
                        DataTable qualList = positionDutyLog.GetDutyCompetencyKSAModifiedDuringReview();
                        e.DetailTableView.DataSource = qualList;
                        break;
                    }
                case "NewQualifications":
                    {
                        List<DutyCompetencyKSALog> qualList = positionDutyLog.GetDutyCompetencyKSAAddedDuringReview();
                        e.DetailTableView.DataSource = qualList;
                        break;
                    }
                case "DeletedQualifications":
                    {
                        List<DutyCompetencyKSALog> qualList = positionDutyLog.GetDutyCompetencyKSADeletedDuringReview();
                        e.DetailTableView.DataSource = qualList;
                        break;
                    }
            }
        }

        protected void rgDutyAdds_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                GridItem gridItem = e.Item;

                if (gridItem.OwnerTableView.Name == "DutyMain" && e.Item is GridDataItem)
                {
                    Label lblDutyDescription = gridItem.FindControl("lblDutyDescription") as Label;
                    Label lblPercentageOfTime = gridItem.FindControl("lblPercentageOfTime") as Label;
                    Label lblDutyTypeName = gridItem.FindControl("lblDutyTypeName") as Label;

                    if (gridItem.DataItem is PositionDutyLog)
                    {
                        PositionDutyLog positionDuty = gridItem.DataItem as PositionDutyLog;

                        lblDutyDescription.Text = positionDuty.DutyDescription.Replace("\n", "<br/>");

                        if (positionDuty.PercentageOfTime == -1)
                            lblPercentageOfTime.Text = String.Empty;
                        else
                            lblPercentageOfTime.Text = positionDuty.PercentageOfTime.ToString();

                        lblDutyTypeName.Text = positionDuty.DutyType;

                        lblDutyDescription.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblDutyDescription.Text);
                        lblPercentageOfTime.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblPercentageOfTime.Text);
                        lblDutyTypeName.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblDutyTypeName.Text);
                    }
                }
                else if (gridItem.OwnerTableView.Name == "EditedQualifications" && gridItem is GridDataItem)
                {
                    Label lblQualification = gridItem.FindControl("lblQualification") as Label;
                    Label lblCompetencyKSA = gridItem.FindControl("lblCompetencyKSA") as Label;
                    Label lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;

                    DataRow currentRow = (gridItem.DataItem as DataRowView).Row;

                    if (currentRow != null)
                    {
                        lblQualification.Text = base.DiffCompareStrings(currentRow["ReviewQualificationName"].ToString(), currentRow["DraftQualificationName"].ToString());
                        lblCompetencyKSA.Text = base.DiffCompareStrings(currentRow["ReviewCompetencyKSA"].ToString(), currentRow["DraftCompetencyKSA"].ToString()).Replace("\n", "<br/>");
                        lblQualificationTypeName.Text = base.DiffCompareStrings(currentRow["ReviewQualificationTypeName"].ToString(), currentRow["DraftQualificationTypeName"].ToString());
                    }
                }
                else if (gridItem.OwnerTableView.Name == "NewQualifications" && gridItem is GridDataItem)
                {
                    Label lblQualification = gridItem.FindControl("lblQualification") as Label;
                    Label lblCompetencyKSA = gridItem.FindControl("lblCompetencyKSA") as Label;
                    Label lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;

                    if (gridItem.DataItem is DutyCompetencyKSALog)
                    {
                        DutyCompetencyKSALog dutyQual = gridItem.DataItem as DutyCompetencyKSALog;
                        if (dutyQual != null)
                        {
                            lblQualification.Text = dutyQual.QualificationName;
                            lblCompetencyKSA.Text = dutyQual.CompetencyKSA;
                            lblQualificationTypeName.Text = dutyQual.QualificationTypeName;

                            lblQualification.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblQualification.Text);
                            lblCompetencyKSA.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblCompetencyKSA.Text);
                            lblQualificationTypeName.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblQualificationTypeName.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region Duty Deletes Grid Event Handlers

        protected void rgDutyDeletes_PreRender(object sender, EventArgs e)
        {
            //Set the Tooltips for Expand Collapse Icons
            rgDutyDeletes.HierarchySettings.ExpandTooltip = "Show Qualifications";
            rgDutyDeletes.HierarchySettings.CollapseTooltip = "Hide Qualifications";

            //Hide Qualification View if no records are returned from the DB
            if (!IsPostBack)
                ShowHideQualifications(rgDutyDeletes.MasterTableView);

            if (rgDutyDeletes.MasterTableView.Items.Count == 0)
            {
                rgDutyDeletes.MasterTableView.Visible = false;
                pnlDutyDeletes.Visible = false;
            }
            else
            {
                if (base.CurrentPD.ArePositionDutiesReviewed)
                {
                    GridColumn gc;
                    GridColumnCollection gcc = rgDutyDeletes.Columns;
                    gc = gcc.FindByUniqueName("Action");
                    gc.Visible = false;
                    gc.Display = false;
                }
            }
        }

        protected void rgDutyDeletes_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == RadGrid.ExpandCollapseCommandName)
            {
                if (!e.Item.Expanded)
                {
                    GridItem[] nestedViewItems = rgDutyDeletes.MasterTableView.GetItems(GridItemType.NestedView);
                    bool atleastOneTableExists = false;

                    foreach (GridNestedViewItem nestedViewItem in nestedViewItems)
                    {
                        if (nestedViewItem.ParentItem.ItemIndex == e.Item.ItemIndex)
                        {
                            foreach (GridTableView nestedView in nestedViewItem.NestedTableViews)
                            {
                                TableCell cell = nestedView.ParentItem["ExpandColumn"];
                                if (nestedView.Items.Count > 0)
                                {
                                    atleastOneTableExists = true;
                                }
                                if (nestedView.Items.Count == 0)
                                {
                                    cell.Controls[0].Visible = false;
                                    nestedView.Visible = false;
                                }
                                cell.Controls[0].Visible = nestedViewItem.Visible = atleastOneTableExists;
                            }
                            atleastOneTableExists = false;
                        }
                    }

                }
            }
        }

        //Bind Duty Deletes Grid
        protected void rgDutyDeletes_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (!e.IsFromDetailTable)
                {
                    List<PositionDutyLog> dutyList = PD.GetDeletedDraftPositionDuties();
                    dutyList.Sort(delegate(PositionDutyLog p1, PositionDutyLog p2) { return p1.PercentageOfTime.CompareTo(p2.PercentageOfTime); });
                    dutyList.Reverse();
                    rgDutyDeletes.DataSource = dutyList;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        //Bind the DetailTable for Qualifications inside Duty Deletes Grid
        protected void rgDutyDeletes_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            int dutyLogID = int.Parse(dataItem.GetDataKeyValue("DutyLogID").ToString());
            positionDutyLog = new PositionDutyLog(dutyLogID);

            switch (e.DetailTableView.Name)
            {
                case "EditedQualifications":
                    {
                        DataTable qualList = positionDutyLog.GetDutyCompetencyKSAModifiedDuringReview();
                        e.DetailTableView.DataSource = qualList;
                        break;
                    }
                case "NewQualifications":
                    {
                        List<DutyCompetencyKSALog> qualList = positionDutyLog.GetDutyCompetencyKSAAddedDuringReview();
                        e.DetailTableView.DataSource = qualList;
                        break;
                    }
                case "DeletedQualifications":
                    {
                        List<DutyCompetencyKSALog> qualList = positionDutyLog.GetDutyCompetencyKSADeletedDuringReview();
                        e.DetailTableView.DataSource = qualList;
                        break;
                    }
            }
        }

        protected void rgDutyDeletes_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                GridItem gridItem = e.Item;

                if (gridItem.OwnerTableView.Name == "DutyMain" && e.Item is GridDataItem)
                {
                    Label lblDutyDescription = gridItem.FindControl("lblDutyDescription") as Label;
                    Label lblPercentageOfTime = gridItem.FindControl("lblPercentageOfTime") as Label;
                    Label lblDutyTypeName = gridItem.FindControl("lblDutyTypeName") as Label;

                    if (gridItem.DataItem is PositionDutyLog)
                    {
                        PositionDutyLog positionDuty = gridItem.DataItem as PositionDutyLog;

                        lblDutyDescription.Text = positionDuty.DutyDescription.Replace("\n", "<br/>");

                        if (positionDuty.PercentageOfTime == -1)
                            lblPercentageOfTime.Text = String.Empty;
                        else
                            lblPercentageOfTime.Text = positionDuty.PercentageOfTime.ToString();

                        lblDutyTypeName.Text = positionDuty.DutyType;

                        lblDutyDescription.Text = string.Format("<span style='color: red;text-decoration:line-through; font-weight: bold;'>{0}</span>", lblDutyDescription.Text);
                        lblPercentageOfTime.Text = string.Format("<span style='color: red;text-decoration:line-through; font-weight: bold;'>{0}</span>", lblPercentageOfTime.Text);
                        lblDutyTypeName.Text = string.Format("<span style='color: red;text-decoration:line-through; font-weight: bold;'>{0}</span>", lblDutyTypeName.Text);
                    }
                }
                else if (gridItem.OwnerTableView.Name == "EditedQualifications" && gridItem is GridDataItem)
                {
                    Label lblQualification = gridItem.FindControl("lblQualification") as Label;
                    Label lblCompetencyKSA = gridItem.FindControl("lblCompetencyKSA") as Label;
                    Label lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;

                    DataRow currentRow = (gridItem.DataItem as DataRowView).Row;

                    if (currentRow != null)
                    {
                        lblQualification.Text = base.DiffCompareStrings(currentRow["ReviewQualificationName"].ToString(), currentRow["DraftQualificationName"].ToString());
                        lblCompetencyKSA.Text = base.DiffCompareStrings(currentRow["ReviewCompetencyKSA"].ToString(), currentRow["DraftCompetencyKSA"].ToString()).Replace("\n", "<br/>");
                        lblQualificationTypeName.Text = base.DiffCompareStrings(currentRow["ReviewQualificationTypeName"].ToString(), currentRow["DraftQualificationTypeName"].ToString());
                    }
                }
                else if (gridItem.OwnerTableView.Name == "NewQualifications" && gridItem is GridDataItem)
                {
                    Label lblQualification = gridItem.FindControl("lblQualification") as Label;
                    Label lblCompetencyKSA = gridItem.FindControl("lblCompetencyKSA") as Label;
                    Label lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;

                    if (gridItem.DataItem is DutyCompetencyKSALog)
                    {
                        DutyCompetencyKSALog dutyQual = gridItem.DataItem as DutyCompetencyKSALog;
                        if (dutyQual != null)
                        {
                            lblQualification.Text = dutyQual.QualificationName;
                            lblCompetencyKSA.Text = dutyQual.CompetencyKSA;
                            lblQualificationTypeName.Text = dutyQual.QualificationTypeName;

                            lblQualification.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblQualification.Text);
                            lblCompetencyKSA.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblCompetencyKSA.Text);
                            lblQualificationTypeName.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblQualificationTypeName.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region [ Position Qualification Grid Event Handlers and Methods]

        #region rgQual

        protected void rgQual_PreRender(object sender, EventArgs e)
        {
            //Hide Qualification View if no records are returned from the DB
            if (!IsPostBack)
            {
                if (rgQual.MasterTableView.Items.Count == 0)
                {
                    rgQual.MasterTableView.Visible = false;
                    pnlQual.Visible = false;
                }
                else
                {

                    if (base.CurrentPD.ArePositionDutiesReviewed)
                    {
                        GridColumn gc;
                        GridColumnCollection gcc = rgQual.Columns;
                        gc = gcc.FindByUniqueName("Action");
                        gc.Visible = false;
                        gc.Display = false;
                    }
                }

            }
        }

        protected void rgQual_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (!e.IsFromDetailTable)
                {

                    this.rgQual.DataSource = PD.GetPositionCompetencyKSAModifiedDuringReview();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rgQual_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                GridItem gridItem = e.Item;
                DataTable dt = (DataTable)(this.rgQual.DataSource);

                if (dt.Rows.Count > 0)
                {
                    if (gridItem.OwnerTableView.Name == "QualMain" && e.Item is GridDataItem)
                    {
                        Label lblQualificationName = gridItem.FindControl("lblQualificationName") as Label;
                        Label lblQualificationDescription = gridItem.FindControl("lblQualificationDescription") as Label;
                        Label lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;

                        DataRow currentRow = (gridItem.DataItem as DataRowView).Row;

                        if (currentRow != null)
                        {
                            lblQualificationName.Text = base.DiffCompareStrings(currentRow["ReviewQualificationName"].ToString(), currentRow["DraftQualificationName"].ToString());
                            lblQualificationDescription.Text = base.DiffCompareStrings(currentRow["ReviewCompetencyKSA"].ToString(), currentRow["DraftCompetencyKSA"].ToString()).Replace("\n", "<br/>");
                            lblQualificationTypeName.Text = base.DiffCompareStrings(currentRow["ReviewQualificationTypeName"].ToString(), currentRow["DraftQualificationTypeName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region rgQualAdds

        protected void rgQualAdds_PreRender(object sender, EventArgs e)
        {
            //Hide Qualification View if no records are returned from the DB
            if (!IsPostBack)
            {
                if (rgQualAdds.MasterTableView.Items.Count == 0)
                {
                    rgQualAdds.MasterTableView.Visible = false;
                    pnlQualAdded.Visible = false;
                }

                else
                {
                    if (base.CurrentPD.ArePositionDutiesReviewed)
                    {
                        GridColumn gc;
                        GridColumnCollection gcc = rgQualAdds.Columns;
                        gc = gcc.FindByUniqueName("Action");
                        gc.Visible = false;
                        gc.Display = false;
                    }
                }

            }
        }

        protected void rgQualAdds_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (!e.IsFromDetailTable)
                {
                    List<PositionCompetencyKSALog> qualList = PD.GetPositionCompetencyKSAAddedDuringReview();
                    rgQualAdds.DataSource = qualList;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rgQualAdds_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                GridItem gridItem = e.Item;
                if (gridItem.OwnerTableView.Name == "QualMain" && e.Item is GridDataItem)
                {
                    Label lblQualificationName = gridItem.FindControl("lblQualificationName") as Label;
                    Label lblQualificationDescription = gridItem.FindControl("lblQualificationDescription") as Label;
                    Label lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;

                    if (gridItem.DataItem is PositionCompetencyKSALog)
                    {
                        PositionCompetencyKSALog positionQual = gridItem.DataItem as PositionCompetencyKSALog;

                        lblQualificationName.Text = positionQual.QualificationName;
                        lblQualificationDescription.Text = positionQual.CompetencyKSA;
                        lblQualificationTypeName.Text = positionQual.QualificationTypeName;

                        lblQualificationName.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblQualificationName.Text);
                        lblQualificationDescription.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblQualificationDescription.Text);
                        lblQualificationTypeName.Text = string.Format("<span style='background-color: #FFFF00;'>{0}</span>", lblQualificationTypeName.Text);
                    }
                }

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region rgQualDeletes

        protected void rgQualDeletes_PreRender(object sender, EventArgs e)
        {
            //Hide Qualification View if no records are returned from the DB
            if (!IsPostBack)
            {
                if (rgQualDeletes.MasterTableView.Items.Count == 0)
                {
                    rgQualDeletes.MasterTableView.Visible = false;
                    pnlQualDeleted.Visible = false;
                }
                else
                {
                    if (base.CurrentPD.ArePositionDutiesReviewed)
                    {
                        GridColumn gc;
                        GridColumnCollection gcc = rgQualDeletes.Columns;
                        gc = gcc.FindByUniqueName("Action");
                        gc.Visible = false;
                        gc.Display = false;
                    }
                }

            }
        }

        protected void rgQualDeletes_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (!e.IsFromDetailTable)
                {
                    List<PositionCompetencyKSALog> qualList = PD.GetPositionCompetencyKSADeletedDuringReview();
                    rgQualDeletes.DataSource = qualList;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rgQualDeletes_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {
                GridItem gridItem = e.Item;

                if (gridItem.OwnerTableView.Name == "QualMain" && e.Item is GridDataItem)
                {
                    Label lblQualificationName = gridItem.FindControl("lblQualificationName") as Label;
                    Label lblQualificationDescription = gridItem.FindControl("lblQualificationDescription") as Label;
                    Label lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;

                    if (gridItem.DataItem is PositionCompetencyKSALog)
                    {
                        PositionCompetencyKSALog positionQual = gridItem.DataItem as PositionCompetencyKSALog;

                        lblQualificationName.Text = positionQual.QualificationName;
                        lblQualificationDescription.Text = positionQual.CompetencyKSA;
                        lblQualificationTypeName.Text = positionQual.QualificationTypeName;

                        lblQualificationName.Text = string.Format("<span style='color: red;text-decoration:line-through; font-weight: bold;'>{0}</span>", lblQualificationName.Text);
                        lblQualificationDescription.Text = string.Format("<span style='color: red;text-decoration:line-through; font-weight: bold;'>{0}</span>", lblQualificationDescription.Text);
                        lblQualificationTypeName.Text = string.Format("<span style='color: red;text-decoration:line-through; font-weight: bold;'>{0}</span>", lblQualificationTypeName.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion
        #endregion

        #region [ Private Properties ]

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

        private Panel pnlDuty
        {
            get
            {
                Panel pnl = (Panel)rgWrapper.Items[0].FindControl("pnlDuty");
                return pnl;
            }
        }

        private Panel pnlDutyAdds
        {
            get
            {
                Panel pnl = (Panel)rgWrapper.Items[0].FindControl("pnlDutyAdds");
                return pnl;
            }
        }

        private Panel pnlDutyDeletes
        {
            get
            {
                Panel pnl = (Panel)rgWrapper.Items[0].FindControl("pnlDutyDeletes");
                return pnl;
            }
        }

        private Panel pnlQual
        {
            get
            {
                Panel pnl = (Panel)rgWrapper.Items[0].FindControl("pnlQual");
                return pnl;
            }
        }

        private Panel pnlQualAdded
        {
            get
            {
                Panel pnl = (Panel)rgWrapper.Items[0].FindControl("pnlQualAdded");
                return pnl;
            }
        }

        private Panel pnlQualDeleted
        {
            get
            {
                Panel pnl = (Panel)rgWrapper.Items[0].FindControl("pnlQualDeleted");
                return pnl;
            }
        }

        private RadGrid rgDuty
        {
            get
            {
                RadGrid rg = (RadGrid)rgWrapper.Items[0].FindControl("rgDuty");
                return rg;
            }
        }

        private RadGrid rgDutyAdds
        {
            get
            {
                RadGrid rg = (RadGrid)rgWrapper.Items[0].FindControl("rgDutyAdds");
                return rg;
            }
        }
        private RadGrid rgDutyDeletes
        {
            get
            {
                RadGrid rg = (RadGrid)rgWrapper.Items[0].FindControl("rgDutyDeletes");
                return rg;
            }
        }
        private RadGrid rgQual
        {
            get
            {
                RadGrid rg = (RadGrid)rgWrapper.Items[0].FindControl("rgQual");
                return rg;
            }
        }
        private RadGrid rgQualAdds
        {
            get
            {
                RadGrid rg = (RadGrid)rgWrapper.Items[0].FindControl("rgQualAdds");
                return rg;
            }
        }
        private RadGrid rgQualDeletes
        {
            get
            {
                RadGrid rg = (RadGrid)rgWrapper.Items[0].FindControl("rgQualDeletes");
                return rg;
            }
        }

        #endregion

        #region [ Private Fields ]

        private PositionDescription pd = null;

        private PositionDutyLog positionDutyLog;

        #endregion

        #region [ Public Properties ]

        public string RedirectedFrom
        {
            get
            {
                if (ViewState["RedirectedFrom"] == null)
                {
                    ViewState["RedirectedFrom"] = Request.UrlReferrer.ToString();
                }
                return ViewState["RedirectedFrom"].ToString();
            }
            set
            {
                ViewState["RedirectedFrom"] = value;
            }
        }
        #endregion
    }
}