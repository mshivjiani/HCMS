using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BasePages;

namespace HCMS.Portal.Common
{
    public partial class FAQ :PageBase 
    {
       
        protected override void OnPreRender(EventArgs e)
        {
            base.PageTitle = "FAQ";
            
            base.OnPreRender(e);
        }
    }
}
