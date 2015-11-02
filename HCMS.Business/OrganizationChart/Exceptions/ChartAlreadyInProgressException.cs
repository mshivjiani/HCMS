using System;

using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Exceptions
{
    public sealed class ChartAlreadyInProgressException : BusinessException
    {
        public ChartAlreadyInProgressException()
        {
        }

        public ChartAlreadyInProgressException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public ChartAlreadyInProgressException(string loadExceptionMessage, Exception innerEx)
            : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
