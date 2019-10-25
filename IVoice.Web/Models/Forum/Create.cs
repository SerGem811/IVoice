using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.Forum
{
    public class Create : BaseModel, ICrudModel<Database.Category>
    {
        public string AreaName { get; set; }
        public string Description { get; set; }


        public bool IsValid()
        {
            if (string.IsNullOrEmpty(AreaName))
                return false;
            else if (string.IsNullOrEmpty(Description))
                return false;

            return true;
        }

        public Database.Category ToEntity(int LoggedUserId, object ObjectToCast)
        {
            return new Database.Category()
            {
                Name = AreaName,
                Description = Description,
                OnlyForum = true,
                Active = true,
                DateCreated = DateTime.Now,
                UserIdCreate = LoggedUserId,
                ImagePath = null,
            };
        }
    }
}