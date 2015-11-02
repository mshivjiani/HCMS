using System;
using System.ComponentModel;
public enum SignatureType : int
{
    Supervisor = 1,
    AdditionalSupervisor = 2,
    Evaluator = 3,
    Classifier = 4,
    Classifier15 = 5,
    HCO = 6
}

public enum PDStatus : int
{
    Null = -1,
    Draft = 1,
    Review = 2,
    Revise = 3,
    FinalReview = 4,
    Published = 5,
    Escalated = 6,
    Inactive = 7
}

public enum enumScheduleStatus : int
{
    Null = -1,
    [DescriptionAttribute("On Track")]
    OnTrack = 0,
    [DescriptionAttribute("Warning")]
    Warning = 1,
    [DescriptionAttribute("Escalated")]
    Escalated = 2,
    [DescriptionAttribute("Inactive")]
    Inactive = 3
}
/// <summary>
/// PDChoiceType maps to PositionDescriptionTypeID
/// </summary>
public enum PDChoiceType : int
{
    FromExistingPD = 1,
    FromExistingStandardPD = 2,
    StatementOfDifferencePD = 3,
    CareerLadderPD = 4,
    NewPD = 5,
    NewStandardPD = 6,
    CLStatementOfDifferencePD = 7
}

public enum enumFactorFormatType : int
{
    None = -1,
    FES = 1,
    GSSG = 2,
    Narrative = 3,
    NarrativeSupervisory = 4
}
public enum enumClassStandardSource : int
{
    None = -1,
    PrimaryFES = 1,
    JSFES = 2,
    JSGSSG = 3,
    JSNarrative = 4,
    JSNarrativeSup = 5,
    Other = 6
}

public enum enumChartPositionType : int
{
    None = -1,
    WFP = 1,
    FPPS = 2
}

public enum enumPositionType : int
{
    None = -1,
    Supervisory = 1,
    Managerial = 2,
    Neither = 3,
    Research = 4,
    Leader = 5
}

public enum enumPayPlan : int
{
    None = -1,
    GS = 1, //Employees covered by the General Schedule classification and pay system established under the Classification Act of 1949, as amended. (5 U.S.C. chapter 53, subchapter III, and 5 CFR part 531)
    WG = 2,//The federal pay plan that covers most Non Supervisory trade, craft, and laboring employees in the executive branch
    GL = 3,//Employees covered by the General Schedule classification and pay system (1) who are law enforcement officers (LEOs) and (2) who receive special base rates at grades 3-10 under section 403 of the Federal Employees Pay Comparability Act of 1990 (FEPCA).
    WS = 4,//The federal pay plan that covers most Supervisory trade, craft, and laboring employees in the executive branch
    WL = 5//The federal pay plan that covers most trade, craft, and laboring employees playing leadership role  in the executive branch
}

public enum enumRole : int
{
    SystemAdministrator = 1,
    CenterAdministrator = 2,
    Classifier = 3,
    Evaluator = 4,
    Supervisor = 5,
    PDDeveloper = 6,
    HRO = 7,
    HRDeputy = 8,
    HCO = 9,
    HRStaffingSpecialist = 10,
    HRStaffingManager = 11
}

public enum enumPDStatusChange : int
{
    None = -1,
    DraftToReview = 1,
    ReviewToRevise = 2,
    ReviseToFinalReview = 3,
    FinalReviewToPublished = 4
}

public enum enumSupervisorStatus : int
{
    Supervisor2 = 2,
    Supervisor4 = 4, 
    ManagementOfficial = 5,
    Leader = 6,
    TeamLeader = 7,
    AllOtherPositions = 8
   
    
}

public enum enumCountries : int
{
    // We only care about the United States enumeration
    Undefined = -1,
    UnitedStates = 1
}

