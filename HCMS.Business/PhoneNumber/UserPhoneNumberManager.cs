using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace HCMS.Business.PhoneNumber
{
    public class UserPhoneNumberManager:BusinessBase
    {
        #region [CRUD Methods]
        public static int Add(UserPhoneNumber userphonenumber)
        {
            int phonenumberid = -1;
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_AddUserPhoneNumber");
                SqlParameter returnParam = new SqlParameter("@PhoneNumberID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;
                commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@UserID", userphonenumber.UserID));
                commandWrapper.Parameters.Add(new SqlParameter("@PhoneNumberTypeID", userphonenumber.PhoneNumberTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@PhoneNumber", userphonenumber.PhoneNumber));
                commandWrapper.Parameters.Add(new SqlParameter("@IsPrimary", userphonenumber.IsPrimary));
                commandWrapper.Parameters.Add(new SqlParameter("@IsPublic", userphonenumber.IsPublic));
                ExecuteNonQuery(commandWrapper);
                phonenumberid = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
            return phonenumberid;
        }

        public static void Update(UserPhoneNumber userphonenumber)
        {
            
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateUserPhoneNumber");
                commandWrapper.Parameters.Add(new SqlParameter("@PhoneNumberID", userphonenumber.PhoneNumberID));
                commandWrapper.Parameters.Add(new SqlParameter("@UserID", userphonenumber.UserID));
                commandWrapper.Parameters.Add(new SqlParameter("@PhoneNumberTypeID", userphonenumber.PhoneNumberTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@PhoneNumber", userphonenumber.PhoneNumber));
                commandWrapper.Parameters.Add(new SqlParameter("@IsPrimary", userphonenumber.IsPrimary));
                commandWrapper.Parameters.Add(new SqlParameter("@IsPublic", userphonenumber.IsPublic));
                ExecuteNonQuery(commandWrapper);
               
            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
            
        }

        public static void Delete(int PhoneNumberID)
        {

            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_DeleteUserPhoneNumber");
                commandWrapper.Parameters.Add(new SqlParameter("@PhoneNumberID", PhoneNumberID));
                ExecuteNonQuery(commandWrapper);

            }
            catch (Exception ex)
            {
                HandleException(ex);

            }

        }
        #endregion

        #region [Private Methods]
        private static UserPhoneNumber GetUserPhoneNumber(DataRow singleRowData)
        {
            // Load Object by dataRow
            UserPhoneNumber  obj = new UserPhoneNumber ();
            try
            {
                obj = FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return obj;


        }

        private static UserPhoneNumber  loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }
            else
            { return null; }
        }

        private static UserPhoneNumber  FillObjectFromRowData(DataRow returnRow)
        {
            UserPhoneNumber  obj = new UserPhoneNumber ();
            if (returnRow["PhoneNumberID"] != DBNull.Value)
                obj.PhoneNumberID = (int)returnRow["PhoneNumberID"];
            if (returnRow["UserID"] != DBNull.Value)
                obj.UserID = (int)returnRow["UserID"];
            if (returnRow["PhoneNumberTypeID"] != DBNull.Value)
                obj.PhoneNumberTypeID = (int)returnRow["PhoneNumberTypeID"];

            if (returnRow["PhoneNumber"] != DBNull.Value)
                obj.PhoneNumber = returnRow["PhoneNumber"].ToString();
            if (returnRow["PhoneNumberType"] != DBNull.Value)
                obj.PhoneNumberType = returnRow["PhoneNumberType"].ToString();


            if (returnRow["IsPrimary"] != DBNull.Value)
                obj.IsPrimary =(bool) returnRow["IsPrimary"];
            if (returnRow["IsPublic"] != DBNull.Value)
                obj.IsPublic = (bool)returnRow["IsPublic"];
            return obj;

        }

        #endregion

        #region Collection Methods

        public static List<UserPhoneNumber> GetUserPhoneNumbersByUserID(int UserID)
        {
            List<UserPhoneNumber> listCollection = new List<UserPhoneNumber>();
            UserPhoneNumber item;
            DataTable dataItems = ExecuteDataTable("spr_GetUserPhoneNumbersByUserID",UserID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    item = GetUserPhoneNumber(dataItems.Rows[i]);
                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a UserPhoneNumber collection from a null data table.");
            }

            return listCollection;
        }
        public static List<UserPhoneNumber> GetUserPhoneNumbersByEmployeeCommonID(int EmployeeCommonID)
        {
            List<UserPhoneNumber> listCollection = new List<UserPhoneNumber>();
            UserPhoneNumber item;
            DataTable dataItems = ExecuteDataTable("spr_GetUserPhoneNumbersByEmployeeCommonID", EmployeeCommonID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    item = GetUserPhoneNumber(dataItems.Rows[i]);
                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a UserPhoneNumber collection from a null data table.");
            }

            return listCollection;
        }
        #endregion
    }
}
