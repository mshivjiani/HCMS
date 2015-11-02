using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
using HCMS.Business.CR;

namespace HCMS.Business.JNP
{
    /// <summary>
    /// JNP Business Object
    /// </summary>
    [Serializable]
    public class JNPackage : BusinessBase
    {
        #region Private Members

        private long _JNPID = -1;
        private enumJNPType _JNPTypeID = enumJNPType.Unknown;
        private eJNPOptionType _JNPOptionTypeID = eJNPOptionType.None;
        private bool _isStandardJNP = false;
        private bool _isDEU = false;
        private bool _isMP = false;
        private bool _isExceptedService = false;
        private int _payPlanID = -1;
        private string _payPlanTitle = string.Empty;
        private int _seriesID = -1;
        private string _seriesName = string.Empty;
        private bool _isInterdisciplinary = false;
        private int _additionalSeriesID = -1;
        private string _additionalSeriesName = string.Empty;
        private int _lowestAdvertisedGrade = -1;
        private int _highestAdvertisedGrade = -1;
        private string _highestAdvertisedGradeName = string.Empty;
        private int _regionID = -1;
        private string _regionName = string.Empty;
        private int _organizationCodeID = -1;
        private string _organizationCode = string.Empty;
        private string _organizationName = string.Empty;
        private string _JNPTitle = string.Empty;
        private string _dutyLocation = string.Empty;
        private long _fullPDID = -1;
        private string _fullPDName = string.Empty;
        private long _additionalPDID = -1;
        private string _additionalPDName = string.Empty;
        private long _JAID = -1;
        private long _CRID = -1;
        private long _JQID = -1;
        private string _FPPSPDID = string.Empty;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;
        private bool _resultedInSuccessfulHiring = false;
        private string _vacancyID = string.Empty;
        private long _copyFromJNPID = -1;
        private bool _IsJNPSignedBySupervisor = false;
        private bool _IsJNPSignedByHR = false;
        

        #endregion

        #region Properties

        public long JNPID
        {
            get
            {
                return this._JNPID;
            }
            set
            {
                this._JNPID = value;
            }
        }

        public enumJNPType JNPTypeID
        {
            get
            {
                return this._JNPTypeID;
            }
            set
            {
                this._JNPTypeID = value;
            }
        }

        public eJNPOptionType JNPOptionTypeID
        {
            get
            {
                return this._JNPOptionTypeID;
            }
            set
            {
                this._JNPOptionTypeID = value;
            }
        }

        public bool IsStandardJNP
        {
            get
            {
                return this._isStandardJNP;
            }
            set
            {
                this._isStandardJNP = value;
            }
        }

        public bool IsDEU
        {
            get
            {
                return this._isDEU;
            }
            set
            {
                this._isDEU = value;
            }
        }

        public bool IsMP
        {
            get
            {
                return this._isMP;
            }
            set
            {
                this._isMP = value;
            }
        }

        public bool IsExceptedService
        {
            get
            {
                return this._isExceptedService;
            }
            set
            {
                this._isExceptedService = value;
            }
        }

        public int PayPlanID
        {
            get
            {
                return this._payPlanID;
            }
            set
            {
                this._payPlanID = value;
            }
        }

        public string PayPlanTitle
        {
            get
            {
                return this._payPlanTitle;
            }
        }

        public int SeriesID
        {
            get
            {
                return this._seriesID;
            }
            set
            {
                this._seriesID = value;
            }
        }

        public string SeriesName
        {
            get
            {
                return this._seriesName;
            }
        }

        public bool IsInterdisciplinary
        {
            get
            {
                return this._isInterdisciplinary;
            }
            set
            {
                this._isInterdisciplinary = value;
            }
        }

        public int AdditionalSeriesID
        {
            get
            {
                return this._additionalSeriesID;
            }
            set
            {
                this._additionalSeriesID = value;
            }
        }

