using System;
using System.DirectoryServices;

namespace HCMS.WebFramework.Security
{
    [Serializable]
    public class ActiveDirectoryUser:IComparable 
    {
        #region Private Members

        private string _SAMAccountName = string.Empty;
        private string _givenName = string.Empty;
        private string _SN = string.Empty;
        private string _mail = string.Empty;
        private string _userPrincipalName = string.Empty;

        #endregion

        #region Properties

        public string SAMAccountName
        {
            get
            {
                return this._SAMAccountName;
            }
            set
            {
                this._SAMAccountName = value;
            }
        }

        public string GivenName
        {
            get
            {
                return this._givenName;
            }
            set
            {
                this._givenName = value;
            }
        }

        public string SN
        {
            get
            {
                return this._SN;
            }
            set
            {
                this._SN = value;
            }
        }

        public string Mail
        {
            get
            {
                return this._mail;
            }
            set
            {
                this._mail = value;
            }
        }
        public string UserPrincipalName
        {
            get { return this._userPrincipalName; }
            set { this._userPrincipalName = value; }
        }
        public string DetailLine
        {
            get
            {
                return string.Format("{0} {1} ({2})", this._givenName, this._SN, this._SAMAccountName);
            }
        }

        #endregion

        #region Constructor

        public ActiveDirectoryUser()
        {
            // empty constructor
        }

        public ActiveDirectoryUser(SearchResult result)
        {
            if (result.Properties.Contains("samaccountname"))
                this._SAMAccountName = (string)result.Properties["samaccountname"][0];

            if (result.Properties.Contains("givenname"))
                this._givenName = (string)result.Properties["givenname"][0];

            if (result.Properties.Contains("sn"))
                this._SN = (string)result.Properties["sn"][0];

            if (result.Properties.Contains("mail"))
                this._mail = (string)result.Properties["mail"][0];
            if (result.Properties.Contains("userPrincipalName"))
                this._userPrincipalName = (string)result.Properties["userPrincipalName"][0];
        }
        
        public ActiveDirectoryUser(string userName, string firstName, string lastName, string emailAddress,string userPrincipalName)
        {
            this._SAMAccountName = userName;
            this._givenName = firstName;
            this._SN = lastName;
            this._mail = emailAddress;
            this._userPrincipalName = userPrincipalName;
        }
        
        #endregion

        #region IComparable Members

        int IComparable.CompareTo(object obj)
        {
            ActiveDirectoryUser newuser = obj as ActiveDirectoryUser;
            return string.Compare(this.SAMAccountName , newuser.SAMAccountName );
        }

        #endregion
    }
}
