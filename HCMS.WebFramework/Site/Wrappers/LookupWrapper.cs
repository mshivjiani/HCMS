using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.WebFramework.Common;
using HCMS.Business.Series;
using HCMS.Business.Series.Collections;
using HCMS.Business.JQ;
using HCMS.Business.JQ.Collections;
using HCMS.Lookups;

namespace HCMS.WebFramework.Site.Wrappers
{
    public abstract class LookupWrapper
    {
        #region Private Members

        private const string _assemblyName = "HCMS.Business";
        private const string _objectName = "HCMS.Business.Lookups.LookupManager";

        #endregion

        #region Cache Handler

        protected static List<T> CacheData<T>(bool reload, string dataMethod, string keyName, string assemblyName, string objectName)
        {
            CachedDataHandler cacheHandler = new CachedDataHandler(assemblyName, objectName);
            return cacheHandler.GetCachedData<T>(reload, dataMethod, keyName);
        }

        protected static List<T> CacheData<T>(bool reload, string dataMethod, string keyName, string assemblyName, string objectName, params object[] argumentList)
        {
            CachedDataHandler cacheHandler = new CachedDataHandler(assemblyName, objectName);
            return cacheHandler.GetCachedData<T>(reload, dataMethod, keyName, argumentList);
        }

        #endregion    

        #region Data Methods

        public static RoleCollection GetAllRoles(bool reload)
        {
            const string keyName = "Roles";
            return (RoleCollection) CacheData<Role>(reload, "GetRoles", keyName, _assemblyName, _objectName);
        }

        public static GradeCollection GetAllGrades(bool reload)
        {
            const string keyName = "Grades";
            return (GradeCollection) CacheData<Grade>(reload, "GetAllGrades", keyName, _assemblyName, _objectName);
        }

        public static SeriesCollection GetAllSeries(bool reload)
        {
            const string keyName = "Series";
            return (SeriesCollection) CacheData<Series>(reload, "GetAllSeries", keyName, _assemblyName, _objectName);
        }

        public static SeriesCollection GetAllSeriesByPayPlan(bool reload, int payPlanID)
        {
            string keyName = string.Concat("Series", payPlanID);
            return (SeriesCollection)CacheData<Series>(reload, "GetPayPlanSeries", keyName, _assemblyName, _objectName, payPlanID);
        }

        public static SeriesCollection GetAllInUseSeries(bool reload)
        {
            const string keyName = "InUseSeries";
            return (SeriesCollection)CacheData<Series>(reload, "GetAllInUseSeries", keyName, _assemblyName, _objectName);
        }
        public static PayPlanCollection GetAllPayPlans(bool reload)
        {
            const string keyName = "PayPlans";
            return (PayPlanCollection) CacheData<PayPlan>(reload, "GetAllPayPlans", keyName, _assemblyName, _objectName);
        }


        public static PayPlanCollection GetAllInUsePayPlans(bool reload)
        {
            const string keyName = "InUsePayPlans";
            return (PayPlanCollection)CacheData<PayPlan>(reload, "GetAllInUsePayPlans", keyName, _assemblyName, _objectName);
        }

        public static List<DutyType> GetAllDutyTypes(bool reload)
        {
            const string keyName = "DutyTypes";
            return CacheData<DutyType>(reload, "GetAllDutyTypes", keyName, _assemblyName, _objectName);
        }

        public static List<PositionType> GetAllPositionTypes(bool reload)
        {
            const string keyName = "PositionTypes";
            return CacheData<PositionType>(reload, "GetAllPositionTypes", keyName, _assemblyName, _objectName);
        }

        public static List<PositionStatusType> GetAllPositionStatusTypes(bool reload)
        {
            const string keyName = "PositionStatusTypes";
            return CacheData<PositionStatusType>(reload, "GetAllPositionStatusTypes", keyName, _assemblyName, _objectName);
        }

        public static List<NoteStatus> GetAllNoteStatuses(bool reload)
        {
            const string keyName = "NoteStatuses";
            return CacheData<NoteStatus>(reload, "GetAllNoteStatuses", keyName, _assemblyName, _objectName);
        }

        public static List<WorkflowStatus> GetAllWorkflowStatuses(bool reload)
        {
            const string keyName = "WorkflowStatuses";
            return CacheData<WorkflowStatus>(reload, "GetAllWorkflowStatuses", keyName, _assemblyName, _objectName);
        }

