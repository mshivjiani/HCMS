using System;


using HCMS.WebFramework.BasePages;

namespace HCMS.Portal
{
    public partial class Default : PageBase 
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void OnPreRender(EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                base.PageTitle = "Module Selection";
                base.ShowLeftMenu = false;
            }
            else
                base.PageTitle = "Login";
            
            base.OnPreRender(e);
        }
    }
}
