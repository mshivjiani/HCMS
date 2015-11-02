using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Security;

namespace HCMS.Business.OrganizationChart
{
    [Serializable]
    public sealed class OrganizationChartLog : OrganizationChartBase
    {
        #region Properties

        public int OrganizationChartLogID { get; set; }
        public ActionUser ApprovedBy { get; set; }

        public string ApprovedBySignedName { get; set; }
        public string ApprovedByTitle { get; set; }
        public string ApprovedFor { get; set; }

        #endregion

        #region Constructors

        public OrganizationChartLog() : base()
        {
            this.OrganizationChartLogID = -1;
            this.ApprovedBySignedName = string.Empty;
            this.ApprovedByTitle = string.Empty;
            this.ApprovedFor = string.Empty;
        }

        #endregion
    }
}