        public string AdditionalSeriesName
        {
            get
            {
                return this._additionalSeriesName;
            }
        }

        public int LowestAdvertisedGrade
        {
            get
            {
                return this._lowestAdvertisedGrade;
            }
            set
            {
                this._lowestAdvertisedGrade = value;
            }
        }

        public int HighestAdvertisedGrade
        {
            get
            {
                return this._highestAdvertisedGrade;
            }
            set
            {
                this._highestAdvertisedGrade = value;
            }
        }

        public string HighestAdvertisedGradeName
        {
            get
            {
                return this._highestAdvertisedGradeName;
            }
        }

        public int RegionID
        {
            get
            {
                return this._regionID;
            }
            set
            {
                this._regionID = value;
            }
        }

        public string RegionName
        {
            get
            {
                return this._regionName;
            }
        }

        public string OrganizationCode
        {
            get
            {
                return this._organizationCode;
            }
            set
            {
                this._organizationCode = value;
            }
        }

        public int OrganizationCodeID
        {
            get { return this._organizationCodeID; }
            set { this._organizationCodeID = value; }
        }


        public string OrganizationName
        {
            get
            {
                return this._organizationName;
            }
        }

        public string JNPTitle
        {
            get
            {
                return this._JNPTitle;
            }
            set
            {
                this._JNPTitle = value;
            }
        }

        public string DutyLocation
        {
            get
            {
                return this._dutyLocation;
            }
            set
            {
                this._dutyLocation = value;
            }
        }

        public long FullPDID
        {
            get
            {
                return this._fullPDID;
            }
            set
            {
                this._fullPDID = value;
            }
        }

        public string FullPDName
        {
            get
            {
                return this._fullPDName;
            }
        }

        public long AdditionalPDID
        {
            get
            {
                return this._additionalPDID;
            }
            set
            {
                this._additionalPDID = value;
            }
        }

        public string AdditionalPDName
        {
            get
            {
                return this._additionalPDName;
            }
        }

        public long JAID
        {
            get
            {
                return this._JAID;
            }
            set
            {
                this._JAID = value;
            }
        }

        public long CRID
        {
            get
            {
                return this._CRID;
            }
            set
            {
                this._CRID = value;
            }
        }

        public long JQID
        {
            get
            {
                return this._JQID;
            }
            set
            {
                this._JQID = value;
            }
        }

        public string FPPSPDID
        {
            get
            {
                return this._FPPSPDID;
            }
            set
            {
                this._FPPSPDID = value;
            }
        }

        public int CreatedByID
        {
            get
            {
                return this._createdByID;
            }
            set
            {
                this._createdByID = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return this._createDate;
            }
            set
            {
                this._createDate = value;
            }
        }

        public int UpdatedByID
        {
            get
            {
                return this._updatedByID;
            }
            set
            {
                this._updatedByID = value;
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                return this._updateDate;
            }
            set
            {
                this._updateDate = value;
            }
        }

        public bool ResultedInSuccessfulHiring
        {
            get
            {
                return this._resultedInSuccessfulHiring;
            }
            set
            {
                this._resultedInSuccessfulHiring = value;
            }
        }

        public string VacancyID
        {
            get
            {
                return this._vacancyID;
            }
            set
            {
                this._vacancyID = value;
            }
        }

        public long CopyFromJNPID
        {
            get
            {
                return this._copyFromJNPID;
            }
            set
            {
                this._copyFromJNPID = value;
            }
        }

        public bool IsJNPSignedBySupervisor
        {
            get { return this._IsJNPSignedBySupervisor; }
            set { this._IsJNPSignedBySupervisor = value; }
        }

        public bool IsJNPSignedByHR
        {
            get { return this._IsJNPSignedByHR; }
            set { this._IsJNPSignedByHR = value; }
        }

        #endregion

        #region Constructors

        public JNPackage()
        {
            // Empty Constructor
        }

