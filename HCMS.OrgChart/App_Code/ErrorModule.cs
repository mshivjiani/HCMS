using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace HCMS.OrgChart.App_Code
{
    public class ErrorModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            context.Error += new EventHandler(OnContextError);
        }

        #endregion

        static void OnContextError(object sender, EventArgs e)
        {
            HttpContext ctx = HttpContext.Current;
            HttpRequest request = ctx.Request;
            bool rethrow = false;
            if (request.Path.IndexOf("/ApplicationError.aspx") == -1)
            {

                Exception serverException = ctx.Server.GetLastError().GetBaseException();
                string policy = "Default Policy";
                if (ctx.Items["Policy"] != null)
                {
                    policy = ctx.Items["Policy"].ToString();
                }
                HandleException(serverException, policy);



            }
            if (null != HttpContext.Current && null != HttpContext.Current.Session)
            {
                ctx.Session.Abandon();
            }
        }

        public static void HandleException(Exception ex, string policy)
        {
            Boolean rethrow = false;
            try
            {
                LogException(ex, policy);

                if (ex is HttpRequestValidationException)
                {
                    HttpContext.Current.ClearError(); // ClearError() stop bubble up to Application_Error()。
                    Exception newException = new Exception("Request server with illigal character");
                    HttpContext.Current.Session.Abandon();
                    rethrow = ExceptionPolicy.HandleException(newException, policy);

                    //HttpContext.Current.Server.Transfer("~/Common/Error.aspx");
                }
                else
                {
                    rethrow = ExceptionPolicy.HandleException(ex, policy);
                }

            }
            catch (Exception innerEx)
            {
                string errormsg = string.Format("An unexpected exception occured while calling HandleException with policy -{0}.", policy);
                string err = string.Concat(errormsg, Environment.NewLine, innerEx.ToString());
                if (rethrow)
                { throw; }
            }
        }

        public static void LogException(Exception ex, string policy)
        {
            LogEntry entry = new LogEntry();
            entry.Message = ex.ToString();
            //entry.Severity = System.Diagnostics.TraceEventType.Error;
            //entry.EventId = 80;
            entry.MachineName = System.Environment.UserName + "/" + System.Environment.MachineName;
            entry.TimeStamp = DateTime.Now;
            Logger.Write(entry);
        }
    }
}