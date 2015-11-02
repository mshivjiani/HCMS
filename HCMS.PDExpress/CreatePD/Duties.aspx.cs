using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.PDExpress.CreatePD
{
    public partial class Duties : CreatePDPageBase
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.PDControlName = PDControlType.Duties;
            base.ShowRequiredFieldMessage = true;
            base.OnPreRender(e);
        }
    }
}
