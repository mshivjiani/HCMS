using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;

namespace HCMS.Business.OrganizationChart.Positions.Adapters
{
    public class OrganizationChartPositionDataAdapter : WorkforcePlanningPositionDataAdapter, IEntityDataAdapter<OrganizationChartPosition>
    {
        public virtual void Fill(DataRow itemRow, OrganizationChartPosition item)
        {
            if (itemRow != null)
            {
                if (itemRow["OrganizationChartID"] != DBNull.Value)
                    item.OrganizationChartID = (int)itemRow["OrganizationChartID"];

                if (itemRow["GroupTypeID"] != DBNull.Value)
                {
                    if (Enum.IsDefined(typeof(enumOrgPositionGroupType), itemRow["GroupTypeID"]))
                        item.PositionGroupType = (enumOrgPositionGroupType)((int)itemRow["GroupTypeID"]);
                }

                if (itemRow["GroupTypeName"] != DBNull.Value)
                    item.PositionGroupTypeName = itemRow["GroupTypeName"].ToString();

                if (itemRow["PlacementTypeID"] != DBNull.Value)
                {
                    if (Enum.IsDefined(typeof(enumOrgPositionPlacementType), itemRow["PlacementTypeID"]))
                        item.PositionPlacementType = (enumOrgPositionPlacementType)((int)itemRow["PlacementTypeID"]);
                }

                if (itemRow["PlacementTypeName"] != DBNull.Value)
                    item.PositionPlacementTypeName = itemRow["PlacementTypeName"].ToString();

                if (itemRow["IsIncluded"] != DBNull.Value)
                    item.IsIncluded = (bool)itemRow["IsIncluded"];
                
                if (itemRow["IsInChartHierarchy"] != DBNull.Value)
                    item.IsInChartHierarchy = (bool)itemRow["IsInChartHierarchy"];

                if (itemRow["IsParentInChartHierarchy"] != DBNull.Value)
                    item.IsParentInChartHierarchy = (bool)itemRow["IsParentInChartHierarchy"];

                if (itemRow["ChartChildCount"] != DBNull.Value)
                    item.ChartChildCount = (int) itemRow["ChartChildCount"];

                base.Fill(itemRow, item);
            }
        }
    }
}
