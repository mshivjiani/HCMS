using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;

namespace HCMS.Business.Lookups
{
    public class AppointmentTypeManager: BusinessBase
    {

        #region Constructor Helper Methods

        //default constructor
        public AppointmentTypeManager()
        {

        }

       

        public static AppointmentType GetAppointmentType(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        private AppointmentType loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }

            return null;
        }

        private static AppointmentType FillObjectFromRowData(DataRow returnRow)
        {
            AppointmentType AppointmentType = new AppointmentType();
            if (returnRow["AppointmentTypeID"] != DBNull.Value)
                AppointmentType.AppointmentTypeID = (int)returnRow["AppointmentTypeID"];

            if (returnRow["AppointmentCode"] != DBNull.Value)
                AppointmentType.AppointmentCode = returnRow["AppointmentCode"].ToString();

            if (returnRow["AppointmentTypeDesc"] != DBNull.Value)
                AppointmentType.AppointmentTypeDesc = returnRow["AppointmentTypeDesc"].ToString();


            if (returnRow["IsActive"] != DBNull.Value)
                AppointmentType.IsActive = (bool)returnRow["IsActive"];

            if (returnRow["DisplayAs"] != DBNull.Value)
                AppointmentType.DisplayAs  = returnRow["DisplayAs"].ToString();

            return AppointmentType;

        }

        #endregion

        #region Collection Methods

        public static List<AppointmentType> GetAllAppointmentTypes()
        {
            List<AppointmentType> listCollection = new List<AppointmentType>();
            AppointmentType  item;
            DataTable dataItems = ExecuteDataTable("spr_GetAllAppointmentTypes");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                   
                   item= GetAppointmentType(dataItems.Rows[i]);                 
                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Appointment Type collection from a null data table.");
            }

            return listCollection;
        }

        #endregion

    }
}
