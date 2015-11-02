using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Security;
namespace HCMS.WebFramework.BasePages
{
    public class AdminPageBase : PageBase
    {
        #region Properties

        protected bool RequireUserID
        {
            get
            {
                if (ViewState["RequireUserID"] == null)
                    ViewState["RequireUserID"] = false;

                return (bool)ViewState["RequireUserID"];
            }
            set
            {
                ViewState["RequireUserID"] = value;
            }
        }

        protected User CurrentEditUser
        {
            get
            {
                if (Session["CurrentEditUser"] == null)
                    Session["CurrentEditUser"] = new User();

                return (User)Session["CurrentEditUser"];
            }
            set
            {
                Session["CurrentEditUser"] = value;
            }
        }

        #region Menu Related Methods

        protected bool ShowLeftMenu
        {
            get { return ((MasterPageBase)Master).ShowLeftMenu; }
            set { ((MasterPageBase)Master).ShowLeftMenu = value; }
        }

        protected bool ShowTopMenu
        {
            get { return ((MasterPageBase)Master).ShowTopMenu ; }
            set { ((MasterPageBase)Master).ShowTopMenu  = value; }
        }
        protected enumTopMenuItem SelectTopMenuItem
        {
            get { return ((MasterPageBase)Master).SelectTopMenuItem; }
            set { ((MasterPageBase)Master).SelectTopMenuItem = value; }
        }

        protected enumLeftMenuItem SelectLeftMenuItem
        {
            get { return ((MasterPageBase)Master).SelectLeftMenuItem; }
            set { ((MasterPageBase)Master).SelectLeftMenuItem = value; }

        }

        protected enumTopMenuType TopMenu
        {
            get { return ((MasterPageBase)Master).TopMenuType; }
            set { ((MasterPageBase)Master).TopMenuType = value; }
        }

        #endregion

        #endregion

        #region Common Methods

        protected void GoToAdminPage()
        {
            base.SafeRedirect("~/admin/default.aspx");
        }

        #endregion

          protected override void OnPreInit(EventArgs e)
        {
            ShowTopMenu = true;
            ShowLeftMenu = true;
            TopMenu = enumTopMenuType.AdminMenu;
            base.OnPreInit(e);

          
        }

          protected override void OnLoad(EventArgs e)
          {
              if (base.IsAdministrator)
              {
                  if (this.RequireUserID)
                  {
                      int currentedituserid = -1;
                      if (Request.QueryString["userID"] != null)
                      {
                          currentedituserid = int.Parse(Request.QueryString["userID"].ToString());
                          CurrentEditUser = new User(currentedituserid);
                      }
                      User tempUser = CurrentEditUser;

                      if (tempUser.UserID == -1)
                          base.PrintErrorMessage("The user account is either not specified or it does not exist in the system.");
                      else
                      {
                          // if the user is not a system admin AND the editUser's region ID is not equal to the currentUser regionID
                          if ((!base.IsSystemAdministrator) && (tempUser.RegionID != base.CurrentUser.RegionID))
                              base.PrintErrorMessage("You do not have permission to access the user account specified.");
                          else
                          {

                              base.OnLoad(e);
                          }
                      }

                  }
                  else
                  {
                      base.OnLoad(e);
                  }
                
              }
              else
                  base.GoToAccessDeniedPage();
          }

         

    }
}
