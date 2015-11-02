using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using HCMS.Business.Base;
using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.Business.Series;
using HCMS.Business.Series.Collections;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using System.Collections;

using HCMS.Lookups;
using HCMS.Business.JQ.Collections;
using HCMS.Business.Lookups.Repositories;
using HCMS.Business.Lookups.Adapters;

namespace HCMS.Business.Lookups
{
    [Serializable]
    [System.ComponentModel.DataObject]
    public abstract class LookupManager : BusinessBase
    {
        public static GradeCollection GetAllGrades()
        {
            return Grade.GetCollection(ExecuteDataTable("spr_GetAllGrades"));
        }

        public static SeriesCollection GetAllSeries()
        {
            return Series.GetCollection(ExecuteDataTable("spr_GetAllSeries"));
        }

        public static SeriesCollection GetAllInUseSeries()
        {
            return Series.GetCollection(ExecuteDataTable("spr_GetAllInUseSeries"));
        }
        public static PayPlanCollection GetAllPayPlans()
        {
            return PayPlan.GetCollection(ExecuteDataTable("spr_GetAllPayPlans"));
        }

        public static PayPlanCollection GetAllInUsePayPlans()
        {
            return PayPlan.GetCollection(ExecuteDataTable("spr_GetAllInUsePayPlans"));
        }
        public static List<DutyType> GetAllDutyTypes()
        {
            return DutyType.GetCollection(ExecuteDataTable("spr_GetAllDutyTypes"));
        }

        public static List<PositionType> GetAllPositionTypes()
        {
            return PositionType.GetCollection(ExecuteDataTable("spr_GetAllPositionTypes"));
        }

        public static List<PositionStatusType> GetAllPositionStatusTypes()
        {
            return PositionStatusType.GetCollection(ExecuteDataTable("spr_GetAllPositionStatusTypes"));
        }

        public static List<NoteStatus> GetAllNoteStatuses()
        {
            return NoteStatus.GetCollection(ExecuteDataTable("spr_GetAllNoteStatus"));
        }

        public static List<WorkflowStatus> GetAllWorkflowStatuses()
        {
            return WorkflowStatus.GetCollection(ExecuteDataTable("spr_GetAllWorkflowStatuses"));
        }

        public static SeriesCollection GetPayPlanSeries(int payPlanID)
        {
            return Series.GetCollection(ExecuteDataTable("spr_GetSeriesByPayPlanID", payPlanID));
        }

        public static List<ReasonForSubmission> GetAllReasonForSubmission()
        {
            return ReasonForSubmission.GetCollection(ExecuteDataTable("spr_GetAllReasonForSubmissions"));
        }

        public static List<Service> GetAllService()
        {
            return Service.GetCollection(ExecuteDataTable("spr_GetAllServices"));
        }

        public static List<PostionSensitivityType> GetAllPostionSensitivityType()
        {
            return PostionSensitivityType.GetCollection(ExecuteDataTable("spr_GetAllPositionSensitivityTypes"));
        }

        public static SeriesOPMTitleCollection GetSeriesOPMTitle(int seriesID)
        {
            return SeriesOPMTitle.GetCollection(ExecuteDataTable("spr_GetSeriesOPMTitlesBySeriesID", seriesID));
        }

        public static List<FactorFormatType> GetAllFactorFormatType()
        {
            return FactorFormatType.GetCollection(ExecuteDataTable("spr_GetAllFactorFormatTypes"));
        }

        public static List<Region> GetAllRegions()
        {
            return Region.GetCollection(ExecuteDataTable("spr_GetAllRegions"));
        }

        public static List<Qualification> GetAllQualifications()
        {
            return Qualification.GetCollection(ExecuteDataTable("spr_GetAllQualifications"));
        }

        public static List<QualificationType> GetAllQualificationTypes()
        {
            return QualificationType.GetCollection(ExecuteDataTable("spr_GetAllQualificationTypes"));
        }

        public static List<ClassificationStandardSource> GetAllClassificationStandardSources()
        {
            return ClassificationStandardSource.GetCollection(ExecuteDataTable("spr_GetAllClassificationStandardSources"));
        }

        public static List<FLSAType> GetAllFLSATypes()
        {
            return FLSAType.GetCollection(ExecuteDataTable("spr_GetAllFLSATypes"));
        }

        public static List<ToolTip> GetAllToolTips()
        {
            return ToolTip.GetCollection(ExecuteDataTable("spr_GetAllToolTips"));
        }

        public static List<EvalCriteria> GetAllEvalCriterias()
        {
            return EvalCriteria.GetCollection(ExecuteDataTable("spr_GetAllEvalCriterias"));
        }

        public static RoleCollection GetRoles()
        {
            return Role.GetCollection(ExecuteDataTable("spr_GetAllRoles"));
        }

        public static UserCollection GetAllUsersByOrganizationCodeSearch(int regionID, int organizationCodeID)
        {
            SecurityManager manager = new SecurityManager();

            return manager.GetAllUsersByOrganizationCodeSearch(regionID, organizationCodeID, string.Empty, string.Empty);
        }

