using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Collections;

using HCMS.Business.Security;
using HCMS.Business.Security.Collections;

namespace HCMS.WebFramework.Security
{
    public class SiteIdentity : IIdentity
    {
        #region Private Members

        private int _userID = -1;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _emailAddress = string.Empty;
        private int _regionID = -1;
        private bool _authenticated = false;
        private RoleCollection _roles = new RoleCollection();
        private PermissionCollection _permissions = new PermissionCollection();

        #endregion

        #region Constructors

        private void loadUser(int loadUserID, string loadFirstName, string loadLastName, string loadEmail, int loadRegionID)
        {
            this._userID = loadUserID;
            this._firstName = loadFirstName;
            this._lastName = loadLastName;
            this._emailAddress = loadEmail;
            this._regionID = loadRegionID;
            this._authenticated = true;
        }

        public SiteIdentity(ISiteUser currentUser, RoleCollection loadRoles, PermissionCollection loadPermissions)
        {
            loadUser(currentUser.UserID, currentUser.FirstName, currentUser.LastName,
                currentUser.EmailAddress, currentUser.RegionID);

            this._roles = loadRoles;
            this._permissions = loadPermissions;
        }

        #endregion

        #region IIdentity Members

        public string AuthenticationType
        {
            get { return "Forms"; }
        }

        public bool IsAuthenticated
        {
            get { return this._authenticated; }
        }

        public string Name
        {
            get {
                return this._userID.ToString();
            }
        }

        #endregion

        #region ISiteUser Members

        public int UserID
        {
            get
            {
                return this._userID;
            }
        }

        public string FirstName
        {
            get
            {
                return this._firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this._lastName;
            }
        }

        public string EmailAddress
        {
            get
            {
                return this._emailAddress;
            }
        }

        public int RegionID
        {
            get
            {
                return this._regionID;
            }
        }

        public bool Authenticated
        {
            get
            {
                return this._authenticated;
            }
        }

        public string DisplayName
        {
            get
            {
                return string.Concat(this._firstName, " ", this._lastName).Trim();
            }
        }

        #endregion

        public RoleCollection Roles
        {
            get
            {
                return this._roles;
            }
        }

        public PermissionCollection Permissions
        {
            get
            {
                return this._permissions;
            }
        }
    }
}
