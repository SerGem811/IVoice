using IVoice.Helpers.Extensions;
using System.Web;
using System.Web.Mvc;
namespace IVoice.Attributes
{
    public class LoginAuth : AuthorizeAttribute
    {
        protected string LoginUrl
        {
            get
            {
                return string.Format("~/User/Login");
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return (httpContext.Session["USER_LOGIN"] != null && httpContext.Session["USER_LOGIN"].ToString().ToInt() > 0);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
                return;


            base.OnAuthorization(filterContext);

            if (filterContext.HttpContext.Session["USER_LOGIN"] == null || filterContext.HttpContext.Session["USER_LOGIN"].ToString().ToInt() == 0)
            {
                string redirect = "";
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.RawUrl))
                    redirect = "?returnURL=" + HttpContext.Current.Request.RawUrl;
                filterContext.Result = new RedirectResult(LoginUrl + redirect);

            }
        }
    }
}