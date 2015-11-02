using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Exceptions
{
    public class InvalidRootNodePositionReplacementException : BusinessException
    {
        public InvalidRootNodePositionReplacementException()
        {
        }

        public InvalidRootNodePositionReplacementException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public InvalidRootNodePositionReplacementException(string loadExceptionMessage, Exception innerEx) : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
