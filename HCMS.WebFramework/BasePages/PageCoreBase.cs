using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Threading;

namespace HCMS.WebFramework.BasePages
{
    public abstract class PageCoreBase : Page
    {
        public void HandleException(Exception ex)
        {
            if (!(ex is ThreadAbortException))
            {
                StringBuilder exceptionMessage = new StringBuilder(string.Concat("[Error Encountered]:  ", ex.ToString()));

                if (ex.InnerException != null)
                    exceptionMessage.Append(string.Concat("-- Inner: ", ex.InnerException.Message));

                this.LogExceptionOnly(exceptionMessage.ToString());
            }
        }

        public void LogExceptionOnly(string exceptionMessage)
        {
            LogEntry entry = new LogEntry();
            entry.Message = exceptionMessage;
            entry.EventId = 80;
            entry.MachineName = System.Environment.UserName + "/" + System.Environment.MachineName;
            entry.TimeStamp = DateTime.Now;

            // log the exception to some destination (log file, event log, etc.)
            Logger.Write(entry);
        }
    }
}
