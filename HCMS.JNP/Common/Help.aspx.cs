using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCMS.JNP.Common
{
    public partial class Help : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((JNPMaster)this.Master).ShowTopMenu = false;
            ((JNPMaster)this.Master).ShowInformationDiv = false;
            ((JNPMaster)this.Master).ShowSubMenu = false;
            ((JNPMaster)this.Master).ShowNotesLink = false;
            ((JNPMaster)this.Master).PageTitle = "Help";
            ((JNPMaster)this.Master).SelectLeftMenuItem = enumLeftMenuItem.Help;
        }
    }
}