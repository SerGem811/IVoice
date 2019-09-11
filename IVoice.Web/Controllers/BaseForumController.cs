using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Interfaces;
using IVoice.Models.Common;
using static IVoice.Helpers.Constants;

namespace IVoice.Controllers
{
    public abstract class BaseForumController : BaseController
    {
        public string _document_path => Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FS_Documents_Forum"].ToString());
        public readonly IUserAttachmentsRepository _userAttachmentsRepository;

        public BaseForumController(IUserRepository userRepository, IUserAttachmentsRepository userAttachmentsRepository) : base(userRepository)
        {
            _userAttachmentsRepository = userAttachmentsRepository;
        }

        // FileUpload
        [HttpPost]
        public virtual JsonResult FileUpload(int Id, HttpPostedFileBase file, Guid UniqueId)
        {
            if(file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName).ToLower();

                var fileName = Path.GetFileName(file.FileName);
                if (!Directory.Exists(_document_path))
                    Directory.CreateDirectory(_document_path);

                if (!Directory.Exists(_document_path + UniqueId))
                    Directory.CreateDirectory(_document_path + UniqueId);

                var path = Path.Combine(_document_path + UniqueId, fileName);
                file.SaveAs(path);

                var id = _userAttachmentsRepository.Save(new Database.UsersAttachment()
                {
                    Active = true,
                    DateAdded = DateTime.Now,
                    FileName = file.FileName,
                    Path = "/upload/" + UniqueId.ToString() + "/" + file.FileName,
                    UserId = this._userID,
                    Visibity = Visibility.PRIVATE.ToString(),
                    UniqueId = UniqueId
                });

                return Json(id, JsonRequestBehavior.AllowGet);
            }
            return Json(new Message(TMessage.FALSE), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult DeleteFile(Guid UniqueId, string FileName)
        {
            var path = Path.Combine(_document_path + UniqueId, FileName);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            var item = _userAttachmentsRepository.FirstOrDefault(x => x.UniqueId == UniqueId && x.UserId == this._userID, x => x, null);
            if(item != null)
            {
                item.Active = false;
                _userAttachmentsRepository.Save(item);
            }
            return Json(new Message(TMessage.TRUE), JsonRequestBehavior.AllowGet);
        }
    }
}