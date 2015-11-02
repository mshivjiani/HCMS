using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.PDExpress.CreatePD
{
    public partial class Factors : CreatePDPageBase 
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.PDControlName = PDControlType.Factors;
            base.ShowRequiredFieldMessage = true;
            base.OnPreRender(e);
        }
    }
}
