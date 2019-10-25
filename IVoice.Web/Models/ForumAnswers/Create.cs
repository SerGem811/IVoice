using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;

namespace IVoice.Models.ForumAnswers
{
    public class Create : BaseModel, ICrudModel<Database.ForumAnswer>
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        [AllowHtml]
        public string Answer { get; set; }
        public Guid UniqueId { get; set; }


        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Answer))
                return false;

            return true;
        }

        public Database.ForumAnswer ToEntity(int LoggedUserId, object ObjectToCast)
        {
            return new Database.ForumAnswer()
            {
                Active = true,
                Answer = Answer,
                AnswerDate = DateTime.Now,
                UserId = LoggedUserId,
                TopicId = TopicId
            };
        }
    }
}