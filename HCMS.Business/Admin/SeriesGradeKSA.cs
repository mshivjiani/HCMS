using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using HCMS.Business.Base;

namespace HCMS.Business.Admin
{
    [DataObject]
    public class SeriesGradeKSA : BusinessBase
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataTable SelectSeriesGradeKSA(int startRowIndex, int maximumRows, int seriesID, int gradeID)
        {
            DataTable table = ExecuteDataTable("spr_GetSeriesGradeKSAsPaged", startRowIndex, maximumRows, seriesID, gradeID);
            return table;
        }

        public static int SelectSeriesGradeKSATotalCount(int seriesID, int gradeID)
        {
            int count = (int)ExecuteScalar("spr_GetSeriesGradeKSATotalCount", seriesID, gradeID);
            return count;
        }


    }
}
