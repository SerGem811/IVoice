using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.Common
{
    public interface ICrudModel<TEntity>
        where TEntity : class
    {
        bool IsValid();
        TEntity ToEntity(int userId, object objectToCast);
    }
}