using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HCMS.Business.Base
{
    [Serializable]
    public abstract class ManagerBase<M, T> : BusinessBase
        where M: new()
        where T : IBusinessEntity, new()
    {
        #region Object Declarations

        private static readonly Lazy<M> _instance = new Lazy<M>(() => new M());

        #endregion

        #region Singleton Property

        public static M Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        #endregion

        internal protected T GetItem(string storedProcedureName, params object[] paramList)
        {
            T returnItem = new T();

            try
            {
                DataTable dt = ExecuteDataTable(storedProcedureName, paramList);

                if (dt != null && dt.Rows.Count > 0)
                    returnItem.Fill(dt.Rows[0]);
            }
            catch (Exception ex)
            {	
                HandleException(ex);
            }

            return returnItem;
        }
        
        internal protected K GetRelatedDataCollection<K>(string storedProcedureName, params object[] paramList)
            where K : ListCollectionBase<T>, IBusinessEntityCollection, new()
        {
            K returnList = new K();

            try
            {
                DataTable dt = ExecuteDataTable(storedProcedureName, paramList);

                if (dt != null && dt.Rows.Count > 0)
                    returnList.Fill(dt);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnList;
        }
    }
}
