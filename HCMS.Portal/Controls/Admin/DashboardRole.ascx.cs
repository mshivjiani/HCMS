using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HCMS.Business.Lookups;
using System.Data;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.Business.Admin.Workforce;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.SSAS;
using System.Configuration;
using BusinessDashboardRole = HCMS.Business.Admin.Workforce.DashboardRole;
namespace HCMS.Portal.Controls
{
    public partial class DashboardRole : DashboardRoleUserControlBase 
    {

        UserCollection userListEnabled;
        UserCollection userList = null;

        protected override void OnLoad(EventArgs e)
        {


            try
            {
                if (!Page.IsPostBack)
                {
                    InitControls();
                }

                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.buttonSearch.Click += new EventHandler(buttonSearch_Click);
            this.btnClear.Click += new EventHandler(btnClear_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);

            this.rdUsers.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rdUsers_SelectedIndexChanged);
            this.rcbRegion.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbRegion_SelectedIndexChanged);
            this.rcbOrganization.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbOrganization_SelectedIndexChanged);
            this.rcbRoleType.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbRoleType_SelectedIndexChanged);

            base.OnInit(e);
        }



        private void InitControls()
        {
            GetAllUsers();

            GetAllRegion();

            GetOrganization(Convert.ToInt32(rcbRegion.SelectedValue));

            GetRoleTypes();

            txtRoleLabel.Text = string.Empty;
        }

        private void RePopulateControls(int DashboardRoleID)
        {
            rcbRoleType.Enabled = true;
            txtRoleLabel.Enabled = true;
            rcbRegion.Enabled = true;
            rcbOrganization.Enabled = true;
            btnSave.Enabled = true;
            lblSave.Visible = false;
            if (rdUsers.SelectedIndex > 0)
            {
                int iUserID = Convert.ToInt32(rdUsers.SelectedValue);
                DashboardRoleManager DRoleManager = new DashboardRoleManager();
                //Getting role(s) for the user
                List<BusinessDashboardRole> lsDashRole = DRoleManager.GetRoleForUser(-1, -1, -1, iUserID);


                if (lsDashRole.Count > 0)//if user is already assigned a role
                {

                    //once user is assigned a role, it should not be assigned different type of role
                    rcbRoleType.Enabled = false;


                    BusinessDashboardRole dashboardrole = new BusinessDashboardRole();
                    if (DashboardRoleID > 0)
                    {
                        dashboardrole = lsDashRole.Find(delegate(BusinessDashboardRole current) { return current.DashboardRoleID == DashboardRoleID; });

                    }
                    else
                    {
                        dashboardrole = lsDashRole[0];
                    }
                    enumDashboardRoleType droletype = dashboardrole.eDashboardRoleType;
                    rcbRoleType.SelectedValue = dashboardrole.DashboardRoleTypeID.ToString();
                    this.txtRoleLabel.Text = dashboardrole.DashboardRoleLabel;
                    rcbRegion.SelectedValue = dashboardrole.RegionID.ToString();

                    //if user is assigned service wide role -- don't allow them to create any other role
                    if (DRoleManager.IsServiceWideRole(droletype))
                    {

                        rcbRegion.Enabled = false;
                        txtRoleLabel.Enabled = false;
                        rcbOrganization.Enabled = false;
                        btnSave.Enabled = false;

                    }
                    //if user is assigned region wide role then allow them to create another region wide role only and therefor allow to select different region
                    else if (DRoleManager.IsRegionWideRole(droletype))
                    {
                        rcbRegion.Enabled = true;
                        txtRoleLabel.Enabled = true;
                    }
                    //if  user is assigned Program/Division level role then allow them to create same role type in the same region. 
                    else
                    {
                        rcbRegion.Enabled = false;
                        txtRoleLabel.Enabled = true;
                    }
                    PopulateOrgList(dashboardrole.OrganizationCodeID);
                    btnSave.Enabled = false;
                    PopulateRoleGrid();
                }
                else //if user is not assigned any role
                {
                    GetRoleTypes();
                    txtRoleLabel.Text = string.Empty;
                    GetAllRegion();
                    //Get user's regions
                    DataTable dt = DRoleManager.GetRegionForUser(iUserID);
                    if (dt.Rows.Count > 0)
                    {
                        rcbRegion.SelectedValue = dt.Rows[0]["RegionID"].ToString();
                    }
                    PopulateOrgList(-1);
                    PopulateRoleGrid();
                }
            }

            else //if user is not selected
            {
                InitControls();
            }
        }

        protected void rdUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            RePopulateControls(-1);

        }
        private void PopulateRoleGrid()
        {
            DashboardRoleManager dm = new DashboardRoleManager();
            int regionid = Convert.ToInt32(rcbRegion.SelectedValue);
            int userid = Convert.ToInt32(rdUsers.SelectedValue);
            int roletypeid = Convert.ToInt32(rcbRoleType.SelectedValue);
            DashboardGrid.Visible = false;
            if (rcbOrganization.SelectedIndex > 0)
            {
                int organizationcodeid = Convert.ToInt32(rcbOrganization.SelectedValue);
                DashboardGrid.DataSource = null;
                DashboardGrid.DataSource = dm.GetRoleForUser(regionid, organizationcodeid, roletypeid, userid);
                DashboardGrid.DataBind();
                DashboardGrid.Visible = true;
            }
        }
        private void PopulateSameProgramOrg(int CurrentOrgCodeID, bool selectCurrent)
        {

            //As per the new rules, this function will find the reporting org code of the current org.
            //and will show all children orgcodes of the reporting org except the current org


            OrganizationCode roleOrgcode = new OrganizationCode(CurrentOrgCodeID);
            //removing condition to check if level >2 because Division level orgcode could be directly under regional orgcode (it can be Level 1)-- eg. Diversity org code

            //removing getting children org codes, always populating the children of reporting org codes
            //OrganizationCodeCollection childrenorgs = roleOrgcode.GetChildrenOrganizations();

            //but keeping in mind the hierarchy hole risk associated with populating reporting orgcode's children.
            //The risk can be explained with following scenario.
            //First time user was given access to Level 2 orgcode(A100) of program A.
            //second time system tries  find reporting org(Program A) of Level 2 org code (A100).
            //System gets all children and greatgrand children of Program A at different levels.

            //this includes other Level 2 orgcodes as well(A200,A300).
            //now if the admin tries to assign the role to a Level 3 Orgcode(A201) under A200 then it causes hole in hierarchy because the user does not have access to A200.
            //Admin should only be assigning role at Level 2 orgcodes A200/A300 etc.
            if (roleOrgcode.ReportingOrganizationCode > 0)
            {
                OrganizationCode rptOrg = new OrganizationCode(roleOrgcode.ReportingOrganizationCode);
                OrganizationCodeCollection Reportingchildrenorgs = rptOrg.GetChildrenOrganizationsSortedByLevel();
                if (!selectCurrent)
                {
                    Reportingchildrenorgs.Remove(roleOrgcode); //remove already assigned org code
                }

                if (rdOrgCode.SelectedValue == "n")
                {
                    ControlUtility.BindRadComboBoxControl(this.rcbOrganization, Reportingchildrenorgs, null, "NewOrgCodeLineWithLevel", "OrganizationCodeID", "<<--Select Organization-->>");
                }
                else
                {
                    ControlUtility.BindRadComboBoxControl(this.rcbOrganization, Reportingchildrenorgs, null,"DetailLineLegacyWithLevel",  "OrganizationCodeID", "<<--Select Organization-->>");
                }
                if (selectCurrent)
                {
                    ControlUtility.SafeListControlSelect(rcbOrganization, CurrentOrgCodeID);
                }
            }




        }
        private void PopulateOrgList(int selectOrgCodeID)
        {
            int userid = Convert.ToInt32(rdUsers.SelectedValue);
            int roletypeid = Convert.ToInt32(rcbRoleType.SelectedValue);
            enumDashboardRoleType eroletype = (enumDashboardRoleType)roletypeid;
            DashboardRoleManager dm = new DashboardRoleManager();
            bool isDivisionLevelRole = false;
            if (rcbRegion.SelectedIndex >= 0)
            {
                int regionid = -1;

                 regionid = Convert.ToInt32(rcbRegion.SelectedValue);
                
               
                if (dm.IsServiceWideRole(eroletype))
                {
                    GetOrganizationByRegionLevel(9, 0, false);
                }
                else if (dm.IsRegionWideRole(eroletype))
                {
                    GetOrganizationByRegionLevel(regionid, 0, false);
                }
                //1.	For role types – Assistant Regional Director, Assistant Director, Deputy Assistant Director, 
                //Division Chief, Project leader , system will display all Level 1 and beyond org code for the selected region.
                else if (dm.IsProgramWideRole(eroletype))
                {
                    GetOrganizationByRegionLevel(regionid, 1, true);
                }
                else
                {
                    isDivisionLevelRole = true;
                    GetOrganizationByRegionLevel(regionid, 1, true);
                }

                if (selectOrgCodeID > 0)
                {

                    if (isDivisionLevelRole)
                    {
                        PopulateSameProgramOrg(selectOrgCodeID, true);

                    }
                    else
                    {
                        ControlUtility.SafeListControlSelect(rcbOrganization, selectOrgCodeID);
                    }
                }
                else
                {
                    //Dashboard Admin-Remove Org Codes from the drop down once it has been assigned to a user 
                    //Getting role(s) for the user
                    List<BusinessDashboardRole> lsDashRole = dm.GetRoleForUser(-1, -1, -1, userid);
                    if (lsDashRole.Count > 0)
                    {
                        foreach (BusinessDashboardRole dashboardrole in lsDashRole)
                        {
                            RadComboBoxItem item = rcbOrganization.Items.FindItemByValue(dashboardrole.OrganizationCodeID.ToString());
                            if (item != null)
                            {
                                rcbOrganization.Items.Remove(item);
                            }
                        }

                        //JAX ID:1052:Since the system is limiting to pick org codes from one same program for Division Chief, 
                        //the system needs to limit Admins from picking org codes from a different program. 
                        if (isDivisionLevelRole)
                        {
                            BusinessDashboardRole dashboardrole = lsDashRole[0];
                            PopulateSameProgramOrg(dashboardrole.OrganizationCodeID, false);

                        }
                    }

                    if (rcbOrganization.Items.Count == 1)
                    {
                        if (rcbOrganization.Items[0].Value == "-1")
                        {
                            rcbOrganization.Items[0].Text = "<<--There are no more organization codes to be assigned.-->>";
                        }

                    }

                }
            }
            else
            {
               
                rcbOrganization.Items.Clear();
            }


        }
        protected void rcbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateOrgList(-1);
            PopulateRoleGrid();
        }

        protected void rdOrgCode_Changed(object sender, EventArgs e)
        {
            rcbOrganization.Items.Clear();
            PopulateOrgList(-1);
        }

        protected void rcbOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            PopulateRoleGrid();
        }

        protected void rcbRoleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this event will only occur till user is not assigned any dashboard role.
            //once the user is assigned a role, changing the roletype will not be possible.
            txtRoleLabel.Text = rcbRoleType.Text;
            if (rcbRoleType.SelectedIndex > 0)
            {
                int roletypeid = Convert.ToInt32(rcbRoleType.SelectedValue);
                enumDashboardRoleType eroletype = (enumDashboardRoleType)roletypeid;
                DashboardRoleManager dm = new DashboardRoleManager();
                if (dm.IsServiceWideRole(eroletype))
                {
                    rcbRegion.Items.Clear();
                    rcbRegion.Items.Add (new RadComboBoxItem("HQ", "9"));
                    GetOrganizationByRegionLevel(9, 0, false);
                }
                else if (eroletype == enumDashboardRoleType.AssistantDirector || eroletype == enumDashboardRoleType.DeputyAssistantDirector)
                {
                    rcbRegion.Items.Clear();
                    rcbRegion.Items.Add(new RadComboBoxItem("HQ", "9"));
                    GetOrganizationByRegionLevel(9, 1, true);
                }
                else
                {
                    GetAllRegion();
                    PopulateOrgList(-1);

                }

                PopulateRoleGrid();

            }


        }

        private void GetAllUsers()
        {
            SecurityManager manager = new SecurityManager();

            userListEnabled = new UserCollection();

            userList = manager.GetAllUsersSearch("", "");

            foreach (User u in userList)
            {
                if (u.Enabled) userListEnabled.Add(u);
            }

            rdUsers.Items.Clear();

            rdUsers.DataSource = userListEnabled;
            rdUsers.DataTextField = "FullNameEmail";
            rdUsers.DataValueField = "UserID";
            rdUsers.DataBind();

            rdUsers.Items.Insert(0, new RadComboBoxItem("<<--Select User-->>", "-1"));

            rdUsers.SelectedValue = "-1";

        }

        private void GetAllRegion()
        {
            // regions
            rcbRegion.Enabled = true;
            rcbRegion.Items.Clear();
            ControlUtility.BindRadComboBoxControl(this.rcbRegion, LookupWrapper.GetAllRegions(false), null, "RegionName", "RegionID", "<<--Select Region-->>");

        }
        private void GetOrganization(int RegionID)
        {
            // Organization
            rcbOrganization.Items.Clear();
            OrganizationCodeCollection orgCodes = LookupWrapper.GetOrganizationCodesByRegion(false, RegionID);
            //orgCodes.OrderBy(i => i.LevelID);

            ControlUtility.BindRadComboBoxControl(this.rcbOrganization, orgCodes, null, "DetailLineLegacyWithLevel", "OrganizationCodeID", "<<--Select Organization-->>");

        }

        private void GetOrganizationByRegionLevel(int RegionID, int LevelID, bool LevelPlus)
        {
            // Organization
           rcbOrganization.Items.Clear();

            OrganizationCodeCollection orgCodes = LookupWrapper.GetOrganizationCodesByRegionLevel(true, RegionID, LevelID, LevelPlus);

            if (rdOrgCode.SelectedValue == "n")
            {
                ControlUtility.BindRadComboBoxControl(this.rcbOrganization, orgCodes, null, "NewOrgCodeLineWithLevel", "OrganizationCodeID", "<<--Select Organization-->>");
            }
            else
            {
                ControlUtility.BindRadComboBoxControl(this.rcbOrganization, orgCodes, null, "DetailLineLegacyWithLevel", "OrganizationCodeID", "<<--Select Organization-->>");
            }

           

        }
        private void GetRoleTypes()
        {
            DashboardRoleTypeManager DRoleManagerType = new DashboardRoleTypeManager();
            List<DashboardRoleType> ls = DRoleManagerType.GetAllDashboardRoleType();

            rcbRoleType.DataSource = ls;
            rcbRoleType.DataTextField = "DashboardRoleType1";
            rcbRoleType.DataValueField = "DashboardRoleTypeID";
            rcbRoleType.DataBind();

            rcbRoleType.Items.Insert(0, new RadComboBoxItem("<<--Select Role Type-->>", "-1"));

            rcbRoleType.SelectedValue = "-1";
        }      

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            ResetAll();

            PerformSearch();

            int iUserID = Convert.ToInt32(rdUsers.SelectedValue);

            if (iUserID > 0)
            {
                DashboardRoleManager DRoleManager = new DashboardRoleManager();
                DataTable dt = DRoleManager.GetRegionForUser(iUserID);

                if (dt.Rows.Count > 0)
                {
                    rcbRegion.SelectedValue = dt.Rows[0]["RegionID"].ToString();
                }


                if (dt.Rows.Count == 1)
                {

                    //Repopulate the roles for this user.
                    DashboardRoleManager dm = new DashboardRoleManager();
                    DashboardGrid.DataSource = null;
                    DashboardGrid.DataSource = dm.GetRoleForUser(Convert.ToInt32(rcbRegion.SelectedValue), Convert.ToInt32(rcbOrganization.SelectedValue), Convert.ToInt32(rcbRoleType.SelectedValue), Convert.ToInt32(rdUsers.SelectedValue));
                    DashboardGrid.DataBind();
                    DashboardGrid.Visible = true;
                }
                else
                    DashboardGrid.Visible = false;

            }

            GetOrganization(Convert.ToInt32(rcbRegion.SelectedValue));


            lblSearch.Visible = true;

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";

            GetAllUsers();
            rdUsers.SelectedValue = "-1";

            GetAllRegion();

            GetOrganization(Convert.ToInt32(rcbRegion.SelectedValue));

            GetRoleTypes();


            txtRoleLabel.Text = "";

            DashboardGrid.Visible = false;

        }

        private void ResetAll()
        {
            GetAllUsers();

            GetAllRegion();

            GetOrganization(Convert.ToInt32(rcbRegion.SelectedValue));

            GetRoleTypes();


            txtRoleLabel.Text = "";

            DashboardGrid.Visible = false;


        }
        private void PerformSearch()
        {
            try
            {
                if (Page.IsValid)
                {
                    rdUsers.DataSource = null;
                    rdUsers.DataBind();

                    GetUsers();

                    rdUsers.DataSource = userListEnabled;
                    rdUsers.DataTextField = "FullNameEmail";// +", " + "FirstName";
                    rdUsers.DataValueField = "UserID";
                    rdUsers.DataBind();


                    rdUsers.Items.Insert(0, new RadComboBoxItem("<<--Select User-->>", "-1"));

                    rdUsers.SelectedValue = "-1";

                    GetAllRegion();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }


        private void GetUsers()
        {
            SecurityManager manager = new SecurityManager();

            userListEnabled = new UserCollection();

            userList = manager.GetAllUsersSearch(txtFirstName.Text.Trim(), txtLastName.Text.Trim());


            foreach (User u in userList)
            {
                if (u.Enabled) userListEnabled.Add(u);
            }
        }

        protected void DashboardGrid_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int DashboardRoleID = (int)item.GetDataKeyValue("DashboardRoleID"); 
                int userID = Convert.ToInt32(item["UserID"].Text);
                int regionID = Convert.ToInt32(item["RegionID"].Text);
                string orgcode = item["OrganizationCode"].Text;
                enumDashboardRoleType eroletype = (enumDashboardRoleType)Convert.ToInt32(item["DashboardRoleTypeID"].Text);
                             

                DeleteDashboardRole(userID, eroletype, regionID, DashboardRoleID, orgcode);
                PopulateRoleGrid();
                

            }
        }
        private void BindData()
        {
            DashboardRoleManager dm = new DashboardRoleManager();
            List<HCMS.Business.Admin.Workforce.DashboardRole> dr = dm.GetAllDashboardRole();
            DashboardGrid.DataSource = dr;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            int iUserID = Convert.ToInt32(rdUsers.SelectedValue);
            int iRegionID = Convert.ToInt32(rcbRegion.SelectedValue);
            HCMS.Business.Admin.Workforce.DashboardRole dr = new Business.Admin.Workforce.DashboardRole();
            int OrganizationCodeID = Convert.ToInt32(rcbOrganization.SelectedValue);
            dr.OrganizationCodeID = OrganizationCodeID;
            dr.DashboardRoleTypeID = Convert.ToInt32(rcbRoleType.SelectedValue);
            dr.UserID = iUserID;
            dr.DashboardRoleLabel = txtRoleLabel.Text;

            User user = new User(iUserID);
            OrganizationCode org = new OrganizationCode(OrganizationCodeID);
            string costcentercode = org.OrganizationCodeValue;

            enumDashboardRoleType eroletype = (enumDashboardRoleType)dr.DashboardRoleTypeID;

            if (iRegionID == -1 || dr.OrganizationCodeID == -1 || dr.DashboardRoleTypeID == -1 || txtRoleLabel.Text.Trim().Length == 0)
            {
                return;
            }

            int DashID = -1;

            DashboardRoleManager dm = new DashboardRoleManager();
            List<Business.Admin.Workforce.DashboardRole> roles = dm.GetRolesForUser(iUserID);

            try
            {

                AnalyisServicesRoleManager ssasrolemgr = GetSSASRoleManager();
                if (roles.Count == 0)
                {
                    // User with no roles

                    string ssasrolename = GetSSASRoleNameForUser(user, eroletype, iRegionID, costcentercode);
                    ssasrolemgr.CreateUserRole(ssasrolename, user.EmailAddress, costcentercode, eroletype);
                }
                else
                {
                    if (roles.Count == 1)
                    {
                        foreach (Business.Admin.Workforce.DashboardRole role in roles)
                        {
                            enumDashboardRoleType currentroletype = role.eDashboardRoleType;
                            string currentrolename = GetSSASRoleNameForUser(user, currentroletype, role.RegionID, role.OrganizationCode);
                            ssasrolemgr.RemoveUserRoleOrgCodeAccess(currentrolename, user.EmailAddress, role.OrganizationCode);

                        }
                    }
                    List<string> orgs = new List<string>();
                    foreach (Business.Admin.Workforce.DashboardRole role in roles)
                    {
                        orgs.Add(role.OrganizationCode);
                    }
                    orgs.Add(costcentercode);
                    // User with exisiting role
                    string ssasrolename = "User_" + user.EmailAddress.Substring(0, user.EmailAddress.IndexOf('@'));
                    ssasrolemgr.AddUpdateMultipleRole(ssasrolename, user.EmailAddress, orgs);                   
                }
                DashID = dm.AddDashboardRole(dr);

                if (DashID > 0)
                {
                    DashboardGrid.Visible = true;
                    RePopulateControls(DashID);
                    lblSave.Visible = true;

                }
                else
                {
                    lblSave.Text = "Error Creating Role";
                    lblSave.Visible = true;
                }
            }
            catch (Exception ex)
            {
                if (DashID > 0)
                {
                    dm.Delete(DashID);
                }
                base.PrintErrorMessage(ex, true);
            }

          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        /// <summary>
        /// re-creates all SSAS roles based on HCMS roles
        /// make sure to drop all roles from ssas manually before calling this.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        protected void btnRecreateAllSSASRoles_Click(object sender, EventArgs e)
        {

            DashboardRoleManager dm = new DashboardRoleManager();
            AnalyisServicesRoleManager ssasrolemgr = GetSSASRoleManager();
            ssasrolemgr.DeleteAllRoles();

            try
            {
                List<User> users = dm.GetAllDashboardUsers();

                foreach (User u in users)
                {
                    List<Business.Admin.Workforce.DashboardRole> roles = dm.GetRolesForUser(u.UserID);

                    try
                    {
                        if (roles.Count == 1)
                        {
                            // User with no roles

                            string ssasrolename = GetSSASRoleNameForUser(u, roles[0].eDashboardRoleType, roles[0].RegionID, roles[0].OrganizationCode);
                            ssasrolemgr.CreateUserRole(ssasrolename, u.EmailAddress, roles[0].OrganizationCode, roles[0].eDashboardRoleType);
                        }
                        else
                        {

                            List<string> orgs = new List<string>();
                            foreach (Business.Admin.Workforce.DashboardRole role in roles)
                            {
                                orgs.Add(role.OrganizationCode);
                            }

                            // User with exisiting role
                            string ssasrolename = "User_" + u.EmailAddress.Substring(0, u.EmailAddress.IndexOf('@'));
                            ssasrolemgr.AddUpdateMultipleRole(ssasrolename, u.EmailAddress, orgs);
                        }

                        base.PrintMessage("All SSAS roles recreated.", true, false);
                    }
                    catch (Exception ex)
                    {
                        base.PrintErrorMessage(ex, true);
                    }


                }
                /*
                List<BusinessDashboardRole> hcmsroles = dm.GetAllDashboardRole();
               
                if ((hcmsroles.Count > 0)   && (ssasrolemgr != null))
                
                {

                    foreach (BusinessDashboardRole role in hcmsroles )
                    {
                        int iUserID = role.UserID;
                        enumDashboardRoleType eroletype = role.eDashboardRoleType;
                        int iRegionID = role.RegionID;
                        string costcentercode = role.OrganizationCode;
                        User user = new User(iUserID);
                        string ssasrolename = GetSSASRoleNameForUser(user, eroletype, iRegionID, costcentercode);

                        
                        if (dm.IsServiceWideRole(eroletype))
                        {
                            ssasrolemgr.CreateRoleWithServicewideAccess(ssasrolename, user.EmailAddress);
                        }
                        else
                        {
                            ssasrolemgr.CreateUserRole(ssasrolename, user.EmailAddress, costcentercode, eroletype);
                        }
                   // System.Diagnostics.Debug.Print (string.Format("{0}-{1}-{2}-{3}", role.Region,ssasrolename,role.UserName ,role.OrganizationCode));
                    }
                }*/
            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex, true);
            }
        }


        protected void btnDeleteAllSSASRoles_Click(object sender, EventArgs e)
        {

            try
            {
                DashboardRoleManager dm = new DashboardRoleManager();
                AnalyisServicesRoleManager ssasrolemgr = GetSSASRoleManager();
                ssasrolemgr.DeleteAllRoles();
                base.PrintMessage("All SSAS Roles Deleted Successfully", true, false);
            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex, true);
            }


        }
    }
}