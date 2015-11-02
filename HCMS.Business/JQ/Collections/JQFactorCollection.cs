using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using HCMS.Business.JQ;

namespace HCMS.Business.JQ.Collections
{
      [Serializable]
    public class JQFactorCollection : List<JQFactor>
    {
        #region Constructors

        public JQFactorCollection()
        {
            // Empty Constructor
        }

        public JQFactorCollection(List<JQFactor> dataItems) : base(dataItems)
        {
            // Fill by List<JQFactor>
        }

        public JQFactorCollection(List<JQFactorEntity> dataItems)
        {
            // Fill by List<JQFactorEntity>
            if (dataItems != null)
            {
                foreach (JQFactorEntity entity in dataItems)
                    this.Add(new JQFactor(entity));
            }
        }

        public JQFactorCollection(DataTable dataItems)
        {
            // Fill by DataTable
            if (dataItems != null)
            {
                foreach (DataRow dr in dataItems.Rows)
                {
                    JQFactor newItem = new JQFactor(dr);
                    newItem.TagName = string.Concat("F_", newItem.JQFactorID.ToString());

                    this.Add(newItem);
                }
            }
        }

        #endregion

        #region Methods

        public bool Contains(long queryJQFactorID)
        {
            return this.Find(queryJQFactorID) != null;
        }

        public JQFactor Find(long queryJQFactorID)
        {
            return base.Find(JQF => JQF.JQFactorID == queryJQFactorID);
        }

        #endregion
    }
}
