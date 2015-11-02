using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HCMS.Business.Base;

namespace HCMS.Business.OrganizationChart
{
    class OrganizationTrackerManager : BusinessBase
    {

        List<OrganizationTracker> ls;
       DataTable tblData = new DataTable();
        public OrganizationTrackerManager()
        {
           ls = new List<OrganizationTracker>();
        }

        public List<OrganizationTracker> LoadForOrgTracker(int UserId)
        {
            try
            {
                tblData = ExecuteDataTable("spr_GetAllOrgChartTrackerItemsByUserID", UserId);

                foreach (DataRow dr in tblData.Rows)
                {
                    FillObjectFromDataRow(dr);
                }

                return ls;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }
        }

        private void FillObjectFromDataRow(DataRow dataRow)
        {
            try
            {
                OrganizationTracker orgTrac = new OrganizationTracker();

                /*
                //Mapping values dynamically.
                Type t = typeof(OrganizationTracker);
                System.Reflection.PropertyInfo[] propInfos = t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

                string[] colName = null;

                for (int i = 0; i < tblData.Columns.Count; i++)
                {
                    colName[i] = tblData.Columns[i].ColumnName;
                }

                for(int i = 0; i < propInfos.Length; i++)
                {

                    if(propInfos[i].Name == colName[i])
                    {
                        if(propInfos[i].PropertyType == typeof(string))
                        {
                            Type ts = propInfos[i].PropertyType;
                            propInfos[i].SetValue(propInfos[i].Name, (ts)(dataRow[colName[i]]).ToString(), null);
                        }
                    }
                }
                */


                orgTrac.OrganizationChartID = (int)dataRow["OrganizationChartID"];
                orgTrac.OrganizationChartTypeID = (int)dataRow["OrganizationChartTypeID"];

                orgTrac.OrganizationCodeID = (int)dataRow["OrganizationCodeID"];
                orgTrac.CheckedOutByID = (int)dataRow["CheckedOutByID"];
                orgTrac.LevelID = (int)dataRow["LevelID"];

                orgTrac.CreatedByID = (int)dataRow["CreatedByID"];
                orgTrac.OrgWorkflowStatusID = (int)dataRow["OrgWorkflowStatusID"];
                orgTrac.UpdateByID = (int)dataRow["UpdateByID"];
                if (dataRow["RegionID"] != DBNull.Value) orgTrac.RegionID = (int)dataRow["RegionID"];

                if (dataRow["Introduction"] != DBNull.Value) orgTrac.Introduction = (string)dataRow["Introduction"];
                if (dataRow["ReportingOrganizationCode"] != DBNull.Value) orgTrac.ReportingOrganizationCode = (string)dataRow["ReportingOrganizationCode"];
                if (dataRow["OldOrganizationCode"] != DBNull.Value) orgTrac.OldOrganizationCode = (string)dataRow["OldOrganizationCode"];
                if (dataRow["OrgWorkflowStatus"] != DBNull.Value) orgTrac.OrgWorkflowStatus = (string)dataRow["OrgWorkflowStatus"];
                if (dataRow["Header1"] != DBNull.Value) orgTrac.Header1 = (string)dataRow["Header1"];
                if (dataRow["Header2"] != DBNull.Value) orgTrac.Header2 = (string)dataRow["Header2"];
                if (dataRow["Header3"] != DBNull.Value) orgTrac.Header3 = (string)dataRow["Header3"];
                if (dataRow["Header4"] != DBNull.Value) orgTrac.Header4 = (string)dataRow["Header4"];
                if (dataRow["OrganizationCode"] != DBNull.Value) orgTrac.Footer = (string)dataRow["Footer"];
                if (dataRow["Introduction"] != DBNull.Value) orgTrac.OrganizationCode = (string)dataRow["OrganizationCode"];
                if (dataRow["OrganizationName"] != DBNull.Value) orgTrac.OrganizationName = (string)dataRow["OrganizationName"];

                if (dataRow["CreateDate"] != DBNull.Value) orgTrac.CreateDate = Convert.ToDateTime(dataRow["CreateDate"]);
                if (dataRow["OrgWorkflowStatusCreateDate"] != DBNull.Value) orgTrac.OrgWorkflowStatusCreateDate = Convert.ToDateTime(dataRow["OrgWorkflowStatusCreateDate"]);
                if (dataRow["CheckedOutByDate"] != DBNull.Value) orgTrac.CheckedOutByDate = Convert.ToDateTime(dataRow["CheckedOutByDate"]);
                if (dataRow["UpdatedByDate"] != DBNull.Value) orgTrac.UpdatedByDate = Convert.ToDateTime(dataRow["UpdatedByDate"]);


                if (dataRow["CanEdit"] != DBNull.Value) orgTrac.CanEdit = (bool)dataRow["CanEdit"];
                 if (dataRow["CanDelete"] != DBNull.Value) orgTrac.CheckedOut = (bool)dataRow["CanDelete"];
                if (dataRow["CanContinueEdit"] != DBNull.Value) orgTrac.CanContinueEdit = (bool)dataRow["CanContinueEdit"];
                if (dataRow["CanFinishEdit"] != DBNull.Value) orgTrac.CanFinishEdit = (bool)dataRow["CanFinishEdit"];
                if (dataRow["CanViewOnly"] != DBNull.Value) orgTrac.CanViewOnly = (bool)dataRow["CanViewOnly"];
                if (dataRow["CheckedOut"] != DBNull.Value) orgTrac.CheckedOut = (bool)dataRow["CheckedOut"];

                ls.Add(orgTrac);
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }

    }
}
