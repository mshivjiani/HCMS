using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCMS.Portal
{
    public partial class AjaxSessionUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        Response.ContentType = "text/html";
        Response.Write(string.Format ("Session Updated - Server Time:{0}" , DateTime.Now.ToString ()));

        }
    }
}