        public static OrganizationCodeCollection GetAllOrganizationCodes()
        {
            return OrganizationCode.GetCollection(ExecuteDataTable("spr_GetAllOrganizationCodes"));
        }

        public static OrganizationCodeCollection GetOrganizationCodesByRegion(int regionID)
        {
            return OrganizationCode.GetCollection(ExecuteDataTable("spr_GetOrganizationCodesByRegionID", regionID));
        }
        public static OrganizationCodeCollection GetOrganizationCodesByRegionLevel(int regionID,int levelID,bool levelPlus)
        {
            return OrganizationCode.GetCollection(ExecuteDataTable("spr_GetOrganizationCodesByRegionLevel", regionID,levelID,levelPlus));
        }
        public static OrganizationCodeCollection GetOrganizationCodesByUser(int userID)
        {
            return OrganizationCode.GetCollection(ExecuteDataTable("spr_GetOrganizationCodeByUserID", userID));
        }


        public static List<FesFactorLevelPoints> GetAllFesFactorLevelPoints()
        {
            return FesFactorLevelPoints.GetCollection(ExecuteDataTable("spr_GetAllFESFactorLevelPoints"));
        }

        public static List<SODParagraphOptions> GetAllSODParagraphOptions()
        {
            return SODParagraphOptions.GetCollection(ExecuteDataTable("spr_GetAllSODParagraphOptions"));
        }

        public static CareerLadderPDTypeCollection GetCareerLadderPDTypes()
        {
            return CareerLadderPDType.GetCollection(ExecuteDataTable("spr_GetAllCareerLadderPDTypes"));
        }

        public static CareerLadderPDTypeGradeCollection GetCareerLadderPDTypeGrades(int careerLadderPDTypeID)
        {
            return CareerLadderPDTypeGrade.GetCollection(ExecuteDataTable("spr_GetCareerLadderPDTypeGradesByType", careerLadderPDTypeID));
        }

