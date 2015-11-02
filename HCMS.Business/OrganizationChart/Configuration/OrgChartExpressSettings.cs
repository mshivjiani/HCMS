using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace HCMS.Business.OrganizationChart.Configuration
{
    public class OrgChartExpressSettings: ConfigurationSection
    {
        
        private OrgExElement _element;      

        public OrgChartExpressSettings()
        {
            _element = new OrgExElement();

        }
        [ConfigurationProperty ("elements",IsDefaultCollection =false)]
        [ConfigurationCollection (typeof(OrgExElementCollection),AddItemName ="add",ClearItemsName ="clear",RemoveItemName="remove")]
        public OrgExElementCollection Elements
        {
            get { return (OrgExElementCollection)base["elements"]; }
        }

    }
    
}
