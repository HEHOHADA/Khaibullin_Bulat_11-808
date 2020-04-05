
using Microsoft.EntityFrameworkCore;
using VKMVC.Models;

namespace VKMVC.DB
{
    public class BloggingContext :DbContext
    {
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<UserModel> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=mvc-vk-server;Username=postgres;Password=bulat551");
    }
}