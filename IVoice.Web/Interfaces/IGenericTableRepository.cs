using IVoice.Helpers;
using IVoice.Helpers.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IVoice.Interfaces
{
    public interface IGenericTableRepository<TEntity, TResult> : IGenericRepository<TEntity>
        where TEntity : class, IEntityBase
        where TResult : class
    {
        DT_ViewList<TEntity> GetTableRows(DataTableParameters dtParams, List<Sorter<TEntity>> sorters, Expression<Func<TEntity, bool>> filter);
        DT_ViewList<TResult> GetTableRows(DataTableParameters dtParams, List<Sorter<TEntity>> sorters, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector);
        List<Sorter<TEntity>> GetSorters(DataTableParameters dtParams);
    }
}
