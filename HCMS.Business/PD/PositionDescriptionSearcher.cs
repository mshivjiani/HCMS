using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.PD.Collections;

namespace HCMS.Business.PD
{
    public enum PublishTypes : short
    {
        All = -1,
        NonPublishedOnly = 0,
        PublishedOnly = 1,
        
    }

    /// <summary>
    /// Object designed to do generic searching on the Position Description
    /// Feel free to add to it
    /// </summary>
    public abstract class PositionDescriptionSearcher : BusinessBase
    {
        #region Methods

        public static PositionDescriptionCollection Search(int ? seriesID = null, int ? gradeID = null, int ? organizationCodeID = null, PublishTypes selectedPublishType = PublishTypes.All)
        {
            DbCommand commandWrapper = GetDbCommand("spr_SearchPositionDescriptionsByCriteria");
            PositionDescriptionCollection searchResults = new PositionDescriptionCollection();

            try
            {
                const int defaultValue = -1;

                SetParameter<int>(commandWrapper, "@SeriesID", seriesID, defaultValue);
                SetParameter<int>(commandWrapper, "@GradeID", gradeID, defaultValue);
                SetParameter<int>(commandWrapper, "@OrganizationCodeID", organizationCodeID, defaultValue);
                SetParameter<int>(commandWrapper, "@IsPublished", (short) selectedPublishType, (short) PublishTypes.All);

                searchResults = new PositionDescriptionCollection(ExecuteDataTable(commandWrapper));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return searchResults;
        }

        #endregion
    }
}
