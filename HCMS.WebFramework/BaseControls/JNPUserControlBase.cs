using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.JNP;
using System.Data;
using HCMS.Business.Base;
using HCMS.Business.JA;
using HCMS.Business.CR;
using HCMS.Business.PD;

namespace HCMS.WebFramework.BaseControls
{
    public abstract class JNPUserControlBase : UserControlBase
    {
        const string CURRENTJA = "CurrentJobAnalysis";
        const string CURRENTCR = "CurrentCategoryRating";
        const string CURRENTJNPID = "CurrentJNPID";
        const string CURRENTJNP = "CurrentJNP";
        const string CURRENTJAID = "CurrentJAID";
        const string CURRENTJADUTYID = "CurrentJADutyID";
        const string CURRENTCRID = "CurrentCRID";
        const string CURRENTJQID = "CurrentJQID";
        const string CURRENTJQFACTORID = "CurrentJQFactorID";
        const string CURRENTJQFACTORTYPEID = "CurrentJQFactorTypeID";
        const string CURRENTJQFACTORITEMID = "CurrentJQFactorItemID";
        const string CURRENTRATINGSCALEID = "CurrentRatingScaleID";
        const string CURRENTKSAID = "CurrentKSAID";
        const string CURRENTFULLPDID = "CurrentFullPDID";
        const string CURRENTJNPWS = "CurrentJNPWS";
        const string CURRENTAPPROVALOBJTYPE = "CurrentApprovalObjectType";
        const string CURRENTACTIVEDOCTYPE = "CurrentActiveDocType";
        const string CURRENTDOCWS = "CurrentDocWS";
        const string CURRENTACTIVECR = "CurrentActiveCR";
        const string DUTYCOUNTERS = "DutyCounterList";

        [Serializable]
        protected struct DutyCounter
        {
            public int Number;
            public long JADutyID;
        }

        public enum JNPAccessType : int
        {
            None = 0,
            ReadOnly = 1,
            Write = 2
        }

        #region Events/Delegates
        public delegate void NonExistentJAHandler();
        public event NonExistentJAHandler NonExistentJAEncountered;
        public delegate void NonExistentCRHandler();
        public event NonExistentCRHandler NonExistentCREncountered;
        //public delegate void NonExistentJQHandler();
        //public event NonExistentJQHandler NonExistentJQEncounterd;
        #endregion
        
        // set by call to IsValidJA
        protected JobAnalysis CurrentJobAnalysis
        {
            get
            {
                if (ViewState[CURRENTJA] == null)
                    ViewState[CURRENTJA] = null;

                return (JobAnalysis)ViewState[CURRENTJA];
            }
            set
            {
                ViewState[CURRENTJA] = value;
            }
        }
        
        protected List<DutyCounter> DutyCounters
        {
            get
            {
                if (Session[DUTYCOUNTERS] == null)
                {
                    Session[DUTYCOUNTERS] = new List<DutyCounter>();
                }
                return (List<DutyCounter>)Session[DUTYCOUNTERS];
            }
            set
            {
                Session[DUTYCOUNTERS] = value;
            }
        }
        
