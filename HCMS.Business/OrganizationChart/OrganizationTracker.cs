using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;

namespace HCMS.Business.OrganizationChart
{
    class OrganizationTracker : BusinessBase
    {
        public int OrganizationChartID { get; set; }
		public int OrganizationChartTypeID { get; set; }
		public int OrganizationCodeID ;
        public int CheckedOutByID { get; set; }
        public int LevelID { get; set; }
        public int CreatedByID { get; set; }
        public int OrgWorkflowStatusID { get; set; }
        public int UpdateByID { get; set; }
        public int RegionID { get; set; }

        public string Introduction { get; set; }
        public string ReportingOrganizationCode { get; set; }
        public string OldOrganizationCode { get; set; } 
        public string OrgWorkflowStatus { get; set; }
        public string Header1 { get; set; }
        public string Header2 { get; set; }
        public string Header3 { get; set; }
        public string Header4 { get; set; }
        public string Footer { get; set; }
        public string OrganizationCode { get; set; }
        public string OrganizationName { get; set; } 

        public DateTime CreateDate { get; set; }
        public DateTime OrgWorkflowStatusCreateDate { get; set; }
        public DateTime CheckedOutByDate { get; set; }
        public DateTime UpdatedByDate { get; set; }

	    public bool	CanEdit { get; set; }
	    public bool CanContinueEdit { get; set; }
	    public bool CanFinishEdit { get; set; }
	    public bool CanViewOnly { get; set; }
        public bool CheckedOut { get; set; }

       
    }
}
