using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Search;

namespace HCMS.Business.Test.OrganizationChart.Search
{
    [TestClass]
    public class OrgChartSearchManager_Test : OrganizationManagerTestBase
    {
        [TestMethod]
        public void OrgChartSearchManager_LoadSearchResults()
        {
            //List<OrgChartSearchResult> resultList = OrgChartSearchManager.Instance.LoadSearchResults();

            //Assert.IsNotNull(resultList, "ResultList is null");
            //Assert.IsTrue(resultList.Count > 0, "ResultList is empty");
        }

        public void OrgChartSearchManager_DataFiller_NONTest()
        {
            CreateOrgChartNew("Org Chart Search Test", 1488, enumOrgChartType.SingleOrg, 9);
            CreateOrgChartNew("Org Chart Search Test 1", 1488, enumOrgChartType.MultiOrg, 13);
            CreateOrgChartNew("Org Chart Search Test 2",1489, enumOrgChartType.SingleOrg, 9);
            //CreateOrgChart("Org Chart Search Test 3", 1433, enumOrgChartType.MultiOrg, 9);
            CreateOrgChartNew("Org Chart Search Test 4", 1433, enumOrgChartType.SingleOrg, 13);
            
        }
    }
}
