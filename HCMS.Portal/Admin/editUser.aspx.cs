using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using Telerik.Web.UI;
using HCMS.Business.JNP;

namespace HCMS.Portal.Admin
{
    public partial class editUser : AdminPageBase 
    {
        const string comboRoleTopLine = "[<<- Select Role for the User ->>]";
        const string comboRegionTopLine = "[<<- Select Region for the User ->>]";
        const string comboOrgCodeTopLine = "[<<- Select Organization Code ->>]";

        #region Properties

        private bool RoleVisible
        {
            get
            {
                if (ViewState["RoleVisible"] == null)
                    ViewState["RoleVisible"] = true;

                return (bool)ViewState["RoleVisible"];
            }
            set
            {
                ViewState["RoleVisible"] = value;
            }
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            this.RequireUserID = true;
            this.Load += new EventHandler(PageLoad);
            this.buttonAssignOrgCode.Click += new EventHandler(buttonAssignOrgCode_Click);
           
            this.buttonSave.Click += new EventHandler(buttonSave_Click);
            this.buttonDelegatePD.Click += new EventHandler(buttonDelegatePD_Click);
            this.buttonDelegateJNP.Click += new EventHandler(buttonDelegateJNP_Click);
            this.buttonDelegateOrgChart.Click += new EventHandler(buttonDelegateOrgChart_Click);
            this.radComboRegions2.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(radComboRegions2_SelectedIndexChanged);
            this.gridViewOrgCodes.RowDeleting += new GridViewDeleteEventHandler(gridViewOrgCodes_RowDeleting);
            this.gridViewOrgCodes.PageIndexChanging += new GridViewPageEventHandler(gridViewOrgCodes_PageIndexChanging);
            base.OnInit(e);
        }

       
        private void PageLoad(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    base.TopMenu = enumTopMenuType.AdminMenu;
                    base.LeftMenu = LeftMenuType.UserAdminMenu;
                    loadPage();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void bindRoles()
        {
            try
            {
                RoleCollection rolesList = LookupWrapper.GetAllRoles(true);

                // if the user does not system admin permission -- remove "System Admin" and "Regional Admin" roles
                if (!base.IsSystemAdministrator)
                {
                    PermissionCollection permissions = base.CurrentEditUser.GetPermissions();

                    // Check to see if the EditUser is a SysAdmin or CenterAdmin (Maintain User Accounts)
                    if (permissions.Contains(enumPermission.AllSystemAdministrationPermissions) ||
                      permissions.Contains(enumPermission.MaintainUserAccounts))
                    {
                        // show System Admin in literal and hide drop down
                        // You cannot change a system admin if you are not 
                        literalRoleName.Text = base.CurrentEditUser.RoleName;
                        this.radComboRoles.Visible = false;
                        this.RoleVisible = false;
                    }
                    else
                    {
                        // remove system admin and regional admin and show role drop down
                        rolesList.Remove(rolesList.Find((int)enumRole.SystemAdministrator));
                        rolesList.Remove(rolesList.Find((int)enumRole.CenterAdministrator));
                    }
                }

                ControlUtility.BindRadComboBoxControl(this.radComboRoles, rolesList, null, "RoleName", "RoleID", comboRoleTopLine);

                // check whether the current user is the logged in user -- and if so, lock down role
                if (base.CurrentUser.UserID == base.CurrentEditUser.UserID)
                {
                    this.radComboRoles.Enabled = false;
                    literalRole.Text = string.Format("<br />You cannot modify the role of your own account.");
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void bindOrganizationCodes()
        {
            bool isSysAdmin = base.IsSystemAdministrator;
            bool isRegionalAdministrator = base.IsAdministrator;
            int filterRegionID = isSysAdmin ? int.Parse(this.radComboRegions2.SelectedValue) : base.CurrentUser.RegionID;
            OrganizationCodeCollection totalOrgCodes = LookupWrapper.GetOrganizationCodesByRegion(false, filterRegionID);
            OrganizationCodeCollection orgCodes = null;

            radComboOrgCodes.Items.Clear();

            if (isSysAdmin)
            {
                if (this.radComboRegions2.SelectedIndex == -1 || this.radComboRegions2.SelectedValue == "-1")
                {
                    this.radComboOrgCodes.Items.Clear();
                    this.radComboOrgCodes.Items.Add(new RadComboBoxItem("[-- Select the Region to View the Organization Codes --]", "-1"));
                    buttonAssignOrgCode.Enabled = false;
                }
                else
                {
                    orgCodes = base.CurrentEditUser.GetUnassignedOrganizationCodesByRegion(int.Parse(this.radComboRegions2.SelectedValue));

                    if (orgCodes.Count == 0)
                    {
                        string dropdownMessage = totalOrgCodes.Count > 0 ? string.Format("[**You have no unassigned Organization Codes in Region {0}. **]", filterRegionID) : string.Format("[** There are no Organization Codes associated with Region {0}. **]", filterRegionID);
                        this.radComboOrgCodes.Items.Clear();
                        this.radComboOrgCodes.Items.Add(new RadComboBoxItem(dropdownMessage, "-1"));
                        buttonAssignOrgCode.Enabled = false;
                    }
                    else
                    {
                        //ControlUtility.BindRadComboBoxControl(this.radComboOrgCodes, orgCodes, null, "DetailLineLegacy", "OrganizationCodeID", comboOrgCodeTopLine);
                        foreach (HCMS.Business.Lookups.OrganizationCode orgCode in orgCodes)
                        {
                            RadComboBoxItem item = new RadComboBoxItem(rdOrgCode.SelectedValue == "n" ? orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName : orgCode.OldOrganizationCode + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                            radComboOrgCodes.Items.Add(item);
                        }

                        radComboOrgCodes.Items.Insert(0, new RadComboBoxItem("[<<- Select Organization Code ->>]", "-1"));

                        buttonAssignOrgCode.Enabled = true;
                    }
                }
            }
            else
            {
                //added this based on request that regional administrator should be able to access all the orgcodes
                //within region even if they are not assigned one
                if (isRegionalAdministrator)
                {
                    orgCodes = base.CurrentEditUser.GetUnassignedOrganizationCodesByRegion(base.CurrentUser.RegionID);
                }
                else
                {
                    // get the unassigned org codes of the edited user based on person currently logged on 
                    orgCodes = base.CurrentEditUser.GetUnassignedOrganizationCodes(base.CurrentUser.UserID);
                }

                if (orgCodes.Count == 0)
                {
                    string dropdownMessage = totalOrgCodes.Count > 0 ? "[**You have no unassigned Organization Codes. **]" : "[** There are no organization codes listed for your Region. **]";
                    this.radComboOrgCodes.Items.Clear();
                    this.radComboOrgCodes.Items.Add(new RadComboBoxItem(dropdownMessage, "-1"));
                    buttonAssignOrgCode.Enabled = false;
                }
                else
                {
                    ControlUtility.BindRadComboBoxControl(this.radComboOrgCodes, orgCodes, null, "DetailLineLegacy", "OrganizationCodeID", comboOrgCodeTopLine);
                    buttonAssignOrgCode.Enabled = base.HasPermission(enumPermission.MaintainUserAccounts);
                }
            }
        }

        protected void rdOrgCode_Changed(object sender, EventArgs e)
        {

            OrganizationCodeCollection orgCodeColl;
            radComboOrgCodes.Items.Clear();

            int RegionID = -1;

            RegionID = Convert.ToInt32(radComboRegions2.SelectedValue);

            orgCodeColl = base.CurrentEditUser.GetUnassignedOrganizationCodesByRegion(RegionID);

            radComboOrgCodes.Items.Clear();

            switch (rdOrgCode.SelectedValue)
            {
                case "n":

                    foreach (HCMS.Business.Lookups.OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        radComboOrgCodes.Items.Add(item);
                    }
                    break;
                case "o":
                    foreach (HCMS.Business.Lookups.OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OldOrganizationCode + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        radComboOrgCodes.Items.Add(item);
                    }
                    break;
                default:
                    foreach (HCMS.Business.Lookups.OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        radComboOrgCodes.Items.Add(item);
                    }
                    break;
            }

            radComboOrgCodes.Items.Insert(0, new RadComboBoxItem("[<<- Select Organization Code ->>]", "-1"));
        }

        private void loadPage()
        {
          
            base.PageTitle = string.Format("Edit User Details for {0}", base.CurrentEditUser.FullNameReverse);

                // bind roles
                bindRoles();

                // bind regions
                ControlUtility.BindRadComboBoxControl(this.radComboRegions, LookupWrapper.GetAllRegions(false), null, "RegionName", "RegionID", comboRegionTopLine);
                ControlUtility.BindRadComboBoxControl(this.radComboRegions2, LookupWrapper.GetAllRegions(false), null, "RegionName", "RegionID", comboRegionTopLine);

                literalLastName.Text = base.CurrentEditUser.LastName;
                literalFirstName.Text = base.CurrentEditUser.FirstName;
                literalEmail.Text = base.CurrentEditUser.EmailAddress;
                literalSupStatusID.Text = base.CurrentEditUser.SupervisorStatusID.ToString();

                string regionIDString = base.CurrentEditUser.RegionID.ToString();
                if (this.radComboRegions.Items.FindItemByValue(regionIDString) != null)
                    this.radComboRegions.SelectedValue = regionIDString;

                string roleIDstring = base.CurrentEditUser.RoleID.ToString();
                if (this.radComboRoles.Items.FindItemByValue(roleIDstring) != null)
                    this.radComboRoles.SelectedValue = roleIDstring;

                radioButtonListStatus.SelectedValue = base.CurrentEditUser.Enabled ? "1" : "0";

                // only allow the modification of the status if there are no Non-Published PD's
                PositionDescriptionCollection pdList = base.CurrentEditUser.GetNonPublishedPositionDescriptions();
                bool hasNonPublishedPDs = pdList.Count > 0;

                JNPManager jnpMgr =  new JNPManager();
                List<JNPSearchResult> jnpList = jnpMgr.GetNonPublishedJNPsByUserID(base.CurrentEditUser.UserID);
                bool hasNonPublishedJNPs = jnpList.Count > 0;

                bool editingMyAccount = (base.CurrentUser.UserID == base.CurrentEditUser.UserID);
                bool isSysAdmin = base.IsSystemAdministrator;
                radioButtonListStatus.Enabled = !hasNonPublishedPDs && !hasNonPublishedJNPs  && !editingMyAccount;

                if (hasNonPublishedPDs)
                    literalPDStatus.Text = string.Format("<br />You cannot modify the status of this account because the user is the owner of {0} non-published position description{1}.", pdList.Count, pdList.Count.Equals(1) ? string.Empty : "s");
           
                if (hasNonPublishedJNPs)
                    literalJNPStatus.Text = string.Format("<br />You cannot modify the status of this account because the user is the owner of {0} non-published job announcement {1}.", jnpList.Count, jnpList.Count.Equals(1) ? string.Empty : "s");
                
                if (editingMyAccount)
                    literalJNPStatus.Text = string.Format("<br />You cannot modify the status of your own account.");


                // according to my research, initialvalue for radcombo goes against the text and not the value
                requiredRole.InitialValue = comboRoleTopLine;
                requiredRegion.InitialValue = comboRegionTopLine;
                requiredOrgCodes.InitialValue = comboOrgCodeTopLine;

                // set region name of current user
                literalRegionName.Text = base.CurrentUser.RegionName;

                this.radComboRegions.Visible = isSysAdmin;
                literalRegionName.Visible = !isSysAdmin;

                // ORGANIZATION ASSIGNMENT SECTION
                rowRegion2.Visible = isSysAdmin;

                // bind organization codes
                bindOrganizationCodes();

                // get the assigned organization codes
                bindGridData();
                gridViewOrgCodes.Columns[0].Visible = !editingMyAccount;

                if (base.HasPermission(enumPermission.MaintainUserAccounts) &&
                    (this.RoleVisible || (!hasNonPublishedPDs && !editingMyAccount)))
                    buttonSave.Enabled = true;

          
        }

      

        private void radComboRegions2_SelectedIndexChanged(object source, EventArgs e)
        {
            bindOrganizationCodes();
        }

        private void bindGridData()
        {
            panelSystem.Visible = false;
            gridViewOrgCodes.DataSource = base.CurrentEditUser.GetAssignedOrganizationCodes();
            gridViewOrgCodes.DataBind();
        }

        private void showMessage(string message)
        {
            literalSystem.Text = message;
            panelSystem.Visible = true;
        }
        private void clearHideMessage()
        {
            literalSystem.Text = string.Empty;
            panelSystem.Visible = false;
        }
        private void buttonAssignOrgCode_Click(object source, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    if (this.ChkAssignChildren.Checked)
                    {
                        base.CurrentEditUser.AddOrganizationCodeAndChildren(int.Parse(this.radComboOrgCodes.SelectedValue), base.CurrentUser.UserID);
                    }
                    else
                    {
                        base.CurrentEditUser.AddOrganizationCode(int.Parse(this.radComboOrgCodes.SelectedValue), base.CurrentUser.UserID);
                    }
                    bindOrganizationCodes();
                    bindGridData();
                    showMessage("Organization Code(s) assigned successfully!");
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonSave_Click(object source, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    clearHideMessage();

                    User current = new User();

                    current.UserID = base.CurrentEditUser.UserID;
                    current.RegionID = base.IsSystemAdministrator ? int.Parse(this.radComboRegions.SelectedValue) : base.CurrentUser.RegionID;

                    current.Enabled = Convert.ToBoolean(int.Parse(radioButtonListStatus.SelectedValue));
                    current.UpdatedByID = base.CurrentUser.UserID;
                    current.Update(int.Parse(this.radComboRoles.SelectedValue));

                    bindOrganizationCodes();
                    bindGridData();
                    showMessage("You have successfully saved this record.");

                }
            }
            catch (Exception ex)
            {
                showMessage(ex.Message);
            }
        }

        private void gridViewOrgCodes_RowDeleting(object source, GridViewDeleteEventArgs e)
        {
            try
            {
                base.CurrentEditUser.DeleteOrganizationCode((int)gridViewOrgCodes.DataKeys[e.RowIndex].Value);
                bindGridData();
                bindOrganizationCodes();
            }
            catch (Exception ex)
            {
                showMessage(ex.Message);
            }
        }

        private void gridViewOrgCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridViewOrgCodes.PageIndex = e.NewPageIndex;
                bindGridData();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

       

        private void buttonDelegatePD_Click(object source, EventArgs e)
        {
            base.SafeRedirect(string.Format("~/Admin/delegatePD.aspx?userID={0}", base.CurrentEditUser.UserID));
        }

        private void buttonDelegateJNP_Click(object source, EventArgs e)
        {
            base.SafeRedirect(string.Format("~/Admin/DelegateJNP.aspx?userID={0}", base.CurrentEditUser.UserID));
        }
       private void buttonDelegateOrgChart_Click(object sender, EventArgs e)
        {
            base.SafeRedirect(string.Format("~/Admin/DelegateOrgChart.aspx?userID={0}", base.CurrentEditUser.UserID));
        }
        #endregion
    }
}
