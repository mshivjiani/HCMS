using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.Security
{
    public interface IPermission
    {
        int PermissionID 
        { 
            get; 
            set; 
        }

        string PermissionName
        { 
            get; 
            set; 
        }
    }
}
