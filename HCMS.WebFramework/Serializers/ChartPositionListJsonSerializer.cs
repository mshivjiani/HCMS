using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.OrganizationChart;
using System.Web.Helpers;
using HCMS.Business.Common;

namespace HCMS.WebFramework.Serializers
{
    public class ChartPositionListJsonSerializer
    {
        #region Object Declarations

        private string _WPFVacantPhrase = string.Empty;
        private string _FPPSVacantPhrase = string.Empty;
        private string _RootTemplateName = string.Empty;
        private string _FPPSTemplateName = string.Empty;
        private string _WFPTemplateName = string.Empty;
        private string _RootNodeColor = string.Empty;
        private string _FPPSNodeColor = string.Empty;
        private string _WFPNodeColor = string.Empty;
        private string _PositionListFunctionName = string.Empty;

        #endregion

        #region Constructors

        public ChartPositionListJsonSerializer (string loadWPFVacantPhrase, string loadFPPSVacantPhrase, string loadRootTemplateName, string loadFPPSTemplateName,
                        string loadWFPTemplateName, string loadRootNodeColor, string loadFPPSNodeColor, string loadWFPNodeColor, string loadPositionListFunctionName)
        {
            _WPFVacantPhrase = loadWPFVacantPhrase;
            _FPPSVacantPhrase = loadFPPSVacantPhrase;
            _RootTemplateName = loadRootTemplateName;
            _FPPSTemplateName = loadFPPSTemplateName;
            _WFPTemplateName = loadWFPTemplateName;
            _RootNodeColor = loadRootNodeColor;
            _FPPSNodeColor = loadFPPSNodeColor;
            _WFPNodeColor = loadWFPNodeColor;
            _PositionListFunctionName = loadPositionListFunctionName;
        }

        #endregion

        public string GetJSON(IList<IChartPosition> positionList, int chartRootNodeID)
        {
            StringBuilder scriptPositionList = this.getPositionListJSON(positionList, chartRootNodeID);
            return scriptPositionList.ToString();
        }

        private string cleanLine(string value)
        {
            return Json.Encode(value);
        }

        private string getCalculatedPositionName(IChartPosition position)
        {
            string nameValue = position.FullNameReverse;

            if (position.PositionStatusHistory.HasValue && position.PositionStatusHistory.Value == (int)enumOrgPositionStatusHistoryType.ActiveVacant)
            {
                if (position.ChartPositionType == enumChartPositionType.FPPS)
                    nameValue = _FPPSVacantPhrase;
                else if (position.ChartPositionType == enumChartPositionType.WFP)
                    nameValue = _WPFVacantPhrase;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(position.FullName))
                    nameValue = _FPPSVacantPhrase;
            }

            return nameValue;
        }

        private string getEmploymentStatus(IChartPosition position)
        {
            string employmentStatus = string.Empty;

            if (position.eWorkScheduleType != enumWorkScheduleType.F_FULL_TIME || position.eAppointmentType != enumAppointmentType.CAREER_COMP_SVC_PERM)
                employmentStatus = position.EmploymentStatus;

            return employmentStatus;
        }

        private StringBuilder getPositionListJSON(IList<IChartPosition> positionList, int rootNode)
        {
            StringBuilder json = new StringBuilder();

            json.Append("[");

            // 0: Node Color
            // 1: templateName 
            // 2: GroupTypeName: Auto, Left, Right 
            // 3: PlacementTypeName: Regular, Assistant, Advisor, SubAssistant, SubAdvisor, 
            // 4: WFPPositionID
            // 5: PaddedSeries
            // 6: ReportsToID
            // 7: PositionTitle
            // 8: FullName
            // 9: Position Title
            // 10: OrganizationCode
            // 11: OrganizationName
            // 12: Pay Plan Abbreviation
            // 13: Grade
            // 14: FPL
            // 15: Employment Status
            // 16: Additional Elements -- you must include leading comma
            const string lineItem = "new primitives.orgdiagram.ItemConfig({{ itemTitleColor: primitives.common.Colors.{0}, templateName: {1}, adviserPlacementType: primitives.common.AdviserPlacementType.{2}, " +
                            "itemType: primitives.orgdiagram.ItemType.{3}, id: {4}, " +
                            "series: {5}, parent: {6}, title: {7}, fullName: {8}, positionTitle: {9}, orgCode: {10}, " +
                            "orgDescription: {11}, payPlan: {12}, grade: {13}, fpl: {14}, gradefpl: {15}, workScheduleType: {16}{17}}})";
            bool firstLineRendered = false;

            foreach (IChartPosition position in positionList)
            {
                if (firstLineRendered)
                    json.Append(", ");

                string nodeColor = string.Empty;
                string templateName = string.Empty;
                string additionalElements = string.Empty;
                string parentPositionID = position.ReportsToID.ToString();

                if (position.WFPPositionID == rootNode)
                {
                    // root node -- set color based on whether it is WFP (Red) or if not use standard Root Node Color (Black)
                    nodeColor = (string.IsNullOrWhiteSpace(position.PositionNumberBase) && string.IsNullOrWhiteSpace(position.PositionNumberSuffix)) ? _WFPNodeColor : _RootNodeColor;
                    templateName = this._RootTemplateName;
                    additionalElements = ", childrenPlacementType: primitives.common.ChildrenPlacementType.Horizontal";
                    parentPositionID = "null";
                }
                else
                {
                    additionalElements = ", childrenPlacementType: primitives.common.ChildrenPlacementType.Matrix";

                    if (position.ChartPositionType == enumChartPositionType.FPPS)
                    {
                        // FPPS Position
                        nodeColor = _FPPSNodeColor;
                        templateName = this._FPPSTemplateName;
                    }
                    else
                    {
                        // WFP (and everything else -- if it exists)
                        nodeColor = _WFPNodeColor;
                        templateName = this._WFPTemplateName;
                    }
                }

                string recordEntry = string.Format(lineItem,
                        nodeColor, // 0:
                        cleanLine(templateName), // 1:
                        EnumHelper<enumOrgPositionGroupType>.GetEnumDescription(position.PositionGroupType.ToString()), // 2:
                        EnumHelper<enumOrgPositionPlacementType>.GetEnumDescription(position.PositionPlacementType.ToString()), // 3:
                        position.WFPPositionID, // 4:
                        cleanLine(position.PaddedSeriesID), // 5:
                        parentPositionID, // 6:
                        cleanLine(position.PositionTitle), // 7:
                        cleanLine(getCalculatedPositionName(position)), // 8:
                        cleanLine(position.PositionTitle), // 9:
                        cleanLine(position.OrganizationCode), // 10:
                        cleanLine(position.OrganizationName), // 11:
                        cleanLine(position.PayPlanAbbreviation), // 12:
                        cleanLine(position.Grade.ToString()), // 13:
                        cleanLine(position.FPLGrade.ToString()), // 14: 
                        cleanLine(position.GradeFPLLineItem), // 15:
                        cleanLine(getEmploymentStatus(position)), // 16:
                        additionalElements // 17:
                    );
                json.Append(recordEntry);
                firstLineRendered = true;
            }

            json.Append("];");
            return json;
        }
    }
}
