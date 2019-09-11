using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.Whisper
{
    public class DetailViewModel : BaseModel
    {
        public Database.Whisper _entity { get; set; }
    }
}