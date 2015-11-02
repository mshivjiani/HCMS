using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HCMS.Business.JA.Collections
{
    [Serializable]
    public class JobAnalysisDutyKSAFactorCollection :List<JobAnalysisDutyKSAFactor>
    {
        #region Constructors

        public JobAnalysisDutyKSAFactorCollection()
        {
            // Empty Constructor
        }

        public JobAnalysisDutyKSAFactorCollection(List<JobAnalysisDutyKSAFactor> dataItems)
            : base(dataItems)
        {
            // Fill by List<NeedAtEntry>
        }

        public JobAnalysisDutyKSAFactorCollection(DataTable dataItems)
        {
            // Fill by DataTable
            if (dataItems != null)
            {
                foreach (DataRow dr in dataItems.Rows)
                    this.Add(new JobAnalysisDutyKSAFactor(dr));
            }
        }

        #endregion

        #region Methods

        public bool Contains(long queryJQFactorID)
        {
            return this.Find(queryJQFactorID) != null;
        }

        public JobAnalysisDutyKSAFactor Find(long queryJQFactorID)
        {
            //return base.Find(KSA => KSA.JADutyKSAID == queryJADutyKSAID);
            return base.Find(KSA => KSA.JQFactorID == queryJQFactorID);
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
            List<JobAnalysisDutyKSAFactor> countList = base.FindAll(KSA => KSA.IsFinalKSA);
            return countList == null ? 0 : countList.Count;
        }

        public JobAnalysisDutyKSAFactorCollection GetFinalDutyKSAList()
        {
            List<JobAnalysisDutyKSAFactor> countList = base.FindAll(KSA => KSA.IsFinalKSA);
            return new JobAnalysisDutyKSAFactorCollection(countList);
        }

        #endregion
    }
}
