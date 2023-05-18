using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Manga.Attributes
{
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("username") == null)
            {
                filterContext.Result = new RedirectResult("~/Usuarios/Login");
                // Guardamos path para el redirect
                filterContext.HttpContext.Session.SetString("redirect", filterContext.HttpContext.Request.Path);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
