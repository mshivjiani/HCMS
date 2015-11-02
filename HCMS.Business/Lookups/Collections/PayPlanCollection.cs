using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Lookups;

namespace HCMS.Business.Lookups.Collections
{
    [Serializable]
    public class PayPlanCollection : List<PayPlan>
    {
        public PayPlan Find(int payPlanID)
        {
            return base.Find(delegate(PayPlan p) { return p.PayPlanID == payPlanID; });
        }

        public bool Contains(int payPlanID)
        {
            PayPlan finder = this.Find(payPlanID);
            return finder != null;
        }
    }
}