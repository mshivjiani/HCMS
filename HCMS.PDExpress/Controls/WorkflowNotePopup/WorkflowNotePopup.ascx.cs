using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Telerik.Web.UI;

using HCMS.Business.PD;
using HCMS.Business.Duty;
using HCMS.Business.Lookups;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

// ----------------------------------------------------
// ! DO NOT initialize Session object in this control !
// ----------------------------------------------------
//
// NOTE:
// this control can be used in two scenarios: when it is being placed on one of the "create PD" 
// pages - Occupation, Duties, etc., i.e. when another page has initialized Session object with 
// the current PD and the second scenario - when the control is used on Dashboard or Search
// grid, when Session object is not initialized with a the current PD. 
//
// In either case - this control will have to create local PD and PD Workflow Status objects 
// for the duraton of the page cycle.
//
// ----------------------------------------------------
// ! DO NOT initialize Session object in this control !
// ----------------------------------------------------

namespace HCMS.PDExpress.Controls.WorkflowNotePopup
{
    public partial class WorkflowNotePopup : CreatePDUserControlBase
    {
        #region [ Page Event Handlers ]
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadData();
                    setPageView();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion

        #region [Other Control Events]
        protected void btnAddWorkflowNote_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtWorkflowNote.Text))
                {
                    if (PD != null && PWS != null)
                    {
                        DateTime createDate = DateTime.Now;
                        WorkflowNote workflowNote = new WorkflowNote();

                        workflowNote.WorkflowRecID = PWS.WorkflowRecID;
                        workflowNote.Note = txtWorkflowNote.Text;
                        workflowNote.NoteStatusID = Convert.ToInt32(WorkflowNoteStatus.Open);
                        workflowNote.CreatedByID = base.CurrentUser.UserID;
                        workflowNote.CreateDate = createDate;
                        workflowNote.UpdatedByID = base.CurrentUser.UserID;
                        workflowNote.UpdateDate = createDate;
                        workflowNote.UpdateNote = String.Empty;

                        workflowNote.Add();

                        txtWorkflowNote.Text = String.Empty;

                        rgWorkflowNote.Rebind();
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void btnRefreshGrid_Click(object source, EventArgs e)
        {
            try
            {
                rgWorkflowNote.Rebind();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion

        #region [ Workflow Note Grid Event Handlers ]
        protected void rgWorkflowNote_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (PD != null && PWS != null)
                {
                    DataSet dataSet = WorkflowNote.GetByPositionDescriptionID(PD.PositionDescriptionID);
                    rgWorkflowNote.DataSource = dataSet;

                    //List<WorkflowNote> list = WorkflowNote.GetByPositionDescriptionID(PD.PositionDescriptionID);
                    //rgWorkflowNote.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void rgWorkflowNote_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem gridDataItem = e.Item as GridDataItem;

                    if (gridDataItem.ItemType == GridItemType.Item || gridDataItem.ItemType == GridItemType.AlternatingItem || gridDataItem.ItemType == GridItemType.SelectedItem)
                    {
                        //((System.Data.DataRowView)(e.Item.DataItem)).Row.ItemArray
                        DataRowView dataRowView = e.Item.DataItem as DataRowView;
                        DataRow row = dataRowView.Row;

                        ImageButton editWorkflowNoteButton = gridDataItem.FindControl("btnEditWorkflowNote") as ImageButton;
                        // [DO NOT DELETE THIS LINE!] GridButtonColumn gbcDelete = gridDataItem.FindControl("gbcDelete") as GridButtonColumn;

                        
                        //editWorkflowNoteButton.Attributes.Add("onclick", "ShowEditWorkflowNotePopup('" + PDIDQS.ToString() + "','" + IsCheckedOutQS.ToString() + "','" + row["WorkflowNoteID"].ToString() + "'); return false;");

                        //Added CheckedOutByID
                        editWorkflowNoteButton.Attributes.Add("onclick", "ShowEditWorkflowNotePopup('" + PDIDQS.ToString() + "','" + IsCheckedOutQS.ToString() + "','" + row["WorkflowNoteID"].ToString() + "','" + CheckedOutByID +"'); return false;");
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rgWorkflowNote_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == RadGrid.DeleteCommandName)
                {
                    if (e.Item is GridDataItem)
                    {
                        GridDataItem item = e.Item as GridDataItem;
                        int workflowNoteID = Convert.ToInt32(item.GetDataKeyValue("WorkflowNoteID"));

                        switch (e.CommandName)
                        {
                            case "DeleteButtonClicked":
                                DeleteWorkflowNote(workflowNoteID);
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void rgWorkflowNote_PageIndexChanged(object source, GridPageChangedEventArgs e)
        {
        }
        #endregion

        #region [ Private Methods ]
        private void LoadData()
        {
            txtWorkflowNote.Text = String.Empty;
        }
        private void setPageView()
        {
            try
            {
                if (PWS != null)
                {
                    PDAccessType accessType = CurrentPDAccessType;
                    PDStatus pwsStatus = (PDStatus)PWS.WorkflowStatusID;

                    bool notCheckedOut = IsCheckedOutQS == false ? true : false;
                    bool notEditable = (accessType == PDAccessType.ReadOnly);

                    switch (pwsStatus)
                    {
                        case PDStatus.Review:
                            notEditable = notEditable && base.HasPermission(enumPermission.MaintainHRSection);
                            break;
                        case PDStatus.Revise:
                            //notEditable = notEditable && base.HasPermission(enumPermission.CreatePD) && !base.HasPermission(enumPermission.MaintainHRSection);
                            notEditable = true;
                            break;
                        case PDStatus.FinalReview:
                        case PDStatus.Published:
                        case PDStatus.Inactive:
                            notEditable = true;
                            break;
                        default:
                            break;
                    }

                    if (notCheckedOut || notEditable)
                    {
                        panelAdd.Visible = false;
                    }
                    else
                    {
                        if (CheckedOutByID != base.CurrentUserID)
                        {
                            panelAdd.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        private void DeleteWorkflowNote(int workflowNoteID)
        {
            try
            {
                WorkflowNote workflowNote = new WorkflowNote(workflowNoteID);

                if (workflowNote != null)
                {
                    workflowNote.Delete();
                    rgWorkflowNote.Rebind();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion

        #region [ Private Properties ]
        private long PDIDQS
        {
            get
            {
                long id = -1;

                if (Page.Request.QueryString["PositionDescriptionID"] != null)
                {
                    id = long.Parse(Page.Request.QueryString["PositionDescriptionID"]);
                }

                return id;
            }
        }
        private bool IsCheckedOutQS
        {
            get
            {
                bool isCheckedOut = false;

                if (Page.Request.QueryString["IsCheckedOut"] != null)
                {
                    isCheckedOut = bool.Parse(Page.Request.QueryString["IsCheckedOut"]);
                }

                return isCheckedOut;
            }
        }
        //Added to hold checkout by id
        private int CheckedOutByID
        {
            get
            {
                int CheckOutByID = 0;

                if (Page.Request.QueryString["CheckedOutByID"] != null)
                {
                    if (Page.Request.QueryString["CheckedOutByID"] != "")
                        CheckOutByID = int.Parse(Page.Request.QueryString["CheckedOutByID"]);
                }

                return CheckOutByID;
            }
        }
        private PositionDescription PD
        {
            get
            {
                if (pd == null && PDIDQS != -1)
                {
                    pd = new PositionDescription(PDIDQS);
                }

                return pd;
            }
        }
        private PositionWorkflowStatus PWS
        {
            get
            {
                if (PD != null && pws == null)
                {
                    pws = PD.GetCurrentPositionWorkflowStatus();
                }

                return pws;
            }
        }
        #endregion

        #region [ Private Fields ]
        private PositionDescription pd = null;
        private PositionWorkflowStatus pws = null;
        #endregion
    }
}
