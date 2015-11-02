using System;
using System.Collections.Generic;
using System.Text;

namespace HCMS.Business.Common.Exceptions
{
    public class DBPrimaryKeyNotSetException : BusinessException
    {
        public DBPrimaryKeyNotSetException()
        {
        }

        public DBPrimaryKeyNotSetException(string loadExceptionMessage) : base(loadExceptionMessage)
        {
        }

        public DBPrimaryKeyNotSetException(string loadExceptionMessage, Exception innerEx) : base(loadExceptionMessage, innerEx)
        {
        }
    }
}
