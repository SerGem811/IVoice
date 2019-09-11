using IVoice.Database;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.Whisper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Services
{
    public class WhisperRepository : GenericTableRepository<Whisper, WhisperRowModel>, IWhisperRepository
    {
        public WhisperRepository(EOneEntities dbContext) : base(dbContext)
        {
        }

        public override List<Sorter<Whisper>> GetSorters(DataTableParameters dtParams)
        {
            List<Sorter<Whisper>> list = new List<Sorter<Whisper>>();

            if(dtParams.Order != null)
            {
                foreach(var orderItem in dtParams.Order)
                {
                    Sorter<Whisper> sorter = Sorter<Whisper>.Get(x => x.DateSent, false);
                    bool asc = (orderItem.Dir == "asc");

                    if (orderItem.Column == 0)
                        list.Add(Sorter<Whisper>.Get(x => x.Id, asc));
                    else if (orderItem.Column == 1)
                        list.Add(Sorter<Whisper>.Get(x => x.DateSent, asc));
                }
            }

            if (list.Count == 0)
                list.Add(Sorter<Whisper>.Get(x => x.DateSent, false));

            return list;
        }
    }
}