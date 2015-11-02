using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Exceptions
{
    public sealed class NullOrganizationCodeException : BusinessException
    {
        public NullOrganizationCodeException()
        {
        }

        public NullOrganizationCodeException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public NullOrganizationCodeException(string loadExceptionMessage, Exception innerEx) : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
