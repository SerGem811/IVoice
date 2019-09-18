﻿using IVoice.Database;
using IVoice.Helpers;
using IVoice.Interfaces;
using System;

namespace IVoice.Services
{
    public class UserActivityRepository : GenericRepository<UsersActivity>, IUsersActivityRepository
    {
        public UserActivityRepository(EOneEntities dbContext) : base(dbContext)
        {

        }

        public int SetActivity(string activityType, string activityOperationType, int UserId, int UsersIPId)
        {
            return Save(new UsersActivity()
            {
                Type = activityType,
                Date = DateTime.Now,
                UserId = UserId,
                UsersIPId = UsersIPId,
                RowText = activityOperationType
            });
        }
    }
}
