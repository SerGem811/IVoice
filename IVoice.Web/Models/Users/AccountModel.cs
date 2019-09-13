using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Database;
using IVoice.Models.Common;

namespace IVoice.Models.Users
{
    public class AccountModel : BaseModel
    {
        public AccountInfoModel _account { get; set; }
        public PersonalInfoModel _personal { get; set; }
        public FavouriteModel _favourite { get; set; }
        public PersonalOptions _option { get; set; }        
        public AdInfoModel _ad { get; set; }
    }

    public class AccountInfoModel
    {
        public bool _active { get; set; }
        public string _email { get; set; }
        public string _voicer { get; set; }
        public bool _active_whisper { get; set; }
        public bool _active_voicer_update { get; set; }
        public bool _active_feeds { get; set; }
        public bool _active_gallery { get; set; }
        public bool _active_voicer { get; set; }
        public bool _active_spread { get; set; }
        public bool _active_ep { get; set; }
        public bool _active_connect { get; set; }
        public string _first { get; set; }
        public string _last { get; set; }
        public bool _is_adult { get; set; }
        public bool _adult_only { get; set; }
        public bool _public { get; set; }
        public string _secret_question { get; set; }
        public string _secret_answer { get; set; }
        public string _pwd { get; set; }
        public string _pwd_new { get; set; }
        public string _pwd_new_re { get; set; }
        
        public AccountInfoModel() { }
        public AccountInfoModel(User wrapper)
        {
            _active = wrapper.Active;
            _email = wrapper.Email;
            _voicer= wrapper.Nickname;
            _active_whisper = wrapper.ActiveWhisper;
            _active_voicer_update = wrapper.ActiveVoicerUpdates;
            _active_feeds = wrapper.ActiveIPFeeds;
            _active_gallery = wrapper.ActiveGallery;
            _active_voicer = wrapper.ActiveVoicer;
            _active_spread = wrapper.ActiveSpread;
            _active_ep = wrapper.ActiveEP;
            _active_connect = wrapper.ActiveConnect;
            _first = wrapper.FirstName;
            _last = wrapper.LastName;
            _is_adult = wrapper.IsAdult;
            _adult_only = wrapper.OnlyAdult;
            _secret_question = wrapper.SecretQuestion;
            _secret_answer = wrapper.SecretAnswer;
            _public = wrapper.isPublic;
        }

        public User ToEntity(User model)
        {
            model.Active = _active;
            model.Email = _email;
            model.Nickname = _voicer;
            model.ActiveWhisper = _active_whisper;
            model.ActiveVoicerUpdates = _active_voicer_update;
            model.ActiveIPFeeds = _active_feeds;
            model.ActiveGallery = _active_gallery;
            model.ActiveVoicer = _active_voicer;
            model.ActiveSpread = _active_spread;
            model.ActiveEP = _active_ep;
            model.ActiveConnect = _active_connect;
            model.FirstName = _first;
            model.LastName = _last;
            model.OnlyAdult = _adult_only;
            model.IsAdult = _is_adult;
            model.SecretQuestion = _secret_question;
            model.SecretAnswer = _secret_answer;
            model.isPublic = _public;

            if (_pwd == model.Password && _pwd_new.Length > 1)
            {
                model.Password = _pwd_new;
            }

            return model;
        }
    }

    public class PersonalInfoModel
    {
        public VoicerFilterModel info { get; set; }
        public string _img { get; set; }

        public PersonalInfoModel() { }
        public PersonalInfoModel(User wrapper)
        {
            if (info == null)
                info = new VoicerFilterModel();

            info._gender_id = wrapper.GenderId;
            info._country_id = wrapper.CountryId;
            info._hobby_ids = wrapper.UsersHobbyUsers.Select(x => x.UsersHobbyId).ToList();
            info._occupation_ids = wrapper.UsersOccupationsUsers.Select(x => x.UsersOccupationsId).ToList();
            info._birthday = wrapper.BirthDate;
            info._relation = wrapper.RelationshipStatus;
            info._region = wrapper.Region;
            info._language = wrapper.Language;
            info._pub_birthday = wrapper.BirthDatePublic;
            info._pub_gender = wrapper.GenderPublic;
            info._pub_country = wrapper.CountryPublic;
            info._pub_region = wrapper.RegionPublic;
            info._pub_language = wrapper.LanguagePublic;
            info._pub_occupations = wrapper.OccupationPublic;
            info._pub_relation = wrapper.RelationshipStatusPublic;
            info._pub_hobby = wrapper.InterestHobbyPublic;
            _img = wrapper.ImageURL;
        }
        public User ToEntity(User model)
        {
            model.GenderId = info._gender_id;
            model.CountryId = info._country_id;
            model.BirthDate = info._birthday;
            model.RelationshipStatus = info._relation;
            model.Region = info._region;
            model.Language = info._language;
            model.BirthDatePublic = info._pub_birthday;
            model.GenderPublic = info._pub_gender;
            model.CountryPublic = info._pub_country;
            model.RegionPublic = info._pub_region;
            model.LanguagePublic = info._pub_language;
            model.OccupationPublic = info._pub_occupations;
            model.RelationshipStatusPublic = info._pub_relation;
            model.InterestHobbyPublic = info._pub_hobby;
            return model;
        }
    }

