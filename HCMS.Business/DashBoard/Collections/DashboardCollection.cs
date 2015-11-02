using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using HCMS.Business.Security;

namespace HCMS.Business.DashBoard.Collections
{
    [Serializable]
    public class DashboardCollection : List<DashBoard>
    {
        public DashBoard Find(long PDID)
        {
            return base.Find(delegate(DashBoard dsh) { return dsh.PositionDescriptionID == PDID; });
        }

        public DashboardCollection GetFilteredList()
        {
            List<DashBoard> dshList = new List<DashBoard>();
            dshList = base.FindAll(delegate(DashBoard dsh) { return dsh.PositionDescriptionTypeID == (int)PDChoiceType.StatementOfDifferencePD || dsh.AssociatedFullPD == -1 || dsh.AssociatedFullPD == 0; });
            return dshList.CreateFromEnumerable<DashboardCollection, DashBoard>();
        }

        public List<DashBoard> GetLadderPDs(long PDID)
        {
            List<DashBoard> dshList = new List<DashBoard>();
            dshList = base.FindAll(delegate(DashBoard dsh) { return dsh.AssociatedFullPD == PDID; });
            dshList.Sort(delegate(DashBoard dsh1, DashBoard dsh2) { return dsh1.ProposedGrade.CompareTo(dsh2.ProposedGrade); });
            dshList.Reverse();
            return dshList;
        }

        public DashboardCollection GetLadderPDs()
        {
            List<DashBoard> dshList = new List<DashBoard>();
            dshList = base.FindAll(delegate(DashBoard dsh) { return (dsh.PositionDescriptionTypeID == (int)PDChoiceType.CLStatementOfDifferencePD || dsh.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD) && (dsh.AssociatedFullPD > 0); });
            dshList.Sort(delegate(DashBoard dsh1, DashBoard dsh2) { return dsh1.ProposedGrade.CompareTo(dsh2.ProposedGrade); });
            dshList.Reverse();
            return dshList.CreateFromEnumerable<DashboardCollection, DashBoard>();
        }

        public bool Contains(long PDID)
        {
            DashBoard finder = this.Find(PDID);
            return finder != null;
        }
    }

    public static class ListToCollection
    {
        public static DashboardCollection CreateFromEnumerable<DashboardCollection, T>(this IEnumerable<T> seq) where DashboardCollection : List<T>, new()
        {
            DashboardCollection outList = new DashboardCollection();
            outList.AddRange(seq);
            return outList;
        }
    }
}
