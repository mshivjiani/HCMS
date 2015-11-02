using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;
using System.Data.SqlClient;


namespace HCMS.Business.Lookups
{
    [System.ComponentModel.DataObject]
    public class OrgPositionStatusHistoryTypeManager : BusinessBase
    {

        private static OrgPositionStatusHistoryType GetOrgPositionStatusHistoryType(DataRow singleRowData)
        {
            try
            {
                return FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }
        //This does not need to be virtual. It is local method to fill the data.
        private static OrgPositionStatusHistoryType  FillObjectFromRowData(DataRow returnRow) 
        {
            OrgPositionStatusHistoryType  obj = new OrgPositionStatusHistoryType ();

            obj.OrgPositionStatusHistoryTypeID = (int)returnRow["OrgPositionStatusHistoryTypeID"];
            obj.OrgPositionStatusHistoryTypeCode  = returnRow["OrgPositionStatusHistoryTypeCode"].ToString();
            obj.OrgPositionStatusHistoryTypeDesc = returnRow["OrgPositionStatusHistoryTypeDesc"].ToString();
            obj.eOrgPositionStatusHistoryType = (enumOrgPositionStatusHistoryType)obj.OrgPositionStatusHistoryTypeID;
            return obj;
        }


        #region Collection Helper Methods
        public static List<OrgPositionStatusHistoryType> GetAllOrgPositionStatusHistoryTypes()
        {
            List<OrgPositionStatusHistoryType> listCollection = new List<OrgPositionStatusHistoryType>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllOrgPositionStatusHistoryTypes");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    listCollection.Add(GetOrgPositionStatusHistoryType(dataItems.Rows[i]));
                }
            }
            else
            {
                throw new Exception("You cannot create a OrgPositionStatusHistoryType collection from a null data table.");
            }

            return listCollection;
        }

        #endregion

    }
}
