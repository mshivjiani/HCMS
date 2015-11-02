using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCMS.Business.Lookups.Repositories;
using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Test.Lookups
{
    [TestClass]
    public class LookupManager_Test
    {
        [TestMethod]
        public void LookupManager_GetCountries()
        {
            IList<Country> list = CountryRepository.Instance.GetCountries();

            Assert.IsNotNull(list, "Country list is null");
            Assert.IsTrue(list.Count > 0, "Country list is empty");
        }

        [TestMethod]
        public void LookupManager_GetOrgChartTypes()
        {
            OrgChartTypeCollection list = OrgChartTypeRepository.Instance.GetAllOrgChartTypes();

            Assert.IsNotNull(list, "OrgChartType list is null");
            Assert.IsTrue(list.Count > 0, "OrgChartType list is empty");
        }

        [TestMethod]
        public void LookupManager_GetPositionGroupTypes()
        {
            IList<OrgPositionGroupType> list = OrgPositionGroupTypeRepository.Instance.GetPositionGroupTypes();

            Assert.IsNotNull(list, "OrgPositionGroupType list is null");
            Assert.IsTrue(list.Count > 0, "OrgPositionGroupType list is empty");
        }

        [TestMethod]
        public void LookupManager_GetPositionPlacementTypes()
        {
            IList<OrgPositionPlacementType> list = OrgPositionPlacementTypeRepository.Instance.GetPositionPlacementTypes();

            Assert.IsNotNull(list, "OrgPositionGroupType list is null");
            Assert.IsTrue(list.Count > 0, "OrgPositionGroupType list is empty");
        }
    }    
}
