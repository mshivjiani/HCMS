using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OC = HCMS.Business.OrganizationChart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCMS.Business.OrganizationChart.Published;

namespace HCMS.Business.Test.OrganizationChart
{
    [TestClass]
    public class OrganizationChartLogManager_Test : OrganizationManagerTestBase
    {
        [TestMethod]
        public void OrganizationChartLogManager_GetByID()
        {
            OrganizationChartLog chart = OrganizationChartLogManager.Instance.GetByID(2);

            Assert.IsNotNull(chart, "OrganizationChartLog is null");
            Assert.IsTrue(chart.OrganizationChartLogID == 2, "Organization Chart not found");
        }

        [TestMethod]
        public void OrganizationChartLogManager_GetOrganizationChartLogByOrgCodeAndChartType()
        {
            OrganizationChartLog chart = OrganizationChartLogManager.Instance.GetByOrgCodeAndChartType(4, enumOrgChartType.SingleOrg);

            Assert.IsNotNull(chart, "OrganizationChartLog is null");
            Assert.IsTrue(chart.OrganizationChartTypeID == enumOrgChartType.SingleOrg && chart.OrgCode.OrganizationCodeID == 4, "Organization Chart not found");
        }

        [TestMethod]
        public void OrganizationChartLogManager_GetOrgChartPublishedYear()
        {
            List<int> publishedYears = OrganizationChartLogManager.Instance.GetOrgChartPublishedYears();

            foreach (int year in publishedYears)
                Console.WriteLine(year);

            Assert.IsNotNull(publishedYears, "Published years collection is null");
            Assert.IsTrue(publishedYears.Count > 0, "Published years collection is empty");
        }

        //[TestMethod]
        //public void OrganizationChartLogManager_GetOrganizationChartLogsByOrgCode()
        //{
        //    const int testOrgCodeID = 4;
        //    int primaryUserID = 1;
        //    int approvedByUserID = 1;
        //    int newOrgChartID = CreateOrgChartNew("Test Generated -- Org Chart Creation", testOrgCodeID, enumOrgChartType.SingleOrg, primaryUserID);

        //    // now try to find it
        //    OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNotNull(chart, "Could not find Organization Chart");

        //    // now publish it
        //    int newOrgChartLogID = OC.OrganizationChartManager.Instance.Publish(chart, approvedByUserID, "Maria Johnson", "Executive Assistant'", "Mark W. Dallas");

        //    // now try to find the original chart again -- chart should not be here
        //    OC.OrganizationChart chartReFind = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNull(chartReFind, "Organization Chart not deleted -- still in tbl_OrganizationChart");

        //    // now try to find it by Org Code and Chart Type
        //    List<OC.OrganizationChartLog> chartList = OC.OrganizationChartLogManager.Instance.GetOrganizationChartLogsByOrgCode(testOrgCodeID);
        //    Assert.IsNotNull(chartList, "OrganizationChartLog List is null");
        //    Assert.IsTrue(chartList.Count > 0, "OrganizationChartLog List is empty");

        //    // now check to see if new chart is in list
        //    OC.OrganizationChartLog chartCheck = chartList.Find(IOCL => IOCL.OrganizationChartLogID == newOrgChartLogID);
        //    Assert.IsNotNull(chartCheck, "Could not find newly published chart (OrgChartLog) in returned chart list");
        //}

        [TestMethod]
        public void OrganizationChartLogManager_GetOrganizationChartLogsByUser()
        {
            int primaryUserID = 50;

            // now try to find it by user and workflow status
            List<OrganizationChartLog> chartListLog = OrganizationChartLogManager.Instance.GetOrganizationChartLogsByUser(primaryUserID);
            Assert.IsNotNull(chartListLog, "Organization Chart List is null");
            Assert.IsTrue(chartListLog.Count > 0, "Organization chart list is empty");
        }
    }
}
