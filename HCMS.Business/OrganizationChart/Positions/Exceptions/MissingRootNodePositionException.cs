using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Common;

namespace HCMS.Business.Positions.Exceptions
{
    public class MissingRootNodePositionException : BusinessException
    {
        public MissingRootNodePositionException()
        {
        }

        public MissingRootNodePositionException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public MissingRootNodePositionException(string loadExceptionMessage, Exception innerEx)
            : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
