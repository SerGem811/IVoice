using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.IPSocial
{
    public class SpreadViewModel
    {
        public int _id { get; set; }
        public VoicerFilterModel _filter { get; set; }
        public List<VoicerModel> _connected { get; set; }
        public List<bool> _selected { get; set; }
    }
}