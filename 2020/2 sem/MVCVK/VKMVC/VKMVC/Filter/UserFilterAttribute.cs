using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VKMVC.Filter
{
    public class UserFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Cookies.ContainsKey("Username") &&
                !context.HttpContext.Request.Cookies.ContainsKey("Email") &&
                !context.HttpContext.Request.Cookies.ContainsKey("Role"))
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            base.OnActionExecuting(context);
        }
    }
}