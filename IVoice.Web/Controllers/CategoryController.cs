using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Database;
using IVoice.Interfaces;
using IVoice.Models.Category;
using IVoice.Models.Common;

namespace IVoice.Controllers
{
    public class CategoryController : BaseController
    {
        protected IGenericRepository<Feature> _featureRepository { get; set; }
        protected IGenericRepository<Category> _categoryRepository { get; set; }
        protected IGenericRepository<Gender> _genderRepository { get; set; }
        protected IGenericRepository<Country> _countryRepository { get; set; }
        protected IGenericRepository<UsersHobby> _hobbyRepository { get; set; }
        protected IGenericRepository<UsersOccupation> _occupationRepository { get; set; }

        public CategoryController(IUserRepository userRepository,
                                    IGenericRepository<Feature> featureRepository,
                                    IGenericRepository<Category> categoryRepository,
                                    IGenericRepository<Gender> genderRepository,
                                    IGenericRepository<Country> countryRepository,
                                    IGenericRepository<UsersHobby> hobbyRepository,
                                    IGenericRepository<UsersOccupation> occupationRepository) : base(userRepository)
        {
            _featureRepository = featureRepository;
            _categoryRepository = categoryRepository;
            _genderRepository = genderRepository;
            _countryRepository = countryRepository;
            _hobbyRepository = hobbyRepository;
            _occupationRepository = occupationRepository;
        }

        public ActionResult Index(int? FeatureId, int? UserId)
        {
            if(FeatureId != null && (int)FeatureId == IVoice.Helpers.Constants.EVENT_ID)
            {
                return RedirectToAction("FilterIndex", "IP", new { FeatureId = FeatureId, UserId = UserId });
            }

            var list = _categoryRepository.LoadAndSelect(x => x.Active, x => x, false).OrderBy(x => x.Name).ToList();

            List<ImageCardModel> lst = new List<ImageCardModel>();
            foreach(var item in list)
            {
                lst.Add(new ImageCardModel() {
                    _img = item.ImagePath,
                    _label = item.Name,
                    _link = Url.Action("Index", "IP", new { FeatureId = FeatureId, CategoryId = item.Id, UserId = UserId})
                });
            }

            CategoryModel model = new CategoryModel() { _lst = lst };
            FillBaseModel(model);

            return View(model);
        }

        public ActionResult FilterIndex(int FeatureId, int? UserId)
        {
            return RedirectToAction("FilterIndex", "IP", new { FeatureId = FeatureId, UserId = UserId});
        }
    }
}