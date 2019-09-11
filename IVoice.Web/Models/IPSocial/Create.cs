using IVoice.Database;
using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.IPSocial
{
    public class Create : BaseModel, ICrudModel<UsersIP>
    {
        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public UsersIP ToEntity(int userId, object objectToCast)
        {
            throw new NotImplementedException();
        }
    }
}