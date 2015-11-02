using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Positions.Exceptions
{
    public class PositionContainsSubordinatesException : BusinessException
    {
        public PositionContainsSubordinatesException()
        {
        }

        public PositionContainsSubordinatesException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public PositionContainsSubordinatesException(string loadExceptionMessage, Exception innerEx) : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
