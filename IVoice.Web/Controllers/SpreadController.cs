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

        public ActionResult Index(int? id)
        {
            int userId = _userID;
            if(id != null)
            {
                userId = (int)id;
            }

            if(userId != _userID)
            {
                var userRepo = _userRepository.FirstOrDefault(x => x.Id == userId, x => x);
                if(userRepo == null || !userRepo.ActiveSpread || !userRepo.isPublic)
                {
                    return RedirectToAction("PermissionDenied", "Home");
                }
            }
            
            ViewBag.selectedUserID = userId;
            ViewBag.currentUserID = _userID;
            return View(ReturnBaseModel());
        }

        [HttpPost]
        public PartialViewResult _GetList(int PageNum, int userID)
        {
            var lst = _userIPSpreadRepository.GetAllIPSForUser(x => x.UserId == userID, PageNum, 9, _userID);

            ViewBag.currentUserID = _userID;
            ViewBag.selectedUserID = userID;
            return PartialView("_GetIPList", lst);
        }
    }
}