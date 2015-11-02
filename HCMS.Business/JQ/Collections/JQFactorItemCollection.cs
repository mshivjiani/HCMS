using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using HCMS.Business.JQ;

namespace HCMS.Business.JQ.Collections
{
    [Serializable]
    public class JQFactorItemCollection : List<JQFactorItem>
    {
        #region Constructors

        public JQFactorItemCollection()
        {
            // Empty Constructor
        }

        public JQFactorItemCollection(List<JQFactorItem> dataItems) : base(dataItems)
        {
            // Fill by List<JQFactorItem>
        }

        public JQFactorItemCollection(List<JQFactorItemEntity> dataItems)
        {
            // Fill by List<JQFactorItemEntity>
            if (dataItems != null)
            {
                foreach (JQFactorItemEntity entity in dataItems)
                    this.Add(new JQFactorItem(entity));
            }
        }

        public JQFactorItemCollection(DataTable dataItems)
        {
            // Fill by DataTable
            if (dataItems != null)
            {
                foreach (DataRow dr in dataItems.Rows)
                {
                    JQFactorItem newItem = new JQFactorItem(dr);
                    newItem.TagName = string.Concat("FI_", newItem.JQFactorItemID.ToString());

                    this.Add(newItem);
                }
            }
        }

        #endregion

        #region Methods

        public bool Contains(long queryJQFactorItemID)
        {
            return this.Find(queryJQFactorItemID) != null;
        }

        public JQFactorItem Find(long queryJQFactorItemID)
        {
            return base.Find(JQFI => JQFI.JQFactorItemID == queryJQFactorItemID);
        }

        public bool ContainsFactor(long queryJQFactorID)
        {
            return base.Find(JQFI => JQFI.JQFactorID == queryJQFactorID) != null;
        }

        public JQFactorItemCollection FindByFactor(long queryJQFactorID)
        {
            return new JQFactorItemCollection(base.FindAll(JQFI => JQFI.JQFactorID == queryJQFactorID));
        }

        public void RemoveByFactor(long queryJQFactorID)
        {
            this.RemoveAll(JQFI => JQFI.JQFactorID == queryJQFactorID);
        }

        #endregion
    }
}
