using IVoice.Database;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Services
{
    public class CategoryRepository : GenericTableRepository<Category, TableRowModel>, ICategoryRepository
    {

        public CategoryRepository(EOneEntities _dbContext) : base(_dbContext)
        {
        }

        public override List<Sorter<Category>> GetSorters(DataTableParameters dataTableParameters)
        {
            List<Sorter<Category>> list = new List<Sorter<Category>>();

            if (dataTableParameters.Order != null)
            {
                foreach (var orderItem in dataTableParameters.Order)
                {
                    Sorter<Category> sorter = Sorter<Category>.Get(x => x.Id, true);
                    bool asc = (orderItem.Dir == "asc");

                    if (orderItem.Column == 0) list.Add(Sorter<Category>.Get(x => x.Id, asc));
                    else if (orderItem.Column == 1) list.Add(Sorter<Category>.Get(x => x.Name, asc));
                }
            }

            if (list.Count == 0)
                list.Add(Sorter<Category>.Get(x => x.Id, true));

            return list;
        }
    }
}