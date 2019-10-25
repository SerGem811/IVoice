using IVoice.Database;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.ForumAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Services
{
    public class ForumAnswerRepository : GenericTableRepository<ForumAnswer, TableRowModel>, IForumAnswerRepository
    {

        public ForumAnswerRepository(EOneEntities _dbContext) : base(_dbContext)
        {
        }

        public override List<Sorter<ForumAnswer>> GetSorters(DataTableParameters dataTableParameters)
        {
            List<Sorter<ForumAnswer>> list = new List<Sorter<ForumAnswer>>();

            if (dataTableParameters.Order != null)
            {
                foreach (var orderItem in dataTableParameters.Order)
                {
                    Sorter<ForumAnswer> sorter = Sorter<ForumAnswer>.Get(x => x.Id, true);
                    bool asc = (orderItem.Dir == "asc");

                    if (orderItem.Column == 0) list.Add(Sorter<ForumAnswer>.Get(x => x.Id, asc));
                    else if (orderItem.Column == 1) list.Add(Sorter<ForumAnswer>.Get(x => x.TopicId, asc));
                }
            }

            if (list.Count == 0)
                list.Add(Sorter<ForumAnswer>.Get(x => x.Id, true));

            return list;
        }
    }
}