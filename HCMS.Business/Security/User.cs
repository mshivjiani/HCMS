using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.Business.Security.Collections;
using System.Linq;
using System.Collections.Generic;

namespace HCMS.Business.Security
{
    /// <summary>
    /// User Business Object
    /// </summary>
    [Serializable]
    public class User : BusinessBase, ISiteUser
    {
        #region Private Members

        private int _userID = -1;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _middleName = string.Empty;
        private string _suffix = string.Empty;
        private string _emailAddress = string.Empty;
        private int _supervisorStatusID = -1;
        private string _FPPSPdID = string.Empty;
        private int _employeeCommonID = -1;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;
        private bool _enabled = false;
        private int _roleID = -1;
        private string _roleName = string.Empty;
        private int _regionID = -1;
        private string _regionName = string.Empty;
        private string _employingOfficeLocation = String.Empty;

        #endregion

        #region Properties

        public int UserID
        {
            get
            {
                return this._userID;
            }
            set
            {
                this._userID = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                this._firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this._lastName;
            }
            set
            {
                this._lastName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this._middleName;
            }
            set
            {
                this._middleName = value;
            }
        }

        public string Suffix
        {
            get
            {
                return this._suffix;
            }
            set
            {
                this._suffix = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return this._emailAddress;
            }
            set
            {
                this._emailAddress = value;
            }
        }

        public int SupervisorStatusID
        {
            get
            {
                return this._supervisorStatusID;
            }
            set
            {
                this._supervisorStatusID = value;
            }
        }

        public string FPPSPdID
        {
            get
            {
                return this._FPPSPdID;
            }
            set
            {
                this._FPPSPdID = value;
            }
        }

        public int EmployeeCommonID
        {
            get
            {
                return this._employeeCommonID;
            }
            set
            {
                this._employeeCommonID = value;
            }
        }

        public int CreatedByID
        {
            get
            {
                return this._createdByID;
            }
            set
            {
                this._createdByID = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return this._createDate;
            }
        }

        public int UpdatedByID
        {
            get
            {
                return this._updatedByID;
            }
            set
            {
                this._updatedByID = value;
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                return this._updateDate;
            }
        }

        public bool Enabled
        {
            get
            {
                return this._enabled;
            }
            set
            {
                this._enabled = value;
            }
        }

        public int RoleID
        {
            get
            {
                return this._roleID;
            }
        }

        public string RoleName
        {
            get
            {
                return this._roleName;
            }
        }

        public int RegionID
        {
            get
            {
                return this._regionID;
            }
            set
            {
                this._regionID = value;
            }
        }

        public string RegionName
        {
            get
            {
                return this._regionName;
            }
        }

        public string EmployingOfficeLocation
        {
            get
            {
                return this._employingOfficeLocation;
            }
        }

        // Calculated Fields

        public string MappedUserName
        {
            get
            {
                return this._emailAddress;
            }
        }

        public string FullName
        {
            get
            {
                string fullName = string.Format("{0} {1}", this._firstName.Trim(), this._lastName.Trim());
                return fullName.Length == 0 ? "(Name Not Available)" : fullName;
            }
        }

        public string FullNameEmail
        {
            get
            {
                string fullnameemail = string.Format("{0} | {1}", this.FullName, this.EmailAddress.Trim());
                return fullnameemail;
            }
        }

        public string FullNameReverse
        {
            get
            {
                const string splitCharacter = ", ";
                string firstName = this._firstName.Trim();
                string lastName = this._lastName.Trim();
                string fullName = string.Empty;

                if (lastName.Length > 0 && firstName.Length > 0)
                    fullName = string.Concat(lastName, splitCharacter, firstName);
                else if (lastName.Length > 0)
                    fullName = lastName;
                else if (firstName.Length > 0)
                    fullName = firstName;
                else
                    fullName = "(Name Not Available)";

                return fullName;
            }
        }

        public string AdminEnabledImageUrl
        {
            get
            {
                if (Enabled)
                    return "~/App_Themes/PDExpress/images/icons/icon_checkmark.gif";
                else
                    return "~/App_Themes/PDExpress/images/icons/flag_red.gif";
            }
        }

