using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Positions;

namespace HCMS.Business.Test.OrganizationChart
{
    [TestClass]
    public class OrganizationChartPositionManager_Test
    {
        [TestMethod]
        public void OrganizationChartPositionManager_GetByID()
        {
            const int testChartID = 1007;
            const int testPositionID = 622;

            OrganizationChartPosition position = OrganizationChartPositionManager.Instance.GetByID(testChartID, testPositionID);
            Assert.IsNotNull(position, "Chart Position is null");
            Assert.IsTrue(position.WFPPositionID != -1, "Position ID is == -1");
            Assert.IsTrue(!string.IsNullOrWhiteSpace(position.PositionTitle), "Position has no title");
        }
    }
}
