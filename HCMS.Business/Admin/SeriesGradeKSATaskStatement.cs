using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data.Common;
using System.Data.SqlClient;

namespace HCMS.Business.Admin
{
    [DataObject]
    public class SeriesGradeKSATaskStatement : BusinessBase
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataTable SelectSeriesGradeKSATaskStatements(int startRowIndex, int maximumRows, int seriesID, int gradeID, long ksaID)
        {
            DataTable table = ExecuteDataTable("spr_GetSeriesGradeKSATaskStatementsPaged", startRowIndex, maximumRows, seriesID, gradeID, ksaID);
            return table;
        }

        public static int SelectSeriesGradeKSATaskStatementsTotalCount(int seriesID, int gradeID, long ksaID)
        {
            int count = (int)ExecuteScalar("spr_GetSeriesGradeKSATaskStatementsTotalCount", seriesID, gradeID, ksaID);
            return count;
        }

        #region General CRUD Methods

        public static bool Add(HCMS.Business.Series.SeriesGradeKSATaskStatement seriesGradeKSATaskStatement)
        {
            bool isSuccessfullyInserted = false;
            DbCommand commandWrapper = GetDbCommand("spr_AddSeriesGradeKSATaskStatement");
            try
            {
                //SqlParameter returnParam = new SqlParameter("@newWorkflowRuleID", SqlDbType.Int);
                //returnParam.Direction = ParameterDirection.Output;
                //commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", seriesGradeKSATaskStatement.SeriesID));
                commandWrapper.Parameters.Add(new SqlParameter("@Grade", seriesGradeKSATaskStatement.Grade));
                commandWrapper.Parameters.Add(new SqlParameter("@KSAID", seriesGradeKSATaskStatement.KSAID));
                commandWrapper.Parameters.Add(new SqlParameter("@TaskStatementID", seriesGradeKSATaskStatement.TaskStatementID));

                ExecuteNonQuery(commandWrapper);

                isSuccessfullyInserted = true;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return isSuccessfullyInserted;
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static bool Delete(HCMS.Business.Series.SeriesGradeKSATaskStatement seriesGradeKSATaskStatement)
        {
            bool isSuccessfullyDeleted = false;
            DbCommand commandWrapper = GetDbCommand("spr_DeleteSeriesGradeKSATaskStatement");
            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@seriesID", seriesGradeKSATaskStatement.SeriesID));
                commandWrapper.Parameters.Add(new SqlParameter("@grade", seriesGradeKSATaskStatement.Grade));
                commandWrapper.Parameters.Add(new SqlParameter("@kSAID", seriesGradeKSATaskStatement.KSAID));
                commandWrapper.Parameters.Add(new SqlParameter("@taskStatementID", seriesGradeKSATaskStatement.TaskStatementID));

                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return isSuccessfullyDeleted;
        }

        #endregion
    }
}