        protected CategoryRating CurrentCategoryRating
        {
            get
            {
                if (ViewState[CURRENTCR] == null)
                    ViewState[CURRENTCR] = null;
                return (CategoryRating)ViewState[CURRENTCR];
            }
            set
            {
                ViewState[CURRENTCR] = value;
            }
        }
        protected bool IsValidJA()
        {
            bool isValid = false;

            try
            {
                JobAnalysis currentJA = new JobAnalysis(CurrentJAID);
                if (currentJA.JAID == -1)
                {
                    if (NonExistentJAEncountered != null)
                        NonExistentJAEncountered();
                }
                else
                {
                    this.CurrentJobAnalysis = currentJA;
                    isValid = true;

                }
            }
            catch (Exception ex)
            {
                isValid = false;
                base.LogExceptionOnly(ex.ToString());
            }

            return isValid;
        }
        protected bool IsValidCR()
        {
            bool isValid = false;
            try
            {
                CategoryRating currentcr = CategoryRatingManager.GetByID(CurrentCRID);
                if (currentcr.CRID <= 0)
                {
                    if (NonExistentCREncountered != null)
                        NonExistentCREncountered();
                }
                else
                {
                    this.CurrentCategoryRating = currentcr;
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
                base.LogExceptionOnly(ex.ToString());
            }
            return isValid;
        }
        #region Session Variables
        protected JNPackage CurrentJNP
        {
            get
            {
                JNPackage currjnp = null;
                if (Session[CURRENTJNP] != null)
                {
                    currjnp = (JNPackage)Session[CURRENTJNP];
                }
                else
                {
                    if (CurrentJNPID > 0)
                    {
                        currjnp = new JNPackage(CurrentJNPID);
                        Session[CURRENTJNP] = currjnp;
                    }
                }
                return currjnp;
            }
            set
            {

                Session[CURRENTJNP] = value;

            }
        }
        protected long CurrentJNPID
        {
            get
            {
                long jnpid = -1;

                if (Session[CURRENTJNPID] != null)
                {
                    jnpid = (long)Session[CURRENTJNPID];
                }

                return jnpid;
            }
            set
            {
                ClearCurrentJNP();
                Session[CURRENTJNPID] = value;
                Session[CURRENTJNP] = new JNPackage(CurrentJNPID);
            }
        }
        protected long CurrentJAID
        {
            get
            {
                long jaid = -1;

                if (Session[CURRENTJAID] != null)
                {
                    jaid = (long)Session[CURRENTJAID];
                }
                else
                {
                    if (CurrentJNPID > 0)
                    {
                        DataTable dt = BusinessBase.ExecuteDataTable("spr_GetJobAnalysisByJNPID", CurrentJNPID);

                        if ((dt != null) && (dt.Rows.Count > 0))
                        {
                            DataRow dr = dt.Rows[0];
                            jaid = (long)dr["JAID"];

                            Session[CURRENTJAID] = jaid;
                        }
                    }
                }

                return jaid;
            }
            set
            {
                Session[CURRENTJAID] = value;
            }
        }
        protected long CurrentJADutyID
        {
            get
            {
                long id = -1;
                if (Session[CURRENTJADUTYID] != null)
                {
                    id = (long)Session[CURRENTJADUTYID];
                }
                return id;
            }
            set
            { Session[CURRENTJADUTYID] = value; }
        }
        protected long CurrentCRID
        {
            get
            {
                long crid = -1;

                if (Session[CURRENTCRID] != null)
                {
                    crid = (long)Session[CURRENTCRID];
                }
                else
                {
                    if (CurrentJNPID > 0)
                    {
                        DataTable dt = BusinessBase.ExecuteDataTable("spr_GetCategoryRatingByJNPID", CurrentJNPID);

                        if ((dt != null) && (dt.Rows.Count > 0))
                        {
                            DataRow dr = dt.Rows[0];
                            crid = (long)dr["CRID"];

                            Session[CURRENTCRID] = crid;
                        }
                    }
                }

                return crid;
            }
            set
            {
                Session[CURRENTCRID] = value;
            }
        }
        protected long CurrentJQID
        {
            get
            {
                long jqid = -1;

                if (Session[CURRENTJQID] != null)
                {
                    jqid = (long)Session[CURRENTJQID];
                }
                else
                {
                    if (CurrentJNPID > 0)
                    {
                        DataTable dt = BusinessBase.ExecuteDataTable("spr_GetJobQuestionnaireByJNPID", CurrentJNPID);

                        if ((dt != null) && (dt.Rows.Count > 0))
                        {
                            DataRow dr = dt.Rows[0];
                            jqid = (long)dr["JQID"];

                            Session[CURRENTJQID] = jqid;
                        }
                    }
                    //else
                    //{
                    //    if (NonExistentJQEncounterd != null)
                    //        NonExistentJQEncounterd();
                    //}
                }

                return jqid;
            }
            set
            {
                Session[CURRENTJQID] = value;
            }
        }
        protected long CurrentJQFactorID
        {
            get
            {
                long id = -1;

                if (Session[CURRENTJQFACTORID] != null)
                {
                    id = (long)Session[CURRENTJQFACTORID];
                }

                return id;
            }
            set
            {
                Session[CURRENTJQFACTORID] = value;
            }
        }
        protected long CurrentJQFactorTypeID
        {
            get
            {
                long id = -1;

                if (Session[CURRENTJQFACTORTYPEID] != null)
                {
                    id = (long)Session[CURRENTJQFACTORTYPEID];
                }

                return id;
            }
            set
            {
                Session[CURRENTJQFACTORTYPEID] = value;
            }
        }
        protected long CurrentJQFactorItemID
        {
            get
            {
                long id = -1;

                if (Session[CURRENTJQFACTORITEMID] != null)
                {
                    id = (long)Session[CURRENTJQFACTORITEMID];
                }

                return id;
            }
            set
            {
                Session[CURRENTJQFACTORITEMID] = value;
            }
        }

        protected long CurrentKSAID
        {
            get
            {
                long id = -1;

                if (Session[CURRENTKSAID] != null)
                {
                    id = (long)Session[CURRENTKSAID];
                }

                return id;
            }
            set
            {
                Session[CURRENTKSAID] = value;
            }
        }
        protected enumJNPWorkflowStatus CurrentJNPWS
        {
            get
            {
                enumJNPWorkflowStatus currentjnpws = enumJNPWorkflowStatus.Null;
                if (Session[CURRENTJNPWS] != null)
                {
                    currentjnpws = (enumJNPWorkflowStatus)Session[CURRENTJNPWS];
                }
                else
                {
                    if (CurrentJNPID > 0)
                    {
                        currentjnpws = JNPackage.GetCurrentWorkflowStatusName(CurrentJNPID);
                        Session[CURRENTJNPWS] = currentjnpws;
                    }
                }
                return currentjnpws;
            }
            set { Session[CURRENTJNPWS] = value; }
        }
        public bool IsKSA
        {
            get
            {
                return (CurrentJQFactorTypeID == (long)enumJQFactorType.KSA) ? true : false;
            }
        }
        protected long CurrentFullPDID
        {
            get
            {
                long fullpdid = -1;
                if (Session[CURRENTFULLPDID] != null)
                {
                    fullpdid = (long)Session[CURRENTFULLPDID];
                }
                else
                {
                    if (CurrentJNPID > 0)
                    {
                        DataTable dt = BusinessBase.ExecuteDataTable("spr_GetPositionDescriptionByJNPID", CurrentJNPID);
                        if ((dt != null) && (dt.Rows.Count > 0))
                        {
                            DataRow dr = dt.Rows[0];

                            fullpdid = (long)dr["PositionDescriptionID"];
                            Session[CURRENTFULLPDID] = fullpdid;
                        }

                    }
                }

                return fullpdid;
            }
            set
            {
                Session[CURRENTFULLPDID] = value;
            }
        }

        protected enumStaffingObjectType CurrentApprovalObjectType
        {
            get
            {
                enumStaffingObjectType id = enumStaffingObjectType.Unknown;

                if (Session[CURRENTAPPROVALOBJTYPE] != null)
                {
                    id = (enumStaffingObjectType)Session[CURRENTAPPROVALOBJTYPE];
                }

                return id;
            }
            set
            {
                Session[CURRENTAPPROVALOBJTYPE] = value;
            }
        }

        protected void ClearCurrentJNP()
        {
            Session[CURRENTJNPID] = null;
            Session[CURRENTJNP] = null;
            Session[CURRENTJAID] = null;
            Session[CURRENTJADUTYID] = null;
            Session[CURRENTCRID] = null;
            Session[CURRENTJQID] = null;
            Session[CURRENTJQFACTORID] = null;
            Session[CURRENTJQFACTORTYPEID] = null;
            Session[CURRENTJQFACTORITEMID] = null;
            Session[CURRENTRATINGSCALEID] = null;
            Session[CURRENTKSAID] = null;
            Session[CURRENTFULLPDID] = null;
            Session[CURRENTJADUTYID] = null;
            Session[CURRENTJNPWS] = null;
            Session[CURRENTAPPROVALOBJTYPE] = null;
            Session[CURRENTACTIVEDOCTYPE] = null;
            Session[CURRENTDOCWS] = null;
            Session[CURRENTACTIVECR] = null;
            CurrentJobAnalysis = null;
        }
        protected void ReloadCurrentJNP(long jnpID)
        {
            JNPackage newJNP = new JNPackage(jnpID);
            if (newJNP.JNPID > 0)
            {
                bool forceReload = true;
                ClearCurrentJNP();
                CurrentJNP = newJNP;
                CurrentJNPID = newJNP.JNPID;
                CurrentJAID = newJNP.JAID;
                CurrentCRID = newJNP.CRID;
                CurrentJQID = newJNP.JQID;
                CurrentFullPDID = newJNP.FullPDID;
                HasActiveCR(forceReload);

                //Below is no longer in scope for new requirement.
                //GetJNPCurrentDocumentWorklfowStatus(forceReload);

                GetActiveDocumentType(forceReload);
                GetJNPCurrentWorkflowStatusName(newJNP);

            }
        }
        #endregion



        /// <summary>
        /// checking if the user has all of the permissions for the Staffing Specialist 
        /// </summary>
        protected bool IsStaffingSpecialist
        {
            get
            {
                return (HasPermission(enumPermission.CompleteHRCertification) &&
                         HasPermission(enumPermission.CreateJNP) &&
                         HasPermission(enumPermission.CreateStandaloneJA) &&
                         HasPermission(enumPermission.CreateStandaloneCR) &&
                         HasPermission(enumPermission.CreateStandaloneJQ) &&
                         HasPermission(enumPermission.FinalizeDocument) &&
                         HasPermission(enumPermission.CreateStandardJNP) &&
                         HasPermission(enumPermission.CreateCustomRatingScale) &&
                         HasPermission(enumPermission.PublishJNPackage));
            }
        }
        /// <summary>
        /// Returns true if the user has all of the permissions for the Staffing Manager 
        /// </summary>
        protected bool IsStaffingManager
        {
            get
            {
                return (HasPermission(enumPermission.CompleteHRCertification) &&
                         HasPermission(enumPermission.CreateJNP) &&
                         HasPermission(enumPermission.CreateStandaloneJA) &&
                         HasPermission(enumPermission.CreateStandaloneCR) &&
                         HasPermission(enumPermission.CreateStandaloneJQ) &&
                         HasPermission(enumPermission.FinalizeDocument) &&
                         HasPermission(enumPermission.CreateStandardJNP) &&
                         HasPermission(enumPermission.CreateCustomRatingScale) &&
                         HasPermission(enumPermission.PublishJNPackage));
            }
        }
        //protected enumDocWorkflowStatus GetJNPCurrentDocumentWorklfowStatus(bool reload)
        //{
        //    enumDocWorkflowStatus currentdocws = enumDocWorkflowStatus.Null;
        //    if ((Session[CURRENTDOCWS] != null) && (!reload))
        //    {
        //        currentdocws = (enumDocWorkflowStatus)Session[CURRENTDOCWS];
        //    }
        //    else
        //    {
        //        if (CurrentJNPID > 0)
        //        {
        //            currentdocws = WorkflowManager.GetJNPCurrentDocumentWorklfowStatus(CurrentJNPID);
        //            Session[CURRENTDOCWS] = currentdocws ;
        //        }

        //    }
        //    return currentdocws;
        //}
        protected enumDocumentType GetActiveDocumentType(bool reload)
        {
            enumDocumentType currentdoctype = enumDocumentType.JNP;
            if ((Session[CURRENTACTIVEDOCTYPE] != null) && (!reload))
            {
                currentdoctype = (enumDocumentType)Session[CURRENTACTIVEDOCTYPE];
            }
            else
            {
                if (CurrentJNPID > 0)
                {
                    currentdoctype = JNPackage.GetActiveDocumentType(CurrentJNPID);
                    Session[CURRENTACTIVEDOCTYPE] = currentdoctype;
                }

            }

            return currentdoctype;

        }
        protected enumJNPWorkflowStatus GetJNPCurrentWorkflowStatusName(JNPackage thisJNP)
        {

            enumJNPWorkflowStatus enumcurrentws = JNPackage.GetCurrentWorkflowStatusName(thisJNP.JNPID);

            Session["CurrentJNPID"] = thisJNP.JNPID;
            Session["CurrentJNP"] = thisJNP;
            Session["CurrentJAID"] = thisJNP.JAID;
            Session["CurrentCRID"] = thisJNP.CRID;
            Session["CurrentJQID"] = thisJNP.JQID;
            Session["CurrentFullPDID"] = thisJNP.FullPDID;
            Session["CurrentJNPWS"] = enumcurrentws;

            return enumcurrentws;

        }
        protected JNPAccessType CurrentJNPAccessType
        {
            get
            {
                return base.IsInEdit == true ? JNPAccessType.Write : JNPAccessType.ReadOnly;
            }
        }
        protected JNPAccessType GetJNPAccessType(JNPackage thisJNP)
        {
            // Need to fix the logic
            JNPAccessType accesstype = JNPAccessType.None;
            enumJNPWorkflowStatus currentws = GetJNPCurrentWorkflowStatusName(thisJNP);
            if (currentws == enumJNPWorkflowStatus.Published)
            {
                accesstype = JNPAccessType.ReadOnly;
            }
            else
            {

                List<enumMenuOption> currentOptions = GetJNPMenuOptionsForUser(thisJNP);
                if ((currentOptions.Contains(enumMenuOption.Edit)) || currentOptions.Contains(enumMenuOption.ContinueEdit))
                {
                    accesstype = JNPAccessType.Write;
                }
            }
            return accesstype;

        }
        protected List<enumMenuOption> GetJNPMenuOptionsForUser(JNPackage thisJNP)
        {
            DataTable dt = new DataTable();
            List<enumMenuOption> availableMenuOptions = new List<enumMenuOption>();
            bool canview = false;
            bool canEdit = false;
            bool canContinueEdit = false;
            bool canFinishEdit = false;
            dt = JNPackage.GetJNPAccessForUser(thisJNP.JNPID, CurrentUserID);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                canview = (bool)dr["CanViewJNP"];
                canEdit = (bool)dr["CanEditJNP"];
                canContinueEdit = (bool)dr["CanContinueEditJNP"];
                canFinishEdit = (bool)dr["CanFinishEditJNP"];

            }
            if (canview)
                availableMenuOptions.Add(enumMenuOption.View);
            if (canEdit)
                availableMenuOptions.Add(enumMenuOption.Edit);
            if (canContinueEdit)
                availableMenuOptions.Add(enumMenuOption.ContinueEdit);
            if (canFinishEdit)
                availableMenuOptions.Add(enumMenuOption.FinishEdit);

            return availableMenuOptions;


        }


