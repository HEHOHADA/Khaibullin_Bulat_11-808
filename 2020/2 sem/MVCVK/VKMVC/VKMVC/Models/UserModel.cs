using System;
using System.Collections.Generic;

namespace VKMVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public List<PostModel> Posts { get; set; }
    }
}