using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Interfaces;
using IVoice.Models.Common;

namespace IVoice.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUserRepository userRepository) : base(userRepository)
        {
        }

        public ActionResult Index()
        {
            CarouselModels model = new CarouselModels()
            {
                _lst = new List<CarouselModel>()
                {
                    new CarouselModel() { _img = "/Images/home/home-pip.jpg", _link = Url.Action("Index", "Features") },
                    new CarouselModel() { _img = "/Images/home/home-profile-voice.jpg", _link = Url.Action("Spreads", "User") },
                    new CarouselModel() { _img = "/Images/home/home-project-voice.jpg", _link = Url.Action("Index", "User") },
                    new CarouselModel() { _img = "/Images/home/home-yabber.jpg", _link = Url.Action("Index", "Forum") }
                }
            };
            FillBaseModel(model);

            return View(model);
        }

        public ActionResult PermissionDenied()
        {
            return View(ReturnBaseModel());
        }

        public ActionResult Error()
        {
            return View(ReturnBaseModel());
        }
    }
}