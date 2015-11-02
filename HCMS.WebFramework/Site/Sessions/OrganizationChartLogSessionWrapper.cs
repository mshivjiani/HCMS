using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Published;

namespace HCMS.WebFramework.Site.Sessions
{
    public static class OrganizationChartLogSessionWrapper
    {
        private const string _CurrentOrgChartLogIDKey = "CurrentOrgChartLogID";
        private const string _CurrentOrgChartLogKey = "CurrentOrgChartLog";

        public static OrganizationChartLog CurrentOrgChartLog
        {
            get
            {
                if (HttpContext.Current.Session[_CurrentOrgChartLogKey] == null)
                {
                    if (CurrentOrgChartLogID == -1)
                        HttpContext.Current.Session[_CurrentOrgChartLogKey] = new OrganizationChart();
                    else
                        HttpContext.Current.Session[_CurrentOrgChartLogKey] = OrganizationChartLogManager.Instance.GetByID(CurrentOrgChartLogID);
                }

                return (OrganizationChartLog) HttpContext.Current.Session[_CurrentOrgChartLogKey];
            }
        }

        public static int CurrentOrgChartLogID
        {
            get
            {
                if (HttpContext.Current.Session[_CurrentOrgChartLogIDKey] == null)
                    HttpContext.Current.Session[_CurrentOrgChartLogIDKey] = -1;

                return (int)HttpContext.Current.Session[_CurrentOrgChartLogIDKey];
            }
            set
            {
                HttpContext.Current.Session[_CurrentOrgChartLogIDKey] = value;
            }
        }

        public static void ClearCurrentOrgChartLog()
        {
            HttpContext.Current.Session[_CurrentOrgChartLogIDKey] = null;
            HttpContext.Current.Session[_CurrentOrgChartLogKey] = null;
        }

        public static void ResetCurrentOrgChartLog(int organizationChartLogID)
        {
            ClearCurrentOrgChartLog();
            CurrentOrgChartLogID = organizationChartLogID;
        }

        public static void RefreshOrgChartLogDataOnly()
        {
            int tempChartLogID = CurrentOrgChartLogID;
            HttpContext.Current.Session[_CurrentOrgChartLogKey] = OrganizationChartLogManager.Instance.GetByID(tempChartLogID);
        }
    }
}
