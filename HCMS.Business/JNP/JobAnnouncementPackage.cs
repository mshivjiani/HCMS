using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data;
using HCMS.Business.Common;
using System.Data.Common;
using System.Data.SqlClient;

namespace HCMS.Business.JNP
{
    public class JobAnnouncementPackage : BusinessBase
    {
        #region [ Constructors ]
        public JobAnnouncementPackage()
        {
        }
        private JobAnnouncementPackage(DataRow dataRow)
        {
            FillObjectFromDataRow(dataRow);
        }
        #endregion

        #region [ Constructor Helper Methods ]
        private void FillObjectFromDataRow(DataRow dataRow)
        {
            try
            {
                JNPID = (long)dataRow["JNPID"];
                JNPTypeID = (int)dataRow["JNPTypeID"];
                JNPOptionTypeID = (int)dataRow["JNPOptionTypeID"];

                if (dataRow["IsStandardJNP"] != DBNull.Value) IsStandardJNP = (bool)dataRow["IsStandardJNP"];
                if (dataRow["IsDEU"] != DBNull.Value) IsDEU = (bool)dataRow["IsDEU"];
                //if (dataRow["IsMP"] != DBNull.Value) IsMP = (bool)dataRow["IsMP"];
                //if (dataRow["IsExceptedService"] != DBNull.Value) IsExceptedService = (bool)dataRow["IsExceptedService"];

                PayPlanID = (int)dataRow["PayPlanID"];
                SeriesID = (int)dataRow["SeriesID"];

                if (dataRow["IsInterdisciplinary"] != DBNull.Value) IsInterdisciplinary = (bool)dataRow["IsInterdisciplinary"];
                if (dataRow["AdditionalSeriesID"] != DBNull.Value) AdditionalSeriesID = (int)dataRow["AdditionalSeriesID"];

                LowestAdvertisedGrade = (int)dataRow["LowestAdvertisedGrade"];
                HighestAdvertisedGrade = (int)dataRow["HighestAdvertisedGrade"];

                if (dataRow["RegionID"] != DBNull.Value) RegionID = (int)dataRow["RegionID"];
                OrganizationCode = (int)dataRow["OrganizationCode"];

                if (dataRow["JNPTitle"] != DBNull.Value) JNPTitle = (string)dataRow["JNPTitle"];

                if (dataRow["FullPDID"] != DBNull.Value) FullPDID = (long)dataRow["FullPDID"];
                if (dataRow["AdditionalPDID"] != DBNull.Value) AdditionalPDID = (long)dataRow["AdditionalPDID"];
                if (dataRow["JAID"] != DBNull.Value) JAID = (long)dataRow["JAID"];
                if (dataRow["CRID"] != DBNull.Value) CRID = (long)dataRow["CRID"];
                if (dataRow["JQID"] != DBNull.Value) JQID = (long)dataRow["JQID"];

                if (dataRow["CreatedByID"] != DBNull.Value) CreatedByID = (int)dataRow["CreatedByID"];
                if (dataRow["CreateDate"] != DBNull.Value) CreateDate = (DateTime)dataRow["CreateDate"];
                if (dataRow["UpdatedByID"] != DBNull.Value) UpdatedByID = (int)dataRow["UpdatedByID"];
                if (dataRow["UpdateDate"] != DBNull.Value) UpdateDate = (DateTime)dataRow["UpdateDate"];

                //TODO: make sure that all stored procedures return these fields and then uncomment the lines
                //if (dataRow["ResultedInSuccessfullHiring"] != DBNull.Value) ResultedInSuccessfullHiring = (bool)dataRow["ResultedInSuccessfullHiring"];
                //if (dataRow["VacancyID"] != DBNull.Value) VacancyID = (long)dataRow["VacancyID"];

                if (dataRow["JNPTitleCombined"] != DBNull.Value) JNPTitleCombined = (string)dataRow["JNPTitleCombined"];
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }
        }
        #endregion

        #region [ Static Helper Methods ]
        //public static JobAnnouncementPackage GetByID(int userID, long JNPID)
        //{
        //    JobAnnouncementPackage item = null;

        //    try
        //    {
        //        //TODO: this stored procedure returns rows more sutable for Business.TrackerItem.
        //        //think about modifying this SP eliminating some fields and @userID and creating a separate 
        //        //stored procedure for retrieving a separate Business.TrackerItem. (better - rename this SP
        //        //to spr_GetTrackerItemByID and create a new spr_GetJNPByID
        //        DataTable dataTable = ExecuteDataTable("spr_GetJNPByID", userID, JNPID);

        //        if (dataTable.Rows.Count == 1)
        //        {
        //            DataRow dataRow = dataTable.Rows[0];

        //            if (dataRow != null)
        //            {
        //                item = new JobAnnouncementPackage(dataRow);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        item = null;
        //        ExceptionBase.HandleException(ex);
        //    }

        //    return item;
        //}

        public static JobAnnouncementPackage GetByID(long JNPID)
        {
            JobAnnouncementPackage item = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetJNPByID", JNPID);

                if (dataTable.Rows.Count == 1)
                {
                    DataRow dataRow = dataTable.Rows[0];

                    if (dataRow != null)
                    {
                        item = new JobAnnouncementPackage(dataRow);
                    }
                }

            }
            catch (Exception ex)
            {
                item = null;
                ExceptionBase.HandleException(ex);
            }

            return item;
        }
        #endregion