        public JNPackage(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetJNPBasicByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public JNPackage(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion

        #region Constructor Helper Methods

        private void loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                this.FillObjectFromRowData(returnRow);
            }
        }

        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            DataColumnCollection columns = returnRow.Table.Columns;

            if (returnRow["JNPID"] != DBNull.Value)
                this._JNPID = (long)returnRow["JNPID"];

            if (returnRow["JNPTypeID"] != DBNull.Value)
            {
                int tempValue = (int)returnRow["JNPTypeID"];

                if (Enum.IsDefined(typeof(enumJNPType), tempValue))
                    this._JNPTypeID = (enumJNPType)tempValue;
            }

            if (returnRow["JNPOptionTypeID"] != DBNull.Value)
            {
                int tempValue = (int)returnRow["JNPOptionTypeID"];

                if (Enum.IsDefined(typeof(eJNPOptionType), tempValue))
                    this._JNPOptionTypeID = (eJNPOptionType)tempValue;
            }

            if (returnRow["IsStandardJNP"] != DBNull.Value)
                this._isStandardJNP = (bool)returnRow["IsStandardJNP"];

            if (returnRow["IsDEU"] != DBNull.Value)
                this._isDEU = (bool)returnRow["IsDEU"];

            if (returnRow["IsMP"] != DBNull.Value)
                this._isMP = (bool)returnRow["IsMP"];

            if (returnRow["IsExceptedService"] != DBNull.Value)
                this._isExceptedService = (bool)returnRow["IsExceptedService"];

            if (returnRow["PayPlanID"] != DBNull.Value)
                this._payPlanID = (int)returnRow["PayPlanID"];

            if (returnRow["PayPlanTitle"] != DBNull.Value)
                this._payPlanTitle = returnRow["PayPlanTitle"].ToString();

            if (returnRow["SeriesID"] != DBNull.Value)
                this._seriesID = (int)returnRow["SeriesID"];

            if (returnRow["SeriesName"] != DBNull.Value)
                this._seriesName = returnRow["SeriesName"].ToString();

            if (returnRow["IsInterdisciplinary"] != DBNull.Value)
                this._isInterdisciplinary = (bool)returnRow["IsInterdisciplinary"];

            if (returnRow["AdditionalSeriesID"] != DBNull.Value)
                this._additionalSeriesID = (int)returnRow["AdditionalSeriesID"];

            if (returnRow["AdditionalSeriesName"] != DBNull.Value)
                this._additionalSeriesName = returnRow["AdditionalSeriesName"].ToString();

            if (returnRow["LowestAdvertisedGrade"] != DBNull.Value)
                this._lowestAdvertisedGrade = (int)returnRow["LowestAdvertisedGrade"];

            if (returnRow["HighestAdvertisedGrade"] != DBNull.Value)
                this._highestAdvertisedGrade = (int)returnRow["HighestAdvertisedGrade"];

            if (returnRow["HighestAdvertisedGradeName"] != DBNull.Value)
                this._highestAdvertisedGradeName = returnRow["HighestAdvertisedGradeName"].ToString();

            if (returnRow["RegionID"] != DBNull.Value)
                this._regionID = (int)returnRow["RegionID"];

            if (returnRow["RegionName"] != DBNull.Value)
                this._regionName = returnRow["RegionName"].ToString();

            if (returnRow["OrganizationCodeID"] != DBNull.Value)
                this._organizationCodeID = (int)returnRow["OrganizationCodeID"];

            if (columns.Contains("OrganizationCode"))
            {
                if (returnRow["OrganizationCode"] != DBNull.Value)
                    this._organizationCode = returnRow["OrganizationCode"].ToString();
            }
            if (columns.Contains("OrganizationName"))
            {
                if (returnRow["OrganizationName"] != DBNull.Value)
                    this._organizationName = returnRow["OrganizationName"].ToString();
            }

            if (returnRow["JNPTitle"] != DBNull.Value)
                this._JNPTitle = returnRow["JNPTitle"].ToString();

