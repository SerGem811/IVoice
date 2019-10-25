using System;
using IVoice.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IVoice.Models.Common;

namespace IVoice.Models.ForumTopic
{
    public class Create : BaseModel, ICrudModel<Database.ForumTopic>
    {
        public int CategoryId { get; set; }
        public string TopicName { get; set; }

        [AllowHtml]
        public string TopicBody { get; set; }
        public object Attachments { get; set; }
        public Guid UniqueId { get; set; }

        public SelectList CategoryList { get; set; }


        public bool IsValid()
        {
            if (string.IsNullOrEmpty(TopicName))
                return false;
            else if (string.IsNullOrEmpty(TopicBody))
                return false;

            return true;
        }

        public Database.ForumTopic ToEntity(int LoggedUserId, object ObjectToCast)
        {
            return new Database.ForumTopic()
            {
                Active = true,
                CategoryId = CategoryId,
                Name = TopicName,
                StartDate = DateTime.Now,
                UserId = LoggedUserId,
                Replies = 0,
                Views = 0,
                LastReplyDate = DateTime.Now,
            };
        }


        public Database.ForumAnswer ToAnswerEntity(int LoggedUserId, int TopicId)
        {
            return new Database.ForumAnswer()
            {
                Active = true,
                Answer = TopicBody,
                TopicId = TopicId,
                UserId = LoggedUserId,
                AnswerDate = DateTime.Now,
            };
        }
    }
}