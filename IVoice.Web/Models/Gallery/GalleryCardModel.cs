using IVoice.Helpers;
using IVoice.Models.Components.Common;
using System.Collections.Generic;

namespace IVoice.Models.Gallery
{
    public class GalleryCardModel : CardBodyModel
    {
        public GalleryItemModel _item;
        public string _truncate;
        public List<SelectListItem_Custom> _folders { get; set; }
    }
}