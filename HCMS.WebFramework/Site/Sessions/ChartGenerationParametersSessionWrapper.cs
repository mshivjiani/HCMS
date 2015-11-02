using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.OrganizationChart.Processing;
using System.Web;

namespace HCMS.WebFramework.Site.Sessions
{
    public static class ChartGenerationParametersSessionWrapper
    {
        private static string SessionKey = "ChartGenerationParameters";

        public static ChartGenerationParameters Parameters
        {
            get
            {
                if (HttpContext.Current.Session[SessionKey] == null)
                    HttpContext.Current.Session[SessionKey] = new ChartGenerationParameters();

                return (ChartGenerationParameters)HttpContext.Current.Session[SessionKey];
            }
            set
            {
                HttpContext.Current.Session[SessionKey] = value;
            }
        }
    }
}
