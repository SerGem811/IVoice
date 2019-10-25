using IVoice.Database;
using IVoice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Services
{
    public class ForumTopicsViewRepository : GenericRepository<ForumTopicsView>, IForumTopicsViewRepository
    {
        public ForumTopicsViewRepository(EOneEntities _dbContext) : base(_dbContext)
        {
        }
    }
}