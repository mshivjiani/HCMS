using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.OrganizationChart.Positions;

namespace HCMS.OrgChart.OrgChart
{
    public partial class UpdateNewFPPSPosition : OrgChartPageBase
    {
        private const string EDITPOSIDKEY = "editPosID";

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.customNewFPPSPosition.TitleChanged += new UserControlBase.TitleChangedHandler(customNewFPPSPosition_TitleChanged);
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                    loadData();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void loadData()
        {
            SiteUtility.RefreshOrgChartDataOnly();
            OrganizationChart chart = SiteUtility.CurrentOrgChart;

            int tempPositionID = -1;
            bool isOK = int.TryParse(Request.QueryString[EDITPOSIDKEY], out tempPositionID);

            if (isOK)
            {
                WorkforcePlanningPosition position = WorkforcePlanningPositionManager.Instance.GetByID(tempPositionID);

                if (position.WFPPositionID == -1)
                    base.PrintErrorMessage(GetLocalResourceObject("PositionDoesNotExistMessage").ToString());
                else
                    customNewFPPSPosition.BindData(position);
            }
            else
                base.PrintErrorMessage(GetLocalResourceObject("PositionIDQuerystringNotValidMessage").ToString());
        }

        private void customNewFPPSPosition_TitleChanged(string newTitle)
        {
            base.PageTitle = newTitle;
        }
    }
}