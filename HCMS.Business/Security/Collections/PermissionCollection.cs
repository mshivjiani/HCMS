using System;
using System.Collections.Generic;

using HCMS.Business.Security;

namespace HCMS.Business.Security.Collections
{
    [Serializable]
    public class PermissionCollection : List<Permission>
    {
        public Permission Find(int permissionID)
        {
            return base.Find(delegate(Permission p) { return p.PermissionID == permissionID; });
        }

        public Permission Find(enumPermission permissionEnumID)
        {
            return base.Find(delegate(Permission p) { return p.PermissionID == (int)permissionEnumID; });
        }

        public bool Contains(int permissionID)
        {
            Permission finder = this.Find(permissionID);
            return finder != null;
        }

        public bool Contains(enumPermission permissionEnumID)
        {
            Permission finder = this.Find(permissionEnumID);
            return finder != null;
        }
    }
}
