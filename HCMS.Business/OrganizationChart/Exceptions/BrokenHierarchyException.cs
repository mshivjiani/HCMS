using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Common;

namespace HCMS.Business.OrganizationChart.Exceptions
{
    public class BrokenHierarchyException : BusinessException
    {
        public BrokenHierarchyException()
        {
        }

        public BrokenHierarchyException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public BrokenHierarchyException(string loadExceptionMessage, Exception innerEx)
            : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
