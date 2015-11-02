using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Lookups;

namespace HCMS.Business.Lookups.Collections
{
    [Serializable]
    public class GradeCollection : List<Grade>
    {
        public Grade Find(int gradeID)
        {
            return base.Find(delegate(Grade g) { return g.GradeID == gradeID; });
        }

        public Grade Find(string gradeName)
        {
            return base.Find(G => string.Compare(G.GradeName, gradeName, true) == 0);
        }

        public bool Contains(int gradeID)
        {
            Grade finder = this.Find(gradeID);
            return finder != null;
        }

        public bool Contains(string gradeName)
        {
            return this.Find(gradeName) != null;
        }
    }
}
