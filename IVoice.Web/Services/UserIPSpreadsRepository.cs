using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using IVoice.Database;
using IVoice.Helpers.Extensions;
using IVoice.Interfaces;
using IVoice.Models.IP;

namespace IVoice.Services
{
    public class UserIPSpreadsRepository : GenericRepository<UsersIPSpread>, IUserIPSpreadsRepository
    {
        public UserIPSpreadsRepository(EOneEntities dbContext) : base(dbContext)
        {

        }

        public List<IPViewModel> GetAllIPSForUser(Expression<Func<UsersIPSpread, bool>> filter, int pgNum, int pgSize, int currentUserId)
        {
            var set = PrepareSet().Where(filter);

            var list = set.OrderByDescending(x => x.Date)
                            .Skip(pgSize * pgNum).Take(pgSize)
                            .Select(x => new IPViewModel()
                            {
                                _user_id = x.UsersIP.UserId,
                                _id = x.UserIpId,
                                _image_path = x.UsersIP.UsersAttachment.Path,
                                _route = x.UsersIP.route,
                                _title = x.UsersIP.Name,
                                _voicer = x.User1.Nickname,
                                _date_add = x.Date,
                                _comments = x.UsersIP.Comments,
                                _dislikes = x.UsersIP.Dislikes,
                                _surfs = x.UsersIP.Surfs,
                                _likes = x.UsersIP.Likes,
                                _views = x.UsersIP.Views,
                                _ep = x.UsersIP.EPPoints,
                                _current_like_dislike = x.UsersIP.UsersIPLikes.FirstOrDefault(y => y.UserId == currentUserId).Type,
                                _current_added_surf_id = x.UsersIP.UsersIPSurfs.FirstOrDefault(y => y.UserId == currentUserId).Id
                            }).ToList();
            
            foreach(var v in list)
            {
                v._time_ago = Extension.getElapsedTime(v._date_add);
            }
            return list;
        }
    }
}
