using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace HCMS.Business.Common
{
    /// <summary>
    /// Severity level of exception
    /// </summary>
    public enum SeverityLevel : int
    {
        Debug = 1,
        Error = 2,
        Information = 3,
        Warn = 4,
        Fatal = 5
    }

    [Serializable]
    public class BusinessException : System.ApplicationException
    {
        #region Fields

        private SeverityLevel _severityLevel = SeverityLevel.Information;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public BusinessException()
            : base()
        {
            // Empty Constructor
        }

        public BusinessException(string exceptionMessage)
            : base(exceptionMessage)
        {
            this._severityLevel = SeverityLevel.Error;
            logException();
        }

        public BusinessException(string exceptionMessage, Exception innerEx)
            : base(exceptionMessage, innerEx)
        {
            this._severityLevel = SeverityLevel.Error;
            logException();
        }

        public BusinessException(Exception ex)
            : base(ex.Message)
        {
            this._severityLevel = SeverityLevel.Error;
            logException();
        }

        public BusinessException(SeverityLevel severity, string exceptionMessage)
            : base(exceptionMessage)
        {
            this._severityLevel = severity;
            logException();
        }

        public BusinessException(SeverityLevel severity, Exception ex)
            : base(ex.Message)
        {
            this._severityLevel = severity;
            logException();
        }

        #endregion

        #region Logging Methods

        private void logException()
        {
            LogException(base.Message);
        }

        private void LogException(string exceptionMessage)
        {

            LogEntry entry = new LogEntry();
            entry.Message = exceptionMessage;
            entry.EventId = 80;
            entry.MachineName = System.Environment.UserName + "/" + System.Environment.MachineName;
            entry.TimeStamp = DateTime.Now;
            
            // log the exception to some destination (log file, event log, etc.)
            switch (this._severityLevel)
            {
                case SeverityLevel.Debug:
                    entry.Severity = System.Diagnostics.TraceEventType.Verbose;
                    break;
                case SeverityLevel.Error:
                    entry.Severity = System.Diagnostics.TraceEventType.Error;
                    break;
                case SeverityLevel.Fatal:
                    entry.Severity = System.Diagnostics.TraceEventType.Critical;
                    break;
                case SeverityLevel.Information:
                    entry.Severity = System.Diagnostics.TraceEventType.Information;
                    break;
                case SeverityLevel.Warn:
                    entry.Severity = System.Diagnostics.TraceEventType.Warning;
                    break;
            }
        
            Logger.Write(entry);
        }

        #endregion
    }
}
