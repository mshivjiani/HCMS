using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.Site.Utilities;
using Telerik.Web.UI;

namespace HCMS.Portal.Admin
{
    public partial class OrgCodeAdmin : AdminPageBase
    {
        const string comboRegionTopLine = "[<<- Select Region to Filter Organization Codes ->>]";
        const string comboOrgCodeTopLine = "[<<- Select Organization Code ->>]";

        #region "Private Methods"
        private void bindDDLOrgCode(int filterRegionID)
        {
            OrganizationCodeCollection orgCodes = LookupWrapper.GetOrganizationCodesByRegion(false, filterRegionID);
            this.radComboOrgCodes.Text = string.Empty;
            ReSetControls();

            radComboOrgCodes.Items.Clear();

            if (orgCodes.Count > 0)
            {
                // bind org list based on current user's region ID

                switch (rdOrgCode.SelectedValue)
                {
                    case "n":

                        foreach (OrganizationCode orgCode in orgCodes)
                        {
                            RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                            radComboOrgCodes.Items.Add(item);
                        }
                        break;
                    case "o":
                        foreach (OrganizationCode orgCode in orgCodes)
                        {
                            RadComboBoxItem item = new RadComboBoxItem(orgCode.OldOrganizationCode + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                            radComboOrgCodes.Items.Add(item);
                        }
                        break;
                    default:
                        foreach (OrganizationCode orgCode in orgCodes)
                        {
                            RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                            radComboOrgCodes.Items.Add(item);
                        }
                        break;
                }

                radComboOrgCodes.Items.Insert(0, new RadComboBoxItem("[<<- Select Organization Code ->>]", "-1"));

                //ControlUtility.BindRadComboBoxControl(this.radComboOrgCodes, orgCodes, null, "DetailLineLegacy", "OrganizationCodeID", comboOrgCodeTopLine);
                btnSave.Enabled = true;
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
        private void setMenuTitle()
        {
            base.TopMenu = enumTopMenuType.AdminMenu;
            base.LeftMenu = LeftMenuType.OrgCodeAdminMenu;
            base.SelectTopMenuItem = enumTopMenuItem.OrgCodeAdmin;
            base.SelectLeftMenuItem = enumLeftMenuItem.OrgcodeAdmin;            
            base.PageTitle = "Organization Code Administration";
        }
        private void loadPage()
        {
            btnSave.Enabled = false;
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

        }
        private void SaveOrganizationCode(int selOrgCode)
        {
            try
            {
                OrganizationCode OrgCode = new OrganizationCode(selOrgCode);
                OrgCode.Introduction = this.txtIntroduction.Text;
                OrgCode.Update();
                showMessage(string.Format("Organization Code '{0}' saved successfully!", OrgCode.OrganizationCodeValue));
            }
            catch (Exception ex)
            {
                showMessage(ex.Message);
            }
        }

        private void showMessage(string systemMessage)
        {
            literalSystem.Text = systemMessage;
            panelSystemMessage.Visible = true;
        }
        private void ReSetControls()
        {
            this.txtIntroduction.Text = string.Empty;
            this.lblReportingOrganizationCode.Text = string.Empty;
            panelSystemMessage.Visible = false;
        }
        #endregion

        #region "Page Events"
        protected override void OnInit(EventArgs e)
        {
            //this.RequireUserID = true;
            this.radComboRegions.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(radComboRegions_SelectedIndexChanged);
            this.radComboOrgCodes.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(radComboOrgCodes_SelectedIndexChanged);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                
                
                setMenuTitle();
                if (!Page.IsPostBack)
                    loadPage();
                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rdOrgCode_Changed(object sender, EventArgs e)
        {

            OrganizationCodeCollection orgCodeColl;
            radComboOrgCodes.Items.Clear();

            int RegionID = -1;

            RegionID = Convert.ToInt32(radComboRegions.SelectedValue);

            orgCodeColl = LookupManager.GetOrganizationCodesByRegion(RegionID);

            radComboOrgCodes.Items.Clear();

            switch (rdOrgCode.SelectedValue)
            {
                case "n":

                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        radComboOrgCodes.Items.Add(item);
                    }
                    break;
                case "o":
                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OldOrganizationCode + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        radComboOrgCodes.Items.Add(item);
                    }
                    break;
                default:
                    foreach (OrganizationCode orgCode in orgCodeColl)
                    {
                        RadComboBoxItem item = new RadComboBoxItem(orgCode.OrganizationCodeValue + " | " + orgCode.OrganizationName, orgCode.OrganizationCodeID.ToString());
                        radComboOrgCodes.Items.Add(item);
                    }
                    break;
            }

            radComboOrgCodes.Items.Insert(0, new RadComboBoxItem("[<<- Select Organization Code ->>]", "-1"));
        }

        #endregion

        #region "Control Events"
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

        private void radComboOrgCodes_SelectedIndexChanged(object source, EventArgs e)
        {
            try
            {
                ReSetControls();
                string Introduction;
                int selOrgCode;
                if (this.radComboOrgCodes.SelectedIndex > 0)
                {
                    selOrgCode = int.Parse(this.radComboOrgCodes.SelectedValue);
                    OrganizationCode OrgCode = new OrganizationCode(selOrgCode);
                    Introduction = OrgCode.Introduction;
                    this.txtIntroduction.Text = Introduction;
                    if (OrgCode.ReportingOrganizationCode > 0)
                    {
                        this.lblReportingOrganizationCode.Text = OrgCode.ReportingOrganizationCodeValue.ToString();
                    }


                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int selOrgCode;
                if (this.radComboOrgCodes.SelectedIndex > 0)
                {
                    selOrgCode = int.Parse(this.radComboOrgCodes.SelectedValue);
                    SaveOrganizationCode(selOrgCode);
                }
            }
        }

        #endregion

    }
}
