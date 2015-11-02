using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.DirectoryServices;


namespace HCMS.WebFramework.Security
{
    public class LDAPAuthenticator : LDAPAccessBase
    {
        public bool IsAuthenticated(string username, string password)
        {
            bool returnVal = false;

            try
            {
                DirectoryEntry de = new DirectoryEntry(base.ActiveDirectoryPath, username, password);
                DirectorySearcher deSearch = new DirectorySearcher();

                deSearch.SearchRoot = de;
                deSearch.PropertiesToLoad.AddRange(new string[] { "cn", "givenName", "sn", "mail" });
                deSearch.Filter = "(&(objectClass=user)(mail=" + username + "))";

                SearchResult result = deSearch.FindOne();
                returnVal = (result != null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user." + ex.Message);
            }

            return returnVal;
        }
    }
}
