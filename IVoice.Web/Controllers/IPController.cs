using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using IVoice.Database;
using IVoice.Extensions;
using IVoice.Helpers;
using IVoice.Helpers.Extensions;
using IVoice.Interfaces;
using IVoice.Models.Common;
using IVoice.Models.IP;

namespace IVoice.Controllers
{
    public class IPController : BaseController
    {
        protected IUsersConnectionRepository _usersConnectionRepository { get; }
        protected IUsersIPRepository _usersIPRepository { get; }
        protected IGenericRepository<UsersIPLike> _usersIPLikesRepository { get; }
        protected IGenericRepository<UsersIPEPPoint> _usersIPEPRepository { get; }
        protected IGenericRepository<UsersIPSurf> _usersIPSurfRepository { get; }
        protected IUsersActivityRepository _usersActivityRepository { get; }

        protected IGenericRepository<Gender> _genderRepository { get; }
        protected IGenericRepository<Country> _countryRepository { get; }
        protected IGenericRepository<UsersHobby> _hobbyRepository { get; }
        protected IGenericRepository<UsersOccupation> _occupationRepository { get; }
        protected IUsersIPCommentsRepository _usersIPCommentsRepository { get; }

        public IPController(IUserRepository userRepository,
                                IUsersConnectionRepository usersConnectionRepository,
                                IGenericRepository<UsersHobby> hobbyRepository,
                                IGenericRepository<UsersOccupation> occupationRepository,
                                IGenericRepository<Gender> genderRepository,
                                IGenericRepository<Country> countryRepository,
                                IGenericRepository<UsersIPLike> usersIPLikesRepository,
                                IGenericRepository<UsersIPEPPoint> usersIPEPRepository,
                                IGenericRepository<UsersIPSurf> usersIPSurfRepository,
                                IUsersActivityRepository usersActivityRepository,
                                IUsersIPRepository usersIPRepository,
                                IUsersIPCommentsRepository usersIPCommentsRepository) : base(userRepository)
        {
            _usersConnectionRepository = usersConnectionRepository;
            _usersIPLikesRepository = usersIPLikesRepository;
            _usersIPRepository = usersIPRepository;
            _usersIPEPRepository = usersIPEPRepository;
            _usersIPSurfRepository = usersIPSurfRepository;
            _usersActivityRepository = usersActivityRepository;

            _genderRepository = genderRepository;
            _countryRepository = countryRepository;
            _hobbyRepository = hobbyRepository;
            _occupationRepository = occupationRepository;

            _usersIPCommentsRepository = usersIPCommentsRepository;
        }

        // id : feature, secondid : categoryid, thirdid: userid
        public ActionResult Index(int? FeatureId, int? CategoryId, int? UserId)
        {
            IPListModel model = new IPListModel()
            {
                _category_id = (int)CategoryId,
                _feature_id = (int)FeatureId,
                _user_id = (UserId != null) ? (int)UserId : -1
            };

            FillBaseModel(model);

            ViewBag.currentUserID = _userID;
            
            return View(model);
        }

        [HttpPost]
        public PartialViewResult _GetList(string Name, int PageNum, int CategoryId, int FeatureId, int UserId)
        {
            IEnumerable<IPViewModel> lst = null;

            Expression<Func<UsersIP, bool>> filter = x => true;

            if (UserId == -1)
                filter = filter.And(x => x.Public && x.FeatureId == FeatureId);
            else
                filter = filter.And(x => x.FeatureId == FeatureId && x.UserId == UserId);

            if(CategoryId > 0)
            {
                filter = filter.And(x => x.CategoryId == CategoryId);
            }
            if(UserId == -1 || (_userModel._account._is_adult))
            {
                filter = filter.And(x => !x.AdultOnly);
            }

            if(!String.IsNullOrEmpty(Name))
            {
                filter = filter.And(x => x.Name.Contains(Name));
            }

            lst = _usersIPRepository.GetAllIPSForUser(filter, PageNum, 9, _userID);

            ViewBag.currentUserID = _userID;

            return PartialView("_GetIPList", lst);
        }

