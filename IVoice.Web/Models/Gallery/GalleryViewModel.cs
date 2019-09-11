using IVoice.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.Gallery
{
    public class GalleryViewModel : BaseModel
    {
        public SelectListItem_Custom _current { get; set; }
        public List<GalleryCardModel> _items { get; set; }
        public List<SelectListItem_Custom> _folders { get; set; }
        public List<SelectListItem_Custom> _path { get; set; }
    }
}