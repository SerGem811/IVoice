using IVoice.Database;
using IVoice.Models.IpAds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Interfaces
{
    public interface IUserIPAdsRepository : IGenericRepository<UsersIPAd>
    {
        IOrderedEnumerable<IpAdModel> GetAllAdsForuser(int UserId);
    }
}