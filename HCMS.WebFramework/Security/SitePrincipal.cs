using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

using HCMS.Business.Security;
using HCMS.Business.Security.Collections;

namespace HCMS.WebFramework.Security
{
    public class SitePrincipal : IPrincipal
    {
        #region Private Members

        private SiteIdentity _identity = null;

        #endregion

        #region Constructors

        public SitePrincipal(SiteIdentity identity)
        {
            _identity = identity;
        }

        #endregion

        #region IPrincipal Members

        public IIdentity Identity
        {
            get 
            { 
                return _identity; 
            }
        }

        public bool IsInRole(string roleName)
        {
            bool isInRole = false;

            if (this.Identity is SiteIdentity)
            {
                SiteIdentity currentidentity = (SiteIdentity)this.Identity;
                RoleCollection roles = currentidentity.Roles;

                isInRole = roles.Contains(roleName);
            }
            
            return isInRole;
        }

        public bool IsInRole(enumRole roleEnumID)
        {
            bool isInRole = false;

            if (this.Identity is SiteIdentity)
            {
                SiteIdentity currentIdentity = (SiteIdentity)this.Identity;
                RoleCollection roles = currentIdentity.Roles;

                isInRole = roles.Contains((int)roleEnumID);
            }

            return isInRole;
        }

        #endregion

        #region Permission Checking

        public bool HasPermission(enumPermission permissionEnumID)
        {
            bool permissionOK = false;

            if (this.Identity is SiteIdentity)
            {
                SiteIdentity currentIdentity = (SiteIdentity)this.Identity;
                PermissionCollection permissions = currentIdentity.Permissions;

                permissionOK = permissions.Contains((int)permissionEnumID);
            }

            return permissionOK;
        }

        #endregion
    }
}
