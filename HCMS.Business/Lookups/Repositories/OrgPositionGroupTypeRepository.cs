using System.Collections.Generic;

using HCMS.Business.Base;
using HCMS.Business.Lookups.Adapters;

namespace HCMS.Business.Lookups.Repositories
{
    public class OrgPositionGroupTypeRepository : RepositoryBase<OrgPositionGroupTypeRepository, OrgPositionGroupType, OrgPositionGroupTypeDataAdapter>
    {
        public OrgPositionGroupType GetByID(int loadByID)
        {
            return base.GetItem("spr_GetOrgPositionGroupTypeByID", loadByID);
        }

        public IList<OrgPositionGroupType> GetPositionGroupTypes()
        {
            return base.GetItemList("spr_GetAllOrgPositionGroupTypes");
        }
    }
}
