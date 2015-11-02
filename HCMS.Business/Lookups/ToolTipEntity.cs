using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.Lookups
{
    [Serializable]
    public class ToolTipEntity
    {
        public long ID { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string ScreenName { get; set; }
    } 
}
