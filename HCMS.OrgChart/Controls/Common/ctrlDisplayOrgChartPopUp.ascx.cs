using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.OrganizationChart;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.Common;
using HCMS.Business.OrganizationChart.Processing;
using HCMS.WebFramework.Serializers;

namespace HCMS.OrgChart.Controls.Common
{
    public partial class ctrlDisplayOrgChartPopUp : UserControlBase
    {
        #region Object Declarations

        // resource strings
        private string _WPFVacantPhrase = string.Empty;
        private string _FPPSVacantPhrase = string.Empty;
        private string _RootTemplateName = string.Empty;
        private string _FPPSTemplateName = string.Empty;
        private string _WFPTemplateName = string.Empty;
        private string _RootNodeColor = string.Empty;
        private string _FPPSNodeColor = string.Empty;
        private string _WFPNodeColor = string.Empty;
        private string _PositionListFunctionName = string.Empty;

        // property strings
        private string _PreviewTitle = string.Empty;

        #endregion

        #region Property

        public string PreviewTitle
        {
            get
            {
                return this._PreviewTitle;
            }
            set
            {
                this._PreviewTitle = value;
            }
        }

        private int ServerScriptTimeoutInSeconds
        {
            get
            {
                if (ViewState["ServerScriptTimeoutInSeconds"] == null)
                    ViewState["ServerScriptTimeoutInSeconds"] = int.Parse(GetLocalResourceObject("Server.ScriptTimeoutInSeconds").ToString());

                return (int)ViewState["ServerScriptTimeoutInSeconds"];
            }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Server.ScriptTimeout = this.ServerScriptTimeoutInSeconds;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.literalPreviewTitle.Text = this._PreviewTitle;
            base.OnPreRender(e);
        }

        private void loadResources()
        {
            _WPFVacantPhrase = GetLocalResourceObject("WPFVacantPhrase").ToString();
            _FPPSVacantPhrase = GetLocalResourceObject("FPPSVacantPhrase").ToString();
            _RootTemplateName = GetLocalResourceObject("RootTemplateName").ToString();
            _FPPSTemplateName = GetLocalResourceObject("FPPSTemplateName").ToString();
            _WFPTemplateName = GetLocalResourceObject("WFPTemplateName").ToString();
            _RootNodeColor = GetLocalResourceObject("RootNodeColor").ToString();
            _FPPSNodeColor = GetLocalResourceObject("FPPSNodeColor").ToString();
            _WFPNodeColor = GetLocalResourceObject("WFPNodeColor").ToString();
            _PositionListFunctionName = GetLocalResourceObject("PositionListFunctionName").ToString();
        }

        private StringBuilder getPositionListJSON(IList<IChartPosition> positionList, int rootNode)
        {
            StringBuilder script = new StringBuilder();

            script.Append(string.Format("function {0}()", _PositionListFunctionName));
            script.Append("{");

            if (positionList.Count == 0)
                script.Append("return null;");
            else
            {
                script.Append("var positionItemList = ");

                ChartPositionListJsonSerializer json = new ChartPositionListJsonSerializer(_WPFVacantPhrase, _FPPSVacantPhrase, _RootTemplateName, _FPPSTemplateName,
                                    _WFPTemplateName, _RootNodeColor, _FPPSNodeColor, _WFPNodeColor, _PositionListFunctionName);

                script.Append(json.GetJSON(positionList, rootNode));
                script.Append("return positionItemList;");
            }

            script.Append("}");

            return script;
        }
        
        public void BindChart(ChartGenerationParameters generationParams, IList<IChartPosition> positionList, int rootNode)
        {
            try
            {
                // load resources
                loadResources();
                
                // get position list JSON
                StringBuilder scriptPositionList = this.getPositionListJSON(positionList, rootNode);

                // write to code block
                string varChartID = string.Format("var ctrlDisplay_srvChartID = {0}; ", generationParams.ID);
                string varChartType = string.Format("var ctrlDisplay_srvChartType = {0}; ", (int)generationParams.ChartType);

                scriptChartBlock.Controls.Add(new LiteralControl(string.Format("<script language=\"javascript\" type=\"text/javascript\">{0}{1}{2}</script>",
                                varChartID, varChartType, scriptPositionList.ToString())));
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
    }
}