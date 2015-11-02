using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
namespace HCMS.Business.Lookups
{
   public class SupervisoryStatusManager:BusinessBase
   {
       #region [Private Methods]

       
       private static SupervisoryStatus  GetSupervisoryStatus(DataRow singleRowData)
        {
            // Load Object by dataRow
            SupervisoryStatus  obj = new SupervisoryStatus ();
            try
            {
               obj =FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return obj ;

          
        }

        private static SupervisoryStatus  loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }
            else
            { return null; }

          
        }

        private static SupervisoryStatus  FillObjectFromRowData(DataRow returnRow)
        {
            SupervisoryStatus  obj = new SupervisoryStatus ();
            if (returnRow["SupervisorStatusID"] != DBNull.Value)
                obj.SupervisorStatusID = (int)returnRow["SupervisorStatusID"];

            if (returnRow["Title"] != DBNull.Value)
                obj.Title = returnRow["Title"].ToString();

            if (returnRow["Description"] != DBNull.Value)
                obj.SupervisorStatusDescription = returnRow["Description"].ToString();


            return obj ;

        }

       #endregion

       #region Collection Methods

        public static List<SupervisoryStatus> GetAllSupervisoryStatus()
        {
            List<SupervisoryStatus> listCollection = new List<SupervisoryStatus>();
            SupervisoryStatus  item=new SupervisoryStatus  ();
            DataTable dataItems = ExecuteDataTable("spr_GetAllSupervisoryStatus");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    item = GetSupervisoryStatus(dataItems.Rows[i]);
                   listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Supervisory status collection from a null data table.");
            }

            return listCollection;
        }

         #endregion

    }
}
