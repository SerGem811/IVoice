using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.Components.Common
{
    public class CardHeaderModel
    {
        public string _icon = "";
        public string _link = "";
        public string _label = "";
        public string _tooltip = "";
        public string _num = "";
        public string _class = "";
        public bool _isbutton = false;

        public bool _open_folder = false;
        public string _open_folder_link = "";
    }
}