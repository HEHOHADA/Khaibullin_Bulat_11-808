using Microsoft.AspNetCore.Authorization;

namespace VKMVC.Filter
{
    public class TimeAccessRequirement : IAuthorizationRequirement
    {
        public int Time = 15;
    }
}