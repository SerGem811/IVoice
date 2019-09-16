using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Database;
using IVoice.Extensions;
using IVoice.Helpers;
using IVoice.Helpers.Extensions;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.Common;
using IVoice.Models.IPSocial;
using IVoice.Models.Voicer;
using Newtonsoft.Json.Linq;
using static IVoice.Helpers.Constants;

namespace IVoice.Controllers
{
    public class IPSocialController : CrudForumController
        <UsersIP,
        IUsersIPRepository,
        Create>
    {
        protected IGenericRepository<Feature> _featureRepository { get; }
        protected IGenericRepository<Category> _categoryRepository { get; }
        protected IGenericRepository<Gender> _genderRepository { get; }
        protected IGenericRepository<UsersIPTag> _userIPTagRepository { get; }
        protected IGenericRepository<IPTag> _ipTagRepository { get; set; }
        protected IGenericRepository<Country> _countryRepository { get; }
        protected IGenericRepository<UsersHobby> _hobbyRepository { get; }
        protected IGenericRepository<UsersOccupation> _occupationRepository { get; }
        protected IGenericRepository<UsersIPFilter> _userIPFilterRepository { get; }
        protected IGenericRepository<UsersIPSpread> _userIPSpreadRepository { get; }
        protected IUsersConnectionRepository _connectionRepository { get; }
        protected IUserIPAdsRepository _userIPAdsRepository { get; }
        protected IGenericRepository<UsersActivity> _userActivityRepository { get; set; }

        public IPSocialController(IUserRepository userRepository,
                                    IUserAttachmentsRepository userAttachmentsRepository,
                                    IUsersIPRepository userIPRepository,
                                    IGenericRepository<Feature> featureRepository,
                                    IGenericRepository<Category> categoryRepository,
                                    IGenericRepository<Gender> genderRepository,
                                    IGenericRepository<UsersIPTag> userIPTagRepository,
                                    IGenericRepository<IPTag> iptagRepository,
                                    IGenericRepository<Country> countryRepository,
                                    IGenericRepository<UsersHobby> hobbyRepository,
                                    IGenericRepository<UsersOccupation> occupationRepository,
                                    IGenericRepository<UsersIPFilter> ipFilterRepository,
                                    IGenericRepository<UsersIPSpread> userIPSpreadRepository,
                                    IUserIPAdsRepository userIPAdsRepository,
                                    IUsersConnectionRepository connectionRepository,
                                    IGenericRepository<UsersActivity> usersActivityRepository
            ) : base(userRepository, userAttachmentsRepository, userIPRepository)
        {
            _featureRepository = featureRepository;
            _categoryRepository = categoryRepository;
            _userIPTagRepository = userIPTagRepository;
            _ipTagRepository = iptagRepository;
            _connectionRepository = connectionRepository;
            _hobbyRepository = hobbyRepository;
            _occupationRepository = occupationRepository;
            _genderRepository = genderRepository;
            _countryRepository = countryRepository;
            _userIPFilterRepository = ipFilterRepository;
            _userIPSpreadRepository = userIPSpreadRepository;
            _userIPAdsRepository = userIPAdsRepository;
            _userActivityRepository = usersActivityRepository;
        }

        public string _cover_path => Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FS_IP_COVER_PATH"].ToString());
        public string _ip_path => Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FS_IP_IMAGE_PATH"].ToString());


        public override ActionResult Create()
        {
            ViewBag.userId = _userID;

            return View(ReturnBaseModel());
        }

        [HttpPost]
        public JsonResult UploadIPImage(HttpPostedFileBase file, Guid guid)
        {
            try
            {
                var fileName = "";
                if (file != null && file.ContentLength > 0)
                {
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    fileName = guid + "_" + Path.GetFileName(file.FileName);
                    if (!Directory.Exists(_ip_path))
                        Directory.CreateDirectory(_ip_path);

                    var path = Path.Combine(_ip_path, fileName);
                    file.SaveAs(path);

                    var id = _userAttachmentsRepository.Save(new UsersAttachment()
                    {
                        Active = false,
                        DateAdded = DateTime.Now,
                        FileName = file.FileName,
                        Path = "/upload/ip/" + fileName,
                        UserId = _userID,
                        Visibity = Visibility.PRIVATE.ToString(),
                        UniqueId = guid
                    });
                }

                return Json("/upload/ip/" + fileName, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed", JsonRequestBehavior.AllowGet);
            }
            
        }

        public PartialViewResult _SaveIP(int Id)
        {
            if(Id != -1)
            {

            }

            FillViewData();

            ViewData["features"] = _featureRepository.LoadSortAndSelect(x => x.ForIP,
                                                                    x => new SelectListItem_Custom { Id = x.Id, Description = x.Name },
                                                                    Sorter<Feature>.Get(x => x.Id, true)).ToSelectList(x => x.Description);
            ViewData["categories"] = _categoryRepository.LoadAndSelect(x => x.Active,
                                                                x => new SelectListItem_Custom { Id = x.Id, Description = x.Name }, false).ToSelectList(x => x.Description);

            var model = new SaveIPOptionModel()
            {
                _guid = Guid.NewGuid(),

                _adult = false,
                _di = false,
                _public = false,
                _filter = new VoicerFilterModel() { _frm_id = "voicerfilter_filter" },
                _event = new VoicerFilterModel() { _frm_id = "voicerfilter_event" },
                _connected = _connectionRepository.GetAllVoicerModelsByFilter(x => x.User1.Active && x.User1.ActiveIPFeeds && x.UserId == _userID && x.Type == VoicerConnectionType.CONNECTED.ToString(),
                                                                                Sorter<UsersConnection>.Get(x => x.DateConnected, false)),
                _img = "/Images/common/no-image.jpg",
            };

            model._selected = new List<bool>();
            foreach (var item in model._connected)
            {
                model._selected.Add(true);
            }
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult GetCategoryTypeByFeature(int FeatureId)
        {
            var item = _featureRepository.FirstOrDefault(x => x.Id == FeatureId, x => x, null);
            var categories = _categoryRepository.LoadSortAndSelect(x => x.FeatureId == FeatureId && x.Enabled && x.OnlyForum == false && x.ForIP,
                                                                    x => new SelectListItem_Custom { Id = x.Id, Description = x.Description },
                                                                    Sorter<Category>.Get(x => x.Name, true));
            if(item.ViewType == "Index" && (categories == null ||categories.Count == 0))
            {
                categories = _categoryRepository.LoadSortAndSelect(x => x.FeatureId == null && x.Active && x.Enabled && x.OnlyForum == false && x.ForIP,
                                                                    x => new SelectListItem_Custom { Id = x.Id, Description = x.Name },
                                                                    Sorter<Category>.Get(x => x.Name, true));
            }

            return Json(new { ViewType = item.ViewType, Categories = categories }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult addCoverImage(HttpPostedFileBase file, Guid UniqueId)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string extension = Path.GetExtension(file.FileName).ToLower();

                    var fileName = UniqueId + "_" + Path.GetFileName(file.FileName);

                    if (!Directory.Exists(_cover_path))
                        Directory.CreateDirectory(_cover_path);

                    var path = Path.Combine(_cover_path, fileName);
                    file.SaveAs(path);

                    var id = _userAttachmentsRepository.Save(new UsersAttachment()
                    {
                        Active = false,
                        DateAdded = DateTime.Now,
                        FileName = file.FileName, //the real FS file name has UniqueId
                        Path = "/upload/ip/cover/" + fileName,
                        UserId = _userID,
                        Visibity = "Private",
                        UniqueId = UniqueId,
                    });

                    var res = new JObject();
                    res["id"] = id;
                    res["cover"] = "/upload/ip/cover/" + fileName;

                    return Json(res, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return Json("Failed", JsonRequestBehavior.AllowGet);
            }

            return Json("Failed", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveIP(SaveIPOptionModel model)
        {
            // validation check
            if(String.IsNullOrEmpty(model._name))
            {
                return Json("Name is not valid", JsonRequestBehavior.AllowGet);
            }
            if(model._feature_id == null || model._feature_id <= 0)
            {
                return Json("Select the feature please", JsonRequestBehavior.AllowGet);
            }
            if(model._category_id == null || model._category_id <= 0)
            {
                return Json("Select the category please", JsonRequestBehavior.AllowGet);
            }
            if (model._cover_id <= 0)
            {
                return Json("Select the cover image please", JsonRequestBehavior.AllowGet);
            }

            var user = _userRepository.FirstOrDefault(x => x.Id == _userID);

            int UserIpId = _crudRepository.Save(new UsersIP()
            {
                AdultOnly = model._adult,
                BodyHtml = model._body,
                BodyStyle = model._style,
                CategoryId = model._category_id,
                FeatureId = (int)model._feature_id,
                DateAdd = DateTime.Now,
                UserId = _userID,
                Name = model._name,
                Public = model._public,
                route = model._name.ToRoute(),
                UserAttachmentId = model._cover_id,
                Views = 0,
                Comments =0,
                Dislikes = 0,
                EPPoints = 0,
                Likes = 0,
                Surfs = 0
            });

            if (model._di)
            {
                user.CurrentUserIPDI = UserIpId;
                _userRepository.Save(user);
            }
            // save Tags
            
            // event
            if(model._feature_id == EVENT_ID)
            {
                _userIPFilterRepository.Save(model._filter.ToUserIIPFilterEntity(UserIpId));               
            }

            // spread to voicer
            SpreadToUser(UserIpId, model._selected);

            // set activity
                _userActivityRepository.Save(new UsersActivity()
                {
                    Date = DateTime.Now,
                    Type = "ACTIVITY",
                    UsersIPId = UserIpId,
                    UserId = _userID,
                    RowText = "Spread"
                });

            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public void SpreadToUser(int id, List<bool> options)
        {
            // spread to voicer
            var connected = _connectionRepository.GetAllVoicerModelsByFilter(x => x.User1.Active && x.User1.ActiveIPFeeds && x.UserId == _userID && x.Type == VoicerConnectionType.CONNECTED.ToString(),
                                                                                Sorter<UsersConnection>.Get(x => x.DateConnected, false));

            var index = 0;
            foreach (var item in connected)
            {
                if (options[index])
                {
                    _userIPSpreadRepository.Save(new UsersIPSpread()
                    {
                        Date = DateTime.Now,
                        UserId = item.Id,
                        UserIpId = id,
                        UserSentId = _userID,
                    });
                }
                index++;
            }
        }

        public SearchVoicerViewModel GetSearchVoicerViewModel(SearchFormType searchFormType, int UserIpId)
        {
            return new SearchVoicerViewModel()
            {
                CountryList = _countryRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.Name }, false).ToSelectList(x => x.Description),
                GenderList = _genderRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.Gender1 }, false).ToSelectList(x => x.Description),
                HobbyList = _hobbyRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.HobbyName }, false).ToSelectList(x => x.Description),
                OccupationProfessionList = _occupationRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.Occupation }, false).ToSelectList(x => x.Description),
                SearchFormType = searchFormType,
                UserIpId = UserIpId
            };
        }

        public void FillViewData()
        {
            ViewData["countries"] = _countryRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.Name }, false).ToSelectList(x => x.Description);
            ViewData["genders"] = _genderRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.Gender1 }, false).ToSelectList(x => x.Description);
            ViewData["hobbies"] = _hobbyRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.HobbyName }, false).ToSelectList(x => x.Description);
            ViewData["occupations"] = _occupationRepository.LoadSortAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.Occupation },
                                                                                    Helpers.External.Sorter<UsersOccupation>.Get(x => x.OrderBy, true)).ToSelectList<SelectListItem_Custom>(null);
        }

        [HttpPost]
        public PartialViewResult _SpreadIP(int IPId)
        {
            var lst = _countryRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.Name }, false).ToSelectList(x => x.Description);

            FillViewData();

            var model = new SpreadViewModel()
            {
                _id = IPId,
                _filter = new VoicerFilterModel() { _frm_id = "voicerfilter_filter" },
                _connected = _connectionRepository.GetAllVoicerModelsByFilter(x => x.User1.Active && x.User1.ActiveIPFeeds && x.UserId == _userID && x.Type == VoicerConnectionType.CONNECTED.ToString(),
                                                                                Sorter<UsersConnection>.Get(x => x.DateConnected, false)),
            };
            model._selected = new List<bool>();
            foreach (var item in model._connected)
            {
                model._selected.Add(true);
            }

            return PartialView("_SpreadForm", model);
        }

        [HttpPost]
        public ActionResult SpreadIP(SpreadViewModel model)
        {
            try
            {
                SpreadToUser(model._id, model._selected);
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Failed", JsonRequestBehavior.AllowGet);
            }
        }
    }
}