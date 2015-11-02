using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.Business.JNP;
using HCMS.WebFramework.BaseControls;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.Business.Security.Collections;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.Security;

namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlJNPAdmin : JNPUserControlBase
    {
        const string dropdownOrgCodeTopLine = "[<<- All Organization Codes ->>]";
        const string dropdownUserTopLine = "[<<- All Active Users ->>]";

        private JNPManager jnpManager = new JNPManager();

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.buttonSearch.Click += new EventHandler(buttonSearch_Click);
            this.gridViewJNP.RowDataBound += new GridViewRowEventHandler(gridViewJNP_RowDataBound);
            this.gridViewJNP.RowCommand += new GridViewCommandEventHandler(gridViewJNP_RowCommand);
            this.gridViewJNP.PageIndexChanging += new GridViewPageEventHandler(gridViewJNP_PageIndexChanging);
            this.gridViewJNP.RowCreated += new GridViewRowEventHandler(gridViewJNP_RowCreated);
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                    loadPage();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void loadPage()
        {
            if (base.HasPermission(enumPermission.ActivateDeactivateJNP))
            {
                bindOrgCodes();
                bindUsers();
            }
        }

        private void bindOrgCodes()
        {
            try
            {
                if (base.IsSystemAdministrator)
                {
                    ControlUtility.BindRadComboBoxControl(this.radDropdownOrgCodes, LookupWrapper.GetAllOrganizationCodes(false), null, "DetailLineLegacy", "OrganizationCodeID", dropdownOrgCodeTopLine);

                }
                else
                {
                    // bind org list based on current user's region ID
                    int filterRegionID = base.CurrentUser.RegionID;
                    ControlUtility.BindRadComboBoxControl(this.radDropdownOrgCodes, LookupWrapper.GetOrganizationCodesByRegion(false, filterRegionID), null, "DetailLineLegacy", "OrganizationCodeID", dropdownOrgCodeTopLine);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void bindUsers()
        {
            try
            {
                SecurityManager userList = new SecurityManager();
                int filterRegionID = -1;
                if (!base.IsSystemAdministrator)
                {
                    filterRegionID = base.CurrentUser.RegionID;
                }
                // bind user list based on current user's region ID
                ControlUtility.BindRadComboBoxControl(this.radDropdownUsers, userList.GetActiveUsers(filterRegionID), null, "FullNameReverse", "UserID", dropdownUserTopLine);

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void bindSearchData()
        {
            long? jnpID = null;
            int? orgCodeID = null;
            int? userID = null;

            if (!string.IsNullOrEmpty(this.textboxJNPID.Text))
            {
                jnpID = Convert.ToInt64(this.textboxJNPID.Text);
            }

            if (Convert.ToInt32(this.radDropdownOrgCodes.SelectedValue) > 0)
            {
                orgCodeID = Convert.ToInt32(this.radDropdownOrgCodes.SelectedValue);
            }

            if (Convert.ToInt32(radDropdownUsers.SelectedValue) > 0)
            {
                userID = Convert.ToInt32(radDropdownUsers.SelectedValue);
            }

            try
            {
                gridViewJNP.DataSource = jnpManager.SearchJNPAdmin(jnpID, orgCodeID, userID); 
                gridViewJNP.DataBind();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bindSearchData();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #region GridView Events
        private void gridViewJNP_RowCreated(object source, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        JNPSearchResult item = (JNPSearchResult)e.Row.DataItem;

                        if (item != null)
                        {
                            ImageButton imageButtonAction = (ImageButton)e.Row.FindControl("imageButtonAction");
                            string imageSkinID = string.Empty;
                            string confirmationMessage = string.Empty;

                            if ((enumJNPWorkflowStatus)item.JNPWorkflowStatusID == enumJNPWorkflowStatus.Inactive)
                            {
                                imageSkinID = "squareIcon";
                                confirmationMessage = "Are you sure you want to reactivate the selected Job Announcement?";
                            }
                            else
                            {
                                imageSkinID = "checkIcon";
                                confirmationMessage = "Are you sure you want to inactivate the selected Job Announcement?";
                            }

                            imageButtonAction.Attributes.Add("onclick", string.Format("return confirm('{0}')", confirmationMessage));
                            imageButtonAction.SkinID = imageSkinID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridViewJNP_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        JNPSearchResult item = (JNPSearchResult)e.Row.DataItem;
                        ImageButton imageButtonAction = (ImageButton)e.Row.FindControl("imageButtonAction");
                        string imageCaption = string.Empty;
                        string actionCommand = string.Empty;

                        if ((enumJNPWorkflowStatus)item.JNPWorkflowStatusID == enumJNPWorkflowStatus.Inactive)
                        {
                            imageCaption = "The current JNP is inactive.  Click this image to activate it.";
                            actionCommand = "Reactivate";
                        }
                        else
                        {
                            imageCaption = "The current JNP is active.  Click this image to inactivate it.";
                            actionCommand = "Deactivate";
                        }

                        imageButtonAction.AlternateText = imageCaption;
                        imageButtonAction.CommandName = actionCommand;
                        imageButtonAction.CommandArgument = item.JNPID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridViewJNP_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Reactivate" || e.CommandName == "Deactivate")
            {
                try
                {
                    long JNPID = Convert.ToInt64(e.CommandArgument);

                    if (e.CommandName.Equals("Reactivate"))
                    {
                        jnpManager.ReactivateJNP(JNPID, base.CurrentUserID);
                    }
                    else
                    {
                        jnpManager.DeactivateJNP(JNPID, base.CurrentUserID);
                    }
                }
                catch (Exception ex)
                {
                    base.PrintErrorMessage(ex, true);
                }
                finally
                {
                    bindSearchData();
                }
            }
        }

        private void gridViewJNP_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridViewJNP.PageIndex = e.NewPageIndex;
                bindSearchData();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

    }
}