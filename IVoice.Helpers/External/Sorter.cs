using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IVoice.Helpers.External
{
    public abstract class Sorter<TEntity>
    where TEntity : class, IEntityBase
    {
        public abstract IQueryable<TEntity> Sort(IQueryable<TEntity> queryable, bool isThenBy);
        public abstract IEnumerable<TEntity> SortList(IEnumerable<TEntity> enumerable, bool isThenBy);

        public static Sorter<TEntity> Get<TOrderKey>(Expression<Func<TEntity, TOrderKey>> orderBy, bool ascending)
            => new TypedSorter<TOrderKey>(orderBy, ascending);

        class TypedSorter<TOrderKey> : Sorter<TEntity>
        {
            Expression<Func<TEntity, TOrderKey>> OrderBy;
            bool Ascending;
            public TypedSorter(Expression<Func<TEntity, TOrderKey>> orderBy, bool ascending)
            {
                OrderBy = orderBy;
                Ascending = ascending;
            }

            public override IQueryable<TEntity> Sort(IQueryable<TEntity> queryable, bool isThenBy)
                => isThenBy ?
            (
                Ascending ?
                (queryable as IOrderedQueryable<TEntity>).ThenBy(OrderBy) :
                (queryable as IOrderedQueryable<TEntity>).ThenByDescending(OrderBy)
            ) :
            (
                Ascending ?
                queryable.OrderBy(OrderBy) :
                queryable.OrderByDescending(OrderBy)
            );



            public override IEnumerable<TEntity> SortList(IEnumerable<TEntity> enumerable, bool isThenBy)
                => isThenBy ?
            (
                Ascending ?
                (enumerable as IOrderedEnumerable<TEntity>).ThenBy(OrderBy.Compile()) :
                (enumerable as IOrderedEnumerable<TEntity>).ThenByDescending(OrderBy.Compile())
            ) :
            (
                Ascending ?
                enumerable.OrderBy(OrderBy.Compile()) :
                enumerable.OrderByDescending(OrderBy.Compile())
            );
        }
    }
}
