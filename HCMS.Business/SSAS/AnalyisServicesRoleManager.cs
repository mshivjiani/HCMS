using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using Microsoft.AnalysisServices;

using HCMS.Business.Base;
using System.Data.Common;
namespace HCMS.Business.SSAS
{
    [Serializable]
    public class AnalyisServicesRoleManager : BusinessBase
    {
        #region Private Properties

        private string _AnalysisServicesInstance;
        private string _AnalysisServicesDatabaseName;
        private string _HCMSDbConnectionString;
        private string _DashboardDbConnectionString;
        private enum enumMDXAction : int
        {
            Add = 1,
            Delete = 2

        }
        #endregion

        #region Public Properties

        public string AnalysisServicesInstance { get { return this._AnalysisServicesInstance; } set { this._AnalysisServicesInstance = value; } }
        public string AnalysisServicesDatabaseName { get { return this._AnalysisServicesDatabaseName; } set { this._AnalysisServicesDatabaseName = value; } }
        public string HCMSDbConnectionString { get { return base.CurrentDatabase.ConnectionString; } }
        public string DashboardDbConnectionString { get { return this._DashboardDbConnectionString; } set { this._DashboardDbConnectionString = value; } }

        #endregion

        #region AMO Properties

        private Server _SSAS;
        private Database _DB;
        private Cube _Cube;

        #endregion

        #region Class Constructors

