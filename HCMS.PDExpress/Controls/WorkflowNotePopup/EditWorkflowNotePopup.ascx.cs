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
    public partial class EditWorkflowNotePopup1 : CreatePDUserControlBase
    {
        #region [ Page Event Handlers ]
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            base.OnInit(e);
        }
        private void Page_Load(object sender, EventArgs e)
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

        #region [ Page Controls Events Handlers ]
        protected void btnSaveEditWorkflowNote_Click(object sender, EventArgs e)
        {
            try
            {
                WorkflowNote workflowNote = new WorkflowNote(WorkflowNoteIDQS);
             
                if (workflowNote != null)
                {
                    workflowNote.UpdateDate = DateTime.Now;
                    workflowNote.UpdatedByID = base.CurrentUser.UserID;
                    workflowNote.UpdateNote = txtUpdateNote.Text;
                    workflowNote.NoteStatusID = Convert.ToInt32(ddlStatus.SelectedValue);
                    workflowNote.Note = txtDescription.Text;

                    workflowNote.Update();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion

        #region [ Private Methods ]
        private void LoadData()
        {
            try
            {
                WorkflowNote workflowNote = new WorkflowNote(WorkflowNoteIDQS);

                if (workflowNote != null)
                {
                    ControlUtility.SafeTextBoxAssign(txtCreatedDate, workflowNote.CreateDate.ToString("MM/dd/yyyy"));
                    ControlUtility.SafeTextBoxAssign(txtCreatedBy, workflowNote.CreatedBy);
                    ControlUtility.SafeTextBoxAssign(txtUpdatedDate, workflowNote.UpdateDate.ToString("MM/dd/yyyy"));
                    ControlUtility.SafeTextBoxAssign(txtUpdatedBy, workflowNote.UpdatedBy);
                    ControlUtility.SafeTextBoxAssign(txtDescription, workflowNote.Note);
                    ControlUtility.SafeTextBoxAssign(txtUpdateNote, workflowNote.UpdateNote);
                    List<NoteStatus> noteStatusList = LookupWrapper.GetAllNoteStatuses(true);
                    ddlStatus.DataSource = noteStatusList;
                    ddlStatus.DataBind();

                    ddlStatus.SelectedValue = workflowNote.NoteStatusID.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        private void setPageView()
        {
            try
            {
                if (PWS != null)
                {
                    PDAccessType accessType = GetPDAccessType(PD);
                    PDStatus pwsStatus = (PDStatus)PWS.WorkflowStatusID;
                    WorkflowNote workflowNote = new WorkflowNote(WorkflowNoteIDQS);
                    bool notCheckedOut = IsCheckedOutQS == false ? true : false;
                    bool notEditable = (accessType == PDAccessType.ReadOnly);
                    //Description is editable if the PD is checked out and note is created by the user that is currently logged in.
                    bool DescEditable = (accessType != PDAccessType.ReadOnly) && (IsCheckedOutQS == true) && (base.CurrentUser.UserID == workflowNote.CreatedByID );
                    this.txtDescription.ReadOnly = !DescEditable;
                    switch (pwsStatus)
                    {
                        case PDStatus.Review:
                            notEditable = notEditable && base.HasPermission(enumPermission.CreatePD);
                            break;
                        case PDStatus.Revise:
                            notEditable = notEditable && base.HasPermission(enumPermission.CreatePD);
                            break;
                        case PDStatus.FinalReview:
                            notEditable = notEditable && base.HasPermission(enumPermission.MaintainHRSection);
                            break;
                        default:
                            break;
                    }
                    if (notCheckedOut || notEditable)
                    {
                        this.btnSaveEditWorkflowNote.Enabled = false;
                    }
                    else
                    {
                        if (CheckedOutByID != base.CurrentUserID)
                        {
                            this.btnSaveEditWorkflowNote.Enabled = false;
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

        public int WorkflowNoteIDQS
        {
            get
            {
                int id = -1;

                if (Page.Request.QueryString["WorkflowNoteID"] != null)
                {
                    id = int.Parse(Page.Request.QueryString["WorkflowNoteID"]);
                }

                return id;
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
