using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

using HCMS.Business.Base;

namespace HCMS.Business.Admin.Workforce
{
    [System.ComponentModel.DataObject]
    public class OrgChartManager : BusinessBase
    {
        public DataTable GetOrgChartData(int RegionID, string OrgCode, int ServiceLevel, int RegionalLevel, int RD, int LevelID)
        {
            DataTable OrgChartData = new DataTable();


            OrgChartData = HCMS.Business.Base.BusinessBase.ExecuteDataTable("spr_GetAllOrgChartData");

            return OrgChartData;

        }
    }

     

    public enum ServiceLevel : int
    {
        Admin = 1,
        HCO = 2,
        HRO = 3
    }

    public enum RegionalLevel : int
    {
        HRO = 1,
        RegioalDir = 2
    }

    public enum RegionalDir : int
    {
        RD1 = 1,
        RD2 = 2,
        RD3 = 3,
        RD4 = 4,
        RD5 = 5,
        RD6 = 6,
        RD7 = 7,
        RD8 = 8,
        RD9 = 9
    }
    public enum Level : int
    {
        Level0 = 1,
        Level1 = 2,
        Level2 = 3,
        Level3 = 4,
        Level4 = 5,
        Level5 = 6

    }

}
