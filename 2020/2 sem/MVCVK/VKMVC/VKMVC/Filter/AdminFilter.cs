using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VKMVC.Filter
{
    public class AdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isAdmin = context.HttpContext.Request.Cookies["Role"];
            if (isAdmin == "User")
                context.Result = new RedirectToActionResult("Index", "Home", null);
            base.OnActionExecuting(context);
        }
    }
}