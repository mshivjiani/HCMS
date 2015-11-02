using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace HCMS.WebFramework.BasePages
{
    public interface IMasterPageBase
    {
        string PageTitle
        {
            get;
            set;
        }
    }
}
