using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Positions.Exceptions
{
    public class InvalidChartPositionException : BusinessException
    {
        public InvalidChartPositionException()
        {
        }

        public InvalidChartPositionException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public InvalidChartPositionException(string loadExceptionMessage, Exception innerEx) : base(loadExceptionMessage, innerEx)
        {
        }
    }
}