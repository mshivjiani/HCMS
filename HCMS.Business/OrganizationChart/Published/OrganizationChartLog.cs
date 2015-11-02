using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Security;
using HCMS.Business.OrganizationChart;

namespace HCMS.Business.OrganizationChart.Published
{
    [Serializable]
    public sealed class OrganizationChartLog : OrganizationChartBase
    {
        #region Properties

        public int OrganizationChartLogID { get; set; }
        public ActionUser ApprovedBy { get; set; }

        public string ApprovedByTitle { get; set; }
        public string ApprovedFor { get; set; }

        #endregion

        #region Constructors

        public OrganizationChartLog() : base()
        {
            this.OrganizationChartLogID = -1;
            this.ApprovedByTitle = string.Empty;
            this.ApprovedFor = string.Empty;
        }

        #endregion
    }
}
