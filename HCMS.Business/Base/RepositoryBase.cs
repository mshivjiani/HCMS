using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HCMS.Business.Base
{
    [Serializable]
    public abstract class RepositoryBase<TRepository, TEntity, TAdapter> : BusinessBase
        where TRepository : new()
        where TEntity : new()
        where TAdapter : IEntityDataAdapter<TEntity>, new()
    {
        #region Object Declarations

        private static readonly Lazy<TRepository> _instance = new Lazy<TRepository>(() => new TRepository());

        #endregion

        #region Singleton Property

        public static TRepository Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        #endregion

        internal protected TEntity GetItem(string storedProcedureName, params object[] paramList)
        {
            TEntity returnItem = new TEntity();

            try
            {
                DataTable dt = ExecuteDataTable(storedProcedureName, paramList);
                TAdapter adapter = new TAdapter();

                if (dt != null && dt.Rows.Count > 0)
                    adapter.Fill(dt.Rows[0], returnItem);
            }
            catch (Exception ex)
            {	
                HandleException(ex);
            }

            return returnItem;
        }

        internal protected IList<TEntity> GetListFromDataTable(DataTable table)
        {
            IList<TEntity> listData = new List<TEntity>();

            try
            {
                TAdapter adapter = new TAdapter();

                foreach (DataRow dr in table.Rows)
                {
                    TEntity item = new TEntity();
                    adapter.Fill(dr, item);

                    listData.Add(item);
                }
            }
            catch (Exception ex)
            {	
                HandleException(ex);
            }
            
            return listData;
        }

        internal protected IList<TEntity> GetItemList(string storedProcedureName, params object[] paramList)
        {
            IList<TEntity> listData = null;

            try
            {
                DataTable dt = ExecuteDataTable(storedProcedureName, paramList);
                listData = this.GetListFromDataTable(dt);
            }
            catch (Exception ex)
            {	
                HandleException(ex);
            }

            return listData ?? new List<TEntity>();
        }

        internal protected TCustomCollection GetItemCustomCollection<TCustomCollection>(string storedProcedureName, params object[] paramList)
            where TCustomCollection : IList<TEntity>, IBusinessEntityCollection, new()
        {
            TCustomCollection returnList = new TCustomCollection();

            try
            {
                IList<TEntity> listData = new List<TEntity>();
                DataTable dt = ExecuteDataTable(storedProcedureName, paramList);
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
