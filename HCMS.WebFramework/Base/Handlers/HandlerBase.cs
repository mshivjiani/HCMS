﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace HCMS.WebFramework.Base.Handlers
{
    public abstract class HandlerBase
    {
        public void LogExceptionOnly(Exception ex)
        {
            this.LogExceptionOnly(ex.ToString());
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
