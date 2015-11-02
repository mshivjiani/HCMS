using System;
using System.Collections.Generic;

using HCMS.Business.Lookups;

namespace HCMS.Business.Lookups.Collections
{
    public class CareerLadderPDTypeGradeCollection : List<CareerLadderPDTypeGrade>
    {
        public CareerLadderPDTypeGrade Find(int typeID, int grade)
        {
            return base.Find(delegate(CareerLadderPDTypeGrade c) { return (c.CareerLadderPDTypeID == typeID) && (c.Grade == grade); });
        }

        public bool Contains(int typeID, int grade)
        {
            CareerLadderPDTypeGrade finder = this.Find(typeID, grade);
            return finder != null;
        }
    }
}
