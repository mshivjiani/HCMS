using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HCMS.Business.Lookups
{
    #region TSEntity
    [Serializable]
    public class TSEntity
    {
        public long TaskStatementID { get; set; }
        public string TaskStatement { get; set; }

        public TSEntity()
        {
        }
        public TSEntity(DataRow singleRowData)
        {
            // Load Object by dataRow
            this.FillTaskStatementEntityFromRowData(singleRowData);

        }
        protected void FillTaskStatementEntityFromRowData(DataRow returnRow)
        {
            DataColumnCollection columns = returnRow.Table.Columns;
            this.TaskStatementID = (long)returnRow["TaskStatementID"];
            this.TaskStatement = returnRow["TaskStatement"].ToString();
        }

    }
    #endregion

    [Serializable]
    public class TaskStatementEntityManager : BusinessBase
    {
        public static DataTable GetGradeEntityTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("GradeID", typeof(int));
            return dt;
        }
        public static List<TSEntity> GetTaskStatementEntityList(int seriesid, int currentGrade ,List<Grade> Grades, bool filterbySeries, string keyword, long KSAID)
        {
            List<TSEntity> items = new List<TSEntity>();

            DataTable gradeEntity = GetGradeEntityTable();
            if (Grades != null)
            {
                foreach (Grade grade in Grades)
                {
                    gradeEntity.Rows.Add(grade.GradeID);
                }
            }
            DbCommand commandWrapper = GetDbCommand("spr_SearchAdminTaskStatement");

            commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", seriesid));

            commandWrapper.Parameters.Add(new SqlParameter("@CurrentGrade", currentGrade));

            if (gradeEntity.Rows.Count > 0)
            {
                SqlParameter sqlGradeEntityparam = new SqlParameter("@GradeTable", SqlDbType.Structured);
                sqlGradeEntityparam.SqlDbType = SqlDbType.Structured;
                sqlGradeEntityparam.Value = gradeEntity;
                commandWrapper.Parameters.Add(sqlGradeEntityparam);
            }

            commandWrapper.Parameters.Add(new SqlParameter("@filterbySeries", filterbySeries));

            if (keyword == "")
                commandWrapper.Parameters.Add(new SqlParameter("@KeyWord", DBNull.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@KeyWord", keyword));

            if (KSAID == -1)
                commandWrapper.Parameters.Add(new SqlParameter("@KSAID", DBNull.Value));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@KSAID", KSAID));

            DataTable dt = ExecuteDataTable(commandWrapper);
            foreach (DataRow row in dt.Rows)
            {
                items.Add(new TSEntity(row));
            }
            return items;

        }

        public static DataTable GetAllAddedTaskStatements(int JQFactorID)
        {
            DbCommand commandWrapper = GetDbCommand("spr_GetAddedTaskStatements");
            commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", JQFactorID));

            DataTable dt = ExecuteDataTable(commandWrapper);

            return dt;
        }

        public static DataTable GetAddedTaskStatementsForJAX(int JNPID)
        {
            DbCommand commandWrapper = GetDbCommand("spr_GetAddedTaskStatementsForJAX");
            commandWrapper.Parameters.Add(new SqlParameter("@JAXID", JNPID));

            DataTable dt = ExecuteDataTable(commandWrapper);

            return dt;
        }

        public static DataTable GetAllAddedTaskStatementsForKSA(int JQFactorID)
        {
            DbCommand commandWrapper = GetDbCommand("spr_GetAddedTaskStatementsForKSA");
            commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", JQFactorID));

            DataTable dt = ExecuteDataTable(commandWrapper);

            return dt;
        }


        public static List<TSEntity> RemoveExistingFromList(List<TSEntity> orderedList, int JQFactorID)
        {
            DataTable dtAddedTS = TaskStatementEntityManager.GetAllAddedTaskStatements(JQFactorID);
            if (dtAddedTS.Rows.Count > 0)
            {
                for (int i = 0; i < dtAddedTS.Rows.Count; i++)
                {
                    orderedList.RemoveAll(o => o.TaskStatementID == Convert.ToInt32(dtAddedTS.Rows[i]["TaskStatementID"]));
                }
            }

            return orderedList;
        }

        public static List<TSEntity> RemoveExistingFromListForJAX(List<TSEntity> orderedList, int JAXID)
        {
            DataTable dtAddedTS = TaskStatementEntityManager.GetAddedTaskStatementsForJAX(JAXID);
            if (dtAddedTS.Rows.Count > 0)
            {
                for (int i = 0; i < dtAddedTS.Rows.Count; i++)
                {
                    orderedList.RemoveAll(o => o.TaskStatementID == Convert.ToInt32(dtAddedTS.Rows[i]["TaskStatementID"]));
                }
            }

            return orderedList;
        }
    }
}
