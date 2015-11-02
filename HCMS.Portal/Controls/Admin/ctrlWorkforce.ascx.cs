using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlWorkforce : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["WorkforceURL"] != null)
            {
                string wfURL = System.Configuration.ConfigurationManager.AppSettings["WorkforceURL"].ToString();

                //iwf.Attributes["src"] = wfURL;
            }
        }
    }
} 