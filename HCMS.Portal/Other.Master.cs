using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Telerik.Web.UI;

namespace HCMS
{
    public partial class Other : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void setNavigation()
        {
            //disabled this because added contact administrator link
            //if user has issues related to login into PDExpress, they should see this link in the footer
            //so footer should be visible here

            //bool blnDisplay = Context.User.Identity.IsAuthenticated;
           
            //footerNav.Visible = blnDisplay;

            radMenuFooter.LoadContentFile("~/App_Data/FooterOtherMaster.xml");
            RadMenuItem supportdeskitem = radMenuFooter.FindItemByValue("SupportDesk");
            if (supportdeskitem != null)
            {
                supportdeskitem.NavigateUrl = ConfigurationManager.AppSettings["SupportDeskURL"].ToString();

            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            //Sets the default page title
            setNavigation();
            base.OnPreRender(e);
        }
    }
}
