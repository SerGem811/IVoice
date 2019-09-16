using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVoice.Models.IP
{
    public class IPModel : BaseModel
    {
        [AllowHtml]
        public string _style { get; set; }
        [AllowHtml]
        public string _body { get; set; }
    }
}