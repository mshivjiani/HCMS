using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Admin.Workforce;
using System.Configuration;
using HCMS.Business.SSAS;
using HCMS.Business.Security;

namespace HCMS.WebFramework.BaseControls
{
    public abstract class DashboardRoleUserControlBase : UserControlBase
    {
        protected AnalyisServicesRoleManager GetSSASRoleManager()
        {

            AnalyisServicesRoleManager _ssasmgr = null;


            string ssasInstance = string.Empty;
            string ssasDB = string.Empty;
            string DashboardConnString = string.Empty;
            if (ConfigurationManager.AppSettings["SSASInstanceName"] != null)
            {


                ssasInstance = string.Format("{0}", ConfigurationManager.AppSettings["SSASInstanceName"].ToString());
            }

            if (ConfigurationManager.AppSettings["SSASDB"] != null)
            {
                ssasDB = ConfigurationManager.AppSettings["SSASDB"].ToString();
            }


            if (ConfigurationManager.AppSettings["WFPDashboardConnString"] != null)
            {
                DashboardConnString = ConfigurationManager.AppSettings["WFPDashboardConnString"].ToString();
            }

            if (!string.IsNullOrEmpty(ssasInstance) && !string.IsNullOrEmpty(ssasDB) && !string.IsNullOrEmpty(DashboardConnString))
            {
                _ssasmgr = new AnalyisServicesRoleManager(ssasInstance, ssasDB, DashboardConnString);

            }
            else
            {
                throw new ApplicationException("SSAS Role Manager could not be created.");
            }


            return _ssasmgr;


        }

        protected bool HasServiceWideRole(int iUserID)
        {
            bool hasServicewideRole = false;
            DashboardRoleManager dm = new DashboardRoleManager();
            List<Business.Admin.Workforce.DashboardRole> droles = dm.GetRolesForUser(iUserID);
            if (droles.Count > 0)
            {
                foreach (Business.Admin.Workforce.DashboardRole role in droles)
                {
                    enumDashboardRoleType currentroletype = role.eDashboardRoleType;
                    if (dm.IsServiceWideRole(currentroletype))
                    {
                        hasServicewideRole = true;
                        break;
                    }
                }
            }
            return hasServicewideRole;
        }

        protected bool HasRegionWideRole(int iUserID)
        {
            bool hasRegionwideRole = false;
            DashboardRoleManager dm = new DashboardRoleManager();
            List<Business.Admin.Workforce.DashboardRole> droles = dm.GetRolesForUser(iUserID);
            if (droles.Count > 0)
            {
                foreach (Business.Admin.Workforce.DashboardRole role in droles)
                {
                    enumDashboardRoleType currentroletype = role.eDashboardRoleType;

                    if (dm.IsRegionWideRole(currentroletype))
                    {
                        hasRegionwideRole = true;
                        break;
                    }
                }
            }

            return hasRegionwideRole;
        }

        protected string GetSSASRoleNameForUser(HCMS.Business.Security.User user, enumDashboardRoleType eroletype, int regionID, string OrganizationCode)
        {
            // Check # of roles, > 1 then user name
            DashboardRoleManager dm = new DashboardRoleManager();
            List<Business.Admin.Workforce.DashboardRole> droles = dm.GetRolesForUser(user.UserID);
            string rolename = string.Empty;
            if (eroletype == enumDashboardRoleType.SystemAdministrator)
            {
                rolename = ConfigurationManager.AppSettings["SYSTEMADMINROLENAME"];
            }
            else if (dm.IsServiceWideRole (eroletype))
            {
                rolename ="Service Wide";
            }
           
            else
            {
                if(droles.Count <=1)
                {
                    if (dm.IsRegionWideRole(eroletype))
                    {
                        rolename = string.Format("FF0{0}G00000", OrganizationCode.Substring(3, 1));
                    }
                    else
                    {
                        rolename = OrganizationCode;
                    }
                }
                else
                {
                    rolename = "User_" + user.EmailAddress.Substring(0, user.EmailAddress.IndexOf('@'));
                }
            }
               
            return rolename;
        }        

        protected void DeleteDashboardRole(int iUserID, enumDashboardRoleType eroletype, int regionID, int DashboardRoleID, string orgcode)
        {


            User user = new User(iUserID);
            string rolename = string.Empty;

            DashboardRoleManager dm = new DashboardRoleManager();
            List<Business.Admin.Workforce.DashboardRole> roles = dm.GetRolesForUser(iUserID);
            AnalyisServicesRoleManager ssasrolemgr = GetSSASRoleManager();

            if (ssasrolemgr != null)
            {
                try
                {
                    switch (roles.Count)
                    {
                        case 0:
                            break;
                        case 1:
                            foreach (Business.Admin.Workforce.DashboardRole role in roles)
                            {
                                dm.Delete(role.DashboardRoleID);
                                rolename = GetSSASRoleNameForUser(user, eroletype, regionID, role.OrganizationCode);
                                ssasrolemgr.RemoveUserRoleOrgCodeAccess(rolename, user.EmailAddress, orgcode);
                            }
                            break;
                        case 2:
                            // delete user_ role
                            dm.Delete(DashboardRoleID);
                            ssasrolemgr.DeleteUserSpecificRole(user.EmailAddress);
                            roles = dm.GetRolesForUser(iUserID);
                            foreach (Business.Admin.Workforce.DashboardRole role in roles)
                            {
                                if (role.DashboardRoleID != DashboardRoleID)
                                {
                                    enumDashboardRoleType currentroletype = role.eDashboardRoleType;
                                    rolename = GetSSASRoleNameForUser(user, eroletype, role.RegionID, role.OrganizationCode);
                                    ssasrolemgr.CreateUserRole(rolename, user.EmailAddress, role.OrganizationCode, currentroletype);
                                }
                            }

                            break;
                        default:
                            //Update multiple roles
                            dm.Delete(DashboardRoleID);
                            roles = dm.GetRolesForUser(iUserID);
                            List<string> orgs = new List<string>();
                            foreach (Business.Admin.Workforce.DashboardRole role in roles)
                            {
                                if (role.DashboardRoleID != DashboardRoleID)
                                {
                                    orgs.Add(role.OrganizationCode);
                                }
                            }

                            // User with exisiting role
                            rolename = "User_" + user.EmailAddress.Substring(0, user.EmailAddress.IndexOf('@'));
                            ssasrolemgr.AddUpdateMultipleRole(rolename, user.EmailAddress, orgs);
                            dm.Delete(DashboardRoleID);
                            break;

                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

        }


    }
}