        public AnalyisServicesRoleManager(string ssasInstance, string ssasDB, string DashboardConnectionString)
        {
            this._AnalysisServicesInstance = ssasInstance;
            this._AnalysisServicesDatabaseName = ssasDB;
            this._DashboardDbConnectionString = DashboardConnectionString;

            _SSAS = new Server();
            try
            {
                _SSAS.Connect(this._AnalysisServicesInstance);
                _DB = _SSAS.Databases.FindByName(this._AnalysisServicesDatabaseName);
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Public Methods

        public void DeleteAllRoles()
        {
            this.DropAllRoles();
        }

        public RoleCollection GetAllRoles()
        {
            return this._DB.Roles;
        }

        public DataTable  GetRoleMembers()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RoleID", typeof(String));
            dt.Columns.Add("RoleName", typeof(String));
            dt.Columns.Add("MemberID", typeof(String));
            dt.Columns.Add("MemberName", typeof(String));
            if (_DB != null)
            {
                RoleCollection rolecollection = this._DB.Roles;
             
                foreach (Role role in rolecollection)
                {

                    if (role.Name != "Admin" && role.Name != "Cognos")
                    {
                        RoleMemberCollection rolemembers = role.Members;
                        foreach (RoleMember member in rolemembers)
                        {
                            DataRow dr = dt.NewRow();
                            dr["RoleID"] = role.ID;
                            dr["RoleName"] = role.Name;
                            dr["MemberID"] = member.Sid;
                            dr["MemberName"] = member.Name;
                            dt.Rows.Add(dr);

                        }
                    }
                }
            }
            return dt;
        }

        public void UpdateHCMSRoles()
        {
            this.DropAllRoles();

            this.GrantUsersWithSingleRole();

            this.GrantUsersWithMultipleRoles();
        }


        public void CreateRoleWithServicewideAccess(string RoleName, string UserEmailAddress)
        {

            // Add Role to SSAS Database if it does not exist
            if (this._DB.Roles.FindByName(RoleName) == null)
            {
                AddRole(RoleName);
                // Add Member to Role
                AddRoleMember(RoleName, UserEmailAddress);
                // Grant Database Read Access
                this.GrantDatabaseRead(RoleName);

                // Grant Read Access To Cubes
                this.GrantCubeRights(RoleName);
            }

            else
            {
                // Add Member to Role
                AddRoleMember(RoleName, UserEmailAddress);

            }
        }

        public void AddUpdateMultipleRole(string RoleName, string UserEmailAddress, List<string> orgs)
        {
            if (this._DB.Roles.FindByName(RoleName) == null)
            {
                AddRole(RoleName);

                // Add Member to Role
                AddRoleMember(RoleName, UserEmailAddress);
                // Grant Database Read Access
                this.GrantDatabaseRead(RoleName);

                // Grant Read Access To Cubes
                this.GrantCubeRights(RoleName);
            }
            
            // Use orgs to create dimension data restrictions
            // if all roles same depth
            string strOrgs = string.Join(",", orgs);

            DataTable dtDimensionData = this.ExecuteStoredProcedure(this._DashboardDbConnectionString
                                                                        , "proc_GetSSASDimensionAllowedMembers"
                                                                        , new string[] { "DimensionName", "OrgList" }
                                                                        , new object[] { "Employee Cost Center", strOrgs }
                                                                        );
            for (int i=0; i<dtDimensionData.Columns.Count; i++)
            {
                if (dtDimensionData.Rows[0][i].ToString() != string.Empty)
                {
                    GrantDimensionDataRead("Employee Cost Center"
                                            , RoleName
                                            , string.Format("Level{0} Code",i.ToString())
                                            , "{" + dtDimensionData.Rows[0][i].ToString() + "}"
                                            , string.Empty
                                            );
                }
            }

            dtDimensionData = this.ExecuteStoredProcedure(this._DashboardDbConnectionString
                                                                                    , "proc_GetSSASDimensionAllowedMembers"
                                                                                    , new string[] { "DimensionName", "OrgList" }
                                                                                    , new object[] { "Cost Center", strOrgs }
                                                                                    );
            for (int i = 0; i < dtDimensionData.Columns.Count; i++)
            {
                if (dtDimensionData.Rows[0][i].ToString() != string.Empty)
                {
                    GrantDimensionDataRead("Cost Center"
                                            , RoleName
                                            , string.Format("Level{0} Code", i.ToString())
                                            , "{" + dtDimensionData.Rows[0][i].ToString() + "}"
                                            , string.Empty
                                            );
                }
            }

        }

        public void CreateUserRole(string RoleName, string UserEmailAddress, string OrganizationCode, enumDashboardRoleType eDashboardRoleType)
        {
            // Add Role to SSAS Database if it does not exist

            /*
             * If role exists, just add member to role
             */


            if (this._DB.Roles.FindByName(RoleName) == null)
            {
                AddRole(RoleName);

                // Add Member to Role
                AddRoleMember(RoleName, UserEmailAddress);
                // Grant Database Read Access
                this.GrantDatabaseRead(RoleName);

                // Grant Read Access To Cubes
                this.GrantCubeRights(RoleName);

                // if not admin / fws service role then we need to restrict access
                if (!RoleName.Equals("HCMS Support Admin") && !RoleName.Equals("Service Wide"))
                {
                    DataTable dtDimensionData = this.ExecuteStoredProcedure(this._DashboardDbConnectionString
                                                                                , "proc_GetSSASDimensionDataByOrg"
                                                                                , new string[] { "Organization" }
                                                                                , new object[] { OrganizationCode }
                                                                                );
                    int SecureLevel = (int)dtDimensionData.Rows[0]["Depth"];
                    for (int i = 0; i <= SecureLevel; i++)
                    {
                        if (i != SecureLevel)
                        {
                            DenyDimensionDataRead("Employee Cost Center"
                                                    , RoleName
                                                    , "Level" + i.ToString() + " Code"
                                                    , "{[Employee Cost Center].[Level" + i.ToString() + " Code].[All]}"
                                                    );

                            DenyDimensionDataRead("Cost Center"
                                                    , RoleName
                                                    , "Level" + i.ToString() + " Code"
                                                    , "{[Cost Center].[Level" + i.ToString() + " Code].[All]}"
                                                    );
                        }
                        else
                        {
                            GrantDimensionDataRead("Employee Cost Center"
                                                    , RoleName
                                                    , dtDimensionData.Rows[0]["AttributeName"].ToString()
                                                    , "{" + dtDimensionData.Rows[0]["MDXExpression"].ToString() + "}"
                                                    , dtDimensionData.Rows[0]["MDXExpression"].ToString()
                                                    );

                            GrantDimensionDataRead("Cost Center"
                                                    , RoleName
                                                    , dtDimensionData.Rows[0]["AttributeName"].ToString()
                                                    , "{" + dtDimensionData.Rows[0]["MDXExpression"].ToString().Replace("Employee ","") + "}"
                                                    , dtDimensionData.Rows[0]["MDXExpression"].ToString().Replace("Employee ", "")
                                                    );
                        }
                    }
                }
                /*

                    // Loop Through Levels

                 */
                // Restrict rights based on Role
                /*if (!RoleName.StartsWith("SADM"))
                {
                    DataTable dtEmpDimensionData = GetCostCenterDimensionData(OrganizationCode, "Employee Cost Center");
                    // Loop Through Levels
                    int SecureLevel = (int)dtEmpDimensionData.Rows[0]["Depth"];
                    for (int i = 0; i <= SecureLevel; i++)
                    {

                        if (i == SecureLevel)
                        {
                            GrantDimensionDataReadAddUpdate("Employee Cost Center"
                                                    , RoleName
                                                    , dtEmpDimensionData
                                                    , eDashboardRoleType
                                                    );

                            //string MDX = dtEmpDimensionData.Rows[0]["MDXExpression"].ToString();
                            //string costcenterMDX = MDX.Replace("[Employee Cost Center]", "[Cost Center]");


                            DataTable dtCCDimensionData = GetCostCenterDimensionData(OrganizationCode, "Cost Center");
                            //adding Cost Center dimension security for FTE
                            GrantDimensionDataReadAddUpdate("Cost Center"
                                                   , RoleName
                                                   , dtCCDimensionData
                                                   , eDashboardRoleType
                                                   );
                        }
                    }
                }*/
            }
            else
            {
                AddRoleMember(RoleName, UserEmailAddress);
            }
        }

        private void SetParentMemberPermission(string DimensionName,Dimension dim, DimensionPermission dimPermission, DataTable dtDimensionData, int attributeLevel)
        {
            if (attributeLevel > 0)
            {
                for (int levelcounter = 0; levelcounter < attributeLevel; levelcounter++)
                {
                    string currentattributename = string.Format("Level{0} Code", levelcounter.ToString());
                    string currentattributecode = string.Format("Level{0}Code", levelcounter.ToString());
                    string currentattributecodevalue = "";

                    if (dtDimensionData.Columns.Contains(currentattributecode))
                    {
                        currentattributecodevalue = dtDimensionData.Rows[0][currentattributecode].ToString();
                    }

                    AttributePermission LevelAttributePermission = dimPermission.AttributePermissions.Find(currentattributename);

                    string levelallowedset = "";

                    if (currentattributecodevalue != "")
                    {
                        levelallowedset = string.Format("[{0}].[{1}].&[{2}]", DimensionName, currentattributename, currentattributecodevalue);
                    }

                    if (LevelAttributePermission != null) //if the permission exists at given level then modify allowed member set 
                    {
                        if (LevelAttributePermission.AllowedSet != null)
                        {
                            string strallowedlevelset = LevelAttributePermission.AllowedSet;
                            strallowedlevelset = strallowedlevelset.TrimStart('{');
                            strallowedlevelset = strallowedlevelset.TrimEnd('}');
                            string[] levelset = strallowedlevelset.Split(',');
                            string newlevelset = GetNewAllowedSet(levelset, levelallowedset, enumMDXAction.Add);
                            LevelAttributePermission.AllowedSet = newlevelset;
                            string[] newlevelsetarray = newlevelset.Split(',');
                            //if there are more than two alloweset members then set the default member to empty string.
                            if (newlevelsetarray.Count() > 1)
                            {
                                LevelAttributePermission.DefaultMember = string.Empty;
                            }
                            else
                            {
                                string defaultmemberstr = newlevelset.TrimStart('{');
                                defaultmemberstr = defaultmemberstr.TrimEnd('}'); //removing curly braces in default member string to avoid error in cognos -tuple provided when only one member is expected
                                LevelAttributePermission.DefaultMember = defaultmemberstr; //if there is only one member then set the default string to that.
                            }
                        }
                        LevelAttributePermission.VisualTotals = "1";
                    }
                    else //if there are no permissions at the given level then create one
                    {
                        LevelAttributePermission = new AttributePermission();
                        LevelAttributePermission.AllowedSet = levelallowedset;
                        LevelAttributePermission.DefaultMember = levelallowedset;
                        LevelAttributePermission.VisualTotals = "1";
                        DimensionAttribute dimAttrib = dim.Attributes.FindByName(currentattributename);
                        LevelAttributePermission.AttributeID = dimAttrib.ID;
                        dimPermission.AttributePermissions.Add(LevelAttributePermission);
                    }
                }
            }
        }
        private string GetNewAllowedSet(string[] existingallowedset, string mdxExpression, enumMDXAction eAction)
        {
            string newallowedset = string.Empty;

            int i = 0;
            int existingcount = existingallowedset.Count();
            if (eAction == enumMDXAction.Add)
            {
                if (existingcount > 0)
                {
                    foreach (string org in existingallowedset)
                        {
                            if (i == 0)
                            {
                                newallowedset = org + ",";
                            }
                            else
                            {
                                newallowedset = newallowedset + org + ",";
                            }
                            i++;

                        }
                        if (i > 0)
                        {
                            
                            //if the existing allowed set already contains the additionalmdxExpression then there is no need to append it
                            if (!existingallowedset.Contains(mdxExpression))
                            {
                                newallowedset = "{" + newallowedset + mdxExpression + "}";
                            }
                            else
                            {  
                                newallowedset = newallowedset.TrimEnd(',');
                                newallowedset = "{" + newallowedset + "}";
                            }
                        }                   
                    
                }
                else
                {
                    newallowedset = mdxExpression;
                }
            }
            else //remove the mdx expression
            {
                if (existingcount > 0)
                {
                    foreach (string org in existingallowedset)
                    {
                        //check if mdxExpression to be removed is found then skip that 
                        if (org != mdxExpression)
                        {
                            if (i == 0)
                            {
                                newallowedset = org + ",";
                            }
                            else
                            {
                                newallowedset = newallowedset + org + ",";
                            }
                           
                            i++;
                        }

                    }
                    if (newallowedset.Length > 0)
                    {
                        newallowedset = newallowedset.TrimEnd(',');
                        if (i > 1)
                        {
                            newallowedset = "{" + newallowedset + "}";
                        }
                    }

                }
            }
            return newallowedset;
        }
        private void GrantDimensionDataReadAddUpdate(string DimensionName, string RoleName, DataTable dtDimensionData, enumDashboardRoleType eDashboardRoleType)
        {
            //for e.g. 'FF01E00000' is Level01 code

            string attributeName = dtDimensionData.Rows[0]["AttributeName"].ToString();//Level1 Code
            string mdxExpression = dtDimensionData.Rows[0]["MDXExpression"].ToString();//[Employee Cost Center].[Level1 Code].&[FF01E00000]
            //setting default member to empty for all other role types except Division Chief/Project Leader
            //because a single user can be member of different regional role/program level role and if you set the default member 
            // and if user is HRO  of two different regions /ARD for two different programs then user will be HRO for only one region/ARD for only one program
            //user won't be able to access two regions/programs
        
            string defaultMemberMdx = string.Empty; 
            int attributeLevel = (int)dtDimensionData.Rows[0]["Depth"];//1
          
            try
            {
                Role role = this._DB.Roles.FindByName(RoleName);

                //getting dimension
                Dimension dim = this._DB.Dimensions.FindByName(DimensionName);

                //getting all permissions for a given role for a given dimension
                DimensionPermission dimPermission = dim.DimensionPermissions.FindByRole(role.ID);
                if (dimPermission == null)
                    dimPermission = dim.DimensionPermissions.Add(role.ID);
                //getting attribute level permissions for this dimension
                AttributePermission dimAttrPermission = dimPermission.AttributePermissions.Find(attributeName);
                //if no permission exists then create new attribute permission and set it's allowedset property to mdxExpression
                if (dimAttrPermission == null)
                {
                    dimAttrPermission = new AttributePermission();
                    dimAttrPermission.AllowedSet = mdxExpression;
                    if (eDashboardRoleType == enumDashboardRoleType.DivisionChief || eDashboardRoleType == enumDashboardRoleType.ProjectLeader)
                    {
                        if (attributeLevel > 0)
                        {
                            SetParentMemberPermission(DimensionName, dim, dimPermission, dtDimensionData, attributeLevel);
                        }
                        else
                        {
                            defaultMemberMdx = dtDimensionData.Rows[0]["MDXExpression"].ToString();//[Employee Cost Center].[Level1 Code].&[FF01E00000]
                        }
                    }
                    dimAttrPermission.DefaultMember = defaultMemberMdx;
                    dimAttrPermission.VisualTotals = "1";
                    DimensionAttribute dimAttrib = dim.Attributes.FindByName(attributeName);
                    if (dimAttrib == null)
                    {
                        //return -1;
                    }
                    dimAttrPermission.AttributeID = dimAttrib.ID;
                    dimPermission.AttributePermissions.Add(dimAttrPermission);
                }
                else //dimension attribute permission exists - so update the allowed set member
                {
                    string strallowedset = dimAttrPermission.AllowedSet;
                    strallowedset = strallowedset.TrimStart('{');
                    strallowedset = strallowedset.TrimEnd('}');
                    string[] allowedset = strallowedset.Split(',');  
                   
                    string newallowedset = GetNewAllowedSet(allowedset, mdxExpression, enumMDXAction.Add);
                    dimAttrPermission.AllowedSet = newallowedset;
                    // When there are more than one org codes are allowed at the same attribute level,then define default member at parent level
                    // and remove the defualt member at the current level
                    dimAttrPermission.DefaultMember = string.Empty; //setting no default member at current attribute level
                    if (attributeLevel > 0)
                    {
                        SetParentMemberPermission(DimensionName, dim, dimPermission, dtDimensionData, attributeLevel);
                    } //end attributeLevel>0
                    else
                    {
                        dimAttrPermission.DefaultMember = string.Empty;
                        dimAttrPermission.VisualTotals = "1";
                        dimAttrPermission.AttributeID = attributeName;
                    }


                }
                dimPermission.Update(UpdateOptions.AlterDependents, UpdateMode.UpdateOrCreate);
                role.Refresh();
            }
            catch (OutOfMemoryException memoryException)
            {
                HandleException(new OutOfMemoryException("ERROR: GrantDimensionDataRead() failed with out of memory exception. The exception message is " + memoryException.Message));

            }
            catch (ConnectionException ServerNotFoundException)
            {
                HandleException(new ConnectionException("ERROR: Unable to connect to Analysis Server '" + this._SSAS + "'. Connection failed with error message " + ServerNotFoundException.Message));
            }
            catch (ArgumentNullException ArgNullException)
            {
                if (RoleName == null) { HandleException(new AmoException("ERROR: roleName parameter supplied with NULL value to GrantDimensionDataRead()")); }
                if (DimensionName == null) { HandleException(new AmoException("ERROR: dimensionName parameter supplied with NULL value to GrantDimensionDataRead()")); }
                if (mdxExpression == null) { HandleException(new AmoException("ERROR: mdxExpression parameter supplied with NULL value to GrantDimensionDataRead()")); }
                if (attributeName == null) { HandleException(new AmoException("ERROR: attribName parameter supplied with NULL value to GrantDimensionDataRead()")); }
                HandleException(ArgNullException);
            }
            catch (OperationException OpException)
            {
                HandleException(new AmoException("ERROR: GrantDimensionDataRead() failed with exception " + OpException.Message + ". Parameters passed were roleName=" + RoleName + ",dimensionName=" + DimensionName + ",attribName=" + attributeName + ",mdxExpression=" + mdxExpression));
            }
            catch (AmoException GenericAmoException)
            {
                if (RoleName.Trim() == "") { HandleException(new AmoException("ERROR: roleName parameter supplied with blank value to GrantDimensionDataRead()")); }
                if (DimensionName.Trim() == "") { HandleException(new AmoException("ERROR: dimensionName parameter supplied with blank value to GrantDimensionDataRead()")); }
                if (mdxExpression.Trim() == "") { HandleException(new AmoException("ERROR: mdxExpression parameter supplied with blank value to GrantDimensionDataRead()")); }
                if (attributeName.Trim() == "") { HandleException(new AmoException("ERROR: attribName parameter supplied with blank value to GrantDimensionDataRead()")); }
                HandleException(GenericAmoException);
            }
            catch (Exception ex)
            {

                HandleException(ex);
            }
        }
        public DataTable GetEmployeeCostCenterDimensionData(string OrganizationCode)
        {
            DataTable dtDimensionData = new DataTable();

            try
            {
                dtDimensionData = this.ExecuteStoredProcedure(this._DashboardDbConnectionString
                                                                            , "proc_GetSSASDimensionDataByOrg_Test"
                                                                            , new string[] { "Organization", "DimensionName" }
                                                                            , new object[] { OrganizationCode, "Employee Cost Center" }
                                                                            );


            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return dtDimensionData;

        }

        public DataTable GetCostCenterDimensionData(string OrganizationCode, string DimensionName)
        {
            DataTable dtDimensionData = new DataTable();

            try
            {
                dtDimensionData = this.ExecuteStoredProcedure(this._DashboardDbConnectionString
                                                                            , "proc_GetSSASDimensionDataByOrg_Test"
                                                                            , new string[] { "Organization", "DimensionName" }
                                                                            , new object[] { OrganizationCode, DimensionName }
                                                                            );


            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return dtDimensionData;

        }

        public void RemoveUserRoleOrgCodeAccess(string RoleName, string UserEmailAddress, string OrganizationCode)
        {
            try
            {
                if (this._DB.Roles.FindByName(RoleName) != null)
                {
                    bool MemberExists = false;
                    string DimensionName = "Employee Cost Center";

                    RoleMember currentMember = new RoleMember();
                    NTAccount acct = new NTAccount(UserEmailAddress);
                    SecurityIdentifier sid = (SecurityIdentifier)acct.Translate(typeof(SecurityIdentifier));

                    Role r = _DB.Roles.FindByName(RoleName);
                    int memeberct = r.Members.Count;


                    foreach (RoleMember rm in r.Members)
                    {
                        if (rm.Sid.ToString() == sid.ToString())
                        {
                            MemberExists = true;
                            currentMember = rm;

                            break;
                        }
                    }



                    if (MemberExists)
                    {
                        DataTable dtDimensionData = GetCostCenterDimensionData(OrganizationCode, DimensionName);
                        string OrgMDX = (string)dtDimensionData.Rows[0]["MDXExpression"];
                        string AttributeName = (string)dtDimensionData.Rows[0]["AttributeName"];
                        Dimension dim = this._DB.Dimensions.FindByName(DimensionName);

                        DimensionPermission dimPermission = dim.DimensionPermissions.FindByRole(r.ID);

                        DeleteRoleMember(RoleName, currentMember);
                        /*
                        if (memeberct > 1) //if there are other members in the same role then remove this member from the role
                        {
                            DeleteRoleMember(RoleName, currentMember);
                        }
                        else //only one member in the role then modify the role 
                        {


                            if (dimPermission != null)
                            {

                                ModifyRole(OrganizationCode, r);
                            } //end dimensionpermission!=null



                            else // there are no permissions for this dimension and  role -- so drop the role
                            {
                                r.Drop(DropOptions.AlterOrDeleteDependents);
                            }

                        }// end memberct<=1
                        */

                    }//end memberexists


                }
            }



            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        #endregion

        #region Private Methods
        private void ModifyAttributePermssion(DimensionPermission DimPermission, AttributePermission LevelAttributePermission, string LevelmembertobeDeleted)
        {
            string levelallowedset = LevelAttributePermission.AllowedSet.TrimStart('{') ;
            levelallowedset = levelallowedset.TrimEnd('}');


            string[] levelset = levelallowedset.Split(',');
            string newlevelset = GetNewAllowedSet(levelset, LevelmembertobeDeleted, enumMDXAction.Delete);
            if (newlevelset.Length > 0)
            {
                LevelAttributePermission.AllowedSet = newlevelset;
                string[] newlevelsetarray = newlevelset.Split(',');
                //if there are more than two alloweset members then set the default member to empty string.
                if (newlevelsetarray.Count() > 1)
                {
                    LevelAttributePermission.DefaultMember = string.Empty;
                }
                else
                {
                    string defaultmemberstr = newlevelset.TrimStart('{');
                    defaultmemberstr = defaultmemberstr.TrimEnd('}');
                    LevelAttributePermission.DefaultMember = defaultmemberstr; //if there is only one member then set the default string to that.
                }
                LevelAttributePermission.VisualTotals = "1";
            }
            else //if  no allowed member at this level then delete the attribute permission
            {
                DimPermission.AttributePermissions.Remove(LevelAttributePermission);
            }
        }
        private void ModifyRole(string OrganizationCode, Role r)
        {
            string EmpDimensionName = "Employee Cost Center";
            string CCDimensionName = "Cost Center";
            DataTable dtEmpDimensionData = GetCostCenterDimensionData(OrganizationCode, EmpDimensionName);
            DataTable dtCCDimensionData = GetCostCenterDimensionData(OrganizationCode, CCDimensionName);
            string OrgMDX = (string)dtEmpDimensionData.Rows[0]["MDXExpression"];
            string EmpAttributeName = (string)dtEmpDimensionData.Rows[0]["AttributeName"];

            string CCAttributeName = (string)dtCCDimensionData.Rows[0]["AttributeName"];

            Dimension dimEmp = this._DB.Dimensions.FindByName(EmpDimensionName);
            Dimension dimCC = this._DB.Dimensions.FindByName(CCDimensionName);

            DimensionPermission dimEmpPermission = dimEmp.DimensionPermissions.FindByRole(r.ID);
            DimensionPermission dimCCPermission = dimCC.DimensionPermissions.FindByRole(r.ID);

            AttributePermission dimEmpAttrPermission = dimEmpPermission.AttributePermissions.Find(EmpAttributeName);
            AttributePermission dimccAttrPermission = dimCCPermission.AttributePermissions.Find(CCAttributeName);


            if (dimEmpAttrPermission != null)
            {
                try
                {
                    string newallowedset = string.Empty;
                    if ((dimEmpAttrPermission.AllowedSet != null) && (dimEmpAttrPermission.AllowedSet.Length > 0))
                    {

                        string strallowedset = dimEmpAttrPermission.AllowedSet;
                        strallowedset = strallowedset.TrimStart('{');
                        strallowedset = strallowedset.TrimEnd('}');
                        string[] allowedset = strallowedset.Split(',');  
                        newallowedset = GetNewAllowedSet(allowedset, OrgMDX, enumMDXAction.Delete);
                      
                    }

                    //if there are no allowedset members for this attribute level then remove 
                    //attribute level permission 
                    if (newallowedset.Length == 0)
                    {

                        if (dimEmpPermission.AttributePermissions.Contains(dimEmpAttrPermission))
                            dimEmpPermission.AttributePermissions.Remove(dimEmpAttrPermission);

                        if (dimCCPermission.AttributePermissions.Contains(dimccAttrPermission))
                            dimCCPermission.AttributePermissions.Remove(dimccAttrPermission);

                        //find the level of attribute 
                        //if the attribute has parent, and the parent has only one allowed member in the set then drop the parent attribute permission as well
                        int attributeLevel = (int)dtEmpDimensionData.Rows[0]["Depth"];
                        if (attributeLevel > 0)
                        {
                            for (int levelcounter = attributeLevel; levelcounter >= 0; levelcounter--)
                            {
                                string currentattributename = string.Format("Level{0} Code", levelcounter.ToString());
                                string currentattributecode = string.Format("Level{0}Code", levelcounter.ToString());

                                if (dtEmpDimensionData.Columns.Contains(currentattributecode))
                                {
                                    string currentattributecodevalue = dtEmpDimensionData.Rows[0][currentattributecode].ToString();

                                    if (dimEmpPermission.AttributePermissions.Contains(currentattributename))
                                    {
                                        AttributePermission LevelEmpAttributePermission = dimEmpPermission.AttributePermissions.Find(currentattributename);
                                        AttributePermission LevelCCAttributePermission = dimCCPermission.AttributePermissions.Find(currentattributename);
                                        string levelempmembertobedeleted = string.Format("[{0}].[{1}].&[{2}]", EmpDimensionName, currentattributename, currentattributecodevalue);
                                        string levelccmembertobedeleted = string.Format("[{0}].[{1}].&[{2}]", CCDimensionName, currentattributename, currentattributecodevalue);
                                        if (LevelEmpAttributePermission != null) //if the permission exists at given level then modify allowed member set 
                                        {
                                            ModifyAttributePermssion(dimEmpPermission, LevelEmpAttributePermission, levelempmembertobedeleted);
                                        }
                                        if (LevelCCAttributePermission != null)
                                        {
                                            ModifyAttributePermssion(dimCCPermission, LevelCCAttributePermission, levelccmembertobedeleted);
                                        }
                                    }
                                }
                            }
                        }

                        if (dimEmpPermission.AttributePermissions.Count == 0)
                        {
                            //if for this role there are no more attribute permissions defined then 
                            //drop the permission 
                            dimEmpPermission.Drop(DropOptions.AlterOrDeleteDependents);
                            dimCCPermission.Drop(DropOptions.AlterOrDeleteDependents);

                            //if there are no more permissions defined for this role for this dimension then
                            //drop the role
                            if (dimEmp.DimensionPermissions.FindByRole(r.ID) == null)
                            {
                                //finally delete role from database
                                r.Drop(DropOptions.AlterOrDeleteDependents);
                            }
                        }
                        else
                        {
                            dimEmpPermission.Update(UpdateOptions.AlterDependents, UpdateMode.UpdateOrCreate);
                            dimCCPermission.Update(UpdateOptions.AlterDependents, UpdateMode.UpdateOrCreate);
                            r.Refresh();
                        }
                    }//newallowedset.Lenght>0
                    else
                    {
                        dimEmpAttrPermission.AllowedSet = newallowedset;
                        dimccAttrPermission.AllowedSet = newallowedset;
                        dimEmpPermission.Update(UpdateOptions.AlterDependents, UpdateMode.UpdateOrCreate);
                        dimCCPermission.Update(UpdateOptions.AlterDependents, UpdateMode.UpdateOrCreate);
                        r.Refresh();
                    }

                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

        }
        private DataTable GetOrgDimensionInfo(string OrganizationCode)
        {

            DataTable dt;
            dt = this.ExecuteStoredProcedure(this._DashboardDbConnectionString
                                                                               , "proc_GetSSASDimensionDataByOrg"
                                                                               , new string[] { "Organization" }
                                                                               , new object[] { OrganizationCode }
                                                                               );

            return dt;
        }
        private DataTable GetOrgProgramName(string OrganizationCode)
        {

            DataTable dt;
            dt = this.ExecuteStoredProcedure(this._DashboardDbConnectionString
                                                                               , "proc_GetOrgProgramName"
                                                                               , new string[] { "Organization" }
                                                                               , new object[] { OrganizationCode }
                                                                               );

            return dt;
        }
        private void AddRole(string RoleName)
        {
            try
            {
                if (this._DB.Roles.FindByName(RoleName) == null)
                {
                    Role role = this._DB.Roles.Add(RoleName);
                    role.Update();
                };
            }
            catch (OutOfMemoryException memoryException)
            {
                HandleException(new OutOfMemoryException("ERROR: AddRole() failed with out of memory exception. The exception message is " + memoryException.Message));
            }
            catch (ConnectionException ServerNotFoundException)
            {
                HandleException(new ConnectionException("ERROR: Unable to connect to Analysis Server '" + this._SSAS + "'. Connection failed with error message " + ServerNotFoundException.Message));
            }
            catch (ArgumentNullException ArgNullException)
            {
                if (RoleName == null) { HandleException(new AmoException("ERROR: roleName parameter supplied with NULL value to AddRole()")); }
                HandleException(ArgNullException);
            }
            catch (OperationException OpException)
            {
                HandleException(new AmoException("ERROR: AddRole() failed with exception " + OpException.Message + ". Parameters passed were roleName=" + RoleName));
            }
            catch (AmoException GenericAmoException)
            {
                if (RoleName.Trim() == "")
                    HandleException(new AmoException("ERROR: roleName parameter supplied with blank value to AddRole()"));
                HandleException(GenericAmoException);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void AddRoleMember(string RoleName, string User)
        {
            bool MemberExists = false;
            NTAccount acct = new NTAccount(User);
            SecurityIdentifier sid = (SecurityIdentifier)acct.Translate(typeof(SecurityIdentifier));

            try
            {
                Role r = _DB.Roles.FindByName(RoleName);

                foreach (RoleMember rm in r.Members)
                {
                    if (rm.Sid.ToString() == sid.ToString())
                    {
                        MemberExists = true;
                        break;
                    }
                }

                if (!MemberExists)
                {
                    r.Members.Add(new RoleMember(User, sid.ToString()));
                    r.Update();
                }
            }
            catch (OutOfMemoryException memoryException)
            {
                HandleException(new OutOfMemoryException("ERROR: AddmemberToRole() failed with out of memory exception. The exception message is " + memoryException.Message));
            }
            catch (ConnectionException ServerNotFoundException)
            {
                HandleException(new ConnectionException("ERROR: Unable to connect to Analysis Server '" + this._SSAS + "'. Connection failed with error message " + ServerNotFoundException.Message));
            }
            catch (ArgumentNullException ArgNullException)
            {
                if (User == null) { HandleException(new AmoException("ERROR: memberName parameter supplied with NULL value to AddMemberToRole()")); }
                if (RoleName == null) { HandleException(new AmoException("ERROR: roleName parameter supplied with NULL value to AddMemberToRole()")); }
                HandleException(ArgNullException);
            }
            catch (OperationException OpException)
            {
                HandleException(new AmoException("ERROR: AddMemberToRole() failed with exception " + OpException.Message + ". Parameters passed were memberName =" + User + ",roleName=" + RoleName));
            }
            catch (AmoException GenericAmoException)
            {
                if (User.Trim() == "") { HandleException(new AmoException("ERROR: memberName parameter supplied with blank value to AddMemberToRole()")); }
                if (RoleName.Trim() == "") { HandleException(new AmoException("ERROR: roleName parameter supplied with blank value to AddMemberToRole()")); }
                HandleException(GenericAmoException);
            }

            catch (System.Security.Principal.IdentityNotMappedException ex)
            {
                HandleException(new AmoException("Error: Validating user's NT account"));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }


        }
        private void DeleteRoleMember(string RoleName,RoleMember rm)
        {
          

            try
            {
                Role r = _DB.Roles.FindByName(RoleName);
               
                if (r.Members.Contains(rm))
                {
                   int i= r.Members.IndexOf(rm);
                   r.Members.RemoveAt(i);
                    r.Update();
                }

              

            }
            catch (OutOfMemoryException memoryException)
            {
                HandleException(new OutOfMemoryException("ERROR: RemoveMemberFromRole() failed with out of memory exception. The exception message is " + memoryException.Message));
            }
            catch (ConnectionException ServerNotFoundException)
            {
                HandleException(new ConnectionException("ERROR: Unable to connect to Analysis Server '" + this._SSAS + "'. Connection failed with error message " + ServerNotFoundException.Message));
            }
            catch (ArgumentNullException ArgNullException)
            {
                if (rm == null) { HandleException(new AmoException("ERROR: RoleMember parameter supplied with NULL value to DeleteRoleMember()")); }
                if (RoleName == null) { HandleException(new AmoException("ERROR: roleName parameter supplied with NULL value to DeleteRoleMember()")); }
                HandleException(ArgNullException);
            }
            catch (OperationException OpException)
            {
                HandleException(new AmoException("ERROR: DeleteRoleMember() failed with exception " + OpException.Message ));
            }
            catch (AmoException GenericAmoException)
            {
                
                if (RoleName.Trim() == "") { HandleException(new AmoException("ERROR: roleName parameter supplied with blank value to DeleteRoleMember()")); }
                HandleException(GenericAmoException);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void DenyDimensionDataRead(string DimensionName, string RoleName, string attribName, string mdxExpression)
        {
            try
            {
                Role role = this._DB.Roles.FindByName(RoleName);
                //if (role == null) return -1;
                Dimension dim = this._DB.Dimensions.FindByName(DimensionName);
                //if (dim == null) return -1;
                DimensionPermission dimPermission = dim.DimensionPermissions.FindByRole(role.ID);
                if (dimPermission == null)
                    dimPermission = dim.DimensionPermissions.Add(role.ID);
                AttributePermission dimAttrPermission = dimPermission.AttributePermissions.Find(attribName);
                if (dimAttrPermission == null)
                {
                    dimAttrPermission = new AttributePermission();
                    dimAttrPermission.DeniedSet = mdxExpression;

                    dimAttrPermission.VisualTotals = "1";
                    DimensionAttribute dimAttrib = dim.Attributes.FindByName(attribName);
                    if (dimAttrib == null)
                    {
                        //return -1;
                    }
                    dimAttrPermission.AttributeID = dimAttrib.ID;
                    dimPermission.AttributePermissions.Add(dimAttrPermission);
                }
                else
                {
                    dimAttrPermission.AllowedSet = mdxExpression;
                    dimAttrPermission.DefaultMember = mdxExpression;
                    dimAttrPermission.VisualTotals = "1";
                    dimAttrPermission.AttributeID = attribName;
                }
                dimPermission.Update(UpdateOptions.AlterDependents, UpdateMode.UpdateOrCreate);
                role.Refresh();
            }
            catch (OutOfMemoryException memoryException)
            {
                HandleException(new OutOfMemoryException("ERROR: GrantDimensionDataRead() failed with out of memory exception. The exception message is " + memoryException.Message));
            }
            catch (ConnectionException ServerNotFoundException)
            {
                HandleException(new ConnectionException("ERROR: Unable to connect to Analysis Server '" + this._SSAS + "'. Connection failed with error message " + ServerNotFoundException.Message));
            }
            catch (ArgumentNullException ArgNullException)
            {
                if (RoleName == null) { HandleException(new AmoException("ERROR: roleName parameter supplied with NULL value to GrantDimensionDataRead()")); }
                if (DimensionName == null) { HandleException(new AmoException("ERROR: dimensionName parameter supplied with NULL value to GrantDimensionDataRead()")); }
                if (mdxExpression == null) { HandleException(new AmoException("ERROR: mdxExpression parameter supplied with NULL value to GrantDimensionDataRead()")); }
                if (attribName == null) { HandleException(new AmoException("ERROR: attribName parameter supplied with NULL value to GrantDimensionDataRead()")); }
                HandleException(ArgNullException);
            }
            catch (OperationException OpException)
            {
                HandleException(new AmoException("ERROR: GrantDimensionDataRead() failed with exception " + OpException.Message + ". Parameters passed were roleName=" + RoleName + ",dimensionName=" + DimensionName + ",attribName=" + attribName + ",mdxExpression=" + mdxExpression));
            }
            catch (AmoException GenericAmoException)
            {
                if (RoleName.Trim() == "") { HandleException(new AmoException("ERROR: roleName parameter supplied with blank value to GrantDimensionDataRead()")); }
                if (DimensionName.Trim() == "") { HandleException(new AmoException("ERROR: dimensionName parameter supplied with blank value to GrantDimensionDataRead()")); }
                if (mdxExpression.Trim() == "") { HandleException(new AmoException("ERROR: mdxExpression parameter supplied with blank value to GrantDimensionDataRead()")); }
                if (attribName.Trim() == "") { HandleException(new AmoException("ERROR: attribName parameter supplied with blank value to GrantDimensionDataRead()")); }
                HandleException(GenericAmoException);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void DropAllRoles()
        {
            try
            {
                List<Role> roles = new List<Role>();
                foreach (Role role in this._DB.Roles)
                {
                    roles.Add(role);
                }
                foreach (Role role in roles)
                {
                    if (role.Name != "Admin" && role.Name != "Cognos")
                    {
                        this.DropRole(role.Name);
                    }
                }
            }
            catch (OutOfMemoryException memoryException)
            {
                HandleException(new OutOfMemoryException("ERROR: DropAllRoles() failed with out of memory exception. The exception message is " + memoryException.Message));
            }
            catch (ConnectionException ServerNotFoundException)
            {
                HandleException(new ConnectionException("ERROR: Unable to connect to Analysis Server '" + this._SSAS + "'. Connection failed with error message " + ServerNotFoundException.Message));
            }
            catch (OperationException OpException)
            {
                HandleException(new AmoException("ERROR: DropAllRoles() failed with exception " + OpException.Message));
            }
            catch (AmoException GenericAmoException)
            {
                HandleException(GenericAmoException);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void DeleteUserSpecificRole(string emailAddress)
        {
            string rolename = "User_" + emailAddress.Substring(0, emailAddress.IndexOf('@'));
            this.DropRole(rolename);
        }

        private void DropRole(String roleName)
        {
            Role role = this._DB.Roles.FindByName(roleName);
            try
            {
                //if (role == null)
                //return retVal;
                //delete members from role
                if (role.Members.Count > 0)
                {
                    role.Members.Clear();
                    role.Update();
                }
                //delete dimension permissions for the role
                foreach (Dimension dim in this._DB.Dimensions)
                {
                    DimensionPermission dimPermission = dim.DimensionPermissions.FindByRole(role.ID);
                    if (dimPermission != null)
                    {
                        dimPermission.AttributePermissions.Clear();
                        dimPermission.Drop(DropOptions.AlterOrDeleteDependents);
                    }
                }
                //delete cube permissions for the role
                //CubePermission cubePermission = this.Cube.CubePermissions.FindByRole(role.ID);
                //if (cubePermission != null) cubePermission.Drop(DropOptions.AlterOrDeleteDependents);
                //delete database permissions for role
                DatabasePermission dbPermission = this._DB.DatabasePermissions.FindByRole(role.ID);
                if (dbPermission != null) dbPermission.Drop(DropOptions.AlterOrDeleteDependents);
                //dbPermission.Update();
                //finally delete role from database
                role.Drop(DropOptions.AlterOrDeleteDependents);
            }
            catch (OutOfMemoryException memoryException)
            {
                HandleException(new OutOfMemoryException("ERROR: DropRole() failed with out of memory exception. The exception message is " + memoryException.Message));
            }
            catch (ConnectionException ServerNotFoundException)
            {
                HandleException(new ConnectionException("ERROR: Unable to connect to Analysis Server '" + this._SSAS + "'. Connection failed with error message " + ServerNotFoundException.Message));
            }
            catch (ArgumentNullException ArgNullException)
            {
                if (roleName == null) { HandleException(new AmoException("ERROR: roleName parameter supplied with NULL value to DropRole()")); }
                HandleException(ArgNullException);
            }
            catch (OperationException OpException)
            {
                role.Refresh(true);
                HandleException(new AmoException("ERROR: DropRole() failed with exception " + OpException.Message + ". Parameters passed were roleName=" + roleName));
            }
            catch (AmoException GenericAmoException)
            {
                if (roleName.Trim() == "")
                    HandleException(new AmoException("ERROR: roleName parameter supplied with blank value to DropRole()"));
                HandleException(GenericAmoException);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void GrantCubeRead(string CubeName, string RoleName)
        {

            try
            {
                this._Cube = this._DB.Cubes.FindByName(CubeName);
                Role role = this._DB.Roles.FindByName(RoleName);
                //if (role == null) return -1; throw RoleNotFoundException
                CubePermission cubeReadPermission = this._Cube.CubePermissions.FindByRole(role.ID);
                if (cubeReadPermission == null) //no permissions
                    cubeReadPermission = this._Cube.CubePermissions.Add(role.ID);
                cubeReadPermission.Read = ReadAccess.Allowed;
                cubeReadPermission.Update(UpdateOptions.AlterDependents, UpdateMode.UpdateOrCreate);
            }
            catch (OutOfMemoryException memoryException)
            {
                HandleException(new OutOfMemoryException("ERROR: GrantCubeRead() failed with out of memory exception. The exception message is " + memoryException.Message));
            }
            catch (ConnectionException ServerNotFoundException)
            {
                HandleException(new ConnectionException("ERROR: Unable to connect to Analysis Server '" + this._SSAS + "'. Connection failed with error message " + ServerNotFoundException.Message));
            }
            catch (ArgumentNullException ArgNullException)
            {
                if (RoleName == null) { HandleException(new AmoException("ERROR: roleName parameter supplied with NULL value to GrantCubeRead()")); }
                HandleException(ArgNullException);
            }
            catch (OperationException OpException)
            {
                HandleException(new AmoException("ERROR: GrantCubeRead() failed with exception " + OpException.Message + ". Parameters passed were roleName=" + RoleName));
            }
            catch (AmoException GenericAmoException)
            {
                if (RoleName.Trim() == "") { HandleException(new AmoException("ERROR: roleName parameter supplied with blank value to GrantCubeRead()")); }
                HandleException(GenericAmoException);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void GrantCubeRights(string RoleName)
        {
            this.GrantCubeRead("Awards", RoleName);
            this.GrantCubeRead("FTE", RoleName);
            this.GrantCubeRead("Performance", RoleName);
            this.GrantCubeRead("Separations", RoleName);
            this.GrantCubeRead("Workforce Profile", RoleName);
        }

        public void GrantDatabaseRead(String roleName)
        {
            try
            {
                Role role = this._DB.Roles.FindByName(roleName);
                //if (role == null) return -1;
                DatabasePermission dbPermission = this._DB.DatabasePermissions.FindByRole(role.ID);
                if (dbPermission == null)
                {
                    dbPermission = new DatabasePermission();
                    dbPermission.RoleID = role.ID;
                    dbPermission.ID = role.Name;
                    dbPermission.Name = role.Name;
                    dbPermission.Read = ReadAccess.Allowed;
                    this._DB.DatabasePermissions.Add(dbPermission);
                }
                else
                {
                    dbPermission.Read = ReadAccess.Allowed;
                }
                dbPermission.Update(UpdateOptions.AlterDependents, UpdateMode.UpdateOrCreate);
                this._DB.Update(UpdateOptions.AlterDependents, UpdateMode.UpdateOrCreate);
            }
            catch (OutOfMemoryException memoryException)
            {
                HandleException(new OutOfMemoryException("ERROR: GrantCubeRead() failed with out of memory exception. The exception message is " + memoryException.Message));
            }
            catch (ConnectionException ServerNotFoundException)
            {
                HandleException(new ConnectionException("ERROR: Unable to connect to Analysis Server '" + this._SSAS + "'. Connection failed with error message " + ServerNotFoundException.Message));
            }
            catch (ArgumentNullException ArgNullException)
            {
                if (roleName == null) { HandleException(new AmoException("ERROR: roleName parameter supplied with NULL value to GrantCubeRead()")); }
                HandleException(ArgNullException);
            }
            catch (OperationException OpException)
            {
                HandleException(new AmoException("ERROR: GrantCubeRead() failed with exception " + OpException.Message + ". Parameters passed were roleName=" + roleName));
            }
            catch (AmoException GenericAmoException)
            {
                if (roleName.Trim() == "") { HandleException(new AmoException("ERROR: roleName parameter supplied with blank value to GrantCubeRead()")); }
                HandleException(GenericAmoException);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }





        private void GrantDimensionDataRead(string DimensionName, string RoleName, string attribName, string mdxExpression, string defaultMemberMdx)
        {
            try
            {
                Role role = this._DB.Roles.FindByName(RoleName);
                //if (role == null) return -1;
                Dimension dim = this._DB.Dimensions.FindByName(DimensionName);
                //if (dim == null) return -1;
                DimensionPermission dimPermission = dim.DimensionPermissions.FindByRole(role.ID);
                if (dimPermission == null)
                    dimPermission = dim.DimensionPermissions.Add(role.ID);
                AttributePermission dimAttrPermission = dimPermission.AttributePermissions.Find(attribName);
                if (dimAttrPermission == null)
                {
                    dimAttrPermission = new AttributePermission();
                    dimAttrPermission.AllowedSet = mdxExpression;
                    dimAttrPermission.DefaultMember = defaultMemberMdx;
                    dimAttrPermission.VisualTotals = "1";
                    DimensionAttribute dimAttrib = dim.Attributes.FindByName(attribName);
                    if (dimAttrib == null)
                    {
                        //return -1;
                    }
                    dimAttrPermission.AttributeID = dimAttrib.ID;
                    dimPermission.AttributePermissions.Add(dimAttrPermission);
                }
                else
                {
                    dimAttrPermission.AllowedSet = mdxExpression;
                    dimAttrPermission.DefaultMember = mdxExpression;
                    dimAttrPermission.VisualTotals = "1";
                    dimAttrPermission.AttributeID = attribName;
                }
                dimPermission.Update(UpdateOptions.AlterDependents, UpdateMode.UpdateOrCreate);
                role.Refresh();
            }
            catch (OutOfMemoryException memoryException)
            {
                HandleException(new OutOfMemoryException("ERROR: GrantDimensionDataRead() failed with out of memory exception. The exception message is " + memoryException.Message));
            }
            catch (ConnectionException ServerNotFoundException)
            {
                HandleException(new ConnectionException("ERROR: Unable to connect to Analysis Server '" + this._SSAS + "'. Connection failed with error message " + ServerNotFoundException.Message));
            }
            catch (ArgumentNullException ArgNullException)
            {
                if (RoleName == null) { HandleException(new AmoException("ERROR: roleName parameter supplied with NULL value to GrantDimensionDataRead()")); }
                if (DimensionName == null) { HandleException(new AmoException("ERROR: dimensionName parameter supplied with NULL value to GrantDimensionDataRead()")); }
                if (mdxExpression == null) { HandleException(new AmoException("ERROR: mdxExpression parameter supplied with NULL value to GrantDimensionDataRead()")); }
                if (attribName == null) { HandleException(new AmoException("ERROR: attribName parameter supplied with NULL value to GrantDimensionDataRead()")); }
                HandleException(ArgNullException);
            }
            catch (OperationException OpException)
            {
                HandleException(new AmoException("ERROR: GrantDimensionDataRead() failed with exception " + OpException.Message + ". Parameters passed were roleName=" + RoleName + ",dimensionName=" + DimensionName + ",attribName=" + attribName + ",mdxExpression=" + mdxExpression));
            }
            catch (AmoException GenericAmoException)
            {
                if (RoleName.Trim() == "") { HandleException(new AmoException("ERROR: roleName parameter supplied with blank value to GrantDimensionDataRead()")); }
                else if (DimensionName.Trim() == "") { HandleException(new AmoException("ERROR: dimensionName parameter supplied with blank value to GrantDimensionDataRead()")); }
                else if (mdxExpression.Trim() == "") { HandleException(new AmoException("ERROR: mdxExpression parameter supplied with blank value to GrantDimensionDataRead()")); }
                else if (attribName.Trim() == "") { HandleException(new AmoException("ERROR: attribName parameter supplied with blank value to GrantDimensionDataRead()")); }
                else HandleException(GenericAmoException);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void GrantUsersWithSingleRole()
        {
            // Get 1 to 1 Roles
            DbCommand commandWrapper = GetDbCommand("spr_GetSSASDashboardUsersWithSingleRole");
            DataTable dtUsersWithSingleRole = ExecuteDataTable(commandWrapper);

            foreach (DataRow dr in dtUsersWithSingleRole.Rows)
            {
                // Add Role to SSAS Database
                this.AddRole(dr["SSASRoleName"].ToString());

                // Add Member to Role
                this.AddRoleMember(dr["SSASRoleName"].ToString(), dr["EmailAddress"].ToString());

                // Grant Database Read Access
                this.GrantDatabaseRead(dr["SSASRoleName"].ToString());

                // Grant Read Access To Cubes
                this.GrantCubeRights(dr["SSASRoleName"].ToString());

                // Restrict rights based on Role
                if (!dr["SSASRoleName"].ToString().StartsWith("SADM"))
                {
                    DataTable dtDimensionData = this.ExecuteStoredProcedure(this._DashboardDbConnectionString
                                                                            , "proc_GetSSASDimensionDataByOrg"
                                                                            , new string[] { "Organization" }
                                                                            , new object[] { dr["OrganizationCode"].ToString() }
                                                                            );
                    // Loop Through Levels
                    int SecureLevel = (int)dtDimensionData.Rows[0]["Depth"];
                    for (int i = 0; i <= SecureLevel; i++)
                    {
                        if (i != SecureLevel)
                        {
                            DenyDimensionDataRead("Employee Cost Center"
                                                    , dr["SSASRoleName"].ToString()
                                                    , "Level" + i.ToString() + " Code"
                                                    , "{[Employee Cost Center].[Level" + i.ToString() + " Code].[All]}"
                                                    );
                        }
                        else
                        {
                            GrantDimensionDataRead("Employee Cost Center"
                                                    , dr["SSASRoleName"].ToString()
                                                    , dtDimensionData.Rows[0]["AttributeName"].ToString()
                                                    , dtDimensionData.Rows[0]["MDXExpression"].ToString()
                                                    , dtDimensionData.Rows[0]["MDXExpression"].ToString()
                                                    );
                        }
                    }
                }
            }
        }

        private void GrantUsersWithMultipleRoles()
        {
            DbCommand commandWrapper = GetDbCommand("spr_GetSSASDashboardUsersWithMultipleRoles");
            DataTable dtUsersWithMultipleRoles = ExecuteDataTable(commandWrapper);


            int CustomRoleCount = 1;

            foreach (DataRow dr in dtUsersWithMultipleRoles.Rows)
            {
                string CustomRoleName = "Custom" + CustomRoleCount.ToString();
                string OrganizationList = dr["Organizations"].ToString();
                string[] MdxExpressions = new string[6];
                string DefaultMember = string.Empty;

                // Add Role to SSAS Database
                this.AddRole(CustomRoleName);

                // Add Member to Role
                this.AddRoleMember(CustomRoleName, dr["EmailAddress"].ToString());

                // Grant Database Read Access
                this.GrantDatabaseRead(CustomRoleName);

                // Grant Read Access To Cubes
                this.GrantCubeRights(CustomRoleName);

                // Restrict rights based on Role
                foreach (string org in OrganizationList.Split(',').Distinct())
                {
                    DataTable dtDimensionData = this.ExecuteStoredProcedure(this._DashboardDbConnectionString
                                                                            , "proc_GetSSASDimensionDataByOrg"
                                                                            , new string[] { "Organization" }
                                                                            , new object[] { org }
                                                                            );
                    int SecureLevel = (int)dtDimensionData.Rows[0]["Depth"];

                    if (MdxExpressions[SecureLevel] == null)
                    {
                        MdxExpressions[SecureLevel] = (string)dtDimensionData.Rows[0]["MDXExpression"];
                    }
                    else
                    {
                        MdxExpressions[SecureLevel] = MdxExpressions[SecureLevel] + "," + (string)dtDimensionData.Rows[0]["MDXExpression"];
                    }

                }

                bool foundMdx = false;

                for (int i = 0; i < MdxExpressions.Length; i++)
                {
                    if (MdxExpressions[i] == null && !foundMdx)
                    {
                        this.DenyDimensionDataRead("Employee Cost Center"
                                                    , CustomRoleName
                                                    , "Level" + i.ToString() + " Code"
                                                    , "{[Employee Cost Center].[Level" + i.ToString() + " Code].[All]}"
                                                    );
                    }
                    else
                    {
                        if (MdxExpressions[i] != null)
                        {
                            this.GrantDimensionDataRead("Employee Cost Center"
                                                        , CustomRoleName
                                                        , "Level" + i.ToString() + " Code"
                                                        , "{" + MdxExpressions[i] + "}"
                                                        , DefaultMember
                                                        );
                            foundMdx = true;
                        }
                    }
                }

                CustomRoleCount++;
            }
        }

        #endregion

        #region Private Helper Methods

        protected DataTable ExecuteStoredProcedure(string ConnectionString, string sqlProcedureName)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand(sqlProcedureName, sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd))
                    {
                        sqlDA.Fill(dt);
                    }
                }
            }
            return dt;
        }

        protected DataTable ExecuteStoredProcedure(string ConnectionString, string sqlProcedureName, string[] parameterNames, object[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCmd = new SqlCommand(sqlProcedureName, sqlConn))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < parameterNames.Length; i++)
                    {
                        sqlCmd.Parameters.AddWithValue(parameterNames[i], parameters[i]);
                    }
                    using (SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd))
                    {
                        sqlDA.Fill(dt);
                    }
                }
            }
            return dt;
        }

        #endregion
    }
}
