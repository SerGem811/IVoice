using IVoice.Database;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

using System.Dynamic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.IO;

using static IVoice.Helpers.Constants;

namespace IVoice.Services
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(EOneEntities _dbContext) : base(_dbContext)
        {
        }

        public List<VoicerModel> GetAllVoicerModelsByFilter(Expression<Func<User, bool>> filter, int CurrentUserId, params Sorter<User>[] sorters)
        {
            var set = PrepareSet().Where(x => true && x.Id != CurrentUserId && x.isPublic);
            if (filter != null)
                set = set.Where(filter);

            if (sorters != null)
            {
                var i = 0;
                foreach (var sorter in sorters)
                {
                    i++;
                    set = sorter.Sort(set, i > 1);
                }
            }

            var list = set.Select(x => new VoicerModel()
            {
                Id = x.Id,
                Data = x.DateRegister,
                ImagePath = x.ImageURL,
                Points = x.EPPoints,
                Type = x.Type,
                Url = "",
                Voicer = x.Nickname,
                DIIP = x.CurrentUserIPDI,
                IsConnected = x.UsersConnections.Any(y => y.Type == VoicerConnectionType.CONNECTED.ToString() && (y.UserId == CurrentUserId || y.ConnectedUserId == CurrentUserId))
            });

            return list.ToList();
        }
    }
}
