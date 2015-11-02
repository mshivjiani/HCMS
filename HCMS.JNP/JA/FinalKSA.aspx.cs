using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BasePages;
using HCMS.JNP.Controls.JA;

namespace HCMS.JNP.JA
{
    public partial class FinalKSA : JNPPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
 
            base.OnInit(e);
        }

       

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.TopMenu = enumTopMenuType.JAMenu;
                base.LeftMenu = LeftMenuType.JAMenu;            
                base.SelectTopMenuItem = enumTopMenuItem.JobAnalysis;
                base.SelectLeftMenuItem = enumLeftMenuItem.FinalKSA;
                base.SelectProgressBar = enumProgressBarItem.JAFinalKSA;
                base.PageTitle = "Final KSA";                        
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

       

    }
}