using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.Security
{
    public interface IRole
    {
        int RoleID 
        { 
            get; 
            set; 
        }

        string RoleName 
        { 
            get; 
            set; 
        }
        
        string RoleDescription 
        { 
            get; 
            set; 
        }
    }
}
