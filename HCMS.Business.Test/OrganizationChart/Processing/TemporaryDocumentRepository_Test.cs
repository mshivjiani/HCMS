using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCMS.Business.OrganizationChart.Processing;

namespace HCMS.Business.Test.OrganizationChart.Processing
{
    [TestClass]
    public class TemporaryDocumentRepository_Test
    {
        [TestMethod]
        public void TemporaryDocumentRepository_GetByID()
        {
            TemporaryDocument document = TemporaryDocumentRepository.Instance.GetByID(Guid.Parse("A46E69CB-93BD-499A-90D4-93F0164762BD"), 1);

            Assert.IsNotNull(document);
            Assert.IsTrue(document.DocumentID != Guid.Empty);
        }
    }
}
