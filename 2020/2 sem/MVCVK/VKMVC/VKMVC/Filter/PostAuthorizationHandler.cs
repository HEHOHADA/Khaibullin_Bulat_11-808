using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using VKMVC.Models;

namespace VKMVC.Filter
{
    public class PostAuthorizationHandler : AuthorizationHandler<TimeAccessRequirement, PostModel>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            TimeAccessRequirement requirement, PostModel resource)
        {
            if ((DateTime.Now - resource.CreateDate).Minutes <= requirement.Time)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}