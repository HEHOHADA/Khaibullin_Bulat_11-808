using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VKMVC.Filter
{
    public class UserFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(
                context.HttpContext.User);
            if(!context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            base.OnActionExecuting(context);
        }
    }
}