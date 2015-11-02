using System;
using HCMS.Business.Common;

namespace HCMS.Business.Base
{
    /// <summary>
    /// Common Exception Handling Functionality
    /// </summary>
    [Serializable]
    public abstract class ExceptionBase
    {
        #region Exception Handling

        /// <summary>
        /// Handle the exception (ignores ThreadAbortExceptions)
        /// </summary>
        /// <param name="ex">Exception to be handled</param>
        public static void HandleException(Exception ex)
        {
            // log error using specifications in web.config
            if (!(ex is System.Threading.ThreadAbortException))
            {
                throw new BusinessException(ex);
            }
        }

        /// <summary>
        /// Handle the exception message
        /// </summary>
        /// <param name="exceptionMessage">The exception message to be handled</param>
        public static void HandleException(string exceptionMessage)
        {
            // log error using specifications in web.config
            throw new BusinessException(exceptionMessage);
        }

        /// <summary>
        /// Handle the exception message
        /// </summary>
        /// <param name="severity">Severity of the Exception</param>
        /// <param name="exceptionMessage">The exception message to be handled</param>
        public static void HandleException(SeverityLevel severity, string exceptionMessage)
        {
            // log error using specifications in web.config
            throw new BusinessException(severity, exceptionMessage);
        }

        /// <summary>
        /// Handle the exception (ignores ThreadAbortExceptions)
        /// </summary>
        /// <param name="severity">Severity of the Exception</param>
        /// <param name="ex">Exception to be handled</param>
        public static void HandleException(SeverityLevel severity, Exception ex)
        {
            // log error using specifications in web.config
            throw new BusinessException(severity, ex);
        }

        /// <summary>
        /// Log the exception
        /// </summary>
        /// <param name="ex">The exception to be logged</param>
        public static void LogMessage(Exception ex)
        {
            // log full exception
            new BusinessException(ex);
        }

        /// <summary>
        /// Log the exception message
        /// </summary>
        /// <param name="exceptionMessage">The exception message to be logged</param>
        public static void LogMessage(string exceptionMessage)
        {
            // log message
            new BusinessException(exceptionMessage);
        }

        #endregion
    }
}

