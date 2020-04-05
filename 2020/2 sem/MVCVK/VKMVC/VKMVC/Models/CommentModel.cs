using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VKMVC.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public UserModel Author { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public PostModel Post { get; set; }
    }
}