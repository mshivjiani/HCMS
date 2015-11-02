using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.PDExpress.Controls.Message;

namespace HCMS.PDExpress.CreatePD
{
    public partial class Occupation : CreatePDPageBase 
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.PDControlName = PDControlType.Occupation;
            base.ShowRequiredFieldMessage = true;
            base.OnPreRender(e);
        }
    }
}
