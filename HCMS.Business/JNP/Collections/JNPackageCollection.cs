using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.JNP;

namespace HCMS.Business.JNP.Collections
{
    public class JNPackageCollection : List<JNPackage>
    {
        #region Constructors

        public JNPackageCollection()
        {
            // Empty Constructor
        }

        public JNPackageCollection(List<JNPackage> loadList) : base(loadList)
        {
            // Empty Constructor
        }

        public JNPackageCollection(DataTable dataItems)
        {
            if (dataItems != null)
            {
                foreach (DataRow dr in dataItems.Rows)
                    this.Add(new JNPackage(dr));
            }
        }

        #endregion

        #region Methods

        public JNPackage Find(long queryJNPID)
        {
            return base.Find(JNP => JNP.JNPID == queryJNPID);
        }

        public bool Contains(long queryJNPID)
        {
            return (this.Find(queryJNPID) != null);
        }

        #endregion
    }
}
