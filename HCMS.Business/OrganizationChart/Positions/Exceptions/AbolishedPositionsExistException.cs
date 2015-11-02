using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Common;

namespace HCMS.Business.Positions.Exceptions
{
    public class AbolishedPositionsExistException : BusinessException
    {
        public AbolishedPositionsExistException()
        {
        }

        public AbolishedPositionsExistException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public AbolishedPositionsExistException(string loadExceptionMessage, Exception innerEx)
            : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
