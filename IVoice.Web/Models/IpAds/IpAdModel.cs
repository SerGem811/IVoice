using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.IpAds
{
    public class IpAdModel
    {
        public int _id { get; set; }
        public string _voicer { get; set; }
        public string _img_path { get; set; }
        public string _name { get; set; }
        public int _order { get; set; }
    }
}