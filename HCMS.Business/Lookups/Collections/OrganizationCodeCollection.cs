using System;
using System.Collections.Generic;

using HCMS.Business.Lookups;

namespace HCMS.Business.Lookups.Collections
{
    [Serializable]
    public class OrganizationCodeCollection : List<OrganizationCode>
    {
        #region Constructors

        public OrganizationCodeCollection()
        {
        }

        public OrganizationCodeCollection(List<OrganizationCode> dataItems) : base(dataItems)
        {
        }

        #endregion

        #region Methods

        public OrganizationCode Find(int organizationCodeID)
        {
            return base.Find(delegate(OrganizationCode oc) { return oc.OrganizationCodeID == organizationCodeID; });
        }

        public bool Contains(int organizationCodeID)
        {
            OrganizationCode finder = this.Find(organizationCodeID);
            return finder != null;
        }

        public OrganizationCodeCollection GetByRegion(int queryRegionID)
        {
            return new OrganizationCodeCollection(base.FindAll(OC => OC.RegionID == queryRegionID));
        }

        #endregion

    }
}
