using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Telerik.Web.UI;

using HCMS.Business.PD;
using HCMS.Business.Duty;
using HCMS.Business.Lookups;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.PDExpress.Controls.CreatePD
{
    public partial class CreatePDWorkflowNote : CreatePDUserControlBase
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (base.CurrentPDID != NULLPDID)
                {
                    // The workflow notes are different than the other PD controls
                    // Workflow notes are editable for all users that can see the PD --
                    // as long as the PD is not in "View" mode and the PD is not Published
                    PositionWorkflowStatus pws = this.CurrentPDWorkflowStatus;
                    PDStatus pwsStatus = (PDStatus)pws.WorkflowStatusID;

                    if (this.IsViewOnly || pwsStatus == PDStatus.Revise || pwsStatus == PDStatus.FinalReview || pwsStatus == PDStatus.Published || pwsStatus == PDStatus.Inactive)
                        lbAddEditNotes.Text = "View Notes";
                    else
                        lbAddEditNotes.Text = "Add/Edit Notes";
                    
                    //lbAddEditNotes.Attributes.Add("OnClick", "ShowAddEditNotePopup('" + base.CurrentPDID.ToString() + "','" + base.CurrentPD.IsCheckedOut.ToString() + "'); return false;");

                     lbAddEditNotes.Attributes.Add("OnClick", "ShowAddEditNotePopup('" + base.CurrentPDID.ToString() + "','" + base.CurrentPD.IsCheckedOut.ToString() + "','" + base.CurrentPD.CheckedOutByID.ToString() + "'); return false;");
                    
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            base.OnLoad(e);
        }
    }
}