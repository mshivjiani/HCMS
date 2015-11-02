using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;

namespace HCMS.Business.Lookups.Adapters
{
    public class OrgPositionGroupTypeDataAdapter : IEntityDataAdapter<OrgPositionGroupType>
    {
        public virtual void Fill(DataRow returnRow, OrgPositionGroupType item)
        {
            if (returnRow != null)
            {
                if (returnRow["GroupTypeID"] != DBNull.Value)
                    item.GroupTypeID = (int)returnRow["GroupTypeID"];

                if (returnRow["GroupTypeName"] != DBNull.Value)
                    item.GroupTypeName = returnRow["GroupTypeName"].ToString();

                if (returnRow["GroupTypeID"] != DBNull.Value)
                {
                    if (Enum.IsDefined(typeof(enumOrgPositionGroupType), returnRow["GroupTypeID"]))
                        item.GroupType = (enumOrgPositionGroupType)((int)returnRow["GroupTypeID"]);
                }
            }
        }
    }
}
