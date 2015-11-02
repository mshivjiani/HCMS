using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.OrganizationChart.Positions.Collections;

namespace HCMS.Business.Test.OrganizationChart.Positions
{
    [TestClass]
    public class WFPPositionManager_Test
    {
        private const int testOrgChartID = 10011;
        private const int testReportToID = 5;

        [TestMethod]
        public void WFPPositionManager_GetByID()
        {
            WorkforcePlanningPosition wfp = WorkforcePlanningPositionManager.Instance.GetByID(1);

            Assert.IsNotNull(wfp, "No position with that ID was found.");
        }

        [TestMethod]
        public void WFPPositionManager_GetAbolishedPositionByID_NotFound()
        {
            WorkforcePlanningPosition wfp = WorkforcePlanningPositionManager.Instance.GetAbolishedPositionByID(555);

            Assert.IsNotNull(wfp, "Position is null.");
            Assert.IsTrue(wfp.WFPPositionID == -1, "Position mistakenly found");
        }

        [TestMethod]
        public void WFPPositionManager_GetAbolishedPositionByID()
        {
            WorkforcePlanningPosition wfp = WorkforcePlanningPositionManager.Instance.GetAbolishedPositionByID(15307);

            Assert.IsNotNull(wfp, "Position is null.");
            Assert.IsTrue(wfp.WFPPositionID != -1, "Position not found");
        }

        //[TestMethod]
        //public void WFPPositionManager_GetChildPositionsForInclusion()
        //{
        //    WorkforcePlanningPositionCollection positionList = WorkforcePlanningPositionManager.Instance.GetChildPositionsForInclusion(testReportToID);

        //    Assert.IsNotNull(positionList, "PositionList Collection is null");
        //    Assert.IsTrue(positionList.Count > 0, "Empty PositionList Collection");
        //}

        [TestMethod]
        public void WFPPositionManager_GetPotentialRootReplacementPositions()
        {
            WorkforcePlanningPositionCollection positionList = WorkforcePlanningPositionManager.Instance.GetPotentialRootReplacementPositions(testOrgChartID);

            Assert.IsNotNull(positionList, "PositionList Collection is null");
            Assert.IsTrue(positionList.Count > 0, "Empty PositionList Collection");
        }

        [TestMethod]
        public void WFPPositionManager_GetPositionsForInclusionInChart()
        {
            WorkforcePlanningPositionCollection positionList = WorkforcePlanningPositionManager.Instance.GetPositionsForInclusionInChart(testOrgChartID);

            Assert.IsNotNull(positionList, "PositionList Collection is null");
            Assert.IsTrue(positionList.Count > 0, "Empty PositionList Collection");
        }

        [TestMethod]
        public void WFPPositionManager_GetNewFPPSPositionsByOrganizationChart()
        {
            WorkforcePlanningPositionCollection positionList = WorkforcePlanningPositionManager.Instance.GetNewFPPSPositionsByOrganizationChart(testOrgChartID);

            Assert.IsNotNull(positionList, "PositionList Collection is null");
            Assert.IsTrue(positionList.Count > 0, "Empty PositionList Collection");
        }

        [TestMethod]
        public void WFPPositionManager_GetAbolishedPositionsByOrganizationChart()
        {
            WorkforcePlanningPositionCollection positionList = WorkforcePlanningPositionManager.Instance.GetAbolishedPositionsByOrganizationChart(testOrgChartID);

            Assert.IsNotNull(positionList, "PositionList Collection is null");
            Assert.IsTrue(positionList.Count > 0, "Empty PositionList Collection");
        }
    }
}
