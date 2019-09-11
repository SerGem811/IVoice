using System;
using System.Collections.Generic;

namespace IVoice.Models.Common
{
    public class UploadModel
    {
        public Guid UniqueId { get; set; }
        public List<HiddenModel> _hiddens { get; set; }
        public string _function { get; set; }
        public string _div_id { get; set; }
        public string _input_file { get; set; }
    }
}