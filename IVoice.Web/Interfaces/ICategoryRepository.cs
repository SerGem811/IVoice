using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Interfaces
{
    public interface ICategoryRepository : IGenericTableRepository<Database.Category, Models.Forum.TableRowModel>
    {
    }
}