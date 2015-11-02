using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Exceptions
{
    public sealed class NullOrganizationChartException : BusinessException
    {
        public NullOrganizationChartException()
        {
        }

        public NullOrganizationChartException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public NullOrganizationChartException(string loadExceptionMessage, Exception innerEx) : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
