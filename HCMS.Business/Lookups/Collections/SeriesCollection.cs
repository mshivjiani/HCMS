using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Lookups;

namespace HCMS.Business.Lookups.Collections
{
    [Serializable]
    public class SeriesCollection : List<Series>
    {
        public Series Find(int seriesID)
        {
            return base.Find(delegate(Series s) { return s.SeriesID == seriesID; });
        }

        public bool Contains(int seriesID)
        {
            Series finder = this.Find(seriesID);
            return finder != null;
        }
    }
}
