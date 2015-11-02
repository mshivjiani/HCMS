using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HCMS.Business.Base
{
    public interface IBusinessEntity
    {
        void Fill(DataRow dataItem);
    }
}
