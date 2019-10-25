using IVoice.Database;
using IVoice.Helpers.Extensions;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.IP;
using IVoice.Models.IPSocial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IVoice.Services
{
    public class UsersIPRepository : GenericTableRepository<UsersIP, TableRowModel>, IUsersIPRepository
    {
        public UsersIPRepository(EOneEntities dbContext) : base(dbContext)
        {
        }

        public List<IPViewModel> GetAllIPSForUser(Expression<Func<UsersIP, bool>> filter, int PageNum, int PageSize, int CurrentUserId)
        {
            var set = PrepareSet().Where(filter);

            var list = set.OrderByDescending(x => x.DateAdd).Skip(PageSize * PageNum).Take(PageSize)
                            .Select(x => new IPViewModel()
                            {
                                _id = x.Id,
                                _image_path = x.UsersAttachment.Path,
                                _route = x.route,
                                _title = x.Name,
                                _voicer = x.User.Nickname,
                                _date_add = x.DateAdd,
                                _public = x.Public,

                                _comments = x.Comments,
                                _dislikes = x.Dislikes,
                                _likes = x.Likes,
                                _views = x.Views,
                                _surfs = x.Surfs,
                                _ep = x.EPPoints,
                                _user_id = x.UserId,
                                _current_like_dislike = x.UsersIPLikes.FirstOrDefault(y => y.UserId == CurrentUserId).Row,
                                _current_added_surf_id = x.UsersIPSurfs.FirstOrDefault(y => y.UserId == CurrentUserId).Id,
                                _is_updated = (x.IsUpdated != null) ? (bool)x.IsUpdated : false,
                            });

            var elements = list.ToList();

            foreach(var item in elements)
            {
                item._time_ago = Extension.getElapsedTime(item._date_add);
            }

            return elements;
        }
        /*
        public override List<Sorter<UsersIP>> GetSorters(DataTableParameters dataTableParameters)
        {
            List<Sorter<UsersIP>> list = new List<Sorter<UsersIP>>();

            if(dataTableParameters.Order != null)
            {
                foreach(var item in dataTableParameters.Order)
                {
                    Sorter<UsersIP> sorter = Sorter<UsersIP>.Get(x => x.Id, false);
                    bool asc = (item.Dir == "asc");

                    if (item.Column == 0) list.Add(Sorter<UsersIP>.Get(x => x.Name, asc));
                    else if(order)
                }
            }
        }
        */
    }
}