using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.WebFramework.Security;
using HCMS.WebFramework.Security.Collections;

namespace HCMS.WebFramework.Security.Collections
{
    [Serializable]
    public class ActiveDirectoryUserCollection : List<ActiveDirectoryUser>
    {
        public ActiveDirectoryUser Find(string samAccountName)
        {
            return base.Find(delegate(ActiveDirectoryUser adu) { return adu.SAMAccountName.Trim().ToLower() == samAccountName.Trim().ToLower(); });
        }

        public bool Contains(string samAccountName)
        {
            ActiveDirectoryUser finder = this.Find(samAccountName);
            return finder != null;
        }
    }
}
