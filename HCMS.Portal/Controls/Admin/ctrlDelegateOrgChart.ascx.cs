using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.Business.Security.Collections;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.OrganizationChart;

namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlDelegateOrgChart : OrgChartUserControlBase
    {
        const string comboUserTopLine = "[<<- Select New Owner ->>]";
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.buttonCancel.Click += new EventHandler(buttonCancel_Click);
            this.gridViewUsers.RowDataBound += new GridViewRowEventHandler(gridViewUsers_RowDataBound);
            this.gridViewUsers.PageIndexChanging += new GridViewPageEventHandler(gridViewUsers_PageIndexChanging);
            this.gridViewUsers.RowEditing += new GridViewEditEventHandler(gridViewUsers_RowEditing);
            this.gridViewUsers.RowCancelingEdit += new GridViewCancelEditEventHandler(gridViewUsers_RowCancelingEdit);
            this.gridViewUsers.RowUpdating += new GridViewUpdateEventHandler(gridViewUsers_RowUpdating);
            this.gridViewUsers.RowCreated += new GridViewRowEventHandler(gridViewUsers_RowCreated);
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            gridViewUsers.DataSource = OrganizationChartManager.Instance.GetInProcessOrganizationChartsByUserID  (base.CurrentEditUser.UserID);
            gridViewUsers.DataBind();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.SafeRedirect(string.Format("~/Admin/editUser.aspx?userID={0}", base.CurrentEditUser.UserID));
        }
        #region GridView Events

        private void gridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                   OrganizationChart  item = (OrganizationChart)e.Row.DataItem;

                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {

                        RadComboBox comboUsers = (RadComboBox)e.Row.FindControl("radComboUsers");
                        HtmlGenericControl spanAssign = (HtmlGenericControl)e.Row.FindControl("spanAssign");

                        int RegionID = base.CurrentUser.RegionID;
                        if (base.IsSystemAdministrator)
                        { RegionID = -1; }
                        UserCollection userList = LookupWrapper.GetAllUsersByOrganizationCodeSearch(true, RegionID, item.OrgCode.OrganizationCodeID);
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
                BindData();
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
                BindData();
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
                BindData();
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
                int OrganizationChartID = (int)gridViewUsers.DataKeys[e.RowIndex].Value;
                int newOwnerUserID = int.Parse(((RadComboBox)gridViewUsers.Rows[e.RowIndex].FindControl("radComboUsers")).SelectedValue);

                OrganizationChartManager.Instance.ChangeOrganizationChartOwner(OrganizationChartID, newOwnerUserID);

                gridViewUsers.EditIndex = -1;
                gridViewUsers.PageIndex = 0;
                BindData();
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