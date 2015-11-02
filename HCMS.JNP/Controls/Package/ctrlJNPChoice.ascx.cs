using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web;
using Telerik.Web.UI;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.JNPTracker;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using HCMS.Business.Base;
using HCMS.Business.Check;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.Business.Lookups;

namespace HCMS.JNP.Controls.Package
{
    public partial class ctrlJNPChoice : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadJNPOptions();
            }
        }

        private void LoadJNPOptions()
        {
            //List<JNPOptionType> optionTypes = LookupWrapper.GetAllJNPOptionType(true);

            //foreach (JNPOptionType optionType in optionTypes)
            //{
            //    if (optionType.IsVisible)
            //    {
                    //if (optionType.JNPOptionTypeID == ((int)eJNPOptionType.CreateStandAloneDoc))
                    //{
                    //    if (HasHRGroupPermission)
                    //    {
                    //        this.rblJNPOptions.Items.Add(new ListItem(optionType.JNPOptionTypeName, optionType.JNPOptionTypeID.ToString())); 
                    //    }
                    //}
                    //else
                    //{
                    //    this.rblJNPOptions.Items.Add(new ListItem(optionType.JNPOptionTypeName, optionType.JNPOptionTypeID.ToString()));
                    //}
            //    }
            //}

            //this.rblJNPOptions.DataSource = LookupWrapper.GetAllJNPOptionType(true);
            //this.rblJNPOptions.DataBind();

            if (base.HasHRGroupPermission)
            {
                divCreateStandAloneDoc.Visible = false;
            }
            else
            {
                divCreateStandAloneDoc.Visible = false;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            eJNPOptionType option;
            if (rbCreateUsingExisting.Checked)
            {
                option = eJNPOptionType.CreateFromExisting;
            }
            else if (rbCreateNewJANP.Checked)
            {
                option = eJNPOptionType.CreateNew;
            }
            else if (rbCreateStandAloneDoc.Checked)
            {
                option = eJNPOptionType.CreateStandAloneDoc;
            }
            else
            {
                option = eJNPOptionType.None;
            }
             
            switch(option)
            {
                case eJNPOptionType.CreateNew :
                    Response.Redirect("~/Package/CreateJNP.aspx");
                    break;
                case eJNPOptionType.CreateFromExisting :
                    //JA issue id 468:Copy package on create new screen should take user to search screen 
                    Response.Redirect("~/Search/SearchResults.aspx");
                    break;
                case eJNPOptionType.CreateStandAloneDoc :
                    break;
            }

        }

        protected void rblJNPOptions_DataBinding(object sender, EventArgs e)
        {
            //RadioButtonList rlist = (RadioButtonList)sender;

            //foreach (ListItem li in rlist.Items)
            //{
            //    if (Convert.ToInt32(li.Value) == (int)eJNPOptionType.CreateStandAloneDoc)
            //    {
            //        li.Enabled = false;   
            //    }
            //}
        }

    }
}