using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.JNP;
using HCMS.WebFramework.BasePages;
using HCMS.JNP.Controls.Package;

namespace HCMS.JNP.Package
{
    public partial class CopyJNPFromExisting : JNPPageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.SelectLeftMenuItem = enumLeftMenuItem.None;
            //base.SelectTopMenuItem = enumTopMenuItem.Create;
            base.ShowTopMenu = false;
            string title = "Copy From Existing Job Announcement";
            base.PageTitle = title;
            base.ShowInformationDiv = false;
            base.ShowSubMenu = false;
            ((JNPMaster)this.Master).ShowNotesLink = false;
            if (!Page.IsPostBack)
            {
                long CopyJNPID = -1;
              
                if (Request.QueryString["CopyJNPID"] != null)
                {
                    CopyJNPID = long.Parse(Request.QueryString["CopyJNPID"].ToString());
                    this.ctrlCopyJNP1.CopyJNPID = CopyJNPID;
                   
                }
                else
                {
                    base.PrintErrorMessage("Copy JAX ID is not provided.", false);
                }
            }
            
        }
    }
}