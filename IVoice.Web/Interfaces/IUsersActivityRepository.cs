﻿using IVoice.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVoice.Interfaces
{
    public interface IUsersActivityRepository : IGenericRepository<Database.UsersActivity>
    {
        int SetActivity(string activityType, string activityOperationType, int UserId, int UsersIPId);
    }
}
