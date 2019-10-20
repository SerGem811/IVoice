using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.IP
{
    public class IPCommentsViewModel : BaseModel
    {
        public List<IPCommentsModel> _list { get; set; }
        public int _id { get; set; }
        public string _type { get; set; }
    }
}