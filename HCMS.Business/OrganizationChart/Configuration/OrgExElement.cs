using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;

namespace HCMS.Business.OrganizationChart.Configuration
{
    public class OrgExElement:ConfigurationElement 
    {

        public OrgExElement() { }
        [ConfigurationProperty("RegionID", DefaultValue = 9, IsRequired = true, IsKey = true)]
        [IntegerValidator(MinValue = 1, MaxValue = 9)]
        public int RegionID
        {
            get { return (int)this["RegionID"]; }
            set { this["RegionID"] = value; }
        }


        [TypeConverter(typeof(CommaDelimitedStringCollectionConverter))]
        [ConfigurationProperty("AllowedRoles", DefaultValue = "1", IsRequired = true, IsKey = false)]
        public CommaDelimitedStringCollection AllowedRoles
        {
            get { return (CommaDelimitedStringCollection)this["AllowedRoles"]; }
            set { this["AllowedRoles"] = value; }

        }
    }
}
