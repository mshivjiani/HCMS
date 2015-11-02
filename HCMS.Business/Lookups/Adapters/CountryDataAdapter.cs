using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HCMS.Business.Base;

namespace HCMS.Business.Lookups.Adapters
{
    public class CountryDataAdapter : IEntityDataAdapter<Country>
    {
        public virtual void Fill(DataRow returnRow, Country item)
        {
            if (returnRow != null)
            {
                if (returnRow["CountryID"] != DBNull.Value)
                    item.CountryID = (int)returnRow["CountryID"];

                if (returnRow["CountryCode"] != DBNull.Value)
                    item.CountryCode = returnRow["CountryCode"].ToString();

                if (returnRow["CountryName"] != DBNull.Value)
                    item.CountryName = returnRow["CountryName"].ToString();
            }
        }
    }
}