        public static OrganizationCodeCollection GetAllOrganizationCodes(bool reload)
        {
            const string keyName = "OrganizationCodes";
            return (OrganizationCodeCollection)CacheData<OrganizationCode>(reload, "GetAllOrganizationCodes", keyName, _assemblyName, _objectName);
        }

        public static OrganizationCodeCollection GetOrganizationCodesByRegion(bool reload, int regionID)
        {
            string keyName = string.Format("OrganizationCodesByRegion-{0}", regionID);
            return (OrganizationCodeCollection)CacheData<OrganizationCode>(reload, "GetOrganizationCodesByRegion", keyName, _assemblyName, _objectName, regionID);
        }
        public static OrganizationCodeCollection GetOrganizationCodesByRegionLevel(bool reload, int regionID, int levelID,bool levelPlus)
        {
            string keyName = string.Format("OrganizationCodesByRegion-{0}-Level{1}", regionID,levelID);
            return (OrganizationCodeCollection)CacheData<OrganizationCode>(reload, "GetOrganizationCodesByRegionLevel", keyName, _assemblyName, _objectName, regionID,levelID, levelPlus);
        }
        public static OrganizationCodeCollection GetOrganizationCodesByUser(bool reload, int userID)
        {
            string keyName = string.Format("OrganizationCodesByUser-{0}", userID );
            return (OrganizationCodeCollection)CacheData<OrganizationCode>(reload, "GetOrganizationCodesByUser", keyName, _assemblyName, _objectName, userID);
        }
        public static UserCollection GetAllUsersByOrganizationCodeSearch(bool reload, int regionID, int organizationCode)
        {
            string keyName = string.Format("UsersByOrganizationCode-{0}-{1}", regionID, organizationCode);
            return (UserCollection)CacheData<User>(reload, "GetAllUsersByOrganizationCodeSearch", keyName, _assemblyName, _objectName, regionID, organizationCode);
        }

        public static SeriesCollection GetPayPlanSeries(bool reload, params object[] paramList)
        {
            const string keyName = "PayPlanSeries";
            return (SeriesCollection) CacheData<Series>(reload, "GetPayPlanSeries", keyName, _assemblyName, _objectName,paramList);            
        }

        public static List<ReasonForSubmission> GetAllReasonForSubmission(bool reload)
        {
            const string keyName = "ReasonForSubmission";
            return CacheData<ReasonForSubmission>(reload, "GetAllReasonForSubmission", keyName, _assemblyName, _objectName);
        }

        public static List<Service> GetAllService(bool reload)
        {
            const string keyName = "Service";
            return CacheData<Service>(reload, "GetAllService", keyName, _assemblyName, _objectName);
        }

        public static List<PostionSensitivityType> GetAllPostionSensitivityType(bool reload)
        {
            const string keyName = "PostionSensitivityType";
            return CacheData<PostionSensitivityType>(reload, "GetAllPostionSensitivityType", keyName, _assemblyName, _objectName);
        }
        public static SeriesOPMTitleCollection GetSeriesOPMTitle(bool reload, params object[] paramlist)
        {
            const string keyName = "SeriesOPMTitle";
            return (SeriesOPMTitleCollection) CacheData<SeriesOPMTitle>(reload, "GetSeriesOPMTitle", keyName, _assemblyName, _objectName, paramlist);

        }
        public static List<FactorFormatType> GetAllFactorFormatType(bool reload)
        {
            const string keyName = "FactorFormatType";
            return CacheData<FactorFormatType>(reload, "GetAllFactorFormatType", keyName, _assemblyName, _objectName);
        }

        public static List<Region> GetAllRegions(bool reload)
        {
            const string keyName = "Regions";
            return CacheData<Region>(reload, "GetAllRegions", keyName, _assemblyName, _objectName);
        }

        public static List<Qualification> GetAllQualifications(bool reload)
        {
            const string keyName = "Qualification";
            return CacheData<Qualification>(reload, "GetAllQualifications", keyName, _assemblyName, _objectName);
        }

        public static List<QualificationType> GetAllQualificationTypes(bool reload)
        {
            const string keyName = "QualificationType";
            return CacheData<QualificationType>(reload, "GetAllQualificationTypes", keyName, _assemblyName, _objectName);
        }
        public static List<ClassificationStandardSource> GetAllClassificationStandardSources(bool reload)
        {
            const string keyName = "ClassificationStandardSources";
            return CacheData<ClassificationStandardSource>(reload, "GetAllClassificationStandardSources", keyName, _assemblyName, _objectName);
        }

