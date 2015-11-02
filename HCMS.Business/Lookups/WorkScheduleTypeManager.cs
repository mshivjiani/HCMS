using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;

namespace HCMS.Business.Lookups
{
    class WorkScheduleTypeManager : BusinessBase
    {

        #region Constructor Helper Methods

        //default constructor
        public WorkScheduleTypeManager()
        {

        }

        

        public static WorkScheduleType GetWorkScheduleType(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
              return FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }

            
        }

        private static WorkScheduleType loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }
            else
            {
                return null;
            }
        }

        private static WorkScheduleType FillObjectFromRowData(DataRow returnRow)
        {
            WorkScheduleType WorkSchedule = new WorkScheduleType();
            if (returnRow["WorkScheduleTypeID"] != DBNull.Value)
                WorkSchedule.WorkScheduleTypeID = (int)returnRow["WorkScheduleTypeID"];

            if (returnRow["WorkScheduleTypeAbbrev"] != DBNull.Value)
                WorkSchedule.WorkScheduleTypeAbbrev = returnRow["WorkScheduleTypeAbbrev"].ToString();

            if (returnRow["WorkScheduleTypeDesc"] != DBNull.Value)
                WorkSchedule.WorkScheduleTypeDesc = returnRow["WorkScheduleTypeDesc"].ToString();


            if (returnRow["IsActive"] != DBNull.Value)
                WorkSchedule.IsActive = (bool)returnRow["IsActive"];

            if (returnRow["DisplayAs"] != DBNull.Value)
                WorkSchedule.DisplayAs = returnRow["DisplayAs"].ToString();

            return WorkSchedule;

        }

        #endregion

        #region Collection Methods

        public static List<WorkScheduleType> GetAllWorkScheduleTypes()
        {
            List<WorkScheduleType> listCollection = new List<WorkScheduleType>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllWorkScheduleTypes");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    WorkScheduleType item = new WorkScheduleType();
                    item  = GetWorkScheduleType(dataItems.Rows[i]);
                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Work Schedule Type collection from a null data table.");
            }

            return listCollection;
        }

        #endregion
    }
}
 