using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.OrganizationChart.Search
{
    public enum enumOrgChartResultSortField
    {
        Undefined = -1,
        OrganizationChartID = 1,
        Region = 2,
        OrganizationCode = 3,
        CreatedByFNR = 4,
        CreateDate = 5,
        UpdatedByFNR = 6,
        UpdateDate = 7,
        WorkflowStatus = 8,
        ChartType=9
    }
    [Serializable]
    public class OrgChartSearchResultCollection : List<OrgChartSearchResult>
    {
        #region Constructors
        public OrgChartSearchResultCollection()
        {
            // Empty Constructor
        }

        public OrgChartSearchResultCollection(List<OrgChartSearchResult> loadList)
            : base(loadList)
        {
            // Empty Constructor
        }
        #endregion
        #region OrderByDelegates

        private int OrderByOrgChartID(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result1.ChartEntity.OrganizationChartID.CompareTo(result2.ChartEntity.OrganizationChartID);
        }
        private int OrderByOrgChartIDDesc(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result2.ChartEntity.OrganizationChartID.CompareTo(result1.ChartEntity.OrganizationChartID);
        }

        private int OrderByRegion(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result1.ChartEntity.OrgCode.RegionID.CompareTo(result2.ChartEntity.OrgCode.RegionID);
        }
        private int OrderByRegionDesc(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result1.ChartEntity.OrgCode.RegionID.CompareTo(result2.ChartEntity.OrgCode.RegionID);
        }
        private int OrderByOrganizationCode(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result1.ChartEntity.OrgCode.OrganizationCodeValue.CompareTo(result2.ChartEntity.OrgCode.OrganizationCodeValue);
        }
        private int OrderByOrganizationCodeDesc(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result2.ChartEntity.OrgCode.OrganizationCodeValue.CompareTo(result1.ChartEntity.OrgCode.OrganizationCodeValue);
        }
        private int OrderByCreatedByFNR(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result1.ChartEntity.CreatedBy.FullNameReverse.CompareTo(result2.ChartEntity.CreatedBy.FullNameReverse);
        }
        private int OrderByCreatedByFNRDesc(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result2.ChartEntity.CreatedBy.FullNameReverse.CompareTo(result1.ChartEntity.CreatedBy.FullNameReverse);
        }

        private int OrderByCreateDate(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result1.ChartEntity.CreatedBy.ActionDate.Value.CompareTo(result2.ChartEntity.CreatedBy.ActionDate.Value);
        }
        private int OrderByCreateDateDesc(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result2.ChartEntity.CreatedBy.ActionDate.Value.CompareTo(result1.ChartEntity.CreatedBy.ActionDate.Value);
        }

        private int OrderByUpdatedByFNR(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result1.ChartEntity.UpdatedBy.FullNameReverse.CompareTo(result2.ChartEntity.UpdatedBy.FullNameReverse);
        }
        private int OrderByUpdatedByFNRDesc(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result2.ChartEntity.UpdatedBy.FullNameReverse.CompareTo(result1.ChartEntity.UpdatedBy.FullNameReverse);
        }

        private int OrderByUpdateDate(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result1.ChartEntity.UpdatedBy.ActionDate.Value.CompareTo(result2.ChartEntity.UpdatedBy.ActionDate.Value);
        }
        private int OrderByUpdateDateDesc(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result2.ChartEntity.UpdatedBy.ActionDate.Value.CompareTo(result1.ChartEntity.UpdatedBy.ActionDate.Value);
        }

        private int OrderByOrgChartStatusID(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result1.ChartEntity.OrgWorkflowStatusID.CompareTo(result2.ChartEntity.OrgWorkflowStatusID);
        }
        private int OrderByOrgChartStatusIDDesc(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result2.ChartEntity.OrgWorkflowStatusID .CompareTo(result1.ChartEntity.OrgWorkflowStatusID);
        }
        private int OrderByOrgChartType(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result1.ChartEntity.OrganizationChartTypeName.CompareTo(result2.ChartEntity.OrganizationChartTypeName);
        }
        private int OrderByOrgChartTypeDESC(OrgChartSearchResult result1, OrgChartSearchResult result2)
        {
            return result2.ChartEntity.OrganizationChartTypeName.CompareTo(result1.ChartEntity.OrganizationChartTypeName);
        }
        #endregion
        public void OrderBy(enumOrgChartResultSortField field, enumSortDirection sortdirection)
        {
            switch (field)
            {
                case enumOrgChartResultSortField.Undefined:
                    break;
                case enumOrgChartResultSortField.OrganizationChartID:
                    if (sortdirection == enumSortDirection.DESC)
                    { this.Sort(OrderByOrgChartIDDesc); }
                    else
                    { this.Sort(OrderByOrgChartID); }
                    break;
                case enumOrgChartResultSortField.Region:
                    if (sortdirection == enumSortDirection.DESC)
                    { this.Sort(OrderByRegionDesc); }
                    else
                    { this.Sort(OrderByRegion); }
                    break;
                case enumOrgChartResultSortField.OrganizationCode:
                    if (sortdirection == enumSortDirection.DESC)
                    { this.Sort(OrderByOrganizationCodeDesc); }
                    else
                    { this.Sort(OrderByOrganizationCode); }
                    break;
                case enumOrgChartResultSortField.CreatedByFNR:
                    if (sortdirection == enumSortDirection.DESC)
                    { this.Sort(OrderByCreatedByFNRDesc); }
                    else
                    { this.Sort(OrderByCreatedByFNR); }
                    break;
                case enumOrgChartResultSortField.CreateDate:
                    if (sortdirection == enumSortDirection.DESC)
                    { this.Sort(OrderByCreateDateDesc); }
                    else
                    { this.Sort(OrderByCreateDate); }
                    break;
                case enumOrgChartResultSortField.UpdatedByFNR:
                    if (sortdirection == enumSortDirection.DESC)
                    { this.Sort(OrderByUpdatedByFNRDesc); }
                    else
                     { this.Sort(OrderByUpdatedByFNR); }
                    break;                    
                case enumOrgChartResultSortField.UpdateDate:
                    if (sortdirection == enumSortDirection.DESC)
                    { this.Sort(OrderByUpdateDateDesc); }
                    else
                    { this.Sort(OrderByUpdateDate); }
                    break;
                case enumOrgChartResultSortField.WorkflowStatus:
                    if (sortdirection == enumSortDirection.DESC)
                    { this.Sort(OrderByOrgChartStatusIDDesc); }
                    else
                    { this.Sort(OrderByOrgChartStatusID); }
                    break;
                case enumOrgChartResultSortField.ChartType :
                    if (sortdirection == enumSortDirection.DESC)
                    { this.Sort(OrderByOrgChartTypeDESC); }
                    else
                    { this.Sort(OrderByOrgChartType); }
                    break;
                default:
                    break;
            }
        }
    }
}