        public static List<FLSAType> GetAllFLSATypes(bool reload)
        {
            const string keyName = "FLSAType";
            return CacheData<FLSAType>(reload, "GetAllFLSATypes", keyName, _assemblyName, _objectName);
        }

        public static List<ToolTip> GetAllToolTips(bool reload)
        {
            const string keyName = "ToolTip";
            return CacheData<ToolTip>(reload, "GetAllToolTips", keyName, _assemblyName, _objectName);
        }

        public static List<EvalCriteria> GetAllEvalCriterias(bool reload)
        {
            const string keyName = "EvalCriteria";
            return CacheData<EvalCriteria>(reload, "GetAllEvalCriterias", keyName, _assemblyName, _objectName);

        }

        public static List<FesFactorLevelPoints> GetAllFesFactorLevelPoints(bool reload)
        {
            const string keyName = "FesFactorLevelPoints";
            return CacheData<FesFactorLevelPoints>(reload, "GetAllFesFactorLevelPoints", keyName, _assemblyName, _objectName);

        }

        public static List<SODParagraphOptions> GetAllSODParagraphOptions(bool reload)
        {
            const string keyName = "SODParagraphOptions";
            return CacheData<SODParagraphOptions>(reload, "GetAllSODParagraphOptions", keyName, _assemblyName, _objectName);
        }

        public static CareerLadderPDTypeCollection GetCareerLadderPDTypes(bool reload)
        {
            const string keyName = "CareerLadderPDTypes";
            return (CareerLadderPDTypeCollection) CacheData<CareerLadderPDType>(reload, "GetCareerLadderPDTypes", keyName, _assemblyName, _objectName);
        }

        public static CareerLadderPDTypeGradeCollection GetCareerLadderPDTypeGrades(bool reload, int careerLadderPDTypeID)
        {
            string keyName = string.Format("CareerLadderPDTypeGrades-{0}", careerLadderPDTypeID);
            return (CareerLadderPDTypeGradeCollection) CacheData<CareerLadderPDTypeGrade>(reload, "GetCareerLadderPDTypeGrades", keyName, _assemblyName, _objectName, careerLadderPDTypeID);

        }

        public static List<StaffingObjectType> GetAllStaffingObjectType(bool reload)
        {
            const string keyName = "StaffingObjectTypeID";
            return CacheData<StaffingObjectType>(reload, "GetAllStaffingObjectType", keyName, _assemblyName, _objectName);   
        }

        public static List<StaffingObjectType> GetAllStandaloneStaffingObjectType(bool reload)
        {
            return GetAllStaffingObjectType(reload).Where(staffingobject => staffingobject.IsStandaloneDocument).ToList();
        }

        public static List<StaffingObjectType> GetAllJNPStaffingObjectType(bool reload)
        {
            return GetAllStaffingObjectType(reload).Where(staffingobject => !staffingobject.IsStandaloneDocument).ToList();
        }

        public static List<JNPOptionType> GetAllJNPOptionType(bool reload)
        {
            const string keyName = "JNPOptionTypeID";
            return CacheData<JNPOptionType>(reload, "GetAllJNPOptionType", keyName, _assemblyName, _objectName);
        }

        public static ImportanceScaleCollection GetImportanceScale(bool reload)
        {
            const string keyName = "ImportanceScale";
            return (ImportanceScaleCollection)CacheData<ImportanceScale>(reload, "GetImportanceScale", keyName, _assemblyName, _objectName);
        }

        public static NeedAtEntryCollection GetNeedAtEntryScale(bool reload)
        {
            const string keyName = "NeedAtEntryScale";
            return (NeedAtEntryCollection)CacheData<NeedAtEntry>(reload, "GetNeedAtEntryScale", keyName, _assemblyName, _objectName);
        }

        public static DistinguishingValueScaleCollection GetDistinguishingValueScale(bool reload)
        {
            const string keyName = "DistinguishingValueScale";
            return (DistinguishingValueScaleCollection)CacheData<DistinguishingValueScale>(reload, "GetDistinguishingValueScale", keyName, _assemblyName, _objectName);
        }

        public static JQRatingScaleCollection GetJQRatingScale(bool reload)
        {
            const string keyName = "JQRatingScale";
            return (JQRatingScaleCollection)CacheData<JQRatingScale>(reload, "GetJQRatingScale", keyName, _assemblyName, _objectName);
        }


