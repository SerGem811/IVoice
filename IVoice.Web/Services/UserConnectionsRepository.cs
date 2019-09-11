using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IVoice.Database;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.Common;
using static IVoice.Helpers.Constants;

namespace IVoice.Services
{
    public class UsersConnectionsRepository : GenericRepository<UsersConnection>, IUsersConnectionRepository
    {
        public UsersConnectionsRepository(EOneEntities dbContext) : base(dbContext)
        {
        }

        public List<int> GetAllBlockedUsers(int UserId)
        {
            var blockedUsersTuple = LoadAndSelect(x => x.Type == VoicerConnectionType.BLOCKED.ToString() 
                                                    && (x.UserId == UserId || x.ConnectedUserId == UserId), 
                                                    x => new { x.UserId, x.ConnectedUserId }, true);
            return blockedUsersTuple.Select(x => x.UserId).Union(blockedUsersTuple.Select(x => x.ConnectedUserId)).Union(new List<int> { UserId }).Distinct().ToList();
        }

        public List<VoicerModel> GetAllVoicerModelsByFilter(Expression<Func<UsersConnection, bool>> filter, params Sorter<UsersConnection>[] sorters)
        {
            var set = PrepareSet().Where(x => true);
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
                Id = x.ConnectedUserId,
                Data = x.DateConnected,
                ImagePath = x.User1.ImageURL,
                Points = x.User1.EPPoints,
                Type = x.Type,
                Url = "",
                Voicer = x.User1.Nickname
            });

            return list.ToList();
        }
    }
}
