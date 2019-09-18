using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using IVoice.Helpers.External;
using IVoice.Interfaces;
using IVoice.Models.Components.Common;
using IVoice.Models.Components.Tabs;
using IVoice.Models.Whisper;
using IVoice.Helpers;
using IVoice.Database;
using static IVoice.Helpers.Constants;
using IVoice.Extensions;
using IVoice.Models.Common;
using IVoice.Helpers.Extensions;
using System.Web;

namespace IVoice.Controllers
{
    public class WhisperController : CrudForumController<Whisper, IWhisperRepository, Create>
    {

        protected IGenericRepository<Database.WhisperAttachment> _whisperAttachmentRepository { get; }
        protected IUsersConnectionRepository _usersConnectionRepository { get; }

        public WhisperController(IUserRepository userRepository, 
                                IUserAttachmentsRepository userAttachmentsRepository, 
                                IWhisperRepository whisperRepository,
                                IGenericRepository<Database.WhisperAttachment> whisperAttachmentRepository,
                                IUsersConnectionRepository usersConnectionRepository) 
            : base(userRepository, userAttachmentsRepository, whisperRepository)
        {
            _whisperAttachmentRepository = whisperAttachmentRepository;
            _usersConnectionRepository = usersConnectionRepository;
        }

        public ActionResult Index(int? id)
        {
            var userId = _userID;
            if(id != null)
            {
                userId = (int)id;
            }

            if(userId != _userID)
            {
                return RedirectToAction("PermissionDenied", "Home");
            }

            CardWhisperModel model = new CardWhisperModel();
            CardHeaderModel inbox_header = new CardHeaderModel() { _label = "Inbox", _class = "active", _link = "#tab_1" };
            CardHeaderModel sent_header = new CardHeaderModel() { _label = "Sent Items", _link = "#tab_2"};
            CardHeaderModel compose = new CardHeaderModel() { _label = "Compose", _icon = "fa fa-comment", _class="pull-right", _link = Url.Action("Create", "Whisper"), _isbutton = true };

            if(userId == _userID)
            {
                model._header = new CardHeaderTabsModel() { _header = new List<CardHeaderModel>() { inbox_header, sent_header, compose } };
            }
            else
            {
                model._header = new CardHeaderTabsModel() { _header = new List<CardHeaderModel>() { inbox_header, sent_header } };
            }

            ColumnModel col_date = new ColumnModel() { _scope = "col", _name = "Date" };
            ColumnModel col_voicer = new ColumnModel() { _scope = "col", _name = "Voicer" };
            ColumnModel col_message = new ColumnModel() { _scope = "col", _name = "Message" };
            ColumnModel col_space = new ColumnModel() { _scope = "col", _class = "col-md-2" };

            CardBodyTableModel inbox_body = new CardBodyTableModel() { _cols = new List<ColumnModel>() { col_date, col_voicer, col_message, col_space }, _class = "active", _html_id = "tab_1" };
            CardBodyTableModel sent_body = new CardBodyTableModel() { _cols = new List<ColumnModel>() { col_date, col_voicer, col_message, col_space }, _html_id = "tab_2" };
            model._body = new CardBodyTabsTableModel() { _body = new List<CardBodyTableModel>() { inbox_body, sent_body } };

            FillBaseModel(model);
            return View(model);
        }

        [HttpPost]
        public JsonResult GetTableList(string Type, DataTableParameters dtParams)
        {
            Expression<Func<Whisper, bool>> filter = x => true;
            Expression<Func<Whisper, WhisperRowModel>> selector = null;

            if(Type == "INBOX")
            {
                filter = x => x.UserReceiverId == this._userID && !x.DeleteReceiver;
                selector = x => new WhisperRowModel()
                {
                    Id = x.Id,
                    Date = x.DateSent,
                    Message = x.Title,
                    VoicerId = x.UserSenderId,
                    VoicerName = x.User1.Nickname
                };

            }
            else if(Type == "SENT")
            {
                filter = x => x.UserSenderId == this._userID && !x.DeleteSender;
                selector = x => new WhisperRowModel()
                {
                    Id = x.Id,
                    Date = x.DateSent,
                    Message = x.Title,
                    VoicerId = x.UserReceiverId,
                    VoicerName = x.User1.Nickname
                };
            }
            var list = _crudRepository.GetTableRows(dtParams, _crudRepository.GetSorters(dtParams), filter, selector);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            DetailViewModel model = new DetailViewModel()
            {
                _entity = _crudRepository.FirstOrDefault(x => x.Id == Id)
            };
            FillBaseModel(model);

            return View(model);
        }

        [HttpGet]
        public override ActionResult Create()
        {
            var model = new Create
            {
                _uniqueId = Guid.NewGuid(),
                _voicers = _usersConnectionRepository.LoadAndSelect(x => x.UserId == _userID && x.Type == VoicerConnectionType.CONNECTED.ToString(),
                                                                    x => new SelectListItem_Custom { Id = x.User1.Id, Description = x.User1.Nickname }, false)
                                                                    .ToSelectList(x => x.Description)
            };

            // need to add whisper active in the future

            FillBaseModel(model);
            return View(model);
        }

        [HttpPost]
        public override JsonResult Create(Create model)
        {
            var result = base.Create(model);
            var resultReturn = (result.Data as Message).Text.ToInt();
            if(resultReturn > 0)
            {
                var attach = _whisperAttachmentRepository.LoadAndSelect(x => x.UsersAttachment.UserId == _userID &&
                                                                            x.UsersAttachment.UniqueId == model._uniqueId &&
                                                                            x.WhisperId == null, x => x, false);
                foreach(var item in attach)
                {
                    item.WhisperId = resultReturn;
                    _whisperAttachmentRepository.Save(item);
                }
            }

            return result;
        }

        [HttpPost]
        public override JsonResult FileUpload(int Id, HttpPostedFileBase file, Guid UniqueId)
        {
            try
            {
                var result = base.FileUpload(Id, file, UniqueId);
                var userAttachmentId = result.Data.ToString().ToInt();
                if (userAttachmentId > 0)
                {
                    _whisperAttachmentRepository.Save(new WhisperAttachment
                    {
                        UserAttachmentId = userAttachmentId,
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Remove(int Id)
        {
            var itemDb = _crudRepository.FirstOrDefault(x => x.Id == Id && (x.UserSenderId == _userID || x.UserReceiverId == _userID));
            if(itemDb != null)
            {
                if (itemDb.UserReceiverId == _userID)
                    itemDb.DeleteReceiver = true;
                else
                    itemDb.DeleteSender = true;

                _crudRepository.Save(itemDb);
            }

            return Json(new Message(TMessage.TRUE), JsonRequestBehavior.AllowGet);
        }
    }
}