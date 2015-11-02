using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Positions.Exceptions
{
    public class CircularPositionReferenceException : BusinessException
    {
        public CircularPositionReferenceException()
        {
        }

        public CircularPositionReferenceException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public CircularPositionReferenceException(string loadExceptionMessage, Exception innerEx)
            : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
