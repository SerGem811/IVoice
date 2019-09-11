using IVoice.Models;
using IVoice.Models.Common;
using System;
using System.Collections.Generic;

namespace IVoice.Models.Users
{
    public class DetailsViewModel : BaseModel
    {
        public List<CarouselModel> _features { get; set; }
        public dynamic _pcard { get; set; }
        public dynamic _ads { get; set; }
        public dynamic _adstream { get; set; }
        public dynamic _tabs { get; set; }
        public dynamic _liveIP { get; set; }
        public dynamic _spreadBox { get; set; }
        public dynamic _chatWing { get; set; }

    }
}