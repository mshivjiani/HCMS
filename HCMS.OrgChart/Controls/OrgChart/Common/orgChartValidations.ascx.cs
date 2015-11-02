using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart;

namespace HCMS.OrgChart.Controls.OrgChart.Common
{
    public partial class orgChartValidations : UserControlBase
    {
        public void BindData(OrganizationChart chart)
        {
            try
            {
                if (chart == null)
                    this.Visible = false;
                else
                {
                    bool notAcknowledged = !chart.IsRootAcknowledged;
                    bool missingRootNode = (chart.StartPointWFPPositionID == -1);
                    bool hasAbolishedPositions = (chart.AbolishedPositionCount > 0);
                    bool hasBrokenHierarchy = (chart.BrokenHierarchyCount > 0);
                    bool hasNewFPPSPositions = (chart.NewFPPSPositionCount > 0);

                    bool toBeDisplayed = notAcknowledged || missingRootNode || hasAbolishedPositions || hasBrokenHierarchy || hasNewFPPSPositions;

                    // show custom validation notes
                    this.customNoteRootNotAcknowledged.Visible = notAcknowledged;
                    this.customNoteMissingRootNode.Visible = missingRootNode;
                    this.customNoteAbolishedPositions.Visible = hasAbolishedPositions;
                    this.customNoteBrokenHierarchy.Visible = hasBrokenHierarchy;
                    this.customNoteNewFPPSPositions.Visible = hasNewFPPSPositions;

                    this.Visible = toBeDisplayed;
                }
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }
    }
}