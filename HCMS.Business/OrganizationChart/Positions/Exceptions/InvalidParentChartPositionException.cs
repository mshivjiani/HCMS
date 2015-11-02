using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Positions.Exceptions
{
    public class InvalidParentChartPositionException : BusinessException
    {
        public InvalidParentChartPositionException()
        {
        }

        public InvalidParentChartPositionException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public InvalidParentChartPositionException(string loadExceptionMessage, Exception innerEx) : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
