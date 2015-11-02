using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Positions;

namespace HCMS.OrgChart.Controls.Positions
{
    public partial class ctrlUpdateChartPosition : OrgChartRequiredUserControlBase
    {
        private const string EDITPOSIDKEY = "editPosID";

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.customFPPSPosition.TitleChanged +=new TitleChangedHandler(custom_TitleChanged);
            this.customWFPPosition.TitleChanged += new TitleChangedHandler(custom_TitleChanged);
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
            base.RefreshOrgChartDataOnly();
            OrganizationChart chart = base.CurrentOrgChart;
            int tempPositionID = -1;
            bool isOK = int.TryParse(Request.QueryString[EDITPOSIDKEY], out tempPositionID);

            if (isOK)
            {
                OrganizationChartPosition position = OrganizationChartPositionManager.Instance.GetByID(chart.OrganizationChartID, tempPositionID);

                if (position.WFPPositionID == -1)
                    base.PrintErrorMessage(GetLocalResourceObject("PositionDoesNotExistMessage").ToString());
                else
                {
                    // now check to see if this is a WFP or an FPPS
                    if (position.ChartPositionType == enumChartPositionType.WFP)
                        this.customWFPPosition.BindData(position);
                    else
                        this.customFPPSPosition.BindData(position);
                }
            }
            else
                base.PrintErrorMessage(GetLocalResourceObject("PositionIDQuerystringNotValidMessage").ToString());
        }

        private void custom_TitleChanged(string newTitle)
        {
            base.SetPageTitle(newTitle);
        } 

        protected override void ToggleReadOnlyView(enumNavigationMode selectedMode)
        {
            // do nothing -- Read-only is not used in this control, but in the underlying controls
        }
    }
}