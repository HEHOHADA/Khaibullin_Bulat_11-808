using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VKMVC.DB;
using VKMVC.Filter;
using VKMVC.Models;

namespace VKMVC.Controllers
{
    public class PostController : Controller
    {
        private BloggingContext dataBase;

        public PostController(BloggingContext context)
        {
            dataBase = context;
        }

        [HttpGet]
        [UserFilter]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [UserFilter]
        public async Task<IActionResult> Create(PostModel model)
        {
            var post = await dataBase.Posts.AddAsync(new PostModel
            {
                Name = model.Name, Text = model.Text,
                User =  dataBase.User.FirstOrDefault(u => u.Username == User.Identity.Name),
                CreateDate = DateTime.Now
            });
            await dataBase.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [UserFilter]
        public IActionResult Edit(int id)
        {
            var post = dataBase.Posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                ViewBag.Name = post.Name;
                ViewBag.Text = post.Text;
                ViewBag.Id = post.Id;
            }

            return View();
        }
        
        [HttpPost]
        [UserFilter]
        public async Task<IActionResult> Edit(PostModel model, int id)
        {
            var post = dataBase.Posts.FirstOrDefault(p => p.Id == id);
            if (post != null)
            {
                post.Name = model.Name;
                post.Text = model.Text;
            }
            await dataBase.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


       

        [HttpGet]
        [UserFilter]
        public async Task<IActionResult> Delete(int id)
        {
            dataBase.Posts.Remove(dataBase.Posts.First(p => p.Id == id));
            var comments = dataBase.Comments.Where(c => c.Post.Id == id);
            foreach (var comment in comments)
                dataBase.Comments.Remove(comment);
            await dataBase.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}