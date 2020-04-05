using System;
using System.Collections.Generic;

namespace VKMVC.Models
{
    public class PostModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public List<CommentModel> Comments { get; set; }
        public DateTime CreateDate { get; set; }
        public UserModel User { get; set; }
    }
}