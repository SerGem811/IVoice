using IVoice.Database;
using IVoice.Helpers;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IVoice.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntityBase
    {
        public EOneEntities _dbContext { get; private set; }
        public GenericRepository(EOneEntities dbContext)
        {
            this._dbContext = dbContext;
        }

        internal virtual IQueryable<TEntity> PrepareSet()
        {
            _dbContext.Database.Log = (s) => { Debug.WriteLine(s); };

            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return PrepareSet().FirstOrDefault(predicate);
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, params Sorter<TEntity>[] sorters)
        {
            var set = PrepareSet().Where(x => true);

            if (filter != null)
                set = set.Where(filter);

            if (sorters != null)
            {
                var i = 0;
                foreach (var sorter in sorters)
                {
                    i++;
                    set = sorter.Sort(set, i > 1);
                }
            }

            return set.Select(selector).FirstOrDefault();
        }

        public List<TResult> LoadAndSelect<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, bool distinct)
        {
            var set = PrepareSet().Where(x => true);
            if (filter != null)
                set = set.Where(filter);

            var list = set.Select(selector);
            if (distinct)
                list = list.Distinct();

            return list.ToList();
        }

        public List<TResult> LoadSortAndSelect<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, params Sorter<TEntity>[] sorters)
        {
            var set = PrepareSet().Where(x => true);
            if (filter != null)
                set = set.Where(filter);

            if (sorters != null)
            {
                var i = 0;
                foreach (var sorter in sorters)
                {
                    i++;
                    set = sorter.Sort(set, i > 1);
                }
            }

            var list = set.Select(selector);

            return list.ToList();
        }

        public List<TResult> LoadSortAndSelect<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, int take, params Sorter<TEntity>[] sorters)
        {
            var set = PrepareSet().Where(x => true);
            if (filter != null)
                set = set.Where(filter);

            if (sorters != null)
            {
                var i = 0;
                foreach (var sorter in sorters)
                {
                    i++;
                    set = sorter.Sort(set, i > 1);
                }
            }

            var list = set.Select(selector).Take(take);

            return list.ToList();
        }

        public List<TResult> LoadAndSelectMany<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, IEnumerable<TResult>>> selector, params Sorter<TEntity>[] sorters)
        {
            var set = PrepareSet();
            if (filter != null)
                set = set.Where(filter);

            if (sorters != null)
            {
                var i = 0;
                foreach (var sorter in sorters)
                {
                    i++;
                    set = sorter.Sort(set, i > 1);
                }
            }

            var list = set.SelectMany(selector);

            return list.ToList();
        }

        public IQueryable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return PrepareSet().Where(predicate);
        }

        public int Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return SaveChanges();
        }

        public int Save(TEntity entity, bool? ForceInsert = null)
        {
            if (ForceInsert.HasValue)
            {
                if (ForceInsert.Value)
                    _dbContext.Entry(entity).State = EntityState.Added;
                else
                    _dbContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                if (entity.Id > 0)
                    _dbContext.Entry(entity).State = EntityState.Modified;
                else
                    _dbContext.Entry(entity).State = EntityState.Added;
            }
            return (SaveChanges() > 0) ? entity.Id : 0;
        }

        public int SaveChanges() { return _dbContext.SaveChanges(); }
    }
}
