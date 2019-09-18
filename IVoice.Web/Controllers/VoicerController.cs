using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Database;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.Voicer;
using static IVoice.Helpers.Constants;
using IVoice.Helpers;
using IVoice.Extensions;
using IVoice.Attributes;
using IVoice.Models.Common;
using System.Linq.Expressions;

namespace IVoice.Controllers
{
    [LoginAuth]
    public class VoicerController : BaseController
    {
        protected IGenericRepository<UsersHobby> _hobbyRepository { get; }
        protected IGenericRepository<UsersOccupation> _occupationRepository { get; }
        protected IGenericRepository<Gender> _genderRepository { get; }
        protected IGenericRepository<Country> _countryRepository { get; }
        protected IUsersConnectionRepository _usersConnectionRepository { get; }

        public VoicerController(IUserRepository userRepository,
                                IUsersConnectionRepository usersConnectionRepository,
                                IGenericRepository<UsersHobby> usersHobbyRepository,
                                IGenericRepository<UsersOccupation> usersOccupationRepository,
                                IGenericRepository<Gender> genderRepository,
                                IGenericRepository<Country> countryRepository) : base(userRepository)
        {
            _usersConnectionRepository = usersConnectionRepository;
            _hobbyRepository = usersHobbyRepository;
            _genderRepository = genderRepository;
            _countryRepository = countryRepository;
            _occupationRepository = usersOccupationRepository;
        }

        public ActionResult Index(int? id)
        {
            VoicersModel model = new VoicersModel();

            int userID = _userID;
            if (id != null)
                userID = (int)id;

            if(userID != _userID)
            {
                var user = _userRepository.FirstOrDefault(x => x.Id == userID, x => x);
                if(user == null || !user.ActiveVoicer || !user.isPublic)
                {
                    // notice for permission
                    return RedirectToAction("PermissionDenied", "Home");
                }
            }

            model._connected = _usersConnectionRepository.GetAllVoicerModelsByFilter(x => x.User1.Active && x.UserId == userID && x.Type == VoicerConnectionType.CONNECTED.ToString(),
                                                                                    Sorter<UsersConnection>.Get(x => x.DateConnected, false));
            foreach (var item in model._connected)
            {
                if (!System.IO.File.Exists(HttpContext.Server.MapPath(item.ImagePath)))
                {
                    item.ImagePath = "/Images/common/no-image.jpg";
                }
            }
            if (userID == _userID)
            {
                model._blocked = _usersConnectionRepository.GetAllVoicerModelsByFilter(x => x.User1.Active && x.UserId == userID && x.Type == VoicerConnectionType.BLOCKED.ToString(),
                                                                                    Sorter<UsersConnection>.Get(x => x.DateConnected, false));

                model._waiting = _usersConnectionRepository.GetAllVoicerModelsByFilter(x => x.User1.Active && x.UserId == userID && x.Type == VoicerConnectionType.WAITING.ToString(),
                                                                                        Sorter<UsersConnection>.Get(x => x.DateConnected, false));

                model._requested = _usersConnectionRepository.GetAllVoicerModelsByFilter(x => x.User1.Active && x.UserId == userID && x.Type == VoicerConnectionType.REQUESTED.ToString(),
                                                                                        Sorter<UsersConnection>.Get(x => x.DateConnected, false));

                foreach (var item in model._blocked)
                {
                    if (!System.IO.File.Exists(HttpContext.Server.MapPath(item.ImagePath)))
                    {
                        item.ImagePath = "/Images/common/no-image.jpg";
                    }
                }

                foreach (var item in model._waiting)
                {
                    if (!System.IO.File.Exists(HttpContext.Server.MapPath(item.ImagePath)))
                    {
                        item.ImagePath = "/Images/common/no-image.jpg";
                    }
                }

                foreach (var item in model._requested)
                {
                    if (!System.IO.File.Exists(HttpContext.Server.MapPath(item.ImagePath)))
                    {
                        item.ImagePath = "/Images/common/no-image.jpg";
                    }
                }
            }

            model._filter = new VoicerFilterModel();
            model._filter._frm_type = 2;

            FillViewData();

            FillBaseModel(model);

            ViewBag.userId = _userID;
            ViewBag.currentUserId = userID;

            return View(model);
        }