            if (returnRow["DutyLocation"] != DBNull.Value)
                this._dutyLocation = returnRow["DutyLocation"].ToString();

            if (returnRow["VacancyID"] != DBNull.Value)
                this._vacancyID = returnRow["VacancyID"].ToString();

            if (returnRow["FullPDID"] != DBNull.Value)
                this._fullPDID = (long)returnRow["FullPDID"];

            if (returnRow["FullPDName"] != DBNull.Value)
                this._fullPDName = returnRow["FullPDName"].ToString();

            if (returnRow["AdditionalPDID"] != DBNull.Value)
                this._additionalPDID = (long)returnRow["AdditionalPDID"];

            if (returnRow["AdditionalPDName"] != DBNull.Value)
                this._additionalPDName = returnRow["AdditionalPDName"].ToString();

            if (returnRow["JAID"] != DBNull.Value)
                this._JAID = (long)returnRow["JAID"];

            if (returnRow["CRID"] != DBNull.Value)
                this._CRID = (long)returnRow["CRID"];

            if (returnRow["JQID"] != DBNull.Value)
                this._JQID = (long)returnRow["JQID"];

            if (returnRow["FPPSPDID"] != DBNull.Value)
                this._FPPSPDID = returnRow["FPPSPDID"].ToString();

            if (returnRow["CreatedByID"] != DBNull.Value)
                this._createdByID = (int)returnRow["CreatedByID"];

            if (returnRow["CreateDate"] != DBNull.Value)
                this._createDate = (DateTime)returnRow["CreateDate"];

            if (returnRow["UpdatedByID"] != DBNull.Value)
                this._updatedByID = (int)returnRow["UpdatedByID"];

            if (returnRow["UpdateDate"] != DBNull.Value)
                this._updateDate = (DateTime)returnRow["UpdateDate"];

            if (returnRow["ResultedInSuccessfulHiring"] != DBNull.Value)
                this._resultedInSuccessfulHiring = (bool)returnRow["ResultedInSuccessfulHiring"];

            if (returnRow["CopyFromJNPID"] != DBNull.Value)
                this._copyFromJNPID = (long)returnRow["CopyFromJNPID"];

            JNPApproval jnpApproval = GetJNPApprovalInfo(this._JNPID);

            if (jnpApproval.SupervisorSignDate != null)
                this._IsJNPSignedBySupervisor = true;

            if (jnpApproval.HRPersonnelSignDate != null )
                this._IsJNPSignedByHR = true;
            
        }

        #endregion

        #region ToXML Method

