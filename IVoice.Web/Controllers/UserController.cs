using System;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using IVoice.Interfaces;
using IVoice.Attributes;
using IVoice.Models.Users;
using System.Collections.Generic;
using IVoice.Helpers.Extensions;
using IVoice.Helpers.External;
using IVoice.Database;
using IVoice.Models.IP;
using IVoice.Models.Components.PersonalCard;
using IVoice.Models.Components.Common;
using IVoice.Models.Components.Tabs;
using IVoice.Models.Components;
using IVoice.Models.Gallery;
using IVoice.Helpers;
using IVoice.Models.Common;
using System.Web;
using System.IO;
using static IVoice.Helpers.Constants;
using IVoice.Extensions;

namespace IVoice.Controllers
{
    [LoginAuth]
    public class UserController : BaseController
    {
        public string _galleryPath => Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FS_USER_GALLERY_PATH"].ToString());
        public string _avatarPath => Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FS_AVATAR_PATH"].ToString());

        protected IUsersConnectionRepository _usersConnectionRepository { get; }
        protected IUsersActivityRepository _usersActivityRepository { get; }
        protected IGenericRepository<Database.Feature> _featureRepository { get; }
        protected IUserIPSpreadsRepository _userIPSpreadsRepository { get; }
        protected IGenericRepository<UsersAttachmentsAlbum> _userAttachmentsAlbumRepository { get; }
        protected IGenericRepository<UsersAttachment> _usersAttachmentRepository { get; }
        protected IGenericRepository<Country> _countryRepository { get; }
        protected IGenericRepository<Gender> _genderRepository { get; }
        protected IGenericRepository<UsersOccupation> _occupationRepository { get; }
        protected IGenericRepository<UsersHobby> _hobbyRepository { get; }
        protected IGenericRepository<UsersHobbyUser> _userHobbyRepository { get; }
        protected IGenericRepository<UsersOccupationsUser> _userOccupationRepository { get; }
        public UserController(IUserRepository userRepository,
                                IGenericRepository<Database.Feature> featureRepository,
                                IUserIPSpreadsRepository userIPSpreadsRepository,
                                IUsersActivityRepository usersActivityRepository,
                                IUsersConnectionRepository usersConnectionRepository,
                                IGenericRepository<UsersAttachmentsAlbum> usersAttachmentsAlbumRepository,
                                IGenericRepository<Country> countryRepository,
                                IGenericRepository<Gender> genderRepository,
                                IGenericRepository<UsersOccupation> occupationRepository,
                                IGenericRepository<UsersHobby> hobbyRepository,
                                IGenericRepository<UsersHobbyUser> userHobbyRepository,
                                IGenericRepository<UsersOccupationsUser> userOccupationRepository,
                                IGenericRepository<UsersAttachment> usersAttachmentRepository) : base(userRepository)
        {
            _featureRepository = featureRepository;
            _userIPSpreadsRepository = userIPSpreadsRepository;
            _usersActivityRepository = usersActivityRepository;
            _usersConnectionRepository = usersConnectionRepository;
            _userAttachmentsAlbumRepository = usersAttachmentsAlbumRepository;
            _usersAttachmentRepository = usersAttachmentRepository;

            _countryRepository = countryRepository;
            _genderRepository = genderRepository;
            _occupationRepository = occupationRepository;
            _hobbyRepository = hobbyRepository;
            _userHobbyRepository = userHobbyRepository;
            _userOccupationRepository = userOccupationRepository;
        }

        #region Login,out,register
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginModel();
            FillBaseModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsValid())
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    model._pwd = BitConverter.ToString(md5.ComputeHash(ASCIIEncoding.Default.GetBytes(model._pwd)));

