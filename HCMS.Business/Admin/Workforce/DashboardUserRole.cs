using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;


namespace HCMS.Business.Admin.Workforce
{
    [Serializable]
    public class DashboardUserRole : BusinessBase
    {
        public int UserID{ get; set; }
        public int DashboardRoleID { get; set; }
        public string DashboardRoleLabel { get; set; }
    }
}
