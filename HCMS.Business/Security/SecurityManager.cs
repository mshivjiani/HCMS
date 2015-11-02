using System;
using System.Data.Common;
using System.Data.SqlClient;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Security.Collections;
using HCMS.Business.OrganizationChart.Configuration;
using System.Configuration;

namespace HCMS.Business.Security
{
    [Serializable]
    public class SecurityManager : BusinessBase
    {       
        private UserCollection GetUsers(int regionID, bool? enabled)
        {
            DbCommand commandWrapper = GetDbCommand("spr_GetUsers");

            if (regionID == -1)
                commandWrapper.Parameters.Add(new SqlParameter("@regionID", DBNull.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@regionID", regionID));

            if (enabled == null)
                commandWrapper.Parameters.Add(new SqlParameter("@enabled", DBNull.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@enabled", enabled));


            return User.GetCollection(ExecuteDataTable(commandWrapper));
        }

        public UserCollection GetInactiveUsers(int regionID)
        {
            return this.GetUsers(regionID, false);
        }

        public UserCollection GetActiveUsers(int regionID)
        {
            return this.GetUsers(regionID, true);
        }

        public UserCollection GetAllUsers(int regionID)
        {
            return this.GetUsers(regionID, null);
        }
               
        public UserCollection GetAllUsersByOrganizationCodeSearch(int regionID, int organizationCodeID, string searchFirstName, string searchLastName)
        {
            DbCommand commandWrapper = GetDbCommand("spr_GetUsersByOrgCodeSearch");
            string firstName = searchFirstName.Trim();
            string lastName = searchLastName.Trim();

            if (regionID == -1)
                commandWrapper.Parameters.Add(new SqlParameter("@regionID", DBNull.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@regionID", regionID));

            if (organizationCodeID == -1)
                commandWrapper.Parameters.Add(new SqlParameter("@organizationCodeID", DBNull.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@organizationCodeID", organizationCodeID));

            if (firstName.Length == 0)
                commandWrapper.Parameters.Add(new SqlParameter("@firstName", DBNull.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@firstName", firstName));

            if (lastName.Length == 0)
                commandWrapper.Parameters.Add(new SqlParameter("@lastName", DBNull.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@lastName", lastName));

            return User.GetCollection(ExecuteDataTable(commandWrapper));
        }

        public UserCollection GetAllUsersSearch(string searchFirstName, string searchLastName)
        {
            DbCommand commandWrapper = GetDbCommand("spr_GetUsersSearch");
            string firstName = searchFirstName.Trim();
            string lastName = searchLastName.Trim();

            if (firstName.Length == 0)
                commandWrapper.Parameters.Add(new SqlParameter("@firstName", DBNull.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@firstName", firstName));

            if (lastName.Length == 0)
                commandWrapper.Parameters.Add(new SqlParameter("@lastName", DBNull.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@lastName", lastName));

            return User.GetCollection(ExecuteDataTable(commandWrapper));
        }

        public UserCollection GetUsersForRegionOrganization(int regionID, int organizationCodeID)
        {
            DbCommand commandWrapper = GetDbCommand("spr_GetUsersForRegionOrganization");

            //if (regionID == -1)
            //    commandWrapper.Parameters.Add(new SqlParameter("@regionID", DBNull.Value));
            //else
                commandWrapper.Parameters.Add(new SqlParameter("@regionID", regionID));

            //if (organizationCodeID == -1)
            //    commandWrapper.Parameters.Add(new SqlParameter("@organizationCodeID", DBNull.Value));
            //else
                commandWrapper.Parameters.Add(new SqlParameter("@OrgCodeID", organizationCodeID));

            return User.GetCollection(ExecuteDataTable(commandWrapper));
        }

        // Application UI rules and security
        // --------------------------------------------
        public class UIRules
        {
            public class PortalTabs
            {
                public bool IsJAnPEnabledForUser(User user)
                {
                    // Only show JAnP tab to users in specific orgs (in web.config/appSettings)
                    var jnpRegionsCSV = System.Configuration.ConfigurationManager.AppSettings["JAnPRegionalAccess"];
                    if (jnpRegionsCSV == null) throw new Exception("Portal web.config appSettings does not contain key 'JAnPRegionalAccess'. This key should be a comma separated list of Region Ids that need access to the JAnP tab.");

                    // Look in list of JAnP region Ids for this user's region Id
                    foreach (var jnpRegionId in jnpRegionsCSV.ToString().Trim().Split(new char[] { ',' }))
                    {
                        if (user.RegionID == Convert.ToInt32(jnpRegionId.Trim())) return true;
                    }
                    return false;
                }

                public bool IsOrgChartEnabledForUser(User user)
                {
                    bool isenabled = false;
                    //System administrator should have access to this tab regarless of the region

                    if (user.IsSystemAdministrator)
                    {
                        isenabled = true;
                    }
                    else
                    {
                        // Only show Org Chart tab to users in specific region with specific role (in web.config/appSettings)
                        OrgChartExpressSettings settings = (OrgChartExpressSettings)ConfigurationManager.GetSection("OrgChartExpressSettings");
                        if (settings != null)
                        {
                            OrgExElementCollection oelements = settings.Elements;
                            foreach (OrgExElement element in oelements)
                            {
                                if (user.RegionID == element.RegionID)
                                {
                                    CommaDelimitedStringCollection allowedroles = element.AllowedRoles;
                                    if (allowedroles.Contains("*") || allowedroles.Contains(user.RoleID.ToString()))
                                    {
                                        isenabled = true;
                                        break;
                                    }
                                }

                            }
                        }
                        else
                        {
                            throw new ApplicationException("Configuration section - OrgChartExpressSettings is missing from the Portal.Web.Config");
                        }
                    }
                   

                    return isenabled;
                    


                    //var orgChartRegionalAccess = ConfigurationManager.AppSettings["OrgChartRegionalAccess"];
                    //if (orgChartRegionalAccess == null) throw new Exception("Portal web.config appSettings does not contain key 'OrgChartRegionalAccess'. This key should be a comma separated list of Region Ids that need access to the Organization Chart tab.");

                    //// Look in list of Org Chart region Ids for this user's region Id
                    //foreach (var OrgChartRegionID in orgChartRegionalAccess.ToString().Trim().Split(new char[] { ',' }))
                    //{
                    //    if (user.RegionID == Convert.ToInt32(OrgChartRegionID.Trim())) return true;
                    //}
                    //return false;
                }
            }
        }


    }
}
