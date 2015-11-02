using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.JNP;
namespace HCMS.Business.CR
{
    [System.ComponentModel.DataObject]
    public class CategoryRatingManager:BusinessBase
    {
        #region [Get Methods]
        public static CategoryRating GetByID(long CRID)
        {
            CategoryRating item = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetCategoryRatingByID", CRID);
                item = loadData(dataTable);           

            }
            catch (Exception ex)
            {
                item = null;
                ExceptionBase.HandleException(ex);
            }

            return item;
        }
        public static CategoryRating GetByJAID(long JAID)
        {
            CategoryRating item = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetCategoryRatingByJAID", JAID);
                item = loadData(dataTable);

            }
            catch (Exception ex)
            {
                item = null;
                ExceptionBase.HandleException(ex);
            }

            return item;
        }
        public static CategoryRating GetByJNPID(long JNPID)
        {
            CategoryRating item = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetCategoryRatingByJNPID", JNPID);
                item = loadData(dataTable);

            }
            catch (Exception ex)
            {
                item = null;
                ExceptionBase.HandleException(ex);
            }

            return item;
        }
        #endregion

        #region [Private Mapper Methods]
        private static CategoryRating loadData(DataTable returnTable)
        {
            CategoryRating currentcr = new CategoryRating();
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                currentcr= FillObjectFromRowData(returnRow);
            }
            return currentcr;
        }
        private static CategoryRating FillObjectFromRowData(DataRow dataRow)
        {
            CategoryRating currentcr = new CategoryRating();
            try
            {
                currentcr.CRID = (long)dataRow["CRID"];
                currentcr.JAID = (long)dataRow["JAID"];
                currentcr.PayPlanID = (int)dataRow["PayPlanID"];
                currentcr.SeriesID = (int)dataRow["SeriesID"];
                currentcr.LowestAdvertisedGrade = (int)dataRow["LowestAdvertisedGrade"];
                currentcr.HighestAdvertisedGrade = (int)dataRow["HighestAdvertisedGrade"];
                if (dataRow["IsStandardCR"] != DBNull.Value) currentcr.IsStandardCR = (bool)dataRow["IsStandardCR"];
                if (dataRow["CreatedByID"] != DBNull.Value) currentcr.CreatedByID = (int)dataRow["CreatedByID"];
                if (dataRow["CreateDate"] != DBNull.Value) currentcr.CreateDate = (DateTime)dataRow["CreateDate"];
                if (dataRow["UpdatedByID"] != DBNull.Value) currentcr.UpdatedByID = (int)dataRow["UpdatedByID"];
                if (dataRow["UpdateDate"] != DBNull.Value) currentcr.UpdateDate = (DateTime)dataRow["UpdateDate"];
                if (dataRow["IsActive"] != DBNull.Value) currentcr.IsActive = (bool)dataRow["IsActive"];
            }
            catch (Exception ex)
            {
                currentcr = null;
                ExceptionBase.HandleException(ex);
            }
            return currentcr;
        }
        #endregion

        #region [CRUD Methods]
        // disabled this method since is not being used anywhere in the system and it adds more overhead to this object
        //public static long AddCategoryRating(CategoryRating currentcr)
        //{
        //    long crid = -1;
        //    try
        //    {
        //        DbCommand commandWrapper = GetDbCommand("spr_CreateCategoryRating");
        //        SqlParameter returnParam = new SqlParameter("@newCRID", SqlDbType.BigInt);
        //        returnParam.Direction = ParameterDirection.Output;
        //        // get the new CRID of the record
        //        commandWrapper.Parameters.Add(returnParam);
        //        commandWrapper.Parameters.Add(new SqlParameter("@jAID", currentcr.JAID ));
        //        commandWrapper.Parameters.Add(new SqlParameter("@payPlanID", currentcr.PayPlanID));
        //        commandWrapper.Parameters.Add (new SqlParameter("@seriesID",currentcr.SeriesID ));
        //        commandWrapper.Parameters.Add (new SqlParameter("@LowestAdvertisedGrade",currentcr.LowestAdvertisedGrade ));
        //        commandWrapper.Parameters.Add (new SqlParameter("@HighestAdvertisedGrade",currentcr.HighestAdvertisedGrade ));
        //        commandWrapper.Parameters.Add (new SqlParameter("@isStandardCR",currentcr.IsStandardCR ));
        //        commandWrapper.Parameters.Add (new SqlParameter("@createdByID",currentcr.CreatedByID ));
        //        commandWrapper.Parameters.Add (new SqlParameter("@createDate",currentcr.CreateDate ));
        //        commandWrapper.Parameters.Add (new SqlParameter("@updatedByID",currentcr.UpdatedByID ));
        //        commandWrapper.Parameters.Add (new SqlParameter("@updateDate",currentcr.UpdateDate  ));
        //        ExecuteNonQuery(commandWrapper);
        //        crid = (long)returnParam.Value; 
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
                
        //    }
        //    return crid;
        //}

        public static void UpdateCategoryRating(CategoryRating currentcr)
        {
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateCategoryRating");

                commandWrapper.Parameters.Add(new SqlParameter("@cRID", currentcr.CRID));
                commandWrapper.Parameters.Add(new SqlParameter("@jAID", currentcr.JAID));
                commandWrapper.Parameters.Add(new SqlParameter("@payPlanID", currentcr.PayPlanID));
                commandWrapper.Parameters.Add(new SqlParameter("@seriesID", currentcr.SeriesID));
                commandWrapper.Parameters.Add(new SqlParameter("@LowestAdvertisedGrade", currentcr.LowestAdvertisedGrade));
                commandWrapper.Parameters.Add(new SqlParameter("@HighestAdvertisedGrade", currentcr.HighestAdvertisedGrade));
                commandWrapper.Parameters.Add(new SqlParameter("@isStandardCR", currentcr.IsStandardCR));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", currentcr.UpdatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@IsActive", currentcr.IsActive));
                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }
        public static int DeleteCategoryRating(CategoryRating currentcr, int currentUserID)
        {
           return DeleteCategoryRating(currentcr.CRID, currentUserID);
        }

        public static int DeleteCategoryRating(long CRID, int currentUserID)
        {int retcode = -1;
            try
            {
                
                   retcode=(int)ExecuteScalar ("spr_DeleteCategoryRating", CRID, currentUserID);
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
            return retcode;
        }

        public static int RestoreCategoryRating(CategoryRating currentcr, int currentUserID)
        {
            return RestoreCategoryRating(currentcr.CRID, currentUserID);
        }

        public static int RestoreCategoryRating(long CRID, int currentUserID)
        {
            int retcode = -1;
            try
            {

                retcode = (int)ExecuteScalar("spr_RestoreCategoryRating", CRID, currentUserID);
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
            return retcode;
        }

        public static long CreateCategoryRatingFromJobAnalysis( long? JNPID,long JAID, bool IsStandardCR, int CreatedByID)
        {
            long crid = -1;
            try
            {
                crid = (long)ExecuteScalar("spr_CreateCategoryRating", JNPID, JAID, IsStandardCR, CreatedByID);
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
            return crid;
        }
        #endregion

        #region [Other Methods]
        public static string GetFinalKSAS(long JAID)
        {
            DbCommand commandWrapper = null;
            commandWrapper = BusinessBase.GetDbCommand("spr_GetAllFinalKSAFactorByJAID");
            commandWrapper.Parameters.Add(new SqlParameter("@JAID", JAID));
            DataTable dt=ExecuteDataTable(commandWrapper);
            int index=0;
           
            StringBuilder listOfKSAs = new StringBuilder();
             DataRow dr;
            while (index<dt.Rows.Count)
            {
                dr=dt.Rows[index];
                listOfKSAs.AppendFormat("{0}\n", ((string)dr["JAKSAdescription"]).Trim());
                index = index + 1;
            }
            // Author: Deepali Anuje
            // Bug # 555 - Consistency of Titles and lists on CR screen vs. CR PDF 
            // Logic in Database Function now to be consistent with reports.
        //    return FormatMultilineTextWithNumbers(listOfKSAs.ToString());
            return listOfKSAs.ToString();
        }
        private static string FormatMultilineTextWithNumbers(string ImputString)
        {
            string outputString = "";
            string[] multiItems = ImputString.Split('\n');

            for (int i = 0; i < multiItems.Length; i++)
            {
                if (multiItems[i] != null)
                {
                    if (multiItems[i] != String.Empty)
                    {
                        if (outputString == String.Empty)
                            outputString = (i + 1).ToString() + ". " + multiItems[i] + "\n\n";
                        else
                            outputString = outputString + (i + 1).ToString() + ". " + multiItems[i] + "\n\n";
                    }
                }
            }

            return outputString;
        }
        public static string GetMinimumQualification(int typeOfWorkID, int grade)
        {
            string minimumQualification = String.Empty;
           
            try
            {
                DataTable dt =ExecuteDataTable("spr_GetMinimumQualifications", typeOfWorkID, grade);
                if(dt.Rows.Count >0)
                {
                minimumQualification = dt.Rows[0]["OPMQualificationStandard"].ToString();   
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return minimumQualification;
        }
       
        #endregion
    }
}
