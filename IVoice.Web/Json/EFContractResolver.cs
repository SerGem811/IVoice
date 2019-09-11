using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Json
{
    public class EFContractResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            //if (typeof(INHibernateProxy).IsAssignableFrom(objectType) || typeof(IProxy).IsAssignableFrom(objectType))
            //    return base.CreateContract(objectType.BaseType);
            return base.CreateContract(objectType);
        }
    }
}