        public static List<KSA> GetAllKSA(bool reload)
        {
            const string keyName = "KSAs";
            return CacheData<KSA>(reload, "GetAllKSA", keyName, _assemblyName, _objectName);
        }

        public static List<TaskStatement> GetAllTaskStatements(bool reload)
        {
            const string keyName = "TaskStatement";
            return CacheData<TaskStatement>(reload, "GetAllTaskStatements", keyName, _assemblyName, _objectName);
        }

        public static List<TaskStatement> GetAllTaskStatementsNotInSeriesGradeKSA(bool reload, int seriesID, int gradeID, int KSAID)
        {
            const string keyName = "TaskStatementsNotInSeriesGradeKSA";
            return CacheData<TaskStatement>(reload, "GetAllTaskStatementsNotInSeriesGradeKSA", keyName, _assemblyName, _objectName);
        }

        public static List<JNPWorkflowStatus> GetAllJNPWorkflowStatus(bool reload)
        {
            const string keyName = "JNPWorkflowStatus";
            return CacheData<JNPWorkflowStatus>(reload, "GetAllJNPWorkflowStatus", keyName, _assemblyName, _objectName);
        }

        public static List<OrgPositionType> GetAllOrgPositionTypes(bool reload)
        {
            const string keyName = "OrgPositionType";
            return CacheData<OrgPositionType>(reload, "GetAllOrgPositionTypes", keyName, _assemblyName, _objectName);
        }

        public static List<OrgWorkflowStatus> GetAllOrgWorkflowStatus(bool reload)
        {
            const string keyName = "OrgWorkflowStatus";
            return CacheData<OrgWorkflowStatus>(reload, "GetAllOrgWorkflowStatus", keyName, _assemblyName, _objectName);
        }

        public static List<WorkScheduleType> GetAllWorkScheduleTypes(bool reload)
        {
            const string keyName = "WorkScheduleType";
            return CacheData<WorkScheduleType>(reload, "GetAllWorkScheduleTypes", keyName, _assemblyName, _objectName);
        }

        public static List<AppointmentType> GetAllAppointmentTypes(bool reload)
        {
            const string keyName = "AppointmentType";
            return CacheData<AppointmentType>(reload, "GetAllAppointmentTypes", keyName, _assemblyName, _objectName);
        }

        public static List<OrgChartType> GetAllOrgChartTypes(bool reload)
        {
            const string keyName = "OrgChartType";
            return CacheData<OrgChartType>(reload, "GetAllOrgChartTypes", keyName, _assemblyName, _objectName);
        }

        public static List<OrgPositionGroupType> GetOrgChartPositionGroupTypes(bool reload)
        {
            const string keyName = "GetOrgChartPositionGroupTypes";
            return CacheData<OrgPositionGroupType>(reload, "GetOrgChartPositionGroupTypes", keyName, _assemblyName, _objectName);
        }

        public static List<OrgPositionPlacementType> GetOrgChartPositionPlacementTypes(bool reload)
        {
            const string keyName = "GetOrgChartPositionPlacementTypes";
            return CacheData<OrgPositionPlacementType>(reload, "GetOrgChartPositionPlacementTypes", keyName, _assemblyName, _objectName);
        }

        public static List<OrgPositionStatusHistoryType> GetAllOrgPositionStatusHistoryTypes(bool reload)
        {
            const string keyName = "OrgPositionStatusHistoryType";
            return CacheData<OrgPositionStatusHistoryType>(reload, "GetAllOrgPositionStatusHistoryTypes", keyName, _assemblyName, _objectName);
        }

        public static List<State> GetAllStates(bool reload)
        {
            const string keyName = "State";
            return CacheData<State>(reload, "GetAllStates", keyName, _assemblyName, _objectName);
        }

        public static IList<Country> GetAllCountries(bool reload)
        {
            const string keyName = "Countries";
            return CacheData<Country>(reload, "GetAllCountries", keyName, _assemblyName, _objectName);
        }

        public static List<SupervisoryStatus> GetAllSupervisoryStatus(bool reload)
        {
            const string keyName = "SupervisoryStatus";
            return CacheData<SupervisoryStatus>(reload, "GetAllSupervisoryStatus", keyName, _assemblyName, _objectName);
        }

        #endregion
    }
}