public enum enumPermission : int
{
    MaintainUserAccounts = 1,
    DelegatePD = 2,
    MonitorPDEscalations = 3,
    HandlePDEscalations = 4,
    PublishPD = 5,
    CompleteHRCertification = 6,
    CompleteSupervisoryCertification = 7,
    CreateStandardPD = 8,
    CreatePD = 9,
    MaintainEvaluationStatements = 10,
    MaintainHRSection = 11,
    MaintainFactorRecommendation = 12,
    CompleteHRCertification15 = 13,
    CompleteHighGradeApproval = 14,
    ActivateDeactivatePD = 15,
    CompleteHighGradeReview = 16,
    CompleteHCOCertification = 17,
    CreateJNP = 18,
    CreateStandaloneJA = 19,
    CreateStandaloneCR = 20,
    CreateStandaloneJQ = 21,
    FinalizeDocument = 22,
    CreateStandardJNP = 23,
    CreateCustomRatingScale = 24,
    PublishJNPackage = 25,
    ActivateDeactivateJNP = 26,
    CompleteJNPCertification = 27,
    AllSystemAdministrationPermissions = 100
}
public enum WorkflowNoteStatus
{
    Open = 1,
    InProgress = 2,
    Closed = 3
}
public enum enumJNPWorkflowNoteStatus : int
{
    Open = 1,
    InProgress = 2,
    Closed = 3
}
public enum enumNextAct : int
{
    SaveandContinue = 1,
    SaveandUnlock = 2
}

public enum enumIDType : int { PositionDescriptionTypeID = 1, PositionFactorID = 2, PositionFactorLogID = 3 }

public enum eMode : int
{
    None = 0,
    Insert = 1,
    Edit = 2,
    View = 3
}


/*********************************JNP related enums ********************************/

public enum enumLastScreen : int
{
    JQ = 1,
    CR = 2,
    Approval = 3
}

public enum eJNPOptionType : int
{
    None = 0,
    CreateNew = 1,
    CreateFromExisting = 2,
    CreateStandAloneDoc = 3
}

public enum enumQualificationType : int
{
    [DescriptionAttribute("KSA-Quality Ranking Factor")]
    KSAQualityRankingFactor = 1,
    [DescriptionAttribute("Selective Factor")]
    SelectiveFactor = 2,
    [DescriptionAttribute("KSA")]
    KSA = 3,
    [DescriptionAttribute("Condition of Employment")]
    ConditionOfEmployment = 4
}


public enum enumJQFactorType : int
{
    None = 0,
    AppointmentEligibility = 1,
    MinimumQualification = 2,
    BasicEducationRequirement = 3,
    ConditionOfEmployment = 4,
    SelectiveFactor = 5,
    AdditionalQualification = 6,
    KSA = 7,
    Other = 8
}

public enum enumRatingScaleType : int
{
    None = -1,
    DefaultYN = 1, //Qual/KSA
    DefaultMultiChoice = 2, //KSA
    CustomYN = 3, //Qual/KSA
    CustomMultiChoice = 4, //KSA
    MultipleChoiceQual = 5, // Qual
    CustomMultiChoiceQual = 6 //Qual
}

public enum enumJQItemType : int
{
    Question = 1,
    Instruction = 2,
    RatingScale = 3,
    Response = 7
}

public enum enumWorkflowStatusType : int
{
    JNP = 1,
    Document = 2
}

public enum enumJNPWorkflowStatus : int
{
    Null = -1,

    [DescriptionAttribute("Draft")]
    Draft = 1,

    [DescriptionAttribute("Review")]
    Review = 2,

    [DescriptionAttribute("Revise")]
    Revise = 3,

    [DescriptionAttribute("Final Review")]
    FinalReview = 4,

    [DescriptionAttribute("Published")]
    Published = 5,

    [DescriptionAttribute("In Active")]
    Inactive = 6


}

//public enum enumDocWorkflowStatus : int
//{
//    Null = -1,
//    Draft = 1,
//    ReviewByHM = 2,
//    ReviewByHR = 3,
//    DocumentFinalize = 4,
//    FinalReview = 5,
//    InFinalReviewByHM = 6,
//    InFinalReviewByHR = 7,
//    Approval = 8,
//    InApprovalByHM = 9,
//    InApprovalByHR = 10,
//    Published = 11,
//    Inactive = 12,
//    ReviseByHM = 13
//}

public enum enumDocWorkflowStatus : int
{
    Null = -1,
    Draft = 1,
    Review = 2,
    Revise = 3,
    FinalReview = 4,
    Published = 5,
    InActive = 6
}

