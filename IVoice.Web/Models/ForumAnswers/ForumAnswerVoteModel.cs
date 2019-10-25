using IVoice.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.ForumAnswers
{
    public class ForumAnswerVoteModel
    {
        public int AnswerId { get; set; }
        public int UserId { get; set; }

        public bool Like { get; set; }

        public string LikeVote { get; set; }

        public DateTime VoteDate { get; set; }

        public ForumAnswerVote ToEntity()
        {
            VoteDate = DateTime.Now;
            LikeVote = "<i class=\"fa fa-thumbs-up\"></i>&nbsp;Like";
            int points = 1;
            if (!Like)
            {
                LikeVote = "<i class=\"fa fa-thumbs-down\"></i>&nbsp;Dislike";
                points = -1;
            }

            return new ForumAnswerVote
            {
                AnswerId = AnswerId,
                Vote = LikeVote,
                Points = points,
                VoteDate = VoteDate,
                UserId = UserId,
            };
        }
    }
}