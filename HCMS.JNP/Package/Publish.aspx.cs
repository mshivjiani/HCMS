using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
using System.Configuration;

namespace HCMS.JNP.Package
{
    public partial class Publish :  System.Web.UI.Page //JNPPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MasterPage masterPage = this.Page.Master;

                HCMS.JNP.JNPMaster site = masterPage as HCMS.JNP.JNPMaster;

                //base.ShowTopMenu = false;
                //base.ShowSubMenu = false;


                //base.PageTitle = "JAX Published";
                //base.ShowRequiredFieldMessage = false;
                //base.ShowInformationDiv = false;
                //((JNPMaster)this.Master).ShowNotesLink = false;

                
                //base.ShowTopMenu = false;
                //HCMS.WebFramework.BasePages.JNPPageBase.
                ((MasterPageBase)Master).ShowTopMenu = false;
                ((MasterPageBase)Master).ShowSubMenu = false;
                ((MasterPageBase)Master).ShowRequiredFieldMessage = false;
                ((MasterPageBase)Master).ShowInformationDiv = false;
                ((JNPMaster)this.Master).ShowNotesLink = false;


                string strmsg = "Job Announcement published successfully.";
                if (Request.QueryString["JNPID"] != null)
                {
                    string JNPID = Request.QueryString["JNPID"].ToString();
                    strmsg = string.Format("Job Announcement: {0} published successfully.", JNPID);
                }
                site.PrintSystemMessage(strmsg, true);
            }            
        }

        public string getDashboardPageURL()
        {
            string url = string.Empty;
            url = System.Configuration.ConfigurationManager.AppSettings["JNPDefaultURL"].ToString();
            return Page.ResolveClientUrl(url);

        }
    }
}