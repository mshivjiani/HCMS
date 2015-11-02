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

namespace HCMS.Business.LogObjects
{
    /// <summary>
    /// PositionDescriptionLog Business Object
    /// </summary>
    [Serializable]
    public class PositionDescriptionLog : BusinessBase
    {
        #region Private Members

        private long _positionDescriptionLogID = -1;
        private long _positionDescriptionID = -1;
        private string _isStandardPD = string.Empty;
        private int _positionDescriptionTypeID = -1;
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
        private string _dutyLocation = string.Empty;
        private string _remarks = string.Empty;
        private string _deptAgencyEstablishment = string.Empty;
        private string _firstSubdivision = string.Empty;
        private string _secondSubdivision = string.Empty;
        private int _organizationCodeID = -1;
        private string _fourthSubdivision = string.Empty;
        private string _fifthSubdivision = string.Empty;
        private string _payPlanJustification = string.Empty;
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
        private int _careerLadderPDTypeID = -1;
        private int _checkedOutByID = -1;
        private DateTime _checkOutDate = DateTime.MinValue;
        private int _checkedInByID = -1;
        private DateTime _checkInDate = DateTime.MinValue;
        private string _employingOfficeLocation = string.Empty;
        private string _titleJustification = string.Empty;
        private bool _highGradeApproval = false;
        private string _supervisorOrgTitle = string.Empty;
        private string _additionalSupOrgTitle = string.Empty;
        private long _copyFromPDID = -1;
        private int _copyFromPDIDByUserID = -1;
        private DateTime _copyFromPDIDDate = DateTime.MinValue;
        private string _evaluatorOrgTitle = string.Empty;
        private string _classifierOrgTitle = string.Empty;
        private string _isAGoodPD = string.Empty;
        private bool _isInterdisciplinaryPD = false;
        private string _additionalSeries = string.Empty;
        private int _hCOID = -1;
        private string _hCOFullName = string.Empty;
        private DateTime _hCOSignDate = DateTime.MinValue;
        private int _aDBPHCID = -1;
        private DateTime _aDBPHCConfirmDate = DateTime.MinValue;
        private int _directorID = -1;
        private DateTime _directorConfirmationDate = DateTime.MinValue;
        private string _hCOOrgTitle = string.Empty;
        private int _workflowStatusID = -1;
        private DateTime _logRecCreateDate = DateTime.MinValue;
        private int _logRecCreatedByID = -1;

        #endregion

        #region Properties

        public long PositionDescriptionLogID
        {
            get
            {
                return this._positionDescriptionLogID;
            }
            set
            {
                this._positionDescriptionLogID = value;
            }
        }

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

        public int CheckedOutByID
        {
            get
            {
                return this._checkedOutByID;
            }
            set
            {
                this._checkedOutByID = value;
            }
        }

        public DateTime CheckOutDate
        {
            get
            {
                return this._checkOutDate;
            }
            set
            {
                this._checkOutDate = value;
            }
        }

        public int CheckedInByID
        {
            get
            {
                return this._checkedInByID;
            }
            set
            {
                this._checkedInByID = value;
            }
        }

