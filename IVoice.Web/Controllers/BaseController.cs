using IVoice.Helpers.Extensions;
using IVoice.Interfaces;
using IVoice.Models;
using IVoice.Services;
using IVoice.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Models.Users;
using IVoice.Models.Common;

namespace IVoice.Controllers
{
    public abstract class BaseController : Controller
    {
        public readonly IUserRepository _userRepository;
        public BaseController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string GetIP
        {
            get
            {
                var IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(IPAdd))
                    IPAdd = Request.ServerVariables["REMOTE_ADDR"];
                return IPAdd.ToString();
            }
        }

        #region Logged User
        public int _userID
        {
            get
            {
                int IdUser = 0;
                try { IdUser = Session["USER_LOGIN"].ToString().ToInt(); }
                catch { }
                return IdUser;
            }
            set { Session["USER_LOGIN"] = value; }
        }

        public AccountModel _userModel
        {
            get
            {
                return _userRepository.FirstOrDefault<AccountModel>(x => x.Id == _userID, x => new AccountModel() {
                    _account = new AccountInfoModel() {
                        _active = x.Active,
                        _active_feeds = x.ActiveIPFeeds,
                        _active_voicer_update = x.ActiveVoicerUpdates,
                        _active_voicer = x.ActiveVoicer,
                        _active_gallery = x.ActiveGallery,
                        _active_spread = x.ActiveSpread,
                        _active_whisper = x.ActiveWhisper,
                        _active_ep = x.ActiveEP,
                        _is_adult = x.IsAdult,
                        _adult_only = x.OnlyAdult,
                        _email = x.Email,
                        _first = x.FirstName,
                        _last = x.LastName,
                        _public = x.isPublic,
                        _pwd = x.Password,
                        _secret_question = x.SecretQuestion,
                        _secret_answer = x.SecretAnswer,
                        _voicer = x.Nickname
                    },
                    _personal = new PersonalInfoModel()
                    {
                        info = new VoicerFilterModel()
                        {
                            _pub_birthday = x.BirthDatePublic,
                            _birthday = x.BirthDate,
                            _pub_country = x.CountryPublic,
                            _country_id = x.CountryId,
                            _pub_gender = x.GenderPublic,
                            _gender_id = x.GenderId,
                            _pub_hobby = x.InterestHobbyPublic,
                            _hobby_ids = x.UsersHobbyUsers.Select(y => y.UsersHobbyId).ToList(),
                            _pub_language = x.LanguagePublic,
                            _language = x.Language,
                            _pub_occupations = x.OccupationPublic,
                            _occupation_ids = x.UsersOccupationsUsers.Select(y => y.UsersOccupationsId).ToList(),
                            _pub_region = x.RegionPublic,
                            _region = x.Region,
                            _pub_relation = x.RelationshipStatusPublic,
                            _relation = x.RelationshipStatus,
                        }
                    },

                });

            }
        }

        public LoggedUser _user
        {
            get
            {
                if (_userID > 0)
                    return _userRepository.FirstOrDefault(x => x.Id == _userID, x => new LoggedUser
                    {
                        Id = x.Id,
                        Level = x.UsersRole.RoleLevel,
                        Voicer = x.Nickname
                    });
                else return new LoggedUser();
            }
        }
        #endregion

        #region
        public BaseModel ReturnBaseModel()
        {
            BaseModel Model = new BaseModel();
            FillBaseModel(Model);
            return Model;
        }

        public void FillBaseModel(BaseModel Model)
        {
            Model._user = this._user;
        }
        #endregion

        #region Forum Search Parameter
        [HttpPost]
        public JsonResult SetSearchParams(string SearchText)
        {
            Session["SearchText"] = SearchText;
            return Json("TRUE", JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}