using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.Business.Common ;
namespace HCMS.JNP.Common
{
    public partial class FAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((JNPMaster)this.Master).ShowTopMenu  = false;
            ((JNPMaster)this.Master).ShowInformationDiv = false;
            ((JNPMaster)this.Master).ShowSubMenu = false;
            ((JNPMaster)this.Master).ShowNotesLink = false;
            ((JNPMaster)this.Master).PageTitle = "FAQ";
            ((JNPMaster)this.Master).SelectLeftMenuItem = enumLeftMenuItem.FAQ;

        }
    }
}