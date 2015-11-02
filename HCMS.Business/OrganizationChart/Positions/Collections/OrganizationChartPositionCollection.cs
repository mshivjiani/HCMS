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
    public sealed class OrganizationChartPositionCollection : ListCollectionBase<OrganizationChartPosition, OrganizationChartPositionDataAdapter>
    {
        #region Constructors

        public OrganizationChartPositionCollection()
        {
        }

        public OrganizationChartPositionCollection(List<OrganizationChartPosition> dataItems) : base(dataItems)
        {
        }

        public OrganizationChartPositionCollection(DataTable tableItems) : base(tableItems)
        {
        }

        #endregion
    }
}
