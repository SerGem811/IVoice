using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.IPSocial
{
    public class TableRowModel
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public string IPImage { get; set; }
        public DateTime? Date { get; set; }
        public int Views { get; set; }
        public int MaxClicks { get; set; }
        public string Status { get; set; }
        public int Position { get; set; }

    }
}