        public static PositionWorkflowStatusCollection SearchPositionsDescription(long positionDescriptionID, int PDCreatorID, int organizationCodeID)
        {
            PositionWorkflowStatusCollection PWSCollection = new PositionWorkflowStatusCollection();

            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_SearchPositionDescriptions");

                if (positionDescriptionID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@positionDescriptionID", positionDescriptionID));

                if (PDCreatorID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@PDCreatorID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@PDCreatorID", PDCreatorID));

                if (organizationCodeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@organizationCodeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@organizationCodeID", organizationCodeID));

                PWSCollection = PositionWorkflowStatus.GetCollection(ExecuteDataTable(commandWrapper));

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return PWSCollection;
        }
        public static List<ScoringRangeGroupType> GetAllScoringRangeGroupTypes()
        {
            return ScoringRangeGroupType.GetCollection (ExecuteDataTable ("spr_GetAllScoringRangeGroupTypes"));
        }

        public static List<StaffingObjectType> GetAllStaffingObjectType()
        {
            List<StaffingObjectType> items = new List<StaffingObjectType>();

            DataTable dt = ExecuteDataTable("spr_GetAllStaffingObjectType");

            foreach (DataRow row in dt.Rows)
            {
                items.Add(new StaffingObjectType((int)row["StaffingObjectTypeID"], row["StaffingObjectTypeName"].ToString(), (bool)row["IsStandaloneDocument"], row["StaffingObjectTypeDesc"].ToString()));
            }

            return items;
        }

        public static List<JNPOptionType> GetAllJNPOptionType()
        {
            List<JNPOptionType> items = new List<JNPOptionType>();

            DataTable dt = ExecuteDataTable("spr_GetAllJNPOptionTypes");

            foreach (DataRow row in dt.Rows)
            {
                items.Add(new JNPOptionType(row));
            }

            return items;
        }

        public static List<KSA> GetAllKSA()
        {
            List<KSA> items = new List<KSA>();
            DataTable dt = ExecuteDataTable("spr_GetAllKSAs");
            foreach (DataRow row in dt.Rows)
            {
                items.Add(new KSA(row));
            }
            return items;
        }
        
         


        public static List<TaskStatement> GetAllTaskStatements()
        {
            List<TaskStatement> items = new List<TaskStatement>();
            DataTable dt = ExecuteDataTable("spr_GetAllTaskStatements");
            foreach (DataRow row in dt.Rows)
            {
                items.Add(new TaskStatement(row));
            }
            return items;
        }

        public static List<TaskStatement> GetAllTaskStatementsNotInSeriesGradeKSA(int seriesID, int gradeID, int KSAID)
        {
            List<TaskStatement> items = new List<TaskStatement>();
            DataTable dt = ExecuteDataTable("spr_GetAllTaskStatementsNotInSeriesGradeKSA", seriesID, gradeID, KSAID);
            foreach (DataRow row in dt.Rows)
            {
                items.Add(new TaskStatement(row));
            }
            return items;
        }

        public static List<TaskStatement> GetTaskStatementsByKSAID(long KSAID)
        {
            List<TaskStatement> items = new List<TaskStatement>();
            DataTable dt = ExecuteDataTable("spr_GetTaskStatementsByKSAID", KSAID);
            foreach (DataRow row in dt.Rows)
            {
                items.Add(new TaskStatement(row));
            }
            return items;
        }

        public static ImportanceScaleCollection GetImportanceScale()
        {
            ImportanceScaleCollection returnList = null;

            try
            {
                returnList = new ImportanceScaleCollection(ExecuteDataTable("spr_GetImportanceScale"));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnList;
        }

        public static NeedAtEntryCollection GetNeedAtEntryScale()
        {
            NeedAtEntryCollection returnList = null;

            try
            {
                returnList = new NeedAtEntryCollection(ExecuteDataTable("spr_GetNeedAtEntryScale"));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnList;
        }

        public static DistinguishingValueScaleCollection GetDistinguishingValueScale()
        {
            DistinguishingValueScaleCollection returnList = null;

            try
            {
                returnList = new DistinguishingValueScaleCollection(ExecuteDataTable("spr_GetDistinguishingValueScale"));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnList;
        }

        public static JQRatingScaleCollection GetJQRatingScale()
        {
            JQRatingScaleCollection returnList = null;

            try
            {
                returnList = new JQRatingScaleCollection(ExecuteDataTable("spr_GetAllJQRatingScale"));
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnList;
        }

        public static List<RatingScaleTypeEntity> GetAllRatingScaleTypes()
        {
            List<RatingScaleTypeEntity> items = new List<RatingScaleTypeEntity>();

            DataTable dt = ExecuteDataTable("spr_GetAllRatingScaleTypes");

            foreach (DataRow row in dt.Rows)
            {
                items.Add(new RatingScaleTypeEntity((int)row["RatingScaleTypeID"], row["RatingScaleName"].ToString(), row["RatingScaleDescription"].ToString()));
            }

            return items;
        }

        public static List<RatingScaleTypeEntity> GetAllRatingScaleTypesForQual()
        {
            List<RatingScaleTypeEntity> items = new List<RatingScaleTypeEntity>();

            DataTable dt = ExecuteDataTable("spr_GetAllRatingScaleTypesForQual");

            foreach (DataRow row in dt.Rows)
            {
                items.Add(new RatingScaleTypeEntity((int)row["RatingScaleTypeID"], row["RatingScaleName"].ToString(), row["RatingScaleDescription"].ToString()));
            }

            return items;
        }

        public static List<RatingScaleTypeEntity> GetAllRatingScaleTypesForKSA()
        {
            List<RatingScaleTypeEntity> items = new List<RatingScaleTypeEntity>();

            DataTable dt = ExecuteDataTable("spr_GetAllRatingScaleTypesForKSA");

            foreach (DataRow row in dt.Rows)
            {
                items.Add(new RatingScaleTypeEntity((int)row["RatingScaleTypeID"], row["RatingScaleName"].ToString(), row["RatingScaleDescription"].ToString()));
            }

            return items;
        }

        public static List<JNPWorkflowStatus> GetAllJNPWorkflowStatus()
        {
            return JNPWorkflowStatus.GetCollection(ExecuteDataTable("spr_GetAllJNPWorkflowStatus"));
        }
        public static List<OrgPositionType> GetAllOrgPositionTypes()
        {
            return OrgPositionTypeManager.GetAllOrgPositionTypes();
        }

        public static List<OrgWorkflowStatus> GetAllOrgWorkflowStatus()
        {
            return OrgWorkflowStatusManager.GetAllOrgWorkflowStatus();
        }

        public static List<State> GetAllStates()
        {
            return StateManager.GetAllStates();
        }

        public static IList<Country> GetAllCountries()
        {
            return CountryRepository.Instance.GetCountries();
        }
        
        public static List<WorkScheduleType> GetAllWorkScheduleTypes()
        {
            return WorkScheduleTypeManager.GetAllWorkScheduleTypes();
        }

        public static IList<OrgPositionGroupType> GetOrgChartPositionGroupTypes()
        {
            return OrgPositionGroupTypeRepository.Instance.GetPositionGroupTypes();
        }

        public static IList<OrgPositionPlacementType> GetOrgChartPositionPlacementTypes()
        {
            return OrgPositionPlacementTypeRepository.Instance.GetPositionPlacementTypes();
        }

        public static List<AppointmentType> GetAllAppointmentTypes()
        {
            return AppointmentTypeManager.GetAllAppointmentTypes();
        }
        public static List<OrgPositionStatusHistoryType> GetAllOrgPositionStatusHistoryTypes()
        {
            return OrgPositionStatusHistoryTypeManager.GetAllOrgPositionStatusHistoryTypes();
        }

        public static List<SupervisoryStatus> GetAllSupervisoryStatus()
        {
            return SupervisoryStatusManager.GetAllSupervisoryStatus();
        }
    }
}
