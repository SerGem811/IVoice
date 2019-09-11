using IVoice.Database;
using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVoice.Models.Whisper
{
    public class Create : BaseModel, ICrudModel<Database.Whisper>
    {
        public Guid _uniqueId { get; set; }
        public string _subject { get; set; }
        [AllowHtml]
        public string _message { get; set; }
        public int _voicerId { get; set; }
        public SelectList _voicers { get; set; }

        public bool IsValid()
        {
            if (_voicerId == 0)
                return false;
            else if (string.IsNullOrEmpty(_subject))
                return false;
            else if (string.IsNullOrEmpty(_message))
                return false;
            return true;
        }

        public Database.Whisper ToEntity(int userId, object objectToCast)
        {
            return new Database.Whisper()
            {
                Body = _message,
                DateSent = DateTime.Now,
                ReadReceiver = false,
                ReadSender = false,
                Title = _subject,
                UserSenderId = userId,
                UserReceiverId = _voicerId
            };
        }
    }
}