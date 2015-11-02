using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.Lookups;

namespace HCMS.Business.Lookups.Collections
{
    public class DistinguishingValueScaleCollection : List<DistinguishingValueScale>
    {
        #region Constructors

        public DistinguishingValueScaleCollection()
        {
            // Empty Constructor
        }

        public DistinguishingValueScaleCollection(List<DistinguishingValueScale> dataItems)
            : base(dataItems)
        {
            // Fill by List<DistinguishingValueScale>
        }

        public DistinguishingValueScaleCollection(DataTable dataItems)
        {
            // Fill by DataTable
            if (dataItems != null)
            {
                foreach (DataRow dr in dataItems.Rows)
                    this.Add(new DistinguishingValueScale(dr));
            }
        }

        #endregion
    }
}
