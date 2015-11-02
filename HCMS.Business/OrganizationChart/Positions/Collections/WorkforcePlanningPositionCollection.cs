using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;
using HCMS.Business.OrganizationChart.Positions.Adapters;

namespace HCMS.Business.OrganizationChart.Positions.Collections
{
    [Serializable]
    public sealed class WorkforcePlanningPositionCollection : ListCollectionBase<WorkforcePlanningPosition, WorkforcePlanningPositionDataAdapter>
    {
        #region Constructors

        public WorkforcePlanningPositionCollection()
        {
        }

        public WorkforcePlanningPositionCollection(List<WorkforcePlanningPosition> dataItems)
            : base(dataItems)
        {
        }

        public WorkforcePlanningPositionCollection(DataTable tableItems)
            : base(tableItems)
        {
        }

        #endregion
    }
}
