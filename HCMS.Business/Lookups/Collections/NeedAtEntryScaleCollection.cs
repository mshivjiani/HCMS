using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.Lookups;

namespace HCMS.Business.Lookups.Collections
{
    public class NeedAtEntryCollection : List<NeedAtEntry>
    {
        #region Constructors

        public NeedAtEntryCollection()
        {
            // Empty Constructor
        }

        public NeedAtEntryCollection(List<NeedAtEntry> dataItems) : base(dataItems)
        {
            // Fill by List<NeedAtEntry>
        }

        public NeedAtEntryCollection(DataTable dataItems)
        {
            // Fill by DataTable
            if (dataItems != null)
            {
                foreach (DataRow dr in dataItems.Rows)
                    this.Add(new NeedAtEntry(dr));
            }
        }

        #endregion
    }
}
