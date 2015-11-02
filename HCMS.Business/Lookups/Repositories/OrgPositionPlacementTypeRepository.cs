using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using HCMS.Business.Lookups.Adapters;

namespace HCMS.Business.Lookups.Repositories
{
    public class OrgPositionPlacementTypeRepository : RepositoryBase<OrgPositionPlacementTypeRepository, OrgPositionPlacementType, OrgPositionPlacementTypeDataAdapter>
    {
        public IList<OrgPositionPlacementType> GetPositionPlacementTypes()
        {
            return base.GetItemList("spr_GetAllOrgPositionPlacementTypes");
        }
    }
}