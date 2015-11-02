using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.JNP;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.JNPWorkflowNote;

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
    public partial class EditJNPWorkflowNotePopup : UserControlBase // CreatePDUserControlBase //System.Web.UI.UserControl
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
        protected void btnSaveEditJNPWorkflowNote_Click(object sender, EventArgs e)
        {
            try
            {
                JNPWorkflowNote workflowNote = JNPWorkflowNote.GetByID(JNPWorkflowNoteIDQS);

                if (workflowNote != null)
                {
                    workflowNote.UpdateDate = DateTime.Now;
                    workflowNote.UpdatedByID = base.CurrentUser.UserID;
                    workflowNote.UpdateNote = txtUpdateNote.Text;
                    workflowNote.JNPWorkflowNoteStatusID = Convert.ToInt32(ddlStatus.SelectedValue);
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
                JNPWorkflowNote workflowNote = JNPWorkflowNote.GetByID(JNPWorkflowNoteIDQS);

                if (workflowNote != null)
                {
                    ControlUtility.SafeTextBoxAssign(txtCreatedDate, workflowNote.CreateDate.ToString("MM/dd/yyyy"));
                    ControlUtility.SafeTextBoxAssign(txtCreatedBy, workflowNote.CreatedBy);
                    ControlUtility.SafeTextBoxAssign(txtUpdatedDate, workflowNote.UpdateDate.ToString("MM/dd/yyyy"));
                    ControlUtility.SafeTextBoxAssign(txtUpdatedBy, workflowNote.UpdatedBy);
                    ControlUtility.SafeTextBoxAssign(txtDescription, workflowNote.Note);
                    ControlUtility.SafeTextBoxAssign(txtUpdateNote, workflowNote.UpdateNote);
                    List<JNPWorkflowNoteStatus> noteStatusList = JNPWorkflowNoteStatus.GetAll();
                    ddlStatus.DataSource = noteStatusList;
                    ddlStatus.DataBind();

                    ddlStatus.SelectedValue = workflowNote.JNPWorkflowNoteStatusID.ToString();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        private void SetView()
        {
            try
            {
                if (IsInEditModeQS)
                { this.btnSaveEditWorkflowNote.Enabled = true; }
                else
                {
                    this.btnSaveEditWorkflowNote.Enabled = false;
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
        public int JNPWorkflowNoteIDQS
        {
            get
            {
                int id = -1;

                if (Page.Request.QueryString["JNPWorkflowNoteID"] != null)
                {
                    id = int.Parse(Page.Request.QueryString["JNPWorkflowNoteID"]);
                }

                return id;
            }
        }
        private JNPackage  JNP
        {
            get
            {
                if (jnp == null && JNPIDQS != -1)
                {
                    int jnpid = (int)JNPIDQS;
                    jnp = new JNPackage(jnpid);
                }

                return jnp;
            }
        }
 
        #endregion

        #region [ Private Fields ]
        private JNPackage  jnp = null;
       
        #endregion
    }
}