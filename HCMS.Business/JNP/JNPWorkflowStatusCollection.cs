using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.JNP
{
    [Serializable]
    public class JNPWorkflowStatusCollection : List<JNPWorkflowStatus>
    {
        public delegate bool IsMatch(JNPWorkflowStatus jws);

        public JNPWorkflowStatus Find(int jnpWorkflowRecID)
        {
            return base.Find(delegate(JNPWorkflowStatus jws) { return jws.JNPWorkflowRecID == jnpWorkflowRecID; });
        }
        public List<JNPWorkflowStatus> FindFiltered(IsMatch match)
        {
            Predicate<JNPWorkflowStatus> predicate = new Predicate<JNPWorkflowStatus>(match);
            return base.FindAll(predicate);
        }
        public JNPWorkflowStatus FindCurrent()
        {
            return base.Find(delegate(JNPWorkflowStatus jws) { return jws.IsCurrent; });
        }
        public bool Contains(int jnpWorkflowRecID)
        {
            JNPWorkflowStatus item = this.Find(jnpWorkflowRecID);
            return item != null;
        }
    }
}
