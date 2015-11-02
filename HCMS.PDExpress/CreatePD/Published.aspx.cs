using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace HCMS.PDExpress.CreatePD
{
    public partial class Published : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MasterPage masterPage = this.Page.Master;

                if (masterPage != null)
                {
                    HCMS.PDExpress.PDMaster site = masterPage as HCMS.PDExpress.PDMaster;
                    string strmsg = "Position Description published successfully.";
                    int i = 0;
                    if (Request.QueryString.Count > 1)
                    {
                        for (i = 0; i < Request.QueryString.Count; i++)
                        {

                            if (i == 0)
                            {
                                strmsg = string.Format("Position Descriptions: {0}", Request.QueryString[i]);
                            }
                            else
                            {
                                strmsg = string.Format("{0},{1}", strmsg, Request.QueryString[i]);
                            }

                        }

                    }
                    else if (Request.QueryString.Count == 1)
                    {
                        strmsg = string.Format("Position Description: {0}", Request.QueryString[0]);
                    }
                    else
                    {
                        strmsg = "Position Description ";
                    }


                    strmsg = string.Format("{0} published successfully.", strmsg);

                    if (site != null)
                    {
                        site.PrintSystemMessage(strmsg, false);
                    }
                }
            }
        }

        public string getDashboardPageURL()
        {   string url = string.Empty;

            //string s = Request.ServerVariables["HTTPS"] == "on" ? "s" : "";
            //string serverProtocol = Request.ServerVariables["SERVER_PROTOCOL"].ToLower();
            //string protocol = serverProtocol.Substring(0, serverProtocol.IndexOf('/')) + s;
            //string port = Request.ServerVariables["SERVER_PORT"] == "80" ? "" : ":" + Request.ServerVariables["SERVER_PORT"];
            //string serverName = Request.ServerVariables["SERVER_NAME"];
            //string scriptName = Request.ServerVariables["SCRIPT_NAME"];
            //string virtualPath = HttpRuntime.AppDomainAppVirtualPath;
            
            //if (virtualPath.StartsWith("/") == false)
            //{
            //    virtualPath = "/" + virtualPath;
            //}

            //url = protocol + "://" + serverName + port + virtualPath + "/Default.aspx";

            url = ConfigurationManager.AppSettings["PDExpressDefaultURL"].ToString();
            return Page.ResolveClientUrl(url);
            
        }
    }
}
