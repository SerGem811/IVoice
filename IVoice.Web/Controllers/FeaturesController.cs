using IVoice.Database;
using IVoice.Interfaces;
using IVoice.Models.Common;
using IVoice.Models.Features;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace IVoice.Controllers
{
    public class FeaturesController : BaseController
    {
        protected IGenericRepository<Feature> _features { get; }
        public FeaturesController(IUserRepository userRepository, IGenericRepository<Database.Feature> feature) : base(userRepository)
        {
            _features = feature;
        }

        // userId
        public ActionResult Index(int? userId)
        {
            List<Feature> list = _features.LoadAndSelect(x => x.Enabled && x.Public, x => x, false).OrderBy(x => x.Id).ToList();
            List<ImageCardModel> lst = new List<ImageCardModel>();

            foreach(Feature f in list)
            {
                lst.Add(new ImageCardModel()
                {
                    _img = f.ImagePath,
                    _label = "Public " + f.Name,
                    _link = Url.Action(f.ViewType, "Category", new { FeatureId = f.Id, UserId = userId})
                });
            }

            FeatureList m = new FeatureList() { _lst = lst };
            FillBaseModel(m);
            return View(m);
        }
    }
}