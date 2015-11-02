using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart.Positions;

namespace HCMS.OrgChart.Controls.Common
{
    public partial class ctrlFPPSPositionInformation : UserControlBase
    {
        private string _NotSpecifiedLine = string.Empty;
        private string _NotApplicableLine = string.Empty;
        private string _PositionNumberBaseSuffixFormatString = string.Empty;
        private string _SeriesLineItem = string.Empty;
        private bool _showReportsToPosition = true;
        private bool _showOrganizationPositionType = true;

        #region Properties

        public bool ShowReportsToPosition
        {
            get
            {
                return this._showReportsToPosition;
            }
            set
            {
                this._showReportsToPosition = value;
            }
        }

        public bool ShowOrganizationPositionType
        {
            get
            {
                return this._showOrganizationPositionType;
            }
            set
            {
                this._showOrganizationPositionType = value;
            }
        }

        #endregion
                
        private void setCleanLine(Literal literalItem, string fieldData)
        {
            literalItem.Text = (string.IsNullOrWhiteSpace(fieldData)) ? _NotSpecifiedLine : HttpUtility.HtmlEncode(fieldData);
        }

        private void loadResources()
        {
            _NotSpecifiedLine = GetLocalResourceObject("DataNotSpecified").ToString();
            _NotApplicableLine = GetLocalResourceObject("NotApplicableMessage").ToString();
            _PositionNumberBaseSuffixFormatString = GetLocalResourceObject("PositionNumberBaseSuffixFormatString").ToString();
            _SeriesLineItem = GetLocalResourceObject("SeriesLineItem").ToString();
        }

        public void BindData(IWorkforcePlanningPosition position, int rootStartingPositionID)
        {
            try
            {
                loadResources();

                bool isChartPosition = position is OrganizationChartPosition;
                loadData(position, rootStartingPositionID, isChartPosition);
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }

        private void loadData(IWorkforcePlanningPosition position, int rootStartingPositionID, bool isChartPosition)
        {
            this.literalOrgCode.Text = string.Format("{0} | {1}", HttpUtility.HtmlEncode(position.OrganizationCode), HttpUtility.HtmlEncode(position.OrganizationName)).Trim();
            this.literalPositionTitle.Text = HttpUtility.HtmlEncode(position.PositionTitle);

            if (position.PositionStatusHistory.HasValue && position.PositionStatusHistory.Value == (int)enumOrgPositionStatusHistoryType.ActiveVacant)
            {
                this.literalPositionStatus.Text = GetLocalResourceObject("PositionStatusHistoryVacantMessage").ToString(); ;
                this.rowFullName.Visible = false;
            }
            else
            {
                this.literalPositionStatus.Text = GetLocalResourceObject("PositionStatusHistoryEncumberedMessage").ToString();
                setCleanLine(this.literalFullName, position.FullName);
            }

            // rules for employment status 
            if (position.eWorkScheduleType == enumWorkScheduleType.F_FULL_TIME && position.eAppointmentType == enumAppointmentType.CAREER_COMP_SVC_PERM)
                rowEmploymentStatus.Visible = false;
            else
                setCleanLine(this.literalEmploymentStatus, position.EmploymentStatus);

            string baseSuffixLine = string.Empty;

            if (string.IsNullOrWhiteSpace(position.PositionNumberBase) && string.IsNullOrWhiteSpace(position.PositionNumberSuffix))
                baseSuffixLine = _NotApplicableLine;
            else
                baseSuffixLine = string.Format(_PositionNumberBaseSuffixFormatString, position.PositionNumberBase, position.PositionNumberSuffix);

            setCleanLine(this.literalPNBPNS, baseSuffixLine);
            setCleanLine(this.literalPayPlan, position.PayPlanAbbreviation);
            setCleanLine(this.literalSeries, string.Format(_SeriesLineItem, position.SeriesName, position.PaddedSeriesID));
            setCleanLine(this.literalFPLGrade, (position.FPLGrade == -1 ? string.Empty : position.FPLGrade.ToString()));
            setCleanLine(this.literalCurrentGrade, (position.Grade == -1 ? string.Empty : position.Grade.ToString()));
            setCleanLine(this.literalDutyStationCountry, position.DutyStationCountryName);

            this.rowDutyStationState.Visible = (position.DutyStationCountryID == (int)enumCountries.UnitedStates);
            setCleanLine(this.literalDutyStationState, position.DutyStationStateName);
            setCleanLine(this.literalDutyStationCity, position.DutyStationDescription);

            setCleanLine(this.literalPositionTypesSupervisoryStatus, position.SupervisorStatusTitle);
            setCleanLine(this.literalOrganizationPositionType, position.OrgPositionType);
            setCleanLine(this.literalCurrentlyReportsToName, position.ReportsToFullNameReverse);
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.rowReportsToPosition.Visible = this._showReportsToPosition;
            this.rowOrganizationPositionType.Visible = this._showOrganizationPositionType;
            base.OnPreRender(e);
        }
    }
}