using IVoice.Database;
using IVoice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Services
{
    public class ForumAnswersAttachRepository : GenericRepository<ForumAnswersAttach>, IForumAnswersAttachRepository
    {
        public ForumAnswersAttachRepository(EOneEntities _dbContext) : base(_dbContext)
        {
        }
    }
}