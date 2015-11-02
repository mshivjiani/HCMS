using System;
using System.Data;
using System.Collections.Generic;

using HCMS.Business.Base;
using HCMS.Business.Lookups.Adapters;

namespace HCMS.Business.Lookups.Collections
{
    [Serializable]
    public sealed class OrgChartTypeCollection : ListCollectionBase<OrgChartType, OrgChartTypeDataAdapter>
    {
        #region Constructors

        public OrgChartTypeCollection()
        {
        }

        public OrgChartTypeCollection(List<OrgChartType> dataItems) : base(dataItems)
        {
        }

        public OrgChartTypeCollection(DataTable tableItems) : base(tableItems)
        {
        }

        #endregion
    }
}
