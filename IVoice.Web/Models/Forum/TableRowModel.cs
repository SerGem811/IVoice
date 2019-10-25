using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.Forum
{
    public class TableRowModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Topics { get; set; }
        public int Posts { get; set; }
        public string Voicer { get; set; }
        public string LastTopicName { get; set; }
        public int? LastTopicId { get; set; }
        public DateTime? LastTopicDate { get; set; }
        public string AreaUrl { get; set; }

        public TableRowModel() { }
    }
}