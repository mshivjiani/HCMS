using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.Portal.Admin
{
    public partial class WorkflowRuleAdministration : AdminPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);

            base.OnInit(e);
        }
        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.TopMenu = enumTopMenuType.AdminMenu;
                base.LeftMenu = LeftMenuType.JNPAdminMenu;
                base.SelectTopMenuItem = enumTopMenuItem.JNPAdmin;
                base.SelectLeftMenuItem = enumLeftMenuItem.WorkflowRuleAdmin;               
                base.PageTitle = "Workflow Rule Administration";
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }        
    }
}