        public enumLastScreen LastScreen()
        {
            switch (this.CurrentJNPWS)
            {
                case enumJNPWorkflowStatus.Draft:
                case enumJNPWorkflowStatus.Review:
                    if (this.HasActiveCR()) { return enumLastScreen.CR; } else { return enumLastScreen.JQ; }
                case enumJNPWorkflowStatus.Revise:
                case enumJNPWorkflowStatus.FinalReview:
                    return enumLastScreen.Approval;
                default:
                    return enumLastScreen.JQ;
            }
        }

        public bool LastScreenIs(enumLastScreen screen)
        {
            return (LastScreen() == screen);
        }

        protected bool HasActiveCR()
        {
            return HasActiveCR(false);
        }

        protected bool HasActiveCR(bool forceDBaseReload)
        {
            bool activecr = false;
            if ((Session[CURRENTACTIVECR] != null) && (!forceDBaseReload))
            {
                activecr = (bool)Session[CURRENTACTIVECR];
            }
            else
            {
                if (CurrentJNPID > 0)
                {
                    activecr = CurrentJNP.HasActiveCR();
                    Session[CURRENTACTIVECR] = activecr;
                }

            }
            return activecr;
        }

        protected enumJNPWorkflowStatus[] InProcessJNPWorkflowStatuses
        {
            get {
                return  new enumJNPWorkflowStatus[4] { 
                enumJNPWorkflowStatus.Draft,
                enumJNPWorkflowStatus.Review,
                enumJNPWorkflowStatus.Revise,
                enumJNPWorkflowStatus.FinalReview };
 
            }
        }
        protected bool ShowEditFields(enumDocumentType docType)
        {
            // If page is not in edit mode, disable editing fields
            if (CurrentNavMode == enumNavigationMode.View) return false;

            // If doc workflow status is one of these, disable editing fields
            enumJNPWorkflowStatus[] viewOnlyStatusList = new enumJNPWorkflowStatus[2] { 
                enumJNPWorkflowStatus.Published, 
                enumJNPWorkflowStatus.Inactive 
            };

            if (base.IsAdmin &&  (!viewOnlyStatusList.Contains(CurrentJNPWS)))
            { return true;}

            if (viewOnlyStatusList.Contains(CurrentJNPWS))
            { return false; }

            // If doc workflow status is one of these, editing should be enabled 
            //  but with considering signature(s) status in switch-case below
            enumJNPWorkflowStatus[] editableStatusList = new enumJNPWorkflowStatus[4] { 
                enumJNPWorkflowStatus.Draft,
                enumJNPWorkflowStatus.Review,
                enumJNPWorkflowStatus.Revise,
                enumJNPWorkflowStatus.FinalReview 
            };
            
            switch (docType)
            {
                case enumDocumentType.JA :
                case enumDocumentType.CR:
                    
                    // Enable editing in Revise status only if doc is NOT signed by supervisor
                    return !(CurrentJNPWS == enumJNPWorkflowStatus.Revise && CurrentJNP.IsJNPSignedBySupervisor);
                
                case enumDocumentType.JQ :
                    
                    // Enable editing in Revise status only if doc is NOT signed by supervisor
                    if (CurrentJNPWS == enumJNPWorkflowStatus.Revise && CurrentJNP.IsJNPSignedBySupervisor) return false;
                    
                    // Enable editing in FinalReview status only if doc is NOT signed by HR
                    return !(CurrentJNPWS == enumJNPWorkflowStatus.FinalReview && CurrentJNP.IsJNPSignedByHR);
            }

            // We must have received some strange enumDocumentType, disable editing in this case
            return false;
        }

    }
}
