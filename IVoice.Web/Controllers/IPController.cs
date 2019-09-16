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
    public class IPController : BasePIPController
    {
        protected IUsersConnectionRepository _usersConnectionRepository { get; }
        protected IUsersIPRepository _usersIPRepository { get; }


        public IPController(IUserRepository userRepository,
                                IUsersConnectionRepository usersConnectionRepository,
                                IGenericRepository<UsersHobby> usersHobbyRepository,
                                IGenericRepository<UsersOccupation> usersOccupationRepository,
                                IGenericRepository<Gender> genderRepository,
                                IGenericRepository<Country> countryRepository,
                                IUsersIPRepository usersIPRepository) : base(userRepository)
        {
            _usersConnectionRepository = usersConnectionRepository;
            _usersIPRepository = usersIPRepository;
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
        public PartialViewResult _GetList(int PageNum, int CategoryId, int FeatureId)
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
            if(_userID > 0)
                filter = filter.And(x => x.UserId == _userID);

            lst = _usersIPRepository.GetAllIPSForUser(filter, PageNum, 9, _userID);
            ViewBag.userID = _userID;
            return PartialView("_GetIPList", lst);
        }
    }
}