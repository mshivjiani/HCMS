using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;

namespace HCMS.Business.Lookups
{
    public class OrgPositionGroupTypeManager : BusinessBase
    {

        #region Constructor Helper Methods - This is not helper method. These are generic methods.

        //default constructor
        public OrgPositionGroupTypeManager()
        {

        }

        public OrgPositionGroupType GetOrgPositionGroupType(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetOrgPositionGroupTypeByID", loadByID);
                return loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return null;
            }

            
        }

        public static OrgPositionGroupType GetOrgPositionGroupType(DataRow singleRowData)
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

        private OrgPositionGroupType loadData(DataTable returnTable)
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

        private static OrgPositionGroupType FillObjectFromRowData(DataRow returnRow)
        {
            OrgPositionGroupType OrgPositionGroupT = new OrgPositionGroupType();
            if (returnRow["OrgPositionGroupTypeID"] != DBNull.Value)
            {
                OrgPositionGroupT.OrgPositionGroupTypeID = (int)returnRow["OrgPositionGroupTypeID"];
                OrgPositionGroupT.eOrgPositionGroupType = (enumOrgPositionGroupType)returnRow["OrgPositionGroupTypeID"];
            }

            if (returnRow["OrgPositionGroupType"] != DBNull.Value)
                OrgPositionGroupT.OrgPositionGroupTypeDesc = returnRow["OrgPositionGroupType"].ToString();

          
                


          return  OrgPositionGroupT;

        }

        #endregion

        #region Collection Methods

        public static List<OrgPositionGroupType> GetAllOrgPositionGroupTypes()
        {
            List<OrgPositionGroupType> listCollection = new List<OrgPositionGroupType>();
            OrgPositionGroupType item;
            DataTable dataItems = ExecuteDataTable("spr_GetAllOrgPositionGroupTypes");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {

                    item = GetOrgPositionGroupType(dataItems.Rows[i]);
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
