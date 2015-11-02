using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Base;
using HCMS.Business.Lookups.Adapters;

namespace HCMS.Business.Lookups.Repositories
{
    public class CountryRepository : RepositoryBase<CountryRepository, Country, CountryDataAdapter>
    {
        public IList<Country> GetCountries()
        {
            return base.GetItemList("spr_GetAllCountries");
        }
    }
}