    public class FavouriteModel
    {
        public string _music { get; set; }
        public string _games { get; set; }
        public string _sports { get; set; }
        public string _vehicle { get; set; }
        public string _tv { get; set; }
        public string _restaurant { get; set; }
        public string _film { get; set; }
        public string _brand { get; set; }
        public string _other { get; set; }
        public string _about { get; set; }
        public bool _pub_music{ get; set; }
        public bool _pub_games { get; set; }
        public bool _pub_sports { get; set; }
        public bool _pub_vehicle { get; set; }
        public bool _pub_tv { get; set; }
        public bool _pub_restaurant { get; set; }
        public bool _pub_film { get; set; }
        public bool _pub_brand { get; set; }
        public bool _pub_other { get; set; }
        public bool _pub_about { get; set; }

        public FavouriteModel() { }
        public FavouriteModel(User wrapper)
        {
            _music = wrapper.FavouriteMusic;
            _games = wrapper.FavouriteGames;
            _sports = wrapper.FavouriteSports;
            _vehicle = wrapper.FavouriteVehicle;
            _tv = wrapper.FavouriteTV;
            _restaurant = wrapper.FavouriteRestaurant;
            _film = wrapper.FavouriteFilm;
            _brand = wrapper.FavouriteBrand;
            _other = wrapper.FavouriteOther;
            _about = wrapper.FavouriteAboutYou;
            _pub_music = wrapper.FavouriteMusicPublic;
            _pub_games = wrapper.FavouriteGamesPublic;
            _pub_sports = wrapper.FavouriteSportsPublic;
            _pub_vehicle = wrapper.FavouriteVehiclePublic;
            _pub_tv = wrapper.FavouriteTVPublic;
            _pub_restaurant = wrapper.FavouriteRestaurantPublic;
            _pub_film = wrapper.FavouriteFilmPublic;
            _pub_brand = wrapper.FavouriteBrandPublic;
            _pub_other = wrapper.FavouriteOtherPublic;
            _pub_about = wrapper.FavouriteAboutYoupublic;
        }

        public User ToEntity(User model)
        {
            model.FavouriteMusic = _music;
            model.FavouriteGames = _games;
            model.FavouriteSports = _sports;
            model.FavouriteVehicle = _vehicle;
            model.FavouriteTV = _tv;
            model.FavouriteRestaurant = _restaurant;
            model.FavouriteFilm = _film;
            model.FavouriteBrand = _brand;
            model.FavouriteOther = _other;
            model.FavouriteAboutYou = _about;
            model.FavouriteMusicPublic = _pub_music;
            model.FavouriteGamesPublic = _pub_games;
            model.FavouriteSportsPublic = _pub_sports;
            model.FavouriteVehiclePublic = _pub_vehicle;
            model.FavouriteTVPublic = _pub_tv;
            model.FavouriteRestaurantPublic = _pub_restaurant;
            model.FavouriteFilmPublic = _pub_film;
            model.FavouriteBrandPublic = _pub_brand;
            model.FavouriteOtherPublic = _pub_other;
            model.FavouriteAboutYoupublic = _pub_about;

            return model;
        }
    }

    public class PersonalOptions
    {
        public int _ip_di { get; set; }       
        public string _date_register { get; set; }
        public string _type { get; set; }
        public int _ep { get; set; }
        public decimal _cmp { get; set; }
    }

    public class AdInfoModel
    {
        public int Balance { get; set; }
        public DateTime? FullAdUntil { get; set; }

        public AdInfoModel(User user)
        {
            Balance = (int)user.CPMPoints;
            FullAdUntil = user.FullAdActiveUntil;
        }
    }
}