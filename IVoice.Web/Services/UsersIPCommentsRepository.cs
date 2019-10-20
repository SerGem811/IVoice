using IVoice.Database;
using IVoice.Interfaces;
using IVoice.Helpers.External;
using IVoice.Models;
using IVoice.Models.IP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Services
{
    public class UsersIPCommentsRepository : GenericRepository<UsersIPComment>, IUsersIPCommentsRepository
    {
        public UsersIPCommentsRepository(EOneEntities _dbContext) : base(_dbContext)
        {
        }

        public List<IPCommentsModel> GetAllComments(string type, int pos, int IpId)
        {
            var set = PrepareSet().Where(x => x.Type == type && x.Pos == pos && x.UsersIPId == IpId);
            set = Sorter<UsersIPComment>.Get(x => x.Id, true).Sort(set, false);

            var list = set.Select(x => new IPCommentsModel()
            {
                _date = x.Date,
                _image = x.User.ImageURL,
                _text = x.Comment
            });

            return list.ToList();
        }
    }
}