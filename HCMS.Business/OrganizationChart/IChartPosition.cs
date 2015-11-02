using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.OrganizationChart.Positions;

namespace HCMS.Business.OrganizationChart
{
    public interface IChartPosition : IWorkforcePlanningPosition
    {
        enumOrgPositionGroupType PositionGroupType { get; set; }
        string PositionGroupTypeName { get; set; }
        
        enumOrgPositionPlacementType PositionPlacementType { get; set; }
        string PositionPlacementTypeName { get; set; }
        
        bool IsInChartHierarchy { get; set; }
        bool IsParentInChartHierarchy { get; set; }

        enumChartPositionType ChartPositionType { get; }
    }
}
