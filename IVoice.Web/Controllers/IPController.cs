using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Database;
using IVoice.Extensions;
using IVoice.Helpers;
using IVoice.Interfaces;
using IVoice.Models.Common;
using IVoice.Models.IP;

namespace IVoice.Controllers
{
    public class IPController : BasePIPController
    {
        protected IGenericRepository<UsersHobby> _hobbyRepository { get; }
        protected IGenericRepository<UsersOccupation> _occupationRepository { get; }
        protected IGenericRepository<Gender> _genderRepository { get; }
        protected IGenericRepository<Country> _countryRepository { get; }
        protected IUsersConnectionRepository _usersConnectionRepository { get; }

        public IPController(IUserRepository userRepository,
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

        // id : featureID, secondid : categoryID
        public ActionResult Index(int id, int secondid)
        {
            VoicerFilterModel filter = new VoicerFilterModel();
            filter._frm_type = 2;
            IPListModel model = new IPListModel()
            {
                _category_id = secondid,
                _feature_id = id,
                _filter = filter,
            };
            FillViewData();
            FillBaseModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult GetList(IPListModel model)
        {
            return Json("Success", JsonRequestBehavior.AllowGet);
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