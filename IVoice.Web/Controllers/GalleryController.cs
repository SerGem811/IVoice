using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IVoice.Attributes;
using IVoice.Database;
using IVoice.Helpers;
using IVoice.Helpers.Extensions;
using IVoice.Interfaces;
using IVoice.Models.Common;
using IVoice.Models.Gallery;
using static IVoice.Helpers.Constants;

namespace IVoice.Controllers
{
    [LoginAuth]
    public class GalleryController : BaseController
    {
        public string _galleryPath => Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["FS_USER_GALLERY_PATH"].ToString());
        protected IGenericRepository<UsersAttachmentsAlbum> _userAttachmentsAlbumRepository { get; }
        protected IGenericRepository<UsersAttachment> _usersAttachmentRepository { get; }

        public GalleryController(IUserRepository userRepository,
                                IGenericRepository<UsersAttachmentsAlbum> userAttachmentsAlbumRepository,
                                IGenericRepository<UsersAttachment> usersAttachmentRepository) : base(userRepository)
        {
            _userAttachmentsAlbumRepository = userAttachmentsAlbumRepository;
            _usersAttachmentRepository = usersAttachmentRepository;
        }

        public ActionResult Index(int? id, int? secondid)
        {
            GalleryViewModel model = new GalleryViewModel();
            int userID = _userID;
            if (id != null)
                userID = (int)id;

            int AlbumId = -1;
            if (secondid != null)
                AlbumId = (int)secondid;

            // check accessibility
            if(userID != _userID)
            {
                var user = _userRepository.FirstOrDefault(x => x.Id == userID, x => x);
                if (user == null || !user.ActiveGallery || !user.isPublic)
                {
                    // direct error page
                    return RedirectToAction("PermissionDenied", "Home");
                }
            }

            if (AlbumId > 0)
            {
                model._current = _userAttachmentsAlbumRepository.LoadAndSelect(x => x.UserId == userID && x.Id == AlbumId,
                                                                                x => new SelectListItem_Custom() { Id = x.Id, Description = x.Name }, false).FirstOrDefault();
            }
            else
            {
                model._current = new SelectListItem_Custom() { Id = 0, Description = "ROOT" };
            }

            var folders = _userAttachmentsAlbumRepository.LoadAndSelect(x => x.Active && x.UserId == userID && x.ParentId == AlbumId,
                            x => new GalleryItemModel() { _id = x.Id, _name = x.Name, _date_add = x.Created, _type = "Folder", _visibility = x.Visibility, _path = x.Cover }, false);
            var media = _usersAttachmentRepository.LoadAndSelect(x => x.Active && x.UserId == userID && x.UserAttachAlbumId == AlbumId,
                            x => new GalleryItemModel() { _id = x.Id, _name = x.FileName, _visibility = x.Visibity, _date_add = x.DateAdded, _type = "Media", _path = x.Path }, false);
            var items = folders.Union(media).ToList();

            model._folders = _userAttachmentsAlbumRepository.LoadAndSelect(x => x.Active && x.UserId == userID,
                                                                        x => new SelectListItem_Custom() { Id = x.Id, Description = x.Name }, false);

            var vitems = new List<GalleryCardModel>();
            foreach (var item in items)
            {
                var vitem = new GalleryCardModel();
                vitem._truncate = Extension.Truncate(item._name, 15);
                if ((item._path == null || item._path == "") && item._type == "Folder")
                    item._path = "/Images/common/folder.png";
                vitem._item = item;
                vitem._folders = model._folders;
                vitems.Add(vitem);
                if(item._type == "Folder")
                    vitem._class += " box-album";
            }

            model._items = vitems;

            model._path = new List<SelectListItem_Custom>();
            int? idF = AlbumId;
            while (idF != null)
            {
                var path = _userAttachmentsAlbumRepository.LoadAndSelect(x => x.Active && x.UserId == userID && x.Id == (int)idF,
                                                                            x => new SelectListItem_Custom() { Id = x.Id, Description = x.Name }, false).FirstOrDefault();
                if(path != null)
                {
                    model._path.Insert(0, path);
                }
                idF = _userAttachmentsAlbumRepository.FirstOrDefault(x => x.UserId == userID && x.Id == idF, x => x.ParentId, null);
            }

            ViewBag.userId = _userID;
            ViewBag.currentUserId = userID;
            ViewBag.albumId = AlbumId;
            
            FillBaseModel(model);
            return View(model);
        }

