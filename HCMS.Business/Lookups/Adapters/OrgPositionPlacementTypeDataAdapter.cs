using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;

namespace HCMS.Business.Lookups.Adapters
{
    public class OrgPositionPlacementTypeDataAdapter : IEntityDataAdapter<OrgPositionPlacementType>
    {
        public virtual void Fill(DataRow returnRow, OrgPositionPlacementType item)
        {
            if (returnRow != null)
            {
                if (returnRow["PlacementTypeID"] != DBNull.Value)
                    item.PlacementTypeID = (int)returnRow["PlacementTypeID"];

                if (returnRow["PlacementTypeName"] != DBNull.Value)
                    item.PlacementTypeName = returnRow["PlacementTypeName"].ToString();
            }
        }
    }
}
