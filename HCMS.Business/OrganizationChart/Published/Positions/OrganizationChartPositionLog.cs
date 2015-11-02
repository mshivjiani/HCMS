using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.OrganizationChart.Positions;

namespace HCMS.Business.OrganizationChart.Published.Positions
{
    public class OrganizationChartPositionLog : WorkforcePlanningPosition, IChartPosition
    {
        #region Properties

        public int OrganizationChartLogID { get; set; }
        
        public enumOrgPositionGroupType PositionGroupType { get; set; }
        public string PositionGroupTypeName { get; set; }
        
        public enumOrgPositionPlacementType PositionPlacementType { get; set; }
        public string PositionPlacementTypeName { get; set;  }
        
        public bool IsIncluded { get; set; }
        public bool IsInChartHierarchy { get; set; }
        public bool IsParentInChartHierarchy { get; set; }

        public enumChartPositionType ChartPositionType
        {
            get
            {
                return (string.IsNullOrWhiteSpace(base.PositionNumberBase) &&
                    string.IsNullOrWhiteSpace(base.PositionNumberSuffix)) ? enumChartPositionType.WFP : enumChartPositionType.FPPS;
            }
        }
        
       #endregion

        #region Constructor

        public OrganizationChartPositionLog() : base()
        {
            this.OrganizationChartLogID = -1;
            
            this.PositionGroupType = enumOrgPositionGroupType.Undefined;
            this.PositionGroupTypeName = string.Empty;

            this.PositionPlacementType = enumOrgPositionPlacementType.Undefined;
            this.PositionPlacementTypeName = string.Empty;

            this.IsIncluded = false;
            this.IsInChartHierarchy = false;
            this.IsParentInChartHierarchy = false;
        }

        #endregion
    }
}
