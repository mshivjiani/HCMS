using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.PD.Collections
{
    [Serializable]
    public class PositionWorkflowStatusCollection : List<PositionWorkflowStatus>
    {

        public delegate bool IsMatch(PositionWorkflowStatus pws);

        public PositionWorkflowStatus Find(int workflowRecID)
        {
            return base.Find(delegate(PositionWorkflowStatus pws) { return pws.WorkflowRecID == workflowRecID; });
        }
        public List<PositionWorkflowStatus> FindFiltered(IsMatch match)
        {
            Predicate<PositionWorkflowStatus> predicate = new Predicate<PositionWorkflowStatus>(match);
            return base.FindAll(predicate);
            
        }

        public PositionWorkflowStatus FindCurrent()
        {
            return base.Find(delegate(PositionWorkflowStatus pws) { return pws.IsCurrent; });
        }

        public bool Contains(int workflowRecID)
        {
            PositionWorkflowStatus finder = this.Find(workflowRecID);
            return finder != null;
        }
        
    }
}
