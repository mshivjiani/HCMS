using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

using HCMS.Business.Base;

namespace HCMS.Business.Lookups.Collections
{
    [System.ComponentModel.DataObject]
    public class DashboardRoleTypeManager : BusinessBase
    {
        #region General CRUD Methods

        public int Add(DashboardRoleType DashboardRoleT)
        {
            int returnID = -1;
            DbCommand commandWrapper = GetDbCommand("spr_AddDashboardRoleType");

            try
            {
                SqlParameter returnParam = new SqlParameter("@DashboardRoleTypeID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                commandWrapper.Parameters.Add(returnParam);

                if (string.IsNullOrWhiteSpace(DashboardRoleT.DashboardRoleType1))
                    commandWrapper.Parameters.Add(new SqlParameter("@DashboardRoleType", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@DashboardRoleType", DashboardRoleT.DashboardRoleType1.Trim()));

                ExecuteNonQuery(commandWrapper);

                DashboardRoleT.DashboardRoleTypeID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnID;
        }

        public void Update(DashboardRoleType DashboardRoleT)
        {

            if (base.ValidateKeyField(DashboardRoleT.DashboardRoleTypeID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateDashboardRoleType");

                try
                {
                    if (DashboardRoleT.DashboardRoleTypeID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@DashboardRoleTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DashboardRoleTypeID", DashboardRoleT.DashboardRoleTypeID));

                    if (string.IsNullOrWhiteSpace(DashboardRoleT.DashboardRoleType1))
                        commandWrapper.Parameters.Add(new SqlParameter("@DashboardRoleType", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DashboardRoleType", DashboardRoleT.DashboardRoleType1.Trim()));


                    if (string.IsNullOrWhiteSpace(DashboardRoleT.DashboardRoleTypeAcronym))
                        commandWrapper.Parameters.Add(new SqlParameter("@DashboardRoleTypeAcronym", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DashboardRoleTypeAcronym", DashboardRoleT.DashboardRoleTypeAcronym.Trim()));


                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void Delete(DashboardRoleType DashboardRoleT)
        {
            if (base.ValidateKeyField(DashboardRoleT.DashboardRoleTypeID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteDashboardRoleType", DashboardRoleT.DashboardRoleTypeID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Constructor Helper Methods

        //default constructor
        public DashboardRoleTypeManager()
        {

        }

        public DashboardRoleType GeDashboardRoleType(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetDashboardRoleTypeByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        public DashboardRoleType GetDashboardRoleType(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        private DashboardRoleType loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }

            return null;
        }

        protected virtual DashboardRoleType FillObjectFromRowData(DataRow returnRow)
        {
            DashboardRoleType DashboardRoleT = new DashboardRoleType();
            if (returnRow["DashboardRoleTypeID"] != DBNull.Value)
                DashboardRoleT.DashboardRoleTypeID = (int)returnRow["DashboardRoleTypeID"];

            if (returnRow["DashboardRoleType"] != DBNull.Value)
                DashboardRoleT.DashboardRoleType1 = returnRow["DashboardRoleType"].ToString();

            if (returnRow["DashboardRoleTypeAcronym"] != DBNull.Value)
                DashboardRoleT.DashboardRoleTypeAcronym = returnRow["DashboardRoleTypeAcronym"].ToString();

            return DashboardRoleT ;

        }

        #endregion

        #region Collection Methods

        public List<DashboardRoleType> GetAllDashboardRoleType()
        {
            List<DashboardRoleType> listCollection = new List<DashboardRoleType>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllDashboardRoleType");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    DashboardRoleType item = new DashboardRoleType();

                    item.DashboardRoleTypeID = dataItems.Rows[i].Field<int>("DashboardRoleTypeID");
                    item.DashboardRoleType1 = dataItems.Rows[i].Field<string>("DashboardRoleType");
                    item.DashboardRoleTypeAcronym = dataItems.Rows[i].Field<string>("DashboardRoleTypeAcronym");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a DashboardRoleType collection from a null data table.");
            }

            return listCollection;
        }

        #endregion

    }
}
