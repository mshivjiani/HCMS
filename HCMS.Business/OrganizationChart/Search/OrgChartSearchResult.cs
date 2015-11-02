using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;
using System.Collections;

namespace HCMS.Business.OrganizationChart
{  
    [Serializable]
    public class OrgChartSearchResult : BusinessBase
    {
        #region Object Declarations

        public IOrganizationChart ChartEntity = null;

        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanContinueEdit { get; set; }
        public bool CanFinishEdit { get; set; }
        public bool CanViewOnly { get; set; }
        public bool IsCheckedOut { get; set; } 

        #endregion

        #region Constructors

        public OrgChartSearchResult()
        {
            // set defaults
            this.CanEdit = false;
            this.CanDelete = false;
            this.CanContinueEdit = false;
            this.CanFinishEdit = false;
            this.CanViewOnly = false;
            this.IsCheckedOut = false;
        }

        #endregion
    }
}
