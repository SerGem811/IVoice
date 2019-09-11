using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVoice.Models
{
    public class BaseModel
    {
        public LoggedUser _user { get; set; }
    }

    public class LoggedUser
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Voicer { get; set; }

        public LoggedUser() { }
    }
}