public enum enumDocumentType : int
{
    Unknown = -1,
    JNP = 0,
    JA = 1,
    CR = 2,
    JQ = 3,
    Comments = 4,
    All = 5
}

public enum enumDocumentFormat : int
{
    Unknown = -1,
    PDF = 0,
    UTF8 = 1,
    Comments = 2,
    DOCX = 3
}

public enum enumStaffingObjectType : int
{
    Unknown = -1,
    JNP = 1,
    JNPJA = 2,  // JA contained within a JNP 
    JNPCR = 3,  // CR contained within a JNP 
    JNPJQ = 4,  // JQ contained within a JNP 
    JA = 5,     // JA stand-alone 
    CR = 6,     // CR stand-alone 
    JQ = 7      // JQ stand-alone 

}

public enum enumActionType : int
{
    Unknown = -1,
    CheckOut = 1,
    CheckIn = 2,
    SaveAndUnlock = 3,
    DocumentFinalize = 4,
    SendToReviewToHiringManager = 5,
    SendToReviewToHumanResources = 6,
    CreateCategoryRatingFromJobAnalysis = 7,
    CreateCategoryRatingFromPublishedCategoryRating = 8,
    CreateJobQuestionnaireFromJobAnalysis = 9,
    CreateJobQuestionnaireFromPublishedJobAnalysis = 10,
    SendForApprovalToHiringManager = 11,
    SendForApprovalToHumanResources = 12,
    SendForFinalReviewToHiringManager = 13,
    SendForFinalReviewToHumanResources = 14,
    CompleteSupervisoryCertification = 15,
    CompleteHumanResourcesCertification = 16,
    CompleteHumanResourcesCertification15 = 17,
    CompleteHighGradeApproval = 18,
    EditCategoryRating = 19,
    EditJobQuestionnaire = 20,
    DeleteCategoryRating = 21,
    UpdateHiringResult = 22,
    Continue = 24,
    SendToReviseToHiringManager = 25,
    RestoreCategoryRatingOptional = 26,
    CreateCategoryRatingOptional = 27,
    SendToReviseToHumanResources = 28,
    CheckAndPublish = 99,
    Publish = 100
}

public enum enumScoringRangeGroupType : int
{
    BestQualified = 1,
    WellQualified = 2,
    Qualified = 3
}

public enum enumJNPType : int
{
    [DescriptionAttribute("Unknown")]
    Unknown = -1,
    [DescriptionAttribute("Single Grade")]
    SingleGrade = 1,
    [DescriptionAttribute("Two Grade")]
    TwoGrade = 2
}

public enum enumNeedAtEntryScale : int
{
    None = -1,
    AcquiredAfterFirst6Months = 1,
    AcquiredWithinFirst4to6Months = 2,
    AcquiredWithinFirst1to3Months = 3,
    NeededFirstDay = 4
}

public enum enumDistinguishingValueScale : int
{
    None = -1,
    NotValuable = 1,
    SomewhatValuable = 2,
    Valuable = 3,
    VeryValuable = 4
}

public enum enumImportanceScale : int
{
    None = -1,
    NotImportant = 1,
    SomewhatImportant = 2,
    Important = 3,
    VeryImportant = 4
}

[Serializable]
public enum LeftMenuType
{
    None = 0,
    PDHomeMenu = 1,
    CreatePDMenu = 2,
    JNPHomeMenu = 4,
    JAMenu = 5,
    CRMenu = 6,
    JQMenu = 7,
    ApprovalMenu = 8,
    UserAdminMenu = 9,
    PDAminMenu = 10,
    OrgCodeAdminMenu = 11,
    JNPAdminMenu = 12,
    DashboardRoleMenu = 13,
    OrgChartActionMenu = 14,
    MiscellaneousAdminMenu=15
}

[Serializable]
public enum enumTopMenuType
{
    None = 0,
    PDHomeMenu = 1,
    CreatePDMenu = 2,
    JNPHomeMenu = 4,
    JAMenu = 5,
    CRMenu = 6,
    JQMenu = 7,
    ApprovalMenu = 8,
    AdminMenu = 9,
    ModuleSelector = 10
}