        public DateTime CheckInDate
        {
            get
            {
                return this._checkInDate;
            }
            set
            {
                this._checkInDate = value;
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

        public bool HighGradeApproval
        {
            get
            {
                return this._highGradeApproval;
            }
            set
            {
                this._highGradeApproval = value;
            }
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
            set
            {
                this._copyFromPDID = value;
            }
        }

        public int CopyFromPDIDByUserID
        {
            get
            {
                return this._copyFromPDIDByUserID;
            }
            set
            {
                this._copyFromPDIDByUserID = value;
            }
        }

        public DateTime CopyFromPDIDDate
        {
            get
            {
                return this._copyFromPDIDDate;
            }
            set
            {
                this._copyFromPDIDDate = value;
            }
        }

        public string EvaluatorOrgTitle
        {
            get
            {
                return this._evaluatorOrgTitle;
            }
            set
            {
                this._evaluatorOrgTitle = value;
            }
        }

        public string ClassifierOrgTitle
        {
            get
            {
                return this._classifierOrgTitle;
            }
            set
            {
                this._classifierOrgTitle = value;
            }
        }

        public string IsAGoodPD
        {
            get
            {
                return this._isAGoodPD;
            }
            set
            {
                this._isAGoodPD = value;
            }
        }

        public bool IsInterdisciplinaryPD
        {
            get
            {
                return this._isInterdisciplinaryPD;
            }
            set
            {
                this._isInterdisciplinaryPD = value;
            }
        }

        public string AdditionalSeries
        {
            get
            {
                return this._additionalSeries;
            }
            set
            {
                this._additionalSeries = value;
            }
        }

        public int HCOID
        {
            get
            {
                return this._hCOID;
            }
            set
            {
                this._hCOID = value;
            }
        }

        public string HCOFullName
        {
            get
            {
                return this._hCOFullName;
            }
            set
            {
                this._hCOFullName = value;
            }
        }

        public DateTime HCOSignDate
        {
            get
            {
                return this._hCOSignDate;
            }
            set
            {
                this._hCOSignDate = value;
            }
        }

        public int ADBPHCID
        {
            get
            {
                return this._aDBPHCID;
            }
            set
            {
                this._aDBPHCID = value;
            }
        }

        public DateTime ADBPHCConfirmDate
        {
            get
            {
                return this._aDBPHCConfirmDate;
            }
            set
            {
                this._aDBPHCConfirmDate = value;
            }
        }

        public int DirectorID
        {
            get
            {
                return this._directorID;
            }
            set
            {
                this._directorID = value;
            }
        }

        public DateTime DirectorConfirmationDate
        {
            get
            {
                return this._directorConfirmationDate;
            }
            set
            {
                this._directorConfirmationDate = value;
            }
        }

        public string HCOOrgTitle
        {
            get
            {
                return this._hCOOrgTitle;
            }
            set
            {
                this._hCOOrgTitle = value;
            }
        }

        public int WorkflowStatusID
        {
            get
            {
                return this._workflowStatusID;
            }
            set
            {
                this._workflowStatusID = value;
            }
        }

        public DateTime LogRecCreateDate
        {
            get
            {
                return this._logRecCreateDate;
            }
            set
            {
                this._logRecCreateDate = value;
            }
        }

        public int LogRecCreatedByID
        {
            get
            {
                return this._logRecCreatedByID;
            }
            set
            {
                this._logRecCreatedByID = value;
            }
        }

        #endregion

        #region Constructors

        public PositionDescriptionLog()
        {
            // Empty Constructor
        }

        public PositionDescriptionLog(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionDescriptionLogByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public PositionDescriptionLog(int PDID, int workflowStatusID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetPositionDescriptionLogByPositionDescriptionID", PDID, workflowStatusID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public PositionDescriptionLog(DataRow singleRowData)
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
            this._positionDescriptionLogID = (long)returnRow["PositionDescriptionLogID"];
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

            if (returnRow["PositionStatusTypeID"] != DBNull.Value)
                this._positionStatusTypeID = (int)returnRow["PositionStatusTypeID"];


            if (returnRow["PositionStatusTypeRemark"] != DBNull.Value)
                this._positionStatusTypeRemark = returnRow["PositionStatusTypeRemark"].ToString();

            if (returnRow["PositionSensitivityTypeID"] != DBNull.Value)
                this._positionSensitivityTypeID = (int)returnRow["PositionSensitivityTypeID"];


            if (returnRow["CompetitiveLevelCode"] != DBNull.Value)
                this._competitiveLevelCode = returnRow["CompetitiveLevelCode"].ToString();

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
                this._bargainingUnitStatus = returnRow["BargainingUnitStatus"].ToString();

            if (returnRow["ReasonForSubmissionID"] != DBNull.Value)
                this._reasonForSubmissionID = (int)returnRow["ReasonForSubmissionID"];


            if (returnRow["ServiceID"] != DBNull.Value)
                this._serviceID = (int)returnRow["ServiceID"];


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


            if (returnRow["FourthSubdivision"] != DBNull.Value)
                this._fourthSubdivision = returnRow["FourthSubdivision"].ToString();

            if (returnRow["FifthSubdivision"] != DBNull.Value)
                this._fifthSubdivision = returnRow["FifthSubdivision"].ToString();

            if (returnRow["PayPlanJustification"] != DBNull.Value)
                this._payPlanJustification = returnRow["PayPlanJustification"].ToString();

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

            if (returnRow["CareerLadderPDTypeID"] != DBNull.Value)
                this._careerLadderPDTypeID = (int)returnRow["CareerLadderPDTypeID"];


            if (returnRow["CheckedOutByID"] != DBNull.Value)
                this._checkedOutByID = (int)returnRow["CheckedOutByID"];


            if (returnRow["CheckOutDate"] != DBNull.Value)
                this._checkOutDate = (DateTime)returnRow["CheckOutDate"];


            if (returnRow["CheckedInByID"] != DBNull.Value)
                this._checkedInByID = (int)returnRow["CheckedInByID"];


            if (returnRow["CheckInDate"] != DBNull.Value)
                this._checkInDate = (DateTime)returnRow["CheckInDate"];


            if (returnRow["EmployingOfficeLocation"] != DBNull.Value)
                this._employingOfficeLocation = returnRow["EmployingOfficeLocation"].ToString();

            if (returnRow["TitleJustification"] != DBNull.Value)
                this._titleJustification = returnRow["TitleJustification"].ToString();

            if (returnRow["HighGradeApproval"] != DBNull.Value)
                this._highGradeApproval = (bool)returnRow["HighGradeApproval"];


            if (returnRow["SupervisorOrgTitle"] != DBNull.Value)
                this._supervisorOrgTitle = returnRow["SupervisorOrgTitle"].ToString();

            if (returnRow["AdditionalSupOrgTitle"] != DBNull.Value)
                this._additionalSupOrgTitle = returnRow["AdditionalSupOrgTitle"].ToString();

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

            if (returnRow["IsAGoodPD"] != DBNull.Value)
                this._isAGoodPD = returnRow["IsAGoodPD"].ToString();

            if (returnRow["IsInterdisciplinaryPD"] != DBNull.Value)
                this._isInterdisciplinaryPD = (bool)returnRow["IsInterdisciplinaryPD"];


            if (returnRow["AdditionalSeries"] != DBNull.Value)
                this._additionalSeries = returnRow["AdditionalSeries"].ToString();

            if (returnRow["HCOID"] != DBNull.Value)
                this._hCOID = (int)returnRow["HCOID"];


            if (returnRow["HCOFullName"] != DBNull.Value)
                this._hCOFullName = returnRow["HCOFullName"].ToString();

            if (returnRow["HCOSignDate"] != DBNull.Value)
                this._hCOSignDate = (DateTime)returnRow["HCOSignDate"];


            if (returnRow["ADBPHCID"] != DBNull.Value)
                this._aDBPHCID = (int)returnRow["ADBPHCID"];


            if (returnRow["ADBPHCConfirmDate"] != DBNull.Value)
                this._aDBPHCConfirmDate = (DateTime)returnRow["ADBPHCConfirmDate"];


            if (returnRow["DirectorID"] != DBNull.Value)
                this._directorID = (int)returnRow["DirectorID"];


            if (returnRow["DirectorConfirmationDate"] != DBNull.Value)
                this._directorConfirmationDate = (DateTime)returnRow["DirectorConfirmationDate"];


            if (returnRow["HCOOrgTitle"] != DBNull.Value)
                this._hCOOrgTitle = returnRow["HCOOrgTitle"].ToString();

            if (returnRow["WorkflowStatusID"] != DBNull.Value)
                this._workflowStatusID = (int)returnRow["WorkflowStatusID"];


            if (returnRow["LogRecCreateDate"] != DBNull.Value)
                this._logRecCreateDate = (DateTime)returnRow["LogRecCreateDate"];


            if (returnRow["LogRecCreatedByID"] != DBNull.Value)
                this._logRecCreatedByID = (int)returnRow["LogRecCreatedByID"];

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
            return "PositionDescriptionLogID:" + PositionDescriptionLogID.ToString();
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
            PositionDescriptionLog PositionDescriptionLogobj = obj as PositionDescriptionLog;

            return (PositionDescriptionLogobj == null) ? false : (this.PositionDescriptionLogID == PositionDescriptionLogobj.PositionDescriptionLogID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return PositionDescriptionLogID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddPositionDescriptionLog");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newPositionDescriptionLogID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new PositionDescriptionLogID of the record
                commandWrapper.Parameters.Add(returnParam);

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
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierID", this._classifierID));
                commandWrapper.Parameters.Add(new SqlParameter("@classifierFullName", this._classifierFullName));

                if (this._classifierSignDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierSignDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierSignDate", this._classifierSignDate));
                commandWrapper.Parameters.Add(new SqlParameter("@pDCreatorID", this._pDCreatorID));

                if (this._associatedFullPD == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@associatedFullPD", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@associatedFullPD", this._associatedFullPD));

                if (this._ladderPosition == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@ladderPosition", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@ladderPosition", this._ladderPosition));
                commandWrapper.Parameters.Add(new SqlParameter("@paragraphOneText", this._paragraphOneText));
                commandWrapper.Parameters.Add(new SqlParameter("@paragraphTwoText", this._paragraphTwoText));
                commandWrapper.Parameters.Add(new SqlParameter("@paragraphThreeText", this._paragraphThreeText));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
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

                if (this._publishedID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@publishedID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@publishedID", this._publishedID));
                commandWrapper.Parameters.Add(new SqlParameter("@fPPSPDID", this._fPPSPDID));

                if (this._careerLadderPDTypeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@careerLadderPDTypeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@careerLadderPDTypeID", this._careerLadderPDTypeID));

                if (this._checkedOutByID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@checkedOutByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@checkedOutByID", this._checkedOutByID));

                if (this._checkOutDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@checkOutDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@checkOutDate", this._checkOutDate));

                if (this._checkedInByID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@checkedInByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@checkedInByID", this._checkedInByID));

                if (this._checkInDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@checkInDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@checkInDate", this._checkInDate));
                commandWrapper.Parameters.Add(new SqlParameter("@employingOfficeLocation", this._employingOfficeLocation));
                commandWrapper.Parameters.Add(new SqlParameter("@titleJustification", this._titleJustification));
                commandWrapper.Parameters.Add(new SqlParameter("@highGradeApproval", this._highGradeApproval));
                commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", this._supervisorOrgTitle));
                commandWrapper.Parameters.Add(new SqlParameter("@additionalSupOrgTitle", this._additionalSupOrgTitle));

                if (this._copyFromPDID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDID", this._copyFromPDID));

                if (this._copyFromPDIDByUserID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDIDByUserID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDIDByUserID", this._copyFromPDIDByUserID));

                if (this._copyFromPDIDDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDIDDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDIDDate", this._copyFromPDIDDate));
                commandWrapper.Parameters.Add(new SqlParameter("@evaluatorOrgTitle", this._evaluatorOrgTitle));
                commandWrapper.Parameters.Add(new SqlParameter("@classifierOrgTitle", this._classifierOrgTitle));
                commandWrapper.Parameters.Add(new SqlParameter("@isAGoodPD", this._isAGoodPD));
                commandWrapper.Parameters.Add(new SqlParameter("@isInterdisciplinaryPD", this._isInterdisciplinaryPD));
                commandWrapper.Parameters.Add(new SqlParameter("@additionalSeries", this._additionalSeries));

                if (this._hCOID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@hCOID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@hCOID", this._hCOID));
                commandWrapper.Parameters.Add(new SqlParameter("@hCOFullName", this._hCOFullName));

                if (this._hCOSignDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@hCOSignDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@hCOSignDate", this._hCOSignDate));

                if (this._aDBPHCID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@aDBPHCID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@aDBPHCID", this._aDBPHCID));

                if (this._aDBPHCConfirmDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@aDBPHCConfirmDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@aDBPHCConfirmDate", this._aDBPHCConfirmDate));

                if (this._directorID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@directorID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@directorID", this._directorID));

                if (this._directorConfirmationDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@directorConfirmationDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@directorConfirmationDate", this._directorConfirmationDate));
                commandWrapper.Parameters.Add(new SqlParameter("@hCOOrgTitle", this._hCOOrgTitle));

                if (this._workflowStatusID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@workflowStatusID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@workflowStatusID", this._workflowStatusID));

                if (this._logRecCreateDate == DateTime.MinValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@logRecCreateDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@logRecCreateDate", this._logRecCreateDate));

                if (this._logRecCreatedByID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@logRecCreatedByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@logRecCreatedByID", this._logRecCreatedByID));

                ExecuteNonQuery(commandWrapper);

                this._positionDescriptionLogID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._positionDescriptionLogID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdatePositionDescriptionLog");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionLogID", this._positionDescriptionLogID));
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
                        commandWrapper.Parameters.Add(new SqlParameter("@classifierID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@classifierID", this._classifierID));
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierFullName", this._classifierFullName));

                    if (this._classifierSignDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@classifierSignDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@classifierSignDate", this._classifierSignDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@pDCreatorID", this._pDCreatorID));

                    if (this._associatedFullPD == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@associatedFullPD", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@associatedFullPD", this._associatedFullPD));

                    if (this._ladderPosition == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@ladderPosition", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ladderPosition", this._ladderPosition));
                    commandWrapper.Parameters.Add(new SqlParameter("@paragraphOneText", this._paragraphOneText));
                    commandWrapper.Parameters.Add(new SqlParameter("@paragraphTwoText", this._paragraphTwoText));
                    commandWrapper.Parameters.Add(new SqlParameter("@paragraphThreeText", this._paragraphThreeText));
                    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
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

                    if (this._publishedID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@publishedID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@publishedID", this._publishedID));
                    commandWrapper.Parameters.Add(new SqlParameter("@fPPSPDID", this._fPPSPDID));

                    if (this._careerLadderPDTypeID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@careerLadderPDTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@careerLadderPDTypeID", this._careerLadderPDTypeID));

                    if (this._checkedOutByID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@checkedOutByID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@checkedOutByID", this._checkedOutByID));

                    if (this._checkOutDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@checkOutDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@checkOutDate", this._checkOutDate));

                    if (this._checkedInByID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@checkedInByID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@checkedInByID", this._checkedInByID));

                    if (this._checkInDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@checkInDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@checkInDate", this._checkInDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@employingOfficeLocation", this._employingOfficeLocation));
                    commandWrapper.Parameters.Add(new SqlParameter("@titleJustification", this._titleJustification));
                    commandWrapper.Parameters.Add(new SqlParameter("@highGradeApproval", this._highGradeApproval));
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", this._supervisorOrgTitle));
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalSupOrgTitle", this._additionalSupOrgTitle));

                    if (this._copyFromPDID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDID", this._copyFromPDID));

                    if (this._copyFromPDIDByUserID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDIDByUserID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDIDByUserID", this._copyFromPDIDByUserID));

                    if (this._copyFromPDIDDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDIDDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@copyFromPDIDDate", this._copyFromPDIDDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@evaluatorOrgTitle", this._evaluatorOrgTitle));
                    commandWrapper.Parameters.Add(new SqlParameter("@classifierOrgTitle", this._classifierOrgTitle));
                    commandWrapper.Parameters.Add(new SqlParameter("@isAGoodPD", this._isAGoodPD));
                    commandWrapper.Parameters.Add(new SqlParameter("@isInterdisciplinaryPD", this._isInterdisciplinaryPD));
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalSeries", this._additionalSeries));

                    if (this._hCOID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@hCOID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@hCOID", this._hCOID));
                    commandWrapper.Parameters.Add(new SqlParameter("@hCOFullName", this._hCOFullName));

                    if (this._hCOSignDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@hCOSignDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@hCOSignDate", this._hCOSignDate));

                    if (this._aDBPHCID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@aDBPHCID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@aDBPHCID", this._aDBPHCID));

                    if (this._aDBPHCConfirmDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@aDBPHCConfirmDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@aDBPHCConfirmDate", this._aDBPHCConfirmDate));

                    if (this._directorID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@directorID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@directorID", this._directorID));

                    if (this._directorConfirmationDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@directorConfirmationDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@directorConfirmationDate", this._directorConfirmationDate));
                    commandWrapper.Parameters.Add(new SqlParameter("@hCOOrgTitle", this._hCOOrgTitle));

                    if (this._workflowStatusID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@workflowStatusID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@workflowStatusID", this._workflowStatusID));

                    if (this._logRecCreateDate == DateTime.MinValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@logRecCreateDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@logRecCreateDate", this._logRecCreateDate));

                    if (this._logRecCreatedByID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@logRecCreatedByID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@logRecCreatedByID", this._logRecCreatedByID));

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
            if (base.ValidateKeyField(this._positionDescriptionLogID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeletePositionDescriptionLog", this._positionDescriptionLogID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static List<PositionDescriptionLog> GetCollection(DataTable dataItems)
        {
            List<PositionDescriptionLog> listCollection = new List<PositionDescriptionLog>();
            PositionDescriptionLog current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PositionDescriptionLog(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PositionDescriptionLog collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

    }
}

