using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.Security
{
    public interface ISiteUser
    {
        int UserID
        { 
            get; 
            set; 
        }

        string FirstName
        { 
            get; 
            set; 
        }

        string LastName
        { 
            get; 
            set; 
        }

        string FullName
        {
            get;
        }

        string FullNameReverse
        {
            get;
        }

        string EmailAddress
        { 
            get; 
            set; 
        }

        int RegionID
        {
            get;
            set;
        }
    }
}
