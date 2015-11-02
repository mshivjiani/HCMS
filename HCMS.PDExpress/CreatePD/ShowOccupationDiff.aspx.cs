using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.PDExpress.CreatePD
{
    public partial class ShowOccupationDiff : PageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            //Hide left menu and set progress bar width for full page.
            base.ShowLeftMenu = false;
            this.ctrlCreatePDMapStatusProgress.ProgressBar.Visible = false;
            this.ctrlCreatePDMapStatusProgress.ProgressBarWidth = 895;

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.UrlReferrer.ToString()))
                {
                    this.ctrlShowOccDiff.GoBackURL = Request.UrlReferrer.ToString();
                    this.ctrlShowOccDiff.GoBackURLQS = Request.UrlReferrer.Query.ToString();

                }
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.PageTitle = "Occupation Changes From HR Review"; // setting value here does not make any difference. Use @Page Title to set the page's title.
            base.ShowRequiredFieldMessage = false;
            base.OnPreRender(e);
        }
    }
}
