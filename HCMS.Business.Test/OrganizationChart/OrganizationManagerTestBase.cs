using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OC = HCMS.Business.OrganizationChart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCMS.Business.Lookups;
using HCMS.Business.Security;

namespace HCMS.Business.Test.OrganizationChart
{
    public abstract class OrganizationManagerTestBase
    {
        protected int CreateOrgChartNew(string title, int orgCodeID, enumOrgChartType chartType, int createdByUserID)
        {
            OC.OrganizationChart newChart = new OC.OrganizationChart()
            {
                OrgCode = new OrganizationCode()
                {
                    OrganizationCodeID = orgCodeID
                },
                OrganizationChartTypeID = chartType,
                CreatedBy = new ActionUser(createdByUserID),
                Header1 = title,
                Header2 = string.Format("Generated on {0}", DateTime.Now)
            };

            int newOrgChartID = OC.OrganizationChartManager.Instance.CreateNew(newChart);

            Assert.IsTrue(newOrgChartID != -1, "Organization Chart not Created");
            Console.WriteLine(string.Concat("New Org Chart: ", newOrgChartID));

            return newOrgChartID;
        }

        protected void DeleteChart(int chartID)
        {
            // now delete it -- we don't need it anymore
            OC.OrganizationChartManager.Instance.Delete(chartID);

            Console.WriteLine(string.Format("Attempting to Delete Chart: {0}", chartID));

            // now try to find it one last time
            OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(chartID);
            Assert.IsNotNull(chartFinalCheck, "Organization Chart was not Deleted");
            Assert.IsTrue(chartFinalCheck.OrganizationChartID == -1);

            Console.WriteLine(string.Format("Final -- Chart: {0} Deleted", chartID));
        }
    }
}
