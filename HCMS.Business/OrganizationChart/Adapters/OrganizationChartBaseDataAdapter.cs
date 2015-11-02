using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;
using HCMS.Business.Lookups;
using HCMS.Business.Security;

namespace HCMS.Business.OrganizationChart.Adapters
{
    public class OrganizationChartBaseDataAdapter<TEntity> : IEntityDataAdapter<TEntity>
        where TEntity : class, IOrganizationChart, new()
    {
        public virtual void Fill(DataRow dataItem, TEntity chart)
        {
            if (dataItem != null)
            {
                if (dataItem["OrganizationChartID"] != DBNull.Value)
                    chart.OrganizationChartID = (int)dataItem["OrganizationChartID"];

                if (dataItem["OrganizationChartTypeID"] != DBNull.Value)
                {
                    if (Enum.IsDefined(typeof(enumOrgChartType), dataItem["OrganizationChartTypeID"]))
                        chart.OrganizationChartTypeID = (enumOrgChartType)((int)dataItem["OrganizationChartTypeID"]);
                }

                if (dataItem["OrganizationName"] != DBNull.Value)
                    chart.OrganizationName = dataItem["OrganizationName"].ToString();

                if (dataItem["OrganizationChartType"] != DBNull.Value)
                    chart.OrganizationChartTypeName = dataItem["OrganizationChartType"].ToString();

                if (dataItem["StartPointWFPPositionID"] != DBNull.Value)
                    chart.StartPointWFPPositionID = (int)dataItem["StartPointWFPPositionID"];

                if (dataItem["StartPointWFPFirstName"] != DBNull.Value)
                    chart.StartPointWFPFirstName = dataItem["StartPointWFPFirstName"].ToString();

                if (dataItem["StartPointWFPLastName"] != DBNull.Value)
                    chart.StartPointWFPLastName = dataItem["StartPointWFPLastName"].ToString();

                if (dataItem["StartPointWFPPositionTitle"] != DBNull.Value)
                    chart.StartPointWFPPositionTitle = dataItem["StartPointWFPPositionTitle"].ToString();

                if (dataItem["StartPointWFPPositionStatusHistory"] != DBNull.Value)
                {
                    if (Enum.IsDefined(typeof(enumOrgPositionStatusHistoryType), dataItem["StartPointWFPPositionStatusHistory"]))
                        chart.StartPointWFPPositionStatusHistory = (enumOrgPositionStatusHistoryType)((int)dataItem["StartPointWFPPositionStatusHistory"]);
                }

                if (dataItem["OrgWorkflowStatusID"] != DBNull.Value)
                {
                    if (Enum.IsDefined(typeof(enumOrgWorkflowStatus), dataItem["OrgWorkflowStatusID"]))
                        chart.OrgWorkflowStatusID = (enumOrgWorkflowStatus)((int)dataItem["OrgWorkflowStatusID"]);
                }

                if (dataItem["OrgWorkflowStatusCreateDate"] != DBNull.Value)
                    chart.OrgWorkflowStatusCreateDate = (DateTime)dataItem["OrgWorkflowStatusCreateDate"];

                if (dataItem["OrgWorkflowStatus"] != DBNull.Value)
                    chart.OrgWorkflowStatusName = dataItem["OrgWorkflowStatus"].ToString();

                if (dataItem["Header1"] != DBNull.Value)
                    chart.Header1 = dataItem["Header1"].ToString();

                if (dataItem["Header2"] != DBNull.Value)
                    chart.Header2 = dataItem["Header2"].ToString();

                if (dataItem["Header3"] != DBNull.Value)
                    chart.Header3 = dataItem["Header3"].ToString();

                if (dataItem["Header4"] != DBNull.Value)
                    chart.Header4 = dataItem["Header4"].ToString();

                if (dataItem["Footer"] != DBNull.Value)
                    chart.Footer = dataItem["Footer"].ToString();

                chart.OrgCode = new OrganizationCode(dataItem);
                chart.CreatedBy = new ActionUser()
                {
                    UserID = dataItem["CreatedByID"] == DBNull.Value ? -1 : (int)dataItem["CreatedByID"],
                    FirstName = dataItem["CreatedByFirstName"] == DBNull.Value ? string.Empty : dataItem["CreatedByFirstName"].ToString(),
                    LastName = dataItem["CreatedByLastName"] == DBNull.Value ? string.Empty : dataItem["CreatedByLastName"].ToString(),
                    ActionDate = dataItem["CreateDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dataItem["CreateDate"]
                };

                chart.UpdatedBy = new ActionUser()
                {
                    UserID = dataItem["UpdatedByID"] == DBNull.Value ? -1 : (int)dataItem["UpdatedByID"],
                    FirstName = dataItem["UpdatedByFirstName"] == DBNull.Value ? string.Empty : dataItem["UpdatedByFirstName"].ToString(),
                    LastName = dataItem["UpdatedByLastName"] == DBNull.Value ? string.Empty : dataItem["UpdatedByLastName"].ToString(),
                    ActionDate = dataItem["UpdatedByDate"] == DBNull.Value ? (DateTime?)null : (DateTime)dataItem["UpdatedByDate"]
                };
            }
        }
    }
}