                    var userId = _userRepository.FirstOrDefault(x => x.Password == model._pwd && x.Email == model._email && x.Active, x => x.Id, null);
                    Session["USER_LOGIN"] = userId;
                    if (userId > 0)
                        return RedirectToAction("Index", "Home");
                    else
                        ViewBag.error = "Incorrect account information";
                }
                else
                {
                    ViewBag.error = "Invalid input";
                }
            }
            else
            {
                ViewBag.error = "Invalid input";
            }
            FillBaseModel(model);
            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["USER_LOGIN"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            var model = new RegisterModel();
            FillBaseModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsValid())
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    model._pwd = BitConverter.ToString(md5.ComputeHash(ASCIIEncoding.Default.GetBytes(model._pwd)));
                    if (_userRepository.Save(model.ToEntity()) > 0)
                    {
                        // register
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.error = "Error while saving data";
                    }
                }
                if (!model.IsValid())
                    ViewBag.error = "Invalid input";
                if (_userRepository.FirstOrDefault(x => x.Nickname == model._voicer, x => x, null) != null)
                    ViewBag.error = "Voicer name is already taken";
                if (_userRepository.FirstOrDefault(x => x.Email == model._email, x => x, null) != null)
                    ViewBag.error = "Email is already taken";
            }

            FillBaseModel(model);
            return View(model);
        }
        #endregion

        #region Detail page
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var userRepo = _userRepository.FirstOrDefault(x => x.Id == Id, x => x, null);
            if (userRepo == null)
                return RedirectToAction("Index", "Home");

            DetailsViewModel model = new DetailsViewModel();

            List<string> lastSpreadList = _userIPSpreadsRepository.GetAllIPSForUser(x => x.UserId == this._userID, 0, int.MaxValue, this._userID)
                                            .Select(x => FormatIPForDetails(x)).ToList();

            List<string> lastActivityList = _usersActivityRepository.LoadSortAndSelect(x => x.Type == "ACTIVITY" && x.UsersIP.UserId == userRepo.Id && x.UsersIP.Public,
                                                                                        x => x, 9, Sorter<UsersActivity>.Get(x => x.Id, false))
                                                                                        .Select(x => FormatActivityForDetails(x)).ToList();

            /*List<string> lastVoicerUpdateList = _usersConnectionRepository.LoadAndSelectMany(x => x.UserId == userRepo.Id, 
                                                                                            x => x.User1.UsersActivities.Select(y => y.RowText), null);*/

            List<string> lastVoicerUpdateList = _usersConnectionRepository.LoadAndSelectMany(x => x.UserId == userRepo.Id,
                                                                                            x => x.User1.UsersActivities.Select(y => y), null).Select(x => FormatActivityForDetails(x)).ToList();


            model._features = _featureRepository.LoadAndSelect(x => x.ProfileUse && !string.IsNullOrEmpty(x.ProfileImagePath), x => new { ImagePath = x.ProfileImagePath, x.Id }, false)
                                                                                        .Select(x => new CarouselModel() { _img = x.ImagePath, _link = Url.Action("IPS","User", new { UserId = Id, FeatureId = x.Id})}).ToList();

            // Personal Card part
            dynamic pCard = new ExpandoObject();
            CardHeaderPersonalModel pHeader = new CardHeaderPersonalModel();
            pHeader._title = new CardHeaderModel() { _label = userRepo.Nickname, _link = Url.Action("Personal", "User", new { Id = userRepo.Id }) };
            pHeader._title_img = "/Images/icons/profile.png";
            if(userRepo.UsersIP != null)
            {
                pHeader._diip = new CardHeaderModel() { _label = "DI IP", _link = Url.Action("View", "IP", new { Id = userRepo.UsersIP.Id }), _tooltip = "Directory Index" };
            }
            pCard.header = pHeader;
            CardBodyPersonalModel pBody = new CardBodyPersonalModel();

            if (System.IO.File.Exists(HttpContext.Server.MapPath(userRepo.ImageURL)))
            {
                pBody._img = userRepo.ImageURL;
            }
            else
            {
                pBody._img = "/Images/common/no-image.jpg";
            }
            pBody._ep = userRepo.EPPoints;
            pBody._current = (userRepo.Id == this._userID) ? true : false;
            pBody._gallery = userRepo.ActiveGallery;
            pBody._voicers = userRepo.ActiveVoicer;
            pBody._spreads = userRepo.ActiveSpread;
            pCard.body = pBody;

            model._pcard = pCard;

            // Ad Card
            dynamic ads = new ExpandoObject();
            ads.header = new CardHeaderModel() { _label = "Ad Box", _icon = "fa fa-ad" } ;
            ads.body = new CardBodyModel() { _style = "height:350px" };
            model._ads = ads;

            // Tab
            dynamic tabs = new ExpandoObject();
            CardHeaderModel action_update_header = new CardHeaderModel() { _label = "Activity & Updates", _icon = "fa fa-flag", _num = lastActivityList.Count().ToString(),
                                                                            _class ="active", _link = "#tab_1", _open_folder = true, _open_folder_link = Url.Action("ActiveUpdateView", "IPSocial") };
            CardHeaderModel voicer_update_header = new CardHeaderModel() { _label = "Voicer Updates", _icon = "fa fa-flag", _num = lastVoicerUpdateList.Count().ToString(), _link = "#tab_2",
                                                                            _open_folder = true, _open_folder_link = Url.Action("VoicerUpdateView", "IPSocial")};
            CardHeaderModel ip_feeds_header = new CardHeaderModel() { _label = "IP Feeds", _icon = "fa fa-flag", _num = lastSpreadList.Count().ToString(), _link = "#tab_3",
                                                                            _open_folder = true, _open_folder_link = Url.Action("IPFeedView", "IPSocial")};
            tabs.header = new CardHeaderTabsModel() { _header = new List<CardHeaderModel>() { action_update_header, voicer_update_header, ip_feeds_header } };

            CardBodyListModel action_update_body = new CardBodyListModel() { _lst = lastActivityList, _class = "tab-pane active" };
            CardBodyListModel voicer_update_body = new CardBodyListModel() { _lst = lastVoicerUpdateList, _class = "tab-pane" };
            CardBodyListModel ip_feeds_body = new CardBodyListModel() { _lst = lastSpreadList, _class = "tab-pane" };
            tabs.body = new List<CardBodyListModel>() { action_update_body, voicer_update_body, ip_feeds_body };
            model._tabs = tabs;

            // Ad stream
            dynamic adstream = new ExpandoObject();
            adstream.header = new CardHeaderModel() { _label = "Adstream", _icon = "fa fa-newspaper" };
            adstream.body = new CardBodyModel() { _text = "When the website will be online we can add share buttons to different social media" };
            model._adstream = adstream;

            // Live IP
            dynamic liveIP = new ExpandoObject();
            liveIP.header = new CardHeaderModel() { _label = "Live IP", _link = Url.Action("Create", "IPSocial"), _tooltip = "create a IP, start spreading" };
            liveIP.body = new CardBodyModel() { };
            model._liveIP = liveIP;

            // Spread Box
            dynamic spreadBox = new ExpandoObject();
            spreadBox.header = new CardHeaderModel() { _icon = "fa fa-share-alt", _label = "Spread box", _link = "#", _tooltip = "Spread box"};
            spreadBox.body = new CardBodyListModel() { _lst = lastSpreadList.Take(4).ToList(), _style = "height:200px;" };
            model._spreadBox = spreadBox;

            // Chat Wing
            dynamic chatWing = new ExpandoObject();
            chatWing.header = new CardHeaderModel() { _label = "Chat Wings", _tooltip = "Chat Wings", _link = "#" };
            chatWing.body = new CardBodyModel() { _text = "Chat you've bought" };
            model._chatWing = chatWing;

            ViewBag.userID = Id;

            FillBaseModel(model);
            return View(model);
        }

        private string FormatIPForDetails(IPViewModel x)
        {
            string url_ip = Url.Action("View", "IP", new { Id = x._id });
            string url_voicer = Url.Action("Details", "User", new { Id = x._user_id });

            return "<i class='fa fa-share-alt'></i>&nbsp;" + "<a href='" + url_ip + "' title=" + x._title + "' class='link-text'>" + Extension.Truncate(x._title, 20) +
                    "</a>&nbsp;by<a href='" + url_voicer + "' class='link-text'>&nbsp;" + Extension.Truncate(x._voicer, 10) + "</a>&nbsp;<small>" + x._time_ago + "</small>";
        }

        private string FormatActivityForDetails(UsersActivity x)
        {
            //string url_ip = Url.Action("View", "IP", new { Id = x.UsersIP.route, secondid = x.UsersIPId });
            string url_ip = Url.Action("View", "IP", new { Id = x.UsersIPId });
            string url_voicer = Url.Action("Details", "User", new { Id = x.User.Id });

            var v=  "<a href='" + url_voicer + "' class='link-text'>" + Extension.Truncate(x.User.Nickname, 10) + "</a>&nbsp;" 
                            + x.RowText.ToLower() + " <a href='" + url_ip + "' class='link-text'>" + Extension.Truncate(x.UsersIP.Name, 20) + "</a>&nbsp;on&nbsp;<small>" + x.Date.ToLongDateString() + "</small>";

            return v;
        }
        #endregion

        #region Account Setting
        public ActionResult Index()
        {
            AccountModel model = new AccountModel();

            var user = _userRepository.FirstOrDefault(x => x.Id == _userID, x => x, null);

            model._account = new AccountInfoModel(user);
            model._personal = new PersonalInfoModel(user);
            model._personal.info._frm_type = 1;         // personal form
            model._favourite = new FavouriteModel(user);
            model._ad = new AdInfoModel(user);

            FillViewData();
            FillBaseModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeAvatar(HttpPostedFileBase file)
        {
            if(file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName).ToLower();

                var fileName = Path.GetFileName(file.FileName);

                if (!Directory.Exists(_avatarPath))
                    Directory.CreateDirectory(_avatarPath);

                var path = Path.Combine(_avatarPath, _userID + "_" + fileName);
                file.SaveAs(path);

                var user = _userRepository.FirstOrDefault(x => x.Id == _userID);
                user.ImageURL = "/upload/users/" + _userID + "_" + fileName;
                var id = _userRepository.Save(user);

                return Json(user.ImageURL, JsonRequestBehavior.AllowGet);
            }

            return Json(new Message(TMessage.FALSE), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveAccountInfo(AccountInfoModel accountInfo)
        {
            _userRepository.Save(accountInfo.ToEntity(_userRepository.FirstOrDefault(x => x.Id == _userID)));
            return Json(new Message(TMessage.TRUE), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SavePersonalInfo(VoicerFilterModel model)
        {
            PersonalInfoModel m = new PersonalInfoModel();
            m.info = model;
            if(_userRepository.Save(m.ToEntity(_userRepository.FirstOrDefault(x => x.Id == _userID))) > 0)
            {
                #region Hobby
                var itemsHobby = _userHobbyRepository.LoadAndSelect(x => x.UserId == _userID, x => x, false);
                var itemsHobbyListId = itemsHobby.Select(x => x.Id).ToList();

                if (model._hobby_ids == null)
                    model._hobby_ids = new List<int>() { };

                foreach (var item in itemsHobby)
                    if (!model._hobby_ids.Contains(item.Id))
                        _userHobbyRepository.Remove(item);

                foreach (var item in model._hobby_ids)
                    if (!itemsHobbyListId.Contains(item))
                        _userHobbyRepository.Save(new UsersHobbyUser()
                        {
                            UserId = _userID,
                            UsersHobbyId = item
                        });
                #endregion
                #region Occupation
                var itemsOccupation = _userOccupationRepository.LoadAndSelect(x => x.UserId == _userID, x => x, false);
                var itemsOccupationListId = itemsOccupation.Select(x => x.Id).ToList();

                if (model._occupation_ids == null)
                    model._occupation_ids = new List<int>() { };

                foreach (var item in itemsOccupation)
                    if (!model._occupation_ids.Contains(item.Id))
                        _userOccupationRepository.Remove(item);

                foreach (var item in model._occupation_ids)
                    if (!itemsOccupationListId.Contains(item))
                        _userOccupationRepository.Save(new UsersOccupationsUser()
                        {
                            UserId = _userID,
                            UsersOccupationsId = item
                        });
                #endregion
            }
            return Json(new Message(TMessage.TRUE), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveFavouriteInfo(FavouriteModel favInfo)
        {
            _userRepository.Save(favInfo.ToEntity(_userRepository.FirstOrDefault(x => x.Id == _userID)));
            return Json(new Message(TMessage.TRUE), JsonRequestBehavior.AllowGet);
        }
        #endregion

        public void FillViewData()
        {
            ViewData["countries"] = _countryRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.Name }, false).ToSelectList(x => x.Description);
            ViewData["genders"] = _genderRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.Gender1 }, false).ToSelectList(x => x.Description);
            ViewData["hobbies"] = _hobbyRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.HobbyName }, false).ToSelectList(x => x.Description);
            ViewData["occupations"] = _occupationRepository.LoadSortAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.Occupation },
                                                                                    Helpers.External.Sorter<UsersOccupation>.Get(x => x.OrderBy, true)).ToSelectList<SelectListItem_Custom>(null);
        }
    }
}