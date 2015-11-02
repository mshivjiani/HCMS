using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

//using Telerik.Web.UI;

//using HCMS.Business.Base;
//using HCMS.Business.Common;
//using HCMS.Business.Search;
//using HCMS.WebFramework.Site.Utilities;
//using HCMS.WebFramework.Site.Wrappers;

using HCMS.WebFramework.BasePages;

namespace HCMS.PDExpress
{
    public partial class SearchReportsAdvanced : PageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.PageTitle = "Search/Reports";
            base.ShowRequiredFieldMessage = true;
            base.OnPreRender(e);
        }
    }
}
