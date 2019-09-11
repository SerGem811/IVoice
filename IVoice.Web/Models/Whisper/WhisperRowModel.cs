using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.Whisper
{
    public class WhisperRowModel : IVoice.Helpers.IEntityBase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string VoicerName { get; set; }
        public int VoicerId { get; set; }
    }
}