using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Interfaces;
using IVoice.Database;
using IVoice.Helpers.External;
using IVoice.Models.Forum;

namespace IVoice.Controllers
{
    public class ForumController : CrudForumController<Category, ICategoryRepository, Create>
    {
        public ForumController(IUserRepository userRepository, ICategoryRepository categoryRepository) : base(userRepository, null, categoryRepository)
        {
        }


        public ActionResult Index()
        {
            return View(ReturnBaseModel());
        }

        public ActionResult Area(int Id)
        {
            return View(ReturnBaseModel());
        }

        [HttpPost]
        public JsonResult GetTableList(DataTableParameters dataTableParameters)
        {

            var urlArea = Url.RouteUrl("TopicList", new { id = 0 });
            urlArea = urlArea.Remove(urlArea.Length - 1);

            var list = _crudRepository.GetTableRows(dataTableParameters, _crudRepository.GetSorters(dataTableParameters), x => x.Active, x => new TableRowModel()
            {
                Id = x.Id,
                AreaUrl = urlArea + x.Id,
                Description = x.Description,
                Name = x.Name,
                Posts = x.Posts,
                Voicer = x.User1 != null ? x.User1.Nickname : "",
                Topics = x.Topics,
                LastTopicName = x.ForumTopic.Name != null ? x.ForumTopic.Name : "",
                LastTopicDate = x.LastDate,
                LastTopicId = x.LastTopicId
            });

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}