using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;


namespace HCMS.JNP.Controls.JNPWorkflowNotePopup
{
    public partial class JNPWorkflowNotePopupLink : JNPUserControlBase  // CreatePDUserControlBase // System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (base.IsInEdit)
                lbAddEditNotes.Text = "Add/Edit Notes";
            else
                lbAddEditNotes.Text = "View Notes";
            
            lbAddEditNotes.Attributes.Add("OnClick", "ShowAddEditNotePopup('" + base.CurrentJNPID.ToString() + "','" + base.IsInEdit.ToString() + "'); return false;");
            
        }
    }
}