using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.Lookups;

namespace HCMS.Business.Lookups.Collections
{
    public class ImportanceScaleCollection : List<ImportanceScale>
    {
        #region Constructors

        public ImportanceScaleCollection()
        {
            // Empty Constructor
        }

        public ImportanceScaleCollection(List<ImportanceScale> dataItems) : base(dataItems)
        {
            // Fill by List<ImportanceScale>
        }

        public ImportanceScaleCollection(DataTable dataItems)
        {
            // Fill by DataTable
            if (dataItems != null)
            {
                foreach (DataRow dr in dataItems.Rows)
                    this.Add(new ImportanceScale(dr));
            }
        }

        #endregion
    }
}
