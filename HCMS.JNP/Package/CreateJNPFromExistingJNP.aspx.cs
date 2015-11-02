using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.JNP;
using HCMS.WebFramework.BasePages;
using HCMS.JNP.Controls.Package;

namespace HCMS.JNP.Package
{
    public partial class CreateJNPFromExistingJNP : JNPPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.JNPDetails.JNPSaved += new ctrlCreateJNP.JNPSavedHandler(JNPDetails_JNPSaved);
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            base.SelectLeftMenuItem = enumLeftMenuItem.None;
            base.SelectTopMenuItem = enumTopMenuItem.Create;
            base.PageTitle = "Create Job Announcement From Existing JNP";
            base.ShowInformationDiv = false;
            ((JNPMaster)this.Master).ShowNotesLink = false;
            if (!Page.IsPostBack)
                this.JNPDetails.UseJNPTemplates = true;
        }

        private void JNPDetails_JNPSaved(JNPackage currentPackage)
        {
            try
            {
                base.SafeRedirect("~/JA/JAPositionInformation.aspx");
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
    }
}