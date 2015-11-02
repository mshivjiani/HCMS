using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.JNP
{
    public class JNPSearchResult
    {
        public long JNPID { get; set; }
        public int JNPTypeID { get; set; }
        public int JNPOptionTypeID { get; set; }
        public bool IsStandardJNP { get; set; }
        public bool IsDEU { get; set; }
        public bool IsMP { get; set; }
        public bool IsExceptedService { get; set; }
        public int PayPlanID { get; set; }
        public int SeriesID { get; set; }
        public string SeriesName { get; set; }
        public bool IsInterdisciplinary { get; set; }
        public int AdditionalSeriesID { get; set; }
        public int LowestAdvertisedGrade { get; set; }
        public int HighestAdvertisedGrade { get; set; }
        public int RegionID { get; set; }
        public string RegionName { get; set; }
        public int OrganizationCodeID { get; set; }
        public string OrganizationCode { get; set; }
        public string OrganizationName { get; set; }
        public int OldOrganizationCode { get; set; }
        public string JNPTitle { get; set; }
        public long FullPDID { get; set; }
        public long AdditionalPDID { get; set; }
        public long? JobAnalysisID { get; set; }
        public long? CategoryRatingID { get; set; }
        public long? JobQuestionnaireID { get; set; }
        public int CreatedByID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool ResultedInSuccessfulHiring { get; set; }
        public string VacancyID { get; set; }
        public int JNPWorkflowStatusID {get; set;}
        public string JNPWorkflowStatus { get; set; }
        public string JNPWorkflowStatusDescription { get; set; }
        public string AuthorFullName { get; set; }

        public string OrganizationDetailLineLegacy
        {
            get
            {
                return string.Format("{0} | {1} | {2}", this.OldOrganizationCode.ToString(), this.OrganizationCode, this.OrganizationName).Trim();
            }
        }
        
        public int CheckedID { get; set; }
        public int CheckedActionTypeID { get; set; }
        public int CheckedByID { get; set; }
        public string CheckedByFullName { get; set; }
        public DateTime? CheckedDate { get; set; }
        public bool CanView { get; set; }
        public bool CanEdit { get; set; }
        public bool CanContinueEdit { get; set; }
        public bool CanFinishEdit { get; set; }
        public bool CanCopyStartNew { get; set; }
    }
}
