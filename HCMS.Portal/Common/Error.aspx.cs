using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCMS.Portal.Common
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Error";
            string strError = "Undefined";
            bool errorRetrievedFromSession = false;

            try
            {
                if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
                {
                    if (Session["error"] != null)
                    {
                        strError = Session["error"].ToString();
                        errorRetrievedFromSession = true;
                    }
                }

                if (errorRetrievedFromSession == false)
                {
                    #region [ this part is identical to the code found in Application_Error() event handler ]
                    bool showException = Request.QueryString["showException"] != null;
                    string message = String.Empty;
                    Exception lastException = Server.GetLastError();

                    if (lastException != null)
                    {
                        Exception lastBaseException = lastException.GetBaseException();

                        if (lastBaseException != null)
                            message = showException ? lastBaseException.ToString() : lastBaseException.Message;
                        else
                            message = showException ? lastException.ToString() : lastException.Message;
                    }

                    strError = String.Format("<b>Location</b> : {0}<br /><b>Message</b> : {1} ", Request.Url.ToString(), message);
                    #endregion
                }

                Server.ClearError();
            }
            catch
            { }

            this.litError.Text = strError;
        }
    }
}
