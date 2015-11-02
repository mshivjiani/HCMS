using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.OrganizationChart;

namespace HCMS.WebFramework.BaseControls
{
    public abstract class OrgChartRequiredUserControlBase : OrgChartUserControlBase
    {
        protected override void OnLoad(EventArgs e)
        {
            if (base.CurrentOrgChartID == -1 || base.CurrentOrgChart == null || base.CurrentOrgChart.OrganizationChartID == -1)
                base.GoToOrgChartTracker();
            else
            {
                // No "Access Denied" View -- everyone has a minimum of View Mode
                this.ToggleReadOnlyView(base.CurrentOrgChartNavMode == enumNavigationMode.Edit ? enumNavigationMode.Edit : enumNavigationMode.View);
                base.OnLoad(e);
            }
        }

        protected void GoToOrgChartPositionManager()
        {
            base.SafeRedirect("~/OrgChart/OrgChartPositions.aspx");
        }

        protected void GoToOrgChartManagerDetails()
        {
            base.SafeRedirect("~/OrgChart/OrgChartDetails.aspx");
        }

        protected abstract void ToggleReadOnlyView(enumNavigationMode selectedMode);
    }
}
