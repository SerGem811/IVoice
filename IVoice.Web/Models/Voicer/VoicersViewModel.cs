using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.Voicer
{
    public class VoicersViewModel : SearchVoicerViewModel
    {
        public List<VoicerModel> _connected { get; set; }
        public List<VoicerModel> _blocked { get; set; }
        public List<VoicerModel> _waiting { get; set; }
        public List<VoicerModel> _requested { get; set; }
    }
}