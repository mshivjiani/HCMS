using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart.Positions;

namespace HCMS.OrgChart.Controls.Positions.Common
{
    public partial class ctrlFPPSPositionInformation : UserControlBase
    {
        private string _NotSpecifiedLine = string.Empty;

        private void setCleanLine(Literal literalItem, string fieldData)
        {
            literalItem.Text = (string.IsNullOrWhiteSpace(fieldData)) ? _NotSpecifiedLine : HttpUtility.HtmlEncode(fieldData);
        }

        public void BindData(IWorkforcePlanningPosition position)
        {
            try
            {
                _NotSpecifiedLine = GetLocalResourceObject("DataNotSpecified").ToString();
                bool isChartPosition = position is OrganizationChartPosition;
                loadData(position, isChartPosition);
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }

        private void loadData(IWorkforcePlanningPosition position, bool isChartPosition)
        {
            this.literalOrgCode.Text = string.Format("{0} | {1}", HttpUtility.HtmlEncode(position.OrganizationCode), HttpUtility.HtmlEncode(position.OrganizationName)).Trim();
            this.literalPositionTitle.Text = HttpUtility.HtmlEncode(position.PositionTitle);

            if (position.PositionStatusHistory.HasValue && position.PositionStatusHistory.Value == (int)enumOrgPositionStatusHistoryType.ActiveEmployee)
            {
                this.literalPositionStatus.Text = GetLocalResourceObject("PositionStatusHistoryEncumberedMessage").ToString();
                setCleanLine(this.literalFullName, position.FullName);
            }
            else
            {
                this.literalPositionStatus.Text = GetLocalResourceObject("PositionStatusHistoryVacantMessage").ToString(); ;
                this.rowFullName.Visible = false;
            }

            // rules for employment status 
            if (position.eWorkScheduleType == enumWorkScheduleType.F_FULL_TIME && position.eAppointmentType == enumAppointmentType.CAREER_COMP_SVC_PERM)
                rowEmploymentStatus.Visible = false;
            else
                setCleanLine(this.literalEmploymentStatus, position.EmploymentStatus);

            setCleanLine(this.literalPayPlan, position.PayPlanAbbreviation);
            setCleanLine(this.literalSeries, position.PaddedSeriesID);
            setCleanLine(this.literalFPLGrade, (position.FPLGrade == -1 ? string.Empty : position.FPLGrade.ToString()));
            setCleanLine(this.literalCurrentGrade, (position.Grade == -1 ? string.Empty : position.Grade.ToString()));
            setCleanLine(this.literalDutyStationCountry, position.DutyStationCountryName);

            this.rowDutyStationState.Visible = (position.DutyStationCountryID == (int)enumCountries.UnitedStates);
            setCleanLine(this.literalDutyStationState, position.DutyStationStateName);
            setCleanLine(this.literalDutyStationCity, position.DutyStationDescription);

            setCleanLine(this.literalPositionTypesSupervisoryStatus, position.SupervisorStatusTitle);
            setCleanLine(this.literalOrganizationPositionType, position.OrgPositionType);
        }
    }
}