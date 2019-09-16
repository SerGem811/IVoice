using IVoice.Attributes;
using IVoice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVoice.Controllers
{
    [LoginAuth]
    public class SpreadController : BaseController
    {
        protected IUserIPSpreadsRepository _userIPSpreadRepository;

        public SpreadController(IUserRepository userRepository,
                                IUserIPSpreadsRepository userIPSpreadsRepository) : base(userRepository)
        {
            _userIPSpreadRepository = userIPSpreadsRepository;
        }

        public ActionResult Index(int? UserId)
        {
            return View(ReturnBaseModel());
        }

        [HttpPost]
        public PartialViewResult _GetList(int PageNum)
        {
            var lst = _userIPSpreadRepository.GetAllIPSForUser(x => x.UserId == _userID, PageNum, 9, _userID);

            ViewBag.userID = _userID;
            return PartialView("_GetIPList", lst);
        }
    }
}