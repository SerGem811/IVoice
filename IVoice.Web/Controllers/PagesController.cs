using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Interfaces;

namespace IVoice.Controllers
{
    public class PagesController : BaseController
    {
        public PagesController(IUserRepository userRepository) : base(userRepository)
        {
        }

        // GET: Pages
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Payments()
        {
            return View(ReturnBaseModel());
        }

        public ActionResult Contact()
        {
            return View(ReturnBaseModel());
        }

        public ActionResult TermsConditions()
        {
            return View(ReturnBaseModel());
        }
    }
}