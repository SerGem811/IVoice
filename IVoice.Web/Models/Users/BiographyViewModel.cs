using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.Users
{
    public class BiographyViewModel : BaseModel
    {
        public Database.User _entity { get; set; }
        public dynamic _spreadBox { get; set; }
        public dynamic _chatWing { get; set; }

    }
}