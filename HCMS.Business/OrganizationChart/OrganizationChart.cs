using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Lookups;
using HCMS.Business.Security;

namespace HCMS.Business.OrganizationChart
{
    [Serializable]
    public sealed class OrganizationChart : OrganizationChartBase
    {
        #region Properties

        public int AbolishedPositionCount { get; set; }
        public int NewFPPSPositionCount { get; set; }
        public int BrokenHierarchyCount { get; set; }

        public ActionUser CheckedOutBy { get; set; }
        public int PublishedVersionCount { get; set; }
        public int PublishedOrganizationChartLogID { get; set; }
        public bool IsRootAcknowledged { get; set; }

        #endregion

        #region Constructors

        public OrganizationChart() : base()
        {
            this.AbolishedPositionCount = 0;
            this.NewFPPSPositionCount = 0;
            this.BrokenHierarchyCount = 0;

            this.PublishedVersionCount = 0;
            this.PublishedOrganizationChartLogID = -1;
            this.IsRootAcknowledged = false;
        }

        #endregion
    }
}
