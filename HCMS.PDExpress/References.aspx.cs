using System;

using HCMS.WebFramework.BasePages;
namespace HCMS.PDExpress
{
    public partial class References : PageBase 
    {
      
      
        protected override void OnPreRender(EventArgs e)
        {
            base.PageTitle = "References";
            
            base.OnPreRender(e);
        }

    }
}
