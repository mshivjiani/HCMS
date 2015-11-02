using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCMS.Business.OrganizationChart.Published.Positions;

namespace HCMS.Business.Test.OrganizationChart.Published
{
    [TestClass]
    public class OrganizationChartPositionLogManager_Test : OrganizationManagerTestBase
    {
        private const int testChartLogID = 1;
        private const int testPositionID = 13798;

        [TestMethod]
        public void OrganizationChartPositionLOGManager_GetByID()
        {
            OrganizationChartPositionLog position = OrganizationChartPositionLogManager.Instance.GetByID(testChartLogID, testPositionID);

            Assert.IsNotNull(position, "Chart Position is null");
            Assert.IsTrue(position.OrganizationChartLogID != -1, "OrgChartLogID == -1");
            Assert.IsTrue(position.WFPPositionID != -1, "Position ID is == -1");
        }

        [TestMethod]
        public void OrganizationChartPositionLOGManager_GetOrganizationChartPositions()
        {
            IList<OrganizationChartPositionLog> positionList = OrganizationChartPositionLogManager.Instance.GetOrganizationChartPositionLogs(testChartLogID);

            Assert.IsNotNull(positionList, "PositionList Collection is null");
            Assert.IsTrue(positionList.Count > 0, "Empty PositionList Collection");
        }

        [TestMethod]
        public void OrganizationChartPositionLOGManager_GetSubordinateOrganizationChartPositionLogsByParent()
        {
            IList<OrganizationChartPositionLog> positionList = OrganizationChartPositionLogManager.Instance.GetSubordinateOrganizationChartPositionLogsByParent(testChartLogID, testPositionID);

            Assert.IsNotNull(positionList, "PositionList Collection is null");
            Assert.IsTrue(positionList.Count > 0, "Empty PositionList Collection");
        }
    }
}
