using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using HCMS.Business.PD;
using PD = HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using Telerik.Web.UI;
using HCMS.Business.PD.Collections;
using System.Linq;
using System.Collections.Generic;

namespace HCMS.Portal.Admin
{
    public partial class delegatePD : AdminPageBase 
    {
        const string comboUserTopLine = "[<<- Select New Owner ->>]";

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            this.RequireUserID = true;
            this.Load += new EventHandler(PageLoad);
            this.buttonCancel.Click += new EventHandler(buttonCancel_Click);
            this.gridViewUsers.RowDataBound += new GridViewRowEventHandler(gridViewUsers_RowDataBound);
            this.gridViewUsers.PageIndexChanging += new GridViewPageEventHandler(gridViewUsers_PageIndexChanging);
            this.gridViewUsers.RowEditing += new GridViewEditEventHandler(gridViewUsers_RowEditing);
            this.gridViewUsers.RowCancelingEdit += new GridViewCancelEditEventHandler(gridViewUsers_RowCancelingEdit);
            this.gridViewUsers.RowUpdating += new GridViewUpdateEventHandler(gridViewUsers_RowUpdating);
            this.gridViewUsers.RowCreated += new GridViewRowEventHandler(gridViewUsers_RowCreated);
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

        private void loadPage()
        {
                base.PageTitle = string.Format("PD Delegation Change for {0}", base.CurrentEditUser.FullNameReverse);
                bindData();
            
        }

        private void bindData()
        {
            PositionDescriptionCollection pcoll = base.CurrentEditUser.GetNonPublishedPositionDescriptions();

            gridViewUsers.DataSource = pcoll.GetNonLadderPDs();
            gridViewUsers.DataBind();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.SafeRedirect(string.Format("~/Admin/editUser.aspx?userID={0}", base.CurrentEditUser.UserID));
        }

       
        #endregion

        #region GridView Events

        private void gridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                { 
                        PositionDescription pd = (PositionDescription)e.Row.DataItem;
                        RadListBox  lboxpds = e.Row.FindControl("lstPDs") as RadListBox ;
                        lboxpds.DataTextField = "PositionDescriptionID";
                        
                        if (pd.PositionDescriptionTypeID == 4)
                        {
                            PositionDescriptionCollection pdcoll = pd.GetOtherCareerLadderPositionDescriptions();
                            lboxpds.DataSource = pdcoll.ToList<PositionDescription>();
                            lboxpds.DataBind();
                        }
                        else
                        {
                            List<PositionDescription> pdlist = new List<PositionDescription>();
                            pdlist.Add(pd);
                            lboxpds.DataSource = pdlist;
                            lboxpds.DataBind();
                        }

                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                       
                        RadComboBox comboUsers = (RadComboBox)e.Row.FindControl("radComboUsers");
                        HtmlGenericControl spanAssign = (HtmlGenericControl)e.Row.FindControl("spanAssign");
                        
                        int RegionID = base.CurrentUser.RegionID;
                        if (base.IsSystemAdministrator)
                        { RegionID = -1; }
                        UserCollection userList = LookupWrapper.GetAllUsersByOrganizationCodeSearch(true, RegionID, pd.OrganizationCodeID);
                        int tempUserID = base.CurrentEditUser.UserID;

                        // remove the currentEditUser from the drop down if                         
                        if (userList.Contains(tempUserID))
                            userList.Remove(userList.Find(tempUserID));

                        if (userList.Count > 0)
                            ControlUtility.BindRadComboBoxControl(comboUsers, userList, null, "FullNameReverse", "UserID", comboUserTopLine);
                        else
                        {
                            spanAssign.Visible = false;
                            comboUsers.Items.Add(new RadComboBoxItem("[** No Other Users Assigned to Org Code **]", "-1"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridViewUsers.PageIndex = e.NewPageIndex;
                bindData();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridViewUsers_RowEditing(object source, GridViewEditEventArgs e)
        {
            try
            {
                gridViewUsers.EditIndex = e.NewEditIndex;
                bindData();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridViewUsers_RowCancelingEdit(object source, GridViewCancelEditEventArgs e)
        {
            try
            {
                gridViewUsers.EditIndex = -1;
                bindData();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridViewUsers_RowUpdating(object source, GridViewUpdateEventArgs e)
        {
            try
            {
                long PDID = (long)gridViewUsers.DataKeys[e.RowIndex].Value;
                int newOwnerUserID = int.Parse(((RadComboBox)gridViewUsers.Rows[e.RowIndex].FindControl("radComboUsers")).SelectedValue);
                PositionDescription currentPD = new PositionDescription();

                currentPD.PositionDescriptionID = PDID;
                currentPD.ChangeOwner(newOwnerUserID);

                gridViewUsers.EditIndex = -1;
                gridViewUsers.PageIndex = 0;
                bindData();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridViewUsers_RowCreated(object source, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        RequiredFieldValidator requiredUsers = (RequiredFieldValidator)e.Row.FindControl("requiredUsers");
                        requiredUsers.InitialValue = comboUserTopLine;
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

    }
}