[Serializable]
public enum enumFooterType
{
    None = 0,
    Site = 1,
    PDExpress = 2,
    JNP = 3,
    Other = 4
}
[Serializable]
public enum enumTopMenuItem
{
    None = 0,
    JNPTracker = 1,
    Create = 2,
    Search = 3,
    References = 4,
    FAQ = 5,
    Help = 6,
    Admin = 7,
    JobAnalysis = 8,
    CategoryRating = 9,
    JobQuestionnaire = 10,
    Approval = 11,
    UserAdmin = 12,
    PDAdmin = 13,
    OrgCodeAdmin = 14,
    JNPAdmin = 15,
    DashboardRole = 16,
    Miscellaneous=17
}


[Serializable]
public enum enumProgressBarItem
{
    None=-1,
    JAPositionInfo=0,
    JADutyKSA=1,
    JAFinalKSA=2,
    JQQualifications=3,
    JQKSA=4,
    JQFinalJQ=5,
    CategoryRating=6,
    Approval=7
}


[Serializable]
public enum enumLeftMenuItem
{
    None,
    WhatsNew,
    References,
    FAQ,
    Help,
    JAPositionInformation,
    JADuties,
    DutyKSA,
    FinalKSA,
    CategoryRating,
    CategoryRating2,
    CategoryRating3,
    JobQuestionnaire,
    Qualifications,
    KSA,
    FinalJQ,
    SearchUser,
    AddUser,
    EditUser,
    PDAdmin,
    SeriesAdmin,
    DelegatePD,
    OrgcodeAdmin,
    JNPAdmin,
    KSAAdmin,
    TaskStatementAdmin,
    SeriesKSATaskStatementAdmin,
    WorkflowActionAdmin,
    WorkflowGroupAdmin,
    WorkflowRuleAdmin,

    DashboardRole,
    DashboardRoleSearch,
    SSASRoles,

    ToolTipAdmin
}
public enum enumItemFlow
{
    Horizontal = 0,
    Vertical = 1
}
public enum enumMenuLevel
{
    Main = 0,
    Sub = 1,
}

public enum enumMenuType
{
    None = 0,
    PDHomeMenu = 1,
    CreatePDMenu = 2,
    JNPHomeMenu = 4,
    JAMenu = 5,
    CRMenu = 6,
    JQMenu = 7,
    ApprovalMenu = 8,
    UserAdminMenu = 9,
    PDAminMenu = 10,
    OrgCodeAdminMenu = 11,
    JNPAdminMenu = 12

}
public enum enumMenuLayout
{
    Top = 0,
    Left = 1,
    Bottom = 2
}

[Serializable]
public enum enumMenuItem
{
    None,
    WhatsNew,
    References,
    FAQ,
    Help,
    JAPositionInformation,
    JADuties,
    DutyKSA,
    FinalKSA,
    CategoryRating,
    CategoryRating2,
    CategoryRating3,
    JobQuestionnaire,
    Qualifications,
    KSA,
    FinalJQ,
    SearchUser,
    AddUser,
    EditUser,
    PDAdmin,
    SeriesAdmin,
    DelegatePD,
    OrgcodeAdmin,
    JNPAdmin,
    KSAAdmin,
    TaskStatementAdmin,
    SeriesKSATaskStatementAdmin,
    WorkflowActionAdmin,
    WorkflowGroupAdmin,
    WorkflowRuleAdmin,

    DashboardRole
}


[Serializable]
public enum enumDashboardRoleType
{
    Director=1,
    DeputyDirector=2,
    RegionalDirector=3,
    DeputyRegionalDirector=4,
    AssistantRegionalDirector=5,
    AssistantDirector=6,
    DeputyAssistantDirector=7,
    HumanCapitalOfficer=8,
    SystemAdministrator=9,
    ProjectLeader=10,
    RegionalHumanResourcesOfficer=11,
    SpecialAssistantToDirector=12,
    DivisionChief=13
}

#region OrgChart 

