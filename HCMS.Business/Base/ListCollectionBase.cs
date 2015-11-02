using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HCMS.Business.Common;

namespace HCMS.Business.Base
{
    [Serializable]
    public abstract class ListCollectionBase<TEntity, TAdapter> : List<TEntity>, IBusinessEntityCollection
        where TEntity : new()
        where TAdapter : IEntityDataAdapter<TEntity>, new()
    {
        #region Constructors

        public ListCollectionBase()
        {
            // Empty Constructor
        }

        public ListCollectionBase(List<TEntity> dataItems) : base(dataItems)
        {
        }

        public ListCollectionBase(DataTable dataList)
        {
            try
            {
                this.fillFromDataTable(dataList);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        #endregion

        #region Methods

        private void fillFromDataTable(DataTable tableItems)
        {
            if (tableItems != null)
            {
                foreach (DataRow currentDataRow in tableItems.Rows)
                {
                    TEntity item = new TEntity();
                    TAdapter adapter = new TAdapter();

                    adapter.Fill(currentDataRow, item);
                    this.Add(item);
                }
            }
        }

        public void Fill(DataTable tableItems)
        {
            this.fillFromDataTable(tableItems);
        }

        #endregion
    }
}
