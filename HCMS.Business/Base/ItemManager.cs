using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HCMS.Business.Base
{
    public class ItemManager:BusinessBase
    {
        
        public ItemManager()
        {
        }

        public  bool ValidateKeyField(Guid primaryKeyID)
        {
            return base.ValidateKeyField(primaryKeyID);
        }

        public  bool ValidateKeyField(int primaryKeyID)
        {
            return base.ValidateKeyField(primaryKeyID);
        }

        protected bool ValidateKeyField(long primaryKeyID)
        {
            return base.ValidateKeyField (primaryKeyID );
        }


    }
}
