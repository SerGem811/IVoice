using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Interfaces;

namespace IVoice.Controllers
{
    public class BasePIPController : BaseController
    {
        public BasePIPController(IUserRepository userRepository) : base(userRepository)
        {
        }
    }
}