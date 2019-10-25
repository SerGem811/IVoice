using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IVoice.Database;

namespace IVoice.Models.ForumAnswers
{
    public class TableRowModel
    {
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public string ImageURL { get; set; }
        public int Posts { get; set; }

        [AllowHtml]
        public string Answer { get; set; }
        public DateTime AnswerDate { get; set; }

        public string Voicer { get; set; }

        //public bool CanLike { get; set; }
        //public string Vote { get; set; }

        public ForumAnswerVote Vote { get; set; }

        public ICollection<ForumAnswerAttachModel> Attach { get; set; }

        public TableRowModel() { }
    }

    public class ForumAnswerAttachModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
    }
}