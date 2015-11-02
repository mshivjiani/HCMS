using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;

namespace HCMS.Business.JNPTracker
{
    public class TrackerItem : BusinessBase
    {
        #region [ Constructors ]
        private TrackerItem(DataRow dataRow)
        {
            FillObjectFromDataRow(dataRow);
        }
        #endregion

        #region [ Constructor Helper Methods ]
        private void FillObjectFromDataRow(DataRow dataRow)
        {
            try
            {
                DataColumnCollection columns = dataRow.Table.Columns;
                JNPID = (long)dataRow["JNPID"];
                JNPTypeID = (int)dataRow["JNPTypeID"];
                JNPOptionTypeID = (int)dataRow["JNPOptionTypeID"];
                if (dataRow["IsStandardJNP"] != DBNull.Value) IsStandardJNP = (bool)dataRow["IsStandardJNP"];
                if (dataRow["IsDEU"] != DBNull.Value) IsStandardJNP = (bool)dataRow["IsDEU"];
                PayPlanID = (int)dataRow["PayPlanID"];
                SeriesID = (int)dataRow["SeriesID"];
                if (dataRow["Grade"] != DBNull.Value) Grade = (string)dataRow["Grade"];
                if (dataRow["IsInterdisciplinary"] != DBNull.Value) IsInterdisciplinary = (bool)dataRow["IsInterdisciplinary"];
                if (dataRow["AdditionalSeriesID"] != DBNull.Value) AdditionalSeriesID = (int)dataRow["AdditionalSeriesID"];
                LowestAdvertisedGrade = (int)dataRow["LowestAdvertisedGrade"];
                HighestAdvertisedGrade = (int)dataRow["HighestAdvertisedGrade"];
                if (dataRow["RegionID"] != DBNull.Value) RegionID = (int)dataRow["RegionID"];

                dataRow["OrganizationCodeID"] = (int)dataRow["OrganizationCodeID"];

                if (columns.Contains("OrganizationCode"))
                {
                    if(dataRow ["OrganizationCode"]!=DBNull.Value)
                    {
                    OrganizationCode = (string)dataRow["OrganizationCode"];
                    }
                }
                if (columns.Contains("OrganizationCodeName"))
                {
                    if (dataRow["OrganizationName"] != DBNull.Value) OrganizationName = (string)dataRow["OrganizationName"];
                }
                if (columns.Contains("OldOrganizationCode"))
                {
                    if (dataRow["OldOrganizationCode"] != DBNull.Value) OldOrganizationCode = dataRow["OldOrganizationCode"].ToString ();
                }
                if (dataRow["JNPTitle"] != DBNull.Value) JNPTitle = (string)dataRow["JNPTitle"];
                if (dataRow["JNPTitleCombined"] != DBNull.Value) JNPTitleCombined = (string)dataRow["JNPTitleCombined"];

                if (dataRow["FullPDID"] != DBNull.Value) FullPDID = (long)dataRow["FullPDID"];
                if (dataRow["AdditionalPDID"] != DBNull.Value) AdditionalPDID = (long)dataRow["AdditionalPDID"];

                if (dataRow["JAID"] != DBNull.Value) JAID = (long)dataRow["JAID"];
                if (dataRow["CRID"] != DBNull.Value) CRID = (long)dataRow["CRID"];
                if (dataRow["JQID"] != DBNull.Value) JQID = (long)dataRow["JQID"];

                if (dataRow["CreatedByID"] != DBNull.Value) CreatedByID = (int)dataRow["CreatedByID"];
                if (dataRow["CreatedBy"] != DBNull.Value) CreatedBy = (string)dataRow["CreatedBy"];
                if (dataRow["CreateDate"] != DBNull.Value) CreateDate = (DateTime)dataRow["CreateDate"];
                //if (dataRow["CreateDateShort"] != DBNull.Value) CreateDateShort = (string)dataRow["CreateDateShort"];
                if (dataRow["CreateDateShort"] != DBNull.Value) CreateDateShort = Convert.ToDateTime(dataRow["CreateDateShort"]);

                if (dataRow["UpdatedByID"] != DBNull.Value) UpdatedByID = (int)dataRow["UpdatedByID"];
                if (dataRow["UpdatedBy"] != DBNull.Value) UpdatedBy = (string)dataRow["UpdatedBy"];
                if (dataRow["UpdateDate"] != DBNull.Value) UpdateDate = (DateTime)dataRow["UpdateDate"];
                //if (dataRow["UpdateDateShort"] != DBNull.Value) UpdateDateShort = (string)dataRow["UpdateDateShort"];
                if (dataRow["UpdateDateShort"] != DBNull.Value) UpdateDateShort = Convert.ToDateTime(dataRow["UpdateDateShort"]);

                if (dataRow["JNPWorkflowStatusID"] != DBNull.Value) JNPWorkflowStatusID = (int)dataRow["JNPWorkflowStatusID"];
                if (dataRow["JNPWorkflowStatus"] != DBNull.Value) JNPWorkflowStatus = (string)dataRow["JNPWorkflowStatus"];

                if (dataRow["JNPScheduleStatus"] != DBNull.Value) JNPScheduleStatus = (enumScheduleStatus)dataRow["JNPScheduleStatus"];
                if (dataRow["JNPNextScheduleStatus"] != DBNull.Value) JNPNextScheduleStatus = (string)dataRow["JNPNextScheduleStatus"];

                if (dataRow["CheckID"] != DBNull.Value) CheckID = (long)dataRow["CheckID"];
                if (dataRow["CheckedOutByID"] != DBNull.Value) CheckedOutByID = (int)dataRow["CheckedOutByID"];
                if (dataRow["CheckedOutDate"] != DBNull.Value) CheckedOutDate = (DateTime)dataRow["CheckedOutDate"];
                if (dataRow["CheckedOutBy"] != DBNull.Value) CheckedOutBy = (string)dataRow["CheckedOutBy"];

                CanViewJNP = (bool)dataRow["CanViewJNP"];
                CanEditJNP = (bool)dataRow["CanEditJNP"];
                CanContinueEditJNP = (bool)dataRow["CanContinueEditJNP"];
                CanFinishEditJNP = (bool)dataRow["CanFinishEditJNP"];
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }
        #endregion

        #region [ Instance Helper Methods ]
        public static TrackerItem GetForUser(int userID, long JNPID)
        {
            TrackerItem trackerItem = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetTrackerItemByID", userID, JNPID);

                if (dataTable.Rows.Count == 1)
                {
                    DataRow dataRow = dataTable.Rows[0];

                    if (dataRow != null)
                    {
                        trackerItem = new TrackerItem(dataRow);
                    }
                }

            }
            catch (Exception ex)
            {
                trackerItem = null;
                ExceptionBase.HandleException(ex);
            }

            return trackerItem;
        }
        #endregion

