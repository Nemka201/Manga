using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace Manga.Attributes
{
    public class SessionCheckAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("admin") == null)
            {
                filterContext.Result = new RedirectResult("~/Usuarios/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
