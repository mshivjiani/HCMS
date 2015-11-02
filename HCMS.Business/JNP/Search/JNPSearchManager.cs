using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using HCMS.Business.Common;
using HCMS.Business.Base;

namespace HCMS.Business.JNP
{
    public class JNPSearchManager : BusinessBase
    {

        public IList<JNPSearchResult> JNPBasicSearch(int userID, int searchType, long? jnpID = null, long? pdID = null, string fppspdID = null, string vacancyID = null)
        {

            return JNPSearch(userID, searchType, jnpID, pdID, fppspdID, vacancyID, null, null, null, null, null, null, null, null, null, null, null);

        }

      
        public IList<JNPSearchResult> JNPAdvanceSearch(int userID, int searchType, bool? jnpType = null, int? seriesID = null, int? jnpStatusID = null, string author = null, string opmPositionTitle = null,
                            int? regionID = null, int? proposedGrade = null, int? orgCode = null,
                            bool? packageSuccessRate = null, string search_keyword = null, int? keyword_search_doctype = null)
        {
            return JNPSearch(userID, searchType, null, null, null, null, jnpType, seriesID, jnpStatusID, author, opmPositionTitle, regionID, proposedGrade, orgCode, packageSuccessRate, search_keyword, keyword_search_doctype);
        }

        public IList<JNPSearchResult> JNPSearch(int userID, int searchType, long? jnpID = null, long? pdID = null, string fppspdID = null, string vacancyID = null,
                            bool? jnpType = null, int? seriesID = null, int? jnpStatusID = null,
                            string author = null, string opmPositionTitle = null,
                            int? regionID = null, int? proposedGrade = null, int? orgCode = null,
                            bool? packageSuccessRate = null, string search_keyword = null, int? keyword_search_doctype = null)
        {

            object[] parameters = new object[] 
            { 
                userID,
                searchType,
                jnpID,
                pdID,
                fppspdID,
                vacancyID,
                jnpType,
                seriesID,
                jnpStatusID,
                author,
                opmPositionTitle,
                regionID,
                proposedGrade,
                orgCode,
                packageSuccessRate,
                search_keyword,
                keyword_search_doctype
            };

            return GetJNP(userID, parameters);
        }


        public IList<JNPSearchResult> GetJNP(int userID, object[] parameterValues)
        {
            IList<JNPSearchResult> collection = new List<JNPSearchResult>();

            try
            {
                DataSet ds = BusinessBase.ExecuteDataSet("spr_SearchJNP", parameterValues);
                DataTable table = ds.Tables[0];

                foreach(DataRow row in table.Rows)
                {
                    collection.Add(Mapper(row));

                }
            }
            catch (Exception ex)
            {
                //string message = ex.Message;
                HandleException(ex);
            }

            return collection;
        }

