﻿using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.IP
{
    public class IPListModel : BaseModel
    {
        public int _feature_id { get; set; }
        public int _category_id { get; set; }
        public VoicerFilterModel _filter { get; set; }
    }
}