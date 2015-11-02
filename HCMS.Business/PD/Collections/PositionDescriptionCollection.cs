using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.Security;

namespace HCMS.Business.PD.Collections
{
    [Serializable]
    public class PositionDescriptionCollection : List<PositionDescription>
    {
        #region Constructors

        public PositionDescriptionCollection()
        {
            // Empty Constructor
        }

        public PositionDescriptionCollection(List<PositionDescription> loadList) : base(loadList)
        {
            // Empty Constructor
        }

        public PositionDescriptionCollection(DataTable dataItems)
        {
            if (dataItems != null)
            {
                foreach (DataRow dr in dataItems.Rows)
                    this.Add(new PositionDescription(dr));
            }
        }

        #endregion

        public PositionDescription Find(long PDID)
        {
            return base.Find(delegate(PositionDescription pd) { return pd.PositionDescriptionID == PDID; });
        }

        public bool Contains(long PDID)
        {
            PositionDescription finder = this.Find(PDID);
            return finder != null;
        }

        public PositionDescriptionCollection GetOtherLadderPDs(long CurrentPDID)
        {
            List<PositionDescription> pdList = new List<PositionDescription>();
            pdList = base.FindAll(delegate(PositionDescription pd) { return pd.PositionDescriptionID != CurrentPDID; });
            return pdList.CreateFromEnumerable<PositionDescriptionCollection, PositionDescription>();
        }
        public PositionDescriptionCollection GetNonLadderPDs()
        {
            List<PositionDescription> pdList = new List<PositionDescription>();
            pdList = base.FindAll(
                delegate(PositionDescription pd)
                {
                    return (pd.IsNonLowerLadderPD);
                }
            );
            return pdList.CreateFromEnumerable<PositionDescriptionCollection, PositionDescription>();
        }
    }

    public static class ListToCollection
    {
        public static PositionDescriptionCollection CreateFromEnumerable<PositionDescriptionCollection, T>(this IEnumerable<T> seq) where PositionDescriptionCollection : List<T>, new()
        {
            PositionDescriptionCollection outList = new PositionDescriptionCollection();
            outList.AddRange(seq);
            return outList;
        }
    }
}