        // Filter View : this is for Event
        // id : fetureId 
        public ActionResult FilterIndex(int? FeatureId, int? UserId)
        {
            IPListModel model = new IPListModel()
            {
                _category_id = -1,
                _feature_id = (int)FeatureId,
                _user_id = (UserId != null) ? (int)UserId : -1,
                _filter = new VoicerFilterModel(),
            };

            model._filter._frm_type = 3;
            model._filter._frm_id = "ip-event-filter";
            model._pageNum = 0;
            FillViewData();

            FillBaseModel(model);
            return View(model);
        }

        [HttpPost]
        public PartialViewResult _GetFilteredList(IPListModel model)
        {
            IEnumerable<IPViewModel> lst = null;

            Expression<Func<UsersIP, bool>> filter = x => true;

            if (model._filter != null)
            {
                if(!string.IsNullOrEmpty(model._filter._birthday))
                {
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().BirthDate == model._filter._birthday);
                }
                if(model._filter._gender_id != null && model._filter._gender_id > 0)
                {
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().GenderId == model._filter._gender_id);
                }
                if(model._filter._country_id != null && model._filter._country_id > 0)
                {
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().CountryId == model._filter._country_id);
                }
                if(model._filter._occupation_ids != null && model._filter._occupation_ids.Count > 0)
                {
                    var val = string.Join(",", model._filter._occupation_ids);
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().OccupationByComma.Contains(val));
                }
                if(model._filter._hobby_ids != null && model._filter._hobby_ids.Count > 0)
                {
                    var val = string.Join(",", model._filter._hobby_ids);
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().HobbiesByComma.Contains(val));
                }
                if(!string.IsNullOrEmpty(model._filter._region))
                {
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().Region.ToUpper().Contains(model._filter._region.ToUpper()));
                }
                if(!string.IsNullOrEmpty(model._filter._language))
                {
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().Language.ToUpper().Contains(model._filter._language.ToUpper()));
                }
                if(!string.IsNullOrEmpty(model._filter._relation))
                {
                    filter = filter.And(x => x.UsersIPFilters.FirstOrDefault().RelationshipStatus.ToUpper().Contains(model._filter._relation.ToUpper()));
                }
            }

            if (model._user_id != -1)
                filter = filter.And(x => x.UserId == model._user_id);
            else
                filter = filter.And(x => x.Public);
            filter = filter.And(x => x.FeatureId == model._feature_id);

            lst = _usersIPRepository.GetAllIPSForUser(filter, model._pageNum, 9, _userID);

            ViewBag.currentUserID = _userID;
            return PartialView("_GetIPList", lst);
        }

        [HttpPost]
        public JsonResult SetLikeDislike(int IpId, string Type)
        {
            var like = _usersIPLikesRepository.FirstOrDefault(x => x.UsersIPId == IpId && x.UserId == _userID);
            var ip = _usersIPRepository.FirstOrDefault(x => x.Id == IpId);
            var nLike = ip.Likes;
            var nDislike = ip.Dislikes;

            if (like != null)
            {
                like.Type = Type;
                _usersIPLikesRepository.Save(like);
                if(Type == "like")
                {
                    ip.Dislikes--;
                    ip.Likes++;
                }
                else
                {
                    ip.Likes--;
                    ip.Dislikes++;
                }
                _usersIPRepository.Save(ip);
                nLike = ip.Likes;
                nDislike = ip.Dislikes;
            }
            else
            {
                _usersIPLikesRepository.Save(new UsersIPLike()
                {
                    Date = DateTime.Now,
                    Row = "",
                    Type = Type,
                    UsersIPId = IpId,
                    UserId = _userID
                });

                if(Type == "like")
                {
                    nLike++;
                }
                else
                {
                    nDislike++;
                }
            }

            var span = "";
            
            if (Type == "like")
            {
                span = "<span class='text-small no-link-text'><i class='fa fa-thumbs-up'>&nbsp;" + nLike.ToString() + "&nbsp;You liked</i></span>";
                span += "<span class='text-small blue-link padding-left-10' onclick='LikeDislikeIP(\"dislike\"," + IpId + ", this)'><i class='fa fa-thumbs-down'>&nbsp;" + nDislike + "&nbsp;Dislike</i></span>";
            }
            else if (Type == "dislike")
            {
                span = "<span class='text-small blue-link' onclick='LikeDislikeIP(\"like\"," + IpId + ", this)'><i class='fa fa-thumbs-up'>&nbsp;" + nLike + "&nbsp;Like</i></span>";
                span += "<span class='text-small no-link-text padding-left-10'><i class='fa fa-thumbs-down'>&nbsp;" + nDislike.ToString() + "&nbsp;You disliked</i></span>";
            }

            return Json(span, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddPoint(int IpId)
        {
            if(_userID > 0 && _userRepository.FirstOrDefault(x => x.Id == _userID, x => x.EPPoints, null) > 0)
            {
                _usersIPEPRepository.Save(new UsersIPEPPoint()
                {
                    Date = DateTime.Now,
                    EPPoints = 1,
                    UserId = _userID,
                    UsersIPId = IpId,
                });
                return Json(_usersIPRepository.FirstOrDefault(x => x.Id == IpId, x => x.EPPoints, null).ToString(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Failed", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult SurfIP(int IpId)
        {
            if(_userID > 0)
            {
                var item = _usersIPSurfRepository.FirstOrDefault(x => x.UsersIPId == IpId && x.UserId == _userID);
                if(item == null)
                {
                    // add to surf
                    _usersIPSurfRepository.Save(new UsersIPSurf()
                    {
                        Date = DateTime.Now,
                        UsersIPId = IpId,
                        UserId = _userID
                    });

                    // save activity
                    _usersActivityRepository.SetActivity("Activity", "Add SURF", _userID, IpId);
                }
                else
                {
                    // remove from surf
                    _usersIPSurfRepository.Remove(item);
                    _usersActivityRepository.SetActivity("Activity", "Remove SURF", _userID, IpId);
                }
                return Json(_usersIPRepository.FirstOrDefault(x => x.Id == IpId, x => x.Surfs, null).ToString(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Failed", JsonRequestBehavior.AllowGet);
            }
            
        }

        public ActionResult View(int id)
        {
            var item = _usersIPRepository.FirstOrDefault(x => x.Id == id, x => x, null);

            var model = new IPModel() {
                id = id,
                _body = item.BodyHtml,
                _style = item.BodyStyle
            };

            FillBaseModel(model);
            return View(model);
        }

        [HttpPost]
        public PartialViewResult GetCommentByIp(string type, int pos, int id)
        {
            IPCommentsViewModel model = new IPCommentsViewModel();
            model._list = _usersIPCommentsRepository.GetAllComments(type, pos, id);
            model._id = id;
            model._type = type;
            FillBaseModel(model);

            return PartialView("_GetCommentByIp", model);
        }

        [HttpPost]
        public PartialViewResult Comments(string type, int pos, int id)
        {
            IPCommentsViewModel model = new IPCommentsViewModel();
            model._list = _usersIPCommentsRepository.GetAllComments(type, pos, id);
            model._id = id;
            model._type = type;
            FillBaseModel(model);
            
            return PartialView("_Comments", model); 
        }

        [HttpPost]
        public JsonResult PostComment(string type, int pos, int ipid, string comment)
        {
            _usersIPCommentsRepository.Save(new UsersIPComment()
            {
                Comment = comment,
                Date = DateTime.Now,
                Pos = pos,
                Type = type,
                UserId = _userID,
                UsersIPId = ipid
            });

            if(_userID > 0)
            {
                _usersActivityRepository.SetActivity("ACTIVITY", "COMMENT", _userID, ipid);
            }

            return Json(new Message(TMessage.TRUE), JsonRequestBehavior.AllowGet);
        }

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