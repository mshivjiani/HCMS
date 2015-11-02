using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using HCMS.WebFramework.Site.Utilities;

namespace HCMS.WebFramework.Site.Sessions
{
    public static class UserSessionWrapper
    {
        private const string CURRENTUSERID = "CurrentUserID";

        // Added this so that it can be used in more than just the UserControlBase
        // Loading is still handled in UserControlBase
        public static int CurrentUserID
        {
            get
            {
                if (HttpContext.Current.Session[CURRENTUSERID] == null)
                    HttpContext.Current.Session[CURRENTUSERID] = SiteUtility.CurrentIdentityUser().UserID;

                return (int)HttpContext.Current.Session[CURRENTUSERID];
            }
        }
    }
}
