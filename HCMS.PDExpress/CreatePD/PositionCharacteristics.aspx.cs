using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.PD;
using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Search;
using HCMS.Business.Lookups;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.Common;
using HCMS.WebFramework.BasePages;

namespace HCMS.PDExpress.CreatePD
{
    public partial class PositionCharacteristics : CreatePDPageBase 
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.PDControlName = PDControlType.Characteristics;
            base.ShowRequiredFieldMessage = true;
            base.OnPreRender(e);
        }
    }
}
