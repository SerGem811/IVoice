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
                                IUsersIPRepository usersIPRepository) : base(userRepository)
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
        }

        // id : featureID, secondid : categoryID
        public ActionResult Index(int id, int secondid)
        {
            IPListModel model = new IPListModel()
            {
                _category_id = secondid,
                _feature_id = id,
            };
            
            FillBaseModel(model);
            return View(model);
        }

        [HttpPost]
        public PartialViewResult _GetList(string Name, int PageNum, int CategoryId, int FeatureId)
        {
            IEnumerable<IPViewModel> lst = null;

            Expression<Func<UsersIP, bool>> filter = x => true;

            filter = filter.And(x => x.Public && x.FeatureId == FeatureId);

            if(CategoryId > 0)
            {
                filter = filter.And(x => x.CategoryId == CategoryId);
            }
            if(_userID == 0 || _userModel._account._is_adult)
            {
                filter = filter.And(x => !x.AdultOnly);
            }

            if(!String.IsNullOrEmpty(Name))
            {
                filter = filter.And(x => x.Name.Contains(Name));
            }
            lst = _usersIPRepository.GetAllIPSForUser(filter, PageNum, 9, _userID);
            ViewBag.userID = _userID;
            return PartialView("_GetIPList", lst);
        }

        // Filter View : this is for Event
        // id : fetureId 
        public ActionResult FilterIndex(int id)
        {
            IPListModel model = new IPListModel()
            {
                _category_id = -1,
                _feature_id = id,
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

            lst = _usersIPRepository.GetAllIPSForUser(filter, model._pageNum, 9, _userID);

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
                    _usersActivityRepository.SetActivity("Activity", "Add SURF", IpId, _userID);
                }
                else
                {
                    // remove from surf
                    _usersIPSurfRepository.Remove(item);
                    _usersActivityRepository.SetActivity("Activity", "Remove SURF", IpId, _userID);
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
                _body = item.BodyHtml,
                _style = item.BodyStyle
            };

            FillBaseModel(model);
            return View(model);
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