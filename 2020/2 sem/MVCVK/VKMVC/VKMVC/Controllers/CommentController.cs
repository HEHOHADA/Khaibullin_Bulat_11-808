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

        public CommentController(BloggingContext context)
        {
            dataBase = context;
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
            await dataBase.Comments.AddAsync(new CommentModel
            {
                Author = await dataBase.User.FirstOrDefaultAsync(u => u.Email == User.Identity.Name),
                CreateDate = DateTime.Now,
                Text = model.Text,
                Post = dataBase.Posts.FirstOrDefault(p => p.Id == id)
            });

            await dataBase.SaveChangesAsync();
            return RedirectToAction("View", "Comment", new {id = id});
        }

        [HttpGet]
        [Admin]
        public IActionResult Edit(int id)
        {
            var comment = dataBase.Comments.FirstOrDefault(c => c.Id == id);
            ViewBag.Text = comment.Text;
            ViewBag.CommentId = comment.Id;
            return View();
        }

        [HttpPost]
        [Admin]
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
        public IActionResult Delete(int id)
        {
            var comment = dataBase.Comments
                .FirstOrDefault(c => c.Id == id);
            var postId = comment.Post.Id;
            dataBase.Comments.Remove(comment);
            dataBase.SaveChanges();
            return RedirectToAction("View", "Comment", new {id = postId});
        }
    }
}