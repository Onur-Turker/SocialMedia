using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.CustomActionFilter
{
    public class CheckLoginAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Session["Id"]==null)
            {
                filterContext.RequestContext.HttpContext.Response.Redirect("/Login/Index");
            }
        }
    }
}