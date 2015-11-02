using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.Common
{
   public class CMenu
    {
       public string Name { get; set; }
       public enumItemFlow Flow { get; set; }
       public enumMenuLevel Level { get; set; }
       public enumMenuType Type { get; set; }
       public enumMenuLayout Layout { get; set; }
       
    }
}
