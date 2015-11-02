using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using HCMS.Business.JQ;

namespace HCMS.Business.JQ.Collections
{
    [Serializable]
    public class RatingScaleResponseCollection : List<RatingScaleResponse>
    {
        #region Constructors

        public RatingScaleResponseCollection()
        {
            // Empty Constructor
        }

        public RatingScaleResponseCollection(List<RatingScaleResponse> dataItems) : base(dataItems)
        {
            // Fill by List<RatingScaleResponse>
        }

        public RatingScaleResponseCollection(List<RatingScaleResponseEntity> dataItems)
        {
            // Fill by List<RatingScaleResponseEntity>
            if (dataItems != null)
            {
                foreach (RatingScaleResponseEntity entity in dataItems)
                    this.Add(new RatingScaleResponse(entity));
            }
        }

        public RatingScaleResponseCollection(DataTable dataItems)
        {
            // Fill by DataTable
            if (dataItems != null)
            {
                foreach (DataRow dr in dataItems.Rows)
                {
                    RatingScaleResponse newItem = new RatingScaleResponse(dr);
                    newItem.TagName = string.Concat("RSR_", newItem.JQResponseID.ToString());

                    this.Add(newItem);
                }
            }
        }

        #endregion

        #region Methods

        public bool Contains(long queryJQResponseID)
        {
            return this.Find(queryJQResponseID) != null;
        }

        public RatingScaleResponse Find(long queryJQResponseID)
        {
            return base.Find(RSR => RSR.JQResponseID == queryJQResponseID);
        }

        public bool ContainsScale(long queryRatingScaleID)
        {
            return base.Find(RSR => RSR.JQRatingScaleID == queryRatingScaleID) != null;
        }

        public RatingScaleResponseCollection FindByScale(long queryRatingScaleID)
        {
            return new RatingScaleResponseCollection(base.FindAll(RSR => RSR.JQRatingScaleID == queryRatingScaleID));
        }

        public void RemoveByScale(long queryRatingScaleID)
        {
            this.RemoveAll(RSR => RSR.JQRatingScaleID == queryRatingScaleID);
        }

        #endregion
    }
}