        private JNPSearchResult Mapper(DataRow row)
        {
            JNPSearchResult searchresult = new JNPSearchResult();

            searchresult.JNPID = long.Parse(row["JNPID"].ToString());
            searchresult.JNPTypeID = int.Parse(row["JNPTypeID"].ToString());
            searchresult.JNPOptionTypeID = int.Parse(row["JNPOptionTypeID"].ToString());
            searchresult.IsStandardJNP = bool.Parse(row["IsStandardJNP"].ToString());
            searchresult.IsDEU = bool.Parse(row["IsDEU"].ToString());
            searchresult.IsMP = ( (row["IsMP"] != DBNull.Value) ? (bool)row["IsMP"] : false);
            searchresult.IsExceptedService = ((row["IsExceptedService"] != DBNull.Value) ? (bool)row["IsExceptedService"] : false);
            searchresult.PayPlanID = int.Parse(row["PayPlanID"].ToString());
            searchresult.SeriesID = int.Parse(row["SeriesID"].ToString());
            searchresult.IsInterdisciplinary = ((row["IsInterdisciplinary"] != DBNull.Value) ? Convert.ToBoolean(row["IsInterdisciplinary"]) : false);
            searchresult.AdditionalSeriesID = ((row["AdditionalSeriesID"] != DBNull.Value) ? (int)row["AdditionalSeriesID"] : -1);
            searchresult.LowestAdvertisedGrade = int.Parse(row["LowestAdvertisedGrade"].ToString());
            searchresult.HighestAdvertisedGrade = int.Parse(row["HighestAdvertisedGrade"].ToString());
            searchresult.RegionID = int.Parse(row["RegionID"].ToString());
            searchresult.OrganizationCodeID = int.Parse(row["OrganizationCodeID"].ToString());
            searchresult.OrganizationCode = ((row["OrganizationCode"] != DBNull.Value) ? row["OrganizationCode"].ToString() : string.Empty);
            searchresult.OrganizationName = ((row["OrganizationName"] != DBNull.Value) ? row["OrganizationName"].ToString() : string.Empty);
            searchresult.OldOrganizationCode = int.Parse(row["OldOrganizationCode"].ToString());
            searchresult.JNPTitle = ((row["JNPTitle"] != DBNull.Value) ? row["JNPTitle"].ToString() : string.Empty);
            searchresult.FullPDID = long.Parse(row["PositionDescriptionID"].ToString());
            searchresult.AdditionalPDID = ((row["AdditionalPDID"] != DBNull.Value) ? (long)row["AdditionalPDID"] : -1);
            searchresult.JobAnalysisID = ((row["JAID"] != DBNull.Value) ? (long)row["JAID"] : -1);
            searchresult.CategoryRatingID = ((row["CRID"] != DBNull.Value) ? (long)row["CRID"] : -1);
            searchresult.JobQuestionnaireID = ((row["JQID"] != DBNull.Value) ? (long)row["JQID"] : -1);
            searchresult.CreatedByID = int.Parse(row["CreatedByID"].ToString());
            searchresult.UpdateDate = ((row["UpdateDate"] != DBNull.Value) ? DateTime.Parse(row["UpdateDate"].ToString()) : new DateTime?() );
            searchresult.ResultedInSuccessfulHiring = ((row["ResultedInSuccessfulHiring"] != DBNull.Value) ? (bool)row["ResultedInSuccessfulHiring"] : false);
            searchresult.VacancyID = ((row["VacancyID"] != DBNull.Value) ? row["VacancyID"].ToString() : string.Empty);
            searchresult.JNPWorkflowStatusID = int.Parse(row["JNPWorkflowStatusID"].ToString());
            searchresult.AuthorFullName = row["AuthorFullName"].ToString();
            searchresult.JNPWorkflowStatus = row["JNPWorkflowStatus"].ToString();
            searchresult.JNPWorkflowStatusDescription = ((row["JNPWorkflowStatusDescription"] != DBNull.Value) ? row["WorkflowStatusDescription"].ToString() : string.Empty);
            searchresult.CheckedByID = ((row["CheckedByID"] != DBNull.Value) ? (int)row["CheckedByID"] : -1);
            searchresult.CheckedActionTypeID = ((row["CheckedActionTypeID"] != DBNull.Value) ? (int)row["CheckedActionTypeID"] : -1);
            searchresult.CheckedByFullName = ((row["CheckedByFullName"] != DBNull.Value) ? row["CheckedByFullName"].ToString() : string.Empty);
            searchresult.CheckedDate = ((row["CheckedDate"] != DBNull.Value) ? DateTime.Parse(row["CheckedDate"].ToString()) : new DateTime?());
            searchresult.CanView = ((row["CanViewJNP"] != DBNull.Value) ? (bool)row["CanViewJNP"] : false);
            searchresult.CanEdit = ((row["CanEditJNP"] != DBNull.Value) ? (bool)row["CanEditJNP"] : false);
            searchresult.CanContinueEdit = ((row["CanContinueEditJNP"] != DBNull.Value) ? (bool)row["CanContinueEditJNP"] : false);
            searchresult.CanFinishEdit = ((row["CanFinishEditJNP"] != DBNull.Value) ? (bool)row["CanFinishEditJNP"] : false);
            searchresult.CanCopyStartNew = ((row["CanCopyStartNewJNP"] != DBNull.Value) ? (bool)row["CanCopyStartNewJNP"] : false);

            return searchresult;
        }

    }
}
