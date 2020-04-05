using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VKMVC.DB;
using VKMVC.Filter;
using VKMVC.Models;
using VKMVC.ViewModels;

namespace VKMVC.Controllers
{
    public class CommentController : Controller
    {
        private BloggingContext dataBase;
        private IAuthorizationService authorizationService;

        public CommentController(BloggingContext context, IAuthorizationService authorizationService)
        {
            dataBase = context;
            this.authorizationService = authorizationService;
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var comments = dataBase.Comments
                .Where(c => c.Post.Id == dataBase.Posts
                    .FirstOrDefault(t => t.Id == id).Id)
                .ToList();
            ViewBag.Comments = comments;
            ViewBag.PostId = id;
            return View();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.PostId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentModel model, int id)
        {
            var post = await dataBase.Posts.FindAsync(id);
            var user = await dataBase.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            await dataBase.Comments.AddAsync(new CommentModel
            {
                Author = user,
                CreateDate = DateTime.Now,
                Text = model.Text,
                Post = post
            });

            await dataBase.SaveChangesAsync();
            return RedirectToAction("View", "Comment", new {id = id});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var comment = dataBase.Comments.FirstOrDefault(c => c.Id == id);
            var timeCheck = await authorizationService.AuthorizeAsync(User, comment, "CommentEditTime");
            if (timeCheck.Succeeded)
            {
                ViewBag.Text = comment.Text;
                ViewBag.CommentId = comment.Id;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommentModel model, int id)
        {
            var comment = dataBase.Comments
                .FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                comment.Text = model.Text;
                var postId = comment.Post.Id;
                await dataBase.SaveChangesAsync();
                return RedirectToAction("View", "Comment", new {id = postId});
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = dataBase.Comments.Include(c => c.Post)
                .FirstOrDefault(c => c.Id == id);
            var postId = comment.Post.Id;
            dataBase.Comments.Remove(comment);
            await dataBase.SaveChangesAsync();
            return RedirectToAction("View", "Comment", new {id = postId});
        }
    }
}