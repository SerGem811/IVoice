using IVoice.Database;
using IVoice.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace IVoice.Models.Common
{
    public class VoicerFilterModel
    {
        /*type of VoicerFilterModel in used, 
            type = 1 then personal info model in settings, 
            type = 2 then normal voicer filter
            type = 3 then event filter
            type = 4 then normal voicer view
            type = 5 then event view
        */
        public int _frm_type;
        public string _birthday { get; set; }
        public bool _pub_birthday { get; set; }

        public int? _gender_id { get; set; }
        public bool _pub_gender { get; set; }

        public int? _country_id { get; set; }
        public bool _pub_country { get; set; }

        public string _region { get; set; }
        public bool _pub_region { get; set; }

        public string _language { get; set; }
        public bool _pub_language { get; set; }

        public List<int> _occupation_ids { get; set; }
        public bool _pub_occupations { get; set; }

        public string _relation { get; set; }
        public bool _pub_relation { get; set; }

        public List<int> _hobby_ids { get; set; }
        public bool _pub_hobby { get; set; }

        public string _type { get; set; }

        public string _frm_id { get; set; }

        public VoicerFilterModel()
        {
            _birthday = "";
            _gender_id = -1;
            _country_id = -1;
            _region = "";
            _language = "";
            _occupation_ids = new List<int>();
            _relation = "";
            _hobby_ids = new List<int>();
        }

        public bool isEmpty()
        {
            if (!string.IsNullOrEmpty(_birthday))
                return false;
            if (_gender_id != null && _gender_id != -1)
                return false;
            if (_country_id != null && _country_id != -1)
                return false;
            if (!string.IsNullOrEmpty(_region))
                return false;
            if (!string.IsNullOrEmpty(_language))
                return false;
            if (_occupation_ids.Count() > 0)
                return false;
            if (_hobby_ids.Count() > 0)
                return false;

            return true;
        }

        public Expression<Func<User, bool>> GetFilter(List<int> blockedUsers)
        {
            Expression<Func<User, bool>> filter = x => !blockedUsers.Contains(x.Id) && x.Active;

            if (!string.IsNullOrEmpty(_birthday))
                filter = filter.And(x => x.BirthDate == _birthday);
            if (_gender_id != null && _gender_id > 0)
                filter = filter.And(x => x.GenderId == _gender_id);
            if (_country_id!= null && _country_id > 0)
                filter = filter.And(x => x.CountryId == _country_id);
            if (!_occupation_ids.IsEmpty())
                filter = filter.And(x => x.UsersOccupationsUsers.Any(y => _occupation_ids.Contains(y.UsersOccupationsId)));
            if (!_hobby_ids.IsEmpty())
                filter = filter.And(x => x.UsersHobbyUsers.Any(y => _hobby_ids.Contains(y.UsersHobbyId)));
            if (!string.IsNullOrEmpty(_region))
                filter = filter.And(x => x.Region.ToUpper().Contains(_region.ToUpper()));
            if (!string.IsNullOrEmpty(_language))
                filter = filter.And(x => x.Language.ToUpper().Contains(_language.ToUpper()));
            if (!string.IsNullOrEmpty(_relation))
                filter = filter.And(x => x.RelationshipStatus.ToUpper().Contains(_relation.ToUpper()));

            return filter;
        }

        public UsersIPFilter ToUserIIPFilterEntity(int userIPId)
        {
            string occupations = null;
            string hobbies = null;
            if(_occupation_ids != null && _occupation_ids.Count > 0)
            {
                occupations = string.Join(", ", _occupation_ids);
            }
            if(_hobby_ids != null && _hobby_ids.Count > 0)
            {
                hobbies = string.Join(", ", _hobby_ids);
            }

            return new UsersIPFilter {
                BirthDate = _birthday,
                CountryId = _country_id,
                GenderId = _gender_id,
                Language = _language,
                Region = _region,
                RelationshipStatus = _relation,
                UsersIPId = userIPId,
                OccupationByComma = occupations,
                HobbiesByComma = hobbies
            };
        }
    }
}