using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.Common 
{
    public class CarouselModels : BaseModel
    {
        public List<CarouselModel> _lst;
    }
    public class CarouselModel
    {
        public string _img { get; set; }
        public string _link { get; set; }
    }
}