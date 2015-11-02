using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;

namespace HCMS.Business.Lookups
{
    public class OrgPositionTypeManager : BusinessBase
    {
        #region Constructor Helper Methods

       

        public OrgPositionType GetOrgPositionType(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;
            OrgPositionType orgpositiontype = new OrgPositionType();
            try
            {
                returnTable = ExecuteDataTable("spr_GetOrgPositionTypeByID", loadByID);
                orgpositiontype = loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return orgpositiontype;
        }

        private static OrgPositionType GetOrgPositionType(DataRow singleRowData)
        {
            // Load Object by dataRow
            OrgPositionType orgpositiontype = new OrgPositionType();
            try
            {
               orgpositiontype =FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return orgpositiontype ;

          
        }

        private OrgPositionType loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }
            else
            { return null; }

          
        }

        private static OrgPositionType FillObjectFromRowData(DataRow returnRow)
        {
            OrgPositionType OrgPosType = new OrgPositionType();
            if (returnRow["OrgPositionTypeID"] != DBNull.Value)
                OrgPosType.OrgPositionTypeID = (int)returnRow["OrgPositionTypeID"];

            if (returnRow["OrgPositionType"] != DBNull.Value)
                OrgPosType.OrgPositionTypeDesc = returnRow["OrgPositionType"].ToString();

            if (returnRow["OrgPositionTypeAcronym"] != DBNull.Value)
                OrgPosType.OrgPositionTypeAcronym = returnRow["OrgPositionTypeAcronym"].ToString();


            return OrgPosType ;

        }

        #endregion

        #region Collection Methods

        public static List<OrgPositionType> GetAllOrgPositionTypes()
        {
            List<OrgPositionType> listCollection = new List<OrgPositionType>();
            OrgPositionType item=new OrgPositionType ();
            DataTable dataItems = ExecuteDataTable("spr_GetAllOrgPositionTypes");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    item = GetOrgPositionType(dataItems.Rows[i]);
                   listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Org Position Type collection from a null data table.");
            }

            return listCollection;
        }

         #endregion

        
    }
}
 