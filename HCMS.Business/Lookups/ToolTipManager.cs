using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;

namespace HCMS.Business.Lookups
{
    [System.ComponentModel.DataObject]
    public class ToolTipManager : BusinessBase
    {
        public ToolTipEntity GetToolTipByID(long id)
        {
            ToolTipEntity entity;

            DataTable dt = ExecuteDataTable("spr_GetToolTipByID", id);

            if (dt != null && dt.Rows.Count > 0)
            {
                entity = FillObjectFromRowData(dt.Rows[0]);
            }
            else
            {
                throw new Exception("You cannot create a ToolTipEntity from a null data table.");
            }

            return entity;
        }

        public ToolTipEntity FillObjectFromRowData(DataRow row)
        {
            ToolTipEntity entity = new ToolTipEntity();

            if (row["ToolTipID"] != DBNull.Value)
                entity.ID = (long)row["ToolTipID"];

            if (row["ToolTipCaption"] != DBNull.Value)
                entity.Caption = (string)row["ToolTipCaption"];

            if (row["ToolTipDescription"] != DBNull.Value)
                entity.Description = (string)row["ToolTipDescription"];

            return entity;
        }
    } 
}
