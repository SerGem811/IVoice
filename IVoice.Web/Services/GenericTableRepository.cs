using IVoice.Database;
using IVoice.Helpers;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IVoice.Services
{
    public class GenericTableRepository<TEntity, TResult> : GenericRepository<TEntity>, IGenericTableRepository<TEntity, TResult>
        where TEntity : class, IEntityBase
        where TResult : class
    {
        public GenericTableRepository(EOneEntities dbContext) : base(dbContext)
        {
        }

        public virtual List<Sorter<TEntity>> GetSorters(DataTableParameters dtParams)
        {
            throw new NotImplementedException();
        }

        public DT_ViewList<TEntity> GetTableRows(DataTableParameters dtParams, List<Sorter<TEntity>> sorters, Expression<Func<TEntity, bool>> filter)
        {
            var list = PrepareSet().Where(filter);
            int recordsTotal = list.Count();

            #region Order By
            var i = 0;
            foreach (var sorter in sorters)
            {
                i++;
                list = sorter.Sort(list, i > 1);
            }
            #endregion

            #region ModelViewReturn
            var listToShow = list.Skip(dtParams.Start).Take(dtParams.Length).ToList();

            DT_ViewList<TEntity> ModelViewReturn = new DT_ViewList<TEntity>();
            ModelViewReturn.draw = dtParams.Draw + 1;
            ModelViewReturn.recordsFiltered = listToShow.Count();
            ModelViewReturn.recordsTotal = recordsTotal;
            ModelViewReturn.data = listToShow;
            #endregion

            return ModelViewReturn;
        }

        public virtual DT_ViewList<TResult> GetTableRows(DataTableParameters dtParams, List<Sorter<TEntity>> sorters, Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector)
        {
            var list = PrepareSet().Where(filter);
            int recordsTotal = list.Count();

            #region Order By
            var i = 0;
            foreach (var sorter in sorters)
            {
                i++;
                list = sorter.Sort(list, i > 1);
            }
            #endregion

            #region ModelViewReturn
            var listToShow = list.Skip(dtParams.Start).Take(dtParams.Length).Select(selector).ToList();

            DT_ViewList<TResult> ModelViewReturn = new DT_ViewList<TResult>();
            ModelViewReturn.draw = dtParams.Draw + 1;
            ModelViewReturn.recordsFiltered = listToShow.Count();
            ModelViewReturn.recordsTotal = recordsTotal;
            ModelViewReturn.data = listToShow;
            #endregion

            return ModelViewReturn;
        }
    }
}