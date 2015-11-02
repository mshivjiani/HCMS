using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OC = HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.OrganizationChart.Positions.Collections;

namespace HCMS.Business.Test.OrganizationChart.Positions
{
    [TestClass]
    public class OrganizationChartPositionManager_Test : OrganizationManagerTestBase
    {
        private const int testChartID = 10012;
        private const int testPositionID = 8221;

        [TestMethod]
        public void OrganizationChartPositionManager_GetByID()
        {
            OrganizationChartPosition position = OrganizationChartPositionManager.Instance.GetByID(testChartID, testPositionID);
            Assert.IsNotNull(position, "Chart Position is null");
            Assert.IsTrue(position.WFPPositionID != -1, "Position ID is == -1");
        }

        [TestMethod]
        public void OrganizationChartPositionManager_GetOrganizationChartPositions()
        {
            OrganizationChartPositionCollection positionList = OrganizationChartPositionManager.Instance.GetOrganizationChartPositions(testChartID);
            Assert.IsNotNull(positionList, "PositionList Collection is null");
            Assert.IsTrue(positionList.Count > 0, "Empty PositionList Collection");
        }
        
        [TestMethod]
        public void OrganizationChartPositionManager_Add()
        {
            const int testOrgCodeID = 15;
            int newOrgChartID = -1;
            int primaryUserID = 1;
            enumOrgChartType selectedChartType = enumOrgChartType.SingleOrg;

            try
            {
                OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByOrgCodeAndChartType(testOrgCodeID, selectedChartType);

                if (chart.OrganizationChartID == -1)
                    newOrgChartID = CreateOrgChartNew("OrganizationChartPositionManager_Add", testOrgCodeID, selectedChartType, primaryUserID);
                else
                    newOrgChartID = chart.OrganizationChartID;

                chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
                
                Assert.IsNotNull(chart, "Organization Chart is null");
                Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");

                // now add position
                OrganizationChartPosition newPosition = new OrganizationChartPosition()
                {
                    OrganizationChartID = newOrgChartID,
                    OrganizationCodeID = testOrgCodeID,
                    CreatedByID = primaryUserID,
                    PositionTitle = "Generated Position Title"
                };

                OrganizationChartPositionManager.Instance.Add(newPosition);

                // try to find position
                OrganizationChartPosition position = OrganizationChartPositionManager.Instance.GetByID(newOrgChartID, newPosition.WFPPositionID);

                Assert.IsTrue(position.WFPPositionID != -1, "Position Not Created");

                WorkforcePlanningPositionManager.Instance.Delete(position.WFPPositionID, newOrgChartID,primaryUserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DeleteChart(newOrgChartID);
            }
        }

        [TestMethod]
        public void OrganizationChartPositionManager_UpdateFPPS()
        {

        }

        [TestMethod]
        public void OrganizationChartPositionManager_UpdateWFP()
        {

        }
    }
}
