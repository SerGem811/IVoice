using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Interfaces
{
    public interface ITopicRepository : IGenericTableRepository<Database.ForumTopic, Models.ForumTopic.TableRowModel>
    {

    }
}