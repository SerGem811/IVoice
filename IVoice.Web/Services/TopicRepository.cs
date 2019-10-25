using IVoice.Database;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.ForumTopic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Services
{
    public class TopicRepository : GenericTableRepository<ForumTopic, TableRowModel>, ITopicRepository
    {

        public TopicRepository(EOneEntities _dbContext) : base(_dbContext)
        {
        }

        public override List<Sorter<ForumTopic>> GetSorters(DataTableParameters dataTableParameters)
        {
            List<Sorter<ForumTopic>> list = new List<Sorter<ForumTopic>>();

            if (dataTableParameters.Order != null)
            {
                foreach (var orderItem in dataTableParameters.Order)
                {
                    Sorter<ForumTopic> sorter = Sorter<ForumTopic>.Get(x => x.Id, true);
                    bool asc = (orderItem.Dir == "asc");

                    if (orderItem.Column == 0) list.Add(Sorter<ForumTopic>.Get(x => x.Id, asc));
                    else if (orderItem.Column == 1) list.Add(Sorter<ForumTopic>.Get(x => x.Name, asc));
                }
            }

            if (list.Count == 0)
                list.Add(Sorter<ForumTopic>.Get(x => x.Id, true));

            return list;
        }
    }
}