using IVoice.Database;
using IVoice.Models.IP;
using IVoice.Models.IPSocial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IVoice.Interfaces
{
    public interface IUsersIPRepository : IGenericTableRepository<UsersIP, TableRowModel>
    {
        List<IPViewModel> GetAllIPSForUser(Expression<Func<UsersIP, bool>> filter, int PageNum, int PageSize, int CurrentUserId);
    }
}
