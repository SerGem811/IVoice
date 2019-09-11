using IVoice.Attributes;
using IVoice.Helpers;
using IVoice.Interfaces;
using IVoice.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVoice.Controllers
{
    [LoginAuth]
    public abstract class CrudForumController<TEntity, ICrudRepository, ICrudModel> : BaseForumController
        where TEntity : class, IEntityBase
        where ICrudRepository : IGenericRepository<TEntity>
        where ICrudModel : ICrudModel<TEntity>
    {
        public readonly ICrudRepository _crudRepository;
        public CrudForumController(IUserRepository userRepository, IUserAttachmentsRepository userAttachmentsRepository, ICrudRepository crudRepository) 
            : base(userRepository, userAttachmentsRepository)
        {
            _crudRepository = crudRepository;
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(ReturnBaseModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual JsonResult Create(ICrudModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.IsValid())
                {
                    var id = _crudRepository.Save(model.ToEntity(_userID, null));
                    if (id > 0)
                        return Json(new Message(id.ToString()), JsonRequestBehavior.AllowGet);
                    else
                        return Json(new Message(TMessage.FALSE), JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new Message(TMessage.FALSE), JsonRequestBehavior.AllowGet);
            }
            return Json(new Message(TMessage.FALSE), JsonRequestBehavior.AllowGet);
        }
    }
}