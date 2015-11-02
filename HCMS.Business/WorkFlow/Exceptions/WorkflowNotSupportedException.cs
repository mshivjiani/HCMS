using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Common;

namespace HCMS.Business.WorkFlow.Exceptions
{
    public class WorkflowNotSupportedException : BusinessException
    {
        public WorkflowNotSupportedException()
        {
        }

        public WorkflowNotSupportedException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public WorkflowNotSupportedException(string loadExceptionMessage, Exception innerEx)
            : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
