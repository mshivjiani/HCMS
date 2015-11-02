using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart;

namespace HCMS.OrgChart.Controls.OrgChart.Common
{
    public partial class orgChartDetailInformation : UserControlBase
    {
        #region Object Declarations

        private string _redirectSuffix = string.Empty;
        private bool _showViewPublishedChartLink = true;
        private bool _showAbolishedPositionsLink = true;
        private bool _showNewFPPSPositionsLink = true;
        private bool _showTopLevelPosition = true;

        #endregion

        #region Properties

        public string RedirectSuffix
        {
            get
            {
                return this._redirectSuffix;
            }
            set
            {
                this._redirectSuffix = value;
            }
        }

        public bool ShowViewPublishedChartLink
        {
            get
            {
                return this._showViewPublishedChartLink;
            }
            set
            {
                this._showViewPublishedChartLink = value;
            }
        }

        public bool ShowAbolishedPositionsLink
        {
            get
            {
                return this._showAbolishedPositionsLink;
            }
            set
            {
                this._showAbolishedPositionsLink = value;
            }
        }

        public bool ShowNewFPPSPositionsLink
        {
            get
            {
                return this._showNewFPPSPositionsLink;
            }
            set
            {
                this._showNewFPPSPositionsLink = value;
            }
        }

        public bool ShowTopLevelPosition
        {
            get
            {
                return this._showTopLevelPosition;
            }
            set
            {
                this._showTopLevelPosition = value;
            }
        }

        #endregion

        private void setView()
        {
            this.spanViewPublishedChart.Visible = this._showViewPublishedChartLink;

            this.divResolutions.Visible = this._showAbolishedPositionsLink || this._showNewFPPSPositionsLink;
            this.spanDivider.Visible = this._showAbolishedPositionsLink && this._showNewFPPSPositionsLink;

            this.spanAbolishedPositions.Visible = this._showAbolishedPositionsLink;
            this.spanNewFPPSPositions.Visible = this._showNewFPPSPositionsLink;
            this.rowTopLevelPosition.Visible = this._showTopLevelPosition;
        }

        private void buildLinks(OrganizationChart chart)
        {
            string lineItemURL = string.Empty;
            
            //if (!string.IsNullOrWhiteSpace(this._redirectSuffix))
            //    lineItemURL = string.Format("?rdr={0}", this._redirectSuffix);

            this.linkViewOrganizationChart.NavigateUrl = string.Format("~/OrgChart/ViewChart.aspx{0}", lineItemURL);
            this.linkViewPublishedChart.NavigateUrl = string.Format("~/OrgChart/ViewPubChart.aspx{0}", lineItemURL);
            this.linkAbolishedPositions.NavigateUrl = string.Format("~/OrgChart/AbolishedPositions.aspx{0}", lineItemURL);
            this.linkNewFPPSPositions.NavigateUrl = string.Format("~/OrgChart/NewFPPSPositions.aspx{0}", lineItemURL);
        }

        public void BindData(OrganizationChart chart)
        {
            try
            {
                bool containsData = (chart != null);
                this.Visible = containsData;

                if (containsData)
                {
                    setView();
                    buildLinks(chart);

                    this.customOrgChartValidations.BindData(chart);

                    this.literalAbolishedCount.Text = chart.AbolishedPositionCount == 0 ? "0" : string.Format(GetLocalResourceObject("AbolishedCountLineItem").ToString(), chart.AbolishedPositionCount);
                    this.literalNewFPPSCount.Text = chart.NewFPPSPositionCount.ToString();

                    this.literalOrganizationChartID.Text = chart.OrganizationChartID.ToString();
                    this.literalChartType.Text = chart.OrganizationChartTypeName;
                    this.literalOrganizationNameLineItem.Text = chart.OrgCode.NewOrgCodeLine; // chart.OrganizationName;

                    if (chart.StartPointWFPPositionID == -1)
                        this.literalTopLevelPosition.Text = GetLocalResourceObject("NoRootPositionSpecified").ToString();
                    else
                        this.literalTopLevelPosition.Text = chart.StartPointPositionLineItemFullName;

                    // only show if there is a published version in the database
                    bool hasPubVersion = (chart.PublishedOrganizationChartLogID != -1);

                    this.linkViewPublishedChart.Visible = hasPubVersion;
                    this.literalNoPublishedChartOnRecord.Visible = !hasPubVersion;
                }
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }
    }
}