using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.JA;

namespace HCMS.Business.JA.Collections
{
    [Serializable]
    public class JobAnalysisDutyKSACollection : List<JobAnalysisDutyKSA>
    {
        #region Constructors

        public JobAnalysisDutyKSACollection()
        {
            // Empty Constructor
        }

        public JobAnalysisDutyKSACollection(List<JobAnalysisDutyKSA> dataItems) : base(dataItems)
        {
            // Fill by List<NeedAtEntry>
        }

        public JobAnalysisDutyKSACollection(DataTable dataItems)
        {
            // Fill by DataTable
            if (dataItems != null)
            {
                foreach (DataRow dr in dataItems.Rows)
                    this.Add(new JobAnalysisDutyKSA(dr));
            }
        }

        #endregion

        #region Methods

        public bool Contains(long queryJADutyKSAID)
        {
            return this.Find(queryJADutyKSAID) != null;
        }

        public JobAnalysisDutyKSA Find(long queryJADutyKSAID)
        {
            return base.Find(KSA => KSA.JADutyKSAID == queryJADutyKSAID);
        }

        public bool ContainsNullScaleInformation()
        {
            return base.Find(KSA => KSA.DistinguishingValueScaleID == enumDistinguishingValueScale.None ||
                            KSA.ImportanceID == enumImportanceScale.None ||
                            KSA.NeedAtEntryID == enumNeedAtEntryScale.None) != null;
        }

        public bool ContainsAtLeastOneFinalizedKSA()
        {
            return base.Find(KSA => KSA.IsFinalKSA) != null;
        }

        public int GetFinalizationCount()
        {
            List<JobAnalysisDutyKSA> countList = base.FindAll(KSA => KSA.IsFinalKSA);
            return countList == null ? 0 : countList.Count;
        }

        public JobAnalysisDutyKSACollection GetFinalDutyKSAList()
        {
            List<JobAnalysisDutyKSA> countList = base.FindAll(KSA => KSA.IsFinalKSA);
            return new JobAnalysisDutyKSACollection(countList);
        }

        #endregion
    }
}
