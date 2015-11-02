using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.Business.Security;
using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using Telerik.Web.UI;
using System.Collections.Generic;

namespace HCMS.Portal.Admin
{
    public partial class PDAdmin : AdminPageBase 
    {
        const string dropdownOrgCodeTopLine = "[<<- All Organization Codes ->>]";
        const string dropdownUserTopLine = "[<<- All Active Users ->>]";
        #region Properties

        private PositionWorkflowStatusCollection PWColl
        {
            get
            {
                
                    string searchPDIDtext = this.textboxPDID.Text.Trim();
                    long searchPDID = searchPDIDtext.Length.Equals(0) ? -1 : long.Parse(searchPDIDtext);
                    PositionWorkflowStatusCollection pdcoll = LookupManager.SearchPositionsDescription
                        (searchPDID, int.Parse(this.radDropdownUsers.SelectedValue), int.Parse(this.radDropdownOrgCodes.SelectedValue));


                    return pdcoll;
            }
          
        }

        #endregion

        #region Page Events
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.buttonSearch.Click += new EventHandler(buttonSearch_Click);
            this.gridViewPD.RowDataBound += new GridViewRowEventHandler(gridViewPD_RowDataBound);
            this.gridViewPD.RowCommand += new GridViewCommandEventHandler(gridViewPD_RowCommand);
            this.gridViewPD.PageIndexChanging += new GridViewPageEventHandler(gridViewPD_PageIndexChanging);
            this.gridViewPD.RowCreated += new GridViewRowEventHandler(gridViewPD_RowCreated);
            base.OnInit(e);
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                setMenuTitle();
                if (!Page.IsPostBack)
                    loadPage();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Get PDs that are non-lower ladder PDs.
        /// </summary>
        /// <param name="pws"></param>
        /// <returns></returns>
        private bool isMatch(PositionWorkflowStatus pws)
        {
            PDChoiceType currentpdtypeid = (PDChoiceType)pws.PositionDescriptionTypeID;
            int ldrposn = pws.LadderPosition;
            //full performance cl
            if ((currentpdtypeid == PDChoiceType.CareerLadderPD && ldrposn <= 0)
                ||
                //non cl
                (currentpdtypeid != PDChoiceType.CareerLadderPD && currentpdtypeid != PDChoiceType.CLStatementOfDifferencePD))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<PositionWorkflowStatus> GetCLBundle(PositionWorkflowStatus PWS)
        {
            List<PositionWorkflowStatus> pdList = new List<PositionWorkflowStatus>();
            pdList = PWColl.FindAll(delegate(PositionWorkflowStatus pws) { return pws.AssociatedFullPD == PWS.PositionDescriptionID; });
            pdList.Add(PWS);
            return pdList;
        }
        private void loadPage()
        {
            if (base.HasPermission(enumPermission.ActivateDeactivatePD))
            {
                bindOrgCodes();
                bindUsers();
            }
            else
                base.GoToAccessDeniedPage();
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
            try
            {
                gridViewPD.DataSource = PWColl.FindFiltered(isMatch);
                gridViewPD.DataBind();
                
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void setMenuTitle()
        {
            base.TopMenu = enumTopMenuType.AdminMenu;
            base.LeftMenu = LeftMenuType.PDAminMenu ;
            base.SelectTopMenuItem = enumTopMenuItem.PDAdmin;
            base.SelectLeftMenuItem = enumLeftMenuItem.PDAdmin ;
            base.PageTitle = "Position Description Administration";
        }

        #endregion

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

        private void gridViewPD_RowCreated(object source, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        PositionWorkflowStatus pws = (PositionWorkflowStatus)e.Row.DataItem;

                        if (pws != null)
                        {
                            ImageButton imageButtonAction = (ImageButton)e.Row.FindControl("imageButtonAction");
                            string imageSkinID = string.Empty;
                            string confirmationMessage = string.Empty;
                            
                            RadListBox lboxpds = e.Row.FindControl("lstPDs") as RadListBox;
                            lboxpds.DataTextField = "PositionDescriptionID";
                            if (pws.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD)
                            {
                                List<PositionWorkflowStatus> ladderpds = GetCLBundle(pws);
                                lboxpds.DataSource = ladderpds;
                            }
                            else
                            {
                                List<PositionWorkflowStatus> pwslist = new List<PositionWorkflowStatus>();
                                pwslist.Add(pws);
                                lboxpds.DataSource = pwslist;
                            }
                            lboxpds.DataBind();

                            if ((PDStatus)pws.WorkflowStatusID == PDStatus.Inactive)
                            {
                                imageSkinID = "squareIcon";
                                confirmationMessage = "Are you sure you want to reactivate the selected position description?";
                            }
                            else
                            {
                                imageSkinID = "checkIcon";
                                confirmationMessage = "Are you sure you want to inactivate the selected position description?";
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

        private void gridViewPD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        PositionWorkflowStatus pws = (PositionWorkflowStatus)e.Row.DataItem;
                        ImageButton imageButtonAction = (ImageButton)e.Row.FindControl("imageButtonAction");
                        string imageCaption = string.Empty;
                        string actionCommand = string.Empty;

                        if ((PDStatus)pws.WorkflowStatusID == PDStatus.Inactive)
                        {
                            imageCaption = "The current PD is inactive.  Click this image to activate it.";
                            actionCommand = "Reactivate";
                        }
                        else
                        {
                            imageCaption = "The current PD is active.  Click this image to inactivate it.";
                            actionCommand = "Deactivate";
                        }

                        imageButtonAction.AlternateText = imageCaption;
                        imageButtonAction.CommandName = actionCommand;
                        imageButtonAction.CommandArgument = pws.PositionDescriptionID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridViewPD_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Reactivate" || e.CommandName == "Deactivate")
            {
                try
                {
                    PositionDescription thisPD = new PositionDescription();
                    thisPD.PositionDescriptionID = Convert.ToInt64(e.CommandArgument);
                    thisPD.UpdatedByID = base.CurrentUser.UserID;

                    if (e.CommandName.Equals("Reactivate"))
                        thisPD.Reactivate();
                    else
                        thisPD.Deactivate();
                    
                 
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

        private void gridViewPD_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridViewPD.PageIndex = e.NewPageIndex;
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
