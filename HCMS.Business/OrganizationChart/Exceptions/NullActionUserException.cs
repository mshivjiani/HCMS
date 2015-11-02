using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Exceptions
{
    public sealed class NullActionUserException : BusinessException
    {
        public NullActionUserException()
        {
        }

        public NullActionUserException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public NullActionUserException(string loadExceptionMessage, Exception innerEx) : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
