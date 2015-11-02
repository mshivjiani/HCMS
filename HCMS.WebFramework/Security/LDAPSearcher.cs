using System;
using System.Text;
using System.DirectoryServices;

using HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.WebFramework.Security;
using HCMS.WebFramework.Security.Collections;

namespace HCMS.WebFramework.Security
{
    public class LDAPSearcher : LDAPAccessBase
    {
        public LDAPSearcher()
        {
        }

        public ActiveDirectoryUserCollection Search(string searchLastName, string searchFirstName, string searchEmailAddress)
        {
            return this.Search(searchLastName, searchFirstName, searchEmailAddress, null);
        }

        public ActiveDirectoryUserCollection Search(string searchLastName, string searchFirstName, string searchEmailAddress, UserCollection excludeUsers)
        {
            ActiveDirectoryUserCollection matchedAccounts = null;
            string firstName = searchFirstName.Trim();
            string lastName = searchLastName.Trim();
            string emailAddress = searchEmailAddress.Trim();

            try
            {
                DirectoryEntry de = new DirectoryEntry(base.ActiveDirectoryPath);
                DirectorySearcher search = new DirectorySearcher();

                search.SearchRoot = de;
                search.SearchScope = SearchScope.Subtree;

                // SELECT CLAUSE
                // return the following fields
                search.PropertiesToLoad.AddRange(new string[] { "samaccountname", "givenName", "sn", "mail","userPrincipalName" });

                // WHERE CLAUSE
                // filter by -- in the following 3 filters we automatically assume wildcard searching
                string searchFilter = string.Empty;

                if (firstName.Length > 0)
                    searchFilter = string.Format("(givenname={0}*)", firstName);

                if (lastName.Length > 0)
                    searchFilter += string.Format("(sn={0}*)", lastName);

                if (emailAddress.Length > 0)
                    searchFilter += string.Format("(userPrincipalName={0}*)", emailAddress);

                // now that we have the filter -- let's add into the filter the accounts to be removed
                string excludeUserFilter = string.Empty;
                if (excludeUsers != null && excludeUsers.Count > 0)
                {
                    // in this search -- we must have the exact account name
                    string tempUserFilter = string.Empty;

                    foreach (User current in excludeUsers)
                        tempUserFilter += string.Format("(!userPrincipalName={0})", current.EmailAddress);

                    excludeUserFilter = string.Format("((|{0}))", tempUserFilter);
                }

                // set filter
                search.Filter = string.Format("(&(objectCategory=user)(userPrincipalName=*)(&{0}){1})", searchFilter, excludeUserFilter);

                // search based on filter                
                SearchResultCollection resultList = search.FindAll();
                SearchResult result = null;

                if (resultList != null)
                {
                    matchedAccounts = new ActiveDirectoryUserCollection();
                    for (int counter = 0; counter < resultList.Count; counter++)
                    {
                        result = resultList[counter];
                        if (result.Properties.Contains("userPrincipalName"))
                        {
                            ActiveDirectoryUser user = new ActiveDirectoryUser(result);
                            matchedAccounts.Add(user);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error encountered while searching Active Directory: " + ex.Message);
            }

            return matchedAccounts;
        }
    }
}
