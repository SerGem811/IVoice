using IVoice.Database;
using IVoice.Helpers;
using IVoice.Interfaces;
using System;

namespace IVoice.Services
{
    public class UserActivityRepository : GenericRepository<UsersActivity>, IUsersActivityRepository
    {
        public UserActivityRepository(EOneEntities dbContext) : base(dbContext)
        {

        }
    }
}
