using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BasePages;
using HCMS.JNP.Controls.JA;
using HCMS.Business.JNP;
using HCMS.JNP.Controls.Package;
using HCMS.WebFramework.BaseControls ;

namespace HCMS.JNP.JA
{
    public partial class JAPositionInformation : JNPPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            
            this.ctrlPositionInfoData.NonExistentJNPEncountered += new ctrlPositionInfo.NonExistentJNPHandler(ctrlPositionInfoData_NonExistentJNPEncountered);
            base.OnInit(e);
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.TopMenu = enumTopMenuType.JAMenu;
                base.LeftMenu = LeftMenuType.JAMenu;
                base.SelectLeftMenuItem = enumLeftMenuItem.JAPositionInformation;
                base.SelectTopMenuItem = enumTopMenuItem.JobAnalysis;
                base.SelectProgressBar = enumProgressBarItem.JAPositionInfo;
                base.PageTitle = "Position Information";

                
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

       

        private void ctrlPositionInfoData_NonExistentJNPEncountered()
        {
            try
            {
                base.PrintErrorMessage(GetLocalResourceObject("JNPNotFoundMessage").ToString(), false);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
    }
}