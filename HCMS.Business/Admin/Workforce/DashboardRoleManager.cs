using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Security;

namespace HCMS.Business.Admin.Workforce
{
     [System.ComponentModel.DataObject]
     public class DashboardRoleManager : BusinessBase
     {
         #region General CRUD Methods

         //default constructor
         public DashboardRoleManager()
         {

         }

         public int AddDashboardRole(DashboardRole DboardRole)
         {
             int DashboardID = -1;

             DbCommand commandWrapper = GetDbCommand("spr_AddDashboardUserRole");
             try
             {
                 commandWrapper.Parameters.Add(new SqlParameter("@UserID", DboardRole.UserID));
                 commandWrapper.Parameters.Add(new SqlParameter("@DashboardRoleTypeID", DboardRole.DashboardRoleTypeID));
                 commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCodeID", DboardRole.OrganizationCodeID));
                 commandWrapper.Parameters.Add(new SqlParameter("@DashboardRoleLabel", DboardRole.DashboardRoleLabel));            

                 SqlParameter returnParam = new SqlParameter("@DashboardRoleID", SqlDbType.Int);
                 returnParam.Direction = ParameterDirection.Output;
                 commandWrapper.Parameters.Add(returnParam);

                 ExecuteNonQuery(commandWrapper);
                                 
                 DashboardID = Convert.ToInt32(returnParam.Value);
             }
             catch (Exception ex)
             {
                 DashboardID = -1;
                 HandleException(ex);
             }

             return DashboardID;
         }

         public bool Delete(int DashboardRoleID)
         {
             bool Success = false;
             if (base.ValidateKeyField(DashboardRoleID))
             {
                 try
                 {
                     ExecuteNonQuery("spr_DeleteDashboardRole", DashboardRoleID);
                     Success = true;
                 }
                 catch (Exception ex)
                 {
                     Success = false;
                     HandleException(ex);
                 }
             }

             return Success;
         }

         #endregion

         #region Collection Methods

         public List<DashboardRole> GetAllDashboardRole()
         {
             List<DashboardRole> listCollection = new List<DashboardRole>();

             DataTable dataItems = ExecuteDataTable("spr_GetAllDashboardRole");

             if (dataItems != null)
             {
                 for (int i = 0; i < dataItems.Rows.Count; i++)
                 {
                     DashboardRole item = new DashboardRole(dataItems.Rows[i]);
                     listCollection.Add(item);
                 }
             }
             else
             {
                 throw new Exception("Failed to get roles");
             }

             return listCollection;
         }

         /* Added by SK on 6/17/2015 */
         public List<User> GetAllDashboardUsers()
         {
             List<User> listCollection = new List<User>();

             DataTable dataItems = ExecuteDataTable("spr_GetAllDashboardUsers");

             if (dataItems != null)
             {
                 for (int i = 0; i < dataItems.Rows.Count; i++)
                 {
                     User item = new User((int)dataItems.Rows[i]["UserId"]);
                     listCollection.Add(item);
                 }
             }
             else
             {
                 throw new Exception("Failed to get roles");
             }

             return listCollection;
         }

         public List<DashboardRole> GetRolesForUser(int UserID)
         {
             return GetRoleForUser(-1, -1, -1, UserID);
         }
         public List<DashboardRole> GetRoleForUser(int RegionID, int OrgCodeID, int RoleTypeID, int UserID)
         {

             DbCommand commandWrapper = GetDbCommand("spr_GetRolesForUser");

             commandWrapper.Parameters.Add(new SqlParameter("@UserID", UserID));
             commandWrapper.Parameters.Add(new SqlParameter("@RegionID", RegionID));
             commandWrapper.Parameters.Add(new SqlParameter("@OrgCodeID", OrgCodeID));
             commandWrapper.Parameters.Add(new SqlParameter("@RoleTypeID", RoleTypeID));
            

             DataTable dataItems = ExecuteDataTable(commandWrapper);
             List<DashboardRole> listCollection = new List<DashboardRole>();

             if (dataItems != null)
             {
                 for (int i = 0; i < dataItems.Rows.Count; i++)
                 {
                     DashboardRole item = new DashboardRole(dataItems.Rows[i]);
                     listCollection.Add(item);
                 }
             }
             else
             {
                 throw new Exception("Failed to get roles");
             }

             return listCollection;
         }


         
         public List<DashboardRole> GetRoleSearchResult(int RegionID, int OrgCodeID, int RoleTypeID,int UserID)
         {

             DbCommand commandWrapper = GetDbCommand("spr_GetRoleSearchResult");


             commandWrapper.Parameters.Add(new SqlParameter("@RegionID", RegionID));
             commandWrapper.Parameters.Add(new SqlParameter("@OrgCodeID", OrgCodeID));
             commandWrapper.Parameters.Add(new SqlParameter("@RoleTypeID", RoleTypeID));
             commandWrapper.Parameters.Add(new SqlParameter("@UserID", UserID));

             DataTable dataItems = ExecuteDataTable(commandWrapper);
             List<DashboardRole> listCollection = new List<DashboardRole>();

             if (dataItems != null)
             {
                 for (int i = 0; i < dataItems.Rows.Count; i++)
                 {
                        DashboardRole item = new DashboardRole(dataItems.Rows[i]);
                        listCollection.Add(item);
                 }
             }
             else
             {
                 throw new Exception("Failed to get roles");
             }

             return listCollection;
         }


         public DataTable GetRegionForUser(int iUserID)
         {
             return ExecuteDataTable("spr_GetUserRegions", iUserID);
              
         }

        
         public bool IsServiceWideRole(enumDashboardRoleType eRoleType)
         {
             bool isServicewide=false;
             if (eRoleType == enumDashboardRoleType.Director || eRoleType == enumDashboardRoleType.SystemAdministrator || eRoleType == enumDashboardRoleType.HumanCapitalOfficer || eRoleType ==enumDashboardRoleType.DeputyDirector ||eRoleType==enumDashboardRoleType.SpecialAssistantToDirector)
             {
                 isServicewide = true;
             }
             return isServicewide;
         }

         public bool IsRegionWideRole(enumDashboardRoleType eRoleType)
         {
             bool isRegionwide = false;
             if (eRoleType == enumDashboardRoleType.RegionalDirector || eRoleType == enumDashboardRoleType.DeputyRegionalDirector || eRoleType == enumDashboardRoleType.RegionalHumanResourcesOfficer)
             {
                 isRegionwide = true;
             }
             return isRegionwide;
         }

         public bool IsProgramWideRole(enumDashboardRoleType eRoleType)
         {
             bool isProgramwide = false;
             if (eRoleType == enumDashboardRoleType.AssistantDirector  || eRoleType == enumDashboardRoleType.DeputyAssistantDirector||eRoleType==enumDashboardRoleType.AssistantRegionalDirector )
             {
                 isProgramwide = true;
             }
             return isProgramwide;
         }

         #endregion

     }
}
