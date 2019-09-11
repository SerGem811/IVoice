using IVoice.Database;
using IVoice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Services
{
    public class UserAttachmentsRepository : GenericRepository<UsersAttachment>, IUserAttachmentsRepository
    {
        public UserAttachmentsRepository(EOneEntities dbContext) : base(dbContext)
        {
        }
    }
}