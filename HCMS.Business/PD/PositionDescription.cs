using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
using HCMS.Business.SeriesGradeFactor;
using HCMS.Business.SeriesFactorLevelLanguage;
using HCMS.Business.Lookups;
using HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.Business.Common;
using HCMS.Business.PD.Collections;

using HCMS.Business.LogObjects;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace HCMS.Business.PD
{
    /// <summary>
    /// PositionDescription Business Object
    /// </summary>
    [Serializable]
    public class PositionDescription : BusinessBase
    {
        #region Private Members

        private long _positionDescriptionID = -1;
        private string _isStandardPD = string.Empty;
        private int _positionDescriptionTypeID = -1;
        private string _positionDescriptionTypeDisp = string.Empty;
        private string _introduction = string.Empty;
        private string _oPMJobTitle = string.Empty;
        private string _agencyPositionTitle = string.Empty;
        private int _payPlanID = -1;
        private int _jobSeries = -1;
        private int _proposedGrade = -1;
        private int _proposedFPGrade = -1;
        private int _positionTypeID = -1;
        private string _eEODStatement = string.Empty;
        private int _positionStatusTypeID = -1;
        private string _positionStatusTypeRemark = string.Empty;
        private int _positionSensitivityTypeID = -1;
        private string _competitiveLevelCode = string.Empty;
        private int _fLSATypeID = -1;
        private string _financialStatementsRequired = string.Empty;
        private string _drugTestingRequired = string.Empty;
        private string _physicalExaminationRequired = string.Empty;
        private string _subjectToIAaction = string.Empty;
        private string _bargainingUnitStatus = string.Empty;
        private int _reasonForSubmissionID = -1;
        private int _serviceID = -1;
        private string _employingOfficeLocation = string.Empty;
        private string _dutyLocation = string.Empty;
        private string _remarks = string.Empty;
        private string _deptAgencyEstablishment = string.Empty;
        private string _firstSubdivision = string.Empty;
        private string _secondSubdivision = string.Empty;
        private int _organizationCodeID = -1;
        private string _organizationCodeName = string.Empty;
        private string _organizationCode = string.Empty;
        private int _oldOrganizationCode = -1;
        private string _fourthSubdivision = string.Empty;
        private string _fifthSubdivision = string.Empty;
        private string _payPlanJustification = string.Empty;
        private string _titleJustification = string.Empty;
        private string _seriesJustification = string.Empty;
        private string _gradeJustification = string.Empty;
        private string _additionalJustification = string.Empty;
        private string _supervisoryCertText = string.Empty;
        private int _supervisorID = -1;
        private string _supervisorFullName = string.Empty;
        private DateTime _supervisorSignDate = DateTime.MinValue;
        private string _classifierCertText = string.Empty;
        private int _evaluatorID = -1;
        private string _evaluatorFullName = string.Empty;
        private DateTime _evaluatorSignDate = DateTime.MinValue;
        private int _classifierID = -1;
        private string _classifierFullName = string.Empty;
        private DateTime _classifierSignDate = DateTime.MinValue;
        private int _pDCreatorID = -1;
        private long _associatedFullPD = -1;
        private int _ladderPosition = -1;
        private int _careerLadderPDTypeID = -1;
        private string _paragraphOneText = string.Empty;
        private string _paragraphTwoText = string.Empty;
        private string _paragraphThreeText = string.Empty;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;
        private int _additionalSupervisorID = -1;
        private string _additionalSupervisorFullName = string.Empty;
        private DateTime _additionalSupervisorSignDate = DateTime.MinValue;
        private long _publishedID = -1;
        private string _fPPSPDID = string.Empty;
        private string _FLSAType = string.Empty;
        private string _positionDescriptionType = string.Empty;
        private string _payPlanAbbrev = string.Empty;
        private string _payPlanTitle = string.Empty;
        private string _positionType = string.Empty;
        private string _positionStatusType = string.Empty;
        private string _reasonForSubmission = string.Empty;
        private string _positionSenesitivityType = string.Empty;
        private string _service = string.Empty;
        //private string _officeLocation = string.Empty;
        private string _seriesDefinition = string.Empty;
        private string _seriesOPMTitle = string.Empty;
        private string _seriesName = string.Empty;
        private string _currentWorkflowStatus = string.Empty;
        private int _checkedOutByID = -1;
        private DateTime _checkOutDate = DateTime.MinValue;
        private int _checkedInByID = -1;
        private DateTime _checkInDate = DateTime.MinValue;
        private string _supervisorOrgTitle = string.Empty;
        private string _additionalSupOrgTitle = string.Empty;
        private long _copyFromPDID = -1;
        private int _copyFromPDIDByUserID = -1;
        private DateTime _copyFromPDIDDate = DateTime.MinValue;
        private string _evaluatorOrgTitle = string.Empty;
        private string _classifierOrgTitle = string.Empty;
        private bool _highGradeApproval = false;
        private bool _isInterdisciplinaryPD = false;
        private string _additionalSeries = string.Empty;

        private int _hcoID = -1;
        private string _hcoFullName = string.Empty;
        private DateTime _hcoSignDate = DateTime.MinValue;
        private string _hcoOrgTitle = string.Empty;
        #region"Changes related to Review Permission To HR"
        private bool _arePositionDutiesReviewed = false;
        private bool _isOccupationReviewComplete = false;
        #endregion
        #endregion

        #region Properties

        public long PositionDescriptionID
        {
            get
            {
                return this._positionDescriptionID;
            }
            set
            {
                this._positionDescriptionID = value;
            }
        }

        public string IsStandardPD
        {
            get
            {
                return this._isStandardPD;
            }
            set
            {
                this._isStandardPD = value;
            }
        }

        public int PositionDescriptionTypeID
        {
            get
            {
                return this._positionDescriptionTypeID;
            }
            set
            {
                this._positionDescriptionTypeID = value;
            }
        }

        public string PositionDescriptionTypeDisp
        {
            get
            {
                return this._positionDescriptionTypeDisp;
            }
            set
            {
                this._positionDescriptionTypeDisp = value;
            }
        }

        public string Introduction
        {
            get
            {
                return this._introduction;
            }
            set
            {
                this._introduction = value;
            }
        }

        public string OPMJobTitle
        {
            get
            {
                return this._oPMJobTitle;
            }
            set
            {
                this._oPMJobTitle = value;
            }
        }

        public string AgencyPositionTitle
        {
            get
            {
                return this._agencyPositionTitle;
            }
            set
            {
                this._agencyPositionTitle = value;
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

        public int JobSeries
        {
            get
            {
                return this._jobSeries;
            }
            set
            {
                this._jobSeries = value;
            }
        }

        public int ProposedGrade
        {
            get
            {
                return this._proposedGrade;
            }
            set
            {
                this._proposedGrade = value;
            }
        }

        public int ProposedFPGrade
        {
            get
            {
                return this._proposedFPGrade;
            }
            set
            {
                this._proposedFPGrade = value;
            }
        }

        public int PositionTypeID
        {
            get
            {
                return this._positionTypeID;
            }
            set
            {
                this._positionTypeID = value;
            }
        }

        public string EEODStatement
        {
            get
            {
                return this._eEODStatement;
            }
            set
            {
                this._eEODStatement = value;
            }
        }

        public int PositionStatusTypeID
        {
            get
            {
                return this._positionStatusTypeID;
            }
            set
            {
                this._positionStatusTypeID = value;
            }
        }

        public string PositionStatusTypeRemark
        {
            get
            {
                return this._positionStatusTypeRemark;
            }
            set
            {
                this._positionStatusTypeRemark = value;
            }
        }

        public int PositionSensitivityTypeID
        {
            get
            {
                return this._positionSensitivityTypeID;
            }
            set
            {
                this._positionSensitivityTypeID = value;
            }
        }

        public string CompetitiveLevelCode
        {
            get
            {
                return this._competitiveLevelCode;
            }
            set
            {
                this._competitiveLevelCode = value;
            }
        }

        public int FLSATypeID
        {
            get
            {
                return this._fLSATypeID;
            }
            set
            {
                this._fLSATypeID = value;
            }
        }

        public string FinancialStatementsRequired
        {
            get
            {
                return this._financialStatementsRequired;
            }
            set
            {
                this._financialStatementsRequired = value;
            }
        }

        public string DrugTestingRequired
        {
            get
            {
                return this._drugTestingRequired;
            }
            set
            {
                this._drugTestingRequired = value;
            }
        }

        public string PhysicalExaminationRequired
        {
            get
            {
                return this._physicalExaminationRequired;
            }
            set
            {
                this._physicalExaminationRequired = value;
            }
        }

        public string SubjectToIAaction
        {
            get
            {
                return this._subjectToIAaction;
            }
            set
            {
                this._subjectToIAaction = value;
            }
        }

        public string BargainingUnitStatus
        {
            get
            {
                return this._bargainingUnitStatus;
            }
            set
            {
                this._bargainingUnitStatus = value;
            }
        }

        public int ReasonForSubmissionID
        {
            get
            {
                return this._reasonForSubmissionID;
            }
            set
            {
                this._reasonForSubmissionID = value;
            }
        }

        public int ServiceID
        {
            get
            {
                return this._serviceID;
            }
            set
            {
                this._serviceID = value;
            }
        }

        public string EmployingOfficeLocation
        {
            get
            {
                return this._employingOfficeLocation;
            }
            set
            {
                this._employingOfficeLocation = value;
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

        public string Remarks
        {
            get
            {
                return this._remarks;
            }
            set
            {
                this._remarks = value;
            }
        }

        public string DeptAgencyEstablishment
        {
            get
            {
                return this._deptAgencyEstablishment;
            }
            set
            {
                this._deptAgencyEstablishment = value;
            }
        }

        public string FirstSubdivision
        {
            get
            {
                return this._firstSubdivision;
            }
            set
            {
                this._firstSubdivision = value;
            }
        }

        public string SecondSubdivision
        {
            get
            {
                return this._secondSubdivision;
            }
            set
            {
                this._secondSubdivision = value;
            }
        }

        public int OrganizationCodeID
        {
            get
            {
                return this._organizationCodeID;
            }
            set
            {
                this._organizationCodeID = value;
            }
        }

        public string OrganizationCodeLegacy
        {
            get
            {
                return string.Format("{0} ({1})", this._organizationCode, this._oldOrganizationCode).Trim();
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

        public string OrganizationCodeName
        {
            get
            {
                return this._organizationCodeName;
            }
            set
            {
                this._organizationCodeName = value;
            }
        }

        public string FourthSubdivision
        {
            get
            {
                return this._fourthSubdivision;
            }
            set
            {
                this._fourthSubdivision = value;
            }
        }

        public string FifthSubdivision
        {
            get
            {
                return this._fifthSubdivision;
            }
            set
            {
                this._fifthSubdivision = value;
            }
        }

        public string PayPlanJustification
        {
            get
            {
                return this._payPlanJustification;
            }
            set
            {
                this._payPlanJustification = value;
            }
        }

        public string TitleJustification
        {
            get
            {
                return this._titleJustification;
            }
            set
            {
                this._titleJustification = value;
            }
        }

        public string SeriesJustification
        {
            get
            {
                return this._seriesJustification;
            }
            set
            {
                this._seriesJustification = value;
            }
        }

        public string GradeJustification
        {
            get
            {
                return this._gradeJustification;
            }
            set
            {
                this._gradeJustification = value;
            }
        }

        public string AdditionalJustification
        {
            get
            {
                return this._additionalJustification;
            }
            set
            {
                this._additionalJustification = value;
            }
        }

        public string SupervisoryCertText
        {
            get
            {
                return this._supervisoryCertText;
            }
            set
            {
                this._supervisoryCertText = value;
            }
        }

        public int SupervisorID
        {
            get
            {
                return this._supervisorID;
            }
            set
            {
                this._supervisorID = value;
            }
        }

        public string SupervisorFullName
        {
            get
            {
                return this._supervisorFullName;
            }
            set
            {
                this._supervisorFullName = value;
            }
        }

        public DateTime SupervisorSignDate
        {
            get
            {
                return this._supervisorSignDate;
            }
            set
            {
                this._supervisorSignDate = value;
            }
        }

        public string ClassifierCertText
        {
            get
            {
                return this._classifierCertText;
            }
            set
            {
                this._classifierCertText = value;
            }
        }

        public int EvaluatorID
        {
            get
            {
                return this._evaluatorID;
            }
            set
            {
                this._evaluatorID = value;
            }
        }

        public string EvaluatorFullName
        {
            get
            {
                return this._evaluatorFullName;
            }
            set
            {
                this._evaluatorFullName = value;
            }
        }

        public DateTime EvaluatorSignDate
        {
            get
            {
                return this._evaluatorSignDate;
            }
            set
            {
                this._evaluatorSignDate = value;
            }
        }

        public int ClassifierID
        {
            get
            {
                return this._classifierID;
            }
            set
            {
                this._classifierID = value;
            }
        }

        public string ClassifierFullName
        {
            get
            {
                return this._classifierFullName;
            }
            set
            {
                this._classifierFullName = value;
            }
        }

        public DateTime ClassifierSignDate
        {
            get
            {
                return this._classifierSignDate;
            }
            set
            {
                this._classifierSignDate = value;
            }
        }

        public int PDCreatorID
        {
            get
            {
                return this._pDCreatorID;
            }
            set
            {
                this._pDCreatorID = value;
            }
        }

        public long AssociatedFullPD
        {
            get
            {
                return this._associatedFullPD;
            }
            set
            {
                this._associatedFullPD = value;
            }
        }

        public int LadderPosition
        {
            get
            {
                return this._ladderPosition;
            }
            set
            {
                this._ladderPosition = value;
            }
        }

        public int CareerLadderPDTypeID
        {
            get
            {
                return this._careerLadderPDTypeID;
            }
            set
            {
                this._careerLadderPDTypeID = value;
            }
        }

        public string ParagraphOneText
        {
            get
            {
                return this._paragraphOneText;
            }
            set
            {
                this._paragraphOneText = value;
            }
        }

        public string ParagraphTwoText
        {
            get
            {
                return this._paragraphTwoText;
            }
            set
            {
                this._paragraphTwoText = value;
            }
        }

        public string ParagraphThreeText
        {
            get
            {
                return this._paragraphThreeText;
            }
            set
            {
                this._paragraphThreeText = value;
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

        public int AdditionalSupervisorID
        {
            get
            {
                return this._additionalSupervisorID;
            }
            set
            {
                this._additionalSupervisorID = value;
            }
        }

        public string AdditionalSupervisorFullName
        {
            get
            {
                return this._additionalSupervisorFullName;
            }
            set
            {
                this._additionalSupervisorFullName = value;
            }
        }

        public DateTime AdditionalSupervisorSignDate
        {
            get
            {
                return this._additionalSupervisorSignDate;
            }
            set
            {
                this._additionalSupervisorSignDate = value;
            }
        }

        public long PublishedID
        {
            get
            {
                return this._publishedID;
            }
            set
            {
                this._publishedID = value;
            }
        }

        public string FPPSPDID
        {
            get
            {
                return this._fPPSPDID;
            }
            set
            {
                this._fPPSPDID = value;
            }
        }

        public string FLSAType
        {
            get { return _FLSAType; }
            set { _FLSAType = value; }
        }

        public string PositionDescriptionType
        {
            get { return _positionDescriptionType; }
            set { _positionDescriptionType = value; }
        }

        public string PayPlanAbbrev
        {
            get { return _payPlanAbbrev; }
            set { _payPlanAbbrev = value; }
        }

        public string PayPlanTitle
        {
            get { return _payPlanTitle; }
            set { _payPlanTitle = value; }
        }

        public string PositionType
        {
            get { return _positionType; }
            set { _positionType = value; }
        }

        public string PositionStatusType
        {
            get { return _positionStatusType; }
            set { _positionStatusType = value; }
        }

        public string ReasonForSubmission
        {
            get { return _reasonForSubmission; }
            set { _reasonForSubmission = value; }
        }

        public string PositionSenesitivityType
        {
            get { return _positionSenesitivityType; }
            set { _positionSenesitivityType = value; }
        }

        public string Service
        {
            get { return _service; }
            set { _service = value; }
        }

        //public string OfficeLocation
        //{
        //    get { return _officeLocation; }
        //    set { _officeLocation = value; }
        //}

        public string SeriesDefinition
        {
            get { return _seriesDefinition; }
            set { _seriesDefinition = value; }
        }

        public string SeriesOPMTitle
        {
            get { return _seriesOPMTitle; }
            set { _seriesOPMTitle = value; }
        }

        public string CurrentWorkflowStatus
        {
            get
            {
                return this._currentWorkflowStatus;
            }
        }

        public int CheckedOutByID
        {
            get { return _checkedOutByID; }
            set { _checkedOutByID = value; }
        }

        public DateTime CheckOutDate
        {
            get { return _checkOutDate; }
            set { _checkOutDate = value; }
        }

        public int CheckedInByID
        {
            get { return _checkedInByID; }
            set { _checkedInByID = value; }
        }

        public DateTime CheckInDate
        {
            get { return _checkInDate; }
            set { _checkInDate = value; }
        }

        // ------------------------------

        public bool IsCheckedOut
        {
            get { return CheckedOutByID != -1; }
        }

        public string SupervisorOrgTitle
        {
            get
            {
                return this._supervisorOrgTitle;
            }
            set
            {
                this._supervisorOrgTitle = value;
            }
        }

        public string AdditionalSupOrgTitle
        {
            get
            {
                return this._additionalSupOrgTitle;
            }
            set
            {
                this._additionalSupOrgTitle = value;
            }
        }

        public long CopyFromPDID
        {
            get
            {
                return this._copyFromPDID;
            }
        }

        public int CopyFromPDIDByUserID
        {
            get
            {
                return this._copyFromPDIDByUserID;
            }
        }

        public DateTime CopyFromPDIDDate
        {
            get
            {
                return this._copyFromPDIDDate;
            }
        }

        public string EvaluatorOrgTitle { get { return this._evaluatorOrgTitle; } set { this._evaluatorOrgTitle = value; } }
        public string ClassifierOrgTitle { get { return this._classifierOrgTitle; } set { this._classifierOrgTitle = value; } }
        public bool HighGradeApproval { get { return this._highGradeApproval; } set { this._highGradeApproval = value; } }
        public bool IsInterdisciplinaryPD { get { return this._isInterdisciplinaryPD; } set { this._isInterdisciplinaryPD = value; } }
        public string AdditionalSeries { get { return this._additionalSeries; } set { this._additionalSeries = value; } }

        public int HCOID
        {
            get { return this._hcoID; }
            set { this._hcoID = value; }
        }
        public string HCOFullName
        {
            get { return this._hcoFullName; }
            set { this._hcoFullName = value; }
        }
        public DateTime HCOSignDate
        {
            get { return this._hcoSignDate; }
            set { this._hcoSignDate = value; }
        }
        public string HCOOrgTitle
        {
            get { return this._hcoOrgTitle; }
            set { this._hcoOrgTitle = value; }
        }
        /// <summary>
        ///  HasEvaluationStatement will return true if the PD has any one of the
        //eval criteria. PD Will have eval criteria if one of the justification fields  is
        //filled or if there is a factor level justification.
        /// </summary>
        public bool HasEvaluationStatement { get { return (this.GetPositionEvalCriteria().Count > 0); } }

        public bool HasFactorLanguage
        {
            get
            {
                bool ret = false;
                DbCommand commandWrapper = GetDbCommand("spr_HasPositionFactorLanguage");
                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    SqlParameter returnParam = new SqlParameter("@ret", SqlDbType.Bit);
                    returnParam.Direction = ParameterDirection.Output;
                    commandWrapper.Parameters.Add(returnParam);
                    ExecuteNonQuery(commandWrapper);
                    ret = (bool)returnParam.Value;

                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
                return ret;
            }
        }

        public bool HasCommentsRecommendations
        {
            get
            {
                bool ret = false;
                DbCommand commandWrapper = GetDbCommand("spr_HasPDCommentsRecommendations");
                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    SqlParameter returnParam = new SqlParameter("@ret", SqlDbType.Bit);
                    returnParam.Direction = ParameterDirection.Output;
                    commandWrapper.Parameters.Add(returnParam);
                    ExecuteNonQuery(commandWrapper);
                    ret = (bool)returnParam.Value;

                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
                return ret;
            }
        }

        #region "Changes related to Review Permission To HR"

        public bool ArePositionDutiesReviewed
        {
            get
            {
                return this._arePositionDutiesReviewed;
            }
            set
            {
                this._arePositionDutiesReviewed = value;
            }
        }
        public bool IsOccupationReviewComplete
        {
            get { return this._isOccupationReviewComplete; }
            set { this._isOccupationReviewComplete = value; }
        }
        public bool HasDutyDifferences(bool blnForBundle)
        {
            bool ret = false;
            DbCommand commandWrapper = GetDbCommand("spr_HasPositionDutyDifferences");
            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@ForBundle", blnForBundle));
                SqlParameter returnParam = new SqlParameter("@ret", SqlDbType.Bit);
                returnParam.Direction = ParameterDirection.Output;
                commandWrapper.Parameters.Add(returnParam);
                ExecuteNonQuery(commandWrapper);
                ret = (bool)returnParam.Value;

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return ret;
        }

        public bool HasDutyDifferences()
        {
            return HasDutyDifferences(false);
        }
        /// <summary>
        /// Returns true if there are occupation related changes made by HR during review
        /// </summary>
        /// <param name="blnForBundle"></param>
        /// <returns>bool</returns>
        public bool HasOccupationChangedDuringReview(bool blnForBundle)
        {

            bool ret = false;
            DbCommand commandWrapper = GetDbCommand("spr_HasPDOccupationChangedDuringReview");
            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@ForBundle", blnForBundle));
                SqlParameter returnParam = new SqlParameter("@ret", SqlDbType.Bit);
                returnParam.Direction = ParameterDirection.Output;
                commandWrapper.Parameters.Add(returnParam);
                ExecuteNonQuery(commandWrapper);
                ret = (bool)returnParam.Value;

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return ret;

        }

        public bool HasOccupationChangedDuringReview()
        {
            return HasOccupationChangedDuringReview(false);
        }

        public bool ArePositionFactorRecommendationsReviewed()
        {

            bool areFactorRecommendationsReviewed = false;
            if (this.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD || this.PositionDescriptionTypeID == (int)PDChoiceType.CLStatementOfDifferencePD)
            {
                PositionDescriptionCollection bundledPDs = this.GetOtherCareerLadderPositionDescriptions();
                areFactorRecommendationsReviewed = (this.GetNonReviewedPostionFactors().Count == 0);
                if (bundledPDs.Count > 0)
                {
                    foreach (PositionDescription item in bundledPDs)
                    {
                        areFactorRecommendationsReviewed = areFactorRecommendationsReviewed && (item.GetNonReviewedPostionFactors().Count == 0);
                    }
                }



            }
            else
            {
                areFactorRecommendationsReviewed = (this.GetNonReviewedPostionFactors().Count == 0);
            }
            return areFactorRecommendationsReviewed;


        }
        #endregion

        /// <summary>
        /// This will return true for all Position Description Types(including SODs)
        /// except for lower ladders of Career Ladder PDs
        /// </summary>
        public bool IsNonLowerLadderPD
        {
            get{
             
                PDChoiceType currentpdtypeid=(PDChoiceType)this._positionDescriptionTypeID;
                int ldrposn=this._ladderPosition ;
                //full performance cl
                if ((currentpdtypeid == PDChoiceType.CareerLadderPD && ldrposn <= 0)
                    || 
                    //non cl
                    (currentpdtypeid != PDChoiceType.CareerLadderPD && currentpdtypeid != PDChoiceType.CLStatementOfDifferencePD))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region [ Constructors ]
        public PositionDescription()
        {
            // Empty Constructor
        }
        public PositionDescription(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionDescriptionByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        public PositionDescription(DataRow singleRowData)
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

        #region [ Constructor Helper Methods ]

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

            this._positionDescriptionID = (long)returnRow["PositionDescriptionID"];
            this._isStandardPD = returnRow["IsStandardPD"].ToString();
            this._positionDescriptionTypeID = (int)returnRow["PositionDescriptionTypeID"];
            this._introduction = returnRow["Introduction"].ToString();
            this._oPMJobTitle = returnRow["OPMJobTitle"].ToString();

            if (returnRow["AgencyPositionTitle"] != DBNull.Value)
                this._agencyPositionTitle = returnRow["AgencyPositionTitle"].ToString();
            this._payPlanID = (int)returnRow["PayPlanID"];
            this._jobSeries = (int)returnRow["JobSeries"];
            this._proposedGrade = (int)returnRow["ProposedGrade"];
            this._proposedFPGrade = (int)returnRow["ProposedFPGrade"];
            this._positionTypeID = (int)returnRow["PositionTypeID"];

            if (returnRow["EEODStatement"] != DBNull.Value)
                this._eEODStatement = returnRow["EEODStatement"].ToString();

            if (returnRow["PositionDescriptionTypeDisp"] != DBNull.Value)
                this._positionDescriptionTypeDisp = returnRow["PositionDescriptionTypeDisp"].ToString();

            if (returnRow["PositionStatusTypeID"] != DBNull.Value)
                this._positionStatusTypeID = (int)returnRow["PositionStatusTypeID"];

            if (returnRow["PositionStatusTypeRemark"] != DBNull.Value)
                this._positionStatusTypeRemark = returnRow["PositionStatusTypeRemark"].ToString();

            if (returnRow["PositionSensitivityTypeID"] != DBNull.Value)
                this._positionSensitivityTypeID = (int)returnRow["PositionSensitivityTypeID"];

            if (returnRow["CompetitiveLevelCode"] != DBNull.Value)
                this._competitiveLevelCode = returnRow["CompetitiveLevelCode"].ToString().Trim();

            if (returnRow["FLSATypeID"] != DBNull.Value)
                this._fLSATypeID = (int)returnRow["FLSATypeID"];

            if (returnRow["FinancialStatementsRequired"] != DBNull.Value)
                this._financialStatementsRequired = returnRow["FinancialStatementsRequired"].ToString();

            if (returnRow["DrugTestingRequired"] != DBNull.Value)
                this._drugTestingRequired = returnRow["DrugTestingRequired"].ToString();

            if (returnRow["PhysicalExaminationRequired"] != DBNull.Value)
                this._physicalExaminationRequired = returnRow["PhysicalExaminationRequired"].ToString();

            if (returnRow["SubjectToIAaction"] != DBNull.Value)
                this._subjectToIAaction = returnRow["SubjectToIAaction"].ToString();

            if (returnRow["BargainingUnitStatus"] != DBNull.Value)
                this._bargainingUnitStatus = returnRow["BargainingUnitStatus"].ToString().Trim();

            if (returnRow["ReasonForSubmissionID"] != DBNull.Value)
                this._reasonForSubmissionID = (int)returnRow["ReasonForSubmissionID"];

            if (returnRow["ServiceID"] != DBNull.Value)
                this._serviceID = (int)returnRow["ServiceID"];


            if (returnRow["EmployingOfficeLocation"] != DBNull.Value)
                this._employingOfficeLocation = returnRow["EmployingOfficeLocation"].ToString();


            if (returnRow["DutyLocation"] != DBNull.Value)
                this._dutyLocation = returnRow["DutyLocation"].ToString();

            if (returnRow["Remarks"] != DBNull.Value)
                this._remarks = returnRow["Remarks"].ToString();

            if (returnRow["DeptAgencyEstablishment"] != DBNull.Value)
                this._deptAgencyEstablishment = returnRow["DeptAgencyEstablishment"].ToString();

            if (returnRow["FirstSubdivision"] != DBNull.Value)
                this._firstSubdivision = returnRow["FirstSubdivision"].ToString();

            if (returnRow["SecondSubdivision"] != DBNull.Value)
                this._secondSubdivision = returnRow["SecondSubdivision"].ToString();

            if (returnRow["OrganizationCodeID"] != DBNull.Value)
                this._organizationCodeID = (int)returnRow["OrganizationCodeID"];

            if (columns.Contains("OrganizationCode"))
            {
                if (returnRow["OrganizationCode"] != DBNull.Value)
                    this._organizationCode = returnRow["OrganizationCode"].ToString();
            }
            if (columns.Contains("OldOrganizationCode"))
            {
                if (returnRow["OldOrganizationCode"] != DBNull.Value)
                    this._oldOrganizationCode = (int)returnRow["OldOrganizationCode"];
            }
            if (columns.Contains("OrganizationName"))
            {
                if (returnRow["OrganizationName"] != DBNull.Value)
                    this._organizationCodeName = returnRow["OrganizationName"].ToString();
            }

            if (returnRow["FourthSubdivision"] != DBNull.Value)
                this._fourthSubdivision = returnRow["FourthSubdivision"].ToString();

            if (returnRow["FifthSubdivision"] != DBNull.Value)
                this._fifthSubdivision = returnRow["FifthSubdivision"].ToString();

            if (returnRow["PayPlanJustification"] != DBNull.Value)
                this._payPlanJustification = returnRow["PayPlanJustification"].ToString();
            if (returnRow["TitleJustification"] != DBNull.Value)
                this._titleJustification = returnRow["TitleJustification"].ToString();
            if (returnRow["SeriesJustification"] != DBNull.Value)
                this._seriesJustification = returnRow["SeriesJustification"].ToString();

            if (returnRow["GradeJustification"] != DBNull.Value)
                this._gradeJustification = returnRow["GradeJustification"].ToString();

            if (returnRow["AdditionalJustification"] != DBNull.Value)
                this._additionalJustification = returnRow["AdditionalJustification"].ToString();

            if (returnRow["SupervisoryCertText"] != DBNull.Value)
                this._supervisoryCertText = returnRow["SupervisoryCertText"].ToString();

            if (returnRow["SupervisorID"] != DBNull.Value)
                this._supervisorID = (int)returnRow["SupervisorID"];

            if (returnRow["SupervisorFullName"] != DBNull.Value)
                this._supervisorFullName = returnRow["SupervisorFullName"].ToString();

            if (returnRow["SupervisorSignDate"] != DBNull.Value)
                this._supervisorSignDate = (DateTime)returnRow["SupervisorSignDate"];


            if (returnRow["ClassifierCertText"] != DBNull.Value)
                this._classifierCertText = returnRow["ClassifierCertText"].ToString();

            if (returnRow["EvaluatorID"] != DBNull.Value)
                this._evaluatorID = (int)returnRow["EvaluatorID"];


            if (returnRow["EvaluatorFullName"] != DBNull.Value)
                this._evaluatorFullName = returnRow["EvaluatorFullName"].ToString();

            if (returnRow["EvaluatorSignDate"] != DBNull.Value)
                this._evaluatorSignDate = (DateTime)returnRow["EvaluatorSignDate"];


            if (returnRow["ClassifierID"] != DBNull.Value)
                this._classifierID = (int)returnRow["ClassifierID"];


            if (returnRow["ClassifierFullName"] != DBNull.Value)
                this._classifierFullName = returnRow["ClassifierFullName"].ToString();

            if (returnRow["ClassifierSignDate"] != DBNull.Value)
                this._classifierSignDate = (DateTime)returnRow["ClassifierSignDate"];

            this._pDCreatorID = (int)returnRow["PDCreatorID"];

            if (returnRow["AssociatedFullPD"] != DBNull.Value)
                this._associatedFullPD = (long)returnRow["AssociatedFullPD"];

            if (returnRow["LadderPosition"] != DBNull.Value)
                this._ladderPosition = (int)returnRow["LadderPosition"];

            if (returnRow["CareerLadderPDTypeID"] != DBNull.Value)
                this._careerLadderPDTypeID = (int)returnRow["CareerLadderPDTypeID"];

            if (returnRow["ParagraphOneText"] != DBNull.Value)
                this._paragraphOneText = returnRow["ParagraphOneText"].ToString();

            if (returnRow["ParagraphTwoText"] != DBNull.Value)
                this._paragraphTwoText = returnRow["ParagraphTwoText"].ToString();

            if (returnRow["ParagraphThreeText"] != DBNull.Value)
                this._paragraphThreeText = returnRow["ParagraphThreeText"].ToString();
            this._updatedByID = (int)returnRow["UpdatedByID"];
            this._updateDate = (DateTime)returnRow["UpdateDate"];

            if (returnRow["AdditionalSupervisorID"] != DBNull.Value)
                this._additionalSupervisorID = (int)returnRow["AdditionalSupervisorID"];

            if (returnRow["AdditionalSupervisorFullName"] != DBNull.Value)
                this._additionalSupervisorFullName = returnRow["AdditionalSupervisorFullName"].ToString();

            if (returnRow["AdditionalSupervisorSignDate"] != DBNull.Value)
                this._additionalSupervisorSignDate = (DateTime)returnRow["AdditionalSupervisorSignDate"];

            if (returnRow["PublishedID"] != DBNull.Value)
                this._publishedID = (long)returnRow["PublishedID"];

            if (returnRow["FPPSPDID"] != DBNull.Value)
                this._fPPSPDID = returnRow["FPPSPDID"].ToString();

            if (returnRow["FLSAType"] != DBNull.Value)
                this._FLSAType = returnRow["FLSAType"].ToString();
            if (returnRow["PositionDescriptionType"] != DBNull.Value)
                this._positionDescriptionType = returnRow["PositionDescriptionType"].ToString();
            if (returnRow["PayPlanAbbrev"] != DBNull.Value)
                this._payPlanAbbrev = returnRow["PayPlanAbbrev"].ToString();
            if (returnRow["PayPlanTitle"] != DBNull.Value)
                this._payPlanTitle = returnRow["PayPlanTitle"].ToString();
            if (returnRow["PositionType"] != DBNull.Value)
                this._positionType = returnRow["PositionType"].ToString();
            if (returnRow["PositionStatusType"] != DBNull.Value)
                this._positionStatusType = returnRow["PositionStatusType"].ToString();
            if (returnRow["ReasonForSubmission"] != DBNull.Value)
                this._reasonForSubmission = returnRow["ReasonForSubmission"].ToString();
            if (returnRow["PositionSenesitivityType"] != DBNull.Value)
                this._positionSenesitivityType = returnRow["PositionSenesitivityType"].ToString();
            if (returnRow["Service"] != DBNull.Value)
                this._service = returnRow["Service"].ToString();
            //if (returnRow["OfficeLocation"] != DBNull.Value)
            //    this._officeLocation = returnRow["OfficeLocation"].ToString();
            if (returnRow["SeriesDefinition"] != DBNull.Value)
                this._seriesDefinition = returnRow["SeriesDefinition"].ToString();
            if (returnRow["SeriesName"] != DBNull.Value)
                this._seriesDefinition = returnRow["SeriesName"].ToString();

            if (returnRow["CheckedOutByID"] != DBNull.Value)
                this._checkedOutByID = (int)returnRow["CheckedOutByID"];
            if (returnRow["CheckOutDate"] != DBNull.Value)
                this._checkOutDate = (DateTime)returnRow["CheckOutDate"];

            if (returnRow["CheckedInByID"] != DBNull.Value)
                this._checkedInByID = (int)returnRow["CheckedInByID"];
            if (returnRow["CheckInDate"] != DBNull.Value)
                this._checkInDate = (DateTime)returnRow["CheckInDate"];
            if (returnRow["SupervisorOrgTitle"] != DBNull.Value)
                this._supervisorOrgTitle = returnRow["SupervisorOrgTitle"].ToString();
            if (returnRow["AdditionalSupOrgTitle"] != DBNull.Value)
                this._additionalSupOrgTitle = returnRow["AdditionalSupOrgTitle"].ToString();
            //if (returnRow["SeriesOPMTitle"] != DBNull.Value)
            //    this._seriesOPMTitle = returnRow["SeriesOPMTitle"].ToString();

            if (returnRow["CopyFromPDID"] != DBNull.Value)
                this._copyFromPDID = (long)returnRow["CopyFromPDID"];

            if (returnRow["CopyFromPDIDByUserID"] != DBNull.Value)
                this._copyFromPDIDByUserID = (int)returnRow["CopyFromPDIDByUserID"];

            if (returnRow["CopyFromPDIDDate"] != DBNull.Value)
                this._copyFromPDIDDate = (DateTime)returnRow["CopyFromPDIDDate"];
            if (returnRow["EvaluatorOrgTitle"] != DBNull.Value)
                this._evaluatorOrgTitle = returnRow["EvaluatorOrgTitle"].ToString();
            if (returnRow["ClassifierOrgTitle"] != DBNull.Value)
                this._classifierOrgTitle = returnRow["ClassifierOrgTitle"].ToString();
            if (returnRow["HighGradeApproval"] != DBNull.Value)
                this._highGradeApproval = (bool)returnRow["HighGradeApproval"];

            if (columns.Contains("WorkFlowStatus"))
            {
                if (returnRow["WorkFlowStatus"] != DBNull.Value)
                    this._currentWorkflowStatus = returnRow["WorkFlowStatus"].ToString();
            }
            if (returnRow["IsInterdisciplinaryPD"] != DBNull.Value)
                this._isInterdisciplinaryPD = (bool)returnRow["IsInterdisciplinaryPD"];
            if (returnRow["AdditionalSeries"] != DBNull.Value)
                this._additionalSeries = returnRow["AdditionalSeries"].ToString();

            if (columns.Contains("HCOID"))
            {
                if (returnRow["HCOID"] != DBNull.Value)
                    this._hcoID = (int)returnRow["HCOID"];
            }
            if (columns.Contains("HCOFullName"))
            {
                if (returnRow["HCOFullName"] != DBNull.Value)
                    this._hcoFullName = returnRow["HCOFullName"].ToString();
            }
            if (columns.Contains("HCOSignDate"))
            {
                if (returnRow["HCOSignDate"] != DBNull.Value)
                    this._hcoSignDate = (DateTime)returnRow["HCOSignDate"];

            }
            if (columns.Contains("HCOOrgTitle"))
            {
                if (returnRow["HCOOrgTitle"] != DBNull.Value)
                    this._hcoOrgTitle = returnRow["HCOOrgTitle"].ToString();
            }

            #region "Changes related to Review Permission To HR"
            if (columns.Contains("ArePositionDutiesReviewed"))
            {
                if (returnRow["ArePositionDutiesReviewed"] != DBNull.Value)
                    this._arePositionDutiesReviewed = (bool)returnRow["ArePositionDutiesReviewed"];
            }

            if (columns.Contains("IsOccupationReviewComplete"))
            {
                if (returnRow["IsOccupationReviewComplete"] != DBNull.Value)
                    this._isOccupationReviewComplete = (bool)returnRow["IsOccupationReviewComplete"];
            }

            #endregion
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
            return "PositionDescriptionID:" + PositionDescriptionID.ToString();
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
            PositionDescription PositionDescriptionobj = obj as PositionDescription;

            return (PositionDescriptionobj == null) ? false : (this.PositionDescriptionID == PositionDescriptionobj.PositionDescriptionID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return PositionDescriptionID.GetHashCode();
        }
        #endregion

        #region [ General Methods ]

        public void Add(PositionWorkflowStatus positionworkflowstatus)
        {
            TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
            currentTransaction.BeginTransaction();

            DbCommand commandWrapper = GetDbCommand("spr_AddPositionDescription");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newPositionDescriptionID", SqlDbType.BigInt);
                returnParam.Direction = ParameterDirection.Output;

                // get the new PositionDescriptionID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@isStandardPD", this._isStandardPD.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionTypeID", this._positionDescriptionTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@introduction", this._introduction.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@oPMJobTitle", this._oPMJobTitle.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@agencyPositionTitle", this._agencyPositionTitle));
                commandWrapper.Parameters.Add(new SqlParameter("@payPlanID", this._payPlanID));
                commandWrapper.Parameters.Add(new SqlParameter("@jobSeries", this._jobSeries));
                commandWrapper.Parameters.Add(new SqlParameter("@proposedGrade", this._proposedGrade));
                commandWrapper.Parameters.Add(new SqlParameter("@proposedFPGrade", this._proposedFPGrade));
                commandWrapper.Parameters.Add(new SqlParameter("@positionTypeID", this._positionTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@eEODStatement", this._eEODStatement));

                if (this._positionStatusTypeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@positionStatusTypeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@positionStatusTypeID", this._positionStatusTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@positionStatusTypeRemark", this._positionStatusTypeRemark));

                if (this._positionSensitivityTypeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@positionSensitivityTypeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@positionSensitivityTypeID", this._positionSensitivityTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@competitiveLevelCode", this._competitiveLevelCode));

                if (this._fLSATypeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@fLSATypeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@fLSATypeID", this._fLSATypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@financialStatementsRequired", this._financialStatementsRequired));
                commandWrapper.Parameters.Add(new SqlParameter("@drugTestingRequired", this._drugTestingRequired));
                commandWrapper.Parameters.Add(new SqlParameter("@physicalExaminationRequired", this._physicalExaminationRequired));
                commandWrapper.Parameters.Add(new SqlParameter("@subjectToIAaction", this._subjectToIAaction));
                commandWrapper.Parameters.Add(new SqlParameter("@bargainingUnitStatus", this._bargainingUnitStatus));

                if (this._reasonForSubmissionID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@reasonForSubmissionID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@reasonForSubmissionID", this._reasonForSubmissionID));

                if (this._serviceID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@serviceID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@serviceID", this._serviceID));


                commandWrapper.Parameters.Add(new SqlParameter("@employingOfficeLocation", this._employingOfficeLocation));
                commandWrapper.Parameters.Add(new SqlParameter("@dutyLocation", this._dutyLocation));
                commandWrapper.Parameters.Add(new SqlParameter("@remarks", this._remarks));
                commandWrapper.Parameters.Add(new SqlParameter("@deptAgencyEstablishment", this._deptAgencyEstablishment));
                commandWrapper.Parameters.Add(new SqlParameter("@firstSubdivision", this._firstSubdivision));
                commandWrapper.Parameters.Add(new SqlParameter("@secondSubdivision", this._secondSubdivision));

                if (this._organizationCodeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@organizationCodeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@organizationCodeID", this._organizationCodeID));

                commandWrapper.Parameters.Add(new SqlParameter("@fourthSubdivision", this._fourthSubdivision));
                commandWrapper.Parameters.Add(new SqlParameter("@fifthSubdivision", this._fifthSubdivision));
                commandWrapper.Parameters.Add(new SqlParameter("@payPlanJustification", this._payPlanJustification));
                commandWrapper.Parameters.Add(new SqlParameter("@titleJustification", this._titleJustification));

                commandWrapper.Parameters.Add(new SqlParameter("@seriesJustification", this._seriesJustification));
                commandWrapper.Parameters.Add(new SqlParameter("@gradeJustification", this._gradeJustification));
                commandWrapper.Parameters.Add(new SqlParameter("@additionalJustification", this._additionalJustification));
                commandWrapper.Parameters.Add(new SqlParameter("@supervisoryCertText", this._supervisoryCertText));

                if (this._supervisorID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", this._supervisorID));

                commandWrapper.Parameters.Add(new SqlParameter("@supervisorFullName", this._supervisorFullName));

                if (this._supervisorSignDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", this._supervisorSignDate));

                commandWrapper.Parameters.Add(new SqlParameter("@classifierCertText", this._classifierCertText));

                if (this._evaluatorID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@evaluatorID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@evaluatorID", this._evaluatorID));
                commandWrapper.Parameters.Add(new SqlParameter("@evaluatorFullName", this._evaluatorFullName));

                if (this._evaluatorSignDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@evaluatorSignDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@evaluatorSignDate", this._evaluatorSignDate));

                if (this._classifierID == -1)
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierID", DBNull.Value));
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierFullName", DBNull.Value));
                }
                else
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierID", this._classifierID));
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierFullName", this._classifierFullName));
                }

                if (this._classifierSignDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierSignDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierSignDate", this._classifierSignDate));

                commandWrapper.Parameters.Add(new SqlParameter("@pDCreatorID", this._pDCreatorID));

                if (this._associatedFullPD == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@associatedFullPD", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@associatedFullPD", this._associatedFullPD));

                commandWrapper.Parameters.Add(new SqlParameter("@paragraphOneText", this._paragraphOneText));
                commandWrapper.Parameters.Add(new SqlParameter("@paragraphTwoText", this._paragraphTwoText));
                commandWrapper.Parameters.Add(new SqlParameter("@paragraphThreeText", this._paragraphThreeText));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));

                if (this._updateDate == DateTime.MinValue)
                    this._updateDate = DateTime.Now;

                commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));

                if (this._additionalSupervisorID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalSupervisorID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalSupervisorID", this._additionalSupervisorID));
                commandWrapper.Parameters.Add(new SqlParameter("@additionalSupervisorFullName", this._additionalSupervisorFullName));

                if (this._additionalSupervisorSignDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalSupervisorSignDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalSupervisorSignDate", this._additionalSupervisorSignDate));
                // commandWrapper.Parameters.Add(new SqlParameter("@publishedID", this._publishedID));
                commandWrapper.Parameters.Add(new SqlParameter("@fPPSPDID", this._fPPSPDID));

                commandWrapper.Parameters.Add(new SqlParameter("@checkedOutByID", this._checkedOutByID));
                commandWrapper.Parameters.Add(new SqlParameter("@checkOutDate", this._checkOutDate));

                commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", this._supervisorOrgTitle));
                commandWrapper.Parameters.Add(new SqlParameter("@additionalSupOrgTitle", this._additionalSupOrgTitle));
                commandWrapper.Parameters.Add(new SqlParameter("@evaluatorOrgTitle", this._evaluatorOrgTitle));
                commandWrapper.Parameters.Add(new SqlParameter("@classifierOrgTitle", this._classifierOrgTitle));
                commandWrapper.Parameters.Add(new SqlParameter("@HighGradeApproval", this._highGradeApproval));
                commandWrapper.Parameters.Add(new SqlParameter("@IsInterdisciplinaryPD", this._isInterdisciplinaryPD));
                commandWrapper.Parameters.Add(new SqlParameter("@AdditionalSeries", this._additionalSeries));

                DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                long lngPDID = (long)returnParam.Value;

                if (lngPDID == -1)
                    throw new BusinessException("The Position Description was not created successfully.");
                else
                {
                    this._positionDescriptionID = lngPDID;
                    if (positionworkflowstatus != null)
                    {
                        positionworkflowstatus.PositionDescriptionID = lngPDID;
                        positionworkflowstatus.Add(currentTransaction);

                    }
                    currentTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                if (currentTransaction.IsOpen)
                    currentTransaction.Rollback();

                HandleException(ex);
            }
        }

        public void AddFromExisting(long copyFromPDID)
        {
            if (copyFromPDID != -1)
            {
                DbCommand commandWrapper = GetDbCommand("spr_AddPositionDescriptionFromExistingPD");

                try
                {
                    SqlParameter returnParam = new SqlParameter("@newPDID", SqlDbType.BigInt);
                    returnParam.Direction = ParameterDirection.Output;

                    // get the new PositionDescriptionID of the record
                    commandWrapper.Parameters.Add(returnParam);

                    commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDID", copyFromPDID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._pDCreatorID));

                    ExecuteNonQuery(commandWrapper);

                    long newPDID = (long)returnParam.Value;

                    if (newPDID == -1)
                        throw new BusinessException("PD Express could not create a copy of the selected position description.");
                    else
                        this._positionDescriptionID = newPDID;
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
            else
                HandleException(new Exception("You must specify a valid position description ID before attempting to copy."));
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionDescription");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@isStandardPD", this._isStandardPD.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionTypeID", this._positionDescriptionTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@introduction", this._introduction.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@oPMJobTitle", this._oPMJobTitle.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@agencyPositionTitle", this._agencyPositionTitle));
                    commandWrapper.Parameters.Add(new SqlParameter("@payPlanID", this._payPlanID));
                    commandWrapper.Parameters.Add(new SqlParameter("@jobSeries", this._jobSeries));
                    commandWrapper.Parameters.Add(new SqlParameter("@proposedGrade", this._proposedGrade));
                    commandWrapper.Parameters.Add(new SqlParameter("@proposedFPGrade", this._proposedFPGrade));
                    commandWrapper.Parameters.Add(new SqlParameter("@positionTypeID", this._positionTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@eEODStatement", this._eEODStatement));

                    if (this._positionStatusTypeID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@positionStatusTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@positionStatusTypeID", this._positionStatusTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@positionStatusTypeRemark", this._positionStatusTypeRemark));

                    if (this._positionSensitivityTypeID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@positionSensitivityTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@positionSensitivityTypeID", this._positionSensitivityTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@competitiveLevelCode", this._competitiveLevelCode));

                    if (this._fLSATypeID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@fLSATypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@fLSATypeID", this._fLSATypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@financialStatementsRequired", this._financialStatementsRequired));
                    commandWrapper.Parameters.Add(new SqlParameter("@drugTestingRequired", this._drugTestingRequired));
                    commandWrapper.Parameters.Add(new SqlParameter("@physicalExaminationRequired", this._physicalExaminationRequired));
                    commandWrapper.Parameters.Add(new SqlParameter("@subjectToIAaction", this._subjectToIAaction));
                    commandWrapper.Parameters.Add(new SqlParameter("@bargainingUnitStatus", this._bargainingUnitStatus));

                    if (this._reasonForSubmissionID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@reasonForSubmissionID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@reasonForSubmissionID", this._reasonForSubmissionID));

                    if (this._serviceID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@serviceID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@serviceID", this._serviceID));

                    commandWrapper.Parameters.Add(new SqlParameter("@employingOfficeLocation", this._employingOfficeLocation));
                    commandWrapper.Parameters.Add(new SqlParameter("@dutyLocation", this._dutyLocation));
                    commandWrapper.Parameters.Add(new SqlParameter("@remarks", this._remarks));
                    commandWrapper.Parameters.Add(new SqlParameter("@deptAgencyEstablishment", this._deptAgencyEstablishment));
                    commandWrapper.Parameters.Add(new SqlParameter("@firstSubdivision", this._firstSubdivision));
                    commandWrapper.Parameters.Add(new SqlParameter("@secondSubdivision", this._secondSubdivision));

                    if (this._organizationCodeID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@organizationCodeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@organizationCodeID", this._organizationCodeID));

                    commandWrapper.Parameters.Add(new SqlParameter("@fourthSubdivision", this._fourthSubdivision));
                    commandWrapper.Parameters.Add(new SqlParameter("@fifthSubdivision", this._fifthSubdivision));
                    commandWrapper.Parameters.Add(new SqlParameter("@payPlanJustification", this._payPlanJustification));
                    commandWrapper.Parameters.Add(new SqlParameter("@titleJustification", this._titleJustification));

                    commandWrapper.Parameters.Add(new SqlParameter("@seriesJustification", this._seriesJustification));
                    commandWrapper.Parameters.Add(new SqlParameter("@gradeJustification", this._gradeJustification));
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalJustification", this._additionalJustification));
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisoryCertText", this._supervisoryCertText));

                    if (this._supervisorID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", this._supervisorID));
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorFullName", this._supervisorFullName));

                    if (this._supervisorSignDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", this._supervisorSignDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierCertText", this._classifierCertText));

                    if (this._evaluatorID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@evaluatorID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@evaluatorID", this._evaluatorID));
                    commandWrapper.Parameters.Add(new SqlParameter("@evaluatorFullName", this._evaluatorFullName));

                    if (this._evaluatorSignDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@evaluatorSignDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@evaluatorSignDate", this._evaluatorSignDate));

                    if (this._classifierID == -1)
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@classifierID", DBNull.Value));
                        commandWrapper.Parameters.Add(new SqlParameter("@classifierFullName", DBNull.Value));
                    }
                    else
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@classifierID", this._classifierID));
                        commandWrapper.Parameters.Add(new SqlParameter("@classifierFullName", this._classifierFullName));
                    }

                    if (this._classifierSignDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@classifierSignDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@classifierSignDate", this._classifierSignDate));

                    if (this._associatedFullPD == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@associatedFullPD", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@associatedFullPD", this._associatedFullPD));

                    commandWrapper.Parameters.Add(new SqlParameter("@paragraphOneText", this._paragraphOneText));
                    commandWrapper.Parameters.Add(new SqlParameter("@paragraphTwoText", this._paragraphTwoText));
                    commandWrapper.Parameters.Add(new SqlParameter("@paragraphThreeText", this._paragraphThreeText));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                    //if (this._updateDate == DateTime.MinValue)

                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", DateTime.Now));
                    //else
                    //    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));


                    if (this._additionalSupervisorID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@additionalSupervisorID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@additionalSupervisorID", this._additionalSupervisorID));
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalSupervisorFullName", this._additionalSupervisorFullName));

                    if (this._additionalSupervisorSignDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@additionalSupervisorSignDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@additionalSupervisorSignDate", this._additionalSupervisorSignDate));

                    commandWrapper.Parameters.Add(new SqlParameter("@fPPSPDID", this._fPPSPDID));
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", this._supervisorOrgTitle));
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalSupOrgTitle", this._additionalSupOrgTitle));
                    commandWrapper.Parameters.Add(new SqlParameter("@evaluatorOrgTitle", this._evaluatorOrgTitle));
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierOrgTitle", this._classifierOrgTitle));
                    commandWrapper.Parameters.Add(new SqlParameter("@HighGradeApproval", this._highGradeApproval));
                    commandWrapper.Parameters.Add(new SqlParameter("@IsInterdisciplinaryPD", this._isInterdisciplinaryPD));
                    commandWrapper.Parameters.Add(new SqlParameter("@AdditionalSeries", this._additionalSeries));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void CreateSOD()
        {
            if (base.ValidateKeyField(this._associatedFullPD))
            {
                DbCommand commandWrapper = GetDbCommand("spr_CreateSODForExistingPD");

                try
                {
                    SqlParameter returnParam = new SqlParameter("@newSODPDID", SqlDbType.BigInt);
                    returnParam.Direction = ParameterDirection.Output;

                    // get the new PositionDescriptionID of the record
                    commandWrapper.Parameters.Add(returnParam);

                    commandWrapper.Parameters.Add(new SqlParameter("@existingPDID", this._associatedFullPD));
                    commandWrapper.Parameters.Add(new SqlParameter("@paragraphOneText", this._paragraphOneText));
                    commandWrapper.Parameters.Add(new SqlParameter("@paragraphTwoText", this._paragraphTwoText));
                    commandWrapper.Parameters.Add(new SqlParameter("@paragraphThreeText", this._paragraphThreeText));
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._pDCreatorID));

                    ExecuteNonQuery(commandWrapper);

                    long newSODPDID = (long)returnParam.Value;

                    if (newSODPDID == -1)
                        throw new BusinessException("PD Express could not create a statement of difference for the selected position description.");
                    else
                        this._positionDescriptionID = newSODPDID;
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
            else
                HandleException(new Exception("You must specify a valid position description ID before attempting to create statement of difference."));
        }

        public void CreateLadderPositionDescriptions(ArrayList gradeList)
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_CreateCareerLadderPositionDescriptions");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@associatedFullPDID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByUserID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@careerLadderPDTypeID", this._careerLadderPDTypeID));

                    string gradeListCommaDelimited = GetCommaDelimitedList(gradeList);
                    commandWrapper.Parameters.Add(new SqlParameter("@gradeList", gradeListCommaDelimited));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void Delete()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeletePositionDescription", this._positionDescriptionID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void ChangeOwner(int newOwnerUserID)
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
                ExecuteNonQuery("spr_ChangePositionDescriptionOwner", this._positionDescriptionID, newOwnerUserID);
        }

        public void Reactivate()
        {
            this.changeActivation(true);
        }

        public void Deactivate()
        {
            this.changeActivation(false);
        }

        private void changeActivation(bool reActivate)
        {
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_ChangeActivation");

                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionIDLoad", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@reActivate", reActivate));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));

                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion

        #region [ Other Methods ]

        public void SaveEval(TransactionManager currentTransaction)
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionEval");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@titleJustification", this._titleJustification));
                    commandWrapper.Parameters.Add(new SqlParameter("@seriesJustification", this._seriesJustification));
                    commandWrapper.Parameters.Add(new SqlParameter("@gradeJustification", this._gradeJustification));
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalJustification", this._additionalJustification));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", DateTime.Now));
                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }
                }
                catch (Exception ex)
                {
                    if ((currentTransaction != null) && (currentTransaction.IsOpen))
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }
        public void DeletePositionEvaluation()
        {
            TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
            currentTransaction.BeginTransaction();
            try
            {
                this._titleJustification = string.Empty;
                this._seriesJustification = string.Empty;
                this._additionalJustification = string.Empty;
                this._gradeJustification = string.Empty;
                SaveEval(currentTransaction);
                DeletePositionFactorJustification(currentTransaction);
                currentTransaction.Commit();
            }
            catch (Exception ex)
            {
                if (currentTransaction.IsOpen)
                    currentTransaction.Rollback();
                HandleException(ex);
            }

        }
        public void DeletePositionFactorJustification(TransactionManager currentTransaction)
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_DeletePositionFactorJustification");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", DateTime.Now));
                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }
                }
                catch (Exception ex)
                {
                    if ((currentTransaction != null) && (currentTransaction.IsOpen))
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }
        public void Sign(int signedbyID, string signedbyFullName, SignatureType signaturetype, string signedbyOrgTitle, string certification)
        {
            Sign(signedbyID, signedbyFullName, signaturetype, signedbyOrgTitle, null, certification);
        }

        public void Sign(int signedbyID, string signedbyFullName, SignatureType signaturetype, string signedbyOrgTitle, TransactionManager currentTransaction, string certification)
        {
            DbCommand commandWrapper = GetDbCommand("spr_SignPositionDescription");

            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@signaturetype", signaturetype));
                commandWrapper.Parameters.Add(new SqlParameter("@signedbyID", signedbyID));
                commandWrapper.Parameters.Add(new SqlParameter("@signedbyFullName", signedbyFullName));
                commandWrapper.Parameters.Add(new SqlParameter("@signedbyOrgTitle", signedbyOrgTitle));
                commandWrapper.Parameters.Add(new SqlParameter("@certification", certification));

                if (currentTransaction != null)
                {
                    DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                }
                else
                {
                    ExecuteNonQuery(commandWrapper);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Sign(int signedbyID, string signedbyFullName, SignatureType signaturetype, string signedbyOrgTitle, bool checkin, string certification)
        {
            if (checkin)
            {
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();
                try
                {
                    Sign(signedbyID, signedbyFullName, signaturetype, signedbyOrgTitle, currentTransaction, certification);
                    CheckIn(signedbyID, currentTransaction);
                    currentTransaction.Commit();

                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
            else
            {
                Sign(signedbyID, signedbyFullName, signaturetype, signedbyOrgTitle, null, certification);
            }
        }

        public void GetPositionSignatures()
        {
            DbCommand commandWrapper = GetDbCommand("spr_GetPositionSignatures");
            DataTable returnTable = new DataTable();

            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                returnTable = ExecuteDataTable(commandWrapper);
                if (returnTable.Rows.Count > 0)
                {
                    DataRow returnRow = returnTable.Rows[0];
                    if (returnRow["SupervisoryCertText"] != DBNull.Value)
                        this._supervisoryCertText = returnRow["SupervisoryCertText"].ToString();

                    if (returnRow["SupervisorID"] != DBNull.Value)
                        this._supervisorID = (int)returnRow["SupervisorID"];

                    if (returnRow["SupervisorFullName"] != DBNull.Value)
                        this._supervisorFullName = returnRow["SupervisorFullName"].ToString();

                    if (returnRow["SupervisorSignDate"] != DBNull.Value)
                        this._supervisorSignDate = (DateTime)returnRow["SupervisorSignDate"];

                    if (returnRow["AdditionalSupervisorID"] != DBNull.Value)
                        this._additionalSupervisorID = (int)returnRow["AdditionalSupervisorID"];

                    if (returnRow["AdditionalSupervisorFullName"] != DBNull.Value)
                        this._additionalSupervisorFullName = returnRow["AdditionalSupervisorFullName"].ToString();

                    if (returnRow["AdditionalSupervisorSignDate"] != DBNull.Value)
                        this._additionalSupervisorSignDate = (DateTime)returnRow["AdditionalSupervisorSignDate"];

                    if (returnRow["ClassifierCertText"] != DBNull.Value)
                        this._classifierCertText = returnRow["ClassifierCertText"].ToString();

                    if (returnRow["EvaluatorID"] != DBNull.Value)
                        this._evaluatorID = (int)returnRow["EvaluatorID"];


                    if (returnRow["EvaluatorFullName"] != DBNull.Value)
                        this._evaluatorFullName = returnRow["EvaluatorFullName"].ToString();

                    if (returnRow["EvaluatorSignDate"] != DBNull.Value)
                        this._evaluatorSignDate = (DateTime)returnRow["EvaluatorSignDate"];


                    if (returnRow["ClassifierID"] != DBNull.Value)
                        this._classifierID = (int)returnRow["ClassifierID"];


                    if (returnRow["ClassifierFullName"] != DBNull.Value)
                        this._classifierFullName = returnRow["ClassifierFullName"].ToString();

                    if (returnRow["ClassifierSignDate"] != DBNull.Value)
                        this._classifierSignDate = (DateTime)returnRow["ClassifierSignDate"];

                    if (returnRow["SupervisorOrgTitle"] != DBNull.Value)
                        this._supervisorOrgTitle = returnRow["SupervisorOrgTitle"].ToString();
                    if (returnRow["AdditionalSupOrgTitle"] != DBNull.Value)
                        this._additionalSupOrgTitle = returnRow["AdditionalSupOrgTitle"].ToString();
                    if (returnRow["EvaluatorOrgTitle"] != DBNull.Value)
                        this._evaluatorOrgTitle = returnRow["EvaluatorOrgTitle"].ToString();
                    if (returnRow["ClassifierOrgTitle"] != DBNull.Value)
                        this._classifierOrgTitle = returnRow["ClassifierOrgTitle"].ToString();
                }

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        public void UpdateHighGradeApproval()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateHighGradeApproval");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@HighGradeApproval", this._highGradeApproval));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", DateTime.Now));
                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void UpdatePositionDutiesReviewedFlag()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionDutiesReviewedFlag");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@ArePositionDutiesReviewed", this._arePositionDutiesReviewed));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", DateTime.Now));
                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public PDValidationErrorCollection GetValidationErrors()
        {
            return this.GetValidationErrors(false);
        }
        public PDValidationErrorCollection GetValidationErrors(bool fastTrackToPublish)
        {
            return this.GetValidationErrors(fastTrackToPublish, false);
        }
        public PDValidationErrorCollection GetValidationErrors(bool fastTrackToPublish, bool validateForFactorScreen)
        {
            bool isValid = false;
            PDValidationErrorCollection errorList = new PDValidationErrorCollection();

            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_ValidatePositionDescriptionAndGetErrorMessages");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@fastTrack", fastTrackToPublish));
                    commandWrapper.Parameters.Add(new SqlParameter("@validateForFactorScreen", validateForFactorScreen));

                    SqlParameter returnParam = new SqlParameter("@validationSuccessful", SqlDbType.Bit);
                    returnParam.Direction = ParameterDirection.Output;
                    commandWrapper.Parameters.Add(returnParam);

                    errorList = PDValidationError.GetCollection(ExecuteDataTable(commandWrapper));
                    isValid = (bool)returnParam.Value;
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return errorList;
        }

        public string Validate(bool validateForFactorScreen)
        {
            return this.Validate(false, validateForFactorScreen);
        }

        public string Validate(bool fastTrackToPublish, bool validateForFactorScreen)
        {
            StringBuilder validationErrors = new StringBuilder();

            try
            {
                PDValidationErrorCollection errorList = this.GetValidationErrors(fastTrackToPublish, validateForFactorScreen);

                if (errorList.Count > 0)
                {
                    foreach (PDValidationError error in errorList)
                        validationErrors.Append(string.Format("{0}<br />", error.ErrorMessage));
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return validationErrors.ToString();
        }

        public string GetIntroduction()
        {
            string intro = this.Introduction;
            if ((intro.Length == 0) && (this.OrganizationCodeID > 0))
            {
                OrganizationCode currentorgcode = new OrganizationCode(this.OrganizationCodeID);
                intro = currentorgcode.Introduction;

            }
            return intro;
        }

        public PositionGradePoint GetPositionGradePoint()
        {
            PositionGradePoint _positionGradePoint = new PositionGradePoint(this._positionDescriptionID);
            return _positionGradePoint;
        }

        public PositionGradePoint GetPositionGradePointByFactorFormatTypeID(int factorFormatTypeID)
        {
            PositionGradePoint _positionGradePoint = new PositionGradePoint(this._positionDescriptionID, factorFormatTypeID);
            return _positionGradePoint;
        }

        public PositionClassificationStandard GetPositionClassificationStandardByClassSourceID(int classsourceID)
        {
            PositionClassificationStandard current = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {

                    DataTable dt = ExecuteDataTable("spr_GetPositionClassificationStandardByClassSourceID", this._positionDescriptionID, classsourceID);
                    if (dt.Rows.Count > 0)
                    {

                        current = new PositionClassificationStandard(dt.Rows[0]);
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
            return current;
        }

        public DataTable GetPositionDescriptionCurrentStatusInfo()
        {
            DataTable returnTable = null;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionDescriptionCurrentStatusInfo", this._positionDescriptionID);

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return returnTable;
        }
        public DataTable GetPositionFactorDiff()
        {
            DataTable returnTable = null;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionFactorDiff", this._positionDescriptionID);

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return returnTable;
        }

        public bool DoSimilarPositionDescriptionsExist()
        {
            bool exist = false;

            try
            {
                exist = (int)ExecuteScalar("spr_DoSimilarPositionDescriptionsExist", this._jobSeries, this._proposedGrade, (int)PDStatus.Published) == 1 ? true : false;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return exist;
        }

        public void Publish(int publishedByID, bool fastTrack)
        {
            DbCommand commandWrapper = GetDbCommand("spr_PublishPositionDescription");

            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@publishedByID", publishedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusID", (int)PDStatus.Published));
                commandWrapper.Parameters.Add(new SqlParameter("@useFastTrack", fastTrack));
                ExecuteNonQuery(commandWrapper);

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void SetPositionClassificationStandard()
        {
            DbCommand commandWrapper = GetDbCommand("spr_SetPositionDescriptionClassificationStandard");

            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@PayPlanID", this._payPlanID));
                commandWrapper.Parameters.Add(new SqlParameter("@JobSeries", this._jobSeries));
                commandWrapper.Parameters.Add(new SqlParameter("@PositionTypeID", this._positionTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@PDCreatorID", this._pDCreatorID));
                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public bool OnlyPrimaryFESStandard()
        {
            bool jsFESfound = false;
            int fesformatcount = 0;
            List<PositionClassificationStandard> PCl = GetPositionClassificationStandard();
            if (PCl.Count > 0)
            {
                foreach (PositionClassificationStandard pc in PCl)
                {
                    if (pc.FactorFormatTypeID == (int)enumFactorFormatType.FES)
                    {
                        fesformatcount++;
                    }
                    if (pc.ClassificationSourceID == (int)enumClassStandardSource.JSFES)
                    {
                        jsFESfound = true;
                    }
                }
            }
            if (fesformatcount > 0 && jsFESfound == false)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        #endregion

        #region [ PositionWorkflowStatus Related Methods ]

        public void SetPositionCurrentStatus(PDStatus currentStatus, int userid)
        {
            SetPositionCurrentStatus(currentStatus, userid, null);
        }

        public void SetPositionCurrentStatus(PDStatus currentStatus, int userid, TransactionManager currentTransaction)
        {

            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    PositionWorkflowStatus currentworkflowstatus = new PositionWorkflowStatus();
                    currentworkflowstatus.PositionDescriptionID = this._positionDescriptionID;
                    currentworkflowstatus.WorkflowStatusID = (int)currentStatus;
                    currentworkflowstatus.CreatedByID = userid;
                    currentworkflowstatus.CreateDate = DateTime.Now;
                    currentworkflowstatus.IsCurrent = true;
                    currentworkflowstatus.Add(currentTransaction);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

        }
        public void SetPositionCurrentStatus(PDStatus currentStatus, int userid, bool checkin)
        {

            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                if (checkin)
                {
                    TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                    currentTransaction.BeginTransaction();
                    try
                    {
                        if (currentStatus == PDStatus.Review) //status is going to change to review
                        {
                            LogPositionDescription(PDStatus.Draft, userid, currentTransaction); //log PD that is in draft
                            LogPositionFactors(PDStatus.Draft, currentTransaction); //log the language that is in draft
                            LogPositionDuties(PDStatus.Draft, userid, currentTransaction); //Log the Duties in Draft Status to the Log Table for Diff Compare
                            LogPositionCompetencyKSA(PDStatus.Draft, userid, currentTransaction); //Log Postion Competency KSA in Draft status
                        }
                        else if (currentStatus == PDStatus.Revise) //status is going to change to revise
                        {
                            LogPositionDescription(PDStatus.Review, userid, currentTransaction);//Log PD that is review
                            LogPositionDuties(PDStatus.Review, userid, currentTransaction); //Log the Duties in Draft Status to the Log Table for Diff Compare
                            LogPositionCompetencyKSA(PDStatus.Review, userid, currentTransaction); //Log Postion Competency KSA in Review status
                        }
                        SetPositionCurrentStatus(currentStatus, userid, currentTransaction);

                        currentTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (currentTransaction.IsOpen)
                            currentTransaction.Rollback();
                        HandleException(ex);
                    }
                }
                else
                {
                    SetPositionCurrentStatus(currentStatus, userid);
                }
            }

        }

        #region PositionFactorLog

        public void LogPositionFactors(PDStatus workflowStausID, TransactionManager currentTransaction)
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_LogPositionFactors");
                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusID", (int)workflowStausID));
                    commandWrapper.Parameters.Add(new SqlParameter("@FactorFormatTypeID", DBNull.Value));
                    if (currentTransaction != null)
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    else
                        ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }
        public void LogPositionFactors(PDStatus workflowStatusID)
        {
            LogPositionFactors(workflowStatusID, null);
        }

        #endregion


        #region PositionDutyLog

        public void LogPositionDuties(PDStatus workflowStausID, int createdBy, TransactionManager currentTransaction)
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_LogPositionDuties");
                try
                {
                    DateTime createdDate = DateTime.Now;

                    commandWrapper.Parameters.Add(new SqlParameter("@PositionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusID", (int)workflowStausID));
                    commandWrapper.Parameters.Add(new SqlParameter("@LogRecCreateDate", createdDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@LogRecCreatedByID", createdBy));

                    if (currentTransaction != null)
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    else
                        ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void LogPositionDuties(PDStatus workflowStatusID, int createdBy)
        {
            LogPositionDuties(workflowStatusID, createdBy, null);
        }

        public void AcceptAllDutyDiffs()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();

                DbCommand commandWrapper = GetDbCommand("spr_AcceptAllDutyDiffs");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionDescriptionID", this._positionDescriptionID));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedDate", this._updateDate));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }
                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }

        public void RejectAllDutyDiffs()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();

                DbCommand commandWrapper = GetDbCommand("spr_RejectAllDutyDiffs");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionDescriptionID", this._positionDescriptionID));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedDate", this._updateDate));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }
                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }

        public void SaveDutyDiffChanges(string dutyDiffXML)
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();

                DbCommand commandWrapper = GetDbCommand("spr_SaveDutyDiffChanges");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@DutyDiffXML", dutyDiffXML));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedDate", this._updateDate));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }
                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region "Changes related to Review Permission To HR"

        public void LogPositionDescription(PDStatus workflowStatusID, int createdBy, TransactionManager currentTransaction)
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_LogPositionDescriptionLog");
                try
                {
                    DateTime createdDate = DateTime.Now;

                    commandWrapper.Parameters.Add(new SqlParameter("@PositionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusID", (int)workflowStatusID));
                    commandWrapper.Parameters.Add(new SqlParameter("@LogRecCreateDate", createdDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@LogRecCreatedByID", createdBy));

                    if (currentTransaction != null)
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    else
                        ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void LogPositionDescription(PDStatus workflowStatusID, int createdBy)
        {
            LogPositionDescription(workflowStatusID, createdBy, null);
        }

        public void AcceptAllOccupationDiffs()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();

                DbCommand commandWrapper = GetDbCommand("spr_AcceptAllOccupationDiffs");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionDescriptionID", this._positionDescriptionID));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedDate", this._updateDate));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }
                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }

        public void RejectAllOccupationDiffs()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();

                DbCommand commandWrapper = GetDbCommand("spr_RejectAllOccupationDiffs");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionDescriptionID", this._positionDescriptionID));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedDate", this._updateDate));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }
                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }

        public void SelectiveUpdateOccupationDiffs()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();

                DbCommand commandWrapper = GetDbCommand("spr_SaveOccupationAcceptsRejectsInRevise");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@JobSeries", this._jobSeries));
                    commandWrapper.Parameters.Add(new SqlParameter("@ProposedGrade", this._proposedGrade));
                    commandWrapper.Parameters.Add(new SqlParameter("@ProposedFPGrade", this._proposedFPGrade));
                    commandWrapper.Parameters.Add(new SqlParameter("@OPMJobTitle", this._oPMJobTitle));
                    commandWrapper.Parameters.Add(new SqlParameter("@AgencyPositionTitle", this._agencyPositionTitle));
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionTypeID", this._positionTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCodeID", this._organizationCodeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@IsInterdisciplinaryPD", this._isInterdisciplinaryPD));
                    commandWrapper.Parameters.Add(new SqlParameter("@AdditionalSeries", this._additionalSeries));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedDate", this._updateDate));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }
                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }
        #endregion

        #region PositionCompetencyKSALog

        public void LogPositionCompetencyKSA(PDStatus workflowStausID, int createdBy, TransactionManager currentTransaction)
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_LogPositionDescriptionQualifications");
                try
                {
                    DateTime createdDate = DateTime.Now;

                    commandWrapper.Parameters.Add(new SqlParameter("@PositionDescriptionID", this._positionDescriptionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@WorkflowStatusID", (int)workflowStausID));
                    commandWrapper.Parameters.Add(new SqlParameter("@LogRecCreateDate", createdDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@LogRecCreatedByID", createdBy));

                    if (currentTransaction != null)
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    else
                        ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void LogPositionCompetencyKSA(PDStatus workflowStatusID, int createdBy)
        {
            LogPositionCompetencyKSA(workflowStatusID, createdBy, null);
        }

        public void SavePositionDescriptionDiffChanges(string PDDiffXML)
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();

                DbCommand commandWrapper = GetDbCommand("spr_SavePositionQualificationDiffChanges");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@PDQualificationDiffXML", PDDiffXML));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedDate", this._updateDate));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }
                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }

        public void RejectAllPositionCompetencyKSADiffs()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();

                DbCommand commandWrapper = GetDbCommand("spr_RejectAllPositionQualificationDiffs");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionDescriptionID", this._positionDescriptionID));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedDate", this._updateDate));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }
                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }

        public void AcceptAllPositionCompetencyKSADiffs()
        {
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
                currentTransaction.BeginTransaction();

                DbCommand commandWrapper = GetDbCommand("spr_AcceptAllPositionQualificationDiffs");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@PositionDescriptionID", this._positionDescriptionID));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this._updatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedDate", this._updateDate));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }
                    currentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    if (currentTransaction.IsOpen)
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }

        #endregion

        #endregion

        #region [ Collection Helper Methods ]

        internal static PositionDescriptionCollection GetCollection(DataTable dataItems)
        {
            PositionDescriptionCollection listCollection = new PositionDescriptionCollection();
            PositionDescription current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PositionDescription(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PositionDescription collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region [ Collection Methods ]

        public UserCollection GetAssignedSupervisors()
        {
            UserCollection childDataCollection = null;

            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetAssignedPDSupervisors", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = User.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        //public List<PositionJobAnalysis> GetPositionJobAnalysis()
        //{
        //    List<PositionJobAnalysis> childDataCollection = null;
        //    if (base.ValidateKeyField(this._positionDescriptionID))
        //    {
        //        try
        //        {
        //            DataTable dt = ExecuteDataTable("spr_GetPositionJobAnalysisByPositionDescriptionID", this._positionDescriptionID);

        //            // fill collection list
        //            childDataCollection = PositionJobAnalysis.GetCollection(dt);
        //        }
        //        catch (Exception ex)
        //        {
        //            HandleException(ex);
        //        }
        //    }

        //    return childDataCollection;
        //}

        public List<PositionCompetencyKSA> GetPositionCompetencyKSA()
        {
            List<PositionCompetencyKSA> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetPositionCompetencyKSAByPositionDescriptionID", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionCompetencyKSA.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<PositionDuty> GetPositionDuty()
        {
            List<PositionDuty> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetPositionDutyByPositionDescriptionID", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionDuty.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<PositionFactor> GetPositionFactor()
        {
            List<PositionFactor> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetPositionFactorByPositionDescriptionID", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionFactor.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<PositionFactor> GetNonReviewedPostionFactors()
        {
            List<PositionFactor> positionfactors = GetPositionFactor();
            List<PositionFactor> nonreviewedpfs = new List<PositionFactor>();
            foreach (PositionFactor pf in positionfactors)
            {

                if (pf.RecommendationNote.Length > 0 && pf.Reviewed.HasValue)
                {
                    bool reviewed = (bool)pf.Reviewed;
                    if (!reviewed)
                    {

                        nonreviewedpfs.Add(pf);
                    }
                }
            }
            return nonreviewedpfs;
        }
        public List<PositionFactor> GetPositionFactorBySeriesGrade(enumFactorFormatType factorformattypeid, int userid)
        {
            List<PositionFactor> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetPositionFactorBySeriesGradeFactorFormatType", this._positionDescriptionID, this._jobSeries, this._proposedGrade, (int)factorformattypeid, userid);

                    // fill collection list
                    childDataCollection = PositionFactor.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public static string GetFirstPositionFactorLanguage(long JNPID)
        {
            string FirstFactor = "";
            try
            {
                DataTable dt = ExecuteDataTable("spr_GetFirstPositionFactorLanguageByJNPID", JNPID);

                FirstFactor = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return FirstFactor;
        }

        public List<PositionFactorLog> GetPositionFactorLog(PDStatus workflowstatusID)
        {
            List<PositionFactorLog> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetPositionFactorLogForAStatus", this._positionDescriptionID, (int)workflowstatusID);

                    // fill collection list
                    childDataCollection = PositionFactorLog.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<SeriesGradeFesFactorLevelPoints> GetSeriesGradeFesFactorLevelPoints()
        {
            List<SeriesGradeFesFactorLevelPoints> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetSeriesGradeFesFactorLevelPoints", this._jobSeries, this._proposedGrade);

                    // fill collection list
                    childDataCollection = SeriesGradeFesFactorLevelPoints.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<SeriesGradeFesFactorLevelPoints> GetSeriesGradeFesFactorLevelPointsByFactorID(int factorid)
        {
            List<SeriesGradeFesFactorLevelPoints> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetSeriesFESFactorLevelPointsByFactorID", this._jobSeries, factorid);

                    // fill collection list
                    childDataCollection = SeriesGradeFesFactorLevelPoints.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;

        }

        public List<SeriesFesFactorLevelLanguage> GetSeriesFesFactorLevelLanguageByFactorID(int factorid)
        {
            List<SeriesFesFactorLevelLanguage> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetSeriesFesFactorLevelLanguageByFactorID", this._jobSeries, factorid);

                    // fill collection list
                    childDataCollection = SeriesFesFactorLevelLanguage.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;

        }

        public List<SeriesGSSGFactorLevelLanguage> GetSeriesGSSGFactorLevelLanguageByFactorID(int factorid)
        {
            List<SeriesGSSGFactorLevelLanguage> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetSeriesGSSGFactorLevelLanguageByFactorID", this._jobSeries, factorid);

                    // fill collection list
                    childDataCollection = SeriesGSSGFactorLevelLanguage.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;

        }

        public List<ISeriesFactorLevelLanguage> GetSeriesFactorLevelLanguageByFactorID(ISeriesFactorLevelLanguage seriesfactorlevellanguage, int factorid)
        {
            List<ISeriesFactorLevelLanguage> retval = new List<ISeriesFactorLevelLanguage>();
            if (seriesfactorlevellanguage is SeriesFesFactorLevelLanguage)
            {
                retval = GetSeriesFesFactorLevelLanguageByFactorID(factorid).ConvertAll<ISeriesFactorLevelLanguage>(
                 delegate(SeriesFesFactorLevelLanguage factorlevellanguage)
                 {
                     return factorlevellanguage;
                 });


            }
            else if (seriesfactorlevellanguage is SeriesGSSGFactorLevelLanguage)
            {
                retval = GetSeriesGSSGFactorLevelLanguageByFactorID(factorid).ConvertAll<ISeriesFactorLevelLanguage>(
                 delegate(SeriesGSSGFactorLevelLanguage factorlevellanguage)
                 {
                     return factorlevellanguage;
                 });
            }

            return retval;
        }

        public PositionWorkflowStatusCollection GetPositionWorkflowStatus()
        {
            PositionWorkflowStatusCollection childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetPositionWorkflowStatusByPositionDescriptionID", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionWorkflowStatus.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<PositionClassificationStandard> GetPositionClassificationStandard()
        {

            List<PositionClassificationStandard> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetPositionClassificationStandard", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionClassificationStandard.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<PositionEvalCriteria> GetPositionEvalCriteria()
        {
            List<PositionEvalCriteria> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetPositionEvalCriteriaByPositionDescriptionID", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionEvalCriteria.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;

        }
        public List<WorkflowNote> GetPositonWorkflowNotes()
        {

            List<WorkflowNote> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("dbo.spr_GetWorkflowNoteByPositionDescriptionID", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = WorkflowNote.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;

        }
        public List<WorkflowNote> GetPositionNonClosedNotes()
        {
            List<WorkflowNote> PositionWorkflowNotes = GetPositonWorkflowNotes();
            List<WorkflowNote> nonclosedwfns = new List<WorkflowNote>();
            if (PositionWorkflowNotes.Count > 0)
            {
                foreach (WorkflowNote currentwn in PositionWorkflowNotes)
                {
                    if (currentwn.NoteStatus != WorkflowNoteStatus.Closed.ToString())
                    {
                        nonclosedwfns.Add(currentwn);
                    }
                }


            }
            return nonclosedwfns;
        }
        public PositionDescriptionCollection GetAssociatedCareerLadderPositionDescriptions()
        {
            PositionDescriptionCollection childDataCollection = null;

            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetCareerLadderPositionDescriptionsByPD", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionDescription.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        #region PositionDescriptonLog
        public DataTable GetPositionDescriptionLogReviewEdits()
        {
            DataTable returnTable = null;

            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    returnTable = ExecuteDataTable("dbo.spr_GetPositionDescriptionLogReviewEdits", this._positionDescriptionID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return returnTable;
        }

        #endregion

        #region PositionDutyLog

        public DataTable GetPositionDutiesModifiedDuringReview()
        {
            DataTable returnTable = null;

            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    returnTable = ExecuteDataTable("dbo.spr_GetPositionDutiesModifiedDuringReview", this._positionDescriptionID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return returnTable;
        }

        public List<PositionDutyLog> GetPositionDutiesAddedDuringReview()
        {
            List<PositionDutyLog> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("dbo.spr_GetPositionDutiesAddedDuringReview", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionDutyLog.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<PositionDutyLog> GetDeletedDraftPositionDuties()
        {
            List<PositionDutyLog> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("dbo.spr_GetDeletedDraftPositionDuties", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionDutyLog.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        #endregion

        #region PositionCompetencyKSALog

        public DataTable GetPositionCompetencyKSAModifiedDuringReview()
        {
            DataTable returnTable = null;

            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    returnTable = ExecuteDataTable("dbo.spr_GetEditedReviewPositionQualifications", this._positionDescriptionID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return returnTable;
        }

        public List<PositionCompetencyKSALog> GetPositionCompetencyKSAAddedDuringReview()
        {
            List<PositionCompetencyKSALog> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("dbo.spr_GetAddedReviewPositionQualifications", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionCompetencyKSALog.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<PositionCompetencyKSALog> GetPositionCompetencyKSADeletedDuringReview()
        {
            List<PositionCompetencyKSALog> childDataCollection = null;
            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("dbo.spr_GetDeletedDraftPositionQualifications", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionCompetencyKSALog.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        #endregion

        #endregion

        #region Database related
        public Database GetCurrentDB()
        {
            return base.CurrentDatabase;
        }
        #endregion

        #region [ WorkflowStatus Related Methods ]

        public PositionWorkflowStatus GetCurrentPositionWorkflowStatus()
        {
            PositionWorkflowStatus workStatus = null;

            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                PositionWorkflowStatusCollection pdStatusList = this.GetPositionWorkflowStatus();

                if (pdStatusList != null && pdStatusList.Count > 0)
                    workStatus = pdStatusList.FindCurrent();
            }

            return workStatus;
        }

        public PDStatus GetCurrentPDStatus()
        {
            PDStatus currentstatus = PDStatus.Null;

            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                PositionWorkflowStatus currentPositionWorkflowStatus = this.GetCurrentPositionWorkflowStatus();

                if (currentPositionWorkflowStatus != null)
                    currentstatus = (PDStatus)currentPositionWorkflowStatus.WorkflowStatusID;
            }

            return currentstatus;
        }

        #endregion

        #region [ Check out / Check in Related Methods ]
        // if the PD is not checked out, can the current user check it out?
        public bool CanCheckOut(int currentUserID)
        {
            bool currUserCanCheckOut = true;
            return !IsCheckedOut && currUserCanCheckOut;
        }

        // if the PD is checked out, can the current user check it in (the PD might be checked ot by another person than current user)?
        public bool CanCheckIn(int currentUserID)
        {
            bool currUserCanCheckIn = true;
            return IsCheckedOut && currUserCanCheckIn;
        }

        public void CheckOut(int checkedOutByID)
        {
            TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
            currentTransaction.BeginTransaction();

            DbCommand commandWrapper = GetDbCommand("spr_CheckOutPositionDescriptionByID");

            try
            {
                DateTime checkOutDate = DateTime.Now;

                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@checkedOutByID", checkedOutByID));
                commandWrapper.Parameters.Add(new SqlParameter("@checkOutDate", checkOutDate));

                DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);

                currentTransaction.Commit();

                this._checkedOutByID = checkedOutByID;
                this._checkOutDate = checkOutDate;
                this._checkedInByID = -1;
                this._checkInDate = DateTime.MinValue;
            }
            catch (Exception ex)
            {
                currentTransaction.Rollback();
                HandleException(ex);
            }
        }


        public void CheckIn(int checkInByID, TransactionManager currentTransaction)
        {
            DbCommand commandWrapper = GetDbCommand("spr_CheckInPositionDescriptionByID");

            try
            {
                DateTime checkInDate = DateTime.Now;

                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@checkedInByID", checkInByID));
                commandWrapper.Parameters.Add(new SqlParameter("@checkInDate", checkInDate));
                if (currentTransaction != null)
                {
                    DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    currentTransaction.Commit();
                }
                else
                {
                    ExecuteNonQuery(commandWrapper);

                }


                this._checkedOutByID = -1;
                this._checkOutDate = checkInDate;
                this._checkedInByID = checkInByID;
                this._checkInDate = DateTime.Now;

            }
            catch (Exception ex)
            {
                if (currentTransaction != null)
                    currentTransaction.Rollback();
                HandleException(ex);
            }
        }
        public void CheckIn(int checkInByID)
        {
            CheckIn(checkInByID, null);

        }


        #region CL Checkin

        public void AddFromExistingCLBundle(long copyFromPDID)
        {
            if (copyFromPDID != -1)
            {
                DbCommand commandWrapper = GetDbCommand("spr_CreateCLForExistingPD");

                try
                {
                    SqlParameter returnParam = new SqlParameter("@newFullPDID", SqlDbType.BigInt);
                    returnParam.Direction = ParameterDirection.Output;

                    // get the new PositionDescriptionID of the record
                    commandWrapper.Parameters.Add(returnParam);

                    commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDID", copyFromPDID));
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._pDCreatorID));

                    ExecuteNonQuery(commandWrapper);

                    long newPDID = (long)returnParam.Value;

                    if (newPDID == -1)
                        throw new BusinessException("PD Express could not create a copy of the selected CL position description.");
                    else
                        this._positionDescriptionID = newPDID;
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
            else
                HandleException(new Exception("You must specify a valid position description ID before attempting to copy."));
        }

        public void CheckOutCareerLadder(int checkedOutByID)
        {
            TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
            currentTransaction.BeginTransaction();

            DbCommand commandWrapper = GetDbCommand("spr_CheckOutCareerLadderByID");

            try
            {
                DateTime checkOutDate = DateTime.Now;

                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@checkedOutByID", checkedOutByID));
                commandWrapper.Parameters.Add(new SqlParameter("@checkOutDate", checkOutDate));

                DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);

                currentTransaction.Commit();

                this._checkedOutByID = checkedOutByID;
                this._checkOutDate = checkOutDate;
                this._checkedInByID = -1;
                this._checkInDate = DateTime.MinValue;
            }
            catch (Exception ex)
            {
                currentTransaction.Rollback();
                HandleException(ex);
            }
        }

        public void CheckInCareerLadder(int checkInByID)
        {
            TransactionManager currentTransaction = new TransactionManager(base.CurrentDatabase);
            currentTransaction.BeginTransaction();

            DbCommand commandWrapper = GetDbCommand("spr_CheckInCareerLadderByID");

            try
            {
                DateTime checkInDate = DateTime.Now;

                commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", this._positionDescriptionID));
                commandWrapper.Parameters.Add(new SqlParameter("@checkedInByID", checkInByID));
                commandWrapper.Parameters.Add(new SqlParameter("@checkInDate", checkInDate));

                DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);

                currentTransaction.Commit();

                this._checkedOutByID = -1;
                this._checkOutDate = checkInDate;
                this._checkedInByID = checkInByID;
                this._checkInDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                currentTransaction.Rollback();
                HandleException(ex);
            }
        }

        public PositionDescriptionCollection GetOtherCareerLadderPositionDescriptions()
        {
            PositionDescriptionCollection childDataCollection = null;

            if (base.ValidateKeyField(this._positionDescriptionID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetOtherLadderPDsByPD", this._positionDescriptionID);

                    // fill collection list
                    childDataCollection = PositionDescription.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        #endregion

        #endregion
    }
}

