using IVoice.Extensions;
using IVoice.Helpers;
using IVoice.Helpers.Extensions;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.Common;
using IVoice.Models.ForumTopic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace IVoice.Controllers
{
    [RoutePrefix("forum/topic")]
    public class ForumTopicController : CrudForumController
        <Database.ForumTopic,
         ITopicRepository,
         Create
        >
    {
        protected ICategoryRepository CategoryRepository;
        protected IForumAnswersAttachRepository ForumAnswersAttachRepository;
        protected IForumAnswerRepository ForumAnswerRepository;
        public ForumTopicController(IUserRepository userRepository,
                                    ITopicRepository topicRepository,
                                    ICategoryRepository categoryRepository,
                                    IForumAnswerRepository forumAnswerRepository,
                                    IUserAttachmentsRepository userAttachmentsRepository,
                                    IForumAnswersAttachRepository forumAnswersAttachRepository) : base(userRepository, userAttachmentsRepository, topicRepository)
        {
            CategoryRepository = categoryRepository;
            ForumAnswersAttachRepository = forumAnswersAttachRepository;
            ForumAnswerRepository = forumAnswerRepository;
        }



        [Route("")]
        public ActionResult Index()
        {
            return RedirectPermanent(Url.Action("Index", "Forum"));
        }

        [Route("{id}", Name = "TopicList")]
        public ActionResult Index(int id)
        {
            var element = CategoryRepository.FirstOrDefault(x => x.Id == id);
            if (element == null)
                return Redirect(Url.Action("Index", "Forum"));
            else
            {
                var model = new Index()
                {
                    AreaId = element.Id,
                    AreaName = element.Name
                };
                this.FillBaseModel(model);
                return View(model);
            }
        }

        [HttpGet]
        [Route("create/{id}", Name = "TopicCreate")]
        public ActionResult Create(int id)
        {
            if (id == 0)
                return Redirect(Url.Action("Index", "Forum"));
            var model = new Create
            {
                UniqueId = Guid.NewGuid(),
                CategoryId = id,
                CategoryList = CategoryRepository.LoadAndSelect(x => true, x => new SelectListItem_Custom { Id = x.Id, Description = x.Name }, false).ToSelectList(x => x.Description)
            };
            this.FillBaseModel(model);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create/{id}", Name = "TopicCreatePost")]
        public override JsonResult Create(Create model)
        {
            var result = base.Create(model);
            var topicId = (result.Data as Message).Text.ToInt();
            if (topicId > 0)
            {
                var answerId = ForumAnswerRepository.Save(model.ToAnswerEntity(_userID, topicId));

                foreach (var item in ForumAnswersAttachRepository.LoadAndSelect(x => x.UsersAttachment.UserId == _userID &&
                                                                                     x.UsersAttachment.UniqueId == model.UniqueId &&
                                                                                    (x.AnswerId == null || x.AnswerId == 0), x => x, false))
                {
                    item.AnswerId = answerId;
                    ForumAnswersAttachRepository.Save(item);
                }
            }

            return result;
        }


        [HttpPost]
        public JsonResult GetTableList(int AreaId, DataTableParameters dataTableParameters)
        {
            var urlTopic = Url.RouteUrl("AnswerList", new { id = 0 });
            urlTopic = urlTopic.Remove(urlTopic.Length - 1);

            Expression<Func<Database.ForumTopic, bool>> filter = null;
            if (AreaId > 0)
                filter = x => x.Active && x.CategoryId == AreaId;
            else
            {
                var searchText = Session["SearchText"].ToString();
                filter = x => x.Active && (x.Name.Contains(searchText) || x.ForumAnswers.Any(y => y.Active && y.Answer.Contains(searchText)));
            }

            var list = _crudRepository.GetTableRows(dataTableParameters, _crudRepository.GetSorters(dataTableParameters), filter, x => new TableRowModel()
            {
                Replies = x.Replies,
                Views = x.Views,
                Voicer = x.User.Nickname,
                TopicDate = x.StartDate,
                TopicName = x.Name,
                TopicURL = urlTopic + x.Id
            });

            return Json(list, JsonRequestBehavior.AllowGet);
        }


        #region FileUpload
        [HttpPost]
        public override JsonResult FileUpload(int Id, HttpPostedFileBase file, Guid UniqueId)
        {
            var result = base.FileUpload(Id, file, UniqueId);

            var userAttachmentId = Convert.ToInt32(result.Data);
            if (userAttachmentId > 0)
            {
                ForumAnswersAttachRepository.Save(new Database.ForumAnswersAttach
                {
                    UserAttachmentId = userAttachmentId
                });
            }

            return result;
        }


        #endregion

        [Route("search", Name = "TopicListSearch")]
        public ActionResult Search()
        {
            if (Session["SearchText"] == null)
                return RedirectToAction("Index", "Forum");

            var model = new SearchModel()
            {
                SearchText = Session["SearchText"].ToString()
            };
            this.FillBaseModel(model);
            return View(model);
        }
    }
}