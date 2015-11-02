using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using HCMS.Business.Base;
using HCMS.Business.JNP.Collections;

namespace HCMS.Business.JNP 

{
    [Serializable]
    public class JNPSearch : BusinessBase
    {
        #region Methods

        public static JNPackageCollection Search(int? seriesID = null, int? gradeID = null)
        {
            DbCommand commandWrapper = GetDbCommand("spr_SearchPublishedJNP");
            JNPackageCollection searchResults = new JNPackageCollection();

            try
            {
                const int defaultValue = -1;

                SetParameter<int>(commandWrapper, "@SeriesID", seriesID, defaultValue);
                SetParameter<int>(commandWrapper, "@HighGradeID", gradeID, defaultValue);

                searchResults = new JNPackageCollection(ExecuteDataTable(commandWrapper));
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
