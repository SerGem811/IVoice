using IVoice.Helpers.External;
using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IVoice.Interfaces
{
    public interface IUserRepository : IGenericRepository<Database.User>
    {
        List<VoicerModel> GetAllVoicerModelsByFilter(Expression<Func<Database.User, bool>> filter, int CurrentUserId, params Sorter<Database.User>[] sorters);
    }
}
