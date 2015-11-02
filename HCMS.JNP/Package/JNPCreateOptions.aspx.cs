using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.JNP.Package
{
    public partial class JNPCreateOptions : JNPPageBase 
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SelectLeftMenuItem = enumLeftMenuItem.None;
            //base.SelectTopMenuItem = enumTopMenuItem.Create;
            base.ShowTopMenu = false;
            base.ShowSubMenu = false;
            base.PageTitle = "Create Job Announcement";
            base.ShowRequiredFieldMessage = true;
            base.ShowInformationDiv = false;
            ((JNPMaster)this.Master).ShowNotesLink = false;
        }
    }
}