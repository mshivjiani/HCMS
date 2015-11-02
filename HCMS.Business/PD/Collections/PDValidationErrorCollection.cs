using System;
using System.Collections.Generic;

using HCMS.Business.PD;

namespace HCMS.Business.PD.Collections
{
    public class PDValidationErrorCollection : List<PDValidationError>
    {
        public PDValidationError Find(int errorID)
        {
            return base.Find(delegate(PDValidationError p) { return p.ErrorID == errorID; });
        }

        public bool Contains(int errorID)
        {
            PDValidationError finder = this.Find(errorID);
            return finder != null;
        }
    }
}
