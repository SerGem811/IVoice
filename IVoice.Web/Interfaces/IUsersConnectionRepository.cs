using IVoice.Helpers.External;
using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IVoice.Interfaces
{
    public interface IUsersConnectionRepository : IGenericRepository<Database.UsersConnection>
    {
        List<VoicerModel> GetAllVoicerModelsByFilter(Expression<Func<Database.UsersConnection, bool>> filter, params Sorter<Database.UsersConnection>[] sorters);
        List<int> GetAllBlockedUsers(int UserId);
    }
}
