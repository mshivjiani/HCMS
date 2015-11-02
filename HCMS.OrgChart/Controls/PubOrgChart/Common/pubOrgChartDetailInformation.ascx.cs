using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Published;

namespace HCMS.OrgChart.Controls.PubOrgChart.Common
{
    public partial class pubOrgChartDetailInformation : UserControlBase
    {
        #region Object Declarations

        private bool _showViewPublishedChartLink = true;

        #endregion

        #region Properties

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

        #endregion

        public void BindData(OrganizationChartLog chartLog)
        {
            try
            {
                loadData(chartLog);
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }

        private void loadData(OrganizationChartLog chartLog)
        {
            this.panelHeaderLinks.Visible = this._showViewPublishedChartLink;
                                    
          //  this.literalChartOrganizationLogID.Text = chartLog.OrganizationChartLogID.ToString();
            this.literalOrganizationChartID.Text = chartLog.OrganizationChartID.ToString();
            this.literalChartType.Text = chartLog.OrganizationChartTypeName;
            this.literalOrganizationName.Text = string.Format("{0} ({1})", chartLog.OrganizationName, chartLog.OrgCode.OrganizationCodeValue);

            string mailAddressLineItem = GetLocalResourceObject("NullMailAddressLineItem").ToString();

            if (chartLog.OrgCode != null && (!string.IsNullOrWhiteSpace(chartLog.OrgCode.MailCity) || !string.IsNullOrWhiteSpace(chartLog.OrgCode.MailStateAbbr)))
            {
                if (string.IsNullOrWhiteSpace(chartLog.OrgCode.MailCity))
                    // MailCity is null -- use State
                    mailAddressLineItem = chartLog.OrgCode.MailStateAbbr;
                else if (string.IsNullOrWhiteSpace(chartLog.OrgCode.MailStateAbbr))
                    // MailState is null -- use city
                    mailAddressLineItem = chartLog.OrgCode.MailCity;
                else
                    // use both
                    mailAddressLineItem = string.Format("{0}, {1}", chartLog.OrgCode.MailCity, chartLog.OrgCode.MailStateAbbr);
            }

            this.literalOrgCodeLocation.Text = mailAddressLineItem;

            string topPositionLineItem = string.Empty;

            if (chartLog.StartPointWFPPositionID == -1)
                topPositionLineItem = GetLocalResourceObject("NoTopLevelPositionMessage").ToString();
            else
                topPositionLineItem = chartLog.StartPointPositionLineItemFullName;

            this.literalTopLevelPosition.Text = topPositionLineItem;
            this.literalWorkflowStatus.Text = chartLog.OrgWorkflowStatusName;

            if (chartLog.CreatedBy != null)
            {
                bool hasCreatedByName = !string.IsNullOrWhiteSpace(chartLog.CreatedBy.FullName);
                this.rowCreatedOn.Visible = chartLog.CreatedBy.ActionDate.HasValue;
                this.rowCreatedBy.Visible = hasCreatedByName;

                if (chartLog.CreatedBy.ActionDate.HasValue)
                    this.literalCreatedDate.Text = chartLog.CreatedBy.ActionDate.Value.ToString();

                if (hasCreatedByName)
                    this.literalCreatedByFullName.Text = chartLog.CreatedBy.FullName;
            }

            if (chartLog.UpdatedBy != null)
            {
                bool hasLastUpdatedName = !string.IsNullOrWhiteSpace(chartLog.UpdatedBy.FullName);
                this.rowUpdatedOn.Visible = chartLog.UpdatedBy.ActionDate.HasValue;
                this.rowUpdatedBy.Visible = hasLastUpdatedName;

                if (chartLog.UpdatedBy.ActionDate.HasValue)
                    this.literalLastUpdated.Text = chartLog.UpdatedBy.ActionDate.Value.ToString();

                if (hasLastUpdatedName)
                    this.literalLastUpdatedBy.Text = chartLog.UpdatedBy.FullName;
            }
        }
    }
}