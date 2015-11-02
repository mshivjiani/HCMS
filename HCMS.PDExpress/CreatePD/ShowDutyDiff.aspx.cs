using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BasePages;

namespace HCMS.PDExpress.CreatePD
{
    public partial class ShowDutyDiff : PageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            //Hide left menu and set progress bar width for full page.
            base.ShowLeftMenu = false;
            this.ctrlCreatePDMapStatusProgress.ProgressBar.Visible = false;
            this.ctrlCreatePDMapStatusProgress.ProgressBarWidth = 900;
            if (!Page.IsPostBack)
            {
                this.ucShowDutyDiff.RedirectedFrom = Request.UrlReferrer.ToString();
            }
        }
    }
}
