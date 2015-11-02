using System;
using System.Collections.Generic;

using HCMS.Business.Lookups;

namespace HCMS.Business.Lookups.Collections
{
    public class CareerLadderPDTypeCollection : List<CareerLadderPDType>
    {
        public CareerLadderPDType Find(int typeID)
        {
            return base.Find(delegate(CareerLadderPDType c) { return c.CareerLadderPDTypeID == typeID; });
        }

        public bool Contains(int typeID)
        {
            CareerLadderPDType finder = this.Find(typeID);
            return finder != null;
        }
    }
}
