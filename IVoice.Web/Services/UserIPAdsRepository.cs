using IVoice.Database;
using IVoice.Interfaces;
using IVoice.Models.IpAds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Services
{
    public class UserIPAdsRepository : GenericRepository<UsersIPAd>, IUserIPAdsRepository
    {
        public UserIPAdsRepository(EOneEntities dbContext) : base(dbContext)
        {
        }

        public IOrderedEnumerable<IpAdModel> GetAllAdsForuser(int UserId)
        {
            var items = LoadAndSelect(x => x.Active && (x.MaxClicks == 0 || x.TotalClicks < x.MaxClicks),
                                        x => new IpAdModel
                                        {
                                            _id = x.Id,
                                            _img_path = x.UsersIP.UsersAttachment.Path,
                                            _name = x.UsersIP.Name,
                                            _order = x.Position,
                                            _voicer = x.UsersIP.User.Nickname
                                        }, false).OrderBy(x => x._order);

            return items;
        }
    }
}