using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
namespace HCMS.Business.Lookups
{
    #region KSAEntity
    [Serializable]
    public class KSAEntity
    {
        private string _KSAText;

        public long KSAID { get; set; }
        public string KSAText 
        { 
            get { return _KSAText; } 
            set { _KSAText = value.ToString().Trim(); } 
        }
        public bool Active { get; set; }
        public KSAEntity()
        {
        }
        public KSAEntity(DataRow singleRowData)
        {
            // Load Object by dataRow
            this.FillKSAEntityFromRowData(singleRowData);

        }
        protected void FillKSAEntityFromRowData(DataRow returnRow)
        {

            DataColumnCollection columns = returnRow.Table.Columns;
            this.KSAID = (long)returnRow["KSAID"];
            this.KSAText = returnRow["KSAText"].ToString();

            if (columns.Contains("Active"))
            {
                if (returnRow["Active"] != DBNull.Value)
                {
                    this.Active = (bool)returnRow["Active"];
                }
            }

        }

    }
    #endregion

    [Serializable]
    public class KSAEntityManager : BusinessBase
    {
        public static  DataTable GetGradeEntityTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("GradeID", typeof(int));
            return dt;
        }
        public static List<KSAEntity> GetKSAEntityList(int seriesid,List<Grade>Grades, string keyword)
        {
            List<KSAEntity> items = new List<KSAEntity>();

            DataTable gradeEntity = GetGradeEntityTable();
            if (Grades!=null)
            {
                foreach (Grade grade in Grades)
                {
                    gradeEntity.Rows.Add(grade.GradeID);
                }
            }
            DbCommand commandWrapper = GetDbCommand("spr_SearchKSA");
            commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", seriesid));
            SqlParameter sqlGradeEntityparam = new SqlParameter("@GradeTable", SqlDbType.Structured);
            sqlGradeEntityparam.Value = gradeEntity;
            commandWrapper.Parameters.Add(sqlGradeEntityparam);
            commandWrapper.Parameters.Add(new SqlParameter("@KeyWord", keyword));
            DataTable dt = ExecuteDataTable(commandWrapper);
            foreach (DataRow row in dt.Rows)
            {
                items.Add(new KSAEntity(row));
            }
            return items;

        }

        public static List<KSAEntity> GetUnAssociatedKSAEntityList(int seriesid, int currentGrade, List<Grade> Grades, string keyword)
        {
            List<KSAEntity> items = new List<KSAEntity>();

            DataTable gradeEntity = GetGradeEntityTable();
            if (Grades != null)
            {
                foreach (Grade grade in Grades)
                {
                    gradeEntity.Rows.Add(grade.GradeID);
                }
            }
            DbCommand commandWrapper = GetDbCommand("spr_SearchAdminKSA");
            commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", seriesid));
            commandWrapper.Parameters.Add(new SqlParameter("@CurrentGrade", currentGrade));
            SqlParameter sqlGradeEntityparam = new SqlParameter("@GradeTable", SqlDbType.Structured);
            sqlGradeEntityparam.Value = gradeEntity;
            commandWrapper.Parameters.Add(sqlGradeEntityparam);
            commandWrapper.Parameters.Add(new SqlParameter("@KeyWord", keyword));
            DataTable dt = ExecuteDataTable(commandWrapper);
            foreach (DataRow row in dt.Rows)
            {
                items.Add(new KSAEntity(row));
            }
            return items;

        }

        public static List<KSAEntity> GetKSAEntityListForADocument(enumDocumentType   documentTypeID, long documentID)
        {
            List<KSAEntity> listCollection = new List<KSAEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllKSAForDocument", documentTypeID, documentID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    KSAEntity item = new KSAEntity(dataItems.Rows[i]);

                    listCollection.Add(item);
                }
            }
            return listCollection;
        }
    }
}
