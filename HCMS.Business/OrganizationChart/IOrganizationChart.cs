using System;

using HCMS.Business.Security;
using HCMS.Business.Lookups;

namespace HCMS.Business.OrganizationChart
{
    public interface IOrganizationChart
    {
        int OrganizationChartID { get; set; }
        enumOrgChartType OrganizationChartTypeID { get; set; }
        string OrganizationChartTypeName { get; set; }
        string OrganizationName { get; set; }
        int StartPointWFPPositionID { get; set; }
        string StartPointWFPFirstName { get; set; }
        string StartPointWFPLastName { get; set; }
        string StartPointWFPPositionTitle { get; set; }
        string StartPointWFPFullName { get; }
        string StartPointWFPFullNameReverse { get; }
        enumOrgPositionStatusHistoryType StartPointWFPPositionStatusHistory { get; set; }

        OrganizationCode OrgCode { get; set; }
        DateTime? OrgWorkflowStatusCreateDate { get; set;  }
        enumOrgWorkflowStatus OrgWorkflowStatusID { get; set; }
        string OrgWorkflowStatusName { get; set;  }

        string Header1 { get; set; }
        string Header2 { get; set; }
        string Header3 { get; set; }
        string Header4 { get; set; }
        string Footer { get; set; }
        
        ActionUser CreatedBy { get; set; }
        ActionUser UpdatedBy { get; set; }
    }
}