        #region [ Collection Helper Methods ]
        public static TrackerItemCollection GetCollectionForUser(int userID)
        {
            TrackerItemCollection collection = null;

            try
            {
                DataTable table = ExecuteDataTable("spr_GetAllTrackerItemByUserID", userID);

                // fill collection list
                collection = TrackerItem.GetCollection(table);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return collection;
        }
        private static TrackerItemCollection GetCollection(DataTable table)
        {
            TrackerItemCollection collection = new TrackerItemCollection();

            try
            {
                if (table != null)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        TrackerItem item = new TrackerItem(table.Rows[i]);
                        collection.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return collection;
        }
        #endregion

        #region [ Public Instance Methods ]
        public DataTable GetDocumentStatusTable()
        {
            DataTable table = null;

            try
            {
                table = ExecuteDataTable("spr_GetJNPRelatedDocumentsStatusByJNPID", this.JNPID);
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }

            return table;
        }

        public static enumDocumentType GetActiveDocumentType(long JNPID)
        {
            enumDocumentType activeDocumentType = enumDocumentType.Unknown;

            try
            {
                activeDocumentType = (enumDocumentType)ExecuteScalar("spr_GetActiveDocumentType", JNPID);
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }

            return activeDocumentType;
        }
        #endregion
        private string _oldOrganizationCode = "N/A";

        #region [ Public Properties ]
        #region [ from vw_JobAnnouncementPackages ]
        public long JNPID { get; set; }
        public int JNPTypeID { get; set; }
        public int JNPOptionTypeID { get; set; }
        public bool? IsStandardJNP { get; set; }
        public bool? IsDEU { get; set; }
        //public bool? IsMP { get; set; }
        //public bool? IsExceptedService { get; set; }
        public int PayPlanID { get; set; }
        public int SeriesID { get; set; }
        public string Grade { get; set; }
        public bool? IsInterdisciplinary { get; set; }
        public int? AdditionalSeriesID { get; set; }
        public int LowestAdvertisedGrade { get; set; }
        public int HighestAdvertisedGrade { get; set; }
        public int? RegionID { get; set; }
        public int OrganizationCodeID { get; set; }
        public string OrganizationCode { get; set; }
        public string OldOrganizationCode { get { return this._oldOrganizationCode; } set { this._oldOrganizationCode = value; } }
        public string OrganizationCodeLegacy
        {
            get
            {
                return string.Format("{0} ({1})", this.OrganizationCode, this.OldOrganizationCode);
            }
        }
        public string OrganizationName { get; set; }
        public string JNPTitle { get; set; }
        public string JNPTitleCombined { get; set; }
        public long? FullPDID { get; set; }
        public long? AdditionalPDID { get; set; }
        public long? JAID { get; set; }
        public long? CRID { get; set; }
        public long? JQID { get; set; }
        public int? CreatedByID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        //public string CreateDateShort { get; set; }
        public DateTime CreateDateShort { get; set; }

        //public string CreatedByDate { get; set; }
        public int? UpdatedByID { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        //public string UpdateDateShort { get; set; }
        public DateTime UpdateDateShort { get; set; }
        //public string UpdatedByDate { get; set; }
        //public bool? ResultedInSuccessfullHiring { get; set; }
        //public long? VacancyID { get; set; }
        #endregion
        #region [ from vw_JobAnnouncementPackageCurrentStatusInfo ]
        public int? JNPWorkflowStatusID { get; set; }
        public string JNPWorkflowStatus { get; set; }
        #endregion
        #region [ from spr_GetAllJobAnnouncementPackagesByUserID ]
        public enumScheduleStatus JNPScheduleStatus { get; set; }
        public string JNPNextScheduleStatus { get; set; }
        #endregion
        #region [ from vw_JobAnalysisCurrentCheckStatus ]
        public long? CheckID { get; set; }
        public int? CheckedOutByID { get; set; }
        public DateTime? CheckedOutDate { get; set; }
        public string CheckedOutBy { get; set; }
        #endregion
        #region [ from udf_CanViewJNP, udf_CanEditJNP, udf_CanContinueEditJNP and udf_CanFinishEditJNP ]
        public bool CanViewJNP { get; set; }
        public bool CanEditJNP { get; set; }
        public bool CanContinueEditJNP { get; set; }
        public bool CanFinishEditJNP { get; set; }
        #endregion

        public bool IsCheckedOut
        {
            get { return CheckID != null; }
        }
        #endregion
    }
}
