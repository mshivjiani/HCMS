using System;
using System.Collections.Generic;

using HCMS.Business.Security;

namespace HCMS.Business.Security.Collections
{
    [Serializable]
    public class RoleCollection : List<Role>
    {
        public Role Find(int roleID)
        {
            return base.Find(delegate(Role r) { return r.RoleID == roleID; });
        }

        public Role Find(string roleName)
        {
            return base.Find(delegate(Role r) { return r.RoleName.Trim().ToLower() == roleName.Trim().ToLower(); });
        }

        public bool Contains(int roleID)
        {
            Role finder = this.Find(roleID);
            return finder != null;
        }

        public bool Contains(string roleName)
        {
            Role finder = this.Find(roleName);
            return finder != null;
        }
    }
}
