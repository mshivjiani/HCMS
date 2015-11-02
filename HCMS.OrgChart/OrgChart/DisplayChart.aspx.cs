using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BasePages;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.OrganizationChart.Processing;

namespace HCMS.OrgChart.OrgChart
{
    public partial class DisplayChart : PageCoreBase
    {
        private const string CHARTIDKEY = "id";
        private string _generalErrorMessage = string.Empty;

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                loadResources();

                if (!Page.IsPostBack)
                    loadData();
            }
            catch (Exception ex)
            {
                printMessage(_generalErrorMessage);
                base.HandleException(ex);
            }
        }

        private void printMessage(string message)
        {
            this.divErrorMessage.Visible = !string.IsNullOrWhiteSpace(message);
            this.literalErrorMessage.Text = message;
        }

        private void loadResources()
        {
            _generalErrorMessage = GetLocalResourceObject("GeneralErrorMessage").ToString();
        }

        private void loadData()
        {
            if (Request.QueryString[CHARTIDKEY] == null)
                printMessage(GetLocalResourceObject("NullIDKey").ToString());
            else
            {
                int tempID = -1;
                bool paramOK = int.TryParse(Request.QueryString[CHARTIDKEY], out tempID);

                if (!paramOK)
                    printMessage(GetLocalResourceObject("IDKeyNotAValidInteger").ToString());
                else
                {
                    OrganizationChart chart = OrganizationChartManager.Instance.GetByID(tempID);

                    if (chart.OrganizationChartID == -1)
                        printMessage(GetLocalResourceObject("IDNotFoundMessage").ToString());
                    else
                    {
                        this.customDisplayChart.Visible = true;
                        this.Page.Title = string.Format(GetLocalResourceObject("PageTitle").ToString(), chart.OrganizationName, chart.OrgCode.OrganizationCodeValue);
                        IList<OrganizationChartPosition> positionList = OrganizationChartPositionManager.Instance.GetOrganizationChartPositions(chart.OrganizationChartID);

                        ChartGenerationParameters genParams = new ChartGenerationParameters()
                        {
                            ID = chart.OrganizationChartID,
                            ChartType = OrganizationChartTypeViews.InProcess
                        };

                        this.customDisplayChart.BindChart(genParams, positionList.ToList<IChartPosition>(), chart.StartPointWFPPositionID);
                    }
                }
            }
        }
    }
}