using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart.Published;
using HCMS.Business.OrganizationChart.Published.Positions;

namespace HCMS.OrgChart.Controls.PubOrgChart
{
    public partial class ctrlViewChartPositionDetailsPublished : PubOrgChartRequiredUserControlBase
    {
        private const string VIEWPOSIDKEY = "viewPosID";
        private const string DRILLPOSIDKEY = "posID";

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.buttonChartPositions.Click += new EventHandler(buttonChartPositions_Click);
            this.buttonOrganizationChartDetails.Click += new EventHandler(buttonOrganizationChartDetails_Click);
            this.buttonCancel.Click += new EventHandler(buttonCancel_Click);
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
            OrganizationChartLog chartLog = base.CurrentOrgChartLog;
            int tempPositionID = -1;
            bool isOK = int.TryParse(Request.QueryString[VIEWPOSIDKEY], out tempPositionID);

            if (isOK)
            {
                OrganizationChartPositionLog position = OrganizationChartPositionLogManager.Instance.GetByID(chartLog.OrganizationChartLogID, tempPositionID);

                if (position.WFPPositionID == -1)
                    base.PrintErrorMessage(GetLocalResourceObject("PositionDoesNotExistMessage").ToString());
                else
                {
                    this.customPubOrgChartDetails.BindData(chartLog);
                    this.customFPPSPositionInformation.BindData(position, chartLog.StartPointWFPPositionID);
                }
            }
            else
                base.PrintErrorMessage(GetLocalResourceObject("PositionIDQuerystringNotValidMessage").ToString());
        }

        #region Button Click Event

        private void buttonChartPositions_Click(object sender, EventArgs e)
        {
            try
            {
                base.GoToPublishedOrganizationChartPositions();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonOrganizationChartDetails_Click(object sender, EventArgs e)
        {
            try
            {
                base.GoToPublishedOrganizationChartDetails();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                string redirectURL = "~/PubOrgChart/OrgChartPositions.aspx";

                if (Request.QueryString[DRILLPOSIDKEY] == null)
                    redirectURL += "#positionlist";
                else
                    redirectURL += string.Format("?posID={0}#positionlist", Request.QueryString[DRILLPOSIDKEY]);

                base.SafeRedirect(redirectURL);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion
    }
}