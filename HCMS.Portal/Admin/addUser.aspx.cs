using System;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Telerik.Web.UI;

using PD = HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Security;
using HCMS.WebFramework.Security.Collections;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.Portal.Admin
{
    public partial class addUser : AdminPageBase
    {
        const string comboUserTopLine = "[<<- Select User to Add to PD Express ->>]";
        const string comboRoleTopLine = "[<<- Select Role for the User ->>]";
        const string comboRegionTopLine = "[<<- Select Region for the User ->>]";

        #region [ Private Predicates ]
        private bool filterSysAdminItem(RadComboBoxItem listItem)
        {
            return listItem.Value == ((int)enumRole.SystemAdministrator).ToString();
        }
        #endregion


        #region Properties

        private ActiveDirectoryUserCollection ResultsList
        {
            get
            {
                return (ActiveDirectoryUserCollection)ViewState["ADUserCollection"];
            }
            set
            {
                ViewState["ADUserCollection"] = value;
            }
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(PageLoad);
            this.customValSearchFields.ServerValidate += new ServerValidateEventHandler(customValSearchFields_ServerValidate);
            this.buttonSearch.Click += new EventHandler(buttonSearch_Click);
            this.buttonAddUser.Click += new EventHandler(buttonAddUser_Click);
            this.buttonReset.Click += new EventHandler(buttonReset_Click);
            //this.buttonCancel.Click += new EventHandler(buttonCancel_Click);
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
                    base.SelectLeftMenuItem = enumLeftMenuItem.AddUser;
                    base.SelectTopMenuItem = enumTopMenuItem.UserAdmin;
                    base.PageTitle = "User Administration";

                    if (base.IsAdministrator)
                        loadPage();
                    else
                        // If the user only has DelegatePD permission -- they CANNOT add a new account
                        base.GoToAccessDeniedPage();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void loadPage()
        {
            setNewSearch();

            // bind roles
            if (base.IsSystemAdministrator)
            {
                ControlUtility.BindRadComboBoxControl(this.radComboRoles, LookupWrapper.GetAllRoles(true), null, "RoleName", "RoleID", comboRoleTopLine);
            }
            else
            {
                ControlUtility.BindRadComboBoxControl(this.radComboRoles, LookupWrapper.GetAllRoles(true), new ControlUtility.RadComboBoxItemFilter(filterSysAdminItem), "RoleName", "RoleID", comboRoleTopLine);
            }

            // bind regions
            ControlUtility.BindRadComboBoxControl(this.radComboRegions, LookupWrapper.GetAllRegions(true), null, "RegionName", "RegionID", comboRegionTopLine);

            // according to my research, initialvalue for radcombo goes against the text and not the value
            requiredUsers.InitialValue = comboUserTopLine;
            requiredRoles.InitialValue = comboRoleTopLine;
            requiredRegion.InitialValue = comboRegionTopLine;

            // set region name of current user
            literalRegionName.Text = base.CurrentUser.RegionName;

            // if sysAdmin, show drop down, otherwise -- show literal
            bool isSysAdmin = base.IsSystemAdministrator;
            this.radComboRegions.Visible = isSysAdmin;
            literalRegionName.Visible = !isSysAdmin;
        }

        private void customValSearchFields_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            // return true if at least one field contains data
            e.IsValid = !(textboxLastName.Text.Trim().Length.Equals(0) &&
                textboxFirstName.Text.Trim().Length.Equals(0) &&
                textboxEmail.Text.Trim().Length.Equals(0));
        }

        private void setNewSearch()
        {
            // New Search -- hide panels
            panelAdd.Visible = false;
            panelCount.Visible = false;
            buttonReset.Visible = false;
            panelSystemMessage.Visible = false;
            //added this to clear the combobox with previous user's name that was added
            this.radComboUsers.ClearSelection();
            this.radComboUsers.Text = string.Empty;

            this.radComboRoles.ClearSelection();
            this.radComboRoles.Text = string.Empty;

            this.radComboRegions.ClearSelection();
            this.radComboRegions.Text = string.Empty;

        }

        /// <summary>
        /// ActionType 1 for Search, 2 for Add
        /// </summary>
        /// <param name="ActionType"></param>
        private void bindUsers(int ActionType)
        {
            if (this.ResultsList != null && this.ResultsList.Count > 0)
            {
                this.ResultsList.Sort();
                panelAdd.Visible = true;
                buttonReset.Visible = true;
                ControlUtility.BindRadComboBoxControl(this.radComboUsers, this.ResultsList, null, "DetailLine", "SAMAccountName", comboUserTopLine);
            }
            else
            {
                switch (ActionType)
                {
                    case 1: //search
                        showCountMessage("There are no user accounts within Active Directory that match your search criteria.");
                        break;
                    case 2: //add
                        showCountMessage("New User " + ADUser.SN + ", " + ADUser.GivenName + " has been added into the system. Access the user to add role and region to the new account.");
                        break;
                    default:
                        showCountMessage("There are no user accounts within Active Directory for this action.");
                        break;
                }
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    setNewSearch();

                    LDAPSearcher searcher = new LDAPSearcher();
                    this.ResultsList = searcher.Search(textboxLastName.Text, textboxFirstName.Text, textboxEmail.Text);
                    bindUsers(1);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.GoToAdminPage();
        }

        private void showCountMessage(string message)
        {
            literalCount.Text = message;
            panelCount.Visible = true;
        }

        private void showMessage(string systemMessage)
        {
            literalSystem.Text = systemMessage;
            panelSystemMessage.Visible = true;
        }

        ActiveDirectoryUser ADUser;
        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    PD.User newUser = new PD.User();
                    ADUser = this.ResultsList.Find(this.radComboUsers.SelectedValue);

                    if (ADUser != null)
                    {
                        int newRoleID = int.Parse(this.radComboRoles.SelectedValue);

                        // if system admin, pull region ID from drop down -- otherwise use the current user's region
                        int newRegionID = base.IsSystemAdministrator ? int.Parse(this.radComboRegions.SelectedValue) : base.CurrentUser.RegionID;

                        newUser.FirstName = ADUser.GivenName;
                        newUser.LastName = ADUser.SN;
                        newUser.EmailAddress = ADUser.UserPrincipalName;
                        newUser.SupervisorStatusID = (int)enumSupervisorStatus.AllOtherPositions;
                        newUser.RegionID = newRegionID;
                        newUser.CreatedByID = int.Parse(Context.User.Identity.Name);
                        newUser.Enabled = true;

                        // add new user
                        try
                        {
                            newUser.Add(newRoleID);
                            showMessage(string.Format("The user account for {0} has been successfully added into HCMS.", ADUser.SAMAccountName));

                            if (this.ResultsList.Count >= 2)
                                // remove newly added item from drop down
                                this.ResultsList.Remove(ADUser);
                            else
                            {
                                this.ResultsList = null;
                                panelAdd.Visible = false;
                            }

                            // re-bind dropdown list
                            bindUsers(2);

                            // set role to default
                            this.radComboRoles.SelectedIndex = 0;
                            this.radComboRegions.SelectedIndex = 0;
                        }
                        catch (Exception ex)
                        {
                            showMessage(ex.Message);
                        }
                    }
                    else
                        // should, theoretically, never get here
                        showMessage("The user account could not be added because of an internal error.");
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {           
            try
            {
                base.SafeRedirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

    }
}
