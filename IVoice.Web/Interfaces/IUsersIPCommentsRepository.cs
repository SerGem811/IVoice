using IVoice.Database;
using IVoice.Models.IP;
using System.Collections.Generic;

namespace IVoice.Interfaces
{
    public interface IUsersIPCommentsRepository : IGenericRepository<UsersIPComment>
    {
        List<IPCommentsModel> GetAllComments(string type, int pos, int IpId);
    }
}