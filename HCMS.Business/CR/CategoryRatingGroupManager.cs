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
    public class CategoryRatingGroupManager:BusinessBase
    {
        #region [Get Methods]
        public static CategoryRatingGroup GetByID(long CategoryRatingGroupID)
        {
            CategoryRatingGroup item = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetCategoryRatingGroupByID", CategoryRatingGroupID);
                item=loadData (dataTable);               

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
        private static CategoryRatingGroup loadData(DataTable returnTable)
        {
            CategoryRatingGroup currentcrgroup = new CategoryRatingGroup();
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                currentcrgroup = FillObjectFromRowData(returnRow);
            }
            return currentcrgroup;
        }
        private static CategoryRatingGroup FillObjectFromRowData(DataRow dataRow)
        {
            CategoryRatingGroup crgroup = new CategoryRatingGroup();
            try
            {
                crgroup.CategoryRatingGroupID = (long)dataRow["CategoryRatingGroupID"];
                crgroup.CRID = (long)dataRow["CRID"];
                crgroup.ScoringRangeGroupTypeID = (int)dataRow["ScoringRangeGroupTypeID"];
                crgroup.ScoringRangeGroupTypeName = (string)dataRow["ScoringRangeGroupTypeName"];
                crgroup.RangeMin = (int)dataRow["RangeMin"];
                crgroup.RangeMax = (int)dataRow["RangeMax"];
                if (dataRow["QualifyingStatements"] != DBNull.Value) crgroup.QualifyingStatements = (string)dataRow["QualifyingStatements"];
            }
            catch (Exception ex)
            {
                crgroup = null;
                ExceptionBase.HandleException(ex);
            }
            return crgroup;
        }
        #endregion

        #region [ Group Helper Methods ]
        public static CategoryRatingGroup GetBestQuilifiedGroup(long CRID)
        {
            List<CategoryRatingGroup> groups = GetCollectionForCRID(CRID);
            CategoryRatingGroup group = groups.SingleOrDefault(g => g.ScoringRangeGroupTypeID == (int)enumScoringRangeGroupType.BestQualified);
            return group;
        }
        public static CategoryRatingGroup GetWellQuilifiedGroup(long CRID)
        {
            List<CategoryRatingGroup> groups = GetCollectionForCRID(CRID);
            CategoryRatingGroup group = groups.SingleOrDefault(g => g.ScoringRangeGroupTypeID == (int)enumScoringRangeGroupType.WellQualified);
            return group;
        }
        public static CategoryRatingGroup GetQuilifiedGroup(long CRID)
        {
            List<CategoryRatingGroup> groups = GetCollectionForCRID(CRID);
            CategoryRatingGroup group = groups.SingleOrDefault(g => g.ScoringRangeGroupTypeID == (int)enumScoringRangeGroupType.Qualified);
            return group;
        }
        #endregion

        #region [ Collection Helper Methods ]
        public static List<CategoryRatingGroup> GetCollectionForCRID(long CRID)
        {
            List<CategoryRatingGroup> list = null;

            try
            {
                DataTable table = ExecuteDataTable("spr_GetCategoryRatingGroupsByCRID", CRID);

                // fill a list
                list = GetCollection(table);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }
        private static List<CategoryRatingGroup> GetCollection(DataTable table)
        {
            List<CategoryRatingGroup> list = new List<CategoryRatingGroup>();

            try
            {
                if (table != null)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        CategoryRatingGroup item = FillObjectFromRowData(table.Rows[i]);
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }
        #endregion

        #region [ General Methods ]
        public static long Add(CategoryRatingGroup crGroup,int userID)
        {
            long crGroupid = -1;
        try
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddCategoryRatingGroup");
            SqlParameter returnParam = new SqlParameter("@CategoryRatingGroupID", SqlDbType.BigInt);
            returnParam.Direction = ParameterDirection.Output;
            // get the new CRID of the record
            commandWrapper.Parameters.Add(returnParam);
            commandWrapper.Parameters.Add(new SqlParameter("@CRID", crGroup.CRID));
            commandWrapper.Parameters.Add(new SqlParameter("@ScoringRangeGroupTypeID", crGroup.ScoringRangeGroupTypeID));
            commandWrapper.Parameters.Add(new SqlParameter(" @ScoringRangeGroupTypeName", crGroup.ScoringRangeGroupTypeName));
            commandWrapper.Parameters.Add(new SqlParameter("@RangeMin", crGroup.RangeMin ));
            commandWrapper.Parameters.Add(new SqlParameter("@RangeMax", crGroup.RangeMax ));
            commandWrapper.Parameters.Add(new SqlParameter("@RangeMax", crGroup.RangeMax ));
            commandWrapper.Parameters.Add(new SqlParameter("@QualifyingStatements", crGroup.QualifyingStatements ));
            commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));
            ExecuteNonQuery(commandWrapper);
            crGroupid = (long)returnParam.Value; 
        }
        catch (Exception ex)
        {
            HandleException(ex);
          
        }
        return crGroupid;
        }
        public static void Update(CategoryRatingGroup crGroup, int userID)
        {
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateCategoryRatingGroup");
                commandWrapper.Parameters.Add(new SqlParameter("@CategoryRatingGroupID", crGroup.CategoryRatingGroupID));
                commandWrapper.Parameters.Add(new SqlParameter("@CRID", crGroup.CRID));
                commandWrapper.Parameters.Add(new SqlParameter("@ScoringRangeGroupTypeID", crGroup.ScoringRangeGroupTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@ScoringRangeGroupTypeName", crGroup.ScoringRangeGroupTypeName));
                commandWrapper.Parameters.Add(new SqlParameter("@RangeMin", crGroup.RangeMin));
                commandWrapper.Parameters.Add(new SqlParameter("@RangeMax", crGroup.RangeMax));                
                commandWrapper.Parameters.Add(new SqlParameter("@QualifyingStatements", crGroup.QualifyingStatements));
                commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));
                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        public static void Delete(CategoryRatingGroup crGroup, int userID)
        {
            DbCommand commandWrapper = GetDbCommand("spr_DeleteCategoryRatingGroup");

            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@CategoryRatingGroupID", crGroup.CategoryRatingGroupID));
                commandWrapper.Parameters.Add(new SqlParameter("@CRID", crGroup.CRID));
                commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));

                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }


        public static long AddCRGroupByScoringRangeGroupType(enumScoringRangeGroupType ScoringRangeGroupType, long crID, int userID)
        {

            long crGroupid = -1;
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_AddCategoryRatingGroupByScoringRangeGroupType");
                SqlParameter returnParam = new SqlParameter("@CategoryRatingGroupID", SqlDbType.BigInt);
                returnParam.Direction = ParameterDirection.Output;
                // get the new CRID of the record
                commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@CRID", crID ));
                commandWrapper.Parameters.Add(new SqlParameter("@ScoringRangeGroupTypeID", (int)ScoringRangeGroupType));
                commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));
                ExecuteNonQuery(commandWrapper);
                crGroupid = (long)returnParam.Value; 

            }
            catch (Exception ex)
            {
                HandleException(ex);

            }
        return crGroupid;
        }
        #endregion
    }
}
