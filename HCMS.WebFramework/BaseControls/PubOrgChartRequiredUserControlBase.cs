using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.WebFramework.BaseControls
{
    public abstract class PubOrgChartRequiredUserControlBase : OrgChartUserControlBase
    {
        protected override void OnLoad(EventArgs e)
        {
            if (base.CurrentOrgChartLogID == -1 || base.CurrentOrgChartLog.OrganizationChartLogID == -1)
                base.GoToOrgChartTracker();
            else
                base.OnLoad(e);
        }

        protected void GoToPublishedOrganizationChartDetails()
        {
            base.SafeRedirect("~/PubOrgChart/OrgChartDetails.aspx");
        }

        protected void GoToPublishedOrganizationChartPositions()
        {
            base.SafeRedirect("~/PubOrgChart/OrgChartPositions.aspx");
        }
    }
}
