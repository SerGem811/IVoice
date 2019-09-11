using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.IP
{
    public class IPViewModel
    {
        public int _id { get; set; }
        public string _image_path { get; set; }
        public string _voicer { get; set; }
        public string _title { get; set; }
        public DateTime _date_add { get; set; }
        public string _time_ago { get; set; }
        public string _route { get; set; }

        public int _views { get; set; }
        public int _comments { get; set; }
        public int _likes { get; set; }
        public int _dislikes { get; set; }
        public int _surfs { get; set; }
        public int _ep { get; set; }
        public int _user_id { get; set; }

        public string _current_like_dislike { get; set; }
        public int? _current_added_surf_id { get; set; }
    }
}