        #region [ General Methods ]
        public void Add()
        {
            throw new NotImplementedException();
        }
        public void Update(TransactionManager transactionManager)
        {
            //TransactionManager transactionManager = new TransactionManager(CurrentDatabase);
            //transactionManager.BeginTransaction();

            //try
            //{
            DbCommand commandWrapper = GetDbCommand("spr_UpdateJNP");

            commandWrapper.Parameters.Add(new SqlParameter("@jNPID", this.JNPID));
            commandWrapper.Parameters.Add(new SqlParameter("@jNPTypeID", this.JNPTypeID));
            commandWrapper.Parameters.Add(new SqlParameter("@jNPOptionTypeID", this.JNPOptionTypeID));

            if (IsStandardJNP != null)
                commandWrapper.Parameters.Add(new SqlParameter("@isStandardJNP", this.IsStandardJNP));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@isStandardJNP", DBNull.Value));

            if (IsDEU != null)
                commandWrapper.Parameters.Add(new SqlParameter("@isDEU", this.IsDEU));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@isDEU", DBNull.Value));

            if (IsMP != null)
                commandWrapper.Parameters.Add(new SqlParameter("@isMP", this.IsMP));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@isMP", DBNull.Value));

            if (IsExceptedService != null)
                commandWrapper.Parameters.Add(new SqlParameter("@isExceptedService", this.IsExceptedService));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@isExceptedService", DBNull.Value));

            commandWrapper.Parameters.Add(new SqlParameter("@payPlanID", this.PayPlanID));
            commandWrapper.Parameters.Add(new SqlParameter("@seriesID", this.SeriesID));

            if (IsInterdisciplinary != null)
                commandWrapper.Parameters.Add(new SqlParameter("@isInterdisciplinary", this.IsInterdisciplinary));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@isInterdisciplinary", DBNull.Value));

            if (AdditionalSeriesID != null)
                commandWrapper.Parameters.Add(new SqlParameter("@additionalSeriesID", this.AdditionalSeriesID));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@additionalSeriesID", DBNull.Value));

            commandWrapper.Parameters.Add(new SqlParameter("@LowestAdvertisedGrade", this.LowestAdvertisedGrade));
            commandWrapper.Parameters.Add(new SqlParameter("@HighestAdvertisedGrade", this.HighestAdvertisedGrade));

            if (RegionID != null)
                commandWrapper.Parameters.Add(new SqlParameter("@regionID", this.RegionID));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@regionID", DBNull.Value));

            commandWrapper.Parameters.Add(new SqlParameter("@organizationCode", this.OrganizationCode));

            if (String.IsNullOrEmpty(JNPTitle) == false)
                commandWrapper.Parameters.Add(new SqlParameter("@jNPTitle", this.JNPTitle));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@jNPTitle", DBNull.Value));

            if (FullPDID != null)
                commandWrapper.Parameters.Add(new SqlParameter("@fullPDID", this.FullPDID));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@fullPDID", DBNull.Value));

            if (AdditionalPDID != null)
                commandWrapper.Parameters.Add(new SqlParameter("@additionalPDID", this.AdditionalPDID));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@additionalPDID", DBNull.Value));

            if (JAID != null)
                commandWrapper.Parameters.Add(new SqlParameter("@jAID", this.JAID));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@jAID", DBNull.Value));

            if (CRID != null)
                commandWrapper.Parameters.Add(new SqlParameter("@cRID", this.CRID));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@cRID", DBNull.Value));

            if (JQID != null)
                commandWrapper.Parameters.Add(new SqlParameter("@jQID", this.JQID));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@jQID", DBNull.Value));

            if (CreatedByID != null)
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this.CreatedByID));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));

            if (CreateDate != null)
                commandWrapper.Parameters.Add(new SqlParameter("@createDate", this.CreateDate));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@createDate", DBNull.Value));

            if (UpdatedByID != null)
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this.UpdatedByID));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", DBNull.Value));

            if (UpdateDate != null)
                commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this.UpdateDate));
            else
                commandWrapper.Parameters.Add(new SqlParameter("@updateDate", DBNull.Value));

            if (transactionManager != null)
            {
                ExecuteNonQuery(transactionManager, commandWrapper);
            }
            else
            {
                ExecuteNonQuery(commandWrapper);
            }
            //}
            //catch (Exception ex)
            //{
            //    if (transactionManager != null && transactionManager.IsOpen)
            //    {
            //        transactionManager.Rollback();
            //    }
            //
            //    ExceptionBase.HandleException(ex);
            //}
        }
        public void Delete()
        {
            throw new NotImplementedException();
            #region [need to delete all dependent objects (statuses) as well]
            #endregion
        }

        #region [ do not use this function. Delete later ]
        //public JNPWorkflowStatus GetCurrentWorkflowStatus()
        //{
        //    JNPWorkflowStatus jws = new JNPWorkflowStatus();
        //    return jws;
        //}
        #endregion
        #endregion

        #region [ Public Properties ]
        public long JNPID { get; set; }
        public int JNPTypeID { get; set; }
        public int JNPOptionTypeID { get; set; }
        public bool? IsStandardJNP { get; set; }
        public bool? IsDEU { get; set; }
        public bool? IsMP { get; set; }
        public bool? IsExceptedService { get; set; }
        public int PayPlanID { get; set; }
        public int SeriesID { get; set; }
        public bool? IsInterdisciplinary { get; set; }
        public int? AdditionalSeriesID { get; set; }
        public int LowestAdvertisedGrade { get; set; }
        public int HighestAdvertisedGrade { get; set; }
        public int? RegionID { get; set; }
        public int OrganizationCode { get; set; }
        public string JNPTitle { get; set; } // null-able
        public long? FullPDID { get; set; }
        public long? AdditionalPDID { get; set; }
        public long? JAID { get; set; }
        public long? CRID { get; set; }
        public long? JQID { get; set; }
        public int? CreatedByID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdatedByID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? ResultedInSuccessfullHiring { get; set; }
        public long? VacancyID { get; set; }
        //
        public string JNPTitleCombined { get; set; } // null-able
        #endregion
    }
}