        [HttpPost]
        public ActionResult cmdConnection(int VoicerID, string func)
        {
            if (func == VoicerConnectionType.CONNECTED.ToString())
            {
                var conn1 = makeConnection(_userID, VoicerID, func);
                _usersConnectionRepository.Save(conn1);
                var conn2 = makeConnection(VoicerID, _userID, func);
                _usersConnectionRepository.Save(conn2);
            }
            else if (func == VoicerConnectionType.WAITING.ToString())
            {
                var voicer = _userRepository.FirstOrDefault(x => x.Id == VoicerID, x => x, null);

                if (!voicer.ActiveConnect)
                {
                    var conn1 = makeConnection(_userID, VoicerID, VoicerConnectionType.CONNECTED.ToString());
                    _usersConnectionRepository.Save(conn1);
                    var conn2 = makeConnection(VoicerID, _userID, VoicerConnectionType.CONNECTED.ToString());
                    _usersConnectionRepository.Save(conn2);
                }
                else
                {
                    var conn1 = makeConnection(_userID, VoicerID, VoicerConnectionType.REQUESTED.ToString());
                    _usersConnectionRepository.Save(conn1);
                    var conn2 = makeConnection(VoicerID, _userID, VoicerConnectionType.WAITING.ToString());
                    _usersConnectionRepository.Save(conn2);
                }

                
            }
            else if (func == VoicerConnectionType.BLOCKED.ToString())
            {
                var conn1 = makeConnection(_userID, VoicerID, func);
                _usersConnectionRepository.Save(conn1);
            }
            else if(func == VoicerConnectionType.REMOVE.ToString())
            {
                var conn1 = _usersConnectionRepository.FirstOrDefault(x => x.UserId == _userID && x.User1.Id == VoicerID, x => x, null);
                if (conn1 != null)
                {
                    _usersConnectionRepository.Remove(conn1);
                    var conn2 = _usersConnectionRepository.FirstOrDefault(x => x.UserId == VoicerID && x.User1.Id == _userID, x => x, null);
                    if (conn2 != null)
                        _usersConnectionRepository.Remove(conn2);
                }
                else
                {
                    return Json(new Message(TMessage.FALSE), JsonRequestBehavior.AllowGet);
                }
            }
            
            return Json(new Message(TMessage.TRUE), JsonRequestBehavior.AllowGet);
        }

        public UsersConnection makeConnection(int Id, int VoicerID, string type)
        {
            var connection = _usersConnectionRepository.FirstOrDefault(x => x.UserId == Id && x.User1.Id == VoicerID, x => x, null);

            if (connection != null)
            {
                if (connection.Type != type)
                {
                    connection.Type = type;
                    connection.DateConnected = DateTime.Now;
                    if (connection.DateRequest == null)
                        connection.DateRequest = DateTime.Now;
                }
            }
            else
            {
                connection = new UsersConnection()
                {
                    UserId = Id,
                    ConnectedUserId = VoicerID,
                    DateConnected = DateTime.Now,
                    DateRequest = DateTime.Now,
                    Type = type
                };
            }
            return connection;
        }

        public ViewResult SearchVoicers(VoicersModel model)
        {
            model._result = _userRepository.GetAllVoicerModelsByFilter(model.GetFilter(new List<int>() { }), _userID, Sorter<User>.Get(x => x.Id, false));
            foreach(var m in model._result)
            {
                var v = _usersConnectionRepository.FirstOrDefault(x => x.UserId == _userID && x.User1.Id == m.Id, x => x, null);
                if(v != null)
                {
                    m.Type = v.Type;
                }
                if(!System.IO.File.Exists(HttpContext.Server.MapPath(m.ImagePath)))
                {
                    m.ImagePath = "/Images/common/no-image.jpg";
                }
            }

            if(model._filter == null)
            {
                model._filter = new VoicerFilterModel();
            }

            model._filter._frm_type = 2;

            FillViewData();
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