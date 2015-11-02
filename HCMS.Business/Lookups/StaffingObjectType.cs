using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.Lookups
{
    public class StaffingObjectType
    {
        public int StaffingObjectTypeID { get; set; }
        public string StaffingObjectTypeName { get; set; }
        public bool IsStandaloneDocument { get; set; }
        public string StaffingObjectTypeDesc { get; set; }
        public int SortOrder { get; set; }                 // future use

        public StaffingObjectType()
        {
            // empty constructor
        }

        public StaffingObjectType(int id, string name, bool isStandalone, string desc)
        {
            this.StaffingObjectTypeID = id;
            this.StaffingObjectTypeName = name;
            this.IsStandaloneDocument = isStandalone;
            this.StaffingObjectTypeDesc = desc;
        }

    }
}
