using System;

using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Exceptions
{
    public sealed class NoPublishedChartAvailableException : BusinessException
    {
        public NoPublishedChartAvailableException()
        {
        }

        public NoPublishedChartAvailableException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public NoPublishedChartAvailableException(string loadExceptionMessage, Exception innerEx)
            : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