[Serializable]
public enum enumAppointmentType
{
    Undefined = -1,
    CAREER_COMP_SVC_PERM =1,
    CAREER_COND_COMP_SVC_PERM = 2,
    NONPERMANENT_COMP_SVC_NONPERM = 3,
    TERM_APPT_COMP_SVC_INACTIVE_12_16_05 = 4,
    SCHED_A_EXC_SVC_PERM = 5,
    SCHED_B_EXC_SVC_PERM = 6,
    SCHED_C_EXC_SVC_PERM_INACTIVE_12_16_05 = 7,
    SCHED_D_EXC_SVC_PERM = 8,
    EXECUTIVE_EXC_SVC_PERM = 9,
    OTHER_EXC_SVC_PERM = 10,
    SCHED_A_EXC_SVC_NONPERM = 11,
    SCHED_B_EXC_SVC_NONPERM = 12,
    SCHED_C_EXC_SVC_NONPERM = 13,
    SCHED_D_EXC_SVC_NONPERM = 14,
    EXECUTIVE_EXC_SVC_NONPERM = 15,
    OTHER_EXC_SVC_NONPERM = 16,
    CAREER_SES_PERM = 17,
    NONCAREER_SES_PERM = 18,
    LIMITED_TERM_SES_NONPERM = 19,
    LIMITED_EMERGENCY_SES_NONPERM = 20
}

[Serializable]
public enum enumOrgPositionType
{
    Undefined = -1,
    Director=1,
    Deputy_Director=2,
    Regional_Director=3,
    Deputy_Regional_Director=4,
    Assistant_Regional_Director=5,
    Assistant_Director=6,
    Deputy_Assistant_Director=7,
    Special_Assistant_To_Director=8,
    Division_Chief=9,
    Branch_Chief=10,
    Special_Advisor=11,
    Administrative_Assistant=12,
    FWS_Employee = 13,
    Special_Assistant = 14
}

[Serializable]
public enum enumWorkScheduleType
{
    Undefined = -1,
    B_BAYLOR_PLAN = 1,
    F_FULL_TIME = 2,
    G_FULL_TIME_SEASONAL = 3,
    I_INTERMITTENT = 4,
    J_INTERMITTENT_SEASONAL = 5,
    P_PART_TIME = 6,
    Q_PART_TIME_SEASONAL = 7,
    S_PART_TIME_JOB_SHARER = 8,
    T_PART_TIME_SEAS_JOB_SHAR = 9
}

[Serializable]
public enum enumOrgChartType : int
{
    Undefined = -1,
    SingleOrg = 1,
    MultiOrg =2
}


[Serializable]
public enum enumOrgWorkflowStatus
{
    Undefined = -1,
    Draft = 1,
    Review = 2,
    Approval = 3,
    Published = 4

}
[Serializable]
public enum enumOrgPositionStatusHistoryType
{
    Undefined = -1,
    ActiveVacant=1,
    ActiveEmployee=2
}

[Serializable]
public enum enumOrgPositionGroupType
{
    [DescriptionAttribute("Auto")]
    Undefined = -1,

    [DescriptionAttribute("Left")]
    Left = 1,

    [DescriptionAttribute("Right")]
    Right = 2
}

[Serializable]
public enum enumOrgPositionPlacementType
{
    [DescriptionAttribute("Regular")]
    Undefined = -1,

    [DescriptionAttribute("Adviser")]
    Advisor=1,

    [DescriptionAttribute("Assistant")]
	Assistant=2,

    [DescriptionAttribute("SubAdviser")]
	SubAdvisor=3,

    [DescriptionAttribute("SubAssistant")]
	SubAssistant=4
}

[Serializable]
public enum enumOrgDocumentFormat
{
    DOCX = 1,
    EXCEL = 2
}
[Serializable]
public enum enumPhoneNumberType
{
    undefined=-1,
    Work=1
}

[Serializable]
public enum enumSortDirection
{
    undefined=-1,
    ASC=1,
    DESC=2
}

public enum AbolishedFixActions : int
{
    TakeNoAction = -1,
    Exclude = 1,
    Delete = 2
}

public enum OrganizationChartTypeViews : int
{
    None = -1,
    InProcess = 1,
    Published = 2
}

public enum OrgCodeFormatTypes : int
{
    None = -1,
    OldOrgCode = 1,
    NewOrgCode = 2
}

#endregion

