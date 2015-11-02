using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HCMS.Business.Base
{
    public interface IBusinessEntityCollection
    {
        void Fill(DataTable dataItems);
    }
}
