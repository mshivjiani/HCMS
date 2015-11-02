using System.Data;

namespace HCMS.Business.Base
{
    public interface IEntityDataAdapter<TEntity>
    {
        void Fill(DataRow dataItem, TEntity item);
    }
}
