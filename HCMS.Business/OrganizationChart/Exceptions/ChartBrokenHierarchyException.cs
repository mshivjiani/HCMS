using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Exceptions
{
    public class ChartBrokenHierarchyException : BusinessException
    {
        public ChartBrokenHierarchyException()
        {
        }

        public ChartBrokenHierarchyException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public ChartBrokenHierarchyException(string loadExceptionMessage, Exception innerEx)
            : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
