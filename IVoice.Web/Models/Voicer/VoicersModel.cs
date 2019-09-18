using IVoice.Database;
using IVoice.Helpers.Extensions;
using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace IVoice.Models.Voicer
{
    public class VoicersModel : BaseModel
    {
        public List<VoicerModel> _connected { get; set; }
        public List<VoicerModel> _blocked { get; set; }
        public List<VoicerModel> _waiting { get; set; }
        public List<VoicerModel> _requested { get; set; }

        public VoicerFilterModel _filter { get; set; }
        public string _free { get; set; }
        public List<VoicerModel> _result { get; set; }


        public Expression<Func<User, bool>> GetFilter(List<int> exclude)
        {
            Expression<Func<Database.User, bool>> filter = x => x.Active && !exclude.Contains(x.Id) && x.isPublic;

            if (!string.IsNullOrEmpty(_free))
            {
                string str = _free.ToUpper();
                filter = filter.And(x => x.Nickname.ToUpper().Contains(str) || x.Gender.Gender1.ToUpper().Contains(str) || x.Country.Name.ToUpper().Contains(str)
                                        || x.Region.ToUpper().Contains(str) || x.Language.ToUpper().Contains(str)
                                        || x.RelationshipStatus.ToUpper().Contains(str));
            }
            else if(_filter != null)
            {
                
                if (!string.IsNullOrEmpty(_filter._birthday))
                    filter = filter.And(x => x.BirthDate == _filter._birthday);
                if (_filter._gender_id != null && _filter._gender_id > 0)
                    filter = filter.And(x => x.GenderId == _filter._gender_id);
                if (_filter._country_id != null && _filter._country_id > 0)
                    filter = filter.And(x => x.CountryId == _filter._country_id);
                if (!_filter._occupation_ids.IsEmpty())
                    filter = filter.And(x => x.UsersOccupationsUsers.Any(y => _filter._occupation_ids.Contains(y.UsersOccupationsId)));
                if (!_filter._hobby_ids.IsEmpty())
                    filter = filter.And(x => x.UsersHobbyUsers.Any(y => _filter._hobby_ids.Contains(y.UsersHobbyId)));
                if (!string.IsNullOrEmpty(_filter._region))
                    filter = filter.And(x => x.Region.ToUpper().Contains(_filter._region.ToUpper()));
                if (!string.IsNullOrEmpty(_filter._language))
                    filter = filter.And(x => x.Language.ToUpper().Contains(_filter._language.ToUpper()));
                if (!string.IsNullOrEmpty(_filter._relation))
                    filter = filter.And(x => x.RelationshipStatus.ToUpper().Contains(_filter._relation.ToUpper()));
            }

            return filter;
        }
    }
}