        ///<summary>
        /// Returns an XML String that represents the current object.
        ///</summary>
        public string ToXML()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StreamReader sr = new StreamReader(new MemoryStream()))
            {
                serializer.Serialize(sr.BaseStream, this);
                sr.BaseStream.Position = 0;
                return sr.ReadToEnd();
            }
        }

        #endregion ToXML Method

        #region ToString Method

        ///<summary>
        /// Returns a String that represents the current object.
        ///</summary>
        public override string ToString()
        {
            return "JNPID:" + JNPID.ToString();
        }

        #endregion ToString Method

        #region CompareMethods

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current object.</param>
        /// <returns>Returns true if the specified System.Object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {
            JNPackage JNPobj = obj as JNPackage;

            return (JNPobj == null) ? false : (this.JNPID == JNPobj.JNPID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return JNPID.GetHashCode();
        }
        #endregion

        #region General Methods

        private void addJNP(string sprocName, bool? createJAFromSelectedPD = null, long? existingJNPID = null)
        {
            try
            {
                DbCommand commandWrapper = GetDbCommand(sprocName);

                SqlParameter JNPIDParam = new SqlParameter("@JNPID", SqlDbType.BigInt);
                JNPIDParam.Direction = ParameterDirection.Output;

                SqlParameter JAIDParam = new SqlParameter("@JAID", SqlDbType.BigInt);
                JAIDParam.Direction = ParameterDirection.Output;

                SqlParameter CRIDParam = new SqlParameter("@CRID", SqlDbType.BigInt);
                CRIDParam.Direction = ParameterDirection.Output;

                SqlParameter JQIDParam = new SqlParameter("@JQID", SqlDbType.BigInt);
                JQIDParam.Direction = ParameterDirection.Output;
                 
                // get the new JNPID of the record
                commandWrapper.Parameters.Add(JNPIDParam);
                commandWrapper.Parameters.Add(JAIDParam);
                commandWrapper.Parameters.Add(CRIDParam);
                commandWrapper.Parameters.Add(JQIDParam);

                if (this._payPlanID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@PayPlanID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@PayPlanID", this._payPlanID));

                if (this._regionID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@RegionID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@RegionID", this._regionID));

                if (this._seriesID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", this._seriesID));

                if (this._organizationCodeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCodeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCodeID", this._organizationCodeID));

                commandWrapper.Parameters.Add(new SqlParameter("@IsStandardJNP", this._isStandardJNP));

                if (string.IsNullOrWhiteSpace(this._JNPTitle))
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPTitle", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPTitle", this._JNPTitle.Trim()));

                commandWrapper.Parameters.Add(new SqlParameter("@IsInterdisciplinary", this._isInterdisciplinary));

                if (!this._isInterdisciplinary || this._additionalSeriesID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@AdditionalSeriesID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@AdditionalSeriesID", this._additionalSeriesID));

                if (this._JNPTypeID == enumJNPType.Unknown)
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPTypeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPTypeID", this._JNPTypeID));

                if (this._JNPOptionTypeID == eJNPOptionType.None)
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPOptionTypeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPOptionTypeID", this._JNPOptionTypeID));

                if (this._lowestAdvertisedGrade == -1)
                    // can't have a null value -- store highest grade value
                    commandWrapper.Parameters.Add(new SqlParameter("@LowestAdvertisedGrade", this._highestAdvertisedGrade));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@LowestAdvertisedGrade", this._lowestAdvertisedGrade));

                if (this._highestAdvertisedGrade == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@HighestAdvertisedGrade", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@HighestAdvertisedGrade", this._highestAdvertisedGrade));

                if (this._fullPDID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@FullPDID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@FullPDID", this._fullPDID));

                if (!(this._JNPTypeID == enumJNPType.TwoGrade) || this._additionalPDID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@AdditionalPDID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@AdditionalPDID", this._additionalPDID));

                if (string.IsNullOrWhiteSpace(this._dutyLocation))
                    commandWrapper.Parameters.Add(new SqlParameter("@DutyLocation", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@DutyLocation", this._dutyLocation.Trim()));

                commandWrapper.Parameters.Add(new SqlParameter("@IsDEU", this._isDEU));
                commandWrapper.Parameters.Add(new SqlParameter("@IsMP", this._isMP));
                commandWrapper.Parameters.Add(new SqlParameter("@IsException", this._isExceptedService));

                if (createJAFromSelectedPD.HasValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@CreateJAFromSelectedPD", createJAFromSelectedPD.Value));
                else
                {
                    if (existingJNPID.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@CopyFromJNPID", existingJNPID.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@CopyFromJNPID", DBNull.Value));
                }

                if (this._createdByID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", this._createdByID));

                ExecuteNonQuery(commandWrapper);

                // set primary key field to new identity
                this._JNPID = (long)JNPIDParam.Value;
                this._JAID = (long)JAIDParam.Value;                
                this._CRID = (CRIDParam.Value == null || CRIDParam.Value.ToString() == "") ? -1 : (long)CRIDParam.Value;
                this._JQID = (long)JQIDParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public bool IsPublished()
        {
            var wfStatus = JNPWorkflowStatus.GetCurrentJNPWorkflowStatus(this.JNPID);
            return ((enumJNPWorkflowStatus)wfStatus.JNPWorkflowStatusID == enumJNPWorkflowStatus.Published);
        }

        public bool HasActiveCR()
        {
            var cr = this.CR();
            return (cr == null ? false : (bool)cr.IsActive);
        }

        public bool HasCR()
        {
            return (this.CR() != null);
        }

        public CategoryRating CR()
        {
            if (this.CRID < 0) return null;
            return CategoryRatingManager.GetByID(this.CRID);
        }

        public void Add(bool createFromSelectedPD)
        {
            addJNP("spr_AddJNP", createJAFromSelectedPD: createFromSelectedPD);
        }

        public void AddBasedOnExistingJNP()
        {
            addJNP("spr_AddJNPFromExistingJNP", existingJNPID: this._copyFromJNPID);
        }

        public void Update()
        {

            if (base.ValidateKeyField(this._JNPID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateJNP");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPID", this._JNPID));
                    commandWrapper.Parameters.Add(new SqlParameter("@isInterdisciplinary", this._isInterdisciplinary));

                    if (!this._isInterdisciplinary || this._additionalSeriesID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@additionalSeriesID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@additionalSeriesID", this._additionalSeriesID));

                    if (string.IsNullOrWhiteSpace(this._FPPSPDID))
                        commandWrapper.Parameters.Add(new SqlParameter("@FPPSPDID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@FPPSPDID", this._FPPSPDID));

                    if (string.IsNullOrWhiteSpace(this._dutyLocation))
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyLocation", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DutyLocation", this._dutyLocation.Trim()));

                    commandWrapper.Parameters.Add(new SqlParameter("@IsDEU", this._isDEU));
                    commandWrapper.Parameters.Add(new SqlParameter("@IsMP", this._isMP));
                    commandWrapper.Parameters.Add(new SqlParameter("@IsException", this._isExceptedService));

                    if (this._updatedByID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this._updatedByID));

                    commandWrapper.Parameters.Add(new SqlParameter("@ResultedInSuccessfulHiring", this._resultedInSuccessfulHiring));
                    commandWrapper.Parameters.Add(new SqlParameter("@VacancyID", this._vacancyID));


                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }



        #endregion

        #region Collection Helper Methods

        internal static List<JNPackage> GetCollection(DataTable dataItems)
        {
            List<JNPackage> listCollection = new List<JNPackage>();
            JNPackage current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new JNPackage(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a JNP collection from a null data table.");

            return listCollection;
        }

        #endregion



        #region Static Methods
        public static DataTable GetJNPAccessForUser(long jnpID, int userID)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = BusinessBase.ExecuteDataTable("GetJNPAccessForUser", jnpID, userID);

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return dt;

        }

        public static enumJNPWorkflowStatus GetCurrentWorkflowStatusName(long jnpID)
        {
            JNPWorkflowStatus currentws = JNPWorkflowStatus.GetCurrentJNPWorkflowStatus(jnpID);
            enumJNPWorkflowStatus enumcurrentws = (enumJNPWorkflowStatus)currentws.JNPWorkflowStatusID;
            return enumcurrentws;
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

        public static DataTable GetAllJNPWorkflowNotes()
        {
            DataTable lstWorkflowNotes = null;

            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_GetAllJNPWorkflowNotes");
                lstWorkflowNotes = ExecuteDataTable(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return lstWorkflowNotes;
        }

        public static bool JNPHasComments(long JNPID)
        {
            bool hasComments = false;

            try
            {
                var dataExists = GetAllJNPWorkflowNotes().Select("JNPID = " + JNPID);
                if (dataExists.Length != 0)
                {
                    hasComments = true;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return hasComments;
        }

        public static JNPApproval GetJNPApprovalInfo(long JNPID)
        {
            JNPApprovalManager approvalMgr = new JNPApprovalManager();
            return approvalMgr.GetJNPApprovalByStaffingObjectID(JNPID, enumStaffingObjectType.JNP);
        }
        #endregion

    }
}

