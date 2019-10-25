using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.ForumAnswers
{
    public class Index : Create
    {
        public int AreaId { get; set; }
        public int LoggedUserId { get; set; }
    }
}