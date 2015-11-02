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

namespace HCMS.Portal.Controls.Admin
{
    public partial class ctlDashboardRoleSearch : DashboardRoleUserControlBase 
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

                    DashboardGrid.Visible = false;
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
            //this.buttonShowAdvanced.Click += new EventHandler(buttonShowAdvanced_Click);
            this.buttonSearch.Click += new EventHandler(buttonSearch_Click);
            this.btnSearchUser.Click += new EventHandler(btnSearchUserh_Click);
            
            this.btnClearSearch.Click += new EventHandler(btnClearSearch_Click);
            this.rcbRegion.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbRegion_SelectedIndexChanged);
            this.rcbOrganization.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbOrganization_SelectedIndexChanged);
            this.rcbOrganization.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rdUsers_SelectedIndexChanged);
            this.btnClearUserSearch.Click += new EventHandler(btnClearUserSearch_Click);
            this.rcbUserSearch.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbUserSearch_SelectedIndexChanged);

            
            base.OnInit(e);
        }
        private void GetUsers()
        {
            SecurityManager manager = new SecurityManager();

            userListEnabled = new UserCollection();

            userList = manager.GetAllUsersSearch(txtFirstName.Text.Trim(), txtLastName.Text.Trim());


            foreach (HCMS.Business.Security.User u in userList)
            {
                if (u.Enabled) userListEnabled.Add(u);
            }
        }

        private void btnSearchUserh_Click(object sender, EventArgs e)
        {

            rcbUserSearch.DataSource = null;
            rcbUserSearch.DataBind();

            GetUsers();

            rcbUserSearch.DataSource = userListEnabled;
            rcbUserSearch.DataTextField = "FullNameEmail";// +", " + "FirstName";
            rcbUserSearch.DataValueField = "UserID";
            rcbUserSearch.DataBind();


            rcbUserSearch.Items.Insert(0, new RadComboBoxItem("<<--Select User-->>", "-1"));

            rcbUserSearch.SelectedValue = "-1";

            tblResults.Visible = false;
            rcbUserSearch.Visible = true;           
        }

        void btnClearUserSearch_Click(object sender, EventArgs e)
        {
            tblResults.Visible = false;
            DashboardGrid.Visible = false;

            txtLastName.Text = "";
            txtFirstName.Text = "";

            rcbUserSearch.Items.Clear();
            rcbUserSearch.Text = "";
            tblResults.Visible = false;

        }
        void rcbUserSearch_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int iUserID = Convert.ToInt32(rcbUserSearch.SelectedValue);
            GetRolesForUsers(iUserID);

        }

        private void GetRolesForUsers(int iUserID)
        {
            //Repopulate the roles for this user.
            DashboardRoleManager dm = new DashboardRoleManager();
            DashboardGrid.DataSource = null;
            DashboardGrid.DataSource = dm.GetRoleForUser(-1, -1, -1, iUserID);
            DashboardGrid.DataBind();

            tblResults.Visible = true;

            DashboardGrid.Visible = true;
        }

        private void InitControls()
        {

            GetAllRegion();

            GetOrganization(Convert.ToInt32(rcbRegion.SelectedValue));

            GetUsersForRegionOrganization(Convert.ToInt32(rcbRegion.SelectedValue), Convert.ToInt32(rcbOrganization.SelectedValue));
            GetRoleTypes();

            if (rblSearchByRegion.Checked)
            {
                tblSearchByRegion.Visible = true;
                tblSearchByUser.Visible = false;
            }
            if (rblSearchByUser.Checked)
            {
                tblSearchByRegion.Visible = false;
                tblSearchByUser.Visible = true;
            }
            tblResults.Visible = false;
        }

        protected void DashboardGrid_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            int RegionID = Convert.ToInt32(rcbRegion.SelectedValue);
            int OrgCodeID = Convert.ToInt32(rcbOrganization.SelectedValue);
            int RoleTypeID = Convert.ToInt32(rcbRoleType.SelectedValue);
            int UserID = Convert.ToInt32(rdUsers.SelectedValue);


            DashboardRoleManager dm = new DashboardRoleManager();
            List<HCMS.Business.Admin.Workforce.DashboardRole> dr = dm.GetRoleSearchResult(RegionID, OrgCodeID, RoleTypeID, UserID);
            DashboardGrid.DataSource = dr;

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

                DashboardGrid.DataSource = null;

                if (rblSearchByRegion.Checked)
                    PerformSearch();

                if (rblSearchByUser.Checked)
                    GetRolesForUsers(Convert.ToInt32(rcbUserSearch.SelectedValue));
                }
        }      

       
       

        private void GetAllDashboardRole()
        {
            DashboardRoleManager dm = new DashboardRoleManager();
            List<HCMS.Business.Admin.Workforce.DashboardRole> dr = dm.GetAllDashboardRole();

            DashboardGrid.DataSource = dr;
        }
        private void GetAllRegion()
        {
            // regions
            ControlUtility.BindRadComboBoxControl(this.rcbRegion, LookupWrapper.GetAllRegions(false), null, "RegionName", "RegionID", "<<--Select Region-->>");

        }

        private void GetOrganization(int RegionID)
        {
            // Get all organization codes in the given region order by Level ID
            OrganizationCodeCollection orgCodes = LookupWrapper.GetOrganizationCodesByRegionLevel(true, RegionID, 0, true);

            ControlUtility.BindRadComboBoxControl(this.rcbOrganization, orgCodes, null, "DetailLineLegacyWithLevel", "OrganizationCodeID", "<<--Select Organization-->>");
         
        }
        private void GetUsersForRegionOrganization(int RegionID, int OrgID)
        {
            SecurityManager manager = new SecurityManager();

            userListEnabled = new UserCollection();

            userList = manager.GetUsersForRegionOrganization(RegionID, OrgID);

            rdUsers.Items.Clear();

            foreach (HCMS.Business.Security.User u in userList)
            {
                if (u.Enabled) userListEnabled.Add(u);
            }

            rdUsers.DataSource = userListEnabled;
            rdUsers.DataTextField = "FullName";
            rdUsers.DataValueField = "UserID";
            rdUsers.DataBind();

            rdUsers.Items.Insert(0, new RadComboBoxItem("<<--Select User-->>", "-1"));

            rdUsers.SelectedValue = "-1";

        }
        private void GetRolesOfUser(int UID)
        {

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

        private void GetAllUsers()
        {
            SecurityManager manager = new SecurityManager();

            userListEnabled = new UserCollection();

            userList = manager.GetAllUsersSearch("", "");

            rdUsers.Items.Clear();

            foreach(HCMS.Business.Security.User u in userList)
            {
                if (u.Enabled) userListEnabled.Add(u);
            }

            rdUsers.DataSource = userListEnabled;
            rdUsers.DataTextField = "FullNameEmail";
            rdUsers.DataValueField = "UserID";
            rdUsers.DataBind();

            rdUsers.Items.Insert(0, new RadComboBoxItem("<<--Select User-->>", "-1"));

            rdUsers.SelectedValue = "-1";
        }

        protected void rcbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetOrganization(Convert.ToInt32(rcbRegion.SelectedValue));
            //GetUsersForRegionOrganization(Convert.ToInt32(rcbRegion.SelectedValue), Convert.ToInt32(rcbOrganization.SelectedValue));
            //////////
            OrganizationCodeCollection orgCodeColl;
            rcbOrganization.Items.Clear();

            int RegionID = -1;

            RegionID = Convert.ToInt32(rcbRegion.SelectedValue);

            orgCodeColl = LookupManager.GetOrganizationCodesByRegion(RegionID);

            switch (rdOrgCode.SelectedValue)
            {
                case "n":

                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        rcbOrganization.Items.Add(item);
                    }
                    break;
                case "o":
                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OldOrganizationCode + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        rcbOrganization.Items.Add(item);
                    }
                    break;
                default:
                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        rcbOrganization.Items.Add(item);
                    }
                    break;
            }

            rcbOrganization.Items.Insert(0, new RadComboBoxItem("<<- Select Organization Code ->>", "-1"));

        }

        protected void rcbOrganization_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetUsersForRegionOrganization(Convert.ToInt32(rcbRegion.SelectedValue),Convert.ToInt32(rcbOrganization.SelectedValue));
        }

        protected void rdUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRolesOfUser(Convert.ToInt32(rcbOrganization.SelectedValue));
        }
        
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            int RegionID = Convert.ToInt32(rcbRegion.SelectedValue);
            int OrgCodeID = Convert.ToInt32(rcbOrganization.SelectedValue);
            int RoleTypeID = Convert.ToInt32(rcbRoleType.SelectedValue);
            int UserID = Convert.ToInt32(rdUsers.SelectedValue);


            DashboardRoleManager dm = new DashboardRoleManager();
            List<HCMS.Business.Admin.Workforce.DashboardRole> dr = dm.GetRoleSearchResult(RegionID, OrgCodeID, RoleTypeID, UserID);

            DashboardGrid.DataSource = dr;
            DashboardGrid.Rebind();

            tblResults.Visible = true;
            DashboardGrid.Visible = true;
        }
        private void btnClearSearch_Click(object sender, EventArgs e)
        {

            GetAllRegion();

            GetOrganization(Convert.ToInt32(rcbRegion.SelectedValue));

            GetUsersForRegionOrganization(Convert.ToInt32(rcbRegion.SelectedValue), Convert.ToInt32(rcbOrganization.SelectedValue));
            GetRoleTypes();

            tblResults.Visible = false;
            DashboardGrid.Visible = false;
        }
        protected void By_Region(object sender, EventArgs e)
        {
            this.tblSearchByRegion.Visible = true;
            this.tblSearchByUser.Visible = false;

            this.DashboardGrid.Visible = false;
        }
        protected void By_User(object sender, EventArgs e)
        {
            this.tblSearchByRegion.Visible = false;
            this.tblSearchByUser.Visible = true;

            this.DashboardGrid.Visible = false;

            rcbUserSearch.Items.Clear();
            txtFirstName.Text = "";
            txtLastName.Text = "";
        }

        protected void rdOrgCode_Changed(object sender, EventArgs e)
        {

            OrganizationCodeCollection orgCodeColl;
            rcbOrganization.Items.Clear();

            int RegionID = -1;

            RegionID = Convert.ToInt32(rcbRegion.SelectedValue);

            orgCodeColl = LookupManager.GetOrganizationCodesByRegion(RegionID);

            rcbOrganization.Items.Clear();

            switch (rdOrgCode.SelectedValue)
            {
                case "n":

                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        rcbOrganization.Items.Add(item);
                    }
                    break;
                case "o":
                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OldOrganizationCode + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        rcbOrganization.Items.Add(item);
                    }
                    break;
                default:
                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        rcbOrganization.Items.Add(item);
                    }
                    break;
            }

            rcbOrganization.Items.Insert(0, new RadComboBoxItem("<<- Select Organization Code ->>", "-1"));
        }

       
    }
}

