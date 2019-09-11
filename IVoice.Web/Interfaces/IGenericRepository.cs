using IVoice.Helpers;
using IVoice.Helpers.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IVoice.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IEntityBase
    {
        Database.EOneEntities _dbContext { get; }
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TResult FirstOrDefault<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, params Sorter<TEntity>[] sorters);
        List<TResult> LoadAndSelect<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, bool distinct);
        List<TResult> LoadSortAndSelect<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, params Sorter<TEntity>[] sorters);
        List<TResult> LoadSortAndSelect<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, int take, params Sorter<TEntity>[] sorters);
        List<TResult> LoadAndSelectMany<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, IEnumerable<TResult>>> selector, params Sorter<TEntity>[] sorters);

        IQueryable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate);
        int Save(TEntity entity, bool? ForceInsert = null);
        int Remove(TEntity entity);
        int SaveChanges();
    }
}
