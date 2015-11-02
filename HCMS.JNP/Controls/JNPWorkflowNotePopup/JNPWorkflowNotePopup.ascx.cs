using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HCMS.Business.JNP;
using HCMS.WebFramework.BaseControls;
using System.Data;

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

namespace HCMS.JNP.Controls.JNPWorkflowNotePopup
{
    public partial class JNPWorkflowNotePopup : JNPUserControlBase
    {
        #region [ Page Event Handlers ]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                SetView();
            }
        }
        #endregion

        #region [Other Control Events]
        protected void btnAddJNPWorkflowNote_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtJNPWorkflowNote.Text))
                {
                    if (JNP != null && jnpws != null)
                    {
                        DateTime createDate = DateTime.Now;
                        JNPWorkflowNote workflowNote = new JNPWorkflowNote();

                        workflowNote.JNPWorkflowRecID = jnpws.JNPWorkflowRecID;
                        workflowNote.Note = txtJNPWorkflowNote.Text;
                        workflowNote.JNPWorkflowNoteStatusID = Convert.ToInt32(enumJNPWorkflowNoteStatus.Open);
                        workflowNote.CreatedByID = base.CurrentUser.UserID;
                        workflowNote.CreateDate = createDate;
                        workflowNote.UpdatedByID = base.CurrentUser.UserID;
                        workflowNote.UpdateDate = createDate;
                        workflowNote.UpdateNote = String.Empty;

                        workflowNote.Add();

                        txtJNPWorkflowNote.Text = String.Empty;

                        rgJNPWorkflowNote.Rebind();
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
                rgJNPWorkflowNote.Rebind();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion

        #region [ Workflow Note Grid Event Handlers ]
        protected void rgJNPWorkflowNote_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                if (JNP != null && jnpws != null)
                {
                    DataSet dataSet = JNPWorkflowNote.GetByJNPID(JNP.JNPID);
                    rgJNPWorkflowNote.DataSource = dataSet;

                    #region [ List vs. DataSet ? ]
                    //List<WorkflowNote> list = WorkflowNote.GetByPositionDescriptionID(PD.PositionDescriptionID);
                    //rgJNPWorkflowNote.DataSource = list;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void rgJNPWorkflowNote_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
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

                        ImageButton editJNPWorkflowNoteButton = gridDataItem.FindControl("btnEditJNPWorkflowNote") as ImageButton;
                        ImageButton viewJNPWorkflowNoteButton = gridDataItem.FindControl("ImageButtonView") as ImageButton;
                        // [DO NOT DELETE THIS LINE!] GridButtonColumn gbcDelete = gridDataItem.FindControl("gbcDelete") as GridButtonColumn;

               
                        string url = Page.ResolveUrl("~/JNPWorkflowNotePopup/EditJNPWorkflowNotePopup.aspx");
                        editJNPWorkflowNoteButton.Attributes.Add("onclick", "ShowEditJNPWorkflowNotePopup('" + url + "', '" + JNPIDQS.ToString() + "','" + IsInEditModeQS.ToString() + "','" + row["JNPWorkflowNoteID"].ToString() + "'); return false;");
                        viewJNPWorkflowNoteButton.Attributes.Add("onclick", "ShowEditJNPWorkflowNotePopup('" + url + "', '" + JNPIDQS.ToString() + "','" + IsInEditModeQS.ToString() + "','" + row["JNPWorkflowNoteID"].ToString() + "'); return false;");
                        // [DO NOT DELETE THIS LINE!] gbcDelete.ImageUrl = Page.ResolveUrl("~/App_Themes/PDExpress/Images/Icons/icon_delete.gif");
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void rgJNPWorkflowNote_ItemCommand(object source, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("DeleteButtonClicked"))
                {
                    if (e.Item is GridDataItem)
                    {
                        GridDataItem item = e.Item as GridDataItem;
                        int jnpWorkflowNoteID = Convert.ToInt32(item.GetDataKeyValue("JNPWorkflowNoteID"));

                        switch (e.CommandName)
                        {
                            case "DeleteButtonClicked":
                                DeleteJNPWorkflowNote(jnpWorkflowNoteID);
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
        protected void rgJNPWorkflowNote_PageIndexChanged(object source, GridPageChangedEventArgs e)
        {
        }
        #endregion

        #region [ Private Methods ]
        private void LoadData()
        {
            txtJNPWorkflowNote.Text = String.Empty;
        }

        private void SetView()
        {
            try
            {
                if (IsInEditModeQS)
                {
                    panelAdd.Visible = true;

                    rgJNPWorkflowNote.Columns[0].Visible = true; // edit column
                    rgJNPWorkflowNote.Columns[1].Visible = true;//delete column
                    rgJNPWorkflowNote.Columns[1].Display = true;//setting the visible=false does not hide the gridbuttoncolumn --delete column
                    rgJNPWorkflowNote.Columns[2].Display = false; //view column  
                }
                else
                {
                    panelAdd.Visible = false;

                    rgJNPWorkflowNote.Columns[0].Visible = false; // edit column
                    rgJNPWorkflowNote.Columns[1].Visible = false;//delete column
                    rgJNPWorkflowNote.Columns[1].Display = false;//setting the visible=false does not hide the gridbuttoncolumn --delete column
                    rgJNPWorkflowNote.Columns[2].Display = true; //view column
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void DeleteJNPWorkflowNote(int jnpWorkflowNoteID)
        {
            try
            {
                JNPWorkflowNote jnpWorkflowNote = JNPWorkflowNote.GetByID(jnpWorkflowNoteID);

                if (jnpWorkflowNote != null)
                {
                    jnpWorkflowNote.Delete(this.CurrentUserID);
                    rgJNPWorkflowNote.Rebind();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion

        #region [ Private Properties ]
        private long JNPIDQS
        {
            get
            {
                long id = -1;

                if (Page.Request.QueryString["JNPID"] != null)
                {
                    id = long.Parse(Page.Request.QueryString["JNPID"]);
                }

                return id;
            }
        }

        /// <summary>
        /// checking the mode from the querystring instead from base.IsInEdit
        /// because this gives capability to open this window from any where and
        /// set the mode -
        /// be called from JAnP tracker and in that case the value can be false
        /// </summary>
        private bool IsInEditModeQS
        {
            get
            {
                bool isineditmode = false;

                if (Page.Request.QueryString["IsInEdit"] != null)
                {
                    isineditmode = bool.Parse(Page.Request.QueryString["IsInEdit"]);
                }

                return isineditmode;
            }
        }
        private JNPackage JNP
        {
            get
            {
                if (jnp == null && JNPIDQS != -1)
                {
                    long jnpid = (long)JNPIDQS;
                    jnp = new JNPackage(jnpid);
                }

                return jnp;
            }
        }

        /// <summary>
        /// checking the current jnp ws for the jnpid that is passed as query string
        /// not checking base.currentjnpws - query string value gives ability to be
        /// called without base.currentjnpws
        /// </summary>
        private JNPWorkflowStatus jnpws
        {
            get
            {
                if (JNPIDQS > 0)
                {
                    jws = JNPWorkflowStatus.GetCurrentJNPWorkflowStatus(JNPIDQS);
                    
                }
                return jws;
            }
        }
        #endregion

        #region [ Private Fields ]
        private JNPackage jnp = null;
        private JNPWorkflowStatus jws = null;
        #endregion
    }
}