using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.JQ;

namespace HCMS.Business.JQ.Collections
{
    public class JQRatingScaleCollection : List<JQRatingScale>
    {
        #region Constructors

        public JQRatingScaleCollection()
        {
            // Empty Constructor
        }

        public JQRatingScaleCollection(List<JQRatingScale> dataItems) : base(dataItems)
        {
            // Fill by List<JQFactorItem>
        }

        public JQRatingScaleCollection(DataTable dataItems)
        {
            // Fill by DataTable
            if (dataItems != null)
            {
                foreach (DataRow dr in dataItems.Rows)
                {
                    JQRatingScale newItem = new JQRatingScale(dr);
                    newItem.TagName = string.Concat("JQRS_", newItem.RatingScaleID.ToString());

                    this.Add(newItem);
                }
            }
        }

        #endregion

        #region Methods

        public bool Contains(long queryRatingScaleID)
        {
            return this.Find(queryRatingScaleID) != null;
        }

        public JQRatingScale Find(long queryRatingScaleID)
        {
            return base.Find(RS => RS.RatingScaleID == queryRatingScaleID);
        }

        #endregion
    }
}
