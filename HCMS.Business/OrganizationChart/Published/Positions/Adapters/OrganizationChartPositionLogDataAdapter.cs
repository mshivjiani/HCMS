using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;
using HCMS.Business.OrganizationChart.Positions.Adapters;

namespace HCMS.Business.OrganizationChart.Published.Positions.Adapters
{
    public class OrganizationChartPositionLogDataAdapter : WorkforcePlanningPositionDataAdapter, IEntityDataAdapter<OrganizationChartPositionLog>
    {
        public virtual void Fill(DataRow itemRow, OrganizationChartPositionLog objectItem)
        {
            if (itemRow != null)
            {
                if (itemRow["OrganizationChartLogID"] != DBNull.Value)
                    objectItem.OrganizationChartLogID = (int)itemRow["OrganizationChartLogID"];

                if (itemRow["GroupTypeID"] != DBNull.Value)
                {
                    if (Enum.IsDefined(typeof(enumOrgPositionGroupType), itemRow["GroupTypeID"]))
                        objectItem.PositionGroupType = (enumOrgPositionGroupType)((int)itemRow["GroupTypeID"]);
                }

                if (itemRow["GroupTypeName"] != DBNull.Value)
                    objectItem.PositionGroupTypeName = itemRow["GroupTypeName"].ToString();

                if (itemRow["PlacementTypeID"] != DBNull.Value)
                {
                    if (Enum.IsDefined(typeof(enumOrgPositionPlacementType), itemRow["PlacementTypeID"]))
                        objectItem.PositionPlacementType = (enumOrgPositionPlacementType)((int)itemRow["PlacementTypeID"]);
                }

                if (itemRow["PlacementTypeName"] != DBNull.Value)
                    objectItem.PositionPlacementTypeName = itemRow["PlacementTypeName"].ToString();

                if (itemRow["IsIncluded"] != DBNull.Value)
                    objectItem.IsIncluded = (bool)itemRow["IsIncluded"];

                if (itemRow["IsInChartHierarchy"] != DBNull.Value)
                    objectItem.IsInChartHierarchy = (bool)itemRow["IsInChartHierarchy"];

                if (itemRow["IsParentInChartHierarchy"] != DBNull.Value)
                    objectItem.IsParentInChartHierarchy = (bool)itemRow["IsParentInChartHierarchy"];

                base.Fill(itemRow, objectItem);
            }
        }
    }
}
