using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VKMVC.DB;

using VKMVC.Models;

namespace VKMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BloggingContext dataBase;

        public HomeController(ILogger<HomeController> logger, BloggingContext context)
        {
            dataBase = context;
            _logger = logger;
        }

    
        public IActionResult Index()
        {
            var posts = dataBase.Posts.Include(user => user.User).ToList();
            ViewBag.Posts = posts;
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return null;
        }
    }
}