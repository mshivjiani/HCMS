using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

using HCMS.Business.Base;
using HCMS.Business.Common;

namespace HCMS.Business.Search
{
    public static class Search
    {
        public static DataSet SearchPositionDescription(int userID,
            int searchType,
            long? positionDescriptionID, char? isStandardPD, int? PositionDescriptionTypeID, int? jobSeries,
            int? workflowStatusID, int? proposedGrade,
            string opmPositionTitle, string agencyPositionTitle,
            int? organizationCodeID, string pdCreator,
            int? pdNumberType, string fppsPDID

            )
        {
            return SearchPositionDescription(userID, searchType, positionDescriptionID, isStandardPD, PositionDescriptionTypeID,
                jobSeries, workflowStatusID, proposedGrade, opmPositionTitle, agencyPositionTitle,
                organizationCodeID, pdCreator, pdNumberType, fppsPDID, null,null);

        }

        public static DataSet SearchPositionDescription(int userID,
          int searchType,
          long? positionDescriptionID, char? isStandardPD, int? PositionDescriptionTypeID, int? jobSeries,
          int? workflowStatusID, int? proposedGrade,
          string opmPositionTitle, string agencyPositionTitle,
          int? organizationCodeID, string pdCreator,
          int? pdNumberType, string fppsPDID
           , string keyword, int? regionID
          )
        {
            object[] parameters = new object[] 
            { 
                userID,
                searchType,
                positionDescriptionID,
                isStandardPD,
                PositionDescriptionTypeID,
                jobSeries,
                workflowStatusID,
                proposedGrade,
                opmPositionTitle,
                agencyPositionTitle,
                organizationCodeID,
                pdCreator,
                pdNumberType,
                fppsPDID,
                keyword,
                regionID 


            };

            DataSet dsPositionDescription = BusinessBase.ExecuteDataSet("[dbo].[spr_SearchPositionDescription]", parameters);
            return dsPositionDescription;
        }
    }
}
