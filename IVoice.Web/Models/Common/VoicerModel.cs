using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVoice.Models.Common
{
    public class VoicerModel
    {
        public int Id { get; set; }
        public string Voicer { get; set; }
        public DateTime Data { get; set; }
        public int Points { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public bool IsConnected { get; set; }
        public int? DIIP { get; set; }
    }
}
