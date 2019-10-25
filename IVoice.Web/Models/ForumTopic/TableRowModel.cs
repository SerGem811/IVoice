using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.ForumTopic
{
    public class TableRowModel
    {
        public string TopicURL { get; set; }
        public string TopicName { get; set; }
        public DateTime TopicDate { get; set; }
        public string Voicer { get; set; }

        public int Replies { get; set; }
        public int Views { get; set; }

        public TableRowModel() { }
    }
}