using IVoice.Helpers.Extensions;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.Common;
using IVoice.Models.ForumAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVoice.Controllers
{
    [RoutePrefix("Forum/Answer")]
    public class ForumAnswerController : CrudForumController
        <Database.ForumAnswer,
         IForumAnswerRepository,
         Create
        >
    {
        protected ITopicRepository TopicRepository;
        protected IForumAnswersAttachRepository ForumAnswersAttachRepository;
        protected IForumAnswerVotesRepository ForumAnswerVotesRepository;
        protected IForumTopicsViewRepository ForumAnswersViewRepository;
        public ForumAnswerController(IUserRepository userRepository,
                                    IForumAnswerRepository forumAnswerRepository,
                                    IForumAnswerVotesRepository forumAnswerVotesRepository,
                                    IForumTopicsViewRepository forumAnswersViewRepository,
                                    ITopicRepository topicRepository,
                                    IUserAttachmentsRepository userAttachmentsRepository,
                                    IForumAnswersAttachRepository forumAnswersAttachRepository) : base(userRepository, userAttachmentsRepository, forumAnswerRepository)
        {
            TopicRepository = topicRepository;
            ForumAnswersAttachRepository = forumAnswersAttachRepository;
            ForumAnswerVotesRepository = forumAnswerVotesRepository;
            ForumAnswersViewRepository = forumAnswersViewRepository;
        }



        [Route("")]
        public ActionResult Index()
        {
            return RedirectPermanent(Url.Action("Index", "Forum"));
        }

        [Route("{id}", Name = "AnswerList")]
        public ActionResult Index(int id)
        {
            var element = TopicRepository.FirstOrDefault(x => x.Id == id);
            if (element == null)
                return Redirect(Url.Action("Index", "Forum"));
            else
            {
                var model = new Index()
                {
                    Answer = "",
                    TopicId = id,
                    TopicName = element.Name,
                    UniqueId = Guid.NewGuid(),
                    AreaId = element.CategoryId,
                    LoggedUserId = _userID
                };
                this.FillBaseModel(model);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create/{id}", Name = "AnswerCreate")]
        public override JsonResult Create(Create model)
        {
            var result = base.Create(model);
            var resultReturn = (result.Data as Message).Text.ToInt();
            if (resultReturn > 0)
            {
                foreach (var item in ForumAnswersAttachRepository.LoadAndSelect(x => x.UsersAttachment.UserId == _userID &&
                                                                                     x.UsersAttachment.UniqueId == model.UniqueId &&
                                                                                    (x.AnswerId == null || x.AnswerId == 0), x => x, false))
                {
                    item.AnswerId = resultReturn;
                    ForumAnswersAttachRepository.Save(item);
                }
            }

            return result;
        }

        [HttpPost]
        public JsonResult GetTableList(int TopicId, DataTableParameters dataTableParameters)
        {
            var url = Url.Action("Topic", "Forum") + "/";
            var list = _crudRepository.GetTableRows(dataTableParameters, _crudRepository.GetSorters(dataTableParameters), x => x.TopicId == TopicId && x.Active, x => new TableRowModel()
            {
                Answer = x.Answer,
                ImageURL = x.User.ImageURL,
                AnswerDate = x.AnswerDate,
                Posts = x.User.TotalForumPosts,
                UserId = x.UserId,
                AnswerId = x.Id,
                Voicer = x.User.Nickname,
                Vote = x.ForumAnswerVotes.FirstOrDefault(y => y.UserId == _userID),
                Attach = x.ForumAnswersAttaches.Where(y => y.UsersAttachment.Active).Select(z => new ForumAnswerAttachModel
                {
                    Id = z.UsersAttachment.Id,
                    FileName = z.UsersAttachment.FileName,
                    Path = z.UsersAttachment.Path
                }).ToList()
            });

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PostActionLike(ForumAnswerVoteModel model)
        {
            var id = ForumAnswerVotesRepository.Save(model.ToEntity());
            if (id > 0)
                return Json(model, JsonRequestBehavior.AllowGet);
            else
                return Json(new Message(TMessage.FALSE), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SetViewPage(int TopicId)
        {
            try
            {
                var id = ForumAnswersViewRepository.Save(new Database.ForumTopicsView
                {
                    TopicId = TopicId,
                    Ip = GetIP,
                    UserId = _userID == 0 ? (int?)null : _userID,
                });
                if (id > 0)
                    return Json(new Message(id.ToString()), JsonRequestBehavior.AllowGet);
            }
            catch { }

            return Json(new Message(TMessage.FALSE), JsonRequestBehavior.AllowGet);
        }

        #region FileUpload
        [HttpPost]
        public override JsonResult FileUpload(int Id, HttpPostedFileBase file, Guid UniqueId)
        {
            var result = base.FileUpload(Id, file, UniqueId);
            var userAttachmentId = (result.Data as Message).Text.ToInt();
            if (userAttachmentId > 0)
            {
                ForumAnswersAttachRepository.Save(new Database.ForumAnswersAttach
                {

                    UserAttachmentId = userAttachmentId,
                });
            }

            return result;
        }


        #endregion
    }
}