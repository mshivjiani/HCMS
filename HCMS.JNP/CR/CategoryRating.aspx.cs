using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.JNP.CR
{
    public partial class CategoryRating :JNPPageBase 
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load +=new EventHandler(Page_Load);
            this.ctrlCategoryRating1.NonExistentCREncountered += new WebFramework.BaseControls.JNPUserControlBase.NonExistentCRHandler(ctrlCategoryRating1_NonExistentCREncountered);
            base.OnInit(e);
        }

        void ctrlCategoryRating1_NonExistentCREncountered()
        {
            base.PrintErrorMessage("Category Rating is not available.");
        }
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.TopMenu = enumTopMenuType.CRMenu;
            base.LeftMenu = LeftMenuType.CRMenu;
            base.SelectLeftMenuItem = enumLeftMenuItem.CategoryRating;
            base.SelectTopMenuItem = enumTopMenuItem.CategoryRating;
            base.SelectProgressBar = enumProgressBarItem.CategoryRating;

            //base.ShowSubMenu = false;
            base.PageTitle = "Category Rating";
        }
    }
}