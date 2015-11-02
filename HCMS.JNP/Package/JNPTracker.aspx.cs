using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.JNP.Package
{
    public partial class JNPTracker : JNPPageBase 
    {
        protected override void   Page_Load(object sender, EventArgs e)
        {
            base.SelectLeftMenuItem = enumLeftMenuItem.None;
            base.ShowTopMenu = false;
            //base.SelectTopMenuItem = enumTopMenuItem.JNPTracker;
            base.ShowSubMenu = false;
            base.PageTitle = "JAX Tracker";
            base.ShowInformationDiv = false;
           
            ((JNPMaster)(this.Master)).ShowNotesLink = false;
           
        }
      
    }
}