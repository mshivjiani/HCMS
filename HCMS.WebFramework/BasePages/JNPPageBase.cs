using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCMS.WebFramework.BasePages
{
    public class JNPPageBase : PageBase
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
          
        }
        protected enumTopMenuItem SelectTopMenuItem
        {
            get { return ((MasterPageBase)Master).SelectTopMenuItem; }
            set { ((MasterPageBase)Master).SelectTopMenuItem = value; }
        }
        protected enumProgressBarItem SelectProgressBar
        {
            get { return ((MasterPageBase)Master).SelectProgressBar; }
            set { ((MasterPageBase)Master).SelectProgressBar = value; }
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

        protected enumProgressBarItem ProgressBar
        {
            get { return ((MasterPageBase)Master).ProgressBar; }
            set { ((MasterPageBase)Master).ProgressBar = value; }
        }

    }

}