        public string AdminEnabledAlternateText
        {
            get
            {
                if (Enabled)
                    return "This user account is active.";
                else
                    return "This user account is inactive.";
            }
        }
        #endregion

        #region Constructors

        public User()
        {
            // Empty Constructor
        }

        public User(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public User(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetUserByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public User(string UserName)
        {
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetUserByUserName", UserName);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        #endregion

        #region Constructor Helper Methods

        private void loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];
                this.FillObjectFromRowData(returnRow);
            }
        }

        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            if (returnRow["UserID"] != DBNull.Value)
                this._userID = (int)returnRow["UserID"];

            if (returnRow["FirstName"] != DBNull.Value)
                this._firstName = returnRow["FirstName"].ToString();

            if (returnRow["LastName"] != DBNull.Value)
                this._lastName = returnRow["LastName"].ToString();

            if (returnRow["MiddleName"] != DBNull.Value)
                this._middleName = returnRow["MiddleName"].ToString();

            if (returnRow["Suffix"] != DBNull.Value)
                this._suffix = returnRow["Suffix"].ToString();

            if (returnRow["EmailAddress"] != DBNull.Value)
                this._emailAddress = returnRow["EmailAddress"].ToString();

            if (returnRow["SupervisorStatusID"] != DBNull.Value)
                this._supervisorStatusID = (int)returnRow["SupervisorStatusID"];

            if (returnRow["FPPSPdID"] != DBNull.Value)
                this._FPPSPdID = returnRow["FPPSPdID"].ToString();

            if (returnRow["EmployeeCommonID"] != DBNull.Value)
                this._employeeCommonID = (int)returnRow["EmployeeCommonID"];

            if (returnRow["CreatedByID"] != DBNull.Value)
                this._createdByID = (int)returnRow["CreatedByID"];

            if (returnRow["CreateDate"] != DBNull.Value)
                this._createDate = (DateTime)returnRow["CreateDate"];

            if (returnRow["UpdatedByID"] != DBNull.Value)
                this._updatedByID = (int)returnRow["UpdatedByID"];

            if (returnRow["UpdateDate"] != DBNull.Value)
                this._updateDate = (DateTime)returnRow["UpdateDate"];

            if (returnRow["Enabled"] != DBNull.Value)
                this._enabled = (bool)returnRow["Enabled"];

            if (returnRow["RoleID"] != DBNull.Value)
                this._roleID = (int)returnRow["RoleID"];

            if (returnRow["RoleName"] != DBNull.Value)
                this._roleName = returnRow["RoleName"].ToString();

            if (returnRow["RegionID"] != DBNull.Value)
                this._regionID = (int)returnRow["RegionID"];

            if (returnRow["RegionName"] != DBNull.Value)
                this._regionName = returnRow["RegionName"].ToString();

            if (returnRow["EmployingOfficeLocation"] != DBNull.Value)
                this._employingOfficeLocation = returnRow["EmployingOfficeLocation"].ToString();
        }

        #endregion

        #region ToString Method

        ///<summary>
        /// Returns a String that represents the current object.
        ///</summary>
        public override string ToString()
        {

            return this._userID.ToString();
        }

        #endregion ToString Method

        #region CompareMethods

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current object.</param>
        /// <returns>Returns true if the specified System.Object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {

            User Userobj = obj as User;

            return (Userobj == null) ? false : (this._userID == Userobj.UserID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this._userID.GetHashCode();
        }

        #endregion

        #region General Methods

        public void Add()
        {
            this.Add(-1);
        }

