using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Series;

namespace HCMS.Business.Series.Collections
{
    [Serializable]
    public class SeriesOPMTitleCollection : List<SeriesOPMTitle>
    {
        public SeriesOPMTitle Find(int seriesID)
        {
            return base.Find(delegate(SeriesOPMTitle s) { return s.Series == seriesID; });
        }

        public SeriesOPMTitle Find(string seriesTitleName)
        {
            return base.Find(delegate(SeriesOPMTitle s) { return s.SeriesOPMTitleName.Trim().ToLower() == seriesTitleName.Trim().ToLower(); });
        }

        public bool Contains(int seriesID)
        {
            SeriesOPMTitle finder = this.Find(seriesID);
            return finder != null;
        }

        public bool Contains(string seriesTitleName)
        {
            SeriesOPMTitle finder = this.Find(seriesTitleName);
            return finder != null;
        }
    }
}
