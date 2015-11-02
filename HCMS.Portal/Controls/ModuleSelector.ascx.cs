using System;
using HCMS.WebFramework.BaseControls;
using HCMS.Business;
using HCMS.Business.Security;
using Telerik.Web.UI;
using System.Collections.Generic;

using System.Web.UI.WebControls;
using HCMS.Business.Admin.Workforce;

namespace HCMS.Portal.Controls
{
    public partial class ModuleSelector : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var tabRules = new SecurityManager.UIRules.PortalTabs();
            
            RadTab adminTab = this.RadTabStripModSel.FindTabByValue("Admin");
            if (adminTab != null) adminTab.Enabled = base.IsAdmin;

            RadTab jnpTab = this.RadTabStripModSel.FindTabByValue("JNP");
            if (jnpTab != null) jnpTab.Enabled = (base.IsAdmin || tabRules.IsJAnPEnabledForUser(base.CurrentUser));

            RadTab orgChartTab = this.RadTabStripModSel.FindTabByValue("oc");
            if (orgChartTab != null) orgChartTab.Enabled = (base.IsAdmin || tabRules.IsOrgChartEnabledForUser(base.CurrentUser));
            
            
            tabRules = null;


            DashboardRoleManager dm = new DashboardRoleManager();
            List<HCMS.Business.Admin.Workforce.DashboardRole> dr = dm.GetRoleForUser(-1,-1,-1,base.CurrentUserID);
            
            RadTab workflowTab = this.RadTabStripModSel.FindTabByValue("wf");
            if (dr.Count > 0)
            {
                if (workflowTab != null)
                    workflowTab.Visible = true;
            }
            else
            {
                if (workflowTab != null)
                    workflowTab.Visible = false;
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            Button button = this.btnEnter as Button;
            if (button != null)
            {
                this.Page.Form.DefaultButton = button.UniqueID;

                button.Focus();
            }

            base.OnPreRender(e);
        }
        protected void btnEnter_Click(object sender, EventArgs e)
        {
            string redirectURL = string.Empty;

            string selectedtab = this.RadTabStripModSel.SelectedIndex.ToString();

            switch (selectedtab)
            {
                case "0":
                    redirectURL = System.Configuration.ConfigurationManager.AppSettings["PDExpressDefaultURL"].ToString();
                    break;
                case "1":
                    redirectURL = System.Configuration.ConfigurationManager.AppSettings["JNPDefaultURL"].ToString();
                    break;
                case "2":
                    redirectURL = System.Configuration.ConfigurationManager.AppSettings["OrgChartDefaultURL"].ToString();
                    break;
                case "3":
                    redirectURL = System.Configuration.ConfigurationManager.AppSettings["WorkforceURL"].ToString();
                    
                    break;
                case "4":
                    redirectURL = System.Configuration.ConfigurationManager.AppSettings["AdminDefaultURL"].ToString();//"~/Admin/Default.aspx";
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(redirectURL)) 
            {
                Response.RedirectPermanent(redirectURL, true);
            }
        }


    }
}