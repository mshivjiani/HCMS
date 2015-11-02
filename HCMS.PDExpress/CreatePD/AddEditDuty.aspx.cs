using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.PDExpress.CreatePD
{
    public partial class AddEditDuty : CreatePDPageBase 
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.PDControlName = PDControlType.Duties;
            base.ShowRequiredFieldMessage = true;
            base.OnPreRender(e);
        }
    }
}
