using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.Business.Lookups.Collections;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Security;
using HCMS.WebFramework.Security.Collections;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

using Telerik.Web.UI;
using System.Data;

namespace HCMS.Portal.Admin
{
    public partial class _default :AdminPageBase 
    {
        const string comboRegionTopLine = "[<<- Select Region to Filter Organization Codes ->>]";
        const string comboOrgCodeTopLine = "[<<- Select Organization Code ->>]";
        const string userListSessionKey = "UserAdministrationPageBase_default_userList";

        #region Properties

        private bool ShowAdvanced
        {
            get
            {
                if (ViewState["ShowAdvanced"] == null)
                    ViewState["ShowAdvanced"] = false;

                return (bool)ViewState["ShowAdvanced"];
            }
            set
            {
                ViewState["ShowAdvanced"] = value;
            }
        }

        private bool IsSearch
        {
            get
            {
                if (ViewState["IsSearch"] == null)
                    ViewState["IsSearch"] = false;

                return (bool)ViewState["IsSearch"];
            }
            set
            {
                ViewState["IsSearch"] = value;
            }
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(PageLoad);
            this.buttonSearch.Click += new EventHandler(buttonSearch_Click);
            this.buttonSearch2.Click += new EventHandler(buttonSearch2_Click);
            this.buttonViewAll.Click += new EventHandler(buttonViewAll_Click);
            //this.buttonAddUser.Click += new EventHandler(buttonAddUser_Click);
            this.buttonShowAdvanced.Click += new EventHandler(buttonShowAdvanced_Click);
            //this.buttonActivateDeactivate.Click += new EventHandler(buttonActivateDeactivate_Click);
            //this.btnOrgCodeAdmin.Click += new EventHandler(btnOrgCodeAdmin_Click);



            //this.gridViewUsers.RowDataBound += new GridViewRowEventHandler(gridViewUsers_RowDataBound);
            //this.gridViewUsers.PageIndexChanging += new GridViewPageEventHandler(gridViewUsers_PageIndexChanging);


            this.radComboRegions.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(radComboRegions_SelectedIndexChanged);
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
                    base.SelectLeftMenuItem = enumLeftMenuItem.SearchUser;
                    base.SelectTopMenuItem = enumTopMenuItem.UserAdmin;
                    base.PageTitle = "User Administration";
                    
                    base.CurrentEditUser = null;
                    loadPage();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void bindDDLOrgCode(int filterRegionID)
        {
            OrganizationCodeCollection orgCodes = LookupWrapper.GetOrganizationCodesByRegion(false, filterRegionID);
            buttonSearch.Enabled = orgCodes.Count > 0;
            this.radComboOrgCodes.Text = string.Empty;
            if (orgCodes.Count > 0)
            {
                // bind org list based on current user's region ID
                //Issue #: 118
                //Author: Deepali Anuje
                //Date: 02/06/2013
                //Description: User Admin org code search shows only new FBMS org, not old org - should show both 
                ControlUtility.BindRadComboBoxControl(this.radComboOrgCodes, orgCodes, null, "DetailLineLegacy", "OrganizationCodeID", comboOrgCodeTopLine);
            }
            else
            {
                this.radComboOrgCodes.Items.Clear();
                this.radComboOrgCodes.Items.Add(new RadComboBoxItem(string.Format("[** There are no organization codes that are associated with Region {0}. **]", filterRegionID), "-1"));
            }
        }

        private void bindOrganizationCodes()
        {
            int filterRegionID = base.CurrentUser.RegionID;

            if (base.IsSystemAdministrator)
            {
                if (this.radComboRegions.SelectedIndex == -1 || this.radComboRegions.SelectedValue == "-1")
                {
                    this.radComboOrgCodes.Items.Clear();
                    this.radComboOrgCodes.Items.Add(new RadComboBoxItem("[-- Select Region to Filter --]", "-1"));
                    buttonSearch.Enabled = false;
                }
                else
                {
                    filterRegionID = int.Parse(this.radComboRegions.SelectedValue);
                    bindDDLOrgCode(filterRegionID);
                }
            }
            else
            {
                // bind org list based on current user's region ID
                bindDDLOrgCode(filterRegionID);
            }
        }

        private void loadPage()
        {
            setNewSearch();

            // bind organization codes
            bindOrganizationCodes();

            // bind regions
            ControlUtility.BindRadComboBoxControl(this.radComboRegions, LookupWrapper.GetAllRegions(false), null, "RegionName", "RegionID", comboRegionTopLine);

            // according to my research, initialvalue for radcombo goes against the text and not the value
            requiredRegion.InitialValue = comboRegionTopLine;

            // set region name of current user
            literalRegionName.Text = base.CurrentUser.RegionName;

            // if sysAdmin, show drop down, otherwise -- show literal
            bool isSysAdmin = base.IsSystemAdministrator;
            this.radComboRegions.Visible = isSysAdmin;
            literalRegionName.Visible = !isSysAdmin;

            // if user has SysAdmin or User Account Permission -- show Add New
            // if user only has delegatePD -- hide the "Add New" section
            //panelAddNew.Visible = base.HasPermission(enumPermission.MaintainUserAccounts);
            //divActivateDeactivate.Visible = base.HasPermission(enumPermission.ActivateDeactivatePD);
        }

        private void setNewSearch()
        {
            panelMoreFields.Visible = false;
            panelSystemMessage.Visible = false;
            panelData.Visible = false;
            buttonSearch.Visible = true;
        }

        private void showMessage(string systemMessage)
        {
            literalSystem.Text = systemMessage;
            panelSystemMessage.Visible = true;
        }

        private void bindUsers()
        {
            SecurityManager manager = new SecurityManager();
            UserCollection userList = null;
            int filterRegionID = base.IsSystemAdministrator ? int.Parse(this.radComboRegions.SelectedValue) : base.CurrentUser.RegionID;

            if (this.IsSearch)
                if (this.radComboOrgCodes.SelectedValue == "")
                { userList = manager.GetAllUsers(filterRegionID); }
                else
                {
                    userList = manager.GetAllUsersByOrganizationCodeSearch(filterRegionID, int.Parse(this.radComboOrgCodes.SelectedValue), textboxFirstName.Text, textboxLastName.Text);
                }
            else
                userList = manager.GetAllUsers(filterRegionID);

            bool isValid = (userList != null) && (userList.Count > 0);
            panelData.Visible = isValid;

            if (isValid)
            {
                Session[userListSessionKey] = null;
                Session[userListSessionKey] = userList;

                rgUsers.Rebind();
            }
            else
            {
                if (this.IsSearch)
                    //Issue #: 117
                    //Author: Deepali Anuje
                    //Date: 02/13/2013
                    //Description: Admin - Modify message when user search returns no results 
                    showMessage("There are no user accounts that match your search criteria.");
                else
                    // should, theoretically, never get here
                    showMessage("There are no user accounts currently in PD Express.");
            }
        }

        private void performSearch()
        {
            try
            {
                if (Page.IsValid)
                {
                    panelData.Visible = false;
                    panelSystemMessage.Visible = false;

                    this.IsSearch = true;
                    bindUsers();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            performSearch();
        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            performSearch();
        }

        private void buttonViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                panelSystemMessage.Visible = false;
                this.IsSearch = false;
                bindUsers();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void showMoreFields(bool showFields)
        {
            panelMoreFields.Visible = showFields;
            buttonSearch.Visible = !showFields;

            if (showFields)
                buttonShowAdvanced.Text = "Cancel Advanced Search Features";
            else
                // no need to explicitly show button search 2 -- 
                // it is displayed when the panel is displayed
                buttonShowAdvanced.Text = "Advanced Search Features";

            // toggle view
            this.ShowAdvanced = !this.ShowAdvanced;
        }

        private void radComboRegions_SelectedIndexChanged(object source, EventArgs e)
        {
            try
            {
                bindOrganizationCodes();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonShowAdvanced_Click(object sender, EventArgs e)
        {
            try
            {
                showMoreFields(!this.ShowAdvanced);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

       
        protected void rgUsers_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (Session[userListSessionKey] != null)
            {
                UserCollection userList = Session[userListSessionKey] as UserCollection;
                rgUsers.DataSource = userList;
            }
        }

        protected void rgUsers_ItemDataBound(object sender, GridItemEventArgs e)
        {
            GridItem gridItem = e.Item;
            

            if (gridItem.ItemType == GridItemType.Item || gridItem.ItemType == GridItemType.AlternatingItem)
            {
                User currentUser = gridItem.DataItem as User;
                if(gridItem is GridDataItem )
                {
                    GridDataItem gditem = gridItem as GridDataItem;


                    System.Web.UI.WebControls.Image img = (System.Web.UI.WebControls.Image)gditem["Active"].Controls[0];
                    if (currentUser.Enabled)
                    {
                        img.ImageUrl = string.Format("~/App_Themes/{0}/images/icons/icon_checkmark.gif", Page.Theme);
                        img.AlternateText = "This user account is active.";
                    }
                    else
                    {
                        img.ImageUrl = string.Format("~/App_Themes/{0}/images/icons/flag_red.gif", Page.Theme);
                        img.AlternateText ="This user account is inactive.";
                    }
                }
                HyperLink linkDelegatePD = gridItem.FindControl("linkDelegatePD") as HyperLink;
                HyperLink linkDelegateJNP = gridItem.FindControl("linkDelegateJNP") as HyperLink;
                HyperLink linkEditUser = gridItem.FindControl("linkEditUser") as HyperLink;
                HyperLink linkDelegateOrgChart = gridItem.FindControl("linkDelegateOrgChart") as HyperLink;
             
                // set links to edit user and delegate PD
               
                linkDelegatePD.NavigateUrl = string.Format("~/Admin/delegatePD.aspx?userID={0}", currentUser.UserID);
                linkDelegateJNP.NavigateUrl = string.Format("~/Admin/DelegateJNP.aspx?userID={0}", currentUser.UserID);
                linkEditUser.NavigateUrl = string.Format("~/Admin/editUser.aspx?userID={0}", currentUser.UserID);
                linkDelegateOrgChart.NavigateUrl = string.Format("~/Admin/DelegateOrgChart.aspx?userID={0}", currentUser.UserID);
            }
        }

        #endregion
    }
}