        [HttpPost]
        public JsonResult SetVisibility(int Id, string Type, string Visibility)
        {
            if (Type.ToUpper() == "FOLDER")
            {
                var item = _userAttachmentsAlbumRepository.FirstOrDefault(x => x.Id == Id, x => x, null);
                if (item != null)
                {
                    item.Visibility = Visibility;
                    _userAttachmentsAlbumRepository.Save(item);
                }
            }
            else
            {
                var item = _usersAttachmentRepository.FirstOrDefault(x => x.Id == Id, x => x, null);
                if (item != null)
                {
                    item.Visibity = Visibility;
                    _usersAttachmentRepository.Save(item);
                }
            }

            return Json(new Message(TMessage.TRUE), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadMedia(HttpPostedFileBase file, Guid UniqueId, int? AlbumId, string type)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    var fileName = UniqueId + "_" + Path.GetFileName(file.FileName);
                    if (!Directory.Exists(_galleryPath))
                        Directory.CreateDirectory(_galleryPath);
                    if (!Directory.Exists(_galleryPath + @"\" + _userID))
                        Directory.CreateDirectory(_galleryPath + @"\" + _userID);

                    if (type == "cover")
                    {
                        if (!Directory.Exists(_galleryPath + @"\" + _userID + @"\cover"))
                            Directory.CreateDirectory(_galleryPath + @"\" + _userID + @"\cover");
                    }

                    var path = Path.Combine(_galleryPath + @"\" + _userID, fileName);

                    if (type == "cover")
                    {
                        path = Path.Combine(_galleryPath + @"\" + _userID + @"\cover", fileName);
                    }
                    file.SaveAs(path);

                    if (AlbumId < 1)
                        AlbumId = null;

                    var id = -1;
                    if (type != "cover")
                    {
                        id = _usersAttachmentRepository.Save(new UsersAttachment()
                        {
                            Active = true,
                            DateAdded = DateTime.Now,
                            FileName = file.FileName,
                            Path = "/upload/gallery/" + _userID + "/" + fileName,
                            UserId = _userID,
                            Visibity = Visibility.PRIVATE.ToString(),
                            UniqueId = UniqueId,
                            UserAttachAlbumId = AlbumId
                        });
                    }
                    else
                    {
                        var album = _userAttachmentsAlbumRepository.FirstOrDefault(x => x.Id == AlbumId);
                        album.Cover = "/upload/gallery/" + _userID + "/cover/" + fileName;
                        _userAttachmentsAlbumRepository.Save(album);
                    }

                    return Json(new Message(TMessage.TRUE), JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json("Failed", JsonRequestBehavior.AllowGet);
            }
            
            return Json("Failed", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateAlbum(int path, string album)
        {
            var al = _userAttachmentsAlbumRepository.LoadAndSelect(x => x.UserId == _userID && x.Name == album, x => x, true).FirstOrDefault();
            if (al == null)
            {
                _userAttachmentsAlbumRepository.Save(new UsersAttachmentsAlbum()
                {
                    Created = DateTime.Now,
                    Name = album,
                    ParentId = path == 0 ? (int?)null : path,
                    UserId = _userID,
                    Visibility = "PRIVATE",
                    Active = true,
                });

                return Json(new Message(TMessage.TRUE), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new Message(TMessage.FALSE), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult MoveMedia(string op, int toId, int id, string type)
        {
            if (op == "DELETE")
            {
                if (type.ToUpper() == "FOLDER")
                {
                    var item = _userAttachmentsAlbumRepository.FirstOrDefault(x => x.Id == id, x => x, null);
                    item.Active = false;
                    _userAttachmentsAlbumRepository.Save(item);
                }
                else
                {
                    var item = _usersAttachmentRepository.FirstOrDefault(x => x.Id == id, x => x, null);
                    item.Active = false;
                    _usersAttachmentRepository.Save(item);
                }
            }
            else if (id != toId)
            {
                if (type.ToUpper() == "FOLDER")
                {
                    var item = _userAttachmentsAlbumRepository.FirstOrDefault(x => x.Id == id, x => x, null);
                    item.ParentId = (toId == 0) ? (int?)null : toId;
                    _userAttachmentsAlbumRepository.Save(item);
                }
                else
                {
                    var item = _usersAttachmentRepository.FirstOrDefault(x => x.Id == id, x => x, null);
                    item.UserAttachAlbumId = (toId == 0) ? (int?)null : toId;
                    _usersAttachmentRepository.Save(item);
                }
            }

            return Json(new Message(TMessage.TRUE), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public RedirectResult ViewMedia(int id)
        {
            var item = _usersAttachmentRepository.FirstOrDefault(x => x.Id == id, x => x, null);
            if (item == null)
                return Redirect(Url.Action("gallery", "user"));
            else
                return Redirect(item.Path);
        }


    }
}