using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace VKMVC.Models
{
    public class UserModel : IdentityUser
    {
       
        public bool isAdmin { get; set; }

        public List<PostModel> Posts { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}