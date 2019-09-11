using IVoice.Models.Common;
using IVoice.Models.Voicer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVoice.Models.IPSocial
{
    public class SaveIPOptionModel
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public Guid _guid { get; set; }
        public bool _feeds { get; set; }

        public int? _feature_id { get; set; }
        public int? _category_id { get; set; }

        public VoicerFilterModel _event { get; set; }
        public VoicerFilterModel _filter { get; set; }
        public string _tags { get; set; }

        public bool _public { get; set; }
        public bool _di { get; set; }
        public bool _adult { get; set; }
        

        public List<VoicerModel> _connected { get; set; }
        public List<bool> _selected { get; set; }
        public string _img { get; set; }
        public int _cover_id { get; set; }

        [AllowHtml]
        public string _style { get; set; }
        [AllowHtml]
        public string _body { get; set; }
    }
}