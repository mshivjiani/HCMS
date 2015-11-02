using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Exceptions
{
    public sealed class NullNewUserException : BusinessException
    {
         public NullNewUserException()
        {
        }

        public NullNewUserException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public NullNewUserException(string loadExceptionMessage, Exception innerEx)
            : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
