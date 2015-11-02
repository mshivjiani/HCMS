using System;
using HCMS.WebFramework.BasePages;

namespace HCMS.PDExpress.CreatePD
{
    public partial class ShowDiff : PageBase 
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.PageTitle = "Show Difference"; // setting value here does not make any difference. Use @Page Title to set the page's title.
            base.ShowRequiredFieldMessage = false ;
            base.OnPreRender(e);
        }
    }
}
