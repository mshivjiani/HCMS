using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Security;

namespace HCMS.Business.Security.Collections
{
    [Serializable]
    public class UserCollection : List<User>
    {
        public User Find(int userID)
        {
            return base.Find(delegate(User u) { return u.UserID == userID; });
        }

        public User Find(string emailAddress)
        {
            return base.Find(delegate(User u) { return u.EmailAddress.Trim().ToLower() == emailAddress.Trim().ToLower(); });
        }

        public bool Contains(int userID)
        {
            User finder = this.Find(userID);
            return finder != null;
        }

        public bool Contains(string emailAddress)
        {
            User finder = this.Find(emailAddress);
            return finder != null;
        }
    }
}
