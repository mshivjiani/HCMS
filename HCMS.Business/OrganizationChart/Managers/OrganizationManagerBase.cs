using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Lookups;
using HCMS.Business.Security;

namespace HCMS.Business.OrganizationChart.Managers
{
    public abstract class OrganizationManagerBase<T> : BusinessBase
        where T : class, IOrganizationChart, new()
    {
        #region Get Methods

        protected T BuildFromDataRow(Action<T, DataRow> dataLoader, DataRow rowItem)
        {
            T item = getItemFromDataRow(dataLoader, rowItem);
            return item;
        }

        protected T GetOrganizationChartEntity(string storedProcedureName, params object[] paramList)
        {
            return GetOrganizationChartEntity(null, storedProcedureName, paramList);
        }

        protected T GetOrganizationChartEntity(Action<T, DataRow> dataLoader, string storedProcedureName, params object[] paramList)
        {
            T item = default(T);

            try
            {
                DataTable returnTable = ExecuteDataTable(storedProcedureName, paramList);

                if (returnTable != null && returnTable.Rows.Count > 0)
                    item = getItemFromDataRow(dataLoader, returnTable.Rows[0]);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return item ?? new T();
        }

        protected List<T> GetOrganizationChartEntityCollection(string storedProcedureName, params object[] paramList)
        {
            return GetOrganizationChartEntityCollection(null, storedProcedureName, paramList);
        }

        protected List<T> GetOrganizationChartEntityCollection(Action<T, DataRow> dataLoader, string storedProcedureName, params object[] paramList)
        {
            List<T> returnList = null;

            try
            {
                DataTable returnTable = ExecuteDataTable(storedProcedureName, paramList);
                returnList = this.getCollection(dataLoader, returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnList ?? new List<T>();
        }

        #endregion

        #region [Private Methods]

        private T getItemFromDataRow(Action<T, DataRow> dataLoader, DataRow returnRow)
        {
            T chart = new T();

            if (returnRow != null)
            {
                chart = getCommonObjectDataRow(returnRow);

                if (dataLoader != null)
                    dataLoader.Invoke(chart, returnRow);
            }

            return chart;
        }

        private T getCommonObjectDataRow(DataRow returnRow)
        {
            T chart = new T();

            if (returnRow["OrganizationChartID"] != DBNull.Value)
                chart.OrganizationChartID = (int)returnRow["OrganizationChartID"];

            if (returnRow["OrganizationChartTypeID"] != DBNull.Value)
            {
                if (Enum.IsDefined(typeof(enumOrgChartType), returnRow["OrganizationChartTypeID"]))
                    chart.OrganizationChartTypeID = (enumOrgChartType)((int)returnRow["OrganizationChartTypeID"]);
            }

            if (returnRow["OrganizationName"] != DBNull.Value)
                chart.OrganizationName = returnRow["OrganizationName"].ToString();

            if (returnRow["OrganizationChartType"] != DBNull.Value)
                chart.OrganizationChartTypeName = returnRow["OrganizationChartType"].ToString();

            if (returnRow["StartPointWFPPositionID"] != DBNull.Value)
                chart.StartPointWFPPositionID = (int) returnRow["StartPointWFPPositionID"];

            if (returnRow["StartPointWFPFirstName"] != DBNull.Value)
                chart.StartPointWFPFirstName = returnRow["StartPointWFPFirstName"].ToString();

            if (returnRow["StartPointWFPLastName"] != DBNull.Value)
                chart.StartPointWFPLastName = returnRow["StartPointWFPLastName"].ToString();

            if (returnRow["StartPointWFPPositionTitle"] != DBNull.Value)
                chart.StartPointWFPPositionTitle = returnRow["StartPointWFPPositionTitle"].ToString();

            if (returnRow["StartPointWFPPositionStatusHistory"] != DBNull.Value)
            {
                if (Enum.IsDefined(typeof(enumOrgPositionStatusHistoryType), returnRow["StartPointWFPPositionStatusHistory"]))
                    chart.StartPointWFPPositionStatusHistory = (enumOrgPositionStatusHistoryType)((int)returnRow["StartPointWFPPositionStatusHistory"]);
            }

            if (returnRow["OrgWorkflowStatusID"] != DBNull.Value)
            {
                if (Enum.IsDefined(typeof(enumOrgWorkflowStatus), returnRow["OrgWorkflowStatusID"]))
                    chart.OrgWorkflowStatusID = (enumOrgWorkflowStatus)((int)returnRow["OrgWorkflowStatusID"]);
            }

            if (returnRow["OrgWorkflowStatusCreateDate"] != DBNull.Value)
                chart.OrgWorkflowStatusCreateDate = (DateTime)returnRow["OrgWorkflowStatusCreateDate"];

            if (returnRow["OrgWorkflowStatus"] != DBNull.Value)
                chart.OrgWorkflowStatusName = returnRow["OrgWorkflowStatus"].ToString();

            if (returnRow["Header1"] != DBNull.Value)
                chart.Header1 = returnRow["Header1"].ToString();

            if (returnRow["Header2"] != DBNull.Value)
                chart.Header2 = returnRow["Header2"].ToString();

            if (returnRow["Header3"] != DBNull.Value)
                chart.Header3 = returnRow["Header3"].ToString();

            if (returnRow["Header4"] != DBNull.Value)
                chart.Header4 = returnRow["Header4"].ToString();

            if (returnRow["Footer"] != DBNull.Value)
                chart.Footer = returnRow["Footer"].ToString();

            chart.OrgCode = new OrganizationCode(returnRow);
            chart.CreatedBy = new ActionUser()
            {
                UserID = returnRow["CreatedByID"] == DBNull.Value ? -1 : (int)returnRow["CreatedByID"],
                FirstName = returnRow["CreatedByFirstName"] == DBNull.Value ? string.Empty : returnRow["CreatedByFirstName"].ToString(),
                LastName = returnRow["CreatedByLastName"] == DBNull.Value ? string.Empty : returnRow["CreatedByLastName"].ToString(),
                ActionDate = returnRow["CreateDate"] == DBNull.Value ? (DateTime?)null : (DateTime)returnRow["CreateDate"]
            };

            chart.UpdatedBy = new ActionUser()
            {
                UserID = returnRow["UpdatedByID"] == DBNull.Value ? -1 : (int)returnRow["UpdatedByID"],
                FirstName = returnRow["UpdatedByFirstName"] == DBNull.Value ? string.Empty : returnRow["UpdatedByFirstName"].ToString(),
                LastName = returnRow["UpdatedByLastName"] == DBNull.Value ? string.Empty : returnRow["UpdatedByLastName"].ToString(),
                ActionDate = returnRow["UpdatedByDate"] == DBNull.Value ? (DateTime?)null : (DateTime)returnRow["UpdatedByDate"]
            };

            return chart;
        }

        private List<T> getCollection(Action<T, DataRow> dataLoader, DataTable listData)
        {
            List<T> chartList = new List<T>();

            try
            {
                if (listData != null)
                {
                    foreach (DataRow rowItem in listData.Rows)
                    {
                        T item = getItemFromDataRow(dataLoader, rowItem);
                        chartList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return chartList;
        }

        #endregion
    }
}