        /// <summary>
        /// Add new user (and role) to database.
        /// Since the role ID is not technically a part of the User table
        /// We create a read-only Role ID property and create a roleID parameter
        /// for this method
        /// </summary>
        public void Add(int newRoleID)
        {
            TransactionManager tranManager = null;

            try
            {
                // Add user to database
                tranManager = new TransactionManager(CurrentDatabase);
                tranManager.BeginTransaction();

                DbCommand commandWrapper = CurrentDatabase.GetStoredProcCommand("spr_AddUser");
                SqlParameter returnParam = new SqlParameter("@newUserID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new UserID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@firstName", this._firstName.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@lastName", this._lastName.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@middleName", this._middleName));
                commandWrapper.Parameters.Add(new SqlParameter("@suffix", this._suffix));
                commandWrapper.Parameters.Add(new SqlParameter("@emailAddress", this._emailAddress));

                if (this._supervisorStatusID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorStatusID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorStatusID", this._supervisorStatusID));

                commandWrapper.Parameters.Add(new SqlParameter("@FPPSPdID", this.FPPSPdID));

                if (this._employeeCommonID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@employeeCommonID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@employeeCommonID", this._employeeCommonID));

                commandWrapper.Parameters.Add(new SqlParameter("@regionID", this._regionID));
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
                commandWrapper.Parameters.Add(new SqlParameter("@enabled", this._enabled));

                ExecuteNonQuery(tranManager, commandWrapper);
                this._userID = (int)returnParam.Value;

                if (newRoleID != -1)
                {
                    // Note: The database supports multiple roles, but 
                    // PD Express is coded to only support one role per user
                    this.DeleteAllRoles(tranManager);

                    // add new role
                    this.AddRole(tranManager, newRoleID);
                    this._roleID = newRoleID;
                }

                tranManager.Commit();
            }
            catch (Exception ex)
            {
                if (tranManager != null)
                    tranManager.Rollback();

                HandleException(ex);
            }
        }

     
        public void Update(int updateRoleID)
        {
            if (base.ValidateKeyField(this._userID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateUser");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@userID", this._userID));
                    commandWrapper.Parameters.Add(new SqlParameter("@roleID", updateRoleID));

                    if (this._regionID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@regionID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@regionID", this._regionID));

                    commandWrapper.Parameters.Add(new SqlParameter("@enabled", this._enabled));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));


                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        private void AddRole(TransactionManager tranManager, int newRoleID)
        {
            if (base.ValidateKeyField(this._userID))
                ExecuteNonQuery(tranManager, "spr_AddRoleToUser", this._userID, newRoleID, this._createdByID);
        }

        private void DeleteRole(TransactionManager tranManager, int removeRoleID)
        {
            if (base.ValidateKeyField(this._userID))
                ExecuteNonQuery(tranManager, "spr_DeleteRoleFromUser", this._userID, removeRoleID);
        }

        private void DeleteAllRoles(TransactionManager tranManager)
        {
            if (base.ValidateKeyField(this._userID))
                ExecuteNonQuery(tranManager, "spr_DeleteAllRolesFromUser", this._userID);
        }

        public void AddOrganizationCode(int organizationCodeID, int orgCodeCreatedByID)
        {
            if (base.ValidateKeyField(this._userID))
                ExecuteNonQuery("spr_AddOrganizationCodeToUser", this._userID, organizationCodeID, orgCodeCreatedByID);
        }

        public void AddOrganizationCodeAndChildren(int organizationCodeID, int orgCodeCreatedByID)
        {
            if (base.ValidateKeyField(this._userID))
                ExecuteNonQuery("spr_AddOrganizationCodeAndChildrenToUser", this._userID, organizationCodeID, orgCodeCreatedByID);
        }

        public void DeleteOrganizationCode(int organizationCodeID)
        {
            if (base.ValidateKeyField(this._userID))
                ExecuteNonQuery("spr_DeleteOrganizationCodeFromUser", this._userID, organizationCodeID);
        }

        public bool IsPDCreatorSupervisor(long positionDescriptionID)
        {
            bool isSupervisor = false;

            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    PositionDescription thisPD = new PositionDescription();

                    thisPD.PositionDescriptionID = positionDescriptionID;
                    UserCollection supervisors = thisPD.GetAssignedSupervisors();
                    isSupervisor = supervisors.Contains(this._userID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return isSupervisor;
        }

        public bool IsOrganizationCodeSupervisor(int OrganizationCodeID)
        {
            bool isOrgcodesupervisor = false;
            try
            {
                isOrgcodesupervisor = (bool)BusinessBase.ExecuteScalar("spr_IsOrgCodeSupervisor", this._userID, OrganizationCodeID);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return isOrgcodesupervisor;
        }

        public bool CanViewReportsWithPhoneNumber()
        {
            bool canView = false;
            try
            {
                canView = (bool)BusinessBase.ExecuteScalar("spr_CanUserViewReportsWithPhoneNumber", this._userID);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return canView;
        }

        public bool IsSystemAdministrator
        {
            get
            {
                return HasPermission(enumPermission.AllSystemAdministrationPermissions);
            }
        }
        #endregion

        #region Collection Helper Methods

        internal static UserCollection GetCollection(DataTable dataItems)
        {
            UserCollection listCollection = new UserCollection();
            User current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new User(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a UserCollection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        public bool HasPermission(enumPermission permissionEnumID)
        {
            bool permissionOK = false;

            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    PermissionCollection permissions = this.GetPermissions();
                    permissionOK = permissions.Contains((int)permissionEnumID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return permissionOK;
        }

        public PermissionCollection GetPermissions()
        {
            PermissionCollection childDataCollection = null;

            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetPermissionsByUserID", this._userID);

                    // fill collection list
                    childDataCollection = Permission.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public RoleCollection GetRoles()
        {
            RoleCollection childDataCollection = null;

            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetUserRoleByUserID", this._userID);

                    // fill collection list
                    childDataCollection = Role.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public PositionDescriptionCollection GetAllPositionDescriptions()
        {
            PositionDescriptionCollection childDataCollection = null;

            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetAllPositionDescriptionsByUserID", this._userID);

                    // fill collection list
                    childDataCollection = PositionDescription.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public PositionDescriptionCollection GetNonPublishedPositionDescriptions()
        {
            PositionDescriptionCollection childDataCollection = null;
            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetNonPublishedPositionDescriptionsByUserID", this._userID);

                    // fill collection list
                    childDataCollection = PositionDescription.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public OrganizationCodeCollection GetAssignedOrganizationCodes()
        {
            OrganizationCodeCollection childDataCollection = null;

            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetOrganizationCodeByUserID", this._userID);

                    // fill collection list
                    childDataCollection = OrganizationCode.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public OrganizationCodeCollection GetAvailableOrganizationCodesByChartType(enumOrgChartType selectedChartType, OrgCodeFormatTypes selectedSortType)
        {
            OrganizationCodeCollection childDataCollection = null;

            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    DbCommand commandWrapper = GetDbCommand("spr_GetAvailableOrganizationCodesByChartType");

                    commandWrapper.Parameters.Add(new SqlParameter("@UserID", this._userID));

                    if (selectedChartType == enumOrgChartType.Undefined)
                        commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@OrganizationChartTypeID", (int)selectedChartType));

                    if (selectedSortType == OrgCodeFormatTypes.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgCodeFormatTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@OrgCodeFormatTypeID", (int)selectedSortType));

                    // fill collection list
                    childDataCollection = OrganizationCode.GetCollection(ExecuteDataTable(commandWrapper));
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }


        public OrganizationCodeCollection GetAssignedActiveOrganizationCodes()
        {
            OrganizationCodeCollection childDataCollection = null;

            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetActiveOrganizationCodeByUserID", this._userID);

                    // fill collection list
                    childDataCollection = OrganizationCode.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }
        public OrganizationCodeCollection GetUnassignedOrganizationCodes(int searchUserIDFilter)
        {
            OrganizationCodeCollection childDataCollection = null;

            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    DataTable dt = null;

                    if (searchUserIDFilter == -1)
                        dt = ExecuteDataTable("spr_GetUnassignedOrganizationCodesByUserID", this._userID, DBNull.Value);
                    else
                        dt = ExecuteDataTable("spr_GetUnassignedOrganizationCodesByUserID", this._userID, searchUserIDFilter);

                    // fill collection list
                    childDataCollection = OrganizationCode.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public OrganizationCodeCollection GetUnassignedOrganizationCodesByRegion(int regionID)
        {
            OrganizationCodeCollection childDataCollection = null;

            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetUnassignedOrganizationCodesByUserIDAndRegionID", this._userID, regionID);

                    // fill collection list
                    childDataCollection = OrganizationCode.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }
        /// <summary>
        /// This function returns distinct list of regions that user should have access
        /// based on user's assigned organizaiton codes
        /// </summary>
        /// <returns></returns>
        public List<Region> GetListOfAssignedRegions()
        {
            List<Region> regions = new List<Region>();          
           
            if (base.ValidateKeyField(this._userID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetUserRegions", this._userID);

                    // fill collection list
                    regions = Region.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
           
            return regions;
        }
     
        #endregion
    }
}

