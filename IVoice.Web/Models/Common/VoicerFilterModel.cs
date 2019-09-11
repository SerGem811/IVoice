using IVoice.Database;
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
            type = 2 then normal voicer search
            type = 3 then
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