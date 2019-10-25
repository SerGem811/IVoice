using IVoice.Database;
using IVoice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Services
{
    public class ForumAnswerVotesRepository : GenericRepository<ForumAnswerVote>, IForumAnswerVotesRepository
    {
        public ForumAnswerVotesRepository(EOneEntities _dbContext) : base(_dbContext)
        {
        }
    }
}