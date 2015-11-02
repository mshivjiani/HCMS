using System;

using HCMS.Business.PD;

namespace HCMS.WebFramework.BasePages
{
    public class CreatePDPageBase : PageBase
    {
        #region Methods

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.LeftMenu = LeftMenuType.CreatePDMenu;
            base.ShowInformationDiv = false;
            base.OnPreRender(e);
        }

        #endregion
    }
}
