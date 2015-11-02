using System;
using System.Collections.Generic;
using System.Configuration;

using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.WebFramework.Security
{
    public abstract class LDAPAccessBase
    {
        #region Private Members

        private string _activeDirectoryPath = string.Empty;

        #endregion

        #region Public Members

        protected string ActiveDirectoryPath
        {
            get 
            {
                return _activeDirectoryPath; 
            }
        }

        #endregion

        #region Constructors

        public LDAPAccessBase()
        {
            this._activeDirectoryPath = ConfigurationManager.ConnectionStrings[ConfigWrapper.CurrentADMembershipConnString].ConnectionString;
        }

        #endregion

        //private ArrayList GetADGroupUsers(string groupName)
        //{
        //    SearchResult result;
        //    DirectorySearcher search = new DirectorySearcher();
        //    search.Filter = String.Format("(cn={0})", groupName);
        //    search.PropertiesToLoad.Add("member");
        //    result = search.FindOne();

        //    ArrayList userNames = new ArrayList();
        //    if (result != null)
        //    {
        //        for (int counter = 0; counter <
        //                 result.Properties["member"].Count; counter++)
        //        {
        //            string user = (string)result.Properties["member"][counter];
        //            userNames.Add(user);
        //        }
        //    }
        //    return userNames;
        //}

        //private ArrayList GetAllADDomainUsers(string domainpath)
        //{
        //    ArrayList allUsers = new ArrayList();

        //    DirectoryEntry searchRoot = new DirectoryEntry(domainpath);
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);
        //    search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    search.PropertiesToLoad.Add("samaccountname");

        //    SearchResult result;
        //    SearchResultCollection resultCol = search.FindAll();
        //    if (resultCol != null)
        //    {
        //        for (int counter = 0; counter < resultCol.Count; counter++)
        //        {
        //            result = resultCol[counter];
        //            if (result.Properties.Contains("samaccountname"))
        //            {
        //                allUsers.Add((String)result.Properties["samaccountname"][0]);
        //            }
        //        }
        //    }
        //    return allUsers;
        //}

    }
}
