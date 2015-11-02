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
    public class TaskStatement : BusinessBase
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataTable SelectTaskStatement(int startRowIndex, int maximumRows)
        {
            DataTable table = ExecuteDataTable("spr_GetTaskStatementsPaged", startRowIndex, maximumRows);
            return table;
        }

        public static int SelectTaskStatementTotalCount()
        {
            int count = (int)ExecuteScalar("spr_GetTaskStatementsTotalCount");
            return count;
        }
    }

    //public class TaskStatementEntity
    //{
    //    public long ID { get; set; }
    //    public string Name { get; set; }
    //}
}
