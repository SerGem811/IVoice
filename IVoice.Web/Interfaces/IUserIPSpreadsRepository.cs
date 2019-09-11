using IVoice.Models.IP;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IVoice.Interfaces
{
    public interface IUserIPSpreadsRepository : IGenericRepository<Database.UsersIPSpread>
    {
        List<IPViewModel> GetAllIPSForUser(Expression<Func<Database.UsersIPSpread, bool>> filter, int pgNum, int pgSize, int currentUserId);
    }
}
