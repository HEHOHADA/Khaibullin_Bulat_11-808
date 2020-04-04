using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VKMVC.DB;
using VKMVC.Models;
using VKMVC.ViewModels;

namespace VKMVC.Controllers
{
    public class AuthController : Controller
    {
        private BloggingContext dataBase;

        public AuthController(BloggingContext context)
        {
            dataBase = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await dataBase.User.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Почты не существует. Попробуйте заново или зарегестрируйтесь");
                }
                else if (user.Password != model.Password)
                {
                    ModelState.AddModelError("", "Пароль не совпадает. Попробуйте снова");
                }
                else
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] {grandmaIdentity});
                    await HttpContext.SignInAsync(userPrincipal);

                    return RedirectToAction("Index", "Home");
                }
            }
            else
                ModelState.AddModelError("", "Что-то пошло не так");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = await dataBase.User.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user != null)
                {
                    ModelState.AddModelError("", "Вы уже зарегестрированны");
                }
                else if (model.Email == "bulat1@yandex.ru")
                {
                    await dataBase.User.AddAsync(new UserModel
                        {Username = model.UserName, Password = model.Password, Email = model.Email, isAdmin = true});
                    await dataBase.SaveChangesAsync();
                }
                else
                {
                    await dataBase.User.AddAsync(new UserModel
                        {Username = model.UserName, Password = model.Password, Email = model.Email, isAdmin = false});
                    await dataBase.SaveChangesAsync();
                }

                return RedirectPermanent("Login");
            }
            else
                ModelState.AddModelError("", "Что-то пошло не так");


            return View();
        }

        public async
            Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}